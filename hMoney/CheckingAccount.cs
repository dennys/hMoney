using System;

namespace hMoney
{
    public class CheckingAccount
    {
        private DateTime transdate;
        private int accountId;
        private int toAccountId;
        private String accountName;
        private String toAccountName;
        private String accountType;
        private String accountNum;
        private String status;
        private String category;
        private int categoryId;
        private String subCategory;
        private int subCategoryId;
        private String payeeName;
        private int payeeId;
        private int transId;
        private decimal transAmount;
        private decimal toTransAmount;
        private String transCode;

        private String notes;
        private String heldAt;

        public DateTime Transdate { get; set; }
        public int AccountId { get; set; }
        public int ToAccountId { get; set; }
        public string AccountName { get; set; }
        public string ToAccountName { get; set; }
        public string AccountType { get; set; }
        public string AccountNum { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string SubCategory { get; set; }
        public int SubCategoryId { get; set; }
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
