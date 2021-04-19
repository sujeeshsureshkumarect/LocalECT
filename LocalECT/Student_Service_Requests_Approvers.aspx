<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Service_Requests_Approvers.aspx.cs" Inherits="LocalECT.Student_Service_Requests_Approvers" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                       <%-- <a href="#">&nbsp;Registration /</a>
                        <a href="StudentSearch">&nbsp;Student Search /</a>--%>
                        <a href="Student_Service_Requests_Approvers">&nbsp;Student Service Requests</a>
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
                                     .badge {
            font-size: 100%;
        }
                                </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-dashboard"></i> Student Service Requests <asp:LinkButton ID="lnk_refresh" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_refresh_Click" ToolTip="Refresh"><i class="fa fa-refresh"></i></asp:LinkButton></h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                 <%--<a href="StudentSearch.aspx" class="btn btn-success btn-sm"><i class="fa fa-search"></i> Student Search</a>--%>
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                        <%--                <div class="x_content">                                                

           
                        </div--%>

                                        <div class="x_content">

                    <ul class="nav nav-tabs bar_tabs" id="myTab" role="tablist">
                      <li class="nav-item">
                        <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Finance</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Host</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" id="contact-tab" data-toggle="tab" href="#contact" role="tab" aria-controls="contact" aria-selected="false">Provider</a>
                      </li>
                    </ul>
                    <div class="tab-content" id="myTabContent">
                      <div class="tab-pane fade active show" id="home" role="tabpanel" aria-labelledby="home-tab">
                                                         <div class="clearfix"></div>                                           
                         <div id="datatable_wrapper" class="table-responsive">
                    <style>                      
                        #datatable11 tbody td div{
width:490px;
max-height:100px !important;
overflow:scroll;
white-space: nowrap;
}
                    </style>
                        <div class="row">
                            <div class="col-sm-12">
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <HeaderTemplate>
                                <table id="datatable11" class="table table-striped table-bordered" role="grid" aria-describedby="datatable_info" style='width: 100%'>
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" width="50px">SR No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" width="300px">Service Name</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending">Detail</th>--%>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Finance Action</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Created on</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Link</th>
                                            <th style="display:none;" class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Show</th>
                                        </tr>
                                    </thead>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.ItemIndex+1 %></td>
                                                    <td><%#Eval("ServiceID")%></td>                                                                                                         
                                                    <td><%#Eval("FinanceAction")%></td>                                                                                                        
                                                    <td><span style="display: none;"><%#Eval("Created","{0:yyyyMMdd}")%></span><%#Eval("Created","{0:dd/MM/yyyy hh:mm tt}")%></td>
                                                    <td><a class="btn btn-success btn-lg" href="https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices/Lists/Students_Requests/EditForm.aspx?ID=<%#Eval("ID")%>" target="_blank" title="Link to Item"><i class="fa fa-globe"></i></a></td>
                                                    <td style="display:none;"><%#Eval("Show")%></td>
                                                </tr>
                                        
                                   </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>                          
                            </div>
                        </div>
                  
                    </div>
                      </div>
                      <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                                                                          <div class="clearfix"></div>                                           
                         <div id="datatable_wrapper1" class="table-responsive">
                    <style>                      
                        #datatable1 tbody td div{
width:490px;
max-height:100px !important;
overflow:scroll;
white-space: nowrap;
}
                    </style>
                        <div class="row">
                            <div class="col-sm-12">
                                        <asp:Repeater ID="Repeater2" runat="server">
                                            <HeaderTemplate>
                                <table id="datatable1" class="table table-striped table-bordered" role="grid" aria-describedby="datatable_info" style='width: 100%'>
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" width="50px">SR No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" width="300px">Service Name</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending">Detail</th>--%>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Host Action</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Created on</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Link</th>
                                            <th style="display:none;" class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Show</th>
                                        </tr>
                                    </thead>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.ItemIndex+1 %></td>
                                                    <td><%#Eval("ServiceID")%></td>                                                                                                         
                                                    <td><%#Eval("HostAction")%></td>                                                                                                        
                                                    <td><span style="display: none;"><%#Eval("Created","{0:yyyyMMdd}")%></span><%#Eval("Created","{0:dd/MM/yyyy hh:mm tt}")%></td>
                                                    <td><a class="btn btn-success btn-lg" href="https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices/Lists/Students_Requests/EditForm.aspx?ID=<%#Eval("ID")%>" target="_blank" title="Link to Item"><i class="fa fa-globe"></i></a></td>
                                                    <td style="display:none;"><%#Eval("Show")%></td>
                                                </tr>
                                        
                                   </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>                          
                            </div>
                        </div>
                  
                    </div>
                      </div>
                      <div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab">
                                                                         <div class="clearfix"></div>                                           
                         <div id="datatable_wrapper2" class="table-responsive">
                    <style>                      
                        #datatable2 tbody td div{
width:490px;
max-height:100px !important;
overflow:scroll;
white-space: nowrap;
}
                    </style>
                        <div class="row">
                            <div class="col-sm-12">
                                        <asp:Repeater ID="Repeater3" runat="server">
                                            <HeaderTemplate>
                                <table id="datatable2" class="table table-striped table-bordered" role="grid" aria-describedby="datatable_info" style='width: 100%'>
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" width="50px">SR No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" width="300px">Service Name</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Office: activate to sort column ascending">Detail</th>--%>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Provider Action</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Created on</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Link</th>
                                            <th style="display:none;" class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Show</th>
                                        </tr>
                                    </thead>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.ItemIndex+1 %></td>
                                                    <td><%#Eval("ServiceID")%></td>                                                                                                         
                                                    <td><%#Eval("ProviderAction")%></td>                                                                                                        
                                                    <td><span style="display: none;"><%#Eval("Created","{0:yyyyMMdd}")%></span><%#Eval("Created","{0:dd/MM/yyyy hh:mm tt}")%></td>
                                                    <td><a class="btn btn-success btn-lg" href="https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices/Lists/Students_Requests/EditForm.aspx?ID=<%#Eval("ID")%>" target="_blank" title="Link to Item"><i class="fa fa-globe"></i></a></td>
                                                    <td style="display:none;"><%#Eval("Show")%></td>
                                                </tr>
                                        
                                   </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>                          
                            </div>
                        </div>
                  
                    </div>
                      </div>
                    </div>
                  </div>

                                         <script>
       var table = document.getElementById("datatable11");
       if (table != null) {
           for (var i = 1; i < table.rows.length; i++) {              
               //var status = table.rows[i].cells[2].textContent;          
               var show = table.rows[i].cells[5].textContent;          
               //if (status == "Completed") {
               //    table.rows[i].cells[2].innerHTML = '<span class="badge badge-success">Completed</span>';
               //}
               if (show == "N") {
                   table.rows[i].cells[4].innerHTML = '&nbsp;';
               }
           }
       }
                                         </script>
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
                                                       $('#datatable11').DataTable({

                                                       });
                                                       $('#datatable1').DataTable({

                                                       });
                                                       $('#datatable2').DataTable({
                                                         
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
                                                   var table = document.getElementById("datatable1");
                                                   if (table != null) {
                                                       for (var i = 1; i < table.rows.length; i++) {
                                                           //var status = table.rows[i].cells[2].textContent;          
                                                           var show = table.rows[i].cells[5].textContent;
                                                           //if (status == "Completed") {
                                                           //    table.rows[i].cells[2].innerHTML = '<span class="badge badge-success">Completed</span>';
                                                           //}
                                                           if (show == "N") {
                                                               table.rows[i].cells[4].innerHTML = '&nbsp;';
                                                           }
                                                       }
                                                   }
                                               </script>
                                              <script>
                                                  var table = document.getElementById("datatable2");
                                                  if (table != null) {
                                                      for (var i = 1; i < table.rows.length; i++) {
                                                          //var status = table.rows[i].cells[2].textContent;          
                                                          var show = table.rows[i].cells[5].textContent;
                                                          //if (status == "Completed") {
                                                          //    table.rows[i].cells[2].innerHTML = '<span class="badge badge-success">Completed</span>';
                                                          //}
                                                          if (show == "N") {
                                                              table.rows[i].cells[4].innerHTML = '&nbsp;';
                                                          }
                                                      }
                                                  }
                                              </script>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>