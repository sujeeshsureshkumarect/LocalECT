<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ACC_Daily_Receipt.aspx.cs" Inherits="LocalECT.ACC_Daily_Receipt" MasterPageFile="~/LocalECT.Master" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Accounting /</a>
                      <a href="ACC_Daily_Receipt">&nbsp;Daily Receipt </a>
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
                            <h2><i class="fa fa-bar-chart"></i>Daily Receipt</h2>
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
                                            <label>Date Type</label>
                                            <div class="input-group">
                                                 <asp:DropDownList ID="ddlDateType" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Payment Date" Value="DPayment" Selected="True"/>
                                            <asp:ListItem Text="Due Date" Value="DueDate" />
                                        </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                  <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>Date From</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="StartDate" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                <strong>
<asp:RequiredFieldValidator ID="StartDateValidator" runat="server" ErrorMessage="**" ControlToValidate="StartDate" ValidationGroup="VLGroup" Font-Size="Large" CssClass="auto-style3"></asp:RequiredFieldValidator>
                                                </strong>
                                            </div>
                                        </div>
                                    </div>
                                  <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>Date To</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="EndDate" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                <strong>
                                              <asp:RequiredFieldValidator ID="EndDateValidator" runat="server" ErrorMessage="**" ControlToValidate="EndDate" ValidationGroup="VLGroup" Font-Size="Large" CssClass="auto-style2"></asp:RequiredFieldValidator>
                                                </strong>
                                            </div>
                                        </div>
                                    </div>
                                    </div>

                              <div class="row">  
                                   <div class="col-sm-6 col-md-6 col-xs-12">
                                        <div class="form-group">
                                            <label>Mode of Payment</label>
                                            <div class="input-group">
                                                <asp:CheckBoxList ID="PaymentMode" runat="server" RepeatDirection="Horizontal" CellPadding="2" CellSpacing="2"   CssClass="auto-style1" Width="871px"  CausesValidation="true">
                                                  <asp:ListItem value="1">Cash</asp:ListItem>
                                                  <asp:ListItem value="2">Credit Card</asp:ListItem>
                                                  <asp:ListItem value="3">Cheque</asp:ListItem>
                                                    <asp:ListItem value="4">Others</asp:ListItem>
                                                  <asp:ListItem value="5">Transfer</asp:ListItem>
                                                   <asp:ListItem value="6">Online</asp:ListItem>
                                                                      </asp:CheckBoxList>
                                                <strong>
                                            

                                                </strong>

                                            </div>
                                        </div>
                                    </div>

                                  <div class="col-sm-5 col-md-5 col-xs-12">
                                        <div class="form-group">
                                            <label>Status</label>
                                            <div class="input-group">
                                                <asp:CheckBoxList ID="Status" runat="server" RepeatDirection="Horizontal" CellPadding="2" CellSpacing="2"   CssClass="auto-style1" Width="875px" >
                                                  <asp:ListItem value="0" Selected="True">Entry</asp:ListItem>
                                                  <asp:ListItem value="1" Selected="True">Paid</asp:ListItem>
                                                  <asp:ListItem value="2" Selected="True">Returned</asp:ListItem>
                                                  <asp:ListItem value="3" Selected="True">Insurance</asp:ListItem>
                                                  <asp:ListItem value="4"  Selected="True">Cancelled</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </div>
                                   </div>
                                 
                                 
                                                                                                    
                                    <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>&nbsp;</label>
                                            <div class="input-group">
                                     <asp:LinkButton ID="lnk_FieldGenerate" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_FieldGenerate_Click" ValidationGroup="VLGroup"><i class="fa fa-print" ></i> Generate Report</asp:LinkButton>
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
                          
                           <div class="loading" align="center">
    
    <img src="C:\Users\abdul.shukkoor\Desktop\LocalECT\LocalECT\images\ajax-loader.gif/ajax-loader.gif" alt="" />
</div>
                          
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="/resources/demos/style.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
      var $j = jQuery.noConflict();
      $j(function () {
        $j("#StartDate").datepicker({
          dateFormat: 'yy-mm-dd',
          maxDate: 0,
          onClose: function (selectedDate) {
            $j("#EndDate").datepicker("option", "minDate", selectedDate);
          }
        });
        $j("#EndDate").datepicker({
          dateFormat: 'yy-mm-dd',
          maxDate: 0,
          onClose: function (selectedDate) {
            $j("#StartDate").datepicker("option", "maxDate", selectedDate);
          }
        });
      });
    </script>  


 

                        <div id="details">
                          
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




                                            </script>
                                        <style>
                                            div.dtsb-searchBuilder button.dtsb-button{
                                                font-size:12px !important;
                                            }
                                              .badge {
            font-size: 100%;
        }
                                            .auto-style1 {
                                                display: block;
                                                font-size: 13px;
                                                font-weight: 400;
                                                line-height: 1.5;
                                                color: #495057;
                                                background-clip: padding-box;
                                                border-radius: 0;
                                                transition: none;
                                                border: 1px solid #ced4da;
                                                background-color: #fff;
                                            }
                                            .auto-style2 {
                                                color: #CC3300;
                                            }
                                            .auto-style3 {
                                                color: #FF0000;
                                            }
                                            .auto-style4 {
                                                color: #FF3300;
                                                font-size: medium;
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
