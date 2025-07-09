using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.Classes
{
    class clsDetailVente
    {
        int id;
        int refEntete;
        int refProduit;
        double qte;
        double pu;

        public int Id { get => id; set => id = value; }
        public int RefEntete { get => refEntete; set => refEntete = value; }
        public int RefProduit { get => refProduit; set => refProduit = value; }
        public double Qte { get => qte; set => qte = value; }
        public double Pu { get => pu; set => pu = value; }
    }
}
