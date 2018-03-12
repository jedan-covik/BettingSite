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
        Task Update(int id, Ticket ticket);
    }

    public class TicketRepository : ITicketRepository
    {
        private BettingSiteContext db = new BettingSiteContext();

        public async Task Add(Ticket Ticket)
        {
            db.Tickets.Add(Ticket);
            await db.SaveChangesAsync();
        }

        public async Task<Ticket> GetById(int id)
        {
            return await db.Tickets.Where(t => (t.ticketId == id)).FirstAsync();
        }

        public async Task Update(int id, Ticket ticket)
        {
            db.Entry(ticket).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}