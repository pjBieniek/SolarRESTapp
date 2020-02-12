using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleTitle { get; set; }
        public virtual IEnumerable<User> Users { get; set; } = new List<User>();
    }
}
