using System;

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
            REPEAT_INACTIVE = -1,
            REPEAT_NONE,            //0
            REPEAT_WEEKLY,          //1
            REPEAT_BI_WEEKLY,       //2: FORTNIGHTLY
            REPEAT_MONTHLY,         //3
            REPEAT_BI_MONTHLY,      //4
            REPEAT_QUARTERLY,       //5: TRI_MONTHLY
            REPEAT_HALF_YEARLY,     //6
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
