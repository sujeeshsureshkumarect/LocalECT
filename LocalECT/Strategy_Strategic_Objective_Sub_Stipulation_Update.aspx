<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Strategic_Objective_Sub_Stipulation_Update.aspx.cs" Inherits="LocalECT.Strategy_Strategic_Objective_Sub_Stipulation_Update" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <%--<h3><i class="fa fa-globe"></i> Link Manager</h3>--%>
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
                                                <%--<a href="Strategy_Initiative_Inspection_Compliance_Home.aspx" style="float:right;" class="btn btn-success btn-sm" title="Back"><i class="fa fa-arrow-circle-left"></i> Manage Initiative Inspection Compliance</a>--%>
                                                <asp:LinkButton ID="lnk_Create" runat="server" style="float:right;" CssClass="btn btn-success btn-sm" OnClick="lnk_Create_Click"><i class="fa fa-arrow-circle-left"></i> Manage MOE Re-licensure Sub Stipulation</asp:LinkButton>
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
                                        <asp:Label ID="lbl_Msg" runat="server" Text="MOE Re-licensure Sub Stipulation Created Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                                            <div class="col-md-12 col-sm-12">

                                                <div class="col-md-6 col-sm-6">

                                                    <div class="form-group ">
                                                        <label>Strategic Objective *</label>
                                                        <asp:DropDownList ID="drp_StrategicObjective" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drp_StrategicObjective" InitialValue="0" ErrorMessage="*Strategic Objective Required" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>MOE Re-licensure Sub Stipulation *</label>
                                                        <asp:DropDownList ID="drp_MOERelicensureSubStipulation" runat="server" CssClass="form-control"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drp_MOERelicensureSubStipulation" InitialValue="0" ErrorMessage="*MOE Re-licensure Sub Stipulation Required" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>
                                                    </div>                                                                                                                                                       
                                                <div class="form-group ">
                                                    <asp:HiddenField ID="hdn_Edit" runat="server" Value="New"/>
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