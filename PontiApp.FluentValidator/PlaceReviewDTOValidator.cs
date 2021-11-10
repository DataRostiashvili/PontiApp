using FluentValidation;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.FluentValidator
{
    public class PlaceReviewDTOValidator:AbstractValidator<PlaceReviewDTO>
    {
        public PlaceReviewDTOValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.PlaceEntityId).NotNull();
            RuleFor(x => x.UserEntityId).NotNull();
            RuleFor(x => x.PlaceEntityId).NotNull();
        }
    }
}
