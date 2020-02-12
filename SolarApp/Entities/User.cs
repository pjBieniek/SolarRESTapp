using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public Session Session { get; set; }
        public int SessionId { get; set; }

        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
