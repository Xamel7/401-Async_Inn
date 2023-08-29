using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab12.Models
{
    public class HotelRoom
    {
        [Key]
        public int ID { get; set; }
        [Required]

        public string? Name { get; set; }
        public int RoomID { get; set; }
        [ForeignKey("Hotel")]
        public int HotelID { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]

        //Navigation Properties
        public HotelAmenity? Hotel { get; set; }
        public Room? Room { get; set; }
    }
}
