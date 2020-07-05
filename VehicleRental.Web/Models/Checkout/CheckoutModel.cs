using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace VehicleRental.Web.Models.Checkout
{
    public class CheckoutModel
    {
        public int AssetId { get; set; }
        public int SelectedPatronLicenseId { get; set; }
        public IEnumerable<SelectListItem> PatronDetails { get; set;}
        public int NumberOfRentalDays { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public bool IsCheckedOut { get; set; }
    }
}
