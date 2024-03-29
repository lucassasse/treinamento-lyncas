﻿using System.ComponentModel.DataAnnotations;

namespace CustomerApiOnion.Domain.ViewModels
{
    public class CustomerViewModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string Cpf { get; set; }
    }
}
