using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BIKEBLL;

namespace BMSYSTEM
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserLogin());
            //if (StaticData.departLocal == null)
            //{
            //    MessageBox.Show("网络不稳定，无法登陆！");
            //}
            //else
            //{
            //    Application.Run(new UserLogin());
            //}
        }
    }
}
