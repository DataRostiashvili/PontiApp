using FluentValidation;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.FluentValidator
{
    public class EventListingResponseDTOValidator:AbstractValidator<EventListingResponseDTO>
    {
        public EventListingResponseDTOValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
