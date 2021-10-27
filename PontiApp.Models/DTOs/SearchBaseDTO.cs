using PontiApp.Models.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class SearchBaseDTO
    {
        public PontiTypeEnum PontiType { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public TimeFilterEnum Time { get; set; }
        public string SearchKeyWord { get; set; }
    }
}
