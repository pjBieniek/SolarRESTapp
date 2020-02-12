using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Entities
{
    public class Result
    {
        public int ResultId { get; set; }
        public int Position { get; set; }
        public Competition Competition { get; set; }
        public Team Team { get; set; }
    }
}
