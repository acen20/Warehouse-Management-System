namespace Warehouse
{
    partial class Records
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
            this.colorline2 = new System.Windows.Forms.Panel();
            this.colorLine = new System.Windows.Forms.Panel();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchBTN = new System.Windows.Forms.PictureBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.searchTB = new System.Windows.Forms.TextBox();
            this.productsButton = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.VanButton = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.vanUserControl1 = new Warehouse.vanUserControl();
            this.manageProducts1 = new Warehouse.manageProducts();
            this.colorLine.SuspendLayout();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchBTN)).BeginInit();
            this.productsButton.SuspendLayout();
            this.VanButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorline2
            // 
            this.colorline2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.colorline2.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorline2.Location = new System.Drawing.Point(0, 0);
            this.colorline2.Name = "colorline2";
            this.colorline2.Size = new System.Drawing.Size(5, 789);
            this.colorline2.TabIndex = 5;
            // 
            // colorLine
            // 
            this.colorLine.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.colorLine.Controls.Add(this.searchPanel);
            this.colorLine.Controls.Add(this.productsButton);
            this.colorLine.Controls.Add(this.VanButton);
            this.colorLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorLine.Location = new System.Drawing.Point(5, 0);
            this.colorLine.Name = "colorLine";
            this.colorLine.Size = new System.Drawing.Size(953, 149);
            this.colorLine.TabIndex = 10;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.searchBTN);
            this.searchPanel.Controls.Add(this.panel11);
            this.searchPanel.Controls.Add(this.label28);
            this.searchPanel.Controls.Add(this.button3);
            this.searchPanel.Controls.Add(this.searchTB);
            this.searchPanel.Location = new System.Drawing.Point(710, 115);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(240, 34);
            this.searchPanel.TabIndex = 19;
            // 
            // searchBTN
            // 
            this.searchBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchBTN.Image = global::Warehouse.Properties.Resources.Asset_121;
            this.searchBTN.Location = new System.Drawing.Point(204, 3);
            this.searchBTN.Name = "searchBTN";
            this.searchBTN.Size = new System.Drawing.Size(19, 20);
            this.searchBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchBTN.TabIndex = 6;
            this.searchBTN.TabStop = false;
            this.searchBTN.Click += new System.EventHandler(this.searchBTN_Click);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel11.Location = new System.Drawing.Point(62, 21);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(136, 1);
            this.panel11.TabIndex = 1;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(3, 6);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 20);
            this.label28.TabIndex = 0;
            this.label28.Text = "Search";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(738, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // searchTB
            // 
            this.searchTB.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.searchTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTB.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.searchTB.Location = new System.Drawing.Point(62, 4);
            this.searchTB.Multiline = true;
            this.searchTB.Name = "searchTB";
            this.searchTB.Size = new System.Drawing.Size(136, 17);
            this.searchTB.TabIndex = 2;
            this.searchTB.TextChanged += new System.EventHandler(this.searchTB_TextChanged);
            // 
            // productsButton
            // 
            this.productsButton.AutoSize = true;
            this.productsButton.BackgroundImage = global::Warehouse.Properties.Resources.manage_Inventory;
            this.productsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.productsButton.Controls.Add(this.label8);
            this.productsButton.Controls.Add(this.label7);
            this.productsButton.Controls.Add(this.label2);
            this.productsButton.Controls.Add(this.label1);
            this.productsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.productsButton.Location = new System.Drawing.Point(5, 3);
            this.productsButton.Name = "productsButton";
            this.productsButton.Size = new System.Drawing.Size(254, 143);
            this.productsButton.TabIndex = 3;
            this.productsButton.Tag = "P";
            this.productsButton.Click += new System.EventHandler(this.productsButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Roboto Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(78, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 25);
            this.label8.TabIndex = 1;
            this.label8.Text = "745";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Roboto Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(15, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(80, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Products";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Categories";
            // 
            // VanButton
            // 
            this.VanButton.AutoSize = true;
            this.VanButton.BackgroundImage = global::Warehouse.Properties.Resources.Manage_Van;
            this.VanButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.VanButton.Controls.Add(this.label4);
            this.VanButton.Controls.Add(this.label3);
            this.VanButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VanButton.Location = new System.Drawing.Point(334, 3);
            this.VanButton.Name = "VanButton";
            this.VanButton.Size = new System.Drawing.Size(254, 143);
            this.VanButton.TabIndex = 3;
            this.VanButton.Tag = "V";
            this.VanButton.Click += new System.EventHandler(this.VanButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Roboto Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightGreen;
            this.label4.Location = new System.Drawing.Point(17, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "15";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(19, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Vans";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(958, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 789);
            this.panel1.TabIndex = 6;
            // 
            // vanUserControl1
            // 
            this.vanUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vanUserControl1.Location = new System.Drawing.Point(5, 149);
            this.vanUserControl1.Name = "vanUserControl1";
            this.vanUserControl1.Size = new System.Drawing.Size(953, 640);
            this.vanUserControl1.TabIndex = 12;
            // 
            // manageProducts1
            // 
            this.manageProducts1.AutoSize = true;
            this.manageProducts1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageProducts1.Location = new System.Drawing.Point(5, 149);
            this.manageProducts1.Name = "manageProducts1";
            this.manageProducts1.Size = new System.Drawing.Size(953, 640);
            this.manageProducts1.TabIndex = 11;
            // 
            // Records
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.vanUserControl1);
            this.Controls.Add(this.manageProducts1);
            this.Controls.Add(this.colorLine);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.colorline2);
            this.Name = "Records";
            this.Size = new System.Drawing.Size(968, 789);
            this.Load += new System.EventHandler(this.Records_Load);
            this.colorLine.ResumeLayout(false);
            this.colorLine.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchBTN)).EndInit();
            this.productsButton.ResumeLayout(false);
            this.productsButton.PerformLayout();
            this.VanButton.ResumeLayout(false);
            this.VanButton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel colorline2;
        private System.Windows.Forms.Panel VanButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel productsButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel colorLine;
        private manageProducts manageProducts1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox searchTB;
        private vanUserControl vanUserControl1;
        private System.Windows.Forms.PictureBox searchBTN;
    }
}
