using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PontiApp.Models.Entities;
using PontiApp.Models.Entities.Enums;
using PontiApp.Models.Response;

namespace PontiApp.Mappings
{
    public static class Helpers
    {
        public static string ConvertToPictureUri(string guid) => $"https://localhost:44389/api/Image/get-profile-picture?guid={guid}";
        public static WeekScheduleResponse TakeCurrentDay(IEnumerable<WeekEntity> weekEntities) 
        {
            var today = (int)DateTime.Now.DayOfWeek;
            var entity = weekEntities.Where(day => Enum.GetName(typeof(Daytype), day.Day) == "Monday");
            var c = entity.Count();
            return null;
          //  return new WeekScheduleResponse { Day = entity.Day, End = entity.End, IsWorking = entity.IsWorking, PlaceEntityId = entity.PlaceEntityId, Start = entity.Start };
        } 
    }
}
