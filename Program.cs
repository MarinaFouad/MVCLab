using Lab4.Models;
using Lab4.Service;
using Lab4.TestRepos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Lab4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
            builder.Services.AddDbContext<LabDbContext>(a =>
            {
                a.UseSqlServer("Server=DESKTOP-1T6LFVE\\SQLEXPRESS;Database=Lab;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True");
            });
            builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddTransient<IStudentRepo, StudentRepo>();
            // if list isn't static
            // builder.Services.AddSingleton<IDepartmentRepo, DepartmentTestRepo>();


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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
