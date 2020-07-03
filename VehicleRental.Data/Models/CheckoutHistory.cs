using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleRental.Data.Models
{
    public class CheckoutHistory
    {
        public int Id { get; set; }
        [Required]
        public VehicleRentalAsset VehicleRentalAsset { get; set; }
        [Required]
        public DriverLicense DriverLicense { get; set; }
        [Required]
        public string FullName { get; set;}
        [Required]
        public DateTime CheckedOut { get; set; }
        public DateTime? CheckedIn { get; set; }
    }
}
