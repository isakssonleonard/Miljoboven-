using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Uppgift1Layout.Models;

namespace Uppgift1Layout.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Uppgift1Layout.Models.Case", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<DateTime>("DateTimeOfObservation");

                    b.Property<string>("Department");

                    b.Property<string>("Employee");

                    b.Property<string>("Info");

                    b.Property<string>("InformerName")
                        .IsRequired();

                    b.Property<string>("InformerPhone");

                    b.Property<string>("Observation");

                    b.Property<string>("Place")
                        .IsRequired();

                    b.Property<string>("RefNumber");

                    b.Property<string>("Status");

                    b.Property<string>("TypeofCrime")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("Uppgift1Layout.Models.Department", b =>
                {
                    b.Property<string>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentName");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Uppgift1Layout.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Department");

                    b.Property<string>("EmployeeName");

                    b.Property<string>("RoleTitle");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Uppgift1Layout.Models.POCO.Picture", b =>
                {
                    b.Property<int>("PictureID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CaseID");

                    b.Property<string>("PictureName");

                    b.HasKey("PictureID");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Uppgift1Layout.Models.POCO.Sample", b =>
                {
                    b.Property<int>("SampleID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CaseID");

                    b.Property<string>("SampleName");

                    b.HasKey("SampleID");

                    b.ToTable("Samples");
                });

            modelBuilder.Entity("Uppgift1Layout.Models.Status", b =>
                {
                    b.Property<string>("StatusID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StatusName");

                    b.HasKey("StatusID");

                    b.ToTable("Status");
                });
        }
    }
}
