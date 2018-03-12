using BettingSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BettingSite.Database
{
    public class MockDataDBInitializer : DropCreateDatabaseIfModelChanges<BettingSiteContext>
    {
        protected override void Seed(BettingSiteContext context)
        {
            context.WagerTypes.Add(new WagerType { wagerTypeId = 1, description = "1" });
            context.WagerTypes.Add(new WagerType { wagerTypeId = 2, description = "2" });
            context.WagerTypes.Add(new WagerType { wagerTypeId = 3, description = "x" });

            context.Sports.Add(new Sport { sportId = 1, name = "Nogomet" });
            context.Sports.Add(new Sport { sportId = 2, name = "Košarka" });

            context.Teams.Add(new Team { teamId = 1, name = "Hajduk", sportId = 1 });
            context.Teams.Add(new Team { teamId = 2, name = "Dinamo Zagreb", sportId = 1 });
            context.Teams.Add(new Team { teamId = 3, name = "Zadar", sportId = 1 });

            context.Teams.Add(new Team { teamId = 4, name = "Zadar", sportId = 2 });
            context.Teams.Add(new Team { teamId = 5, name = "Split", sportId = 2 });

            context.Matches.Add(new Match { matchId = 1, homeTeamId = 1, guestTeamId = 2, matchQuota = (decimal)1.4, matchDateTime = new DateTime(2018, 3, 16, 18, 0, 0) });
            context.Matches.Add(new Match { matchId = 2, homeTeamId = 3, guestTeamId = 2, matchQuota = (decimal)1.8, matchDateTime = new DateTime(2018, 3, 22, 18, 0, 0) });
            context.Matches.Add(new Match { matchId = 3, homeTeamId = 3, guestTeamId = 1, matchQuota = (decimal)1.6, matchDateTime = new DateTime(2018, 3, 26, 18, 0, 0) });

            context.Matches.Add(new Match { matchId = 4, homeTeamId = 5, guestTeamId = 4, matchQuota = (decimal)1.6, matchDateTime = new DateTime(2018, 3, 24, 18, 0, 0) });


            context.Wallets.Add(new Wallet { walletId = 1, amount = 100 });

            context.Tickets.Add(new Ticket { ticketId = 1, totalWager = 50, walletId = 1, totalQuota = (decimal)1.4 });

            context.TicketWagers.Add(new TicketWagers { ticketWagerId = 1, ticketId = 1, matchId = 1, wagerTypeId = 1, matchQuota = (decimal)1.4, wagerAmount = 50 });

            context.SaveChanges();
        }
    }
}