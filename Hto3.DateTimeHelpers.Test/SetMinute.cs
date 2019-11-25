using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class SetMinute
    {
        [TestMethod]
        public void NormalUse()
        {
            var date = new DateTime(2010, 10, 3, 12, 22, 7);
            var date2 = new DateTime(2010, 10, 3, 12, 23, 7);
            Assert.AreEqual(DateTimeHelpers.SetMinute(date, 23), date2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Invalid_Minute()
        {
            var date = new DateTime(2010, 10, 3, 12, 22, 7);
            DateTimeHelpers.SetMinute(date, -8);
        }
    }
}
