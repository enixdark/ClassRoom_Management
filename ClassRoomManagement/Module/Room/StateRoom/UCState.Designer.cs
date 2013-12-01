namespace CustomItem.Module
{
    partial class UCState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCState));
            this.mainlayout = new DevExpress.XtraEditors.PanelControl();
            this.xtraUserControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.v = new DevExpress.XtraEditors.RadioGroup();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.del = new DevExpress.XtraEditors.LabelControl();
            this.update = new DevExpress.XtraEditors.LabelControl();
            this.add = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainlayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraUserControl1)).BeginInit();
            this.xtraUserControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // mainlayout
            // 
            this.mainlayout.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.mainlayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainlayout.Location = new System.Drawing.Point(0, 35);
            this.mainlayout.Name = "mainlayout";
            this.mainlayout.Size = new System.Drawing.Size(720, 401);
            this.mainlayout.TabIndex = 3;
            this.mainlayout.Paint += new System.Windows.Forms.PaintEventHandler(this.mainlayout_Paint);
            // 
            // xtraUserControl1
            // 
            this.xtraUserControl1.Controls.Add(this.panelControl1);
            this.xtraUserControl1.Controls.Add(this.v);
            this.xtraUserControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraUserControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraUserControl1.Name = "xtraUserControl1";
            this.xtraUserControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(258, 296, 250, 350);
            this.xtraUserControl1.Root = this.Root;
            this.xtraUserControl1.Size = new System.Drawing.Size(720, 35);
            this.xtraUserControl1.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(565, 31);
            this.panelControl1.TabIndex = 5;
            // 
            // v
            // 
            this.v.AutoSizeInLayoutControl = true;
            this.v.Location = new System.Drawing.Point(571, 2);
            this.v.Name = "v";
            this.v.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.v.Properties.Appearance.Options.UseBackColor = true;
            this.v.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.v.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Advance"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Standard")});
            this.v.Size = new System.Drawing.Size(147, 31);
            this.v.StyleController = this.xtraUserControl1;
            this.v.TabIndex = 4;
            this.v.SelectedIndexChanged += new System.EventHandler(this.v_SelectedIndexChanged_1);
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(720, 35);
            this.Root.Text = "Root";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.v;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(569, 0);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(151, 17);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(151, 35);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.panelControl1;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(569, 35);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panelControl3);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.layoutControl1.Location = new System.Drawing.Point(0, 436);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(296, 205, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(720, 44);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.del);
            this.panelControl3.Controls.Add(this.update);
            this.panelControl3.Controls.Add(this.add);
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(716, 40);
            this.panelControl3.TabIndex = 0;
            // 
            // del
            // 
            this.del.Appearance.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Bold);
            this.del.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("del.Appearance.HoverImage")));
            this.del.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("del.Appearance.Image")));
            this.del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.del.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.del.Dock = System.Windows.Forms.DockStyle.Right;
            this.del.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.del.LineColor = System.Drawing.Color.Transparent;
            this.del.LineStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.del.LineVisible = true;
            this.del.Location = new System.Drawing.Point(495, 0);
            this.del.Name = "del";
            this.del.Padding = new System.Windows.Forms.Padding(5);
            this.del.Size = new System.Drawing.Size(74, 40);
            this.del.StyleController = this.layoutControl1;
            this.del.TabIndex = 9;
            this.del.Text = "Delete";
            // 
            // update
            // 
            this.update.Appearance.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Bold);
            this.update.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("update.Appearance.HoverImage")));
            this.update.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("update.Appearance.Image")));
            this.update.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.update.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.update.Dock = System.Windows.Forms.DockStyle.Right;
            this.update.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.update.LineColor = System.Drawing.Color.Transparent;
            this.update.LineStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.update.LineVisible = true;
            this.update.Location = new System.Drawing.Point(569, 0);
            this.update.Name = "update";
            this.update.Padding = new System.Windows.Forms.Padding(5);
            this.update.Size = new System.Drawing.Size(80, 40);
            this.update.StyleController = this.layoutControl1;
            this.update.TabIndex = 9;
            this.update.Text = "Update";
            // 
            // add
            // 
            this.add.Appearance.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Bold);
            this.add.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("add.Appearance.HoverImage")));
            this.add.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("add.Appearance.Image")));
            this.add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.add.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.add.Dock = System.Windows.Forms.DockStyle.Right;
            this.add.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.add.LineColor = System.Drawing.Color.Transparent;
            this.add.LineStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.add.LineVisible = true;
            this.add.Location = new System.Drawing.Point(649, 0);
            this.add.Name = "add";
            this.add.Padding = new System.Windows.Forms.Padding(5);
            this.add.Size = new System.Drawing.Size(67, 40);
            this.add.StyleController = this.layoutControl1;
            this.add.TabIndex = 8;
            this.add.Text = "Insert";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(720, 44);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.panelControl3;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(720, 44);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // UCState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainlayout);
            this.Controls.Add(this.xtraUserControl1);
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "UCState";
            this.Load += new System.EventHandler(this.UCState_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainlayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraUserControl1)).EndInit();
            this.xtraUserControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl mainlayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControl xtraUserControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.RadioGroup v;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.LabelControl del;
        private DevExpress.XtraEditors.LabelControl update;
        private DevExpress.XtraEditors.LabelControl add;


    }
}
