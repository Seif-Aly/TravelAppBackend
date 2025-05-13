using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAppBackend.models
{
    [Table("room_types")]
    public class RoomType
    {
        [Key] [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name     { get; set; } = "Standard";

        [Column("capacity")]
        public int Capacity    { get; set; } = 2;

        // public ICollection<Tour>? Tours { get; set; }
    }
}
