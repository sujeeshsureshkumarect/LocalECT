<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Strategic_KPI_Update.aspx.cs" Inherits="LocalECT.Strategy_Strategic_KPI_Update" MasterPageFile="~/LocalECT.Master" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3><i class="fa fa-globe"></i> Corporate Strategy</h3>
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
                                            <h2><i class="fa fa-plus"></i> <asp:Label ID="lbl_Header" runat="server" ForeColor="#444444"></asp:Label></h2>
                                            <ul class="nav navbar-right panel_toolbox">                                                
                                                <asp:LinkButton ID="lnk_Back" runat="server" style="float:right;" CssClass="btn btn-success btn-sm" title="Back" OnClick="lnk_Back_Click"><i class="fa fa-arrow-circle-left"></i> KPIs</asp:LinkButton>
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
                                        <asp:Label ID="lbl_Msg" runat="server" Text="KPI Created Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                                            <div class="col-md-12 col-sm-12">

                                                <div class="col-md-6 col-sm-6">

                                                    <div class="form-group ">
                                                        <label>KPI ID *</label>
                                                        <asp:TextBox ID="txt_KPIID" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*KPI ID Required" ControlToValidate="txt_KPIID" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>KPI Description *</label>
                                                        <asp:TextBox ID="txt_KPIDesc" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*KPI Description Required" ControlToValidate="txt_KPIDesc" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Period *</label>
                                                        <asp:DropDownList ID="drp_Period" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>   
                                                    <div class="form-group ">
                                                        <label>Formula *</label>
                                                        <asp:DropDownList ID="drp_Formula" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Target KPI *</label>
                                                        <asp:TextBox ID="txt_TargetKPI" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Target KPI Required" ControlToValidate="txt_TargetKPI" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Min *</label>
                                                        <asp:TextBox ID="txt_Min" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Min Required" ControlToValidate="txt_Min" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Max *</label>
                                                        <asp:TextBox ID="txt_Max" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Max Required" ControlToValidate="txt_Max" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Overall KPI *</label>
                                                        <asp:TextBox ID="txt_OverallKPI" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Overall KPI Required" ControlToValidate="txt_OverallKPI" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>KPI Source *</label>
                                                        <asp:DropDownList ID="drp_KPISource" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>KPI Level *</label>
                                                        <asp:DropDownList ID="drp_KPILevel" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drp_KPILevel_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>KPI Sub Level *</label>
                                                        <asp:DropDownList ID="drp_KPISubLevel" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Is Institutional Class *</label>
                                                        <asp:DropDownList ID="drp_IsInstitutionalClass" runat="server" CssClass="form-control">
                                                            <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>MOE Classification Pillars *</label>
                                                        <asp:DropDownList ID="drp_MOEClassificationPillars" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Market Positioning Pillars *</label>
                                                        <asp:DropDownList ID="drp_MarketPositioningPillars" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                     <div class="form-group ">
                                                        <label>Department *</label>
                                                        <asp:DropDownList ID="drp_Department" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drp_Department_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Section *</label>
                                                        <asp:DropDownList ID="drp_Section" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drp_Section_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                                    </div>                                                    
                                                    <div class="form-group ">
                                                        <label>Initiative *</label>
                                                        <asp:DropDownList ID="drp_Initiative" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Strategy Version *</label>
                                                        <asp:DropDownList ID="drp_StrategyVersion" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                                    </div>
                                                        <div class="form-group ">
                                                        <label>Order *</label>
                                                        <asp:TextBox ID="txt_Order" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Order Required" ControlToValidate="txt_Order" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Survey Form Reference *</label>
                                                        <asp:DropDownList ID="drp_SurveyFormReference" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                     <%--<div class="form-group ">
                                                        <label>RiskManagement *</label>
                                                        <asp:DropDownList ID="drp_RiskManagement" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>--%>
                                                    <div class="form-group ">
                                                        <label>Is QS World University Ranking *</label>
                                                        <asp:DropDownList ID="drp_isQSWorldUniversityRanking" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="1" Selected>Yes</asp:ListItem>
                                                            <asp:ListItem Value="0">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Evidence *</label>
                                                        <asp:DropDownList ID="drp_Evidence" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                     <div class="form-group ">
                                                        <label>EV *</label>                                                        
                                                        <asp:TextBox ID="txt_EV" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*EV Required" ControlToValidate="txt_EV" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>                                                        
                                                    </div>
                                                <div class="form-group ">
                                                <asp:Button id="btn_Create" runat="server" Text="Create" CssClass="btn btn-success btn-sm" ValidationGroup="no" OnClick="btn_Create_Click"/>
                                                <asp:Button id="btn_Cancel" runat="server" Text="Cancel" CssClass="btn btn-warning btn-sm" OnClick="btn_Cancel_Click"/>
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