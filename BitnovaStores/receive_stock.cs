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
    public partial class receive_stock : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;Initial Catalog=bitnovastores;Integrated Security=false");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public receive_stock()
        {
            InitializeComponent();
        }

        private void receive_stock_Load(object sender, EventArgs e)
        {
            GetRecords();
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

        private void dataGridViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridViewProduct.CurrentRow.Index;
            lblId.Text = dataGridViewProduct[0, i].Value.ToString();
            txtQty.Text = dataGridViewProduct[2, i].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int i = dataGridViewProduct.CurrentRow.Index;
            try {
                ds = new DataSet();
                adapter = new MySqlDataAdapter("update products set qty = qty +'" + txtQty.Text + "' where id =" + lblId.Text, con);
                adapter.Fill(ds, "products");
                //txtQty.Clear();
                lblId.Text = "";
                GetRecords();
                ds = new DataSet();
                adapter = new MySqlDataAdapter("insert into receivedstock(name,qty,category,supplier,tdate) VALUES('" + dataGridViewProduct[1, i].Value.ToString() + "','" + txtQty.Text + "','" + dataGridViewProduct[3, i].Value.ToString() + "','" + dataGridViewProduct[4, i].Value.ToString() + "','" + DateTime.Now.ToString("yyyyMMdd") + "')", con);
                adapter.Fill(ds, "receivedstock");
                con.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
