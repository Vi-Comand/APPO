using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor;
using Microsoft.EntityFrameworkCore;
using SISPR.Models.DataBase;
using SISPR.Models.DataBase.Basic.User;

namespace SISPR
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "server=localhost;user=root;password=123456;database=iro23_appo"; // Replace with your server version and type.
            // Use 'MariaDbServerVersion' for MariaDB.
            // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
            // For common usages, see pull request #1233.
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 26)); // Replace 'YourDbContext' with the name of your own DbContext derived class.

            services.AddDbContext<IdentityContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion).EnableSensitiveDataLogging()); // <-- These two calls are optional but help .EnableDetailedErrors() //   );




            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();


            services.AddControllersWithViews();

          services.AddDbContext<Context>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion).EnableSensitiveDataLogging()); // <-- These two calls are optional but help .EnableDetailedErrors() //   );

            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
