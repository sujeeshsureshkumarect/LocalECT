<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ECTSystems_Update.aspx.cs" Inherits="LocalECT.ECTSystems_Update" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <%--<h3>Welcome To Emirates College Of Technology (ECT)</h3>--%>
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
                                            <h2><i class="fa fa-plus"></i> Update ECT System</h2>
                                            <ul class="nav navbar-right panel_toolbox">
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
                                        <asp:Label ID="lbl_Msg" runat="server" Text="ECT System Updated Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                                            <div class="col-md-6 ">
                                                <div class="form-group row">
                                                    <label>System Name (EN) *</label>                                                    
                                                    <asp:TextBox ID="txt_Header" runat="server" CssClass="form-control" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*System Name (EN) Required" ControlToValidate="txt_Header" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group row">
                                                    <label>System Name (AR)</label>
                                                    <asp:TextBox ID="txt_Detail" runat="server" CssClass="form-control"></asp:TextBox>                                                   
                                                </div>
                                                   <div class="form-group row">
                                                    <label>Status *</label>
                                                    <asp:DropDownList ID="drp_Status" runat="server" CssClass="form-control">
                                                         <asp:ListItem Text="Active" Value="1" Selected/>
                                                         <asp:ListItem Text="Inactive" Value="0" />
                                                    </asp:DropDownList>                                                    
                                                </div>
                                                   <div class="form-group row">
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
    </asp:Content>