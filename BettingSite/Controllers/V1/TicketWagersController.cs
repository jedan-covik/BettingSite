using BettingSite.Models;
using BettingSite.Repositories;
using BettingSite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace BettingSite.Controllers.V1
{
    public class TicketWagersController : ApiController
    {

        private ITicketWagersRepository ticketWagersRepository;
        private ITicketRepository ticketRepository;
        private IQuotaCalculator quotaCalculator;

        public TicketWagersController(ITicketWagersRepository ticketWagersRepository, ITicketRepository ticketRepository, IQuotaCalculator quotaCalculator)
        {
            this.ticketWagersRepository = ticketWagersRepository;
            this.ticketRepository = ticketRepository;
            this.quotaCalculator = quotaCalculator;
        }

        // POST: api/Tickets
        [ResponseType(typeof(TicketWagers))]
        public async Task<IHttpActionResult> PostTicketWagers(TicketWagers ticketWager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Ticket ticket = await ticketRepository.GetById(ticketWager.ticketId);

            IQueryable<TicketWagers> tickerWagers = ticketWagersRepository.GetByTicketsId(ticketWager.ticketId);
            decimal tickerWagerNumOfPairs = tickerWagers.Count() + 1;

            ticketWager.wagerAmount = ticket.totalWager / tickerWagerNumOfPairs;

            foreach (TicketWagers currentWager in tickerWagers.ToList())
            {
                currentWager.wagerAmount = ticket.totalWager / tickerWagerNumOfPairs;
                await ticketWagersRepository.Update(currentWager.ticketWagerId, currentWager);
            }

            await ticketWagersRepository.Add(ticketWager);

            ticket.totalQuota = await quotaCalculator.getQuota(ticket);

            await ticketRepository.Update(ticket.ticketId, ticket);

            return CreatedAtRoute("DefaultApi", new { id = ticketWager.ticketWagerId }, ticketWager);
        }
    }
}
