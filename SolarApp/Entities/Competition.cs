using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Entities
{
    public class Competition
    {
        [Key]
        public int CompetitionId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompetitionTitle { get; set; }
        public string CompetitionDescription { get; set; }
        public string CompetitionUrlAddress { get; set; }
        public DateTime CompetitionDate { get; set; }
        public IEnumerable<Result> CompetitionResults { get; set; } = new List<Result>();
    }
}
