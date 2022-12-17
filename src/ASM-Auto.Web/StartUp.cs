using ASM_Auto.Data;
using ASM_Auto.Data.Models;
using ASM_Auto.Data.Repository;
using ASM_Auto.Data.Seed;
using ASM_Auto.Data.Seed.Seeders.Administration;
using ASM_Auto.Data.Seed.Seeders.RolesSeed;
using ASM_Auto.Services.AutoAccessoriesServices;
using ASM_Auto.Services.Common;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


namespace ASM_Auto.Web
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ASMAutoDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ASMAutoDbContext>();
            builder.Services.AddControllersWithViews();


            builder.Services.AddServices();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Shared/AccessDenied";
            });

            // Cloudinary api

            builder.Services.AddSingleton(new Cloudinary(new Account("dh6kqijic", "639656954689724", "yyBqb6eizRMvAYp27ZSN6W4-OkU")));

            builder.Services.AddControllersWithViews(
              options =>
              {
                  options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
              });

            builder.Services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });

            var app = builder.Build();

            //Seed Data

            using (var scope = app.Services.CreateScope())
            {
               var dbContext = scope.ServiceProvider.GetRequiredService<ASMAutoDbContext>();
               var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
               var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var cartService = scope.ServiceProvider.GetRequiredService<ICartService>();
               

                dbContext.Database.Migrate();

             
                new ASMAutoDbSeeder().SeedAsync(dbContext).GetAwaiter().GetResult();

                new RolesSeeder(roleManager).SeedRoles().GetAwaiter().GetResult();
                new AdminSeed(userManager,cartService).SeedAsync(dbContext).GetAwaiter().GetResult();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
            endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.MapRazorPages();

            app.Run();
        }
    }
}