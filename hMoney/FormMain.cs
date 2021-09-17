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

        private void initial(object sender, EventArgs e)
        {
            DB db = new DB();
            var accountList = new SortedSet<string>();
            accountList = db.getAccountList();

            TreeNode nodeHome = treeView1.Nodes.Add("Home");
            TreeNode nodeAccounts = treeView1.Nodes.Add("Accounts");
            foreach (string account in accountList)
            {
                nodeAccounts.Nodes.Add(account);
            }
            nodeAccounts.ExpandAll();
        }

    }
}
