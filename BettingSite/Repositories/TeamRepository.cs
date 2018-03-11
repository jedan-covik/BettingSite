using BettingSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BettingSite.Repositories
{
    public interface ITeamRepository
    {
        IQueryable<Team> GetAll();
        Task<Team> GetById(int id);
        Task Add(Team team);
        Task Update(int id, Team team);
        Task Delete(Team team);

        bool TeamExists(int id);
    }

    public class TeamRepository : ITeamRepository
    {
        private BettingSiteContext db = new BettingSiteContext();

        public async Task Add(Team team)
        {
            db.Teams.Add(team);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Team team)
        {
            team.deleted = true;
            db.Entry(team).State = EntityState.Modified;

            await db.SaveChangesAsync();
        }

        public IQueryable<Team> GetAll()
        {
            return db.Teams.Where(t => t.deleted == false)
                     .AsQueryable();
        }

        public async Task<Team> GetById(int id)
        {
            return await db.Teams.Where(t => (t.deleted == false) && (t.teamId == id)).FirstAsync();
        }


        public async Task Update(int id, Team team)
        {
            db.Entry(team).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public bool TeamExists(int id)
        {
            return db.Teams.Count(t => t.sportId == id && t.deleted == false) > 0;
        }
    }
}