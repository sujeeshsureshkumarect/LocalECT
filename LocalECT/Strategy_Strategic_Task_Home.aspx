<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Strategic_Task_Home.aspx.cs" Inherits="LocalECT.Strategy_Strategic_Task_Home" MasterPageFile="~/LocalECT.Master"%>

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
                                            <h2><i class="fa fa-sitemap"></i> Tasks</h2>
                                            <ul class="nav navbar-right panel_toolbox">                                                
                                                <asp:LinkButton ID="lnk_Create" runat="server" style="float:right;" CssClass="btn btn-success btn-sm" OnClick="lnk_Create_Click"><i class="glyphicon glyphicon-plus"></i> Create New</asp:LinkButton>
                                                <%--<a href="Strategy_Strategic_Initiative_Home.aspx" style="float:right;" class="btn btn-success btn-sm"><i class="fa fa-arrow-circle-left"></i> Strategic Initiative</a>--%>
                                                <asp:LinkButton ID="lnk_Back" runat="server" style="float:right;" CssClass="btn btn-success btn-sm" title="Back" OnClick="lnk_Back_Click"><i class="fa fa-arrow-circle-left"></i> Strategic Initiative</asp:LinkButton>
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
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Task ID</th> 
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Task Description</th> 
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Period</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Start Date</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">End Date</th>    --%>                                        
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Department</th>     
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Section</th>                                                                                        
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">MOE Re-licensure Stipulation</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">MOE Re-licensure Sub Stipulation</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">MOE Re-licensure Stipulation Guidelines</th>                                            
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Inspection Compliance Standard</th>  
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Inspection Compliance Domain</th>                                                                                        
                                            <%--<th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Inspection Compliance Indicator</th>--%>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Inspection Compliance Guidelines</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Risk Management</th>--%>                                            
<%--                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Survey Form Reference</th>     
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">IRQA Recommendation</th>   --%>  
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Survey Form Reference</th> 
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Evidence Record</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Initiative</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Duration</th> 
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Duration Value</th>
                                            <%--<th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">EV</th>--%>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Digital Transformation Program</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Digital Use Case</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Strategy Version</th>                                            
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Order</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Added On</th>
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Added By</th>                                                                                                                             
                                            <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Start date: activate to sort column ascending">Action</th>
                                        </tr>
                                    </thead>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.ItemIndex+1 %></td>
                                                    <td title="<%#Eval("sTaskDesc")%>"><%#Eval("sTaskID")%></td>  
                                                    <td><%#Eval("sTaskDesc")%></td>
                                                    <td><%#Eval("sPeriod")%></td>
                                                    <%--<td><%#Eval("dStart","{0:yyyy-MM-dd}")%></td>
                                                    <td><%#Eval("dEnd","{0:yyyy-MM-dd}")%></td>--%>
                                                    <td ><%#Eval("DepartmentAbbreviation")%></td>   
                                                    <td ><%#Eval("SectionAbbreviation")%></td>  
                                                    <td ><%#Eval("sStipulationDesc")%></td> 
                                                    <td ><%#Eval("sSubStipulationDesc")%></td> 
                                                    <td ><%#Eval("sGuidelinesDesc")%></td> 
                                                    <td ><%#Eval("sInspectionComplianceStandardDesc")%></td>
                                                    <td ><%#Eval("sInspectionComplianceDomainDesc")%></td>
                                                    <%--<td title="<%#Eval("sInspectionComplianceIndicatorDesc")%>"><%#Eval("sInspectionComplianceIndicatorID")%></td>--%>
                                                    <td ><%#Eval("sInspectionComplianceGuidelinesDesc")%></td>
                                                   <%-- <td><%#Eval("sRiskManagement")%></td>--%>
                                                   <%-- 
                                                    <td><%#Eval("sIRQARecommendation")%></td>--%>
                                                    <td title="<%#Eval("sSurveyName")%>"><%#Eval("sSurveyFormReference")%></td>
                                                    <%--<td><%#Eval("sEvidenceRecored")%></td>--%>
                                                    <td><a href="Strategy_Strategic_Evidence_Home?id=<%#Eval("iSerial1")%>" style="color:blue;" target="_blank"><u><%#Eval("sEvidenceRecored")%></u></a></td>
                                                    <td ><%#Eval("sInitiativeID")%> <%#Eval("sInitiativeDesc")%></td>    
                                                    <td><%#Eval("sDuration")%></td>
                                                    <td><%#Eval("iDurationValue")%></td>
                                                    <%--<td><%#Eval("sEV")%></td>--%>
                                                    <td><%#Eval("sDigitalTransformationProgram")%></td>
                                                    <td><%#Eval("sDigitalUseCase")%></td>
                                                    <td><%#Eval("sStrategyVersion")%></td>
                                                    <td><%#Eval("iOrder")%></td>                                                    
                                                    <td><%#Eval("dAdded","{0:yyyy-MM-dd}")%></td>
                                                    <td><%#Eval("sAddedBy")%></td>                                                                                                     
                                                     <td>
                                                    <div class="btn-group">
                                                         <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                             Actions
                                                         </button>
                                                         <div class="dropdown-menu">  
                                                             <asp:LinkButton ID="lnk_View" runat="server" class="dropdown-item" OnClick="lnk_View_Click" CommandArgument=<%#Eval("iSerial")%>>View</asp:LinkButton>
                                                             <asp:LinkButton ID="lnk_Edit" runat="server" class="dropdown-item" OnClick="lnk_Edit_Click" CommandArgument=<%#Eval("iSerial")%>>Edit</asp:LinkButton>
                                                             <asp:LinkButton ID="LinkButton1" runat="server" class="dropdown-item" OnClick="LinkButton1_Click" CommandArgument=<%#Eval("iSerial")%>>Execute</asp:LinkButton>

                                                             <%--<a href="Strategy_Strategic_Task_Update.aspx?id=<%#Eval("iInitiative")%>&sid=<%#Eval("iSerial")%>&t=v" class="dropdown-item">View</a> 
                                                             <a href="Strategy_Strategic_Task_Update.aspx?id=<%#Eval("iInitiative")%>&sid=<%#Eval("iSerial")%>&t=e" class="dropdown-item">Edit</a> 
                                                             <a href="Strategy_Strategic_Task_Detail_Home.aspx?id=<%#Eval("iInitiative")%>&sid=<%#Eval("iSerial")%>" class="dropdown-item">Execute</a> --%>
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