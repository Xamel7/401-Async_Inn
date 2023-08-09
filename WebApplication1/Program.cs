using Lab12.Data;
using Lab12.Models.Interfaces;
using Lab12.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace Lab12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddJsonOptions(o => {
                o.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

            /* TODO
            builder.Services.addContext
             */
            builder.Services.AddDbContext<AsyncInnContext>(options =>
                options.UseSqlServer(
                    builder.Configuration
                    .GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<IHotel, HotelService>();

            var app = builder.Build();

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