<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkedIn_frmGetDataFromAPI.aspx.cs" Inherits="LocalECT.LinkedIn_frmGetDataFromAPI" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="LinkedIn_frmGetDataFromAPI">&nbsp;LinkedIn Activity Report /</a>                        

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
                                            <h2><i class="fa fa-dashboard"></i> LinkedIn Activity Report</h2>
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

                                    <div class="alert alert-success alert-dismissible " role="alert" runat="server" id="div_Alert">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">×</span>
                                        </button>
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Service Updated Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                                            <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="/resources/demos/style.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
      var $j = jQuery.noConflict();
      $j(function () {
          $j("#txt_StartDate").datepicker({ dateFormat: 'dd/mm/yy' });
          $j("#txt_EndDate").datepicker({ dateFormat: 'dd/mm/yy' });
      });
        </script>
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
                                            <div class="col-md-12 col-sm-12">
                                                <div class="col-md-3 col-sm-3">
                                                    <div class="form-group ">
                                                        <label>Start Date *</label>
                                                        <asp:TextBox ID="txt_StartDate" runat="server" CssClass="form-control" ClientIDMode="Static" Placeholder="dd/mm/yyyy"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Start Date Required" ControlToValidate="txt_StartDate" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-3 col-sm-3">
                                                    <div class="form-group ">
                                                        <label>End Date *</label>
                                                        <asp:TextBox ID="txt_EndDate" runat="server" CssClass="form-control" ClientIDMode="Static" Placeholder="dd/mm/yyyy"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*End Date Required" ControlToValidate="txt_EndDate" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-sm-4">
                                                    <div class="form-group ">
                                                       <br />
                                                        <asp:LinkButton ID="lnk_Get" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_Get_Click"><i class="fa fa-download"></i> Get Employee Activity Report</asp:LinkButton>
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
                                                         //$('#example-select-all').on('click', function () {
                                                         //    // Check/uncheck all checkboxes in the table
                                                         //    var rows = table.rows({ 'search': 'applied' }).nodes();
                                                         //    $('input[type="checkbox"]', rows).prop('checked', this.checked);
                                                         //    if ($('#example-select-all').is(':checked')) {
                                                         //        //all selected
                                                         //        //alert("all");
                                                         //        //show actions
                                                         //        $("#Bulk_Actions").show();
                                                         //        selected();
                                                         //    }
                                                         //    else {
                                                         //        $("#Bulk_Actions").hide();
                                                         //        selected();
                                                         //    }
                                                         //});

                                                         //$('.individualCHK').on('click', function () {
                                                         //    // Check/uncheck all checkboxes in the table
                                                         //    if ($('.individualCHK').is(':checked')) {

                                                         //        //show actions
                                                         //        $("#Bulk_Actions").show();
                                                         //        selected();
                                                         //    }
                                                         //    else {
                                                         //        $("#Bulk_Actions").hide();
                                                         //        selected();
                                                         //    }
                                                         //});

                                                         // Handle click on checkbox to set state of "Select all" control
                                                         //$('#example tbody').on('change', 'input[type="checkbox"]', function () {
                                                         //    // If checkbox is not checked
                                                         //    if (!this.checked) {
                                                         //        var el = $('#example-select-all').get(0);
                                                         //        // If "Select all" control is checked and has 'indeterminate' property
                                                         //        if (el && el.checked && ('indeterminate' in el)) {
                                                         //            // Set visual state of "Select all" control 
                                                         //            // as 'indeterminate'
                                                         //            el.indeterminate = true;
                                                         //        }
                                                         //    }                                                             
                                                         //});

                                                         //function selected() {   
                                                         //    var form = this;
                                                         //    var sid = "";
                                                         //    // Iterate over all checkboxes in the table
                                                         //    //$.each($('input[type="checkbox"]'), function () {
                                                         //    table.$('input[type="checkbox"]').each(function () {
                                                         //        // If checkbox doesn't exist in DOM                                                                 
                                                         //        if ($.contains(document, this)) {
                                                         //            // If checkbox is checked                                                                     
                                                         //            if (this.checked) {
                                                         //                sid += this.value + ',';                                                                         
                                                         //            }
                                                         //        }
                                                         //        if (!$.contains(document, this)) {
                                                         //            // If checkbox is checked                                                                     
                                                         //            if (this.checked) {
                                                         //                sid += this.value + ',';
                                                         //            }
                                                         //        }
                                                         //    }); 
                                                         //    //alert(sid);
                                                         //    setCookie("sids", sid, "1");                                                           
                                                         //}
                                                     });
                                                     //function setCookie(cname, cvalue, exdays) {
                                                     //    //var d = new Date();
                                                     //    //d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
                                                     //    //var expires = "expires=" + d.toUTCString();
                                                     //    //document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
                                                     //    document.getElementById("hdn_Selected_Sids").value = cvalue;
                                                     //}
                                                 </script>
                                 <%--<style>
                                     .dropdown-menu.show{
                                         overflow-y:scroll;
                                         max-height:200px !important;
                                     }
                                 </style>--%>
                                 <%--<asp:HiddenField ID="hdn_Selected_Sids" runat="server" ClientIDMode="Static"/>--%>
                                 

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
                                                         <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending">#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Department</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Section</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Employee ID</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Employee Name</th>                                                                                                                                                                                                                                 
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Email</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Course ID</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Course Title</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Job ID</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Job Title</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Engagement Type</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Engagement Value</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">First View Date</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Last Engaged Date</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Is Active</th>
                                                     </tr>
                                                 </thead>
                                         </HeaderTemplate>
                                         <ItemTemplate>
                                             <tr>                                                 
                                                 <td align='center'><%# Container.ItemIndex+1 %></td>                                                
                                                 <td><%#Eval("DepartmentDesc")%></td>
                                                 <td><%#Eval("Section")%></td>
                                                 <td><%#Eval("EmployeeID")%></td>
                                                 <td><%#Eval("EmployeeDisplayName")%></td>                                                     
                                                 <td><%#Eval("InternalEmail")%></td>
                                                 <td><%#Eval("CourseID")%></td>
                                                 <td><%#Eval("CourseTitle")%></td>
                                                 <td><%#Eval("JobID")%></td> 
                                                 <td><%#Eval("JobTitleEn")%></td>
                                                 <td><%#Eval("sEngagmentType")%></td>
                                                 <td><%#Eval("iEngagmentValue")%></td>
                                                 <td><%#Eval("FirstViewDate")%></td> 
                                                 <td><%#Eval("LastEngagedCompletedDate")%></td>
                                                 <td><%#Eval("IsActive")%></td> 
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
    </asp:Content>