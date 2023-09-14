using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12.Data;
using Lab12.Models;

namespace Lab12.Controllers
{
    // Define the base route for the controller
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly AsyncInnContext _context;

        // Constructor to inject the database context
        public AmenitiesController(AsyncInnContext context)
        {
            _context = context;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenity()
        {
            // Check if there are no amenities in the context
            if (_context.Amenities == null)
            {
                return NotFound();
            }
            // Retrieve and return a list of all amenities
            return await _context.Amenities.ToListAsync();
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            // Check if there are no amenities in the context
            if (_context.Amenities == null)
            {
                return NotFound();
            }
            // Find the amenity with the provided ID
            var amenity = await _context.Amenities.FindAsync(id);

            // Return 404 Not Found if amenity is not found
            if (amenity == null)
            {
                return NotFound();
            }

            // Return the retrieved amenity
            return amenity;
        }

        // PUT: api/Amenities/5
        // Update an existing amenity
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
            // Check if the provided ID matches the ID in the amenity object
            if (id != amenity.ID)
            {
                return BadRequest();
            }

            // Set the state of the amenity object as modified
            _context.Entry(amenity).State = EntityState.Modified;

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Check if the amenity still exists after concurrency exception
                if (!AmenityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Return success with no content
            return NoContent();
        }

        // POST: api/Amenities
        // Create a new amenity
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
        {
            // Check if there are no amenities in the context
            if (_context.Amenities == null)
            {
                return Problem("Entity set 'AsyncInnContext.Amenity'  is null.");
            }
            // Add the new amenity to the context and save changes
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();

            // Return the created amenity with its ID
            return CreatedAtAction("GetAmenity", new { id = amenity.ID }, amenity);
        }

        // DELETE: api/Amenities/5
        // Delete an existing amenity
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            // Check if there are no amenities in the context
            if (_context.Amenities == null)
            {
                return NotFound();
            }
            // Find the amenity with the provided ID
            var amenity = await _context.Amenities.FindAsync(id);
            // Return 404 Not Found if amenity is not found
            if (amenity == null)
            {
                return NotFound();
            }

            // Remove the amenity from the context and save changes
            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();

            // Return success with no content
            return NoContent();
        }

        // Check if an amenity with the given ID exists
        private bool AmenityExists(int id)
        {
            return (_context.Amenities?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
