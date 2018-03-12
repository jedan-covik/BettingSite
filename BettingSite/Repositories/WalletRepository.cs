using BettingSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BettingSite.Repositories
{

    public interface IWalletRepository
    {
        Task<Wallet> GetById(int id);
        Task Update(int id, Wallet wallet);
    }

    public class WalletRepository : IWalletRepository
    {
        private BettingSiteContext db = new BettingSiteContext();

        public async Task Update(int walletId, Wallet wallet)
        {
            db.Entry(wallet).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<Wallet> GetById(int id)
        {
            return await db.Wallets.Where(w => (w.walletId == id)).FirstAsync();
        }
    }
}