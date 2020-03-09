using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.DatabaseCreation.Entities
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public ICollection<Result> TeamResults { get; set; } = new List<Result>();
    }
}
