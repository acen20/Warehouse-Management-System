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
using BuisnessLogicLayer;

namespace Warehouse
{
    public partial class addProductForm : MetroFramework.Forms.MetroForm
    {
        public addProductForm()
        {
            InitializeComponent();
        }

        private void addProductForm_Load(object sender, EventArgs e)
        {
            getAllCompanies();
        }

        void getAllCompanies()
        {
            FacadeController f = FacadeController.getFController();
            DataSet s = f.getAllCompanies();
            DataTable dt = s.Tables["myTable"];
            companyCB.Items.Clear();
            foreach (DataRow r in dt.Rows)
            {
                companyCB.Items.Add(r["Company"].ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (nameTB.Text != "" && descTB.Text != "" && companyCB.Text != ""&& crtTB.Text!="")
            {
                FacadeController f = FacadeController.getFController();
                int response = f.addProduct(nameTB.Text, descTB.Text, companyCB.Text, crtTB.Text);
                clearTextBoxes();
            }
        }

        void clearTextBoxes()
        {
            foreach(Control c in Controls)
            {
                if (c is TextBox || c is ComboBox)
                    c.Text = "";
            }
        }

        private void companyCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
