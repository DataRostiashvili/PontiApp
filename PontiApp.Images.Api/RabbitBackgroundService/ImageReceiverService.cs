using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using RabbitMQ.Client;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using PontiApp.Models.MongoSchema;
using System.Text;
using PontiApp.Images.Services.Generic_Services;
using Microsoft.Extensions.DependencyInjection;
using PontiApp.MessageSender;
using Microsoft.Extensions.Logging;

namespace PontiApp.Images.Api.RabbitBackgroundService
{
    public class ImageReceiverService : BackgroundService
    {
        private readonly ILogger<ImageReceiverService>  _logger;
        private readonly IServiceProvider _service;
        private readonly IConnection _conn;
        private readonly IModel _channel;
        private readonly IMongoService mongoService;
        private readonly ConnectionFactory _cFac;
        public ImageReceiverService(IServiceProvider service,ConnectionFactory cFac,ILogger<ImageReceiverService> logger)
        {
            _logger = logger;
            _service = service;
            using(var scope = service.CreateScope())
            {
                mongoService = scope.ServiceProvider.GetRequiredService<IMongoService>();
            }
            _cFac = cFac;
            _cFac.HostName = RabbitMQConsts.HOSTNAME;
            _cFac.UserName = RabbitMQConsts.USERNAME;
            _cFac.Password = RabbitMQConsts.PASSWORD;
            _cFac.Port = RabbitMQConsts.PORT;
            _conn = _cFac.CreateConnection();
            _channel = _conn.CreateModel();
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //Register events
            var delConsumer = new EventingBasicConsumer(_channel);
            var addConsumer = new EventingBasicConsumer(_channel);
            var updateAddConsumer = new EventingBasicConsumer(_channel);
            var updateRemoveBasicConsumer = new EventingBasicConsumer(_channel);

            //Subscribe
            delConsumer.Received += Consumer_Received;
            addConsumer.Received += Consumer_Received;
            updateAddConsumer.Received += Consumer_Received;
            updateRemoveBasicConsumer.Received += Consumer_Received;

            //Consume
            _channel.BasicConsume(RabbitMQConsts.UPDATE_ADD_Q, true, updateAddConsumer);
            _channel.BasicConsume(RabbitMQConsts.UPDATE_REMOVE_Q, true, updateRemoveBasicConsumer);
            _channel.BasicConsume(RabbitMQConsts.ADD_Q, true, addConsumer);
            _channel.BasicConsume(RabbitMQConsts.DELETE_Q, true, delConsumer);
            return Task.CompletedTask;
        }


        private async void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var jsonStr = Encoding.UTF8.GetString(body);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonStr);
            switch (e.RoutingKey){
                case RabbitMQConsts.UPDATE_ADD_Q:
                    await mongoService.UpdateImage((string)dict[RabbitMQConsts.GUID],JsonConvert.DeserializeObject<List<byte[]>>(Convert.ToString(dict[RabbitMQConsts.LIST])));
                    _logger.LogInformation($"Message consumder from {RabbitMQConsts.UPDATE_ADD_Q} queue at {DateTime.Now}");
                    break;
                case RabbitMQConsts.UPDATE_REMOVE_Q:
                    await mongoService.UpdateImage((string)dict[RabbitMQConsts.GUID], JsonConvert.DeserializeObject<int[]>(Convert.ToString(dict[RabbitMQConsts.INDICES])));
                    _logger.LogInformation($"Message consumder from {RabbitMQConsts.UPDATE_REMOVE_Q} queue at {DateTime.Now}");
                    break;
                case RabbitMQConsts.ADD_Q:
                    await mongoService.PostImage((string)dict[RabbitMQConsts.GUID],JsonConvert.DeserializeObject<List<byte[]>>(Convert.ToString(dict[RabbitMQConsts.LIST])));
                    _logger.LogInformation($"Message consumder from {RabbitMQConsts.ADD_Q} queue at {DateTime.Now}");
                    break;
                case RabbitMQConsts.DELETE_Q:
                    await mongoService.DeleteImage((string)dict[RabbitMQConsts.GUID]);
                    _logger.LogInformation($"Message consumder from {RabbitMQConsts.DELETE_Q} queue at {DateTime.Now}");
                    break;
            }
        }
    }
}
