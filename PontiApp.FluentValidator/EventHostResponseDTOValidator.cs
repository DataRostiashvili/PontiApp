using FluentValidation;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.FluentValidator
{
    public class EventHostResponseDTOValidator:AbstractValidator<EventHostResponseDTO>
    {
        public EventHostResponseDTOValidator()
        {
            RuleFor(x => x.Mail).EmailAddress();
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
