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
    public partial class products : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;Initial Catalog=bitnovastores;Integrated Security=false");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public products()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter ad = new MySqlDataAdapter("select name from products where name='" + txtName.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Field cannot be Empty!");
                return;
            }
            else if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("Product Already Exists!");
                return;
            }
            else
                ds = new DataSet();
            adapter = new MySqlDataAdapter("insert into products(name,qty,category,supplier,tdate) VALUES('" + txtName.Text + "','" + txtQty.Text + "','" + drpCategory.Text + "','" + txtSupplier.Text + "','" + DateTime.Now.ToString("yyyyMMdd") + "')", con);
            adapter.Fill(ds, "products");
            MessageBox.Show("Added Successfully!");
            txtName.Text = txtQty.Text = txtSupplier.Text = drpCategory.Text = "";
            GetRecords();
            con.Close();
        }
        private void GetRecords()
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select * from products", con);
            adapter.Fill(ds, "products");
            dataGridViewProduct.DataSource = ds;
            dataGridViewProduct.DataMember = "products";
            con.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int i = dataGridViewProduct.CurrentRow.Index;
            lblId.Text = dataGridViewProduct[0, i].Value.ToString();
            txtQty.Text = dataGridViewProduct[2, i].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = dataGridViewProduct.CurrentRow.Index;
            ds = new DataSet();
            adapter = new MySqlDataAdapter("delete from products where id=" + dataGridViewProduct[0, 0].Value.ToString(), con);
            adapter.Fill(ds, "products");
            //txtCommodity.Clear();
            lblId.Text = "";
            GetRecords();
            con.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            EasyHTMLReports print = new EasyHTMLReports();
            print.AddLineBreak();
            print.HeaderBackgroundColor = Color.Maroon;
            print.AddString("<h2>Bitnova Stores</h2>");
            print.AddLineBreak();
            print.AddString("<h3>Products</h3>");
            print.AddHorizontalRule();
            print.AddDatagridView(dataGridViewProduct);
            print.ShowPrintPreviewDialog();
        }

        private void products_Load(object sender, EventArgs e)
        {
            GetRecords();
            populateComboProd();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("update products set qty = '" + txtQty.Text + "' where id =" + lblId.Text, con);
            adapter.Fill(ds, "products");
            //txtCommodity.Clear();
            lblId.Text = "";
            GetRecords();
            con.Close();
        }
        private void populateComboProd()
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
    }
}
