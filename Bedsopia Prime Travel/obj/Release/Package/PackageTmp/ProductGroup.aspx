<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductGroup.aspx.cs" Inherits="Bedsopia_Prime_Travel.ProductGroup" MasterPageFile="~/Bedsopia.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <meta name="author" content="Mehmet Can KILIÇ, mehmet-ck@outlook.com" />
    <script src="js/owl.carousel.js"></script>
    <link href="css/animate.min.css" rel="stylesheet" />
    <link href="css/owl.carousel.min.css" rel="stylesheet" />
    <link href="css/owl.theme.default.min.css" rel="stylesheet" />
    <link href="carousel/css/owl.carousel.min.css" rel="stylesheet">
    <link href="carousel/css/owl.theme.default.min.css" rel="stylesheet">
    <script src="carousel/js/jquery.min.js"></script>
    <script src="carousel/js/owl.carousel.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css" />

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
    <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>

    <div class="row clearfix">

        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="card">
                <div class="header">
                    <h2>
                        <asp:Literal ID="Literal1" Text="ADD PRODUCT GROUP" runat="server"></asp:Literal></h2>
                </div>
                <div class="body">

                    <div class="col-lg-10" style="margin-bottom: 0;">
                        <div class="form-group">
                            <div class="form-line">
                                <asp:TextBox ID="txtProductGroupName" required Style="font-size: medium;" runat="server" CssClass="form-control" placeholder="Product Group Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="room" ControlToValidate="txtProductGroupName" InitialValue="0" ErrorMessage="*" CssClass="bg-red"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>
                  

                    <div class="col-lg-2" style="margin-bottom: 0; margin-top: 10px; text-align: left;">
                        <asp:Button ID="btnProductAdd" runat="server" CssClass="btn bg-blue waves-effect" Text="SAVE" ValidationGroup="room" OnClick="btnProductAdd_Click" Style="font-weight: bold; margin-left: 1px;"></asp:Button>
                    </div>

                </div>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="card">
                <div class="header">
                    <h2>
                        <asp:Literal ID="ltrBaslikListe" Text="PRODUCT GROUP" runat="server"></asp:Literal></h2>
                </div>
                <div class="body">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Product Group Id</th>
                                <th>Product Group Name</th>
                                <th>Insert Date</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="lvProductGroupNameList" runat="server" ItemPlaceholderID="itemHolder"  OnItemEditing="lvProductGroupNameList_ItemEditing">
                                <ItemTemplate>
                                    <tr style="width: 70%;">
                                        <td><strong><%#Eval("Logicalref") %></strong></td>
                                        <td><%#Eval("ProductGroupName") %></td>
                                        <td><%#Eval("InsertDate") %></td>
                                        <td style="text-align: right;">
                                            <asp:LinkButton ID="btnProductDelete" runat="server" CssClass="btn bg-grey waves-effect" CommandName="Delete" CommandArgument='<%#Eval("Logicalref") %>' OnCommand="btnProductDelete_Command" Style="margin-left: 1px; font-weight: bold;"><i class="material-icons">delete</i></asp:LinkButton>
                                            <%--                                                <a href="RoomTypeAdd.aspx?RoomId=<%#Eval("RoomId") %>" class="btn bg-grey waves-effect fancybox" data-fancybox-type="iframe" data-width="85%" data-height="85%"><i class="material-icons">delete</i></a>--%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>

                        </tbody>
                    </table>

                </div>
            </div>
        </div>
    </div>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/owl.carousel.min.js"></script>
    <script src="js/fancybox/jquery.fancybox.js?v=2.1.4" type="text/javascript"></script>
    <script src="js/fancybox/jquery.mousewheel-3.0.6.pack.js" type="text/javascript"></script>
</asp:Content>
