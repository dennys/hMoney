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
    [TestClass]
    public class ApiTests
    {
        readonly Apix apix = new();
        DateTime nextTransDate;

/*        [TestMethod]
        public void GetNextTrlyTestInactive()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_INACTIVE, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/04/2021"));
        }

        [TestMethod]
        public void GetNextTrlyTestNone()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_NONE, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/04/2021"));
        }

        [TestMethod]
        public void GetNextTrlyTest()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_WEEKLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/11/2021"));
        }
        [TestMethod]
        public void GetNextTransDateBiWeeklyTest()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_BI_WEEKLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/18/2021"));
        }

        [TestMethod]
        public void GetNextTransDateMonthlyTest()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_MONTHLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("07/04/2021"));
        }

        [TestMethod]
        public void GetNextTransDateBiMonthlyTest()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_BI_MONTHLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("08/04/2021"));
        }

        [TestMethod]
        public void GetNextTransDateQuarterlyTest()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_QUARTERLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("09/04/2021"));
        }

        [TestMethod]
        public void GetNextTransDateHalyYearlyTest()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_HALF_YEARLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("12/04/2021"));
        }

        [TestMethod]
        public void GetNextTransDateYearlyyTest()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_YEARLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/04/2022"));
        }

        [TestMethod]
        public void GetNextTransDateFourMonthlyTest()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_FOUR_MONTHLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("10/04/2021"));
        }

        [TestMethod]
        public void GetNextTransDateFourWeeklyTest()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_FOUR_WEEKLY, Convert.ToDateTime("06/01/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/29/2021"));
        }

        [TestMethod]
        public void GetNextTransDateDailyTest()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_DAILY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/05/2021"));
        }

        [TestMethod]
        public void GetNextTransDateXDays1Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_IN_X_DAYS, Convert.ToDateTime("06/04/2021"), 1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/05/2021"));
        }

        [TestMethod]
        public void GetNextTransDateXDays2Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_IN_X_DAYS, Convert.ToDateTime("06/04/2021"), 2);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/06/2021"));
        }

        [TestMethod]
        public void GetNextTransDateXDays3Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_IN_X_DAYS, Convert.ToDateTime("06/04/2021"), 3);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/07/2021"));
        }

        [TestMethod]
        public void GetNextTransDateXMonths1Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_IN_X_MONTHS, Convert.ToDateTime("06/04/2021"), 1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("07/04/2021"));
        }

        [TestMethod]
        public void GetNextTransDateXMonths2Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_IN_X_MONTHS, Convert.ToDateTime("06/04/2021"), 2);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("08/04/2021"));
        }

        [TestMethod]
        public void GetNextTransDateXMonths3Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_IN_X_MONTHS, Convert.ToDateTime("06/04/2021"), 3);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("09/04/2021"));
        }

        [TestMethod]
        public void GetNextTransDateEveryXDays1Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_EVERY_X_DAYS, Convert.ToDateTime("06/04/2021"), 1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/05/2021"));
        }

        [TestMethod]
        public void GetNextTransDateEveryXDays2Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_EVERY_X_DAYS, Convert.ToDateTime("06/04/2021"), 2);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/06/2021"));
        }

        [TestMethod]
        public void GetNextTransDateEveryXDays3Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_EVERY_X_DAYS, Convert.ToDateTime("06/04/2021"), 3);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/07/2021"));
        }

        [TestMethod]
        public void GetNextTransDateEveryXMonths1Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_EVERY_X_MONTHS, Convert.ToDateTime("06/04/2021"), 1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("07/04/2021"));
        }

        [TestMethod]
        public void GetNextTransDateEveryXMonths2Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_EVERY_X_MONTHS, Convert.ToDateTime("06/04/2021"), 2);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("08/04/2021"));
        }

        [TestMethod]
        public void GetNextTransDateEveryXMonths3Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_EVERY_X_MONTHS, Convert.ToDateTime("06/04/2021"), 3);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("09/04/2021"));
        }

        [TestMethod]
        public void GetNextTransDateMonthlyLastDay1Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_DAY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/30/2021"));
        }

        [TestMethod]
        public void GetNextTransDateMonthlyLastDay2Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_DAY, Convert.ToDateTime("07/24/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("07/31/2021"));
        }

        [TestMethod]
        public void GetNextTransDateMonthlyLastDay3Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_DAY, Convert.ToDateTime("02/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("02/28/2021"));
        }

        [TestMethod]
        public void GetNextTransDateMonthlyLastDayTest()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_DAY, Convert.ToDateTime("07/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("07/31/2021"));
        }

        [TestMethod]
        public void GetNextTransDateMonthlyLastBusinessDay1Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_BUSINESS_DAY, Convert.ToDateTime("10/17/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("10/29/2021"));
        }

        [TestMethod]
        public void GetNextTransDateMonthlyLastBusinessDay2Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_BUSINESS_DAY, Convert.ToDateTime("10/23/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("10/29/2021"));
        }
        [TestMethod]
        public void GetNextTransDateMonthlyLastBusinessDay3Test()
        {
            nextTransDate = apix.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_BUSINESS_DAY, Convert.ToDateTime("10/30/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("10/29/2021"));
        }
*/
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetNextTransDateExceptionTest()
        {
            nextTransDate = apix.GetNextTransDate((RepeatType)999, Convert.ToDateTime("10/30/2021"), -1);
        }
    }
}