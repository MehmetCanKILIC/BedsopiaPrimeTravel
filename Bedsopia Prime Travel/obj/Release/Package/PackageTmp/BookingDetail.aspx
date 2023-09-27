<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingDetail.aspx.cs" Inherits="Bedsopia_Prime_Travel.BookingDetail" %>

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
    <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>

    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="card">
                <div class="header">
                    <h2>
                        <asp:Literal ID="ltrBaslik" Text="RESERVATION INFORMATION" runat="server"></asp:Literal></h2>
                </div>

                <div class="body">
                    <table class="table table-striped">
                        <tbody>


                            <%if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2" || Session["TitleFilter"].ToString() == "" || Session["TitleFilter"].ToString() == null)
                                {%>
                            <tr>
                                <td>Voucher Number</td>
                                <td>
                                    <asp:Literal ID="ltrVoucherNumber" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>Hotel Name</td>
                                <td>
                                    <asp:Literal ID="ltrHotelName" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>Check In</td>
                                <td>
                                    <asp:Literal ID="ltrCheckIn" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>Check Out</td>
                                <td>
                                    <asp:Literal ID="ltrCheckOut" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>Pessenger Name</td>
                                <td>
                                    <asp:Literal ID="ltrPessengerName" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>Note</td>
                                <td>
                                    <asp:Literal ID="ltrNote" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>Nationality</td>
                                <td>
                                    <asp:Literal ID="ltrNationality" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>Status</td>
                                <td>
                                    <asp:Literal ID="ltrStatus" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>Cost</td>
                                <td>
                                    <asp:Literal ID="ltrCost" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>Cost Currency</td>
                                <td>
                                    <asp:Literal ID="ltrCostCurrency" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>Room Type</td>
                                <td>
                                    <asp:Literal ID="ltrRoomType" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>Board Type</td>
                                <td>
                                    <asp:Literal ID="ltrBoardType" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>NonRefundable</td>
                                <td>
                                    <asp:Literal ID="ltrNonRefundable" runat="server"></asp:Literal></td>
                            </tr>
                            <%if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2")
                                {%>
                            <tr>
                                <td>Selling Price</td>
                                <td>
                                    <asp:Literal ID="ltrSellingPrice" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>Sell Currency</td>
                                <td>
                                    <asp:Literal ID="ltrSellCurrency" runat="server"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td>Agency Name</td>
                                <td>
                                    <asp:Literal ID="ltrAgencyName" runat="server"></asp:Literal></td>
                            </tr>
                            <%} %>
                            <tr>
                                <td>BookingDate</td>
                                <td>
                                    <asp:Literal ID="ltrBookingDate" runat="server"></asp:Literal></td>
                            </tr>

                            <tr>
                                <td>Agency Reference Number</td>
                                <td>
                                    <asp:Literal ID="ltrAgencyRef" runat="server"></asp:Literal></td>
                            </tr>



                            <tr>
                                <td>Area Name</td>
                                <td>
                                    <asp:Literal ID="ltrAreaName" runat="server"></asp:Literal></td>
                            </tr>

                            <tr>
                                <td>Customer Remarks</td>
                                <td>
                                    <asp:Literal ID="ltrRemarks" runat="server"></asp:Literal></td>
                            </tr>

                            <%}
                                else
                                {
                                    string[] filter = Session["TitleFilter"].ToString().Split(',');
                                    for (int i = 0; i < filter.Length; i++)
                                    {
                                        switch (filter[i].ToString())
                                        {
                                            case "Voucher Number":
                            %>

                            <tr>
                                <td>Voucher Number</td>
                                <td>
                                    <asp:Literal ID="ltrVoucherNumberHotel" runat="server"></asp:Literal></td>
                            </tr>

                            <%
                                    break;
                                case "Hotel Name":
                            %>
                            <tr>
                                <td>Hotel Name</td>
                                <td>
                                    <asp:Literal ID="ltrHotelNameHotel" runat="server"></asp:Literal></td>
                            </tr>

                            <%
                                    break;
                                case "Check In":
                            %>
                            <tr>
                                <td>Check In</td>
                                <td>
                                    <asp:Literal ID="ltrCheckInHotel" runat="server"></asp:Literal></td>
                            </tr>

                            <%
                                    break;
                                case "Check Out":
                            %>
                            <tr>
                                <td>Check Out</td>
                                <td>
                                    <asp:Literal ID="ltrCheckOutHotel" runat="server"></asp:Literal></td>
                            </tr>

                            <%
                                    break;
                                case "Pessenger Name":
                            %>
                            <tr>
                                <td>Pessenger Name</td>
                                <td>
                                    <asp:Literal ID="ltrPessengerNameHotel" runat="server"></asp:Literal></td>
                            </tr>
                            <%
                                    break;
                                case "Nationality":
                            %>
                            <tr>
                                <td>Nationality</td>
                                <td>
                                    <asp:Literal ID="ltrNationalityHotel" runat="server"></asp:Literal></td>
                            </tr>
                            <%
                                    break;
                                case "Status":
                            %>
                            <tr>
                                <td>Status</td>
                                <td>
                                    <asp:Literal ID="ltrStatusHotel" runat="server"></asp:Literal></td>
                            </tr>
                            <%
                                    break;
                                case "Cost":
                            %>
                            <tr>
                                <td>Cost</td>
                                <td>
                                    <asp:Literal ID="ltrCostHotel" runat="server"></asp:Literal></td>
                            </tr>

                            <%
                                    break;
                                case "Cost Currency":
                            %>
                            <tr>
                                <td>Cost Currency</td>
                                <td>
                                    <asp:Literal ID="ltrCostCurrencyHotel" runat="server"></asp:Literal></td>
                            </tr>
                            <%
                                    break;
                                case "Room Type":
                            %>
                            <tr>
                                <td>Room Type</td>
                                <td>
                                    <asp:Literal ID="ltrRoomTypeHotel" runat="server"></asp:Literal></td>
                            </tr>
                            <%
                                    break;
                                case "Board Type":
                            %>
                            <tr>
                                <td>Board Type</td>
                                <td>
                                    <asp:Literal ID="ltrBoardTypeHotel" runat="server"></asp:Literal></td>
                            </tr>
                            <%
                                    break;
                                case "NonRefundable":
                            %>
                            <tr>
                                <td>NonRefundable</td>
                                <td>
                                    <asp:Literal ID="ltrNonRefundableHotel" runat="server"></asp:Literal></td>
                            </tr>

                            <%
                                    break;
                                case "BookingDate":
                            %>
                            <tr>
                                <td>BookingDate</td>
                                <td>
                                    <asp:Literal ID="ltrBookingDateHotel" runat="server"></asp:Literal></td>
                            </tr>
                            <%
                                    break;

                                case "Agency Reference Number":
                            %>
                            <tr>
                                <td>Agency Reference Number</td>
                                <td>
                                    <asp:Literal ID="ltrAgencyRefHotel" runat="server"></asp:Literal></td>
                            </tr>
                            <%
                                    break;
                                case "Area Name":
                            %>


                            <tr>
                                <td>Area Name</td>
                                <td>
                                    <asp:Literal ID="ltrAreaNameHotel" runat="server"></asp:Literal></td>
                            </tr>
                            <%
                                    break;
                                case "Customer Remarks":
                            %>
                            <tr>
                                <td>Customer Remarks</td>
                                <td>
                                    <asp:Literal ID="ltrRemarksHotel" runat="server"></asp:Literal></td>
                            </tr>

                            <%
                                                break;

                                            default:
                                                break;
                                        }

                                    }

                                }%>
                        </tbody>

                    </table>

                </div>


            </div>
        </div>
    </div>

    <div class="clear"></div>

    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="card">
                <div class="header">
                    <h2>
                        <asp:Literal ID="ltrBaslikListe" Text="RESERVATION PAXS" runat="server"></asp:Literal></h2>
                </div>
                <div class="body">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>LastName</th>
                                <th>TipPax</th>
                                <th>Age</th>
                                <th>Born</th>
                                <th>City</th>
                                <th>Country</th>
                                <th>Email</th>
                                <th>ReferenceNumber</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvBookingsList" runat="server" OnPagePropertiesChanged="lvBookingsList_PagePropertiesChanged" OnItemDataBound="lvBookingsList_ItemDataBound">
                                <ItemTemplate>
                                    <tr style="width: 70%;">
                                        <td><strong><%#Eval("Name") %></strong></td>
                                        <td><%#Eval("LastName") %></td>
                                        <td><%#Eval("TipPax") %></td>
                                        <td><strong><%#Eval("Age") %></strong></td>
                                        <td><%#Eval("Born") %></td>
                                        <td><%#Eval("City") %></td>
                                        <td><%#Eval("Country") %></td>
                                        
                                        <td></td>
                                        <td><%#Eval("ReferenceNumber") %></td>
                                        <td></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>

                        </tbody>
                    </table>

                </div>
            </div>
        </div>
    </div>
</body>
</html>
