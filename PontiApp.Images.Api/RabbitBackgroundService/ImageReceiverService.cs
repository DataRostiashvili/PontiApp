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

namespace PontiApp.Images.Api.RabbitBackgroundService
{
    public class ImageReceiverService : BackgroundService
    {
        private readonly IServiceProvider _service;
        private readonly IConnection _conn;
        private readonly IModel _channel;
        private readonly IMongoService mongoService;
        private readonly ConnectionFactory _cFac;
        public ImageReceiverService(IServiceProvider service,ConnectionFactory cFac)
        {
            _service = service;
            using(var scope = service.CreateScope())
            {
                mongoService = scope.ServiceProvider.GetRequiredService<IMongoService>();
            }
            _cFac = cFac;
            _cFac.HostName = "localhost";
            _cFac.UserName = "guest";
            _cFac.Password = "guest";
            _cFac.Port = 5672;
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
            _channel.BasicConsume("Update.Add", true, updateAddConsumer);
            _channel.BasicConsume("Update.Remove", true, updateRemoveBasicConsumer);
            _channel.BasicConsume("Add", true, addConsumer);
            _channel.BasicConsume("Delete", true, addConsumer);
            return Task.CompletedTask;
        }


        private async void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var jsonStr = Encoding.UTF8.GetString(body);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonStr);
            switch (e.RoutingKey){
                case "Update.Add":
                    await mongoService.UpdateImage((string)dict["Guid"],JsonConvert.DeserializeObject<List<byte[]>>(Convert.ToString(dict["Indices"])));
                    break;
                case "Update.Remove":
                    await mongoService.UpdateImage((string)dict["Guid"], JsonConvert.DeserializeObject<int[]>(Convert.ToString(dict["Indices"])));
                    break;
                case "Add":
                    await mongoService.PostImage((string)dict["Guid"],JsonConvert.DeserializeObject<List<byte[]>>(Convert.ToString(dict["BytesList"])));
                    break;
                case "Delete":
                    await mongoService.DeleteImage((string)dict["Guid"]);
                    break;
            }
        }
    }
}
