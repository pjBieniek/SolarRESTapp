using System;

namespace SolarApp.Data.Models
{
    public class SessionDTO
    {
        public int SessionId { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
