<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePrivileges.aspx.cs" Inherits="LocalECT.ManagePrivileges" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Security /</a>
                        <a href="Security_Objects">&nbsp;Maps Manager /</a>
                        <a href="#">&nbsp;Manage Objects Privileges</a>
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
                     .style7
        {
            width: 100%;
        }
        .style8
        {
            height: 23px;
            text-align: center;
        }
                </style>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><i class="fa fa-cog"></i> Manage Objects Privileges</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                 <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/Security_Objects.aspx"  CssClass="btn btn-success btn-sm"><i class="fa fa-angle-double-left"></i> Back to Maps Manager</asp:HyperLink>
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
                             <div class="row">
                                 <div class="x_panel">
                           <table class="style7">      
<%--        <tr>
            <td colspan="3" class="style8">
                <div id="divMsg" runat="server" align="center" class="NoData"></div></td>
        </tr>--%>
      <%--  <tr>
            <td colspan="3" class="style8">
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/Security_Objects.aspx"  CssClass="btn btn-success btn-sm"><i class="fa fa-angle-double-left"></i> Back to Maps Manager</asp:HyperLink>
            </td>
        </tr>--%>
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" Text="Privileges" 
                    style="font-weight: 700"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td align="center">
                <asp:Label ID="ObjectLBL" runat="server" Text="Object Privileges" 
                    style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" rowspan="5" valign="top">
                <asp:ListBox ID="PrivilegesLST" runat="server" Width="300px" Height="288px" 
                    SelectionMode="Multiple" ForeColor="#444444" CssClass="select2_multiple form-control"></asp:ListBox>
            </td>
            <td>
                &nbsp;</td>
            <td align="center" rowspan="5" valign="top">
                <asp:ListBox ID="ObjectPrivilegesLST" runat="server" Height="288px" 
                    Width="300px" SelectionMode="Multiple" ForeColor="#444444" CssClass="select2_multiple form-control"></asp:ListBox>
            </td>
        </tr>
         <tr>
            <td align="center" valign="middle">                        
                <asp:LinkButton ID="AddCMD" runat="server" ToolTip="Add" CssClass="btn btn-success btn-sm" onclick="AddCMD_Click">&nbsp;&nbsp;&nbsp;<i class="fa fa-arrow-right"></i>&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                        </td>
        </tr>
         <tr>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td align="center" valign="middle">                      
                 <asp:LinkButton ID="RemoveCMD" runat="server" ToolTip="Remove" CssClass="btn btn-success btn-sm" onclick="RemoveCMD_Click">&nbsp;&nbsp;&nbsp;<i class="fa fa-arrow-left"></i>&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                        </td>
        </tr>
         <tr>
            <td>
                </td>
        </tr>
    </table>
                                     </div>
                                 </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
