using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAppBackend.models
{
    [Table("services")]
    public class Service
    {
        [Key] [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = "";

        // public ICollection<Tour>? Tours { get; set; }
    }
}
