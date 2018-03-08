using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BettingSite.Models;
using Microsoft.Web.Http;

namespace BettingSite.Controllers.V1
{
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/Sports")]
    public class SportsController : ApiController
    {
        private BettingSiteContext db = new BettingSiteContext();

        // GET: api/Sports
        public IQueryable<Sport> GetSports()
        {
            return db.Sports.Where(s => s.deleted == false)
                      .AsQueryable();
        }

        // GET: api/Sports/5
        [ResponseType(typeof(Sport))]
        public async Task<IHttpActionResult> GetSport(int id)
        {
            Sport sport = await db.Sports.Where(s => (s.deleted == false) && (s.sportId == id)).FirstAsync();
            if (sport == null)
            {
                return NotFound();
            }

            return Ok(sport);
        }

        // PUT: api/Sports/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSport(int id, Sport sport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sport.sportId)
            {
                return BadRequest();
            }

            db.Entry(sport).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Sports
        [ResponseType(typeof(Sport))]
        public async Task<IHttpActionResult> PostSport(Sport sport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sports.Add(sport);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sport.sportId }, sport);
        }

        // DELETE: api/Sports/5
        [ResponseType(typeof(Sport))]
        public async Task<IHttpActionResult> DeleteSport(int id)
        {
            Sport sport = await db.Sports.FindAsync(id);
            if (sport == null)
            {
                return NotFound();
            }


            sport.deleted = true;
            db.Entry(sport).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(sport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SportExists(int id)
        {
            return db.Sports.Count(e => e.sportId == id) > 0;
        }
    }
}