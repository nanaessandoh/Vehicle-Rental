using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Data;
using VehicleRental.Web.Models.Patron;

namespace VehicleRental.Web.Controllers
{
    public class PatronController : Controller
    {

        private readonly IPatron _patronService;

        // Constructor to enable us access IVehicleRentalAsset object
        public PatronController(IPatron patronService)
        {
            _patronService = patronService;

        }

        public IActionResult Index()
        {
            var patronModel = _patronService.GetAll();

            var listingResult = patronModel
                .Select(result => new PatronIndexListingModel 
                { 
                    PatronId = result.Id,
                    Name = _patronService.GetPatronName(result.Id),
                    Address = result.Address,
                    Number = result.TelephoneNumber,
                    OverdueFees = _patronService.GetDriverLicense(result.Id).Fees,
                    PatronRentalBranch = result.VehicleRentalBranch.Name
                });

            var model = new PatronIndexModel()
            {
                Patrons = listingResult
            };

            return View(model);
        }


        public IActionResult Detail(int id)
        {
            var patronModel = _patronService.GetById(id);

            var model = new PatronDetailModel
            {
                PatronId = patronModel.Id,
                Name = _patronService.GetPatronName(id),
                Address = patronModel.Address,
                Number = patronModel.TelephoneNumber,
                OverdueFees = patronModel.DriverLicense.Fees,
                LicenseID = _patronService.GetDriverLicense(id).LicenseID,
                IssueDate = _patronService.GetDriverLicense(id).IssueDate,
                ExpiryDate = _patronService.GetDriverLicense(id).ExpiryDate,
                Checkout = _patronService.GetCheckouts(id),
                CheckoutHistory = _patronService.GetCheckoutHistories(id)
            };


            return View(model);
        }
    }
}
