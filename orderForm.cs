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
using MetroFramework.Controls;
using Bunifu.Framework.UI;
using System.Text.RegularExpressions;

namespace Warehouse
{
    public partial class orderForm : UserControl
    {
        public orderForm()
        {
            InitializeComponent();
            discountTB.Controls[0].Enabled = false;
            whtTB.Controls[0].Enabled = false;
        }

        List<item> itemsList = new List<item>();
        List<item> orderList = new List<item>();
        List<Customer> cust = new List<Customer>();
        int maxLimit = 25;
        string format = DateTime.Now.ToString("MMMy-");
        int highestID;
        string preparedby = "Ahsen Nazir";

        private void orderForm_Load(object sender, EventArgs e)
        {
            reset();
            getAllProducts();
            update();
        }

        void reset()
        {
            autoCompletePanel.Parent = this;
            autoCompletePanel.BringToFront();
            panel.Controls.Clear();
            cust.Clear();
            srNoPanel.Controls.Clear();
            getAllCCustomers();
            numberOfItems = 0;

        }

        public void update()
        {
            FacadeController f = FacadeController.getFController();
            DataTable dt = f.getHighestBillId().Tables["myTable"];
            if (dt.Rows[0]["Max"].ToString() != "")
                highestID = int.Parse(dt.Rows[0]["Max"].ToString()) + 1;
            else
                highestID = 1;
            billNoTB.Text = format.ToUpper() + highestID;
        }


        private void billNTNCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (billNTNCheck.Checked == true)
                billNTNTB.Enabled = true;
            else
                billNTNTB.Enabled = false;
        }

        bool alreadyExists(string name, string desc, string expiry, string tradeOffer, int maxCart, int maxPcs)
        {
            bool result = false;

            return result;
        }


        double calculateItemTotal(item i)
        {
            double total = 0;
            double totalcartprice = (double.Parse(i.rate.ToString()) - double.Parse(i.tradeOffer.ToString())) * i.qtycart;
            double pricePerPc = Convert.ToDouble(i.rate) / Convert.ToDouble(i.crt);
            double totalpcprice = double.Parse(i.qtypcs.ToString()) * pricePerPc;
            total = totalpcprice + totalcartprice;
            return total;
        }

        double calculateTotal()
        {
            double total = 0;
            foreach (item i in orderList)
            {
                total = total + i.total;
            }
            return total;
        }

        double calculateGrandTotal()
        {
            double total = double.Parse(calculateTotal().ToString());
            double wht = double.Parse(whtTB.Value.ToString());
            if (inclusiveRB.Checked == true)
            {
                total = total - (total * (wht / 100));
            }
            else if (exclusiveRB.Checked == true)
            {
                total = total + (total * (wht / 100));
            }

            total -= double.Parse(discountTB.Value.ToString());

            return Math.Round(total);
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void submitBTN_Click(object sender, EventArgs e)
        {
            if (orderList.Count < 1)
                MetroMessageBox.Show(this, "Oops. The Order is void. Please add some items", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error, 125);
            else if (validate())
            {
                FacadeController f = FacadeController.getFController();
                int customerID;
                if (billNTNCheck.Checked == false)
                    billNTNTB.Text = "nil";
                string tax = "";
                if (exclusiveRB.Checked == true)
                    tax = exclusiveRB.Text;
                else
                    tax = inclusiveRB.Text;
                foreach (item i in orderList)
                {
                    f.newSale(i.Name, i.desc, i.crt.ToString(), i.tradeOffer, i.rate.ToString(), i.qtycart.ToString(), i.qtypcs.ToString(), billNoTB.Text, calculateTotal().ToString(), i.expiry, i.id);
                    f.updateProductQty(getProductID(i.id).ToString(), (i.maxPcs - i.qtypcs).ToString(), (i.maxCart - i.qtycart).ToString());
                }
                customerID = getCustomerId(billNameTB.Text, billPhoneTB.Text, billAddressTB.Text, billNTNTB.Text);
                f.generateBill(billNoTB.Text, customerID, whtTB.Value.ToString(),
                        discountTB.Value.ToString(), tax, DateTime.Now.ToString("dd-MM-yyyy hh:mm tt"), calculateTotal().ToString(),
                        calculateGrandTotal().ToString(), preparedby, "nil", 0);
                generateReceipt(tax);
                reset();
            }

            else
            {
                MetroMessageBox.Show(this, "Either fill the empty fields or remove them by clicking -\nAlso check the billing information", "Invalid values provided", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
            }
        }

        bool validateAmounts()
        {
            if (discountTB.Text == "" || whtTB.Text == "" || !validateBillDetails() || !validateRadio())
                return false;
            else
                return true;
        }

        bool validateBillDetails()
        {
            if (billNameTB.Text == "" || billAddressTB.Text == "" || billPhoneTB.Text == "" || (billNTNCheck.Checked == true && billNTNTB.Text == ""))
                return false;
            else
                return true;
        }

        private void totalBTN_Click(object sender, EventArgs e)
        {
            if (validateRadio())
            {
                grandTotalLB.Text = calculateGrandTotal().ToString();
                grandTotalPanel.Visible = true;
            }
            subtotalLB.Text = calculateTotal().ToString();
        }

        bool validateRadio()
        {
            if (inclusiveRB.Checked == true || exclusiveRB.Checked == true)
                return true;
            else
                return false;
        }

        void generateReceipt(string tax)
        {
            receipt r = new receipt();
            r.to = billNameTB.Text;
            r.billNo = billNoTB.Text;
            r.total = (calculateGrandTotal()).ToString();
            r.subtotal = calculateTotal().ToString();
            r.ntn = billNTNTB.Text;
            r.wht = whtTB.Value.ToString() + " (" + tax + ")";
            r.phone = billPhoneTB.Text;
            r.address = billAddressTB.Text;
            r.preparedBy = preparedby;
            r.dateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
            r.assignList(orderList);
            r.discount = discountTB.Value.ToString();
            r.Show();
        }

        int getCustomerId(string name, string phone, string address, string ntn)
        {
            int customerID;
            FacadeController f = FacadeController.getFController();
            DataTable dt = f.getExistingCustomer(ntn).Tables["myTable"];
            if (dt.Rows.Count > 0 && dt.Rows[0]["id"].ToString() != "nil")
                customerID = int.Parse(dt.Rows[0]["id"].ToString());
            else
                customerID = insertNewCustomer(name, phone, address, ntn);
            return customerID;
        }

        int insertNewCustomer(string name, string phone, string address, string ntn)
        {
            int customerID;
            FacadeController f = FacadeController.getFController();
            f.insertCustomer(name, phone, address, ntn);
            DataTable dt = f.getNewCustomerId().Tables["myTable"];
            customerID = int.Parse(dt.Rows[0]["id"].ToString());
            return customerID;
        }

        //----------Version 2.1------------
        int numberOfItems = 0;

        private void addItemBTN_Click(object sender, EventArgs e)
        {
            if (numberOfItems < maxLimit)
            {
                numberOfItems++;
                addAnotherItem();
                subtotalLB.Text = calculateTotal().ToString();
            }
            else
                MetroMessageBox.Show(this, "25 items are allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 150);
        }


        //-------------Create Panels--------------------------------------
        public void addAnotherItem()
        {
            int id = numberOfItems;
            Panel eachItemPanel = createEachItemPanel();
            Label serial = createSerialNo(numberOfItems);
            srNoPanel.Controls.Add(serial);
            panel.Controls.Add(eachItemPanel);
            createNewOrderItem(numberOfItems);
            //items item = new items();
            //item.p = eachItemPanel;
            //item.number = numberOfItems;
        }

        public Panel createEachItemPanel()
        {
            Panel eachItemPanel = new Panel();
            Panel itemAndDetPL = createItemAndDetPL();
            eachItemPanel.BackColor = Color.White;
            eachItemPanel.Dock = DockStyle.Bottom;
            eachItemPanel.Location = new Point(0, 0);
            eachItemPanel.Name = "eachItemPanel" + numberOfItems; //will be used to delete an entry
            eachItemPanel.Size = new Size(828, 32);
            eachItemPanel.Controls.Add(itemAndDetPL);
            return eachItemPanel;
        }

        public Panel createItemAndDetPL()
        {
            Panel itemAndDetPL = new Panel();
            //Panel itemDetailsPanel = createItemDetailsPanel();
            Panel itemsPanel = createItemsPanel();
            //itemAndDetPL.Controls.Add(itemDetailsPanel);
            itemAndDetPL.Controls.Add(itemsPanel);
            itemAndDetPL.Dock = DockStyle.Top;
            itemAndDetPL.Location = new Point(0, 0);
            itemAndDetPL.Name = "orderItemAndDetPL" + numberOfItems;
            //itemAndDetPL.Size = new Size(825, 32);
            return itemAndDetPL;
        }


        public Panel createItemsPanel()
        {
            Panel itemsPanel = new Panel();
            NumericUpDown itemUnitPrice = createItemUnitPriceTB();
            NumericUpDown itemQtyCart = createItemQtyCartTB();
            NumericUpDown itemQtyPc = createItemQtyPcTB();
            NumericUpDown TradeOffer = createTradeOfferTB();
            ComboBox itemDesc = createItemDescCombo();
            BunifuDropdown itemName = createItemNameCombo();
            Label amount = createAmount();
            Label remove = createRemoveSign();
            ComboBox expiry = createExpiryCB();
            itemsPanel.Dock = DockStyle.Top;
            //itemsPanel.BorderStyle = BorderStyle.FixedSingle;
            itemsPanel.Location = new Point(0, 0);
            itemsPanel.Name = "itemsPanel" + numberOfItems;
            itemsPanel.Size = new System.Drawing.Size(700, 25);
            itemsPanel.Controls.Add(itemName);
            itemsPanel.Controls.Add(itemDesc);
            itemsPanel.Controls.Add(itemQtyCart);
            itemsPanel.Controls.Add(itemUnitPrice);
            itemsPanel.Controls.Add(itemQtyPc);
            itemsPanel.Controls.Add(TradeOffer);
            itemsPanel.Controls.Add(amount);
            itemsPanel.Controls.Add(remove);
            itemsPanel.Controls.Add(expiry);
            return itemsPanel;
        }


        //-------------Descriptions--------------------------------------

        public BunifuDropdown createItemNameCombo()
        {
            BunifuDropdown itemNameCombo = new BunifuDropdown();
            itemNameCombo.Anchor = AnchorStyles.None;
            itemNameCombo.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            //itemNameCombo.FormattingEnabled = true;
            //itemNameCombo.FontWeight = MetroComboBoxWeight.Regular;
            //itemNameCombo.FontSize = MetroComboBoxSize.Small;
            itemNameCombo.Location = new Point(2, 0);
            itemNameCombo.Name = "itemNameCombo" + numberOfItems;
            itemNameCombo.Size = new Size(100, 25);
            itemNameCombo.Margin = new Padding(0);
            itemNameCombo.BorderRadius = 3;
            //itemNameCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            fillItems(itemNameCombo);
            itemNameCombo.Tag = numberOfItems;
            itemNameCombo.onItemSelected += (s, args) => addDescription(int.Parse(itemNameCombo.Tag.ToString()));
            return itemNameCombo;
        }

        public ComboBox createItemDescCombo()
        {
            MetroComboBox itemDescCombo = new MetroComboBox();
            itemDescCombo.Anchor = AnchorStyles.None;
            itemDescCombo.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            itemDescCombo.FormattingEnabled = true;
            itemDescCombo.Location = new Point(108, 0);
            itemDescCombo.FontWeight = MetroComboBoxWeight.Regular;
            itemDescCombo.FontSize = MetroComboBoxSize.Small;
            itemDescCombo.Name = "itemDescCombo" + numberOfItems;
            itemDescCombo.Size = new Size(71, 20);
            itemDescCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            itemDescCombo.Tag = numberOfItems;
            itemDescCombo.TextChanged += (s, args) => assignMaxQty(int.Parse(itemDescCombo.Tag.ToString()));
            return itemDescCombo;
        }

        public NumericUpDown createItemQtyCartTB()
        {
            NumericUpDown itemQtyCart = new NumericUpDown();
            itemQtyCart.Anchor = AnchorStyles.None;
            itemQtyCart.Location = new Point(188, 0);
            itemQtyCart.Name = "itemQtyCartTB" + numberOfItems;
            itemQtyCart.Font = new Font("Tahoma", 11.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            itemQtyCart.Size = new Size(62, 20);
            itemQtyCart.Minimum = 0;
            itemQtyCart.Tag = numberOfItems;
            Label l = new Label();
            l.BackColor = Color.White;
            l.AutoSize = false;
            l.Size = itemQtyCart.Controls[0].Size;
            l.Width = l.Size.Width;
            l.Height = l.Size.Height;
            l.Location = itemQtyCart.Controls[0].Location;
            itemQtyCart.Controls[0].Hide();
            itemQtyCart.Controls.Add(l);
            itemQtyCart.LostFocus += (s, args) =>
            {
                if (itemQtyCart.Text == "")
                    itemQtyCart.Value = itemQtyCart.Minimum;
            };
            itemQtyCart.ValueChanged += (s, args) => setAmount(int.Parse(itemQtyCart.Tag.ToString()));
            return itemQtyCart;
        }

        public NumericUpDown createItemQtyPcTB()
        {
            NumericUpDown itemQtyPc = new NumericUpDown();
            itemQtyPc.Anchor = AnchorStyles.None;
            itemQtyPc.Location = new Point(256, 0);
            itemQtyPc.Name = "itemQtyPcTB" + numberOfItems;
            itemQtyPc.Size = new Size(49, 20);
            itemQtyPc.Font = new Font("Tahoma", 11.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            itemQtyPc.Minimum = 0;
            Label l = new Label();
            l.BackColor = Color.White;
            l.AutoSize = false;
            l.Size = itemQtyPc.Controls[0].Size;
            l.Width = l.Size.Width;
            l.Height = l.Size.Height;
            l.Location = itemQtyPc.Controls[0].Location;
            itemQtyPc.Controls[0].Hide();
            itemQtyPc.Controls.Add(l);
            itemQtyPc.Tag = numberOfItems;
            itemQtyPc.LostFocus += (s, args) =>
            {
                if (itemQtyPc.Text == "")
                    itemQtyPc.Value = itemQtyPc.Minimum;
            };
            itemQtyPc.ValueChanged += (s, args) => setAmount(int.Parse(itemQtyPc.Tag.ToString()));
            return itemQtyPc;
        }

        public NumericUpDown createItemUnitPriceTB()
        {
            NumericUpDown itemUnitPrice = new NumericUpDown();
            itemUnitPrice.Anchor = AnchorStyles.None;
            itemUnitPrice.Location = new Point(311, 0);
            itemUnitPrice.Name = "itemUnitPriceTB" + numberOfItems;
            itemUnitPrice.Font = new Font("Tahoma", 11.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            itemUnitPrice.Size = new Size(87, 20);
            Label l = new Label();
            l.BackColor = Color.White;
            l.AutoSize = false;
            l.Size = itemUnitPrice.Controls[0].Size;
            l.Width = l.Size.Width;
            l.Height = l.Size.Height;
            l.Location = itemUnitPrice.Controls[0].Location;
            itemUnitPrice.Controls[0].Hide();
            itemUnitPrice.Controls.Add(l);
            //itemUnitPrice.BorderStyle = BorderStyle.None;
            itemUnitPrice.Maximum = Decimal.MaxValue;
            return itemUnitPrice;
        }

        public NumericUpDown createTradeOfferTB()
        {
            NumericUpDown tradeOfferTB = new NumericUpDown();
            tradeOfferTB.Anchor = AnchorStyles.None;
            tradeOfferTB.Location = new Point(407, 0);
            tradeOfferTB.Font = new Font("Tahoma", 11.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            tradeOfferTB.Name = "tradeOfferTB" + numberOfItems;
            tradeOfferTB.Size = new Size(61, 20);
            tradeOfferTB.Maximum = Decimal.MaxValue;
            Label l = new Label();
            l.BackColor = Color.White;
            l.AutoSize = false;
            l.Size = tradeOfferTB.Controls[0].Size;
            l.Width = l.Size.Width;
            l.Height = l.Size.Height;
            l.Location = tradeOfferTB.Controls[0].Location;
            tradeOfferTB.Controls[0].Hide();
            //tradeOfferTB.Width = 61;
            tradeOfferTB.Tag = numberOfItems;
            tradeOfferTB.Controls.Add(l);
            tradeOfferTB.ValueChanged += (s, args) => setAmount(int.Parse(tradeOfferTB.Tag.ToString()));
            return tradeOfferTB;
        }


        public Label createAmount()
        {
            Label amount = new Label();
            amount.BackColor = Color.PaleGreen;
            amount.AutoSize = false;
            amount.Anchor = AnchorStyles.None;
            amount.Location = new Point(474, 0);
            amount.Name = "totalLB" + numberOfItems;
            amount.Size = new Size(70, 25);
            amount.Text = "0";
            return amount;
        }

        ComboBox createExpiryCB()
        {
            MetroComboBox expiry = new MetroComboBox();
            expiry.FormattingEnabled = true;
            expiry.Anchor = AnchorStyles.None;
            expiry.Location = new System.Drawing.Point(558, 0);
            expiry.FontWeight = MetroComboBoxWeight.Regular;
            expiry.FontSize = MetroComboBoxSize.Small;
            expiry.Name = "expiry" + numberOfItems;
            expiry.Tag = numberOfItems;
            expiry.SelectedIndexChanged += (s, args) => assignMaxQty(int.Parse(expiry.Tag.ToString()));
            //expiry.Size = new System.Drawing.Size(100, 28);
            expiry.Width = 100;
            return expiry;
        }

        Label createRemoveSign()
        {
            BunifuCustomLabel remove = new BunifuCustomLabel();
            //remove.BackColor = System.Drawing.Color.OrangeRed;
            remove.Cursor = System.Windows.Forms.Cursors.Hand;
            remove.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            remove.ForeColor = System.Drawing.Color.OrangeRed;
            remove.Location = new System.Drawing.Point(659, 0);
            remove.Name = "remove" + numberOfItems;
            remove.Size = new System.Drawing.Size(29, 15);
            remove.Text = "-";
            remove.Anchor = AnchorStyles.None;
            remove.Tag = numberOfItems;
            remove.AutoSize = false;
            remove.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            remove.Click += (s, args) => removeThisItem(int.Parse(remove.Tag.ToString()));
            return remove;
        }




        //-------------Detail Labels--------------------------------------
        /*public Label createRemaining()
        {
            Label remaining = new Label();
            remaining.Anchor = AnchorStyles.None;
            remaining.AutoSize = true;
            remaining.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            remaining.ForeColor = Color.White;
            remaining.Location = new Point(154, 8);
            remaining.Name = "remainingLB"+numberOfItems;
            remaining.Size = new Size(69, 17);
            remaining.Text = "Remaning"+numberOfItems;
            return remaining;
        }

        public Label createExpiry()
        {
            Label expiry = new Label();
            expiry.Anchor = AnchorStyles.None;
            expiry.AutoSize = true;
            expiry.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            expiry.ForeColor = Color.White;
            expiry.Location = new Point(103, 8);
            expiry.Name = "expiryLB"+numberOfItems;
            expiry.Size = new Size(69, 17);
            expiry.Text = "Expiry"+numberOfItems;
            return expiry;
        }*/

        public Label createSerialNo(int i)
        {
            Label SrNoLB = new Label();
            SrNoLB.Dock = DockStyle.Bottom;
            SrNoLB.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            SrNoLB.ForeColor = Color.MidnightBlue;
            SrNoLB.Location = new Point(0, 0);
            SrNoLB.Name = "SrNoLB" + i;
            SrNoLB.Size = new Size(33, 32);
            SrNoLB.Text = i.ToString();
            SrNoLB.TextAlign = ContentAlignment.MiddleCenter;
            return SrNoLB;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //-----------------------functions------------------
        void changeOrderDesc(item it)
        {

        }

        public void getAllProducts()
        {
            itemsList.Clear();
            FacadeController f = FacadeController.getFController();
            DataTable dt = f.getAllProducts().Tables["myTable"];
            foreach (DataRow r in dt.Rows)
            {
                item i = new item();
                i.id = int.Parse(r["id"].ToString());
                i.product_id = int.Parse(r["id"].ToString());
                i.Name = r["name"].ToString();
                i.desc = r["Desc."].ToString();
                i.maxCart = int.Parse(r["qtycart"].ToString());
                i.maxPcs = int.Parse(r["qtypcs"].ToString());
                i.rate = int.Parse(r["rate"].ToString());
                i.crt = int.Parse(r["crt"].ToString());
                i.expiry = r["expiry"].ToString();
                itemsList.Add(i);
            }
        }


        void addDescription(int id)
        {
            BunifuDropdown name = ((BunifuDropdown)this.Controls.Find("itemNameCombo" + id, true)[0]);
            ComboBox desc = ((ComboBox)this.Controls.Find("itemDescCombo" + id, true)[0]);
            ComboBox expiry = ((ComboBox)this.Controls.Find("expiry" + id, true)[0]);
            desc.Items.Clear();
            expiry.Items.Clear();
            bool exists = false;
            foreach (item i in itemsList)
            {
                if (i.Name == name.selectedValue)
                {
                    foreach (string s in desc.Items)
                    {
                        if (s == i.desc)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (exists)
                        break;
                    else
                        desc.Items.Add(i.desc);
                }
            }
            if (desc.Items.Count > 0)
                desc.Text = desc.Items[0].ToString();
        }


        void assignMaxQty(int id)
        {
            NumericUpDown qtyCart = ((NumericUpDown)this.Controls.Find("itemQtyCartTB" + id, true)[0]);
            BunifuDropdown name = ((BunifuDropdown)this.Controls.Find("itemNameCombo" + id, true)[0]);
            NumericUpDown qtyPc = ((NumericUpDown)this.Controls.Find("itemQtyPcTB" + id, true)[0]);
            ComboBox desc = ((ComboBox)this.Controls.Find("itemDescCombo" + id, true)[0]);
            NumericUpDown unitPrice = ((NumericUpDown)this.Controls.Find("itemUnitPriceTB" + id, true)[0]);
            ComboBox expiry = ((ComboBox)this.Controls.Find("expiry" + id, true)[0]);
            if (expiry.Items.Count == 0)
                fillExpiry(id, name.selectedValue, desc.Text);
            int crt = 0;
            int maxcart = 0;
            int maxpc = 0;
            foreach (item i in itemsList)
            {
                if (i.desc == desc.Text && i.Name == name.selectedValue && i.expiry == expiry.Text)
                {
                    qtyCart.Maximum = i.maxCart;
                    qtyPc.Maximum = i.maxPcs;
                    unitPrice.Value = i.rate;
                    crt = i.crt;
                    maxcart = i.maxCart;
                    maxpc = i.maxPcs;
                    break;
                }
            }
            modifyOrder(id, name, desc, crt, expiry, int.Parse(qtyCart.Value.ToString()), int.Parse(qtyPc.Value.ToString()), maxcart, maxpc);
            setAmount(id);
        }


        void assignQty(int id)
        {
            NumericUpDown qtyCart = ((NumericUpDown)this.Controls.Find("itemQtyCartTB" + id, true)[0]);
            BunifuDropdown name = ((BunifuDropdown)this.Controls.Find("itemNameCombo" + id, true)[0]);
            NumericUpDown qtyPc = ((NumericUpDown)this.Controls.Find("itemQtyPcTB" + id, true)[0]);
            ComboBox desc = ((ComboBox)this.Controls.Find("itemDescCombo" + id, true)[0]);
            NumericUpDown unitPrice = ((NumericUpDown)this.Controls.Find("itemUnitPriceTB" + id, true)[0]);
            ComboBox expiry = ((ComboBox)this.Controls.Find("expiry" + id, true)[0]);

            if (name.selectedValue != "" && desc.Text != "" && expiry.Text != "")
                assignNewMax(id, name, desc, expiry, qtyCart, qtyPc);
        }

        void assignNewMax(int id, BunifuDropdown name, ComboBox desc, ComboBox expiry, NumericUpDown qtyCart, NumericUpDown qtyPc)
        {
            int qtycartons = 0;
            int qtypcs = 0;

            foreach (item ii in orderList)
            {
                if (ii.id != id)
                {
                    if (name.selectedValue == ii.Name && desc.Text == ii.desc && expiry.Text == ii.expiry)
                    {
                        qtycartons += ii.qtycart;
                        qtypcs += ii.qtypcs;
                    }
                }
            }

            qtyCart.Maximum = qtyCart.Maximum - qtycartons;
            qtyPc.Maximum = qtyPc.Maximum - qtypcs;
        }

        void modifyOrder(int id, BunifuDropdown name, ComboBox desc, int crt, ComboBox expiry, int qtyCart, int qtyPc, int maxCart, int maxPc)
        {
            foreach (item i in orderList)
            {
                if (i.id == id)
                {
                    i.Name = name.selectedValue;
                    i.desc = desc.Text;
                    i.crt = crt;
                    i.expiry = expiry.Text;
                    i.qtycart = qtyCart;
                    i.qtypcs = qtyPc;
                    i.maxCart = maxCart;
                    i.maxPcs = maxPc;
                    break;
                }
            }
        }

        void fillItems(BunifuDropdown name)
        {
            List<string> list = new List<string>();
            foreach (item i in itemsList)
                list.Add(i.Name);
            foreach (string s in list.Distinct())
                name.AddItem(s);
        }

        void fillExpiry(int id, string name, string desc)
        {
            ComboBox expiry = ((ComboBox)this.Controls.Find("expiry" + id, true)[0]);
            expiry.Items.Clear();
            foreach (item i in itemsList)
            {
                if (name == i.Name && desc == i.desc)
                {
                    expiry.Items.Add(i.expiry);
                }
            }
            if (expiry.Items.Count > 0)
                expiry.Text = expiry.Items[0].ToString();
        }




        void removeThisItem(int id)
        {
            Panel p = ((Panel)this.Controls.Find("eachItemPanel" + id, true)[0]);
            p.Dispose();
            numberOfItems--;
            reOrderItems();
            var found = orderList.Find(i => i.id == id);
            orderList.Remove(found);
        }

        void reOrderItems()
        {
            srNoPanel.Controls.Clear();
            int i = 1;
            while (i <= numberOfItems)
            {
                srNoPanel.Controls.Add(createSerialNo(i));
                i++;
            }
        }

        item createNewOrderItem(int id)
        {
            item i = new item();
            i.id = id;
            orderList.Add(i);
            return i;
        }

        void setAmount(int id)
        {
            NumericUpDown qtyCart = ((NumericUpDown)this.Controls.Find("itemQtyCartTB" + id, true)[0]);
            NumericUpDown qtyPc = ((NumericUpDown)this.Controls.Find("itemQtyPcTB" + id, true)[0]);
            NumericUpDown unitPrice = ((NumericUpDown)this.Controls.Find("itemUnitPriceTB" + id, true)[0]);
            NumericUpDown tradeOffer = ((NumericUpDown)this.Controls.Find("tradeOfferTB" + id, true)[0]);
            Label amount = ((Label)this.Controls.Find("totalLB" + id, true)[0]);
            BunifuDropdown name = ((BunifuDropdown)this.Controls.Find("itemNameCombo" + id, true)[0]);
            ComboBox desc = ((ComboBox)this.Controls.Find("itemDescCombo" + id, true)[0]);
            ComboBox expiry = ((ComboBox)this.Controls.Find("expiry" + id, true)[0]);
            if (qtyCart.Value > qtyCart.Maximum)
                qtyCart.Value = qtyCart.Maximum;
            if (qtyPc.Value > qtyPc.Maximum)
                qtyPc.Value = qtyPc.Maximum;
            if (name.selectedIndex != -1 && desc.SelectedIndex != -1 && expiry.SelectedIndex != -1)
                foreach (item i in orderList)
                {
                    if (i.Name == name.selectedValue && i.desc == desc.Text && i.expiry == expiry.Text)
                    {
                        i.rate = int.Parse(unitPrice.Value.ToString());
                        i.qtypcs = int.Parse(qtyPc.Text);
                        i.qtycart = int.Parse(qtyCart.Text);
                        i.tradeOffer = tradeOffer.Value.ToString();
                        double total = calculateItemTotal(i);
                        amount.Text = total.ToString();
                        i.total = double.Parse(total.ToString());
                    }
                }
        }

        public void getAllCCustomers()
        {
            List<string> s = new List<string>();
            FacadeController f = FacadeController.getFController();
            cust = f.getAllCustomersInfo();
        }

        bool validate()
        {
            bool validated = false;

            foreach (item i in orderList)
            {
                NumericUpDown qtyCart = ((NumericUpDown)this.Controls.Find("itemQtyCartTB" + i.id, true)[0]);
                NumericUpDown qtyPc = ((NumericUpDown)this.Controls.Find("itemQtyPcTB" + i.id, true)[0]);
                NumericUpDown unitPrice = ((NumericUpDown)this.Controls.Find("itemUnitPriceTB" + i.id, true)[0]);
                NumericUpDown tradeOffer = ((NumericUpDown)this.Controls.Find("tradeOfferTB" + i.id, true)[0]);
                Label amount = ((Label)this.Controls.Find("totalLB" + i.id, true)[0]);
                BunifuDropdown name = ((BunifuDropdown)this.Controls.Find("itemNameCombo" + i.id, true)[0]);
                ComboBox desc = ((ComboBox)this.Controls.Find("itemDescCombo" + i.id, true)[0]);
                if (qtyCart.Text == "" || qtyPc.Text == "" || unitPrice.Text == "" || tradeOffer.Text == ""
                    || amount.Text == "" || name.selectedIndex == -1 || desc.Text == "" || !validateAmounts() || !validateBillDetails())
                {
                    validated = false;
                }
                else
                    validated = true;
            }
            return validated;
        }

        private void autoCompleteList_Click(object sender, EventArgs e)
        {
            if (autoCompleteList.SelectedItems.Count == 1)
            {
                billNameTB.Text = autoCompleteList.SelectedItems[0].Text;
                billPhoneTB.Text = autoCompleteList.SelectedItems[0].SubItems[1].Text;
                billNTNTB.Text = autoCompleteList.SelectedItems[0].SubItems[2].Text;
                if (billNTNTB.Text != "nil")
                    billNTNCheck.Checked = true;
                else
                    billNTNCheck.Checked = false;
                billAddressTB.Text = autoCompleteList.SelectedItems[0].SubItems[3].Text;
                autoCompletePanel.Visible = false;
                int id = int.Parse(autoCompleteList.SelectedItems[0].Name);
                getDeliveryAddress(id);
            }
        }

        void getDeliveryAddress(int id)
        {
            FacadeController f = FacadeController.getFController();
            deliveryAddressTB.Text = f.getDeliveryAddress(id);
        }

        private void billNameTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            autoCompleteList.Clear();
            if (billNameTB.Text == "")
                autoCompletePanel.Visible = false;
            else
            {
                foreach (Customer c in cust)
                {
                    if (c.Name.ToLower().Contains(billNameTB.Text.ToLower()))
                    {
                        autoCompletePanel.Visible = true;
                        autoCompleteList.Items.Add(c.Name);
                        autoCompleteList.Items[autoCompleteList.Items.Count - 1].SubItems.Add(c.Phone);
                        autoCompleteList.Items[autoCompleteList.Items.Count - 1].SubItems.Add(c.NTN);
                        autoCompleteList.Items[autoCompleteList.Items.Count - 1].SubItems.Add(c.Address);
                        autoCompleteList.Items[autoCompleteList.Items.Count - 1].Name = c.id.ToString();
                    }
                }
            }
        }

        int getProductID(int id)
        {
            BunifuDropdown name = ((BunifuDropdown)this.Controls.Find("itemNameCombo" + id, true)[0]);
            ComboBox desc = ((ComboBox)this.Controls.Find("itemDescCombo" + id, true)[0]);
            ComboBox expiry = ((ComboBox)this.Controls.Find("expiry" + id, true)[0]);
            foreach (item i in itemsList)
            {
                if (i.Name == name.selectedValue && i.desc == desc.Text && i.expiry == expiry.Text)
                {
                    return i.id;
                }
            }
            return 0;
        }

    }
}
