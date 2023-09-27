<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Bedsopia_Prime_Travel.Users" MasterPageFile="~/Prime.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <meta name="author" content="Mehmet Can KILIÇ, mehmet-ck@outlook.com" />
    <script src="js/owl.carousel.js"></script>
    <link href="css/animate.min.css" rel="stylesheet" />
    <link href="css/owl.carousel.min.css" rel="stylesheet" />
    <link href="css/owl.theme.default.min.css" rel="stylesheet" />
    <link href="carousel/css/owl.carousel.min.css" rel="stylesheet" />
    <link href="carousel/css/owl.theme.default.min.css" rel="stylesheet" />
    <script src="carousel/js/jquery.min.js"></script>
    <script src="carousel/js/owl.carousel.min.js"></script>


    <script type="text/javascript">

        function OnayAlert(ctl, event) {

            //alert(ctl);
            //alert(event);

            var defaultAction = $(ctl).prop("href");

            event.preventDefault();
            swal({
                title: "Kullanıcı silinecek!",
                text: "Seçilen Kullanıcı silinecektir!",
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>
        <div class="panel-card d-flex" id="panel">
            <div class="panel col-12 panel-sortable" id="panel-2">
                <div class="panel-header">
                    <h2>Filters</h2>
                    <div class="panel-saving mr-2" style="display: none;"><i class="fal fa-spinner-third fa-spin-4x fs-xl"></i></div>
                    <div class="panel-toolbar">
                        <a href="#" class="btn-toolbar js-panel-collapse" id="collapse"></a>
                        <a href="#" class="btn-toolbar js-panel-fullscreen" id="fullscreen"></a>
                        <a href="#" class="btn-toolbar js-panel-close" id="closed"></a>
                    </div>
                    <div class="panel-toolbar panel-dropdown" style="padding-right:5px;">
                       
                    </div>
                </div>
                <div class="panel-container ">
                    <div class="loader">
                        <i class="fa-solid fa-spinner"></i>
                    </div>
                    <div class="panel-content">
                        <div class="row clearfix">
                            <div class="col-lg-6" style="margin-bottom: 0;">
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox ID="txtHotelname" Style="font-size: medium;" runat="server" CssClass="form-control" placeholder="Hotel Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-5" style="margin-bottom: 0;">
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:TextBox ID="txtEmail" Style="font-size: medium;" runat="server" CssClass="form-control" placeholder="E-Mail"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-1" style="margin-bottom: 0; margin-top: 10px; text-align: right;">
                                <asp:LinkButton ID="btnFiltre" runat="server" CssClass="btn bg-blue waves-effect" OnClick="btnFiltre_Click" Style="margin-left: 1px;"><i class="material-icons">search</i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <br />
        <div class="panel-card d-flex" id="panel">
            <div class="panel col-12 panel-sortable" id="panel-2">
                <div class="panel-header">
                    <h2>Users</h2>
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
                            <a href="UserAdd.aspx" class="dropdown-item js-panel-refresh fancybox" data-fancybox-type="iframe" data-width="85%" data-height="85%">New User</a>
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
                                    <th>User Id</th>
                                    <th>User Name</th>
                                    <th>Hotel Name</th>
                                    <th>Email</th>
                                    <th style="width: 15%;"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="lvUserList" runat="server" OnPagePropertiesChanged="lvUserList_PagePropertiesChanged">
                                    <ItemTemplate>
                                        <tr style="width: 70%;">
                                            <td><%#Eval("UserId") %></td>
                                            <td><strong><%#Eval("Username") %></strong></td>
                                            <td><strong><%#Eval("HotelName") %></strong></td>
                                            <td><strong><%#Eval("Email") %></strong></td>
                                            <td style="text-align: right;">
                                                <% if (Session["UserType"].ToString() == "1" || Session["UserType"].ToString() == "2")
                                                    { %>
                                                <a href="UserFilter.aspx?UserId=<%#Eval("UserId") %>" class="btn bg-grey waves-effect" data-fancybox-type="iframe" data-width="85%" data-height="85%"><i class="material-icons">filter_hdr</i></a>
                                                <a href="UserEdit.aspx?UserId=<%#Eval("UserId") %>" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="85%" data-height="60%"><i class="material-icons">mode_edit</i></a>
                                                <asp:LinkButton ID="linkSil" runat="server" CssClass="btn bg-grey waves-effect" OnClientClick="OnayAlert(this, event);" OnCommand="linkSil_Command" CommandName="Sil" CommandArgument='<%#Eval("UserId") %>'><i class="material-icons">delete</i></asp:LinkButton>
                                                <% } %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>User Id</th>
                                    <th>User Name</th>
                                    <th>Hotel Name</th>
                                    <th>Email</th>
                                    <th style="width: 15%;"></th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <div class="clearfix"></div>




    <script src="assets/js/bundle.js" crossorigin="anonymous"></script>
    <script src="assets/js/jquery.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="assets/js/app.js"></script>
    <script src="assets/js/datatables.js"></script>
    <script src="assets/js/flot.js"></script>
    <script src="plugins/momentjs/moment.js"></script>
    <script src="plugins/momentjs/moment-with-locales.min.js"></script>
    <script src="plugins/bootstrap-material-datetimepicker/js/bootstrap-material-datetimepicker.js"></script>
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
                    location.href = "Users.aspx";
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
