<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HR_LeaveApplication.aspx.cs" Inherits="LocalECT.HR_LeaveApplication" MasterPageFile="~/LocalECT.Master" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
  <head>
   
 
  </head>
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3></h3>
                </div>
                <style>
                    .page-title .title_left {
                        width: 100%;
                        float: left;
                        display: block;
                    }
                </style>
                <style>
                    .details {
                        /* font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;*/
                        border-collapse: collapse;
                        width: 100%;
                    }

                    td {
                        width: 25%;
                    }

                    .details td, .details th {
                        border: 1px solid #ddd;
                        padding: 5px;
                    }

                    /*#details tr:nth-child(even){background-color: #f2f2f2;}

#details tr:hover {background-color: #ddd;}*/

                    .details th {
                        padding-top: 12px;
                        padding-bottom: 12px;
                        text-align: left;
                        background-color: #4CAF50;
                        color: white;
                    }
                    .auto-style5 {
                        width: 24%
                    }
                    .auto-style6 {
                        width: 24%;
                        height: 39px;
                    }
                    .auto-style7 {
                        height: 39px;
                    }
                    .auto-style8 {
                        width: 8%
                    }
                </style>
               <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="/resources/demos/style.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
      var $j = jQuery.noConflict();
      $j(function () {
        $j("#Leave_StartDate").datepicker({ dateFormat: 'dd/mm/yy' });
        $j("#Leave_EndDate").datepicker({ dateFormat: 'dd/mm/yy' });
      });
        </script>
               
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2></h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <div id="form" align="center">

                                <div class="x_content bs-example-popovers" id="div_msg" runat="server" visible="false">

                                    <div class="alert alert-success alert-dismissible " role="alert" runat="server" id="div_Alert">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">×</span>
                                        </button>
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Request Generated Successfully" Visible="false" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>

                                <table style="width: 100%">
                                    <tr>
                                        <th style="text-align: left; padding-left: 10px">Issue: 19/05/2013</th>
                                        <th style="text-align: right;">Revision Date: 12/09/2018</th>
                                        <th style="text-align: right; padding-right: 10px"> <asp:Label runat="server" ID="Lbl_Reference" Text="Ref No.: ECT-HRS-HRSO-FRM.001 "></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <p style="text-align: center; font-size: 23px; font-weight: bold;">Leave Application</p>
                                        </td>
                                    </tr>
                                </table>

                              
                              
                                  <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b>Service ID</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_ServiceID" runat="server" Text="1032">1032</asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Service Name</b>
                                        </td>
                                        <td align="center">
                                           
                                            <asp:Label ID="lbl_ServiceName" runat="server" Style="font-size: 13px; font-weight: bold">Leave Application Form
                                            </asp:Label>
                                        </td>
                                    </tr>
                                   
                                </table>
                                <hr />
                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style6">
                                            <b>Employee ID/No</b></td>
                                        <td align="center" class="auto-style7">
                                            <asp:Label ID="lbl_EmpID" runat="server" Text="Employee ID/No"></asp:Label>
                                        </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;" class="auto-style7">
                                            <b>Employee Name</b> 
                                        </td>
                                        <td align="center" class="auto-style7">
                                            <asp:Label ID="lbl_EmpName" runat="server" Text="Employee Name"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                     <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b>Position</b></td>
                                        <td align="center">
                                            <asp:Label ID="Lbl_Position" runat="server" ></asp:Label>
                                        </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;">
                                            <b>Department</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_Dept" runat="server" ></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    
                                </table>
                                    <hr />                         
                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr id="tdlanguage" runat="server">
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style8">
                                            <b>Leave Type</b></td>
                                        <td align="center">
                                            <asp:RadioButtonList ID="LeaveType" runat="server"   >
                                                <asp:ListItem> Annual Leave</asp:ListItem>
                                                <asp:ListItem> Short Leave (one day or more) </asp:ListItem>
                                                <asp:ListItem> Maternity Leave</asp:ListItem>
                                                <asp:ListItem> Sick Leave (all sick leave applications should be supported with medical certificate, even if it’s one day)</asp:ListItem>
                                                <asp:ListItem> Compassionate Leave ( shall be supported with death certificate upon submission of Duty Resumption Form)</asp:ListItem>
                                                <asp:ListItem> Unauthorized Absence (leave without prior approval from line manager)</asp:ListItem>
                                                <asp:ListItem> Unpaid Leave (leave without pay is granted only in case the employee has fully utilized the annual leave entitlement)</asp:ListItem>
                                                <asp:ListItem> Others (Please specify: </asp:ListItem>
                                            </asp:RadioButtonList>
<asp:RequiredFieldValidator ID="LeaveTypeValidator1" runat="server" ErrorMessage="Please select leave type" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="no" ControlToValidate="LeaveType"></asp:RequiredFieldValidator>
                                        </td>
                                    
                                    </tr>
                                   <tr>
                                       <td align="center" style="background-color: #f2f2f2;" class="auto-style8" ><b>If others, Please specify</b></td>
                                        <td align="center">
                                            <asp:TextBox ID="Leave_Specify" runat="server" TextMode="MultiLine" CssClass="form-control" Height="35px"></asp:TextBox>
                                       </td>
                                   </tr>
                                   <%-- <tr>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Proof of Payment</b><br />
                                           
                                        </td>
                                        <td align="center">
                                            <asp:FileUpload ID="flp_Upload" runat="server"/>
                                            <br /> <small style="color:red;">(Only .pdf, .jpg and .png files are allowed / يُسمح فقط بملفات pdf و jpg و png)</small>                                                                                      
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>إثبات دفع</b><br />                                            
                                        </td>
                                    </tr>--%>
                                </table> <br />
                                     <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style6">
                                            <b>Leave Starts on</b></td>
                                        <td align="center" class="auto-style7">
                                            <asp:TextBox ID="Leave_StartDate" runat="server" CssClass="form-control"   Placeholder="dd/mm/yyyy" ClientIDMode="Static"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="Leave_StartDate_Validator" runat="server" ErrorMessage="Please select leave start date" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="no" ControlToValidate="Leave_StartDate"></asp:RequiredFieldValidator>
                                            </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;" class="auto-style7">
                                                <b><span>Leave ends on</span></b> 
                                        </td>
                                        <td align="center" class="auto-style7">
                                            <asp:TextBox ID="Leave_EndDate" runat="server" CssClass="form-control"   ClientIDMode="Static" Placeholder="dd/mm/yyyy" OnTextChanged="Leave_EndDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="Leave_EndDate_Validator" runat="server" ErrorMessage="Please select leave end date" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="no" ControlToValidate="Leave_EndDate"></asp:RequiredFieldValidator>
                                           </td>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style6"><b>No of Days</b></td>
                                        <td><asp:Label runat="server" ID="Total_Days" CssClass="form-control"  ></asp:Label></td>
                                    </tr>
                                     <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span>Contact address while on leave: </span></b></td>
                                        <td align="center">
                                            <asp:TextBox ID="ContactOnLeave" runat="server" TextMode="MultiLine" CssClass="form-control" Height="50px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please  enter address while on leave" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="no" ControlToValidate="ContactOnLeave"></asp:RequiredFieldValidator>
                                           </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;">
                                                <b><span>Contact No.: </span></b>&nbsp;</td>
                                        <td align="center" colspan="3">
                                            <asp:TextBox ID="ContactNo" runat="server" CssClass="form-control" TextMode="Phone" placeholder="0505005500"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please  enter mobile no" Display="Dynamic" ForeColor="#CC3300" ValidationGroup="no" ControlToValidate="ContactNo"></asp:RequiredFieldValidator>

                                            </td>
                                        
                                    </tr>
                                     <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span>Signature </span></b></td>
                                        <td align="center">
                                            <asp:TextBox ID="Sig" runat="server" CssClass="form-control"  Font-Names="Vladimir Script" Font-Size="Large"></asp:TextBox>
                                            </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;">
                                               
                                               <b> Date</b><td align="center" colspan="3">
                                           <asp:Label ID="Today_Date" CssClass="form-control" runat="server" ></asp:Label>

                                                           </td>
                                        
                                    </tr>
                                       <tr>
                                         <td align="center" style="background-color: #f2f2f2;"><b>Upload Document</b></td>
                                         <td>
                                        <asp:FileUpload ID="EvidenceDocumetFile" runat="server" />
                                         </td>
                                       </tr>
                                </table>
                                <asp:HiddenField ID="UserEmail" runat="server" />
                                <br />
                                <asp:HiddenField ID="Approvers" runat="server" />
                              <asp:HiddenField ID="Approvals" runat="server" />
                                <asp:LinkButton ID="lnk_Generate" runat="server" CssClass="btn btn-success btn-sm" ValidationGroup="no" OnClick="lnk_Generate_Click" ><i class="fa fa-send"> </i> Generate Request</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
