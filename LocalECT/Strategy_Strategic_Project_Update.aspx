<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Strategic_Project_Update.aspx.cs" Inherits="LocalECT.Strategy_Strategic_Project_Update" MasterPageFile="~/LocalECT.Master"%>

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
                                                <a href="Strategy_Strategic_Project_Home.aspx" style="float:right;" class="btn btn-success btn-sm" title="Back"><i class="fa fa-arrow-circle-left"></i> Strategic Project</a>
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
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Strategic Project Created Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                                            <div class="col-md-12 col-sm-12">

                                                <div class="col-md-6 col-sm-6">

                                                    <div class="form-group ">
                                                        <label>Strategic Project ID *</label>
                                                        <asp:TextBox ID="txt_StrategicProjectID" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Strategic Project ID Required" ControlToValidate="txt_StrategicProjectID" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Strategic Project Description *</label>
                                                        <asp:TextBox ID="txt_StrategicProjectDesc" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Strategic Project Description Required" ControlToValidate="txt_StrategicProjectDesc" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Project Owner *</label>
                                                        <asp:DropDownList ID="drp_ProjectOwner" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drp_ProjectOwner_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Hierarchy Project Owner *</label>
                                                        <asp:TextBox ID="txt_HierarchyProjectOwner" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                        <asp:HiddenField ID="hdn_iHierarchyProjectOwner" runat="server" />
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Owner Department *</label>
                                                        <asp:TextBox ID="txt_OwnerDepartment" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                        <asp:HiddenField ID="hdn_iOwnerDepartment" runat="server" />
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Owner Section *</label>
                                                        <asp:TextBox ID="txt_OwnerSection" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                        <asp:HiddenField ID="hdn_iOwnerSection" runat="server" />
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Strategic Goal *</label>
                                                        <asp:DropDownList ID="drp_StrategicGoal" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Order *</label>
                                                        <asp:TextBox ID="txt_Order" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Order Required" ControlToValidate="txt_Order" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Strategy Version *</label>
                                                        <asp:DropDownList ID="drp_StrategyVersion" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Abbreviation *</label>
                                                        <asp:TextBox ID="txt_Abbreviation" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Abbreviation Required" ControlToValidate="txt_Abbreviation" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                      <div class="form-group ">
                                                        <label>Market Competitive Implication *</label>
                                                        <asp:DropDownList ID="drp_MarketCompetitiveImplication" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                     <div class="form-group ">
                                                        <label>Image Path *</label><br />
                                                        <asp:FileUpload ID="flp_Upload" runat="server"/>
                                                         <asp:HyperLink ID="hyp_ImagePath" runat="server" Target="_blank"><u><i class="fa fa-eye"></i> View</u></asp:HyperLink>
                                                        <%--<asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Image Path Required" ControlToValidate="flp_Upload" ForeColor="Red" ValidationGroup="no">
                                                        </asp:RequiredFieldValidator>--%>
                                                    </div>
                                                    <div class="form-group ">
                                                        <label>Level *</label>
                                                        <asp:TextBox ID="txt_Level" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Level Required" ControlToValidate="txt_Level" ForeColor="Red" ValidationGroup="no">
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