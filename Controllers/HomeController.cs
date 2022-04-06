using CrashUtahProject.Models;
using CrashUtahProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Data(string searchByCity, string searchByCounty, string searchBySeverity, int pageNum = 1)
        {
            int pageSize = 25;

            if (searchByCity == null && searchByCounty == null && searchBySeverity == null)
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
                    .Where(x => x.city.Contains(searchByCity)
                    && x.county_name.Contains(searchByCounty)
                    && x.crash_severity_id.ToString().Contains(searchBySeverity))
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

        [Authorize]
        [HttpGet]
        public IActionResult CreateAccident()
        {
            return View("Editor");
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateAccident(Accident a)
        {

            if (ModelState.IsValid)
            {
                a.crash_id = (repo.Accidents.Max(x => x.crash_id)) + 1;
                repo.CreateAccident(a);
                return RedirectToAction("Data");

            }
            else
            {
                return View("Editor", a);
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int crash_id)
        {
            var accident = repo.Accidents.Single(x => x.crash_id == crash_id);
            return View("Editor", accident);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Accident accident)
        {
            repo.SaveAccident(accident);
            return RedirectToAction("Data");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(int crash_id)
        {
            var accident = repo.Accidents.FirstOrDefault(x => x.crash_id == crash_id);

            return View(accident);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(Accident accident)
        {
            repo.DeleteAccident(accident);

            return RedirectToAction("Data");
        }
    }
}