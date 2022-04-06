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

        public IActionResult Data(string searchByCity, string searchByCounty, int pageNum = 1)
        {
            int pageSize = 25;

            if (searchByCity == null && searchByCounty == null)
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
                var x = new AccidentsViewModel
                {
                    Accidents = repo.Accidents
                    .Where(x => x.city.ToString().Contains(searchByCity) && x.county_name.Contains(searchByCounty))
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
