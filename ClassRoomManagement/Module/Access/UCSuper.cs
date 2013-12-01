using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomItem;
using CustomItem.Module.Report;

namespace CustomItem.Module.Access
{
    public partial class UCSuper : UserControl
    {
        public Control control{get;set;}

        public UCSuper()
        {
            InitializeComponent();
        }

        private void AddControl(CTItem item, Control c,EventArgs e)
        {
            if (!item.ACTIVITE)
            {
                refreshItem(e);
                item.ActiviteDown(e);
                this.control.Controls.Clear();
                control.Controls.Add(c);
                c.Dock = DockStyle.Fill;
            }
        }

        private void refreshItem(EventArgs e)
        {
            TimeTable.ResetMouse(e);
            phong.ResetMouse(e);
            nhom.ResetMouse(e);
            trangthai.ResetMouse(e);
            quyen.ResetMouse(e);
            thongke.ResetMouse(e);
        }
        private void Clear()
        {
            foreach (Control i in control.Controls)
            {
                foreach (Control j in i.Controls)
                    j.Dispose();
            }
        }
        private void TimeTable_Click(object sender, EventArgs e)
        {
            Clear();
            AddControl(TimeTable, new UCTimetable(), e);
        }

        private void quyen_Click(object sender, EventArgs e)
        {
            Clear();
            AddControl(quyen, new UCTimetable(), e);
        }

        private void phong_Click(object sender, EventArgs e)
        {
            Clear();
            AddControl(phong, new UCRoom(), e);
        }

        private void trangthai_Click(object sender, EventArgs e)
        {
            //AddControl(trangthai, new UCStateGRUD(), e);
            Clear();
            AddControl(trangthai, new UCState(), e);
        }

        private void thongke_Click(object sender, EventArgs e)
        {
            
            AddControl(thongke, new UCReport(), e);
        }

        private void nhom_Click(object sender, EventArgs e)
        {
            AddControl(nhom, new UCTimetable(), e);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
