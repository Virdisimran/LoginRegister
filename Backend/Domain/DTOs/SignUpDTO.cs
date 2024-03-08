﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class SignUpDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? DOB { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int IsActive { get; set; }
    }
}
