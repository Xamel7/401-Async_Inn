using Lab12.Data;
using Lab12.Models.Interfaces;
using Lab12.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;

namespace Lab12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<IHotel, HotelService>();
            // Add services to the container.
            builder.Services.AddControllersWithViews()
                            .AddJsonOptions(options =>
                            {
                                //Ignore Data Cycling Errors
                                options.JsonSerializerOptions.ReferenceHandler
                                    = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                                //CamelCase JSON Attributes
                                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                                //Leave out null data fields in objects
                                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                            });
            //builder.Services.AddDbContext<IdentityUser>(options =>
            //{
            //    options.SignIn.RequireConfirmedAccount = true;
            //    options.Password.RequireDigit = false;
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequiredNonAlphanumeric = false;
            //    options.Password.RequiredUppercase = false;
            //    options.Password.RequiredLowercase = false;
            //})
            builder.Services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v20", new OpenApiInfo()
                {
                    Title = "Async Inn",
                    Version = "v20",
                });
            });

            /* TODO
            builder.Services.addContext
             */
            builder.Services.AddDbContext<AsyncInnContext>(options =>
                options.UseSqlServer(
                    builder.Configuration
                    .GetConnectionString("DefaultConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AsyncInnContext>();

            builder.Services.AddTransient<IHotel, HotelService>();

            var app = builder.Build();

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api/{documentName}/" +
                "swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v20/swagger.json",
                   "Async Inn");
                options.RoutePrefix = "docs";
            });

            //app.MapGet("/", () => "Hello World!");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //https://localhost:44391/Hotel/CheckIn/
            //https://website/Hotel/CheckOut
            //https://website/Hotel/

            /*
             * 
             * 
            
             */

            app.Run();
        }
    }
}