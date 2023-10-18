using KimToo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitnovaStores
{
    public partial class UsedStockReport : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;Initial Catalog=bitnovastores;Integrated Security=false");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public UsedStockReport()
        {
            InitializeComponent();
        }

        private void UsedStockReport_Load(object sender, EventArgs e)
        {
            GetRecords();
        }
        private void GetRecords()
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select * from usedstock", con);
            adapter.Fill(ds, "usedstock");
            dataGridViewAlerts.DataSource = ds;
            dataGridViewAlerts.DataMember = "usedstock";
            con.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            EasyHTMLReports print = new EasyHTMLReports();
            print.AddLineBreak();
            print.HeaderBackgroundColor = Color.Maroon;
            print.AddString("<h2>Bitnova Stores</h2>");
            print.AddLineBreak();
            print.AddString("<h3>Used Stock Report</h3>");
            print.AddHorizontalRule();
            print.AddDatagridView(dataGridViewAlerts);
            print.ShowPrintPreviewDialog();
        }
    }
}
