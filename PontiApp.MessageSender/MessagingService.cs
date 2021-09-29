using System;
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
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                Port = 5672
            };
            Conn = factory.CreateConnection();
            Channel = Conn.CreateModel();
        }
        public void SendUpdateMessage(string guid,List<byte[]> BytesList)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("Guid",guid);
            dict.Add("BytesList", BytesList);
            var json = JsonConvert.SerializeObject(dict);
            var body = Encoding.UTF8.GetBytes(json);
            Channel.BasicPublish("PontiAppEx", "Update.Add", null, body);
        }
        public void SendUpdateMessage(string guid,int[] indices)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("Guid", guid);
            dict.Add("Indices", indices);
            var json = JsonConvert.SerializeObject(dict);
            var body = Encoding.UTF8.GetBytes(json);
            Channel.BasicPublish("PontiAppEx", "Update.Remove", null, body);
        }
        public void SendAddMessage(string guid,List<byte[]> BytesList)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("Guid", guid);
            dict.Add("BytesList", BytesList);
            var json = JsonConvert.SerializeObject(dict);
            var body = Encoding.UTF8.GetBytes(json);
            Channel.BasicPublish("PontiAppEx", "Add", null, body);
        }
        public void SendDeleteMessage(string guid)
        {
            var dict = new Dictionary<string, string>();
            dict.Add("Guid", guid);
            var json = JsonConvert.SerializeObject(dict);
            var body = Encoding.UTF8.GetBytes(json);
            Channel.BasicPublish("PontiAppEx", "Add", null, body);
        }
    }
}
