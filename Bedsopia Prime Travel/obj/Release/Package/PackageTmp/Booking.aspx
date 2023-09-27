<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="Bedsopia_Prime_Travel.Booking" MasterPageFile="~/Bedsopia.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="author" content="Mehmet Can KILIÇ, mehmet-ck@outlook.com" />

    <link href="plugins/light-gallery/css/lightgallery.css" rel="stylesheet" />

    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css" />
    <style type="text/css">
        td {
            /*cursor: pointer;*/
            line-height: 30px !important;
        }
    </style>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link type="text/css" href="css/jquery.datepick.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.datepick.js"></script>
    <script type="text/javascript" src="js/jquery.datepick-tr.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>


    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/bs-3.3.7/jq-2.2.4/jszip-3.1.3/pdfmake-0.1.27/dt-1.10.15/b-1.3.1/b-html5-1.3.1/b-print-1.3.1/r-2.1.1/rg-1.0.0/datatables.min.css" />

    <script type="text/javascript" src="https://cdn.datatables.net/v/bs-3.3.7/jq-2.2.4/jszip-3.1.3/pdfmake-0.1.27/dt-1.10.15/b-1.3.1/b-html5-1.3.1/b-print-1.3.1/r-2.1.1/rg-1.0.0/datatables.min.js"></script>


    <script>
        $(document).ready(function () {
            $(".collapseToggle").click(function () {
                if ($(".accordion-material-icons").html() == "arrow_upward") {
                    $(".accordion-material-icons").html("arrow_downward")
                }
                else {
                    $(".accordion-material-icons").html("arrow_upward");
                }
            });
        });
    </script>


    <script type="text/javascript">
        $(document).ready(function () {
            $("#LinkButton1").click(function () {
                dvPassport.style.display = "block";
            });
            $("#LinkButton1").click(function () {
                dvPassport.style.display = "none";
            });
        });

        $(document).ready(function () {

            $('.date_tr').bootstrapMaterialDatePicker({
                format: 'DD.MM.YYYY',
                lang: 'tr',
                //weekStart: 0,
                time: false,
                cancelText: 'VAZGEÇ'
            });



        });

    </script>
    <script type="text/javascript">
        function ShowHideDiv(chkPassport) {
            //var dvPassport = document.getElementById("dvPassport");
            if (chkPassport.checked) {
                // Select all Products in Grid
                $("input[id*='cbSecim']").prop("checked", true);
                // Make discontinue and delete buttons visible
                dvPassport.style.display = "block";

                makeButtonsVisible();
            }
            else {
                // Unselect all Products in grid
                $("input[id*='cbSecim']").prop("checked", false);
                // Make discontinue and delete buttons Invisible
                dvPassport.style.display = "none";
                makeButtonsInvisible();
            }
            //    dvPassport.style.display = chkPassport.checked ? "block" : "none";
        }
        function makeButtonsVisible() {
            $("#panelAll").removeClass("invisible");
            $("#deleteButton").removeClass("invisible");
        }

        function makeButtonsInvisible() {
            $("#panelAll").addClass("invisible");
            $("#deleteButton").addClass("invisible");
        }


    </script>
    <script type="text/javascript">
        $(function () {
            // Get all checkboxes in grid
            // They all will contain 'chkSelect'
            var checkboxes = $("input[id*='cbSecim']");

            // Connect to click event.
            checkboxes.click(function () {
                // If any are checked, make Discontinue and Delete
                // buttons visible
                if (checkboxes.is(":checked")) {
                    dvPassport.style.display = "block";
                }
                else {
                    dvPassport.style.display = "none";
                }
            });
        })

    </script>
    <script type="text/javascript">
        function OnayAlert(ctl, event) {

            var defaultAction = $(ctl).prop("href");

            event.preventDefault();
            Swal.fire({
                title: "All Confirmed",
                text: "All Booking Confirme!",
                icon: "question",
                input: 'textarea',
                inputAttributes: {
                    autocapitalize: 'off'
                },
                showCancelButton: true,
                confirmButtonText: 'OK',
                showLoaderOnConfirm: true,
                preConfirm: (login) => {
                    console.log(login);
                    $.ajax({
                        url: '/Booking.aspx/GetEmployeeById',
                        type: 'post',
                        contentType: "application/json; charset=utf-8",
                        data: '{Description:"' + login + '"}',
                        dataType: "json",
                        success: function (data) {
                            console.log(data);

                        },
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                },
                allowOutsideClick: () => !Swal.isLoading()
            }).then((result) => {

                if (result.isConfirmed) {



                }
                window.location.href = defaultAction;
                return true;
            })
        }
    </script>
    <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/toastify-js/src/toastify.min.css">
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/toastify-js"></script>
    <script type="text/javascript">
        function Toasts() {
            console.log(Toastify())
            Toastify({
                text: "Success!",
                duration: 3000,
                newWindow: true,
                close: true,
                gravity: "top", // `top` or `bottom`
                position: "right", // `left`, `center` or `right`
                stopOnFocus: true, // Prevents dismissing of toast on hover
                style: {

                    background: "linear-gradient(to right, #00b09b, #96c93d)",
                },
                onClick: function () { } // Callback after click
            }).showToast();
        }
    </script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.min.js"></script>
    <link rel="stylesheet" href="@sweetalert2/theme-default/default.css">

    <script src="sweetalert2/dist/sweetalert2.min.js"></script>

    <script type="text/javascript">
        function PostToNewWindow() {
            originalTarget = document.forms[0].target;
            document.forms[0].target = '_blank';
            window.setTimeout("document.forms[0].target=originalTarget;", 300);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>
            <div class="row clearfix" id="accordion">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="card">


                        <div class="header bg-blue clearfix collapseToggle" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                            <div class="card-header row header" id="headingOne">
                                <a href="#" class="col-md-11" style="text-decoration: none;"><ins>
                                    <h2 style="width: 100%; float: left;">FILTERS</h2>
                                </ins></a>
                                <div class="col-md-1"><i class="accordion-material-icons material-icons">arrow_downward</i></div>
                            </div>

                        </div>


                        <div id="collapseOne" class="collapse " aria-labelledby="headingOne" data-parent="#accordion">

                            <div class="body">
                                <div class="row clearfix">
                                    <div class="col-lg-5" style="margin-bottom: 0;">
                                        <asp:Literal ID="ltrilktar1" runat="server" Text="Begin Date"></asp:Literal>

                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:TextBox ID="txtIlkTarih" Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="Başlangıç Tarihi"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-5" style="margin-bottom: 0;">
                                        <asp:Literal ID="Literal1" runat="server" Text="End Date"></asp:Literal>

                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:TextBox ID="txtSonTarih" Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="Bitiş Tarihi"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-5" style="margin-bottom: 0;">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:TextBox ID="txtArananKelime" runat="server" CssClass="form-control" Font-Size="Medium" placeholder="Booking Code"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-5" style="margin-bottom: 0;">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:TextBox ID="txtVoucherNumber" runat="server" CssClass="form-control" Font-Size="Medium" placeholder="Voucher Number"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-5" style="margin-bottom: 0;">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:TextBox ID="txtHotelName" runat="server" CssClass="form-control" Font-Size="Medium" placeholder="Hotel Name"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-5" style="margin-bottom: 0;">
                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:TextBox ID="txtAreaName" runat="server" CssClass="form-control" Font-Size="Medium" placeholder="Area Name"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-5" style="margin-bottom: 0;">
                                        <asp:Literal ID="Literal2" runat="server" Text="Confirmed"></asp:Literal>

                                        <div class="form-line">
                                            <asp:DropDownList ID="dropFilter" CssClass="form-control show-tick" runat="server">
                                                <asp:ListItem Text="ALL" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="CONFIRMED" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="NOT CONFIRMED" Value="2"></asp:ListItem>
                                            </asp:DropDownList>


                                        </div>
                                    </div>
                                    <div class="col-lg-5" style="margin-bottom: 0;">
                                        <asp:Literal ID="Literal3" runat="server" Text="Booking Date"></asp:Literal>

                                        <div class="form-group">
                                            <div class="form-line">
                                                <asp:TextBox ID="txtBookingDate" Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="BookingDate"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-10" style="margin-bottom: 0; margin-top: 10px; text-align: right;">
                                        <asp:LinkButton ID="btnFiltre" runat="server" CssClass="btn bg-blue waves-effect" OnClick="btnFiltre_Click" Style="margin-left: 1px;"><i class="material-icons">search</i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row clearfix">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="card">
                        <div class="header">
                            <h2>RESERVATIONS</h2>
                        </div>

                        <div class="body table-responsive" style="background-color: white;">

                            <table class="table table-striped">

                                <thead>

                                    <tr>
                                        <th style="width: 2%;">
                                            <asp:CheckBox ID="chkActions" Text="ALL" onclick="ShowHideDiv(this)" runat="server" />
                                        </th>
                                        <th style="position: fixed; text-align: center;">
                                            <div id="dvPassport" style="display: none;">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                                    <div class="card">
                                                        <div class="header">

                                                            <asp:LinkButton ID="linkConfirme" runat="server" CssClass="btn bg-blue waves-effect" OnClientClick="OnayAlert(this, event);" OnCommand="linkConfirme_Command"><i class="material-icons">check_circle</i> All Confirme</asp:LinkButton>
                                                            <asp:LinkButton ID="linkNotConfirme" runat="server" CssClass="btn bg-blue waves-effect" OnClientClick="OnayAlert(this, event);" OnCommand="linkNotConfirme_Command"><i class="material-icons">highlight_off</i> All Not Confirme</asp:LinkButton>
                                                            <%if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2")
                                                                {%>
                                                            <%--                                                                                                        <asp:LinkButton ID="linkReminder" runat="server" CssClass="btn bg-blue waves-effect" OnClientClick="OnayAlert(this, event);" OnCommand="linkReminder_Command" ><i class="material-icons">send</i> All Reminder</asp:LinkButton>--%>
                                                            <%} %>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </th>

                                        <th style="text-align: center;"></th>
                                        <%if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2" || Session["TitleFilter"].ToString() == "" || Session["TitleFilter"].ToString() == null)
                                            {%>
                                        <th>
                                            <asp:Literal ID="ltrVoucheradmin" runat="server"></asp:Literal></th>
                                        <th>
                                            <asp:Literal ID="ltrHotelNameAdmin" runat="server"></asp:Literal></th>
                                        <th>
                                            <asp:Literal ID="ltrCheckInAdmin" runat="server"></asp:Literal></th>
                                        <th>
                                            <asp:Literal ID="ltrCheckOutAdmin" runat="server"></asp:Literal></th>
                                        <th>
                                            <asp:Literal ID="ltrPessengerName" runat="server"></asp:Literal></th>
                                        <th>
                                            <asp:Literal ID="ltrNationalityAdmin" runat="server"></asp:Literal></th>
                                        <th>
                                            <asp:Literal ID="ltrStatusAdmin" runat="server"></asp:Literal></th>
                                        <th>
                                            <asp:Literal ID="ltrBookingDateAdmin" runat="server"></asp:Literal></th>
                                        <%if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2")
                                            { %>
                                        <th>
                                            <asp:Literal ID="ltrAgencyNameAdmin" runat="server"></asp:Literal></th><%} %>
                                        <th>
                                            <asp:Literal ID="ltrBookingCodeAdmin" runat="server"></asp:Literal></th>
                                        <th>
                                            <asp:Literal ID="ltrConfirmeDateAdmin" runat="server"></asp:Literal></th>
                                        <% }
                                            else
                                            {
                                                string[] filter = Session["TitleFilter"].ToString().Split(',');
                                                for (int i = 0; i < filter.Length; i++)
                                                {
                                                    switch (filter[i].ToString())
                                                    {
                                                        case "Voucher Number":
                                        %>
                                        <th> <asp:Literal ID="ltrVoucher" runat="server"></asp:Literal></th>
                                        <%
                                                break;
                                            case "Hotel Name":
                                        %>
                                        <th> <asp:Literal ID="ltrHotelName" runat="server"></asp:Literal></th>
                                        <%
                                                break;
                                            case "Check In":
                                        %>
                                        <th> <asp:Literal ID="ltrCheckIn" runat="server"></asp:Literal></th>
                                        <%
                                                break;
                                            case "Check Out":
                                        %>
                                        <th> <asp:Literal ID="ltrCheckOut" runat="server"></asp:Literal></th>
                                        <%
                                                break;
                                            case "Pessenger Name":
                                        %>
                                        <th> <asp:Literal ID="ltrPessenger" runat="server"></asp:Literal></th>
                                        <%
                                                break;
                                            case "Nationality":
                                        %>
                                        <th> <asp:Literal ID="ltrNationality" runat="server"></asp:Literal></th>
                                        <%
                                                break;
                                            case "Status":
                                        %>
                                        <th> <asp:Literal ID="ltrStatus" runat="server"></asp:Literal></th>
                                        <%
                                                break;
                                            case "BookingDate":
                                        %>
                                        <th> <asp:Literal ID="ltrBookingDate" runat="server"></asp:Literal></th>
                                        <%
                                                break;

                                            case "BookingCode":
                                        %>
                                        <th> <asp:Literal ID="ltrBookingCode" runat="server"></asp:Literal></th>
                                        <%
                                                            break;

                                                        default:
                                                            break;
                                                    }

                                                }

                                            }%>





                                        <th style="width: 13%; color: orangered; font: bold;"></th>
                                    </tr>

                                </thead>
                                                        <tbody>

                                <asp:ListView ID="lvBookingsList" runat="server" OnItemDataBound="lvBookingsList_ItemDataBound">

                                    <ItemTemplate>
                                        <%# Eval("VisibleStatus").ToString() == "1" && Eval("BookingConfirm").ToString() == "" ? " <tr style=\"width: 70%; background-color:aliceblue;font-weight:bold;\" >" : "<tr style=\"width: 70%;\" > " %>
                                        <%--                                    <tr style="width: 70%;">--%>
                                        <td>
                                            <asp:CheckBox ID="cbSecim" Text=" " runat="server" CssClass='<%#Eval("BookingCode") %>' /></td>
                                        <td> </td>

                                        <%--                                    <td><%#Eval("VisibleStatus").ToString() == "1" && Eval("BookingConfirm").ToString() == "" && (Eval("Status").ToString() != "CaC" || Eval("Status").ToString() != "Can") ? "<center style=\"color:dodgerblue;font-weight:bold;\">NEW</center>" : Eval("Status").ToString() == "CaC" || Eval("Status").ToString() == "Can" ? "<center style=\"color:orangered;font-weight:bold;\">CANCEL</center>":"" %></td>--%>
                                        <td><%#Eval("VisibleStatus").ToString() == "1" && Eval("BookingConfirm").ToString() == ""  && (Eval("Status").ToString() != "CaC" || Eval("Status").ToString() != "Can") ? "<center style=\"color:dodgerblue\">NEW</center>" : Eval("BookingConfirm").ToString() == "1" && (Eval("Status").ToString() != "CaC" || Eval("Status").ToString() != "Can")  ? "<center style=\"color:greenyellow;font-weight:bold;\">CONFIRMED</center>":Eval("BookingConfirm").ToString() == "-1" && (Eval("Status").ToString() != "CaC" || Eval("Status").ToString() != "Can")  ?  "<center style=\"color:orangered;font-weight:bold;\">NOT CONFIRMED</center>": Eval("Status").ToString() == "CaC" || Eval("Status").ToString() == "Can" ? "<center style=\"color:red;font-weight:bold;\">CANCEL</center>": "" %></td>
                                        <%if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2" || Session["TitleFilter"].ToString() == "" || Session["TitleFilter"].ToString() == null)
                                            {%>
                                        <td><strong><%#Eval("Voucher Number") %></strong></td>
                                        <td><%#Eval("Hotel Name") %></td>
                                        <td><%#Eval("Check In","{0:dd.MM.yyyy}") %></td>
                                        <td><%#Eval("Check Out","{0:dd.MM.yyyy}") %></td>
                                        <td><%#Eval("Pessenger Name") %></td>
                                        <td><%#Eval("Nationality") %></td>
                                        <td><%#Eval("Status") %></td>

                                        <td><%#Eval("BookingDate","{0:dd.MM.yyyy}") %></td>
                                        <td><%#Eval("Agency Name") %></td>
                                        <td><strong><%#Eval("BookingCode") %></strong></td>
                                        <td><strong><%#Eval("BookingConfirmeDate", "{0:d/M/yyyy HH:mm}") %></strong></td>
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
                                        <td><strong><%#Eval("Voucher Number") %></strong></td>
                                        <%
                                                break;
                                            case "Hotel Name":
                                        %>
                                        <td><%#Eval("Hotel Name") %></td>
                                        <%
                                                break;
                                            case "Check In":
                                        %>
                                        <td><%#Eval("Check In","{0:dd.MM.yyyy}") %></td>
                                        <%
                                                break;
                                            case "Check Out":
                                        %>
                                        <td><%#Eval("Check Out","{0:dd.MM.yyyy}") %></td>
                                        <%
                                                break;
                                            case "Pessenger Name":
                                        %>
                                        <td><%#Eval("Pessenger Name") %></td>
                                        <%
                                                break;
                                            case "Nationality":
                                        %>
                                        <td><%#Eval("Nationality") %></td>
                                        <%
                                                break;
                                            case "Status":
                                        %>
                                        <td><%#Eval("Status") %></td>
                                        <%
                                                break;
                                            case "BookingDate":
                                        %>
                                        <td><%#Eval("BookingDate","{0:dd.MM.yyyy}") %></td>
                                        <%
                                                break;
                                           
                                            case "BookingCode":
                                        %>
                                        <td><strong><%#Eval("BookingCode") %></strong></td>
                                        <%
                                                            break;

                                                        default:
                                                            break;
                                                    }

                                                }
                                            }%>

                                        <td style="text-align: right;">
                                            <a href="BookingDetail.aspx?BookingCode=<%#Eval("BookingCode") %>" class="btn bg-grey waves-effect fancybox" title="Booking Detail"  data-fancybox-type="iframe" data-width="85%" data-height="85%"><i class="material-icons">open_in_new</i></a>
                                            <%if (Session["UserType"].ToString() != "2")
                                                {%>
                                            <a href="BookingConfirme.aspx?BookingCode=<%#Eval("BookingCode") %>" class="btn bg-grey waves-effect fancybox" title="Booking Confirme"  data-fancybox-type="iframe" data-width="45%" data-height="45%"><i class="material-icons">check_circle</i></a>
                                            <a href="BookingNotConfirme.aspx?BookingCode=<%#Eval("BookingCode") %>" class="btn bg-grey waves-effect fancybox" title="Booking Not Confirme"  data-fancybox-type="iframe" data-width="45%" data-height="45%"><i class="material-icons">highlight_off</i></a>
                                            <%}%>
                                            <%--                                            <a href="BookingDetail.aspx" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="90%" data-height="90%" onclientclick="OnayAlert(this, event);"><i class="material-icons">delete</i></a>--%>
                                            <%if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2")
                                                {%>
                                            <a href="BookingDetailEdit.aspx?BookingCode=<%#Eval("BookingCode") %>" class="btn bg-grey waves-effect fancybox" title="Booking Edit" data-fancybox-type="iframe" data-width="85%" data-height="85%"><i class="material-icons">edit</i></a>
                                            <%--                                                                                        <%#Eval("Hotel Status").ToString() != "1" ? "<a href=\"OpenSaleAdmin.aspx?SaleId="+Eval("BookingCode")+"\"  title=\"Not Confirme\" class=\"btn bg-grey waves-effect\" ><i class=\"material-icons\">highlight_off</i></a>": "" %>--%>

                                            <%--    <%#Eval("Hotel Status").ToString() != "1" ? "<a href=\"OpenSaleAdmin.aspx?SaleId="+Eval("BookingCode")+"\"  title=\"İşleme Alındı\" class=\"btn bg-grey waves-effect\" ><i class=\"material-icons\">add_alert</i></a>": "" %>--%>
                                            <%#Eval("Hotel Status").ToString() != "1" ? "<a href=\"BookingReminder.aspx?BookingCode="+Eval("BookingCode")+" \"  title=\"Reminder\" class=\"btn bg-grey waves-effect fancybox\" data-fancybox-type=\"iframe\" data-width=\"85%\" data-height=\"85%\" ><i class=\"material-icons\">send</i></a>": "" %>
                                            <%}
                                                else
                                                {%>

                                            <%} %>
                                        </td>
                                        </tr>
                                    
                                    </ItemTemplate>

                                </asp:ListView>
                                                            </tbody>
                            </table>

                        </div>

                    </div>
                </div>
            </div>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    
                        <div style="float: right; margin-top: 40px; margin-bottom: 40px;">
                            <asp:DataPager ID="pagerListe" runat="server" PagedControlID="lvBookingsList" PageSize="20">
                                <Fields>
                                    <asp:NumericPagerField NumericButtonCssClass="GridPage" CurrentPageLabelCssClass="GridPage"
                                        NextPageText="»" PreviousPageText="«" NextPreviousButtonCssClass="GridPage" ButtonCount="10" />
                                </Fields>
                            </asp:DataPager>
                        </div>

                        <div class="clearfix"></div>

    <script src="plugins/momentjs/moment.js"></script>
    <script src="plugins/momentjs/moment-with-locales.min.js"></script>

    <!-- Bootstrap Material Datetime Picker Plugin Js -->
    <script src="plugins/bootstrap-material-datetimepicker/js/bootstrap-material-datetimepicker.js"></script>

    <!-- Autosize Plugin Js -->
    <script src="js/fancybox/jquery.fancybox.js?v=2.1.4" type="text/javascript"></script>
    <script src="js/fancybox/jquery.mousewheel-3.0.6.pack.js" type="text/javascript"></script>
    <link href="js/fancybox/jquery.fancybox.css?v=2.1.4"" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        $(document).ready(function () {

            $(".fancybox").fancybox({
                type: 'iframe',
                autoSize: false,
                beforeShow: function () {
                    this.width = $(this.element).data("width") ? $(this.element).data("width") : null;
                    this.height = $(this.element).data("height") ? $(this.element).data("height") : null;
                },
                fitToView: false,
                minWidth: 200,
                minHeight: 200,
                maxWidth: 1600,
                maxHeight: 1200,
                afterClose: function () {
                    location.href = "Booking.aspx";
                }
            });

        });
    </script>
</asp:Content>
