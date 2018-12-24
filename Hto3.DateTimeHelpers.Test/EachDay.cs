using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class EachDay
    {
        [TestMethod]
        public void NormalUse()
        {
            var start = new DateTime(2018, 2, 26);
            var end = new DateTime(2018, 3, 4);

            var result = DateTimeHelpers.EachDay(start, end).ToArray();

            Assert.AreEqual(result[0], new DateTime(2018, 2, 26));
            Assert.AreEqual(result[1], new DateTime(2018, 2, 27));
            Assert.AreEqual(result[2], new DateTime(2018, 2, 28));
            Assert.AreEqual(result[3], new DateTime(2018, 3, 1));
            Assert.AreEqual(result[4], new DateTime(2018, 3, 2));
            Assert.AreEqual(result[5], new DateTime(2018, 3, 3));
            Assert.AreEqual(result[6], new DateTime(2018, 3, 4));
        }
    }
}
