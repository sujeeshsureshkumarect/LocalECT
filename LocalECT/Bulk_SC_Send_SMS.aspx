<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bulk_SC_Send_SMS.aspx.cs" Inherits="LocalECT.Bulk_SC_Send_SMS" MasterPageFile="~/LocalECT.Master" MaintainScrollPositionOnPostback="true"%>

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
                                            <h2><i class="fa fa-mobile-phone"></i> Send Bulk SMS</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <%-- <a href="StudentSearch.aspx" class="btn btn-success btn-sm"><i class="fa fa-search"></i> Student Search</a>--%>
                                                <a href="StudentSearch.aspx" class="btn btn-success btn-sm" runat="server" id="lnk_Search"><i class="fa fa-search"></i> Search Again</a> 
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
                                            <div class="col-md-10">
                                               <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>SMS Text&nbsp;&nbsp;</label> <asp:RadioButtonList ID="rdb_Lang" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                            <asp:ListItem Text="English&nbsp;" Selected="True" ></asp:ListItem>
                                                            <asp:ListItem Text="Arabic"></asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txt_Text" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px" ClientIDMode="Static"></asp:TextBox>                                                           
                                                        </div>                                                        
                                                            <p style="font-size:12px;color: crimson;"><span id="remaining">160 characters remaining,</span> <span id="messages">1 message(s)</span></p>
                                                    </div>
                                                   </div>
                                                <asp:HiddenField ID="hdn_text_contents" runat="server" />
                                                <asp:HiddenField ID="hdn_iEffected" runat="server" value="0"/>
                                                <div class="col-md-6 col-sm-6">
                                                    <%-- <div class="form-group">--%>
                                                       <%--<label>Custom SMS Messages per Student</label> --%>
                                                        <%--<div class="input-group">--%>
                                                            <asp:FileUpload ID="flp_upload" runat="server" Style="float:left;"/>
                                                            <asp:LinkButton ID="lnk_Upload" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_Upload_Click"><i class="fa fa-upload"></i> Upload File</asp:LinkButton>
                                                      <%--  </div> --%>
                                                    <br /> <br />
                                                         <p style="font-size:12px;color: red;">(Only .xlsx,.xls files are allowed)</p>
                                                         <a href="Upload/Bulk%20SMS%20Sample.xlsx" target="_blank" style="color:blue"><u><i class="fa fa-download"></i> Sample Excel</u></a>
                                                   <%-- </div>--%>
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    SR No.
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Mobile_Number" DataField="Mobile_Number" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                           
                                            
                                            <div class="col-md-12">
                                                <hr />
                                                 <asp:LinkButton ID="lnk_BulkUpdate" runat="server" CssClass="btn btn-success btn-sm" OnClientClick="return confirm('Are you sure to proceed with this bulk operation (Send SMS)?')" ValidationGroup="no" OnClick="lnk_BulkUpdate_Click"><i class="fa fa-send"></i> Send</asp:LinkButton>
                                                <asp:LinkButton ID="lnk_Cancel" runat="server" CssClass="btn btn-danger btn-sm" OnClick="lnk_Cancel_Click"><i class="fa fa-close"></i> Cancel</asp:LinkButton>
                                            </div>  
                                                   <script src="Scripts/jquery-3.4.1.min.js"></script>
                                            <script>
                                                var count = 160;
                                                $('#ContentPlaceHolder1_rdb_Lang_0').click(function () {
                                                    count = 160;//English
                                                    var chars = $('#txt_Text').val().length;
                                                    if (chars == 0) {
                                                        $remaining.text(count + ' characters remaining,');
                                                        $messages.text(1 + ' message(s)');
                                                    }
                                                    else {
                                                        var messages = Math.ceil(chars / count);
                                                        var remaining = messages * count - (chars % (messages * count) || messages * count);
                                                        $remaining.text(remaining + ' characters remaining,');
                                                        $messages.text(messages + ' message(s)');
                                                    }
                                                });
                                                $('#ContentPlaceHolder1_rdb_Lang_1').click(function () {
                                                    count = 70;//Arabic
                                                    var chars = $('#txt_Text').val().length;
                                                    if (chars == 0) {
                                                        $remaining.text(count + ' characters remaining,');
                                                        $messages.text(1 + ' message(s)');
                                                    }
                                                    else {
                                                        var messages = Math.ceil(chars / count);
                                                        var remaining = messages * count - (chars % (messages * count) || messages * count);
                                                        $remaining.text(remaining + ' characters remaining,');
                                                        $messages.text(messages + ' message(s)');
                                                    }
                                                });
                                                var $remaining = $('#remaining'),
                                                    $messages = $remaining.next();

                                                $('#txt_Text').keyup(function () {
                                                    var chars = this.value.length;
                                                    if (chars > 0) {
                                                        var messages = Math.ceil(chars / count);
                                                        var remaining = messages * count - (chars % (messages * count) || messages * count);

                                                        $remaining.text(remaining + ' characters remaining,');
                                                        $messages.text(messages + ' message(s)');
                                                    }
                                                    else {

                                                        $remaining.text(count + ' characters remaining,');
                                                        $messages.text(1 + ' message(s)');
                                                    }

                                                });
                                            </script>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>