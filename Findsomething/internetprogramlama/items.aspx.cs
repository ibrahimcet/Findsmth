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
    public partial class items : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["username"] as string)){
                Response.Redirect("login.aspx");
            }
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    string n = Request.QueryString["id"];
                    command.CommandText = "select * from yorum where yapilanId='" + n + "'";
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

        protected string kadiCekici(){
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

        protected void aciklamaCekici(){
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
                    }
                }
            }
        }
        protected void btnCommentAdd_Click(object sender, EventArgs e){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    string n1 = String.Format("{0}", Request.Form["yorumBar"]);
                    string n2 = "";
                    for (int i = 0; i < n1.Length; i++)
                    {
                        if (i % 20 == 0)
                        {
                            n2 += " &nbsp ";
                        }
                        n2 += n1[i].ToString();
                    }
                    command.CommandText = "insert into yorum(yorumIcerik, yorumuYapan, yapilanId) Values('" + n2 + "','" + Session["username"].ToString() + "','" + Request.QueryString["id"] + "')";
                    command.ExecuteNonQuery();

                }
            }
        }
        protected void btnPuan_Click(object sender, EventArgs e){

            string kadiNedir = kadiCekici();
            string kadiBizim = Session["username"].ToString();
            string idCekici = Request.QueryString["id"];
            if (!kadiNedir.Equals(kadiBizim)) {
               

                string a = kontrolDeneme();

                if (a.Equals(""))
                {
                    using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
                    {
                        using (MySqlCommand cmd = connection.CreateCommand())
                        {
                            connection.Open();

                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "insert into puanguncel (puaniYapan, puanYapilan, idyapilan) values ( '" + kadiBizim + "', '" + kadiNedir + "', '" + idCekici + "')";
                            cmd.ExecuteNonQuery();
                        }
                    }
                        

                    string b = items12.SelectedItem.ToString();
                    if (b.Equals(""))
                    {
                        b = "0";
                    }
                    double a1 = toplamgetirici();
                    double b1 = Convert.ToDouble(b);
                    double c1 = a1 + b1;
                    int bolucu = sayacgetirici();
                    if (a1 == 0)
                    {
                        bolucu++;
                        using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
                        {
                            using (MySqlCommand command2 = connection.CreateCommand())
                            {
                                connection.Open();
                                command2.CommandType = CommandType.Text;
                                command2.CommandText = "Update register set userPoint = '" + c1.ToString() + "', sayac = '" + bolucu.ToString() + "', toplam = '" + c1.ToString() + "' where username = '" + kadiCekici() + "'";
                                command2.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        double c2 = c1 / bolucu;
                        bolucu++;
                        using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
                        {
                            using (MySqlCommand command2 = connection.CreateCommand())
                            {
                                command2.CommandType = CommandType.Text;
                                command2.CommandText = "Update register set userPoint = '" + c2.ToString() + "', sayac = '" + bolucu.ToString() + "', toplam ='" + c1.ToString() + "'  where username = '" + kadiCekici() + "'";
                                command2.ExecuteNonQuery();
                            }
                        }
                    }
                    Response.Write("<script>alert('" + "Oyunuz kullanıldı" + "')</script>");
                }
                else{
                    Response.Write("<script>alert('" + "Zaten oy verdiniz." + "')</script>");
                }
            }
            else{
                Response.Redirect("homepage.aspx");
            }
            
        }

        protected string kontrolDeneme(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select puaniYapan from puanguncel where idyapilan ='" + Request.QueryString["id"] + "' and puanYapilan = '" + kadiCekici() + "' and puaniYapan = '" + Session["username"].ToString() + "'";
                    command.ExecuteNonQuery();
                    string a = "";
                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {
                        a = dtr.GetString(0);
                    }
                    connection.Close();
                    return a;
                }
            }
                
        }

        protected int sayacgetirici(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();


                    command.CommandType = CommandType.Text;
                    command.CommandText = "select sayac from register where username ='" + kadiCekici() + "'";
                    command.ExecuteNonQuery();
                    string a = "";
                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {
                        a = dtr.GetString(0);
                    }
                    connection.Close();
                    return Convert.ToInt32(a);
                }
            }
        }


        protected int toplamgetirici(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();


                    command.CommandType = CommandType.Text;
                    command.CommandText = "select toplam from register where username ='" + kadiCekici() + "'";
                    command.ExecuteNonQuery();
                    string a = "";
                    MySqlDataReader dtr = command.ExecuteReader();
                    if (dtr.Read())
                    {
                        a = dtr.GetString(0);
                    }
                    connection.Close();
                    return Convert.ToInt32(a);
                }
            }
        }


        protected void btnLike_Click()
        {
            MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220");
            connection.Open();

            string ekranaGetirici = "";

            MySqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;

            string n = Request.QueryString["id"];
            command.CommandText = "select begeni from paylasimlar where idpaylasimlar = '" + n + "'";
            command.ExecuteNonQuery();
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                ekranaGetirici = dr.GetString(0);
            }
            int likeTutucu = Convert.ToInt32(ekranaGetirici);
            likeTutucu++;

            string a = begeniKadiCekici();
            connection.Close();

            string yapilanKontrol = kontrol();
            if (yapilanKontrol.Equals(""))
            {
                MySqlConnection connection2 = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220");
                connection2.Open();
                MySqlCommand command2 = connection2.CreateCommand();
                command2.CommandType = CommandType.Text;
                command2.CommandText = "insert into begeni (begeniYapan, begeniYapilan, yapilanId) VALUES( '" + Session["username"].ToString() + "', '" + a + "', '" + n + "')";
                command2.ExecuteNonQuery();
                connection.Close();
                yazici(likeTutucu);
            }
            else
            {
                connection.Close();
                Response.Write("items.aspx?id=" + n);
            }
        }
        protected string kontrol(){

            using (MySqlConnection connection3 = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command3 = connection3.CreateCommand())
                {
                    connection3.Open();
                    
                    command3.CommandType = CommandType.Text;
                    string a = begeniKadiCekici();
                    string n = Request.QueryString["id"];
                    command3.CommandText = "select idbegeni from begeni where begeniYapan = '" + Session["username"].ToString() + "' and begeniYapilan = '" + a + "' and  yapilanId = '" + n + "'";
                    command3.ExecuteNonQuery();
                    MySqlDataReader dr = command3.ExecuteReader();
                    string kadiTutucu = "";
                    if (dr.Read())
                    {
                        kadiTutucu = dr.GetString(0);
                    }
                    connection3.Close();
                    return kadiTutucu;
                }
            }


               
        }

        protected string begeniKadiCekici(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command3 = connection.CreateCommand())
                {
                    connection.Open();

                    command3.CommandType = CommandType.Text;
                    string n = Request.QueryString["id"];
                    command3.CommandText = "select kadi from paylasimlar where idpaylasimlar = '" + n + "'";
                    command3.ExecuteNonQuery();

                    MySqlDataReader dr = command3.ExecuteReader();
                    string kadiTutucu = "";
                    if (dr.Read())
                    {
                        kadiTutucu = dr.GetString(0);
                    }
                    connection.Close();
                    return kadiTutucu;
                }
            }
             
        }

        protected void yazici(int a){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    string n = Request.QueryString["id"];


                    command.CommandType = CommandType.Text;
                    command.CommandText = "Update paylasimlar set begeni = '" + a + "' where idpaylasimlar = '" + n + "'";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        protected void yazdirici(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    string n = Request.QueryString["id"];

                    
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select begeni from paylasimlar where idpaylasimlar = '" + n + "'";
                    command.ExecuteNonQuery();
                    MySqlDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        Response.Write(dr.GetValue(0));
                    }
                    connection.Close();
                }
            }
        }
      
        protected void yonlendiriciYorum(){
            Response.Write("yorum.aspx?idkullanici=" + Request.QueryString["id"] + "&id=");
        }
        protected void urlCekici(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;

                    string n = Request.QueryString["id"];
                    command.CommandText = "select url from paylasimlar where idpaylasimlar = '" + n + "'";
                    command.ExecuteNonQuery();
                    MySqlDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        Response.Write(dr.GetValue(0));
                    }
                    connection.Close();
                }
            }
                 
        }
        protected void yonlediriciMesaj(){
            Response.Write("messages.aspx?gonderilen=" + kadiCekici());
        }
        protected void konumCekme(){
            using (MySqlConnection connection = new MySqlConnection("Database=findsmth_;Data Source=localhost;User Id=root;Password=ibrahim220"))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();


                    command.CommandType = CommandType.Text;

                    string n = Request.QueryString["id"];
                    command.CommandText = "select adres from paylasimlar where idpaylasimlar = '" + n + "'";
                    command.ExecuteNonQuery();
                    MySqlDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        Response.Write("https://www.google.com/maps/place/" + dr.GetValue(0));
                    }
                    connection.Close();
                }
            }
        }
    }
}