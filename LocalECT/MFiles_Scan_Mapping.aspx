<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MFiles_Scan_Mapping.aspx.cs" Inherits="LocalECT.MFiles_Scan_Mapping" MasterPageFile="~/LocalECT.Master"%>

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
                                            <h2><i class="fa fa-file-archive-o"></i> MFiles</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                            <div class="col-md-5 col-sm-5"> 
                                            <div class="form-group row">
                                                    <label class="col-form-label col-md-3 col-sm-3">Student ID<span style="color: red">*</span></label>
                                                     <div class="col-md-9 col-sm-9 ">
                                                         <asp:TextBox ID="txt_StudnetID" runat="server" CssClass="form-control" ValidationGroup="SD"></asp:TextBox>                                                         
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                             ControlToValidate="txt_StudnetID" ErrorMessage="Student ID is requied."
                                                              SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Student ID is requied.</asp:RequiredFieldValidator>
                                                     </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-form-label col-md-3 col-sm-3">Place<span style="color: red">*</span></label>
                                                     <div class="col-md-9 col-sm-9 ">
                                                         <asp:TextBox ID="txt_Place" runat="server" CssClass="form-control" ValidationGroup="SD" TextMode="Number"></asp:TextBox>                                                         
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                             ControlToValidate="txt_StudnetID" ErrorMessage="Place is requied."
                                                              SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Place is requied.</asp:RequiredFieldValidator>
                                                     </div>
                                                </div>
                                                <div><%--align="middle"--%>
                                                    <asp:LinkButton ID="lnk_Save" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_Save_Click" ValidationGroup="SD"><i class="fa fa-plus"></i> Add</asp:LinkButton>
                                                    <asp:Label ID="lbl_Msg" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
                                                </div>
            </div>
                                            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.3/jquery.min.js"></script>
                                            <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
                                            <%--<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />--%>
                                            <div id="myModal" class="modal fade">
                                                <div class="modal-dialog">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                           <%-- <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>--%>
                                                            <h4 class="modal-title" id="myModalLabel">Alert</h4>
                                                        </div>
                                                        <div class="modal-body">
                                                            <h3 style="font-size:14px !important">No records found. Would you like to add this record?</h3>
                                                            <asp:Button ID="btnYes" runat="server" Text="Yes" OnCommand="Decision_Command" CommandArgument="Yes" CssClass="btn btn-success btn-sm"/>
                                                            <asp:Button ID="btnNo" runat="server" Text="No" OnCommand="Decision_Command" CommandArgument="No" CssClass="btn btn-danger btn-sm"/>
                                                        </div>
                                                        <%--<div class="modal-footer">
                                                            <button type="button" class="btn btn-primary btn-sm" data-dismiss="modal">Close</button>
                                                        </div>--%>
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