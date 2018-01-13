using Microsoft.AspNetCore.Mvc;
using Session.Infrastructure;
using Uppgift1Layout.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Uppgift1Layout.Controllers
{
    public class CitizenController : Controller
    {
        // GET: /<controller>/

        private IRepository _model;

        public CitizenController(IRepository model)
        {
            _model = model;
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Thanks()
        {
            // sparar crimet 
            var CaseCrime = HttpContext.Session.GetJson<Case>("Crime");
            CaseCrime.RefNumber = "2017-45-";
            CaseCrime.Status = "inrapporterad";
            _model.SaveCrimeReport(CaseCrime);
            
            // lägger in data i viewbag
            var crimecase = _model.Cases.ToList()[_model.Cases.ToList().Count - 1];
            ViewBag.löpnummer = crimecase.RefNumber + crimecase.ID;

            // tar bort session data
            HttpContext.Session.Remove("Crime");
            return View();
        }

        public IActionResult Validate()
        {         
            return View();
        }
    }
}
