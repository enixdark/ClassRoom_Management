using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomItem;

namespace CustomItem.Module
{
    public partial class UCRoom : UCBase
    {
        UCBaseRoom c;
        UCRoomSwitch s;
        public UCRoom()
        {
            InitializeComponent();
            
        }

       
        protected override void ONCREATE()
        {

            c = AddControl<UCBaseRoom>(mainlayout,true);
            c.Mainlayout = this.mainlayout;
            c.Radio = v; 
        }

        private void UCRoom_Load(object sender, EventArgs e)
        {
            UCOnLoad(ONCREATE);
            EnableClick(true);
        }

        private void mainlayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            Global.ActiveID = false;
            if (v.Properties.Items[v.SelectedIndex].Description.Equals("Advance"))
            {
                Global.main.GoTo<UCAddRoom>();
            }
            else
            {
                EnableClick(false);
            }
        }

        private void EnableClick(bool check)
        {
            add.Enabled = check;
            labelControl2.Enabled = check;
            save.Enabled = !check;
        }

        private void radioGroup1_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainlayout.Controls.Clear();
            var index = v.SelectedIndex;
            if (v.Properties.Items[index].Description.Equals("Advance"))
            {
                EnableClick(true);
                ONCREATE();
                (new CustomItem.Navigation.TransitionChild(this.mainlayout,this.mainlayout.Left - this.mainlayout.Width,this.mainlayout.Left,500)).Start(); 
            }
            else
            {
                
                s = AddControl<UCRoomSwitch>(mainlayout,true);
                (new CustomItem.Navigation.TransitionChild(this.mainlayout)).Start();
                
                
            }
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {
            Global.ActiveID = true;
            if (v.Properties.Items[v.SelectedIndex].Description.Equals("Advance"))
            {
                
                Global.main.GoTo<UCAddRoom>();
            }
            else
            {
                EnableClick(false);
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            refresh.img = refresh.Appearance.Image;
            refresh.X = this.refresh.Appearance.Image.Width / 2;
            refresh.Y = this.refresh.Appearance.Image.Height / 2;
            if (!v.Properties.Items[v.SelectedIndex].Description.Equals("Advance"))
            {
                EnableClick(true);
                s.RefreshClick();
            }
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

            if (v.Properties.Items[v.SelectedIndex].Description.Equals("Advance"))
            {
                c.Remove((string)Global.ID);
            }
            else
            {
                s.DeleteClick();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            s.Save();
        }

    }
}
