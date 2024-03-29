﻿using System.ComponentModel.DataAnnotations;

namespace Kitchen.Models
{
    public class UserData
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
