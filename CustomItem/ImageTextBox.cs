

namespace CustomItem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class ImageTextBox : DevExpress.XtraEditors.TextEdit
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private PictureBox _picture;

        public PictureBox Picture
        {
            get { return _picture; }
        } 

        public ImageTextBox()
        {
            InitializeComponent();
            _picture = new PictureBox { Cursor = Cursors.Default };

            _picture.SizeChanged += (o, e) => OnResize(e);
            this.Controls.Add(_picture); 
        }

        protected override void OnResize(EventArgs e)
        {

            _picture.Size = new Size(this.ClientSize.Height - 4, this.ClientSize.Height - 4);
            _picture.Location = new Point(this.Width - _picture.Image.Width,2);
            _picture.BringToFront();
            SendMessage(this.Handle, 0xd3, (IntPtr)2, (IntPtr)(_picture.Width << 16));
            base.OnResize(e);
        }

        public event EventHandler PictureClick
        {
            add { this.Picture.Click += value; }
            remove { this.Picture.Click -= value; }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            
        }
    }
}
