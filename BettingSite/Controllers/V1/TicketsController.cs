using BettingSite.App_Start;
using BettingSite.Models;
using BettingSite.Repositories;
using Ninject;
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

        // GET: api/Tickets/5
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

        // POST: api/Tickets
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> PostTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await ticketRepository.Add(ticket);

            return CreatedAtRoute("DefaultApi", new { id = ticket.ticketId }, ticket);
        }
    }
}
