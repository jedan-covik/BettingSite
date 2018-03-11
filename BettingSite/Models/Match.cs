using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BettingSite.Models
{
    public class Match
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int matchId { get; set; }

        [Index("SX_HomeTeam")]
        public int homeTeamId { get; set; }
        [Index("SX_GuestTeam")]
        public int guestTeamId { get; set; }

        public decimal homePoints { get; set; }
        public decimal guestPoints { get; set; }

        public virtual Team homeTeam { get; set; }
        public virtual Team guestTeam { get; set; }

        [Index("SX_MatchDate")]
        public DateTime matchDateTime { get; set; }
        public bool matchFinished { get; set; }

        public decimal matchQuota { get; set; }

        public DateTime createDate { get; set; }
    }
}