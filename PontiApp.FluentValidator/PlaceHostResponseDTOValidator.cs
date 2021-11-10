using FluentValidation;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.FluentValidator
{
    public class PlaceHostResponseDTOValidator:AbstractValidator<PlaceHostResponseDTO>
    {
        public PlaceHostResponseDTOValidator()
        {
            RuleFor(x => x.Mail).EmailAddress();
        }
    }
}
