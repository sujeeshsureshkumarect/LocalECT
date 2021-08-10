<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Strategic_KPI_Detail_Update.aspx.cs" Inherits="LocalECT.Strategy_Strategic_KPI_Detail_Update" MasterPageFile="~/LocalECT.Master" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3><i class="fa fa-globe"></i>Corporate Strategy</h3>
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
                            <h2><i class="fa fa-plus"></i>
                                <asp:Label ID="lbl_Header" runat="server" ForeColor="#444444"></asp:Label></h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <asp:LinkButton ID="lnk_Back" runat="server" Style="float: right;" CssClass="btn btn-success btn-sm" title="Back" OnClick="lnk_Back_Click"><i class="fa fa-arrow-circle-left"></i> Execute</asp:LinkButton>
                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                </li>
                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <div class="x_content bs-example-popovers" id="div_msg" runat="server" visible="false">

                                <div class="alert alert-success alert-dismissible " role="alert" runat="server" id="div_Alert">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                    <asp:Label ID="lbl_Msg" runat="server" Text="Detail Created Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12 col-sm-12">

                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group ">
                                        <label>KPI ID *</label>
                                        <asp:DropDownList ID="drp_KPI" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                    </div>
                                    <div class="form-group ">
                                        <label>Period *</label>
                                        <asp:DropDownList ID="drp_Period" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                    </div>
                                    <div class="form-group ">
                                        <label>Sub Period *</label>
                                        <asp:DropDownList ID="drp_SubPeriod" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group ">
                                        <label>Value *</label>
                                        <asp:TextBox ID="txt_Value" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Value Required" ControlToValidate="txt_Value" ForeColor="Red" ValidationGroup="no">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group ">
                                        <label>Department *</label>
                                        <asp:DropDownList ID="drp_Department" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drp_Department_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                    </div>
                                    <div class="form-group ">
                                        <label>Section *</label>
                                        <asp:DropDownList ID="drp_Section" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                    </div>
                                    <div class="form-group ">
                                        <label>KPI Status *</label>
                                        <asp:DropDownList ID="drp_KPIStatus" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group ">
                                        <label>Strategy Version *</label>
                                        <asp:DropDownList ID="drp_StrategyVersion" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                    </div>
                                    <div class="form-group ">
                                        <label>Note *</label>
                                        <asp:TextBox ID="txt_Note" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Note Required" ControlToValidate="txt_Note" ForeColor="Red" ValidationGroup="no">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group ">
                                        <label>Sub Period Target *</label>
                                        <asp:TextBox ID="txt_SubPeriodTarget" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Sub Period Target Required" ControlToValidate="txt_SubPeriodTarget" ForeColor="Red" ValidationGroup="no">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group ">
                                        <asp:Button ID="btn_Create" runat="server" Text="Create" CssClass="btn btn-success btn-sm" ValidationGroup="no" OnClick="btn_Create_Click" />
                                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CssClass="btn btn-warning btn-sm" OnClick="btn_Cancel_Click" />
                                    </div>
                                    <%-- </div> --%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
