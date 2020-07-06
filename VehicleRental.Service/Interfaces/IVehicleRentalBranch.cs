using System;
using System.Collections.Generic;
using System.Text;
using VehicleRental.Data.Models;

namespace VehicleRental.Service.Interfaces
{
    public interface IVehicleRentalBranch
    {
        IEnumerable<VehicleRentalBranch> GetAll();
        VehicleRentalBranch GetById(int branchId);
        void Add(VehicleRentalBranch newBranch);
        IEnumerable<Patron> GetPatrons(int branchId);
        IEnumerable<VehicleRentalAsset> GetAssets(int branchId);
        IEnumerable<string> GetBranchHours(int branchId);
        bool IsBranchOpen(int branchId);

    }
}
