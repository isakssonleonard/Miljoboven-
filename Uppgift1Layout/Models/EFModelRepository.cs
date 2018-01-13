using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Uppgift1Layout.Models
{
    public class EFModelRepository : IRepository
    {
        private ApplicationDBContext _context;

        public EFModelRepository(ApplicationDBContext context)
        {
            _context = context;
        }


        public void UpdateCrimeAction(Case crimecase)
        {
            // annars så söker jag ut case objectet med ID som kommer in
            Case dbEntry = _context.Cases.FirstOrDefault(x => x.ID == crimecase.ID);

            // kollar om den är olika med null
            if (dbEntry != null)
            {
                // adderar till action kolumnen fältet
                dbEntry.Action += crimecase.Action;
            }

            _context.SaveChanges();
        }

        public void UpdateCrimeSample(Case crimecase)
        {
            // annars så söker jag ut case objectet med ID som kommer in
            Case dbEntry = _context.Cases.FirstOrDefault(x => x.ID == crimecase.ID);

            // kollar om den är olika med null
            if (dbEntry != null)
            {
                // ändrar endast sample fältet
                dbEntry.Samples = crimecase.Samples;
            }

            _context.SaveChanges();
        }

        public void UpdateCrimePicture(Case crimecase)
        {
            // annars så söker jag ut case objectet med ID som kommer in
            Case dbEntry = _context.Cases.FirstOrDefault(x => x.ID == crimecase.ID);

            // kollar om den är olika med null
            if (dbEntry != null)
            {
                // ändrar endast picture fältet
                dbEntry.Pictures = crimecase.Pictures;
            }

            _context.SaveChanges();
        }

        // Update 
        public void UpdateCrimeDepartment(Case crimecase)
        {
            // annars så söker jag ut case objectet med ID som kommer in
            Case dbEntry = _context.Cases.FirstOrDefault(x => x.ID == crimecase.ID);

            // kollar om den är olika med null
            if (dbEntry != null)
            {
                // ändrar endast department fältet
                dbEntry.Department = crimecase.Department;
            }

            _context.SaveChanges();
        }

        public void UpdateCrimeStatus(Case crimecase)
        {
            // annars så söker jag ut case objectet med ID som kommer in
            Case dbEntry = _context.Cases.FirstOrDefault(x => x.ID == crimecase.ID);

            // kollar om den är olika med null
            if (dbEntry != null)
            {
                // ändrar endast status fältet               
                dbEntry.Status = crimecase.Status;              
            }

            _context.SaveChanges();
        }

        public void UpdateCrimeEmployee(Case crimecase)
        {
            // annars så söker jag ut case objectet med ID som kommer in
            Case dbEntry = _context.Cases.FirstOrDefault(x => x.ID == crimecase.ID);

            // kollar om den är olika med null
            if (dbEntry != null)
            {
                // ändrar endast employee fältet               
                dbEntry.Employee = crimecase.Employee;
            }

            _context.SaveChanges();
        }

        public void UpdateCrimeInfo(Case crimecase)
        {
            // annars så söker jag ut case objectet med ID som kommer in
            Case dbEntry = _context.Cases.FirstOrDefault(x => x.ID == crimecase.ID);

            // kollar om den är olika med null
            if (dbEntry != null)
            {
                // adderar till info kolumnen               
                dbEntry.Info += crimecase.Info;
            }

            _context.SaveChanges();
        }

        // Create
        public void SaveCrimeReport(Case crimecase)
        {
            // Denna metod skapar ett nytt case 
            // if satsen testar om värdet är 0 så läggs crimecase in i _context
            if (crimecase.ID == 0)
            {
                _context.Cases.Add(crimecase);
            }
            _context.SaveChanges();
        }

        // Read
        // lägger in samples och pictures in i cases
        public IEnumerable<Case> Cases => _context.Cases.Include(s => s.Samples).Include(p => p.Pictures);

        public Task<Case> GetOneCrimeReport(int id) 
        {
            // får in case id matchar sedan det med ett id i cases listan och tar ut en och retunarar den 
            return Task.Run(() =>
            {
                return Cases.Where(x => x.ID == id).First();
            });
        }

        public IEnumerable<Employee> Employees => _context.Employees;

        public IEnumerable<Status> Status => _context.Status;
       
        public IEnumerable<Department> Departments => _context.Departments;       
    }
}
