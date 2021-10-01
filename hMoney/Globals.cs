﻿using System;

namespace hMoney
{
    public static class Globals
    {
        public static readonly String INI_FILE_NAME = "hMoney.ini";
        public static readonly String TREE_VIEW_HOME_NAME = "NodeHome";

        enum REPEAT_TYPE
        {
            REPEAT_INACTIVE = -1,
            REPEAT_NONE,
            REPEAT_WEEKLY,
            REPEAT_BI_WEEKLY,      // FORTNIGHTLY
            REPEAT_MONTHLY,
            REPEAT_BI_MONTHLY,
            REPEAT_QUARTERLY,      // TRI_MONTHLY
            REPEAT_HALF_YEARLY,
            REPEAT_YEARLY,
            REPEAT_FOUR_MONTHLY,   // QUAD_MONTHLY
            REPEAT_FOUR_WEEKLY,    // QUAD_WEEKLY
            REPEAT_DAILY,
            REPEAT_IN_X_DAYS,
            REPEAT_IN_X_MONTHS,
            REPEAT_EVERY_X_DAYS,
            REPEAT_EVERY_X_MONTHS,
            REPEAT_MONTHLY_LAST_DAY,
            REPEAT_MONTHLY_LAST_BUSINESS_DAY
        }
    }
}
