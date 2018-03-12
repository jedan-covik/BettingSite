﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BettingSite.Models
{
    public class TicketWagers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ticketWagerId { get; set; }

        [Index("SX_Ticket")]
        [Required]
        public int ticketId { get; set; }

        [Required]
        [Index("SX_Match")]
        public int matchId { get; set; }

        [Required]
        public int wagerTypeId { get; set; }

        [Column(TypeName = "Money")]
        public decimal wagerAmount { get; set; }

        [Required]
        public decimal matchQuota { get; set; }

        public DateTime createDate { get; set; } = DateTime.UtcNow;

        public virtual Match Match { get; set; }

        public virtual WagerType WagerType { get; set; }
    }
}