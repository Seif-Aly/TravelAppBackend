using Microsoft.EntityFrameworkCore;
using TravelAppBackend.models;

public class TravelAppDbContext : DbContext
{
    public TravelAppDbContext(DbContextOptions<TravelAppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<TourDate>  TourDates    { get; set; }
    public DbSet<RoomType>  RoomTypes    { get; set; }
    public DbSet<Service>   Services     { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<Booking>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(b => b.UserId);

        modelBuilder.Entity<Booking>()
            .HasOne<Tour>()
            .WithMany()
            .HasForeignKey(b => b.TourId);
        
         
    }
}

