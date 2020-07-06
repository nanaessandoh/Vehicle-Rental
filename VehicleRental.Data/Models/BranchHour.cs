using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleRental.Data.Models
{
    public class BranchHour
    {
        public int Id { get; set; }
        public VehicleRentalBranch Branch {get; set;}
        [Range(0,6)]
        public int DayOfWeek { get; set; }
        [Range(0,23)]
        public int? OpenTime { get; set; }
        [Range(0,23)]
        public int? CloseTime { get; set; }
    }
}
