using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace internetProgramlama
{
    public partial class share : System.Web.UI.Page
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("images/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                    using(MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
                    {
                        using (MySqlCommand command = connection.CreateCommand())
                        {
                            connection.Open();
                            command.CommandType = CommandType.Text;

                            string n1 = String.Format("{0}", Request.Form["urunAd"]);
                            string n2 = items12.SelectedItem.ToString();
                            string n3 = Session["username"].ToString();
                            string n4 = String.Format("{0}", Request.Form["urunAciklama"]);

                            //Ürünler kısmında görünen bar 150 karakter sınırı ekleme
                            string n12 = "";
                            if (n4.Length < 100)
                            {
                                n12 = n4.ToString();
                            }
                            else
                            {
                                for (int i = 0; i < 100; i++)
                                {
                                    n12 += n4[i].ToString();
                                }
                            }

                            string n5 = "images/" + filename.ToString();


                            //adres bolumu
                            string n6 = String.Format("{0}", Request.Form["mahalle"]);
                            string n7 = String.Format("{0}", Request.Form["cadde"]);
                            string n8 = String.Format("{0}", Request.Form["numara"]);
                            string n9 = String.Format("{0}", Request.Form["sehir"]);
                            string n10 = String.Format("{0}", Request.Form["ilce"]);

                            string n11 = n6 + "+" + n7 + "+" + n8 + "+" + n9 + "+" + n10;
                            command.CommandText = "insert into paylasimlar(paylasimAdi, paylasimTuru, kadi, urunAciklama, begeni, url, adres, urunAciklamaHalf) Values('" + n1 + "','" + n2 + "','" + n3 + "','" + n4 + "','0','" + n5 + "','" + n11 + "', '" + n12 + "')";
                            command.ExecuteNonQuery();
                            connection.Close();
                            Response.Redirect("homepage.aspx");
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            
        }
    }
}