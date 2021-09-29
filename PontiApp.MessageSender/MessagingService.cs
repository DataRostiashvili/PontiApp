﻿using System;
using System.Collections.Generic;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PontiApp.MessageSender
{
    public class MessagingService
    {
        public IConnection Conn { get; set; }
        public IModel Channel { get; set; }
        public MessagingService()
        {
            var factory = new ConnectionFactory()
            {
                HostName = RabbitMQConsts.HOSTNAME,
                UserName = RabbitMQConsts.USERNAME,
                Password = RabbitMQConsts.PASSWORD,
                Port = RabbitMQConsts.PORT
            };
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
        }

        public void SendUpdateMessage(string guid,int[] indices)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(RabbitMQConsts.GUID, guid);
            dict.Add(RabbitMQConsts.INDICES, indices);
            var json = JsonConvert.SerializeObject(dict);
            var body = Encoding.UTF8.GetBytes(json);
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.UPDATE_REMOVE_Q, null, body);
        }
        public void SendAddMessage(string guid,List<byte[]> BytesList)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(RabbitMQConsts.GUID, guid);
            dict.Add(RabbitMQConsts.LIST, BytesList);
            var json = JsonConvert.SerializeObject(dict);
            var body = Encoding.UTF8.GetBytes(json);
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE,RabbitMQConsts.ADD_Q, null, body);
        }
        public void SendDeleteMessage(string guid)
        {
            var dict = new Dictionary<string, string>();
            dict.Add(RabbitMQConsts.GUID, guid);
            var json = JsonConvert.SerializeObject(dict);
            var body = Encoding.UTF8.GetBytes(json);
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.DELETE_Q,  null, body);
        }
    }
}
