using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace internetProgramlama
{
    public partial class yorum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){
            if (string.IsNullOrEmpty(Session["username"] as string)){
                Response.Redirect("login.aspx");
            }
            string a = Request.QueryString["idkullanici"];
            string kullaniciAdi = kadicekici();
            if (!kullaniciAdi.Equals(Session["username"].ToString()))
            {
                Response.Redirect("items.aspx?id=" + a);
            }
        }

        protected string kadicekici(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    string n = Request.QueryString["id"];
                    command.CommandText = "select yorumuYapan from yorum where idyorum ='" + n + "'";
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
        protected void yorumIcerikGetirici(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    string n = Request.QueryString["id"];
                    command.CommandText = "select yorumIcerik from yorum where idyorum ='" + n + "'";
                    command.ExecuteNonQuery();

                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {
                        Response.Write(dtr.GetValue(0));
                    }
                }
            }           
        }
        protected void btnUpdateComment_Click(object sender, EventArgs e){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    string n = Request.QueryString["id"];
                    string n2 = String.Format("{0}", Request.Form["yorumTutucu"]);
                    command.CommandText = "UPDATE yorum SET yorumIcerik = '" + n2 + "' where idyorum = '" + n + "'";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        protected void btnDeleteComment_Click(object sender, EventArgs e){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    string n = Request.QueryString["id"];
                    command.CommandText = "Delete from yorum where idyorum = '"+n+"'";
                    command.ExecuteNonQuery();
                    connection.Close();
                    Response.Redirect("homepage.aspx");
                }
            }
        }
    }
}