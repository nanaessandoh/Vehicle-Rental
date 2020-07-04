using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleRental.Data.Models
{
    public class Car : VehicleRentalAsset
    {

        [Required]
        public string BodyType { get; set; }
        [Required]
        public string Options { get; set; }
        [Required]
        public int Passengers { get; set; }
        [Required]
        public int Bags { get; set; }

    }
}
