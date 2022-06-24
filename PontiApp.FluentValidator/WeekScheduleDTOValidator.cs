using FluentValidation;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.FluentValidator
{
    public class WeekScheduleDTOValidator:AbstractValidator<WeekScheduleDTO>
    {
        public WeekScheduleDTOValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Start).NotNull();
            RuleFor(x => x.Day).Must(x => x.GetType() == typeof(DayOfWeek));
        }
    }
}
