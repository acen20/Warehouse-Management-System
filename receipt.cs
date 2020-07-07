using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuisnessLogicLayer;

namespace Warehouse
{
    public partial class receipt : Form
    {
        public receipt()
        {
            InitializeComponent();
        }

        public string billNo { get; set; }
        public string preparedBy { get; set; }
        public string total { get; set; }
        public string subtotal { get; set; }
        public string address { get; set; }
        public string wht { get; set; }
        public string ntn { get; set; }
        public string discount { get; set; }
        public string dateTime { get; set; }
        public string phone { get; set; }
        public string to { get; set; }

        int count = 0;
        List<item> lst;

        void createDetailPanel(item i)
        {
           
            Label l1=createNameLabel(i.Name+" "+i.desc);
            Label l2=createQtyLabel(i.qtycart + "C, " + i.qtypcs + "P");
            Label l3=createtradeofferLabel(i.tradeOffer);
            Label l4=createtotalLb(i.total.ToString());

            Panel p = new Panel();
            p.Controls.Add(l1);
            p.Controls.Add(l2);
            p.Controls.Add(l3);
            p.Controls.Add(l4);
            p.Dock = DockStyle.Top;
            p.Name = "panel"+ ++count;
            p.Size = new Size(330, 23);

            productsPanel.Controls.Add(p);
        }

        Label createNameLabel(string name)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Font = new Font("Segoe UI Semilight", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label.Location = new Point(5, 6);
            label.MaximumSize = new Size(121, 13);
            label.Name = "label" + ++count;
            label.Text = name;
            return label;
        }
        
        Label createQtyLabel(string qty)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Font = new Font("Segoe UI Semilight", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label.Location = new Point(132, 6);
            label.MaximumSize = new Size(63, 13);
            label.Name = "label" + ++count;
            label.Text = qty;
            return label;
        }

        Label createtradeofferLabel(string tradeOffer)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Font = new Font("Segoe UI Semilight", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label.Location = new Point(212, 6);
            label.MaximumSize = new Size(63, 13);
            label.Name = "label" + ++count;
            label.Text = tradeOffer;
            return label;
        }

        Label createtotalLb(string total)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Font = new Font("Segoe UI Semilight", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label.Location = new Point(275, 6);
            label.MaximumSize = new Size(63, 13);
            label.Name = "label" + ++count;
            label.Text = total;
            return label;
        }

        public void assignList(object list)
        {
            lst = (List<item>)list;
        }

        private void receipt_Load(object sender, EventArgs e)
        {
            productsPanel.HorizontalScroll.Maximum = 0;
            productsPanel.AutoScroll = false;
            productsPanel.VerticalScroll.Visible = false;
            productsPanel.AutoScroll = true;
            billNoLB.Text = billNo;
            preparedByLB.Text = preparedBy;
            whtLB.Text = wht;
            discountLB.Text = discount;
            ntnLB.Text = ntn;
            phoneLB.Text = phone;
            addressLB.Text = address;
            toLB.Text = to;
            subtotalLB.Text = subtotal;
            grandTotalLB.Text = total;
            dateLB.Text = dateTime;

            foreach(item i in lst)
            {
                createDetailPanel(i);
            }
        }

        private void dismissBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void assignDriverBTN_Click(object sender, EventArgs e)
        {
            vansCB.Items.Clear();
            FacadeController f = FacadeController.getFController();
            assignVanPanel.Visible = true;
            DataTable dt = f.getAllVans().Tables["myTable"];
            foreach(DataRow r in dt.Rows)
            {
                vansCB.Items.Add(r["Vehicle no"].ToString());
            }
        }

        private void okBTN_Click(object sender, EventArgs e)
        {
            if(vansCB.Text!="")
            {
                FacadeController f = FacadeController.getFController();
                f.updateSalesman(billNo, vansCB.Text);
                Close();
            }
        }
    }
}
