using Lab12.Data;
using Lab12.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab12.Models.Services
{
    public class HotelService : IHotel
    {
        private AsyncInnContext _context;

        public HotelService(AsyncInnContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> DeleteHotel(int id)
        {
            //former hotel controller functionality
            var hotel = await _context.Hotels.FindAsync(id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            //end
            return null;
            //return null to controller. controller returns No Content to user
        }

        //Get All Hotels
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {
            return await _context.Hotels.ToListAsync();
        }
        //Get a Hotel
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public bool HotelExists(int id)
        {
            return (_context.Hotels?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            //update model with new hotel data
            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                //save data changes
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return null;
        }
    }
}
