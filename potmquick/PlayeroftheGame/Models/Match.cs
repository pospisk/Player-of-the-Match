using System;
using System.Collections.Generic;
using System.Text;

namespace PlayeroftheGame.Models
{
    public class Match
    {
        public int ClubId { get; set; }
        public string ClubImagePath { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime MatchDate { get; set; }
        public int OpponentId { get; set; }
        public string OpponentName { get; set; }
        public string OpponentClubImagePath { get; set; }
        public int Sponsor { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
