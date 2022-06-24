using Microsoft.AspNetCore.Http;
using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class CompositeObj<T,G> 
    {
        public T Entity { get; set; }
        public G Files { get; set; }
    }
}
