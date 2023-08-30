﻿using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab12.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public string Id { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Token { get; set; }

        [NotMapped]
        public IList<string>? Roles { get; set; }


    }
}
