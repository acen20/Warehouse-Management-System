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
    public partial class assignVan : UserControl
    {
        public assignVan()
        {
            InitializeComponent();
        }

        List<Van> vans = new List<Van>();

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void billsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            changeGridColors("selected");
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
                billsGrid.DefaultCellStyle.SelectionBackColor = Color.Crimson;
                billsGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            }

        }

        private void assignVan_Load(object sender, EventArgs e)
        {
            update();
        }

        public DataTable getAllUnassignedBills()
        {
            billsGrid.Columns.Clear();
            FacadeController f = FacadeController.getFController();
            DataTable dt=f.getAllBills().Tables["myTable"];
            foreach(DataRow r in dt.Rows)
            {
                if(r["salesman"].ToString()!="nil")
                {
                    r.Delete();
                }
            }
            billsGrid.DataSource = dt;
            billsGrid.Columns["total"].Visible = false;
            billsGrid.Columns["subtotal"].Visible = false;
            billsGrid.Columns["id"].Visible = false;
            billsGrid.Columns["date"].Visible = false;
            billsGrid.Columns["wht"].Visible = false;
            billsGrid.Columns["tax"].Visible = false;
            billsGrid.Columns["returned"].Visible = false;
            billsGrid.Columns["discount"].Visible = false;
            return dt;
        }

        public void getAllVans()
        {
            vansFlow.Controls.Clear();
            FacadeController f = FacadeController.getFController();
            DataTable dt=f.getAllVans().Tables["myTable"];
            foreach(DataRow r in dt.Rows)
            {
                createVan(r);
            }
        }

        void createVan(DataRow r)
        {
            Van v = new Van();
            v.id = r["id"].ToString();
            v.vehicleNo = r["vehicle no"].ToString();
            v.phone = r["driver no"].ToString();
            v.Name = r["name"].ToString();
            v.mileage = r["mileage"].ToString();
            v.cnic = r["Cnic"].ToString();
            vans.Add(v);
            createVanButton(v);
        }

        void createVanButton(Van v)
        {
            Button b = new Button();
            b.BackColor = Color.White;
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.Maroon;
            b.FlatStyle = FlatStyle.Flat;
            b.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            b.ForeColor = Color.DimGray;
            b.Image =Properties.Resources.whiteTruck;
            b.ImageAlign = ContentAlignment.MiddleRight;
            b.Name = "button"+v.id;
            b.Tag = v.id;
            b.Size = new Size(411, 40);
            b.Text = v.vehicleNo + ", " + v.Name + ", " + v.mileage;
            b.TextAlign = ContentAlignment.MiddleLeft;
            b.Click += (s, args) => vanClick(v);
            b.MouseEnter += (s, args) => mouseEnter(b);
            b.MouseLeave += (s, args) => mouseLeave(b);
            vansFlow.Controls.Add(b);
        }

        void vanClick(Van v)
        {
            if (billsGrid.SelectedRows.Count == 1)
                fillDetailsPanel(v);
            else
                MetroMessageBox.Show(this, "Please select a row from bills", "Caution", MessageBoxButtons.OK,MessageBoxIcon.Stop, 200);
        }

        void fillDetailsPanel(Van v)
        {
            detailsPanel.Visible = true;
            billNoLB.Text = billsGrid.SelectedRows[0].Cells["billno"].Value.ToString();
            vanNoLB.Text = v.vehicleNo;
            nameLB.Text = v.Name;
            PhoneLB.Text = v.phone;
            mileageLB.Text = v.mileage;
        }

        public void update()
        {
            getAllUnassignedBills();
            getAllVans();
            changeGridColors("unselected");
            detailsPanel.Visible = false;
        }

        private void vanSearchTB_TextChanged(object sender, EventArgs e)
        {
            if (vanSearchTB.Text != "")
            {
                string v = vanSearchTB.Text.ToLower();
                foreach(Control c in vansFlow.Controls)
                {
                    string buttonText = c.Text.ToLower();
                    if (buttonText.Contains(v))
                    {
                        c.Visible = true;
                    }
                    else
                        c.Visible = false;
                }
            }
            else
                getAllVans();
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            detailsPanel.Visible = false;
        }

        private void confirmBTN_Click(object sender, EventArgs e)
        {
            updateSalesman();
        }

        void updateSalesman()
        {
            FacadeController f = FacadeController.getFController();
            f.updateSalesman(billNoLB.Text, vanNoLB.Text);
            MetroMessageBox.Show(this, "Bill No. "+billNoLB.Text+" assigned to Van "+vanNoLB.Text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, 200);
            update();
        }

        private void billsGrid_SelectionChanged(object sender, EventArgs e)
        {
            detailsPanel.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        void mouseEnter(Button b)
        {
            b.ForeColor = Color.White;
        }

        void mouseLeave(Button b)
        {
            b.ForeColor = Color.DimGray;
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
                getAllUnassignedBills();
        }
    }
}
