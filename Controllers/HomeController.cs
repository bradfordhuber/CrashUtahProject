using CrashUtahProject.Models;
using CrashUtahProject.Models.ViewModels;
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

        public IActionResult Data(string searchByID, string searchByCity, int pageNum = 1)
        {
            int pageSize = 25;

            if (searchByID == null && searchByCity == null)
            {
                var x = new AccidentsViewModel
                {
                    Accidents = repo.Accidents
                    .OrderBy(x => x.crash_id)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                    PageInfo = new PageInfo
                    {
                        TotalNumAccidents = repo.Accidents.Count(),
                        AccidentsPerPage = pageSize,
                        CurrentPage = pageNum
                    }
                };

                return View(x);
            }
            else
            {
                searchByID = searchByID ?? "%";

                var x = new AccidentsViewModel
                {
                    Accidents = repo.Accidents
                    .Where(x => x.crash_id.ToString().Contains(searchByID) && x.city.Contains(searchByCity))
                    .OrderBy(x => x.crash_id)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                    PageInfo = new PageInfo
                    {
                        TotalNumAccidents = repo.Accidents.Count(),
                        AccidentsPerPage = pageSize,
                        CurrentPage = pageNum
                    }
                };

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
