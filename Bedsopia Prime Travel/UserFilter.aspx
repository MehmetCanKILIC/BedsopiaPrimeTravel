<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserFilter.aspx.cs" Inherits="Bedsopia_Prime_Travel.UserFilter" MasterPageFile="~/Bedsopia.Master" %>

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
    <link href="style.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <link rel="stylesheet" href="font-awesome-4.5.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="js/chosen/docsupport/prism.css" />
    <link rel="stylesheet" href="js/chosen/chosen.css" />

    <link type="text/css" href="css/jquery.datepick.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.datepick.js"></script>
    <script type="text/javascript" src="js/jquery.datepick-tr.js"></script>



    <script type="text/javascript">

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
        function PostToNewWindow() {
            originalTarget = document.forms[0].target;
            document.forms[0].offsetHeight = 55;
            document.forms[0].target = '_blank';
            window.setTimeout("document.forms[0].target=originalTarget;", 350);
            return false;
        }
    </script>

    <script type="text/javascript">

        function OnayAlert(ctl, event) {

            //alert(ctl);
            //alert(event);

            var defaultAction = $(ctl).prop("href");

            event.preventDefault();
            swal({
                title: "Filtre silinecek!",
                text: "Seçilen Filtre silinecektir!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#2196F3",
                confirmButtonText: "Tamam",
                cancelButtonText: "Vazgeç",
                closeOnConfirm: false
            }, function () {
                //YÖNLENDİR
                //location.href = "http://google.com"
                //VEYA
                //İŞLEME DEVAM ET
                window.location.href = defaultAction;
                return true;
            });
        }

    </script>

    <script type="text/javascript">

        function OnayAlertStatus(ctl, event) {

            //alert(ctl);
            //alert(event);

            var defaultAction = $(ctl).prop("href");

            event.preventDefault();
            swal({
                title: "Rezervasyon Aç/Kapat!",
                text: "Seçilen Rezervasyon Statüsü Görünür olacak!",
                type: "info",
                showCancelButton: true,
                confirmButtonColor: "#2196F3",
                confirmButtonText: "Tamam",
                cancelButtonText: "Close",
                closeOnConfirm: false
            }, function () {
                //YÖNLENDİR
                //location.href = "http://google.com"
                //VEYA
                //İŞLEME DEVAM ET
                window.location.href = defaultAction;
                return true;
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>

    <!-- Input -->
    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="card">
                <div class="header">
                    <h2>NEW FILTER
                    </h2>
                </div>
                <div class="body">
                    <div class="col-sm-12">

                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Filter Type</span>
                        </div>
                        <div class="col-sm-10">
                            <div class="form-line">
                                <asp:DropDownList ID="dropFilterType" CssClass="form-control show-tick" runat="server" OnSelectedIndexChanged="dropFilterType_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="Day" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Visible Titles" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Date" Value="2"></asp:ListItem>
                                </asp:DropDownList>


                            </div>
                        </div>

                        <asp:Panel ID="panelFilterDay" runat="server">
                            <div class="col-sm-2">
                                <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">CheckIn Day</span>
                            </div>
                            <div class="col-sm-10">
                                <div class="form-line">
                                    <asp:DropDownList ID="dropCheckIn" CssClass="form-control show-tick" runat="server">
                                        <asp:ListItem Text="1 Day" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2 Day" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3 Day" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4 Day" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5 Day" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6 Day" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7 Day" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="2 Week" Value="14"></asp:ListItem>
                                        <asp:ListItem Text="3 Week" Value="21"></asp:ListItem>
                                        <asp:ListItem Text="1 Month" Value="30"></asp:ListItem>
                                        <asp:ListItem Text="3 Month" Value="90"></asp:ListItem>
                                        <asp:ListItem Text="6 Month" Value="180"></asp:ListItem>
                                        <asp:ListItem Text="9 Month" Value="270"></asp:ListItem>
                                        <asp:ListItem Text="1 Year" Value="365"></asp:ListItem>

                                    </asp:DropDownList>


                                </div>
                            </div>
                            <div class="col-sm-2">
                                <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">CheckOut Day</span>
                            </div>
                            <div class="col-sm-10">
                                <div class="form-line">
                                    <asp:DropDownList ID="dropCheckOut" runat="server" CssClass="form-control show-tick">
                                        <asp:ListItem Text="1 Day" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2 Day" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3 Day" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4 Day" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5 Day" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6 Day" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7 Day" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="2 Week" Value="14"></asp:ListItem>
                                        <asp:ListItem Text="3 Week" Value="21"></asp:ListItem>
                                        <asp:ListItem Text="1 Month" Value="30"></asp:ListItem>
                                        <asp:ListItem Text="3 Month" Value="90"></asp:ListItem>
                                        <asp:ListItem Text="6 Month" Value="180"></asp:ListItem>
                                        <asp:ListItem Text="9 Month" Value="270"></asp:ListItem>
                                        <asp:ListItem Text="1 Year" Value="365"></asp:ListItem>


                                    </asp:DropDownList>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="panelFilterDate" Visible="false" runat="server">
                            <div class="col-sm-2">
                                <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">CheckIn Date</span>
                            </div>
                            <div class="col-lg-10" style="margin-bottom: 0;">
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox ID="txtIlkTarih" Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="CheckIn Date"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">CheckOut Date</span>
                            </div>
                            <div class="col-lg-10" style="margin-bottom: 0;">
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox ID="txtSonTarih" Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="CheckOut Date"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="panelFilterTitles" Visible="false" runat="server">

                            <div class="col-sm-2">
                                <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Visible Titles</span>
                            </div>
                            <div class="col-sm-10">
                                <div class="form-line">
                                    <asp:ListBox ID="dropTitles" runat="server" CssClass="form-control show-tick" SelectionMode="Multiple">
                                          <asp:ListItem Text="Voucher Number" Value="Voucher Number"></asp:ListItem>
                                        <asp:ListItem Text="Hotel Name" Value="Hotel Name"></asp:ListItem>
                                        <asp:ListItem Text="Check In" Value="Check In"></asp:ListItem>
                                        <asp:ListItem Text="Check Out" Value="Check Out"></asp:ListItem>
                                        <asp:ListItem Text="Pessenger Name" Value="Pessenger Name"></asp:ListItem>
                                        <asp:ListItem Text="Nationality" Value="Nationality"></asp:ListItem>
                                        <asp:ListItem Text="Status" Value="Status"></asp:ListItem>
                                        <asp:ListItem Text="BookingDate" Value="BookingDate"></asp:ListItem>
                                        <asp:ListItem Text="Agency Name" Value="Agency Name"></asp:ListItem>
                                        <asp:ListItem Text="BookingCode" Value="BookingCode"></asp:ListItem>
                                        <asp:ListItem Text="AgencyGroupName" Value="AgencyGroupName"></asp:ListItem>
                                        <asp:ListItem Text="AgencyRef" Value="AgencyRef"></asp:ListItem>
                                        <asp:ListItem Text="RoomType" Value="RoomType"></asp:ListItem>
                                        <asp:ListItem Text="BoardType" Value="BoardType"></asp:ListItem>
                                        <asp:ListItem Text="AreaName" Value="AreaName"></asp:ListItem>
                                        <asp:ListItem Text="SellingPrice" Value="SellingPrice"></asp:ListItem>
                                        <asp:ListItem Text="SellCurrency" Value="SellCurrency"></asp:ListItem>
                                        <asp:ListItem Text="Cost" Value="Cost"></asp:ListItem>
                                        <asp:ListItem Text="CostCurrency" Value="CostCurrency"></asp:ListItem>
                                        <asp:ListItem Text="NonRefundable" Value="NonRefundable"></asp:ListItem>
                                        <asp:ListItem Text="Remarks" Value="Remarks"></asp:ListItem>
                                        <asp:ListItem Text="Paxes" Value="Paxes"></asp:ListItem>
                                    </asp:ListBox>
                                </div>
                            </div>
                        </asp:Panel>



                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Filter Note</span>
                        </div>
                        <div class="col-lg-10" style="margin-bottom: 0;">
                            <div class="form-group">
                                <div class="form-line">
                                    <asp:TextBox ID="txtFilterNote" CssClass="form-control" runat="server" placeholder="Note"></asp:TextBox>
                                </div>
                            </div>
                        </div>




                    </div>



                </div>
            </div>
        </div>
    </div>
    <!-- #END# Input -->

    <div style="float: right;">
        <a href="javascript:history.back();" class="btn bg-grey waves-effect"><i class="material-icons">keyboard_arrow_left</i>
            <span>GERİ</span></a>
        <asp:LinkButton ID="btnKaydet" runat="server" CssClass="btn bg-blue waves-effect" OnClick="btnKaydet_Click"><i class="material-icons">check</i>
                                    <span>KAYDET</span></asp:LinkButton>
    </div>

    <div class="clearfix"></div>


    <br />
    <br />

    <div class="row clearfix">

        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

            <div class="card">
                <div class="header">
                    <h2>
                        <asp:Literal ID="ltrHotelBannerName" runat="server"> </asp:Literal>
                        FILTER</h2>
                </div>
                <div class="body table-responsive" style="background-color: white;">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>HotelName</th>
                                <th>Filter Type</th>
                                <th>Values</th>

                                <th>Status</th>
                                <th>Filter Open/Close</th>

                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvHotelFilter" runat="server" OnItemDataBound="lvHotelFilter_ItemDataBound">
                                <ItemTemplate>
                                    <tr style="width: 70%;">
                                        <td><strong><%#Eval("HotelName") %></strong></td>
                                        <td><%#Eval("FilterType") %></td>
                                        <td><%#Eval("Filters") %></td>
                                        <td><%#Eval("FilterStatus").ToString()%></td>
                                        <td>
                                            <div class="switch">
                                                <label>OFF<asp:CheckBox ID="cbDurum" runat="server" Checked='true' OnCheckedChanged="cbDurum_CheckedChanged" AutoPostBack="true" /><span class="lever"></span>ON</label>
                                            </div>
                                            <asp:HiddenField ID="hfFilterId" runat="server" Value='<%#Eval("FilterId") %>' />

                                        </td>
                                        <td style="text-align: right;">
                                            <% if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2")
                                                { %>
                                            <%--                                            <a href="UserFilter.aspx?UserId=<%#Eval("UserId") %>" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="85%" data-height="60%" title="FilterClose"><i class="material-icons">mode_edit</i></a>--%>
                                            <%--                                            <asp:LinkButton ID="linkDegistir" runat="server" CssClass="btn bg-grey waves-effect" OnClientClick="OnayAlertStatus(this, event);" CommandName="Filtre Aç/Kapat" CommandArgument='<%#Eval("FilterId") %>'><i class="material-icons">delete</i></asp:LinkButton>--%>

                                            <asp:LinkButton ID="linkSil" runat="server" CssClass="btn bg-grey waves-effect" OnClientClick="OnayAlert(this, event);" OnCommand="linkSil_Command" CommandName="Sil" CommandArgument='<%#Eval("FilterId") %>'><i class="material-icons">delete</i></asp:LinkButton>
                                            <% } %>
                                        </td>
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

    <div class="clearfix"></div>


    <br />
    <br />
    <div class="row clearfix">

        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

            <div class="card">
                <div class="header">
                    <h2>
                        <asp:Literal ID="ltrListHotelName" runat="server"> </asp:Literal>
                        RESERVATION</h2>
                </div>
                <div class="body table-responsive" style="background-color: white;">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <td style="text-align: center;"></td>
                                <th>VOUCHER NUMBER</th>
                                <th>HOTEL NAME</th>
                                <th>CHECK IN</th>
                                <th>CHECK OUT</th>
                                <th>PESSENGER NAME</th>
                                <th>NATIONALITY</th>
                                <th>STATUS</th>
                                <%if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2")
                                    {%>
                                <th>BOOKING DATE</th>
                                <th>AGENCY NAME</th>
                                <th>BOOKING CODE</th>
                                <%--                                <th>HOTEL STATUS</th>--%>

                                <%} %>


                                <th style="width: 13%; color: orangered"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvHotelReservationList" runat="server">
                                <ItemTemplate>
                                    <%# Eval("VisibleStatus").ToString() == "1" && Eval("BookingConfirm").ToString() == "" ? " <tr style=\"width: 70%; background-color:aliceblue;font-weight:bold;\" >" : "<tr style=\"width: 70%;\" > " %>
                                    <td><%#Eval("VisibleStatus").ToString() == "1" && Eval("BookingConfirm").ToString() == "" ? "<center style=\"color:dodgerblue\">NEW</center>" : Eval("BookingConfirm").ToString() == "1" ? "<center style=\"color:greenyellow;font-weight:bold;\">CONFIRMED</center>":Eval("BookingConfirm").ToString() == "-1" ?  "<center style=\"color:orangered;font-weight:bold;\">NOT CONFIRMED</center>":"" %></td>
                                    <td><strong><%#Eval("Voucher Number") %></strong></td>
                                    <td><%#Eval("Hotel Name") %></td>
                                    <td><%#Eval("Check In","{0:dd.MM.yyyy}") %></td>
                                    <td><%#Eval("Check Out","{0:dd.MM.yyyy}") %></td>
                                    <td><%#Eval("Pessenger Name") %></td>
                                    <td><%#Eval("Nationality") %></td>
                                    <td><%#Eval("Status") %></td>
                                    <%if (Session["UserId"].ToString() == "1")
                                        {%>
                                    <td><%#Eval("BookingDate","{0:dd.MM.yyyy}") %></td>
                                    <td><%#Eval("Agency Name") %></td>
                                    <td><strong><%#Eval("BookingCode") %></strong></td>
                                    <%} %>




                                    <td style="text-align: right;">
                                        <asp:LinkButton ID="linkVisible" runat="server" CssClass="btn bg-grey waves-effect" title="Visibility Open" OnClientClick="OnayAlertStatus(this, event);" OnCommand="linkVisible_Command" CommandName="Visible Open" CommandArgument='<%#Eval("BookingCode") %>'><i class="material-icons">visibility</i></asp:LinkButton>
                                        <a href="BookingDetail.aspx?BookingCode=<%#Eval("BookingCode") %>" class="btn bg-grey waves-effect fancybox" title="Booking Detail" data-fancybox-type="iframe" data-width="85%" data-height="85%"><i class="material-icons">open_in_new</i></a>
                                         <%if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2")
                                            {%>
                                                 <%#Eval("Hotel Status").ToString() != "1" ? "<a href=\"BookingReminder.aspx?BookingCode="+Eval("BookingCode")+" \"  title=\"Reminder\" class=\"btn bg-grey waves-effect fancybox\" data-fancybox-type=\"iframe\" data-width=\"85%\" data-height=\"85%\" ><i class=\"material-icons\">send</i></a>": "" %>
                                            <%}%>
                                    </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                    <div style="float: right; margin-top: 40px; margin-bottom: 40px;">
                        <asp:DataPager ID="pagerListe" runat="server" PagedControlID="lvHotelReservationList" PageSize="10">
                            <Fields>
                                <asp:NumericPagerField NumericButtonCssClass="GridPage" CurrentPageLabelCssClass="GridPage"
                                    NextPageText="»" PreviousPageText="«" NextPreviousButtonCssClass="GridPage" ButtonCount="10" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </div>



                <div class="clearfix"></div>
            </div>
        </div>
    </div>

    <script src="plugins/momentjs/moment.js"></script>
    <script src="plugins/momentjs/moment-with-locales.min.js"></script>
    <script src="js/fancybox/jquery.fancybox.js?v=2.1.4" type="text/javascript"></script>
    <script src="js/fancybox/jquery.mousewheel-3.0.6.pack.js" type="text/javascript"></script>
                <link href="js/fancybox/jquery.fancybox.css?v=2.1.4"" rel="stylesheet" type="text/css" />  
    <!-- Bootstrap Material Datetime Picker Plugin Js -->
    <script src="plugins/bootstrap-material-datetimepicker/js/bootstrap-material-datetimepicker.js"></script>
    <script src="plugins/autosize/autosize.js"></script>
    <script src="js/chosen/chosen.jquery.js" type="text/javascript"></script>
    <script src="js/chosen/docsupport/prism.js" type="text/javascript" charset="utf-8"></script>

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

                }
            });

        });
    </script>
    <script type="text/javascript">


        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Sonuç yok!' },
            '.chosen-select-width': { width: "95%" }
        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {

                    for (var selector in config) {
                        $(selector).chosen(config[selector]);
                    }




                }
            });
        };

    </script>
</asp:Content>


