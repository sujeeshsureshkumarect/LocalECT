<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeTableViewer.aspx.cs" Inherits="LocalECT.TimeTableViewer" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <%--<h3>Welcome To Emirates College Of Technology (ECT)</h3>--%>
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
                                            <h2><i class="fa fa-calendar"></i> Course Time Table</h2>
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

                                            <div>
                                                       <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Term :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="TermCBO" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Session :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="PeriodCBO" runat="server" CssClass="form-control" AutoPostBack="True" 
                                            onselectedindexchanged="PeriodCBO_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td>
                <asp:Label ID="Label7" runat="server" Text="Department :"></asp:Label>
                                    </td>
                                    <td>
                <asp:DropDownList ID="UnitCBO" runat="server" 
                   CssClass="form-control" onselectedindexchanged="UnitCBO_SelectedIndexChanged" 
                                            AutoPostBack="True">
                </asp:DropDownList>
                                    </td>
                                    <td colspan="4">
                                        <asp:CheckBox ID="chkShowPassedOnly" runat="server" Text="Not Passed Only" 
                                            Visible="False" />
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Campus :"></asp:Label>
                                    </td>
                                    <td colspan="5">
                                        <asp:RadioButtonList ID="rbnCampus" runat="server" RepeatDirection="Horizontal" 
                                            CssClass="form-control">
                                            <asp:ListItem Selected="True" Value="-1">Media &amp; Males</asp:ListItem>
                                            <asp:ListItem>Media</asp:ListItem>
                                            <asp:ListItem>Females</asp:ListItem>
                                        </asp:RadioButtonList>
                                       
                                    </td>
                                    <td colspan="4">
                                        <asp:CheckBox ID="chkShowRegCount" runat="server" Checked="True" 
                                            Text="Show Reg Count" />
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Class :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ClassCBO" runat="server" CssClass="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select Class</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Course :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="CourseCBO" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </td>
                                    <td>
                <asp:Label ID="Label1" runat="server" Text="Instructor :"></asp:Label>
                                    </td>
                                    <td>
                <asp:DropDownList ID="LecturerCBO" runat="server" 
                    CssClass="form-control">
                </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="RunCMD" runat="server" 
                                        ToolTip="Run" onclick="RunCMD_Click" CssClass="btn btn-success btn-sm"><i class="fa fa-flash"></i> Run</asp:LinkButton>
                                    </td>
                                    <td style="display:none;">
                                        <asp:ImageButton ID="PrintCMD" runat="server" ImageUrl="~/Images/Icons/Print_BW.jpg"
                                        Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                                        ToolTip="Print as PDF" onclick="PrintCMD_Click" Enabled="False" />
                                    </td>
                                    <td style="display:none;">
                                        <asp:ImageButton ID="toExcelCMD" runat="server" ImageUrl="~/Images/Icons/toExcel_BW.jpg"
                                        Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                                        ToolTip="Transfer to Excel" Enabled="False" onclick="toExcelCMD_Click" />
                                    </td>
                                    <td style="display:none;">
                                        <asp:ImageButton ID="toWordCMD" runat="server" ImageUrl="~/Images/Icons/toWord_BW.jpg"
                                        Style="border-top-width: thin; border-left-width: thin; border-left-color: blue; border-bottom-width: thin; border-bottom-color: blue; border-top-color: blue; border-right-width: thin; border-right-color: blue;" 
                                        ToolTip="Transfer to Word" Enabled="False" onclick="toWordCMD_Click" />
                                    </td>
                                    
                                </tr>
                            </table>
                                                <hr />
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
                                               thead input {
        width: 100%;
    }
                                        </style>


            <div class="col-md-12 col-sm-12">
                     <div id="divResult" runat="server" class="table-responsive">
                                     <asp:Repeater ID="RepterDetails" runat="server">
                                         <HeaderTemplate>
                                             <table id='example' class='table table-striped table-bordered' style='width: 100%'>
                                                 <thead>
                                                     <tr class='headings'>
                                                        <%-- <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending">#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">ID</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Name</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Major</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Status</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Actions</th>--%>
                                                         <%--<th><input type="checkbox" name="select_all" value="1" id="example-select-all"></th>--%>
                                                         <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending">#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Session</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Course</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Section No</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Instructor</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">sTFrom</th>                                                         
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">sTTo</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">sDay</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">sHall</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Reg</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Cap</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Actions</th>
                                                     </tr>
                                                 </thead>
                                         </HeaderTemplate>
                                         <ItemTemplate>
                                             <tr>
                                                 <%--<td><input type="checkbox" name="select_all" value=<%#Eval("sNo")%> class="individualCHK"></td>--%>
                                                 <td align='center'><%# Container.ItemIndex+1 %></td>                                                
                                                 <td><%#Eval("sPeriod")%></td>
                                                 <td><%#Eval("sCourse")%></td>
                                                 <td><%#Eval("iClass")%></td>
                                                 <td><%#Eval("sLecturer")%></td>
                                                 <td><%#Eval("sTFrom")%></td>
                                                 <td><%#Eval("sTTo")%></td>
                                                  <td><%#Eval("sDay")%></td>
                                                  <td><%#Eval("sHall")%></td>
                                                 <td><%#Eval("iCapacity")%></td>
                                                 <td><%#Eval("iMax")%></td>
                                                 <td>
                                                     <div class="btn-group">
                                                         <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                             Actions
                                                         </button>
                                                         <div class="dropdown-menu">
                                                             <a class="dropdown-item" href="#">Edit</a>
                                                              <asp:LinkButton ID="BtnView" runat="server"  CssClass="dropdown-item"
                                        CommandArgument='<%# Eval("sCourse")+ ";" + Eval("iClass")+";"+Eval("iPeriod")+";"+Eval("sPeriod") %>' 
                                        oncommand="BtnView_Command">List</asp:LinkButton>     
                                                             <asp:LinkButton ID="BtnAtt" runat="server" CssClass="dropdown-item"
                                                CommandArgument='<%# Eval("sCourse")+ ";" + Eval("iClass")+";"+Eval("iPeriod")+";"+Eval("sPeriod") %>' 
                                                oncommand="BtnAtt_Command" Enabled="false">Attendance</asp:LinkButton>
                                       
                                                             
                                                             <asp:LinkButton ID="BtnGrades" runat="server" CssClass="dropdown-item"
                                                CommandArgument='<%# Eval("sCourse")+ ";" + Eval("iClass")+";"+Eval("iPeriod")+";"+Eval("sPeriod") %>' 
                                                oncommand="SelectBTN_Command" Enabled="false">Grades</asp:LinkButton>
                                                             <a class="dropdown-item" href="#">Send SMS</a>
                                                             <a class="dropdown-item" href="#">Send Email</a>                                                                                                                    
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
 <style>
                                     .dropdown-menu.show{
                                         overflow-y:scroll;
                                         max-height:200px !important;
                                     }
                                     .dropdown-item {
    width: 100%;
    padding: 5px !important;
}
                                     .table-responsive{
                                         overflow-x:visible !important;
                                     }
                                 </style>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>