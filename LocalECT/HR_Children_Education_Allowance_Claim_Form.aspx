<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HR_Children_Education_Allowance_Claim_Form.aspx.cs" Inherits="LocalECT.HR_Children_Education_Allowance_Claim_Form" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
  <head>
   
   <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
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
                    .auto-style9 {
                        height: 39px;
                        font-weight: bold;
                    }
                    .auto-style10 {
                        height: 39px;
                        width: 25%;
                    }
                    .auto-style11 {
                        color: #CC3300;
                    }
                </style>
               <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="/resources/demos/style.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
      var $j = jQuery.noConflict();
      $j(function () {
        $j("#DOB").datepicker({ dateFormat: 'dd/mm/yy' });
      
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
                                        <th style="text-align: left; padding-left: 10px">Issue: 04/10/2016</th>
                                        <th style="text-align: right;">Revision Date: 12/09/2018</th>
                                        <th style="text-align: right; padding-right: 10px"> <asp:Label runat="server" ID="Lbl_Reference" Text="Ref No.: ECT-HRS-HRSO-FRM.036 "></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <p style="text-align: center; font-size: 23px; font-weight: bold;"><span>Children Education Allowance Claim Form</span></p>
                                        </td>
                                    </tr>
                                </table>

                              
                               
                                  <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b>Service ID</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_ServiceID" runat="server" Text="1032">1058</asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Service Name</b>
                                        </td>
                                        <td align="center">
                                           
                                            <asp:Label ID="lbl_ServiceName" runat="server" Style="font-size: 13px; font-weight: bold">Children Education Allowance Claim
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
                                      
                                        <td align="center" colspan="2">
                                            <asp:Label runat="server">
                                             <b> I hereby apply for the reimbursement of Children Education Allowance for my child. The relevant                   
details are furnished below.</b>

                                            </asp:Label>
                                        </td>
                                    
                                    </tr>
                                  </table> <br />
                              
                                     <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style6">
                                            <b>Name of the Child (in BLOCK letters) <span class="auto-style11">*</span></b></td>
                                        <td align="center" class="auto-style10">
                                            <asp:TextBox ID="ChildName" runat="server" CssClass="form-control"  Placeholder="Name of Child" style='text-transform:uppercase' ></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="Leave_StartDate_Validator" runat="server" ErrorMessage="**" Display="Dynamic" ForeColor="Red" ValidationGroup="no" ControlToValidate="ChildName"></asp:RequiredFieldValidator>
                                            </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;" class="auto-style9">
                                                Date of Birth <span class="auto-style11">*</span></td>
                                        <td align="center" class="auto-style7">
                                            <asp:TextBox ID="DOB" runat="server" CssClass="form-control" ClientIDMode="Static" Placeholder="dd/mm/yyyy" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="Leave_EndDate_Validator" runat="server" ErrorMessage="**" Display="Dynamic" ForeColor="Red" ValidationGroup="no" ControlToValidate="DOB"></asp:RequiredFieldValidator>
                                           </td>
                                        
                                    </tr>
                                     <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span>Name and address of the School in which Studiying </span><span class="auto-style11">*</span></b></td>
                                        <td align="center" class="w-25">
                                            <asp:TextBox ID="SchoolAddress" runat="server" TextMode="MultiLine" CssClass="form-control" Height="50px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="**" Display="Dynamic" ForeColor="Red" ValidationGroup="no" ControlToValidate="SchoolAddress"></asp:RequiredFieldValidator>
                                           </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;">
                                                <b><span>Class in which studying </span><span class="auto-style11">*</span></b>&nbsp;</td>
                                        <td align="center" >
                                            <asp:TextBox ID="Class" runat="server" CssClass="form-control"   placeholder="Class"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="**" Display="Dynamic" ForeColor="Red" ValidationGroup="no" ControlToValidate="Class"></asp:RequiredFieldValidator>

                                            </td>
                                        
                                    </tr>
                                        <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style6">
                                            <b>Total Amount of Children Education Allowance Claimed (AED)<span class="auto-style11"> *</span></b></td>
                                        <td align="center" class="auto-style10">
                                            <asp:TextBox ID="TotalAmount" runat="server" CssClass="form-control"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="**" Display="Dynamic" ForeColor="Red" ValidationGroup="no" ControlToValidate="TotalAmount"></asp:RequiredFieldValidator>
                                            </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;" class="auto-style9" colspan="2">
                                                &nbsp;</td>
                                                                            </tr>
                                       <tr>
                                         <td colspan="4" class="text-justify">

                                             <span><b>Certified that my Husband/Wife Mr. /Ms. *</b>&nbsp; <asp:TextBox runat="server" ID="Partner"  Height="25px" Width="200px"  BorderColor="LightGrey"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="**" ForeColor="#CC3300" ValidationGroup="no" ControlToValidate="Partner"></asp:RequiredFieldValidator>&nbsp;<b> is presently working as</b>&nbsp; <asp:TextBox runat="server" ID="PartnerDesignation"  Height="25px" Width="150px" BorderColor="LightGrey"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="**" ForeColor="#CC3300" ValidationGroup="no" ControlToValidate="PartnerDesignation"></asp:RequiredFieldValidator>&nbsp; </span><b>in</b> <span> <asp:TextBox runat="server" ID="PartnerCompany"  Height="25px" Width="150px" BorderColor="LightGrey"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="**" ForeColor="#CC3300" ValidationGroup="no" ControlToValidate="PartnerCompany"></asp:RequiredFieldValidator>&nbsp;<br /><b>and that he/she will not apply/ has not applied for the Children Education Allowance for the child mentioned above.</b></span>

                                         </td>
                                          <tr>
                                         <td colspan="4" class="text-justify">
                                           <asp:Label runat="server" ID="Terms" >
                                             <b>The particulars/information furnished above is complete and correct and I have not suppressed any relevant information.  In the event of any change in the particulars given above which affect my eligibility for reimbursement of Children Education Allowance, I undertake to intimate the same promptly and also to refund excess payments, if any made.  Further I am aware that if at any stage the information/documents furnished above is found to be false I am liable for disciplinary action.</b>

                                           </asp:Label>
                                            
                                         </td>
                                       </tr>
                                       </tr>
                                     <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span>Signature </span></b></td>
                                        <td align="center" class="w-25">
                                            <asp:TextBox ID="Sig" runat="server" CssClass="form-control"  Font-Names="Vladimir Script" Font-Size="Large"></asp:TextBox>
                                            </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;">
                                               
                                               <b> Date</b><td align="justify">
                                           <asp:Label ID="Today_Date" CssClass="form-control" runat="server" ></asp:Label>

                                                           </td>
                                        
                                    </tr>
                                       <tr>
                                         <td align="center" style="background-color: #f2f2f2;"><b>Upload Document</b></td>
                                         <td class="w-25">
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
