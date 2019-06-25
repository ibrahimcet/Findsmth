<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="messages.aspx.cs" Inherits="internetProgramlama.messages" %>

<!DOCTYPE html>
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

<html>
<head>
    <meta charset="utf-8" />
    <link rel="stylesheet" href="css/mesajPanel.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous" />
    <link rel="stylesheet" href="css/instagram-brands.svg" />
    <link rel="stylesheet" href="css/support.css" />
    <link rel="stylesheet" href="css/mainkategorilink.css" />

    <title></title>
</head>
<body>
    <form runat="server" id="formTutucu">
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

        <div class="container">
            <h3 class=" text-center">Mesajlar</h3>
            <div class="messaging">
                <div class="inbox_msg">
                    <div class="mesgs">
                        <div class="msg_history">
                                <% yazdirmaci(); %>
                        </div>
                        <div class="type_msg">
                            <div class="input_msg_write">
                                <input id="messages" name="messages" type="text" class="write_msg" placeholder="Merhaba demek ister misin?" />
                                <asp:Button ID="Button1" runat="server" Text="Gonder" TabIndex="3" class="login-button" OnClick="btnMessageSend_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
