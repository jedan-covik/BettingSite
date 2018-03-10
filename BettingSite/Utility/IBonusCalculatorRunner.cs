using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettingSite.Utility
{
    public interface IBonusCalculatorRunner
    {
        decimal getTotalBonus();
    }
}