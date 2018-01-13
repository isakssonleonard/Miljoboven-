using System.Collections.Generic;
using System.Threading.Tasks;

namespace Uppgift1Layout.Models
{
    public interface IRepository
    {
        // Create
        void SaveCrimeReport(Case crimecase);

        // Read
        IEnumerable<Case> Cases { get; }

        // skapar en signatur för GetOneCrimeReport metoden som sedan implenteras i EFModelRepository.cs
        Task<Case> GetOneCrimeReport(int id);

        IEnumerable<Employee> Employees { get; }

        IEnumerable<Status> Status { get; }

        IEnumerable<Department> Departments { get; }

        // Update

        // skapar en signatur för UpdateCrimeDepartment metoden som sedan implenteras i EFModelRepository.cs
        void UpdateCrimeDepartment(Case crimecase);

        // skapar en signatur för UpdateCrime metoden som sedan implenteras i EFModelRepository.cs
        void UpdateCrimeStatus(Case crimecase);

        // skapar en signatur för UpdateCrimeStatus metoden som sedan implenteras i EFModelRepository.cs
        void UpdateCrimeEmployee(Case crimecase);

        // skapar en signatur för UpdateCrimeStatus metoden som sedan implenteras i EFModelRepository.cs
        void UpdateCrimeInfo(Case crimecase);

        // skapar en signatur för UpdateCrimeAction metoden som sedan implenteras i EFModelRepository.cs
        void UpdateCrimeAction(Case crimecase);

        // skapar en signatur för UpdateCrimeSample metoden som sedan implenteras i EFModelRepository.cs
        void UpdateCrimeSample(Case crimecase);

        // skapar en signatur för UpdateCrimePicture metoden som sedan implenteras i EFModelRepository.cs
        void UpdateCrimePicture(Case crimecase);

        // Delete 

    }
}
