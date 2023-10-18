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
    public partial class alerts : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;Initial Catalog=bitnovastores;Integrated Security=false");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public alerts()
        {
            InitializeComponent();
        }

        private void alerts_Load(object sender, EventArgs e)
        {
            GetRecords();
        }
        private void GetRecords()
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select * from products where qty < 10", con);
            adapter.Fill(ds, "products");
            dataGridViewAlerts.DataSource = ds;
            dataGridViewAlerts.DataMember = "products";
            con.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            EasyHTMLReports print = new EasyHTMLReports();
            print.AddLineBreak();
            print.HeaderBackgroundColor = Color.Maroon;
            print.AddString("<h2>Bitnova Stores</h2>");
            print.AddLineBreak();
            print.AddString("<h3>Low Stock Alert</h3>");
            print.AddHorizontalRule();
            print.AddDatagridView(dataGridViewAlerts);
            print.ShowPrintPreviewDialog();
        }
    }
}
