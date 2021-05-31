<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Link_Manager_Analysis.aspx.cs" Inherits="LocalECT.Link_Manager_Analysis" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3><i class="fa fa-globe"></i> Link Manager</h3>
                </div>
                <style>
                    .page-title .title_left {
                        width: 100%;
                        float: left;
                        display: block;
                    }
                </style>
            </div>
            <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="/resources/demos/style.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script type="text/javascript">
            var $j = jQuery.noConflict();
            $j(function () {
                $j("#txt_Start").datepicker({
                    dateFormat: 'yy-mm-dd',
                    maxDate: 0,
                    onClose: function (selectedDate) {
                        $j("#txt_End").datepicker("option", "minDate", selectedDate);
                    }
                });
                $j("#txt_End").datepicker({
                    dateFormat: 'yy-mm-dd',
                    maxDate: 0,
                    onClose: function (selectedDate) {
                        $j("#txt_Start").datepicker("option", "maxDate", selectedDate);
                    }
                });
            });
        </script>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><i class="fa fa-bar-chart"></i>  <asp:DropDownList ID="lbl_Order" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lbl_Order_SelectedIndexChanged">
                                <asp:ListItem Text="Last 7 days" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Daily"></asp:ListItem>
                                <asp:ListItem Text="Weekly"></asp:ListItem>
                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                <asp:ListItem Text="Yearly"></asp:ListItem>
                                                                         </asp:DropDownList> Analysis of Clicks</h2>
                             <div class="col-md-2 col-sm-2">
                                     <div class="form-group ">
                                    <asp:TextBox ID="txt_Start" runat="server" CssClass="form-control" placeholder="Start Date" ClientIDMode="Static" AutoPostBack="true" OnTextChanged="txt_Start_TextChanged"></asp:TextBox>
</div>
                                </div>
                                <div class="col-md-2 col-sm-2">
                                     <div class="form-group ">
                                    <asp:TextBox ID="txt_End" runat="server" CssClass="form-control" placeholder="End Date" ClientIDMode="Static" AutoPostBack="true" OnTextChanged="txt_Start_TextChanged"></asp:TextBox>
                                         </div>
                                </div>

                            <ul class="nav navbar-right panel_toolbox">
                                 <a href="Link_Manager_Home.aspx" style="float:right;" class="btn btn-success btn-sm"><i class="fa fa-globe"></i> Link Manager</a>
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <div class="clearfix"></div>

                            <div id="chart_div" style="width: auto; height: 300px">
</div>


                        </div>
                          <asp:ScriptManager ID="ScriptManager" runat="server" />

                        <script type="text/javascript" src="https://www.google.com/jsapi"></script>
                        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
                        <script>
                            var chartData; // globar variable for hold chart data
                            google.load("visualization", "1", { packages: ["corechart"] });

                            // Here We will fill chartData

                            $(document).ready(function () {

                                $.ajax({
                                    url: "Link_Manager_Analysis.aspx/GetLineChartData",
                                    data: "",
                                    dataType: "json",
                                    type: "POST",
                                    contentType: "application/json; chartset=utf-8",
                                    success: function (data) {
                                        chartData = data.d;
                                    },
                                    error: function () {
                                        alert("Error loading data! Please try again.");
                                    }
                                }).done(function () {
                                    // after complete loading data
                                    google.setOnLoadCallback(drawChart);
                                    drawChart();
                                });
                            });


                            function drawChart() {
                                var data = google.visualization.arrayToDataTable(chartData);

                                var options = {
                                    title: "",
                                    pointSize: 5
                                };

                                var lineChart = new google.visualization.LineChart(document.getElementById('chart_div'));
                                lineChart.draw(data, options);

                            }
                        </script>

                        
                            <div class="col-md-12 col-sm-12">
                               <%-- <div class="col-md-2 col-sm-2">
                                     <div class="form-group ">
                                    Start Date<asp:TextBox ID="txt_Start" runat="server" CssClass="form-control"></asp:TextBox>
</div>
                                </div>
                                <div class="col-md-2 col-sm-2">
                                     <div class="form-group ">
                                    End Date<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                                         </div>
                                </div>--%>
                            
                           
                            <br />
                            <div id="divResult" runat="server" class="table-responsive">
                                             <asp:Literal ID="DynamicTable" runat="server"></asp:Literal>
                                            </div>
                        </div>
                        
                        
                                        <link rel="stylesheet" type="text/css" href="SearchBuilder/jquery.dataTables.min.css">
                                        <link rel="stylesheet" type="text/css" href="SearchBuilder/searchBuilder.dataTables.min.css">
                                        <link rel="stylesheet" type="text/css" href="SearchBuilder/dataTables.dateTime.min.css">
                                        <link rel="stylesheet" type="text/css" href="SearchBuilder/buttons.dataTables.min.css">

                                        <script type="text/javascript" src="SearchBuilder/jquery-3.5.1.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/jquery.dataTables.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/dataTables.searchBuilder.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/dataTables.dateTime.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/dataTables.buttons.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/jszip.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/pdfmake.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/vfs_fonts.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/buttons.print.min.js"></script>
                                        <script type="text/javascript" src="SearchBuilder/buttons.html5.min.js"></script>

                                            <script>
                                                $.noConflict();  //Release the $ variable
                                                jQuery(document).ready(function ($) {
                                                    $('#example').DataTable({
                                                        language: {
                                                            searchBuilder: {
                                                                title: {
                                                                    0: 'Search Builder',
                                                                    _: 'Search Builder (%d)'
                                                                }
                                                            }
                                                        },
                                                        dom: 'lBfrtip', /*QlBfrtip*/
                                                        buttons: [
                                                            'csv', 'excel', 'print'
                                                        ]
                                                    });
                                                });
    //$(document).ready(function () {
    //    $('#example').DataTable({
    //        dom: 'Qlfrtip',
    //        searchBuilder: {
    //            logic: 'OR'
    //        }
    //    });
    //});
                                            </script>
                                        <style>
                                            div.dtsb-searchBuilder button.dtsb-button{
                                                font-size:12px !important;
                                            }
                                              .badge {
            font-size: 100%;
        }
                                        </style>

                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
