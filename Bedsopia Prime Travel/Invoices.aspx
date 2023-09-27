<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="Bedsopia_Prime_Travel.Invoices" MasterPageFile="~/Bedsopia.Master" %>

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
            document.forms[0].target = '_blank';
            window.setTimeout("document.forms[0].target=originalTarget;", 300);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>
    <asp:Panel ID="panelFiltregenel" runat="server" CssClass="card" DefaultButton="btnFiltre">
        <div class="header bg-blue">
            <h2>FILTERS</h2>

        </div>
        <asp:Panel ID="panelFiltre" runat="server">
            <div class="body">
                <div class="row clearfix">
                    <div class="col-lg-5" style="margin-bottom: 0;">
                         <asp:Literal ID="ltrilktar1" runat="server" Text="Begin Date 1"></asp:Literal>
                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtIlkTarih1" Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="Begin Travel Date 1"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                   
                    <div class="col-lg-5" style="margin-bottom: 0;">
                                                 <asp:Literal ID="ltrsontar1" runat="server" Text="End Date 1"></asp:Literal>

                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtSonTarih1" Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="End Travel Date 1"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                     <div class="col-lg-5" style="margin-bottom: 0;">
                                                  <asp:Literal ID="ltrilktar2" runat="server" Text="Begin Date 2"></asp:Literal>

                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtIlkTarih2" Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="Begin Travel Date 2"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5" style="margin-bottom: 0;">
                                                 <asp:Literal ID="ltrsontar2" runat="server" Text="End Date 1"></asp:Literal>

                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtSonTarih2" Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="End Travel Date 2"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                   
                    <div class="col-sm-5" style="margin-bottom: 0;">
                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtBookingCode" runat="server" CssClass="form-control" Font-Size="Medium" placeholder="Booking Code"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5" style="margin-bottom: 0;">
                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtBookingDate" Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="Booking Date"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                     <div class="col-sm-5" style="margin-bottom: 0;">
                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtInvoiceNumber" runat="server" CssClass="form-control" Font-Size="Medium" placeholder="Invoice Number"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-5" style="margin-bottom: 0;">
                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control" Font-Size="Medium" placeholder="Customer Name"></asp:TextBox>
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
                                <asp:TextBox ID="txtSaleCompany" runat="server" CssClass="form-control" Font-Size="Medium" placeholder="SaleCompanyName"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-10" style="margin-bottom: 0; margin-top: 10px; text-align: right;">
                        <asp:LinkButton ID="btnFiltre" runat="server" CssClass="btn bg-blue waves-effect" OnClick="btnFiltre_Click" Style="margin-left: 1px;"><i class="material-icons">search</i></asp:LinkButton>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </asp:Panel>
    <div class="row clearfix">

        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

            <div class="card">
                <div class="header">
                    <h2>INVOICES</h2>
                </div>
                <div class="body table-responsive" style="background-color: white;">
                    <table class="table table-striped">
                        <thead>
                            <tr>
<%--                                <th>Invoice Id</th>--%>
                                <th>BookingCode</th>
                                <th>CheckIn</th>
                                <th>CheckOut</th>
                                <th>BookingDate</th>
                                <th>SellingPrice</th>
                                <th>SellCurrency</th>
                                <th>HotelName</th>
                                <th>Service</th>
                                <th>CostAmount</th>
                                <th>CostCurrency</th>
                                <th>InvoiceNumber</th>
                                <th>AgencyReference</th>
  
                                <th style="width: 13%;"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvInvoicesList" runat="server" OnPagePropertiesChanged="lvInvoicesList_PagePropertiesChanged" OnItemDataBound="lvInvoicesList_ItemDataBound">
                                <ItemTemplate>
                                    <tr style="width: 70%;">
<%--                                        <td><%#Eval("IdInvoice") %></td>--%>
                                        <td><strong><%#Eval("BookingCode") %></strong></td>
                                        <td><%#Eval("CheckIn" ,"{0:dd.MM.yyyy}") %></td>
                                        <td><%#Eval("CheckOut" ,"{0:dd.MM.yyyy}") %></td>
                                        <td><%#Eval("BookingDate" ,"{0:dd.MM.yyyy}") %></td>
                                        <td><%#Eval("SellingPrice") %></td>
                                        <td><%#Eval("SellCurrency") %></td>
                                        <td><%#Eval("HotelName") %></td>
                                        <td><%#Eval("ServiceName") %></td>
                                        <td><%#Eval("Cost") %></td>
                                        <td><%#Eval("CostCurrency") %></td>
                                        <td><strong><%#Eval("InvoiceNumber") %></strong></td>
                                        <td><%#Eval("AgencyRef") %></td>
                                      
                                        <td style="text-align: right;">
                                            <a href="InvoicePdf.aspx?BookingCode=<%#Eval("BookingCode") %>" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="85%" data-height="85%"><i class="material-icons">picture_as_pdf</i></a>
                                            <a href="InvoiceSendMail.aspx?BookingCode=<%#Eval("BookingCode") %>" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="85%" data-height="85%"><i class="material-icons">send</i></a>
                                          <%--  <a href="BookingConfirme.aspx?BookingCode=<%#Eval("BookingCode") %>" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="45%" data-height="45%"><i class="material-icons">check_circle</i></a>
                                            <a href="BookingNotConfirme.aspx?BookingCode=<%#Eval("BookingCode") %>" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="45%" data-height="45%"><i class="material-icons">highlight_off</i></a>
                                          --%>  <%--                                            <a href="BookingDetail.aspx" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="90%" data-height="90%" onclientclick="OnayAlert(this, event);"><i class="material-icons">delete</i></a>--%>
                                            <%if (Session["UserId"].ToString() == "1")
                                                {%>
                                            <%--                                                                                        <%#Eval("Hotel Status").ToString() != "1" ? "<a href=\"OpenSaleAdmin.aspx?SaleId="+Eval("BookingCode")+"\"  title=\"Not Confirme\" class=\"btn bg-grey waves-effect\" ><i class=\"material-icons\">highlight_off</i></a>": "" %>--%>

                                            <%--    <%#Eval("Hotel Status").ToString() != "1" ? "<a href=\"OpenSaleAdmin.aspx?SaleId="+Eval("BookingCode")+"\"  title=\"İşleme Alındı\" class=\"btn bg-grey waves-effect\" ><i class=\"material-icons\">add_alert</i></a>": "" %>--%>
                                           <%-- <%#Eval("Hotel Status").ToString() != "1" ? "<a href=\"BookingReminder.aspx?BookingCode="+Eval("BookingCode")+" \"  title=\"Reminder\" class=\"btn bg-grey waves-effect fancybox\" data-fancybox-type=\"iframe\" data-width=\"85%\" data-height=\"85%\" ><i class=\"material-icons\">send</i></a>": "" %>
                                            <%}
                                                else
                                                {%>--%>

                                            <%} %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>

                <div style="float: right; margin-top: 40px; margin-bottom: 40px;">
                    <asp:DataPager ID="pagerListe" runat="server" PagedControlID="lvInvoicesList" PageSize="20">
                        <Fields>
                            <asp:NumericPagerField NumericButtonCssClass="GridPage" CurrentPageLabelCssClass="GridPage"
                                NextPageText="»" PreviousPageText="«" NextPreviousButtonCssClass="GridPage" ButtonCount="10" />
                        </Fields>
                    </asp:DataPager>
                </div>

                <div class="clearfix"></div>
            </div>
        </div>
    </div>

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

                }
            });

        });
    </script>
</asp:Content>
