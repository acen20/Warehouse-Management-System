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
using MetroFramework;

namespace Warehouse
{
    public partial class salesReturn : UserControl
    {
        public salesReturn()
        {
            InitializeComponent();
        }

        List<item> billItems=new List<item>();
        List<item> replacedItems = new List<item>();
        List<item> returnedItems = new List<item>();
        List<item> schemes = new List<item>();
        List<saleReturn> sales=new List<saleReturn>();
        string billno = "";
        string tax = "";
        int payid = 0;

        private void salesReturn_Load(object sender, EventArgs e)
        {
            update();
        }

        public void update()
        {
            changeGridColors("unselected");
            getAllBills();
        }

        void getAllBills()
        {
            FacadeController f = FacadeController.getFController();
            DataTable dt=f.getAllBills().Tables["myTable"];
            billsGrid.Columns.Clear();
            foreach(DataRow r in dt.Rows)
            {
                if (r["returned"].ToString() == "1")
                    r.Delete();
            }
            billsGrid.DataSource = dt;
            billsGrid.Columns["returned"].Visible = false;
            billsGrid.Columns["id"].Visible = false;
            billsGrid.Columns["discount"].Visible = false;
            billsGrid.Columns["wht"].Visible = false;
            billsGrid.Columns["CustomerID"].Visible = false;
        }

        void changeGridColors(string state)
        {
            if (state == "unselected")
            {
                billsGrid.DefaultCellStyle.SelectionBackColor = Color.White;
                billsGrid.DefaultCellStyle.SelectionForeColor = Color.DarkGray;
            }

            if (state == "selected")
            {
                billsGrid.DefaultCellStyle.SelectionBackColor = Color.MidnightBlue;
                billsGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            }

        }

        private void billsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            changeGridColors("selected");
        }

        private void deferredCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(deferredCheck.Checked==true)
            {
                paymentDetailsPanel.Enabled = false;
            }
            
            else
            {
                paymentDetailsPanel.Enabled = true;
            }
        }

        private void replacementBTN_Click(object sender, EventArgs e)
        {
            if (replacementPanel.Visible == true)
            {
                replacementPanel.Visible = false;
            }
            else
                replacementPanel.Visible = true;
        }

        private void returnBTN_Click(object sender, EventArgs e)
        {
            if (returnPanel.Visible == true)
            {
                returnPanel.Visible = false;
            }
            else
                returnPanel.Visible = true;
        }

        private void schemeBTN_Click(object sender, EventArgs e)
        {
            if (schemePanel.Visible == true)
            {
                schemePanel.Visible = false;
            }
            else
                schemePanel.Visible = true;
        }

        private void addReplacementBTN_Click(object sender, EventArgs e)
        {
            if (replacedCartTB.Value.ToString() != ""&&replacedProductCB.Text!=""&&(int.Parse(replacedCartTB.Value.ToString())>0))
            { 
                if (replacedPcsTB.Value.ToString() == "")
                    replacedPcsTB.Value = 0;
                string[] id=replacedProductCB.Text.Split('.');
                foreach(item i in billItems)
                {
                    if(i.tag==(id[0]))
                    {
                        if (searchExisting("replacement", i.id.ToString()))
                        {
                            updateItem(i, "replacement");
                            updateList("replacement", i);
                        }
                        else
                        {
                            item ii = createnewItem(i);
                            ii.qtycart = int.Parse(replacedCartTB.Value.ToString());
                            ii.qtypcs = int.Parse(replacedPcsTB.Value.ToString());
                            ii.total = int.Parse(calculateAmount(ii).ToString());
                            replacedItems.Add(ii);
                            createItem(ii, "replacement");
                        }
                        break;
                    }
                }
                replacedAmountLB.Text = calculateReplaceTotal().ToString() ;
                grandTotalLB.Text=calculateGrandTotal().ToString();
            }
        }

        void getAllSales(string billno)
        {
            int count = 0;
            clearAllFields();
            billNoLB.Text = billno;
            subTotalLB.Text = billsGrid.SelectedRows[0].Cells["subtotal"].Value.ToString();
            discountLB.Text = billsGrid.SelectedRows[0].Cells["discount"].Value.ToString();
            tax = billsGrid.SelectedRows[0].Cells["tax"].Value.ToString();
            whtTypeLB.Text = "WHT (" + tax + ")";
            whtLB.Text = billsGrid.SelectedRows[0].Cells["wht"].Value.ToString();
            FacadeController f = FacadeController.getFController();
            DataTable dt=f.getAllSales(billno).Tables["myTable"];
            foreach(DataRow r in dt.Rows)
            {
                item i = new item();
                i.Name = r["Name"].ToString();
                i.desc = r["description"].ToString();
                i.crt = int.Parse(r["crt"].ToString());
                i.tradeOffer = r["tradeOffer"].ToString();
                i.expiry = r["expiry"].ToString();
                i.rate = int.Parse(r["rate"].ToString());
                i.qtycart = int.Parse(r["qtycarton"].ToString());
                i.qtypcs= int.Parse(r["qtypc"].ToString());
                i.total = int.Parse(r["total"].ToString());
                i.id = int.Parse(r["id"].ToString());
                i.product_id = int.Parse(r["prod_id"].ToString());
                i.tag = (++count).ToString();
                billItems.Add(i);
                replacedProductCB.Items.Add(count+"."+i.Name+" ("+i.expiry+")");
                returnedProductCB.Items.Add(count+"."+i.Name+" ("+i.expiry+")");
            }
        }

        void clearAllFields()
        {
            //clear all lists
            clearLists();

            //clear all added content
            clearAllItems();

            //reset textboxes
            clearAllTextboxes();
        }

        void clearLists()
        {
            billItems.Clear();
            schemes.Clear();
            returnedItems.Clear();
            replacedItems.Clear();
            sales.Clear();
        }

        void clearAllItems()
        {
            replacementFlow.Controls.Clear();
            returnsFlow.Controls.Clear();
            schemeFlow.Controls.Clear();
            paymentDetailsPanel.Visible = false;
            replacementPanel.Visible = false;
            returnPanel.Visible = false;
        }

        void clearAllTextboxes()
        {
            replacedProductCB.Items.Clear();
            returnedProductCB.Items.Clear();
            replacedProductCB.Text = "";
            returnedProductCB.Text = "";
            whtLB.Text = "0";
            discountLB.Text = "0";
            whtTypeLB.Text = "WHT";
            replacedCartTB.Value = 0;
            replacedPcsTB.Value = 0;
            returnedCartTB.Value = 0;
            returnedPcsTB.Value = 0;
            note1TB.Text = "0";
            note2TB.Text = "0";
            note3TB.Text = "0";
            note4TB.Text = "0";
            note5TB.Text = "0";
            amountTB.Text = "0";
            grandTotalLB.Text = "0";
            paymentCB.Text = "";
            bankNameTB.Text = "";
            AccountTB.Text = "";
            subTotalLB.Text = "0";
            replacedAmountLB.Text = "0";
            returnedAmountLB.Text = "0";

        }

        private void billsGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            billno = billsGrid.SelectedRows[0].Cells["billno"].Value.ToString();
            getAllSales(billno);
            grandTotalLB.Text=calculateGrandTotal().ToString();
        }

        void createItem(item i, string option)
        {
            Panel itemMinus=createItemMinus(i.tag, option);

            Label labelText=createLabel(i.qtycart+"C,"+i.qtypcs+"P "+i.Name , i.tag, option);

            Panel itemPanel=createItemPanel(i.tag, option);

            labelText.Parent = itemPanel;
            itemMinus.Parent = itemPanel;

            itemPanel.Controls.Add(itemMinus);
            itemPanel.Controls.Add(labelText);

            if (option == "replacement")
                replacementFlow.Controls.Add(itemPanel);
            else if (option == "returned")
                returnsFlow.Controls.Add(itemPanel);
        }

        void updateItem(item i, string option)
        {
            if(option=="replacement")
            {
                foreach(Panel p in replacementFlow.Controls)
                {
                    if(option+"itemPanel "+i.tag==p.Name)
                    {
                        foreach(Control c in p.Controls)
                        {
                            if(c.Name==option+"itemlabel "+i.tag)
                            {
                                c.Text = replacedCartTB.Value.ToString() + "C," + replacedPcsTB.Value.ToString() + "P " + i.Name;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            else if(option=="returned")
            {
                foreach (Panel p in returnsFlow.Controls)
                {
                    if (option + "itemPanel " + i.tag == p.Name)
                    {
                        foreach (Control c in p.Controls)
                        {
                            if (c.Name == option + "itemlabel " + i.tag)
                            {
                                c.Text = returnedCartTB.Value.ToString() + "C," + returnedPcsTB.Value.ToString() + "P " + i.Name;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        Label createLabel(string labelText, string id, string option)
        {
            Label itemLabel = new Label();
            itemLabel.AutoSize = true;
            itemLabel.BackColor = Color.Transparent;
            itemLabel.Font = new Font("Candara", 9.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            itemLabel.ForeColor = Color.White;
            itemLabel.Location = new Point(40, 5);
            itemLabel.Name = option+"itemlabel " + id.ToString();
            itemLabel.Text = labelText;
            return itemLabel;
        }

        Panel createItemMinus(string id, string option)
        {
            Panel itemMinus = new Panel();
            itemMinus.BackColor = Color.Transparent;
            itemMinus.Name = option+"minus " + id.ToString();
            itemMinus.Size = new Size(27, 27);
            itemMinus.Location = new Point(161, 0);
            itemMinus.Click += (s, args) => deleteItem(id, option);
            return itemMinus;
        }

        Panel createItemPanel(string id, string option)
        {
            Panel itemPanel = new Panel();
            itemPanel.BackgroundImage = Properties.Resources.whiteItem_1;
            itemPanel.BackgroundImageLayout = ImageLayout.Zoom;
            itemPanel.Location = new Point(3, 3);
            itemPanel.Name = option+"itemPanel " + id.ToString();
            itemPanel.Size = new Size(229, 27);
            return itemPanel;
        }

        void deleteItem(string id,string option)
        {
            if (option == "replacement")
            {
                deleteReplaced(id, option);
            }
             
            else if(option=="returned")
            {
                deleteReturned(id, option);
            }
        }

        void deleteReturned(string id, string option)
        {
            foreach (Panel p in returnsFlow.Controls)
            {
                if (p.Name == option + "itemPanel " + id)
                {
                    p.Controls.Clear();
                    p.Dispose();
                    break;
                }
            }

            foreach (item i in returnedItems)
            {
                if (i.tag == id)
                {
                    returnedItems.Remove(i);
                    break;
                }
            }

            returnedAmountLB.Text = calculateReturnTotal().ToString();
            grandTotalLB.Text = calculateGrandTotal().ToString();
        }

        void deleteReplaced(string id, string option)
        {

            foreach (Panel p in replacementFlow.Controls)
            {
                if (p.Name == option + "itemPanel " + id)
                {
                    p.Controls.Clear();
                    p.Dispose();
                    break;
                }
            }

            foreach (item i in replacedItems)
            {
                if (i.tag == id)
                {
                    replacedItems.Remove(i);
                    break;
                }
            }
            replacedAmountLB.Text = calculateReplaceTotal().ToString();
            grandTotalLB.Text = calculateGrandTotal().ToString();
        }

        private void addReturnBTN_Click(object sender, EventArgs e)
        {
            if (returnedCartTB.Value.ToString() != "" && returnedProductCB.Text != ""&& (int.Parse(returnedCartTB.Value.ToString())>0))
            {
                if (returnedPcsTB.Value.ToString() == "")
                    returnedPcsTB.Value = 0;
                string[] id = returnedProductCB.Text.Split('.');
                foreach (item i in billItems)
                {
                    if (i.tag == (id[0]))
                    {
                        if (searchExisting("returned", i.id.ToString()))
                        {
                            updateItem(i, "returned");
                            updateList("returned", i);
                        }
                        else
                        {
                            item ii = createnewItem(i);
                            ii.qtycart = int.Parse(returnedCartTB.Value.ToString());
                            ii.qtypcs = int.Parse(returnedPcsTB.Value.ToString());
                            ii.total = int.Parse(calculateAmount(ii).ToString());
                            returnedItems.Add(ii);
                            createItem(ii, "returned");
                        }
                        break;
                    }
                }
                returnedAmountLB.Text = calculateReturnTotal().ToString();
                grandTotalLB.Text = calculateGrandTotal().ToString();
            }
        }

        private void returnedProductCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.Text = "";
        }

        double calculateAmount(item i)
        {
            double total = 0;
            double totalcartprice = (double.Parse(i.rate.ToString()) - double.Parse(i.tradeOffer.ToString())) * i.qtycart;
            double totalpcprice = (double.Parse(i.rate.ToString()) / double.Parse(i.crt.ToString()))*i.qtypcs;
            total = totalcartprice + totalpcprice;
            return Math.Round(total);
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                saveAll();
                MetroMessageBox.Show(this, "Sale return for bill " + billno + " saved successfully\nAmount Received: "+amountTB.Text
                    +" via "+paymentCB.Text+"\nAmount Due: " +
                    (int.Parse(grandTotalLB.Text)-int.Parse(amountTB.Text))+"", "Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                getAllBills();
                clearAllFields();
            }
            else
                MessageBox.Show("Invalid");
        }

        private void paymentCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            paymentDetailsPanel.Visible = true;
            if(paymentCB.SelectedItem.ToString()=="Cash")
            {
                cashDetailsPanel.Visible = true;
                chequeDetail.Visible = false;
            }

            else
            {
                chequeDetail.Visible = true;
                cashDetailsPanel.Visible = false;
            }
        }

        bool validate()
        {
            if (validateReplacement() && validateReturns() && validatePayment())
                return true;
            else
                return false;
        }

        bool validateReplacement()
        {
            if ((replacementPanel.Visible == true && (replacedItems.Count > 0)) || replacementPanel.Visible == false)
                return true;
            else
                return false;
        }

        bool validateReturns()
        {
            if ((returnPanel.Visible == true && (returnedItems.Count > 0)) || returnPanel.Visible == false)
                return true;
            else
                return false;
        }

        bool validatePayment()
        {
            if (amountTB.Text != "" && paymentCB.Text != "")
            {
                if (cashDetailsPanel.Visible == true)
                {
                    foreach (Control c in cashDetailsPanel.Controls)
                        if (c is TextBox && c.Text == "")
                            c.Text = "0";
                    return true;
                }
                else if (chequeDetail.Visible == true)
                {
                    if (bankNameTB.Text == "" && AccountTB.Text == "")
                        return false;
                    else
                        return true;
                }
                else
                    return false;
            }
            else
                return false;

        }

        void saveAll()
        {
            savePayment();
            setPayid();
            saveAllItems();
            resaveReturnedItems();
            updateBill();
        }

        void savePayment()
        {
            string bank="";
            string account="";
            FacadeController f = FacadeController.getFController();
            if(paymentCB.Text=="Cash")
            {
                bank = "-";
                account = "-";
            }

            else if (paymentCB.Text=="Cheque")
            {
                bank = bankNameTB.Text;
                account = AccountTB.Text;
            }
            f.insertPayment(billno,paymentCB.Text, note1TB.Text, note2TB.Text, note3TB.Text, note4TB.Text, note5TB.Text, amountTB.Text, bank, account,grandTotalLB.Text);
        }


        void setPayid()
        {
            FacadeController f = FacadeController.getFController();
            DataSet s = f.getPayment(billno);
            payid = int.Parse(s.Tables["myTable"].Rows[0]["id"].ToString());
        }

        void updateBill()
        {
            FacadeController f = FacadeController.getFController();
            f.updateReturn(billno);
        }

        void addToProducts(item i)
        {
            FacadeController f = FacadeController.getFController();
            DataTable dt = getAllProducts();
            foreach(DataRow r in dt.Rows)
            {
                string product_id = r["id"].ToString();
                if (product_id == i.product_id.ToString())
                {
                    int qtyCart =int.Parse( r["qtycart"].ToString())+i.qtycart;
                    int qtyPc = int.Parse(r["qtypcs"].ToString())+i.qtypcs;
                    f.updateProductQty(product_id, qtyPc.ToString(), qtyCart.ToString());
                    break;
                }
            }
            
        }

        DataTable getAllProducts()
        {
            FacadeController f = FacadeController.getFController();
            DataTable dt=f.getAllProducts().Tables["myTable"];
            return dt;
        }

        double calculateReturnTotal()
        {
            double total = 0;
            foreach(item i in returnedItems)
            {
                total += calculateAmount(i);
            }
            return total;
        }

        double calculateReplaceTotal()
        {
            double total = 0;
            foreach (item i in replacedItems)
            {
                total += calculateAmount(i);
            }
            return total;
        }

        double calculateGrandTotal()
        {
            double total = double.Parse(subTotalLB.Text);
            foreach (item i in returnedItems)
            {
                total = total - calculateAmount(i);
            }

            foreach (item i in replacedItems)
            {
                total = total - calculateAmount(i);
            }

            total = total - double.Parse(discountLB.Text);
            if (tax == "Inclusive")
                total = total - (double.Parse(whtLB.Text) / 100);
            else if (tax == "Exclusive")
                total = total + (double.Parse(whtLB.Text) / 100);
            grandTotalLB.Text = Math.Round(total).ToString();

            return Math.Round(total);
        }

        
        private void returnedAmountLB_Click(object sender, EventArgs e)
        {

        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            clearAllFields();
        }

        void saveAllItems()
        {
            FacadeController f = FacadeController.getFController();
            foreach (item i in billItems)
            {
                int returnedpcs = 0;
                int returnedcart = 0;
                int replacedpcs = 0;
                int replacedcart = 0;
                foreach (item ii in returnedItems)
                {
                    if (i.id == ii.id)
                    {
                        i.total -= ii.total;
                        returnedpcs = ii.qtypcs;
                        returnedcart = ii.qtycart;
                        break;
                    }
                }
                foreach(item ii in replacedItems)
                {
                    if (i.id == ii.id)
                    {
                        i.total -= ii.total;
                        replacedpcs = ii.qtypcs;
                        replacedcart = ii.qtycart;
                        break;
                    }
                }
                f.saveSaleReturn(i.id, billno, returnedcart, returnedpcs, replacedcart, replacedpcs,payid, i.total);
            }
            
        }

        item createnewItem(item i)
        {
            item ii = new item();
            ii.Name = i.Name;
            ii.id = i.id;
            ii.rate = i.rate;
            ii.tag = i.tag;
            ii.expiry = i.expiry;
            ii.desc = i.desc;
            ii.tradeOffer = i.tradeOffer;
            ii.crt = i.crt;
            ii.product_id = i.product_id;
            return ii;
        }

        bool searchExisting(string type, string tag)
        {
            bool found = false;
            if (type == "returned")
            {
                foreach (item i in returnedItems)
                {
                    if (i.id.ToString() == tag)
                    {
                        found = true;
                        break;
                    }
                    else
                        found = false;
                }
            }

            else if(type=="replacement")
            {
                foreach (item i in replacedItems)
                {
                    if (i.id.ToString() == tag)
                    {
                        found = true;
                        break;
                    }
                    else
                        found = false;
                }
            }
            return found;
        }

        void updateList(string type, item i)
        {
            if(type=="replacement")
            {
                foreach(item ii in replacedItems)
                {
                    if(i.id==ii.id)
                    {
                        ii.qtycart = int.Parse(replacedCartTB.Value.ToString());
                        ii.qtypcs = int.Parse(replacedPcsTB.Value.ToString());
                        ii.total = int.Parse(calculateAmount(ii).ToString());
                        break;
                    }
                }
            }

            else if (type == "returned")
            {
                foreach (item ii in returnedItems)
                {
                    if (i.id == ii.id)
                    {
                        ii.qtycart = int.Parse(returnedCartTB.Value.ToString());
                        ii.qtypcs = int.Parse(returnedPcsTB.Value.ToString());
                        ii.total = int.Parse(calculateAmount(ii).ToString());
                        break;
                    }
                }

            }
        }

        void resaveReturnedItems()
        {
            foreach(item i in returnedItems)
            {
                addToProducts(i);
            }
        }

        private void replacedProductCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] id = replacedProductCB.Text.Split('.');
            foreach (item i in billItems)
            {
                if (i.tag == id[0])
                {
                    replacedCartTB.Maximum = i.qtycart;
                    replacedPcsTB.Maximum = i.qtypcs;
                    break;
                }

            }
        }

        private void returnedProductCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] id = returnedProductCB.Text.Split('.');
            foreach (item i in billItems)
            {
                if (i.tag == id[0])
                {
                    returnedCartTB.Maximum = i.qtycart;
                    returnedPcsTB.Maximum = i.qtypcs;
                    break;
                }

            }
        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            if (searchTB.Text != "")
            {
                billsGrid.ClearSelection();
                for (int i = 0; i < billsGrid.Rows.Count; i++)
                {
                    if (billsGrid["billno", i].Value.ToString().ToLower().Contains(searchTB.Text.ToLower()))
                    {
                        billsGrid.Rows[i].Visible = true;
                        billsGrid["billno", i].Selected = true;
                        billsGrid.FirstDisplayedScrollingRowIndex = billsGrid.SelectedRows[0].Index;
                    }
                    else
                        billsGrid.Rows[i].Visible = false;
                }
            }
            else
                getAllBills();
        }
    }
}
