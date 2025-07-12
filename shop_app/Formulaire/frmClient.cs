using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using shop_app.Classes;

namespace shop_app.Formulaire
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        clsClient cl = new clsClient();

        void InsertUpdateDelete(int a)
        {
            cl.Noms = txtNoms.Text;
            cl.Adresse = txtAdresse.Text;
            cl.Contact = txtContact.Text;

            if (a == 1)
            {
                cl.Id = -1;
                clsGlossiaire.GetInstance().insertClient(cl);
                liste_data.DataSource = clsGlossiaire.GetInstance().loadData("tClient");
            }
            else if (a == 2)
            {
                cl.Id = int.Parse(txtId.Text);
                clsGlossiaire.GetInstance().insertClient(cl);
                liste_data.DataSource = clsGlossiaire.GetInstance().loadData("tClient");
            }
            else if (a == 3)
            {
                clsGlossiaire.GetInstance().deleteData("tClient", "id", int.Parse(txtId.Text));
                liste_data.DataSource = clsGlossiaire.GetInstance().loadData("tClient");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtId.Text="";
            txtNoms.Text = "";
            txtAdresse.Text = "";
            txtContact.Text = "";
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            liste_data.DataSource = clsGlossiaire.GetInstance().loadData("tClient");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertUpdateDelete(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertUpdateDelete(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InsertUpdateDelete(3);
        }
    }
}
