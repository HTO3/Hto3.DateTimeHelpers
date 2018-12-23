using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class UnixTimeToDateTime
    {
        [TestMethod]
        public void NormalUse()
        {
            var utc = new DateTime(2018, 12, 11, 23, 50, 30, DateTimeKind.Utc);
            var unspecifiedDateTime = new DateTime(utc.ToLocalTime().Ticks);

            Assert.AreEqual(Helpers.UnixTimeToDateTime(1544572230), unspecifiedDateTime);
        }
    }
}
