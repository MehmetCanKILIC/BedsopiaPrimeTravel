<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="Bedsopia_Prime_Travel.UserAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Jquery Core Js -->
    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900" rel="stylesheet">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="TEST/css/style.css">
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&amp;subset=latin,cyrillic-ext" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css" />
    <script src="plugins/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core Css -->
    <link href="plugins/bootstrap/css/bootstrap.css" rel="stylesheet" />

    <!-- Bootstrap Material Datetime Picker Css -->
    <link href="plugins/bootstrap-material-datetimepicker/css/bootstrap-material-datetimepicker.css" rel="stylesheet" />

    <!-- Waves Effect Css -->
    <link href="plugins/node-waves/waves.css" rel="stylesheet" />

    <!-- Bootstrap Select Css -->
    <link href="plugins/bootstrap-select/css/bootstrap-select.css" rel="stylesheet" />

    <!-- Animation Css -->
    <link href="plugins/animate-css/animate.css" rel="stylesheet" />

    <!-- Sweetalert Css -->
    <link href="plugins/sweetalert/sweetalert.css" rel="stylesheet" />

    <!-- Custom Css -->
    <link href="css/style.css" rel="stylesheet" />
    <%--    <link href="css/all-themes.css" rel="stylesheet" />--%>

    <link href="css/style_b2b.css" rel="stylesheet" />
    <link href="css/menu/styles.css" rel="stylesheet" />

    <!-- Material Extra Icon Css -->
    <link rel="stylesheet" href="../css/material-design-iconic-font.min.css" />
    <script type="text/javascript" language="javascript">
        function Func() {
            parent.jQuery.fancybox.close()
        }
    </script>


</head>
<body style="background-color: #f5f5f5;">
    <form id="form1" runat="server">
        <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <h2>NEW USER</h2>
                    </div>
                    <div class="body">
                        <%if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "1")
                            {%>
                        <div class="col-sm-4">
                            <span class="input-group-addon bilgiBaslik" style="border: none; text-align: left; background-color: transparent; padding-left: 0; font-weight: bold;">User Type</span>
                        </div>

                        <div class="col-sm-4" style="float: left;">
                            <asp:DropDownList ID="dropUserType" Style="text-align: center;" CssClass="form-control show-tick" runat="server"></asp:DropDownList>


                        </div>
                        <% } %>
                        <table class="table table-striped">
                            <tbody>


                                <tr>
                                    <td>
                                        <div class="col-sm-6" style="margin-bottom: 0;">

                                            <span class="input-group-addon bilgiBaslik" style="border: none; text-align: left; background-color: transparent; padding-left: 0; font-weight: bold;">UserName</span>
                                        </div>
                                    </td>
                                    <td>

                                        <div class="col-sm-6" style="margin-bottom: 0;">
                                            <div class="form-group">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Font-Size="Medium" placeholder="UserName"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="col-sm-6" style="margin-bottom: 0;">

                                            <span class="input-group-addon bilgiBaslik" style="border: none; text-align: left; background-color: transparent; padding-left: 0; font-weight: bold;">Hotel Name</span>
                                        </div>
                                    </td>
                                    <td>

                                        <div class="col-sm-6" style="margin-bottom: 0;">
                                            <div class="form-group">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtHotelName" runat="server" CssClass="form-control" Font-Size="Medium" placeholder="Hotel Name"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="col-sm-6" style="margin-bottom: 0;">

                                            <span class="input-group-addon bilgiBaslik" style="border: none; text-align: left; background-color: transparent; padding-left: 0; font-weight: bold;">Password</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-sm-6" style="margin-bottom: 0;">
                                            <div class="form-group">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Font-Size="Medium" placeholder="Password"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="col-sm-6" style="margin-bottom: 0;">

                                            <span class="input-group-addon bilgiBaslik" style="border: none; text-align: left; background-color: transparent; padding-left: 0; font-weight: bold;">E-Mail</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-sm-6" style="margin-bottom: 0;">
                                            <div class="form-group">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Font-Size="Medium" placeholder="E-Mail"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>

                            </tbody>
                        </table>

                    </div>
                </div>
            </div>
        </div>
        <div style="float: right;">
            <%--  <a href="javascript:history.back();" class="btn bg-grey waves-effect"><i class="material-icons">keyboard_arrow_left</i>
                        <span>GERİ</span></a>--%>
            <asp:LinkButton ID="btnSave" runat="server" CssClass="btn bg-blue waves-effect" OnClick="btnSave_Click"><i class="material-icons">check</i>
                                    <span>SAVE</span></asp:LinkButton>
        </div>

    </form>

</body>
</html>

<!-- Bootstrap Core Js -->
<script src="plugins/bootstrap/js/bootstrap.js"></script>

<!-- Select Plugin Js -->
<script src="plugins/bootstrap-select/js/bootstrap-select.js"></script>

<!-- Slimscroll Plugin Js -->
<script src="plugins/jquery-slimscroll/jquery.slimscroll.js"></script>

<!-- Waves Effect Plugin Js -->
<script src="plugins/node-waves/waves.js"></script>

<!-- SweetAlert Plugin Js -->
<script src="plugins/sweetalert/sweetalert.min.js"></script>

<!-- Jquery CountTo Plugin Js -->
<script src="plugins/jquery-countto/jquery.countTo.js"></script>

<!-- Sparkline Chart Plugin Js -->
<script src="plugins/jquery-sparkline/jquery.sparkline.js"></script>

<!-- Light Gallery Plugin Js -->
<script src="plugins/light-gallery/js/lightgallery-all.js"></script>

<!-- Custom Js -->
<script src="js/pages/medias/image-gallery.js"></script>

<!-- Bootstrap Notify Plugin Js -->
<script src="plugins/bootstrap-notify/bootstrap-notify.js"></script>

<script src="js/admin.js"></script>
<script src="js/pages/index.js"></script>
<script src="js/pages/ui/notifications.js"></script>
<script src="js/pages/ui/tooltips-popovers.js"></script>

<script type='text/javascript' src='js/jquery.hoverIntent.minified.js'></script>
<script type='text/javascript' src='js/jquery.dcverticalmegamenu.1.3.js'></script>

<script src="css/menu/script.js"></script>
