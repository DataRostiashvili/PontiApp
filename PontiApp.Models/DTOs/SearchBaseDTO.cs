﻿using PontiApp.Models.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class SearchBaseDTO
    {
        PontiTypeEnum PontiType { get; set; }
        string Categoty { get; set; }
        TImeFilterEnum Time { get; set; }
        string SearchKeyWord { get; set; }
    }
}
