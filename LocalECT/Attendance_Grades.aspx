<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendance_Grades.aspx.cs" Inherits="LocalECT.Attendance_Grades" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Accounting /</a>
                      <a href="Attendance_Grades">&nbsp;Attendance Grades </a>
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
                            <h2><i class="fa fa-bar-chart"></i> Attendance Grades</h2>
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
                                            <label> Term</label>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddlRegTerm" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                   <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>Faculty</label>
                                            <div class="input-group">
                                                 <asp:DropDownList ID="ddlfaculty" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Select" Value=" " Selected="True"/>
                                            
                                        </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                  <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>From Date</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="fromDate" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                <strong>
<asp:RequiredFieldValidator ID="FromDateValidator" runat="server" ErrorMessage="***"   ControlToValidate="fromDate" ValidationGroup="no" CssClass="auto-style2"></asp:RequiredFieldValidator>
                                                </strong>
                                            </div>
                                        </div>
                                    </div>

                                  <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>To Date</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="toDate" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                <strong>
                                              <asp:RequiredFieldValidator ID="toDateValidator" runat="server" ErrorMessage="***"   ControlToValidate="toDate" ValidationGroup="no" CssClass="auto-style1"></asp:RequiredFieldValidator>
                                                </strong>
                                            </div>
                                        </div>
                                    </div>

                                 
                                  
                                    <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>&nbsp;</label>
                                            <div class="input-group">
                                     <asp:LinkButton ID="lnk_FieldGenerate" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_FieldGenerate_Click" ValidationGroup="no"><i class="fa fa-print" ></i> Generate Report</asp:LinkButton>
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

      .modal
    {
        position: fixed;
        top: 0;
        left: 0;
        background-color: black;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
    }
    .loading
    {
        font-family: Arial;
        font-size: 10pt;
        border: 5px solid #67CFF5;
        width: 200px;
        height: 100px;
        display: none;
        position: fixed;
        background-color: White;
        z-index: 999;
    }
                               </style>
                          
                        <%--   <div class="loading" align="center">
    
    <img src="C:\Users\abdul.shukkoor\Desktop\LocalECT\LocalECT\images\ajax-loader.gif/ajax-loader.gif" alt="" />
</div>--%>
                          
<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
  function ShowProgress() {
    setTimeout(function () {
      var modal = $('<div />');
      modal.addClass("modal");
      $('body').append(modal);
      var loading = $(".loading");
      loading.show();
      var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
      var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
      loading.css({ top: top, left: left });
    }, 200);
  }
  $('form').live("submit", function () {
    ShowProgress();
  });
</script>--%>
                           <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="/resources/demos/style.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
      var $j = jQuery.noConflict();
      $j(function () {
        $j("#fromDate").datepicker({ dateFormat: 'yy-mm-dd' });
        $j("#toDate").datepicker({ dateFormat: 'yy-mm-dd' });
      });
    </script>

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
                                            .auto-style1 {
                                                font-size: large;
                                                color: #FF0000;
                                            }
                                            .auto-style2 {
                                                font-size: large;
                                                color: #FF3300;
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
