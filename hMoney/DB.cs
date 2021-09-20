using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hMoney
{
    public class DB
    {
        public List<CheckingAccount> getTransactionByAccountId(int accountId)
        {
            var result = new List<CheckingAccount>();
            Configuration config = new Configuration();
            config.Init();

            // Get the path of database file
            string path = @"Data Source = " + config.GetDbPath();

            //進行連線，用using可以避免忘了釋放
            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                // SQL command
                string sql = " SELECT a.accountname, c.categname, sc.subcategname, p.payeename, t.* "
                           + "   FROM checkingaccount_v1 t, accountlist_v1 a, category_v1 c, subcategory_v1 sc, payee_v1 p "
                           + "  WHERE t.accountid = a.accountid "
                           + "    AND t.categid = c.CategID "
                           + "    AND t.subcategid = sc.subcategid "
                           + "    AND t.payeeid = p.payeeid "
                           + "    AND t.accountid = @int1"
                           + "  ORDER BY t.transdate "; 
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                conn.Open();
                cmd.Prepare();
                cmd.Parameters.Add("@int1", DbType.Int32).Value = accountId;
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
                    trans.TransAmount = Convert.ToInt32(reader["transamount"]);
                    trans.Notes = reader["notes"].ToString();
                    result.Add(trans);
                }
                return result;
            }
        }

        public List<Account> getAccountList()
        {
            var result = new List<Account>();
            Configuration config = new Configuration();
            config.Init();

            // Get the path of database file
            string path = @"Data Source = " + config.GetDbPath();

            //進行連線，用using可以避免忘了釋放
            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                // SQL command
                //string sql = "select * from accountlist_v1 where accounttype='Checking' order by accountname";
                string sql = "select * from accountlist_v1 order by accountname ";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                conn.Open();
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
        public SortedSet<string> getAccountNameList()
        {
            var result = new SortedSet<string>();
            Configuration config = new Configuration();
            config.Init();

            // Get the path of database file
            string path = @"Data Source = " + config.GetDbPath();

            //進行連線，用using可以避免忘了釋放
            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                // SQL command
                string sql = "select * from accountlist_v1 where accounttype='Checking'";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                conn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();

                //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
                while (reader.Read())
                {
                    result.Add(reader["accountname"].ToString());
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

    }
}
