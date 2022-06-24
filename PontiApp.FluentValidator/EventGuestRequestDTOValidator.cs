using FluentValidation;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.FluentValidator
{
    class EventGuestRequestDTOValidator:AbstractValidator<EventGuestRequestDTO>
    {
        public EventGuestRequestDTOValidator()
        {
            RuleFor(x => x.UserGuestId).NotNull();
            RuleFor(x => x.EventId).NotNull();
        }
    }
}
