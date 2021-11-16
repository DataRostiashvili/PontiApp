using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Exceptions
{
    public class AlreadyExistsException :BaseCustomException
    {
        public AlreadyExistsException() : base()
        {

        }

        public AlreadyExistsException(string message) : base(message)
        {

        }
    }
}
