<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage_Users.aspx.cs" Inherits="LocalECT.Manage_Users" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Security /</a>
                        <a href="Security_Roles">&nbsp;Roles Manager /</a>
                        <a href="#">&nbsp;Manage Role Users</a>

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

                    .style7 {
                        width: 100%;
                    }

                    .style8 {
                        height: 23px;
                    }
                </style>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><i class="fa fa-users"></i> Manage Role Users</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                 <asp:HyperLink ID="RolesBackLNK" runat="server"
                                NavigateUrl="~/Security_Roles.aspx" CssClass="btn btn-success btn-sm"><i class="fa fa-angle-double-left"></i> Back to Roles Manager</asp:HyperLink>
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
                                <div class="col-md-5 col-sm-5">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-user"></i> Users</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                            <div class="input-group">
													  <asp:TextBox ID="UserSerachTXT" runat="server" ToolTip="Enter User Name then Click Search" CssClass="form-control"></asp:TextBox>    
													<span class="input-group-btn">
														<asp:LinkButton ID="SearchCMD" runat="server" OnClick="SearchCMD_Click" CssClass="btn btn-success btn-sm" style="float: right;" ToolTip="Users Search"><i class="fa fa-search"></i></asp:LinkButton>                                                
													</span>
												</div>
                                            <div>
<asp:ListBox ID="UsersLST" runat="server" Width="100%" Height="288px" SelectionMode="Multiple" CssClass="select2_multiple form-control"></asp:ListBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2 col-sm-2" align="center">
                                   
                                    <br /><br />
                                    <asp:LinkButton ID="AddUserCMD" runat="server" OnClick="AddUserCMD_Click" CssClass="btn btn-success btn-sm" ToolTip="Add New User"><i class="fa fa-plus"></i> Add New User</asp:LinkButton>
                                    <br /><br /><br /><br />
                                     <asp:LinkButton ID="AddCMD" runat="server" ToolTip="Add" CssClass="btn btn-success btn-sm" onclick="AddCMD_Click">&nbsp;&nbsp;&nbsp;<i class="fa fa-arrow-right"></i>&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                    <br /><br /><br />
                                     <asp:LinkButton ID="RemoveCMD" runat="server" ToolTip="Remove" CssClass="btn btn-success btn-sm" onclick="RemoveCMD_Click">&nbsp;&nbsp;&nbsp;<i class="fa fa-arrow-left"></i>&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                </div>

                                <div class="col-md-5 col-sm-5">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-user"></i> <asp:Label ID="RoleLBL" runat="server" Text="Role Users" ForeColor="#444444"></asp:Label></h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                            <br />
                                            <br />
                                            <div>
                                                <asp:ListBox ID="RoleUsersLST" runat="server" Height="288px" Width="100%" SelectionMode="Multiple" CssClass="select2_multiple form-control" style="float:right"></asp:ListBox>
                                                </div>
                                        </div>
                                    </div>
                                </div>
                            </div>                       
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <style>

    </style>
</asp:Content>
