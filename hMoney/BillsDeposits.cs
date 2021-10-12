using System;
using static hMoney.Globals;

namespace hMoney
{
    public class BillsDeposits
    {
        const int VALUE_AUTO_EXECUTE_MANUAL = 100;
        const int VALUE_AUTO_EXECUTE_SILENT = 200;

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
        private RepeatType repeats;
        private DateTime nextOccurrenceDate;
        private int numOccurrence;
        private Boolean autoExecuteManual;
        private Boolean autoExecuteSilent;

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
        public RepeatType Repeats { 
            get => repeats; 
            set
            {
                if (Convert.ToInt32(value) >= VALUE_AUTO_EXECUTE_SILENT)
                {
                    repeats = value - VALUE_AUTO_EXECUTE_SILENT;
                    autoExecuteSilent = true;
                } 
                else if (Convert.ToInt32(value) >= VALUE_AUTO_EXECUTE_MANUAL)
                {
                    repeats = value - VALUE_AUTO_EXECUTE_MANUAL;
                    autoExecuteManual = true;
                } 
                else
                {
                    repeats = value;
                }
            }
        }
        public DateTime NextOccurrenceDate { get => nextOccurrenceDate; set => nextOccurrenceDate = value; }
        public int NumOccurrence { get => numOccurrence; set => numOccurrence = value; }
        public string Notes { get => notes; set => notes = value; }
        public bool AutoExecuteSilent { get => autoExecuteSilent; set => autoExecuteSilent = value; }
        public bool AutoExecuteManual { get => autoExecuteManual; set => autoExecuteManual = value; }
    }
}
