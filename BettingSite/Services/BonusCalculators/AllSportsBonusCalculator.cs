using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettingSite.Services
{
    public class AllSportsBonusCalculator : IBonusCalculator
    {
        public decimal getBonus()
        {
            return 10;
        }
    }
}