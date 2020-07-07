using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleRental.Web.Models.Checkout
{
    public class CheckoutModel
    {
        public int AssetId { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int SelectedPatronLicenseId { get; set; }
        public IEnumerable<SelectListItem> PatronDetails { get; set;}
        [Required]
        [Range(1, 28)]
        public int NumberOfRentalDays { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public double Cost { get; set; }
        public bool IsCheckedOut { get; set; }
    }
}
