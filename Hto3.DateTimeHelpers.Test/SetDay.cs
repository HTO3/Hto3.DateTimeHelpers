﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class SetDay
    {
        [TestMethod]
        public void NormalUse()
        {
            var date = new DateTime(2010, 10, 3, 12, 22, 7);
            var date2 = new DateTime(2010, 10, 4, 12, 22, 7);
            Assert.AreEqual(DateTimeHelpers.SetDay(date, 4), date2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Invalid_Day()
        {
            var date = new DateTime(2010, 10, 3, 12, 22, 7);
            DateTimeHelpers.SetDay(date, -8);
        }
    }
}
