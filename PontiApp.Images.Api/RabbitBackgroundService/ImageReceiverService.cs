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
        public ImageReceiverService(IServiceProvider service)
        {
            _service = service;
            using(var scope = service.CreateScope())
            {
                mongoService = scope.ServiceProvider.GetRequiredService<IMongoService>();
            }
            var fac = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                Port = 5672
            };
            _conn = fac.CreateConnection();
            _channel = _conn.CreateModel();
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var delConsumer = new EventingBasicConsumer(_channel);
            var addConsumer = new EventingBasicConsumer(_channel);
            var updateAddConsumer = new EventingBasicConsumer(_channel);
            var updateRemoveBasicConsumer = new EventingBasicConsumer(_channel);
            delConsumer.Received += Consumer_Received;
            addConsumer.Received += Consumer_Received;
            updateAddConsumer.Received += Consumer_Received;
            updateRemoveBasicConsumer.Received += Consumer_Received;
            _channel.BasicConsume("Update.Add", true, updateAddConsumer);
            _channel.BasicConsume("Update.Remove", true, updateRemoveBasicConsumer);
            _channel.BasicConsume("Add", true, addConsumer);
            _channel.BasicConsume("Delete", true, addConsumer);
        }


        private async void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var jsonStr = Encoding.UTF8.GetString(body);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonStr);
            switch (e.RoutingKey){
                case "Update.Add":
                    await mongoService.UpdateImage((string)dict["Guid"],(List<byte[]>)dict["BytesList"]);
                    break;
                case "Update.Remove":
                    await mongoService.UpdateImage((string)dict["Guid"], (int[])dict["indices"]);
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
