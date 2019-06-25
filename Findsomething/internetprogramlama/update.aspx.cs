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
    public partial class update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["username"] as string))
            {
                Response.Redirect("login.aspx");
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

        protected void btnUpdate_Click(object sender, EventArgs e){
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("profileImages/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                    using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
                    {
                        using (MySqlCommand command = connection.CreateCommand()) {
                            connection.Open();
                            command.CommandType = CommandType.Text;
                            string n1 = String.Format("{0}", Request.Form["sifre"]);
                            string n2 = String.Format("{0}", Request.Form["mail"]);
                            string n3 = String.Format("{0}", Request.Form["tel"]);
                            string n4 = String.Format("{0}", Request.Form["sehir"]);
                            string n5 = "profileImages/" + filename.ToString();

                            if (n1.Equals("") || n2.Equals("") || n3.Equals("") || n4.Equals(""))
                            {
                                Response.Write("veriler boş bırakılamaz");
                                
                            }
                            else
                            {
                                string cekici = urlCekici();
                                System.IO.File.Delete(Server.MapPath(cekici));
                                command.CommandText = "UPDATE register SET password='" + n1 + "', mail='" + n2 + "', phone = '" + n3 + "', city ='" + n4 + "', photourl = '" + n5 + "' where username = '" + Session["username"].ToString() + "'";
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    
                    
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }

        protected string urlCekici(){
            string a = "";
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select photourl from register where username = '" + Session["username"].ToString() + "'";
                    command.ExecuteNonQuery();
                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {
                        a = dtr.GetString(0);
                    }
                    return a;
                }
            }
        }
    }
}