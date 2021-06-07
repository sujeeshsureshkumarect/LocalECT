<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Department_Manage_Sections.aspx.cs" Inherits="LocalECT.Strategy_Department_Manage_Sections" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                   <%-- <h3><i class="fa fa-globe"></i> Link Manager</h3>--%>
                                </div>
                                <style>
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
                                            <h2><i class="fa fa-edit"></i> Manage Sections</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                  
                                            <div class="col-md-5 col-sm-5">
                                                <div class="x_panel">
                                                    <div class="x_title">
                                                        <h2>Sections</h2>
                                                        <ul class="nav navbar-right panel_toolbox">
                                                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                            </li>
                                                        </ul>
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <div class="x_content">
                                                         <asp:ListBox ID="PermissionsLST" runat="server" Width="100%" Height="288px" 
                    SelectionMode="Multiple" CssClass="select2_multiple form-control"></asp:ListBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-2 col-sm-2" align="center">
                                                <div class="x_panel">
                                                    <div class="x_content">
                                                        <br /><br /><br /><br />
                                     <asp:LinkButton ID="AddPermissionCMD" runat="server" ToolTip="Add" CssClass="btn btn-success btn-sm" OnClick="AddPermissionCMD_Click">&nbsp;&nbsp;&nbsp;<i class="fa fa-arrow-right"></i>&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                    <br /><br /><br />
                                     <asp:LinkButton ID="RemovePermissionCMD" runat="server" ToolTip="Remove" CssClass="btn btn-success btn-sm" OnClick="RemovePermissionCMD_Click">&nbsp;&nbsp;&nbsp;<i class="fa fa-arrow-left"></i>&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-5 col-sm-5">
                                                <div class="x_panel">
                                                    <div class="x_title">
                                                        <h2>Sections in the Department</h2>
                                                        <ul class="nav navbar-right panel_toolbox">
                                                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                            </li>
                                                        </ul>
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <div class="x_content">
                                                        <asp:ListBox ID="ObjPermissionLST" runat="server" Width="100%" Height="288px" 
                    SelectionMode="Multiple" CssClass="select2_multiple form-control"></asp:ListBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>