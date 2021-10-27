using NUnit.Framework;
using hMoney;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hMoney.Globals;

namespace hMoney.Tests
{
    [TestFixture]
    public class ApiTests
    {
        [Test]
        public void GetNextTransDateWeeklyTest()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_WEEKLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/11/2021"));
        }

        [Test]
        public void GetNextTransDateBiWeeklyTest()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_BI_WEEKLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/18/2021"));
        }

        [Test]
        public void GetNextTransDateMonthlyTest()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_MONTHLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("07/04/2021"));
        }

        [Test]
        public void GetNextTransDateBiMonthlyTest()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_BI_MONTHLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("08/04/2021"));
        }

        [Test]
        public void GetNextTransDateQuarterlyTest()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_QUARTERLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("09/04/2021"));
        }

        [Test]
        public void GetNextTransDateHalyYearlyTest()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_HALF_YEARLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("12/04/2021"));
        }

        [Test]
        public void GetNextTransDateYearlyyTest()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_YEARLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/04/2022"));
        }

        [Test]
        public void GetNextTransDateFourMonthlyTest()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_FOUR_MONTHLY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("10/04/2021"));
        }

        [Test]
        public void GetNextTransDateFourWeeklyTest()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_FOUR_WEEKLY, Convert.ToDateTime("06/01/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/29/2021"));
        }

        [Test]
        public void GetNextTransDateDailyTest()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_DAILY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/05/2021"));
        }

        [Test]
        public void GetNextTransDateXDays1Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_IN_X_DAYS, Convert.ToDateTime("06/04/2021"), 1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/05/2021"));
        }

        [Test]
        public void GetNextTransDateXDays2Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_IN_X_DAYS, Convert.ToDateTime("06/04/2021"), 2);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/06/2021"));
        }

        [Test]
        public void GetNextTransDateXDays3Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_IN_X_DAYS, Convert.ToDateTime("06/04/2021"), 3);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/07/2021"));
        }

        [Test]
        public void GetNextTransDateXMonths1Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_IN_X_MONTHS, Convert.ToDateTime("06/04/2021"), 1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("07/04/2021"));
        }

        [Test]
        public void GetNextTransDateXMonths2Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_IN_X_MONTHS, Convert.ToDateTime("06/04/2021"), 2);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("08/04/2021"));
        }

        [Test]
        public void GetNextTransDateXMonths3Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_IN_X_MONTHS, Convert.ToDateTime("06/04/2021"), 3);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("09/04/2021"));
        }

        [Test]
        public void GetNextTransDateEveryXDays1Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_EVERY_X_DAYS, Convert.ToDateTime("06/04/2021"), 1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/05/2021"));
        }

        [Test]
        public void GetNextTransDateEveryXDays2Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_EVERY_X_DAYS, Convert.ToDateTime("06/04/2021"), 2);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/06/2021"));
        }

        [Test]
        public void GetNextTransDateEveryXDays3Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_EVERY_X_DAYS, Convert.ToDateTime("06/04/2021"), 3);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/07/2021"));
        }

        [Test]
        public void GetNextTransDateEveryXMonths1Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_EVERY_X_MONTHS, Convert.ToDateTime("06/04/2021"), 1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("07/04/2021"));
        }

        [Test]
        public void GetNextTransDateEveryXMonths2Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_EVERY_X_MONTHS, Convert.ToDateTime("06/04/2021"), 2);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("08/04/2021"));
        }

        [Test]
        public void GetNextTransDateEveryXMonths3Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_EVERY_X_MONTHS, Convert.ToDateTime("06/04/2021"), 3);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("09/04/2021"));
        }

        [Test]
        public void GetNextTransDateMonthlyLastDay1Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_DAY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/30/2021"));
        }

        [Test]
        public void GetNextTransDateMonthlyLastDay2Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_DAY, Convert.ToDateTime("07/24/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("07/31/2021"));
        }

        [Test]
        public void GetNextTransDateMonthlyLastDay3Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_DAY, Convert.ToDateTime("02/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("02/28/2021"));
        }

        [Test]
        public void GetNextTransDateMonthlyLastDayTest()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_DAY, Convert.ToDateTime("06/04/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("06/30/2021"));
        }

        [Test]
        public void GetNextTransDateMonthlyLastBusinessDay1Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_BUSINESS_DAY, Convert.ToDateTime("10/17/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("10/29/2021"));
        }

        [Test]
        public void GetNextTransDateMonthlyLastBusinessDay2Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_BUSINESS_DAY, Convert.ToDateTime("10/23/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("10/29/2021"));
        }
        [Test]
        public void GetNextTransDateMonthlyLastBusinessDay3Test()
        {
            DateTime nextTransDate = Api.GetNextTransDate(RepeatType.REPEAT_MONTHLY_LAST_BUSINESS_DAY, Convert.ToDateTime("10/30/2021"), -1);
            Assert.AreEqual(nextTransDate, Convert.ToDateTime("10/29/2021"));
        }

    }
}