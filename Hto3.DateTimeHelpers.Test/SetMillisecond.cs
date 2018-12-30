using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class SetMillisecond
    {
        [TestMethod]
        public void NormalUse()
        {
            var date = new DateTime(2010, 10, 3, 12, 22, 7, 8);
            var date2 = new DateTime(2010, 10, 3, 12, 22, 7, 9);
            Assert.AreEqual(DateTimeHelpers.SetMillisecond(date, 9), date2);
        }
    }
}
