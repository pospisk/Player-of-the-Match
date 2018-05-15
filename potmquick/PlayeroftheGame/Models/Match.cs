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
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public bool HasOpponent { get; set; }
        private int _OpponentId;
        public int OpponentId {
            get
            {
                return _OpponentId;
            }
            set
            {
                _OpponentId = value;
                HasOpponent = (OpponentId != 0) ? true : false;
            }
        }
        public string OpponentName { get; set; }
        public string OpponentClubImagePath { get; set; }
        public bool HasSponsor { get; set; }
        private int _SponsorId;
        public int SponsorId {
            get
            {
                return _SponsorId;
            }
            set
            {
                _SponsorId = value;
                HasSponsor = (SponsorId != 0) ? true : false;
            }
        }
        public string SponsorName { get; set; }
        public string SponsorImagePath { get; set; }
        

    }

}
