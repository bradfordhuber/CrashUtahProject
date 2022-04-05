using CrashUtahProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrashUtahProject.Controllers
{
    public class HomeController : Controller
    {

        private IAccidentRepository repo { get; set; }

        public HomeController(IAccidentRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Data(string searchByID, string searchByCity)
        {

            if (searchByID == null && searchByCity == null)
            {
                var x = repo.Accidents
                    .ToList();

                return View(x);
            }
            else
            {
                var x = repo.Accidents
                    .Where(x => x.crash_id.ToString().Contains(searchByID) && x.city.Contains(searchByCity))
                    .ToList();

                return View(x);
            }

            
        }

        public IActionResult Crash(double id)
        {
            var x = repo.Accidents
                .FirstOrDefault(x => x.crash_id == id);

            return View(x);
        }
    }
}
