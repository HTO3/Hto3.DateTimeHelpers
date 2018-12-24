using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class DateDiff
    {
        [TestMethod]
        public void NormalUse()
        {
            var start = new DateTime(2010, 1, 1);
            var end = new DateTime(2010, 1, 2);

            Assert.AreEqual(DateTimeHelpers.DateDiff(start, end), TimeSpan.FromDays(1));
        }
    }
}
