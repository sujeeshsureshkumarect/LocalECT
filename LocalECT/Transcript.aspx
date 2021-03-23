<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transcript.aspx.cs" Inherits="LocalECT.Transcript" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="Includes/jQuery/jquery-1.4.1.min.js" type="text/javascript"></script>
    <!-- Sexy error includes -->
    <script src="Includes/jQuery/sexy-alert-box-1.2.2/jquery.easing.1.3.js" type="text/javascript"></script>
    <script src="Includes/jQuery/sexy-alert-box-1.2.2/sexyalertbox.v1.2.jquery.js" type="text/javascript"></script>
    <link href="Includes/jQuery/sexy-alert-box-1.2.2/sexyalertbox.css" rel="stylesheet" media="all" type="text/css" />
    <!-- end of sexy error includes -->
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                                  <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Registration /</a>
                        <a href="StudentSearch">&nbsp;Student Search /</a>
                        <a href="#">&nbsp;Student Advising /</a>
                        <a href="#">&nbsp;Student Transcript</a>
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
                                     .table {
                        color: #444444;
                    }
                    table{
                        border: 1px solid #dee2e6
                    }
                      #ContentPlaceHolder1_tblDetail  th, td {
  padding-bottom: 7px;
  padding-top: 7px;
}
                                </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-dashboard"></i> Student Transcript</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <a href="StudentSearch.aspx" class="btn btn-success btn-sm"><i class="fa fa-search"></i> Student Search</a>
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
                                            <div class="x_panel" id="student_Details">
                                                  <div id="divPlan" runat="server">
                                                </div>
                                                </div>

                                            <div class="x_panel" style="background:#f7f7f7">
                                                 
                                                <div class="col-md-6">
                                                     <table width="100%">
        <tr>
            <td colspan="4" >
            <div id="divMsg" runat="server" class="NoData"></div>
            </td>
        </tr>
      <%--  <tr>
            <th class="PageTitle" colspan="4">
                        Transcript</th>
        </tr>--%>
       <%-- <tr>--%>
          <%--  <td width="120">
                                         <asp:Label ID="Label18" runat="server" Text="Campus :" 
                            Width="100px" style="margin-bottom: 0px"></asp:Label>
                                     </td>--%>
          <%--  <td colspan="3">
                                         <asp:DropDownList ID="Campus_ddl" runat="server" Width="120px" 
                                             AutoPostBack="True">
                                             <asp:ListItem Value="1">Males</asp:ListItem>
                                             <asp:ListItem Selected="True" Value="2">Females</asp:ListItem>
                                             <asp:ListItem Value="3">Media Males</asp:ListItem>
                                             <asp:ListItem Value="4">Media Females</asp:ListItem>
                                         </asp:DropDownList>
                                     </td>--%>
        <%--</tr>--%>
        <tr>
            <td>
                                         <asp:Label ID="Label3" runat="server" Text="Term :"></asp:Label>
                                     </td>
            <td>
                                         <asp:DropDownList ID="Term_ddl" runat="server" CssClass="form-control">
                                         </asp:DropDownList>
                <asp:CheckBox ID="isCurrent_chk" runat="server" Text="Current Term" 
                                             Checked="True"/>
                                         
                                     </td>
            <td > &nbsp;
                                        </td>
            <td>
                                         &nbsp;</td>
        </tr>
        <%--<tr>
            <td>
                &nbsp;</td>
            <td colspan="3">
                                         &nbsp;</td>
        </tr>--%>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="3">
                                         <asp:CheckBox ID="chkPrintAllStudents" runat="server" 
                        Text="Print All Students" />
                    </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPath" runat="server" Text="Path:"></asp:Label>
                                     </td>
            <td colspan="3">
                <asp:TextBox ID="Path_txt" runat="server"  CssClass="form-control"></asp:TextBox>
                    </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="3">
                <asp:Label ID="lblProgress" runat="server" Text="Progress" 
                        style="text-align: center"></asp:Label>
                    </td>
        </tr>
       <%-- <tr>
            <td>
                &nbsp;</td>
            <td colspan="3">
                   
                    </td>
        </tr>--%>
       <%-- <tr>
            <td >
                    
            </td>
            <td align="right" colspan="3">&nbsp;</td>
        </tr>--%>
       <%-- <tr>
            <td colspan="4">
                <hr /></td>
        </tr>--%>
        <tr>
            <td colspan="4">
                        <div id="divDetail" runat="server" ></div></td>
        </tr>
       <%-- <tr>
            <td colspan="4">
                <hr /></td>
        </tr>--%>       
    </table>
                                                </div>
                                                <div class="col-md-6">
 <asp:RadioButton ID="Trans_rbn" runat="server" GroupName="Type" 
                                    Text="Transcript" AutoPostBack="True" 
                                    oncheckedchanged="Trans_rbn_CheckedChanged" />
                                <asp:RadioButton ID="Sheet_rbn" runat="server" Checked="True" GroupName="Type" 
                                    Text="Mark Sheet" AutoPostBack="True" 
                                    oncheckedchanged="Sheet_rbn_CheckedChanged" />
                            &nbsp;&nbsp;
                                <asp:CheckBox ID="chkLogo" runat="server" Checked="True" Text="Show Logo" />
                                <asp:CheckBox ID="chkSign" runat="server" Text="Show Signatures" 
                                    Enabled="False" Visible="False" />
                                                    <br />
                                                    <asp:LinkButton ID="Print_btn" runat="server" 
                                     ToolTip="Print" 
                                    onclick="PrintCMD_Click" CssClass="btn btn-success btn-sm"><i class="fa fa-print"></i> Print</asp:LinkButton>
                                                </div>

                                                 <asp:HiddenField ID="sSelectedValue" runat="server" />
                    <asp:HiddenField ID="sSelectedText" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>