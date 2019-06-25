using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace internetProgramlama
{
    public partial class itemupdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["username"] as string))
            {
                Response.Redirect("login.aspx");
            }

            string n = Session["username"].ToString();

            string n2 = kadiCekici();

            if (!n.Equals(n2)){
                Response.Redirect("profile.aspx");
            }
        }
        protected void btnLogin3_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            try
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Buffer = true;
                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
                Response.Expires = -1000;
                Response.CacheControl = "no-cache";
                //Response.Redirect("login.aspx", true);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            Response.Redirect("~/Login.aspx");
        }
        protected string kadiCekici()
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();


                    command.CommandType = CommandType.Text;
                    string n = Request.QueryString["id"];
                    command.CommandText = "select kadi from paylasimlar where idpaylasimlar ='" + n + "'";
                    command.ExecuteNonQuery();

                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {
                        return dtr.GetString(0);
                    }
                    return "";
                }
            }
        }

        protected void aciklamaCekici()
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();


                    command.CommandType = CommandType.Text;
                    string n = Request.QueryString["id"];
                    command.CommandText = "select urunAciklama from paylasimlar where idpaylasimlar ='" + n + "'";
                    command.ExecuteNonQuery();

                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {

                        Response.Write(dtr.GetValue(0));
                        connection.Close();
                    }
                    connection.Close();
                }
            }
                
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("images/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                    MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220");
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;

                    string n1 = String.Format("{0}", Request.Form["urunAd"]);
                    string n2 = items12.SelectedItem.ToString();
                    string n3 = Session["username"].ToString();
                    string n4 = String.Format("{0}", Request.Form["urunAciklama"]);
                    string n5 = "images/" + filename.ToString();
                    string n6 = kadiCekici();

                    //adres
                    //adres bolumu
                    string n12 = String.Format("{0}", Request.Form["mahalle"]);
                    string n7 = String.Format("{0}", Request.Form["cadde"]);
                    string n8 = String.Format("{0}", Request.Form["numara"]);
                    string n9 = String.Format("{0}", Request.Form["sehir"]);
                    string n10 = String.Format("{0}", Request.Form["ilce"]);

                    string n11 = n12 + "+" + n7 + "+" + n8 + "+" + n9 + "+" + n10;
                    command.CommandText = "UPDATE paylasimlar SET paylasimAdi = '" + n1 + "', paylasimTuru = '" + n2 + "', kadi = '" + n3 + "', urunAciklama = '" + n4 + "', begeni = '0', url = '" + n5 + "', adres='"+n11+"' where idpaylasimlar = '" + Request.QueryString["id"] + "'";
                    command.ExecuteNonQuery();
                    connection.Close();
                    Response.Redirect("profile.aspx");
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
        protected void btnDeleteItem_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command2 = connection.CreateCommand())
                {
                    connection.Open();

                    command2.CommandType = CommandType.Text;

                    command2.CommandText = "DELETE from paylasimlar where idpaylasimlar = '" + Request.QueryString["id"] + "'";
                    command2.ExecuteNonQuery();
                    Response.Redirect("profile.aspx");
                    connection.Close();
                }
            }
        }
    }
}