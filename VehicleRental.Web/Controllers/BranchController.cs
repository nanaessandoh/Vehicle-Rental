using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Service.Interfaces;
using VehicleRental.Web.Models.Branch;

namespace VehicleRental.Web.Controllers
{
    public class BranchController : Controller
    {
        private readonly IVehicleRentalBranch _branchService;

        public BranchController(IVehicleRentalBranch branchService)
        {
            _branchService = branchService;
        }



        public IActionResult Index()
        {
            var allBranchesModel = _branchService.GetAll();

            var listingResult = allBranchesModel
                .Select(result => new BranchIndexListingModel
                {
                    BranchId = result.Id,
                    Name = result.Name,
                    Address = result.Address,
                    Location = result.City + ", " + result.Province,
                    Telephone = result.Telephone,
                    ImageUrl = result.ImageUrl
                });

            var model = new BranchIndexModel
            {
                Branches = listingResult
            };

            return View(model);
        }


        public IActionResult Detail(int id)
        {
            var branchModel = _branchService.GetById(id);
            var model = new BranchDetailModel
            {
                BranchId = id,
                Name = branchModel.Name,
                Address = branchModel.Address,
                Location = branchModel.City + ", " + branchModel.Province,
                ImageUrl = branchModel.ImageUrl,
                Telephone = branchModel.Telephone,
                OpenDate = branchModel.OpenDate.ToString("yyyy-MM-dd"),
                HoursOpen = _branchService.GetBranchHours(id),
                IsOpen = _branchService.IsBranchOpen(id),
                BranchAssets = _branchService.GetAssets(id),
                NumberOfAssets = _branchService.GetAssets(id).Count()
            };

            return View(model);
        }

    }
}
