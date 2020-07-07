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
using System.Globalization;

namespace Warehouse
{
    public partial class loadSheetUserControl : UserControl
    {
        public loadSheetUserControl()
        {
            InitializeComponent();
        }

        DataTable sheet = new DataTable();

        private void printBTN_MouseLeave(object sender, EventArgs e)
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

        public void refreshGrid()
        {
            FacadeController f = FacadeController.getFController();
            loadGrid.Columns.Clear();
            sheet = f.getLoadSheet();
            getReport();
            loadGrid.Columns["date"].Visible = false;
            changeGridColors("unselected");
        }

        void changeGridColors(string state)
        {
            if (state == "unselected")
            {
                loadGrid.DefaultCellStyle.SelectionBackColor = Color.White;
                loadGrid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);
            }

            if (state == "selected")
            {
                loadGrid.DefaultCellStyle.SelectionBackColor = Color.MidnightBlue;
                loadGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            }

        }

        private void fromDate_ValueChanged(object sender, EventArgs e)
        {
            getReport();
        }

        void getReport()
        {
            DateTime from = fromDate.Value;
            DateTime to = toDate.Value;
            DataTable dt = new DataTable();
            foreach (DataColumn c in sheet.Columns)
            {
                dt.Columns.Add(c.ColumnName);
            }
            foreach (DataRow r in sheet.Rows)
            {
                DateTime date = DateTime.ParseExact(r["date"].ToString(), "dd-MM-yyyy hh:mm tt", CultureInfo.InvariantCulture);
                if (date >= from && date <= to)
                {
                    DataRow row = dt.NewRow();
                    row["Product"] = r["Product"];
                    row["Customer"] = r["Customer"];
                    row["Address"] = r["Address"];
                    row["Van"] = r["Van"];
                    dt.Rows.Add(row);
                }
            }
            loadGrid.DataSource = dt;
        }

        private void loadSheetUserControl_Load(object sender, EventArgs e)
        {
            fromDate.Value = DateTime.Now;
            toDate.Value = DateTime.Now;
        }
    }
}
