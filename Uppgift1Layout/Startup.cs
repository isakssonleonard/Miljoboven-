using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Uppgift1Layout.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Uppgift1Layout
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IHostingEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsetting.json")
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDBContext>(options => options.UseSqlServer(
            _configuration["Data:miljobovenidentity:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Cookies.ApplicationCookie.LoginPath = "/Login/Login";
                options.Cookies.ApplicationCookie.AccessDeniedPath = "/Login/AccessDenied";
                // ta bort sedan automaticauthenicate
                options.Cookies.ApplicationCookie.AutomaticAuthenticate = true;
            })
            .AddEntityFrameworkStores<AppIdentityDBContext>();
            services.AddSession();
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
            _configuration["Data:miljobovencon:ConnectionString"]));
            services.AddTransient<IRepository, EFModelRepository>();
            // ta bort sen nedan services.tryaddsingelton()
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseSession();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvcWithDefaultRoute();
            DBInitializer.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
