using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRental.Web.Models.Branch
{
    public class BranchIndexModel
    {
        IEnumerable<BranchIndexListingModel> Branch { get; set; }
    }

    public class BranchIndexListingModel
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Location
        {
            get { return City + ", " + Province; }
            set { Location = value; }
        }
        public string ImageUrl { get; set; }

    }
}
