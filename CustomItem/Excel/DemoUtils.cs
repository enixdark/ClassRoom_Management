using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;
using DevExpress.DXperience.Demos;

namespace CustomItem
{
    public class SpreadSheetTutorialControlBase : TutorialControlBase {
        public override bool AutoMergeRibbon { get { return true; } set { } }
    }

    public class DemoUtils {
        public static string GetRelativePath(string name) {
            name = "Data\\" + name;
            string path = System.Windows.Forms.Application.StartupPath;
            string s = "\\";
            for(int i = 0; i <= 10; i++) {
                if(System.IO.File.Exists(path + s + name))
                    return (path + s + name);
                else
                    s += "..\\";
            }
            return "";
        }
        public static string GetRelativeDirectoryPath(string name) {
            name = "Data\\" + name;
            string path = System.Windows.Forms.Application.StartupPath;
            string s = "\\";
            for(int i = 0; i <= 10; i++) {
                if(System.IO.Directory.Exists(path + s + name))
                    return (path + s + name);
                else
                    s += "..\\";
            }
            return "";
        }
        public static Bitmap LoadImageByName(string name) {
            Stream stream = typeof(frmMain).Assembly.GetManifestResourceStream("Modules." + name);
            if(stream == null)
                stream = typeof(frmMain).Assembly.GetManifestResourceStream(name);
            if(stream != null)
                return (Bitmap)DevExpress.Data.Utils.ImageTool.ImageFromStream(stream);
            return null;
        }

        
    }

    
}
