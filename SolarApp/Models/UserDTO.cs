﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.Models
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}