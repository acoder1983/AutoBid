using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoBid
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // only one instance could run
            FileInfo fi = new FileInfo(Application.ExecutablePath);
            if (System.Diagnostics.Process.GetProcessesByName(fi.Name.Substring(0, fi.Name.IndexOf("."))).Length > 1)
            {
                MessageBox.Show("Only one instance could run!");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFm());
        }
    }
}
