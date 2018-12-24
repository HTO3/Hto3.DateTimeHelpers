using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class FirstDayOfMonth
    {
        [TestMethod]
        public void NormalUse()
        {
            Assert.AreEqual(DateTimeHelpers.FirstDayOfMonth(new DateTime(2018, 2, 26)), new DateTime(2018, 2, 1));
        }
    }
}
