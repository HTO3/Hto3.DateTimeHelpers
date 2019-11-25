using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class IsValidTime
    {
        [TestMethod]
        public void NormalUse()
        {
            Assert.IsTrue(DateTimeHelpers.IsValidTime(23, 59, 1));
            Assert.IsFalse(DateTimeHelpers.IsValidTime(24, -1, 0));
        }

        [TestMethod]
        public void Invalid_Hour()
        {
            Assert.IsFalse(DateTimeHelpers.IsValidTime(25, 59, 1));
        }

        [TestMethod]
        public void Invalid_Minute()
        {
            Assert.IsFalse(DateTimeHelpers.IsValidTime(22, 62, 1));
        }

        [TestMethod]
        public void Invalid_Second()
        {
            Assert.IsFalse(DateTimeHelpers.IsValidTime(22, 33, -7));
        }
    }
}
