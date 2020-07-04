using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using VehicleRental.Web.Models.Catalog;
using VehicleRental.Data;
using VehicleRental.Data.Models;
using VehicleRental.Web.Models.Checkout;

namespace VehicleRental.Web.Controllers
{
    public class CatalogController : Controller
    {

        private readonly IVehicleRentalAsset _assetsService;
        private readonly ICheckout _checkoutService;

        // Constructor to enable us access IVehicleRentalAsset object
        public CatalogController(IVehicleRentalAsset assetsService, ICheckout checkoutService)
        {
            _assetsService = assetsService;
            _checkoutService = checkoutService;

        }
        public IActionResult Index()
        {
            var allAssetModel = _assetsService.GetAll();

            var listingResult = allAssetModel
                .Select(result => new AssetIndexListingModel 
                {
                    AssetId = result.Id,
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
                AssetId = id,
                Make = assetModels.Make,
                Model = assetModels.Model,
                ImageUrl = assetModels.ImageUrl,
                Status = assetModels.Status.Name,
                Cost = assetModels.Cost,
                BodyType = _assetsService.GetBodyType(id),
                Options = _assetsService.GetOptions(id),
                Passengers = _assetsService.GetPassengers(id),
                Bags = _assetsService.GetBags(id),
                VIN = _assetsService.GetVIN(id),
                CurrentLocation = _assetsService.GetVehicleRentalLocation(id).Name,
                PatronName = _checkoutService.GetCurrentCheckoutPatron(id),
                LatestCheckout = _checkoutService.GetLatestCheckout(id),
                CheckoutHistory = _checkoutService.GetCheckoutHistory(id),
                HoldHistory = _checkoutService.GetCurrentHolds(id)
            };

            return View(model);
        }



        public IActionResult CheckOut(int id)
        {
            var assetModel = _assetsService.GetById(id);

            var model = new CheckoutModel
            {
                AssetId = id,
                DriverLicenseId = 0,
                NumberOfRentalDays = 0,
                ImageUrl = assetModel.ImageUrl,
                Make = assetModel.Make,
                Model = assetModel.Model,
                IsCheckedOut = _checkoutService.IsCheckedout(id)
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult PlaceCheckout(int assetId, int driverLicenseId, int numberOfRentalDays)
        {
            _checkoutService.CheckOutItem(assetId, driverLicenseId, numberOfRentalDays);
            return RedirectToAction("Detail", new { id = assetId });
        }

        public IActionResult CheckIn(int id)
        {
            _checkoutService.CheckInItem(id);
            return RedirectToAction("Detail", new { id = id });
        }

        public IActionResult PlaceHold(int id)
        {
            _checkoutService.PlaceHold(id);
            return RedirectToAction("Detail", new { id = id });
        }

        public IActionResult MarkStolen(int id)
        {
            _checkoutService.MarkStolen(id);
            return RedirectToAction("Detail", new { id = id });
        }

        public IActionResult MarkAvailable(int id)
        {
            _checkoutService.MarkAvailable(id);
            return RedirectToAction("Detail", new { id = id });
        }
    }
}
