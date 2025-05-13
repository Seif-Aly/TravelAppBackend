using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAppBackend.models
{
    [Table("tours")]
    public class Tour
    {
        [Key] [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; } = "";

        [Column("country")]
        public string Country { get; set; } = "";

        [Column("description")]
        public string Description { get; set; } = "";

        [Column("image_url")]
        public string ImageUrl { get; set; } = "";

        [Column("rating_value")]
        public double RatingValue { get; set; }

        [Column("rating_count")]
        public int RatingCount { get; set; }

        [Column("duration_days")]
        public int DurationDays { get; set; }

        [Column("distance_km")]
        public int DistanceKm { get; set; }

        [Column("temperature_c")]
        public int TemperatureC { get; set; }

        [Column("weather_state")]
        public string WeatherState { get; set; } = "";

        [Column("price_per_adult")]
        public decimal PricePerAdult { get; set; }

        [Column("price_per_child")]
        public decimal PricePerChild { get; set; }

        // navigation
        public ICollection<TourDate>?   AvailableDates { get; set; }
        public ICollection<RoomType>?   Rooms          { get; set; }
        public ICollection<Service>?    Services       { get; set; }
        public ICollection<Booking>?    Bookings       { get; set; }
    }
}
