using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VehicleRental.Data;
using VehicleRental.Data.Models;

namespace VehicleRental.Service
{
    public class VehicleRentalAssetService : IVehicleRentalAsset
    {
        // Create DbContext private field and Create a constructor that takes the DbContext  
        private readonly VehicleRentalDBContext _context;
        // Constructor
        public VehicleRentalAssetService(VehicleRentalDBContext context)
        {
            _context = context;
        }

        public IEnumerable<VehicleRentalAsset> GetAll()
        {
            return _context.VehicleRentalAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location);
        }

        public VehicleRentalAsset GetById(int assetId)
        {
            return GetAll().FirstOrDefault(asset => asset.Id == assetId);

        }

        public void Add(VehicleRentalAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public string GetBodyType(int assetId)
        {
            // Car (Discriminator)
            if (GetType(assetId) != "Car") return "N/A";
            var car = (Car)GetById(assetId);
            return car.BodyType;
        }

        public string GetOptions(int assetId)
        {
            // Car (Discriminator)
            if (GetType(assetId) != "Car") return "N/A";
            var car = (Car)GetById(assetId);
            return car.Options;
        }

        public int GetPassengers(int assetId)
        {
            // Car (Discriminator)
            if (GetType(assetId) != "Car") return 0;
            var car = (Car)GetById(assetId);
            return car.Passengers;
        }

        public int GetBags(int assetId)
        {
            // Car (Discriminator)
            if (GetType(assetId) != "Car") return 0;
            var car = (Car)GetById(assetId);
            return car.Bags;
        }

        public VehicleRentalBranch GetVehicleRentalLocation(int assetId)
        {
            return _context.VehicleRentalAssets.First(asset => asset.Id == assetId).Location;
        }

        public string GetType(int assetId)
        {
            // In this Method we check the type of object so we can determine whether Discriminator Column 
            // is Car or other type of Vehicle
            // Incase we add other types of Vehicles like motor cycle we can create a motorcycle class that
            // inherits from VehicleRentalAsset
            var isCar = _context.VehicleRentalAssets.OfType<Car>()
                .SingleOrDefault(asset => asset.Id == assetId);
            return isCar != null ? "Car" : "Unknown";

        }

    }
}
