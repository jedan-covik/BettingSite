using BettingSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BettingSite.Repositories
{
    public interface ITicketWagersRepository
    {
        Task<TicketWagers> GetById(int id);
        IQueryable<TicketWagers> GetByTicketsId(int ticketId);
        Task Add(TicketWagers TicketWager);
    }


    public class TicketWagersRepository : ITicketWagersRepository
    {

        private BettingSiteContext db = new BettingSiteContext();

        public async Task Add(TicketWagers ticketWager)
        {
            db.TicketWagers.Add(ticketWager);
            await db.SaveChangesAsync();
        }

        public async Task<TicketWagers> GetById(int id)
        {
            return await db.TicketWagers.Where(t => (t.ticketWagerId == id)).FirstAsync();
        }

        public IQueryable<TicketWagers> GetByTicketsId(int ticketId)
        {
            return db.TicketWagers.Where(t => (t.ticketId == ticketId)).AsQueryable();
        }
    }
}