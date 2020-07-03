using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRental.Data.Models;

namespace VehicleRental.Web.Models.Patron
{
    public class PatronDetailModel
    {
        public int PatronId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string LicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public IEnumerable<VehicleRental.Data.Models.Checkout> Checkout { get; set; }
        public IEnumerable<CheckoutHistory> CheckoutHistory { get; set; }
    }
}
