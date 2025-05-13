using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    [Required(ErrorMessage = "First Name is required")]
    [MaxLength(50)]
    public required string FirstName { get; set; }

    [Column("last_name")]  
    [Required(ErrorMessage = "Last Name is required")]
    [MaxLength(50)]
    public required string LastName { get; set; }

    [Column("email")]
    [Required]
    public required string Email { get; set; }

    [Column("password_hash")]
    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public required string PasswordHash { get; set; }

    [Required]
    public string Role { get; set; } = "User";
    [JsonIgnore]
    public ICollection<Booking>? Bookings { get; set; }
}