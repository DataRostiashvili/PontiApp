using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Exceptions
{
    public class DoesNotExistsException : BaseCustomException
    {
        public DoesNotExistsException() : base()
        {

        }

        public DoesNotExistsException(string message) : base(message)
        {

        }
    }
}
