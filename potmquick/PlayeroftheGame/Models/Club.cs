using System;
using System.Collections.Generic;
using System.Text;

namespace PlayeroftheGame.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClubLogo { get; set; }
        public List<Team> Teams { get; set; }
    }
}
