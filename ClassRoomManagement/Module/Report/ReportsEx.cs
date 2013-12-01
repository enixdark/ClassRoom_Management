using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CustomItem.Module.Report
{
    public partial class ReportsEx : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportsEx()
        {
            InitializeComponent();
        }
        public ReportsEx(string tablename)
        {
            InitializeComponent();
            this.tablename.Text = tablename;
        }

    }
}
