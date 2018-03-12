using BettingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSite.Utility
{
    public interface IBonusCalculator
    {
        decimal getQuotaBonus(IQueryable<TicketWagers> ticketWagers);
    }
}
