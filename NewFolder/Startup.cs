using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neupusti.Data;
using Microsoft.EntityFrameworkCore;
using Neupusti.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Neupusti.Data.FileManager;
using Microsoft.AspNetCore.Mvc;

namespace Neupusti
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=App;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<AppDbContext>
                (options => options.UseSqlServer(connection));

        


            services.AddIdentity<Neupusti.Models.User, IdentityRole>(options => 
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminAccess", policy => policy.RequireRole("Admin"));
                options.AddPolicy("PremiumUSerAccess", policy =>
                    policy.RequireAssertion(context => context.User.IsInRole("Admin")
                    || context.User.IsInRole("PremiumUser")));
                options.AddPolicy("UserAccess", policy =>
                    policy.RequireAssertion(context => context.User.IsInRole("Admin")
                    || context.User.IsInRole("PremiumUser")
                    || context.User.IsInRole("User")));
            }
                );

            services.AddMvc(options =>
                options.CacheProfiles.Add("Monthly", new CacheProfile { Duration = 60 * 60 * 24 * 7 * 4 })
                );

            services.AddTransient<IRepository, Repository>();

            services.AddTransient<IFileManager, FileManager>();
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
