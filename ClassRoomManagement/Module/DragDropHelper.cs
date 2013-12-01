using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraEditors;
using System.Xml.Linq;
using System.Linq;
using System;
namespace CustomItem.Module
{
    public class DragDropHelper
    {
        RibbonHitInfo dragItemHitInfo = null;
        GalleryControl sourceGallery, targetGallery;
        LabelControl Recycle;
        XDocument doc = XDocument.Load(Application.StartupPath + @"\Data.xml");
        public DragDropHelper(GalleryControl sourceGallery, GalleryControl targetGallery,LabelControl Recycle)
        {
            this.sourceGallery = sourceGallery;
            this.targetGallery = targetGallery;
            this.Recycle = Recycle;
            
            
        }

        public void EnableDragDrop()
        {
            sourceGallery.MouseDown += OnSourceGalleryMouseDown;
            sourceGallery.MouseMove += OnSourceGalleryMouseMove;
            targetGallery.MouseDown += OnTargetGalleryMouseDown;
            targetGallery.MouseMove += OnTargetGalleryMouseMove;
            //targetGallery.AllowDrop = true;
            //Recycle.AllowDrop = true;
            targetGallery.DragDrop += OnTargetGalleryDragDrop;
            targetGallery.DragOver += OnTargetGalleryDragOver;
            Recycle.DragDrop += Recycle_DragDrop;
            Recycle.DragOver += Recycle_DragOver;
            Recycle.DragEnter += Recycle_DragEnter;
            Recycle.DragLeave += Recycle_DragLeave;
        }

        void Recycle_DragLeave(object sender, System.EventArgs e)
        {
            var img = (from s in doc.Descendants("DragDrop").Elements("Group") where (string)s.Attribute("caption") == "close" select s.Value).First();
            Recycle.Appearance.Image = Images.DecodeImage(Convert.FromBase64String(img));
        }

        void Recycle_DragEnter(object sender, DragEventArgs e)
        {
            string img = (from s in doc.Descendants("DragDrop").Elements("Group") where (string)s.Attribute("caption")=="open" select s.Value ).ToList().First();
            Recycle.Appearance.Image = Images.DecodeImage(Convert.FromBase64String(img));
        }

        void Recycle_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GalleryItem)))
                e.Effect = DragDropEffects.Copy;
        }

        void Recycle_DragDrop(object sender, DragEventArgs e)
        {
            if (!(e.Data.GetDataPresent(typeof(GalleryItem))))
                return;

            GalleryItem draggedItem = e.Data.GetData(typeof(GalleryItem)) as GalleryItem;

            LabelControl recycle = (LabelControl)sender;
            targetGallery.Gallery.Groups[0].Items.Remove(draggedItem);
            if (targetGallery.Gallery.Groups[0].Items.Count < 1)
            {
                targetGallery.Gallery.Groups.RemoveAt(0);
            }
            this.Recycle.AllowDrop = false;
            
        }

        private void OnTargetGalleryMouseDown(object sender, MouseEventArgs e)
        {
            this.Recycle.AllowDrop = true;
            GalleryControl galControl = (GalleryControl)sender;
            RibbonHitInfo hitInfo = galControl.CalcHitInfo(e.Location);
            if (hitInfo.InGalleryItem)
            {
                dragItemHitInfo = hitInfo;
                return;
            }

            dragItemHitInfo = null;
        }

        private void OnTargetGalleryMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || Control.ModifierKeys != Keys.None || dragItemHitInfo == null)
                return;

            Size dragSize = SystemInformation.DragSize;
            Rectangle dragRect = new Rectangle(dragItemHitInfo.HitPoint.X - dragSize.Width / 2, dragItemHitInfo.HitPoint.Y - dragSize.Height / 2, dragSize.Width, dragSize.Height);
            if (!(dragRect.Contains(e.Location)))
                targetGallery.DoDragDrop(dragItemHitInfo.GalleryItem, DragDropEffects.Copy);
        }

        private void OnSourceGalleryMouseDown(object sender, MouseEventArgs e)
        {
            targetGallery.AllowDrop = true ;
            GalleryControl galControl = (GalleryControl)sender;
            RibbonHitInfo hitInfo = galControl.CalcHitInfo(e.Location);
            
            if (hitInfo.InGalleryItem)
            {
                dragItemHitInfo = hitInfo;
                return;
            }

            dragItemHitInfo = null;
        }

        private void OnSourceGalleryMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || Control.ModifierKeys != Keys.None || dragItemHitInfo == null)
                return;

            Size dragSize = SystemInformation.DragSize;
            Rectangle dragRect = new Rectangle(dragItemHitInfo.HitPoint.X - dragSize.Width / 2, dragItemHitInfo.HitPoint.Y - dragSize.Height / 2, dragSize.Width, dragSize.Height);
            if (!(dragRect.Contains(e.Location)))
                sourceGallery.DoDragDrop(dragItemHitInfo.GalleryItem, DragDropEffects.Move);
        }

        private void OnTargetGalleryDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GalleryItem)))
                e.Effect = DragDropEffects.Move;
        }

        private void OnTargetGalleryDragDrop(object sender, DragEventArgs e)
        {
            if (!(e.Data.GetDataPresent(typeof(GalleryItem))))
                return;

            GalleryItem draggedItem = e.Data.GetData(typeof(GalleryItem)) as GalleryItem;

            GalleryControl galControl = (GalleryControl)sender;
            RibbonHitInfo hitInfo = galControl.CalcHitInfo(galControl.PointToClient(new Point(e.X, e.Y)));
            if (hitInfo.Gallery.Groups.Count > 0)
                foreach(GalleryItem i in hitInfo.Gallery.Groups[0].Items){
                    System.Diagnostics.Debug.WriteLine(draggedItem.Caption + "hhhh" );
                    if (i.Caption.Equals(draggedItem.Caption))
                        return;
                }
            if (hitInfo.Gallery.Groups.Count > 0 || hitInfo.InGalleryGroup)
            {
                hitInfo.GalleryItemGroup.Items.Add((GalleryItem)draggedItem.Clone());

            }
            else
            {
                int groupIndex = galControl.Gallery.Groups.Add(new GalleryItemGroup());
                galControl.Gallery.Groups[groupIndex].Caption = draggedItem.GalleryGroup.Caption;
                galControl.Gallery.Groups[groupIndex].Items.Add((GalleryItem)draggedItem.Clone());
            }
            
            targetGallery.AllowDrop = false;
        }

        public void DisableDragDrop()
        {
            sourceGallery.MouseDown -= OnSourceGalleryMouseDown;
            sourceGallery.MouseMove -= OnSourceGalleryMouseMove;

            targetGallery.AllowDrop = false;
            targetGallery.DragDrop -= OnTargetGalleryDragDrop;
            targetGallery.DragOver -= OnTargetGalleryDragOver;
        }
    }
}
