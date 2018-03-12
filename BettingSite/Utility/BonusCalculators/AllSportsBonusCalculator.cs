using BettingSite.Models;
using BettingSite.Repositories;
using BettingSite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettingSite.Utility.BonusCalculators
{
    public class AllSportsBonusCalculator : IBonusCalculator
    {
        public ISportRepository sportRepository;

        public AllSportsBonusCalculator(ISportRepository sportRepository)
        {
            this.sportRepository = sportRepository;
        }

        public decimal getQuotaBonus(IQueryable<TicketWagers> ticketWagers)
        {

            int sportsCount = sportRepository.GetSpotsCount();
            HashSet<int> differentSports = new HashSet<int>();

            foreach (TicketWagers current in ticketWagers)
            {
                differentSports.Add(current.Match.homeTeam.sportId);
            }

            if (sportsCount == differentSports.Count)
                return 10;

            return 0;
        }
    }
}