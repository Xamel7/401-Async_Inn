using System.ComponentModel.DataAnnotations;

namespace Lab12.Models
{
    public class RoomAmenity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int RoomID { get; set; }
        [Required]
        public int AmenityID { get; set; }

        public Room Room { get; set; }

        public Amenity Amenity { get; set; } 
    }
}
