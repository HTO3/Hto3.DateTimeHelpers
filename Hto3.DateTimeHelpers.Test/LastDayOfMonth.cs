using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class LastDayOfMonth
    {
        [TestMethod]
        public void NormalUse()
        {
            Assert.AreEqual(DateTimeHelpers.LastDayOfMonth(new DateTime(2018, 2, 1)), new DateTime(2018, 2, 28));
        }
    }
}
