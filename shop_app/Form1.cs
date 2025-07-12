using shop_app.Formulaire;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmClient c = new frmClient();
            c.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCategorie cat = new frmCategorie();
            cat.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmProduit pr = new FrmProduit();
            pr.ShowDialog();
        }
    }
}
