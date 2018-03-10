using BettingSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettingSite.Utility
{
    public class BonusCalculatorRunner : IBonusCalculatorRunner
    {

        private List<IBonusCalculator> bonusCalculators;

        public BonusCalculatorRunner(List<IBonusCalculator> bonusCalculators)
        {
            this.bonusCalculators = bonusCalculators;
        }

        public decimal getTotalBonus()
        {
            decimal totalBonus = 0;

            foreach(IBonusCalculator calculator in bonusCalculators)
            {
                totalBonus += calculator.getBonus();
            }

            return totalBonus;
        }
    }
}