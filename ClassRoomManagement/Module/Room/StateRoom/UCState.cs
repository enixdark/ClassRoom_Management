using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomItem.Module
{
    public partial class UCState : UCBase
    {
        public UCState()
        {
            InitializeComponent();
        }

        

        private void mainlayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UCState_Load(object sender, EventArgs e)
        {
            AddControl<UCStateGRUD>(mainlayout);
            UpdateButton(false);
            UCStateStandart.Insert = add;
            UCStateStandart.Update = update;
            UCStateStandart.Delete = del;
        }

        private void UpdateButton(bool check)
        {
            add.Visible = check;
            update.Visible = check;
            del.Visible = check;
            
        }
        
        private void v_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mainlayout.Controls.Clear();
            var index = v.SelectedIndex;
            if (v.Properties.Items[index].Description.Equals("Advance"))
            {
                UpdateButton(false);
                AddControl<UCStateGRUD>(mainlayout);
                (new CustomItem.Navigation.TransitionChild(this.mainlayout, this.mainlayout.Left - this.mainlayout.Width, this.mainlayout.Left, 500)).Start();
            }
            else
            {
                UpdateButton(true);
                var control = AddControl<UCStateStandart>(mainlayout,true);
                (new CustomItem.Navigation.TransitionChild(this.mainlayout)).Start();
                

            }
        }

        
    }
}
