using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VehicleRental.Web.Controllers
{
    public class BranchController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
