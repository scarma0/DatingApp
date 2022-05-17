using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UserDto            // This is the object we return when a user logs in / registers
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}