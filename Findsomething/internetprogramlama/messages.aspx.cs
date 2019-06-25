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
    public partial class messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["username"] as string))
            {
                Response.Redirect("login.aspx");
            }
            string n = Request.QueryString["gonderilen"];
            if (n.Equals(Session["username"].ToString()))
            {
                Response.Redirect("homepage.aspx");
            }
        }
        protected void yazdirmaci(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;
                    string gonderilen = Request.QueryString["gonderilen"];
                    string holderUname = Session["username"].ToString();
                    string a = "";
                    command.CommandText = "select mesajdurum, mesajicerik from messages where (mesajAlan = '" + gonderilen + "' and mesajGonderen = '" + holderUname + "') or (mesajGonderen = '" + gonderilen + "'and mesajAlan = '" + holderUname + "')";
                    command.ExecuteNonQuery();
                    MySqlDataReader dtr = command.ExecuteReader();
                    int count = dtr.FieldCount;
                    string total1 = Session["username"].ToString() + Request.QueryString["gonderilen"];
                    string total2 = Request.QueryString["gonderilen"] + Session["username"].ToString();
                    while (dtr.Read())
                    {
                        for (int i = 0; i < count; i++)
                        {
                            a = dtr.GetString(i);
                            if (a.Equals(""))
                            {
                                Response.Write("lütfen mesajlaşmaya başlayınız.");
                            }
                            else if (a.Equals(total1))
                            {
                                Response.Write("<div class=\"sent_msg\" style=\"float:right;\"><p>" + dtr.GetString(i + 1) + "</p></div>");
                            }
                            else if (a.Equals(total2))
                            {
                                Response.Write("<div class=\"received_withd_msg\" style=\"float:left;\"><p>" + dtr.GetString(i + 1) + "</p></div>");
                            }
                        }
                    }
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
        protected void btnMessageSend_Click(object sender, EventArgs e){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;
                    string gonderilen = Request.QueryString["gonderilen"];
                    string sira = siraGetirme();
                    int a = Convert.ToInt32(sira);
                    a += 1;
                    string siraSon = a.ToString();
                    string messageIcerik = String.Format("{0}", Request.Form["messages"]);
                    command.CommandText = "insert into messages(mesajGonderen, mesajAlan, mesajIcerik, mesajDurum, mesajSira) Values('" + Session["username"].ToString() + "', '" + Request.QueryString["gonderilen"] + "', '" + messageIcerik + "', '" + Session["username"].ToString() + Request.QueryString["gonderilen"] + "', '" + siraSon + "')";
                    command.ExecuteNonQuery();
                }
            }
        }

        protected string siraGetirme(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT mesajSira FROM `messages` where mesajAlan = '" + Session["username"].ToString() + "' or mesajAlan = '" + Request.QueryString["gonderilen"] + "' and mesajGonderen = '" + Request.QueryString["gonderilen"] + "' or mesajGonderen = '" + Session["username"].ToString() + "'";
                    command.ExecuteNonQuery();
                    MySqlDataReader dtr = command.ExecuteReader();
                    int count = dtr.FieldCount;
                    string tutucu = "";
                    if (dtr.Read())
                        tutucu = dtr.GetString(count - 1);

                    if (tutucu.Equals(""))
                    {
                        return "0";
                    }
                    else
                    {
                        return tutucu;
                    }
                }
            }            
        }
        protected void alinan(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select mesajIcerik from messages where mesajAlan = '" + Session["username"].ToString() + "' and mesajGonderen = '" + Request.QueryString["gonderilen"] + "'";
                    command.ExecuteNonQuery();
                    MySqlDataReader dtr = command.ExecuteReader();
                    int count = dtr.FieldCount;
                    while (dtr.Read())
                    {
                        for (int i = 0; i < count; i++)
                        {
                            Response.Write(dtr.GetValue(i) + "<br>");
                        }
                    }
                }
            }
                
        }
        protected void gonderilen(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select mesajIcerik from messages where mesajGonderen = '" + Session["username"].ToString() + "' and mesajAlan = '" + Request.QueryString["gonderilen"] + "'";
                    command.ExecuteNonQuery();
                    MySqlDataReader dtr = command.ExecuteReader();
                    int count = dtr.FieldCount;
                    while (dtr.Read())
                    {
                        for (int i = 0; i < count; i++)
                        {
                            Response.Write(dtr.GetValue(i) + "<br>");
                        }
                    }
                }
            }
        }
    }
}