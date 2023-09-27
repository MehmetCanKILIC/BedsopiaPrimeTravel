<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinanceCustomerCard.aspx.cs" Inherits="Bedsopia_Prime_Travel.FinanceCustomerCard" MasterPageFile="~/Prime.Master" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>

    <form runat="server">

        <div class="panel-card d-flex" id="panel">
            <div class="panel col-12 panel-sortable" id="panel-2">

                <div class="panel-container ">
                    <div class="loader">
                        <i class="fa-solid fa-spinner"></i>
                    </div>
                    <div class="panel-content">
                        <table id="example" class="table table-bordered table-striped w-100 dataTable dtr-inline" style="vertical-align: middle;">
                            <thead class="thead-dark">
                                <tr>
                                    <th>Logicalref</th>
                                    <th>CustomerId</th>
                                    <th>CustomerName</th>
                                    <th>Bank</th>
                                    <th>CreditAmount</th>
                                    <th>Depozit</th>
                                    <th>WorkPeriotType</th>
                                    <th>PaymentType</th>
                                    <th>PaymentMethod</th>
                                    <th>Email</th>
                                    <th style="width:10%;"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="FinanceCustomerList" runat="server">
                                    <itemtemplate>
                                        <tr style="width: 70%;">
                                            <td><strong><%#Eval("Logicalref") %></strong></td>
                                            <td><strong><%#Eval("CustomerId") %></strong></td>
                                            <td><%#Eval("CustomerName") %></td>
                                            <td><%#Eval("Bank") %></td>
                                            <td><%#Eval("CreditAmount") %></td>
                                            <td><%#Eval("Depozit") %></td>
                                            <td><%#Eval("WorkPeriotType") %></td>
                                            <td><%#Eval("PaymentType") %></td>
                                            <td><%#Eval("PaymentMethod") %></td>
                                            <td><%#Eval("Email") %></td>
                                            <td style="text-align: right;">
                                                <a href="FinanceCustomerCardDetail.aspx?CustomerId=<%#Eval("CustomerId") %>" class="btn bg-grey waves-effect" ><i class="material-icons">details</i></a>
                                                <a href="InvoiceSendMail.aspx?CustomerId=<%#Eval("CustomerId") %>" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="85%" data-height="85%"><i class="material-icons">send</i></a>

                                            </td>
                                        </tr>
                                    </itemtemplate>
                                </asp:ListView>

                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Logicalref</th>
                                    <th>CustomerId</th>
                                    <th>CustomerName</th>
                                    <th>Bank</th>
                                    <th>CreditAmount</th>
                                    <th>Depozit</th>
                                    <th>WorkPeriotType</th>
                                    <th>PaymentType</th>
                                    <th>PaymentMethod</th>
                                    <th>Email</th>
                                    <th style="width:10%;"></th>
                                </tr>
                            </tfoot>
                        </table>
                        
                    </div>
                </div>

            </div>
        </div>


    </form>



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
    </script>
</asp:Content>
