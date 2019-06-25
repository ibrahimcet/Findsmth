<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="items.aspx.cs" Inherits="internetProgramlama.items" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>FindSomething Hoş Geldiniz :)</title>
    <link rel="stylesheet" href="css/addingPannel.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous" />
    
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="css/instagram-brands.svg" />
    <link rel="stylesheet" href="css/support2.css" />
    <link rel="stylesheet" href="css/mainkategorilink.css" />
    <link rel="stylesheet" href="css/itemsShare5.css" />
</head>
<body style="font-size:16px;">
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

        <!-- CONTENT START -->
        <div class="row main" style="height: 610px;">
            <div class="urunaciklama-div">
                <div class="urunaciklama-profil-div">
                    <div class="ua-profil">
                        <img src="<% urlCekici();%>">
                        <h2><%kadiCekici(); %></h2>

                        <asp:DropDownList ID="items12" runat="server" CssClass="kategori-list">
                            <asp:ListItem Enabled="true" Text="Puanınız" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="0" Value="1"></asp:ListItem>
                            <asp:ListItem Text="1" Value="2"></asp:ListItem>
                            <asp:ListItem Text="2" Value="3"></asp:ListItem>
                            <asp:ListItem Text="3" Value="4"></asp:ListItem>
                            <asp:ListItem Text="4" Value="5"></asp:ListItem>
                            <asp:ListItem Text="5" Value="6"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="Button1" runat="server" Text="Puan Ver" TabIndex="3" class="puan-button" OnClick="btnPuan_Click" />
                    </div>

                    <div class="urunbegenme">
                        <label><% yazdirici(); %></label>
                        <a href= "<% btnLike_Click(); %>"><i class="fa fa-heart" style="font-size:20px; color:black; margin-top:10px;"></i></a>
                    </div>

                </div>
                <div class="urunaciklama">
                    <div class="urunaciklama-paragraf-div">
                        <p><%aciklamaCekici(); %></p>
                    </div>
                </div>
                <div class="yorumyazma">
                    <textarea id="yorumBar" name="yorumBar" placeholder="Yorumunuz.."></textarea>

                </div>
                <div class="yorumyap">
                    <asp:Button ID="ButtonAdd" runat="server" Text="Yorum Yap" TabIndex="3" class="puan-button" OnClick="btnCommentAdd_Click" />
                </div>

                <div class="ua-yorumlar-div">
                    <div class="yorumlar-div">
                                <asp:DataList ID="d1" runat="server" class="yorumlar">
                                    <ItemTemplate>
                                        <div class="yorumlar">
                                            <a href="<%
                                                yonlendiriciYorum();
                                            %>
                                            <%#Eval("idyorum") %>" class="yorum-genel-bar">
                                            <div class="paylasimlar-genel-div">
                                                <div class="paylasimlar-div">
                                                    <div class="p-kadi">
                                                        <p class="p-h1"><%#Eval("yorumIcerik")%></p>
                                                    </div>
                                                    <div class="aciklama">
                                                        <div class="aciklama-div" style="float:right;">
                                                            <p class="paragraf"><bold>@<%#Eval("yorumuYapan") %></bold></p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </a>
                                        </div>
                                        
                                    </ItemTemplate>
                                </asp:DataList>
                        </div>
                </div>
                <div class="panel-icons">
                    <div class="message-icon">
                        <a href="<% yonlediriciMesaj(); %>">
                            <i class="fas fa-envelope" style="font-size:32px; color:black;"></i>
                        </a>
                    </div>
                    <div class="naviga-icon">
                        <a href="<% konumCekme(); %>">
                            <i class="fas fa-map-marker-alt" style="font-size:32px; color:black;"></i></a>
                    </div>
                </div>
                
            </div>
        </div>
        <!-- CONTENT END-->

    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>
