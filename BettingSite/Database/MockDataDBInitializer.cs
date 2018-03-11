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
            context.Sports.Add(new Sport { sportId = 1, name = "Nogomet" });
            context.Sports.Add(new Sport { sportId = 2, name = "Košarka" });

            context.Teams.Add(new Team { teamId = 1, name = "Hajduk", sportId = 1 });
            context.Teams.Add(new Team { teamId = 2, name = "Dinamo Zagreb", sportId = 1 });
            context.Teams.Add(new Team { teamId = 3, name = "Zadar", sportId = 1 });

            context.Matches.Add(new Match { matchId = 1, homeTeamId = 1, guestTeamId = 2, matchQuota = (decimal)1.4, matchDateTime = new DateTime(2018, 3, 16, 18, 0, 0) });
            context.Matches.Add(new Match { matchId = 1, homeTeamId = 3, guestTeamId = 2, matchQuota = (decimal)1.8, matchDateTime = new DateTime(2018, 3, 22, 18, 0, 0) });

            context.Wallets.Add(new Wallet { walletId = 1, amount = 100 });

            context.SaveChanges();
        }
    }
}