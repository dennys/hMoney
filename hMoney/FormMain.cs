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
            // Enable configuration
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
            this.configFormat();
            tabAccount.Hide();

            //TreeNode nodeHome = treeView1.Nodes.Add("Home");

            List<String> accountTypes = new List<String>();
            accountTypes.Add("Checking");
            accountTypes.Add("Credit Card");
            accountTypes.Add("Investment");
            accountTypes.Add("Loan");
            accountTypes.Add("Term");
            accountTypes.Add("Shares");
            accountTypes.Add("Asset");

            List<Account> accountList = new List<Account>();

            foreach (String accountType in accountTypes)
            {
                Log.Debug("Start to get AccountIdList of " + accountType);
                // Show account list
                accountList.Clear();
                accountList = db.getAccountListByAccountType(accountType);

                TreeNode nodeAccounts = treeView1.Nodes.Add(accountType);
                foreach (Account account in accountList)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = account.AccountId;
                    node.Text = account.AccountName;
                    nodeAccounts.Nodes.Add(node);
                }
                nodeAccounts.ExpandAll();
            }

            treeView1.SelectedNode = treeView1.Nodes[0];    // Select the Home node

        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name == Globals.TREE_VIEW_HOME_NAME)
                this.showSummary();
            else
                this.showAccount(e.Node.Tag.ToString(), e.Node.Text);

        }
        private void showAccount(String accountId, String accountName)
        {
            var transList = new List<CheckingAccount>();
            transList = db.getTransactionByAccountId(Convert.ToInt32(accountId));
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
                if (trans.TransCode == "Deposit")
                {
                    gridTrans.Rows[i].Cells[x++].Value = trans.TransAmount;
                    x++;
                }
                else
                {
                    x++;
                    gridTrans.Rows[i].Cells[x++].Value = trans.TransAmount;
                }
                gridTrans.Rows[i].Cells[x++].Value = trans.Notes;
                i++;
            }
            gridTrans.FirstDisplayedScrollingRowIndex = gridTrans.RowCount - 1;  // Move to last row

            tabControl1.SelectedTab = tabAccount;
            tabAccount.Text = accountName;
        }
        private void showSummary()
        {
            List<Account> accountList = db.getAccountSummary();
            gridSummary.Rows.Clear();
            int i = 0;
            String accountType = "";

            foreach (Account account in accountList)
            {
                gridSummary.Rows.Add(new DataGridViewRow());
                int x = 0;

                if (accountType != account.AccountType) // New account type
                {
                    gridSummary.Rows[i].Cells[0].Value = account.AccountType;
                    gridSummary.Rows[i].DefaultCellStyle.Font = new Font(gridSummary.Font, FontStyle.Bold);
                    gridSummary.Rows[i].DefaultCellStyle.BackColor = config.GetAccountSummaryHeaderBackColor();
                    gridSummary.Rows[i].DefaultCellStyle.BackColor = Color.Cornsilk;
                    gridSummary.Rows.Add(new DataGridViewRow());
                    i++;
                }
                accountType = account.AccountType;

                gridSummary.Rows[i].Cells[x++].Value = "  " + account.AccountName;
                gridSummary.Rows[i].Cells[x++].Value = null;
                gridSummary.Rows[i].Cells[x++].Value = account.TodayBal;
                gridSummary.Rows[i].Cells[x++].Value = null;
                i++;
                //Log.Debug(account.AccountId + "/" + account.AccountName + ":" + account.TodayBal);
            }
            gridSummary.ClearSelection();
            tabControl1.SelectedTab = tabHome;
        }
        private void configFormat()
        {
            gridTrans.Columns[0].DefaultCellStyle.Format = config.GetDateFormat();
            gridTrans.Columns[4].DefaultCellStyle.Format = config.GetNumberFormat();
            gridTrans.Columns[5].DefaultCellStyle.Format = config.GetNumberFormat();
            //gridSummary.AlternatingRowsDefaultCellStyle.Format = config.GetNumberFormat();
            gridSummary.Columns[1].DefaultCellStyle.Format = config.GetNumberFormat();
            gridSummary.Columns[2].DefaultCellStyle.Format = config.GetNumberFormat();
            gridSummary.Columns[3].DefaultCellStyle.Format = config.GetNumberFormat();
            treeView1.Font = new Font(treeView1.Font.Name, config.GetTreeAccountFontSize());
            gridSummary.Font = new Font(treeView1.Font.Name, config.GetFontSize());
            gridTrans.Font = new Font(treeView1.Font.Name, config.GetFontSize());
        }

    }
}
