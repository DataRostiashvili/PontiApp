using PontiApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Exceptions
{
    public class BaseCustomException :Exception
    {
        public BaseCustomException() : base()
        {

        }

        public BaseCustomException(string message) : base(message)
        {

        }

    }
}
