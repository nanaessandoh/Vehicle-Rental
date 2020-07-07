using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleRental.Data;
using VehicleRental.Data.Models;
using VehicleRental.Service.Interfaces;

namespace VehicleRental.Service
{
    public class VehicleRentalBranchService : IVehicleRentalBranch
    {
        private readonly VehicleRentalDBContext _context;

        public VehicleRentalBranchService(VehicleRentalDBContext context)
        {
            _context = context;
        }
        public void Add(VehicleRentalBranch newBranch)
        {
            _context.Add(newBranch);
            _context.SaveChanges();
        }

        public IEnumerable<VehicleRentalBranch> GetAll()
        {
            return _context.VehicleRentalBranches
                .Include(asset => asset.Patrons)
                .Include(asset => asset.VehicleRentalAssets);
        }

        public VehicleRentalBranch GetById(int branchId)
        {
            return GetAll().FirstOrDefault(asset => asset.Id == branchId);
        }

        public IEnumerable<VehicleRentalAsset> GetAssets(int branchId)
        {
            return _context.VehicleRentalAssets
                .Include(asset => asset.Location)
                .Include(asset => asset.Status)
                .Where(asset => asset.Location.Id == branchId);
        }

        public IEnumerable<string> GetBranchHours(int branchId)
        {
            var hours =  _context.BranchHours
                .Where(asset => asset.Branch.Id == branchId);

            return DataHelperMethod.HumanizeBusinessHours(hours);

        }



        public IEnumerable<Patron> GetPatrons(int branchId)
        {
            return _context.Patrons
                .Include(asset => asset.DriverLicense)
                .Where(asset => asset.VehicleRentalBranch.Id == branchId);
        }

        public bool IsBranchOpen(int branchId)
        {
            var currentTimeHour = DateTime.Now.Hour;
            var currentDayOfWeek = (int)DateTime.Now.DayOfWeek + 1;
            var branchHours = _context.BranchHours
                .Where(asset => asset.Branch.Id == branchId);
            var selectDayDetails = branchHours
                .FirstOrDefault(asset => asset.DayOfWeek == currentDayOfWeek);

            return (currentTimeHour > selectDayDetails.OpenTime) && (currentTimeHour < selectDayDetails.CloseTime);
        }
    }
}
