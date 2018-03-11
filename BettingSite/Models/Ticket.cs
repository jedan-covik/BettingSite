using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BettingSite.Models
{
    public class Ticket
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ticketId { get; set; }

        public decimal totalQuota { get; set; }

        [Column(TypeName = "Money")]
        public decimal totalWager { get; set; }

        [Index("SX_Wallet")]
        public int walletId { get; set; }
    }
}