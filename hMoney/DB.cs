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
        public SortedSet<string> getAccountList()
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
