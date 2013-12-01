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

namespace CustomItem.Module
{
    public partial class UCRoomSwitch : UCBase
    {
        PhonghocBUS BUS = new PhonghocBUS();

        public UCRoomSwitch()
        {
            InitializeComponent();
            gridControl1.DataSource = BUS.getdata();
            Clear();
            
        }

        public void AddClick()
        {

            if (BUS.Insert(new Model.Models.phonghoc
            {
                maphong = vGridControl1.GetRowByName("Maphong").Properties.Value.ToString() ,
                tenphong = vGridControl1.GetRowByName("tenphong").Properties.Value.ToString(),
                siso = Convert.ToInt32(vGridControl1.GetRowByName("succhua").Properties.Value) ,
                dien_tich = Convert.ToDouble(vGridControl1.GetRowByName("dientich").Properties.Value),
                images = Images.EncodeImage(vGridControl1.GetRowByName("image").Properties.Value.ToString())
            }))
            {
                
                LoadData();
            }
            DevExpress.XtraEditors.XtraMessageBox.Show(ClassRoomDAL.Log.message);
        }

        public void DeleteClick()
        {
            if (gridView1.GetSelectedRows().Count() > 0)
            {
                foreach (var i in gridView1.GetSelectedRows())
                {
                    BUS.Delete(new Model.Models.phonghoc
                    {
                        maphong = gridView1.GetRowCellValue(i, "maphong").ToString()
                    });
                }
                DevExpress.XtraEditors.XtraMessageBox.Show(ClassRoomDAL.Log.message);
                LoadData();
            }
            
        }

        public void RefreshClick()
        {
            Clear();
            LoadData();
        }

        

        public void UpdateClick()
        {
            if (gridView1.GetSelectedRows().Count() > 0)
            {
                foreach (var i in gridView1.GetSelectedRows())
                {
                    BUS.Update(new Model.Models.phonghoc
                    {
                        maphong = gridView1.GetRowCellValue(i, "maphong").ToString()
                    },
                    new Model.Models.phonghoc
                    {
                        maphong = vGridControl1.GetRowByName("Maphong").Properties.Value.ToString(),
                        tenphong = vGridControl1.GetRowByName("tenphong").Properties.Value.ToString(),
                        siso = Convert.ToInt32(vGridControl1.GetRowByName("succhua").Properties.Value),
                        dien_tich = Convert.ToDouble(vGridControl1.GetRowByName("dientich").Properties.Value),
                        images = Images.EncodeImage(vGridControl1.GetRowByName("image").Properties.Value.ToString())
                    });
                }

                LoadData();
            }
            DevExpress.XtraEditors.XtraMessageBox.Show(ClassRoomDAL.Log.message);
        }


        public void Save()
        {
            if (Global.ActiveID)
                UpdateClick();
            AddClick();
        }

        private void LoadData()
        {
            gridControl1.DataSource = BUS.getdata();
            gridControl1.RefreshDataSource();
            
        }

        private void Clear()
        {
            vGridControl1.GetRowByName("Maphong").Properties.Value = "";
            vGridControl1.GetRowByName("tenphong").Properties.Value = "";
            vGridControl1.GetRowByName("succhua").Properties.Value = 0;
            vGridControl1.GetRowByName("dientich").Properties.Value = 0;
            vGridControl1.GetRowByName("image").Properties.Value = "";
        }

        private void repositoryItemTextEdit1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Images Files|*.png;*.jpg;*.jpeg;*.bmp";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                vGridControl1.SetCellValue(vGridControl1.GetRowByName("image"), 0, open.FileName);

            }
        }

        private void UCRoomSwitch_Load(object sender, EventArgs e)
        {
            gridView1.RowClick += (o, ev) =>
            {
                vGridControl1.GetRowByName("Maphong").Properties.Value = gridView1.GetRowCellValue(ev.RowHandle, "maphong").ToString();
                vGridControl1.GetRowByName("tenphong").Properties.Value = gridView1.GetRowCellValue(ev.RowHandle, "tenphong").ToString();
                vGridControl1.GetRowByName("succhua").Properties.Value = (Nullable<int>)gridView1.GetRowCellValue(ev.RowHandle, "siso");
                vGridControl1.GetRowByName("dientich").Properties.Value = (Nullable<double>)gridView1.GetRowCellValue(ev.RowHandle, "dientich");
                vGridControl1.GetRowByName("image").Properties.Value = "";
            };
        }

        

       
    }
}
