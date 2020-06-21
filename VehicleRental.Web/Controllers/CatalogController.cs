using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using VehicleRental.Web.Models.Catalog;
using VehicleRental.Data;

namespace VehicleRental.Web.Controllers
{
    public class CatalogController : Controller
    {

        private readonly IVehicleRentalAsset _assetsService;

        // Constructor to enable us access IVehicleRentalAsset object
        public CatalogController(IVehicleRentalAsset assetsService)
        {
            _assetsService = assetsService;
        }
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
                    Options = _assetsService.GetOptions(result.Id),
                    BodyType = _assetsService.GetBodyType(result.Id),
                    Passengers = _assetsService.GetPassengers(result.Id),
                    Bags = _assetsService.GetBags(result.Id)
                });

            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };

            return View(model);
        }
    }
}
