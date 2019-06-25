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
    public partial class homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e ) {
            if (string.IsNullOrEmpty(Session["username"] as string)) {
                Response.Redirect("login.aspx");
            }
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from register rg, paylasimlar py where rg.username = py.kadi order by rg.userPoint desc";
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

        protected void btnLogin3_Click(object sender, EventArgs e) {
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
        protected void btn_addClick(object sender, EventArgs e) {
            Response.Redirect("share.aspx");
        }

        public void yonlendirici() {
            Response.Write("items.aspx?id=");
        }


        protected void btnQuery1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from paylasimlar py, register rg where py.paylasimTuru='fikirler' and rg.username = py.kadi order by rg.userPoint desc";
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
        protected void btnQuery2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from paylasimlar py, register rg where py.paylasimTuru='cocuklar icin' and rg.username = py.kadi order by rg.userPoint desc";
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
        protected void btnQuery3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from paylasimlar py, register rg where py.paylasimTuru='egitimler' AND rg.username = py.kadi order by rg.userPoint desc";
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
        protected void btnQuery4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from paylasimlar py, register rg where py.paylasimTuru='ev ilanlari' AND rg.username = py.kadi order by rg.userPoint desc";
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
        protected void btnQuery5_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from paylasimlar py, register rg where py.paylasimTuru='arabalar' AND rg.username = py.kadi order by rg.userPoint desc";
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
        protected void btnQuery6_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from paylasimlar py, register rg where py.paylasimTuru='diger' AND rg.username = py.kadi order by rg.userPoint desc";
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string a = String.Format("{0}", Request.Form["ara"]);
            Response.Redirect("search.aspx?sorgu="+ a);
        }
    }

}