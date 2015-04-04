using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoBid
{
    public partial class EndTimeFm : Form
    {
        public EndTimeFm()
        {
            InitializeComponent();

            this.Load += new EventHandler(EndTimeFm_Load);
        }

        void EndTimeFm_Load(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = DateTime.Now;
        }


    }
}
