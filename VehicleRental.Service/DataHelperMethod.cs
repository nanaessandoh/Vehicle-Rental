using System;
using System.Collections.Generic;
using VehicleRental.Data.Models;

namespace VehicleRental.Service
{
    public class DataHelperMethod
    {
        public static IEnumerable<string> HumanizeBusinessHours(IEnumerable<BranchHour> branchHours)
        {
            var hours = new List<string>();

            foreach(var time in branchHours)
            {
                var day = HumanizeDay(time.DayOfWeek);
                var openTime = HumanizeTime(time.OpenTime);
                var closeTime = HumanizeTime(time.CloseTime);
                string timeEntry;
                if ( openTime == null)
                {
                    timeEntry = $"{day} - Closed for the day";
                }
                else
                {
                    timeEntry = $"{day} - {openTime} to {closeTime}";
                }
                
                hours.Add(timeEntry);
            }
            return hours;
        }

        public static string HumanizeTime(int? openTime)
        {
            return TimeSpan.FromHours((int)openTime).ToString("hh':'mm");
        }

        public static string HumanizeDay(int dayOfWeek)
        {
            return Enum.GetName(typeof(DayOfWeek), dayOfWeek);
        }
    }
}
