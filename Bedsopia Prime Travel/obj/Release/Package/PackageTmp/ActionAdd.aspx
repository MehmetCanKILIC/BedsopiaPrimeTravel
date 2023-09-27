<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActionAdd.aspx.cs" Inherits="Bedsopia_Prime_Travel.ActionAdd" MasterPageFile="~/Bedsopia.Master" %>

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
    <script type="text/javascript" src="js/dataTables.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {

            $('.date_tr').bootstrapMaterialDatePicker({
                format: 'DD.MM.YYYY',
                lang: 'tr',
                //weekStart: 0,
                time: false,
                cancelText: 'VAZGEÇ'
            });

            $('#example').dataTable({
                "lengthChange": false,
                "searching": false,
                "paging": false
            });



            var t = $('#example').DataTable();
            var counter = 1;

            $('#addRow').on('click', function () {
                t.row.add([
                    counter + '.1',
                    counter + '.2'

                ]).draw();
                counter++;
            });

            // Automatically add a first row of data
            $('#addRow').click();

        });

    </script>
    <script>
        function myFunction() {



            const para = document.createElement("div");
            para.classList = "col-md-12";
            para.innerText = "This is a paragraph";
            document.getElementById("mylist").appendChild(para);
        }
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
                    <h2>ACTION ADD</h2>
                </div>
                <div class="body">

                    <div class="col-sm-2">
                        <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Action Type</span>
                    </div>
                    <div class="col-sm-10">
                        <div class="form-line">
                            <asp:DropDownList ID="dropActionType" AutoPostBack="true" OnSelectedIndexChanged="dropActionType_SelectedIndexChanged" required CssClass="form-control show-tick" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="oke" ControlToValidate="dropActionType" InitialValue="0" ErrorMessage="*" CssClass="bg-red"></asp:RequiredFieldValidator>


                        </div>
                    </div>

                    <div class="col-sm-2">
                        <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Action Begin Date</span>
                    </div>
                    <div class="col-lg-10" style="margin-bottom: 0;">

                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtActionBeginDate" required Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="Action Begin Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="oke" ControlToValidate="txtActionBeginDate" InitialValue="0" ErrorMessage="* NULL" CssClass="bg-red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>


                    <div class="col-sm-2">
                        <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Action End  Date</span>
                    </div>
                    <div class="col-lg-10" style="margin-bottom: 0;">

                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtActionEndDate" required Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="Action End Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="oke" ControlToValidate="txtActionEndDate" InitialValue="0" ErrorMessage="* NULL" CssClass="bg-red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Check In Date</span>
                    </div>
                    <div class="col-lg-10" style="margin-bottom: 0;">

                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtCheckInDate" required Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="Check In Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="oke" ControlToValidate="txtCheckInDate" InitialValue="0" ErrorMessage="* NULL" CssClass="bg-red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>


                    <div class="col-sm-2">
                        <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Check Out Date</span>
                    </div>
                    <div class="col-lg-10" style="margin-bottom: 0;">

                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtCheckOutDate" required Style="font-size: medium;" runat="server" CssClass="datepicker date_tr form-control" placeholder="Check Out Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="oke" ControlToValidate="txtCheckOutDate" InitialValue="0" ErrorMessage="* NULL" CssClass="bg-red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>


                    <asp:Panel ID="panelDiscount" runat="server" Visible="true">
                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Discount</span>
                        </div>
                        <div class="col-lg-10" style="margin-bottom: 0;">
                            <div class="form-group">
                                <div class="form-line">
                                    <asp:TextBox ID="txtDiscountRate" required CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server" placeholder="Discount"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="oke" ControlToValidate="txtDiscountRate" InitialValue="0" ErrorMessage="* NULL" CssClass="bg-red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panelRelease" runat="server" Visible="true">
                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Release</span>
                        </div>
                        <div class="col-lg-10" style="margin-bottom: 0;">
                            <div class="form-group">
                                <div class="form-line">
                                    <asp:TextBox ID="txtRelease" required CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server" placeholder="Release"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="oke" ControlToValidate="txtRelease" InitialValue="0" ErrorMessage="* NULL" CssClass="bg-red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panelAge" runat="server" Visible="false">
                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Age Range</span>
                        </div>
                        <div class="col-lg-10" style="margin-bottom: 0;">
                            <div class="form-group">
                                <div class="form-line">
                                    <asp:TextBox ID="txtAge" required CssClass="form-control" Style="font-size: medium; width: 100%;" runat="server" placeholder="Release"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"   ValidationGroup="oke" ControlToValidate="txtAge" InitialValue="0" ErrorMessage="* NULL" CssClass="bg-red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panelRoom" runat="server" Visible="false">
                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Room Type</span>
                        </div>
                        <div class="col-sm-10">
                            <div class="form-line">
                                <asp:DropDownList ID="dropRoom" required CssClass="form-control show-tick" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ValidationGroup="oke"  ControlToValidate="dropRoom" InitialValue="0" ErrorMessage="* NULL" CssClass="bg-red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panelFreeRoom" runat="server" Visible="false">
                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Upgrage Room Type</span>
                        </div>
                        <div class="col-sm-10">
                            <div class="form-line">
                                <asp:DropDownList ID="dropRoomUprage" required CssClass="form-control show-tick" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"  ValidationGroup="oke"  ControlToValidate="dropRoomUprage" InitialValue="0" ErrorMessage="* NULL" CssClass="bg-red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panelBoard" runat="server" Visible="false">
                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Board Type</span>
                        </div>
                        <div class="col-sm-10">
                            <div class="form-line">
                                <asp:DropDownList ID="dropBoard" required runat="server" CssClass="form-control show-tick"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ValidationGroup="oke"  ControlToValidate="dropBoard" InitialValue="0" ErrorMessage="* NULL" CssClass="bg-red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panelFreeBoard" runat="server" Visible="false">
                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Upgrade Board Type</span>
                        </div>
                        <div class="col-sm-10">
                            <div class="form-line">
                                <asp:DropDownList ID="dropBoardUpgrade" required runat="server" CssClass="form-control show-tick"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"  ValidationGroup="oke"  ControlToValidate="dropBoardUpgrade" InitialValue="0" ErrorMessage="* NULL" CssClass="bg-red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panelAgeRange" runat="server" Visible="false">

                        <div class="col-sm-2">
                            <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Child</span>
                        </div>
                        <div class="col-sm-10">
                            <div class="form-line">
                                <asp:DropDownList ID="dropChild" required runat="server" CssClass="form-control show-tick">
                                    <asp:ListItem Text="No Child" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="1 Child" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2 Child" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3 Child" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4 Child" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5 Child" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="6 Child" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="7 Child" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="8 Child" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="9 Child" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10+ Child" Value="10"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="dropBoard"   ValidationGroup="oke"  InitialValue="0" ErrorMessage="* NULL" CssClass="bg-red"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </asp:Panel>







                    <div class="col-sm-2">
                        <span class="input-group-addon bilgiBaslik" style="border: none; background-color: transparent; padding-left: 0; font-weight: bold;">Promotion Request</span>
                    </div>
                    <div class="col-lg-10" style="margin-bottom: 0;">
                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtPromotionRequest" CssClass="form-control" Rows="5" TextMode="MultiLine" Style="font-size: medium; width: 100%;" runat="server" placeholder="Promotion Request"></asp:TextBox>
                            </div>
                        </div>
                    </div>





                    <div class="col-sm-12">
                        <div class="card">
                            <div class="body bg-blue-grey">
                                Bilgilerin işleme alınması 24 saati bulmaktadır.    /    It takes 24 hours for the information to be processed.
                            </div>
                        </div>
                    </div>

                    <div style="float: right;">
                        <a href="javascript:history.back();" class="btn bg-grey waves-effect"><i class="material-icons">keyboard_arrow_left</i>
                            <span>GERİ</span></a>

                        <asp:Button ID="btnKaydet" CssClass="btn btn-primary waves-effect" Height="37" Width="70" Style="font-size:medium;" runat="server" Text="SAVE" ValidationGroup="oke" OnClick="btnKaydet_Click" />
                    </div>
            </div>
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
                    <h2>ACTIONS</h2>
                </div>
                <div class="body table-responsive" style="background-color: white;">
                    <table class="table table-striped">
                        <thead>
                            <tr >
                                <th>Action Id</th>
                                <th>Action Type</th>
                                <th>Action Date</th>
                                <th>Begin Date</th>
                                <th>End Date</th>
                                <th>Check In</th>
                                <th>Check Out</th>
                                <th>Promotion Request</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvActionList" runat="server">
                                <ItemTemplate>
                                    <tr style="width: 70%;">
                                        <td><strong><%#Eval("ActionId") %></strong></td>
                                        <td><%#Eval("ActionTypeName") %></td>
                                        <td><%#Eval("ActionDate") %></td>
                                        <td><%#Eval("BeginDate") %></td>
                                        <td><%#Eval("EndDate") %></td>
                                        <td><%#Eval("CheckIn") %></td>
                                        <td><%#Eval("CheckOut") %></td>
                                        <td><%#Eval("PromotionRequest") %></td>
                                        <td><%#Eval("Status").ToString() == "1" ? " <i background-color:green; class=\"material-icons\">check_circle</i>" : " <i background-color:yellow; class=\"material-icons\">history</i>" %></td>

                                        <td style="text-align: right;">
                                            <a href="ActionDetail.aspx?ActionId=<%#Eval("ActionId") %>" class="btn bg-grey waves-effect fancybox" title="Action Detail" data-fancybox-type="iframe" data-width="50%" data-height="70%"><i class="material-icons">open_in_new</i></a>
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
</asp:Content>


