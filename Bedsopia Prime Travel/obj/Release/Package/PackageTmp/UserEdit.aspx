<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="Bedsopia_Prime_Travel.UserEdit" %>



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
</head>
<body style="background-color: #f5f5f5;">
    <form id="form1" runat="server">
        <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <h2>USER DETAIL</h2>
                    </div>
                    <div class="body">
                        <table class="table table-striped">
                            <tbody>
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
            <asp:LinkButton ID="btnKaydet" runat="server" CssClass="btn bg-blue waves-effect" OnClick="btnKaydet_Click"><i class="material-icons">check</i>
                                    <span>KAYDET</span></asp:LinkButton>
        </div>
  
    </form>
</body>
</html>
