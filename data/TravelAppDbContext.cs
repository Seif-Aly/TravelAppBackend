using Microsoft.EntityFrameworkCore;
using TravelAppBackend.models;

public class TravelAppDbContext : DbContext
{
    public TravelAppDbContext(DbContextOptions<TravelAppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<TourDate> TourDates { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email).IsUnique();

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Tour)
            .WithMany(t => t.Bookings)
            .HasForeignKey(b => b.TourId);

        modelBuilder.Entity<Tour>()
            .HasMany(t => t.Services)
            .WithMany(s => s.Tours)
            .UsingEntity<Dictionary<string, object>>(
                "tour_services",
                r => r.HasOne<Service>()
                      .WithMany()
                      .HasForeignKey("ServiceId")
                      .OnDelete(DeleteBehavior.Cascade),
                l => l.HasOne<Tour>()
                      .WithMany()
                      .HasForeignKey("TourId")
                      .OnDelete(DeleteBehavior.Cascade));

        modelBuilder.Entity<Tour>()
            .HasMany(t => t.Rooms)
            .WithMany(r => r.Tours)
            .UsingEntity<Dictionary<string, object>>(
                "tour_room_types",
                rj => rj.HasOne<RoomType>()
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade),
                lj => lj.HasOne<Tour>()
                        .WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade));
    }
}

