using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hMoney
{
    public class CheckingAccount
    {
        public DateTime Transdate;
        public int AccountId;
        public int ToAccountId;
        public String AccountName;
        public String ToAccountName;
        public String AccountType;
        public String AccountNum;
        public String Status;
        public String Category;
        public int CategoryId;
        public String SubCategory;
        public int SubCategoryId;
        public String PayeeName;
        public int PayeeId;
        public int TransId;
        public decimal TransAmount;
        public decimal ToTransAmount;
        public String TransCode;

        public String Notes;
        public String HeldAt;
    }
}
