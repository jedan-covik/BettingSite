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

namespace BettingSite.Controllers.V1
{
    public class TeamsController : ApiController
    {
        private ITeamRepository teamRepository;

        public TeamsController(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        // GET: api/Teams
        public IQueryable<Team> GetTeams()
        {
            return teamRepository.GetAll();
        }

        // GET: api/Teams/5
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> GetTeam(int id)
        {
            Team team = await teamRepository.GetById(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        // PUT: api/Teams/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTeam(int id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.teamId)
            {
                return BadRequest();
            }

            try
            {
                await teamRepository.Update(id, team);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Teams
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> PostTeam(Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await teamRepository.Add(team);

            return CreatedAtRoute("DefaultApi", new { id = team.teamId }, team);
        }

        // DELETE: api/Teams/5
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> DeleteTeam(int id)
        {
            Team team = await teamRepository.GetById(id);
            if (team == null)
            {
                return NotFound();
            }

            try
            {
                await teamRepository.Delete(team);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(team);
        }

        private bool TeamExists(int id)
        {
            return teamRepository.TeamExists(id);
        }
    }
}