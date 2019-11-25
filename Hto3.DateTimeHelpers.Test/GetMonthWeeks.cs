using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class GetMonthWeeks
    {
        [TestMethod]
        public void NormalUse()
        {
            var weeks = DateTimeHelpers.GetMonthWeeks(2, 2018);

            Assert.AreEqual(weeks.ElementAt(0).Item1, new DateTime(2018, 2, 1));
            Assert.AreEqual(weeks.ElementAt(0).Item2, new DateTime(2018, 2, 3));

            Assert.AreEqual(weeks.ElementAt(1).Item1, new DateTime(2018, 2, 4));
            Assert.AreEqual(weeks.ElementAt(1).Item2, new DateTime(2018, 2, 10));

            Assert.AreEqual(weeks.ElementAt(2).Item1, new DateTime(2018, 2, 11));
            Assert.AreEqual(weeks.ElementAt(2).Item2, new DateTime(2018, 2, 17));

            Assert.AreEqual(weeks.ElementAt(3).Item1, new DateTime(2018, 2, 18));
            Assert.AreEqual(weeks.ElementAt(3).Item2, new DateTime(2018, 2, 24));

            Assert.AreEqual(weeks.ElementAt(4).Item1, new DateTime(2018, 2, 25));
            Assert.AreEqual(weeks.ElementAt(4).Item2, new DateTime(2018, 2, 28));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Invalid_Month()
        {
            DateTimeHelpers.GetMonthWeeks(13, 2018);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Invalid_Year()
        {
            DateTimeHelpers.GetMonthWeeks(13, -8);
        }
    }
}
