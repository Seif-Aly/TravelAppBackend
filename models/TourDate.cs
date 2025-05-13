using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAppBackend.models
{
    [Table("tour_dates")]
    public class TourDate
    {
        [Key] [Column("id")]
        public int Id { get; set; }

        [Column("tour_id")]
        public int TourId { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [ForeignKey("TourId")]
        public Tour? Tour { get; set; }
    }
}
