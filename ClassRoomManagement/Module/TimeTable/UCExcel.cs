using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using CustomItem;
using Model.Models;
namespace CustomItem.Module
{
    public partial class UCExcel : UCBase
    {
        DevExpress.Spreadsheet.IWorkbook workbook;
        CustomDrawModule Ex = null;
        public UCExcel()
        {
            InitializeComponent();
             
        }

        private void layout2_Load(object sender, EventArgs e)
        {
            Ex = this.layout2;
            workbook = Ex.SpreadsheetControl1.Document;
            Ex.Execute_Click += (o,ev) =>
            {
                int check = 0;
                var Data = (Excel.GetTableFromExcel(Ex.SpreadsheetControl1)).AsEnumerable();
                List<thoikhoabieu> list = new List<thoikhoabieu>();
                try
                {
                    list = (from s in Data
                            select new thoikhoabieu
                            {
                                maca = s.Field<String>("maca"),
                                magv = s.Field<String>("magv"),
                                mahp = s.Field<String>("mahp"),
                                malop = s.Field<String>("malop"),
                                manganh = s.Field<String>("manganh"),
                                siso = Convert.ToInt32(s["siso"]),
                                tuanhocbatdau = Convert.ToInt32(s["tuanhocbatdau"]),
                                tuanhocketthuc = Convert.ToInt32(s["tuanhocketthuc"]),
                            }).ToList();
                    if (list.Count > 0)
                    {
                        foreach (thoikhoabieu ob in list)
                        {
                            check = (new ClassRoomBUS.ThoikhoabieuBUS()).Insert(ob);
                            if (check == 0)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Chưa có dữ liệu nào trong Bảng");
                                return;
                            }
                        }
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Chưa có dữ liệu nào trong Bảng");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    var k = ex.Message;
                }
                //for (int i = 0; i < table.Rows.Count;i++ )
                //{
                //    DataRow row = table.Rows[i];
                //    for(int j = 0; j < table.Columns.Count;j++)
                //    {
                //        System.Diagnostics.Debug.Write(row[j].ToString());
                //    }
                //}
                DevExpress.XtraEditors.XtraMessageBox.Show("Đã Cập nhật vào Cơ Sở Dữ Liệu");
            };
        }

        
    }
}
