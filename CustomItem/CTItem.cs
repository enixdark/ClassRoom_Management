using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomItem
{
    public partial class CTItem : DevExpress.XtraEditors.LabelControl
    {
        private bool activite = false;

        public bool ACTIVITE
        {
            get { return activite; }
            //set { activite = value; }
        }

        public CTItem()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        [PropertyTab("IsNumaric")]
        [Browsable(true)]
        [Description("TextBox only valid for numbers only"), Category("EmSoft")]
        public bool IsNumaricTextBox
        {
            set
            {
                this.Enabled = value;
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!activite)
            {
                SetEventMouse(Color.Transparent, Color.Black, 30);
            }
            else
            {

            }
            
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!activite)
            {
                this.BackColor = Color.DarkOrange;
                SetEventMouse(Color.DarkOrange, Color.White, 40);
            }
            //else
            //{
            //}
        }

        private void SetEventMouse(Color backcolor, Color forecolor,int pad)
        {
            this.ForeColor = forecolor;
            this.Padding = new System.Windows.Forms.Padding(pad);
            this.BackColor = backcolor;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {

            base.OnMouseDown(e);
            SetEventMouse(Color.DeepSkyBlue, Color.White, 40);
            
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!activite)
            {
                this.BackColor = Color.DarkOrange;
            }
        }

        public void ResetMouse(EventArgs e)
        {
            this.activite = false;
            this.OnMouseLeave(e);
        }

        public void ActiviteDown(EventArgs e)
        {
            this.activite = true;
            OnMouseDown((MouseEventArgs)e);
        }
    }
}
