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

namespace PontiApp.MessageSender
{
    public class MessagingService
    {
        private readonly IConfiguration _config;
        private readonly ConnectionFactory _factory;
        private readonly ILogger<MessagingService> _logger;
        public IConnection Conn { get; set; }
        public IModel Channel { get; set; }
        public MessagingService (IConfiguration config,ILogger<MessagingService> logger,ConnectionFactory factory)
        {
            _config = config;
            _factory = factory;
            _logger = logger;
            _factory.HostName = _config.GetSection("RabbitMQ").GetSection("HostName").Value;
            _factory.UserName = _config.GetSection("RabbitMQ").GetSection("UserName").Value;
            _factory.Password = _config.GetSection("RabbitMQ").GetSection("PassWord").Value;
            _factory.Port = Convert.ToInt16(_config.GetSection("RabbitMQ").GetSection("Port").Value);
            Conn = factory.CreateConnection();
            Channel = Conn.CreateModel();
        }
        public async Task SendUpdateMessage (string guid,IFormFileCollection files)
        {
            var BytesList = await files.GetBytes();
            var dict = new Dictionary<string,object>();
            dict.Add(RabbitMQConsts.GUID,guid);
            dict.Add(RabbitMQConsts.LIST,BytesList);
            var body = dict.GetJsonBytes();
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE,RabbitMQConsts.UPDATE_ADD_Q,null,body);
            _logger.LogInformation($"Message sent to {RabbitMQConsts.UPDATE_ADD_Q} at {DateTime.Now}");
        }

        public void SendUpdateMessage (string guid,int[] indices)
        {
            var dict = new Dictionary<string,object>();
            dict.Add(RabbitMQConsts.GUID,guid);
            dict.Add(RabbitMQConsts.INDICES,indices);
            var body = dict.GetJsonBytes();
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE,RabbitMQConsts.UPDATE_REMOVE_Q,null,body);
            _logger.LogInformation($"Message sent to {RabbitMQConsts.UPDATE_REMOVE_Q} at {DateTime.Now}");
        }
        public async Task SendAddMessage (string guid,IFormFileCollection files)
        {
            var BytesList = await files.GetBytes();
            var dict = new Dictionary<string,object>();
            dict.Add(RabbitMQConsts.GUID,guid);
            dict.Add(RabbitMQConsts.LIST,BytesList);
            var body = dict.GetJsonBytes();
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE,RabbitMQConsts.ADD_Q,null,body);
            _logger.LogInformation($"Message sent to {RabbitMQConsts.ADD_Q} at {DateTime.Now}");
        }
        public void SendDeleteMessage (string guid)
        {
            var dict = new Dictionary<string,string>();
            dict.Add(RabbitMQConsts.GUID,guid);
            var body = dict.GetJsonBytes();
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE,RabbitMQConsts.DELETE_Q,null,body);
            _logger.LogInformation($"Message sent to {RabbitMQConsts.DELETE_Q} at {DateTime.Now}");
        }
        
    }
}
