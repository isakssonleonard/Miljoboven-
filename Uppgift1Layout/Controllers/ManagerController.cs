using Microsoft.AspNetCore.Mvc;
using Session.Infrastructure;
using Uppgift1Layout.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Uppgift1Layout.Controllers
{
    [Authorize(Roles = "manager")]
    public class ManagerController : Controller
    {
        private IRepository _model;
        private IHttpContextAccessor _httpContextAccessor;

        public ManagerController(IRepository model, IHttpContextAccessor httpContextAccessor)
        {
            _model = model;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: /<controller>/
        public IActionResult Startmanager()
        {
            // lägger in det som kommer från httpcontext i en viewbag som sedan används i view för att få fram rätt data till den akutella användaren
            ViewBag.name = this._httpContextAccessor.HttpContext.User.Identity.Name;
            return View(_model);
        }

        public IActionResult Crimemanager(int id)
        {
            ViewBag.id = id;
            HttpContext.Session.SetJson("id", id);
            ViewBag.ListOfEmployees = _model.Employees;
            return View();
        }

        [HttpPost]
        public IActionResult SavesChanges(Case crimecase)
        {
            // får värdet från checkboxen antigen "on" det är den är incheckad och null då är det inte checkad 
            string check = HttpContext.Request.Form["noAction"];

            // lägger in case ID från session till ett case object
            crimecase.ID = HttpContext.Session.GetJson<int>("id");
            HttpContext.Session.Remove("id");

            // om värdet är on så har användaren checkat checkboxen och om den är null så har användaren ej checkat den
            if (check == "on")
            {
                // Lägger till Ingen åtgärd på status om checkboxen är checkad
                crimecase.Status = "Ingen åtgärd";
                // skickar till metoden
                _model.UpdateCrimeStatus(crimecase);
            }

            // kollar om den är olika välj om det är så skrivs den in i och sparas i databasen           
            if (crimecase.Employee != "Välj")
            {
                // Skicakr in objecten till metoderna som uppdaterar
                _model.UpdateCrimeEmployee(crimecase);
            }
            
            // kollar om den är olika Ange motivering om det är så skrivs den in i och sparas i databasen
            if (crimecase.Info.ToLower() != "ange motivering")
            {
                // Skicakr in objecten till metoderna som uppdaterar
                _model.UpdateCrimeInfo(crimecase);
            }

            // skicakr till baka användaren till startsidan av denna login typ
            return RedirectToAction("Startmanager", "Manager");
        }
    }
}
