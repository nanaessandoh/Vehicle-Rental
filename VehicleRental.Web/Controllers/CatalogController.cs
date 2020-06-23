using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using VehicleRental.Web.Models.Catalog;
using VehicleRental.Data;
using VehicleRental.Data.Models;

namespace VehicleRental.Web.Controllers
{
    public class CatalogController : Controller
    {

        private readonly IVehicleRentalAsset _assetsService;

        // Constructor to enable us access IVehicleRentalAsset object
        public CatalogController(IVehicleRentalAsset assetsService) => _assetsService = assetsService;
        public IActionResult Index()
        {
            var assetModels = _assetsService.GetAll();

            var listingResult = assetModels
                .Select(result => new AssetIndexListingModel 
                {
                    Id = result.Id,
                    Make = result.Make,
                    Model = result.Model,  
                    ImageUrl = result.ImageUrl,
                    BodyType = _assetsService.GetBodyType(result.Id)
                });

            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var assetModels = _assetsService.GetById(id);
            var model = new AssetDetailModel
            {
                Id = id,
                Make = assetModels.Make,
                Model = assetModels.Model,
                ImageUrl = assetModels.ImageUrl,
                BodyType = _assetsService.GetBodyType(id),
                Options = _assetsService.GetOptions(id),
                Passengers = _assetsService.GetPassengers(id),
                Bags = _assetsService.GetBags(id),
                Status = assetModels.Status.Name,
                Cost = assetModels.Cost,
                VIN = _assetsService.GetVIN(id),
                CurrentLocation = _assetsService.GetVehicleRentalLocation(id).Name
            };

            return View(model);
        }
    }
}
