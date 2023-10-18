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
    public partial class warehouse : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;Initial Catalog=bitnovastores;Integrated Security=false");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        DataTable dt = new DataTable();
        DataTable dtw = new DataTable("products");
        public DataSet ds = new DataSet();
      
        public DataSet dsr = new DataSet();
        public warehouse()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void warehouse_Load(object sender, EventArgs e)
        {
            GetRecords();
            populateComboCat();
            populateComboSupp();
            populateComboDate();

        }
        private void GetRecords()
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select * from products", con);
            adapter.Fill(ds, "products");
            dataGridViewWarehouse.DataSource = ds;
            dataGridViewWarehouse.DataMember = "products";
            con.Close();
        }
        private void populateComboCat()
        {
            string sQuery = "SELECT * FROM categories";
            con.Open();
            MySqlCommand comnd = new MySqlCommand(sQuery, con);
            MySqlDataReader rdr = comnd.ExecuteReader();
            while (rdr.Read())
            {
                drpCategory.Items.Add(rdr.GetString("name"));

            }
            con.Close();

        }
        private void populateComboSupp()
        {
            string sQuery = "SELECT * FROM suppliers";
            con.Open();
            MySqlCommand comnd = new MySqlCommand(sQuery, con);
            MySqlDataReader rdr = comnd.ExecuteReader();
            while (rdr.Read())
            {
                drpSupplier.Items.Add(rdr.GetString("name"));

            }
            con.Close();

        }
        private void populateComboDate()
        {
            string sQuery = "SELECT * FROM products";
            con.Open();
            MySqlCommand comnd = new MySqlCommand(sQuery, con);
            MySqlDataReader rdr = comnd.ExecuteReader();
            while (rdr.Read())
            {
                drpDate.Items.Add(rdr.GetString("tdate"));

            }
            con.Close();

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            EasyHTMLReports print = new EasyHTMLReports();
            print.AddLineBreak();
            print.HeaderBackgroundColor = Color.Maroon;
            print.AddString("<h2>Bitnova Stores</h2>");
            print.AddLineBreak();
            print.AddString("<h3>Stock</h3>");
            print.AddHorizontalRule();
            print.AddDatagridView(dataGridViewWarehouse);
            print.ShowPrintPreviewDialog();
        }

        private void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            MySqlDataAdapter sdf = new MySqlDataAdapter("SELECT * FROM products WHERE category='" + drpCategory.Text + "'", con);
            DataTable sd = new DataTable();
            sdf.Fill(sd);
            DataView SortedDataView = new DataView();
            SortedDataView = sd.DefaultView;
            SortedDataView.Sort = "id DESC";
            dataGridViewWarehouse.DataSource = sd;
            con.Close();
        }

        private void drpSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            MySqlDataAdapter sdf = new MySqlDataAdapter("SELECT * FROM products WHERE supplier='" + drpSupplier.Text + "'", con);
            DataTable sd = new DataTable();
            sdf.Fill(sd);
            DataView SortedDataView = new DataView();
            SortedDataView = sd.DefaultView;
            SortedDataView.Sort = "id DESC";
            dataGridViewWarehouse.DataSource = sd;
            con.Close();
        }

        private void drpDate_SelectedIndexChanged(object sender, EventArgs e)
        {

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            MySqlDataAdapter sdf = new MySqlDataAdapter("SELECT * FROM products WHERE tdate='" + drpDate.Text + "'", con);
            DataTable sd = new DataTable();
            sdf.Fill(sd);
            DataView SortedDataView = new DataView();
            SortedDataView = sd.DefaultView;
            SortedDataView.Sort = "id DESC";
            dataGridViewWarehouse.DataSource = sd;
            con.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            receive_stock stock = new receive_stock();
            stock.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            orders order = new orders();
            order.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            use_stock stock = new use_stock();
            stock.ShowDialog();
        }
    }
}
