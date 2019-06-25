<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="share.aspx.cs" Inherits="internetProgramlama.share" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>FindSomething Hoþ Geldiniz :)</title>
    <link rel="stylesheet" href="css/content.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous" />
    
    <link rel="stylesheet" href="css/addingPannel.css" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="css/instagram-brands.svg" />
    <link rel="stylesheet" href="css/support2.css" />
    <link rel="stylesheet" href="css/category2.css" />
    <link rel="stylesheet" href="css/mainkategorilink.css" />
    <link rel="stylesheet" href="css/sharenew.css" />

</head>
<body background="images/orman.jpg" style="width: 100%; height: 100%; background-repeat : no-repeat; background-size:cover;">
    <form id="form1" runat="server" method="post">
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
        <div class="row main" style="height: 610px;">


            <div class="share-genel-div">
                <div class="share-txt-div">
                    <div class="eklemeler">
                        <div class="ekl">
                            <div class="urunadi">
                                <input type="text" id="urunAd" name="urunAd" placeholder="Paylaşım ismi" />
                            </div>
                        </div>
                        <div class="dropdown">
                            <asp:DropDownList ID="items12" runat="server">
                                <asp:ListItem Enabled="true" Text="Kategori Türü" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Fikirler" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Çocuklar İçin" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Egitim" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Ev ilanları" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Arabalar" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Diger" Value="6"></asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <asp:FileUpload ID="FileUploadControl" runat="server" />
                        <br />
                        <br />
                        <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
                        <div class="urunaciklama">
                            <textarea id="urunAciklama" name="urunAciklama" placeholder="Lütfen ürünün özelliklerini giriniz."></textarea></div>
                            <input type = "text" id = "mahalle" name = "mahalle" placeholder="Mahalleniz" />
                            <input type = "text" id = "cadde" name = "cadde" placeholder="sokak ya da caddeniz" />
                            <input type = "text" id = "numara" name = "numara" placeholder ="Bina numaraniz" />
                            <input type = "text" id = "sehir" name = "sehir" placeholder = "Şehir" />
                            <input type = "text" id = "ilce" name = "ilce" placeholder = "ilçe" />
                        <div class="buton">
                            <asp:Button ID="btnAdd" runat="server" Text="Ekle" TabIndex="3" class="login-button" OnClick="btnAdd_Click" />
                        </div>
                            
                    </div>
                </div>
            </div>
        </div>
        <!-- CATEGORÝES END -->
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>
