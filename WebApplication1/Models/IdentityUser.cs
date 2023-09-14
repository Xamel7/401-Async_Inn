using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab12.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        public string? Token { get; set; }
        

        [NotMapped]
        public IList<string>? Roles { get; set; }


    }
}
