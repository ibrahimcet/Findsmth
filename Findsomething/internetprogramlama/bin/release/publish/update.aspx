<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="internetProgramlama.update" %>


<!DOCTYPE html>
<html>
<head>
    <title>Verileri Deðiþtir</title>
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="css/kayit.css">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="css/instagram-brands.svg" />
    <link rel="stylesheet" href="css/main.css" />
    <link rel="stylesheet" href="css/profilguncelle.css" />
</head>
<body background="images/gokyuzu.jpg" style="width: 100%; height: 100%; background-repeat : no-repeat; background-size:cover;">
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
        <div class="kgenel-div">
            <div class="kayit-genel-div">
                <div class="kayit-div">
                  
                    <div class="txt-div">
                        <div class="txt-form-div">
                            <input id="sifre" type="password" name="sifre" placeholder=" Yeni Sifre.">
                            <input id="mail" type="text" name="mail" placeholder=" Yeni Mail.">
                            <input id="tel" type="text" name="tel" placeholder=" Yeni Telefon.">
                            <input id="sehir" type="text" name="sehir" placeholder=" Yeni Sehir.">
                            <asp:FileUpload ID="FileUploadControl" runat="server" />
                                <br />
                                <br />
                                <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
                        </div>
                        <div class="kayit-buton-div">
                            <asp:Button ID="btnLogin" runat="server" Text="Giriş" TabIndex="3" class="kayit-buton" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
