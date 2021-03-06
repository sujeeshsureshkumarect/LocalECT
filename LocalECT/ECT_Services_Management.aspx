﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ECT_Services_Management.aspx.cs" Inherits="LocalECT.ECT_Services_management" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                     <%--<h3><i class="fa fa-globe"></i> Link Manager</h3>--%>
                                </div>
                                <style>
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
                                            <h2><i class="fa fa-globe"></i> Services Management</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                           
                      
                              
<%--                                            <a href="Link_Manager_Create.aspx" style="float:right;" class="btn btn-success btn-sm"><i class="glyphicon glyphicon-plus"></i> Create New Link</a>--%>
                                            <div class="clearfix"></div>
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
                                        </style>

                         <div id="datatable_wrapper" class="table-responsive">
                     
                        <div class="row">
                            <div class="col-sm-12">
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <HeaderTemplate>
                                <table id="example" class="table table-striped table-bordered" role="grid" aria-describedby="datatable_info" style='width: 100%'>
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" width="50px">SR No.</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Service ID</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" width="300px">Service Name</th>                                                                                       
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Audience</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Host</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Finance</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Status</th>                                            
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Action</th>
                                        </tr>
                                    </thead>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.ItemIndex+1 %></td>
                                                     <td><%#Eval("ServiceID")%></td>                                                    
                                                    <td><%#Eval("ServiceEn")%><br /><p style="direction: rtl;float:right;font-size:14px;font-weight:bold;"><%#Eval("ServiceAr")%></p></td>
                                                    <td><%#Eval("Audience")%></td>   
                                                    <td style="text-align:center;"><%#Eval("Host")%><br />(<%#Eval("HostDesc")%>)</td>
                                                    <td><%#Eval("Finance")%></td>
                                                    <td><%#Eval("isActive")%></td>
                                                     <td>
                                                    <div class="btn-group">
                                                         <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                             Actions
                                                         </button>
                                                         <div class="dropdown-menu">                                                             
                                                             <a href="ECT_Services_Update.aspx?id=<%#Eval("ServiceID")%>" class="dropdown-item">Edit</a>                                                                                                                       
                                                         </div>
                                                     </div>
                                                   </td>                                                    
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
       <script>
           var table = document.getElementById("example");
           if (table != null) {
               for (var i = 1; i < table.rows.length; i++) {       
                   var status = table.rows[i].cells[6].textContent;
                   if (status == "True") {
                       table.rows[i].cells[6].innerHTML = '<span class="badge badge-success">Active</span>';
                   }
                   else if (status == "False") {
                       table.rows[i].cells[6].innerHTML = '<span class="badge badge-danger">Inactive</span>';
                   }
               }
           }
       </script>
                                                    <style>
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