<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Strategic_Initiative_Home.aspx.cs" Inherits="LocalECT.Strategy_Strategic_Initiative_Home" MasterPageFile="~/LocalECT.Master"%>

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
                                            <h2><i class="fa fa-sitemap"></i> Strategic Initiative</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <a href="Strategy_Strategic_Initiative_Update.aspx" style="float:right;" class="btn btn-success btn-sm"><i class="glyphicon glyphicon-plus"></i> Create New Strategic Initiative</a>
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
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Initiative ID</th>                                                                                                                                    
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">University Status</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Initiative Priority</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Initiative Maturity</th>                                                                                        
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Digital Transformation Program</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Digital Use Case</th>--%>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Enterprise Model</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Principal Department</th>                                                                                        
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Principal Section</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Theme</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Goal</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Project</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Objective</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Order</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Strategy Version</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Abbreviation</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Value Proposition Impact</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Level</th>                                            
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Added On</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Added By</th>                                                                                                                             
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Action</th>
                                        </tr>
                                    </thead>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.ItemIndex+1 %></td>
                                                    <td title="<%#Eval("sInitiativeDesc")%>"><%#Eval("sInitiativeID")%></td>                                                       
                                                    <td><%#Eval("sUniversityStatus")%></td>
                                                    <td><%#Eval("sInitiativePriority")%></td>
                                                    <td><%#Eval("sInitiativeMaturity")%></td>    
                                                    <td><%#Eval("sDigitalTransformationProgram")%></td>
                                                    <%--<td><%#Eval("sDigitalUseCase")%></td>--%>
                                                    <td><%#Eval("sEnterpriseModel")%></td>
                                                    <td title="<%#Eval("Expr1")%>"><%#Eval("DepartmentAbbreviation")%></td>    
                                                    <td title="<%#Eval("DescEN")%>"><%#Eval("SectionAbbreviation")%></td>
                                                    <td title="<%#Eval("sThemeDesc")%>"><%#Eval("sThemeCode")%></td>
                                                    <td title="<%#Eval("sStrategicGoalDesc")%>"><%#Eval("sStrategicGoalID")%></td>
                                                    <td title="<%#Eval("sStrategicProjectDesc")%>"><%#Eval("sStrategicProjectID")%></td>
                                                    <td title="<%#Eval("sStrategicObjectiveDesc")%>"><%#Eval("sStrategicObjectiveID")%></td>
                                                    <td><%#Eval("iOrder")%></td>
                                                    <td><%#Eval("sStrategyVersion")%></td>
                                                    <td><%#Eval("sAbbreviation")%></td> 
                                                    <td><%#Eval("sValuePropositionImpact")%></td>   
                                                    <td><%#Eval("iLevel")%></td> 
                                                    <td><%#Eval("dAdded","{0:yyyy-MM-dd}")%></td>
                                                    <td><%#Eval("sAddedBy")%></td>                                                                                                     
                                                    <td>
                                                    <div class="btn-group">
                                                         <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                             Actions
                                                         </button>
                                                         <div class="dropdown-menu">                                                                                                                          
                                                             <a href="Strategy_Strategic_Initiative_Update.aspx?id=<%#Eval("iSerial")%>&t=v" class="dropdown-item">View</a> 
                                                             <a href="Strategy_Strategic_Initiative_Update.aspx?id=<%#Eval("iSerial")%>&t=e" class="dropdown-item">Edit</a>
                                                             <a href="Strategy_Initiative_Dpartment_Section_Home.aspx?id=<%#Eval("iSerial")%>" class="dropdown-item">Manage Support Department/Section</a>
                                                             <a href="Strategy_Risk_Management.aspx?id=<%#Eval("iSerial")%>" class="dropdown-item">Manage Risks</a>
                                                             <a href="Strategy_Strategic_KPI_Home.aspx?id=<%#Eval("iSerial")%>" class="dropdown-item">KPIs</a>
                                                             <a href="Strategy_Strategic_Task_Home.aspx?id=<%#Eval("iSerial")%>" class="dropdown-item">Tasks</a>
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