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
using BettingSite.Repositories;
using Microsoft.Web.Http;

namespace BettingSite.Controllers.V1
{
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/Sports")]
    public class SportsController : ApiController
    {
        private ISportRepository sportRepository;

        public SportsController(ISportRepository sportRepository)
        {
            this.sportRepository = sportRepository;
        }

        // GET: api/Sports
        public IQueryable<Sport> GetSports()
        {
            return sportRepository.GetAll();
        }

        // GET: api/Sports/5
        [ResponseType(typeof(Sport))]
        public async Task<IHttpActionResult> GetSport(int id)
        {
            Sport sport = await sportRepository.GetById(id);
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

            try
            {
                await sportRepository.Update(id, sport);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sportRepository.SportExists(id))
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

            await sportRepository.Add(sport);

            return CreatedAtRoute("DefaultApi", new { id = sport.sportId }, sport);
        }

        // DELETE: api/Sports/5
        [ResponseType(typeof(Sport))]
        public async Task<IHttpActionResult> DeleteSport(int id)
        {
            Sport sport = await sportRepository.GetById(id);
            if (sport == null)
            {
                return NotFound();
            }

            try
            {
                await sportRepository.Delete(sport);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(sport);
        }
    }
}