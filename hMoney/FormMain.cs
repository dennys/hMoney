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
        Configuration config;

        public FormMain()
        {
            config = new Configuration();
            config.Init();
            // Setup i18n
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(config.GetLanguage());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(config.GetLanguage());
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

        private void initial(object sender, EventArgs e)
        {
            DB db = new DB();

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
            DB db = new DB();

            // Show account list
            var transList = new List<CheckingAccount>();
            transList = db.getTransactionByAccountId(Convert.ToInt32(e.Node.Tag));
            dataGridView1.Rows.Clear();
            int i = 0;
            foreach (CheckingAccount trans in transList)
            {
                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Rows.Add(row);
                int x = 0;
                dataGridView1.Rows[i].Cells[x++].Value = trans.Transdate;
                dataGridView1.Rows[i].Cells[x++].Value = trans.Category + ":" + trans.SubCategory;
                dataGridView1.Rows[i].Cells[x++].Value = trans.AccountName;
                dataGridView1.Rows[i].Cells[x++].Value = trans.PayeeName;
                if (trans.TransCode == "Deposit") {
                    dataGridView1.Rows[i].Cells[x++].Value = trans.TransAmount;
                    x++;
                } else {
                    x++;
                    dataGridView1.Rows[i].Cells[x++].Value = trans.TransAmount;
                }
                dataGridView1.Rows[i].Cells[x++].Value = trans.Notes;
                i++;
            }
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;  // Move to last row
        }
    }
}
