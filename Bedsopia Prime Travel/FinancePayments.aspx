<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinancePayments.aspx.cs" Inherits="Bedsopia_Prime_Travel.FinancePayments" MasterPageFile="~/Prime.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="author" content="Mehmet Can KILIÇ, mehmet-ck@outlook.com" />

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Admin Panel</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css" />
    <link rel="stylesheet" href="dist/css/skins/skin-blue.min.css" />
    <link rel="stylesheet" href="dist/css/skins/skin-blue.min.css" />
    <!-- Google Font -->
    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" />


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
  
        <div class="row clearfix">
                <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>

        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

            <div class="card">
                <div class="header">
                    <h2>INVOICES</h2>
                </div>
                <div id="example" style="width:100%" class="body table-responsive" style="background-color: white;">
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
    <%--            <link href="js/fancybox/jquery.fancybox.css?v=2.1.4"" rel="stylesheet" type="text/css" />--%>

    <script type="text/javascript">




        function format(d) {
            // `d` is the original data object for the row
            return (
                '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
                '<tr>' +
                '<td>Full name:</td>' +
                '<td>' +
                d.name +
                '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>Extension number:</td>' +
                '<td>' +
                d.extn +
                '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>Extra info:</td>' +
                '<td>And any further details here (images etc)...</td>' +
                '</tr>' +
                '</table>'
            );
        }

        $(document).ready(function () {
            var table = $('#example').DataTable({
                ajax: '../ajax/data/objects.txt',
                columns: [
                    {
                        className: 'dt-control',
                        orderable: false,
                        data: null,
                        defaultContent: '',
                    },
                    { data: 'name' },
                    { data: 'position' },
                    { data: 'office' },
                    { data: 'salary' },
                ],
                order: [[1, 'asc']],
            });

            // Add event listener for opening and closing details
            $('#example tbody').on('click', 'td.dt-control', function () {
                var tr = $(this).closest('tr');
                var row = table.row(tr);

                if (row.child.isShown()) {
                    // This row is already open - close it
                    row.child.hide();
                    tr.removeClass('shown');
                } else {
                    // Open this row
                    row.child(format(row.data())).show();
                    tr.addClass('shown');
                }
            });
        });




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
