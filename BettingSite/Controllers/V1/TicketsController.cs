using BettingSite.Models;
using BettingSite.Repositories;
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
    public class TicketsController : ApiController
    {
        private ITicketRepository ticketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        // GET: api/Sports/5
        [ResponseType(typeof(Ticket))]
        public async Task<IHttpActionResult> GetTicket(int id)
        {
            Ticket ticket = await ticketRepository.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }
    }
}
