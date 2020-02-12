﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Entities
{
    public class Session
    {
        public int SessionId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
    }
}
