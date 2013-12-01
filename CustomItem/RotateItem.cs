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
    public partial class RotateItem : DevExpress.XtraEditors.LabelControl
    {
        Timer time;
        const int next = 10;
        const int limit = 5;
        int live = 0;
        public int X { get; set; }
        public int Y { get; set; }
        
        int angle = 0;
        //public RotateItem() : this(0, 0) { }
        public Image img
        {
            get;
            set;
        }
        public RotateItem()
        {
            InitializeComponent();
            
            time = new Timer();
            time.Interval = 10;
            time.Tick += new EventHandler(time_Tick);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }



        void time_Tick(object sender, EventArgs e)
        {
            if (live < limit)
            {

                if (angle < 360)
                {
                    angle += next;
                }
                else
                {
                    angle = 0;
                    live++;
                }
                this.Appearance.Image = RotateImage(img, new PointF(X, Y), angle);
            }
            else
            {
                time.Stop();
            }

        }

        private Bitmap RotateImage(Image image, PointF offset, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");


            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);


            Graphics g = Graphics.FromImage(rotatedBmp);


            g.TranslateTransform(offset.X, offset.Y);


            g.RotateTransform(angle);


            g.TranslateTransform(-offset.X, -offset.Y);


            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            time.Start();
            live = 0;
        }
    }
}
