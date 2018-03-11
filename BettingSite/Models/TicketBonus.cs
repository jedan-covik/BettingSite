using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BettingSite.Models
{
    public class TicketBonus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ticketBonusId { get; set; }

        [Index("SX_Ticket")]
        public int ticketId { get; set; }

        public String bonusDescription { get; set; }

        public decimal bonusAmount { get; set; }

        public DateTime createDate { get; set; } = DateTime.UtcNow;
    }
}