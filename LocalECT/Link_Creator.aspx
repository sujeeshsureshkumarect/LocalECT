<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Link_Creator.aspx.cs" Inherits="LocalECT.Link_Creator" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3><i class="fa fa-globe"></i> Link Manager</h3>
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
                                            <h2><i class="fa fa-plus"></i> Create New Link(s)-Bulk</h2>
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
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Link Created Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                                            <div class="col-md-12 col-sm-12">

                                                <div class="col-md-6 col-sm-6">
                                                    <div class="form-group ">
                                                    <label>Term *</label>                                                    
                                                    <asp:DropDownList ID="ddlRegTerm" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                    <%--<asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Description Required" ControlToValidate="txt_Description" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>--%>
                                                </div>
                                                    <div class="form-group ">
                                                    <label>File Upload *</label>
                                                    <asp:FileUpload ID="flp_upload" runat="server" CssClass="form-control"/>
                                                </div>
                                                   <%-- <div class="form-group ">
                                                    <label>Short URL *</label>
                                                    <asp:TextBox ID="txt_ShortURL" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>                                                   
                                                </div>--%>
                                                    <div class="form-group ">
                                                    <label>Status *</label>
                                                    <asp:DropDownList ID="drp_Status" runat="server" CssClass="form-control">
                                                         <asp:ListItem Text="Active" Value="1" Selected/>
                                                         <asp:ListItem Text="Inactive" Value="0" />
                                                    </asp:DropDownList>                                                    
                                                </div>
                                                    <div class="form-group ">
                                                    <label>Target Language *</label>
                                                    <asp:DropDownList ID="drp_Target" runat="server" CssClass="form-control">
                                                         <asp:ListItem Text="Arabic"/>
                                                         <asp:ListItem Text="English"  Selected/>
                                                    </asp:DropDownList>                                                    
                                                </div>
                                                     <div class="form-group ">
                                                    <label>Note *</label>                                                    
                                                    <asp:TextBox ID="txt_Note" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px" placeholder="Enter notes here..."></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Note Required" ControlToValidate="txt_Note" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                    </div>
                                                 <div class="col-md-6 col-sm-6">
                                                      <div class="form-group ">
                                                    <label>Description *</label>                                                    
                                                    <asp:TextBox ID="txt_Description" runat="server" CssClass="form-control" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Description Required" ControlToValidate="txt_Description" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                     <asp:HiddenField ID="hdn_sCode" runat="server" />
                                                      <div class="form-group ">
                                                    <label>Alternative URL *</label>
                                                    <asp:TextBox ID="txt_Alt_URL" runat="server" CssClass="form-control" Text="https://ect.ac.ae/"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Alternative URL Required" ControlToValidate="txt_Alt_URL" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                                                                  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="/resources/demos/style.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script type="text/javascript">
            var $j = jQuery.noConflict();
            $j(function () {
                $j("#txt_Date").datepicker({ dateFormat: 'dd/mm/yy' });
            });
        </script>
                                                <div class="form-group ">
                                                    <label>Expiry Date *</label>
                                                    <asp:TextBox ID="txt_Date" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Expiry Date Required" ControlToValidate="txt_Date" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>  
                                                       <div class="form-group ">
                                                    <label>Source *</label>
                                                    <asp:DropDownList ID="drp_Source" runat="server" CssClass="form-control">
                                                         <asp:ListItem Text="Marketing Campaign" Selected/>
                                                         <asp:ListItem Text="ACC SMS"/>
                                                        <asp:ListItem Text="SAR SMS"/>
                                                    </asp:DropDownList>                                                    
                                                </div>
                                                      <div class="form-group ">
                                                    <label>Medium *</label>
                                                    <asp:DropDownList ID="drp_Medium" runat="server" CssClass="form-control">
                                                         <asp:ListItem Text="Email"  Selected/>
                                                         <asp:ListItem Text="SMS"  />
                                                    </asp:DropDownList>                                                    
                                                </div>
                                                     <div class="form-group ">
                                                <asp:Button id="btn_Create" runat="server" Text="Create" CssClass="btn btn-success btn-sm" ValidationGroup="no"/>
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