using BettingSite.Models;
using BettingSite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettingSite.Utility.BonusCalculators
{
    public class ThreeMatchesSameSportBonusCalculator : IBonusCalculator
    {
        public decimal getQuotaBonus(List<TicketWagers> ticketWagers)
        {

            Dictionary<int, int> matchesPerSport = new Dictionary<int, int>();

            bool hasThreeMatcherForSport = false;

            foreach (TicketWagers current in ticketWagers)
            {
                int currentCount = 0;
                if (matchesPerSport.ContainsKey(current.Match.homeTeam.sportId))
                    currentCount = matchesPerSport[(current.Match.homeTeam.sportId)];
                currentCount++;

                if (currentCount >= 3)
                {
                    hasThreeMatcherForSport = true;
                    break;
                }

                matchesPerSport[current.Match.homeTeam.sportId] = currentCount;
            }

            if (hasThreeMatcherForSport)
                return 5;

            return 0;
        }
    }
}