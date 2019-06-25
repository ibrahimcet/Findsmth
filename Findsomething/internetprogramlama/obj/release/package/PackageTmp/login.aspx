<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="internetProgramlama.login" %>




<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="css/giris.css">

    <style>
        .header {
            background-color: red;
            height: 80px;
        }
    </style>


</head>
<body background="background.jpeg" style="width: 100%; height: 100%;">
    <form id="deneme12" runat="server">
        <div class="genel-div">
            <div class="giris-genel-div">
                <div class="giris-div">
                    <div class="img-logo-div">
                        <div class="img-logo">
                            <img src="images/logo4.png">
                        </div>
                    </div>
                    <div class="txt-img-div">
                        <div class="txt-div">

                            <input id="kadi" type="text" name="kadi" placeholder=" Kullanıcı adınızı giriniz.">
                            <input id="sifre" type="password" name="sifre" placeholder=" Şifrenizi giriniz.">
                        </div>
                        <div class="giris-buton-div">

                            <asp:Button ID="btnLogin2" runat="server" Text="GİRİŞ" TabIndex="3" class="giris-buton" OnClick="btnLogin2_Click" />

                        </div>
                        <div class="kayit-div">
                            <a href="register.aspx">
                                <p>Hesabın yok mu kaydol ?</p>
                            </a>
                        </div>
                        <div class="hesaplar-div">
                            <div class="hesaplar">
                                <a href="FacebookLogin.html">
                                    <img src="images/facebook.png"></a>
                                <a href="GoogleLogin.html">
                                    <img src="images/google.png"></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
