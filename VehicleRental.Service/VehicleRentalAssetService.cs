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
        public void Add(VehicleRentalAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }
        public IEnumerable<VehicleRentalAsset> GetAll()
        {
            //return GetAll();
            return _context.VehicleRentalAssets
                .Include(asset => asset.Id)
                .Include(asset => asset.Make)
                .Include(asset => asset.Model)
                .Include(asset => asset.StatusId)
                .Include(asset => asset.NumberOfUnits)
                .Include(asset => asset.Cost)
                .Include(asset => asset.ImageUrl)
                .Include(asset => asset.Location);
        }
        public VehicleRentalAsset GetById(int id)
        {
            //return _context.VehicleRentalAssets
                //.Include(asset => asset.Make)
                //.Include(asset => asset.Model)
                //.Include(asset => asset.Status)
                //.Include(asset => asset.Location)
                //.FirstOrDefault(asset => asset.Id == id);
            return GetAll().FirstOrDefault(asset => asset.Id == id);
        }
        public VehicleRentalBranch GetVehicleRentalBranch(int id)
        {
            //return _context.VehicleRentalAssets.FirstOrDefault(asset => asset.Id == id).Location;
            return GetById(id).Location;
        }
        public string GetBodyType(int id)
        {
            // Discriminator Car
            if (_context.Cars.Any(vehicle => vehicle.Id == id))
            {
                return _context.Cars.FirstOrDefault(vehicle => vehicle.Id == id).BodyType;
            }
            else return "";
        }
        public string GetOptions(int id)
        {
            // Discriminator Car
            if (_context.Cars.Any(vehicle => vehicle.Id == id))
            {
                return _context.Cars.FirstOrDefault(vehicle => vehicle.Id == id).Options;
            }
            else return "";
        }

        public int GetPassengers(int id)
        {
            // Discriminator Car
            if (_context.Cars.Any(vehicle => vehicle.Id == id))
            {
                return _context.Cars.FirstOrDefault(vehicle => vehicle.Id == id).Passengers;
            }
            else return 0;
        }
        public string GetVIN(int id)
        {
            // Discriminator Car
            if (_context.Cars.Any(vehicle => vehicle.Id == id))
            {
                return _context.Cars.FirstOrDefault(vehicle => vehicle.Id == id).VIN;
            }
            else return "";
        }

        public int GetBags(int id)
        {
            // Discriminator Car
            if (_context.Cars.Any(vehicle => vehicle.Id == id))
            {
                return _context.Cars.FirstOrDefault(vehicle => vehicle.Id == id).Bags;
            }
            else return 0;
        }
        public string GetType(int id)
        {
            // In this Method we check the type of object so we can determine whether Discriminator Column 
            // is Car or other type of Vehicle
            // Incase we add other types of Vehicles like motor cycle we can create a motorcycle class that
            // inherits from VehicleRentalAsset
            var isCar = _context.VehicleRentalAssets.OfType<Car>()
                .Where(asset => asset.Id == id);
            return isCar.Any() ? "Car" : "Unknown";

        }

    }
}
