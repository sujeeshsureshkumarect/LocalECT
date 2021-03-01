<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Report_Center.aspx.cs" Inherits="LocalECT.Student_Report_Center" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="Student_Report_Center">&nbsp;Student Report Center</a>

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
                            <h2><i class="fa fa-print"></i> Student Report Center</h2>
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
                                     <div class="col-sm-3 col-md-3 col-xs-12">
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
                                       <div class="col-sm-3 col-md-3 col-xs-12">
                                        <div class="form-group">
                                            <label>Term</label>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddlRegTerm" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>                                    
                                    <div class="x_panel">   
                                         <div class="x_title">
                            <h2><i class="fa fa-info"></i> Choose your fields (Maximum 10 Fields)</h2>                         
                            <div class="clearfix"></div>
                        </div>
                                    <asp:CheckBoxList id="chk_Fields" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CellPadding="5">
                                        <asp:ListItem Text="SID" Value="SD.SID"></asp:ListItem>
                                        <asp:ListItem Text="Name(En)" Value="SD.NameEn"></asp:ListItem>
                                        <asp:ListItem Text="Name(Ar)" Value="SD.NameAr"></asp:ListItem>
                                        <asp:ListItem Text="Gender" Value="SD.Gender"></asp:ListItem>
                                        <asp:ListItem Text="HRS" Value="RBS.HRS"></asp:ListItem>
                                        <asp:ListItem Text="MCRS" Value="RBS.MCRS"></asp:ListItem>
                                        <asp:ListItem Text="FCRS" Value="RBS.FCRS"></asp:ListItem>

                                        <asp:ListItem Text="CRS" Value="RBS.MCRS + RBS.FCRS AS CRS"></asp:ListItem>

                                        
                                        <asp:ListItem Text="RegDate" Value="convert(varchar(10),convert(date,RDBS.YYYYMMDD),23) AS RegDate"></asp:ListItem>
                                        <asp:ListItem Text="Balance" Value="ACBS.Balance"></asp:ListItem>
                                        <asp:ListItem Text="MajorFaculty" Value="MF.FacultyName AS MajorFaculty"></asp:ListItem>

                                        <asp:ListItem Text="MajorPlan" Value="M.strMajor AS MajorPlan"></asp:ListItem>
                                        <asp:ListItem Text="MajorName" Value="M.strCaption AS MajorName"></asp:ListItem>
                                        <asp:ListItem Text="PrvMajor" Value="PMJ.Major AS PrvMajor"></asp:ListItem>
                                        <asp:ListItem Text="MajorUnified" Value="M.sUnified AS MajorUnified"></asp:ListItem>
                                        <asp:ListItem Text="MajorNameUnified" Value="M.strDisplay AS MajorNameUnified"></asp:ListItem>
                                        <asp:ListItem Text="PlanHRS" Value="M.intStudyHours AS PlanHRS"></asp:ListItem>
                                        <asp:ListItem Text="FTR" Value="FT.FTR"></asp:ListItem>
                                        <asp:ListItem Text="LTR" Value="LT.LTR"></asp:ListItem>
                                        <asp:ListItem Text="TC" Value="TR.TC"></asp:ListItem>
                                        <asp:ListItem Text="DirectRef" Value="SD.DirectRef"></asp:ListItem>                                        
                                        
                                        <asp:ListItem Text="STType" Value="condition1"></asp:ListItem>
                                        <asp:ListItem Text="Completed" Value="condition2"></asp:ListItem>                                        
                                        <asp:ListItem Text="UID" Value="SD.UID"></asp:ListItem>
                                        <asp:ListItem Text="CXID" Value="SD.CXID"></asp:ListItem>
                                        <asp:ListItem Text="EID" Value="SD.EID"></asp:ListItem>
                                        <asp:ListItem Text="Session" Value="SD.Session"></asp:ListItem>
                                        <asp:ListItem Text="Age" Value="SD.Age"></asp:ListItem>
                                        <asp:ListItem Text="POD" Value="SD.POD"></asp:ListItem>
                                        <asp:ListItem Text="Nationality" Value="SD.Nationality"></asp:ListItem>
                                        <asp:ListItem Text="NGroup" Value="SD.NGroup"></asp:ListItem>
                                        <asp:ListItem Text="HSSection" Value="SD.HSSection"></asp:ListItem>
                                        <asp:ListItem Text="HSScore" Value="SD.HSScore"></asp:ListItem>
                                        <asp:ListItem Text="EmSAT(Ar)" Value="SD.EmSAT_AR"></asp:ListItem>
                                        <asp:ListItem Text="ENG" Value="SD.ENG"></asp:ListItem>
                                        <asp:ListItem Text="ENGSource" Value="SD.ENGSource"></asp:ListItem>
                                        <asp:ListItem Text="ENGDate" Value="SD.ENGDate"></asp:ListItem>
                                        <asp:ListItem Text="ENGYear" Value="SD.ENGYear"></asp:ListItem>
                                        <asp:ListItem Text="ENGCenter" Value="SD.ENGCenter"></asp:ListItem>
                                        <asp:ListItem Text="ENGScore" Value="SD.ENGScore"></asp:ListItem>
                                        <asp:ListItem Text="CGPA" Value="SD.CGPA"></asp:ListItem>
                                        <asp:ListItem Text="Status" Value="SD.Status"></asp:ListItem>
                                        <asp:ListItem Text="StatusTerm" Value="SD.StatusTerm"></asp:ListItem>
                                        <asp:ListItem Text="Phone1" Value="SD.Phone1"></asp:ListItem>
                                        <asp:ListItem Text="Phone2" Value="SD.Phone2"></asp:ListItem>
                                        <asp:ListItem Text="eMail" Value="SD.eMail"></asp:ListItem>
                                        <asp:ListItem Text="isActive" Value="SD.isActive"></asp:ListItem>
                                        <asp:ListItem Text="isComplete" Value="SD.isComplete"></asp:ListItem>
                                        <asp:ListItem Text="WantedMajor" Value="SD.WantedMajor"></asp:ListItem>
                                        <asp:ListItem Text="CreatedBy" Value="SD.CreatedBy"></asp:ListItem>                                        
                                        <asp:ListItem Text="Created" Value="convert(varchar(10),convert(date,SD.Created),23) as Created"></asp:ListItem>
                                        <asp:ListItem Text="RCity" Value="SD.RCity"></asp:ListItem>
                                        <asp:ListItem Text="REmirate" Value="SD.REmirate"></asp:ListItem>
                                        <asp:ListItem Text="How" Value="SD.How"></asp:ListItem>
                                        <asp:ListItem Text="Account" Value="SD.Account"></asp:ListItem>
                                        <asp:ListItem Text="FinCategory" Value="SD.FinCategory"></asp:ListItem>
                                        <asp:ListItem Text="Sponsor" Value="SD.Sponsor"></asp:ListItem>
                                        <asp:ListItem Text="IsACCWanted" Value="SD.IsACCWanted"></asp:ListItem>
                                        <asp:ListItem Text="ACCRegTerm" Value="SD.ACCRegTerm"></asp:ListItem>
                                        <asp:ListItem Text="OnlineStatus" Value="SD.OnlineStatus"></asp:ListItem>
                                        <asp:ListItem Text="RefHistory" Value="[dbo].[GetREFs] (SD.SID) AS RefHistory"></asp:ListItem>
                                        <asp:ListItem Text="Joined" Value="SD.Joined"></asp:ListItem>
                                        <asp:ListItem Text="AcceptanceType" Value="SD.AcceptanceType"></asp:ListItem>
                                        <asp:ListItem Text="AcceptanceCondition" Value="SD.AcceptanceCondition"></asp:ListItem>
                                        <asp:ListItem Text="AdmissionStatus" Value="SD.AdmissionStatus"></asp:ListItem>
                                    </asp:CheckBoxList>  
                                        <asp:LinkButton ID="lnk_FieldGenerate" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_FieldGenerate_Click"><i class="fa fa-print"></i> Generate Report</asp:LinkButton>
                                        </div>
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
