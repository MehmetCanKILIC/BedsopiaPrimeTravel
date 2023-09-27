<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultFinance.aspx.cs" Inherits="Bedsopia_Prime_Travel.DefaultFinance" MasterPageFile="~/Prime.Master" %>

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

    <ol class="breadcrumb page-breadcrumb">
        <li class="breadcrumb-item"><a href="%">Primetravel</a></li>
        <li class="breadcrumb-item">Application Intel</li>
        <li class="breadcrumb-item active">Marketing Dashboard</li>
        <li class="position-absolute pos-top pos-right d-none d-sm-block">
            <span class="js-get-date">Monday, September 19, 2022</span></li>
    </ol>

    <div class="subheader">
        <h1 class="subheader-title">
            <i class="subheader-icon fa fa-chart-area"></i>Prime Travel <span class="fw-300">Dashboard</span>
        </h1>
        <div class="subheader-block d-lg-flex align-items-center">
            <div class="d-flex mr-4">
                <div class="mr-2">
                    <span class="peity-donut" data-peity="{ &quot;fill&quot;: [&quot;#967bbd&quot;, &quot;#ccbfdf&quot;],  &quot;innerRadius&quot;: 14, &quot;radius&quot;: 20 }" style="display: none;">7/10</span><svg class="peity" height="40" width="40"><path d="M 20 0 A 20 20 0 1 1 0.9788696740969307 26.18033988749895 L 6.685208771867851 24.326237921249266 A 14 14 0 1 0 20 6" data-value="7" fill="#967bbd"></path><path d="M 0.9788696740969307 26.18033988749895 A 20 20 0 0 1 19.999999999999996 0 L 19.999999999999996 6 A 14 14 0 0 0 6.685208771867851 24.326237921249266" data-value="3" fill="#ccbfdf"></path></svg>
                </div>
                <div>
                    <label class="fs-sm mb-0 mt-2 mt-md-0">New Sessions</label>
                    <h4 class="font-weight-bold mb-0">70.60%</h4>
                </div>
            </div>
            <div class="d-flex mr-0">
                <div class="mr-2">
                    <span class="peity-donut" data-peity="{ &quot;fill&quot;: [&quot;#2196F3&quot;, &quot;#9acffa&quot;],  &quot;innerRadius&quot;: 14, &quot;radius&quot;: 20 }" style="display: none;">3/10</span><svg class="peity" height="40" width="40"><path d="M 20 0 A 20 20 0 0 1 39.02113032590307 26.18033988749895 L 33.31479122813215 24.326237921249263 A 14 14 0 0 0 20 6" data-value="3" fill="#2196F3"></path><path d="M 39.02113032590307 26.18033988749895 A 20 20 0 1 1 19.999999999999996 0 L 19.999999999999996 6 A 14 14 0 1 0 33.31479122813215 24.326237921249263" data-value="7" fill="#9acffa"></path></svg>
                </div>
                <div>
                    <label class="fs-sm mb-0 mt-2 mt-md-0">Page Views</label>
                    <h4 class="font-weight-bold mb-0">14,134</h4>
                </div>
            </div>
        </div>
    </div>


    <%--                    KUTULAR --%>


    <div class="row">
        <div class="col-sm-6 col-xl-3">
            <div class="p-3 bg-primary-300 rounded overflow-hidden position-relative text-white mb-g">
                <div class="">
                    <h3 class="display-4 d-block l-h-n m-0 fw-500">21.5k
                                        <small class="m-0 l-h-n">users signed up</small>
                    </h3>
                </div>
                <i class="fa fa-user position-absolute pos-right pos-bottom opacity-15 mb-n1 mr-n1" style="font-size: 6rem"></i>
            </div>
        </div>
        <div class="col-sm-6 col-xl-3">
            <div class="p-3 bg-warning-400 rounded overflow-hidden position-relative text-white mb-g">
                <div class="">
                    <h3 class="display-4 d-block l-h-n m-0 fw-500">$10,203
                                        <small class="m-0 l-h-n">Visual Index Figure
                                        </small>
                    </h3>
                </div>
                <i class="fa fa-gem position-absolute pos-right pos-bottom opacity-15 mb-n1 mr-n1" style="font-size: 6rem"></i>
            </div>
        </div>
        <div class="col-sm-6 col-xl-3">
            <div class="p-3 bg-success-200 rounded overflow-hidden position-relative text-white mb-g">
                <div class="">
                    <h3 class="display-4 d-block l-h-n m-0 fw-500">-103.72
                                        <small class="m-0 l-h-n">Offset Balance Ratio
                                        </small>
                    </h3>
                </div>
                <i class="fa fa-lightbulb  position-absolute pos-right pos-bottom opacity-15 mb-n1 mr-n1" style="font-size: 6rem"></i>
            </div>
        </div>
        <div class="col-sm-6 col-xl-3">
            <div class="p-3 bg-info-200 rounded overflow-hidden position-relative text-white mb-g">
                <div class="">
                    <h3 class="display-4 d-block l-h-n m-0 fw-500">+40%
                                        <small class="m-0 l-h-n">Product level increase
                                        </small>
                    </h3>
                </div>
                <i class="fa fa-globe position-absolute pos-right pos-bottom opacity-15 mb-n1 mr-n1" style="font-size: 6rem"></i>
            </div>
        </div>
    </div>


    <%--                    MARKETİNG PROFFİTS ALANI--%>

    <div class="panel-card d-flex" id="panel">
        <div class="panel col-12 panel-sortable" id="panel-1">
            <div class="panel-header">
                <h2>Marketing profits</h2>
                <div class="panel-saving mr-2" style="display: none;"><i class="fal fa-spinner-third fa-spin-4x fs-xl"></i></div>
                <div class="panel-toolbar">
                    <a href="#" class="btn-toolbar js-panel-collapse" id="collapse"></a>
                    <a href="#" class="btn-toolbar js-panel-fullscreen" id="fullscreen"></a>
                    <a href="#" class="btn-toolbar js-panel-close" id="closed"></a>
                </div>
                <div class="panel-toolbar panel-dropdown  ">
                    <a href="#" class="btn btn-toolbar-master waves-effect waves-themed" id="panel-dropdown"><i class="fa fa-ellipsis-v"></i></a>
                    <div class="panel-dropdown-menu ">
                        <a href="#" class="dropdown-item js-panel-refresh" id="panel-refresh-content"><span data-i18n="drpdwn.refreshpanel">Refresh Content</span></a>
                        <a href="#" class="dropdown-item js-panel-refresh"><span data-i18n="drpdwn.refreshpanel">Lock Position</span></a>
                        <a href="#" class="dropdown-item js-panel-refresh"><span data-i18n="drpdwn.refreshpanel">Panel Style</span></a>
                        <a href="#" class="dropdown-item js-panel-refresh"><span data-i18n="drpdwn.refreshpanel">Reset Panel</span></a>
                    </div>
                </div>

            </div>
            <div class="panel-container " style="background-image: linear-gradient(to top, #fff, #f6f8fc);">
                <div class="loader">
                    <i class="fa-solid fa-spinner"></i>
                </div>
                <div class="panel-content bg-subtlelight-fade">
                    <div id="js-checkbox-toggles" class="d-flex mb-3">
                        <div class="custom-control custom-switch mr-2">
                            <input type="checkbox" class="custom-control-input" name="gra-0" id="gra-0" checked="checked">
                            <label class="custom-control-label" for="gra-0">Target Profit</label>
                        </div>
                        <div class="custom-control custom-switch mr-2">
                            <input type="checkbox" class="custom-control-input" name="gra-1" id="gra-1" checked="checked">
                            <label class="custom-control-label" for="gra-1">Actual Profit</label>
                        </div>
                        <div class="custom-control custom-switch mr-2">
                            <input type="checkbox" class="custom-control-input" name="gra-2" id="gra-2" checked="checked">
                            <label class="custom-control-label" for="gra-2">User Signups</label>
                        </div>
                    </div>
                    <div id="flot-toggles" class="w-100 mt-4" style="height: 300px; padding: 0px; position: relative;">
                        <canvas class="flot-base" width="1439" height="375" style="direction: ltr; position: absolute; left: 0px; top: 0px; width: 1151.2px; height: 300px;"></canvas>
                        <div class="flot-text" style="position: absolute; inset: 0px; font-size: smaller; color: rgb(84, 84, 84);">
                            <div class="flot-x-axis flot-x1-axis xAxis x1Axis" style="position: absolute; inset: 0px;"></div>
                            <div class="flot-y-axis flot-y1-axis yAxis y1Axis" style="position: absolute; inset: 0px;"></div>
                        </div>
                        <canvas class="flot-overlay" width="1439" height="375" style="direction: ltr; position: absolute; left: 0px; top: 0px; width: 1151.2px; height: 300px;"></canvas>
                        <div class="legend">
                            <div style="position: absolute; width: 82.6375px; height: 53.775px; top: 13px; right: 28px; background-color: rgb(255, 255, 255); opacity: 0.85;">
                            </div>
                            <table style="position: absolute; top: 13px; right: 28px; font-size: smaller; color: #545454">
                                <tbody>
                                    <tr>
                                        <td class="legendColorBox">
                                            <div style="border: 1px solid #ccc; padding: 1px">
                                                <div style="width: 4px; height: 0; border: 5px solid #39a1f4; overflow: hidden"></div>
                                            </div>
                                        </td>
                                        <td class="legendLabel">Target Profit</td>
                                    </tr>
                                    <tr>
                                        <td class="legendColorBox">
                                            <div style="border: 1px solid #ccc; padding: 1px">
                                                <div style="width: 4px; height: 0; border: 5px solid #ffc241; overflow: hidden"></div>
                                            </div>
                                        </td>
                                        <td class="legendLabel">Actual Profit</td>
                                    </tr>
                                    <tr>
                                        <td class="legendColorBox">
                                            <div style="border: 1px solid #ccc; padding: 1px">
                                                <div style="width: 4px; height: 0; border: 5px solid #1dc9b7; overflow: hidden"></div>
                                            </div>
                                        </td>
                                        <td class="legendLabel">User Signups</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="panel-card d-flex" id="panel">
        <div class="panel col-12 panel-sortable" id="panel-2">
            <div class="panel-header">
                <h2>Sales Records</h2>
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
                        <a href="#" class="dropdown-item js-panel-refresh"><span data-i18n="drpdwn.refreshpanel">Lock Position</span></a>
                        <a href="#" class="dropdown-item js-panel-refresh"><span data-i18n="drpdwn.refreshpanel">Panel Style</span></a>
                        <a href="#" class="dropdown-item js-panel-refresh"><span data-i18n="drpdwn.refreshpanel">Reset Panel</span></a>
                    </div>
                </div>

            </div>
            <div class="panel-container ">
                <div class="loader">
                    <i class="fa-solid fa-spinner"></i>
                </div>
                <div class="panel-content">
                    <table id="example" class="table table-bordered table-striped w-100 dataTable dtr-inline" style="vertical-align: middle; ">
                        <thead class="thead-dark">
                            <tr>
                                <th>Name</th>
                                <th>Position</th>
                                <th>Office</th>
                                <th>Age</th>
                                <th>Start date</th>
                                <th>Salary</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Tiger Nixon</td>
                                <td>System Architect</td>
                                <td>Edinburgh</td>
                                <td>61</td>
                                <td>2011-04-25</td>
                                <td>$320,800</td>
                            </tr>

                            <tr>
                                <td>Garrett Winters</td>
                                <td>Accountant</td>
                                <td>Tokyo</td>
                                <td>63</td>
                                <td>2011-07-25</td>
                                <td>$170,750</td>
                            </tr>
                            <tr>
                                <td>Tiger Nixon</td>
                                <td>System Architect</td>
                                <td>Edinburgh</td>
                                <td>61</td>
                                <td>2011-04-25</td>
                                <td>$320,800</td>
                            </tr>

                            <tr>
                                <td>Garrett Winters</td>
                                <td>Accountant</td>
                                <td>Tokyo</td>
                                <td>63</td>
                                <td>2011-07-25</td>
                                <td>$170,750</td>
                            </tr>

                            <tr>
                                <td>Tiger Nixon</td>
                                <td>System Architect</td>
                                <td>Edinburgh</td>
                                <td>61</td>
                                <td>2011-04-25</td>
                                <td>$320,800</td>
                            </tr>


                        </tbody>
                        <tfoot>
                            <tr>
                                <th>Name</th>
                                <th>Position</th>
                                <th>Office</th>
                                <th>Age</th>
                                <th>Start date</th>
                                <th>Salary</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>


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





