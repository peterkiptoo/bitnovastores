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
    public partial class reports : Form
    {
        public reports()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DoneOrdersReport done = new DoneOrdersReport();
            done.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UsedStockReport used = new UsedStockReport();
            used.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LowStockReport low = new LowStockReport();
            low.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ReceivedStockReport receive = new ReceivedStockReport();
            receive.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LiveOrdersReport live = new LiveOrdersReport();
            live.ShowDialog();
        }
    }
}
