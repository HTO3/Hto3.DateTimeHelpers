﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class SetYear
    {
        [TestMethod]
        public void NormalUse()
        {
            var date = new DateTime(2010, 10, 3, 12, 22, 7);
            var date2 = new DateTime(2011, 10, 3, 12, 22, 7);
            Assert.AreEqual(DateTimeHelpers.SetYear(date, 2011), date2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Invalid_Year()
        {
            var date = new DateTime(2010, 10, 3, 12, 22, 7);
            DateTimeHelpers.SetYear(date, -8);
        }
    }
}
