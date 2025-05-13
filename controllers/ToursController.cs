using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAppBackend.models;

namespace TravelAppBackend.controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly TravelAppDbContext _ctx;
        public ToursController(TravelAppDbContext ctx) => _ctx = ctx;

        // GET api/tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTours()
        {
            try
            {
                var tours = await _ctx.Tours
                    .Include(t => t.AvailableDates)
                    .Include(t => t.Rooms)
                    .Include(t => t.Services)
                    .ToListAsync();

                return Ok(tours);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching tours: {ex.Message}");
                return StatusCode(500, "An error occurred while retrieving tours.");
            }
        }

        // GET api/tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTour(int id)
        {
            var tour = await _ctx.Tours
                .Include(t => t.AvailableDates)
                .Include(t => t.Rooms)
                .Include(t => t.Services)
                .FirstOrDefaultAsync(t => t.Id == id);

            return tour == null ? NotFound() : tour;
        }

        // POST api/tours   (Admin only)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Tour>> PostTour(Tour tour)
        {
            _ctx.Tours.Add(tour);
            await _ctx.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTour), new { id = tour.Id }, tour);
        }

        // PUT api/tours/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutTour(int id, Tour tour)
        {
            if (id != tour.Id) return BadRequest();
            _ctx.Entry(tour).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/tours/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTour(int id)
        {
            var tour = await _ctx.Tours.FindAsync(id);
            if (tour == null) return NotFound();
            _ctx.Tours.Remove(tour);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }
    }
}
