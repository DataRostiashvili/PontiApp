using FluentValidation;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.FluentValidator
{
    public class PlaceCategoryDTOValidator:AbstractValidator<PlaceCategoryDTO>
    {
        public PlaceCategoryDTOValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.CategoryEntityId).NotNull();
            RuleFor(x => x.PlaceEntityId).NotNull();
        }
    }
}
