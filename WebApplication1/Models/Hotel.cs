using System.ComponentModel.DataAnnotations;

namespace Lab12.Models
{
    public class Hotel //hotellocations
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Phone { get; set; }

        public List<HotelRoom> HotelRooms { get; set; }
    }
}
