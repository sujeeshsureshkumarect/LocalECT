<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Digital_Transformation_Program.aspx.cs" Inherits="LocalECT.Digital_Transformation_Program" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                     <h3><i class="fa fa-globe"></i> Corporate Strategy</h3>
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
                                            <h2><i class="fa fa-dashboard"></i> Digital Transformation Program</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                               <a href="Strategy_Digital_Transformation_Create" style="float:right;" class="btn btn-success btn-sm"><i class="glyphicon glyphicon-plus"></i> Create New Program</a>
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                
                                                 
                                           
                                           

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
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Digital Transformation Program</th>
                                             
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Action</th>
                              
                                        </tr>
                                    </thead>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.ItemIndex+1 %></td>
                                                     <td><%#Eval("sDigitalTransformationProgram")%></td>
                                                   
                                                     <td style="text-align:center">
                                                    <div class="btn-group" style="text-align:center">
                                                         <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                             Actions
                                                         </button>
                                                         <div class="dropdown-menu" >                                                             
                                                            <a href="Strategy_Digital_Transformation_Edit.aspx?id=<%#Eval("iSerial")%>" class="dropdown-item">Edit</a>
                                                           <a href="Strategy_Digital_Use_Case.aspx?id=<%#Eval("iSerial")%>" class="dropdown-item">Digital Use Case</a>    
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

                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
       <script>
           var table = document.getElementById("example");
       if (table != null) {
           for (var i = 1; i < table.rows.length; i++) {
               //var link = table.rows[i].cells[3].textContent;
               //var attachment = table.rows[i].cells[4].textContent;
               var status = table.rows[i].cells[5].textContent;


               //if (link == "") {
               //    table.rows[i].cells[3].innerHTML = '';
               //}
               //else {
               //    table.rows[i].cells[3].innerHTML = '<a href=' + link +' target="_blank"><i class="fa fa-globe"></i> <u>View</u></a>';
               //}  
               //if (attachment == "") {
               //    table.rows[i].cells[4].innerHTML = '';
               //}
               //else {
               //    table.rows[i].cells[4].innerHTML = '<a href=' + attachment + ' target="_blank"><i class="fa fa-paperclip"></i> <u>View</u></a>';
               //} 
               if (status == "True") {
                   table.rows[i].cells[5].innerHTML = '<span class="badge badge-success">Active</span>';
               }
               else if (status == "False") {
                   table.rows[i].cells[5].innerHTML = '<span class="badge badge-danger">Inactive</span>';
               }  
           }
       }
       </script>

                    <style>
                         .badge {
            font-size: 100%;
        }
     
    </style>
    </asp:Content>
