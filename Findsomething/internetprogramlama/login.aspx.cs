using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace internetProgramlama
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    string n1 = String.Format("{0}", Request.Form["kadi"]);
                    string n2 = String.Format("{0}", Request.Form["sifre"]);

                    command.CommandType = CommandType.Text;
                    command.CommandText = "select username, password from register where username ='" + n1 + "' and password = '" + n2 + "'";
                    command.ExecuteNonQuery();

                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {
                        Session["username"] = n1;
                        Response.Redirect("homepage.aspx");
                    }
                    //middleware
                    else
                    {
                        Response.Redirect("login.aspx");
                    }
                 
                }
            }
        }
    }
}