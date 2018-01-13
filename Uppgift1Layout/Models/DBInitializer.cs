using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;

namespace Uppgift1Layout.Models
{
    public class DBInitializer
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDBContext context = app.ApplicationServices.GetRequiredService<ApplicationDBContext>();
            // Denna klass hanterar att man får all data till applikationen 
            // if satsen testar om det finns något i _context vänder på utrycket om det inte finns något så vänds det med ! till att det blir true
            if (!context.Cases.Any())
            {
                 context.AddRange(
                     new Case
                     {
                         RefNumber = "2017-45-",
                         Place = "Skogslunden vid Jensens gård",
                         TypeofCrime = "Sopor",
                         DateTimeOfObservation = new DateTime(2017, 04, 24),
                         Observation = "Anmälaren var på promenad i skogslunden när hon upptäckte soporna",
                         Info = "Undersökning har gjorts och bland soporna hittades bl.a ett brev till Gösta Olsson",
                         Action = "Brev har skickats till Gösta Olsson om soporna och anmälan har gjorts till polisen 2017-05-10",
                         InformerName = "Ada Bengtsson",
                         InformerPhone = "0432-5545522",
                         Status = "Klar",
                         Department = "Renhållning och avfall",
                         Employee = "Susanne Fred"
                    },

                    new Case
                    {
                        RefNumber = "2017-45-",
                        Place = "Småstadsjön",
                        TypeofCrime = "Oljeutsläpp",
                        DateTimeOfObservation = new DateTime(2017, 04, 29),
                        Observation = "Jag såg en oljefläck på vattnet när jag var där för att fiska",
                        Info = "Undersökning gjorts på plats, ingen fläck har hittats",
                        Action = "",
                        InformerName = "Bengt Svensson",
                        InformerPhone = "0432-5152255",
                        Status = "Ingen åtgärd",
                        Department = "Tekniska Avloppshanteringen",
                        Employee = ""
                    },

                    new Case
                    {
                        RefNumber = "2017-45-",
                        Place = "Ödehuset",
                        TypeofCrime = "Skrot",
                        DateTimeOfObservation = new DateTime(2017, 05, 02),
                        Observation = "Anmälaren körde förbi ödehuset och upptäcket ett antal bilar och annat skrot",
                        Info = "Undersökning har gjorts och bilder tagits",
                        Action = "",
                        InformerName = "Olle Pettersson",
                        InformerPhone = "0432-5255522",
                        Status = "Påbörjad",
                        Department = "Miljö och Hälsoskydd",
                        Employee = "Lena Larsson"
                    },

                    new Case
                    {
                        RefNumber = "2017-45-",
                        Place = "Restaurang Krögaren",
                        TypeofCrime = "Buller",
                        DateTimeOfObservation = new DateTime(2017, 06, 04),
                        Observation = "Restaurang hade för högt ljud på så man kunde inte sova",
                        Info = "Bullermätning har gjorts. Håller sig inom riktvärden.",
                        Action = "Meddelat restaurangen att tänka på ljudet i fortsättningen",
                        InformerName = "Roland Jönsson",
                        InformerPhone = "0432-5322255",
                        Status = "Klar",
                        Department = "Miljö och Hälsoskydd",
                        Employee = "Martin Kvist"
                    },

                    new Case
                    {
                        RefNumber = "2017-45-0005",
                        Place = "Torget",
                        TypeofCrime = "Klotter",
                        DateTimeOfObservation = new DateTime(2017, 07, 10),
                        Observation = "Samtliga skräpkorgar och bänkar är nedklottrade",
                        Info = "",
                        Action = "",
                        InformerName = "Peter Svensson",
                        InformerPhone = "0432-5322555",
                        Status = "Inrapporterad",
                        Department = "Ej tillsatt",
                        Employee = "Ej tillsatt"
                    }
                );
                context.SaveChanges();
            }

            if (!context.Departments.Any())
            {
                context.AddRange(
                     new Department { DepartmentName = "Småstads Kommun" },
                     new Department { DepartmentName = "Tekniska Avloppshanteringen", },
                     new Department { DepartmentName = "Klimat och Energi" },
                     new Department { DepartmentName = "Miljö och Hälsoskydd" },
                     new Department { DepartmentName = "Natur och Skogsvård" },
                     new Department { DepartmentName = "Renhållning och Avfall" }
                );
                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                context.AddRange(
                    // Småstads Kommun
                    new Employee { EmployeeID = "E001", EmployeeName = "Östen Ärling", RoleTitle = "coordinator", Department = "Småstads Kommun" },

                    // Tekniska Avloppshanteringen 
                    new Employee { EmployeeID = "E100", EmployeeName = "Anna Åkerman", RoleTitle = "manager", Department = "Tekniska Avloppshanteringen" },
                    new Employee { EmployeeID = "E101", EmployeeName = "Fredrik Roos", RoleTitle = "investigator", Department = "Tekniska Avloppshanteringen" },
                    new Employee { EmployeeID = "E102", EmployeeName = "Gösta Qvist", RoleTitle = "investigator", Department = "Tekniska Avloppshanteringen" },
                    new Employee { EmployeeID = "E103", EmployeeName = "Hilda Persson", RoleTitle = "investigator", Department = "Tekniska Avloppshanteringen" },

                    // Klimat och Energi
                    new Employee { EmployeeID = "E200", EmployeeName = "Bengt Viik", RoleTitle = "manager", Department = "Klimat och Energi" },
                    new Employee { EmployeeID = "E201", EmployeeName = "Ivar Oscarsson", RoleTitle = "investigator", Department = "Klimat och Energi" },
                    new Employee { EmployeeID = "E202", EmployeeName = "Jenny Nordström", RoleTitle = "investigator ", Department = "Klimat och Energi" },
                    new Employee { EmployeeID = "E203", EmployeeName = "Kurt Mild", RoleTitle = "investigator", Department = "Klimat och Energi" },

                    // Miljö och Hälsoskydd
                    new Employee { EmployeeID = "E300", EmployeeName = "Cecilia Unosson", RoleTitle = "manager", Department = "Miljö och Hälsoskydd" },
                    new Employee { EmployeeID = "E301", EmployeeName = "Lena Larsson", RoleTitle = "investigator", Department = "Miljö och Hälsoskydd" },
                    new Employee { EmployeeID = "E302", EmployeeName = "Martin Kvist", RoleTitle = "investigator", Department = "Miljö och Hälsoskydd" },
                    new Employee { EmployeeID = "E303", EmployeeName = "Nina Jansson", RoleTitle = "investigator", Department = "Miljö och Hälsoskydd" },

                    // Natur och Skogsvård 
                    new Employee { EmployeeID = "E400", EmployeeName = "David Trastlund", RoleTitle = "manager", Department = "Natur och Skogsvård" },
                    new Employee { EmployeeID = "E401", EmployeeName = "Oskar Ivarsson" , RoleTitle = "investigator", Department = "Natur och Skogsvård" },
                    new Employee { EmployeeID = "E402", EmployeeName = "Petra Hermansdotter", RoleTitle = "investigator", Department = "Natur och Skogsvård" },
                    new Employee { EmployeeID = "E403", EmployeeName = "Rolf Gunnarsson", RoleTitle = "investigator", Department = "Natur och Skogsvård" },

                    // Renhållning och Avfall 
                    new Employee { EmployeeID = "E500", EmployeeName = "Emma Svanberg", RoleTitle = "manager", Department = "Renhållning och Avfall" },
                    new Employee { EmployeeID = "E501", EmployeeName = "Susanne Fred", RoleTitle = "investigator", Department = "Renhållning och Avfall" },
                    new Employee { EmployeeID = "E502", EmployeeName = "Torsten Embjörn", RoleTitle = "investigator", Department = "Renhållning och Avfall" },
                    new Employee { EmployeeID = "E503", EmployeeName = "Ulla Davidsson", RoleTitle = "investigator", Department = "Renhållning och Avfall" }
                );
                context.SaveChanges();
            }

            if (!context.Status.Any())
            {
                context.Status.AddRange(
                    new Status { StatusID = "S_A", StatusName = "Inrapporterad " },
                    new Status { StatusID = "S_B", StatusName = "Ingen åtgärd" },
                    new Status { StatusID = "S_C", StatusName = "Påbörjad" },
                    new Status { StatusID = "S_D", StatusName = "Klar" }
                );
                context.SaveChanges();
            }


        }
    }
}
