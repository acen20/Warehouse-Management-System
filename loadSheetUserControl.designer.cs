namespace Warehouse
{
    partial class loadSheetUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.loadGrid = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Van = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.printBTN = new System.Windows.Forms.Button();
            this.durationPanel = new System.Windows.Forms.Panel();
            this.toDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.fromDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.loadGrid)).BeginInit();
            this.optionsPanel.SuspendLayout();
            this.durationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(816, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 671);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 671);
            this.panel2.TabIndex = 1;
            // 
            // loadGrid
            // 
            this.loadGrid.AllowUserToAddRows = false;
            this.loadGrid.AllowUserToDeleteRows = false;
            this.loadGrid.AllowUserToResizeColumns = false;
            this.loadGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.loadGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.loadGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.loadGrid.BackgroundColor = System.Drawing.Color.White;
            this.loadGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loadGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.loadGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.loadGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.loadGrid.ColumnHeadersHeight = 40;
            this.loadGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.loadGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.Customer,
            this.Address,
            this.Van});
            this.loadGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.loadGrid.EnableHeadersVisualStyles = false;
            this.loadGrid.GridColor = System.Drawing.Color.White;
            this.loadGrid.Location = new System.Drawing.Point(10, 67);
            this.loadGrid.Name = "loadGrid";
            this.loadGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.loadGrid.RowHeadersVisible = false;
            this.loadGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.loadGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.loadGrid.RowTemplate.Height = 38;
            this.loadGrid.RowTemplate.ReadOnly = true;
            this.loadGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.loadGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.loadGrid.Size = new System.Drawing.Size(806, 542);
            this.loadGrid.TabIndex = 35;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            // 
            // Customer
            // 
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // Van
            // 
            this.Van.HeaderText = "Van";
            this.Van.Name = "Van";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(806, 10);
            this.panel3.TabIndex = 34;
            // 
            // optionsPanel
            // 
            this.optionsPanel.BackColor = System.Drawing.Color.White;
            this.optionsPanel.Controls.Add(this.printBTN);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.optionsPanel.Location = new System.Drawing.Point(10, 609);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(806, 62);
            this.optionsPanel.TabIndex = 33;
            // 
            // printBTN
            // 
            this.printBTN.BackColor = System.Drawing.Color.White;
            this.printBTN.Dock = System.Windows.Forms.DockStyle.Right;
            this.printBTN.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.printBTN.FlatAppearance.BorderSize = 2;
            this.printBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Navy;
            this.printBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.printBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printBTN.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBTN.ForeColor = System.Drawing.Color.Indigo;
            this.printBTN.Location = new System.Drawing.Point(686, 0);
            this.printBTN.MaximumSize = new System.Drawing.Size(120, 30);
            this.printBTN.Name = "printBTN";
            this.printBTN.Size = new System.Drawing.Size(120, 30);
            this.printBTN.TabIndex = 4;
            this.printBTN.Text = "Print";
            this.printBTN.UseVisualStyleBackColor = false;
            this.printBTN.MouseEnter += new System.EventHandler(this.printBTN_MouseLeave);
            this.printBTN.MouseLeave += new System.EventHandler(this.printBTN_MouseLeave);
            // 
            // durationPanel
            // 
            this.durationPanel.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.durationPanel.Controls.Add(this.toDate);
            this.durationPanel.Controls.Add(this.fromDate);
            this.durationPanel.Controls.Add(this.pictureBox1);
            this.durationPanel.Controls.Add(this.label1);
            this.durationPanel.Controls.Add(this.panel4);
            this.durationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.durationPanel.Location = new System.Drawing.Point(10, 0);
            this.durationPanel.Name = "durationPanel";
            this.durationPanel.Size = new System.Drawing.Size(806, 57);
            this.durationPanel.TabIndex = 32;
            // 
            // toDate
            // 
            this.toDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toDate.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.toDate.BorderRadius = 0;
            this.toDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDate.ForeColor = System.Drawing.Color.White;
            this.toDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDate.FormatCustom = "dd-MM-yyyy";
            this.toDate.Location = new System.Drawing.Point(479, 17);
            this.toDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(150, 31);
            this.toDate.TabIndex = 36;
            this.toDate.Value = new System.DateTime(2019, 3, 10, 0, 0, 0, 0);
            this.toDate.onValueChanged += new System.EventHandler(this.fromDate_ValueChanged);
            // 
            // fromDate
            // 
            this.fromDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fromDate.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.fromDate.BorderRadius = 0;
            this.fromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDate.ForeColor = System.Drawing.Color.White;
            this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDate.FormatCustom = "dd-MM-yyyy";
            this.fromDate.Location = new System.Drawing.Point(158, 17);
            this.fromDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(150, 31);
            this.fromDate.TabIndex = 36;
            this.fromDate.Value = new System.DateTime(2019, 3, 10, 0, 0, 0, 0);
            this.fromDate.onValueChanged += new System.EventHandler(this.fromDate_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::Warehouse.Properties.Resources.SheetBTN;
            this.pictureBox1.Location = new System.Drawing.Point(713, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 47);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(380, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "To";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(806, 10);
            this.panel4.TabIndex = 0;
            // 
            // loadSheetUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadGrid);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.durationPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "loadSheetUserControl";
            this.Size = new System.Drawing.Size(826, 671);
            this.Load += new System.EventHandler(this.loadSheetUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadGrid)).EndInit();
            this.optionsPanel.ResumeLayout(false);
            this.durationPanel.ResumeLayout(false);
            this.durationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView loadGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Van;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Button printBTN;
        private System.Windows.Forms.Panel durationPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuDatepicker fromDate;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuDatepicker toDate;
    }
}
