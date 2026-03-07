using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCLAB2.Models;
using MVCLAB2.Repos;

namespace MVCLAB2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddScoped<IEntities<Student>, StudentRepo>();
            builder.Services.AddScoped<IEntities<Department>, DepartmentRepo>();
            builder.Services.AddScoped<IEntities<Course>, CourseRepo>();
            builder.Services.AddScoped<IEntities<User>, UserRepo>();


            builder.Services.AddDbContext<ITIContextcs>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });


            //builder.Services.AddDbContext


            builder.Services.AddAuthentication("Cookies").AddCookie(s =>
            {
                s.LoginPath = "/Account/Login";
                s.LogoutPath = "/Account/Login";
            });

            var app = builder.Build();

           

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
