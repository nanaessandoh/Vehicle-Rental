﻿using System;
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
                HoldHistory = _checkoutService.GetCurrentHolds(id),
                CheckoutHistoryCount = _checkoutService.GetCheckoutHistory(id).Count(),
                HoldHistoryCount = _checkoutService.GetCurrentHolds(id).Count()
            };

            return View(model);
        }



        public IActionResult CheckOut(int id)
        {
            var assetModel = _assetsService.GetById(id);

            var model = new CheckoutModel
            {
                AssetId = id,
                ImageUrl = assetModel.ImageUrl,
                Make = assetModel.Make,
                Model = assetModel.Model,
                IsCheckedOut = _checkoutService.IsCheckedout(id)
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult PlaceCheckout(int assetId, int driverLicenseId)
        {
            _checkoutService.CheckOutItem(assetId, driverLicenseId);
            return RedirectToAction("Detail", new { id = assetId });
        }

        [HttpPost]
        public IActionResult CheckIn(int assetId, int driverLicenseId)
        {
            _checkoutService.CheckInItem(assetId);
            return RedirectToAction("Detail", new { id = assetId });
        }

        [HttpPost]
        public IActionResult PlaceHold(int assetId, int driverLicenseId)
        {
            _checkoutService.PlaceHold(assetId);
            return RedirectToAction("Detail", new { id = assetId });
        }

        [HttpPost]
        public IActionResult MarkStolen(int assetId, int driverLicenseId)
        {
            _checkoutService.MarkStolen(assetId);
            return RedirectToAction("Detail", new { id = assetId });
        }

        [HttpPost]
        public IActionResult MarkAvailable(int assetId, int driverLicenseId)
        {
            _checkoutService.MarkAvailable(assetId);
            return RedirectToAction("Detail", new { id = assetId });
        }
    }
}
