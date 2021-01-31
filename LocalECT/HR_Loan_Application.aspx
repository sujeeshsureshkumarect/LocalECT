<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HR_Loan_Application.aspx.cs" Inherits="LocalECT.HR_Loan_Application" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
  </head>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
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
            $j("#txt_Date").datepicker({ dateFormat: 'dd/mm/yy' });
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
                                        <th style="text-align: left; padding-left: 10px">Issue: 11/09/2019</th>
                                        <th style="text-align: right;">Revision Date:</th>
                                        <th style="text-align: right; padding-right: 10px">Ref No.: ECT-HRS-HRSO-FRM.037</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <p style="text-align: center; font-size: 23px; font-weight: bold;">Application Form for a Relocation Loan </p>
                                        </td>
                                    </tr>
                                </table>

                              
                                
                                  <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b>Service ID</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_ServiceID" runat="server">1059</asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Service Name</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_ServiceName" runat="server" Style="font-size: 13px; font-weight: bold">Loan Application
                                            </asp:Label>
                                        </td>
                                    </tr>
                                   
                                </table>
                                <hr />
                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b>Employee ID/No</b>&nbsp; / <b><span dir="RTL" lang="AR-SA">رقم الموظف</span></b></td>
                                        <td align="center">
                                            <asp:Label ID="lbl_EmpID" runat="server" Text="Employee ID/No"></asp:Label>
                                        </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;">
                                            <b>Employee Name</b> /<b><span dir="RTL" lang="AR-SA">الاسم</span><span dir="RTL"> </span></b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_EmpName" runat="server" Text="Employee Name"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    
                                </table>
                                    <hr />                         
                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr id="tdlanguage" runat="server">
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b>Faculty<span class="auto-style6"> *</span></b></td>
                                        <td align="center">
                                            <asp:TextBox ID="Faculty" runat="server" CssClass="form-control"  ></asp:TextBox>
                                                                   <asp:RequiredFieldValidator ID="MobileValidator" runat="server" ControlToValidate="Faculty" Display="Dynamic" ValidationGroup="no" ErrorMessage="**" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b>Relocation Loan Amount Requested (Not exceeding One month salary)<span class="auto-style6"> *</span></b>
                                        </td>
                                        <td align="center">
                                          <asp:TextBox ID="LoanAmount" runat="server" CssClass="form-control" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="LetterLangValidator" runat="server" ControlToValidate="LoanAmount" Display="Dynamic" ValidationGroup="no" ErrorMessage="**" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </td>
                                       
                                    </tr>
                                 
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span>Terms & Conditions *</b></td>
                                        <td class="text-justify" >
                                            <div class="text-center">
                                            <asp:RadioButtonList ID="Agreement" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            </div>
                                          <asp:Label runat="server" ID="Conditions" class="text-left"> 
                                            I agree that this relocation loan to be fully redeemed from my salary on equal 12 installments over one year starting from the next month.
If for any reason the contract between me and ECT is terminated, I’m committed to pay the remaining balance in full. 

                                          </asp:Label>
                                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Agreement" Display="Dynamic" ValidationGroup="no" ErrorMessage="**" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                           <b> Date </b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_Date" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                        </td>
                                       
                                    </tr>
                                    
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span>Signature</span></b></td>
                                        <td align="center">
                                            <asp:TextBox ID="Signature" runat="server"  CssClass="form-control" Height="25px" Font-Names="Vladimir Script" Font-Size="Large"></asp:TextBox>
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
                                </table>
               <asp:HiddenField ID="UserEmail" runat="server" />
                                <asp:HiddenField ID="Approvers" runat="server" />
                                <asp:HiddenField ID="Approvals" runat="server" />
                                <br />
                                <asp:LinkButton ID="lnk_Generate" runat="server" CssClass="btn btn-success btn-sm" ValidationGroup="no" OnClick="lnk_Generate_Click"><i class="fa fa-send"> </i> Generate Request</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
