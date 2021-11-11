using FluentValidation;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.FluentValidator
{
    public class EventHostRequestDTOValidator:AbstractValidator<EventHostRequestDTO>
    {
        public EventHostRequestDTOValidator()
        {
            RuleFor(x => x.Mail).EmailAddress();
        }
    }
}
