using System;

namespace hMoney
{
    public class Account
    {
        public int AccountId;
        public int CurrencyId;
        public String AccountName;
        public String AccountType;
        public String AccountNum;
        public String Status;
        public String Notes;
        public String WebSite;
        public Boolean FavoriteAcct;
        public String HeldAt;
        public decimal InitialBal;
        public decimal Reconciled;

        public decimal TodayBal;     // This field is calculated dynamically, not existed in database
        public decimal FutureBal;     // This field is calculated dynamically, not existed in database
    }
}
