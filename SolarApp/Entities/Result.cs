using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Entities
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        public int ResultPosition { get; set; }

        [ForeignKey("CompetitionId")]
        public Competition Competition { get; set; }
        public int CompetitionId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }
        public int TeamId { get; set; }
    }
}
