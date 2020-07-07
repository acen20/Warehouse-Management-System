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
    public partial class Sales : UserControl
    {
        public Sales()
        {
            InitializeComponent();
        }

        string active = "";
        FacadeController f = FacadeController.getFController();
        DataTable bill;

        private void button8_Click(object sender, EventArgs e)
        {
            if (active != "Book Order")
                orderForm1.getAllProducts();
            active = "Book Order";
            orderForm1.BringToFront();
            bookOrderBTN.Controls.Add(selector);
            selector.BringToFront();
        }

        private void salesRetBTN_Click(object sender, EventArgs e)
        {
            if (active != "Sales Return")
            {
                salesReturn1.update();
            }
            salesReturn1.BringToFront();
            active = "Sales Return";
            salesRetBTN.Controls.Add(selector);
            selector.BringToFront();
        }


        private void assignVanBTN_Click(object sender, EventArgs e)
        {
            if (active != "Assign Van")
            {
                assignVan1.getAllUnassignedBills();
                assignVan1.getAllVans();
            }
            active = "Assign Van";
            assignVan1.BringToFront();
            assignVanBTN.Controls.Add(selector);
            selector.BringToFront();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            orderForm1.BringToFront();
            selector.BringToFront();
        }

        public void setProgress()
        {
            bill = f.getAllBills().Tables["myTable"];
            double count_bills = count_bills = bill.Rows.Count;
            double count_unassigned = 0;
            double count_returns = 0;
            foreach (DataRow r in bill.Rows)
            {
                if (r["Salesman"].ToString() == "nil")
                    count_unassigned++;
                if (r["returned"].ToString() == "1")
                    count_returns++;
            }
            double unassigned = Math.Round(count_unassigned / count_bills * 100);
            double returned = Math.Round(count_returns / count_bills * 100);
            try
            {
                unassignedBillProgress.Value = int.Parse(unassigned.ToString());
            }
            catch (Exception ex)
            {
                unassignedBillProgress.Value = 0;
            }

            try
            {
                salesReturnProgress.Value = int.Parse(returned.ToString());
            }
            catch (Exception ex)
            {
                salesReturnProgress.Value = 0;
            }
        }

        private void salesReportBTN_Click(object sender, EventArgs e)
        {
            salesReport1.BringToFront();
            salesReportBTN.Controls.Add(selector);
            selector.BringToFront();
        }
    }
}
