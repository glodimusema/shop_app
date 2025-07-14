using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace shop_app.Classes
{
    class clsGlossiaire
    {
        public static clsGlossiaire _instance = null;

        public static clsGlossiaire GetInstance()
        {
            if (_instance == null)
                _instance = new clsGlossiaire();
            return _instance;
        }


        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataAdapter dt = null;
        SqlDataReader dr = null;

        public void InnitialiseConnexion()
        {
            try
            {
                con = new SqlConnection(clsConnexion.chemin);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de Connextion" + ex.Message);
            }
        }


        private static void setParameter(SqlCommand cmd, string name, DbType type, int length, object paramValue)
        {
            IDbDataParameter a = cmd.CreateParameter();
            a.ParameterName = name;
            a.Size = length;
            a.DbType = type;

            if (paramValue == null)
            {
                if (!a.IsNullable)
                {
                    a.DbType = DbType.String;
                }
                a.Value = DBNull.Value;
            }
            else
                a.Value = paramValue;
            cmd.Parameters.Add(a);
        }

        //LES INSERTIONS ======================================

        public void insertClient(clsClient cli)
        {
            try
            {
                InnitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("EXEC saveClient @id,@noms,@adresse,@contact", con);
                cmd.Parameters.AddWithValue("@id", cli.Id);
                cmd.Parameters.AddWithValue("@noms", cli.Noms);
                cmd.Parameters.AddWithValue("@adresse", cli.Adresse);
                cmd.Parameters.AddWithValue("@contact", cli.Contact);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void saveCategorie(clsCategorie cli)
        {
            try
            {
                InnitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("EXEC saveCategorie @id,@nom_categorie", con);
                cmd.Parameters.AddWithValue("@id", cli.Id);
                cmd.Parameters.AddWithValue("@nom_categorie", cli.Nom_categorie);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void saveProduit(clsProduit cli)
        {
            try
            {
                InnitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("EXEC saveProduit @id,@nom_produit,@prix_unitaire,@refCategorie", con);
                cmd.Parameters.AddWithValue("@id", cli.Id);
                cmd.Parameters.AddWithValue("@nom_produit", cli.Nom_produit);
                cmd.Parameters.AddWithValue("@prix_unitaire", cli.Prix_unitaire);
                cmd.Parameters.AddWithValue("@refCategorie", cli.RefCategorie);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void saveEnteteVente(clsEnteteVente cli)
        {
            try
            {
                InnitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("EXEC saveEnteteVente @id,@refClient,@dateVente", con);
                cmd.Parameters.AddWithValue("@id", cli.Id);
                cmd.Parameters.AddWithValue("@refClient", cli.RefClient);
                cmd.Parameters.AddWithValue("@dateVente", cli.DateVente);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void saveDetailVente(clsDetailVente cli)
        {
            try
            {
                InnitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("EXEC saveDetailVente @id,@refEntete,@refProduit,@qte,@pu", con);
                cmd.Parameters.AddWithValue("@id", cli.Id);
                cmd.Parameters.AddWithValue("@refEntete", cli.RefEntete);
                cmd.Parameters.AddWithValue("@refProduit", cli.RefProduit);
                cmd.Parameters.AddWithValue("@qte", cli.Qte);
                cmd.Parameters.AddWithValue("@pu", cli.Pu);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public DataTable loadData(string nomTable)
        {

            InnitialiseConnexion();
            if (!con.State.ToString().ToLower().Equals("open")) con.Open();
            DataTable table = new DataTable();
            dt = new SqlDataAdapter("select * from " + nomTable + "", con);
            dt.Fill(table);
            con.Close();

            return table;
        }
        public void deleteData(string nomTable,string champId,int id)
        {
            try
            {
                InnitialiseConnexion();
                con.Open();
                cmd = new SqlCommand("DELETE FROM "+nomTable+" where "+champId+"=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadCombo(string nomTable, string nomchamp, System.Windows.Forms.ComboBox comb1)
        {
            InnitialiseConnexion();
            if (!con.State.ToString().ToLower().Equals("open")) con.Open();
            DataTable table = new DataTable();
            dt = new SqlDataAdapter("SELECT " + nomchamp + " FROM " + nomTable + "", con);
            try
            {
                DataTable dt1 = new DataTable();
                dt.Fill(dt1);

                foreach (DataRow dr in dt1.Rows)
                {
                    comb1.Items.Add(dr[nomchamp]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex);
            }

            con.Close();
        }

        public string getcode_Combo(string nomTable, string nomChampId, string nomChamp, string valeur)
        {
            string IdData = "";
            try
            {
                InnitialiseConnexion();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("select " + nomChampId + " from " + nomTable + " where " + nomChamp + "=@a", con);
                cmd.Parameters.AddWithValue("@a", valeur);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IdData = (dr[nomChampId].ToString());
                }
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return IdData;
        }





        public DataSet get_Report_All(string nomTable)
        {
            DataSet dst;
            try
            {
                InnitialiseConnexion();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("SELECT * FROM " + nomTable + "", con);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }
        public DataSet get_Report_Trier(string nomTable, string nomchamp, DateTime val1, DateTime val2)
        {
            DataSet dst;
            try
            {
                InnitialiseConnexion();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("SELECT * FROM " + nomTable + " WHERE " + nomchamp + " between @date1 and @date2 ", con);
                setParameter(cmd, "@date1", DbType.DateTime, 30, val1);
                setParameter(cmd, "@date2", DbType.DateTime, 30, val2);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }

        public DataSet get_Report_One(string nomTable, string nomchamp, string val1)
        {
            DataSet dst;
            try
            {
                InnitialiseConnexion();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("SELECT * FROM " + nomTable + " WHERE " + nomchamp + " = @val1 ", con);
                setParameter(cmd, "@val1", DbType.String, 30, val1);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }



    }




}

