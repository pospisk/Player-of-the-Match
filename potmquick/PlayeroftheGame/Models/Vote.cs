using System;
using System.Collections.Generic;
using System.Text;

namespace PlayeroftheGame.Models
{
    public class Vote
    { 
        public string IMEI { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int VoteBatchId { get; set; }
    }
}
