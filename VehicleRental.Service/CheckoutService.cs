﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Checkout> GetAll()
        {
            return _context.Checkouts
                .Include(asset => asset.VehicleRentalAsset)
                .Include(asset => asset.DriverLicense);
        }

        public Checkout GetById(int checkoutId)
        {
            return GetAll().FirstOrDefault(asset => asset.Id == checkoutId);
        }

        public void Add(Checkout newCheckout)
        {
            _context.Add(newCheckout);
            _context.SaveChanges();
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int assetId)
        {
            return _context.CheckoutHistories
                .Include(asset => asset.VehicleRentalAsset)
                .Include(asset => asset.DriverLicense)
                .Where(asset => asset.VehicleRentalAsset.Id == assetId);
        }

        public Checkout GetLatestCheckout(int assetId)
        {
            return _context.Checkouts
                .Where(asset => asset.VehicleRentalAsset.Id == assetId)
                .OrderByDescending(asset => asset.StartTime)
                .FirstOrDefault();
        }

        public string GetCurrentCheckoutPatron(int assetId)
        {
            var checkout = GetCheckedoutByAsset(assetId);
            if ( checkout == null)
            {
                return "N/A";
            }

            var cardId = checkout.DriverLicense.Id;
            var patron = _context.Patrons
                .FirstOrDefault(asset => asset.Id == cardId);
            return patron.FirstName + " " + patron.LastName;
        }
        
        public bool IsCheckedout(int assetId)
        {
            //var item = _context.VehicleRentalAssets
                //.Include(asset => asset.Status)
                //.Include(asset => asset.Location)
                //.FirstOrDefault(asset => asset.Id == assetId);
            //return (item.Status.Name == "Checked Out") ;

            // OR
            return _context.Checkouts
                .Where(assets => assets.VehicleRentalAsset.Id == assetId)
                .Any();
        }






        public void CheckOutItem(int assetId, int driverLicenseId, int numberOfRentalDays)
        {
            var currentTime = DateTime.Now;

            var driverLicense = _context.DriverLicenses
                .Include(asset => asset.Checkouts)
                .FirstOrDefault(asset => asset.Id == driverLicenseId);

            var item = _context.VehicleRentalAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location)
                .FirstOrDefault(asset => asset.Id == assetId);

            var fullname = GetPatronFullName(driverLicenseId);

            // Check if Asset is Available and not Checked Out
            if (item.Status.Name == "Available")
            {

                // Update Asset Status as Checked Out
                UpdateAssetStatus(assetId, "Checked Out");

                // Add New Checkout to the Table
                var checkout = new Checkout
                {
                    VehicleRentalAsset = item,
                    DriverLicense = driverLicense,
                    StartTime = currentTime,
                    EndTime = GetCheckoutDate(currentTime, numberOfRentalDays)

                };
                _context.Add(checkout);

                // Add to CheckoutHistory Table
                var CheckoutHistory = new CheckoutHistory
                {
                    VehicleRentalAsset = item,
                    DriverLicense = driverLicense,
                    CheckedOut = currentTime,
                    FullName = fullname
                };
                _context.Add(CheckoutHistory);

                _context.SaveChanges();

            }

        }

        public void CheckInItem(int assetId)
        {
            var currentTime = DateTime.Now;
            var item = _context.VehicleRentalAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location)
                .FirstOrDefault(asset => asset.Id == assetId);

            // Check if Asset has been Checked Out
            if (item.Status.Name == "Checked Out")
            {
                // Remove Existing Checkout on Asset
                RemoveExistingCheckout(assetId);
                // Close Existing Checkout History
                CloseExistingCheckoutHistory(assetId, currentTime);
                // Update Asset Status as Available
                UpdateAssetStatus(assetId, "Available");
                // Save Changes
                _context.SaveChanges();

            }

        }

        public void MarkStolen(int assetId)
        {
            var item = _context.VehicleRentalAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location)
                .FirstOrDefault(asset => asset.Id == assetId);

            // Check If Asset is Checked Out
            if (item.Status.Name == "Checked Out")
            {
                // Update Status of Vehicle Asset to Available
                UpdateAssetStatus(assetId, "Stolen");
                // Save Changes
                _context.SaveChanges();
            }
        }

        public void MarkAvailable(int assetId)
        {
            var currentTime = DateTime.Now;

            var item = _context.VehicleRentalAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location)
                .FirstOrDefault(asset => asset.Id == assetId);

            if (item.Status.Name == "On Hold")
            {
                // Update Status of Vehicle Asset to Available
                UpdateAssetStatus(assetId, "Available");
                // Save Changes
                _context.SaveChanges();
            }

            if (item.Status.Name == "Stolen")
            {
                // Remove Existing Checkout on Asset
                RemoveExistingCheckout(assetId);
                // Close Existing Checkout History
                CloseExistingCheckoutHistory(assetId, currentTime);
                // Update Asset Status as Available
                UpdateAssetStatus(assetId, "Available");
                // Save Changes
                _context.SaveChanges();
            }

        }







        public void PlaceHold(int assetId)
        {
            var currentTime = DateTime.Now;
            var item = _context.VehicleRentalAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location)
                .FirstOrDefault(asset => asset.Id == assetId);

            // Check if Asset if Available then Set Satus as On hold
            if (item.Status.Name == "Available")
            {
                UpdateAssetStatus(assetId, "On Hold");

                // Add Entry to Hold Table
                var hold = new Hold
                {
                    VehicleRentalAsset = item,
                    HoldPlaced = currentTime
                };

                _context.Add(hold);
                _context.SaveChanges();
            }


        }

        public DateTime GetCurrentHoldPlaced(int assetId)
        {
            return _context.Holds
                .Where(asset => asset.VehicleRentalAsset.Id == assetId)
                .OrderByDescending(asset => asset.HoldPlaced)
                .FirstOrDefault().HoldPlaced;
        }

        public IEnumerable<Hold> GetCurrentHolds(int assetId)
        {
            return _context.Holds
                .Include(asset => asset.VehicleRentalAsset)
                .Where(asset => asset.VehicleRentalAsset.Id == assetId);
        }





        // Helper Methods

        private void UpdateAssetStatus(int assetId, string statusName)
        {
            var item = _context.VehicleRentalAssets.FirstOrDefault(asset => asset.Id == assetId);
            _context.Update(item);
            item.Status = _context.Statuses.FirstOrDefault(asset => asset.Name == statusName);
        }

        private void CloseExistingCheckoutHistory(int assetId, DateTime currentTime)
        {
            var history = _context.CheckoutHistories
                .Include(asset => asset.VehicleRentalAsset)
                .Include(asset => asset.DriverLicense)
                .FirstOrDefault(asset => asset.VehicleRentalAsset.Id == assetId && asset.CheckedIn == null);
            if (history != null)
            {
                _context.Update(history);
                history.CheckedIn = currentTime;
            }
        }

        private void RemoveExistingCheckout(int assetId)
        {
            var checkout = _context.Checkouts
                .Include(asset => asset.VehicleRentalAsset)
                .Include(asset => asset.DriverLicense)
                .FirstOrDefault(asset => asset.VehicleRentalAsset.Id == assetId); ;

            if (checkout != null)
            {
                _context.Remove(checkout);
            }
        }

        private DateTime GetCheckoutDate(DateTime currentTime, int numberOfRentalDays)
        {
            // Default CheckIn time is 2 days from Checkout 
            return currentTime.AddDays(numberOfRentalDays);
        }

        private Checkout GetCheckedoutByAsset(int assetId)
        {
            return _context.Checkouts
                .Include(asset => asset.VehicleRentalAsset)
                .Include(asset => asset.DriverLicense)
                .FirstOrDefault(asset => asset.VehicleRentalAsset.Id == assetId);
        }

        public string GetPatronFullName(int DriverLicenseId)
        {
            var patron = _context.Patrons
                 .Include(asset => asset.DriverLicense)
                 .FirstOrDefault(asset => asset.DriverLicense.Id == DriverLicenseId);
            return patron.FirstName + " " + patron.LastName;
        }

    }
}
