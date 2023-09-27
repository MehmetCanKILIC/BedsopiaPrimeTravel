<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceSendMail.aspx.cs" Inherits="Bedsopia_Prime_Travel.InvoiceSendMail" %>

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
                        <h2>INVOICE SEND MAIL</h2>
                    </div>
                    <div class="body">
                        <table class="table table-striped">
                            <tbody>
                                <tr>
                                    <td>
                                       BookingCode
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrBookingCode" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                       Invoice Number
                                    </td>
                                    <td>

                                        <asp:Literal ID="ltrInvoiceNumber" runat="server"></asp:Literal>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        E-Mail
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrEmail" runat="server"></asp:Literal>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                       E-Mail Adresi Ekle
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                     
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="col-sm-12">
                            <div class="card">
                                <div class="body bg-blue-grey">
                                    1'den fazla e-mail girişlerinde e-mailler arasına " ; " (noktalı virgül) kullanınız.
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div style="float: right;">

                    <asp:LinkButton ID="btnKaydet" runat="server" CssClass="btn bg-blue waves-effect" OnClick="btnKaydet_Click"><i class="material-icons">&nbsp;&nbsp; send</i>
                                    <span>SEND</span></asp:LinkButton>

                </div>
            </div>







<%--
            <%if (Session["UserId"].ToString() == "1")
                {%>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <div class="card">
                    <div class="header">
                        <h2>REMINDER LOG</h2>
                    </div>
                    <div class="body table-responsive" style="background-color: white;">
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Booking Code</th>
                                    <th>E-mail</th>
                                    <th>Reminder Date</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="lvReservationEmailLog" runat="server" OnPagePropertiesChanged="lvReservation_PagePropertiesChanged">
                                    <ItemTemplate>
                                        <tr style="width: 70%;">
                                            <td><strong><%#Eval("BookingCode") %></strong></td>
                                            <td><%#Eval("Email") %></td>
                                            <td><%#Eval("LogDate") %></td>

                                            <td></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </tbody>
                        </table>
                    </div>



                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
        <%} %>--%>
    </form>
</body>
</html>
