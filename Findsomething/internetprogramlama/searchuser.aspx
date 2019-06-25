<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchuser.aspx.cs" Inherits="internetProgramlama.searchuser" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>FindSomething Hoş Geldiniz :)</title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous
    
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="css/instagram-brands.svg" />
    <link rel="stylesheet" href="css/content3.css" />
    <link rel="stylesheet" href="css/category.css" />
    <link rel="stylesheet" href="css/mainkategorilink.css" />

</head>
<body>
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
        <div style="margin-top:100px;">
        <asp:DataList ID="d1" runat="server" class="item-list1">
            <ItemTemplate>
                <div class="paylasimlar-genel-div">

                    <a href="<%
                        yonlendirici();
                                %>
                                <%#Eval("idregister") %>">

                        <div class="paylasimlar-div">
                            <div class="p-kadi">
                                <h1 class="p-h1"><%#Eval("username")%></h1>
                            </div>
                            <div class="p-foto">
                                <div class="foto">
                                    <img src="<%#Eval("photourl")%>">
                                </div>
                                <div class="aciklama">
                                    <div class="aciklama-div">
                                        <p class="paragraf"><%#Eval("name") %></p>
                                    </div>
                                </div>
                            </div>
                            <div class="p-puanlama"></div>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:DataList>
            </div>
    </form>


    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>


