using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BettingSite.Models
{
    public class Team
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int teamId { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(300)]
        [Index("UX_Team_Sport", 1, IsUnique = true)]
        [Index("SX_Name", 1, IsUnique = true)]
        public String name { get; set; }

        [Index("UX_Team_Sport", 2, IsUnique = true)]
        [Index("SI_Sport", 1)]
        public int sportId { get; set; }

        public virtual Sport sport { get; set; }

        public DateTime createDate { get; }
        public bool deleted { get; set; }

        public virtual ICollection<Match> homeMatches { get; set; }
        public virtual ICollection<Match> awayMatches { get; set; }

        public Team()
        {
            createDate = DateTime.Now;
            deleted = false;
        }
    }
}