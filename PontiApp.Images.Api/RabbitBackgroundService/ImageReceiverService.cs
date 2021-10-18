using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PontiApp.Images.Services.Generic_Services;
using PontiApp.MessageSender;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PontiApp.Images.Api.RabbitBackgroundService
{
    public class ImageReceiverService : BackgroundService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<ImageReceiverService> _logger;
        private readonly IServiceProvider _service;
        private readonly IConnection _conn;
        private readonly IModel _channel;
        private readonly IMongoService mongoService;
        private readonly ConnectionFactory _cFac;
        public ImageReceiverService (IServiceProvider service,ConnectionFactory cFac,ILogger<ImageReceiverService> logger,
            IConfiguration config)
        {
            _config = config;
            _logger = logger;
            _service = service;
            using (var scope = service.CreateScope())
            {
                mongoService = scope.ServiceProvider.GetRequiredService<IMongoService>();
            }
            _cFac = cFac;
            _cFac.HostName = _config.GetSection("RabbitMQ").GetSection("HostName").Value;
            _cFac.UserName = _config.GetSection("RabbitMQ").GetSection("UserName").Value;
            _cFac.Password = _config.GetSection("RabbitMQ").GetSection("PassWord").Value;;
            _cFac.Port = Convert.ToInt16(_config.GetSection("RabbitMQ").GetSection("Port").Value);
            ;
            _conn = _cFac.CreateConnection();
            _channel = _conn.CreateModel();
            InitRabbit();
        }

        protected override Task ExecuteAsync (CancellationToken stoppingToken)
        {
            //Register events
            var consummer = new EventingBasicConsumer(_channel);

            //Subscribe
            consummer.Received += Consumer_Received;
            
            //Consume
            _channel.BasicConsume(RabbitMQConsts.UPDATE_ADD_Q,true,consummer);
            _channel.BasicConsume(RabbitMQConsts.UPDATE_REMOVE_Q,true,consummer);
            _channel.BasicConsume(RabbitMQConsts.ADD_Q,true,consummer);
            _channel.BasicConsume(RabbitMQConsts.DELETE_Q,true,consummer);
            return Task.CompletedTask;
        }

        private async void Consumer_Received (object sender,BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var jsonStr = Encoding.UTF8.GetString(body);
            var dict = JsonConvert.DeserializeObject<Dictionary<string,object>>(jsonStr);
            switch (e.RoutingKey)
            {
                case RabbitMQConsts.UPDATE_ADD_Q:
                    await mongoService.UpdateImage((string) dict[RabbitMQConsts.GUID],JsonConvert.DeserializeObject<List<byte[]>>(Convert.ToString(dict[RabbitMQConsts.LIST])));
                    _logger.LogInformation($"Message consumder from {RabbitMQConsts.UPDATE_ADD_Q} queue at {DateTime.Now}");
                    break;
                case RabbitMQConsts.UPDATE_REMOVE_Q:
                    await mongoService.UpdateImage((string) dict[RabbitMQConsts.GUID],JsonConvert.DeserializeObject<int[]>(Convert.ToString(dict[RabbitMQConsts.INDICES])));
                    _logger.LogInformation($"Message consumder from {RabbitMQConsts.UPDATE_REMOVE_Q} queue at {DateTime.Now}");
                    break;
                case RabbitMQConsts.ADD_Q:
                    await mongoService.PostImage((string) dict[RabbitMQConsts.GUID],JsonConvert.DeserializeObject<List<byte[]>>(Convert.ToString(dict[RabbitMQConsts.LIST])));
                    _logger.LogInformation($"Message consumder from {RabbitMQConsts.ADD_Q} queue at {DateTime.Now}");
                    break;
                case RabbitMQConsts.DELETE_Q:
                    await mongoService.DeleteImage((string) dict[RabbitMQConsts.GUID]);
                    _logger.LogInformation($"Message consumder from {RabbitMQConsts.DELETE_Q} queue at {DateTime.Now}");
                    break;
            }
        }

        private void InitRabbit ()
        {
            _channel.ExchangeDeclare(RabbitMQConsts.EXCHANGE,ExchangeType.Direct,true,true);
            _channel.QueueDeclare(RabbitMQConsts.ADD_Q,true,autoDelete: true);
            _channel.QueueDeclare(RabbitMQConsts.DELETE_Q,true,autoDelete: true);
            _channel.QueueDeclare(RabbitMQConsts.UPDATE_ADD_Q,true,autoDelete: true);
            _channel.QueueDeclare(RabbitMQConsts.UPDATE_REMOVE_Q,true,autoDelete: true);
            _channel.QueueBind(RabbitMQConsts.ADD_Q,RabbitMQConsts.EXCHANGE,RabbitMQConsts.ADD_Q);
            _channel.QueueBind(RabbitMQConsts.DELETE_Q,RabbitMQConsts.EXCHANGE,RabbitMQConsts.DELETE_Q);
            _channel.QueueBind(RabbitMQConsts.UPDATE_ADD_Q,RabbitMQConsts.EXCHANGE,RabbitMQConsts.UPDATE_ADD_Q);
            _channel.QueueBind(RabbitMQConsts.UPDATE_REMOVE_Q,RabbitMQConsts.EXCHANGE,RabbitMQConsts.UPDATE_REMOVE_Q);
        }
    }
}
