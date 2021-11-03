using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace hMoney
{
    public partial class FormMain : Form
    {
        const String TRANSCODE_WITHDRAWAL = "Withdrawal";
        const String TRANSCODE_TRANSFER = "Transfer";
        private readonly Configuration config;
        private readonly DB db;
        private readonly Apix api;

        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public FormMain()
        {
            Log.Debug("Hello World!!");
            // Enable configuration
            config = new Configuration();
            config.Init();

            // Setup i18n
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(config.GetLanguage());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(config.GetLanguage());
            InitializeComponent();

            // Enable DB
            db = new DB();

            // Enable API
            api = new Apix();
        }

        private void Initial(object sender, EventArgs e)
        {
            this.ConfigFormat();
            tabAccount.Hide();

            //TreeNode nodeHome = treeView1.Nodes.Add("Home");

            // Set DoubleBuffered to true to improve DataGridView scrolling performance
            Type dgvType = gridForecast.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(gridForecast, true, null);

            List<String> accountTypes = new();
            accountTypes.Add("Checking");
            accountTypes.Add("Credit Card");
            accountTypes.Add("Investment");
            accountTypes.Add("Loan");
            accountTypes.Add("Term");
            accountTypes.Add("Shares");
            accountTypes.Add("Asset");

            List<Account> accountList = new();

            foreach (String accountType in accountTypes)
            {
                Log.Debug("Start to get AccountIdList of " + accountType);
                // Show account list
                accountList.Clear();
                accountList = db.GetAccountListByAccountType(accountType);

                TreeNode nodeAccounts = treeView1.Nodes.Add(accountType);
                foreach (Account account in accountList)
                {
                    TreeNode node = new();
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
            {
                this.ShowSummary();
            }
            else
            {
                this.ShowAccount(Convert.ToInt32(e.Node.Tag.ToString()), e.Node.Text);
            }

        }
        private void ShowAccount(int accountId, String accountName)
        {
            Account account = db.GetAccountByAccountId(accountId);
            List<CheckingAccount> transList = db.GetTransactionByAccountId(accountId);
            gridTrans.Rows.Clear();
            int i = 0;
            decimal balance = account.InitialBal;
            foreach (CheckingAccount trans in transList)
            {
                DataGridViewRow row = new();
                gridTrans.Rows.Add(row);
                int x = 0;
                gridTrans.Rows[i].Cells[x++].Value = trans.Transdate;
                gridTrans.Rows[i].Cells[x++].Value = trans.CategName + ":" + trans.SubCategName;
                gridTrans.Rows[i].Cells[x++].Value = trans.AccountName;
                gridTrans.Rows[i].Cells[x++].Value = trans.PayeeName;
                if ( (trans.TransCode == TRANSCODE_WITHDRAWAL) || //Withdrawal
                     (trans.TransCode == TRANSCODE_TRANSFER && trans.AccountId == accountId) ) //Transfer out
                {
                    gridTrans.Rows[i].Cells[x++].Value = trans.TransAmount;
                    balance -= trans.TransAmount;
                    x++;
                }
                else // Transfer in or deposit
                {
                    x++;
                    gridTrans.Rows[i].Cells[x++].Value = trans.TransAmount;
                    balance += trans.TransAmount;
                }
                gridTrans.Rows[i].Cells[x++].Value = balance;
                gridTrans.Rows[i].Cells[x++].Value = trans.Status;
                gridTrans.Rows[i].Cells[x].Value = trans.Notes;
                i++;
            }
            gridTrans.FirstDisplayedScrollingRowIndex = gridTrans.RowCount - 1;  // Move to last row

            tabControl1.SelectedTab = tabAccount;
            tabAccount.Text = accountName;
        }
        private void ShowSummary()
        {
            List<Account> accountList = db.GetAccountSummary();
            gridSummary.Rows.Clear();
            int i = 0;
            String accountType = "";

            // Get account data and generate balance
            foreach (Account account in accountList)
            {
                gridSummary.Rows.Add(new DataGridViewRow());
                int x = 0;

                if (accountType != account.AccountType) // New account type
                {
                    gridSummary.Rows[i].Cells[1].Value = account.AccountType;
                    gridSummary.Rows[i].DefaultCellStyle.Font = new Font(gridSummary.Font, FontStyle.Bold);
                    gridSummary.Rows[i].DefaultCellStyle.BackColor = config.GetAccountSummaryHeaderBackColor();
                    gridSummary.Rows[i].DefaultCellStyle.BackColor = Color.Cornsilk;
                    gridSummary.Rows.Add(new DataGridViewRow());
                    i++;
                }
                accountType = account.AccountType;
                gridSummary.Rows[i].Cells[x++].Value = account.AccountId;   // Account ID
                gridSummary.Rows[i].Cells[x++].Value = "  " + account.AccountName;
                gridSummary.Rows[i].Cells[x++].Value = account.Reconciled;  // Reconciled
                gridSummary.Rows[i].Cells[x++].Value = account.TodayBal;    // Today balance
                gridSummary.Rows[i].Cells[x].Value = account.FutureBal;   // Future balance
                i++;
                //Log.Debug(account.AccountId + "/" + account.AccountName + ":" + account.TodayBal);
            }

            // GUI Friendly
            gridSummary.ClearSelection();
            gridSummary.Height = gridSummary.Rows[0].Height * (gridSummary.Rows.Count + 1);     // Resize the grid height
            tabControl1.SelectedTab = tabHome;
        }
        private void ConfigFormat()
        {
            // TreeView
            treeView1.Font = new Font(treeView1.Font.Name, config.GetTreeAccountFontSize());
            // Grid Summary
            gridSummary.Font = new Font(treeView1.Font.Name, config.GetFontSize());
            gridSummary.Columns["ColumnReconciled"].DefaultCellStyle.Format = config.GetNumberFormat(); //Reconciled balance
            gridSummary.Columns["ColumnToday"].DefaultCellStyle.Format = config.GetNumberFormat();      //Today balance
            gridSummary.Columns["ColumnFuture"].DefaultCellStyle.Format = config.GetNumberFormat();     //Future balance
            // Grid Forecast
            gridForecast.Font = new Font(treeView1.Font.Name, config.GetFontSize());
            gridForecast.Columns["ColumnForecastReconciled"].DefaultCellStyle.Format = config.GetNumberFormat();   //Reconciled balance
            gridForecast.Columns["ColumnForecastToday"].DefaultCellStyle.Format = config.GetNumberFormat();   //Reconciled balance
            // Grid Transaction
            gridTrans.Columns["ColumnDate"].DefaultCellStyle.Format = config.GetDateFormat();
            gridTrans.Columns["ColumnExpense"].DefaultCellStyle.Format = config.GetNumberFormat();
            gridTrans.Columns["ColumnIncome"].DefaultCellStyle.Format = config.GetNumberFormat();
            gridTrans.Columns["ColumnBalance"].DefaultCellStyle.Format = config.GetNumberFormat();
            gridTrans.Font = new Font(treeView1.Font.Name, config.GetFontSize());
        }

        private void gridSummary_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 1)
            {
                gridSummary.Cursor = Cursors.Hand;
            }
        }

        private void gridSummary_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridSummary.Cursor = Cursors.Default;
        }

        private void gridSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int accountId = Convert.ToInt32(gridSummary.Rows[e.RowIndex].Cells[4].Value);
            DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)gridSummary.Rows[e.RowIndex].Cells[e.ColumnIndex];
            Log.Debug("Cell.Value=" + cell.Value + ", account id = " + accountId);

            if (e.ColumnIndex == 0)
            {
                this.ShowAccount(accountId, cell.Value.ToString());
            }
        }

        private void btnRefreshForecast_Click(object sender, EventArgs e)
        {
            List<Account> accountList = db.GetAccountSummary();
            gridForecast.Rows.Clear();
            String accountType = "";
            int period = Convert.ToInt32(textRefreshForecastPeriod.Text);

            // Generate forecast columns 
            DateTime firstDayOfMonth = new(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            int m = 1;
            for (int c = 4; c < period + 4; c++)
            {
                DataGridViewColumn col = new();
                col.Name = "ColumnForecast" + (c - 3).ToString();
                col.HeaderText = lastDayOfMonth.ToString("M/dd");
                lastDayOfMonth = firstDayOfMonth.AddMonths(++m).AddDays(-1);
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.CellTemplate = new DataGridViewTextBoxCell();
                gridForecast.Columns.Insert(c, col);
            }

            // Get account data and generate balance
            foreach (Account account in accountList)
            {
                gridForecast.Rows.Add(new DataGridViewRow());
                DataGridViewRow row = gridForecast.Rows[gridForecast.RowCount - 1];

                // New account type
                if (accountType != account.AccountType) 
                {
                    row.DefaultCellStyle.Font = new Font(gridForecast.Font, FontStyle.Bold);
                    row.DefaultCellStyle.BackColor = config.GetAccountSummaryHeaderBackColor();
                    row.DefaultCellStyle.BackColor = Color.Cornsilk;
                    row.Cells[1].Value = account.AccountType;
                    gridForecast.Rows.Add(new DataGridViewRow());
                    row = gridForecast.Rows[gridForecast.RowCount - 1];
                }
                accountType = account.AccountType;
                // Log.Debug(account.AccountId + "/" + account.AccountName + ":" + account.TodayBal);

                row.Cells["ColumnForecastAccountId"].Value = account.AccountId;               // Account ID
                row.Cells["ColumnForecastAccountName"].Value = "  " + account.AccountName;    // Account Name
                row.Cells["ColumnForecastReconciled"].Value = account.Reconciled;             // Reconciled
                row.Cells["ColumnForecastToday"].Value = account.TodayBal;                    // Today balance

                // Calculate forecast balance
                //List<BillsDeposits> billsDepositsList = db.GetBillsDepositsByAccountId(account.AccountId);
                //foreach (BillsDeposits billsDeposits in billsDepositsList)
                //{
                //}

            }

            List<BillsDeposits> billsDepositsList = db.GetBillsDepositsByAccountId(1);
            foreach (BillsDeposits billsDeposits in billsDepositsList)
            {
                Log.Debug("Repeat: account id=" + billsDeposits.AccountId + ", bdid=" + billsDeposits.BdId + ", Repeats=" + billsDeposits.Repeats + ", NextTrans=" + billsDeposits.NextOccurrenceDate + ", AutoSilent=" + billsDeposits.AutoExecuteSilent + ", AutoManual=" + billsDeposits.AutoExecuteManual);
                Log.Debug("Next trans date=" + api.GetNextTransDate(billsDeposits.Repeats, billsDeposits.TransDate, billsDeposits.NumOccurrence));
            }

            // GUI Friendly
            gridForecast.ClearSelection();
            gridForecast.Height = gridForecast.Rows[0].Height * (gridForecast.Rows.Count + 1);     // Resize the grid height
        }

    }
}
