﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VehicleRental.Data;
using VehicleRental.Data.Models;
using VehicleRental.Service.Interfaces;

namespace VehicleRental.Service
{
    public class PatronService : IPatron
    {
        private readonly VehicleRentalDBContext _context;

        public PatronService(VehicleRentalDBContext context)
        {
            _context = context;
        }

        public void Add(Patron newPatron)
        {
            _context.Add(newPatron);
            _context.SaveChanges();
        }


        public void ClearFees(int patronId)
        {
            var driverLicense = GetDriverLicense(patronId);
            driverLicense.Fees = 0.0;
            _context.SaveChanges();
        }

        public void UpdateFees(int patronLicenseId, double costPerDay, int numberOfRentalDays)
        {
            var driverLicense = _context.DriverLicenses
                .FirstOrDefault(asset => asset.Id == patronLicenseId);
            driverLicense.Fees += (numberOfRentalDays * costPerDay);
            _context.SaveChanges();
        }

        public IEnumerable<Patron> GetAll()
        {
            return _context.Patrons
                .Include(asset => asset.DriverLicense)
                .Include(asset => asset.VehicleRentalBranch)
                .OrderBy(asset => asset.FirstName);
        }


        public Patron GetById(int patronId)
        {
            return GetAll()
                .FirstOrDefault(asset => asset.Id == patronId);
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistories(int patronId)
        {
            var patron = GetById(patronId);
            var driverLicenseId = patron.DriverLicense.Id;

            return _context.CheckoutHistories
                .Include(asset => asset.VehicleRentalAsset)
                .Include(asset => asset.DriverLicense)
                .Where(asset => asset.DriverLicense.Id == driverLicenseId)
                .OrderByDescending(asset => asset.CheckedOut);
        }

        public IEnumerable<Checkout> GetCheckouts(int patronId)
        {
            var patron = GetById(patronId);
            var driverLicenseId = patron.DriverLicense.Id;

            return _context.Checkouts
                .Include(asset => asset.VehicleRentalAsset)
                .Include(asset => asset.DriverLicense)
                .Where(asset => asset.DriverLicense.Id == driverLicenseId)
                .OrderByDescending(asset => asset.StartTime);
        }

        public DriverLicense GetDriverLicense(int patronId)
        {
            var patron = GetById(patronId);
            var driverLicenseId = patron.DriverLicense.Id;

            return _context.DriverLicenses
                .FirstOrDefault(asset => asset.Id == driverLicenseId);

        }


        public string GetPatronName(int patronId)
        {
            var patron = GetById(patronId);
            return patron.FirstName + " " + patron.LastName;
        }


        public IEnumerable<PatronList> GetPatronList()
        {
            return _context.Patrons
                .Select(asset => new PatronList()
                {
                    DriverLicenseId = asset.DriverLicense.Id,
                    PatronDetails = asset.FirstName + " " + asset.LastName + " - "+ asset.DriverLicense.LicenseID
                });
        }

    }
}
