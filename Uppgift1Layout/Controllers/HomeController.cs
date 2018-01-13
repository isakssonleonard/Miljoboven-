using Microsoft.AspNetCore.Mvc;
using Uppgift1Layout.Models;
using Microsoft.AspNetCore.Http;
using Session.Infrastructure;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Uppgift1Layout.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            // hämtar session data sparar ner den i ett object av type case
            var crimecase = HttpContext.Session.GetJson<Case>("Crime");
            
            // testar om den är null så retunaras bara view med ingen model data
            if (crimecase == null)
            {
                return View();
            }

            // annars så finns det data då skickar jag med data till view
            else
            {
                return View(crimecase);
            }
        }

        [HttpPost]
        public IActionResult HomeCrimeReport(Case crimeCase)
        {            
            if (ModelState.IsValid)
            {
                // får in data med hjälp av sessions
                HttpContext.Session.SetJson("Crime", crimeCase);                
                return View("~/Views/Citizen/Validate.cshtml", crimeCase);
            }

            else
            {
                return View("Index");
            }            
        }
    }
}
