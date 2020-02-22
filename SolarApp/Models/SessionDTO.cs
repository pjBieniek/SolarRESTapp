using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Models
{
    public class SessionDTO
    {
        public int SessionId { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
