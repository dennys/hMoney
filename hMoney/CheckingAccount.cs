using System;

namespace hMoney
{
    public class CheckingAccount
    {
        public DateTime Transdate { get; set; }
        public int AccountId { get; set; }
        public int ToAccountId { get; set; }
        public string AccountName { get; set; }
        public string ToAccountName { get; set; }
        public string AccountType { get; set; }
        public string AccountNum { get; set; }
        public string Status { get; set; }
        public string CategName { get; set; }
        public int CategId { get; set; }
        public string SubCategName { get; set; }
        public int SubCategId { get; set; }
        public string PayeeName { get; set; }
        public int PayeeId { get; set; }
        public int TransId { get; set; }
        public decimal TransAmount { get; set; }
        public decimal ToTransAmount { get; set; }
        public string TransCode { get; set; }
        public string Notes { get; set; }
        public string HeldAt { get; set; }
    }
}
