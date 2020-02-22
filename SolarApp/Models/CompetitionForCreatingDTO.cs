using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Models
{
    public class CompetitionForCreatingDTO
    {
        public string CompetitionTitle { get; set; }
        public string CompetitionDescription { get; set; }
        public string CompetitionUrlAddress { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime CompetitionDate { get; set; }
    }
}
