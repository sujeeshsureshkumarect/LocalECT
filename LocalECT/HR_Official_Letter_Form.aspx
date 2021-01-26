<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HR_Official_Letter_Form.aspx.cs" Inherits="LocalECT.HR_Official_Letter_Form" MasterPageFile="~/LocalECT.Master" %>

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
                                        <th style="text-align: left; padding-left: 10px">Issue: 18/08/2011</th>
                                        <th style="text-align: right;">Revision Date: 23/03/2014</th>
                                        <th style="text-align: right; padding-right: 10px">Ref No.: ECT-HRS-HRSO-FRM.002</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <p style="text-align: center; font-size: 23px; font-weight: bold;">Official Letter Form /
                                                <b><span dir="RTL" lang="AR-SA">طلب خطاب رسمي</span></b></p>
                                        </td>
                                    </tr>
                                </table>

                              
                               
                                  <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b>Service ID</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_ServiceID" runat="server">1033</asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Service Name</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_ServiceNameEn" runat="server" Style="text-transform: capitalize;">طلب خطاب رسمي</asp:Label>
                                            <br />
                                            <asp:Label ID="lbl_ServiceNameAr" runat="server" Style="font-size: 13px; font-weight: bold">Official Letter Form
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
                                            <b><span>Mobile No.</span><span style="color: red">*</span></b></td>
                                        <td align="center">
                                            <asp:TextBox ID="Mobile" runat="server" CssClass="form-control"></asp:TextBox>
                                                                   <asp:RequiredFieldValidator ID="MobileValidator" runat="server" ControlToValidate="Mobile" Display="Dynamic" ValidationGroup="no" ErrorMessage="*Mobile Number Required" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span style="color: red">*</span><span dir="RTL" lang="AR-SA">الهاتف المتحرك</span></b></td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span>Letter Language</span><span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:DropDownList ID="LetterLang" runat="server" CssClass="form-control">
                                                <asp:ListItem>Arabic</asp:ListItem>
                                                <asp:ListItem>English</asp:ListItem>
                                            </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="LetterLangValidator" runat="server" ControlToValidate="LetterLang" Display="Dynamic" ValidationGroup="no" ErrorMessage="*Language Required" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </td>
                                       <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span style="color: red">*</span><span dir="RTL" lang="AR-SA">لغة الرسالة</span><span dir="RTL"> </span> </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span>Purpose</span><span style="color: red">*</span></b></td>
                                        <td align="center">
                                            <asp:TextBox ID="Purpose" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PurposeValidator1" runat="server" ControlToValidate="Purpose" Display="Dynamic" ValidationGroup="no" ErrorMessage="*Purpose Required" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </td>
                                       <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span style="color: red">*</span><span dir="RTL" lang="AR-SA">الغرض من الرسالة</span></b></td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span>To Whom</span><span style="color: red">*</span></b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="ToWhom" runat="server" CssClass="form-control"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="WhomValidator" runat="server" ControlToValidate="ToWhom" Display="Dynamic" ValidationGroup="no" ErrorMessage="*To Whom Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                       <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span style="color: red">*</span><span dir="RTL" lang="AR-SA">الجهة المعنية</span> </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                           <b><span>Date</span> </b>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_Date" runat="server" CssClass="form-control" Height="25px" ClientIDMode="Static"></asp:TextBox>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                           <b><span dir="RTL" lang="AR-SA">التاريخ</span></b>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span>Signature</span></b></td>
                                        <td align="center">
                                            <asp:TextBox ID="Signature" runat="server"  CssClass="form-control" Height="25px" Font-Names="Vladimir Script" Font-Size="Large"></asp:TextBox>
                                        </td>
                                          <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b><span dir="RTL" lang="AR-SA">التوقيع</span></b></td>
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
