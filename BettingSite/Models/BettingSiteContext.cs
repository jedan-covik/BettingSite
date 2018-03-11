using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BettingSite.Models
{
    public class BettingSiteContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public BettingSiteContext() : base("name=BettingSiteContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BettingSiteContext>(new DropCreateDatabaseIfModelChanges<BettingSiteContext>());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                    .HasRequired(m => m.homeTeam)
                    .WithMany(t => t.homeMatches)
                    .HasForeignKey(m => m.homeTeamId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                        .HasRequired(m => m.guestTeam)
                        .WithMany(t => t.awayMatches)
                        .HasForeignKey(m => m.guestTeamId)
                        .WillCascadeOnDelete(false);

        }

        public System.Data.Entity.DbSet<BettingSite.Models.Sport> Sports { get; set; }

        public System.Data.Entity.DbSet<BettingSite.Models.Team> Teams { get; set; }

        public System.Data.Entity.DbSet<BettingSite.Models.Match> Matches { get; set; }

        public System.Data.Entity.DbSet<BettingSite.Models.Ticket> Tickets { get; set; }

        public System.Data.Entity.DbSet<BettingSite.Models.Wallet> Wallets { get; set; }

        public System.Data.Entity.DbSet<BettingSite.Models.TicketWagers> TicketWagers { get; set; }

        public System.Data.Entity.DbSet<BettingSite.Models.TicketBonus> TicketBonuses { get; set; }

        public System.Data.Entity.DbSet<BettingSite.Models.WagerType> WagerTypes { get; set; }

    }
}
