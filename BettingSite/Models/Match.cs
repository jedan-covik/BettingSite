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

        [Index("SX_FirstTeam")]
        [Index("SX_BothTeams", 1)]
        public int firstTeamId { get; set; }

        [Index("SX_SecondTeam")]
        [Index("SX_BothTeams", 2)]
        public int secondTeamId { get; set; }

        [Index("SX_MatchTime")]
        public DateTime matchDateTime { get; set; }

        private DateTime createDate { get; set; }

        public virtual Team firstTeam { get; set; }

        public virtual Team secondTeam { get; set; }
    }
}