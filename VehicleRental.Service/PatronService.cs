using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleRental.Data;
using VehicleRental.Data.Models;

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

        public IEnumerable<Patron> GetAll()
        {
            return _context.Patrons
                .Include(asset => asset.DriverLicense)
                .Include(asset => asset.VehicleRentalBranch);
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


        string IPatron.GetPatronName(int patronId)
        {
            var patron = GetById(patronId);
            return patron.FirstName + " " + patron.LastName;
        }
    }
}
