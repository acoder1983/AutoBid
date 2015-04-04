namespace AutoBid
{
    partial class MainFm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAutoBid = new System.Windows.Forms.ToolStripButton();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnTestWebCnt3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTestWebCnt7 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTestWebCnt13 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTestWebCnt20 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbTips = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.panTop = new System.Windows.Forms.Panel();
            this.panTime = new System.Windows.Forms.Panel();
            this.panLeft = new System.Windows.Forms.Panel();
            this.ckbConfirm = new System.Windows.Forms.CheckBox();
            this.ckbSelAll = new System.Windows.Forms.CheckBox();
            this.panBottom = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain.SuspendLayout();
            this.panTop.SuspendLayout();
            this.panLeft.SuspendLayout();
            this.panBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton2,
            this.tsbAutoBid,
            this.tsbOptions,
            this.toolStripDropDownButton1,
            this.tsbTips,
            this.tsbAbout});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(518, 27);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbOpen,
            this.tsbSave,
            this.tsbSaveAs,
            this.tsbExit});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(47, 24);
            this.toolStripDropDownButton3.Text = "File";
            // 
            // tsbNew
            // 
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(130, 24);
            this.tsbNew.Text = "New";
            // 
            // tsbOpen
            // 
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(130, 24);
            this.tsbOpen.Text = "Open";
            // 
            // tsbSave
            // 
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(130, 24);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbSaveAs
            // 
            this.tsbSaveAs.Name = "tsbSaveAs";
            this.tsbSaveAs.Size = new System.Drawing.Size(130, 24);
            this.tsbSaveAs.Text = "SaveAs";
            // 
            // tsbExit
            // 
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(130, 24);
            this.tsbExit.Text = "Exit";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbDel,
            this.tsbRefresh});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(50, 24);
            this.toolStripDropDownButton2.Text = "Edit";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(133, 24);
            this.tsbAdd.Text = "Add";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(133, 24);
            this.tsbDel.Text = "Delete";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(133, 24);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbAutoBid
            // 
            this.tsbAutoBid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAutoBid.Image = ((System.Drawing.Image)(resources.GetObject("tsbAutoBid.Image")));
            this.tsbAutoBid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAutoBid.Name = "tsbAutoBid";
            this.tsbAutoBid.Size = new System.Drawing.Size(72, 24);
            this.tsbAutoBid.Text = "AutoBid";
            this.tsbAutoBid.Click += new System.EventHandler(this.tsbAutoBid_Click);
            // 
            // tsbOptions
            // 
            this.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsbOptions.Image")));
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(71, 24);
            this.tsbOptions.Text = "Options";
            this.tsbOptions.Visible = false;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTestWebCnt3,
            this.btnTestWebCnt7,
            this.btnTestWebCnt13,
            this.btnTestWebCnt20});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(53, 24);
            this.toolStripDropDownButton1.Text = "Test";
            this.toolStripDropDownButton1.Visible = false;
            // 
            // btnTestWebCnt3
            // 
            this.btnTestWebCnt3.Name = "btnTestWebCnt3";
            this.btnTestWebCnt3.Size = new System.Drawing.Size(186, 24);
            this.btnTestWebCnt3.Text = "TestWebCnt3";
            this.btnTestWebCnt3.Click += new System.EventHandler(this.btnTestWebCnt3_Click);
            // 
            // btnTestWebCnt7
            // 
            this.btnTestWebCnt7.Name = "btnTestWebCnt7";
            this.btnTestWebCnt7.Size = new System.Drawing.Size(186, 24);
            this.btnTestWebCnt7.Text = "TestWebCnt7";
            this.btnTestWebCnt7.Click += new System.EventHandler(this.btnTestWebCnt7_Click);
            // 
            // btnTestWebCnt13
            // 
            this.btnTestWebCnt13.Name = "btnTestWebCnt13";
            this.btnTestWebCnt13.Size = new System.Drawing.Size(186, 24);
            this.btnTestWebCnt13.Text = "TestWebCnt13";
            this.btnTestWebCnt13.Click += new System.EventHandler(this.btnTestWebCnt13_Click);
            // 
            // btnTestWebCnt20
            // 
            this.btnTestWebCnt20.Name = "btnTestWebCnt20";
            this.btnTestWebCnt20.Size = new System.Drawing.Size(186, 24);
            this.btnTestWebCnt20.Text = "TestWebCnt20";
            this.btnTestWebCnt20.Click += new System.EventHandler(this.btnTestWebCnt20_Click);
            // 
            // tsbTips
            // 
            this.tsbTips.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTips.Image = ((System.Drawing.Image)(resources.GetObject("tsbTips.Image")));
            this.tsbTips.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTips.Name = "tsbTips";
            this.tsbTips.Size = new System.Drawing.Size(72, 24);
            this.tsbTips.Text = "AutoTip";
            this.tsbTips.Click += new System.EventHandler(this.tsbTips_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(38, 24);
            this.tsbAbout.Text = "aha";
            this.tsbAbout.Visible = false;
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.panTime);
            this.panTop.Controls.Add(this.panLeft);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 27);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(518, 70);
            this.panTop.TabIndex = 2;
            // 
            // panTime
            // 
            this.panTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.panTime.Location = new System.Drawing.Point(358, 0);
            this.panTime.Name = "panTime";
            this.panTime.Size = new System.Drawing.Size(160, 70);
            this.panTime.TabIndex = 1;
            // 
            // panLeft
            // 
            this.panLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panLeft.Controls.Add(this.ckbConfirm);
            this.panLeft.Controls.Add(this.ckbSelAll);
            this.panLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLeft.Location = new System.Drawing.Point(0, 0);
            this.panLeft.Name = "panLeft";
            this.panLeft.Size = new System.Drawing.Size(518, 70);
            this.panLeft.TabIndex = 0;
            // 
            // ckbConfirm
            // 
            this.ckbConfirm.AutoSize = true;
            this.ckbConfirm.Checked = true;
            this.ckbConfirm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbConfirm.Location = new System.Drawing.Point(200, 25);
            this.ckbConfirm.Name = "ckbConfirm";
            this.ckbConfirm.Size = new System.Drawing.Size(101, 19);
            this.ckbConfirm.TabIndex = 1;
            this.ckbConfirm.Text = "Confirmed";
            this.ckbConfirm.UseVisualStyleBackColor = true;
            // 
            // ckbSelAll
            // 
            this.ckbSelAll.AutoSize = true;
            this.ckbSelAll.Location = new System.Drawing.Point(57, 25);
            this.ckbSelAll.Name = "ckbSelAll";
            this.ckbSelAll.Size = new System.Drawing.Size(109, 19);
            this.ckbSelAll.TabIndex = 0;
            this.ckbSelAll.Text = "Select All";
            this.ckbSelAll.UseVisualStyleBackColor = true;
            // 
            // panBottom
            // 
            this.panBottom.Controls.Add(this.dataGridView1);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBottom.Location = new System.Drawing.Point(0, 97);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(518, 251);
            this.panBottom.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(518, 251);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 326);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(518, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRestore,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(136, 52);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // tsmiRestore
            // 
            this.tsmiRestore.Name = "tsmiRestore";
            this.tsmiRestore.Size = new System.Drawing.Size(135, 24);
            this.tsmiRestore.Text = "Restore";
            this.tsmiRestore.Visible = false;
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // MainFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 348);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panBottom);
            this.Controls.Add(this.panTop);
            this.Controls.Add(this.tsMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoBid for Ebay v1.1";
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.panTop.ResumeLayout(false);
            this.panLeft.ResumeLayout(false);
            this.panLeft.PerformLayout();
            this.panBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbAutoBid;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panTime;
        private System.Windows.Forms.Panel panLeft;
        private System.Windows.Forms.CheckBox ckbConfirm;
        private System.Windows.Forms.CheckBox ckbSelAll;
        private System.Windows.Forms.ToolStripButton tsbOptions;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnTestWebCnt3;
        private System.Windows.Forms.ToolStripMenuItem btnTestWebCnt7;
        private System.Windows.Forms.ToolStripMenuItem btnTestWebCnt13;
        private System.Windows.Forms.ToolStripMenuItem btnTestWebCnt20;
        private System.Windows.Forms.ToolStripButton tsbTips;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiRestore;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem tsbAdd;
        private System.Windows.Forms.ToolStripMenuItem tsbDel;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem tsbNew;
        private System.Windows.Forms.ToolStripMenuItem tsbOpen;
        private System.Windows.Forms.ToolStripMenuItem tsbSave;
        private System.Windows.Forms.ToolStripMenuItem tsbSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsbExit;
        private System.Windows.Forms.ToolStripMenuItem tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbAbout;

    }
}

