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
    public partial class Records : UserControl
    {
        public Records()
        {
            InitializeComponent();
        }

        string active="P";

        private void productsButton_Click(object sender, EventArgs e)
        {
            manageProducts1.BringToFront();
            changeColors(Color.RoyalBlue);
            active = "P";
        }

        private void VanButton_Click(object sender, EventArgs e)
        {
            vanUserControl1.BringToFront();
            changeColors(Color.MediumSeaGreen);
            active = "V";
        }

        void changeColors(Color c)
        {
            colorLine.BackColor=colorline2.BackColor=searchTB.BackColor=c;
        }

        private void Records_Load(object sender, EventArgs e)
        {
            manageProducts1.BringToFront();
            changeColors(Color.RoyalBlue);
            active = "P";
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            if(searchTB.Text=="")
            {
                if(active=="P")
                {
                    manageProducts1.loadProductsGrid();
                }
            }
        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            if (active == "P")
            {
                DataTable dt = new DataTable();
                FacadeController f = FacadeController.getFController();
                DataSet s = f.getProducts();
                dt = s.Tables["myTable"];
                string search = searchTB.Text.ToLower();
                foreach (DataRow row in dt.Rows)
                {
                    string name = row["Name"].ToString().ToLower();
                    string company = row["Company"].ToString().ToLower();
                    string dispatchno = row["dispatchno"].ToString().ToLower();
                    if (name.Contains(search) || company.Contains(search) || dispatchno.Contains(search))
                    {
                    }
                    else
                        row.Delete();
                }

                manageProducts1.productsGrid.DataSource = dt;
                manageProducts1.productsGrid.DefaultCellStyle.SelectionBackColor = Color.MediumAquamarine;
                manageProducts1.productsGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }
    } 
}
