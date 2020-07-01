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
                    PatronRentalBranch = result.VehicleRentalBranch.Name
                });

            var model = new PatronIndexModel()
            {
                Patrons = listingResult
            };

            return View(model);
        }
    }
}
