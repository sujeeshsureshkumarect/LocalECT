<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HR_Extra_Days_Hours_Form.aspx.cs" Inherits="LocalECT.HR_Extra_Days_Hours_Form" MasterPageFile="~/LocalECT.Master"%>

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
                   
                       
                  
                    .auto-style8 {
                        width: 8%
                    }
                   
                       
                  
                    .auto-style12 {
                        width: 4%
                    }
                    .auto-style13 {
                        width: 30%
                    }
                    .auto-style15 {
                        width: 9%
                    }
                    .auto-style16 {
                        width: 31%
                    }
                   
                       
                  
                </style>
                <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="/resources/demos/style.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script type="text/javascript">
          var $j = jQuery.noConflict();
          $j(function () {
            $j("#Overtime_Date1").datepicker({ dateFormat: 'dd/mm/yy' });
            $j("#Overtime_Date2").datepicker({ dateFormat: 'dd/mm/yy' });
            $j("#Overtime_Date3").datepicker({ dateFormat: 'dd/mm/yy' });
            $j("#Overtime_Date4").datepicker({ dateFormat: 'dd/mm/yy' });
            $j("#Overtime_Date5").datepicker({ dateFormat: 'dd/mm/yy' });
            $j("#Redumption_Date1").datepicker({ dateFormat: 'dd/mm/yy' });
            $j("#Redumption_Date1").datepicker({ dateFormat: 'dd/mm/yy' });
            $j("#Redumption_Date2").datepicker({ dateFormat: 'dd/mm/yy' });
            $j("#Redumption_Date3").datepicker({ dateFormat: 'dd/mm/yy' });
            $j("#Redumption_Date4").datepicker({ dateFormat: 'dd/mm/yy' });
            $j("#Redumption_Date5").datepicker({ dateFormat: 'dd/mm/yy' });
            $j("#Redumption_Date5").datepicker({ dateFormat: 'dd/mm/yy' });

            
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
                                        <th style="text-align: right;">Revision Date: 12/09/2018</th>
                                        <th style="text-align: right; padding-right: 10px">Ref No.: ECT-HRS-HRSO-FRM.027</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <p style="text-align: center; font-size: 23px; font-weight: bold;"> Extra Days/Hours Form/<br />
                                                <b><span dir="RTL" lang="AR-SA">نموذج إضافة رصيد إجازات</span></b></p>
                                        </td>
                                    </tr>
                                </table>

                              
                              
                                  <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b>Service ID</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_ServiceID" runat="server">1052</asp:Label>
                                        </td>
                                        <td align="center" style="background-color: #f2f2f2;">
                                            <b>Service Name</b>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_ServiceNameAr" runat="server" Style="text-transform: capitalize;">نموذج إضافة رصيد إجازات</asp:Label>
                                            <br />
                                            <asp:Label ID="lbl_ServiceNameEn" runat="server" Style="font-size: 13px; font-weight: bold">Extra Days/Hours Form
                                            </asp:Label>
                                        </td>
                                    </tr>
                                   
                                </table>
                                <hr />
                                <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style5">
                                            <b>From</b></td>
                                        <td align="center">
                                            <asp:Label ID="lbl_EmpName" runat="server" Text="From"></asp:Label>
                                        </td>
                                        
                                            <td align="center" style="background-color: #f2f2f2;">
                                            <b>To</b> 
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbl_To" runat="server" Text="Human Resource Department"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    
                                </table>
                                    <hr />                         
                                 <table style="width: 100%; border: 1px solid #e5e5e5" align="center" class="details">
                                    <tr>
                                        <td align="center" style="background-color: #f2f2f2;" class="auto-style8" colspan="2">
                                            <b>Date</b>
                                        </td>
                                        <td align="center" colspan="5">
                                               <asp:Label ID="Today_Date" CssClass="form-control" runat="server"></asp:Label>
                                        </td>
                                      </tr>
                                   <tr>
                                     <td align="center" style="background-color: #f2f2f2;" class="auto-style12"><b>S.No.</b></td>
                                       <td align="center" style="background-color: #f2f2f2;" class="auto-style13"><strong>Name of Employee</strong></td>
                                         <td align="center" style="background-color: #f2f2f2;" class="auto-style15"><strong>Overtime Date</strong></td>
                                           <td align="center" style="background-color: #f2f2f2;" class="auto-style15"><strong>Overtime Time</strong></td>
                                             <td align="center" style="background-color: #f2f2f2;" class="auto-style16"><strong>Overtime Purpose</strong></td>
                                               <td align="center" style="background-color: #f2f2f2;" class="auto-style5"><strong>Redemption Date(s)</strong></td>
                                   </tr>
                                   <tr>
                                     <td align="center" class="auto-style12" ><asp:Label ID="SL1" runat="server">1</asp:Label></td>
                                       <td align="center" class="auto-style13" ><asp:TextBox ID="Employees_Names1" runat="server"  Width="300px"></asp:TextBox></td>
                                         <td align="center" class="auto-style15" ><asp:TextBox ID="Overtime_Date1" runat="server" Width="100px" ClientIDMode="Static"></asp:TextBox></td>
                                           <td align="center" class="auto-style15"><asp:TextBox ID="Overtime_Time1" runat="server"  Width="100px" ></asp:TextBox></td>
                                             <td align="center" class="auto-style16" ><asp:TextBox ID="Overtime_Purpose1" runat="server" Width="300px"></asp:TextBox></td>
                                               <td align="center"><asp:TextBox ID="Redumption_Date1" runat="server" Width="100px" ClientIDMode="Static"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                     <td align="center" class="auto-style12" ><asp:Label ID="SL2" runat="server">2</asp:Label></td>
                                       <td align="center" class="auto-style13" ><asp:TextBox ID="Employees_Names2" runat="server"  Width="300px"></asp:TextBox></td>
                                         <td align="center" class="auto-style15" ><asp:TextBox ID="Overtime_Date2" runat="server"  Width="100px" ClientIDMode="Static"></asp:TextBox></td>
                                           <td align="center" class="auto-style15"><asp:TextBox ID="Overtime_Time2" runat="server"  Width="100px" ></asp:TextBox></td>
                                             <td align="center" class="auto-style16" ><asp:TextBox ID="Overtime_Purpose2" runat="server" Width="300px"></asp:TextBox></td>
                                               <td align="center"><asp:TextBox ID="Redumption_Date2" runat="server" Width="100px"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                     <td align="center" class="auto-style12" ><asp:Label ID="SL3" runat="server">3</asp:Label></td>
                                       <td align="center" class="auto-style13" ><asp:TextBox ID="Employees_Names3" runat="server"  Width="300px"></asp:TextBox></td>
                                         <td align="center" class="auto-style15" ><asp:TextBox ID="Overtime_Date3" runat="server"  Width="100px" ClientIDMode="Static"></asp:TextBox></td>
                                           <td align="center" class="auto-style15"><asp:TextBox ID="Overtime_Time3" runat="server"  Width="100px" ></asp:TextBox></td>
                                             <td align="center" class="auto-style16" ><asp:TextBox ID="Overtime_Purpose3" runat="server" Width="300px"></asp:TextBox></td>
                                               <td align="center"><asp:TextBox ID="Redumption_Date3" runat="server" Width="100px" ClientIDMode="Static"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                     <td align="center" class="auto-style12" ><asp:Label ID="SL4" runat="server">4</asp:Label></td>
                                       <td align="center" class="auto-style13" ><asp:TextBox ID="Employees_Names4" runat="server"  Width="300px"></asp:TextBox></td>
                                         <td align="center" class="auto-style15" ><asp:TextBox ID="Overtime_Date4" runat="server"  Width="100px" ClientIDMode="Static"></asp:TextBox></td>
                                           <td align="center" class="auto-style15"><asp:TextBox ID="Overtime_Time4" runat="server"  Width="100px" ></asp:TextBox></td>
                                             <td align="center" class="auto-style16" ><asp:TextBox ID="Overtime_Purpose4" runat="server" Width="300px"></asp:TextBox></td>
                                               <td align="center"><asp:TextBox ID="Redumption_Date4" runat="server" Width="100px" ClientIDMode="Static"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                     <td align="center" class="auto-style12" ><asp:Label ID="SL5" runat="server">5</asp:Label></td>
                                       <td align="center" class="auto-style13" ><asp:TextBox ID="Employees_Names5" runat="server"  Width="300px"></asp:TextBox></td>
                                         <td align="center" class="auto-style15" ><asp:TextBox ID="Overtime_Date5" runat="server"  Width="100px" ClientIDMode="Static"></asp:TextBox></td>
                                           <td align="center" class="auto-style15"><asp:TextBox ID="Overtime_Time5" runat="server"  Width="100px" ></asp:TextBox></td>
                                             <td align="center" class="auto-style16" ><asp:TextBox ID="Overtime_Purpose5" runat="server" Width="300px"></asp:TextBox></td>
                                               <td align="center"><asp:TextBox ID="Redumption_Date5" runat="server" Width="100px" ClientIDMode="Static"></asp:TextBox></td>
                                   </tr>
                                   </table><br />

                              <br />
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
