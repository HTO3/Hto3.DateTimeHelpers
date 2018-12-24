using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class AddWeeks
    {
        [TestMethod]
        public void NormalUse()
        {
            Assert.AreEqual(DateTimeHelpers.AddWeeks(new DateTime(2018, 10, 1), 1), new DateTime(2018, 10, 8));
            Assert.AreEqual(DateTimeHelpers.AddWeeks(new DateTime(2018, 10, 8), -1), new DateTime(2018, 10, 1));
        }
    }
}
