using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIKEBLL;
using MODEL;

namespace BMSYSTEM
{
    public partial class ChooseLogInfoWindow : Form
    {
        DepartInfo departInfo  = StaticData.departLocal;
        LogBLL logBLL;
        public ChooseLogInfoWindow()
        {
            InitializeComponent();
            logBLL = new LogBLL();
        }


        private void ChooseLogInfoWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
