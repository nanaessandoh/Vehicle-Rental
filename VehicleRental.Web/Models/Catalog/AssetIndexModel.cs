using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRental.Web.Models.Catalog
{
    public class AssetIndexModel
    {
        public IEnumerable<AssetIndexListingModel> Assets { get; set; }

    }

    public class AssetIndexListingModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public string BodyType { get; set; }
        public string Options { get; set; }
        public int Passengers { get; set; }
        public int Bags { get; set; }

    }
}
