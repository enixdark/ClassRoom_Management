namespace CustomItem
{
    partial class Layout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Layout));
            this.header = new DevExpress.XtraEditors.PanelControl();
            this.title = new DevExpress.XtraEditors.LabelControl();
            this.back = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList();
            ((System.ComponentModel.ISupportInitialize)(this.header)).BeginInit();
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.header.Controls.Add(this.title);
            this.header.Controls.Add(this.back);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Padding = new System.Windows.Forms.Padding(24, 36, 0, 15);
            this.header.Size = new System.Drawing.Size(892, 66);
            this.header.TabIndex = 1;
            // 
            // title
            // 
            this.title.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.title.Location = new System.Drawing.Point(50, 3);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(20, 45);
            this.title.TabIndex = 1;
            this.title.Text = "[]";
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(0, 3);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(44, 44);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.back.TabIndex = 0;
            this.back.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "arrowclick.png");
            this.imageList1.Images.SetKeyName(1, "arrowhover.png");
            this.imageList1.Images.SetKeyName(2, "arrownormal.png");
            // 
            // Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.header);
            this.Name = "Layout";
            this.Size = new System.Drawing.Size(892, 536);
            ((System.ComponentModel.ISupportInitialize)(this.header)).EndInit();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl header;
        private DevExpress.XtraEditors.LabelControl title;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.ImageList imageList1;
    }
}
