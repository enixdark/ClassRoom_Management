using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
namespace CustomItem
{
    public class Global
    {
        //biến toàn cục dùng lưu trữ/tham chiếu tới panel chính (MainForm)
        public static Control main = null;
        //biến toàn cục dùng để lưu trữ 1 giá trị tùy y (thông trữ giá tị 1 column/field(primarykey,uni,foreignkey) trong Table/List 
        public static object ID = null;
        //kích hoạt biến ID
        public static bool ActiveID = false;
        public static String Information = "";

    }
}
