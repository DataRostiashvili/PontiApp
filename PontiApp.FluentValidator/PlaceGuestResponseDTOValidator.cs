using FluentValidation;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.FluentValidator
{
    public class PlaceGuestResponseDTOValidator:AbstractValidator<PlaceGuestResponseDTO>
    {
        public PlaceGuestResponseDTOValidator()
        {
            RuleFor(x => x.Mail).EmailAddress();
        }
    }
}
