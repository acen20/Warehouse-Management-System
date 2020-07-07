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
    public partial class vanUserControl : UserControl
    {
        public vanUserControl()
        {
            InitializeComponent();
        }

        private void vanUserControl_Load(object sender, EventArgs e)
        {
            vanGrid.DefaultCellStyle.SelectionBackColor = Color.White;
            vanGrid.DefaultCellStyle.SelectionForeColor = Color.DarkGray;
            getAllVans();
            fillDetails();
        }

        void getAllVans()
        {
            FacadeController f = FacadeController.getFController();
            DataSet s=f.getAllVans();
            DataTable dt = s.Tables["myTable"];
            vanGrid.Columns.Clear();
            vanGrid.DataSource = dt;
            vanGrid.Columns["id"].Visible = false;
        }

        private void addNewVan_Click(object sender, EventArgs e)
        {
            newVanForm.Visible = true;
            detailsPanel.Visible = false;
            rightPanelHeader.Text = "New Van";
            foreach(Control c in newVanForm.Controls)
            {
                if (c is TextBox || c is MaskedTextBox)
                    c.Text = "";
            }
        }

        private void vanGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vanGrid.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
            vanGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            rightPanelHeader.Text = "Details";
            detailsPanel.Visible = true;
            newVanForm.Visible = false;

            if(vanGrid.SelectedRows.Count==1)
            {
                fillDetails();
            }
        }

        void fillDetails()
        {
            if (vanGrid.SelectedRows.Count == 1)
            {
                nameLB.Text = vanGrid.SelectedRows[0].Cells["Name"].Value.ToString().ToUpper();
                vehicleNoLb.Text = vanGrid.SelectedRows[0].Cells["Vehicle No"].Value.ToString();
                cnicLB.Text = vanGrid.SelectedRows[0].Cells["CNIC"].Value.ToString().ToUpper();
                mileageLB.Text = vanGrid.SelectedRows[0].Cells["Mileage"].Value.ToString();
                contactLB.Text = vanGrid.SelectedRows[0].Cells["Driver no"].Value.ToString();
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            vehicleNoTB.Text = vehicleNoLb.Text;
            mileageTB.Text = mileageLB.Text;
            contactTB.Text = contactLB.Text;
            nameTB.Text = nameLB.Text;
            cnicTB.Text = cnicLB.Text;
            newVanForm.Visible = true;
            detailsPanel.Visible = false;
            rightPanelHeader.Text = "Editing";
        }

        private void submitBTN_Click(object sender, EventArgs e)
        {
            if (nameTB.Text != "" && mileageTB.Text != "" && contactTB.Text != "" && cnicTB.Text != "" && vehicleNoTB.Text != "")
            {
                FacadeController f = FacadeController.getFController();
                if (rightPanelHeader.Text.Contains("Edit"))
                {
                    string id = vanGrid.SelectedRows[0].Cells["id"].Value.ToString();
                    int response=f.updateVan(id, nameTB.Text, vehicleNoTB.Text, contactTB.Text, mileageTB.Text, cnicTB.Text);
                    if (response == 1)
                    {
                        MessageBox.Show("Record Updated Successfully");
                        getAllVans();
                        newVanForm.Visible = false;
                        rightPanelHeader.Text = "Cick a record";
                    } 

                }
                else
                {
                    f.createVanData(vehicleNoTB.Text, nameTB.Text,cnicTB.Text,contactTB.Text, mileageTB.Text);
                    getAllVans();
                    newVanForm.Visible = false;
                    rightPanelHeader.Text = "Cick a record";
                }
            }

            else
                MessageBox.Show("Please fill the form correctly");
        }
    }
}
