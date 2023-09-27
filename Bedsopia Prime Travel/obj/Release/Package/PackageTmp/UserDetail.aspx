<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="Bedsopia_Prime_Travel.UserDetail" %>
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
</head>
<body style="background-color: #f5f5f5;">
    <form id="form1" runat="server">
         <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>

    <!-- Input -->
    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="card">
                <div class="header">
                    <h2>STOP SALE</h2>
                </div>
                <div class="body">
                    <div class="col-sm-12">

                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Room Type</span>
                        </div>
                        <div class="col-sm-10">
                            <div class="form-line">
                                <asp:ListBox ID="dropRoom" CssClass="form-control show-tick" runat="server" SelectionMode="Multiple"></asp:ListBox>


                            </div>
                        </div>
                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Board Type</span>
                        </div>
                        <div class="col-sm-10">
                            <div class="form-line">
                                <asp:ListBox ID="dropBoard" runat="server" CssClass="form-control show-tick" SelectionMode="Multiple"></asp:ListBox>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Nationality</span>
                        </div>
                        <div class="col-sm-10">
                            <div class="form-line">
                                <asp:ListBox ID="dropNationality" runat="server" CssClass="form-control show-tick" SelectionMode="Multiple"></asp:ListBox>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Başlangıç Tarihi</span>
                        </div>
                        <div class="col-lg-10" style="margin-bottom: 0;">
                            <div class="form-group">
                                <div class="form-line">
                                    <asp:TextBox ID="txtIlkTarih" Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="Başlangıç Tarihi"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Bitiş Tarihi</span>
                        </div>
                        <div class="col-lg-10" style="margin-bottom: 0;">
                            <div class="form-group">
                                <div class="form-line">
                                    <asp:TextBox ID="txtSonTarih" Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="Bitiş Tarihi"></asp:TextBox>

                                </div>
                            </div>
                        </div>



                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Sales Note</span>
                        </div>
                        <div class="col-lg-10" style="margin-bottom: 0;">
                            <div class="form-group">
                                <div class="form-line">
                                    <asp:TextBox ID="txtSalesNote" TextMode="MultiLine" Style="font-size: medium; width: 100%;" runat="server" placeholder="Note"></asp:TextBox>
                                </div>
                            </div>
                        </div>




                    </div>


                    <div class="col-sm-12">
                        <div class="card">
                            <div class="body bg-blue-grey">
                                Bilgilerin işleme alınması 24 saati bulmaktadır.
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
                    <h2>OPEN SALE</h2>
                </div>
                <div class="body table-responsive" style="background-color: white;">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>HotelName</th>
                                <th>BeginDate</th>
                                <th>EndDate</th>
                                <th>Notification Date</th>
                                <th>Nationality</th>
                                <th>Status</th>

                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvOpenSaleList" runat="server" >
                                <ItemTemplate>
                                    <tr style="width: 70%;">
                                        <td><strong><%#Eval("HotelName") %></strong></td>
                                        <td><%#Eval("BeginDate") %></td>
                                        <td><%#Eval("EndDate") %></td>
                                        <td><%#Eval("Date") %></td>
                                        <td><%#Eval("NationalityId") %></td>
                                        <td><%#Eval("Status").ToString() == "1" ? " <i background-color:green; class=\"material-icons\">check_circle</i>" : " <i background-color:yellow; class=\"material-icons\">history</i>" %></td>

                                        <td style="text-align: right;">
                                            <a href="SaleDetail.aspx?SaleId=<%#Eval("SaleId") %>" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="65%" data-height="53%"><i class="material-icons">open_in_new</i></a>
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

    </form>
</body>
</html>
