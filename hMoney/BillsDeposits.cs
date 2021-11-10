using System;
using static hMoney.Globals;

namespace hMoney
{
    public class BillsDeposits
    {
        const int VALUE_AUTO_EXECUTE_MANUAL = 100;
        const int VALUE_AUTO_EXECUTE_SILENT = 200;

        private Boolean autoExecuteManual;
        private Boolean autoExecuteSilent;
        private RepeatType repeats;

        public int BdId { get; set; }
        public int AccountId { get; set; }
        public int ToAccountId { get; set; }
        public int PayeeId { get; set; }
        public string TransCode { get; set; }
        public decimal TransAmount { get; set; }
        public string Status { get; set; }
        public string TransActionNumber { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string SubCategory { get; set; }
        public int SubCategoryId { get; set; }
        public DateTime TransDate { get; set; }
        public int FollowUpId { get; set; }
        public decimal ToTransAmount { get; set; }
        public Boolean AutoExecuteSilent { get; set; }
        public Boolean AutoExecuteManual { get; set; }

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
        public DateTime NextOccurrenceDate { get; set; }
        public int NumOccurrence { get; set; }
        public string Notes { get; set; }
    }
}
