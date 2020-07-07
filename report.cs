using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class report : UserControl
    {
        public report()
        {
            InitializeComponent();
        }

        public string name;
        public string desc;
        public string dispatch;
        public string expiry;
        public string purchasedOn;
        public bool damaged;
        public string company;
        public string quantity;
        public string reason="";
        public string purchasePrice;
        public string salePrice;

        public void setValues()
        {
            nameLB.Text = name;
            descriptionLB.Text = desc;
            dispatchnoLB.Text = dispatch;
            expiryLB.Text = expiry;
            purchasedOnLB.Text = purchasedOn;

            if (damaged == true)
                damagedPanel.BackColor = Color.Crimson;
            else
                damagedPanel.BackColor = Color.RoyalBlue;
            if (reason != "")
                reasonLB.Text = reason;
            else
                reasonLB.Text = "-";

            salePriceLB.Text = salePrice;
            purchasePriceLB.Text = purchasePrice;
            companyLB.Text = company;
            qtyLB.Text = quantity;
        }
    }
}
