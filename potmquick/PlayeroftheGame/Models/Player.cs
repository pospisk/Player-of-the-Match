﻿using System;
using System.Collections.Generic;

namespace PlayeroftheGame.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public string PlayerImage { get; set; }
    }
}