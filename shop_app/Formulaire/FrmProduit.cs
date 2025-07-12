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
    public partial class FrmProduit : Form
    {
        public FrmProduit()
        {
            InitializeComponent();
        }

        clsProduit pr = new clsProduit();
        void InsertUpdateDelete(int a)
        {
            pr.Nom_produit = txtNomProduit.Text;
            pr.Prix_unitaire = double.Parse(txtPU.Text);
            pr.RefCategorie = int.Parse(clsGlossiaire.GetInstance().getcode_Combo("tCategorie", "id", "nom_categorie", cmbCategorie.Text));

            if (a == 1)
            {
                pr.Id = -1;
                clsGlossiaire.GetInstance().saveProduit(pr);
                liste_data.DataSource = clsGlossiaire.GetInstance().loadData("Afficher_Produit");
            }
            else if (a == 2)
            {
                pr.Id = int.Parse(txtId.Text);
                clsGlossiaire.GetInstance().saveProduit(pr);
                liste_data.DataSource = clsGlossiaire.GetInstance().loadData("Afficher_Produit");
            }
            else if (a == 3)
            {
                clsGlossiaire.GetInstance().deleteData("tCategorie", "id", int.Parse(txtId.Text));
                liste_data.DataSource = clsGlossiaire.GetInstance().loadData("Afficher_Produit");
            }
        }

        private void FrmProduit_Load(object sender, EventArgs e)
        {
            liste_data.DataSource = clsGlossiaire.GetInstance().loadData("Afficher_Produit");
            clsGlossiaire.GetInstance().loadCombo("tCategorie", "nom_categorie",cmbCategorie);
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
