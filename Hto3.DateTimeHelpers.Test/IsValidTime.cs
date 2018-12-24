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
    }
}
