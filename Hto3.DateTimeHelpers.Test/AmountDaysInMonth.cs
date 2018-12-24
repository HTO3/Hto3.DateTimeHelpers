using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class AmountDaysInMonth
    {
        [TestMethod]
        public void NormalUse()
        {
            Assert.AreEqual(DateTimeHelpers.AmountDaysInMonth(new DateTime(2018, 2, 1)), 28);
            Assert.AreEqual(DateTimeHelpers.AmountDaysInMonth(new DateTime(2018, 1, 1)), 31);
            Assert.AreEqual(DateTimeHelpers.AmountDaysInMonth(new DateTime(2020, 2, 1)), 29);
        }
    }
}
