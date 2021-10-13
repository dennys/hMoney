using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hMoney.Globals;

namespace hMoney
{
    public class Api
    {
        public DateTime GetNextTransDate(RepeatType repeatType, DateTime preTransDate, int numOccurrences)
        {
            DateTime nextTransDate = preTransDate;
            switch (repeatType)
            {
                case RepeatType.REPEAT_INACTIVE:    // -1
                    break;
                case RepeatType.REPEAT_NONE:        // 0
                    break;
                case RepeatType.REPEAT_WEEKLY:      // 1
                    nextTransDate = preTransDate.AddDays(7);
                    break;
                case RepeatType.REPEAT_BI_WEEKLY:   // 2
                    nextTransDate = preTransDate.AddDays(14);
                    break;
                case RepeatType.REPEAT_MONTHLY:     // 3
                    nextTransDate = preTransDate.AddMonths(1);
                    break;
                case RepeatType.REPEAT_BI_MONTHLY:  // 4
                    nextTransDate = preTransDate.AddMonths(2);
                    break;
                case RepeatType.REPEAT_QUARTERLY:   // 5
                    nextTransDate = preTransDate.AddMonths(3);
                    break;
                case RepeatType.REPEAT_HALF_YEARLY: // 6
                    nextTransDate = preTransDate.AddMonths(6);
                    break;
                case RepeatType.REPEAT_YEARLY:      // 7
                    nextTransDate = preTransDate.AddYears(1);
                    break;
                case RepeatType.REPEAT_FOUR_MONTHLY:// 8
                    break;
                case RepeatType.REPEAT_FOUR_WEEKLY: // 9
                    break;
                case RepeatType.REPEAT_DAILY:       // 10
                    nextTransDate = preTransDate.AddDays(1);
                    break;
                case RepeatType.REPEAT_IN_X_DAYS:   // 11
                    nextTransDate = preTransDate.AddDays(numOccurrences);
                    break;
                case RepeatType.REPEAT_IN_X_MONTHS: // 12
                    nextTransDate = preTransDate.AddMonths(numOccurrences);
                    break;
                case RepeatType.REPEAT_EVERY_X_DAYS:// 13
                    break;
                case RepeatType.REPEAT_EVERY_X_MONTHS:  // 14
                    break;
                case RepeatType.REPEAT_MONTHLY_LAST_DAY:    // 15
                    break;
                case RepeatType.REPEAT_MONTHLY_LAST_BUSINESS_DAY:   //  16
                    break;
                default:
                    Log.Error("Invalid repeat type: " + repeatType);
                    //TODO should raise exception here
                    break;
            }
            return nextTransDate;
        }
    }
}
