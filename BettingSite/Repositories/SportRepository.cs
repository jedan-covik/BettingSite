using BettingSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BettingSite.Repositories
{

    public interface ISportRepository
    {
        IQueryable<Sport> GetAll();
        Task<Sport> GetById(int id);
        Task Add(Sport sport);
        Task Update(int id, Sport sport);
        Task Delete(Sport sport);

        int GetSpotsCount();

        bool SportExists(int id);
    }


    public class SportRepository : ISportRepository
    {

        private BettingSiteContext db = new BettingSiteContext();

        public async Task Add(Sport sport)
        {
            db.Sports.Add(sport);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Sport sport)
        {
            sport.deleted = true;
            db.Entry(sport).State = EntityState.Modified;

            await db.SaveChangesAsync();
        }

        public IQueryable<Sport> GetAll()
        {
            return db.Sports.Where(s => s.deleted == false)
                      .AsQueryable();
        }

        public async Task<Sport> GetById(int id)
        {
            return await db.Sports.Where(s => (s.deleted == false) && (s.sportId == id)).FirstAsync();
        }

        public async Task Update(int id, Sport sport)
        {
            db.Entry(sport).State = EntityState.Modified;

            await db.SaveChangesAsync();
        }

        public bool SportExists(int id)
        {
            return db.Sports.Count(e => e.sportId == id) > 0;
        }

        public int GetSpotsCount()
        {
            return db.Sports.Count(e => e.deleted == false);
        }
    }
}