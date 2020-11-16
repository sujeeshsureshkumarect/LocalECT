<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acc_Search_Edit.aspx.cs" Inherits="LocalECT.Acc_Search_Edit" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Accounting /</a>
                        <a href="Acc_Search">&nbsp;Account Search /</a>
                        <a href="#">&nbsp;Account Details</a>
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
                                            <h2><i class="fa fa-edit"></i> Account Details</h2>
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
                                                        <label>Current Online Status</label>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="ddlOnlineStatus" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="ddlOnlineStatus_SelectedIndexChanged" CssClass="form-control">
                                            <asp:ListItem Selected="True" Value="0">Inactive</asp:ListItem>
                                            <asp:ListItem Value="1">Active</asp:ListItem>
                                            <asp:ListItem Value="2">Fully Activated</asp:ListItem>
                                        </asp:DropDownList>
                                                        </div>
                                                    </div>
</div>
                                                                                    <div class="col-md-6 col-sm-6">
                                                                          <div class="form-group">
                                                        <label>Finance Category</label>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="ddlFinanceCat" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="ddlFinanceCat_SelectedIndexChanged" 
                                CssClass="form-control" DataSourceID="FinCatDs" DataTextField="sFinDesc" 
                                            DataValueField="iFinCategory">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="FinCatDs" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:ECTDataNew %>" 
                                            SelectCommand="SELECT [iFinCategory], [sFinDesc] FROM [Acc_Finance_Category] ORDER BY [iFinCategory]">
                                        </asp:SqlDataSource>
                                                        </div>
                                                    </div>
</div>
                                                                                        <div class="col-md-6 col-sm-6">
                                                                          <div class="form-group">
                                                        <label>Is ACC Wanted ?</label>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="ddlACCWanted" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="ddlACCWanted_SelectedIndexChanged" 
                                CssClass="form-control">
                                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                                                            </div>
                                                                                                                            <div class="col-md-6 col-sm-6">
                                                                       <div class="form-group">
                                                        <label>Reg Term</label>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="ddlRegTerm" runat="server" CssClass="form-control">                                                            
                                                           </asp:DropDownList>
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
                                                        <label>Account Type</label>
                                                        <div class="input-group">
                                                           <asp:DropDownList ID="ddlACCType" runat="server" CssClass="form-control" 
                                                                >                                                              
                                                               <asp:ListItem Selected="True" Value="0">Student Account</asp:ListItem>
                                                               <asp:ListItem Value="1">TOEFL Account</asp:ListItem>
                                                               <asp:ListItem Value="2">IELTS Account</asp:ListItem>
                                                           </asp:DropDownList>
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
                                                        <label>Phone Number</label>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                            </div>
                                                            <div class="col-md-6 col-sm-6">
                                                                       <div class="form-group">
                                                        <label>Note</label>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txtNote" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 col-sm-6">
                                                                       <div class="form-group">
                                                        <label>Sponsored By</label>
                                                        <div class="input-group">
                                                           <asp:DropDownList ID="ddlSponsor" runat="server" 
                                                               CssClass="form-control" 
                                                               >
                                                           </asp:DropDownList>
                                                        </div>
                                                    </div>
</div>
                                                                    <div class="col-md-6 col-sm-6">
                                                                       <div class="form-group">
                                                        <label>Amount</label>
                                                        <div class="input-group">
                                                           <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                                           <asp:Label ID="Label28" runat="server" Text="%"></asp:Label>
                                                        </div>
                                                    </div>
</div>
                                                <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>Remarks</label>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                                                          <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>Admission Payment Type</label>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="drp_PaymentType" runat="server"                                             
                                CssClass="form-control" >
                                        </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                                                          <div class="col-md-6 col-sm-6">
                                                    <div class="form-group">
                                                        <label>Admission Payment Value</label>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txt_Value" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-sm-6">
                                                    &nbsp;<br />
                                                <asp:LinkButton ID="lnk_update" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_update_Click"><i class=" fa fa-floppy-o"></i> Update</asp:LinkButton>
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