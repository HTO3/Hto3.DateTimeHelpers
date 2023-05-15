using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class StripMinutes
    {
        [TestMethod]
        public void NormalUse()
        {
            //arrange
            var input = new DateTime(2010, 10, 3, 12, 22, 7);
            var expected = new DateTime(2010, 10, 3, 12, 0, 0);

            //act
            var actual = DateTimeHelpers.StripMinutes(input);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
