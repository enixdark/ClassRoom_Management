using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomItem.Form;
using DevExpress.Skins;
using DevExpress.Skins.Info;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraSplashScreen;

namespace CustomItem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            AppearanceObject.DefaultFont = new Font("Segoe UI", 8.25f);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Main());
        }
    }
}
