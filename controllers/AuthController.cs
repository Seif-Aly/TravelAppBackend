using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly TravelAppDbContext _context;  

    public AuthController(TravelAppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (await _context.Users.AnyAsync(u => u.Email.ToLower() == request.Email.ToLower()))
            return BadRequest("Email already in use.");

        var user = new User
        {
            Email = request.Email,
            PasswordHash = HashPassword(request.Password),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = request.Role ?? "User" 
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("Registration successful.");
    }

    [HttpPost("login")]
public async Task<IActionResult> Login([FromBody] UserLogin request)
{
    var user = await _context.Users.SingleOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower());
    if (user == null || user.PasswordHash != HashPassword(request.Password))
        return Unauthorized("Invalid credentials.");

    var token = GenerateToken(user);

    Response.Cookies.Append("jwt", token, new CookieOptions
    {
        HttpOnly = true,
        Secure = false,      
        SameSite = SameSiteMode.Strict,
        Expires = DateTime.UtcNow.AddHours(1)
    });

    return Ok(new
    {
        message = "Login successful.",
        token = token  
    });
}

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return Ok("Logged out successfully.");
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyForJWTTokenGeneration"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

