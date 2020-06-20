using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleRental.Data.Models
{
    public abstract class VehicleRentalAsset
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public int NumberOfUnits { get; set; }
        [Required]
        public double Cost { get; set; }
        public string ImageUrl { get; set; }
        public virtual VehicleRentalBranch Location { get; set; }
    }
}
