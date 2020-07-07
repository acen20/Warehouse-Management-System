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
    public partial class dashboard : UserControl
    {
        public dashboard()
        {
            InitializeComponent();
        }

        int highestProduct = 0;
        int productsWorth = 0;
        int totalstock = 0;
        int categories = 0;
        string highestProductName = "-";
        int lowestProduct = 0;
        string lowestProductName = "-";

        private void dashboard_Load(object sender, EventArgs e)
        {
            refresh();
            deliveriesGrid.RowsDefaultCellStyle.SelectionBackColor = Color.White;
            deliveriesGrid.RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
        }

        void getVehiclesSummary()
        {
            FacadeController f = FacadeController.getFController();
            DataTable dt=f.getVehiclesSummary().Tables["myTable"];
            DataTable total = f.getAllVans().Tables["myTable"];
            totalVehiclesLB.Text=total.Rows.Count.ToString();
            if (dt.Rows.Count > 0)
                departedVehiclesLB.Text = dt.Rows[0]["departed"].ToString();
            else
                departedVehiclesLB.Text = "0";
            availableVehiclesLB.Text = (int.Parse(totalVehiclesLB.Text) - int.Parse(departedVehiclesLB.Text)).ToString();
        }

        void getCompaniesSummary()
        {
            FacadeController f = FacadeController.getFController();
            DataTable dt = f.getCompaniesSummary().Tables["myTable"];
            activeCompaniesLB.Text = dt.Rows.Count.ToString();
            if (dt.Rows.Count > 0)
                totalCompaniesLB.Text = dt.Rows[0][0].ToString();
            else
                totalCompaniesLB.Text = "0";
            getactiveCompanies();
            dt = f.getTopCompany().Tables["myTable"];
            if (dt.Rows.Count > 0)
                topCompanyLB.Text = dt.Rows[0]["company"].ToString();
            else
                topCompanyLB.Text = "-";
        }

        void getProductsSummary()
        {
            FacadeController f = FacadeController.getFController();
            DataTable dt = f.getProductsSummary().Tables["myTable"];
            categories = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                highestProduct = int.Parse(dt.Rows[0]["qtycart"].ToString());
                lowestProduct = int.Parse(dt.Rows[0]["qtycart"].ToString());
                foreach (DataRow r in dt.Rows)
                {
                    if (int.Parse(r["qtycart"].ToString()) > highestProduct)
                    {
                        highestProduct = int.Parse(r["qtycart"].ToString());
                        highestProductName = r["Name"].ToString();
                    }
                    productsWorth += int.Parse(r["rate"].ToString()) * int.Parse(r["qtycart"].ToString());
                    totalstock += int.Parse(r["qtycart"].ToString());
                    if (int.Parse(r["qtycart"].ToString()) < lowestProduct)
                    {
                        lowestProduct = int.Parse(r["qtycart"].ToString());
                        lowestProductName = r["Name"].ToString();
                    }
                }
            }
            setInventoryDetails();
        }

        void getCustomersSummary()
        {
            FacadeController f = FacadeController.getFController();
            DataTable allCustomers = f.getAllCustomers().Tables["myTable"];
            DataTable topCustomer = f.getTopCustomer().Tables["myTable"];
            DataTable activeCustomer = f.getActiveCustomers().Tables["myTable"];
            if (allCustomers.Rows.Count > 0)
                totalCustomersLB.Text = f.getAllCustomers().Tables["myTable"].Rows[0][0].ToString();
            else
                totalCustomersLB.Text = "0";
            if (activeCustomer.Rows.Count > 0)
                activeCustomerLB.Text = f.getActiveCustomers().Tables["myTable"].Rows[0][0].ToString();
            else
                totalCustomersLB.Text = "0";
            if (topCustomer.Rows.Count > 0)
                topCustomerLB.Text = f.getTopCustomer().Tables["myTable"].Rows[0]["Name"].ToString();
            else
                topCustomerLB.Text = "0";
            updateCustomerChart();
        }

        void getReturnsSummary()
        {
            deliveries();
        }

        public void refresh()
        {
            getVehiclesSummary();
            getCompaniesSummary();
            getProductsSummary();
            getCustomersSummary();
            getReturnsSummary();
            getTopSelling();
            setGrid();
        }

        void setInventoryDetails()
        {
            lowestItemLB.Text = lowestProductName + " (" + lowestProduct + ")";
            highestItemLB.Text = highestProductName + " (" + highestProduct + ")";
            productCategoriesLB.Text = categories.ToString();
            totalWorthLB.Text = productsWorth.ToString();
            totalStockLB.Text = totalstock.ToString();
        }

        DataTable getactiveCompanies()
        {
            int count = 0;
            FacadeController f = FacadeController.getFController();
            DataTable allproducts = f.getAllProducts().Tables["myTable"];
            DataTable companies = f.getAllCompanies().Tables["myTable"];
            foreach(DataRow r in companies.Rows)
            {
                foreach(DataRow r2 in allproducts.Rows)
                {
                    string productsCompany = r2["company"].ToString().ToLower();
                    string company = r["company"].ToString().ToLower();
                    if (productsCompany == company)
                    {
                        count++;
                        break;
                    }
                }
            }
            activeCompaniesLB.Text = count.ToString();
            return companies;
        }

        void updateCustomerChart()
        {
            FacadeController f = FacadeController.getFController();
            DataTable dt = f.getTopCustomer().Tables["myTable"];
            if(dt.Rows.Count!=0)
                for(int i=0; i<dt.Rows.Count;i++)
                {
                    if (i == 0)
                    {
                        firstCustomerLB.Text = dt.Rows[0][0].ToString();
                    }
                    else if (i == 1)
                    {
                        secondCustomerLB.Text = dt.Rows[1][0].ToString();
                    }
                    else if (i == 2)
                    {
                        thirdCustomerLB.Text = dt.Rows[2][0].ToString();
                    }
                    else if (i == 3)
                        break;
                }
            else 
            {
                firstCustomerLB.Text = "-";
                secondCustomerLB.Text = "-";
                thirdCustomerLB.Text = "-";
            }
        }

        void getTopSelling()
        {
            FacadeController f = FacadeController.getFController();
            DataTable dt = f.getTopSelling().Tables["myTable"];
            if (dt.Rows.Count > 0)
            {
                topSellingItemLB.Text = dt.Rows[0][1].ToString();
                topSellingQtyLB.Text = dt.Rows[0][0].ToString();
            }
            else
                topSellingItemLB.Text = "-";
            topSellingQtyLB.Text = "-";
        }

        void deliveries()
        {
            int scheduled = 0;
            int pending = 0;
            int delivered = 0;
            FacadeController f = FacadeController.getFController();
            DataTable dt = f.getAllBills().Tables["myTable"];
            if(dt.Rows.Count>0)
            {
                foreach(DataRow r in dt.Rows)
                {
                    if (r["returned"].ToString() == "0" && r["salesman"].ToString() == "nil")
                    {
                        pending++;
                    }
                    else if (r["returned"].ToString() == "1")
                    {
                        delivered++;
                    }
                    else if (r["returned"].ToString() == "0" && r["salesman"].ToString()!="nil")
                    {
                        scheduled++;
                    }
                }
            }
            deliveriesScheduledLB.Text = scheduled.ToString();
            deliveriesSentLB.Text = delivered.ToString();
            pendingLB.Text = pending.ToString();
        }

        void setGrid()
        {
            deliveriesGrid.Columns.Clear();
            FacadeController f = FacadeController.getFController();
            DataTable dt = f.getDeliverySummary().Tables["myTable"];
            deliveriesGrid.DataSource = dt;
        }
    }
}
