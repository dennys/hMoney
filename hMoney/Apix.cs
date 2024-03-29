﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using static hMoney.Globals;

namespace hMoney
{
    public class Apix
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

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
                    nextTransDate = preTransDate.AddMonths(4);
                    break;
                case RepeatType.REPEAT_FOUR_WEEKLY: // 9
                    nextTransDate = preTransDate.AddDays(28);
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
                    nextTransDate = preTransDate.AddDays(numOccurrences);
                    break;
                case RepeatType.REPEAT_EVERY_X_MONTHS:  // 14
                    nextTransDate = preTransDate.AddMonths(numOccurrences);
                    break;
                case RepeatType.REPEAT_MONTHLY_LAST_DAY:    // 15
                    nextTransDate = new DateTime(preTransDate.Year, preTransDate.Month, DateTime.DaysInMonth(preTransDate.Year, preTransDate.Month));
                    break;
                case RepeatType.REPEAT_MONTHLY_LAST_BUSINESS_DAY:   //  16
                    List<DateTime> holidays = new();
                    int i = DateTime.DaysInMonth(preTransDate.Year, preTransDate.Month);
                    while (i > 0)
                    {
                        DateTime dtCurrent = new(preTransDate.Year, preTransDate.Month, i);
                        if (dtCurrent.DayOfWeek < DayOfWeek.Saturday && dtCurrent.DayOfWeek > DayOfWeek.Sunday && !holidays.Contains(dtCurrent))
                        {
                            nextTransDate = dtCurrent;
                            break;
                        }
                        else
                        {
                            i--;
                        }
                    }
                    break;
                default:
                    Logger.Error("Invalid repeat type: " + repeatType);
                    throw new ArgumentException("Invalid parameter " + repeatType);
            }
            return nextTransDate;
        }
    }
}