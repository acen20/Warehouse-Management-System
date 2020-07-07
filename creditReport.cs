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

namespace Warehouse
{
    public partial class creditReport : UserControl
    {
        public creditReport()
        {
            InitializeComponent();
        }

        List<Payment> lst = new List<Payment>();
        List<Payment> unpaid = new List<Payment>();
        List<Payment> paid = new List<Payment>();
        List<Payment> all = new List<Payment>();
        DataTable dt = new DataTable();

        int display = 1;
        int total = 0;
        int amount = 0;
        int remaining = 0;
        
        public void refresh()
        {
            lst.Clear();
            all.Clear();
            unpaid.Clear();
            paid.Clear();
            getPayments();
        }

        void getPayments()
        {
            FacadeController f = FacadeController.getFController();
            dt=f.getPayments();
            lst.Clear();
            foreach(DataRow r in dt.Rows)
            {
                addToList(r);
            }
            if (display == 1)
                getAllPayments();
            else if (display == 2)
                getAllUnpaidPayments();
            else if (display == 3)
                getAllPaid();
        }

        void getAllUnpaidPayments()
        {
            DataTable dt = new DataTable();
            setColumnName(dt);
            foreach (Payment p in lst)
                if(p.total>p.amount)
                    unpaid.Add(p);
            dt = addRows(dt, unpaid);
            paymentGrid.DataSource = dt;
        }

        void getAllPaid()
        {
            DataTable dt = new DataTable();
            setColumnName(dt);
            foreach (Payment p in lst)
                if (p.total == p.amount)
                    paid.Add(p);
            dt=addRows(dt, paid);
            paymentGrid.DataSource = dt;
        }

        void getAllPayments()
        {
            DataTable dt = new DataTable();
            setColumnName(dt);
            foreach (Payment p in lst)
                    all.Add(p);
            dt = addRows(dt, all);
            paymentGrid.DataSource = dt;
        }

        DataTable addRows(DataTable dt, List<Payment> p)
        {
            foreach(Payment pay in p)
            {
                DataRow r = dt.NewRow();
                r["billno"] = pay.billno;
                r["mode"] = pay.mode;
                r["total"] = pay.total;
                r["amount"] = pay.amount;
                r["n5000"] = pay.n5000;
                r["n1000"] = pay.n1000;
                r["n500"] = pay.n500;
                r["n100"] = pay.n100;
                r["other"] = pay.other;
                r["account"] = pay.account;
                r["bank"] = pay.bank;
                r["name"] = pay.name;
                dt.Rows.Add(r);
            }
            return dt;
        }

        void changeGridColors(string state)
        {
            if (state == "unselected")
            {
                paymentGrid.DefaultCellStyle.SelectionBackColor = Color.White;
                paymentGrid.DefaultCellStyle.SelectionForeColor = Color.DarkGray;
            }

            if (state == "selected")
            {
                paymentGrid.DefaultCellStyle.SelectionBackColor = Color.Gold;
                paymentGrid.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            }

        }

        void setColumnName(DataTable dt)
        {
            foreach (DataColumn c in this.dt.Columns)
            {
                if(c.ColumnName.ToLower()!="ID".ToLower())
                    dt.Columns.Add(c.ColumnName);
            }
        }

        Payment addToList(DataRow r)
        {
            Payment p = new Payment();
            p.name = r["name"].ToString();
            p.id = int.Parse(r["id"].ToString());
            p.billno = r["billno"].ToString();
            p.mode = r["mode"].ToString();
            p.total = int.Parse(r["total"].ToString());
            p.amount = int.Parse(r["amount"].ToString());
            p.n5000 = (r["n5000"].ToString());
            p.n1000 = (r["n1000"].ToString());
            p.n500 = (r["n500"].ToString());
            p.n100 = (r["n100"].ToString());
            p.other = (r["other"].ToString());
            p.account = r["account"].ToString();
            p.bank = r["bank"].ToString();
            lst.Add(p);
            return p;
        }

        private void creditReport_Load(object sender, EventArgs e)
        {
            paymentGrid.Columns.Clear();
            changeGridColors("selected");
        }

        private void unpaidBTN_Click(object sender, EventArgs e)
        {
            unpaid.Clear();
            display = 2;
            unpaidBTN.Controls.Add(activeIndicator);
            getPayments();
        }

        private void paidBTN_Click(object sender, EventArgs e)
        {
            paid.Clear();
            display = 3;
            paidBTN.Controls.Add(activeIndicator);
            getPayments();
        }

        private void allBTN_Click(object sender, EventArgs e)
        {
            all.Clear();
            display = 1;
            allBTN.Controls.Add(activeIndicator);
            getPayments();
        }

        private void paymentGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            updateAmounts();
            total= int.Parse(paymentGrid.SelectedRows[0].Cells["total"].Value.ToString());
            amount= int.Parse(paymentGrid.SelectedRows[0].Cells["amount"].Value.ToString());
            remaining = total - amount;
            billNoLB.Text = paymentGrid.SelectedRows[0].Cells["billno"].Value.ToString();
            remainingLB.Text = remaining.ToString();
            paidTB.Maximum = remaining;
        }

        private void paymentGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            changeGridColors("selected");
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if(paidTB.Value>0 && paymentGrid.SelectedRows.Count==1)
            {
                FacadeController f = FacadeController.getFController();
                amount = amount + int.Parse(paidTB.Value.ToString());
                remaining = total - amount;
                f.updatePayment(billNoLB.Text, amount);
                remainingLB.Text = remaining.ToString();
                MetroFramework.MetroMessageBox.Show(this,"Amount Updated. Remaining amount is " + remaining);
                refresh();
            }

        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
           
        }

        void updateAmounts()
        {
            total = 0;
            remaining = 0;
            amount = 0;
            remainingLB.Text = "-";
            paidTB.Value = 0;
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            if (searchTB.Text != "")
            {
                paymentGrid.ClearSelection();
                for (int i = 0; i < paymentGrid.Rows.Count; i++)
                {
                    if (paymentGrid["billno", i].Value.ToString().ToLower().Contains(searchTB.Text.ToLower()))
                    {
                        paymentGrid.Rows[i].Visible = true;
                        paymentGrid["billno", i].Selected = true;
                        paymentGrid.FirstDisplayedScrollingRowIndex = paymentGrid.SelectedRows[0].Index;
                    }
                    else
                        paymentGrid.Rows[i].Visible = false;
                }
            }
            else
                refresh();
        }
    }
}
