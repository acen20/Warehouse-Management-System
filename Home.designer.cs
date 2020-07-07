namespace Warehouse
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.movementPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuPanel = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PLBTN = new System.Windows.Forms.PictureBox();
            this.creditReportBTN = new System.Windows.Forms.PictureBox();
            this.loadSheetBTN = new System.Windows.Forms.PictureBox();
            this.salesBTN = new System.Windows.Forms.PictureBox();
            this.recordBTN = new System.Windows.Forms.PictureBox();
            this.dashboardBTN = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.notifNumLB = new System.Windows.Forms.Label();
            this.notificationButton = new System.Windows.Forms.PictureBox();
            this.notifications1 = new Warehouse.notifications();
            this.loadSheetUserControl1 = new Warehouse.loadSheetUserControl();
            this.sales1 = new Warehouse.Sales();
            this.records1 = new Warehouse.Records();
            this.dashboard1 = new Warehouse.dashboard();
            this.creditReport1 = new Warehouse.creditReport();
            this.movementPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PLBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditReportBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadSheetBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardBTN)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationButton)).BeginInit();
            this.SuspendLayout();
            // 
            // movementPanel
            // 
            this.movementPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(188)))), ((int)(((byte)(233)))));
            this.movementPanel.Controls.Add(this.label3);
            this.movementPanel.Controls.Add(this.label2);
            this.movementPanel.Controls.Add(this.label1);
            this.movementPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.movementPanel.Location = new System.Drawing.Point(0, 0);
            this.movementPanel.Name = "movementPanel";
            this.movementPanel.Size = new System.Drawing.Size(1080, 19);
            this.movementPanel.TabIndex = 1;
            this.movementPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.movementPanel_MouseDown);
            this.movementPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.movementPanel_MouseMove);
            this.movementPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.movementPanel_MouseUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Goldenrod;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.label3.Location = new System.Drawing.Point(975, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "─";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(1010, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "☐";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(1045, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.menuPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuPanel.BackgroundImage")));
            this.menuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuPanel.Controls.Add(this.panel2);
            this.menuPanel.Controls.Add(this.panel1);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.menuPanel.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.menuPanel.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.menuPanel.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.menuPanel.Location = new System.Drawing.Point(0, 19);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Quality = 10;
            this.menuPanel.Size = new System.Drawing.Size(112, 661);
            this.menuPanel.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.PLBTN);
            this.panel2.Controls.Add(this.creditReportBTN);
            this.panel2.Controls.Add(this.loadSheetBTN);
            this.panel2.Controls.Add(this.salesBTN);
            this.panel2.Controls.Add(this.recordBTN);
            this.panel2.Controls.Add(this.dashboardBTN);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(112, 480);
            this.panel2.TabIndex = 9;
            // 
            // PLBTN
            // 
            this.PLBTN.BackColor = System.Drawing.Color.Transparent;
            this.PLBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PLBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.PLBTN.Image = ((System.Drawing.Image)(resources.GetObject("PLBTN.Image")));
            this.PLBTN.Location = new System.Drawing.Point(0, 388);
            this.PLBTN.Name = "PLBTN";
            this.PLBTN.Size = new System.Drawing.Size(112, 70);
            this.PLBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PLBTN.TabIndex = 5;
            this.PLBTN.TabStop = false;
            this.PLBTN.Tag = "profitloss";
            this.PLBTN.Click += new System.EventHandler(this.PLBTN_Click);
            this.PLBTN.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.PLBTN.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // creditReportBTN
            // 
            this.creditReportBTN.BackColor = System.Drawing.Color.Transparent;
            this.creditReportBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.creditReportBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.creditReportBTN.Image = ((System.Drawing.Image)(resources.GetObject("creditReportBTN.Image")));
            this.creditReportBTN.Location = new System.Drawing.Point(0, 318);
            this.creditReportBTN.Name = "creditReportBTN";
            this.creditReportBTN.Size = new System.Drawing.Size(112, 70);
            this.creditReportBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.creditReportBTN.TabIndex = 6;
            this.creditReportBTN.TabStop = false;
            this.creditReportBTN.Tag = "creditreport";
            this.creditReportBTN.Click += new System.EventHandler(this.creditReportBTN_Click);
            this.creditReportBTN.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.creditReportBTN.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // loadSheetBTN
            // 
            this.loadSheetBTN.BackColor = System.Drawing.Color.Transparent;
            this.loadSheetBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadSheetBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadSheetBTN.Image = ((System.Drawing.Image)(resources.GetObject("loadSheetBTN.Image")));
            this.loadSheetBTN.Location = new System.Drawing.Point(0, 248);
            this.loadSheetBTN.Name = "loadSheetBTN";
            this.loadSheetBTN.Size = new System.Drawing.Size(112, 70);
            this.loadSheetBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadSheetBTN.TabIndex = 7;
            this.loadSheetBTN.TabStop = false;
            this.loadSheetBTN.Tag = "loadsheet";
            this.loadSheetBTN.Click += new System.EventHandler(this.loadSheetBTN_Click);
            this.loadSheetBTN.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.loadSheetBTN.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // salesBTN
            // 
            this.salesBTN.BackColor = System.Drawing.Color.Transparent;
            this.salesBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.salesBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.salesBTN.Image = ((System.Drawing.Image)(resources.GetObject("salesBTN.Image")));
            this.salesBTN.Location = new System.Drawing.Point(0, 178);
            this.salesBTN.Name = "salesBTN";
            this.salesBTN.Size = new System.Drawing.Size(112, 70);
            this.salesBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.salesBTN.TabIndex = 8;
            this.salesBTN.TabStop = false;
            this.salesBTN.Tag = "sales";
            this.salesBTN.Click += new System.EventHandler(this.salesBTN_Click);
            this.salesBTN.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.salesBTN.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // recordBTN
            // 
            this.recordBTN.BackColor = System.Drawing.Color.Transparent;
            this.recordBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recordBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.recordBTN.Image = ((System.Drawing.Image)(resources.GetObject("recordBTN.Image")));
            this.recordBTN.Location = new System.Drawing.Point(0, 108);
            this.recordBTN.Name = "recordBTN";
            this.recordBTN.Size = new System.Drawing.Size(112, 70);
            this.recordBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.recordBTN.TabIndex = 12;
            this.recordBTN.TabStop = false;
            this.recordBTN.Tag = "records";
            this.recordBTN.Click += new System.EventHandler(this.recordBTN_Click);
            this.recordBTN.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.recordBTN.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // dashboardBTN
            // 
            this.dashboardBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.dashboardBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboardBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashboardBTN.Image = ((System.Drawing.Image)(resources.GetObject("dashboardBTN.Image")));
            this.dashboardBTN.Location = new System.Drawing.Point(0, 38);
            this.dashboardBTN.Name = "dashboardBTN";
            this.dashboardBTN.Size = new System.Drawing.Size(112, 70);
            this.dashboardBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dashboardBTN.TabIndex = 11;
            this.dashboardBTN.TabStop = false;
            this.dashboardBTN.Tag = "dashboard";
            this.dashboardBTN.Click += new System.EventHandler(this.dashboardBTN_Click);
            this.dashboardBTN.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.dashboardBTN.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(112, 38);
            this.panel3.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.notifNumLB);
            this.panel1.Controls.Add(this.notificationButton);
            this.panel1.Location = new System.Drawing.Point(23, 501);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 100);
            this.panel1.TabIndex = 11;
            // 
            // notifNumLB
            // 
            this.notifNumLB.AutoSize = true;
            this.notifNumLB.BackColor = System.Drawing.Color.Red;
            this.notifNumLB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.notifNumLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifNumLB.ForeColor = System.Drawing.Color.White;
            this.notifNumLB.Location = new System.Drawing.Point(34, 20);
            this.notifNumLB.Name = "notifNumLB";
            this.notifNumLB.Padding = new System.Windows.Forms.Padding(4);
            this.notifNumLB.Size = new System.Drawing.Size(22, 23);
            this.notifNumLB.TabIndex = 10;
            this.notifNumLB.Text = "0";
            this.notifNumLB.Click += new System.EventHandler(this.notificationButton_Click);
            // 
            // notificationButton
            // 
            this.notificationButton.BackColor = System.Drawing.Color.Transparent;
            this.notificationButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("notificationButton.BackgroundImage")));
            this.notificationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.notificationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.notificationButton.Location = new System.Drawing.Point(16, 27);
            this.notificationButton.Name = "notificationButton";
            this.notificationButton.Size = new System.Drawing.Size(35, 37);
            this.notificationButton.TabIndex = 9;
            this.notificationButton.TabStop = false;
            this.notificationButton.Tag = "notification";
            this.notificationButton.Click += new System.EventHandler(this.notificationButton_Click);
            // 
            // notifications1
            // 
            this.notifications1.AutoSize = true;
            this.notifications1.BackColor = System.Drawing.Color.White;
            this.notifications1.Location = new System.Drawing.Point(112, 63);
            this.notifications1.Name = "notifications1";
            this.notifications1.Size = new System.Drawing.Size(510, 509);
            this.notifications1.TabIndex = 7;
            this.notifications1.Visible = false;
            // 
            // loadSheetUserControl1
            // 
            this.loadSheetUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadSheetUserControl1.Location = new System.Drawing.Point(0, 0);
            this.loadSheetUserControl1.Name = "loadSheetUserControl1";
            this.loadSheetUserControl1.Size = new System.Drawing.Size(1080, 680);
            this.loadSheetUserControl1.TabIndex = 6;
            // 
            // sales1
            // 
            this.sales1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sales1.Location = new System.Drawing.Point(0, 0);
            this.sales1.Name = "sales1";
            this.sales1.Size = new System.Drawing.Size(1080, 680);
            this.sales1.TabIndex = 5;
            // 
            // records1
            // 
            this.records1.BackColor = System.Drawing.Color.White;
            this.records1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.records1.Location = new System.Drawing.Point(0, 0);
            this.records1.Name = "records1";
            this.records1.Size = new System.Drawing.Size(1080, 680);
            this.records1.TabIndex = 4;
            // 
            // dashboard1
            // 
            this.dashboard1.AutoSize = true;
            this.dashboard1.BackColor = System.Drawing.Color.White;
            this.dashboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboard1.Location = new System.Drawing.Point(112, 19);
            this.dashboard1.Name = "dashboard1";
            this.dashboard1.Size = new System.Drawing.Size(968, 661);
            this.dashboard1.TabIndex = 3;
            // 
            // creditReport1
            // 
            this.creditReport1.BackColor = System.Drawing.Color.White;
            this.creditReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creditReport1.Location = new System.Drawing.Point(0, 0);
            this.creditReport1.Name = "creditReport1";
            this.creditReport1.Size = new System.Drawing.Size(1080, 680);
            this.creditReport1.TabIndex = 8;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 680);
            this.Controls.Add(this.notifications1);
            this.Controls.Add(this.dashboard1);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.movementPanel);
            this.Controls.Add(this.creditReport1);
            this.Controls.Add(this.loadSheetUserControl1);
            this.Controls.Add(this.sales1);
            this.Controls.Add(this.records1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.movementPanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PLBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditReportBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadSheetBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardBTN)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel movementPanel;
        private Bunifu.Framework.UI.BunifuGradientPanel menuPanel;
        private dashboard dashboard1;
        private System.Windows.Forms.Label label1;
        private Records records1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Sales sales1;
        private loadSheetUserControl loadSheetUserControl1;
        private System.Windows.Forms.PictureBox notificationButton;
        private System.Windows.Forms.Label notifNumLB;
        private System.Windows.Forms.Panel panel1;
        private notifications notifications1;
        private creditReport creditReport1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PLBTN;
        private System.Windows.Forms.PictureBox creditReportBTN;
        private System.Windows.Forms.PictureBox loadSheetBTN;
        private System.Windows.Forms.PictureBox salesBTN;
        private System.Windows.Forms.PictureBox recordBTN;
        private System.Windows.Forms.PictureBox dashboardBTN;
        private System.Windows.Forms.Panel panel3;
    }
}