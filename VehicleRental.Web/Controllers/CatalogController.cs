using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using VehicleRental.Web.Models.Catalog;
using VehicleRental.Data;

namespace VehicleRental.Controllers
{
    public class CatalogController : Controller
    {

        private IVehicleRentalAsset _assets;

        // Constructor to enable us access IVehicleRentalAsset object
        public CatalogController(IVehicleRentalAsset assets)
        {
            _assets = assets;
        }
        public IActionResult Index()
        {
            var assetModels = _assets.GetAll();
            var listingResult = assetModels
                .Select(result => new AssetIndexListingModel {

                    Id = result.Id,
                    Make = result.Make,
                    Model = result.Model,  
                    ImageUrl = result.ImageUrl,
                    Options = _assets.GetOptions(result.Id),
                    BodyType = _assets.GetBodyType(result.Id),
                    Passengers = _assets.GetPassengers(result.Id),
                    Bags = _assets.GetBags(result.Id)

                }) ;

            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };

            return View(model);
        }
    }
}
