using System;
using System.Collections.Generic;
using System.Text;
using VehicleRental.Data.Models;

namespace VehicleRental.Data
{
    public interface IVehicleRentalAsset
    {
        IEnumerable<VehicleRentalAsset> GetAll();
        VehicleRentalAsset GetById(int id);
        void Add(VehicleRentalAsset newAsset);
        string GetVIN(int id);
        string GetBodyType(int id);
        string GetOptions(int id);
        int GetPassengers(int id);
        int GetBags(int id);
        string GetType(int id);
        string GetMake(int id);
        string GetModel(int id);
        VehicleRentalBranch GetVehicleRentalLocation(int id);


    }
}
