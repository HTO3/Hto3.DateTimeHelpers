using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class IsValidDate
    {
        [TestMethod]
        public void NormalUse()
        {
            Assert.IsTrue(DateTimeHelpers.IsValidDate(2010, 1, 1));
            Assert.IsFalse(DateTimeHelpers.IsValidDate(2010, 13, 66));
        }
    }
}
