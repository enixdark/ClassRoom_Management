using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
namespace CustomItem
{
    
    
    public partial class Layout : DevExpress.XtraEditors.XtraUserControl, IChrome
    {
        public Layout()
        {
            InitializeComponent();

            this.back.Image = this.imageList1.Images["arrownormal.png"];
            
            this.back.MouseClick += Back_MouseClick;
            this.back.MouseHover += Back_MouseHover;
            this.back.MouseLeave += Back_MouseLeave;
        }

        

        Control _previous;
        void IChrome.Navigate(Control previous)
        {
            _previous = previous;
        }

        public override string Text
        {
            get
            {
                return this.title.Text;
            }
            set
            {
                this.title.Text = value;
            }
        }

        void Back_MouseLeave(object sender, EventArgs e)
        {
            
             this.back.Image = this.imageList1.Images["arrownormal.png"];
            
        }

        void Back_MouseHover(object sender, EventArgs e)
        {

            this.back.Image = this.imageList1.Images["arrowhover.png"];
            
        }

        void Back_MouseClick(object sender, MouseEventArgs e)
        {
            this.back.Image = this.imageList1.Images["arrowclick.png"];
            this.Parent.GoTo(_previous, null);
            this.Dispose(true);
            MemoryManagement.FlushMemory();

        }

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }

        

    }
}
