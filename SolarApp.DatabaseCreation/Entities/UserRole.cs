using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.DatabaseCreation.Entities
{
    public class UserRole
    {
        public int UId { get; set; }
        public User User { get; set; }

        public int RId { get; set; }
        public Role Role { get; set; }
    }
}
