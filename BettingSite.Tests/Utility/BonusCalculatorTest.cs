using BettingSite.App_Start;
using BettingSite.Repositories;
using BettingSite.Services;
using BettingSite.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BettingSite.Tests.Utility
{
    [TestClass]
    public class BonusCalculatorTest
    {

        private IBonusCalculatorRunner bonusCalculatorRunner;

        [TestInitialize]
        public void MyTestInitialize()
        {
            var kernel = NinjectWebCommon.CreatePublicKernel();
            bonusCalculatorRunner = kernel.Get<IBonusCalculatorRunner>();
        }

        [TestMethod]
        public void calculateBonusTest()
        {
            decimal bonus = bonusCalculatorRunner.getTotalBonus();

            Assert.AreEqual(15, bonus);
        }
    }
}
