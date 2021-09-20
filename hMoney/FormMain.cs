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
using Serilog;

namespace hMoney
{
    public partial class FormMain : Form
    {
        Configuration config;
        DB db;

        public FormMain()
        {
            config = new Configuration();
            config.Init();

            // Setup log (Serilog)
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            // Setup i18n
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(config.GetLanguage());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(config.GetLanguage());
            InitializeComponent();

            // Enable DB
            db = new DB();

            Log.Information("Initial ...");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void initial(object sender, EventArgs e)
        {
            // Show account list
            var accountList = new List<Account>();
            accountList = db.getAccountList();

            //TreeNode nodeHome = treeView1.Nodes.Add("Home");
            TreeNode nodeAccounts = treeView1.Nodes.Add("Accounts");
            foreach (Account account in accountList)
            {
                TreeNode node = new TreeNode();
                node.Tag = account.AccountId;
                node.Text = account.AccountName;
                nodeAccounts.Nodes.Add(node);
            }
            nodeAccounts.ExpandAll();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Show account list
            var transList = new List<CheckingAccount>();
            transList = db.getTransactionByAccountId(Convert.ToInt32(e.Node.Tag));
            gridTrans.Rows.Clear();
            int i = 0;
            foreach (CheckingAccount trans in transList)
            {
                DataGridViewRow row = new DataGridViewRow();
                gridTrans.Rows.Add(row);
                int x = 0;
                gridTrans.Rows[i].Cells[x++].Value = trans.Transdate;
                gridTrans.Rows[i].Cells[x++].Value = trans.Category + ":" + trans.SubCategory;
                gridTrans.Rows[i].Cells[x++].Value = trans.AccountName;
                gridTrans.Rows[i].Cells[x++].Value = trans.PayeeName;
                if (trans.TransCode == "Deposit") {
                    gridTrans.Rows[i].Cells[x++].Value = trans.TransAmount;
                    x++;
                } else {
                    x++;
                    gridTrans.Rows[i].Cells[x++].Value = trans.TransAmount;
                }
                gridTrans.Rows[i].Cells[x++].Value = trans.Notes;
                i++;
            }
            gridTrans.FirstDisplayedScrollingRowIndex = gridTrans.RowCount - 1;  // Move to last row
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.getAccountSummary();
        }
    }
}
