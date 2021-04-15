<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Online_Payment_Tracking.aspx.cs" Inherits="LocalECT.Online_Payment_Tracking" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Accounting /</a>
                      <a href="Online_Payment_Tracking">&nbsp;Online Payment Tracking </a>
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
                            <h2><i class="fa fa-bar-chart"></i> Online Payment Tracking </h2>
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
                                    <%--<button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>--%>
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
                                            <label>Order Date From</label>
                                            <div class="input-group">
                                                 <asp:TextBox ID="DDateFrom" runat="server" CssClass="form-control"  ClientIDMode="Static" ValidationGroup="sd"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="DateFromValidator" runat="server" ErrorMessage="***" CssClass="auto-style1" ControlToValidate="DDateFrom" ValidationGroup="sd"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                    </div>

                                  <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>Order Date To</label>
                                            <div class="input-group">
                                                 <asp:TextBox ID="DDateTo" runat="server" CssClass="form-control"  ClientIDMode="Static" ValidationGroup="sd"></asp:TextBox>
                                                 <strong>
                                              <asp:RequiredFieldValidator ID="DateToValidator" runat="server" ErrorMessage="***" CssClass="auto-style1" ControlToValidate="DDateTo" ValidationGroup="sd"></asp:RequiredFieldValidator>
                                                 </strong>
                                            </div>
                                        </div>
                                    </div>
                                  
                                  
                                    <div class="col-sm-2 col-md-2 col-xs-12">
                                        <div class="form-group">
                                            <label>SID</label>
                                                                           <div class="input-group">
                                                <asp:TextBox ID="txtSID" runat="server" CssClass="form-control" ></asp:TextBox>
                                              
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
                                     <asp:LinkButton ID="lnk_FieldGenerate" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_FieldGenerate_Click" ValidationGroup="sd"><i class="fa fa-print"></i> Generate Report</asp:LinkButton>
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
    
  
</div>

               <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="/resources/demos/style.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
      var $j = jQuery.noConflict();
      $j(function () {
        $j("#DDateFrom").datepicker({ dateFormat: 'yy-mm-dd' });
        $j("#DDateTo").datepicker({ dateFormat: 'yy-mm-dd' });
      });
    </script>

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
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
                                            <%-- <asp:Literal ID="DynamicTable" runat="server"></asp:Literal>--%>
                                               <div id="div1" runat="server" class="table-responsive">
                                     <asp:Repeater ID="RepterDetails" runat="server">
                                         <HeaderTemplate>
                                             <table id='example' class='table table-striped table-bordered' style='width: 100%'>
                                                 <thead>
                                                     <tr class='headings'>                                                         
                                                         <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending">#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="display:none;">Serial#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Order#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Account#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">SID</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Service</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">RDate</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">isCaptured</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Captured</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Voucher#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">isCanceled</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">cAmount</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" style="display:none;">cVAT</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Actions</th>
                                                     </tr>
                                                 </thead>
                                         </HeaderTemplate>
                                         <ItemTemplate>
                                             <tr>                                                
                                                 <td align='center'><%# Container.ItemIndex+1 %></td>
                                                 <td style="display:none;"><%#Eval("Serial#")%></td>
                                                 <td><%#Eval("Order")%></td>
                                                 <td><%#Eval("Account")%></td>
                                                 <td><%#Eval("SID")%></td>
                                                 <td><%#Eval("Service")%></td>
                                                <%-- <td><%#Eval("RDate")%></td>--%>
                                                 <td><span style="display: none;"><%#Eval("RDate","{0:yyyyMMdd}")%></span><%#Eval("RDate","{0:dd/MM/yyyy hh:mm tt}")%></td>
                                                 <td><%#Eval("isCaptured")%></td>
                                                 <td><span style="display: none;"><%#Eval("Captured","{0:yyyyMMdd}")%></span><%#Eval("Captured","{0:dd/MM/yyyy hh:mm tt}")%></td>
                                                 <%--<td><%#Eval("Captured")%></td>--%>
                                                 <td><%#Eval("VoucherNo")%></td>
                                                 <td><%#Eval("isCanceled")%></td>
                                                 <td><%#Eval("cAmount")%></td>
                                                 <td style="display:none;"><%#Eval("cVAT")%></td>
                                                 <td>
                                                     <%--<div class="btn-group">
                                                         <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                             Actions
                                                         </button>
                                                         <div class="dropdown-menu">
                                                             <a class="dropdown-item" href="Acc_Search_Edit?sAcc">Edit</a>                                                             
                                                         </div>
                                                     </div>--%>
                                                     <asp:LinkButton ID="lnk_Create_Voucher" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_Create_Voucher_Click" OnClientClick="return confirm('Are you sure you want to add this voucher?');" CommandArgument=<%#Eval("Order")%>><i class="fa fa-plus"></i> Add Voucher</asp:LinkButton>
                                                 </td>
                                             </tr>
                                         </ItemTemplate>
                                         <FooterTemplate>
                                             </table>  
                                         </FooterTemplate>
                                     </asp:Repeater>
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


                                      <script>
                                        var table = document.getElementById("example");
                                        if (table != null) {
                                          for (var i = 1; i < table.rows.length; i++) {
                                              var status = table.rows[i].cells[7].textContent;   
                                              var isCanceled = table.rows[i].cells[10].textContent;  
                                              var isCaptured = table.rows[i].cells[7].textContent;  
                                              var cAmount = table.rows[i].cells[11].textContent;                                              
                                              var cVAT = table.rows[i].cells[12].textContent;
                                            if ( status == "Yes") {
                                              table.rows[i].cells[7].innerHTML = '<span class="badge badge-success">' + status + '</span>';
                                            }
                                            else {
                                              table.rows[i].cells[7].innerHTML = '<span class="badge badge-danger">' + status + '</span>';
                                              }
                                              if (isCanceled == "Yes") {
                                                  table.rows[i].cells[10].innerHTML = '<span class="badge badge-success">' + isCanceled + '</span>';
                                              }
                                              else {
                                                  table.rows[i].cells[10].innerHTML = '<span class="badge badge-danger">' + isCanceled + '</span>';
                                              }

                                              if (cAmount == "" || cAmount == null) {
                                                  table.rows[i].cells[11].innerHTML = 0;
                                              }
                                              if (cVAT == "" || cVAT == null) {
                                                  table.rows[i].cells[12].innerHTML = 0;
                                              }

                                              if (isCaptured == "No" && isCanceled == "No") {

                                              }
                                              else {
                                                  table.rows[i].cells[13].innerHTML = "";
                                              }

                                              if (isCanceled == "Yes") {
                                                  table.rows[i].cells[13].innerHTML = "";
                                              }
                                          }
                                        }
                                      </script>
                                        <style>
                                            div.dtsb-searchBuilder button.dtsb-button{
                                                font-size:12px !important;
                                            }
                                              .badge {
            font-size: 100%;
        }
                                            .auto-style1 {
                                                color: #FF0000;
                                                font-size: large;
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
