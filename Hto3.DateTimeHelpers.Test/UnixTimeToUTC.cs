﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.DateTimeHelpers.Test
{
    [TestClass]
    public class AppendMissing
    {
        [TestMethod]
        public void NormalUse()
        {
            Assert.AreEqual(Helpers.UnixTimeToUTC(1544572230), new DateTime(2018, 12, 11, 23, 50, 30, DateTimeKind.Utc));
        }
    }
}
