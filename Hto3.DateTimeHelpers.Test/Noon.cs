using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class Noon
    {
        [TestMethod]
        public void NormalUse()
        {
            var date = new DateTime(2010, 10, 3, 12, 22, 7);
            var date2 = new DateTime(2010, 10, 3, 12, 0, 0);
            Assert.AreEqual(DateTimeHelpers.Noon(date), date2);
        }
    }
}
