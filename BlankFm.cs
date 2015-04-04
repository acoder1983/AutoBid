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
    public partial class BlankFm : Form
    {
        public BlankFm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            
            this.MouseMove += new MouseEventHandler(BlankFm_MouseMove);
            
            this.Load += new EventHandler(BlankFm_Load);
        }

        void BlankFm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        internal int PlacebidX = -1;
        internal int PlacebidY = -1;

        private void BlankFm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Cursor.Current = Cursors.Default;
                this.Close();
            }
        }

        private void BlankFm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.PlacebidX = e.X;
            this.PlacebidY = e.Y;
        }

        int begX = -1, begY;
        private void BlankFm_MouseDown(object sender, MouseEventArgs e)
        {
            begX = e.X;
            begY = e.Y;
        }

        internal Image Img;
        private void BlankFm_MouseUp(object sender, MouseEventArgs e)
        {
            int w = Math.Abs(e.X - begX);
            int h = Math.Abs(e.Y - begY);
            if (w > 0 && h > 0)
            {
                this.Img = new Bitmap(w, h);
                Graphics g = Graphics.FromImage(this.Img);
                g.CopyFromScreen(begX > e.X ? e.X : begX, begY > e.Y ? e.Y : begY, 0, 0,
                    new Size(this.Img.Width, this.Img.Height));
            }
            this.begX = -1;

            this.Invalidate();
        }

        private void BlankFm_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.begX == -1) return;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.begX != -1)
            {
                Pen p = new Pen(Color.Black);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                p.Width = 2;
                e.Graphics.DrawRectangle(p,
                begX > Cursor.Position.X ? Cursor.Position.X : begX, begY > Cursor.Position.Y ?
                Cursor.Position.Y : begY,
                Math.Abs(Cursor.Position.X - begX), Math.Abs(Cursor.Position.Y - begY));
            }
        }
    }
}
