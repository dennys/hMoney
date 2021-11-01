using System;

namespace hMoney
{
    public class Account
    {
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
        public string ContactInfo { get; set; }
        public string AccessInfo { get; set; }
    }
}
