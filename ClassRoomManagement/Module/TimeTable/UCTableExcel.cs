using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Spreadsheet;
using CustomItem;

namespace CustomItem.Module
{
    public partial class UCTableExcel : UCBase
    {
        IWorkbook workbook;
        public UCTableExcel()
        {
            InitializeComponent();
            workbook = this.spreadsheetControl1.Document;
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textEdit1.Text = op.FileName;
            }
        }

        private void UCTableExcel_Load(object sender, EventArgs e)
        {
            checkEdit1.CheckedChanged += (o, s) =>
            {
                textEdit2.Enabled = checkEdit1.Checked ? true : false;

            };
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Worksheet worksheet = workbook.Worksheets[0];
            worksheet.DeleteCells(worksheet.Cells, DeleteMode.ShiftCellsLeft);
            workbook.History.IsEnabled = false;
            workbook.BeginUpdate();
            ImportDataTable(workbook,textEdit1.Text.Trim(),textEdit2.Enabled ? textEdit2.Text : "Sheet1");
            workbook.EndUpdate();
            workbook.History.IsEnabled = true;
        }

        void ImportDataTable(IWorkbook workbook,string url,string dataname)
        {

            Worksheet worksheet = workbook.Worksheets[0];
            worksheet.Name = dataname;
            worksheet.Import(Excel.LoadFile(url,dataname), true, 1, 1);

        }
    }
}
