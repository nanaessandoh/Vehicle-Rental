using System.Collections.Generic;
using VehicleRental.Data.Models;

namespace VehicleRental.Data
{
    public interface IPatron
    {
        Patron GetById(int patronId);
        IEnumerable<Patron> GetAll();
        void Add(Patron newPatron);
        void ClearFees(int patronId);
        void UpdateFees(int patronLicenseId, double costPerDay, int numberOfRentalDays);
        string GetPatronName(int patronId);
        DriverLicense GetDriverLicense(int patronId);
        IEnumerable<CheckoutHistory> GetCheckoutHistories(int patronId);
        IEnumerable<Checkout> GetCheckouts(int patronId);
        IEnumerable<PatronList> GetPatronList();
    }

    public class PatronList
    {
        public int DriverLicenseId { get; set; }
        public string PatronDetails { get; set; }
    }
}
