<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HR_Failure_to_Report_for_Work_on_Time.aspx.cs" Inherits="LocalECT.HR_Failure_to_Report_for_Work_on_Time" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left" style="width: 100%">
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
            $j("#sDate").datepicker({ dateFormat: 'dd/mm/yy' });
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
                                        <th style="text-align: left; padding-left: 10px">Issue: 18/08/2011</th>
                                        <th style="text-align: right;">Revision Date: 23/03/2014</th>
                                        <th style="text-align: right; padding-right: 10px">Ref No.: ECT-HRS-HRSO-FRM.006</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <p style="text-align: center; font-size: 23px; font-weight: bold;"><span>Failure to Report for Work on Time</span></p>
                                        </td>
                                    </tr>
                                </table>

                              
                               
                                  <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b>Service ID</b>
                                        </td>
                                        <td align="center">
                                         <asp:Label ID="lbl_ServiceID" runat="server" Text="1037">1037</asp:Label></td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Service Name</b>
                                        </td>
                                        <td align="center">
                                            <br />
                                            <asp:Label ID="lbl_ServiceName" runat="server" Style="font-size: 13px; font-weight: bold">Failure to Report for Work on Time
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
                                            <asp:Label ID="Lbl_Position" runat="server" Text="Position"></asp:Label>
                                        </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;">
                                            <b>Department</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_Dept" runat="server" Text="Department"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    
                                </table>
                                    <hr />                         
                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                   
                                   <tr>
                                       <td align="center" style="background-color: #f2f2f2;" class="auto-style8" ><b>Date<span style="color: red">*</span></b></td>
                                        <td align="left">
                                            <asp:TextBox ID="sDate" runat="server" CssClass="form-control" Width="200px"  ClientIDMode="Static"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="DateValidator" runat="server" ControlToValidate="sDate" Display="Dynamic" ValidationGroup="no" ErrorMessage="*Date Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
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
                                            <b>Time From<span style="color: red">*</span></b></td>
                                        <td align="left" class="auto-style7">
                                            <asp:TextBox ID="TimeFrom" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="TimeFromValidator" runat="server" ControlToValidate="TimeFrom" Display="Dynamic" ValidationGroup="no" ErrorMessage="*Time From Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                            </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;" class="auto-style7">
                                                <b><span>Time To</span><span style="color: red">*</span></b></td>
                                        <td align="left" class="auto-style7">
                                            <asp:TextBox ID="TimeTo" runat="server" CssClass="form-control"   TextMode="Time"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="TimeToValidator" runat="server" ControlToValidate="TimeTo" Display="Dynamic" ValidationGroup="no" ErrorMessage="*Time To Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                           </td>
                                        
                                    </tr>
                                          <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style6">
                                            <b><span>Total Days/ Hours</span><span style="color: red">*</span></b></td>
                                        <td align="left" class="auto-style7">
                                            <asp:TextBox ID="TotalDays" runat="server" CssClass="form-control" ></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="TotalDaysValidator" runat="server" ControlToValidate="TotalDays" Display="Dynamic" ValidationGroup="no" ErrorMessage="*Total Days/ Hours Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                            </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;" class="auto-style7">
                                                <b><span>Evidence Document Attached</span><span style="color: red">*</span></b></td>
                                        <td align="center" class="auto-style7">
                                            <asp:RadioButtonList ID="EV_Document" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                            </asp:RadioButtonList>
                                           <asp:RequiredFieldValidator ID="EVValidator" runat="server" ControlToValidate="EV_Document" Display="Dynamic" ValidationGroup="no" ErrorMessage="**" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                                                                     
                                    </tr>
                                         
                                     <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <span><b>Explain the Leave Purpose in brief<span style="color: red">*</span></b></span></td>
                                        <td align="center">
                                            <asp:TextBox ID="ExplainBrief" runat="server" TextMode="MultiLine" CssClass="form-control" Height="50px"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ExplainBrief" Display="Dynamic" ValidationGroup="no" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                           </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;">
                                                <b><span>Contact No.: </span><span style="color: red">*</span></b>&nbsp;</td>
                                        <td align="center">
                                            <asp:TextBox ID="ContactNo" runat="server" CssClass="form-control" ></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ContactNo" Display="Dynamic" ValidationGroup="no" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        
                                    </tr>
                                       <tr>
                                         <td align="center" style="background-color: #f2f2f2;"><b>Upload Evidence Document</b></td>
                                         <td align="center">
                                        <asp:FileUpload ID="EvidenceDocumetFile" runat="server" />
                                         </td>
                                       </tr>
                                     <tr>
                                        <td align="center" colspan="4">
                                            <span>I hereby request leave / approved absence from duty as indicated above and certify that such leave / absence is requested for the purpose(s) indicated. I understand that must comply with ECT procedures for requesting this leave / approved absence (and provide additional documentation, if required) and that falsification on this form maybe grounds for disciplinary action, including termination</span></td>
                                        
                                    </tr>
                                     <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span>Signature </span></b></td>
                                        <td align="center">
                                            <asp:TextBox ID="Sig" runat="server" CssClass="form-control" Font-Names="Vladimir Script" Font-Size="Large"></asp:TextBox>
                                            </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;">
                                               
                                                <strong>Application Date</strong><td align="center">
                                            <asp:TextBox ID="tDate" runat="server" CssClass="form-control"  ReadOnly="True"></asp:TextBox>
                                            </td>
                                        
                                    </tr>
                                </table>
                                <br />
                               <asp:HiddenField ID="UserEmail" runat="server" />
                              <asp:HiddenField ID="Approvers" runat="server" />
                               <asp:HiddenField ID="Approvals" runat="server" />
                              
                                <asp:LinkButton ID="lnk_Generate" runat="server" CssClass="btn btn-success btn-sm" ValidationGroup="no" OnClick="lnk_Generate_Click"><i class="fa fa-send"> </i> Generate Request</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

