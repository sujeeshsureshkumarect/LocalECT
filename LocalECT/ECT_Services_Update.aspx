<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ECT_Services_Update.aspx.cs" Inherits="LocalECT.ECT_Services_Update" MasterPageFile="~/LocalECT.Master"%>

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
                                            <h2><i class="fa fa-edit"></i> Update Services (ID: <asp:Label id="lbl_ID" runat="server" ForeColor="#444444"></asp:Label>)</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                 <a href="ECT_Services_Management.aspx" class="btn btn-success btn-sm"><i class="fa fa-arrow-left"></i> Service Management</a>
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
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Service Updated Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                    <div class="col-md-12 col-sm-12">

                                                <div class="col-md-6 col-sm-6">
                                                   <%-- <div class="form-group ">
                                                    <label>Service ID *</label>                                                    
                                                    <asp:TextBox ID="txt_Service_ID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Service ID Required" ControlToValidate="txt_Service_ID" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>--%>
                                                          <div class="form-group ">
                                                    <label>Service Name (En) *</label>                                                    
                                                    <asp:TextBox ID="txt_ServiceEn" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Service Name (En) Required" ControlToValidate="txt_ServiceEn" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                     <div class="form-group ">
                                                    <label>Service Header (En) *</label>                                                    
                                                    <asp:TextBox ID="txt_ServiceHeaderEn" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Service Header (En) Required" ControlToValidate="txt_ServiceHeaderEn" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                      <div class="form-group ">
                                                    <label>Service Description (En) *</label>                                                    
                                                    <asp:TextBox ID="txt_ServiceDescEn" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Service Description (En) Required" ControlToValidate="txt_ServiceDescEn" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                     <div class="form-group ">
                                                    <label>Host *</label>                                                    
                                                    <asp:TextBox ID="txt_Host" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Host Required" ControlToValidate="txt_Host" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                     <div class="form-group ">
                                                    <label>Audience *</label>                                                    
                                                    <asp:TextBox ID="txt_Audience" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Audience Required" ControlToValidate="txt_Audience" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                   
                                                    <div class="form-group ">
                                                        <asp:Button ID="btn_Create" runat="server" Text="Update" CssClass="btn btn-success btn-sm" ValidationGroup="no" OnClick="btn_Create_Click" />
                                                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CssClass="btn btn-warning btn-sm" OnClick="btn_Cancel_Click" />
                                                    </div>

            
                                                    </div>
                        <asp:HiddenField ID="UserEmail" runat="server" />
                                                 <div class="col-md-6 col-sm-6">
                                                                                        <div class="form-group ">
                                                    <label>Service Name (Ar) *</label>                                                    
                                                    <asp:TextBox ID="txt_ServiceAr" runat="server" CssClass="form-control" style="direction:rtl"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Service Name (Ar) Required" ControlToValidate="txt_ServiceAr" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                     <div class="form-group ">
                                                    <label>Service Header (Ar) *</label>                                                    
                                                    <asp:TextBox ID="txt_ServiceHeaderAr" runat="server" CssClass="form-control" style="direction:rtl"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Service Header (Ar) Required" ControlToValidate="txt_ServiceHeaderAr" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                     <div class="form-group ">
                                                    <label>Service Description (Ar) *</label>                                                    
                                                    <asp:TextBox ID="txt_ServiceDescAr" runat="server" CssClass="form-control" style="direction:rtl" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Service Description (Ar) Required" ControlToValidate="txt_ServiceDescAr" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                       <div class="form-group ">
                                                    <label>Finance *</label>                                                    
                                                    <asp:TextBox ID="txt_Finance" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*txt_Finance Required" ControlToValidate="txt_Finance" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>--%>
                                                </div>
                                                   
                                                 <div class="form-group ">
                                                    <label>Is Active? *</label>
                                                    <asp:DropDownList ID="drp_Status" runat="server" CssClass="form-control">
                                                         <asp:ListItem Text="Yes" Value="1" Selected/>
                                                         <asp:ListItem Text="No" Value="0" />
                                                    </asp:DropDownList>                                                    
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