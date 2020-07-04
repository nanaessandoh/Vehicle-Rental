using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRental.Data.Models;

namespace VehicleRental.Web.Models.Catalog
{
    public class AssetDetailModel
    {
        public int AssetId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public double Cost { get; set; }
        public string BodyType { get; set; }
        public string Options { get; set; }
        public int Passengers { get; set; }
        public int Bags { get; set; }
        public string VIN { get; set; }
        public string CurrentLocation { get; set; }
        public string PatronName { get; set; }
        public VehicleRental.Data.Models.Checkout LatestCheckout { get; set; }
        public IEnumerable<CheckoutHistory> CheckoutHistory { get; set; }
        public IEnumerable<Hold> HoldHistory { get; set; }
    }
}
