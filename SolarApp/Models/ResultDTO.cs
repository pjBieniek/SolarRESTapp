﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Models
{
    public class ResultDTO
    {
        public int ResultId { get; set; }
        public int ResultPosition { get; set; }

        public int CompetitionId { get; set; }

        public int TeamId { get; set; }
    }
}