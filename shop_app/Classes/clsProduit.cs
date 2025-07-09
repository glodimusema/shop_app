using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.Classes
{
    class clsProduit
    {
        int id;
        string nom_produit;
        double prix_unitaire;
        int refCategorie;

        public int Id { get => id; set => id = value; }
        public string Nom_produit { get => nom_produit; set => nom_produit = value; }
        public double Prix_unitaire { get => prix_unitaire; set => prix_unitaire = value; }
        public int RefCategorie { get => refCategorie; set => refCategorie = value; }
    }
}
