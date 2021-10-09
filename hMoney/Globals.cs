using System;
using System.ComponentModel;

namespace hMoney
{
    public static class Globals
    {
        public static readonly String INI_FILE_NAME = "hMoney.ini";
        public static readonly String TREE_VIEW_HOME_NAME = "NodeHome";
        //public static class AccountType
        //{
        //    public const String Checking = "Checking";
        //    public const String Credit_Card = "Credit Card";
        //    public const String Term = "Term";
        //    public const String Investment = "Investment";
        //    public const String Loan = "Loan";
        //    public const String Shares = "Shares";
        //    public const String Asset = "Asset";
        //}
        public enum Status
        {
            Reconciled,
            Void,
            Followup,
            Duplicate
        }
        public enum RepeatType
        {
            [Description("REPEAT_INACTIVE")]
            REPEAT_INACTIVE = -1,
            [Description("REPEAT_NONE")]
            REPEAT_NONE,            //0
            [Description("REPEAT_WEEKLY")]
            REPEAT_WEEKLY,          //1
            [Description("REPEAT_BI_WEEKLY")]
            REPEAT_BI_WEEKLY,       //2: FORTNIGHTLY
            [Description("REPEAT_MONTHLY")]
            REPEAT_MONTHLY,         //3
            [Description("REPEAT_BI_MONTHLY")]
            REPEAT_BI_MONTHLY,      //4
            [Description("REPEAT_QUARTERLY")]
            REPEAT_QUARTERLY,       //5: TRI_MONTHLY
            [Description("REPEAT_HALF_YEARLY")]
            REPEAT_HALF_YEARLY,     //6
            [Description("REPEAT_YEARLY")]
            REPEAT_YEARLY,          //7
            REPEAT_FOUR_MONTHLY,    //8: QUAD_MONTHLY
            REPEAT_FOUR_WEEKLY,     //9: QUAD_WEEKLY
            REPEAT_DAILY,           //10
            REPEAT_IN_X_DAYS,       //11
            REPEAT_IN_X_MONTHS,     //12
            REPEAT_EVERY_X_DAYS,    //13
            REPEAT_EVERY_X_MONTHS,  //14
            REPEAT_MONTHLY_LAST_DAY,//15
            REPEAT_MONTHLY_LAST_BUSINESS_DAY
        }
    }
}
