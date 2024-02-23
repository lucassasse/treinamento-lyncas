﻿using System.ComponentModel.DataAnnotations;

namespace Dashboard.Domain.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
