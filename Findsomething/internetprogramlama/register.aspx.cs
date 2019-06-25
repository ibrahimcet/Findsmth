using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace internetProgramlama
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string kontrol = kontrolEdici();
            if (kontrol.Equals("yok"))
            {
                if (FileUploadControl.HasFile)
                {
                    try
                    {
                        string filename = Path.GetFileName(FileUploadControl.FileName);
                        FileUploadControl.SaveAs(Server.MapPath("/images/") + filename);
                        StatusLabel.Text = "Upload status: File uploaded!";
                        using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
                        {
                            using (MySqlCommand command = connection.CreateCommand())
                            {
                                connection.Open();

                                command.CommandType = CommandType.Text;

                                string n1 = String.Format("{0}", Request.Form["ad"]);
                                string n2 = String.Format("{0}", Request.Form["soyad"]);
                                string n3 = String.Format("{0}", Request.Form["kadi"]);
                                string n4 = String.Format("{0}", Request.Form["mail"]);
                                string n5 = String.Format("{0}", Request.Form["tel"]);
                                string n6 = String.Format("{0}", Request.Form["sehir"]);
                                string n7 = String.Format("{0}", Request.Form["sifre"]);
                                string n8 = "/images/" + filename.ToString();
                                Response.Write("<script>alert('" + "Kullanıcı yukledın lan." + "')</script>");

                                command.CommandText = "insert into register(name, surname, username, mail, phone, city, password, userPhoto, userPoint, sayac, toplam, photourl) Values('" + n1 + "', '" + n2 + "','" + n3 + "', '" + n4 + "', '" + n5 + "', '" + n6 + "', '" + n7 + "','images/classicUser.png', '0', '1', '0', '" + n8 + "')";
                                command.ExecuteNonQuery();
                                connection.Close();
                                Response.Redirect("login.aspx");
                            }
                        }   
                    }
                    catch (Exception ex)
                    {
                        StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    }
                }
            }
            else{
                Response.Write("<script>alert('" + "Kullanıcı adı mevcut." + "')</script>");
            }
        }
        protected string kontrolEdici(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;
                    string n3 = String.Format("{0}", Request.Form["kadi"]);
                    command.CommandText = "select username from register where username = '" + n3 + "'";
                    command.ExecuteNonQuery();
                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {
                        return "var";
                    }
                    else
                    {
                        return "yok";
                    }
                }
            }
        }
    }
}