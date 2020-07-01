using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRental.Web.Models.Patron
{
    public class PatronIndexModel
    {
        public IEnumerable<PatronIndexListingModel> Patrons { get; set; }
    }


    public class PatronIndexListingModel
    {
        public int PatronId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string PatronRentalBranch { get; set; }

    }
}
