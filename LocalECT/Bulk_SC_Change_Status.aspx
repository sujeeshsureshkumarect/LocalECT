<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bulk_SC_Change_Status.aspx.cs" Inherits="LocalECT.Bulk_SC_Change_Status" MasterPageFile="~/LocalECT.Master" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3></h3>
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
                                            <h2><i class="fa fa-exclamation"></i> Bulk Change Status</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                 <a href="StudentSearch.aspx" class="btn btn-success btn-sm"><i class="fa fa-search"></i> Student Search</a>
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                             <div class="x_content bs-example-popovers" id="div_msg" runat="server" visible="false">
                                                <div class="alert alert-danger alert-dismissible" role="alert" runat="server" id="div_Alert">
                                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                        <span aria-hidden="true">×</span>
                                                    </button>
                                                    <asp:Label ID="lbl_Msg" runat="server" Text="" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="x_content bs-example-popovers">
                                  <div class="alert alert-info alert-dismissible " role="alert" runat="server" id="alertsearch" visible="false">

                            <strong>Selected Student IDs - </strong><asp:Label runat="server" ID="lbl_IDs" ClientIDMode="Static"></asp:Label>
                            
                        </div>
                                     </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Status</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlStatus" runat="server" DataTextField="strReasonDesc"
                                                                                    DataValueField="byteReason" Enabled="true"  CssClass="form-control" ValidationGroup="no">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="ddlStatus" ErrorMessage="*Status is required" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Term</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlStatusTerm" runat="server" DataTextField="LongDesc"
                                                                                    DataValueField="Term" Enabled="true"  CssClass="form-control" ValidationGroup="no">
                                                                                </asp:DropDownList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlStatusTerm" InitialValue="0" ErrorMessage="*Term is required" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>--%>
                                                                            </div>
                                                                        </div>
                                                  <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Remarks*</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:TextBox ID="txt_Remarks" runat="server" CssClass="form-control" TextMode="MultiLine" ValidationGroup="no"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Remarks" ErrorMessage="*Remarks is required" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>
                                                                            </div>
                                                                        </div>
                                            </div>
                                            <div class="col-md-6">
                                                  <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Major Reason</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlReason" runat="server" AutoPostBack="True"
                                                                                    DataTextField="strMainReasonEn" DataValueField="byteMainReason" Enabled="true"
                                                                                    CssClass="form-control" ValidationGroup="no">
                                                                                </asp:DropDownList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlReason" InitialValue="0" ErrorMessage="*Major Reason is required" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>--%>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Minor Reason</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlSubReason" runat="server" DataSourceID="SubReasonDS"
                                                                                    DataTextField="strSubReasonEn" DataValueField="byteSubReson" Enabled="true"
                                                                                     CssClass="form-control" ValidationGroup="no">
                                                                                </asp:DropDownList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSubReason" InitialValue="0" ErrorMessage="*Minor Reason is required" Display="Dynamic" ForeColor="Red" ValidationGroup="no"/>--%>
                                                                            </div>
                                                                        </div>
                                            </div>
                                            
                                            <div class="col-md-12">
                                                <hr />
                                                 <asp:LinkButton ID="lnk_BulkUpdate" runat="server" CssClass="btn btn-success btn-sm" OnClientClick="return confirm('Are you sure to proceed with this bulk operation (Change Status)?')" ValidationGroup="no" OnClick="lnk_BulkUpdate_Click"><i class="fa fa-upload"></i> Bulk Update</asp:LinkButton>
                                            </div>                                           

                                            
                                                                      
                                             <asp:SqlDataSource ID="SubReasonDS" runat="server"
        ConnectionString="<%$ ConnectionStrings:ECTDataMales %>"
        SelectCommand="SELECT [byteSubReson], [strSubReasonEn] FROM [Lkp_SubReasons] WHERE ([byteMainReason] = @byteMainReason) ORDER BY [strSubReasonEn]">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlReason" DefaultValue="0"
                Name="byteMainReason" PropertyName="SelectedValue" Type="Int16" />
        </SelectParameters>
    </asp:SqlDataSource>
            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>