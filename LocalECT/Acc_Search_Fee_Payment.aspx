<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acc_Search_Fee_Payment.aspx.cs" Inherits="LocalECT.Acc_Search_Fee_Payment" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                   <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Accounting /</a>
                        <a href="Acc_Search">&nbsp;Account Search /</a>
                        <a href="#">&nbsp;Receive Fees Payment</a>
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
                                            <h2><i class="fa fa-money"></i> Receive Fees Payment</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <a href="Acc_Search.aspx" class="btn btn-success btn-sm"><i class="fa fa-search"></i> Account Search</a>
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
                                                        <label>Student Account Number</label><a href="Acc_Search.aspx" class="btn btn-success btn-sm" style="float:right;"><i class="fa fa-search"></i> Account Search</a>
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
                                                            <asp:TextBox ID="txtDatePayment" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="DD/MM/YYYY"></asp:TextBox>
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
                                                                <%--<asp:ListItem Value="1">Paid</asp:ListItem>
                                                                <asp:ListItem Value="2">Returned</asp:ListItem>
                                                                <asp:ListItem Value="3">Insurance</asp:ListItem>
                                                                <asp:ListItem Value="4">Canceled</asp:ListItem>--%>
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
                                                                <asp:TextBox ID="txtDueDate" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="DD/MM/YYYY"></asp:TextBox>                                                                
                                                            </div>
                                                        </div>
                                                    </div>
                                                     <div class="col-md-6 col-sm-6">
                                                        <div class="form-group">
                                                            <label>Bank</label>
                                                            <div class="input-group">
                                                                <asp:DropDownList ID="ddlBank" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                          <%--      <asp:SqlDataSource ID="BankDS" runat="server"
                                                                    ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>"
                                                                    SelectCommand="SELECT [intBank], [strBankEn] FROM [Acc_Banks] ORDER BY [strBankEn]"></asp:SqlDataSource>--%>
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
                                                                <asp:HiddenField ID="hdnChquenoUpdate" runat="server" Value="0" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                 <div class="col-md-6 col-sm-6">
                                                        <div class="form-group">
                                                            <asp:LinkButton ID="lnk_update" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_update_Click" ValidationGroup="no"><i class=" fa fa-plus"></i> Add Payment</asp:LinkButton>
                                                      <asp:LinkButton ID="lnk_Cancel" runat="server" CssClass="btn btn-danger btn-sm" OnClick="lnk_Cancel_Click"><i class=" fa fa-close"></i> Cancel</asp:LinkButton>                      
                                                            <asp:LinkButton ID="lnk_Print" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_Print_Click" Visible="false" ToolTip="Print PDF"><i class=" fa fa-print"></i> Print</asp:LinkButton>                      
                                                        </div>
                                                    </div>
                                                
                                                <div class="col-md-12" runat="server" id="div_Entries">
                                                    <hr />
                                                              <div id="divResult" runat="server" class="table-responsive">
                                     <asp:Repeater ID="RepterDetails" runat="server">
                                         <HeaderTemplate>
                                             <table id='datatable' class='table table-striped table-bordered' style='width: 100%'>
                                                 <thead>
                                                     <tr class='headings'>
                                                         <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending">#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Voucher-Entry #</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Payment Way</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Amount</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Cheque #</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Due Date</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Actions</th>
                                                     </tr>
                                                 </thead>
                                         </HeaderTemplate>
                                         <ItemTemplate>
                                             <tr>
                                                 <td align='center'><%# Container.ItemIndex+1 %></td>
                                                 <td><%#Eval("strVoucherNo")%>-<%#Eval("lngEntryNo")%></td>
                                                 <td><%#Eval("strPaymentTypeEn")%></td>
                                                 <td><%#Eval("curCredit")%></td>
                                                 <td><%#Eval("strChequeNo")%></td>
                                                  <td><span style="display: none;"><%#Eval("dateDue","{0:yyyyMMdd}")%></span><%#Eval("dateDue","{0:dd/MM/yyyy}")%></td>
                                                 <td>
                                                     <div class="btn-group">
                                                         <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                             Actions
                                                         </button>
                                                         <div class="dropdown-menu">
                                                             <%--<a class="dropdown-item" href="Acc_Search_Edit?sAcc=<%#Eval("strVoucherNo")%>">Edit</a>
                                                             <a class="dropdown-item" href="Acc_Search_Fee_Payment?sAcc=<%#Eval("strVoucherNo")%>">Delete</a>  --%>   
                                                              <asp:LinkButton ID="lnk_Edit" runat="server" CssClass="dropdown-item" CommandArgument='<%#Eval("lngEntryNo")%>' oncommand="EditBTN_Command"><i class="fa fa-edit"></i> View / Edit</asp:LinkButton>
                                                             <asp:LinkButton ID="lnk_Delete" runat="server" CssClass="dropdown-item" CommandArgument='<%#Eval("lngEntryNo")%>' oncommand="DeleteBTN_Command" OnClientClick="return confirm('Are you sure you want to delete?'); " CommandName='<%#Eval("lngCheque")%>'><i class="fa fa-trash"></i> Delete</asp:LinkButton>
                                                         </div>
                                                     </div>
                                                 </td>
                                             </tr>
                                         </ItemTemplate>
                                         <FooterTemplate>
                                             </table>  
                                         </FooterTemplate>
                                     </asp:Repeater>
                                 </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    
                                               <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script type="text/javascript">
            var $j = jQuery.noConflict();
            $j(function () {
                $j("#txtDatePayment").datepicker({ dateFormat: 'dd/mm/yy' });
                $j("#txtDueDate").datepicker({ dateFormat: 'dd/mm/yy' });
            });
        </script>
    </asp:Content>