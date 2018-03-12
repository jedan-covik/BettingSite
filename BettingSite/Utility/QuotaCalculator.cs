using BettingSite.Models;
using BettingSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BettingSite.Utility
{
    public interface IQuotaCalculator
    {
        Task<decimal> getQuota(Ticket ticket);
    }

    public class QuotaCalculator : IQuotaCalculator
    {

        private ITicketWagersRepository ticketWagersRepository;
        private List<IBonusCalculator> bonusCalculators;

        public QuotaCalculator(ITicketWagersRepository ticketWagersRepository, List<IBonusCalculator> bonusCalculators)
        {
            this.ticketWagersRepository = ticketWagersRepository;
            this.bonusCalculators = bonusCalculators;
        }

        public async Task<decimal> getQuota(Ticket ticket)
        {
            IQueryable<TicketWagers> ticketWagers = ticketWagersRepository.GetByTicketsId(ticket.ticketId);

            decimal totalQuota = 1;
            decimal bonusQuota = 0;

            foreach (TicketWagers current in ticketWagers)
            {
                totalQuota *= current.matchQuota;
            }

            foreach(IBonusCalculator current in bonusCalculators)
            {
                bonusQuota += current.getQuotaBonus(ticketWagers);
            }

            return totalQuota + bonusQuota;
        }
    }
}