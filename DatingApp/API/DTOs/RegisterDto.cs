using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDto
    {   
        [Required]
        [MaxLength(100)]
        public required string Username { get; set; } // required -> does not accept null/empty strings

        [Required]
        public required string Password { get; set; }
    }
}