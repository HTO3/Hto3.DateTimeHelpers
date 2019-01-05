using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class NextWeek
    {
        [TestMethod]
        public void NormalUse()
        {
            var date = new DateTime(2019, 1, 5, 12, 22, 7);
            var date2 = new DateTime(2019, 1, 12, 12, 22, 7);
            Assert.AreEqual(DateTimeHelpers.NextWeek(date), date2);
        }
    }
}
