using Microsoft.AspNetCore.Mvc;
using Session.Infrastructure;
using System.Linq;
using Uppgift1Layout.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Uppgift1Layout.Controllers
{
    [Authorize(Roles = "coordinator")]
    public class CoordinatorController : Controller
    {
        private IRepository _model;

        public CoordinatorController(IRepository model)
        {
            _model = model;
        }

        // GET: /<controller>/
        public IActionResult Startcoordinator()
        {
            return View(_model);
        }

        public IActionResult Crimecoordinator(int id)
        {
            ViewBag.id = id;
            HttpContext.Session.SetJson("id", id);
            ViewBag.ListOfDepartment = _model.Departments;
            return View();
        }

        public IActionResult Reportcrime()
        {
            var crimecase = HttpContext.Session.GetJson<Case>("Crime");
            
            if (crimecase == null)
            {
                return View();
            }
            else
            {
                return View(crimecase);
            }
        }

        public IActionResult Validate()
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

        public ViewResult CoordinatorCrimeReport(Case crimeCase)
        {
            if (ModelState.IsValid)
            {
                // får in data med hjälp av sessions
                HttpContext.Session.SetJson("Crime", crimeCase);
                return View("Validate", crimeCase);
            }

            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        public IActionResult SaveChanges(Department department)
        {
            // kollar om den är olika Välj så att det inte kommer in som deparment värde och inget sparas
            if (department.DepartmentName != "Välj")
            {
                // skapar case object
                var crimecase = new Case();
                // Lägger in case ID med session
                crimecase.ID = HttpContext.Session.GetJson<int>("id");
                // tar bort session data
                HttpContext.Session.Remove("Crime");
                // Lägger in deparment in i case objectet i fältet deparment
                crimecase.Department = department.DepartmentName;
                // uppdaterar värdet eller lägger till om den inte har ett värde redan
                _model.UpdateCrimeDepartment(crimecase);
            }
            // skickar tillbaka användaren tillbaka till startcoordinator
            return RedirectToAction("Startcoordinator", "Coordinator");
        }
    }
}
