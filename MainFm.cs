using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AutoBid
{
    public partial class MainFm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll", EntryPoint = "mouse_event")]
        public static extern void mouse_event(
             int dwFlags,
             int dx,
             int dy,
             int cButtons,
             int dwExtraInfo
             );

        public const int MOUSEEVENTF_LEFTDOWN = 0x2;
        public const int MOUSEEVENTF_LEFTUP = 0x4;

        public MainFm()
        {
            InitializeComponent();

            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            WebBrowser wb = new WebBrowser();
            this.panTime.Controls.Add(wb);
            wb.Dock = DockStyle.Fill;
            wb.Url = new Uri("http://chabudai.sakura.ne.jp/blogparts/honehoneclock/honehone_clock_tr.swf");

            this.Width = 750;
            this.Height = 600;

            this.checkSelAllHandler = new EventHandler(this.ckbSelAll_CheckedChanged);
            this.ckbSelAll.CheckedChanged += this.checkSelAllHandler;

            bool b = false;
            this.dt.Columns.Add(new DataColumn("Selected", b.GetType()));
            Image i = new Bitmap(1, 1);
            this.dt.Columns.Add(new DataColumn("Caption", i.GetType()));
            double d = 0.0;
            this.dt.Columns.Add(new DataColumn("MaxBid", d.GetType()));
            this.dt.Columns.Add(new DataColumn("PlaceBidPos"));
            this.dt.Columns.Add(new DataColumn("PlaceBidPosX"));
            this.dt.Columns.Add(new DataColumn("PlaceBidPosY"));

            this.dt.Columns.Add(new DataColumn("EndTime"));
            this.dt.Columns.Add(new DataColumn("TimeLeft"));
            this.dt.TableName = "Bids";
            this.dv.Table = this.dt;
            this.dv.Sort = "EndTime";
            this.dataGridView1.DataSource = this.dv;

            this.dataGridView1.Columns["Selected"].HeaderText = string.Empty;
            this.dataGridView1.Columns["Selected"].Width = 50;
            this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);

            this.dataGridView1.Columns["Caption"].Width = 200;
            
            this.dataGridView1.Columns["PlaceBidPos"].HeaderText = "Placebid Position";
            this.dataGridView1.Columns["PlaceBidPos"].ReadOnly = true;
            this.dataGridView1.Columns["PlaceBidPosX"].Visible = false;
            this.dataGridView1.Columns["PlaceBidPosY"].Visible = false;
            
            this.dataGridView1.Columns["EndTime"].ReadOnly = true;

            this.dataGridView1.Columns["TimeLeft"].ReadOnly = true;

            this.dataGridView1.RowTemplate.Height = 150;

            // add row index
            this.dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView1_RowPostPaint);

            this.tsbOptions.Click += new EventHandler(tsbOptions_Click);

            timerRefresh.Interval = Convert.ToInt32(this.config.AppSettings.Settings["RefreshInterval"].Value);
            timerRefresh.Tick += new EventHandler(timerRefresh_Tick);

            this.timerCalcTimeLeft.Interval = 1000;
            this.timerCalcTimeLeft.Tick += new EventHandler(timerCalcTimeLeft_Tick);
            
            this.timerBid.Tick += new EventHandler(timerBid_Tick);

            this.Load += new EventHandler(MainFm_Load);

            this.FormClosing += new FormClosingEventHandler(MainFm_FormClosing);

            this.timerLogo.Interval = 1000;
            this.timerLogo.Tick += new EventHandler(timerLogo_Tick);
            this.logoIcons = new Icon[]{Properties.Resources.logo1, Properties.Resources.logo2,
                Properties.Resources.logo3, Properties.Resources.logo4};
        }

        Icon[] logoIcons;
        int curLogoIdx;
        void timerLogo_Tick(object sender, EventArgs e)
        {
            // when auto bidding or tipping is running    
            // every interval the notifyicon loads a new one
            if (this.curLogoIdx == this.logoIcons.Length)
                this.curLogoIdx = 0;
            this.notifyIcon.Icon = this.logoIcons[this.curLogoIdx];
            this.curLogoIdx++;
        }

        bool needClose = false;
        void MainFm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !needClose;
            if (!needClose)
                this.Visible = needClose;
        }

        internal Configuration config;
        void MainFm_Load(object sender, EventArgs e)
        {
            
        }

        void tsbOptions_Click(object sender, EventArgs e)
        {
            OptionFm fm = new OptionFm();
            fm.config = this.config;
            fm.ShowDialog();
        }

        void timerBid_Tick(object sender, EventArgs e)
        {
            this.timerRefresh.Stop();
            this.timerBid.Stop();

            System.Threading.Thread.Sleep(6000);
            // find bid button
            Point bidPos = new Point(
                Convert.ToInt16(this.dv[curBidIndex]["PlacebidPosX"]), 
                Convert.ToInt16(this.dv[curBidIndex]["PlacebidPosY"]));
            
            // calc money input pos
            int money_x = bidPos.X - Convert.ToInt16(this.config.AppSettings.Settings["MoneyInputDistance"].Value);
            int money_y = bidPos.Y ;
            
            SetCursorPos(money_x, money_y);

            //System.Threading.Thread.Sleep(2000);
            // gen left click
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            //System.Threading.Thread.Sleep(2000);
            // gen money key events
            SendKeys.Send(this.dv[curBidIndex]["MaxBid"].ToString());
                
            //System.Threading.Thread.Sleep(2000);
            // click the "bid" btn
            SetCursorPos(bidPos.X, bidPos.Y);
            //System.Threading.Thread.Sleep(1000);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            // wait for the confirm diag
            //Cursor.Current = Cursors.WaitCursor;
            System.Threading.Thread.Sleep(5000);
            //Cursor.Current = Cursors.Default;
            // click the "confirm" btn
            Point conPos = new Point(
                Convert.ToInt16(this.config.AppSettings.Settings["ConfirmPosX"].Value), 
                Convert.ToInt16(this.config.AppSettings.Settings["ConfirmPosY"].Value));
            
            SetCursorPos(conPos.X, conPos.Y);
            if (this.ckbConfirm.Checked)
            {
                //System.Threading.Thread.Sleep(3000);
                // gen left click
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }
            System.Threading.Thread.Sleep(2000);

            // bid on next item
            
            if (this.dv.Count == ++curBidIndex)
            {
                this.StopBidding();
                return;
            }

            this.SwitchToNext();

            this.timerBid.Interval = (int)Convert.ToDateTime(
                this.dv[curBidIndex]["EndTime"]).Subtract(DateTime.Now).TotalMilliseconds - 
                this.GetWaitSeconds()*1000;
            this.timerBid.Start();
            this.timerRefresh.Start();
        }

        DataTable dt = new DataTable();
        DataView dv = new DataView();

        void timerRefresh_Tick(object sender, EventArgs e)
        {
            // refresh the cur page every interval
            SendKeys.Send("{F5}");
        }

        EventHandler checkSelAllHandler;

        void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
                e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dataGridView1.RowHeadersWidth - 4,
                e.RowBounds.Height
            );

            TextRenderer.DrawText(this.dataGridView1.CreateGraphics(),
                (e.RowIndex + 1).ToString(),
                dataGridView1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right); 
        }

        void timerCalcTimeLeft_Tick(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataRowView dr in this.dv)
            {
                if (!DBNull.Value.Equals(dr["EndTime"]))
                {
                    DateTime dt = Convert.ToDateTime(dr["EndTime"]);
                    TimeSpan ts = dt.Subtract(DateTime.Now);
                    dr["TimeLeft"] = string.Format("{0}:{1}:{2}", ts.Hours, ts.Minutes, ts.Seconds);
                    this.dataGridView1.UpdateCellValue(this.dataGridView1.Columns["TimeLeft"].Index, i);
                }
                ++i;
            }
            
        }

        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex >= this.dv.Table.Columns.Count ||
                e.RowIndex < 0 || e.RowIndex >= this.dv.Count) return;
            
            if (e.ColumnIndex == this.dv.Table.Columns["Selected"].Ordinal)
            {
                bool b = true;
                int ySum = 0;
                foreach (DataRowView dr in this.dv)
                {
                    if (b.Equals(dr["Selected"]))
                    {
                        ++ySum;
                    }
                }

                this.ckbSelAll.CheckedChanged -= this.checkSelAllHandler;
                if (ySum == 0)
                {
                    this.ckbSelAll.CheckState = CheckState.Unchecked;
                }
                else if (ySum == this.dv.Count)
                {
                    this.ckbSelAll.CheckState = CheckState.Checked;
                }
                else
                {
                    this.ckbSelAll.CheckState = CheckState.Indeterminate;
                }
                this.ckbSelAll.CheckedChanged += this.checkSelAllHandler;
            }
        }

        void tsbDel_Click(object sender, EventArgs e)
        {
            if (this.currentState != RunningState.Editting) return;
            System.Collections.ObjectModel.Collection<DataRow> delRows = 
                new System.Collections.ObjectModel.Collection<DataRow>();
            foreach (DataRowView dr in this.dv)
            {
                if (Convert.ToBoolean(dr["Selected"]))
                    delRows.Add(dr.Row);
            }
            foreach (DataRow dr in delRows)
            {
                dr.Delete();
            }
            if (this.dv.Count == 0)
            {
                this.ckbSelAll.Checked = false;
            }
        }

        void tsbAdd_Click(object sender, EventArgs e)
        {
            if (this.currentState != RunningState.Editting) return;
            DataRow dr = this.dt.NewRow();
            dr["Selected"] = false;
            dr["EndTime"] = DateTime.MaxValue;
                //new DateTime(
                //DateTime.Now.Year,
                //DateTime.Now.Month,
                //DateTime.Now.Day,
                //23, 59, 59);
            this.dt.Rows.Add(dr);
        }

        Point FindButton(Bitmap btnImg)
        {
            Cursor.Current = Cursors.WaitCursor;
            Point btnPos = new Point(-1,-1);
            int bmp_width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            int bmp_height = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height);
            Bitmap bmp = new Bitmap(bmp_width, bmp_height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(0, 0, 0, 0,
                new System.Drawing.Size(bmp_width, bmp_height));

            int x = 0, y = 0;
            int btnWidth = btnImg.Width, btnHeight = btnImg.Height;
            for (int i = bmp_width - 1; i > btnWidth; --i)
            {
                for (int j = bmp_height - 1; j > btnHeight; --j)
                {
                    if (bmp.GetPixel(i, j).R == btnImg.GetPixel(btnWidth - 1, btnHeight - 1).R &&
                        bmp.GetPixel(i, j).G == btnImg.GetPixel(btnWidth - 1, btnHeight - 1).G &&
                        bmp.GetPixel(i, j).B == btnImg.GetPixel(btnWidth - 1, btnHeight - 1).B &&
                        bmp.GetPixel(i - btnWidth + 1, j - btnHeight + 1).R == btnImg.GetPixel(0, 0).R &&
                        bmp.GetPixel(i - btnWidth + 1, j - btnHeight + 1).G == btnImg.GetPixel(0, 0).G &&
                        bmp.GetPixel(i - btnWidth + 1, j - btnHeight + 1).B == btnImg.GetPixel(0, 0).B
                        )
                    {
                        x = i;
                        y = j;
                        break;
                    }
                }
                if (y != 0)
                {
                    btnPos.X = x - btnWidth / 2;
                    btnPos.Y = y - btnHeight / 2;
                    break;
                }
            }

            Cursor.Current = Cursors.Default;
            return btnPos;
        }

        void StopBidding()
        {
            this.timerRefresh.Stop();
            this.timerBid.Stop();
            this.timerCalcTimeLeft.Stop();

            this.timerLogo.Stop();
            this.curLogoIdx = 0;
            this.notifyIcon.Icon = Properties.Resources.logo;

            this.currentState = RunningState.Editting;
            this.curBidIndex = 0;

            this.dataGridView1.Enabled = true;

            tsbAutoBid.Text = "AutoBid";
            
        }

        private void tsbAutoBid_Click(object sender, EventArgs e)
        {
            if (this.dv.Count == 0) return;

            if (this.currentState == RunningState.Bidding)
            {
                this.StopBidding();
                return;
            }
            if (this.currentState == RunningState.Tipping)
            {
                DialogResult dr = MessageBox.Show("Stop tipping now?", "?", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    this.StopTipping();
                }
                else
                {
                    return;
                }
            }
            // validate
            int i = 0;
            foreach (DataRowView dr in this.dv)
            {
                if (DBNull.Value.Equals(dr["MaxBid"]) ||
                    DBNull.Value.Equals(dr["PlacebidPosX"]) ||
                    DBNull.Value.Equals(dr["PlacebidPosY"]) ||
                    DBNull.Value.Equals(dr["EndTime"]))
                {
                    MessageBox.Show(string.Format("Bid{0} has incomplete info", i+1));
                    return;
                }
                if (i > 0)
                {
                    // compare the two bids, if the two end times less than op time
                    DateTime t2 = Convert.ToDateTime(this.dv[i]["EndTime"]);
                    DateTime t1 = Convert.ToDateTime(this.dv[i - 1]["EndTime"]);
                    TimeSpan ts = t2.Subtract(t1);
                    if (ts.TotalSeconds <= this.GetWaitSeconds())
                    {
                        MessageBox.Show(string.Format("Bid{0}'s EndTime is too close to the previous", i + 1));
                        return;
                    }
                }
                ++i;
            }

            this.timerBid.Interval = (int) Convert.ToDateTime(
                this.dv[0]["EndTime"]).Subtract(DateTime.Now).TotalMilliseconds - 
                this.GetWaitSeconds()*1000;
            this.timerBid.Start();
            this.timerRefresh.Start();
            this.timerCalcTimeLeft.Start();
            this.timerLogo.Start();

            this.dataGridView1.Enabled = false;
            this.tsbAutoBid.Text = "Bidding";
            this.Visible = false;
            this.currentState = RunningState.Bidding;
        }

        int GetWaitSeconds()
        {
            return Convert.ToInt16(this.config.AppSettings.Settings["BidOpTime"].Value);
        }

        private void tsbConfirmed_Click(object sender, EventArgs e)
        {
            //this.tsbConfirmed.Text = this.tsbConfirmed.Text == "Confirm" ? "Not Confirm" : "Confirm";
        }

        Timer timerRefresh = new Timer();
        Timer timerCalcTimeLeft = new Timer();
        Timer timerBid = new Timer();
        int curBidIndex = 0;

        internal void SwitchToNext()
        {
            int webTabPosY = Convert.ToInt16(this.config.AppSettings.Settings["WebTabPosY"].Value);
            int maxFixedTabCnt = Convert.ToInt16(this.config.AppSettings.Settings["MaxFixedTabCount"].Value);
            int webTabBegGap = Convert.ToInt16(this.config.AppSettings.Settings["WebTabBegGap"].Value);
            int webTabEndGap = Convert.ToInt16(this.config.AppSettings.Settings["WebTabEndGap"].Value);
            int webTabOverlappedWidth = Convert.ToInt16(this.config.AppSettings.Settings["WebTabOverlappedWidth"].Value);
            
            // switch to next page
            int webTabWidth;
            if (this.dv.Count > maxFixedTabCnt)
            {
                webTabWidth = (SystemInformation.PrimaryMonitorSize.Width - 
                    webTabBegGap - webTabEndGap - webTabOverlappedWidth) / 
                    this.dv.Count;
            }   
            else
            {
                webTabWidth = Convert.ToInt16(this.config.AppSettings.Settings["WebTabWidth"].Value) -
                    webTabOverlappedWidth;
            }
            SetCursorPos(webTabBegGap + webTabOverlappedWidth/2 + 
                webTabWidth / 2 + curBidIndex * webTabWidth, webTabPosY);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dt.Columns["Caption"].Ordinal ||
                e.ColumnIndex == this.dt.Columns["PlaceBidPos"].Ordinal)
            {
                this.WindowState = FormWindowState.Minimized;
                System.Threading.Thread.Sleep(500);
                BlankFm bfm = new BlankFm();
                bfm.BackgroundImage = new Bitmap(SystemInformation.PrimaryMonitorSize.Width,
                SystemInformation.PrimaryMonitorSize.Height);
                Graphics g = Graphics.FromImage(bfm.BackgroundImage);
                g.CopyFromScreen(0, 0, 0, 0, bfm.BackgroundImage.Size);
                bfm.ShowDialog();
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                if (bfm.PlacebidX != -1 && bfm.PlacebidY != -1)
                {
                    this.dv[e.RowIndex]["PlaceBidPosX"] = bfm.PlacebidX;
                    this.dv[e.RowIndex]["PlaceBidPosY"] = bfm.PlacebidY;
                    this.dv[e.RowIndex]["PlaceBidPos"] = string.Format("X:{0} Y:{1}", bfm.PlacebidX, bfm.PlacebidY);

                }
                if (bfm.Img != null)
                {
                    this.dv[e.RowIndex]["Caption"] = bfm.Img;
                }
            }
            else if (e.ColumnIndex == this.dt.Columns["EndTime"].Ordinal)
            {
                this.WindowState = FormWindowState.Minimized;
                EndTimeFm fm = new EndTimeFm();
                fm.TopMost = true;
                fm.ShowDialog();
                this.dv[e.RowIndex]["EndTime"] = fm.dateTimePicker1.Value.AddHours(
                    Convert.ToDouble(ConfigurationManager.AppSettings["TimeDiffer"]));
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.timerCalcTimeLeft_Tick(null, null);
                // refresh the sort state
                // move to the near cell to cause resort
                /*
                if(this.dv.Count>1)
                {
                    int nearRow;
                    if (e.RowIndex == this.dv.Count - 1)
                    {
                        nearRow = e.RowIndex - 1;
                    }
                    else
                    {
                        nearRow = e.RowIndex + 1;
                    }
                    this.dataGridView1.Rows[nearRow].Cells[e.ColumnIndex].Selected = true;
                }
                 */
            }
        }

        private void ckbSelAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in this.dt.Rows)
            {
                dr["Selected"] = this.ckbSelAll.Checked;
            }
        }

        private void btnTestWebCnt3_Click(object sender, EventArgs e)
        {
            WebTabSwtichTest(3);
        }

        private void WebTabSwtichTest(int cnt)
        {
            this.dt.Clear();
            for (int i = 0; i < cnt; ++i)
            {
                DataRow dr = this.dt.NewRow();
                dr["MaxBid"] = 2;
                dr["PlacebidPosX"] = 800;
                dr["PlacebidPosY"] = 600;
                dr["EndTime"] = DateTime.Now.AddSeconds((i + 1) * 20);
                this.dt.Rows.Add(dr);
            }
            this.dv.Table = this.dt;
            this.tsbAutoBid_Click(null, null);
        }

        private void btnTestWebCnt7_Click(object sender, EventArgs e)
        {
            this.WebTabSwtichTest(7);
        }

        private void btnTestWebCnt13_Click(object sender, EventArgs e)
        {
            this.WebTabSwtichTest(13);
        }

        private void btnTestWebCnt20_Click(object sender, EventArgs e)
        {
            this.WebTabSwtichTest(20);
        }

        Timer timerTip = new Timer();
        // tip 5 min before a bid ends
        private void tsbTips_Click(object sender, EventArgs e)
        {
            if (this.dv.Count == 0) return;

            // if the autobid is running, ask if close it
            if (this.currentState == RunningState.Tipping)
            {
                this.StopTipping();
                return;
            }
            
            if (this.currentState == RunningState.Bidding)
            {
                DialogResult dr = MessageBox.Show("Stop bidding now?", "?", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    this.StopBidding();
                }
                else
                {
                    return;
                }
            }

            // validate
            int i = 0;
            foreach (DataRowView dr in this.dv)
            {
                if (DBNull.Value.Equals(dr["EndTime"]))
                {
                    MessageBox.Show(string.Format("Bid{0} needs EndTime", i + 1));
                    return;
                }
                if (i > 0)
                {
                    // compare the two bids, if the two end times less than op time
                    DateTime t2 = Convert.ToDateTime(this.dv[i]["EndTime"]);
                    DateTime t1 = Convert.ToDateTime(this.dv[i - 1]["EndTime"]);
                    TimeSpan ts = t2.Subtract(t1);
                    if (ts.TotalMinutes < 0.0)
                    {
                        MessageBox.Show(string.Format("Bid{0}'s EndTime is later than the next", i));
                        return;
                    }
                }
                ++i;
            }

            this.timerTip.Interval = 60 * 1000;
            this.timerTip.Tick += new EventHandler(timerTip_Tick);
            this.timerTip.Start();
            this.timerLogo.Start();

            this.tsbTips.Text = "Tipping";
            this.dataGridView1.Enabled = false;
            this.Visible = false;
            this.currentState = RunningState.Tipping;
        }

        int GetTipTime()
        {
            return Convert.ToInt16(this.config.AppSettings.Settings["TipTime"].Value);
        }

        void timerTip_Tick(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataRowView dr in this.dv)
            {
                DateTime dt = Convert.ToDateTime(dr["EndTime"]);
                TimeSpan ts = dt.Subtract(DateTime.Now);
                if ((int)ts.TotalMinutes == this.GetTipTime())
                {
                    this.notifyIcon.ShowBalloonTip(10000, "", "Bids are about to end!", ToolTipIcon.Info);
                    return;
                }
                ++i;
                if (i == this.dv.Count && ts.TotalMinutes < 0.0)
                {
                    this.StopTipping();
                    return;
                }
            }
        }

        void StopTipping()
        {
            this.timerTip.Stop();
            this.tsbTips.Text = "AutoTip";
            this.dataGridView1.Enabled = true;
            this.currentState = RunningState.Editting;

            this.timerLogo.Stop();
            this.curLogoIdx = 0;
            this.notifyIcon.Icon = Properties.Resources.logo;

        }

        enum RunningState
        {
            Editting,
            Bidding,
            Tipping
        }

        RunningState currentState = RunningState.Editting;

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Restore")
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
            else if (e.ClickedItem.Text == "Exit")
            {
                this.needClose = true;
                this.Close();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //if (this.WindowState == FormWindowState.Minimized)
            //{
            //    this.Visible = false;
            //}
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.needClose = true;
            this.Close();
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip1_ItemClicked(null, 
                new ToolStripItemClickedEventArgs(tsmiRestore));
        }

        // timer for set logo animation
        Timer timerLogo = new Timer();

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            this.timerCalcTimeLeft_Tick(null, null);
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("acodersop's work\r\nacodersop@gmail.com", "aha");
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {

        }
    }
}
