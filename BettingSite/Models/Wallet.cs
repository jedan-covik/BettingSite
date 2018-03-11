using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BettingSite.Models
{
    public class Wallet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int walletId { get; set; }

        [Column(TypeName = "Money")]
        public decimal amount { get; set; }
    }
}