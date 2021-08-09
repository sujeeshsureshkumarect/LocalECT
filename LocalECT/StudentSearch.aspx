<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentSearch.aspx.cs" Inherits="LocalECT.StudentSearch" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Registration /</a>
                        <a href="StudentSearch">&nbsp;Student Search</a>

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
                            <h2><i class="fa fa-search"></i> Student Search</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <%--<a href="Student_Profile.aspx" class="btn btn-success btn-sm" id="lnk_add" runat="server"><i class="glyphicon glyphicon-plus"></i> Create New Student</a>--%>
                                <asp:LinkButton ID="lnk_add" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_add_Click"><i class="glyphicon glyphicon-plus"></i> Create New Student</asp:LinkButton>
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
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
                                    <label class="col-form-label col-md-3 col-sm-3 ">Search Criteria</label>
                                    <div class="col-md-6 col-sm-6 ">
                                        <asp:DropDownList ID="drp_Criteria" runat="server" CssClass="form-control">
                                            <%--<asp:ListItem Text="Student ID" Value="lngStudentNumber" />
                                            <asp:ListItem Text="Student Name" Value="strLastDescEn" />
                                            <asp:ListItem Text="Phone Number" Value="phone" />
                                            <asp:ListItem Text="ECT Email" Value="ectmail" />--%>
                                            <asp:ListItem Text="Student ID" Value="sNo" />
                                            <asp:ListItem Text="Student Name" Value="sName" />
                                            <asp:ListItem Text="Student Account Number" Value="sAccount" />
                                             <asp:ListItem Text="Major Name" Value="strCaption" />  
                                            <asp:ListItem Text="Phone Number" Value="sPhone1" />  
                                            <asp:ListItem Text="ECT Email" Value="ECTEmail" />   
                                             <asp:ListItem Text="LTR" Value="LTR" /> 
                                             <asp:ListItem Text="Status" Value="Status" /> 
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-md-3 col-sm-3 ">Search Text <span class="required">*</span></label>
                                    <div class="col-md-6 col-sm-6 ">
                                        <asp:DropDownList ID="drp_Type" runat="server" CssClass="form-control" Width="100px">
                                            <asp:ListItem Selected="True" Text="Like" Value="Like"></asp:ListItem>
                                            <asp:ListItem Text="In" Value="In"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txt_Search" runat="server" CssClass="form-control" OnTextChanged="lnk_Search_Click" TextMode="MultiLine" Height="100px" ToolTip="You can add many IDs  or copy from excel column" placeholder="Example:
StudentID1
StudentID2
StudentID3"></asp:TextBox>
                                         <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Search Text Required" ControlToValidate="txt_Search" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
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
                                                 <script>
                                                     $(document).ready(function () {
                                                         $("#Bulk_Actions").hide();
                                                         var table = $('#datatabless').DataTable({
                                                             'columnDefs': [{
                                                                 'targets': 0,
                                                                 'searchable': false,
                                                                 'orderable': false,
                                                                 'className': 'dt-body-center'
                                                                 //'render': function (data, type, full, meta) {
                                                                 //    return '<input type="checkbox" class="individualCHK" name="id[]" value="'
                                                                 //        + $('<div/>').text(data).html() + '">';
                                                                 //}
                                                             }],
                                                             'order': [1, 'asc']
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
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">ID</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Student Name</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Major</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Account No.</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Phone No.</th>                                                         
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Email</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">LTR</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Status</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Actions</th>
                                                     </tr>
                                                 </thead>
                                         </HeaderTemplate>
                                         <ItemTemplate>
                                             <tr>
                                                 <td><input type="checkbox" name="select_all" value=<%#Eval("sNo")%> class="individualCHK"></td>
                                                 <td align='center'><%# Container.ItemIndex+1 %></td>
                                                 <%--<td><%#Eval("lngStudentNumber")%></td>
                                                 <td><%#Eval("strLastDescEn")%></td>
                                                 <td><%#Eval("strCaption")%></td>
                                                 <td><%#Eval("strReasonDesc")%></td>--%>
                                                 <td><%#Eval("sNo")%></td>
                                                 <td><%#Eval("sName")%></td>
                                                 <td><%#Eval("strCaption")%></td>
                                                 <td><%#Eval("sAccount")%></td>
                                                 <td><%#Eval("sPhone1")%></td>
                                                 <td><%#Eval("ECTEmail")%></td>
                                                  <td><%#Eval("LTR")%></td>
                                                  <td><%#Eval("Status")%></td>
                                                 <td>
                                                     <div class="btn-group">
                                                         <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                             Actions
                                                         </button>
                                                         <div class="dropdown-menu">
                                                             <a class="dropdown-item" href="Student_Profile?sid=<%#Eval("sNo")%>&isr=<%#Eval("iSerial")%>">Profile</a>
                                                             <a class="dropdown-item" href="Student_Details?sid=<%#Eval("sNo")%>&sAcc=<%#Eval("sAccount")%>">Details</a>
                                                              <a class="dropdown-item" href="Students_Advising?sid=<%#Eval("sNo")%>">Advising</a>
                                                             <a class="dropdown-item" href="Registration?sid=<%#Eval("sNo")%>">Registration</a>
                                                             <a class="dropdown-item" href="ChangeMajor?sid=<%#Eval("sNo")%>">Change Major</a>
                                                             <a class="dropdown-item" href="Change_Status?sid=<%#Eval("sNo")%>">Change Status</a>
                                                             <a class="dropdown-item" href="CourseCalc?sid=<%#Eval("sNo")%>">Course Calc</a>
                                                             <a class="dropdown-item" href="GradesEdit_Alt?sid=<%#Eval("sNo")%>">Alternative Setup</a>
                                                             <a class="dropdown-item" href="GradesEdit?sid=<%#Eval("sNo")%>">Grades Edit</a>
                                                            <%-- <a class="dropdown-item" href="Transcript.aspx?PreviousTerm">Transcript</a>--%>
                                                             <asp:LinkButton ID="lnk_Transcript_Menu" runat="server" Text="Transcript" OnClick="lnk_Transcript_Menu_Click" CssClass="dropdown-item" CommandArgument=<%#Eval("sNo")%> CommandName=<%#Eval("sName")%>></asp:LinkButton>
                                                             <a class="dropdown-item" href="Student_Service_Requests?sEmail=<%#Eval("ECTEmail")%>">Requested Services</a>
                                                              <a class="dropdown-item" href="Testimonies_Printing?sid=<%#Eval("sNo")%>">Testimonies</a>
                                                             <a class="dropdown-item" href="Attendance_Warning?sid=<%#Eval("sNo")%>">Attendance Warnings</a>
                                                             <asp:LinkButton ID="lnk_Create_ACC" runat="server" Text="Create Account" OnClick="lnk_Create_ACC_Click" CssClass="dropdown-item" CommandArgument=<%#Eval("sNo")%> CommandName=<%#Eval("sName")%> ValidationGroup=<%#Eval("sPhone1")%>></asp:LinkButton>
                                                              <a class="dropdown-item" href="Student_Search_SMSSent?sid=<%#Eval("sNo")%>">SMS</a>
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
                                    <asp:ListItem Text="Change Status" Value="Bulk_SC_Change_Status"></asp:ListItem>
                                    <asp:ListItem Text="Send SMS" Value="Bulk_SC_Send_SMS"></asp:ListItem>
                                    <asp:ListItem Text="Action 3" Value="#"></asp:ListItem>
                                    <asp:ListItem Text="Action 4" Value="#"></asp:ListItem>
                                    <asp:ListItem Text="Action 5" Value="#"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="drp_Bulk" ErrorMessage="*Select any bulk action" Display="Dynamic" ForeColor="Red" ValidationGroup="no1" InitialValue="Bulk Actions"/>
                                <asp:LinkButton ID="lnk_Execute" runat="server" OnClick="lnk_Execute_Click" CssClass="btn btn-secondary btn-sm"  ValidationGroup="no1"><i class="fa fa-flash"></i> Execute</asp:LinkButton>
                              <%--  <div class="btn-group">
                                    <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Bulk Actions
                                    </button>
                                    <div class="dropdown-menu">
                                        <a class="dropdown-item" href="Bulk_SC_Change_Status" id="change_status" target="_blank">Change Status</a>                                      
                                        <a class="dropdown-item" href="#">Action 2</a>
                                        <a class="dropdown-item" href="#">Action 3</a>
                                        <a class="dropdown-item" href="#">Action 4</a>
                                        <a class="dropdown-item" href="#">Action 5</a>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <script>
         var table = document.getElementById("datatable");
         if (table != null) {
             for (var i = 1; i < table.rows.length; i++) {
                 var status = table.rows[i].cells[4].textContent;


                 if (status == "") {
                     table.rows[i].cells[4].innerHTML = 'Active';
                 }                 
             }
         }
     </script>
</asp:Content>
