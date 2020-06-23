using Microsoft.EntityFrameworkCore;
using System;
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
        //Constructor
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

        public VehicleRentalAsset GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(asset => asset.Id == id);
        }
        public void Add(VehicleRentalAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }
        public string GetVIN(int id)
        {
            // Car (Discriminator)
            if (GetType(id) != "Car") return "N/A";
            var car = (Car)GetById(id);
            return car.VIN;
        }
        public string GetBodyType(int id)
        {
            // Car (Discriminator)
            if (GetType(id) != "Car") return "N/A";
            var car = (Car)GetById(id);
            return car.BodyType;
        }
        public string GetOptions(int id)
        {
            // Car (Discriminator)
            if (GetType(id) != "Car") return "N/A";
            var car = (Car)GetById(id);
            return car.Options;
        }
        public int GetPassengers(int id)
        {
            // Car (Discriminator)
            if (GetType(id) != "Car") return 0;
            var car = (Car)GetById(id);
            return car.Passengers;
        }

        public int GetBags(int id)
        {
            // Car (Discriminator)
            if (GetType(id) != "Car") return 0;
            var car = (Car)GetById(id);
            return car.Bags;
        }
        public VehicleRentalBranch GetVehicleRentalLocation(int id)
        {
            return _context.VehicleRentalAssets.First(asset => asset.Id == id).Location;
        }


        public string GetType(int id)
        {
            // In this Method we check the type of object so we can determine whether Discriminator Column 
            // is Car or other type of Vehicle
            // Incase we add other types of Vehicles like motor cycle we can create a motorcycle class that
            // inherits from VehicleRentalAsset
            var isCar = _context.VehicleRentalAssets.OfType<Car>()
                .SingleOrDefault(asset => asset.Id == id);
            return isCar != null ? "Car" : "Unknown";

        }

        public string GetMake(int id)
        {
            return _context.VehicleRentalAssets.First(asset => asset.Id == id).Make;
        }

        public string GetModel(int id)
        {
            return _context.VehicleRentalAssets.First(asset => asset.Id == id).Model;
        }


    }
}
