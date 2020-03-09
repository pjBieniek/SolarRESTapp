using System;
using System.ComponentModel.DataAnnotations;

namespace SolarApp.Data.Models
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
