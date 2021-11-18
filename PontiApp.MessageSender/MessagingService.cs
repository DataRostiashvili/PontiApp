using System;
using System.Collections.Generic;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http;

namespace PontiApp.MessageSender
{
    public class MessagingService
    {
        private readonly IConfiguration Configuration;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<MessagingService> _logger;
        private readonly ConnectionFactory _factory;
        public IConnection Conn { get; set; }
        public IModel Channel { get; set; }
        public MessagingService(ConnectionFactory factory, IConfiguration _Configuration, IHttpClientFactory clientFactory, ILogger<MessagingService> logger)
        {
            _logger = logger;
            Configuration = _Configuration;
            _factory = factory;
            _clientFactory = clientFactory;


            var rabbitconfig = Configuration.GetSection("RabbitMQ");
            _factory.HostName = rabbitconfig.GetSection("HostName").Value;
            _factory.UserName = rabbitconfig.GetSection("UserName").Value;
            _factory.Password = rabbitconfig.GetSection("PassWord").Value;
            _factory.VirtualHost = rabbitconfig.GetSection("VirtualHost").Value;
            _factory.Port = Convert.ToInt32(rabbitconfig.GetSection("Port").Value);
            Conn = factory.CreateConnection();
            Channel = Conn.CreateModel();
            _logger.LogInformation($"Application Started at {DateTime.Now}");
        }
        public async Task SendUpdateMessage(string guid, IFormFileCollection files)
        {
            var BytesList = await files.GetBytes();
            var dict = new Dictionary<string, object>();
            dict.Add(RabbitMQConsts.GUID, guid);
            dict.Add(RabbitMQConsts.LIST, BytesList);
            var body = dict.GetJsonBytes();
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.UPDATE_ADD_Q, null, body);
            _logger.LogInformation($"Sent Image to the update(Adding to the existing data) command at {DateTime.Now}"); //add more info?

        }

        public void SendUpdateMessage(string guid, int[] indices)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(RabbitMQConsts.GUID, guid);
            dict.Add(RabbitMQConsts.INDICES, indices);
            var body = dict.GetJsonBytes();
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.UPDATE_REMOVE_Q, null, body);
            _logger.LogInformation($"Sent Image to the update(Deleting from existing data) command at {DateTime.Now}");
        }
        public async Task SendAddMessage(string guid, IFormFileCollection files)
        {
            var BytesList = await files.GetBytes();
            var dict = new Dictionary<string, object>();
            dict.Add(RabbitMQConsts.GUID, guid);
            dict.Add(RabbitMQConsts.LIST, BytesList);
            var body = dict.GetJsonBytes();
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.ADD_Q, null, body);
            _logger.LogInformation($"Sent Image to the Add command at {DateTime.Now}");
        }
        public void SendDeleteMessage(string guid)
        {
            var dict = new Dictionary<string, string>();
            dict.Add(RabbitMQConsts.GUID, guid);
            var body = dict.GetJsonBytes();
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.DELETE_Q, null, body);
            _logger.LogInformation($"Sent Image to the Delete command at {DateTime.Now}");
        }

        public async Task SendAddMessage(string guid, string url)
        {

            var client = _clientFactory.CreateClient("Facebook");
            var image = await client.GetByteArrayAsync(url);
            var list = new List<byte[]>()
            {
                image
            };
            var dict = new Dictionary<string, object>();
            dict.Add(RabbitMQConsts.GUID, guid);
            dict.Add(RabbitMQConsts.LIST, list);
            var body = dict.GetJsonBytes();
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.ADD_Q, null, body);
            _logger.LogInformation($"Sent Image to the Add command at {DateTime.Now}");

        }


    }
}
