using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Web.Models.Catalog;
using VehicleRental.Data;
using VehicleRental.Web.Models.Checkout;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace VehicleRental.Web.Controllers
{
    public class CatalogController : Controller
    {

        private readonly IVehicleRentalAsset _assetsService;
        private readonly ICheckout _checkoutService;
        private readonly IPatron _patronService;

        // Constructor to enable us access IVehicleRentalAsset object
        public CatalogController(IVehicleRentalAsset assetsService, ICheckout checkoutService, IPatron patronService)
        {
            _assetsService = assetsService;
            _checkoutService = checkoutService;
            _patronService = patronService;

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
                VIN = assetModels.VIN,
                ImageUrl = assetModels.ImageUrl,
                Status = assetModels.Status.Name,
                Cost = assetModels.Cost,
                BodyType = _assetsService.GetBodyType(id),
                Options = _assetsService.GetOptions(id),
                Passengers = _assetsService.GetPassengers(id),
                Bags = _assetsService.GetBags(id),
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
            var patrolModel = _patronService.GetPatronList();

           

            var model = new CheckoutModel
            {
                AssetId = id,
                DriverLicenseId = 0,
                SelectedPatronId = 0,
                PatronDetails = ConvertToSelectListItem(patrolModel), 
                NumberOfRentalDays = 0,
                ImageUrl = assetModel.ImageUrl,
                Make = assetModel.Make,
                Model = assetModel.Model,
                IsCheckedOut = _checkoutService.IsCheckedout(id)
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult PlaceCheckout(int assetId, int selectedPatronId, int numberOfRentalDays)
        {
            if (isCheckoutConditionMet(selectedPatronId,numberOfRentalDays))
            {
                _checkoutService.CheckOutItem(assetId, selectedPatronId, numberOfRentalDays);
                return RedirectToAction("Detail", new { id = assetId });
            }

            return RedirectToAction("CheckOut", new { id = assetId });
        }


        public IActionResult CheckIn(int id)
        {
            _checkoutService.CheckInItem(id);
            return RedirectToAction("Detail", new { Id = id });
        }

        public IActionResult PlaceHold(int id)
        {
            _checkoutService.PlaceHold(id);
            return RedirectToAction("Detail", new { Id = id });
        }

        public IActionResult MarkStolen(int id)
        {
            _checkoutService.MarkStolen(id);
            return RedirectToAction("Detail", new { Id = id });
        }

        public IActionResult MarkAvailable(int id)
        {
            _checkoutService.MarkAvailable(id);
            return RedirectToAction("Detail", new { Id = id });
        }


        // Helper Methods
        public IEnumerable<SelectListItem> ConvertToSelectListItem(IEnumerable<PatronList> list)
        {
            return from PatronList asset in list
                   select new SelectListItem
                   {
                       Value = asset.DriverLicenseId.ToString(),
                       Text = asset.PatronDetails
                   };
        }


        private bool isCheckoutConditionMet(int selectedPatronId, int numberOfRentalDays)
        {
            return numberOfRentalDays > 0 && numberOfRentalDays < 29 && selectedPatronId != 0;
        }



    }
}
