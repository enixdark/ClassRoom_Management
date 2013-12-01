namespace ClassRoomManagement
{
    partial class TestConnect
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.dbcbbox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.br = new System.Windows.Forms.Button();
            this.txtbrowser = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(87, 61);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(189, 20);
            this.txtuser.TabIndex = 0;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(87, 87);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(189, 20);
            this.txtpass.TabIndex = 1;
            // 
            // dbcbbox
            // 
            this.dbcbbox.FormattingEnabled = true;
            this.dbcbbox.Items.AddRange(new object[] {
            "Oracle",
            "SQLServer",
            "MySql",
            "MongoDB",
            "Access",
            "SQLite"});
            this.dbcbbox.Location = new System.Drawing.Point(87, 113);
            this.dbcbbox.Name = "dbcbbox";
            this.dbcbbox.Size = new System.Drawing.Size(189, 21);
            this.dbcbbox.TabIndex = 2;
            this.dbcbbox.SelectedIndexChanged += new System.EventHandler(this.dbcbbox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "DatabaseEV";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // br
            // 
            this.br.Location = new System.Drawing.Point(281, 154);
            this.br.Name = "br";
            this.br.Size = new System.Drawing.Size(75, 23);
            this.br.TabIndex = 6;
            this.br.Text = "Browser";
            this.br.UseVisualStyleBackColor = true;
            this.br.Visible = false;
            this.br.Click += new System.EventHandler(this.br_Click);
            // 
            // txtbrowser
            // 
            this.txtbrowser.Enabled = false;
            this.txtbrowser.Location = new System.Drawing.Point(87, 154);
            this.txtbrowser.Name = "txtbrowser";
            this.txtbrowser.Size = new System.Drawing.Size(188, 20);
            this.txtbrowser.TabIndex = 7;
            this.txtbrowser.Visible = false;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(200, 189);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 8;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(281, 189);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 9;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "File";
            this.label4.Visible = false;
            // 
            // TestConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 224);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.txtbrowser);
            this.Controls.Add(this.br);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dbcbbox);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtuser);
            this.Name = "TestConnect";
            this.Text = "TestConnect";
            this.Load += new System.EventHandler(this.TestConnect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.ComboBox dbcbbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button br;
        private System.Windows.Forms.TextBox txtbrowser;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label label4;
    }
}