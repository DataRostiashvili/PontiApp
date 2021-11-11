using FluentValidation;
using PontiApp.Models.DTOs;
using PontiApp.Models.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.FluentValidator
{
    public class SearchBaseDTOValidator : AbstractValidator<SearchBaseDTO>
    {
        public SearchBaseDTOValidator()
        {
            RuleFor(x => x.PontiType).Must(x => x.GetType() == typeof(PontiTypeEnum));
            RuleFor(x => x.Time).Must(x => x.GetType() == typeof(TimeFilterEnum));
        }
    }
}
