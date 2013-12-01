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
using DevExpress.XtraReports.UI;

namespace CustomItem.Module.Report
{
    
    
    public partial class UCReport : UCBase
    {
        Dictionary<int, DateTime[]> date = new Dictionary<int, DateTime[]>();

        public UCReport()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void UCReport_Load(object sender, EventArgs e)
        {

            UCOnLoad(delegate { });
            date = CustomItem.CustomTime.DataDatetime();
            repositoryItemComboBox1.Items.Add("");
            (new NganhBUS()).getdata().ForEach(x =>
            {
                repositoryItemComboBox1.Items.Add(x.tennganh);
            });
            
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            XtraReport reports = null;
            var list = (from s in (new LapphongBUS()).getdata()
                        join i in (new ThoikhoabieuBUS()).getdata()
                            on s.mahp equals i.mahp
                        select new
                        {
                            mahp = s.mahp,
                            tenlop = i.Lop.tenlop,
                            siso = i.siso,
                            maca = i.maca,
                            tengv = i.Giangvien.tengv,
                            tennganh = i.Nganh.tennganh,
                            maphong = s.maphong,
                            thoigian = i.tuanhocbatdau + " → " + i.tuanhocketthuc + "( " + date[(int)i.tuanhocbatdau][0].ToShortDateString() + " - " + date[(int)i.tuanhocketthuc][1].ToShortDateString(),
                            

                        }).ToList();
            System.Diagnostics.Debug.WriteLine(combonganh.EditValue);
            if (combonganh.EditValue.Equals(""))
            {
                reports = new Report.Reports();
                reports.DataSource = list;
            }
            else
            {
                
                reports = new Report.ReportsEx(combonganh.EditValue.ToString());
                reports.DataSource = list.FindAll(x => x.tennganh.Equals(combonganh.EditValue.ToString()));
            }
            reports.CreateDocument();
            documentViewer1.DocumentSource = reports;
            
            //ReportPrintTool tool = new ReportPrintTool(reports);
            //tool.ShowPreview();
        }
    }
}
