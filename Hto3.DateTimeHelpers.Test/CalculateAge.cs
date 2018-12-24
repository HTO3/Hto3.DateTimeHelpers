using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class CalculateAge
    {
        [TestMethod]
        public void NormalUse()
        {
            var today = DateTime.Today;
            var minusTenYearsOld = today.AddYears(10);
            var tenYearsOld = today.AddYears(-10);

            Assert.AreEqual(DateTimeHelpers.CalculateAge(minusTenYearsOld), -10);
            Assert.AreEqual(DateTimeHelpers.CalculateAge(tenYearsOld), 10);
            Assert.AreEqual(DateTimeHelpers.CalculateAge(today), 0);
        }
    }
}
