<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenSale.aspx.cs" Inherits="Bedsopia_Prime_Travel.OpenSale" MasterPageFile="~/Bedsopia.Master" %>

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




    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>



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

    <!-- Input -->

    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="card">
                <div class="header">
                    <h2>NEW OPEN SALE</h2>


                </div>
                <div class="body">

                    <div class="col-sm-12">

                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Room Type</span>
                        </div>
                        <div class="col-sm-10">
                            <div class="form-line">
                                <asp:ListBox ID="dropRoom"  required  validationGroup="control"  CssClass="form-control show-tick" runat="server" SelectionMode="Multiple"></asp:ListBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5"  ValidationGroup="control" runat="server" ControlToValidate="dropRoom" InitialValue="0" ErrorMessage="*" CssClass="bg-red"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Board Type</span>
                        </div>
                        <div class="col-sm-10">
                            <div class="form-line">
                                <asp:ListBox ID="dropBoard" runat="server" required  validationGroup="control"  CssClass="form-control show-tick" SelectionMode="Multiple"></asp:ListBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  ValidationGroup="control" runat="server" ControlToValidate="dropBoard" InitialValue="0" ErrorMessage="*" CssClass="bg-red"></asp:RequiredFieldValidator>
                            
                            </div>
                        </div>
                          <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Nationality Area</span>
                        </div>
                        <div class="col-sm-10">
                            <div class="form-line">
                                <asp:DropDownList ID="dropNationalityArea" AutoPostBack="true" required runat="server" ValidationGroup="control" OnSelectedIndexChanged="dropNationalityArea_SelectedIndexChanged" CssClass="form-control show-tick" SelectionMode="Multiple"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="control" runat="server" ControlToValidate="dropNationalityArea" InitialValue="0" ErrorMessage="*" CssClass="bg-red"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Nationality</span>
                        </div>
                        <div class="col-sm-10">
                            <div class="form-line">
                                <asp:ListBox ID="dropNationality" required  validationGroup="control"  runat="server" CssClass="form-control show-tick" SelectionMode="Multiple"></asp:ListBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ValidationGroup="control" runat="server" ControlToValidate="dropNationality" InitialValue="0" ErrorMessage="*" CssClass="bg-red"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                      
                         <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Date</span>
                        </div>
                        <div class="col-lg-10" style="margin-bottom: 0;">
                            <asp:ListView ID="listview1" runat="server">
                                <LayoutTemplate>
                                    <table border="0px" class="table table-striped" cellpadding="1">
                                        <tr style="background-color: #E5E5FE">
                                            <th>CheckIn</th>
                                            <th>CheckOut</th>
                                        </tr>
                                        <tr id="itemplaceholder" runat="server"></tr>
                                    </table>
                                </LayoutTemplate>

                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="col-lg-10" style="margin-bottom: 0;">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtCheckIn" Style="font-size: medium;"  ValidationGroup="control" Text='<%#Eval("CheckIn") %>' required runat="server" CssClass="datepicker date_tr form-control" placeholder="CheckIn"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ValidationGroup="control" runat="server" ControlToValidate="txtCheckIn" InitialValue="0" ErrorMessage="*" CssClass="bg-red"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-lg-10" style="margin-bottom: 0;">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtCheckOut" Style="font-size: medium;"  ValidationGroup="control" Text='<%#Eval("CheckOut") %>' required runat="server" CssClass="datepicker date_tr form-control" placeholder="CheckOut"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ValidationGroup="control" runat="server" ControlToValidate="txtCheckOut" InitialValue="0" ErrorMessage="*" CssClass="bg-red"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>
                                            </div>
                                        </td>


                                    </tr>
                                </ItemTemplate>

                                <AlternatingItemTemplate>
                                    <tr style="background-color: #EFEFEF">


                                        <td>
                                            <div class="col-lg-10" style="margin-bottom: 0;">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtCheckIn" Style="font-size: medium;" Text='<%#Eval("CheckIn") %>'  ValidationGroup="control" required runat="server" CssClass="datepicker date_tr form-control" placeholder="CheckIn"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"   ValidationGroup="control" runat="server" ControlToValidate="txtCheckIn" InitialValue="0" ErrorMessage="*" CssClass="bg-red"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-lg-10" style="margin-bottom: 0;">
                                                <div class="form-group">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtCheckOut" Style="font-size: medium;"  ValidationGroup="control" Text='<%#Eval("CheckOut") %>' required runat="server" CssClass="datepicker date_tr form-control" placeholder="CheckOut"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="control" runat="server" ControlToValidate="txtCheckOut" InitialValue="0" ErrorMessage="*" CssClass="bg-red"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>
                                            </div>
                                        </td>


                                    </tr>
                                </AlternatingItemTemplate>

                            </asp:ListView>
                            <asp:Button ID="btnAdd" CssClass="btn bg-blue waves-effect" ValidationGroup="control" runat="server" Text="Add New Date" OnClick="btnAdd_Click" />
                        </div>

                        <div class="clearfix"></div>


                        <br />
                        <br />


                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Sales Note</span>
                        </div>
                        <div class="col-lg-10" style="margin-bottom: 0;">
                            <div class="form-group">
                                <div class="form-line">
                                    <asp:TextBox ID="txtSalesNote" CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server" placeholder="Note"></asp:TextBox>
                                </div>
                            </div>
                        </div>




                    </div>
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="body bg-blue-grey">
                                Bilgilerin işleme alınması 24 saati bulmaktadır.  /    It takes 24 hours for the information to be processed.
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="float: right;">
        <a href="javascript:history.back();" class="btn bg-grey waves-effect"><i class="material-icons">keyboard_arrow_left</i>
            <span>BACK</span></a>
        <asp:Button ID="btnKaydet" runat="server"  Text="SAVE" ValidationGroup="control" Height="37" Width="70" Style="font-size:medium;" CssClass="btn bg-blue waves-effect" OnClick="btnKaydet_Click" />
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
                                <th>SalesDateCount</th>
                                <th>Notification Date</th>
                                <th>Nationality</th>
                                <th>Status</th>

                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvOpenSaleList" runat="server" OnPagePropertiesChanged="lvOpenSaleList_PagePropertiesChanged">
                                <ItemTemplate>
                                    <tr style="width: 70%;">
                                        <td><strong><%#Eval("HotelName") %></strong></td>
                                        <td><%#Eval("BeginDate") %></td>
                                        <td><%#Eval("EndDate") %></td>
                                        <td><%#Eval("SalesDateCount") %></td>
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
    <!-- #END# Input -->


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

    <%--    <script type="text/javascript">
        $(function () {
            $('[id*=lstStudents]').multiselect
                ({
                    includeSelectAllOption: true,
                    nonSelectedText: 'Select Students' // Here you can change with your desired text as per your requirement.
                });
        });
    </script>--%>
</asp:Content>

