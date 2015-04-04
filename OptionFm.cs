using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace AutoBid
{
    public partial class OptionFm : Form
    {
        public OptionFm()
        {
            InitializeComponent();
            this.Load += new EventHandler(OptionFm_Load);
            this.FormClosed += new FormClosedEventHandler(OptionFm_FormClosed);
        }

        void OptionFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ConfigurationManager.AppSettings["TimeDiffer"] = this.tbTimeDiffer.Text;
            //System.Configuration.Configuration config =
            //ConfigurationManager.OpenExeConfiguration(
            //      ConfigurationUserLevel.PerUserRoaming);
            //config.AppSettings.Settings["TimeDiffer"].LockItem = false;
            //    config.AppSettings.Settings["TimeDiffer"].Value = this.tbTimeDiffer.Text;
            //    config.Save(ConfigurationSaveMode.Modified);
            this.config.AppSettings.Settings["TimeDiffer"].Value = this.tbTimeDiffer.Text;
            this.config.Save();
            //this.config.Save(ConfigurationSaveMode.Modified);
            //this.config.Save(ConfigurationSaveMode.Modified, true);
            //ConfigurationManager.RefreshSection("appSettings");

        }

        internal Configuration config;
        void OptionFm_Load(object sender, EventArgs e)
        {
            this.tbTimeDiffer.Text = this.config.AppSettings.Settings["TimeDiffer"].Value.ToString();
        }
    }
}
