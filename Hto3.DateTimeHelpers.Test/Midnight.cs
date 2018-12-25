using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class Midnight
    {
        [TestMethod]
        public void NormalUse()
        {
            Assert.AreEqual(DateTimeHelpers.Midnight(new DateTime(2018, 2, 1, 11, 45, 22)), new DateTime(2018, 2, 1, 0, 0, 0));
        }
    }
}
