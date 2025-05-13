using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TravelAppBackend.models;

[Table("bookings")]
public class Booking
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("tour_id")]
    public int TourId { get; set; }

    [Column("booking_date")]
    public DateTime BookingDate { get; set; } = DateTime.UtcNow;

    [ForeignKey("UserId")]
    [JsonIgnore]
    public User? User { get; set; }

    [ForeignKey("TourId")]
    public Tour? Tour { get; set; }
}