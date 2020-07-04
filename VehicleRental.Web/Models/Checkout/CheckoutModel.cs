using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRental.Web.Models.Checkout
{
    public class CheckoutModel
    {
        public int AssetId { get; set; }
        [Range(1,10)]
        public int DriverLicenseId { get; set; }
        [Range(1,28)]
        public int NumberOfRentalDays { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public bool IsCheckedOut { get; set; }
    }
}
