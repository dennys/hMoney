using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using static hMoney.Globals;

namespace hMoney
{
    public class DB
    {
        readonly String dbPath;
        const String FIELD_ACCOUNTTYPE = "AccountType";
        const String FIELD_ACCOUNTID = "AccountId";
        const String FIELD_TOACCOUNTID = "ToAccountId";
        const String FIELD_ACCOUNTNAME = "AccountName";
        const String FIELD_ACCOUNTNUM = "AccountNum";
        const String FIELD_STATUS = "status";
        const String FIELD_NOTES = "notes";
        const String FIELD_WEBSITE = "website";
        const String FIELD_CURRENCYID = "CurrencyId";
        const String FIELD_TRANSDATE = "TransDate";
        const String FIELD_TRANSCODE = "TransCode";
        const String FIELD_TRANSAMOUNT = "TransAmount";
        const String FIELD_CATEGNAME = "CategName";
        const String FIELD_SUBCATEGNAME = "SubCategName";
        const String FIELD_PAYEENAME = "PayeeName";
        const String FIELD_BALANCE = "Balance";
        const String FIELD_FAVORITEACCT = "FavoriteAcct";
        const String FIELD_INITIALBAL = "InitialBal";
        const String FIELD_HELDAT = "HeldAt";
        const String FIELD_CONTACTINFO = "ContactInfo";
        const String FIELD_ACCESSINFO = "AccessInfo";
        const String FIELD_BDID = "BdId";
        const String FIELD_PAYEEID = "PayeeId";
        const String FIELD_TRANSACTIONNUMBER = "TransActionNumber";
        const String FIELD_CATEGID = "CategId";
        const String FIELD_SUBCATEGID = "SubCategId";
        const String FIELD_FOLLOWUPID = "FollowUpId";
        const String FIELD_TOTRANSAMOUNT = "ToTransAmount";
        const String FIELD_REPEATS = "Repeats";
        const String FIELD_NEXTOCCURRENCEDATE = "NextOccurrenceDate";
        const String FIELD_NUMOCCURRENCES = "NumOccurrences";

        const String CONDITION_ALL = "All";
        const String CONDITION_TODAY = "Today";
        const String CONDITION_RECONCILED = "Reconciled";

        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        public DB()
        {
            Configuration config;

            // Setup configuration
            config = new Configuration();
            config.Init();

            // Get the path of database file
            dbPath = @"Data Source = " + config.GetDbPath();
        }

        public List<CheckingAccount> GetTransactionByAccountId(int accountId)
        {
            List<CheckingAccount> result = new();
            using SQLiteConnection conn = new(dbPath);

            // SQL command
            const string sql = @"SELECT a.accountname, c.categname, sc.subcategname,
                                            CASE WHEN t.transcode = 'Transfer' AND t.toaccountid = 1 THEN '< '||a.accountname
                                                 WHEN t.transcode = 'Transfer' AND t.accountid = 1   THEN '> '||ta.accountname
                                                 ELSE p.payeename
                                            END AS payeename, t.*
                                       FROM checkingaccount_v1 t
                                       LEFT OUTER JOIN accountlist_v1 a   ON t.accountid = a.accountid 
                                       LEFT OUTER JOIN accountlist_v1 ta  ON t.toaccountid = ta.accountid 
                                       LEFT OUTER JOIN category_v1 c      ON t.categid    = c.CategID
                                       LEFT OUTER JOIN subcategory_v1 sc  ON t.subcategid = sc.subcategid 
                                       LEFT OUTER JOIN payee_v1 p         ON t.payeeid       = p.payeeid 
                                      WHERE (t.accountid = @accountId OR t.toaccountid = @accountId)
                                      ORDER BY t.transdate  ";
            SQLiteCommand cmd = new(sql, conn);
            conn.Open();
            cmd.Prepare();
            cmd.Parameters.Add("@accountId", DbType.Int32).Value = accountId;
            Log.Debug("SQL:" + sql);
            SQLiteDataReader reader = cmd.ExecuteReader();

            //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
            while (reader.Read())
            {
                CheckingAccount trans = new();
                trans.AccountId = Convert.ToInt32(reader[FIELD_ACCOUNTID]);
                trans.AccountName = reader[FIELD_ACCOUNTNAME].ToString();
                trans.Transdate = DateTime.Parse(reader[FIELD_TRANSDATE].ToString());
                trans.CategName = reader[FIELD_CATEGNAME].ToString();
                trans.SubCategName = reader[FIELD_SUBCATEGNAME].ToString();
                trans.PayeeName = reader[FIELD_PAYEENAME].ToString();
                trans.TransCode = reader[FIELD_TRANSCODE].ToString();
                trans.TransAmount = Convert.ToDecimal(reader[FIELD_TRANSAMOUNT]);
                trans.Status = reader[FIELD_STATUS].ToString();
                trans.Notes = reader[FIELD_NOTES].ToString();
                result.Add(trans);
            }
            return result;
        }

        public List<Account> GetAccountListByAccountType(String accountType)
        {
            List<Account> result = new();

            //進行連線，用using可以避免忘了釋放
            using SQLiteConnection conn = new(dbPath);
            // SQL command
            const string sql = @"SELECT * 
                                       FROM accountlist_v1
                                      WHERE accounttype = @accountType
                                      ORDER BY accountname ";
            SQLiteCommand cmd = new(sql, conn);
            conn.Open();
            cmd.Prepare();
            cmd.Parameters.Add("@accountType", DbType.String).Value = accountType;
            SQLiteDataReader reader = cmd.ExecuteReader();

            //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
            while (reader.Read())
            {
                Account account = new();
                account.AccountId = Convert.ToInt32(reader[FIELD_ACCOUNTID]);
                account.AccountName = reader[FIELD_ACCOUNTNAME].ToString();
                result.Add(account);
            }
            return result;

            //改用System.Data.SQLite後，要轉DataTable只要用Load()就行了
            //DataTable dt = new DataTable();
            //dt.Load(reader);

            //如果是用adapter跟DataSet就更簡單了
            //SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn); //似乎不能直接用cmd? 會有Exception
            //DataSet ds = new DataSet();
            //adapter.Fill(ds, "FirstTable"); //用 .Fill(ds) 就夠了，要重新命名TableName才需要放第二個參數
            //接著只要 ds.Tables[0] 就能取出DataTable (當然... DataSet不止能這樣用)
        }
        public decimal GetAccountTodayBalanceByAccountIdWithoutInitialBalance(int accountId, String condition)
        {
            decimal todayBalance = 0;
            string sql;

            //進行連線，用using可以避免忘了釋放
            using SQLiteConnection conn = new(dbPath);
            // SQL command
            if (condition == CONDITION_TODAY)
            {
                sql = @"SELECT sum(amount) balance
                                       FROM (SELECT CASE WHEN t.transcode = 'Deposit'  THEN t.transamount
                                                         WHEN t.transcode = 'Transfer' AND t.toaccountid = @accountId THEN t.transamount
                                                    ELSE t.transamount * -1
                                                    END as amount
                                               FROM checkingaccount_v1 t
                                              WHERE (accountid = @accountId OR toaccountid = @accountId)
                                                AND t.transdate <= date(CURRENT_TIMESTAMP, 'localtime') ) ";
            }
            else if (condition == CONDITION_RECONCILED)
            {
                sql = @"SELECT sum(amount) balance
                                       FROM (SELECT CASE WHEN t.transcode = 'Deposit'  THEN t.transamount
                                                         WHEN t.transcode = 'Transfer' AND t.toaccountid = @accountId THEN t.transamount
                                                    ELSE t.transamount * -1
                                                    END as amount
                                               FROM checkingaccount_v1 t
                                              WHERE (accountid = @accountId OR toaccountid = @accountId)
                                                AND t.status = 'R' ) ";
            }
            else //Quary all transactions
            {
                sql = @"SELECT sum(amount) balance
                                       FROM (SELECT CASE WHEN t.transcode = 'Deposit'  THEN t.transamount
                                                         WHEN t.transcode = 'Transfer' AND t.toaccountid = @accountId THEN t.transamount
                                                    ELSE t.transamount * -1
                                                    END as amount
                                               FROM checkingaccount_v1 t
                                              WHERE (accountid = @accountId OR toaccountid = @accountId) ) ";
            }
            SQLiteCommand cmd = new(sql, conn);
            conn.Open();
            cmd.Prepare();
            cmd.Parameters.Add("@accountId", DbType.Int32).Value = accountId;
            SQLiteDataReader reader = cmd.ExecuteReader();

            // TODO: The SQL is not good, it will return 1 row even there is no data
            while (reader.Read())
            {
                todayBalance = String.IsNullOrEmpty(reader[FIELD_BALANCE].ToString()) ? 0 : Convert.ToInt32(reader[FIELD_BALANCE]);
                Log.Debug("AccountId = " + accountId + ", balance (without initlal balance) = " + todayBalance);
            }
            return todayBalance;
        }
        public List<Account> GetAccountBalanceByAccountType(String accountType)
        {
            List<Account> accountList = new();

            using SQLiteConnection conn = new(dbPath);

            // Save Reconciled data into a dictionary
            //const string sqlReconciled = @"SELECT IFNULL ((a.initialbal + x.amount), 0) reconciled, a.* 
            //                 FROM accountlist_v1 a
            //                 LEFT OUTER JOIN (
            //                      SELECT accountid,
            //                             SUM(CASE WHEN t.transcode = 'Deposit'  THEN t.transamount
            //                                      WHEN t.transcode = 'Transfer' THEN t.transamount
            //                                      ELSE t.transamount * -1
            //                                    END) as amount
            //                         FROM checkingaccount_v1 t
            //                        WHERE t.status = 'R'
            //                        GROUP BY accountid ) x
            //                   ON a.accountid = x.accountid
            //                WHERE a.accounttype = @AccountType
            //                ORDER BY a.accountname ";
            //SQLiteCommand cmd = new(sqlReconciled, conn);
            //conn.Open();
            //cmd.Prepare();
            //cmd.Parameters.Add("@AccountType", DbType.String).Value = accountType;
            //SQLiteDataReader reader = cmd.ExecuteReader();

            //Dictionary<int, int> reconciledDict = new Dictionary<int, int>();
            //while (reader.Read())
            //{
            //    reconciledDict.Add(Convert.ToInt32(reader[FIELD_ACCOUNTID]), Convert.ToInt32(reader["reconciled"]));
            //}
            //conn.Close();

            // Save Today Balance
            const string sqlTodayBal = @"SELECT (a.initialbal + x.amount) todaybal, a.initialbal, a.* 
                                 FROM accountlist_v1 a
                                 LEFT OUTER JOIN (
                                      SELECT accountid,
                                             SUM(CASE WHEN t.transcode = 'Deposit'  THEN t.transamount
                                                      WHEN t.transcode = 'Transfer' THEN t.transamount
                                                      ELSE t.transamount * -1
                                                    END) as amount
                                         FROM checkingaccount_v1 t
                                        GROUP BY accountid ) x
                                   ON a.accountid = x.accountid
                                WHERE a.accounttype = @AccountType
                                ORDER BY a.accountname ";
            SQLiteCommand cmd = new(sqlTodayBal, conn);
            conn.Open();
            cmd.Prepare();
            cmd.Parameters.Add("@AccountType", DbType.String).Value = accountType;
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Account account = new();
                account.AccountId = Convert.ToInt32(reader[FIELD_ACCOUNTID]);
                account.AccountType = reader[FIELD_ACCOUNTTYPE].ToString();
                account.AccountName = reader[FIELD_ACCOUNTNAME].ToString();
                //account.Reconciled = reconciledDict[account.AccountId];
                account.InitialBal = Convert.ToInt32(reader[FIELD_INITIALBAL]);
                account.Reconciled = account.InitialBal + this.GetAccountTodayBalanceByAccountIdWithoutInitialBalance(account.AccountId, CONDITION_RECONCILED);
                account.TodayBal = account.InitialBal + this.GetAccountTodayBalanceByAccountIdWithoutInitialBalance(account.AccountId, CONDITION_TODAY);
                account.FutureBal = account.InitialBal + this.GetAccountTodayBalanceByAccountIdWithoutInitialBalance(account.AccountId, CONDITION_ALL);
                account.Status = reader[FIELD_STATUS].ToString();
                account.Notes = reader[FIELD_NOTES].ToString();
                account.WebSite = reader[FIELD_WEBSITE].ToString();
                account.CurrencyId = Convert.ToInt32(reader[FIELD_CURRENCYID]);
                account.FavoriteAcct = reader[FIELD_FAVORITEACCT].ToString() == "TRUE";
                accountList.Add(account);
                //Log.Debug(account.AccountId + "/" + account.AccountName + ":" + account.TodayBal);
            }
            return accountList;
        }
        public Account GetAccountByAccountId(int accountId)
        {
            Account account = new();
            //進行連線，用using可以避免忘了釋放
            using SQLiteConnection conn = new(dbPath);
            // SQL command
            const string sql = @"SELECT * 
                                 FROM accountlist_v1
                                WHERE accountid = @accountId ";
            SQLiteCommand cmd = new(sql, conn);
            conn.Open();
            cmd.Prepare();
            cmd.Parameters.Add("@accountId", DbType.Int32).Value = accountId;
            SQLiteDataReader reader = cmd.ExecuteReader();

            //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
            while (reader.Read())
            {
                account.AccountId = Convert.ToInt32(reader[FIELD_ACCOUNTID]);
                account.AccountName = reader[FIELD_ACCOUNTNAME].ToString();
                account.AccountType = reader[FIELD_ACCOUNTTYPE].ToString();
                account.AccountNum = reader[FIELD_ACCOUNTNUM].ToString();
                account.Status = reader[FIELD_STATUS].ToString();
                account.Notes = reader[FIELD_NOTES].ToString();
                account.HeldAt = reader[FIELD_HELDAT].ToString();
                account.WebSite = reader[FIELD_WEBSITE].ToString();
                account.ContactInfo = reader[FIELD_CONTACTINFO].ToString();
                account.AccessInfo = reader[FIELD_ACCESSINFO].ToString();
                account.InitialBal = Convert.ToDecimal(reader[FIELD_INITIALBAL]);
                account.FavoriteAcct = reader[FIELD_FAVORITEACCT].ToString() == "TRUE";
                account.CurrencyId = Convert.ToInt32(reader[FIELD_CURRENCYID]);
                account.Reconciled = account.InitialBal + this.GetAccountTodayBalanceByAccountIdWithoutInitialBalance(account.AccountId, CONDITION_RECONCILED);
                account.TodayBal = account.InitialBal + this.GetAccountTodayBalanceByAccountIdWithoutInitialBalance(account.AccountId, CONDITION_TODAY);
                account.FutureBal = account.InitialBal + this.GetAccountTodayBalanceByAccountIdWithoutInitialBalance(account.AccountId, CONDITION_ALL);
                //Log.Debug(account.AccountId + "/" + account.AccountName + ":" + account.TodayBal);
            }
            return account;
        }
        public List<Account> GetAccountSummary()
        {
            List<String> accountTypes = new();
            accountTypes.Add("Checking");
            accountTypes.Add("Credit Card");
            accountTypes.Add("Term");
            accountTypes.Add("Investment");
            accountTypes.Add("Loan");
            accountTypes.Add("Shares");
            accountTypes.Add("Asset");

            List<Account> accountList = new();
            foreach (String accountType in accountTypes)
            {
                accountList.AddRange(GetAccountBalanceByAccountType(accountType));
            }
            return accountList;
        }
        public SortedSet<int> GetAccountIdListByAccountType(String accountType)
        {
            SortedSet<int> result = new();

            //進行連線，用using可以避免忘了釋放
            using SQLiteConnection conn = new(dbPath);
            // SQL command
            const string sql = @"SELECT * 
                                       FROM accountlist_v1 
                                      WHERE accounttype = @accountType
                                      ORDER BY accountid ";
            SQLiteCommand cmd = new(sql, conn);
            conn.Open();
            cmd.Prepare();
            cmd.Parameters.Add("@accountType", DbType.String).Value = accountType;
            SQLiteDataReader reader = cmd.ExecuteReader();

            //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
            while (reader.Read())
            {
                result.Add(Convert.ToInt32(reader[FIELD_ACCOUNTID]));
            }
            Log.Debug("Get " + result.Count + " accounts of " + accountType);
            return result;
        }
        public SortedSet<string> GetAccountNameList()
        {
            SortedSet<string> result = new();

            //進行連線，用using可以避免忘了釋放
            using SQLiteConnection conn = new(dbPath);
            // SQL command
            const string sql = @"SELECT * 
                                       FROM accountlist_v1
                                      --WHERE accounttype='Checking'
                                      ORDER BY accountname ";
            SQLiteCommand cmd = new(sql, conn);
            conn.Open();
            SQLiteDataReader reader = cmd.ExecuteReader();

            //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
            while (reader.Read())
            {
                result.Add(reader[FIELD_ACCOUNTNAME].ToString());
            }
            return result;
        }
        public List<BillsDeposits> GetBillsDepositsByAccountId(int accountId)
        {
            List< BillsDeposits> billsDepositsList = new();
            //進行連線，用using可以避免忘了釋放
            using SQLiteConnection conn = new(dbPath);
            // SQL command
            const string sql = @"SELECT a.accountname, ta.accountname, p.payeename, c.categname, sc.subcategname, b.*
                                       FROM billsdeposits_v1 b
                                       LEFT OUTER JOIN accountlist_v1 a  ON b.accountid = a.accountid
                                       LEFT OUTER JOIN accountlist_v1 ta ON b.toaccountid = ta.accountid
                                       LEFT OUTER JOIN payee_v1 p        ON b.payeeid = p.payeeid
                                       LEFT OUTER JOIN category_v1 c     ON b.categid = c.categid
                                       LEFT OUTER JOIN subcategory_v1 sc ON b.subcategid = sc.subcategid
                                      WHERE b.accountid = @accountId ";
            SQLiteCommand cmd = new(sql, conn);
            conn.Open();
            cmd.Prepare();
            cmd.Parameters.Add("@accountId", DbType.Int32).Value = accountId;
            SQLiteDataReader reader = cmd.ExecuteReader();

            //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
            while (reader.Read())
            {
                BillsDeposits billsDeposits = new();
                billsDeposits.BdId = Convert.ToInt32(reader[FIELD_BDID]);
                billsDeposits.AccountId = Convert.ToInt32(reader[FIELD_ACCOUNTID]);
                billsDeposits.ToAccountId = Convert.ToInt32(reader[FIELD_TOACCOUNTID]);
                billsDeposits.PayeeId = Convert.ToInt32(reader[FIELD_PAYEEID]);
                billsDeposits.TransCode = reader[FIELD_TRANSCODE].ToString();
                billsDeposits.TransAmount = Convert.ToDecimal(reader[FIELD_TRANSAMOUNT]);
                billsDeposits.Status = reader[FIELD_STATUS].ToString();
                billsDeposits.TransActionNumber = reader[FIELD_TRANSACTIONNUMBER].ToString();
                billsDeposits.Notes = reader[FIELD_NOTES].ToString();
                billsDeposits.CategoryId = Convert.ToInt32(reader[FIELD_CATEGID]);
                billsDeposits.SubCategoryId = Convert.ToInt32(reader[FIELD_SUBCATEGID]);
                billsDeposits.TransDate = DateTime.Parse(reader[FIELD_TRANSDATE].ToString());
                billsDeposits.FollowUpId = Convert.ToInt32(reader[FIELD_FOLLOWUPID]);
                billsDeposits.ToTransAmount = Convert.ToDecimal(reader[FIELD_TOTRANSAMOUNT]);
                billsDeposits.Repeats = (RepeatType)Enum.Parse(typeof(RepeatType), reader[FIELD_REPEATS].ToString());
                billsDeposits.NextOccurrenceDate = DateTime.Parse(reader[FIELD_NEXTOCCURRENCEDATE].ToString());
                billsDeposits.NumOccurrence = Convert.ToInt32(reader[FIELD_NUMOCCURRENCES]);
                billsDepositsList.Add(billsDeposits);
            }
            return billsDepositsList;
        }

    }
}
