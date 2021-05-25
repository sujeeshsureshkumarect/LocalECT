<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bulk_Acc_BlockUnBlock.aspx.cs" Inherits="LocalECT.Bulk_Acc_BlockUnBlock" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Accounting /</a>
                        <a href="Acc_Search">&nbsp;Account Search /</a>
                        <a href="#">&nbsp;Block/Unblock</a>
                    </h3>
                </div>
                <style>
                    .page-title .title_left {
                        width: 100%;
                        float: left;
                        display: block;
                    }

                    .breadcrumb {
                        padding: 8px 15px;
                        margin-bottom: 20px;
                        list-style: none;
                        background-color: #ededed;
                        border-radius: 4px;
                        font-size: 13px;
                    }
                </style>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><i class="fa fa-lock"></i> Block/Unblock</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <a href="Acc_Search.aspx" class="btn btn-success btn-sm"><i class="fa fa-search"></i> Account Search</a>
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
                               <div class="x_content bs-example-popovers">
                                  <div class="alert alert-info alert-dismissible " role="alert" runat="server" id="alertsearch" visible="false">

                            <strong>Selected Student IDs - </strong><asp:Label runat="server" ID="lbl_IDs" ClientIDMode="Static"></asp:Label>
                            
                        </div>
                                     </div>
                            <div class="x_panel">                           
                                <div class="col-md-4 col-sm-4">
                                  
                                        <div class="col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Current Online Status</label>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddlOnlineStatus" runat="server" 
                                                         CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="0">Inactive</asp:ListItem>
                                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                                        <asp:ListItem Value="2">Fully Activated</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CheckBox ID="chk_Enable1" runat="server" Checked="true" style="padding-left:10px;"/>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Finance Category</label>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddlFinanceCat" runat="server" CssClass="form-control">       
                                                        <asp:ListItem Text="Allowed" Value="1"></asp:ListItem>
                                                         <asp:ListItem Text="Categorize Now" Value="other"></asp:ListItem>
                                                    </asp:DropDownList>
                                                   <%-- <asp:SqlDataSource ID="FinCatDs" runat="server"
                                                        ConnectionString="<%$ ConnectionStrings:ECTDataNew %>"
                                                        SelectCommand="SELECT [iFinCategory], [sFinDesc] FROM [Acc_Finance_Category] ORDER BY [iFinCategory]"></asp:SqlDataSource>--%>
                                                    <asp:CheckBox ID="chk_Enable2" runat="server" Checked="true" style="padding-left:10px;"/>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Is ACC Wanted ?</label>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddlACCWanted" runat="server" 
                                                        
                                                        CssClass="form-control">
                                                        <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CheckBox ID="chk_Enable3" runat="server" Checked="true" style="padding-left:10px;"/>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12">
                                            <div class="form-group">
                                                <label>Reg Term</label>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddlRegTerm" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                    <asp:CheckBox ID="chk_Enable4" runat="server" Checked="true" style="padding-left:10px;"/>
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="col-md-12 col-sm-12">
                                            <div class="form-group">
                                                &nbsp;
                                                </div>
                                            </div>--%>

                                           <div class="col-md-12 col-sm-12">
                                            &nbsp;<br />
                                            <asp:LinkButton ID="lnk_Settings" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_Settings_Click" Visible="false" OnClientClick="return confirm('Are you sure to proceed with this bulk operation (Block/Unblock)?')"><i class=" fa fa-floppy-o"></i> Bulk Update</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-danger btn-sm" OnClick="lnk_Cancel_Click"><i class=" fa fa-close"></i> Back</asp:LinkButton>
                                        </div>
                                    
                                </div>


                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdn_Admission_Payment_Type" runat="server" />
    <asp:HiddenField ID="hdn_OpportunityID" runat="server" />
    </div>
</asp:Content>
