using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ClassRoomBUS;

namespace CustomItem.Module
{
    public partial class UCGroup : UCBase
    {
        Dictionary<string,DevExpress.XtraBars.Ribbon.GalleryItem> dic;
        List<Model.Models.Nhom> list;
        public UCGroup()
        {
            InitializeComponent();
            dic = new Dictionary<string,DevExpress.XtraBars.Ribbon.GalleryItem>();
            list = new List<Model.Models.Nhom>();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup group = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            
            XDocument doc = XDocument.Load(Application.StartupPath + @"\Data.xml");
            var x = (from s in doc.Descendants("Groups").Elements("Group") select s).ToList<XElement>();
            foreach(var i in x)
            {
                DevExpress.XtraBars.Ribbon.GalleryItem item = new DevExpress.XtraBars.Ribbon.GalleryItem();
                item.Image = Images.DecodeImage(Convert.FromBase64String(i.Attribute("image").Value));
                item.Caption = i.Attribute("caption").Value;
                item.Value = i.Value;
                dic.Add(i.Value,item);
                group.Items.Add(item);
            }
            Ucgrouploai.Gallery.Groups.Add(group);
            var help = new DragDropHelper(Ucgrouploai, Ucgroupphanloai,Ucgrouprecycle);
            help.EnableDragDrop();

            LoadData();
            dataNavigator1.PositionChanged += (o, e) =>
            {
                
                var index = (o as DevExpress.XtraEditors.DataNavigator).Position;
                DataBindingToList(list[index]);
                gridView1.SelectRow(index);
                //System.Diagnostics.Debug.WriteLine(dataNavigator1.Position);
            };

            add.Click += add_Click;
            update.Click += update_Click;
            delete.Click += delete_Click;
            save.Click += save_Click;
            refresh.Click += refresh_Click;
            gridView1.RowClick += gridView1_RowClick;
            Ucgrouppicture.DoubleClick += Ucgrouppicture_DoubleClick;
        }

        void Ucgrouppicture_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Images Files|*.png;*.jpg;*.jpeg;*.bmp";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                Ucgrouppicture.Image = Images.LoadFromFile(open.FileName);
                
            }
        }

        void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            var row = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            Ucgroupphanloai.Gallery.Groups.Clear();
            Global.ID = row.GetRowCellValue(e.RowHandle, "manhom").ToString();
            Ucgrouptxtmanhon.Text = row.GetRowCellValue(e.RowHandle, "manhom").ToString();
            Ucgrouptxttennhom.Text = row.GetRowCellValue(e.RowHandle, "tennhom").ToString();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup group = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            var pl = row.GetRowCellValue(e.RowHandle, "phanloai").ToString().Split(new char[] { ',' });
            foreach (var i in pl)
            {
                group.Items.Add(dic[i]);
            }
            Ucgroupphanloai.Gallery.Groups.Add(group);
            Ucgroupmemothonhtin.Text = row.GetRowCellValue(e.RowHandle, "thongtin").ToString();
            Ucgrouppicture.Image = Images.DecodeImage((byte[])row.GetRowCellValue(e.RowHandle, "image"));
            dataNavigator1.Position = e.RowHandle;
        }
        private void LoadData()
        {
            list = (new NhomBUS()).getdata();
            gridControl1.RefreshDataSource();
            dataNavigator1.Refresh();
            gridControl1.DataSource = list;
            dataNavigator1.DataSource = list;
        }
        private void DataBindingToList(Model.Models.Nhom obj)
        {
            Ucgroupphanloai.Gallery.Groups.Clear();
            Global.ID = obj.manhom;
            Ucgrouptxtmanhon.Text = obj.manhom;
            Ucgrouptxttennhom.Text = obj.tennhom;
            DevExpress.XtraBars.Ribbon.GalleryItemGroup group = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            var pl = obj.phanloai.Split(new char[] { ',' });
            foreach (var i in pl)
            {
                group.Items.Add(dic[i]);
            }
            Ucgroupphanloai.Gallery.Groups.Add(group);
            Ucgroupmemothonhtin.Text = obj.thongtin;
            Ucgrouppicture.Image = Images.DecodeImage(obj.image);
            
        }
        void refresh_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void save_Click(object sender, EventArgs e)
        {
            string pl ="";
            foreach(DevExpress.XtraBars.Ribbon.GalleryItem i in Ucgroupphanloai.Gallery.Groups[0].Items){
                pl += i.Value+",";
            }

            if (Global.ActiveID)
            {
                (new NhomBUS()).Update(new Model.Models.Nhom { manhom = (string)Global.ID }, new Model.Models.Nhom
                {
                    tennhom = Ucgrouptxttennhom.Text,
                    manhom = Ucgrouptxtmanhon.Text,
                    image = Ucgrouppicture.Image == null ? null : Images.EncodeImage(Ucgrouppicture.Image),
                    phanloai = pl.Length > 0 ? pl.Substring(0, pl.Length - 1) : pl,
                    thongtin = Ucgroupmemothonhtin.Text
                });
            }
            else
            {
                (new NhomBUS()).Insert(new Model.Models.Nhom
                {
                    tennhom = Ucgrouptxttennhom.Text,
                    manhom = Ucgrouptxtmanhon.Text,
                    image = Ucgrouppicture.Image == null ? null : Images.EncodeImage(Ucgrouppicture.Image),
                    phanloai = pl.Length > 0 ? pl.Substring(0, pl.Length - 1) : pl,
                    thongtin = Ucgroupmemothonhtin.Text
                });
                    
            }
                DevExpress.XtraEditors.XtraMessageBox.Show("OK");
        }

        void delete_Click(object sender, EventArgs e)
        {
            (new NhomBUS()).Delete(new Model.Models.Nhom { manhom = (string)Global.ID });
        }

        void update_Click(object sender, EventArgs e)
        {
            Global.ActiveID = true;
            SetEnableClick(false);
        }

        void add_Click(object sender, EventArgs e)
        {
            Global.ActiveID = false;
            SetEnableClick(false);
            Ucgrouptxtmanhon.Text = "";
            Ucgrouptxttennhom.Text = "";
            Ucgroupmemothonhtin.Text = "";
            Ucgroupphanloai.Gallery.Groups.Clear();
            Ucgrouppicture.Image = null;


        }
        private void SetEnableClick(bool check)
        {
            this.delete.Enabled = check;
            this.add.Enabled = check;
            this.update.Enabled = check;
            this.save.Enabled = !check;
        }
        private void dataNavigator1_Click(object sender, EventArgs e)
        {

        }

        private void hideContainerRight_Click(object sender, EventArgs e)
        {

        }
    }
}
