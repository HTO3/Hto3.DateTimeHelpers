using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class StripTime
    {
        [TestMethod]
        public void NormalUse()
        {
            var dateWithTime = new DateTime(2010, 10, 3, 12, 22, 7);
            Assert.AreEqual(DateTimeHelpers.StripTime(dateWithTime), dateWithTime.Date);
        }
    }
}
