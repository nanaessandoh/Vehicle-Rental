using System;
using System.Collections.Generic;
using System.Text;
using VehicleRental.Data.Models;

namespace VehicleRental.Data
{
    public interface ICheckout
    {
        IEnumerable<Checkout> GetAll();
        Checkout GetById(int checkoutId);
        void Add(Checkout newCheckout);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);
        Checkout GetLatestCheckout(int id);
        string GetCurrentCheckoutPatron(int id);


        void CheckOutItem(int assetId, int driverLicenseId);
        void CheckInItem(int assetId);
        void MarkStolen(int assetId);
        void MarkAvailable(int assetId);

        void PlaceHold(int assetId);
        DateTime GetCurrentHoldPlaced(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);

    }
}
