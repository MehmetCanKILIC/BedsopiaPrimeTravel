<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingNotConfirme.aspx.cs" Inherits="Bedsopia_Prime_Travel.BookingNotConfirme" %>

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
    <form runat="server">
        <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>

        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <h2>
                            <asp:Literal ID="ltrBaslik" Text="Rezervasyon Bilgileri" runat="server"></asp:Literal></h2>
                    </div>

                    <div class="body">
                        <table class="table table-striped">
                            <tbody>
                                <tr>
                                    <td>Voucher Number</td>
                                    <td>
                                        <asp:Literal ID="ltrVoucherNumber" runat="server"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <td>Confirme Note</td>
                                    <td>
                                        <div class="col-lg-10" style="margin-bottom: 0;">
                                            <div class="form-group">
                                                <div class="form-line">
                                                    <asp:TextBox ID="txtConfirmeNote" TextMode="MultiLine" Style="font-size: medium; width:100%;" runat="server" placeholder="Note"></asp:TextBox>
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

        <div class="clear"></div>
         <div style="float: right;">
      
        <asp:LinkButton ID="btnKaydet" runat="server" CssClass="btn bg-blue waves-effect" OnClick="btnKaydet_Click"><i class="material-icons">check</i>
                                    <span>KAYDET</span></asp:LinkButton>
    </div>
    </form>
</body>
</html>

</html>
