using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class IsBetween
    {
        [TestMethod]
        public void NormalUse()
        {
            var date = new DateTime(2010, 1, 1);
            var start = new DateTime(2009, 1, 1);
            var end = new DateTime(2010, 1, 2);

            Assert.IsTrue(DateTimeHelpers.IsBetween(date, start, end));
            Assert.IsFalse(DateTimeHelpers.IsBetween(start, date, end));
        }
    }
}
