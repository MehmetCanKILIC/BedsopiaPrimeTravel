<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinanceSupplierCardDetail.aspx.cs" Inherits="Bedsopia_Prime_Travel.FinanceSupplierCardDetail" MasterPageFile="~/Prime.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="author" content="Mehmet Can KILIÇ, mehmet-ck@outlook.com" />

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












    <link href="plugins/light-gallery/css/lightgallery.css" rel="stylesheet" />

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




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>

    <form runat="server">


        <div class="panel-card d-flex" id="panel">
            <div class="panel col-12 panel-sortable" id="panel-2">
                <div class="panel-header">
                    <h2>Supplier</h2>
                    <div class="panel-saving mr-2" style="display: none;"><i class="fal fa-spinner-third fa-spin-4x fs-xl"></i></div>
                    <div class="panel-toolbar">
                        <a href="#" class="btn-toolbar js-panel-collapse" id="collapse"></a>
                        <a href="#" class="btn-toolbar js-panel-fullscreen" id="fullscreen"></a>
                        <a href="#" class="btn-toolbar js-panel-close" id="closed"></a>
                    </div>
                    <div class="panel-toolbar panel-dropdown">
                        <a href="#" class="btn btn-toolbar-master waves-effect waves-themed" id="panel-dropdown"><i class="fa fa-ellipsis-v"></i></a>
                        <div class="panel-dropdown-menu ">
                            <a href="#" class="dropdown-item js-panel-refresh" id="panel-refresh-content"><span data-i18n="drpdwn.refreshpanel">Refresh Content</span></a>
                            <a href="#" class="dropdown-item js-panel-refresh"><span data-i18n="drpdwn.refreshpanel">Lock Position</span></a>
                            <a href="#" class="dropdown-item js-panel-refresh"><span data-i18n="drpdwn.refreshpanel">Panel Style</span></a>
                            <a href="#" class="dropdown-item js-panel-refresh"><span data-i18n="drpdwn.refreshpanel">Reset Panel</span></a>
                        </div>
                    </div>

                </div>
                <div class="panel-container ">
                    <div class="loader">
                        <i class="fa-solid fa-spinner"></i>
                    </div>
                    <div class="panel-content">

                        <div class="row">
                            <div style="width: 100%;">

                                <div style="width: 49%; float: left;">

                                    <div class="panel-container">
                                        <div class="loader">
                                            <i class="fa-solid fa-spinner"></i>
                                        </div>
                                        <div class="panel-content">
                                            <div class="body">
                                                <div class="row clearfix">
                                                    <div class="col-sm-12" style="padding: 2%; float: left;">
                                                        <div class="col-lg-10" style="margin-bottom: 0;">
                                                            <asp:Literal ID="ltrSupplierId" runat="server" Text="Supplier Id"></asp:Literal>

                                                            <div class="form-group">
                                                                <div class="form-line">
                                                                    <asp:TextBox ID="txtSupplierId" Enabled="true" Style="font-size: medium;" runat="server" CssClass="form-control show-tick" placeholder="Supplier Id"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-10" style="margin-bottom: 0;">
                                                            <asp:Literal ID="ltrSupplierName" runat="server" Text="Supplier Name"></asp:Literal>

                                                            <div class="form-group">
                                                                <div class="form-line">
                                                                    <asp:TextBox ID="txtSupplierName" Style="font-size: medium;" CssClass="form-control show-tick" runat="server" placeholder="Supplier Name"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-10" style="margin-bottom: 0;">
                                                            <asp:Literal ID="ltrBank" runat="server" Text="Bank"></asp:Literal>

                                                            <div class="form-group">
                                                                <div class="form-line">
                                                                    <asp:TextBox ID="txtBank" Style="font-size: medium;" CssClass="form-control show-tick" runat="server" placeholder="Bank"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-10" style="margin-bottom: 0;">
                                                            <asp:Literal ID="ltrCreditAmount" runat="server" Text="Credit Amount"></asp:Literal>

                                                            <div class="form-group">
                                                                <div class="form-line">
                                                                    <asp:TextBox ID="txtCreditAmount" Style="font-size: medium;" CssClass="form-control show-tick" runat="server" placeholder="Credit Amount"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-10" style="margin-bottom: 0;">
                                                            <asp:Literal ID="ltrDepozit" runat="server" Text="Depozit"></asp:Literal>

                                                            <div class="form-group">
                                                                <div class="form-line">
                                                                    <asp:TextBox ID="txtDepozit" Style="font-size: medium;" CssClass="form-control show-tick" runat="server" placeholder="Depozit"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>

                                                         <div class="col-lg-10" style="margin-bottom: 0;">
                                                            <asp:Literal ID="ltrContractFile" runat="server" Text="ContractFile"></asp:Literal>

                                                            <div class="form-group">
                                                                <div class="form-line">
                                                                        <asp:FileUpload ID="fileContractFile" runat="server"  CssClass="form-control show-tick"/>  
                                                                </div>
                                                            </div>
                                                        </div>


                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div style="width: 49%; float: left;">

                                    <div class="panel-container">
                                        <div class="loader">
                                            <i class="fa-solid fa-spinner"></i>
                                        </div>
                                        <div class="panel-content">
                                            <div class="body">
                                                <div class="row clearfix">
                                                    <div class="col-sm-12" style="padding: 2%; float: left;">
                                                        <div class="col-lg-10" style="margin-bottom: 0;">
                                                            <asp:Literal ID="ltrWorkPeriotType" runat="server" Text="Work Periot Type"></asp:Literal>

                                                            <div class="form-group">
                                                                <div class="form-line">
                                                                    <asp:DropDownList ID="dropWorkPeriotType" AutoPostBack="true" runat="server" ValidationGroup="control"  CssClass="form-control show-tick" ></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-10" style="margin-bottom: 0;">
                                                            <asp:Literal ID="ltrPaymentType" runat="server" Text="Payment Type"></asp:Literal>

                                                            <div class="form-group">
                                                                <div class="form-line">
                                                                    <asp:DropDownList ID="dropPaymentType" AutoPostBack="true" runat="server" ValidationGroup="control"  CssClass="form-control show-tick" ></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-10" style="margin-bottom: 0;">
                                                            <asp:Literal ID="ltrPaymentMethod" runat="server" Text="Payment Method"></asp:Literal>

                                                            <div class="form-group">
                                                                <div class="form-line">
                                                                    <asp:DropDownList ID="dropPaymentMethod" AutoPostBack="true" runat="server" ValidationGroup="control"  CssClass="form-control show-tick" ></asp:DropDownList>

                                                                </div>
                                                            </div>
                                                        </div>

                                                         <div class="col-lg-10" style="margin-bottom: 0;">
                                                            <asp:Literal ID="ltrDueDate" runat="server" Text="DueDate"></asp:Literal>

                                                            <div class="form-group">
                                                                <div class="form-line">
                                                                    <asp:DropDownList ID="dropDueDate" AutoPostBack="true" runat="server" ValidationGroup="control"  CssClass="form-control show-tick" ></asp:DropDownList>

                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="col-lg-10" style="margin-bottom: 0;">
                                                            <asp:Literal ID="ltrEmail" runat="server" Text="Email"></asp:Literal>

                                                            <div class="form-group">
                                                                <div class="form-line">
                                                                    <asp:TextBox ID="txtEmail" Style="font-size: medium;" CssClass="form-control show-tick" runat="server" placeholder="Email"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-10" style="margin-bottom: 0;">
                                                            <asp:Literal ID="ltrNote" runat="server" Text="Note"></asp:Literal>

                                                            <div class="form-group">
                                                                <div class="form-line">
                                                                    <asp:TextBox ID="txtNote" Style="font-size: medium; "  TextMode="MultiLine" CssClass="form-control show-tick" runat="server" placeholder="Note"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div style="float: right; text-align: center;">
            <%-- <a href="javascript:history.back();" class="btn btn-sm btn-secondary  col-8 btn-icon btn-inline-block mr-2" style="float:left; width:54%;" ><i style="float:left;" class="material-icons">keyboard_arrow_left</i>
                <span>Back</span></a>--%>
            <asp:Button ID="backbutton" runat="server" Style="float: left;" OnClientClick="history.back()" class="btn btn-dark" Text=" < Back"></asp:Button>
            <asp:Button ID="btnKaydet" runat="server" Text="Save" ValidationGroup="control" Style="font-size: medium; width: 40%;" class="float-end btn bg-primary-500 btn-pills waves-effect waves-themed" OnClick="btnKaydet_Click" />
        </div>

        <div class="clearfix"></div>
        <br />
        <br />
        <div class="panel-card d-flex" id="panel">
            <div class="panel col-12 panel-sortable" id="panel-2">
                <div class="panel-header">
                    <h2>Periot</h2>
                    <div class="panel-saving mr-2" style="display: none;"><i class="fal fa-spinner-third fa-spin-4x fs-xl"></i></div>
                    <div class="panel-toolbar">
                        <a href="#" class="btn-toolbar js-panel-collapse" id="collapse"></a>
                        <a href="#" class="btn-toolbar js-panel-fullscreen" id="fullscreen"></a>
                        <a href="#" class="btn-toolbar js-panel-close" id="closed"></a>
                    </div>
                    <div class="panel-toolbar panel-dropdown">
                        <a class="btn btn-toolbar-master waves-effect waves-themed" id="panel-dropdown"><i class="fa fa-ellipsis-v"></i></a>
                        <div class="panel-dropdown-menu ">
                            <a href="#" class="dropdown-item js-panel-refresh" id="panel-refresh-content"><span data-i18n="drpdwn.refreshpanel">Refresh Content</span></a>
                            <a href="#" class="dropdown-item js-panel-refresh"><span data-i18n="drpdwn.refreshpanel">Lock Position</span></a>
                            <a href="#" class="dropdown-item js-panel-refresh"><span data-i18n="drpdwn.refreshpanel">Panel Style</span></a>
                            <a href="#" class="dropdown-item js-panel-refresh"><span data-i18n="drpdwn.refreshpanel">Reset Panel</span></a>
                        </div>
                    </div>

                </div>
                <div class="panel-container ">
                    <div class="loader">
                        <i class="fa-solid fa-spinner"></i>
                    </div>
                    <div class="panel-content">
                        <table id="example" class="table table-bordered table-striped w-100 dataTable dtr-inline" style="vertical-align: middle;">
                            <thead class="thead-dark">
                                <tr>
                                    <th>Logicalref</th>
                                    <th>SupplierId</th>
                                    <th>SupplierName</th>
                                    <th>Bank</th>
                                    <th>CreditAmount</th>
                                    <th>Depozit</th>
                                    <th>WorkPeriotType</th>
                                    <th>PaymentType</th>
                                    <th>PaymentMethod</th>
                                    <th>Email</th>
                                    <th style="width: 10%;"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="FinanceSupplierList" runat="server">
                                    <ItemTemplate>
                                        <tr style="width: 70%;">
                                            <td><strong><%#Eval("Logicalref") %></strong></td>
                                            <td><strong><%#Eval("SupplierId") %></strong></td>
                                            <td><%#Eval("SupplierName") %></td>
                                            <td><%#Eval("Bank") %></td>
                                            <td><%#Eval("CreditAmount") %></td>
                                            <td><%#Eval("Depozit") %></td>
                                            <td><%#Eval("WorkPeriotType") %></td>
                                            <td><%#Eval("PaymentType") %></td>
                                            <td><%#Eval("PaymentMethod") %></td>
                                            <td><%#Eval("Email") %></td>
                                            <td style="text-align: right;">
                                                <a href="InvoicePdf.aspx?BookingCode=<%#Eval("SupplierId") %>" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="85%" data-height="85%"><i class="material-icons">picture_as_pdf</i></a>
                                                <a href="InvoiceSendMail.aspx?BookingCode=<%#Eval("SupplierId") %>" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="85%" data-height="85%"><i class="material-icons">send</i></a>

                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>

                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Logicalref</th>
                                    <th>SupplierId</th>
                                    <th>SupplierName</th>
                                    <th>Bank</th>
                                    <th>CreditAmount</th>
                                    <th>Depozit</th>
                                    <th>WorkPeriotType</th>
                                    <th>PaymentType</th>
                                    <th>PaymentMethod</th>
                                    <th>Email</th>
                                    <th style="width: 10%;"></th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>

            </div>
        </div>


    </form>


    <script src="plugins/momentjs/moment.js"></script>
    <script src="plugins/momentjs/moment-with-locales.min.js"></script>


    <script src="assets/js/bundle.js" crossorigin="anonymous"></script>
    <script src="assets/js/jquery.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="assets/js/app.js"></script>
    <script src="assets/js/datatables.js"></script>
    <script src="assets/js/flot.js"></script>
    <script src="plugins/momentjs/moment.js"></script>
    <script src="plugins/momentjs/moment-with-locales.min.js"></script>
    <!-- Bootstrap Material Datetime Picker Plugin Js -->
    <script src="plugins/bootstrap-material-datetimepicker/js/bootstrap-material-datetimepicker.js"></script>
    <!-- Autosize Plugin Js -->
    <script src="js/fancybox/jquery.fancybox.js?v=2.1.4" type="text/javascript"></script>
    <script src="js/fancybox/jquery.mousewheel-3.0.6.pack.js" type="text/javascript"></script>
    <%--            <link href="js/fancybox/jquery.fancybox.css?v=2.1.4"" rel="stylesheet" type="text/css" />--%>

    <script type="text/javascript">
        /**** Datatables *****/
        var table;
        $(document).ready(function () {
            table = $('#example').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'excel', 'pdf', 'csv', 'print'
                ],
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
