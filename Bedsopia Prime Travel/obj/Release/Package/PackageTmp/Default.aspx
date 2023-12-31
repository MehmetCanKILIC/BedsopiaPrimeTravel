﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bedsopia_Prime_Travel.Default"  MasterPageFile="~/Bedsopia.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Admin Panel</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css" />
    <link rel="stylesheet" href="dist/css/skins/skin-blue.min.css" />
    <link rel="stylesheet" href="dist/css/skins/skin-blue.min.css" />
    <!-- Google Font -->
    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" />





</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    


        <script src="assets/js/bundle.js" crossorigin="anonymous"></script>
    <script src="assets/js/jquery.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="assets/js/app.js"></script>
    <script src="assets/js/datatables.js"></script>
    <script src="assets/js/flot.js"></script>

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


    <script type="text/javascript">


        /* defined datas */
        var dataTargetProfit = [
            [1354586000000, 253],
            [1364587000000, 658],
            [1374588000000, 198],
            [1384589000000, 663],
            [1394590000000, 801],
            [1404591000000, 1080],
            [1414592000000, 353],
            [1424593000000, 749],
            [1434594000000, 523],
            [1444595000000, 258],
            [1454596000000, 688],
            [1464597000000, 364]
        ]
        var dataProfit = [
            [1354586000000, 53],
            [1364587000000, 65],
            [1374588000000, 98],
            [1384589000000, 83],
            [1394590000000, 980],
            [1404591000000, 808],
            [1414592000000, 720],
            [1424593000000, 674],
            [1434594000000, 23],
            [1444595000000, 79],
            [1454596000000, 88],
            [1464597000000, 36]
        ]
        var dataSignups = [
            [1354586000000, 647],
            [1364587000000, 435],
            [1374588000000, 784],
            [1384589000000, 346],
            [1394590000000, 487],
            [1404591000000, 463],
            [1414592000000, 479],
            [1424593000000, 236],
            [1434594000000, 843],
            [1444595000000, 657],
            [1454596000000, 241],
            [1464597000000, 341]
        ]
        var dataSet1 = [
            [0, 10],
            [100, 8],
            [200, 7],
            [300, 5],
            [400, 4],
            [500, 6],
            [600, 3],
            [700, 2]
        ];
        var dataSet2 = [
            [0, 9],
            [100, 6],
            [200, 5],
            [300, 3],
            [400, 3],
            [500, 5],
            [600, 2],
            [700, 1]
        ];
        $(document).ready(function () {
            /* flot toggle example */
            var flot_toggle = function () {
                var data = [{
                    label: "Target Profit",
                    data: dataTargetProfit,
                    color: color.info._400,
                    bars: {
                        show: true,
                        align: "center",
                        barWidth: 30 * 30 * 60 * 1000 * 80,
                        lineWidth: 0,
                        /*fillColor: {
                            colors: [color.primary._500, color.primary._900]
                        },*/
                        fillColor: {
                            colors: [{
                                opacity: 0.9
                            }, {
                                opacity: 0.1
                            }]
                        }
                    },
                    highlightColor: 'rgba(255,255,255,0.3)',
                    shadowSize: 0
                }, {
                    label: "Actual Profit",
                    data: dataProfit,
                    color: color.warning._500,
                    lines: {
                        show: true,
                        lineWidth: 2
                    },
                    shadowSize: 0,
                    points: {
                        show: true
                    }
                }, {
                    label: "User Signups",
                    data: dataSignups,
                    color: color.success._500,
                    lines: {
                        show: true,
                        lineWidth: 2
                    },
                    shadowSize: 0,
                    points: {
                        show: true
                    }
                }]
                var options = {
                    grid: {
                        hoverable: true,
                        clickable: true,
                        tickColor: 'rgba(0,0,0,0.05)',
                        borderWidth: 1,
                        borderColor: 'rgba(0,0,0,0.05)'
                    },
                    tooltip: true,
                    tooltipOpts: {
                        cssClass: 'tooltip-inner',
                        defaultTheme: false
                    },
                    xaxis: {
                        mode: "time",
                        tickColor: 'rgba(0,0,0,0.05)',
                    },
                    yaxes: {
                        tickColor: 'rgba(0,0,0,0.05)',
                        tickFormatter: function (val, axis) {
                            return "$" + val;
                        },
                        max: 1200
                    }
                };
                var plot2 = null;
                function plotNow() {
                    var d = [];
                    $("#js-checkbox-toggles").find(':checkbox').each(function () {
                        if ($(this).is(':checked')) {
                            d.push(data[$(this).attr("name").substr(4, 1)]);
                        }
                    });
                    if (d.length > 0) {
                        if (plot2) {
                            plot2.setData(d);
                            plot2.draw();
                        } else {
                            plot2 = $.plot($("#flot-toggles"), d, options);
                        }
                    }
                };
                $("#js-checkbox-toggles").find(':checkbox').on('change', function () {
                    plotNow();
                });
                plotNow()
            }
            flot_toggle();

        });





    </script>

</asp:Content>











