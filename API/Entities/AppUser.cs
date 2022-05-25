using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;        // initial value
        public DateTime LastActive { get; set; } = DateTime.Now;     // initial value
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> Photos { get; set; }      // FULLY DEFINING THE RELATIONSHIP BETWEEN AppUser CLASS AND Photo CLASS

        // public int GetAge()                      // DO NOT CHANGE THE NAME. THE NAME MUST BEGIN WITH Get.
        // {
        //     // return 99;
        //     return DateOfBirth.CalculateAge();     // extension class CalculateAge created
        // }


    }
}