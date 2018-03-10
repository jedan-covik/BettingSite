using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettingSite.Services
{
    public class _3PairsSameSportBonusCalculator : IBonusCalculator
    {
        public decimal getBonus()
        {
            return 5;
        }
    }
}