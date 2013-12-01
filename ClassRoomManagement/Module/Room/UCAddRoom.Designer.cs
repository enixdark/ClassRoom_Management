namespace CustomItem.Module
{
    partial class UCAddRoom
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xtraUserControl1 = new DevExpress.XtraEditors.XtraUserControl();
            this.xtraUserControl2 = new DevExpress.XtraEditors.XtraUserControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.ucFormAddRoom1 = new CustomItem.Module.UCFormAddRoom();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraUserControl1
            // 
            this.xtraUserControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraUserControl1.Location = new System.Drawing.Point(0, 436);
            this.xtraUserControl1.Name = "xtraUserControl1";
            this.xtraUserControl1.Size = new System.Drawing.Size(720, 44);
            this.xtraUserControl1.TabIndex = 0;
            // 
            // xtraUserControl2
            // 
            this.xtraUserControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraUserControl2.Location = new System.Drawing.Point(0, 0);
            this.xtraUserControl2.Name = "xtraUserControl2";
            this.xtraUserControl2.Size = new System.Drawing.Size(720, 35);
            this.xtraUserControl2.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.ucFormAddRoom1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 35);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(720, 401);
            this.panelControl1.TabIndex = 2;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // ucFormAddRoom1
            // 
            this.ucFormAddRoom1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucFormAddRoom1.Location = new System.Drawing.Point(0, 0);
            this.ucFormAddRoom1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ucFormAddRoom1.Name = "ucFormAddRoom1";
            this.ucFormAddRoom1.Size = new System.Drawing.Size(720, 401);
            this.ucFormAddRoom1.TabIndex = 0;
            // 
            // UCAddRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.xtraUserControl2);
            this.Controls.Add(this.xtraUserControl1);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "UCAddRoom";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraUserControl xtraUserControl1;
        private DevExpress.XtraEditors.XtraUserControl xtraUserControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private UCFormAddRoom ucFormAddRoom1;

    }
}
