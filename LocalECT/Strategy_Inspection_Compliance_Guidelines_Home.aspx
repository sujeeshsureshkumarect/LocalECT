﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Inspection_Compliance_Guidelines_Home.aspx.cs" Inherits="LocalECT.Strategy_Inspection_Compliance_Guidelines_Home" MasterPageFile="~/LocalECT.Master"%>

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
                                            <h2><i class="fa fa-sitemap"></i> Inspection Compliance Guidelines</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <%--<a href="Strategy_SubStipulation_Update.aspx" style="float:right;" class="btn btn-success btn-sm"><i class="glyphicon glyphicon-plus"></i> Create New Sub Stipulation</a>--%>
                                                <asp:LinkButton ID="lnk_Create" runat="server" style="float:right;" CssClass="btn btn-success btn-sm" OnClick="lnk_Create_Click"><i class="glyphicon glyphicon-plus"></i> Create New Inspection Compliance Guidelines</asp:LinkButton>
                                                <%--<a href="Strategy_SubStipulation_Home.aspx" style="float:right;" class="btn btn-success btn-sm" title="Back"><i class="fa fa-arrow-circle-left"></i> Sub Stipulation</a>--%>
                                                 <asp:LinkButton ID="LinkButton1" runat="server" style="float:right;" CssClass="btn btn-success btn-sm" OnClick="LinkButton1_Click"><i class="fa fa-arrow-circle-left"></i> Inspection Compliance Domain</asp:LinkButton>
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">                                                                                              
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
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Inspection Compliance Guidelines ID</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Position: activate to sort column ascending" width="300px">Inspection Compliance Guidelines Description</th>                                                                                       
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Inspection Compliance Standard ID</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Inspection Compliance Domain ID</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Inspection Compliance Indicator ID</th>--%>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Order</th>    
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Added On</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Added By</th>                                                                                                                             
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Action</th>
                                        </tr>
                                    </thead>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.ItemIndex+1 %></td>
                                                     <td><%#Eval("sInspectionComplianceGuidelinesID")%></td>                                                    
                                                    <td><%#Eval("sInspectionComplianceGuidelinesDesc")%></td>
                                                    <td><%#Eval("sInspectionComplianceStandardID")%></td> 
                                                    <td><%#Eval("sInspectionComplianceDomainID")%></td> 
                                                    <%--<td><%#Eval("sInspectionComplianceIndicatorID")%></td> --%>
                                                    <td><%#Eval("iOrder")%></td>  
                                                    <td><%#Eval("dAdded","{0:yyyy-MM-dd}")%></td>
                                                    <td><%#Eval("sAddedBy")%></td>                                                                                                     
                                                     <td>
                                                    <div class="btn-group">
                                                         <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                             Actions
                                                         </button>
                                                         <div class="dropdown-menu">                                                             
                                                             <a href="Strategy_Inspection_Compliance_Guidelines_Update.aspx?sid=<%#Eval("iInspectionComplianceStandard")%>&did=<%#Eval("iInspectionComplianceDomain")%>&gid=<%#Eval("iSerial")%>" class="dropdown-item">Edit</a>                                                             
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


               
    </asp:Content>