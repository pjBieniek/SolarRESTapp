using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Entities
{
    public class Competition
    {
        public int CompetitionId { get; set; }
        public string CompetitionTitle { get; set; }
        public string CompetitionDescription { get; set; }
        public string CompetitionUrlAddress { get; set; }
        public DateTime CompetitionDate { get; set; }
        public IEnumerable<Result> CompetitionResults { get; set; } = new List<Result>();
    }
}
