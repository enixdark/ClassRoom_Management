using DevExpress.XtraEditors;

namespace ClassRoomManagement {
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.windowsUIView = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView(this.components);
            this.startGroup = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer(this.components);
            this.pageGroup = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.PageGroup(this.components);
            this.page = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Page(this.components);
            this.browserPage = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Page(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.page)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.View = this.windowsUIView;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.windowsUIView});
            // 
            // windowsUIView
            // 
            this.windowsUIView.Caption = "TEST";
            this.windowsUIView.ContentContainers.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer[] {
            this.startGroup,
            this.pageGroup,
            this.page,
            this.browserPage});
            this.windowsUIView.LoadingIndicatorProperties.DescriptionFormat = "{0} loading...";
            this.windowsUIView.TileProperties.AllowHtmlDraw = true;
            // 
            // startGroup
            // 
            this.startGroup.ActivationTarget = this.pageGroup;
            this.startGroup.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startGroup.AppearanceItem.Normal.Options.UseFont = true;
            this.startGroup.Caption = "";
            this.startGroup.Name = "startGroup";
            this.startGroup.Properties.ItemSize = 180;
            this.startGroup.Properties.RowCount = 3;
            // 
            // pageGroup
            // 
            this.pageGroup.Caption = "";
            this.pageGroup.Name = "pageGroup";
            this.pageGroup.Parent = this.startGroup;
            this.pageGroup.Properties.Margin = new System.Windows.Forms.Padding(40, 0, 40, 20);
            // 
            // page
            // 
            this.page.Document = null;
            this.page.Name = "page";
            this.page.Parent = this.startGroup;
            // 
            // browserPage
            // 
            this.browserPage.Document = null;
            this.browserPage.Name = "browserPage";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1039, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 600);
            this.barDockControlBottom.Size = new System.Drawing.Size(1039, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 600);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1039, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 600);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1039, 600);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.page)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        
        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView windowsUIView;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer startGroup;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.PageGroup pageGroup;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Page page;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Page browserPage;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}
