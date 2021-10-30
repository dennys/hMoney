using Microsoft.VisualStudio.TestTools.UnitTesting;
using hMoney;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hMoney.Globals;

namespace Api.Tests
{
    [TestClass()]
    public class ApiTests
    {
        Apix api = new Apix();
        DateTime nextTransDate;

        [TestMethod()]
        public void GetNextTrlyTest()
        {
            nextTransDate = api.GetNextTransDate(RepeatType.REPEAT_WEEKLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/11/2021"));
        }
    }
}