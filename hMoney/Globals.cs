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
            REPEAT_INACTIVE = -1,               //-1
            [Description("REPEAT_NONE")]
            REPEAT_NONE,                        //0
            [Description("REPEAT_WEEKLY")]
            REPEAT_WEEKLY,                      //1
            [Description("REPEAT_BI_WEEKLY")]
            REPEAT_BI_WEEKLY,                   //2: FORTNIGHTLY
            [Description("REPEAT_MONTHLY")]
            REPEAT_MONTHLY,                     //3
            [Description("REPEAT_BI_MONTHLY")]
            REPEAT_BI_MONTHLY,                  //4
            [Description("REPEAT_QUARTERLY")]
            REPEAT_QUARTERLY,                   //5: TRI_MONTHLY
            [Description("REPEAT_HALF_YEARLY")]
            REPEAT_HALF_YEARLY,                 //6
            [Description("REPEAT_YEARLY")]
            REPEAT_YEARLY,                      //7
            [Description("REPEAT_FOUR_MONTHLY")]
            REPEAT_FOUR_MONTHLY,                //8: QUAD_MONTHLY
            [Description("REPEAT_FOUR_WEEKLY")]
            REPEAT_FOUR_WEEKLY,                 //9: QUAD_WEEKLY
            [Description("REPEAT_DAILY")]
            REPEAT_DAILY,                       //10
            [Description("REPEAT_IN_X_DAYS")]
            REPEAT_IN_X_DAYS,                   //11
            [Description("REPEAT_IN_X_MONTHS")]
            REPEAT_IN_X_MONTHS,                 //12
            [Description("REPEAT_EVERY_X_DAYS")]
            REPEAT_EVERY_X_DAYS,                //13
            [Description("REPEAT_EVERY_X_MONTHS")]
            REPEAT_EVERY_X_MONTHS,              //14
            [Description("REPEAT_MONTHLY_LAST_DAY")]
            REPEAT_MONTHLY_LAST_DAY,            //15
            [Description("REPEAT_MONTHLY_LAST_BUSINESS_DAY")]
            REPEAT_MONTHLY_LAST_BUSINESS_DAY    //16
        }
    }
}
