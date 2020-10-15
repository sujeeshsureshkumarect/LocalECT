<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Security_Objects.aspx.cs" Inherits="LocalECT.Security_Objects" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Security /</a>
                        <a href="Security_Objects">&nbsp;Maps Manager</a>

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
                            <h2><i class="fa fa-gears"></i> Maps Manager</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <div class="row">
                                <div class="col-md-6 col-sm-6">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2>Maps Attributes</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                            <div class="col-md-6 col-sm-6">
                                                <div class="form-group row">
                                                    <label>System</label>
                                                    <asp:DropDownList ID="SystemsCBO" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="SystemsCBO_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group row">
                                                    <label>Description *</label>
                                                    <asp:TextBox ID="DescTXT" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        ControlToValidate="DescTXT" ErrorMessage="Desc is Required"
                                                        ValidationGroup="isValid" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group row">
                                                    <label>Parent</label>
                                                    <asp:TextBox ID="ParentLBL" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group row">
                                                    <label>Level</label>
                                                    <asp:TextBox ID="LevelLBL" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6">
                                                <div class="form-group row">
                                                    <label>ID *</label>
                                                    <asp:TextBox ID="IDTXT" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                        ControlToValidate="IDTXT" ErrorMessage="Select node from the tree"
                                                        ValidationGroup="isValid" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group row">
                                                    <label>Caption *</label>
                                                    <asp:TextBox ID="CaptionTXT" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                        ControlToValidate="CaptionTXT" ErrorMessage="Caption is Required"
                                                        ValidationGroup="isValid" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group row">
                                                    <label>URL</label>
                                                    <asp:TextBox ID="UrlTXT" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group row">
                                                    <label>Order</label>
                                                    <asp:DropDownList ID="OrderCBO" runat="server" CssClass="form-control">
                                                        <asp:ListItem>0</asp:ListItem>
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                        <asp:ListItem>6</asp:ListItem>
                                                        <asp:ListItem>7</asp:ListItem>
                                                        <asp:ListItem>8</asp:ListItem>
                                                        <asp:ListItem>9</asp:ListItem>
                                                        <asp:ListItem>10</asp:ListItem>
                                                        <asp:ListItem>11</asp:ListItem>
                                                        <asp:ListItem>12</asp:ListItem>
                                                        <asp:ListItem>13</asp:ListItem>
                                                        <asp:ListItem>14</asp:ListItem>
                                                        <asp:ListItem>15</asp:ListItem>
                                                        <asp:ListItem>16</asp:ListItem>
                                                        <asp:ListItem>17</asp:ListItem>
                                                        <asp:ListItem>18</asp:ListItem>
                                                        <asp:ListItem>19</asp:ListItem>
                                                        <asp:ListItem>20</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>









                                            <asp:HiddenField ID="isDataChanged" runat="server" />
                                            <asp:HiddenField ID="DataStatus" runat="server" />
                                            <asp:HiddenField ID="Sel" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2>Maps Objects (Menu)</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                            <div id="divTree" runat="server">
                                                <asp:TreeView ID="myTree" runat="server" ShowLines="True" OnSelectedNodeChanged="myTree_SelectedNodeChanged">
                                                    <SelectedNodeStyle BackColor="#3f658c" ForeColor="White" />
                                                </asp:TreeView>
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
