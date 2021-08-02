<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Strategic_Evidence_Submission_Update.aspx.cs" Inherits="LocalECT.Strategy_Strategic_Evidence_Submission_Update" MasterPageFile="~/LocalECT.Master" MaintainScrollPositionOnPostback="true"%>

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
                                                <%--<a href="Strategy_Strategic_Evidence_Home.aspx" style="float:right;" class="btn btn-success btn-sm" title="Back"><i class="fa fa-arrow-circle-left"></i> Strategic Evidence Submission</a>--%>
                                                <asp:LinkButton ID="lnk_Create" runat="server" style="float:right;" CssClass="btn btn-success btn-sm" OnClick="lnk_Create_Click"><i class="fa fa-arrow-circle-left"></i> Strategic Evidence Submission</asp:LinkButton>
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
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Strategic Evidence Submission Created Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                                            <div class="col-md-12 col-sm-12">

                                                <div class="col-md-6 col-sm-6">
                                                  <div class="form-group ">
                                                        <label>Evidence Record *</label>
                                                        <asp:DropDownList ID="drp_EvidenceRecord" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                                    </div>                                                    
                                                    <div class="form-group ">
                                                    <label>Period *</label>
                                                    <asp:DropDownList ID="drp_Period" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                                     <div class="form-group ">
                                                    <label>Sub Period *</label>
                                                    <asp:DropDownList ID="drp_SubPeriod" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                                      <div class="form-group ">
                                                    <label>Note *</label>
                                                    <asp:TextBox ID="txt_Note" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Note Required" ControlToValidate="txt_Note" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                     <div class="form-group ">
                                                        <label>Attachment *</label>
                                                        <asp:FileUpload ID="EvidenceDocumetFile" runat="server"/>
                                                          <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="* Required Field" ControlToValidate="EvidenceDocumetFile" ForeColor="Red" ValidationGroup="no">
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