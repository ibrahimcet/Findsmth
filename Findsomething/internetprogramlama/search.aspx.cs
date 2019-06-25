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
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["username"] as string))
            {
                Response.Redirect("login.aspx");
            }
            string n = Request.QueryString["sorgu"];
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from paylasimlar where paylasimAdi='" + n + "'";
                    command.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter mdtd = new MySqlDataAdapter(command);

                    mdtd.Fill(dt);


                    d1.DataSource = dt;
                    d1.DataBind();

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
        public void yonlendirici()
        {
            Response.Write("items.aspx?id=");
        }
        public string image_displayer()
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();


                    command.CommandType = CommandType.Text;
                    command.CommandText = "select url from paylasimlar where paylasimAdi ='" + Request.QueryString["sorgu"].ToString() + "'";
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
    }
}