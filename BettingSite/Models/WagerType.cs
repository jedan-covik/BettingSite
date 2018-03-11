using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BettingSite.Models
{
    public class WagerType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int wagerTypeId { get; set; }

        public String description { get; set; }
    }
}