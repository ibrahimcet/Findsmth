<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="internetProgramlama.homepage" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>FindSomething Hoş Geldiniz :)</title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="css/instagram-brands.svg" />
    <link rel="stylesheet" href="css/content3.css" />
    <link rel="stylesheet" href="css/category2.css" />
    <link rel="stylesheet" href="css/mainkategorilink.css" />
    </head>
<body>
    <form id="form1" runat="server" method="post">
        <div class="w3-top">
            <div class="w3-bar w3-white w3-wide w3-padding w3-card">
                <a href="homepage.aspx" class="w3-bar-item w3-button"><b>Find</b> Something</a>
                <!-- Float links to the right. Hide them on small screens -->
                <div class="wrap">
                    <div class="search">
                        <input id="ara" name="ara" type="text" class="searchTerm" placeholder="Ne arıyorsunuz?">
                        <button runat="server" id="btnRun" onserverclick="btnSearch_Click" class="searchButton" title="Search">
                            <i class="fa fa-search"></i>
                        </button>
                    </div>
                </div>

                <div class="w3-right w3-hide-small">
                    <a href="profile.aspx" class="w3-bar-item w3-button">Profilim </a>
                    <asp:Button ID="btnLogin3" runat="server" Text="Çıkış" TabIndex="3" class="w3-bar-item w3-button" OnClick="btnLogin3_Click" />
                </div>
            </div>
        </div>
        <!-- CATEGORİES START -->
        <div class="row main" style="height: 580px;">
            <div class="col-lg-2 kategorisabitleme">
                <div class="text-center kategoribaslik">
                    <h2>Kategoriler</h2>
                </div>

                <div class="kategori-link-div">
                    <div class="kategoriler-item-1 kategorilink">
                        <asp:Button ID="btnQuery1" runat="server" Text="Fikirler" TabIndex="3" class="nav-link" OnClick="btnQuery1_Click" />
                    </div>
                    <div class="kategoriler-item-2 kategorilink">
                        <asp:Button ID="btnQuery2" runat="server" Text="Çocuklar İçin" TabIndex="3" class="nav-link" OnClick="btnQuery2_Click" />
                    </div>
                    <div class="kategoriler-item-3 kategorilink">
                        <asp:Button ID="btnQuery3" runat="server" Text="Eğitim" TabIndex="3" class="nav-link" OnClick="btnQuery3_Click" />
                    </div>
                    <div class="kategoriler-item-4 kategorilink">
                        <asp:Button ID="btnQuery4" runat="server" Text="Ev ilanları" TabIndex="3" class="nav-link" OnClick="btnQuery4_Click" />
                    </div>
                    <div class="kategoriler-item-5 kategorilink">
                        <asp:Button ID="btnQuery5" runat="server" Text="Arabalar" TabIndex="3" class="nav-link" OnClick="btnQuery5_Click" />
                    </div>
                    <div class="kategoriler-item-6 kategorilink">
                        <asp:Button ID="btnQuery6" runat="server" Text="Diğer.." TabIndex="3" class="nav-link" OnClick="btnQuery6_Click" />
                    </div>
                </div>
            </div>

            <div class="col-10 p-genel-div">
                <asp:Button ID="btn_add" runat="server" Text="Ekle" TabIndex="3" class="buton123" OnClick="btn_addClick" />

                <asp:DataList ID="d1" runat="server" class="pp">
                    <ItemTemplate>
                        <div class="paylasimlar-genel-div">
                            <a href="<%
                                yonlendirici();
                                %>
                                <%#Eval("idpaylasimlar") %>">

                                <div class="paylasimlar-div">
                                    <div class="p-kadi">
                                        <h1 class="p-h1"><%#Eval("kadi")%></h1>
                                    </div>
                                    <div class="p-foto">
                                        <div class="foto">
                                            <img src="<%#Eval("url")%>">
                                        </div>
                                        <div class="aciklama">
                                            <div class="aciklama-div">
                                                <p class="paragraf" id ="total-sayi"> <%#Eval("urunAciklamaHalf")%>
                                            </div>
                                        </div>
                                    </div>
                                
                            </a>
                            <div class="p-puanlama">
                                <p><%#Eval("userPoint") %> puana sahip kullanıcı.</p>
                            </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <!-- CATEGORİES END -->
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>
