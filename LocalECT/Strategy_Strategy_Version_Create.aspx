<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Strategy_Strategy_Version_Create.aspx.cs" Inherits="LocalECT.CS_Strategy_Version_Create" MasterPageFile="~/LocalECT.Master" %>

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
                                            <h2><i class="fa fa-plus"></i> Create Strategy Version</h2>
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
                                            <%--<span aria-hidden="true">×</span>--%>
                                        </button>
                                        <asp:Label ID="lbl_Msg" runat="server" Text="Strategy Version Created Successfully" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                    </div>
                                </div>
                                            <div class="col-md-12 col-sm-12">

                                                
                                                
                                                 <div class="col-md-6 col-sm-6">
                                                      <div class="form-group ">
                                                    <label>Strategy Version*</label>                                                    
                                                    <asp:TextBox ID="txt_Version" runat="server" CssClass="form-control" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Strategy Version Required" ControlToValidate="txt_Version" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div> </div>
                                                   <div class="col-md-6 col-sm-6">
                                                      <div class="form-group ">
                                                    <label>Start Date*</label>                                                    
                                                    <asp:TextBox ID="txt_sDate" runat="server" CssClass="form-control" ClientIDMode="Static" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Required" ControlToValidate="txt_sDate" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div> </div>
                                                     <div class="col-md-6 col-sm-6">
                                                      <div class="form-group ">
                                                    <label>End Date*</label>                                                    
                                                    <asp:TextBox ID="txt_eDate" runat="server" CssClass="form-control" ClientIDMode="Static" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Required" ControlToValidate="txt_eDate" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div> </div>
                                                       <div class="col-md-6 col-sm-6">
                                                      <div class="form-group ">
                                                    <label>Order *</label>                                                    
                                                    <asp:TextBox ID="txt_Order" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="* Required" ControlToValidate="txt_Order" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div> </div>
                                                         <div class="col-md-6 col-sm-6">
                                                      <div class="form-group ">
                                                    <label>Is Active*</label>                                                    
                                                    <asp:DropDownList ID="txt_IsActive" runat="server" CssClass="form-control"  >
                                                      <asp:ListItem  Value="1">Yes</asp:ListItem>
                                                      <asp:ListItem Value="0">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="* Required" ControlToValidate="txt_IsActive" ForeColor="Red" ValidationGroup="no">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                           </div>
                                                    
                                                                                                  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <link rel="stylesheet" href="/resources/demos/style.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script type="text/javascript">
            var $j = jQuery.noConflict();
            $j(function () {
              $j("#txt_sDate").datepicker({ dateFormat: 'dd/mm/yy' });
              $j("#txt_eDate").datepicker({ dateFormat: 'dd/mm/yy' });
            });
        </script>
                                                
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
</asp:Content>

