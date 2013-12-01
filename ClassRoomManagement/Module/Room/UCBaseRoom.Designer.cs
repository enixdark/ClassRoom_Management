namespace CustomItem.Module
{
    partial class UCBaseRoom
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
            this.imageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.xtraUserControl2 = new DevExpress.XtraEditors.XtraUserControl();
            this.xtraUserControl1 = new DevExpress.XtraEditors.XtraUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageSlider1
            // 
            this.imageSlider1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageSlider1.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch;
            this.imageSlider1.Location = new System.Drawing.Point(50, 63);
            this.imageSlider1.Name = "imageSlider1";
            this.imageSlider1.Size = new System.Drawing.Size(620, 338);
            this.imageSlider1.TabIndex = 11;
            this.imageSlider1.Text = "imageSlider1";
            // 
            // tileControl1
            // 
            this.tileControl1.AllowDrag = false;
            this.tileControl1.AllowGroupHighlighting = true;
            this.tileControl1.AllowItemHover = true;
            this.tileControl1.AllowSelectedItem = true;
            this.tileControl1.AppearanceGroupHighlighting.MaskOpacity = 0;
            this.tileControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileControl1.IndentBetweenGroups = 0;
            this.tileControl1.IndentBetweenItems = 2;
            this.tileControl1.ItemCheckMode = DevExpress.XtraEditors.TileItemCheckMode.Single;
            this.tileControl1.ItemPadding = new System.Windows.Forms.Padding(0);
            this.tileControl1.ItemSize = 40;
            this.tileControl1.ItemTextShowMode = DevExpress.XtraEditors.TileItemContentShowMode.Hover;
            this.tileControl1.Location = new System.Drawing.Point(50, 0);
            this.tileControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tileControl1.MaxId = 15;
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.Padding = new System.Windows.Forms.Padding(2);
            this.tileControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tileControl1.RowCount = 1;
            this.tileControl1.Size = new System.Drawing.Size(620, 63);
            this.tileControl1.TabIndex = 10;
            this.tileControl1.Text = "tileControl1";
            // 
            // xtraUserControl2
            // 
            this.xtraUserControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.xtraUserControl2.Location = new System.Drawing.Point(670, 0);
            this.xtraUserControl2.Name = "xtraUserControl2";
            this.xtraUserControl2.Size = new System.Drawing.Size(50, 401);
            this.xtraUserControl2.TabIndex = 1;
            // 
            // xtraUserControl1
            // 
            this.xtraUserControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xtraUserControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraUserControl1.Name = "xtraUserControl1";
            this.xtraUserControl1.Size = new System.Drawing.Size(50, 401);
            this.xtraUserControl1.TabIndex = 0;
            // 
            // UCBaseRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageSlider1);
            this.Controls.Add(this.tileControl1);
            this.Controls.Add(this.xtraUserControl2);
            this.Controls.Add(this.xtraUserControl1);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "UCBaseRoom";
            this.Size = new System.Drawing.Size(720, 401);
            this.Load += new System.EventHandler(this.UCBaseRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraUserControl xtraUserControl1;
        private DevExpress.XtraEditors.XtraUserControl xtraUserControl2;
        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider1;
    }
}
