<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingForm.aspx.cs" Inherits="Bedsopia_Prime_Travel.Information.MeetingForm" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <meta name="author" content="Mehmet Can KILIÇ, mehmet-ck@outlook.com" />
    <title>
        <asp:Literal ID="ltrTitle" runat="server"></asp:Literal></title>
    <!-- Favicon-->
    <link rel="icon" href="images/favicon.ico" type="image/x-icon" />

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css" />

    <!-- Bootstrap Core Css -->
    <link href="plugins/bootstrap/css/bootstrap.css" rel="stylesheet" />

    <!-- Waves Effect Css -->
    <link href="plugins/node-waves/waves.css" rel="stylesheet" />

    <!-- Animation Css -->
    <link href="plugins/animate-css/animate.css" rel="stylesheet" />

    <!-- Custom Css -->

    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            background-image: url('../images/petlaszemzem.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-attachment: fixed;
            background-size: cover;
        }


        .girisBolumUst {
            width: 90%;
            margin: auto;
            padding-top: 30px;
            padding-bottom: 90px;
        }

        .girisBolumSag {
            width: 40%;
             margin: auto;
            padding-top: 30px;
            padding-bottom: 90px;
        }

        .mesajHata {
            font-size: 14px;
            display: block;
            margin-bottom: 20px;
            font-weight: normal;
            color: #F44336;
        }

        .girisBolumSag2 {
            width: 40%;
            float: right;
        }



        @media (max-width:768px) {

            .girisBolumUst {
                padding-bottom: 20px;
                text-align: center;
            }


            .girisBolumUstMeeting {
                padding-bottom: 20px;
                text-align: center;
            }


            .girisBolumSag {
                width: 100%;
                display: block;
                float: none;
            }
        }
    </style>







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

    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-121418428-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-121418428-1');
    </script>

</head>
<body style="background-color: #E2EEF7">
    <form id="form1" runat="server">



        <div style="width: 90%; margin: auto; margin-bottom: 300px; padding-bottom: 50px;">





            <div class="girisBolumSag">
                <div style="text-align: center;">
                    <img src="Images/logo.svg" style="margin-bottom: 50px; width: 300px;" />

                </div>
                <div style="background-color: white;">

                    <div style="width: 100%; background-color: white;">
                        <div style="margin-bottom: 10px; width: 100%; height: 100%; text-align: center; position: center;">
                            <img src="Images/MeetingPhoto.jpeg" style="margin-top: 30px; width: 90%; height: 90%; text-align: center; position: center;" />
                            <div class="clearfix"></div>

                        </div>

                        <div style="width: 100%; padding: 38px; background-image: url('../images/form_bg.png');">

                            <asp:Label ID="lblIslemSonuc" runat="server" CssClass="mesajHata" Visible="false"></asp:Label>

                            <div class="msg" style="font-size: 24px; text-align: center; color: #777;">
                                <asp:Literal ID="ltrGiris" runat="server"></asp:Literal>
                            </div>
                            <br />

                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="material-icons">person</i>
                                </span>
                                <div class="form-line">
                                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" placeholder="Company Name*" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="material-icons">person</i>
                                </span>
                                <div class="form-line">
                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="material-icons">mail</i>
                                </span>
                                <div class="form-line">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email*" required></asp:TextBox>
                                </div>
                            </div>

                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="material-icons">list</i>
                                </span>
                                <div class="form-line">
                                    <div class="col-xs-7">
                                        <asp:TextBox ID="txtPreferredDate" TextMode="Date" CssClass="datepicker date_tr form-control" runat="server" placeholder="Preferred Date"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:TextBox ID="txtPreferredTime" runat="server" CssClass="form-control" placeholder="Time"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="material-icons">phone</i>
                                </span>
                                <div class="form-line">
                                    <asp:TextBox ID="txtPhone" runat="server" placeholder="(xxx) xxx-xxxx"
                                        onkeydown="javascript:backspacerDOWN(this,event);"
                                        onkeyup="javascript:backspacerUP(this,event);" CssClass="form-control" onblur="markSpace(this);" required></asp:TextBox>

                                </div>
                            </div>
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="material-icons">message</i>
                                </span>
                                <div class="form-line">
                                    <asp:TextBox ID="txtMessages" runat="server" Rows="3" TextMode="MultiLine" CssClass="form-control" placeholder="...Enter you message here:*" required></asp:TextBox>
                                </div>
                            </div>
                            Already a Prime Travel customer?
                    <br />
                            <br />
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <%--                            <i class="material-icons">lock</i>--%>
                                </span>
                                <div class="form-line">
                                    <asp:RadioButtonList ID="radiobutton" runat="server" OnSelectedIndexChanged="radiobutton_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-7">
                                    <%--                            <asp:CheckBox ID="cbHatirla" runat="server" Text="Beni Hatırla" />--%>
                                </div>
                                <div class="col-xs-12" style="text-align: right; float: right;">
                                    <asp:Button ID="btnGiris" runat="server" CssClass="btn btn-primary waves-effect" data-loading-text="loading..." Style="width: 100%;" OnClick="btnGiris_Click" Text="REQUEST A MEETING" />
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <div class="clearfix"></div>

                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="clearfix"></div>

            </div>
            <div class="clearfix"></div>

        </div>
    </form>


    <script src="TEST/js/popper.js"></script>
    <script src="TEST/js/bootstrap.min.js"></script>
    <script src="TEST/js/main.js"></script>


    <!-- Jquery Core Js -->
    <script src="plugins/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core Js -->
    <script src="plugins/bootstrap/js/bootstrap.js"></script>

    <!-- Waves Effect Plugin Js -->
    <script src="plugins/node-waves/waves.js"></script>

    <!-- Validation Plugin Js -->
    <script src="plugins/jquery-validation/jquery.validate.js"></script>

    <!-- Custom Js -->
    <script src="js/admin.js"></script>
    <script src="js/pages/examples/sign-in.js"></script>
    <script src="plugins/bootstrap-material-datetimepicker/js/bootstrap-material-datetimepicker.js"></script>
    <script src="plugins/autosize/autosize.js"></script>
    <script src="js/chosen/chosen.jquery.js" type="text/javascript"></script>
    <script src="js/chosen/docsupport/prism.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">

        $("form").submit(function (e) {
            var $btn = $(this).find('.btn');
            $btn.button('loading');
        });

    </script>


    <script type="text/javascript">

        function markSpace(field) {
            if (field.value.includes(")")) {
                field.value = field.value.split(')').join(') ');
            }
            if (field.value.includes(") ")) {
                field.value = field.value.replace(/  +/g, ' ');

            }
        }


        //Phone validation
        var zChar = new Array(' ', '(', ')', '-', '.');
        var maxphonelength = 13;
        var phonevalue1;
        var phonevalue2;
        var cursorposition;

        function ParseForNumber1(object) {
            phonevalue1 = ParseChar(object.value, zChar);
        }
        function ParseForNumber2(object) {
            phonevalue2 = ParseChar(object.value, zChar);
        }

        function backspacerUP(object, e) {
            if (e) {
                e = e
            } else {
                e = window.event
            }
            if (e.which) {
                var keycode = e.which
            } else {
                var keycode = e.keyCode
            }

            ParseForNumber1(object)

            if (keycode >= 48) {
                ValidatePhone(object)
            }
        }

        function backspacerDOWN(object, e) {
            if (e) {
                e = e
            } else {
                e = window.event
            }
            if (e.which) {
                var keycode = e.which
            } else {
                var keycode = e.keyCode
            }
            ParseForNumber2(object)
        }

        function GetCursorPosition() {

            var t1 = phonevalue1;
            var t2 = phonevalue2;
            var bool = false
            for (i = 0; i < t1.length; i++) {
                if (t1.substring(i, 1) != t2.substring(i, 1)) {
                    if (!bool) {
                        cursorposition = i
                        bool = true
                    }
                }
            }
        }

        function ValidatePhone(object) {

            var p = phonevalue1

            p = p.replace(/[^\d]*/gi, "")

            if (p.length < 3) {
                object.value = p
            } else if (p.length == 3) {
                pp = p;
                d4 = p.indexOf('(')
                d5 = p.indexOf(')')
                if (d4 == -1) {
                    pp = "(" + pp;
                }
                if (d5 == -1) {
                    pp = pp + ")";
                }
                object.value = pp;
            } else if (p.length > 3 && p.length < 7) {
                p = "(" + p;
                l30 = p.length;
                p30 = p.substring(0, 4);
                p30 = p30 + ")"

                p31 = p.substring(4, l30);
                pp = p30 + p31;

                object.value = pp;

            } else if (p.length >= 7) {
                p = "(" + p;
                l30 = p.length;
                p30 = p.substring(0, 4);
                p30 = p30 + ")"

                p31 = p.substring(4, l30);
                pp = p30 + p31;

                l40 = pp.length;
                p40 = pp.substring(0, 8);
                p40 = p40 + "-"

                p41 = pp.substring(8, l40);
                ppp = p40 + p41;

                object.value = ppp.substring(0, maxphonelength);
            }

            GetCursorPosition()

            if (cursorposition >= 0) {
                if (cursorposition == 0) {
                    cursorposition = 2
                } else if (cursorposition <= 2) {
                    cursorposition = cursorposition + 1
                } else if (cursorposition <= 5) {
                    cursorposition = cursorposition + 2
                } else if (cursorposition == 6) {
                    cursorposition = cursorposition + 2
                } else if (cursorposition == 7) {
                    cursorposition = cursorposition + 4
                    e1 = object.value.indexOf(')')
                    e2 = object.value.indexOf('-')
                    if (e1 > -1 && e2 > -1) {
                        if (e2 - e1 == 4) {
                            cursorposition = cursorposition - 1
                        }
                    }
                } else if (cursorposition < 11) {
                    cursorposition = cursorposition + 3
                } else if (cursorposition == 11) {
                    cursorposition = cursorposition + 1
                } else if (cursorposition >= 12) {
                    cursorposition = cursorposition
                }

                var txtRange = object.createTextRange();
                txtRange.moveStart("character", cursorposition);
                txtRange.moveEnd("character", cursorposition - object.value.length);
                txtRange.select();
            }

        }

        function ParseChar(sStr, sChar) {
            if (sChar.length == null) {
                zChar = new Array(sChar);
            }
            else zChar = sChar;

            for (i = 0; i < zChar.length; i++) {
                sNewStr = "";

                var iStart = 0;
                var iEnd = sStr.indexOf(sChar[i]);

                while (iEnd != -1) {
                    sNewStr += sStr.substring(iStart, iEnd);
                    iStart = iEnd + 1;
                    iEnd = sStr.indexOf(sChar[i], iStart);
                }
                sNewStr += sStr.substring(sStr.lastIndexOf(sChar[i]) + 1, sStr.length);

                sStr = sNewStr;
            }

            return sNewStr;
        }
    </script>

</body>
</html>
