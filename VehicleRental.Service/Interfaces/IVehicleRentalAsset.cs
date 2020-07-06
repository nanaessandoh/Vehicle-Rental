using System;
using System.Collections.Generic;
using System.Text;
using VehicleRental.Data.Models;

namespace VehicleRental.Service
{
    public interface IVehicleRentalAsset
    {
        IEnumerable<VehicleRentalAsset> GetAll();
        VehicleRentalAsset GetById(int assetId);
        void Add(VehicleRentalAsset newAsset);
        string GetBodyType(int id);
        string GetOptions(int id);
        int GetPassengers(int id);
        int GetBags(int id);
        string GetType(int id);
        VehicleRentalBranch GetVehicleRentalLocation(int assetId);


    }
}
