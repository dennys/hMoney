using System;

namespace hMoney
{
    public class Account
    {
        private int accountId;
        private int currencyId;
        private String accountName;
        private String accountType;
        private String accountNum;
        private String status;
        private String notes;
        private String webSite;
        private Boolean favoriteAcct;
        private String heldAt;
        private decimal initialBal;
        private decimal reconciled;

        private decimal todayBal;     // This field is calculated dynamically, not existed in database
        private decimal futureBal;     // This field is calculated dynamically, not existed in database

        public int AccountId { get; set; }
        public int CurrencyId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string AccountNum { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string WebSite { get; set; }
        public bool FavoriteAcct { get; set; }
        public string HeldAt { get; set; }
        public decimal InitialBal { get; set; }
        public decimal Reconciled { get; set; }
        public decimal TodayBal { get; set; }
        public decimal FutureBal { get; set; }
    }
}
