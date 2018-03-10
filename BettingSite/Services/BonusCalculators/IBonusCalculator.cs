using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSite.Services
{
    public interface IBonusCalculator
    {
        decimal getBonus(/*ticket*/);
    }
}
