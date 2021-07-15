<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendace_Warning_Management.aspx.cs" Inherits="LocalECT.Attendace_Warning_Management" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <%--<a href="#">&nbsp;Registration /</a>--%>
                        <a href="Attendace_Warning_Management">&nbsp;Attendance Warning Management</a>

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
                 /*   .alert{
                        padding:5px;
                    }*/
                    .table {
                        color:#444444;
                    }
                    .dropdown-item {
    width: 100%;
    padding: 5px !important;
}
                </style>
                 <script>
                     setTimeout(explode, 200);
                     function explode() {
                         var test = document.getElementById('datatabless_info').textContent;
                         document.getElementById('lbl_Count').textContent = "(" + test + ")";
                     }
                     $(document).on('keyup', '.dataTables_filter input', function () {
                         var test = document.getElementById('datatabless_info').textContent;
                         document.getElementById('lbl_Count').textContent = "(" + test + ")";
                     })
                 </script>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><i class="fa fa-warning"></i> Attendance Warning Management</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <%--<a href="Student_Profile.aspx" class="btn btn-success btn-sm" id="lnk_add" runat="server"><i class="glyphicon glyphicon-plus"></i> Create New Student</a>--%>
                               <%-- <asp:LinkButton ID="lnk_add" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_add_Click"><i class="glyphicon glyphicon-plus"></i> Create New Student</asp:LinkButton>--%>
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
                            <div class="col-md-9 col-sm-12">
                                <div class="form-group row">
                                    <label class="col-form-label col-md-3 col-sm-3 ">Campus</label>
                                    <div class="col-md-6 col-sm-6 ">
                                        <asp:DropDownList ID="drp_Campus" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Males" Value="1" />
                                            <asp:ListItem Text="Females" Value="2" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-md-3 col-sm-3 ">Term</label>
                                    <div class="col-md-6 col-sm-6 ">
                                        <asp:DropDownList ID="ddlTerm" runat="server" CssClass="form-control">                                            
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3 col-sm-3 ">
                                        <asp:LinkButton ID="lnk_Search" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_Search_Click" ValidationGroup="no"><i class="fa fa-search"></i> Search</asp:LinkButton>
                                    </div>
                                </div>                                
                            </div>
                             <div class="col-md-12 col-sm-12">
                                 <hr />
                                 <div class="x_content bs-example-popovers">
                                  <div class="alert alert-info alert-dismissible " role="alert" runat="server" id="alertsearch" visible="false">

                            <strong>Search Result - </strong><asp:Label runat="server" ID="lbl_Count" ClientIDMode="Static"></asp:Label>
                            
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
                                                         $("#Bulk_Actions").hide();
                                                         var table = $('#datatabless').DataTable({
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

                                                         // Handle click on "Select all" control
                                                         $('#example-select-all').on('click', function () {
                                                             // Check/uncheck all checkboxes in the table
                                                             var rows = table.rows({ 'search': 'applied' }).nodes();
                                                             $('input[type="checkbox"]', rows).prop('checked', this.checked);
                                                             if ($('#example-select-all').is(':checked')) {
                                                                 //all selected
                                                                 //alert("all");
                                                                 //show actions
                                                                 $("#Bulk_Actions").show();
                                                                 selected();
                                                             }
                                                             else {
                                                                 $("#Bulk_Actions").hide();
                                                                 selected();
                                                             }
                                                         });

                                                         $('.individualCHK').on('click', function () {
                                                             // Check/uncheck all checkboxes in the table
                                                             if ($('.individualCHK').is(':checked')) {

                                                                 //show actions
                                                                 $("#Bulk_Actions").show();
                                                                 selected();
                                                             }
                                                             else {
                                                                 $("#Bulk_Actions").hide();
                                                                 selected();
                                                             }
                                                         });

                                                         // Handle click on checkbox to set state of "Select all" control
                                                         $('#example tbody').on('change', 'input[type="checkbox"]', function () {
                                                             // If checkbox is not checked
                                                             if (!this.checked) {
                                                                 var el = $('#example-select-all').get(0);
                                                                 // If "Select all" control is checked and has 'indeterminate' property
                                                                 if (el && el.checked && ('indeterminate' in el)) {
                                                                     // Set visual state of "Select all" control 
                                                                     // as 'indeterminate'
                                                                     el.indeterminate = true;
                                                                 }
                                                             }                                                             
                                                         });

                                                         function selected() {   
                                                             var form = this;
                                                             var sid = "";
                                                             // Iterate over all checkboxes in the table
                                                             //$.each($('input[type="checkbox"]'), function () {
                                                             table.$('input[type="checkbox"]').each(function () {
                                                                 // If checkbox doesn't exist in DOM                                                                 
                                                                 if ($.contains(document, this)) {
                                                                     // If checkbox is checked                                                                     
                                                                     if (this.checked) {
                                                                         sid += this.value + ',';                                                                         
                                                                     }
                                                                 }
                                                                 if (!$.contains(document, this)) {
                                                                     // If checkbox is checked                                                                     
                                                                     if (this.checked) {
                                                                         sid += this.value + ',';
                                                                     }
                                                                 }
                                                             }); 
                                                             //alert(sid);
                                                             setCookie("sids", sid, "1");                                                           
                                                         }
                                                     });
                                                     function setCookie(cname, cvalue, exdays) {
                                                         //var d = new Date();
                                                         //d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
                                                         //var expires = "expires=" + d.toUTCString();
                                                         //document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
                                                         document.getElementById("hdn_Selected_Sids").value = cvalue;
                                                     }
                                                 </script>
                                 <style>
                                     .dropdown-menu.show{
                                         overflow-y:scroll;
                                         max-height:200px !important;
                                     }
                                 </style>
                                 <asp:HiddenField ID="hdn_Selected_Sids" runat="server" ClientIDMode="Static"/>
                                 

                                          <%--  <script>
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
                                            </script>--%>


                                 <div id="divResult" runat="server" class="table-responsive">
                                     <asp:Repeater ID="RepterDetails" runat="server">
                                         <HeaderTemplate>
                                             <table id='datatabless' class='table table-striped table-bordered' style='width: 100%'>
                                                 <thead>
                                                     <tr class='headings'>
                                                        <%-- <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending">#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">ID</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Name</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Major</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Status</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Actions</th>--%>
                                                         <th><input type="checkbox" name="select_all" value="1" id="example-select-all"></th>
                                                         <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending">#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Student ID</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Course</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Warning Type</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Date</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Published</th>                                                                                                                  
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Actions</th>
                                                     </tr>
                                                 </thead>
                                         </HeaderTemplate>
                                         <ItemTemplate>
                                             <tr>
                                                 <td><input type="checkbox" name="select_all" value='<%#Eval("dateWarning")%>_<%#Eval("strCourse")%>_<%#Eval("lngStudentNumber")%>_<%#Eval("byteWarningType")%>' class="individualCHK"></td>
                                                 <td align='center'><%# Container.ItemIndex+1 %></td>
                                                 <%--<td><%#Eval("lngStudentNumber")%></td>
                                                 <td><%#Eval("strLastDescEn")%></td>
                                                 <td><%#Eval("strCaption")%></td>
                                                 <td><%#Eval("strReasonDesc")%></td>--%>
                                                 <td><%#Eval("lngStudentNumber")%></td>
                                                 <td><%#Eval("strCourse")%></td>
                                                 <td><%#Eval("byteWarningType")%></td>
                                                 <td><%#Eval("dateWarning1")%></td>
                                                 <td><%#Eval("isPublished")%></td>                                                 
                                                 <td>
                                                     <div class="btn-group">
                                                         <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                             Actions
                                                         </button>
                                                         <div class="dropdown-menu">                                                             
                                                             <asp:LinkButton ID="LinkButton1" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure to want to Delete?')" OnClick="LinkButton1_Click" CssClass="dropdown-item" CommandArgument=<%#Eval("dateWarning")%> CommandName=<%#Eval("strCourse")%> ToolTip=<%#Eval("lngStudentNumber")%>></asp:LinkButton>
                                                             <asp:LinkButton ID="LinkButton2" runat="server" Text="Publish" OnClientClick="return confirm('Are you sure to want to Publish?')" OnClick="LinkButton2_Click" CssClass="dropdown-item" CommandArgument=<%#Eval("dateWarning")%> CommandName=<%#Eval("strCourse")%> ToolTip=<%#Eval("lngStudentNumber")%>></asp:LinkButton>
                                                             <asp:LinkButton ID="LinkButton3" runat="server" Text="Convert to Grade" OnClientClick="return confirm('Are you sure to want to Convert to Grade?')" OnClick="LinkButton3_Click" CssClass="dropdown-item" CommandArgument=<%#Eval("dateWarning")%> CommandName=<%#Eval("strCourse")%> ToolTip=<%#Eval("lngStudentNumber")%> ValidationGroup=<%#Eval("byteWarningType")%>></asp:LinkButton>
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
                            
                            <div class="col-md-12" id="Bulk_Actions">
                                <hr />
                                <asp:DropDownList ID="drp_Bulk" runat="server" CssClass="btn btn-secondary btn-sm" ValidationGroup="no1">
                                     <asp:ListItem Text="Bulk Actions" Value="Bulk Actions" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Delete" Value="Delete"></asp:ListItem>
                                    <asp:ListItem Text="Publish" Value="Publish"></asp:ListItem>
                                    <asp:ListItem Text="Convert to Grade" Value="Convert to Grade"></asp:ListItem>                                    
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="drp_Bulk" ErrorMessage="*Select any bulk action" Display="Dynamic" ForeColor="Red" ValidationGroup="no1" InitialValue="Bulk Actions"/>
                                <asp:LinkButton ID="lnk_Execute" runat="server" OnClientClick="return confirm('Are you sure to proceed with this Bulk Operation?')" OnClick="lnk_Execute_Click" CssClass="btn btn-secondary btn-sm"  ValidationGroup="no1"><i class="fa fa-flash"></i> Execute</asp:LinkButton>                              
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <script>
         var table = document.getElementById("datatabless");
         if (table != null) {
             for (var i = 1; i < table.rows.length; i++) {
                 var status = table.rows[i].cells[6].textContent;
                 var warning = table.rows[i].cells[4].textContent;      

                 if (status == "False") {
                     table.rows[i].cells[6].innerHTML = 'No';
                 }
                 else {
                     table.rows[i].cells[6].innerHTML = 'Yes';
                 }
                 if (warning == "1") {
                     table.rows[i].cells[4].innerHTML = 'First Warning';                     
                 }
                 else if (warning == "2") {
                     table.rows[i].cells[4].innerHTML = 'Second Warning';                     
                 }
                 else if (warning == "3") {
                     table.rows[i].cells[4].innerHTML = 'Third Warning';                     
                 }
                 else if (warning == "4") {
                     table.rows[i].cells[4].innerHTML = 'EW';                     
                 }
                 else {
                     table.rows[i].cells[4].innerHTML = '-';                     
                 }
             }
         }
     </script>
            <%--  <style>
                         .badge {
            font-size: 100%;
        }
                   .alert-info1 {
    color: #fff;
    background-color: #2b9ad6;
    border-color: #268ec5;
}
.dashboard-stat.red-intense {
    background-color: #e35b5a;
}
.dashboard-stat {
    display: block;
    margin-bottom: 25px;
    overflow: hidden;
    -webkit-border-radius: 8px;
    -moz-border-radius: 8px;
    -ms-border-radius: 8px;
    -o-border-radius: 8px;
    border-radius: 8px;
}

.dashboard-stat .visual {
    width: 80px;
    height: 80px;
    display: block;
    float: left;
    padding-top: 10px;
    padding-left: 15px;
    margin-bottom: 15px;
    font-size: 35px;
    line-height: 35px;
}
.dashboard-stat .positionchane {
    width: 80px;
    height: 80px;
    display: block;
    float: left;
    padding-top: 10px;
    padding-left: 15px;
    margin-bottom: 15px;
    font-size: 35px;
    line-height: 35px;
}
.dashboard-stat .details {
    position: absolute;
    right: 15px;
    padding-right: 15px;
    color: #FFFFFF;
}
.dashboard-stat .details .number {
    padding-top: 13px;
    text-align: right;
    line-height: 36px;
    letter-spacing: -1px;
    margin-bottom: 0px;
    font-weight: 300;
    font-size: 26px;
    font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
}
.dashboard-stat .details .desc {
    text-align: right;
    font-size: 16px;
    letter-spacing: 0px;
    font-weight: 300;
    font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
}
.fa1 {
    display: inline-block;
    font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
    font-style: normal;
    font-weight: normal;
    line-height: 1;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
}
.dashboard-stat .visual > i {
    margin-left: -35px;
    font-size: 110px;
    line-height: 110px;
}
.dashboard-stat .positionchane > i {
    margin-left: -50px;
    font-size: 40px;
    line-height: 40px;
}
.dashboard-stat.red-intense .positionchane > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.purple-plum .positionchane > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.blue-madison .positionchane > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.red-intense .visual > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.orange_clr {
    background: #EA9852 !important;
}
.dashboard-stat.blue-madison {
    background-color: #578ebe;
}
.dashboard-stat.purple-plum {
    background-color: #73A839;
}
.dashboard-stat.blue-madison .visual > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.purple-plum .visual > i {
    color: #FFFFFF;
    opacity: 0.1;
    filter: alpha(opacity=10);
}
.dashboard-stat.red-intense .more {
    color: #FFFFFF;
    background-color: #e04a49;
}
.dashboard-stat .more {
    clear: both;
    display: block;
    padding: 6px 10px 6px 10px;
    position: relative;
    text-transform: uppercase;
    font-weight: 300;
    font-size: 11px;
    opacity: 0.7;
    filter: alpha(opacity=70);
}
.badge-warning1 {
    color: #212529;
    background-color: #ffff8a;/*light yellow*/
}
.badge-warning2 {
    color: #212529;
    background-color: #f7ca79;/*light orange*/
}
.badge-warning3 {
    color: #212529;
    background-color: #ea6254;/*red*/
}
.badge-warningEW {
    color: red;/*text red bold*/
    font-weight:bold;
}
.badge-success1 {
    color: #212529;
    background-color: #90ee90;/*light green*/
}
    </style>--%>
</asp:Content>
