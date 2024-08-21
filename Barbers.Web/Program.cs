using Barber.Data.Context;
using Barbers.Core.Services.Premition;
using Barbers.Core.Services.Product;
using Barbers.Core.Services.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Barbers.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages();


            #region DbContext

            builder.Services.AddDbContext<BarbersContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Barbers_Connection"));
            });

            #endregion

            #region IOC

            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IPremitionService, PremitionService>();
             builder.Services.AddTransient<IProductService, ProductService>();

            #endregion


            #region Authentication


            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(option =>
            {
                option.LoginPath = "/Login";
                option.LogoutPath = "/Logout";
                option.ExpireTimeSpan = TimeSpan.FromDays(60);
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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
            
            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}"
            );


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapRazorPages();
            });

           






            app.Run();
        }
    }
}
