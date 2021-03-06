<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Risk_Management_Edit.aspx.cs" Inherits="LocalECT.CS_Risk_Management_Edit" MasterPageFile="~/LocalECT.Master" %>

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
                                            <h2><i class="fa fa-plus"></i> Update Risk Management </h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <asp:LinkButton ID="lnk_Create" runat="server" CssClass="btn btn-success btn-sm" style="float:right;" OnClick="lnk_Create_Click"><i class="fa fa-arrow-circle-left"></i> Risk Management</asp:LinkButton>
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
                                                                                    </button>
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Risk Updated Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                    <div class="col-md-12 col-sm-12">

                                                
                                                 <div class="col-md-6 col-sm-6">
                                                       <div class="form-group ">
                                                        <label>Initiative *</label>
                                                        <asp:DropDownList ID="drp_Initiative" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                                    </div>
                                                      <div class="form-group ">
                                                        <label>Framework *</label>
                                                        <asp:DropDownList ID="drp_Framework" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drp_Framework_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                     <div class="form-group ">
                                                        <label>Registry Framework *</label>
                                                        <asp:DropDownList ID="drp_RegisatryFramework" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                     <div class="form-group ">
                                                         <label>Statement Serial No*</label>
                                                         <asp:TextBox ID="txt_StatementSerialNo" runat="server" CssClass="form-control"></asp:TextBox>
                                                         <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*StatementSerialNo Required" ControlToValidate="txt_StatementSerialNo" ForeColor="Red" ValidationGroup="no">
                                                         </asp:RequiredFieldValidator>
                                                     </div>
                                                     <div class="form-group ">
                                                         <label>Statement*</label>
                                                         <asp:TextBox ID="txt_Statement" runat="server" CssClass="form-control"></asp:TextBox>
                                                         <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Statement Required" ControlToValidate="txt_Statement" ForeColor="Red" ValidationGroup="no">
                                                         </asp:RequiredFieldValidator>
                                                     </div>                                                     
                                                      <div class="form-group ">
                                                        <label>MOE Licensure Stipulation Guidelines *</label>
                                                        <asp:DropDownList ID="drp_StipulationGuidelines" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div> 
                                            
                                                
                                                     <div class="form-group ">
                                                <asp:Button id="btn_Create" runat="server" Text="Update" CssClass="btn btn-success btn-sm" ValidationGroup="no" OnClick="btn_Create_Click"/>
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

