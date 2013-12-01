using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomItem
{
    public class Ultility
    {
    }
    public class CustomTime{
        
        public static DateTime firstweek()
        {
            DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
            TimeSpan time = new TimeSpan(1, 0, 0);
            while (!start.DayOfWeek.ToString().Equals("Sunday"))
            {
                Console.WriteLine(start.DayOfWeek);
                start += time;
            }
            return start;
        }
        public static Dictionary<int,DateTime[]> DataDatetime()
        {
            Dictionary<int, DateTime[]> date = new Dictionary<int, DateTime[]>();
            TimeSpan nextday = new TimeSpan(1,0,0,0,0);
            TimeSpan nextweek = new TimeSpan(7,0,0,0,0);
            date.Add(1,new DateTime[]{new DateTime(DateTime.Now.Year,1,1),firstweek() - nextday});
            DateTime start = firstweek();
            DateTime end = new DateTime(DateTime.Now.Year,12,31);
            int i = 1;
            while (start < end)
            {
                date.Add(++i,new DateTime[]{start,start + nextweek - nextday});
                start += nextweek;
            }
            date.Add(++i, new DateTime[] { start - nextweek, end});
            return date;
        }

        public static DateTime lastweek()
        {
            DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
            TimeSpan time = new TimeSpan(1, 0, 0);
            while (!start.DayOfWeek.ToString().Equals("Sunday"))
            {
                Console.WriteLine(start.DayOfWeek);
                start += time;
            }
            return start;
        }
    }
    public static class Images
    {
        public static byte[] EncodeImage(string url)
        {
            return Images.EncodeImage(url, new System.Drawing.Size(1280,720));
        }

        public static byte[] EncodeImage(string url, System.Drawing.Size size)
        {
            if (!url.Equals(""))
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(url);
                var f = img.RawFormat;
                System.Drawing.Bitmap bit = new System.Drawing.Bitmap(img, size);
                System.IO.MemoryStream str = new System.IO.MemoryStream();
                bit.Save(str, f);
                return str.ToArray();
            }
            return null;
        }

        public static byte[] EncodeImage(System.Drawing.Image img)
        {
            return Images.EncodeImage(img, new System.Drawing.Size(1280, 720));
        }

        public static byte[] EncodeImage(System.Drawing.Image img, System.Drawing.Size size)
        {
            var f = img.RawFormat;
            System.Drawing.Bitmap bit = new System.Drawing.Bitmap(img, size);
            System.IO.MemoryStream str = new System.IO.MemoryStream();
            bit.Save(str, f);
            return str.ToArray();
        }

        public static System.Drawing.Image DecodeImage(byte[] image)
        {
            if(image==null)
                return System.Drawing.Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(ImageNull.imagenull)));
            return System.Drawing.Image.FromStream(new System.IO.MemoryStream(image));
        }

        public static System.Drawing.Image LoadFromFile(string url)
        {
            return System.Drawing.Image.FromFile(url);
        }

    }
    public static class Excel
    {
        public static DataTable LoadFile(string file, string worksheet = "Sheet1")
        {
            string url = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0\";", file);
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            using (DbConnection conn = factory.CreateConnection())
            {
                conn.ConnectionString = url;
                using (OleDbCommand cmd = (OleDbCommand)conn.CreateCommand())
                {
                    cmd.CommandText = string.Format("Select * from [{0}$]", worksheet);
                    conn.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;

                }
            }
        }

        public static IEnumerable<DataRow> TableToList(this DataTable table){
            return table.AsEnumerable(); //as EnumerableRowCollection<T>;
        }

        public static DataTable GetTableFromExcel(DevExpress.XtraSpreadsheet.SpreadsheetControl control)
        {
            DataTable table = new DataTable();
            DevExpress.Spreadsheet.IWorkbook workbook = control.Document;
            DevExpress.Spreadsheet.Worksheet worksheet = workbook.Worksheets[control.ActiveWorksheet.Name];
            DevExpress.Spreadsheet.Range range = worksheet.GetUsedRange();

            Func<DevExpress.Spreadsheet.Worksheet, DevExpress.Spreadsheet.Range,int> Rowindex = (sheet,ran) =>
            {

                for (int i = 0; i < ran.RowCount; i++)
                {
                    int j = 0;
                    for (int k = 0; k < ran.ColumnCount; k++)
                    {
                        if (!sheet.Cells[i, k].DisplayText.Equals(""))
                            j++;
                    }
                    if (j > ran.ColumnCount / 2 + 1)
                        return i;
                }
                return 0;
            };

            int index = Rowindex(worksheet, range);
            for (int i = 0; i < range.ColumnCount; i++)
            {

                table.Columns.Add(worksheet.Rows[index][i].Value.ToString());
                //Debug.WriteLine(worksheet.Rows[1][i].Name);
            }
            for (int i = index + 1; i < range.RowCount; i++)
            {
                DataRow row = table.NewRow();
                int space = 0;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    row[j] = worksheet.Cells[i, j].DisplayText;
                    space = worksheet.Cells[i, j].DisplayText.Equals("") ? space + 1 : space;
                }
                if(space < table.Columns.Count/2)
                    table.Rows.Add(row);
            }
            return table;
        }

        
    }

    
}
