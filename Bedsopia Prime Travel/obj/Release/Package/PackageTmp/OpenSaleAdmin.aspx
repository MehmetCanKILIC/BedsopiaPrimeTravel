<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenSaleAdmin.aspx.cs" Inherits="Bedsopia_Prime_Travel.OpenSaleAdmin" MasterPageFile="~/Bedsopia.Master" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>
    <div class="row clearfix">

        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

            <div class="card">
                <div class="header">
                    <h2>OPEN SALES</h2>
                </div>
                <div class="body table-responsive" style="background-color: white;">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th></th>
                                <th>HotelName</th>
                                <th>BeginDate</th>
                                <th>EndDate</th>
                                 <th>SalesDateCount</th>

                                <th>Notification Date</th>
                                <th>Nationality</th>
                                <th>Status</th>

                                <th  style="text-align:center;">Reservation</th>

                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvOpenSaleList" runat="server" OnPagePropertiesChanged="lvOpenSaleList_PagePropertiesChanged" OnItemDataBound="lvOpenSaleList_ItemDataBound">
                                <ItemTemplate>
                                    <tr style="width: 70%;">
                                        <td><asp:Literal ID="ltrUyari" runat="server"></asp:Literal></td>
                                        <td><strong><%#Eval("HotelName") %></strong></td>
                                        <td><%#Eval("BeginDate","{0:dd.MM.yyyy}") %></td>
                                        <td><%#Eval("EndDate","{0:dd.MM.yyyy}") %></td>
                                                                                <td><%#Eval("SalesDateCount") %></td>

                                        <td><%#Eval("Date","{0:dd.MM.yyyy}") %></td>
                                        <td><%#Eval("NationalityId") %></td>
                                        <td><%#Eval("Status").ToString() == "1" ? " <i background-color:green; class=\"material-icons\">check_circle</i>" : " <i background-color:yellow; class=\"material-icons\">history</i>" %></td>
                                                                                <td style="text-align:center;"><asp:Literal ID="ltrSaleCount" runat="server"></asp:Literal></td>

                                        <td style="text-align: right;">
                                             <%#Eval("Status").ToString() != "1" ? "<a href=\"OpenSaleAdmin.aspx?SaleId="+Eval("SaleId")+"\" class=\"btn bg-grey waves-effect\" ><i class=\"material-icons\">check_circle</i></a>": "" %>

                                            <a href="SaleDetail.aspx?SaleId=<%#Eval("SaleId") %>" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="65%" data-height="73%"><i class="material-icons">open_in_new</i></a>
                                            
                                               
                                            
                                            
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


    <script src="plugins/momentjs/moment.js"></script>
    <script src="plugins/momentjs/moment-with-locales.min.js"></script>

    <!-- Bootstrap Material Datetime Picker Plugin Js -->
    <script src="plugins/bootstrap-material-datetimepicker/js/bootstrap-material-datetimepicker.js"></script>
    <script src="plugins/autosize/autosize.js"></script>
    <script src="js/chosen/chosen.jquery.js" type="text/javascript"></script>
    <script src="js/chosen/docsupport/prism.js" type="text/javascript" charset="utf-8"></script>



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
