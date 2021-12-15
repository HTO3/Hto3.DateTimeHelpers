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
            var today = DateTime.Now;

            //leave the clock work (avoid .NET runtime optimizations)
            System.Threading.Thread.Sleep(100);

            var minusTenYearsOld = today.AddYears(10);
            var tenYearsOld = today.AddYears(-10);

            Assert.AreEqual(-9, DateTimeHelpers.CalculateAge(minusTenYearsOld));
            Assert.AreEqual(10, DateTimeHelpers.CalculateAge(tenYearsOld));
            Assert.AreEqual(0, DateTimeHelpers.CalculateAge(today));
        }
    }
}
