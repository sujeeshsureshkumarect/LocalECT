<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePermissions.aspx.cs" Inherits="LocalECT.ManagePermissions" MasterPageFile="~/LocalECT.Master" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Setting /</a>
                        <a href="Security_Roles">&nbsp;Roles Manager /</a>
                        <a href="#">&nbsp;Manage Permissions</a>
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
                </style>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><i class="fa fa-dashboard"></i> Permissions Manager</h2>                           
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
                        <asp:HiddenField ID="HiddenScrollTop" runat="server" Value="0" ClientIDMode="Static"/>
                        <asp:HiddenField ID="HiddenScrollTop1" runat="server" Value="0" ClientIDMode="Static"/>
                        <script src="https://code.jquery.com/jquery-1.11.0.min.js"></script>                         
                         <script>
                             $(function () {
                                 //recover the scroll postion                                 
                                 if ($("#HiddenScrollTop").val() > 0) {
                                     $("#ContentPlaceHolder1_divTree").scrollTop($("#HiddenScrollTop").val());
                                 }
                                 if ($("#HiddenScrollTop1").val() > 0) {
                                     $("#ContentPlaceHolder1_divTree0").scrollTop($("#HiddenScrollTop1").val());
                                 }

                             })
                             $(function () {
                                 //save the scroll position
                                 $("#ContentPlaceHolder1_divTree").scroll(function () {
                                     $("#HiddenScrollTop").val($(this).scrollTop());
                                 });
                                 $("#ContentPlaceHolder1_divTree0").scroll(function () {
                                     $("#HiddenScrollTop1").val($(this).scrollTop());
                                 });
                             })
                         </script>

                        <div class="x_content">   
                            <div id="divHeader" runat="server"                     
                    style="color: #444444;  text-transform: capitalize; font-size: large;" 
                    align="center"></div>

                             <div class="x_content bs-example-popovers" id="div_msg" runat="server" visible="false">
                                <div class="alert alert-danger alert-dismissible" role="alert" runat="server" id="div_Alert">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <asp:Label ID="lbl_Msg" runat="server" Text="" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_content">
                                            <div class="col-md-5 col-sm-5">
                                                <div class="x_panel">
                                                    <div class="x_title">
                                                        <h2>System Map</h2>
                                                        <ul class="nav navbar-right panel_toolbox">
                                                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                            </li>
                                                        </ul>
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <div class="x_content">
                                                        <div id="divTree" runat="server" style="height:400px;overflow:scroll;">
                    <asp:TreeView ID="myTree" runat="server" 
                        onselectednodechanged="myTree_SelectedNodeChanged" ShowLines="True" 
                        Width="372px">
                       <%-- <SelectedNodeStyle BackColor="#84A5D6" ForeColor="White" />--%>
                         <SelectedNodeStyle CssClass="btn btn-success btn-sm" />
                    </asp:TreeView>
                </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-2 col-sm-2" align="center">
                                                <div class="x_panel">
                                                    <div class="x_content">
                                                         <br /><br /><br /><br />
                                     <asp:LinkButton ID="AddObjCMD" runat="server" ToolTip="Add" CssClass="btn btn-success btn-sm" onclick="AddObjCMD_Click">&nbsp;&nbsp;&nbsp;<i class="fa fa-arrow-right"></i>&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                    <br /><br /><br />
                                     <asp:LinkButton ID="RemoveObjCMD" runat="server" ToolTip="Remove" CssClass="btn btn-success btn-sm" onclick="RemoveObjCMD_Click">&nbsp;&nbsp;&nbsp;<i class="fa fa-arrow-left"></i>&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-5 col-sm-5">
                                                <div class="x_panel">
                                                    <div class="x_title">
                                                        <h2>Role Map</h2>
                                                        <ul class="nav navbar-right panel_toolbox">
                                                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                            </li>
                                                        </ul>
                                                        <div class="clearfix"></div>
                                                    </div>
                                                    <div class="x_content">
                                                        <div id="divTree0" runat="server" style="height:400px;overflow:scroll;">
                    <asp:TreeView ID="RoleTree" runat="server" ShowLines="True" Width="372px" 
                        onselectednodechanged="RoleTree_SelectedNodeChanged">
                        <%--<SelectedNodeStyle BackColor="#84A5D6" ForeColor="White" />--%>
                         <SelectedNodeStyle CssClass="btn btn-success btn-sm" />
                    </asp:TreeView>
                </div>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_content">
                                            <div class="col-md-5 col-sm-5">
                                                <div class="x_panel">
                                                    <div class="x_title">
                                                        <h2>Permissions</h2>
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
                                     <asp:LinkButton ID="AddPermissionCMD" runat="server" ToolTip="Add" CssClass="btn btn-success btn-sm" onclick="AddPermissionCMD_Click">&nbsp;&nbsp;&nbsp;<i class="fa fa-arrow-right"></i>&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                    <br /><br /><br />
                                     <asp:LinkButton ID="RemovePermissionCMD" runat="server" ToolTip="Remove" CssClass="btn btn-success btn-sm" onclick="RemovePermissionCMD_Click">&nbsp;&nbsp;&nbsp;<i class="fa fa-arrow-left"></i>&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-5 col-sm-5">
                                                <div class="x_panel">
                                                    <div class="x_title">
                                                        <h2>Object Permissions</h2>
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>
