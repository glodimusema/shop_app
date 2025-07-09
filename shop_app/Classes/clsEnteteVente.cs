using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.Classes
{
    class clsEnteteVente
    {
        int id;
        int refClient;
        DateTime dateVente;

        public int Id { get => id; set => id = value; }
        public int RefClient { get => refClient; set => refClient = value; }
        public DateTime DateVente { get => dateVente; set => dateVente = value; }
    }
}
