using System;

namespace hMoney
{
    public class BillsDeposits
    {
        private int bdId;
        private int accountId;
        private int toAccountId;
        private int payeeId;
        private String transCode;
        private decimal transAmount;
        private String status;
        private String transActionNumber;
        private String notes;
        private String category;
        private int categoryId;
        private String subCategory;
        private int subCategoryId;
        private DateTime transDate;
        private int followUpId;
        private decimal toTransAmount;
        private int repeats;
        private DateTime nextOccurrenceDate;
        private int numOccurrence;

        public int BdId { get => bdId; set => bdId = value; }
        public int AccountId { get => accountId; set => accountId = value; }
        public int ToAccountId { get => toAccountId; set => toAccountId = value; }
        public int PayeeId { get => payeeId; set => payeeId = value; }
        public string TransCode { get => transCode; set => transCode = value; }
        public decimal TransAmount { get => transAmount; set => transAmount = value; }
        public string Status { get => status; set => status = value; }
        public string TransActionNumber { get => transActionNumber; set => transActionNumber = value; }
        public string Category { get => category; set => category = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string SubCategory { get => subCategory; set => subCategory = value; }
        public int SubCategoryId { get => subCategoryId; set => subCategoryId = value; }
        public DateTime TransDate { get => transDate; set => transDate = value; }
        public int FollowUpId { get => followUpId; set => followUpId = value; }
        public decimal ToTransAmount { get => toTransAmount; set => toTransAmount = value; }
        public int Repeats { get => repeats; set => repeats = value; }
        public DateTime NextOccurrenceDate { get => nextOccurrenceDate; set => nextOccurrenceDate = value; }
        public int NumOccurrence { get => numOccurrence; set => numOccurrence = value; }
        public string Notes { get => notes; set => notes = value; }
    }
}
