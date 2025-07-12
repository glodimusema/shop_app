using shop_app.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop_app.Formulaire
{
    public partial class frmCategorie : Form
    {
        public frmCategorie()
        {
            InitializeComponent();
        }

        clsCategorie c = new clsCategorie();

        void InsertUpdateDelete(int a)
        {
            c.Nom_categorie = txtNomCategorie.Text;

            if (a == 1)
            {
                c.Id = -1;
                clsGlossiaire.GetInstance().saveCategorie(c);
                liste_data.DataSource = clsGlossiaire.GetInstance().loadData("tCategorie");
            }
            else if (a == 2)
            {
                c.Id = int.Parse(txtId.Text);
                clsGlossiaire.GetInstance().saveCategorie(c);
                liste_data.DataSource = clsGlossiaire.GetInstance().loadData("tCategorie");
            }
            else if (a == 3)
            {
                clsGlossiaire.GetInstance().deleteData("tCategorie", "id", int.Parse(txtId.Text));
                liste_data.DataSource = clsGlossiaire.GetInstance().loadData("tCategorie");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNomCategorie.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertUpdateDelete(1);
        }

        private void frmCategorie_Load(object sender, EventArgs e)
        {
            liste_data.DataSource = clsGlossiaire.GetInstance().loadData("tCategorie");
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
