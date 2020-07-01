using System;
using System.Collections.Generic;
using System.Text;
using VehicleRental.Data.Models;

namespace VehicleRental.Data
{
    public interface IPatron
    {
        Patron GetById(int patronId);
        IEnumerable<Patron> GetAll();
        void Add(Patron newPatron);
        IEnumerable<CheckoutHistory> GetCheckoutHistories(int patronId);
        IEnumerable<Checkout> GetCheckouts(int patronId);
    }
}
