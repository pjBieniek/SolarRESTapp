using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Entities
{
    public class Competition
    {
        public int CompetitionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UrlAddress { get; set; }
        public DateTime CompetitionDate { get; set; }
        public IEnumerable<Result> CompetitionResults { get; set; }
    }
}
