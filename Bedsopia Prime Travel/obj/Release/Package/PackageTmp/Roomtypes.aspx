<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Roomtypes.aspx.cs" Inherits="Bedsopia_Prime_Travel.Roomtypes"  MasterPageFile="~/Bedsopia.Master" %>

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
     <asp:Panel ID="panelFiltregenel" runat="server" CssClass="card" DefaultButton="btnFiltre">
            <div class="header bg-blue">
                <h2>FILTERS</h2>

            </div>
            <asp:Panel ID="panelFiltre" runat="server">
                <div class="body">
                    <div class="row clearfix">
                        <div class="col-lg-12" style="margin-bottom: 0;">
                            <div class="form-group">
                                <div class="form-line">
                                    <asp:TextBox ID="txtRoomTypeFilter" Style="font-size: medium;" runat="server" CssClass="form-control" placeholder="Hotel Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    <%--    <div class="col-lg-5" style="margin-bottom: 0;">
                            <div class="form-group">
                                <div class="form-line">
                                    <asp:TextBox ID="txtRoomCodeFilter" Style="font-size: medium;" runat="server" CssClass="form-control" placeholder="Room Code"></asp:TextBox>

                                </div>
                            </div>
                        </div>--%>

                        <div class="col-lg-12" style="margin-bottom: 0; margin-top: 10px; text-align: right;">
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
                    <h2>ROOM TYPES</h2>
                </div>
                <div class="body table-responsive" style="background-color: white;">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                             <%--   <th>Room Id</th>
                                <th>Room Type</th>
                                <th>Room Code</th>--%>
                                <th>Hotel Name</th>
                              

                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvRoomTypes" runat="server" OnPagePropertiesChanged="lvRoomTypes_PagePropertiesChanged">
                                <ItemTemplate>
                                    <tr style="width: 70%;">
<%--                                        <td><strong><%#Eval("RoomId") %></strong></td>--%>
                            <%--            <td><%#Eval("RoomType") %></td>
                                        <td><%#Eval("RoomCode") %></td>--%>
                                        <td><%#Eval("HotelName") %></td>
                                        <td style="text-align: right;">
                                                <a href="RoomTypeAdd.aspx?HotelName=<%#Eval("HotelName") %>" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe"  data-width="85%" data-height="85%"><i class="material-icons">view_list</i></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>

                   <div style="float: right; margin-top: 40px; margin-bottom: 40px;">
                    <asp:DataPager ID="pagerListe" runat="server" PagedControlID="lvRoomTypes" PageSize="20">
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

