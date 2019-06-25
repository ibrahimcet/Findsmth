<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="internetProgramlama.profile" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />

    <title>FindSomething Profil Sayfası:)</title>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="Content/bootstrap.min.css" />

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="css/instagram-brands.svg" />
    <link rel="stylesheet" href="css/support2.css" />
    <link rel="stylesheet" href="css/content3.css" />
    <link rel="stylesheet" href="css/category2.css" />
    <link rel="stylesheet" href="css/mainkategorilink.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous">

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
</head>
<body>
    <!--HEADER -->
    <form runat="server" id="formcuk">
        <div class="w3-top">
            <div class="w3-bar w3-white w3-wide w3-padding w3-card">
                <a href="homepage.aspx" class="w3-bar-item w3-button"><b>Find</b> Something</a>
                <!-- Float links to the right. Hide them on small screens -->
                <div class="wrap">
                    <div class="search">
                        <input id="ara" name="ara" type="text" class="searchTerm" placeholder="Kimi arıyorsunuz?">
                        <button runat="server" id="btnRun" onserverclick="btnSearch_Click" class="searchButton" title="Search">
                            <i class="fa fa-search"></i>
                        </button>
                    </div>
                </div>
                
                <div class="w3-right w3-hide-small">
                    <a href="profile.aspx" class="w3-bar-item w3-button">Profilim</a>
                    <asp:Button ID="btnLogin3" runat="server" Text="Çıkış" TabIndex="3" class="w3-bar-item w3-button" OnClick="btnLogin3_Click" />
                </div>
            </div>
        </div>

        <!-- Header -->
        <header class="w3-display-container w3-content w3-wide" style="max-width: 1500px;" id="home">
            <img class="w3-image" src="/w3images/architect.jpg" alt="Architecture" width="1500" height="800">
            <div class="w3-display-middle w3-margin-top w3-center">
            </div>
        </header>


        <div class="profil-ana">
            <div class="card hovercard">
                <div class="card-background">
                    <img class="card-bkimg" alt="" src="images/bck.jpeg">
                </div>
                <div class="useravatar">
                    <img alt="" src="<%Response.Write(image_displayer());%>">
                </div>
                <div class="card-info">
                    <span class="card-title"><% Response.Write(Session["username"].ToString()); %></span>
                </div>
            </div>
            <div class="btn-pref btn-group btn-group-justified btn-group-lg" role="group" aria-label="...">
                <div class="btn-group" role="group">
                    <button runat="server"  onserverclick="btnUpdate_Click" type="button" id="following" class="btn btn-default" data-toggle="tab">
                        <span class="glyphicon glyphicon-cog" aria-hidden="true"></span>
                        <div class="hidden-xs">Profilimi Güncelle</div>
                    </button>
                    <button runat="server"  onserverclick="btnDelete_Click" type="button" id="following2" class="btn btn-default" data-toggle="tab">
                        <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                        <div class="hidden-xs">Profilimi sil</div>
                    </button>
                </div>
            </div>

            <div class="well">
                <div class="tab-content">
                    <div class="tab-pane fade in active" id="tab1">
                        <h3><label>
                            <%
                                getirici();
                            %></label><br>
                        <label>
                            <%
                                getirici2();
                            %></label><br></h3>
                    </div>
                    <div class="tab-pane fade in" id="tab2">
                        <h3>This is tab 2</h3>
                    </div>
                    <div class="tab-pane fade in" id="tab3">
                        <h3>This is tab 3</h3>
                    </div>
                </div>
            </div>

        </div>
        <script>
            $(document).ready(function () {
                $(".btn-pref .btn").click(function () {
                    $(".btn-pref .btn").removeClass("btn-primary").addClass("btn-default");
                    // $(".tab").addClass("active"); // instead of this do the below 
                    $(this).removeClass("btn-default").addClass("btn-primary");
                });
            });
        </script>

        <!--    -->

            <asp:DataList ID="d2" runat="server" class="pp">
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
                                                <p class="paragraf"><%#Eval("urunAciklamaHalf") %></p>
                                            </div>
                                        </div>
                                    </div>
                            </a>
                            <div class="p-puanlama">
                                <a href="<%guncellemeYonlendirici();%>
                    <%#Eval("idpaylasimlar") %>"><i class="glyphicon glyphicon-cog"></i></a>
                            </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>


        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    </form>
</body>
</html>
