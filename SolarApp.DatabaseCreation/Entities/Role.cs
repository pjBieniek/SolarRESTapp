using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.DatabaseCreation.Entities
{
    public class Role
    {
        public int RoleId { get; set; }

        [Required]
        [MaxLength(100)]
        public string RoleTitle { get; set; }

        public IList<UserRole> UserRoles { get; set; }
    }
}
