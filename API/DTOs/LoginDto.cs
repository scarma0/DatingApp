using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class LoginDto            // This is the object we return when a user logins (??)
    {
         public string Username { get; set; }
        
        public string Password { get; set; }
    }
}