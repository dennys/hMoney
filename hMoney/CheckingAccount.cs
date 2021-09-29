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

        public DateTime Transdate { get => transdate; set => transdate = value; }
        public int AccountId { get => accountId; set => accountId = value; }
        public int ToAccountId { get => toAccountId; set => toAccountId = value; }
        public string AccountName { get => accountName; set => accountName = value; }
        public string ToAccountName { get => toAccountName; set => toAccountName = value; }
        public string AccountType { get => accountType; set => accountType = value; }
        public string AccountNum { get => accountNum; set => accountNum = value; }
        public string Status { get => status; set => status = value; }
        public string Category { get => category; set => category = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string SubCategory { get => subCategory; set => subCategory = value; }
        public int SubCategoryId { get => subCategoryId; set => subCategoryId = value; }
        public string PayeeName { get => payeeName; set => payeeName = value; }
        public int PayeeId { get => payeeId; set => payeeId = value; }
        public int TransId { get => transId; set => transId = value; }
        public decimal TransAmount { get => transAmount; set => transAmount = value; }
        public decimal ToTransAmount { get => toTransAmount; set => toTransAmount = value; }
        public string TransCode { get => transCode; set => transCode = value; }
        public string Notes { get => notes; set => notes = value; }
        public string HeldAt { get => heldAt; set => heldAt = value; }
    }
}
