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
    public partial class manageProducts : UserControl
    {
        public manageProducts()
        {
            InitializeComponent();
        }

        List<generalProd> lst = new List<generalProd>();

        string timeFormat = "hh:mm tt";
        string dateFormat = "dd-MM-yyyy";
        int dispatchno;
        int counter = 0;
        string id;


        private void manageProducts_Load(object sender, EventArgs e)
        {
            updateProductSelection();
            update();
            middlePanel.Dock = DockStyle.Fill;
            loadProductsGrid();
            fillDetails();
            productsGrid.DefaultCellStyle.SelectionBackColor = Color.White;
            productsGrid.DefaultCellStyle.SelectionForeColor = Color.DarkGray;
            repory1.deleteBTN.Click += (s, args) => deleteRecord();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void newDispatchEntry_Click(object sender, EventArgs e)
        {
            counter = 0;
            newDispatchPanel.Enabled = false;
            label12.Visible = false;
            addDispatchPanel.Visible = true;
            dispatchFormLabel.Text = "Dispatch No " + dispatchNoTB.Text;
            clearTextboxes();
            multipleExpiryCheck.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            middlePanel.Dock = DockStyle.Top;
            productsfunctionsPanel.Visible = true;
            addCompany.Visible = true;
            bottomLeftPanel.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!newDispatchPanel.Visible)
            {
                middlePanel.Dock = DockStyle.Top;
                productsfunctionsPanel.Visible = true;
                newDispatchPanel.Visible = true;
                bottomLeftPanel.Visible = true;
                addDispatchPanel.Visible = false;
                foreach (Control c in newDispatchPanel.Controls)
                {
                    if (c is TextBox)
                        c.Text = "";
                }
                commitBTN.Visible = false;
                label12.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (productsGrid.SelectedRows.Count == 1 && newDispatchPanel.Visible == false)
            {
                middlePanel.Dock = DockStyle.Top;
                productsfunctionsPanel.Visible = true;
                addDispatchPanel.Visible = true;
                dispatchFormLabel.Text = "Edit";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void qtyCartonTB_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Contains("-"))
                reasonPanel.Visible = true;
            else
                reasonPanel.Visible = false;
        }

        private void qtyPiecesTB_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Contains("-"))
                reasonPanel.Visible = true;
            else
                reasonPanel.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (nameTB.Text != "" && descTB.Text != "" && (qtyCartonTB.Text != "" || qtyCartonTB.Text != "") && companyTB.Text != ""
                    && salePriceTb.Text != "" && tradePriceTB.Text != "" && purchaseDate.Value != null && expiryDate.Value != null && ((reasonPanel.Visible == true && reasonTB.Text != "") ||
                    (reasonPanel.Visible == false)) &&((multipleExpiryCheck.Checked==true && validateMultiExpiry())||multipleExpiryCheck.Checked==false))
            {
                    if (reasonPanel.Visible == false)
                        reasonTB.Text = "";
                    FacadeController f = FacadeController.getFController();
                    string damage;
                    if (damageCheck.Checked == true)
                        damage = "1";
                    else
                        damage = "0";
                    int response = 0;
                if (!dispatchFormLabel.Text.Contains("Edit") && multipleExpiryCheck.Checked == false)
                {
                    //InsertionCode
                    response = f.createInventoryData(dispatchNoTB.Text, nameTB.Text, descTB.Text, qtyCartonTB.Text, qtyPiecesTB.Text, purchaseDate.Value.ToString(dateFormat),
                        expiryDate.Value.ToString(dateFormat), tradePriceTB.Text, salePriceTb.Text, companyTB.Text, dateInTB.Text + " " + timeInTB.Text, null, reasonTB.Text, damage);
                    addProduct(nameTB.Text, descTB.Text, salePriceTb.Text, expiryDate.Value.ToString(dateFormat), qtyCartonTB.Text, qtyPiecesTB.Text, crtTB.Text, companyTB.Text);

                }

                else if (multipleExpiryCheck.Checked == true && multipleExpiryCheck.Visible == true)
                {
                    if (expiry1Check.Checked == true)
                    {
                        response = f.createInventoryData(dispatchNoTB.Text, nameTB.Text, descTB.Text, qtyC1.Text, qtyP1.Text, purchaseDate.Value.ToString(dateFormat),
                        expiry1Date.Value.ToString(dateFormat), tradePriceTB.Text, salePriceTb.Text, companyTB.Text, dateInTB.Text + " " + timeInTB.Text, null, reasonTB.Text, damage);
                        addProduct(nameTB.Text, descTB.Text, salePriceTb.Text, expiry1Date.Value.ToString(dateFormat), qtyCartonTB.Text, qtyPiecesTB.Text, crtTB.Text, companyTB.Text);
                    }
                    if (expiry2Check.Checked == true)
                    {
                        response = f.createInventoryData(dispatchNoTB.Text, nameTB.Text, descTB.Text, qtyC2.Text, qtyP2.Text, purchaseDate.Value.ToString(dateFormat),
                        expiry2Date.Value.ToString(dateFormat), tradePriceTB.Text, salePriceTb.Text, companyTB.Text, dateInTB.Text + " " + timeInTB.Text, null, reasonTB.Text, damage);
                        addProduct(nameTB.Text, descTB.Text, salePriceTb.Text, expiry2Date.Value.ToString(dateFormat), qtyCartonTB.Text, qtyPiecesTB.Text, crtTB.Text, companyTB.Text);
                    }
                    if (expiry3Check.Checked == true)
                    {
                        response = f.createInventoryData(dispatchNoTB.Text, nameTB.Text, descTB.Text, qtyC3.Text, qtyP3.Text, purchaseDate.Value.ToString(dateFormat),
                        expiry3Date.Value.ToString(dateFormat), tradePriceTB.Text, salePriceTb.Text, companyTB.Text, dateInTB.Text + " " + timeInTB.Text, null, reasonTB.Text, damage);
                        addProduct(nameTB.Text, descTB.Text, salePriceTb.Text, expiry3Date.Value.ToString(dateFormat), qtyCartonTB.Text, qtyPiecesTB.Text, crtTB.Text, companyTB.Text);
                    }
                }

                else if (dispatchFormLabel.Text.Contains("Edit"))
                {
                    {  //UpdateCodeHere
                        int res = f.updateInventory(id, nameTB.Text, descTB.Text, qtyCartonTB.Text, qtyPiecesTB.Text, purchaseDate.Value.ToString(dateFormat), expiryDate.Value.ToString(dateFormat),
                            tradePriceTB.Text, salePriceTb.Text, companyTB.Text, reasonTB.Text, damage);
                        if (res == 1)
                            MessageBox.Show("Dispatch updated successfully");
                        addUpdateConfig();
                        loadProductsGrid();
                    }
                }
                    
                if (response == 1)
                {
                    doneBTN.Visible = true;
                    counter++;
                    clearTextboxes();
                    loadProductsGrid();
                }

            }
                else
                {
                    MessageBox.Show("Incomplete information provided. Fill Correctly");
                }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FacadeController f = FacadeController.getFController();
            int response = f.commitDispatch(dispatchNoTB.Text, dateOutTB.Value.ToString(dateFormat) + " " + timeOutTB.Value.ToString(timeFormat));
            if (response!=-1)
            {
                newDispatchPanel.Visible = false;
                DialogResult res = MessageBox.Show("Saved. Do you want invoice?", "Success", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    //Print Invoice Code Here
                }
                update();
            }
        }

        private void doneBTN_Click(object sender, EventArgs e)
        {
            addDispatchPanel.Visible = false;
            newDispatchPanel.Enabled = true;
            if (counter > 0)
            {
                commitBTN.Visible = true;
            }
            else
                label12.Visible = true;
        }

        public void update()
        {
            FacadeController f = FacadeController.getFController();
            DataSet s=f.getHighestDispatch();
            if (s.Tables["myTable"].Rows[0][0].ToString()!="")
            {
                string disp = s.Tables["myTable"].Rows[0][0].ToString();
                dispatchno = int.Parse(disp)+1;
            }
            else
                dispatchno = 1;

            middlePanel.Dock = DockStyle.Fill;
            productsfunctionsPanel.Visible = false;
            dispatchNoTB.Text = dispatchno.ToString();
            newDispatchPanel.Visible = false;
            loadProductsGrid();
            addDispatchPanel.Visible = false;

            s = f.getNoOfDispatch();
            totalDispatchesLB.Text=s.Tables["myTable"].Rows.Count.ToString();
            totalProductsLB.Text = productsGrid.Rows.Count.ToString();

        }

        public void clearTextboxes()
        {
            foreach (Control c in panel20.Controls)
            {
                if(c is TextBox || c is DateTimePicker|| c is ComboBox)
                {
                    c.Text = "";
                }

                if(c is CheckBox)
                {
                    CheckBox box = c as CheckBox;
                    box.Checked = false;
                }
            }
            expiryDate.Enabled = true;
        }

        public void loadProductsGrid()
        {
            FacadeController f = FacadeController.getFController();
            DataSet s=f.getProducts();
            DataTable dt = new DataTable();
            dt = s.Tables["myTable"];
            productsGrid.Columns.Clear();
            productsGrid.DataSource = dt;
            productsGrid.Columns["id"].Visible = false;
            productsGrid.Columns["dispatchno"].Visible = false;
            productsGrid.Columns["purchase Date"].Visible = false;
            productsGrid.Columns["Reason"].Visible = false;
            productsGrid.Columns["purchase price"].Visible = false;
        }

        public void productsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            productsGrid.RowsDefaultCellStyle.SelectionBackColor = Color.MediumAquamarine;
            productsGrid.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            fillDetails();
            repory1.editBTN.Click += (s, args) => fillEditBoxes();
        }

        private void fillEditBoxes()
        {
            doneBTN.Visible = false;
            if (productsGrid.SelectedRows.Count == 1)
            {
                bottomLeftPanel.Visible = true;
                id = productsGrid.SelectedCells[0].Value.ToString();
                string dispatch= productsGrid.SelectedCells[1].Value.ToString();
                nameTB.Text = productsGrid.SelectedCells[2].Value.ToString();
                descTB.Text = productsGrid.SelectedCells[3].Value.ToString();
                qtyCartonTB.Text = productsGrid.SelectedCells[4].Value.ToString();
                qtyPiecesTB.Text = productsGrid.SelectedCells[5].Value.ToString();
                purchaseDate.Value = DateTime.ParseExact(productsGrid.SelectedCells[7].Value.ToString(), dateFormat, null);
                expiryDate.Value = DateTime.ParseExact(productsGrid.SelectedCells[8].Value.ToString(), dateFormat, null);
                tradePriceTB.Text = productsGrid.SelectedCells[9].Value.ToString();
                salePriceTb.Text = productsGrid.SelectedCells[10].Value.ToString();
                companyTB.Text = productsGrid.SelectedCells[11].Value.ToString();
                if (productsGrid.SelectedCells[6].Value.ToString() != "")
                {
                    reasonTB.Text = productsGrid.SelectedCells[6].Value.ToString();
                    reasonPanel.Visible = true;
                }
                else
                    reasonPanel.Visible = false;
                damageCheck.Checked = (bool)productsGrid.SelectedCells[12].Value;
                addDispatchPanel.Visible = true;
                productsfunctionsPanel.Visible = true;
                middlePanel.Dock = DockStyle.Top;
                dispatchFormLabel.Text = "Editing dispatch " + dispatch;
                multipleExpiryCheck.Visible = false;
            }
            else
                MessageBox.Show("Please Select a single row");
        }

        void fillDetails()
        {
            try
            {
                repory1.name = productsGrid.SelectedRows[0].Cells["Name"].Value.ToString();
                repory1.desc = productsGrid.SelectedRows[0].Cells["Desc."].Value.ToString();
                repory1.damaged = (bool)productsGrid.SelectedRows[0].Cells["Damaged"].Value;
                repory1.quantity = productsGrid.SelectedRows[0].Cells["Qty Carton"].Value.ToString() + " Cartons, " + productsGrid.SelectedRows[0].Cells["Qty Pieces"].Value.ToString() + " Pieces";
                repory1.company = productsGrid.SelectedRows[0].Cells["Company"].Value.ToString();
                repory1.purchasedOn = productsGrid.SelectedRows[0].Cells["Purchase Date"].Value.ToString();
                repory1.reason = productsGrid.SelectedRows[0].Cells["Reason"].Value.ToString();
                repory1.expiry = productsGrid.SelectedRows[0].Cells["Expiry Date"].Value.ToString();
                repory1.purchasePrice = productsGrid.SelectedRows[0].Cells["Purchase Price"].Value.ToString();
                repory1.salePrice = productsGrid.SelectedRows[0].Cells["Sale Price"].Value.ToString();
                repory1.dispatch = productsGrid.SelectedRows[0].Cells["Dispatchno"].Value.ToString();
                repory1.setValues();
            }
            catch (ArgumentOutOfRangeException ex)
            { }
        }

        private void dispatchNoTB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dispatchno = int.Parse(dispatchNoTB.Text);
            }catch(Exception)
            { }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            DialogResult res=MessageBox.Show("Are you sure you want to cancel?", "Confirm", MessageBoxButtons.YesNo);
            if(res==DialogResult.Yes)
            {
                addUpdateConfig();
            }
            
        }

        void addUpdateConfig()
        {
            if (newDispatchPanel.Visible == false)
                update();
            else if (newDispatchPanel.Enabled == false)
            {
                dispatchFormLabel.Text = "Dispatch No " + dispatchNoTB.Text;
                doneBTN.Visible = true;
            }
            else
                addDispatchPanel.Visible = false;
            clearTextboxes();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            newDispatchPanel.Visible = false;
            if (addCompany.Visible == false)
                update();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            addCompany.Visible = false;
            if (!newDispatchPanel.Visible)
                update();
        }

        void deleteRecord()
        {
            if (productsGrid.SelectedRows.Count == 1)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    FacadeController f = FacadeController.getFController();
                    int response = f.deleteProduct(productsGrid.SelectedRows[0].Cells["id"].Value.ToString());
                    if (response == 1)
                    {
                        loadProductsGrid();
                    }
                    else
                        MessageBox.Show("Error");
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
                if (button3.Text == "<")
                {
                    foreach (Control c in multipleExpiryPanel.Controls)
                        if (c is Panel)
                        c.Visible = false;
                    multipleExpiryPanel.Size = new Size(12, 76);
                    button3.Text = ">";
                }

                else if(button3.Text==">")
                {
                foreach (Control c in multipleExpiryPanel.Controls)
                    if (c is Panel)
                        c.Visible = true;
                    multipleExpiryPanel.Size = new Size(306, 76);
                    button3.Text = "<";
                }            
        }

        private void multipleExpiryCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (multipleExpiryCheck.Checked == true)
            {
                multipleExpiryPanel.Visible = true;
                expiryDate.Enabled = false;
            }
            else
            {
                multipleExpiryPanel.Visible = false;
                expiryDate.Enabled = true;
            }
        }

        bool validateMultiExpiry()
        {
            bool valid = true;

            if (expiry1Check.Checked == true && qtyC1.Text == "")
                valid = false;
            if (expiry2Check.Checked == true && qtyC2.Text == "")
                valid = false;
            if (expiry2Check.Checked == true && qtyC3.Text == "")
                valid = false;
            return valid;
        }

        private void saveCompany_Click(object sender, EventArgs e)
        {
            if(addCompanyTB.Text!="")
            {
                FacadeController f = FacadeController.getFController();
                f.insertCompany(addCompanyTB.Text);
                addCompanyTB.Text = "";
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            addProductForm m = new addProductForm();
            m.Show();
            m.FormClosed += (s, args) => updateProductSelection();
        }

        private void nameTB_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(generalProd p in lst)
            {
                if(p.name==nameTB.Text)
                {
                    companyTB.Text = p.company;
                    descTB.Text = p.desc;
                    crtTB.Text = p.crt;
                    break;
                }
            }
        }

        void updateProductSelection()
        {
            lst.Clear();
            nameTB.Items.Clear();
            FacadeController f = FacadeController.getFController();
            DataSet s = f.getAllGeneralProducts();
            DataTable dt = s.Tables["myTable"];
            foreach(DataRow row in dt.Rows)
            {
                generalProd pd = new generalProd();
                pd.name=row["Name"].ToString();
                pd.desc = row["Description"].ToString();
                pd.company = row["Company"].ToString();
                pd.crt = row["Crt"].ToString();
                lst.Add(pd);
                nameTB.Items.Add(pd.name);
            }
        }

        void addProduct(string name, string desc, string rate, string expiry, string qtyCarton, string qtyPcs, string crt, string company)
        {
            bool exists = false;
            FacadeController f = FacadeController.getFController();
            DataTable dt = f.getAllProducts().Tables["myTable"];
            foreach(DataRow r in dt.Rows)
            {
                if (r["Name"].ToString().ToLower() == name.ToLower()&&r["Expiry"].ToString()==expiry && rate==r["rate"].ToString())
                {
                    exists = true;
                    int totalQtyPcs = int.Parse(r["qtypcs"].ToString());
                    if (qtyPcs != "")
                        totalQtyPcs += int.Parse(qtyPcs);
                    int totalQtyCart = int.Parse(qtyCarton) + int.Parse(r["qtycart"].ToString());
                    f.updateProductQty(r["id"].ToString(), totalQtyPcs.ToString(), totalQtyCart.ToString());
                    break;
                }
            }

            if(exists==false)
            {
                if (qtyPcs != "")
                    f.insertProduct(name, desc, rate, expiry, qtyCarton, qtyPcs, crt, company);
                else
                    f.insertProduct(name, desc, rate, expiry, qtyCarton, qtyPcs = 0.ToString(), crt, company);
            }
        }
    }
}
