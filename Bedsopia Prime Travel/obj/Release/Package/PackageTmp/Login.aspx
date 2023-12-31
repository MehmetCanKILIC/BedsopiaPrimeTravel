﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bedsopia_Prime_Travel.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <meta name="author" content="Mehmet Can KILIÇ, mehmet-ck@outlook.com" />
    <title>
        <asp:Literal ID="ltrTitle" runat="server"></asp:Literal></title>
    <!-- Favicon-->
    <link rel="icon" href="images/favicon.ico" type="image/x-icon" />

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css" />

    <!-- Bootstrap Core Css -->
    <link href="plugins/bootstrap/css/bootstrap.css" rel="stylesheet" />

    <!-- Waves Effect Css -->
    <link href="plugins/node-waves/waves.css" rel="stylesheet" />

    <!-- Animation Css -->
    <link href="plugins/animate-css/animate.css" rel="stylesheet" />

    <!-- Custom Css -->
    <link href="css/style.css" rel="stylesheet" />

    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            background-image: url('../images/petlaszemzem.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-attachment: fixed;
            background-size: cover;
        }
    </style>

    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-121418428-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-121418428-1');
    </script>

</head>
<body style="background:url(Images/img.jpeg)">
    <form id="form1" runat="server">

        <div class="girisBolumUst">
           <%--   <asp:Image ID="imgLogo" runat="server" Style="margin-right: 18px; margin-bottom: 20px;width:auto; height:50px; vertical-align: -webkit-baseline-middle;" />
                      <img src="images/logo.png"       style="margin-right: 18px; margin-bottom: 20px; vertical-align: -webkit-baseline-middle;"  />
            <img src="images/logozemzem.png" style="margin-bottom: 20px;" />
            <img src="Images/img.jpeg" style="margin-bottom: 20px;" />--%>

        </div>

        <div style="width: 90%; margin: auto; margin-bottom: 300px; padding-bottom: 50px;">
         
            <div class="girisBolumSag" style="background-color:white;">
                <div style="width: 100%; padding: 38px; background-image: url('../images/form_bg.png');">
                                <img src="Images/Prime_yeni_logo.png" style="margin-bottom: 20px;" />

                    <div class="msg" style="font-size: 24px; text-align: center; color: #777;">
                        <asp:Literal ID="ltrGiris" runat="server"></asp:Literal>
                    </div>
                    <br />
                    <asp:Label ID="lblIslemSonuc" runat="server" CssClass="mesajHata" Visible="false"></asp:Label>
        
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">person</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox ID="txtKullaniciAd" runat="server" CssClass="form-control" placeholder="Kullanıcı Adı" required></asp:TextBox>
                        </div>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">lock</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox ID="txtSifre" runat="server" TextMode="Password" CssClass="form-control" placeholder="Şifre" required></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-7">
                            <asp:CheckBox ID="cbHatirla" runat="server" Text="Beni Hatırla" />
                        </div>
                        <div class="col-xs-4" style="text-align: right; float: right;">
                            <asp:Button ID="btnGiris" runat="server" CssClass="btn btn-primary waves-effect" data-loading-text="loading..." Style="width: 100%;" OnClick="btnGiris_Click" Text="Giriş Yap" />
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>

        <div id="footer">
            <div style="width: 90%; margin: auto; line-height: 40px;">
                <ul class="altListeGiris">
                    <%--                    <li><a href="UyeYeni.aspx"><asp:Literal ID="ltrYeniKullanici" runat="server"></asp:Literal></a></li>--%>
                    <li><a href="UyeSifre.aspx">
                        <asp:Literal ID="ltrSifremiUnuttum" runat="server" Text="Şifremi Unuttum"></asp:Literal></a></li>
                </ul>

                <span style="float: right; color: #f5f5f5; text-shadow: -1px -1px 0 #777, 1px -1px 0 #777, -1px 1px 0 #777, 1px 1px 0 #777;">
                    <asp:Literal ID="ltrBosfor" runat="server"></asp:Literal></span>
                <div class="clearfix"></div>
            </div>
        </div>

        <!-- Jquery Core Js -->
        <script src="plugins/jquery/jquery.min.js"></script>

        <!-- Bootstrap Core Js -->
        <script src="plugins/bootstrap/js/bootstrap.js"></script>

        <!-- Waves Effect Plugin Js -->
        <script src="plugins/node-waves/waves.js"></script>

        <!-- Validation Plugin Js -->
        <script src="plugins/jquery-validation/jquery.validate.js"></script>

        <!-- Custom Js -->
        <script src="js/admin.js"></script>
        <script src="js/pages/examples/sign-in.js"></script>

        <script type="text/javascript">

            $("form").submit(function (e) {
                var $btn = $(this).find('.btn');
                $btn.button('loading');
            });

        </script>

    </form>
</body>
</html>