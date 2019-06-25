using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace internetProgramlama
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["username"] as string))
            {
                Response.Redirect("login.aspx");
            }
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from paylasimlar where kadi='" + Session["username"].ToString() + "'";
                    command.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter mdtd = new MySqlDataAdapter(command);

                    mdtd.Fill(dt);


                    d2.DataSource = dt;
                    d2.DataBind();

                    connection.Close();
                }
            }
               
        }

        protected void getirici()
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();


                    command.CommandType = CommandType.Text;
                    command.CommandText = "select mail from register where username ='" + Session["username"].ToString() + "'";
                    command.ExecuteNonQuery();
                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {

                        Response.Write(dtr.GetValue(0).ToString());
                        connection.Close();
                    }
                    else
                    {

                        Response.Redirect("login.aspx");
                        connection.Close();
                    }
                }
            }
        }
        protected void getirici2()
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();


                    command.CommandType = CommandType.Text;
                    command.CommandText = "select phone from register where username ='" + Session["username"].ToString() + "'";
                    command.ExecuteNonQuery();
                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {

                        Response.Write(dtr.GetValue(0).ToString());
                        connection.Close();
                    }
                    else
                    {
                        connection.Close();
                        Response.Redirect("login.aspx");
                    }
                }
            }
                
        }

        public string image_displayer()
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();


                    command.CommandType = CommandType.Text;
                    command.CommandText = "select photourl from register where username ='" + Session["username"].ToString() + "'";
                    command.ExecuteNonQuery();
                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {

                        return dtr.GetValue(0).ToString();
                    }
                    connection.Close();
                    return "";
                }
            }
                
        }

        protected void kullaniciGetirici()
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();


                    command.CommandType = CommandType.Text;
                    string n = Request.QueryString["id"];
                    command.CommandText = "select kadi from paylasimlar where kadi ='" + Session["username"].ToString() + "'";
                    command.ExecuteNonQuery();

                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {

                        Response.Write(dtr.GetValue(0));
                    }
                }
            }
                
        }
        protected void urunGetirici()
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    string n = Request.QueryString["id"];
                    command.CommandText = "select urunAciklama from paylasimlar where kadi ='" + Session["username"].ToString() + "'";
                    command.ExecuteNonQuery();

                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {

                        Response.Write(dtr.GetValue(0));
                    }
                    connection.Close();

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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string a = String.Format("{0}", Request.Form["ara"]);
            Response.Redirect("searchuser.aspx?sorgu=" + a);
        }
        public void yonlendirici()
        {
            Response.Write("items.aspx?id=");
        }
        protected void guncellemeYonlendirici()
        {
            Response.Write("itemupdate.aspx?id=");
        }

        protected void puanGetirici()
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();


                    command.CommandType = CommandType.Text;
                    string n = Request.QueryString["id"];
                    command.CommandText = "select userPoint from register where username ='" + Session["username"].ToString() + "'";
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
        protected void sayacGetirici()
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();


                    command.CommandType = CommandType.Text;
                    string n = Request.QueryString["id"];
                    command.CommandText = "select sayac from register where username ='" + Session["username"].ToString() + "'";
                    command.ExecuteNonQuery();

                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {

                        Response.Write(dtr.GetValue(0));
                        connection.Close();
                    }
                }
            }
                 
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("update.aspx");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("delete.aspx");
        }
        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile.aspx");
        }
        protected void btnMessages_Click(object sender, EventArgs e)
        {
            Response.Redirect("messages.aspx");
        }
    }
}