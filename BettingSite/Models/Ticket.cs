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

        [Required]
        [Column(TypeName = "Money")]
        public decimal totalWager { get; set; }

        [Required]
        [Index("SX_Wallet")]
        public int walletId { get; set; }

        public DateTime createDate { get; set; } = DateTime.UtcNow;

        public virtual List<TicketWagers> TicketWagers { get; set; }
    }
}