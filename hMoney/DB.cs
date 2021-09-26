using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace hMoney
{
    public class DB
    {

        Configuration config;
        String dbPath;

        public DB()
        {
            // Setup log (Serilog)
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Console()
                    .CreateLogger();

            // Setup configuration
            config = new Configuration();
            config.Init();

            // Get the path of database file
            dbPath = @"Data Source = " + config.GetDbPath();
        }

        public List<CheckingAccount> getTransactionByAccountId(int accountId)
        {
            var result = new List<CheckingAccount>();

            //進行連線，用using可以避免忘了釋放
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                // SQL command
                string sql = @"SELECT a.accountname, c.categname, sc.subcategname, p.payeename, t.* 
                                 FROM checkingaccount_v1 t, accountlist_v1 a
								 LEFT OUTER JOIN category_v1 c      ON t.categid    = c.CategID
								 LEFT OUTER JOIN subcategory_v1 sc  ON t.subcategid = sc.subcategid 
								 LEFT OUTER JOIN payee_v1 p         ON t.payeeid       = p.payeeid 
                                WHERE t.accountid = a.accountid 
                                  AND t.accountid = @int1
                                ORDER BY t.transdate ";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                conn.Open();
                cmd.Prepare();
                cmd.Parameters.Add("@int1", DbType.Int32).Value = accountId;
                Log.Debug("SQL:" + sql);
                SQLiteDataReader reader = cmd.ExecuteReader();

                //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
                while (reader.Read())
                {
                    CheckingAccount trans = new CheckingAccount();
                    trans.AccountId = Convert.ToInt32(reader["accountid"]);
                    trans.AccountName = reader["accountname"].ToString();
                    trans.Transdate = DateTime.Parse(reader["transdate"].ToString());
                    trans.Category = reader["categname"].ToString();
                    trans.SubCategory = reader["subcategname"].ToString();
                    trans.PayeeName = reader["payeename"].ToString();
                    trans.TransCode = reader["TransCode"].ToString();
                    trans.TransAmount = Convert.ToDecimal(reader["transamount"]);
                    trans.Notes = reader["notes"].ToString();
                    result.Add(trans);
                }
                return result;
            }
        }

        public List<Account> getAccountListByAccountType(String accountType)
        {
            var result = new List<Account>();

            //進行連線，用using可以避免忘了釋放
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                // SQL command
                string sql = @"SELECT * 
                                 FROM accountlist_v1
                                WHERE accounttype = @AccountType
                                ORDER BY accountname ";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                conn.Open();
                cmd.Prepare();
                cmd.Parameters.Add("@AccountType", DbType.String).Value = accountType;
                SQLiteDataReader reader = cmd.ExecuteReader();

                //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
                while (reader.Read())
                {
                    Account account = new Account();
                    account.AccountId = Convert.ToInt32(reader["accountid"]);
                    account.AccountName = reader["accountname"].ToString();
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
        }
        public decimal getAccountBalanceByAccountIdWithoutInitialBalance(int accountId)
        {
            decimal result = 0;

            //進行連線，用using可以避免忘了釋放
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                // SQL command
                string sql = @"SELECT sum(amount) balance FROM (
                                 SELECT CASE WHEN t.transcode = 'Deposit'  THEN t.transamount
                                             WHEN t.transcode = 'Transfer' THEN t.transamount * -1
	                                         ELSE t.transamount * -1
	                                    END as amount
                                   FROM checkingaccount_v1 t
                                  WHERE accountid = @AccountId) ";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                conn.Open();
                cmd.Prepare();
                cmd.Parameters.Add("@AccountId", DbType.Int32).Value = accountId;
                SQLiteDataReader reader = cmd.ExecuteReader();
                Log.Debug("AccountId = " + accountId);

                //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
                // TODO: The SQL is not good, it will return 1 row even there is no data
                while (reader.Read())
                {
                    if (String.IsNullOrEmpty(reader["balance"].ToString())) { return 0; }
                    result = Convert.ToDecimal(reader["balance"]);
                }
                return result;
            }
        }
        public List<Account> getAccountBalanceByAccountType(String accountType)
        {
            var result = new List<Account>();

            //進行連線，用using可以避免忘了釋放
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                // Save Reconciled data into a dictionary
                string sqlReconciled = @"SELECT IFNULL ((a.initialbal + x.amount), 0) reconciled, a.* 
                                 FROM accountlist_v1 a
                                 LEFT OUTER JOIN (
                                      SELECT accountid,
                                             SUM(CASE WHEN t.transcode = 'Deposit'  THEN t.transamount
                                                      WHEN t.transcode = 'Transfer' THEN t.transamount * -1
	                                                  ELSE t.transamount * -1
       	                                         END) as amount
                                         FROM checkingaccount_v1 t
                                        WHERE t.status = 'R'
                                        GROUP BY accountid ) x
                                   ON a.accountid = x.accountid
                                WHERE a.accounttype = @AccountType
                                ORDER BY a.accountname ";
                SQLiteCommand cmd = new SQLiteCommand(sqlReconciled, conn);
                conn.Open();
                cmd.Prepare();
                cmd.Parameters.Add("@AccountType", DbType.String).Value = accountType;
                SQLiteDataReader reader = cmd.ExecuteReader();

                Dictionary<int, int> reconciledDict = new Dictionary<int, int>();
                while (reader.Read())
                {
                    int accountId = Convert.ToInt32(reader["accountid"]);
                    int reconciled = Convert.ToInt32(reader["reconciled"]);
                    reconciledDict.Add(Convert.ToInt32(reader["accountid"]), Convert.ToInt32(reader["reconciled"]));
                }
                conn.Close();

                // Save Today Balance
                string sqlTodayBal = @"SELECT (a.initialbal + x.amount) todaybal, a.* 
                                 FROM accountlist_v1 a
                                 LEFT OUTER JOIN (
                                      SELECT accountid,
                                             SUM(CASE WHEN t.transcode = 'Deposit'  THEN t.transamount
                                                      WHEN t.transcode = 'Transfer' THEN t.transamount * -1
	                                                  ELSE t.transamount * -1
       	                                         END) as amount
                                         FROM checkingaccount_v1 t
                                        GROUP BY accountid ) x
                                   ON a.accountid = x.accountid
                                WHERE a.accounttype = @AccountType
                                ORDER BY a.accountname ";
                cmd = new SQLiteCommand(sqlTodayBal, conn);
                conn.Open();
                cmd.Prepare();
                cmd.Parameters.Add("@AccountType", DbType.String).Value = accountType;
                reader = cmd.ExecuteReader();

                //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
                while (reader.Read())
                {
                    Account account = new Account();
                    account.AccountId = Convert.ToInt32(reader["accountid"]);
                    account.AccountType = reader["accounttype"].ToString();
                    account.AccountName = reader["accountname"].ToString();
                    account.TodayBal = account.InitialBal + this.getAccountBalanceByAccountIdWithoutInitialBalance(account.AccountId);
                    account.Reconciled = reconciledDict[account.AccountId];
                    account.Status = reader["status"].ToString();
                    account.Notes = reader["notes"].ToString();
                    account.WebSite = reader["website"].ToString();
                    account.CurrencyId = Convert.ToInt32(reader["CurrencyId"]);
                    if (reader["FavoriteAcct"].ToString() == "TRUE")
                        account.FavoriteAcct = true;
                    else
                        account.FavoriteAcct = false;
                    result.Add(account);
                    //Log.Debug(account.AccountId + "/" + account.AccountName + ":" + account.TodayBal);
                }
                return result;
            }
        }
        public List<Account> getAccountBalanceByAccountTypeXXX(String accountType)
        {
            var result = new List<Account>();

            //進行連線，用using可以避免忘了釋放
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                // SQL command
                string sql = @"SELECT * 
                                 FROM accountlist_v1
                                WHERE accounttype = @AccountType
                                ORDER BY accountname ";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                conn.Open();
                cmd.Prepare();
                cmd.Parameters.Add("@AccountType", DbType.String).Value = accountType;
                SQLiteDataReader reader = cmd.ExecuteReader();

                //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
                while (reader.Read())
                {
                    Account account = new Account();
                    account.AccountId = Convert.ToInt32(reader["accountid"]);
                    account.AccountName = reader["accountname"].ToString();
                    account.TodayBal = account.InitialBal + this.getAccountBalanceByAccountIdWithoutInitialBalance(account.AccountId);
                    account.Status = reader["status"].ToString();
                    account.Notes = reader["notes"].ToString();
                    account.WebSite = reader["website"].ToString();
                    if (reader["website"].ToString() == "TRUE")
                        account.FavoriteAcct = true;
                    else
                        account.FavoriteAcct = false;
                    //Log.Debug(account.AccountId + "/" + account.AccountName + ":" + account.TodayBal);
                }
                return result;
            }
        }
        public List<Account> getAccountSummary()
        {
            List<String> accountTypes = new List<String>();
            accountTypes.Add("Checking");
            accountTypes.Add("Credit Card");
            accountTypes.Add("Term");
            accountTypes.Add("Investment");
            accountTypes.Add("Loan");
            accountTypes.Add("Term");
            accountTypes.Add("Shares");
            accountTypes.Add("Asset");

            List<Account> accountList = new List<Account>();
            foreach (String accountType in accountTypes)
            {
                accountList.AddRange(getAccountBalanceByAccountType(accountType));
            }
            return accountList;
        }
        public SortedSet<int> getAccountIdListByAccountType(String accountType)
        {
            var result = new SortedSet<int>();

            //進行連線，用using可以避免忘了釋放
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                // SQL command
                string sql = @"SELECT * 
                                 FROM accountlist_v1 
                                WHERE accounttype = @AccountType
                                ORDER BY accountid ";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                conn.Open();
                cmd.Prepare();
                cmd.Parameters.Add("@AccountType", DbType.String).Value = accountType;
                SQLiteDataReader reader = cmd.ExecuteReader();

                //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
                while (reader.Read())
                {
                    result.Add(Convert.ToInt32(reader["accountid"]));
                }
                Log.Debug("Get " + result.Count + " accounts of " + accountType);
                return result;
            }

        }
        public SortedSet<string> getAccountNameList()
        {
            var result = new SortedSet<string>();

            //進行連線，用using可以避免忘了釋放
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                // SQL command
                string sql = @"SELECT * 
                                 FROM accountlist_v1
                                WHERE accounttype='Checking'
                                ORDER BY accountname ";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                conn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();

                //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
                while (reader.Read())
                {
                    result.Add(reader["accountname"].ToString());
                }
                return result;
            }

        }

    }
}
