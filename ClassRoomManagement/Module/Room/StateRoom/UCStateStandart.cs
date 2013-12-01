using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Models;
using ClassRoomBUS;
namespace CustomItem.Module
{
    public partial class UCStateStandart : UCBase
    {
        TrangthaiphongBUS tt;
        private static Control insert;
        private static Control update;
        private static Control delete;
        private trangthaiphong oldobj = null;
        public static Control Delete
        {
            get { return delete; }
            set { delete = value; }
        }
        public static Control Update
        {
            get { return update; }
            set { update = value; }
        }
        public static Control Insert
        {
            get { return insert; }
            set { insert = value; }
        }

        private event EventHandler ADDClick
        {
            add
            {
                if (insert != null)
                    insert.Click += value;
            }
            remove { insert.Click -= value; }
        }

        private event EventHandler DELClick
        {
            add { if (delete != null)delete.Click += value; }
            remove { delete.Click -= value; }
        }

        private event EventHandler UPClick
        {
            add { if (update != null)update.Click += value; }
            remove { update.Click -= value; }
        }

        public UCStateStandart()
        {
            InitializeComponent();
            
        }
        protected override void ONCREATE()
        {
            CahocBUS ca = new CahocBUS();
            PhonghocBUS phong = new PhonghocBUS();
            var dic = new System.Collections.Generic.Dictionary<string, Nullable<System.TimeSpan>[]>();
            tt = new TrangthaiphongBUS();
            txtstmaphong.Properties.Items.AddRange(phong.getdataextract());
            ClassRoomBUS.CahocBUS BUS = new ClassRoomBUS.CahocBUS();
            dic.Add("", new Nullable<System.TimeSpan>[] { new TimeSpan(), new TimeSpan() });
            ca.getdata().ForEach(i =>
            {

                txtstmaca.Properties.Items.Add(i.maca);
                dic.Add(i.maca, new Nullable<System.TimeSpan>[] { System.TimeSpan.Parse(i.thoigianbatdau.ToString()), System.TimeSpan.Parse(i.thoigianketthuc.ToString()) });

            });
            txtstmaca.SelectedIndexChanged += (o, e) =>
            {
                try
                {
                    var d = dic[(string)txtstmaca.SelectedItem];
                    ststarttime.EditValue = new DateTime(d[0].Value.Ticks);
                    stendtime.EditValue = new DateTime(d[1].Value.Ticks);
                }
                catch(Exception ex)
                {
                }
            };

            gridControl1.DataSource = tt.getdata();
            gridView1.RowClick += (o, e) =>
            {
                var row = ((DevExpress.XtraGrid.Views.Grid.GridView)o);
                if (e.RowHandle != -1)
                {
                    
                    var column = row.Columns;
                    txtstmaphong.SelectedItem = row.GetRowCellValue(e.RowHandle, column["maphong"]);
                    txtstmaca.SelectedItem = row.GetRowCellValue(e.RowHandle, column["maca"]);
                    stday.EditValue = row.GetRowCellValue(e.RowHandle, column["thoigianbatdau"]);
                    ststarttime.EditValue = row.GetRowCellValue(e.RowHandle, column["thoigianbatdau"]);
                    stendtime.EditValue = row.GetRowCellValue(e.RowHandle, column["thoigianketthuc"]);
                    oldobj = new trangthaiphong{maphong = txtstmaphong.Text,
                                                maca = txtstmaca.Text,
                                                hientrang = txtsttrangthai.Text,
                                                thoigianbatdau = ststarttime.Time,
                                                thoigianketthuc = stendtime.Time,
                    };

                }
                
                
            };

            this.UPClick += UCStateStandart_UPClick;
            this.DELClick += UCStateStandart_DELClick;
            this.ADDClick += UCStateStandart_ADDClick;
            
        }

        void UCStateStandart_ADDClick(object sender, EventArgs e)
        {
            var d = stday.DateTime;
            var s = ststarttime.Time;
            var ed = stendtime.Time;
            if(tt.Insert(new trangthaiphong
            {
                maphong = txtstmaphong.Text,
                maca = txtstmaca.Text,
                hientrang = txtsttrangthai.Text,
                thoigianbatdau = new DateTime(d.Year,d.Month,d.Day,s.Hour,s.Minute,s.Millisecond),
                thoigianketthuc = new DateTime(d.Year, d.Month, d.Day, ed.Hour, ed.Minute, ed.Millisecond)
            }))
            {
            gridControl1.DataSource = tt.getdata();
             }
            DevExpress.XtraEditors.XtraMessageBox.Show(ClassRoomDAL.Log.message);
        }

        void UCStateStandart_DELClick(object sender, EventArgs e)
        {
            var d = stday.DateTime;
            var s = ststarttime.Time;
            var ed = stendtime.Time;
            tt.Delete(new trangthaiphong
            {
                maphong = txtstmaphong.Text,
                maca = txtstmaca.Text,
                thoigianbatdau = new DateTime(d.Year, d.Month, d.Day, s.Hour, s.Minute, s.Millisecond),
                thoigianketthuc = new DateTime(d.Year, d.Month, d.Day, ed.Hour, ed.Minute, ed.Millisecond)
            });
            
                gridControl1.DataSource = tt.getdata();
           
        }

        void UCStateStandart_UPClick(object sender, EventArgs e)
        {
            var d = stday.DateTime;
            var s = ststarttime.Time;
            var ed = stendtime.Time;
            if (tt.Update(oldobj, new trangthaiphong
            {
                maphong = txtstmaphong.Text,
                maca = txtstmaca.Text,
                hientrang = txtsttrangthai.Text,
                thoigianbatdau = new DateTime(d.Year, d.Month, d.Day, s.Hour, s.Minute, s.Millisecond),
                thoigianketthuc = new DateTime(d.Year, d.Month, d.Day, ed.Hour, ed.Minute, ed.Millisecond)
            }))
            {

                gridControl1.DataSource = tt.getdata();
            }
            DevExpress.XtraEditors.XtraMessageBox.Show(ClassRoomDAL.Log.message);
        }
        private void standartday_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void UCStateStandart_Load(object sender, EventArgs e)
        {
            UCOnLoad(ONCREATE);
        }

        
    }
}
