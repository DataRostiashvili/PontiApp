using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.MessageSender
{
    public static class Utils
    {
        public static async Task<List<byte[]>> GetBytes (this IFormFileCollection col)
        {
            List<byte[]> BytesList = new List<byte[]>();
            foreach (var file in col)
            {
                using (MemoryStream str = new MemoryStream())
                {
                    await file.CopyToAsync(str);
                    BytesList.Add(str.ToArray());
                }
            }
            return BytesList;
        }
        public static byte[] GetJsonBytes(this Dictionary<string,object> jsonDict)
        {
            var jsonStr = JsonConvert.SerializeObject(jsonDict);
            return Encoding.UTF8.GetBytes(jsonStr);
        }
        public static byte[] GetJsonBytes(this Dictionary<string,string> dict)
        {
            var JsonStr = JsonConvert.SerializeObject(dict);
            return Encoding.UTF8.GetBytes(JsonStr);
        }
    }
}
