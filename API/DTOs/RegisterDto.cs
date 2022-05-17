using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDto            // This is the object we return when a user registers (??)
    {
        [Required]                             // Data annotations
        public string Username { get; set; }
        
        [Required]                             // Data annotations
        public string Password { get; set; }
    }
}