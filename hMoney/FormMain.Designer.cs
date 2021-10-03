
namespace hMoney
{
    partial class FormMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.gridSummary = new System.Windows.Forms.DataGridView();
            this.tabAccount = new System.Windows.Forms.TabPage();
            this.gridTrans = new System.Windows.Forms.DataGridView();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPayee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIncome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabFuture = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefreshFuture = new System.Windows.Forms.Button();
            this.gridFuture = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traditionalChineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ColumnAccountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReconciled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnToday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFuture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFutureReconciled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).BeginInit();
            this.tabAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrans)).BeginInit();
            this.tabFuture.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFuture)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            // 
            // treeView1
            // 
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.Name = "treeView1";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes")))});
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabHome);
            this.tabControl1.Controls.Add(this.tabAccount);
            this.tabControl1.Controls.Add(this.tabFuture);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabHome
            // 
            resources.ApplyResources(this.tabHome, "tabHome");
            this.tabHome.Controls.Add(this.gridSummary);
            this.tabHome.Name = "tabHome";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // gridSummary
            // 
            this.gridSummary.AllowUserToAddRows = false;
            this.gridSummary.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.NullValue = null;
            this.gridSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAccountId,
            this.ColumnAccountName,
            this.ColumnReconciled,
            this.ColumnToday,
            this.ColumnFuture});
            resources.ApplyResources(this.gridSummary, "gridSummary");
            this.gridSummary.MultiSelect = false;
            this.gridSummary.Name = "gridSummary";
            this.gridSummary.ReadOnly = true;
            this.gridSummary.RowHeadersVisible = false;
            this.gridSummary.RowTemplate.Height = 24;
            this.gridSummary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSummary_CellClick);
            this.gridSummary.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSummary_CellMouseEnter);
            this.gridSummary.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSummary_CellMouseLeave);
            // 
            // tabAccount
            // 
            this.tabAccount.Controls.Add(this.gridTrans);
            resources.ApplyResources(this.tabAccount, "tabAccount");
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.UseVisualStyleBackColor = true;
            // 
            // gridTrans
            // 
            this.gridTrans.AllowUserToAddRows = false;
            this.gridTrans.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTrans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTrans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDate,
            this.ColumnCategory,
            this.ColumnAccount,
            this.ColumnPayee,
            this.ColumnExpense,
            this.ColumnIncome,
            this.ColumnBalance,
            this.ColumnStatus,
            this.ColumnNotes});
            resources.ApplyResources(this.gridTrans, "gridTrans");
            this.gridTrans.Name = "gridTrans";
            this.gridTrans.ReadOnly = true;
            this.gridTrans.RowTemplate.Height = 24;
            // 
            // ColumnDate
            // 
            dataGridViewCellStyle7.NullValue = null;
            this.ColumnDate.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.ColumnDate, "ColumnDate");
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            // 
            // ColumnCategory
            // 
            resources.ApplyResources(this.ColumnCategory, "ColumnCategory");
            this.ColumnCategory.Name = "ColumnCategory";
            this.ColumnCategory.ReadOnly = true;
            // 
            // ColumnAccount
            // 
            resources.ApplyResources(this.ColumnAccount, "ColumnAccount");
            this.ColumnAccount.Name = "ColumnAccount";
            this.ColumnAccount.ReadOnly = true;
            // 
            // ColumnPayee
            // 
            resources.ApplyResources(this.ColumnPayee, "ColumnPayee");
            this.ColumnPayee.Name = "ColumnPayee";
            this.ColumnPayee.ReadOnly = true;
            // 
            // ColumnExpense
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnExpense.DefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(this.ColumnExpense, "ColumnExpense");
            this.ColumnExpense.Name = "ColumnExpense";
            this.ColumnExpense.ReadOnly = true;
            // 
            // ColumnIncome
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnIncome.DefaultCellStyle = dataGridViewCellStyle9;
            resources.ApplyResources(this.ColumnIncome, "ColumnIncome");
            this.ColumnIncome.Name = "ColumnIncome";
            this.ColumnIncome.ReadOnly = true;
            // 
            // ColumnBalance
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnBalance.DefaultCellStyle = dataGridViewCellStyle10;
            resources.ApplyResources(this.ColumnBalance, "ColumnBalance");
            this.ColumnBalance.Name = "ColumnBalance";
            this.ColumnBalance.ReadOnly = true;
            // 
            // ColumnStatus
            // 
            resources.ApplyResources(this.ColumnStatus, "ColumnStatus");
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            // 
            // ColumnNotes
            // 
            resources.ApplyResources(this.ColumnNotes, "ColumnNotes");
            this.ColumnNotes.Name = "ColumnNotes";
            this.ColumnNotes.ReadOnly = true;
            // 
            // tabFuture
            // 
            resources.ApplyResources(this.tabFuture, "tabFuture");
            this.tabFuture.Controls.Add(this.panel1);
            this.tabFuture.Controls.Add(this.gridFuture);
            this.tabFuture.Name = "tabFuture";
            this.tabFuture.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnRefreshFuture);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnRefreshFuture
            // 
            resources.ApplyResources(this.btnRefreshFuture, "btnRefreshFuture");
            this.btnRefreshFuture.Name = "btnRefreshFuture";
            this.btnRefreshFuture.UseVisualStyleBackColor = true;
            this.btnRefreshFuture.Click += new System.EventHandler(this.btnRefreshFuture_Click);
            // 
            // gridFuture
            // 
            this.gridFuture.AllowUserToAddRows = false;
            this.gridFuture.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.NullValue = null;
            this.gridFuture.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.gridFuture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFuture.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gridFuture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFuture.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn1,
            this.ColumnFutureReconciled});
            resources.ApplyResources(this.gridFuture, "gridFuture");
            this.gridFuture.MultiSelect = false;
            this.gridFuture.Name = "gridFuture";
            this.gridFuture.ReadOnly = true;
            this.gridFuture.RowHeadersVisible = false;
            this.gridFuture.RowTemplate.Height = 24;
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.ToolStripMenuItem,
            this.qqToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            resources.ApplyResources(this.openFileToolStripMenuItem, "openFileToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.languagesToolStripMenuItem});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            resources.ApplyResources(this.ToolStripMenuItem, "ToolStripMenuItem");
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.traditionalChineseToolStripMenuItem});
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            resources.ApplyResources(this.languagesToolStripMenuItem, "languagesToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            // 
            // traditionalChineseToolStripMenuItem
            // 
            this.traditionalChineseToolStripMenuItem.Name = "traditionalChineseToolStripMenuItem";
            resources.ApplyResources(this.traditionalChineseToolStripMenuItem, "traditionalChineseToolStripMenuItem");
            // 
            // qqToolStripMenuItem
            // 
            this.qqToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.cCToolStripMenuItem});
            this.qqToolStripMenuItem.Name = "qqToolStripMenuItem";
            resources.ApplyResources(this.qqToolStripMenuItem, "qqToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            // 
            // cCToolStripMenuItem
            // 
            this.cCToolStripMenuItem.Name = "cCToolStripMenuItem";
            resources.ApplyResources(this.cCToolStripMenuItem, "cCToolStripMenuItem");
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ColumnAccountId
            // 
            resources.ApplyResources(this.ColumnAccountId, "ColumnAccountId");
            this.ColumnAccountId.Name = "ColumnAccountId";
            this.ColumnAccountId.ReadOnly = true;
            // 
            // ColumnAccountName
            // 
            this.ColumnAccountName.FillWeight = 183.4862F;
            resources.ApplyResources(this.ColumnAccountName, "ColumnAccountName");
            this.ColumnAccountName.Name = "ColumnAccountName";
            this.ColumnAccountName.ReadOnly = true;
            // 
            // ColumnReconciled
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = null;
            this.ColumnReconciled.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnReconciled.FillWeight = 61.96669F;
            resources.ApplyResources(this.ColumnReconciled, "ColumnReconciled");
            this.ColumnReconciled.Name = "ColumnReconciled";
            this.ColumnReconciled.ReadOnly = true;
            // 
            // ColumnToday
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.NullValue = null;
            this.ColumnToday.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnToday.FillWeight = 72.83604F;
            resources.ApplyResources(this.ColumnToday, "ColumnToday");
            this.ColumnToday.Name = "ColumnToday";
            this.ColumnToday.ReadOnly = true;
            // 
            // ColumnFuture
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.NullValue = null;
            this.ColumnFuture.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnFuture.FillWeight = 81.71102F;
            resources.ApplyResources(this.ColumnFuture, "ColumnFuture");
            this.ColumnFuture.Name = "ColumnFuture";
            this.ColumnFuture.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 183.4862F;
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // ColumnFutureReconciled
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.NullValue = null;
            this.ColumnFutureReconciled.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColumnFutureReconciled.FillWeight = 61.96669F;
            resources.ApplyResources(this.ColumnFutureReconciled, "ColumnFutureReconciled");
            this.ColumnFutureReconciled.Name = "ColumnFutureReconciled";
            this.ColumnFutureReconciled.ReadOnly = true;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.Initial);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).EndInit();
            this.tabAccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTrans)).EndInit();
            this.tabFuture.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFuture)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traditionalChineseToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.DataGridView gridSummary;
        private System.Windows.Forms.TabPage tabAccount;
        private System.Windows.Forms.DataGridView gridTrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPayee;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpense;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIncome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNotes;
        private System.Windows.Forms.TabPage tabFuture;
        private System.Windows.Forms.DataGridView gridFuture;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefreshFuture;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReconciled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnToday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFuture;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFutureReconciled;
    }
}

