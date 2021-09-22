using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hMoney
{
    public class Account
    {
        public int AccountId;
        public String AccountName;
        public String AccountType;
        public String AccountNum;
        public String Status;
        public String Notes;
        public String HeldAt;
        public decimal InitialBal;


        public decimal TodayBal;     // This field is calculated dynamically, not existed in database
        public decimal FutureBal;     // This field is calculated dynamically, not existed in database
    }
}
