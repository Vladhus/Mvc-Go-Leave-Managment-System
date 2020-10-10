using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGo.Data
{
    public class Employee : IdentityUser
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string TaxId { get; set; }
        public DateTime DateOfBearth { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
