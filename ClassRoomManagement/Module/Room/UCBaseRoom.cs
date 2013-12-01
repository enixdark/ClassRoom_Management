using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassRoomBUS;
using DevExpress.XtraEditors;
using System.IO;
using CustomItem;
namespace CustomItem.Module
{
    public partial class UCBaseRoom : UCBase
    {
        PhonghocBUS BUS = new PhonghocBUS();
        List<Model.Models.phonghoc> list;
        private Control mainlayout;

        public Control Mainlayout
        {
            get { return mainlayout; }
            set { mainlayout = value; }
        }

        private RadioGroup radio;

        public RadioGroup Radio
        {
            get { return radio; }
            set { radio = value; }
        }

        public UCBaseRoom()
        {
            InitializeComponent();
            
        }

        public void Remove(string maph)
        {
            int index = list.FindIndex(x => x.maphong.Equals(maph));
            BUS.Delete(new Model.Models.phonghoc { maphong = maph });
            tileControl1.Groups[0].Items.RemoveAt(index);
            imageSlider1.Images.RemoveAt(index);
            list.RemoveAt(index);
        }

        public void Insert(string maph)
        {
            var ph = BUS.getdata().Last<Model.Models.phonghoc>();
            Image img = Image.FromStream(new MemoryStream(ph.images));
            img.Tag = ph.maphong;
            TileItem item = new TileItem();
            item.ItemSize = TileItemSize.Wide;
            item.Image = img;
            item.Text = ph.maphong;
            item.ImageScaleMode = TileItemImageScaleMode.Stretch;
            tileControl1.Groups[0].Items.Insert(list.Count, item);
            list.Add(ph);
            imageSlider1.Images.Add(img);

        }


        protected override void ONCREATE()
        {
            list = BUS.getdata();
            TileGroup group = new TileGroup();
            
            foreach (var i in list)
            {
                //process, convert byte[] from database to Image
                Image img = Image.FromStream(new MemoryStream(i.images));
                img.Tag = i.maphong;
                //Create tileitem and information
                TileItem item = new TileItem();
                item.ItemSize = TileItemSize.Wide;
                item.Image = img;
                item.Text = i.maphong;
                item.ImageScaleMode = TileItemImageScaleMode.Stretch;
                imageSlider1.Images.Add(img);
                item.ItemClick += (o, e) =>
                {
                    int index = group.Items.IndexOf(e.Item);
                    imageSlider1.SetCurrentImageIndex(index);
                    Global.ID = list[index].maphong;
                };
                item.ItemDoubleClick += (o, e) =>
                {
                    this.mainlayout.Controls.Clear();
                    AddControl<UCRoomSwitch>(mainlayout);
                    radio.SelectedIndex = 1;
                    (new CustomItem.Navigation.TransitionChild(this.mainlayout)).Start();
                    //this.GoTo<UCRoomSwitch>();
                };

                imageSlider1.MouseClick += (o, e) =>
                {

                    int index = imageSlider1.GetCurrentImageIndex();
                    tileControl1.SelectedItem = group.Items[index];
                    Global.ID = list[index].maphong;
                };

                group.Items.Add(item);
            }
            tileControl1.Groups.Add(group);
            if (group.Items.Count > 0)
            {
                tileControl1.SelectedItem = group.Items[0];
                Global.ID = list[0].maphong;
            }
            
        }

        private void UCBaseRoom_Load(object sender, EventArgs e)
        {
            ONCREATE();
        }
    }
}

