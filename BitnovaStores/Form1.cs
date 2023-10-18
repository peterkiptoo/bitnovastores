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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            profile profile = new profile();
            profile.txtUser.Text = lblUser.Text;
            profile.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            warehouse warehouse = new warehouse();
            warehouse.ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.ShowDialog();
           

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            categories category = new categories();
            category.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            suppliers supplier = new suppliers();
            supplier.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            products product = new products();
            product.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            users user = new users();
            user.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            alerts alert = new alerts();
            alert.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            settings setting = new settings();
            setting.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            reports report = new reports();
            report.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            login login = new login();
            login.ShowDialog();
        }
    }
}
