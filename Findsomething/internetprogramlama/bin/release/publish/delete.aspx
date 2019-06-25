<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delete.aspx.cs" Inherits="internetProgramlama.delete" %>

<!DOCTYPE html>
<html>
<head>
    <title>Verileri Değiştir</title>
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="css/kayit.css">
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="css/instagram-brands.svg" />
    <link rel="stylesheet" href="css/main.css" />
    <link rel="stylesheet" href="css/delete.css" />
    <link rel="stylesheet" href="css/profilguncelle.css" />
</head>
<body>
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
        <div class="dlt">
            <h1 class="dlt-baslik">SANA ELVEDA DEMEK BİZİ ÜZÜYOR. BİR DAHA DÜŞÜN HESABINI SİLMEK İSTEDİĞİNE EMİN MİSİN?</h1>
            <div class="kaydirici">
                <asp:Button ID="Button1" runat="server" Text="EVET" TabIndex="3" class="login-button" OnClick="btnDelete_Click" />
                <asp:Button ID="Button2" runat="server" Text="HAYIR" TabIndex="3" class="login-button2" OnClick="btnNotdelete_Click" />
            </div>
        </div>
        
                
    </form>
</body>
</html>

