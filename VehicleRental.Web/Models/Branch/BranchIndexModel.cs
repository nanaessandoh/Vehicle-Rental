using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRental.Web.Models.Branch
{
    public class BranchIndexModel
    {
        public IEnumerable<BranchIndexListingModel> Branches { get; set; }
    }

    public class BranchIndexListingModel
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public string Telephone { get; set; }

    }
}
