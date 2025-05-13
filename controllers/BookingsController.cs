using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly TravelAppDbContext _context;

    public BookingsController(TravelAppDbContext context)
    {
        _context = context;
    }

    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
    {
        Console.WriteLine("Admin endpoint hit");
        return await _context.Bookings
            .Include(b => b.Tour)
            .Include(b => b.User)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> GetBooking(int id)
    {
        var booking = await _context.Bookings
            .Include(b => b.Tour)
            .Include(b => b.User)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (booking == null) return NotFound();
        return booking;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBooking(int id, Booking booking)
    {
        if (id != booking.Id)
            return BadRequest();

        _context.Entry(booking).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null)
            return NotFound();

        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("my")]
    public async Task<ActionResult<IEnumerable<Booking>>> GetMyBookings()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var user  = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        if (user == null) return Unauthorized();

        var list = await _context.Bookings
            .Where(b => b.UserId == user.Id)
            .Include(b => b.Tour)
            .OrderByDescending(b => b.BookingDate)
            .ToListAsync();

        return Ok(list);
    }

    [HttpPost]
    public async Task<ActionResult<Booking>> PostBooking(Booking booking)
    {
        if (booking.UserId == 0)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user  = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null) return Unauthorized();
            booking.UserId = user.Id;
        }

        booking.BookingDate = DateTime.UtcNow;
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
    }


}

