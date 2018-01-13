using Microsoft.AspNetCore.Mvc;
using Uppgift1Layout.Models;
using System.Threading.Tasks;
using System;

namespace Uppgift1Layout.Components
{
    public class CrimeReportViewComponent : ViewComponent
    {
        private IRepository _model;

        public CrimeReportViewComponent(IRepository model)
        {
            _model = model;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            // Denna metod skickar datan till partial viewen
            
            // Här hämtas ett case object i genom GetOneCrimeReport metoden
            var crimeReport = await _model.GetOneCrimeReport(id);
            // Retunerar till partial viewen med objectet av typen Case
            return View("CrimeReportLayout", crimeReport);
        }
    }
}