<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yorum.aspx.cs" Inherits="internetProgramlama.yorum" %>

<!DOCTYPE html>
<html>
<head>
    <title>Verileri Deðiþtir</title>
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="css/kayit.css">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous" />
    
    
    <link rel="stylesheet" href="css/instagram-brands.svg" />
    <link rel="stylesheet" href="css/main.css" />
    <link rel="stylesheet" href="css/profilguncelle.css" />
    <link rel="stylesheet" href="css/yorumlar.css" />
</head>
<body background="images/sunrise.jpg" style="width: 100%; height: 100%; background-repeat : no-repeat; background-size:cover;">
    <form id="form1" method="POST" runat="server">
        <!--HEADER -->
        <div class="w3-top">
            <div class="w3-bar w3-white w3-wide w3-padding w3-card">
                <a href="homepage.aspx" class="w3-bar-item w3-button"><b>Find</b> Something</a>
                <!-- Float links to the right. Hide them on small screens -->
                <div class="w3-right w3-hide-small">
                    <a href="profile.aspx" class="w3-bar-item w3-button">Profilim</a>
                    <asp:Button ID="btnLogin3" runat="server" Text="Çıkış" TabIndex="3" class="w3-bar-item w3-button" OnClick="btnLogin3_Click" />
                </div>
            </div>
        </div>
        <!--HEADER END -->


        



            <div class="yorumlar">
                <div class="yorumlaritut">

                    <textarea id="yorumTutucu" class="txtyorum" name="yorumTutucu"><% yorumIcerikGetirici(); %></textarea>

                </div>

                <div class="btntut1">
                    <asp:Button ID="Button1" runat="server" Text="Güncelle" TabIndex="3" class="login-button" OnClick="btnUpdateComment_Click" />
                </div>

                <div class="btntut2">
                    <asp:Button ID="Button2" runat="server" Text="Sil" TabIndex="3" class="login-button2" OnClick="btnDeleteComment_Click" />

                </div>


            </div>




        
      
    </form>
</body>
</html>

