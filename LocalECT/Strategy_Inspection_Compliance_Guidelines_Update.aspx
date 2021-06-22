<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Inspection_Compliance_Guidelines_Update.aspx.cs" Inherits="LocalECT.Strategy_Inspection_Compliance_Guidelines_Update" MasterPageFile="~/LocalECT.Master"%>

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
                                                <asp:LinkButton ID="lnk_Back" runat="server" style="float:right;" CssClass="btn btn-success btn-sm" OnClick="lnk_Back_Click" ToolTip="Back"><i class="fa fa-arrow-circle-left"></i> Inspection Compliance Guidelines</asp:LinkButton>
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
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Inspection Compliance Guidelines Created Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                                            <div class="col-md-12 col-sm-12">

                                                <div class="col-md-6 col-sm-6">
                                                  
                                                    <div class="form-group ">
                                                    <label>Inspection Compliance Guidelines ID *</label>
                                                    <asp:TextBox ID="txt_InspectionComplianceGuidelines_ID" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Inspection Compliance Guidelines ID Required" ControlToValidate="txt_InspectionComplianceGuidelines_ID" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                    <div class="form-group ">
                                                    <label>Inspection Compliance Guidelines Description *</label>
                                                    <asp:TextBox ID="txt_InspectionComplianceGuidelines_Desc" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>  
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Inspection Compliance Guidelines Desc Required" ControlToValidate="txt_InspectionComplianceGuidelines_Desc" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                     <div class="form-group ">
                                                    <label>Inspection Compliance Standard ID *</label>
                                                    <asp:DropDownList ID="drp_InspectionComplianceStandard" runat="server" CssClass="form-control" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="drp_InspectionComplianceStandard_SelectedIndexChanged"></asp:DropDownList>
                                                </div>
                                                     <div class="form-group ">
                                                    <label>Inspection Compliance Domain ID *</label>
                                                    <asp:DropDownList ID="drp_InspectionComplianceDomain" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                                </div>
                                                    <%-- <div class="form-group ">
                                                    <label>Inspection Compliance Indicator ID *</label>
                                                    <asp:DropDownList ID="drp_InspectionComplianceIndicator" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>--%>
                                                     <div class="form-group ">
                                                    <label>Inspection Compliance Guidelines Order *</label>
                                                    <asp:TextBox ID="txt_InspectionComplianceGuidelines_Order" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Inspection Compliance Guidelines Order Required" ControlToValidate="txt_InspectionComplianceGuidelines_Order" ForeColor="Red" ValidationGroup="no">
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