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
using ClassRoomBUS;
using Model.Models;
namespace CustomItem.Module
{
    public partial class UCTimetable : UCBase
    {
        ThoikhoabieuBUS TKB;
        System.Collections.IList l;
        
        public UCTimetable()
        {
            InitializeComponent();
            TKB = new ThoikhoabieuBUS();
            
        }
        private void LoadData()
        {
            l = (from s in TKB.getdata()
                     select new
                     {
                         maca = s.maca,
                         magv = s.magv,
                         malop = s.malop,
                         manganh = s.manganh,
                         mahp = s.mahp,
                         siso = s.siso,
                         thoigian = s.tuanhocbatdau.ToString() + " -> " + s.tuanhocketthuc.ToString(),
                         ID = s.ID,
                     }).ToList();
            gridControl1.DataSource = l;
        }

        //private void DeleteClick(Object sender, EventArgs events)
        //{
        //    delete.Click += (o, e) =>
        //    {
        //        foreach (var k in gridView1.GetSelectedRows())
        //        {
        //            thoikhoabieu obj = new thoikhoabieu
        //            {
        //                ID = (int)gridView1.GetRowCellValue(k,"ID")
        //            };
        //            TKB.Delete(obj);
        //        }
        //    };
        //}

        //private void AddClick(Object sender,EventArgs events)
        //{
        //    add.Click += (o, e) =>
        //    {
        //        Global.Information = "INSERT";
        //        Global.ActiveID = false;
        //        Global.main.GoTo<UCTimetable_Add>();
        //    };
        //}
        //private void UpdateClick(Object sender, EventArgs events)
        //{
        //    update.Click += (o, e) =>
        //    {
        //        Global.Information = "UPDATE";
        //        Global.ActiveID = true;
        //        Global.main.GoTo<UCTimetable_Add>();
        //    };
        //}
        //private void GridViewEvent(Object sender, EventArgs events)
        //{
        //    gridView1.RowClick += (o, e) =>
        //    {
        //        Global.ID = gridView1.GetRowCellValue(e.RowHandle, "ID");
        //        System.Diagnostics.Debug.WriteLine((int)Global.ID);
        //    };
        //}
        protected override void ONCREATE()
        {
            refresh.img = refresh.Appearance.Image;
            refresh.X = this.refresh.Appearance.Image.Width / 2;
            refresh.Y = this.refresh.Appearance.Image.Height / 2;
        }
        

        private void rotateItem1_Click(object sender, EventArgs e)
        {
            refresh.img = refresh.Appearance.Image;
            refresh.X = this.refresh.Appearance.Image.Width / 2;
            refresh.Y = this.refresh.Appearance.Image.Height / 2;
            LoadData();
        }


        

        private void rotateItem1_MouseHover(object sender, EventArgs e)
        {
            refresh.img = refresh.Appearance.HoverImage;
            refresh.X = this.refresh.Appearance.Image.Width / 2;
            refresh.Y = this.refresh.Appearance.Image.Height / 2;
        }

        private void UCTimetable_Load(object sender, EventArgs e)
        {
            UCOnLoad(ONCREATE);
            LoadData();
            //delete.Click += delete_Click;
            //update.Click += update_Click;
            //add.Click += add_Click;
            gridView1.RowClick += gridView1_RowClick;
        }

        void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Global.ID = gridView1.GetRowCellValue(e.RowHandle, "ID");
            System.Diagnostics.Debug.WriteLine((int)Global.ID);
        }

        void add_Click(object sender, EventArgs e)
        {
            Global.Information = "INSERT";
            Global.ActiveID = false;
            Global.main.GoTo<UCTimetable_Add>();
        }

        void update_Click(object sender, EventArgs e)
        {
            
                Global.Information = "UPDATE";
                Global.ActiveID = true;
                Global.main.GoTo<UCTimetable_Add>();
            
        }

        void delete_Click(object sender, EventArgs e)
        {
            
                foreach (var k in gridView1.GetSelectedRows())
                {
                    thoikhoabieu obj = new thoikhoabieu
                    {
                        ID = (int)gridView1.GetRowCellValue(k, "ID")
                    };
                    TKB.Delete(obj);
                }
            
        }

        private void add_Click_1(object sender, EventArgs e)
        {
            Global.Information = "INSERT";
            Global.ActiveID = false;
            Global.main.GoTo<UCTimetable_Add>();
        }

        private void update_Click_1(object sender, EventArgs e)
        {
            Global.Information = "UPDATE";
            Global.ActiveID = true;
            Global.main.GoTo<UCTimetable_Add>();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {
            Global.main.GoTo<UCExcel>();
        }

        
    }
}
