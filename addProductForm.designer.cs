namespace Warehouse
{
    partial class addProductForm
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
            this.descTB = new System.Windows.Forms.TextBox();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.panel24 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.companyCB = new MetroFramework.Controls.MetroComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crtTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // descTB
            // 
            this.descTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descTB.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descTB.Location = new System.Drawing.Point(85, 135);
            this.descTB.Multiline = true;
            this.descTB.Name = "descTB";
            this.descTB.Size = new System.Drawing.Size(200, 17);
            this.descTB.TabIndex = 5;
            // 
            // nameTB
            // 
            this.nameTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTB.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTB.Location = new System.Drawing.Point(85, 92);
            this.nameTB.Multiline = true;
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(200, 17);
            this.nameTB.TabIndex = 2;
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.Color.Gainsboro;
            this.panel24.Location = new System.Drawing.Point(85, 151);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(200, 2);
            this.panel24.TabIndex = 6;
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.Color.Gainsboro;
            this.panel23.Location = new System.Drawing.Point(85, 108);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(200, 2);
            this.panel23.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Roboto Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 14);
            this.label14.TabIndex = 3;
            this.label14.Text = "Desc.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Roboto Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 14);
            this.label13.TabIndex = 4;
            this.label13.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Company";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(85, 195);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 2);
            this.panel1.TabIndex = 6;
            // 
            // companyCB
            // 
            this.companyCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.companyCB.FormattingEnabled = true;
            this.companyCB.ItemHeight = 23;
            this.companyCB.Items.AddRange(new object[] {
            "Testing",
            "Ahsen",
            "Zaighum"});
            this.companyCB.Location = new System.Drawing.Point(85, 167);
            this.companyCB.Name = "companyCB";
            this.companyCB.Size = new System.Drawing.Size(200, 29);
            this.companyCB.Style = MetroFramework.MetroColorStyle.Blue;
            this.companyCB.TabIndex = 8;
            this.companyCB.Theme = MetroFramework.MetroThemeStyle.Light;
            this.companyCB.UseSelectable = true;
            this.companyCB.UseStyleColors = true;
            this.companyCB.SelectedIndexChanged += new System.EventHandler(this.companyCB_SelectedIndexChanged);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.RoyalBlue;
            this.button8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(20, 267);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(268, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "Save";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Crt";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(85, 232);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 2);
            this.panel2.TabIndex = 7;
            // 
            // crtTB
            // 
            this.crtTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.crtTB.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crtTB.Location = new System.Drawing.Point(85, 216);
            this.crtTB.Multiline = true;
            this.crtTB.Name = "crtTB";
            this.crtTB.Size = new System.Drawing.Size(200, 17);
            this.crtTB.TabIndex = 2;
            // 
            // addProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 310);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.companyCB);
            this.Controls.Add(this.descTB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crtTB);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.panel24);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel23);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Name = "addProductForm";
            this.Text = "Add Product";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.addProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descTB;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox crtTB;
        private MetroFramework.Controls.MetroComboBox companyCB;
    }
}