using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRental.Data.Models;

namespace VehicleRental.Web.Models.Branch
{
    public class BranchDetailModel
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Telephone { get; set; }
        public bool IsOpen { get; set; }
        public string ImageUrl { get; set; }
        public int NumberOfAssets { get; set; }
        public IEnumerable<string> HoursOpen { get; set; }
        public IEnumerable<VehicleRentalAsset> BranchAssets { get; set; }


    }
}
