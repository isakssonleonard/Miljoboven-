using Microsoft.AspNetCore.Mvc;
using Uppgift1Layout.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Uppgift1Layout.Models.POCO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Session.Infrastructure;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Uppgift1Layout.Controllers
{
    [Authorize(Roles = "investigator")]
    public class InvestigatorController : Controller
    {
        private IRepository _model;
        private IHostingEnvironment _environment;
        private IHttpContextAccessor _httpContextAccessor;
  
        public InvestigatorController(IRepository model, IHostingEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            _model = model;
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: /<controller>/
        public IActionResult Startinvestigator()
        {
            // lägger in det som kommer från httpcontext i en viewbag som sedan används i view för att få fram rätt data till den akutella användaren
            ViewBag.ID = this._httpContextAccessor.HttpContext.User.Identity.Name;
            return View(_model);
        }

        public IActionResult Crimeinvestigator(int id)
        {
            if (id != 0)
            {
                ViewBag.id = id;
                HttpContext.Session.SetJson("id", id);
                return View(_model.Status);
            }

            ViewBag.id = HttpContext.Session.GetJson<int>("id");
            return View(_model);
        }

        [HttpPost]
        public IActionResult Upload(IFormFile Document, IFormFile Picture)
        {
            // hämtar värderna i textarea och dropdown menyn
            string actiontext = HttpContext.Request.Form["events"];
            string infotext = HttpContext.Request.Form["information"];
            string statustext = HttpContext.Request.Form["status"];

            // skapar ett case object
            var crimecase = new Case();

            // lägger in id from session
            int ID = HttpContext.Session.GetJson<int>("id");

            // lägger in ID i objectet
            crimecase.ID = ID;

            // tar bort session
            HttpContext.Session.Remove("id");

            // följande if satser kollar att inte olämpliga värdern kommer in
            if (statustext != "Välj")
            {
                crimecase.Status = statustext;
                _model.UpdateCrimeStatus(crimecase);               
            }

            if (infotext != "")
            {
                crimecase.Info = " " + infotext;
                _model.UpdateCrimeInfo(crimecase);
            }

            if (actiontext != "")
            {
                crimecase.Action = " " + actiontext;
                _model.UpdateCrimeAction(crimecase);
            }

            // kollar om mappen inte är tom
            if (Document != null && Document.Length > 0)
            {
                // sökvägen till mappen 
                var filePath = Path.Combine(_environment.WebRootPath, "Samples", Document.FileName);

                // sparar filen och stänger streamen
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Document.CopyToAsync(stream);
                    stream.Dispose();
                }

                var samplePath = Path.Combine(_environment.WebRootPath, "Samples", Document.FileName);
                samplePath = Path.GetFileName(Document.FileName);
                crimecase.Samples = new List<Sample>();
                crimecase.Samples.Add(new Sample() { CaseID = ID, SampleName = samplePath });
                // Skickar in objectet i metoden
                _model.UpdateCrimeSample(crimecase);
            }

            if (Picture != null)
            {
                // sökvägen till mappen 
                var filePath = Path.Combine(_environment.WebRootPath, "Pictures", Picture.FileName);
                // sparar filen och stänger streamen
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Picture.CopyToAsync(stream);
                    stream.Dispose();
                }

                // lägger in sökvägarna i objectet
                var picturePath = Path.Combine(_environment.WebRootPath, "Pictures", Picture.FileName);
                picturePath = Path.GetFileName(Picture.FileName);
                crimecase.Pictures = new List<Picture>();
                crimecase.Pictures.Add(new Picture() { CaseID = ID, PictureName = picturePath });
                // Skickar in objectet i metoden
                _model.UpdateCrimePicture(crimecase);
            }
            // skickar tillbaka användaren till starten
            return RedirectToAction("Startinvestigator", "Investigator");
        }
    }
}
