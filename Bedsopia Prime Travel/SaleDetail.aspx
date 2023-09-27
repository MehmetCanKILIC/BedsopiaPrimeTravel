<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleDetail.aspx.cs" Inherits="Bedsopia_Prime_Travel.SaleDetail" %>

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
                        <h2>OPEN / STOP SALE DETAIL</h2>
                    </div>
                    <div class="body">
                        <table class="table table-striped">
                            <tbody>
                                <tr>
                                    <td>
                                        <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Hotel Name</span>
                                    </td>
                                    <td>

                                        <asp:Literal ID="ltrHotelName" runat="server"></asp:Literal>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Notification Date</span>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrInsertDate" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Room Type</span>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrRoom" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Board Type</span>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrBoard" runat="server"></asp:Literal>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Nationality</span>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrNationality" runat="server"></asp:Literal>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">SalesDate</span>
                                    </td>
                                    <td>
                                        <table class="table table-striped">
                                            <thead>
                                                <tr>
                                                    <th>BeginDate</th>
                                                    <th>EndDate</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:ListView ID="lvSaleDate" runat="server">
                                                    <ItemTemplate>
                                                        <tr style="width: 70%;">
                                                            <td><%#Eval("BeginDate") %></td>
                                                            <td><%#Eval("EndDate") %></td>
                                                            <td></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="row clearfix">
            <%if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2")
                {%>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <h2>RESERVATION</h2>
                    </div>
                    <div class="body table-responsive" style="background-color: white;">
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Voucher Number</th>
                                    <th>Hotel Name</th>
                                    <th>Check In</th>
                                    <th>Check Out</th>
                                    <th>Pessenger Name</th>
                                    <th>Note</th>
                                    <th>Nationality</th>
                                    <th>Status</th>


                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="lvReservation" runat="server" OnPagePropertiesChanged="lvReservation_PagePropertiesChanged">
                                    <ItemTemplate>
                                        <tr style="width: 70%;">
                                            <td><strong><%#Eval("Voucher Number") %></strong></td>
                                            <td><%#Eval("Hotel Name") %></td>
                                            <td><%#Eval("Check In","{0:dd.MM.yyyy}") %></td>
                                            <td><%#Eval("Check Out","{0:dd.MM.yyyy}") %></td>
                                            <td><%#Eval("Pessenger Name") %></td>
                                            <td><%#Eval("Note") %></td>
                                            <td><%#Eval("Nationality") %></td>
                                            <td><%#Eval("Status") %></td>
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
        <%} %>
    </form>
</body>
</html>
