using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.ExpressionTranslators.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleRental.Data;
using VehicleRental.Data.Models;

namespace VehicleRental.Service
{
    public class CheckoutService : ICheckout
    {
        // Create DbContext private field and Create a constructor that takes the DbContext  
        private readonly VehicleRentalDBContext _context;

        // Constructor
        public CheckoutService(VehicleRentalDBContext context)
        {
            _context = context;
        }

        public void Add(Checkout newCheckout)
        {
            _context.Add(newCheckout);
            _context.SaveChanges();
        }

        public void CheckInItem(int assetId)
        {
            var item = _context.VehicleRentalAssets.FirstOrDefault(asset => asset.Id == assetId);
            _context.Update(item);

            // Remove Existing Checkout on Asset
            RemoveExistingCheckout(assetId);
            // Close Existing Checkout History
            CloseExistingCheckoutHistory(assetId);
            // Update Asset Status as Available
            UpdateAssetStatus(assetId, "Available");
            // Save Changes
            _context.SaveChanges();
        }

        public void CheckOutItem(int assetId, int driverLicenseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Checkout> GetAll()
        {
            return _context.Checkouts;
        }

        public Checkout GetById(int checkoutId)
        {
            return GetAll().FirstOrDefault(asset => asset.Id == checkoutId);
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int id)
        {
            return _context.CheckoutHistories
                .Include(asset => asset.VehicleRentalAsset)
                .Include (asset => asset.DriverLicense)
                .Where(asset => asset.VehicleRentalAsset.Id == id);
        }

        public DateTime GetCurrentHoldPlaced(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            return _context.Holds
                .Include(asset => asset.VehicleRentalAsset)
                .Where(asset => asset.VehicleRentalAsset.Id == id);
        }

        public Checkout GetLatestCheckout(int id)
        {
            return _context.Checkouts
                .Where(asset => asset.VehicleRentalAsset.Id == id)
                .OrderByDescending(asset => asset.StartTime)
                .FirstOrDefault();
        }

        public void MarkAvailable(int assetId)
        {

            // Update Status of Vehicle Asset to Available
            UpdateAssetStatus(assetId, "Available");
            // Remove Existing Checkout Outs since it is now Checked In
            RemoveExistingCheckout(assetId);
            // Close Any Existing Checkout History
            CloseExistingCheckoutHistory(assetId);
            // Save Changes
            _context.SaveChanges();
             
        }

        private void UpdateAssetStatus(int assetId, string statusName)
        {
            var item = _context.VehicleRentalAssets.FirstOrDefault(asset => asset.Id == assetId);
            _context.Update(item);
            item.Status = _context.Statuses.FirstOrDefault(asset => asset.Name == statusName);
        }

        private void CloseExistingCheckoutHistory(int assetId)
        {
            var history = _context.CheckoutHistories.FirstOrDefault(asset => asset.Id == assetId && asset.CheckedIn == null);
            if (history != null)
            {
                _context.Update(history);
                history.CheckedIn = DateTime.Now;
            }
        }

        private void RemoveExistingCheckout(int assetId)
        {
            var checkout = _context.Checkouts.FirstOrDefault(asset => asset.Id == assetId); ;

            if (checkout != null)
            {
                _context.Remove(checkout);
            }
        }

        public void MarkStolen(int assetId)
        {
            UpdateAssetStatus(assetId, "Stolen");
            _context.SaveChanges();
        }

        public void PlaceHold(int assetId)
        {
            throw new NotImplementedException();
        }

        public void RemoveHold(int assetId)
        {
            throw new NotImplementedException();
        }

    }
}
