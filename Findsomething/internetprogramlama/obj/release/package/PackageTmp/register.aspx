<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="internetProgramlama.register" %>


<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<link rel="stylesheet" type="text/css" href="css/kayit.css">

	
</head>
<body background="background.jpeg" style="width: 100%; height: 100%;">
    <form id="deneme12" runat="server">
        <div class="kgenel-div">
		<div class="kayit-genel-div">
			<div class="kayit-div">
				<div class="img-logo-div">
					<div class="img-logo">
						<img src="images/logo4.png">
					</div>
				</div>
				<div class="txt-div">
					<div class="txt-form-div">

                            <input id="ad" type="text" name="ad" placeholder=" Adınızı giriniz.">
                        	<input id="soyad" type="text" name="soyad" placeholder=" Soyadınızı giriniz.">
                        	<input id="kadi" type="text" name="kadi" placeholder=" Kullanıcı adınızı giriniz.">
                        	<input id="sifre" type="password" name="sifre" placeholder=" Şifrenizi giriniz.">
                        	<input id="mail" type="text" name="mail" placeholder=" Mailinizi giriniz.">
                        	<input id="tel" type="text" name="tel" placeholder=" Telefonu giriniz.">
                        	<input id="sehir" type="text" name="sehir" placeholder=" Şehir giriniz.">
                            
                            
					</div>
                    <asp:FileUpload ID="FileUploadControl" runat="server" CssClass="upload" />
                                <br />
                                <br />
                                <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
					<div class="kayit-buton-div">
                        <asp:Button ID="btnLogin" runat="server" Text="Kayıt Ol" TabIndex="3" class="kayit-buton" onclick="btnLogin_Click" />
					</div>
				</div>
			</div>
		</div>
	</div>


    </form>
</body>
</html>
