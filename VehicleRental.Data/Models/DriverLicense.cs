using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleRental.Data.Models
{
    public class DriverLicense
    {
        public int Id { get; set; }
        public string LicenseID { get; set; }
        public double Fees { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public virtual IEnumerable<Checkout> Checkouts { get; set; }
    }
}
