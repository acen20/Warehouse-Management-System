using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace Warehouse
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        bool move;
        int mouseX;
        int mouseY;
        string activeMenu = "dashboard";

        private void movementPanel_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void movementPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
                this.SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
        }

        private void movementPanel_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void Home_Load(object sender, EventArgs e)
        {
            updateNotifications();
            dashboard1.BringToFront();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            if (p.Tag.ToString() != activeMenu)
                p.BackColor = Color.FromArgb(30, 40, 44);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            if (p.Tag.ToString() != activeMenu)
                p.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void recordBTN_Click(object sender, EventArgs e)
        {
            changeColor(recordBTN.Tag.ToString());
            records1.BringToFront();
        }

        private void dashboardBTN_Click(object sender, EventArgs e)
        {
            changeColor(dashboardBTN.Tag.ToString());
            dashboard1.BringToFront();
        }

        void changeColor(string active)
        {
            foreach (Control c in panel2.Controls)
            {
                if (c is PictureBox && c.Tag.ToString() == active)
                {
                    c.BackColor = Color.FromArgb(30, 40, 44);
                    activeMenu = c.Tag.ToString();
                }
                else
                    c.BackColor = Color.Transparent;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void salesBTN_Click(object sender, EventArgs e)
        {
            changeColor(salesBTN.Tag.ToString());
            sales1.BringToFront();
            sales1.setProgress();
        }

        private void loadSheetBTN_Click(object sender, EventArgs e)
        {
            changeColor(loadSheetBTN.Tag.ToString());
            loadSheetUserControl1.BringToFront();
            loadSheetUserControl1.refreshGrid();
        }

        private void notificationButton_Click(object sender, EventArgs e)
        {
            if (notifications1.Visible == true)
                notifications1.Visible = false;
            else
            {
                notifications1.Visible = true;
                notifications1.BringToFront();
                updateNotifications();
            }
        }

        void updateNotifications()
        {
            if (notifications1.fillPanel() > 0)
            {
                notifNumLB.Text = notifications1.fillPanel().ToString();
            }
            else
                notifNumLB.Text = "0";
        }

        private void creditReportBTN_Click(object sender, EventArgs e)
        {
            changeColor(creditReportBTN.Tag.ToString());
            creditReport1.BringToFront();
            creditReport1.refresh();
        }

        private void PLBTN_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Buy full version to avail this feature", "Stop!", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
        }
    }
}
