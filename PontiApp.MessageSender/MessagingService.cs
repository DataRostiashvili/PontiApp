using System;
using System.Collections.Generic;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace PontiApp.MessageSender
{
    public class MessagingService
    {
        private readonly ConnectionFactory _factory;
        private readonly ILogger<MessagingService> _logger;
        public IConnection Conn { get; set; }
        public IModel Channel { get; set; }
        public MessagingService(ILogger<MessagingService> logger,ConnectionFactory factory)
        {
            _factory = factory;
            _logger = logger;
            _factory.HostName = RabbitMQConsts.HOSTNAME;
            _factory.UserName = RabbitMQConsts.USERNAME;
            _factory.Password = RabbitMQConsts.PASSWORD;
            _factory.Port = RabbitMQConsts.PORT;
            Conn = factory.CreateConnection();
            Channel = Conn.CreateModel();
        }
        public void SendUpdateMessage(string guid,List<byte[]> BytesList)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(RabbitMQConsts.GUID, guid);
            dict.Add(RabbitMQConsts.LIST, BytesList);
            var json = JsonConvert.SerializeObject(dict);
            var body = Encoding.UTF8.GetBytes(json);
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.UPDATE_ADD_Q, null, body);
            _logger.LogInformation($"Message sent to {RabbitMQConsts.UPDATE_ADD_Q} at {DateTime.Now}");
        }

        public void SendUpdateMessage(string guid,int[] indices)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(RabbitMQConsts.GUID, guid);
            dict.Add(RabbitMQConsts.INDICES, indices);
            var json = JsonConvert.SerializeObject(dict);
            var body = Encoding.UTF8.GetBytes(json);
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.UPDATE_REMOVE_Q, null, body);
            _logger.LogInformation($"Message sent to {RabbitMQConsts.UPDATE_REMOVE_Q} at {DateTime.Now}");
        }
        public void SendAddMessage(string guid,List<byte[]> BytesList)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(RabbitMQConsts.GUID, guid);
            dict.Add(RabbitMQConsts.LIST, BytesList);
            var json = JsonConvert.SerializeObject(dict);
            var body = Encoding.UTF8.GetBytes(json);
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE,RabbitMQConsts.ADD_Q, null, body);
            _logger.LogInformation($"Message sent to {RabbitMQConsts.ADD_Q} at {DateTime.Now}");
        }
        public void SendDeleteMessage(string guid)
        {
            var dict = new Dictionary<string, string>();
            dict.Add(RabbitMQConsts.GUID, guid);
            var json = JsonConvert.SerializeObject(dict);
            var body = Encoding.UTF8.GetBytes(json);
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.DELETE_Q,  null, body);
            _logger.LogInformation($"Message sent to {RabbitMQConsts.DELETE_Q} at {DateTime.Now}");
        }
    }
}
