using FluentValidation;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.FluentValidator
{
    public class PlaceGuestRequestDTOValidator : AbstractValidator<PlaceGuestRequestDTO>
    {
        public PlaceGuestRequestDTOValidator()
        {
            RuleFor(x => x.PlaceId).NotNull();
            RuleFor(x => x.UserGuestId).NotNull();
        }
    }
}
