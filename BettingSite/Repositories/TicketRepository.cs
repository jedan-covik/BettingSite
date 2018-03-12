using BettingSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BettingSite.Repositories
{

    public interface ITicketRepository
    {
        Task<Ticket> GetById(int id);
        Task Add(Ticket Ticket);
    }

    public class TicketRepository : ITicketRepository
    {
        private BettingSiteContext db = new BettingSiteContext();

        public Task Add(Ticket Ticket)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> GetById(int id)
        {
            return await db.Tickets.Where(t => (t.ticketId == id)).FirstAsync();
        }
    }
}