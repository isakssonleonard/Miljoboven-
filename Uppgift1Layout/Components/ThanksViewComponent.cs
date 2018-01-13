using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Uppgift1Layout.Models;

namespace Uppgift1Layout.Components
{
    public class ThanksViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string number)
        {
            // lägger in data i crimecase objectet från parametern
            var crimecase = new Case();
            crimecase.RefNumber = number;
            return View(crimecase);
        }
    }
}
