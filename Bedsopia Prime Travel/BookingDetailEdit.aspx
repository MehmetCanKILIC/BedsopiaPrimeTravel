<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingDetailEdit.aspx.cs" Inherits="Bedsopia_Prime_Travel.BookingDetailEdit" %>


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
    <form runat="server">
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

                                <tr>
                                    <td>Voucher Number</td>
                                    <td>
                                        <asp:TextBox ID="ltrVoucherNumber" Enabled="true" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Hotel Name</td>
                                    <td>
                                        <asp:TextBox ID="ltrHotelName" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Check In</td>
                                    <td>
                                        <asp:TextBox ID="ltrCheckIn" CssClass="datepicker date_tr form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Check Out</td>
                                    <td>
                                        <asp:TextBox ID="ltrCheckOut" CssClass="datepicker date_tr form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Pessenger Name</td>
                                    <td>
                                        <asp:TextBox ID="ltrPessengerName" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Note</td>
                                    <td>
                                        <asp:TextBox ID="ltrNote" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Nationality</td>
                                    <td>
                                        <asp:TextBox ID="ltrNationality" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Status</td>
                                    <td>
                                        <asp:TextBox ID="ltrStatus" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Cost</td>
                                    <td>
                                        <asp:TextBox ID="ltrCost" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Cost Currency</td>
                                    <td>
                                        <asp:TextBox ID="ltrCostCurrency" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Room Type</td>
                                    <td>
                                        <asp:TextBox ID="ltrRoomType" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Board Type</td>
                                    <td>
                                        <asp:TextBox ID="ltrBoardType" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>NonRefundable</td>
                                    <td>
                                        <asp:TextBox ID="ltrNonRefundable" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td>Selling Price</td>
                                    <td>
                                        <asp:TextBox ID="ltrSellingPrice" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Sell Currency</td>
                                    <td>
                                        <asp:TextBox ID="ltrSellCurrency" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>BookingDate</td>
                                    <td>
                                        <asp:TextBox ID="ltrBookingDate" CssClass="datepicker date_tr form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Agency Name</td>
                                    <td>
                                        <asp:TextBox ID="ltrAgencyName" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Agency Reference Number</td>
                                    <td>
                                        <asp:TextBox ID="ltrAgencyRef" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>



                                <tr>
                                    <td>Area Name</td>
                                    <td>
                                        <asp:TextBox ID="ltrAreaName" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td>Customer Remarks</td>
                                    <td>
                                        <asp:TextBox ID="ltrRemarks" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server"></asp:TextBox></td>
                                </tr>

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
                                            <td>
                                                <asp:TextBox ID="txtPaxName" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server" placeholder="Name" Text='<%#Eval("Name") %>'></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtPaxLastName" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server" placeholder="LastName" Text='<%#Eval("LastName") %>'></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtPaxTipPax" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server" placeholder="TipPax" Text='<%#Eval("TipPax") %>'></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtPaxAge" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server" placeholder="Age" Text='<%#Eval("Age") %>'></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtPaxBorn" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server" placeholder="Born" Text='<%#Eval("Born") %>'></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtPaxCity" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server" placeholder="City" Text='<%#Eval("City") %>'></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtPaxCountry" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server" placeholder="Country" Text='<%#Eval("Country") %>'></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtPaxEmail" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server" placeholder="Email" Text='<%#Eval("Email") %>'></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtPaxReferenceNumber" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server" placeholder="ReferenceNumber" Text='<%#Eval("ReferenceNumber") %>'></asp:TextBox></td>
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

        <div style="float: right;">
     <%--   <a href="javascript:history.back();" class="btn bg-grey waves-effect"><i class="material-icons">keyboard_arrow_left</i>
            <span>GERİ</span></a>--%>
        <asp:LinkButton ID="btnKaydet" runat="server" CssClass="btn bg-blue waves-effect" OnClick="btnKaydet_Click" ><i class="material-icons">check</i>
                                    <span>SAVE</span></asp:LinkButton>
    </div>




    <div class="clearfix"></div>


    <br />
    <br />
    </form>
</body>
</html>
