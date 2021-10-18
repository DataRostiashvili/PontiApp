using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.MessageSender
{
    public static class RabbitMQConsts
    {


        public const string EXCHANGE = "PontiApp";
        public const string UPDATE_ADD_Q = "Update.Add";
        public const string UPDATE_REMOVE_Q = "Update.Remove";
        public const string ADD_Q = "Add";
        public const string DELETE_Q = "Delete";


        public const string GUID = "Guid";
        public const string LIST = "BytesList";
        public const string INDICES = "Indices";
    }
}
