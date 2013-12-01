using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CustomItem.Module;
using CustomItem.Module.Access;
using CustomItem.Module.Form;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace CustomItem.Form
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {

        public Main()
        {
            InitializeComponent();
            //var c = new UCMetro();

            //this.Controls.Add(c); 
            //c.Dock = DockStyle.Fill;
            Global.main = this;
        }
        private void refreshItem(EventArgs e)
        {
            //ctItem1.ResetMouse(e);
            //ctItem2.ResetMouse(e);
            
        }
        private void Main_Load(object sender, EventArgs e)
        {
            UCSupers s = new UCSupers();
            panelControl2.Controls.Add(s);
            s.Dock = DockStyle.Fill;
            s.control = panelControl3;
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucBase1_Load(object sender, EventArgs e)
        {

        }

        

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        

        
    }
}