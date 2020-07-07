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
    public partial class salesReport : UserControl
    {
        public salesReport()
        {
            InitializeComponent();
        }

        List<DataTable> tables = new List<DataTable>();

        private void printBTN_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "Print")
            {
                b.Text = "Buy Full Version";
            }
            else
            {
                b.Text = "Print";
            }
        }

        private void salesReport_Load(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Now;
            getAllBills();
            createReport();
            loadGrid();
            getSalesSummary();
        }

        void setWidth()
        {
            for (int i = 1; i < salesGrid.Columns.Count; i++)
            {
                salesGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            salesGrid.DefaultCellStyle.SelectionBackColor = Color.White;
            salesGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            salesGrid.Sort(salesGrid.Columns[0], ListSortDirection.Ascending);
            salesGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            salesGrid.Columns[salesGrid.Columns.Count-1].AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;
            salesGrid.Columns[salesGrid.Columns.Count - 2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            salesGrid.Columns[salesGrid.Columns.Count - 3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            salesGrid.Columns[salesGrid.Columns.Count - 4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        void getSalesSummary()
        {
            FacadeController f = FacadeController.getFController();
            int totalPc = 0;
            int totalCartons = 0;
            int returnedCartons = 0;
            int returnedpcs = 0;
            int replacedCartons = 0;
            int replacedpcs = 0;
            foreach (string bill in Salesman.bills)
            {
                DataTable dt = f.getSalesTotal(bill).Tables["myTable"];
                totalPc += int.Parse(dt.Rows[0]["totalPieces"].ToString());
                totalCartons += int.Parse(dt.Rows[0]["totalCartons"].ToString());
                returnedCartons += int.Parse(dt.Rows[0]["returnedCart"].ToString());
                returnedpcs += int.Parse(dt.Rows[0]["returnedpc"].ToString());
                replacedCartons += int.Parse(dt.Rows[0]["replacedCart"].ToString());
                replacedpcs += int.Parse(dt.Rows[0]["replacedpc"].ToString());
            }
            int soldCartons = totalCartons - (returnedCartons + replacedCartons);
            int soldpcs = totalPc - (returnedpcs + replacedpcs);

            totalLB.Text = totalCartons + "C\n" + totalPc+"P";
            returnedLB.Text = returnedCartons + "C\n" + returnedpcs+"P";
            replacedLB.Text = replacedCartons + "C\n" + replacedpcs+"P";
            soldLB.Text = soldCartons + "C\n" + soldpcs+"P";
        }

        private void datePicker_onValueChanged(object sender, EventArgs e)
        {
            fillVansCombo();
        }

        private void vansCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(vansCB.SelectedItem.ToString()!="")
            {
                clearAll();
                getAllBills();
                createReport();
                loadGrid();
                getSalesSummary();
                loadDetails();
            }
        }

        void fillVansCombo()
        {
            FacadeController f = FacadeController.getFController();
            DataTable dt = f.getAllVans(datePicker.Value.ToString("dd-MM-yyyy")).Tables["myTable"];
            vansCB.Items.Clear();
            foreach (DataRow r in dt.Rows)
            {
                bool found = false;
                string vehicleNo = r["Vehicle No"].ToString();
                foreach (string s in vansCB.Items)
                {
                    if (s == vehicleNo)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                    vansCB.Items.Add(vehicleNo);
            }
        }

        void getAllBills()
        {
            FacadeController f = FacadeController.getFController();
            DataTable dt = f.getAllBills(datePicker.Value.ToString("dd-MM-yyyy"), vansCB.Text).Tables["myTable"];
            if (dt.Rows.Count > 0)
            {
                Salesman.bills.Clear();
                Salesman.name = dt.Rows[0]["Name"].ToString();
                Salesman.vehicleNo = dt.Rows[0]["Vehicle No"].ToString();
                foreach (DataRow r in dt.Rows)
                {
                    Salesman.bills.Add(r["billno"].ToString());
                }
                getSaleTables();
            }
        }

        void getSaleTables()
        {
            FacadeController f = FacadeController.getFController();
            foreach (string bill in Salesman.bills)
            {
                DataTable dt = f.getSalesReport2(bill).Tables["myTable"];
                tables.Add(dt);
            }
        }

        void createReport()
        {
            foreach(DataTable dt in tables)
            {
                foreach (DataRow r in dt.Rows)
                {
                    bool found = false;
                    foreach (itemreport i in itemreport.saleTable)
                    {
                        string name = r["product"].ToString();
                        int rate = int.Parse(r["rate"].ToString());
                        int tradeOffer = int.Parse(r["tradeOffer"].ToString());
                        string expiry = r["expiry"].ToString();
                        if (i.name==name &&i.rate==rate&&i.tradeoffer==tradeOffer&&i.expiry==expiry)
                        {
                            incrementQuantity(r, i);
                            found = true;
                            break;
                        }
                    }

                    if(found==false)
                    {
                        itemreport i=createNewItem(r);
                        itemreport.saleTable.Add(i);
                    }
                }
            }
        }

        void incrementQuantity(DataRow r, itemreport i)
        {
            int totalCart = int.Parse(r["qtycarton"].ToString());
            int totalPc = int.Parse(r["qtypc"].ToString());
            int returnedCart = int.Parse(r["returnedCart"].ToString());
            int returnedpc = int.Parse(r["returnedpc"].ToString());
            int replacedCart = int.Parse(r["replacedcart"].ToString());
            int replacedpc = int.Parse(r["replacedpc"].ToString());
            int soldCart = int.Parse(r["soldcart"].ToString());
            int soldpc = int.Parse(r["soldpc"].ToString());

            i.totalCart += totalCart;
            i.totalpc += totalPc;
            i.returnedcart += returnedCart;
            i.returnedpc += returnedpc;
            i.replacedcart += replacedCart;
            i.replacedpc += replacedpc;
            i.soldcart += soldCart;
            i.soldpc += soldpc;
        }

        itemreport createNewItem(DataRow r)
        {
            itemreport i = new itemreport();
            i.totalCart = int.Parse(r["qtycarton"].ToString());
            i.totalpc = int.Parse(r["qtypc"].ToString());
            i.returnedcart = int.Parse(r["returnedCart"].ToString());
            i.returnedpc = int.Parse(r["returnedpc"].ToString());
            i.replacedcart = int.Parse(r["replacedcart"].ToString());
            i.replacedpc = int.Parse(r["replacedpc"].ToString());
            i.soldcart = int.Parse(r["soldcart"].ToString());
            i.soldpc = int.Parse(r["soldpc"].ToString());
            i.name = r["product"].ToString();
            i.rate = int.Parse(r["rate"].ToString());
            i.expiry = r["expiry"].ToString();
            i.tradeoffer = int.Parse(r["tradeoffer"].ToString());
            i.crt = int.Parse(r["crt"].ToString());
            return i;
        }

        void loadGrid()
        {
            DataTable dt = new DataTable();
            createColumns(dt);
            foreach(itemreport i in itemreport.saleTable)
            {
                DataRow row = dt.NewRow();
                row=createNewRow(row, i);
                dt.Rows.Add(row);
            }
            salesGrid.Columns.Clear();
            salesGrid.DataSource = dt;
            setWidth();
        }

        void createColumns(DataTable dt)
        {
            DataColumn product = new DataColumn();
            DataColumn crt= new DataColumn();
            DataColumn rate = new DataColumn();
            DataColumn expiry = new DataColumn();
            DataColumn tradeOffer = new DataColumn();
            DataColumn total = new DataColumn();
            DataColumn returned = new DataColumn();
            DataColumn replaced = new DataColumn();
            DataColumn sold = new DataColumn();
            dt.Columns.Add(product);
            dt.Columns.Add(crt);
            foreach(string bill in Salesman.bills)
            {
                DataColumn c = new DataColumn();
                dt.Columns.Add(c);
            }
            dt.Columns.Add(rate);
            dt.Columns.Add(expiry);
            dt.Columns.Add(tradeOffer);
            dt.Columns.Add(total);
            dt.Columns.Add(returned);
            dt.Columns.Add(replaced);
            dt.Columns.Add(sold);
            setColumnNames(dt);
        }

        void setColumnNames(DataTable dt)
        {
            int index = -1;
            int load = 0;
            dt.Columns[++index].ColumnName = "Product";
            dt.Columns[++index].ColumnName = "Crt";
            foreach(string bill in Salesman.bills)
            {
                dt.Columns[++index].ColumnName = "Load "+ ++load;
            }
            dt.Columns[++index].ColumnName = "Rate";
            dt.Columns[++index].ColumnName = "Expiry";
            dt.Columns[++index].ColumnName = "T/O";
            dt.Columns[++index].ColumnName = "Total";
            dt.Columns[++index].ColumnName = "Returned";
            dt.Columns[++index].ColumnName = "Replaced";
            dt.Columns[++index].ColumnName = "Sold";
        }

        DataRow createNewRow(DataRow r, itemreport i)
        {
            r["Product"] = i.name;
            r["crt"] = i.crt;
            r["rate"] = i.rate;
            r["expiry"] = i.expiry;
            r["T/O"] = i.tradeoffer;
            r["total"] = i.totalCart + "C, " + i.totalpc+"P";
            r["returned"] = i.returnedcart + "C, " + i.returnedpc + "P";
            r["replaced"] = i.replacedcart + "C, " + i.replacedpc + "P";
            r["sold"] = i.soldcart + "C, " + i.soldpc + "P";
            int load = 0;
            foreach(string bill in Salesman.bills)
            {
                r["Load " + ++load] = bill;
            }

            return r;
        }

        void loadDetails()
        {
            vanNoLB.Text = Salesman.vehicleNo;
            salesmanLB.Text = Salesman.name;
            dateLB.Text = datePicker.Value.ToString("dd-MM-yyyy");
        }

        void clearAll()
        {
            tables.Clear();
            Salesman.bills.Clear();
            itemreport.saleTable.Clear();
            salesGrid.Columns.Clear();
        }
    }
}
