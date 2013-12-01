namespace CustomItem.Module
{
    partial class UCExcel
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
            this.layout2 = new CustomItem.CustomDrawModule();
            this.SuspendLayout();
            // 
            // layout2
            // 
            this.layout2.AutoMergeRibbon = true;
            this.layout2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout2.Location = new System.Drawing.Point(0, 0);
            this.layout2.Name = "layout2";
            this.layout2.RibbonMenuManager = null;
            this.layout2.Size = new System.Drawing.Size(720, 480);
            this.layout2.TabIndex = 0;
            this.layout2.TutorialName = "";
            this.layout2.Load += new System.EventHandler(this.layout2_Load);
            // 
            // UCExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.layout2);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "UCExcel";
            this.ResumeLayout(false);

        }

        #endregion

        
        private CustomItem.CustomDrawModule layout2;



    }
}
