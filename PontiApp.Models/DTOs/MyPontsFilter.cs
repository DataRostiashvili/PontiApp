using PontiApp.Models.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class MyPontsFilter
    {
        public int QueueId { get; set; }
        PontiTypeEnum PontiType { get; set; }
        MyRoleEnum MyRole { get; set; }
        
    }
}
