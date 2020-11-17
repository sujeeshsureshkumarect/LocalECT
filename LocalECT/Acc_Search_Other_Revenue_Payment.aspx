<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acc_Search_Other_Revenue_Payment.aspx.cs" Inherits="LocalECT.Acc_Search_Other_Revenue_Payment" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                   <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Accounting /</a>
                        <a href="Acc_Search">&nbsp;Account Search /</a>
                        <a href="#">&nbsp;Receive Other Revenue Payment</a>
                    </h3>
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }  
                                    .breadcrumb {
                        padding: 8px 15px;
                        margin-bottom: 20px;
                        list-style: none;
                        background-color: #ededed;
                        border-radius: 4px;
                        font-size: 13px;
                    }
                                </style>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-money"></i> Receive Other Revenue Payment</h2>
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
                                                <div class="alert alert-danger alert-dismissible" role="alert" runat="server" id="div_Alert">
                                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                        <span aria-hidden="true">×</span>
                                                    </button>
                                                    <asp:Label ID="lbl_Msg" runat="server" Text="" Visible="true" Font-Bold="true" Font-Size="16px"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="x_panel">
                                                <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>Reg Term</label>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="ddlRegTerm" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                            <br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select a Term" Display="Dynamic" ForeColor="Red" ControlToValidate="ddlRegTerm" ValidationGroup="no" InitialValue="0">*Please Select a Term</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>Account Number</label>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="lblACC" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>Student Name</label>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>Student ID</label>
                                                        <div class="input-group">
                                                            <%-- <asp:DropDownList ID="ddlIDs" runat="server" CssClass="form-control" 
                                                                 Enabled="false">                                                               
                                                           </asp:DropDownList>--%>
                                                            <asp:TextBox ID="ddlIDs" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                   <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>Voucher #</label>
                                                        <div class="input-group">                                                           
                                                            <asp:TextBox ID="lblVoucher" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                   <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>Entry #</label>
                                                        <div class="input-group">                                                            
                                                            <asp:TextBox ID="lblEntryNo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                  <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>Date</label>
                                                        <div class="input-group">                                                            
                                                            <asp:TextBox ID="txtDatePayment" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Payment Date Required" Display="Dynamic" ForeColor="Red" ControlToValidate="txtDatePayment" ValidationGroup="no" >*Payment Date Required</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                  <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>Amount</label>
                                                        <div class="input-group">                                                            
                                                            <asp:TextBox ID="txtPayment" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Payment Amount Required" Display="Dynamic" ForeColor="Red" ControlToValidate="txtPayment" ValidationGroup="no" >*Payment Amount Required</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                 <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>Payment Way</label>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="ddlPaymentWay" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPaymentWay_SelectedIndexChanged" AutoPostBack="true">                                                                
                                                                <asp:ListItem Selected="True" Value="1">Cash</asp:ListItem>
                                                                <asp:ListItem Value="2">Credit Card</asp:ListItem>
                                                                <asp:ListItem Value="3">Cheque</asp:ListItem>
                                                                <asp:ListItem Value="4">Other</asp:ListItem>
                                                                <asp:ListItem Value="5">Transfer</asp:ListItem>
                                                                <asp:ListItem Value="6">Online</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                  <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>Status</label>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                                                <asp:ListItem Selected="True" Value="0">Entry</asp:ListItem>
                                                                <asp:ListItem Value="1">Paid</asp:ListItem>
                                                                <asp:ListItem Value="2">Returned</asp:ListItem>
                                                                <asp:ListItem Value="3">Insurance</asp:ListItem>
                                                                <asp:ListItem Value="4">Canceled</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="cheque" runat="server" visible="false">
                                                    <div class="col-md-6 col-sm-6">
                                                        <div class="form-group">
                                                            <label>Cheque #</label>
                                                            <div class="input-group">
                                                                <asp:TextBox ID="txtCheque" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <asp:HiddenField ID="hdnCheque" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                     <div class="col-md-6 col-sm-6">
                                                        <div class="form-group">
                                                            <label>Due Date</label>
                                                            <div class="input-group">
                                                                <asp:TextBox ID="txtDueDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>                                                                
                                                            </div>
                                                        </div>
                                                    </div>
                                                     <div class="col-md-6 col-sm-6">
                                                        <div class="form-group">
                                                            <label>Bank</label>
                                                            <div class="input-group">
                                                                <asp:DropDownList ID="ddlBank" runat="server" CssClass="form-control"
                                                                    DataSourceID="BankDS" DataTextField="strBankEn" DataValueField="intBank">
                                                                </asp:DropDownList>
                                                                <asp:SqlDataSource ID="BankDS" runat="server"
                                                                    ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>"
                                                                    SelectCommand="SELECT [intBank], [strBankEn] FROM [Acc_Banks] ORDER BY [strBankEn]"></asp:SqlDataSource>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                  <div class="col-md-6 col-sm-6">
                                                        <div class="form-group">
                                                            <label>Remarks</label>
                                                            <div class="input-group">
                                                                <asp:TextBox ID="txtPRemark" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>                                                                
                                                                 <asp:HiddenField ID="hdnPaymentStatus" runat="server" Value="1" />
                                                                <asp:HiddenField ID="hdniAdmissionPaymentType" runat="server" Value="0" />
                                                                <asp:HiddenField ID="hdncAdmissionPaymentValue" runat="server" Value="0" />
                                                                <asp:HiddenField ID="hdnRevenueAccount" runat="server" Value="0200000" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                 <div class="col-md-6 col-sm-6">
                                                        <div class="form-group">
                                                            <asp:LinkButton ID="lnk_update" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_update_Click" ValidationGroup="no"><i class=" fa fa-floppy-o"></i> Create Payment</asp:LinkButton>
                                                      <asp:LinkButton ID="lnk_Cancel" runat="server" CssClass="btn btn-danger btn-sm" OnClick="lnk_Cancel_Click"><i class=" fa fa-close"></i> Cancel</asp:LinkButton>                      
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