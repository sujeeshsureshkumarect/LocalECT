<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ACC_Reg_Balance.aspx.cs" Inherits="LocalECT.ACC_Reg_Balance"  MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Accounting /</a>
                      <a href="ACC_Reg_Balance">&nbsp;Reg Balances </a>
                    </h3>
                </div>
                <style>
                    .breadcrumb {
                        padding: 8px 15px;
                        margin-bottom: 20px;
                        list-style: none;
                        background-color: #ededed;
                        border-radius: 4px;
                        font-size: 13px;
                    }

                    .page-title .title_left {
                        width: 100%;
                        float: left;
                        display: block;
                    }



                </style>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><i class="fa fa-bar-chart"></i> Registered Balances</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                              <div class="x_content bs-example-popovers" id="div_msg" runat="server" visible="false">
                                <div class="alert alert-danger alert-dismissible" role="alert" runat="server" id="div_Alert">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <asp:Label ID="lbl_Msg" runat="server" Text="" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                </div>
                            </div>
                            <div id="Headers">
                                <div class="row">  
                                     <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>Campus</label>
                                            <div class="input-group">
                                                 <asp:DropDownList ID="drp_Campus" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Males" Value="1" Selected="True"/>
                                            <asp:ListItem Text="Females" Value="2" />
                                        </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                       <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>Term</label>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddlRegTerm" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                  <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>Report Type</label>
                                            <div class="input-group">
                                                 <asp:DropDownList ID="ddlRptType" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Semester Balance" Value="1" Selected="True"/>
                                            <asp:ListItem Text="Over all Balance" Value="2" />
                                        </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>SID</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtSID" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>ACC</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtACC" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div> 
                                    <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>&nbsp;</label>
                                            <div class="input-group">
                                     <asp:LinkButton ID="lnk_FieldGenerate" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_FieldGenerate_Click"><i class="fa fa-print"></i> Generate Report</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    <%--<div class="x_panel">   
                                         <div class="x_title">
                            <h2><i class="fa fa-info"></i> Choose your fields (Maximum 10 Fields)</h2>                         
                            <div class="clearfix"></div>
                        </div>                                   
                                       
                                        </div>--%>
                                    </div>                              
                                </div>
                            <style>
                               #ContentPlaceHolder1_chk_Fields label{
                                    padding-left: 5px;
    padding-right: 25px;
    padding-top:14px;
                                }
                               thead input {
        width: 100%;
    }
                            </style>
                           <%-- <script src="Scripts/jquery-3.4.1.min.js"></script>--%>
                      <%--      <script src="https://cdn.datatables.net/1.10.23/js/jquery.dataTables.min.js"></script>
                            <script src="https://cdn.datatables.net/fixedheader/3.1.8/js/dataTables.fixedHeader.min.js"></script>
                            <link href="https://cdn.datatables.net/fixedheader/3.1.8/css/fixedHeader.dataTables.min.css" rel="stylesheet" />--%>
            <%--               <script>
                               $(document).ready(function () {
                                   // Setup - add a text input to each footer cell
                                   $('#datatable thead tr').clone().prependTo('#datatable thead');
                                   $('#datatable thead tr:eq(0) th').each(function (i) {
                                       var title = $(this).text();

                                       $(this).html('<input type="text" placeholder="Search ' + title + '" />');

                                       $('input', this).on('keyup change', function () {
                                           if (table.column(i).search() !== this.value) {
                                               table
                                                   .column(i)
                                                   .search(this.value)
                                                   .draw();
                                           }
                                       });
                                   });

                                   var table;
                                   if ($.fn.dataTable.isDataTable('#datatable')) {
                                       table = $('#datatable').DataTable();
                                   }
                                   else {
                                       table = $('#datatable').DataTable({
                                           orderCellsTop: true,
                                           fixedHeader: true
                                       });
                                   }
                               });
                           </script>--%>

                        <div id="details">
                            <hr />
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-tasks"></i> Results</h2>
                                            <div class="clearfix"></div>
                                        </div>
                                       <%-- <asp:GridView ID="Results" runat="server" AutoGenerateColumns="true"                                           
                                            EnableViewState="true" ShowHeaderWhenEmpty="True">
                                        </asp:GridView>--%>

                                        <div id="divResult" runat="server" class="table-responsive">
                                             <asp:Literal ID="DynamicTable" runat="server"></asp:Literal>
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
                                                        dom: 'QlBfrtip',
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
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>

