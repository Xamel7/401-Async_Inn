using Lab12.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab12.Data
{
    public class AsyncInnContext: DbContext
    {
        public DbSet<Amenity> Amenities;
        public DbSet<RoomAmenity> RoomAmenities;
        public DbSet<Room> Rooms;
        public DbSet<HotelRoom> HotelRooms;
        public DbSet<Hotel> Hotels;

        public AsyncInnContext(DbContextOptions<AsyncInnContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //information tables
            modelBuilder.Entity<Amenity>().HasData(new Amenity 
            { ID = 1, Name = "A/C"});
            modelBuilder.Entity<Room>().HasData(new Room
            { ID = 1, Layout = 0, Name = "Basic Room"},
            new Room
            { ID = 2, Layout = 1, Name = "Basic Single Room" },
            new Room
            { ID = 3, Layout = 2, Name = "Basic Double Room" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel
            { ID = 1, Address = "123 Sesame St", City = "Memphis", 
            State = "TN", Name = "Elmo's Hotel", Phone = "555-555-5555"});

            //reference tables
            modelBuilder.Entity<RoomAmenity>().HasData(new RoomAmenity
            { ID = 1, AmenityID = 1, RoomID = 1});
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom
            { ID = 1, HotelID = 1, RoomID = 1, Price = 100.99});
        }

        public DbSet<Lab12.Models.Hotel> Hotel { get; set; } = default!;
    }
}
