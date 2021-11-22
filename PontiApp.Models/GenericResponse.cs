using PontiApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models
{
    public class GenericResponse : IGenericResponse
    {
        public bool IsSuccess { get; set; } = true;
    }
}
