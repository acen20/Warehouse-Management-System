using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuisnessLogicLayer;
using System.Globalization;

namespace Warehouse
{
    public partial class notifications : UserControl
    {
        public notifications()
        {
            InitializeComponent();
        }

        public int fillPanel()
        {
            Notification.lst.Clear();
            paymentsNotifications();
            notificationsFlow.Controls.Clear();
            if (Notification.lst.Count > 0)
                foreach (Notification N in Notification.lst)
                {
                    createNotification(N);
                }
            else
                notificationsFlow.Controls.Add(createEmptyMessage());
            return Notification.lst.Count;
        }

        void createNotification(Notification N)
        {
            Notification.count++;
            Panel notify = createNotificationPanel(N);
            Panel logo=createNotificationLogo(N);
            Label title = createTitleLB(N);
            Label desc = createDescLB(N);
            Label time = createTimeLB(N);
            notify.Controls.Add(logo);
            notify.Controls.Add(title);
            notify.Controls.Add(desc);
            notify.Controls.Add(time);
            notificationsFlow.Controls.Add(notify);
        }

        Panel createNotificationPanel(Notification N)
        {
            Panel p = new Panel();
            p.BackgroundImage = global::Warehouse.Properties.Resources.notifybar2;
            p.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            p.Location = new System.Drawing.Point(3, 3);
            p.Name = "notificationBar"+Notification.count;
            p.Size = new System.Drawing.Size(464, 77);
            p.TabIndex = 1;
            return p;
        }

        Label createTitleLB(Notification N)
        {
            Label l = new Label();
            l.AutoSize = true;
            l.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            l.ForeColor = System.Drawing.Color.MidnightBlue;
            l.Location = new System.Drawing.Point(71, 13);
            l.Name = "nameLB"+ Notification.count;
            l.Size = new System.Drawing.Size(75, 15);
            l.TabIndex = 1;
            l.Text = N.title;
            return l;
        }

        Label createTimeLB(Notification N)
        {
            Label l = new Label();
            l.AutoSize = true;
            l.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            l.ForeColor = System.Drawing.Color.Gray;
            l.Location = new System.Drawing.Point(408, 13);
            l.Name = "timeLB"+ Notification.count;
            l.Size = new System.Drawing.Size(53, 15);
            l.TabIndex = 1;
            l.Text = DateTime.Now.ToString("hh:mm tt");
            return l;
        }

        Label createDescLB(Notification N)
        {
            Label l = new Label();
            l.AutoSize = false ;
            l.MaximumSize = new Size(359, 36);
            l.Font = new Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            l.ForeColor = Color.Gray;
            l.Location = new Point(71, 32);
            l.Name = "descLB"+ Notification.count;
            l.Size = new Size(359, 36);
            l.TabIndex = 1;
            l.Text = N.description;
            return l;
        }

        Panel createNotificationLogo(Notification N)
        {
            Panel p = new Panel();
            p.BackColor = Color.Transparent;
            if(N.type=="user")
                p.BackgroundImage = Properties.Resources.user1;
            else if(N.type=="payment")
                p.BackgroundImage = Properties.Resources.moneyLogo;
            p.BackgroundImageLayout = ImageLayout.Zoom;
            p.Dock = DockStyle.Left;
            p.Location = new Point(0, 0);
            p.Name = "notificationLogo"+ Notification.count;
            p.Size = new Size(55, 77);
            p.TabIndex = 0;
            return p;
        }

        void paymentsNotifications()
        {
            FacadeController f = FacadeController.getFController();
            DataTable dt = f.getDuePayments();
            foreach(DataRow r in dt.Rows)
            {
                DateTime date=DateTime.ParseExact(r["date"].ToString(), "dd-MM-yyyy hh:mm tt", CultureInfo.InvariantCulture);
                int numdays = (DateTime.Now - date).Days;
                if (numdays>=7)
                {
                    int amount = int.Parse(r["amount"].ToString());
                    int total = int.Parse(r["total"].ToString());
                    int remaining = total - amount;
                    string phone = r["phone"].ToString();
                    Notification N = new Notification();
                    N.type = "payment";
                    N.title = r["name"].ToString()+"'s payment is due for "+numdays+" days";
                    N.description = "For Bill " + r["billno"].ToString() + ", Total was " + total + " and amount" +
                        " received was " + amount+", Remaining Amount is "+remaining+" Contact "+phone;
                    Notification.lst.Add(N);
                }
            }
        }

        Label createEmptyMessage()
        {
            Label l = new Label();
            l.Dock = DockStyle.Fill;
            l.AutoSize = false;
            l.Name = "emptyMessage";
            l.Text = "No Notifications right Now";
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Font = new Font("Century Gothic", 48.00F, FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            l.ForeColor = Color.Gainsboro;
            l.BringToFront();
            return l;
        }
    }
}
