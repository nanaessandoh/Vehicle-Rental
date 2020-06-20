using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleRental.Data.Models
{
    public class Checkout
    {
        public int Id { get; set; }
        [Required]
        public VehicleRentalAsset VehicleRentalAsset { get; set; }
        public DriverLicense DriverLicense { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
