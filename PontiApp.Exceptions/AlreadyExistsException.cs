using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Exceptions
{

    public class AlreadyExistsException : BaseCustomException
    {
        public AlreadyExistsException() : base("Such Entity Already Exists!")
        {

        }

        public AlreadyExistsException(string message) : base(message)
        {

        }
    }

}

