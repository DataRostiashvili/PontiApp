using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Response
{
    public interface IGenericResponse
    {
        public bool IsSuccess { get; set; }
    }
}
