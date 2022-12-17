using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OECE
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                
                   
                SqlConnection connessioneDB = new SqlConnection();
                connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["connessioneOECE"].ToString();
                connessioneDB.Open();
                try
                {
                SqlCommand ottenere = new SqlCommand();
                ottenere.CommandText = "SELECT * FROM ItemLoPossiedoLoVoglio WHERE LoPossiedo = 'false' AND LoVoglio = 'true'";
                ottenere.Connection = connessioneDB;

                SqlDataReader readerOttenere = ottenere.ExecuteReader();

                if (readerOttenere.HasRows)
                {
                        OECE.OECEList.Clear();
                        while (readerOttenere.Read()) 
                    {
                            OECE n = new OECE();
                            n.ID   = Convert.ToInt32(readerOttenere["ID_ItemObbiettivo"]);
                            n.Item = readerOttenere["ItemObbiettivo"].ToString();
                            n.LoPossiedo = Convert.ToBoolean(readerOttenere["LoPossiedo"]);
                            n.LoVoglio = Convert.ToBoolean(readerOttenere["LoVoglio"]);
                            OECE.OECEList.Add(n);
                    
                    }
                        Repeater_Ottenere.DataSource = OECE.OECEList;
                        Repeater_Ottenere.DataBind();
                }
                } catch(Exception ex)
                {
                    Label_ERROR.Text = ex.Message;
                }

                try
                {
                    SqlCommand conservare = new SqlCommand();
                    conservare.CommandText = "SELECT * FROM ItemLoPossiedoLoVoglio WHERE LoPossiedo = 'true' AND LoVoglio = 'true'";
                    conservare.Connection = connessioneDB;

                    SqlDataReader readerConservare = conservare.ExecuteReader();

                    if (readerConservare.HasRows)
                    {

                        OECE.OECEList.Clear();
                        while (readerConservare.Read())
                        {
                            OECE n = new OECE();
                            n.ID = Convert.ToInt32(readerConservare["ID_ItemObbiettivo"]);
                            n.Item = readerConservare["ItemObbiettivo"].ToString();
                            n.LoPossiedo = Convert.ToBoolean(readerConservare["LoPossiedo"]);
                            n.LoVoglio = Convert.ToBoolean(readerConservare["LoVoglio"]);
                            OECE.OECEList.Add(n);

                        }
                        Repeater_Conservare.DataSource = OECE.OECEList;
                        Repeater_Conservare.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Label_ERROR.Text = ex.Message;
                }

                try
                {
                    SqlCommand evitare = new SqlCommand();
                    evitare.CommandText = "SELECT * FROM ItemLoPossiedoLoVoglio WHERE LoPossiedo = 'false' AND LoVoglio = 'false'";
                    evitare.Connection = connessioneDB;

                    SqlDataReader readerEvitare = evitare.ExecuteReader();

                    if (readerEvitare.HasRows)
                    {

                        OECE.OECEList.Clear();
                        while (readerEvitare.Read())
                        {
                            OECE n = new OECE();
                            n.ID = Convert.ToInt32(readerEvitare["ID_ItemObbiettivo"]);
                            n.Item = readerEvitare["ItemObbiettivo"].ToString();
                            n.LoPossiedo = Convert.ToBoolean(readerEvitare["LoPossiedo"]);
                            n.LoVoglio = Convert.ToBoolean(readerEvitare["LoVoglio"]);
                            OECE.OECEList.Add(n);

                        }
                        Repeater_Evitare.DataSource = OECE.OECEList;
                        Repeater_Evitare.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Label_ERROR.Text = ex.Message;
                }

                try
                {
                    SqlCommand eliminare = new SqlCommand();
                    eliminare.CommandText = "SELECT * FROM ItemLoPossiedoLoVoglio WHERE LoPossiedo = 'true' AND LoVoglio = 'false'";
                    eliminare.Connection = connessioneDB;

                    SqlDataReader readerEliminare = eliminare.ExecuteReader();

                    if (readerEliminare.HasRows)
                    {

                        OECE.OECEList.Clear();
                        while (readerEliminare.Read())
                        {
                            OECE n = new OECE();
                            n.ID = Convert.ToInt32(readerEliminare["ID_ItemObbiettivo"]);
                            n.Item = readerEliminare["ItemObbiettivo"].ToString();
                            n.LoPossiedo = Convert.ToBoolean(readerEliminare["LoPossiedo"]);
                            n.LoVoglio = Convert.ToBoolean(readerEliminare["LoVoglio"]);
                            OECE.OECEList.Add(n);

                        }
                        Repeater_Eliminare.DataSource = OECE.OECEList;
                        Repeater_Eliminare.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Label_ERROR.Text = ex.Message;
                }



                connessioneDB.Close();
            }
        }

        protected void Button_InviaAlDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connessioneDB = new SqlConnection();
                connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["connessioneOECE"].ToString();
                connessioneDB.Open();

                SqlCommand ottenere = new SqlCommand();

                ottenere.Parameters.AddWithValue("@ItemObbiettivo", TextBox_AggiungiNuovaVoce.Text);
                ottenere.Parameters.AddWithValue("@LoVoglio", CheckBox_LoVoglio.Checked);
                ottenere.Parameters.AddWithValue("@LoPossiedo", CheckBox_CeLho.Checked);
                ottenere.CommandText = "INSERT INTO ItemLoPossiedoLoVoglio VALUES (@ItemObbiettivo, @LoPossiedo, @LoVoglio)";
                ottenere.Connection = connessioneDB;

                SqlDataReader reader = ottenere.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OECE n = new OECE();
                        n.ID = Convert.ToInt32(reader["ID_ItemObbiettivo"]);
                        n.Item = reader["ItemObbiettivo"].ToString();
                        n.LoPossiedo = Convert.ToBoolean(reader["LoPossiedo"]);
                        n.LoVoglio = Convert.ToBoolean(reader["LoVoglio"]);
                        OECE.OECEList.Add(n);

                    }
                }
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                Label_ERROR.Text = ex.Message;
            }
        }

        protected void Button_DeleteVoceFromDB_Click(object sender, EventArgs e)
        {
            string ItemObbiettivo = (sender as Button).Text;

            try
            {
                SqlConnection connessioneDB = new SqlConnection();
                connessioneDB.ConnectionString = ConfigurationManager.ConnectionStrings["connessioneOECE"].ToString();
                connessioneDB.Open();

                SqlCommand delete = new SqlCommand();
                delete.CommandText = $"DELETE FROM ItemLoPossiedoLoVoglio WHERE ItemObbiettivo LIKE '{ItemObbiettivo}'";
                delete.Connection = connessioneDB;

                int row = delete.ExecuteNonQuery();

                if (row > 0)
                {
                    Label_ERROR.Text = "Delete Eseguito.";
                }
                else
                {
                    Label_ERROR.Text = "Righe interessate 0.";
                }
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                Label_ERROR.Text = ex.Message;
            }
        }
    }
}