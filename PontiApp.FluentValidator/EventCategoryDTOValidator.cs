using FluentValidation;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.FluentValidator
{
    public class EventCategoryDTOValidator:AbstractValidator<EventCategoryDTO>
    {
        public EventCategoryDTOValidator()
        {
            RuleFor(x => x.EventEntityId).NotNull();
            RuleFor(x => x.CategoryEntityId).NotNull();
        }
    }
}
