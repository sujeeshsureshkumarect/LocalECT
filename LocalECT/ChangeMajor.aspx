<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeMajor.aspx.cs" Inherits="LocalECT.ChangeMajor" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="StudentSearch">&nbsp;Student Search /</a>
                        <a href="#">&nbsp;Change Major</a>
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
                            <h2><i class="fa fa-cog"></i> Change Major</h2>
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
                            <div class="x_panel">
                                <div class="col-md-6 col-sm-6 ">
                                    <asp:HiddenField ID="hdnKey" runat="server" />
                                    <asp:HiddenField ID="hdnSerial" runat="server" />
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-2 col-sm-2">Term</label>
                                        <div class="col-md-7 col-sm-7 ">
                                            <asp:DropDownList ID="ddlTerm" runat="server" DataTextField="LongDesc"
                                                DataValueField="Term" TabIndex="27" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-2 col-sm-2">Old Major</label>
                                        <div class="col-md-7 col-sm-7 ">
                                            <asp:TextBox ID="lblOldMajor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-2 col-sm-2">New Major</label>
                                        <div class="col-md-7 col-sm-7 ">
                                            <asp:DropDownList ID="ddlMajor" runat="server" TabIndex="11" AutoPostBack="True" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-2 col-sm-2">Student</label>
                                        <div class="col-md-7 col-sm-7 ">
                                            <asp:TextBox ID="lblStudentNo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-2 col-sm-2">Name</label>
                                        <div class="col-md-7 col-sm-7 ">
                                            <asp:TextBox ID="lblName" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-2 col-sm-2">New ID</label>
                                        <div class="col-md-7 col-sm-7 ">
                                            <asp:TextBox ID="lnkNewId" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3 col-sm-3 ">
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="lnkNewId_Command" ForeColor="Blue" Font-Underline="true" Text="Goto New Profile"></asp:LinkButton>
                                        </div>
                                    </div>
                                                    <div class="form-group row">
                                                        <asp:LinkButton ID="RunCMD" runat="server" CssClass="btn btn-success btn-sm" OnClick="RunCMD_Click"><i class="fa fa-floppy-o"></i> Run</asp:LinkButton>
                                                        <asp:LinkButton ID="btn_Cancel" runat="server" CssClass="btn btn-danger btn-sm" OnClick="btn_Cancel_Click"><i class="fa fa-reply"></i> Cancel</asp:LinkButton>
                                                    </div>
                                </div>








                                <asp:HiddenField ID="hdnStatus" runat="server" />
                                <asp:SqlDataSource ID="SidDS" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>"
                                    OnSelected="SidDS_Selected"
                                    ProviderName="<%$ ConnectionStrings:ECTDataFemales.ProviderName %>"
                                    SelectCommand="GetNew_StId" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="String" />
                                        <asp:Parameter DefaultValue="0" Name="iType" Type="Int32" />
                                        <asp:Parameter DefaultValue="2011" Name="iYear" Type="Int32" />
                                        <asp:Parameter DefaultValue="3" Name="iSem" Type="Int32" />
                                        <asp:Parameter DefaultValue="1" Name="iCampus" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="CopyDS" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:ECTDataMales %>"
                                    InsertCommand="CopyStudent" InsertCommandType="StoredProcedure"
                                    OnInserted="CopyDS_Inserted"
                                    ProviderName="<%$ ConnectionStrings:ECTDataMales.ProviderName %>">
                                    <InsertParameters>
                                        <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                        <asp:ControlParameter ControlID="hdnSerial" DefaultValue="-" Name="iSerial"
                                            PropertyName="Value" Type="Int32" />
                                        <asp:SessionParameter DefaultValue="-" Name="sUser"
                                            SessionField="CurrentUserName" Type="String" />
                                    </InsertParameters>
                                </asp:SqlDataSource>
                                <asp:HiddenField ID="hdnNewSerial" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
