using System;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;

namespace ClassRoomManagement {
    public partial class Main : XtraForm {
        public Main() {
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Location = System.Windows.Forms.Screen.GetBounds(MousePosition).Location;
            InitializeComponent();
            
            
            //windowsUIView.ContentContainerActions.Add(new SetSkinAction("Metropolis", "White Theme"));
            //windowsUIView.ContentContainerActions.Add(new SetSkinAction("MetroBlack", "Black Theme"));
            
        
        
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
