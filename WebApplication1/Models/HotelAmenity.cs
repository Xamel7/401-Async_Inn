using System;
using System.ComponentModel.DataAnnotations;

namespace Lab12.Models
{
    public class HotelAmenity
    {
        [Key] 
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string State { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
    }
}
