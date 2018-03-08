﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BettingSite.Models
{
    public class Sport
    {
        public int sportId { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        [Index("SX_Name", 1, IsUnique = true)]
        public String name { get; set; }

        public DateTime createDate { get; }
        public bool deleted { get; set; }

        public Sport()
        {
            createDate = DateTime.Now;
            deleted = false;
        }
    }
}