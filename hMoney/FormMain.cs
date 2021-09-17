using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hMoney
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void qqToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generateAccountList(object sender, EventArgs e)
        {

            //個人習慣會在一開始就開變數，可以無視
            string str = string.Empty;

            //這裡才是SQLite重點
            //將Data Source指到檔案位置
            //用Directory.GetCurrentDirectory()可以簡易的取得根目錄
            string path = @"Data Source = " + @"D:\Dennys\MMEX\dennys.mmb";
            //進行連線，用using可以避免忘了釋放
            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                //再來這邊的步驟跟操作其他DB很像，就是建立Command，然後連入合法的SQL語句，再Open連線
                string sql = "select * from accountlist_v1 where accounttype='Checking'";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                conn.Open();

                //連線有Open後，就能用Reader去讀取Query結果
                SQLiteDataReader reader = cmd.ExecuteReader();

                //這是用Microsoft.Data.Sqlite時的寫法，只能這樣先推到儲存資料再另外處理。
                TreeNode nodeHome = treeView1.Nodes.Add("Home");
                TreeNode nodeAccounts;
                nodeAccounts = nodeHome.Nodes.Add("Accounts");
                while (reader.Read())
                {
                    //_str.Add(reader["name"].ToString());
                    str = reader["accountname"].ToString();
                    nodeAccounts.Nodes.Add(str);
                }
                nodeHome.ExpandAll();

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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
