using System;

namespace hMoney
{
    public class Account
    {
        private int accountId;
        private String accountName;
        private String accountType;
        private String accountNum;
        private String status;
        private String notes;
        private String heldAt;
        private String webSite;
        private String contactInfo;
        private String accessInfo;
        private Boolean favoriteAcct;
        private int currencyId;
        private decimal initialBal;
        private decimal reconciled;

        private decimal todayBal;     // This field is calculated dynamically, not existed in database
        private decimal futureBal;     // This field is calculated dynamically, not existed in database

        public int AccountId { get => accountId; set => accountId = value; }
        public int CurrencyId { get => currencyId; set => currencyId = value; }
        public string AccountName { get => accountName; set => accountName = value; }
        public string AccountType { get => accountType; set => accountType = value; }
        public string AccountNum { get => accountNum; set => accountNum = value; }
        public string Status { get => status; set => status = value; }
        public string Notes { get => notes; set => notes = value; }
        public string WebSite { get => webSite; set => webSite = value; }
        public bool FavoriteAcct { get => favoriteAcct; set => favoriteAcct = value; }
        public string HeldAt { get => heldAt; set => heldAt = value; }
        public decimal InitialBal { get => initialBal; set => initialBal = value; }
        public decimal Reconciled { get => reconciled; set => reconciled = value; }
        public decimal TodayBal { get => todayBal; set => todayBal = value; }
        public decimal FutureBal { get => futureBal; set => futureBal = value; }
        public string ContactInfo { get => contactInfo; set => contactInfo = value; }
        public string AccessInfo { get => accessInfo; set => accessInfo = value; }
    }
}
