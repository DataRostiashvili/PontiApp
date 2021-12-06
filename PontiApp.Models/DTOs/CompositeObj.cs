using Microsoft.AspNetCore.Http;
using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class CompositeObj<T> 
    {
        public T Entity { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}
