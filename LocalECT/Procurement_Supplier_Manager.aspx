<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Procurement_Supplier_Manager.aspx.cs" Inherits="LocalECT.Procurement_Supplier_Manager" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Procurement /</a>
                        <a href="Procurement_Supplier_Manager">&nbsp;Supplier Manager</a>

                    </h3>
                                </div>
                                <style>
                                     .breadcrumb {
                        padding: 8px 15px;
                        margin-bottom: 20px;
                        list-style: none;
                        background-color: #ededed;
                        border-radius: 4px;
                        font-size: 13px;
                    }
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }                                  
                                </style>               
                                <script>
                                    setTimeout(explode, 200);
                                    function explode() {                                       
                                        var test = document.getElementById('datatable_info').textContent;
                                        document.getElementById('lbl_Count').textContent = "(" + test + ")";
                                    }
                                    $(document).on('keyup', '.dataTables_filter input', function () {                                         
                                        var test = document.getElementById('datatable_info').textContent;
                                        document.getElementById('lbl_Count').textContent = "(" + test + ")";
                                    })
                                </script>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-shopping-cart"></i> Supplier Manager</h2>
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
            
                                                   <div class="col-md-9 col-sm-12">
                                <div class="form-group row">
                                    <label class="col-form-label col-md-3 col-sm-3 ">Supplier ID</label>
                                    <div class="col-md-6 col-sm-6 ">
                                        <asp:TextBox ID="RoleIDLBL" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-md-3 col-sm-3 ">Supplier Name *</label>
                                    <div class="col-md-6 col-sm-6 ">
                                        <asp:TextBox ID="NameTXT" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ControlToValidate="NameTXT" ErrorMessage="*Supplier Name is required"
                                            ValidationGroup="isValid" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                               <div class="form-group row">
                                    <label class="col-form-label col-md-3 col-sm-3 ">Supplier Phone</label>
                                    <div class="col-md-6 col-sm-6 ">
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>                                        
                                    </div>
                                </div>
                                                        <div class="form-group row">
                                    <label class="col-form-label col-md-3 col-sm-3 ">Supplier Fax</label>
                                    <div class="col-md-6 col-sm-6 ">
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>                                        
                                    </div>
                                </div>
                                                                                 <div class="form-group row">
                                    <label class="col-form-label col-md-3 col-sm-3 ">Supplier PO Box</label>
                                    <div class="col-md-6 col-sm-6 ">
                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>                                        
                                    </div>
                                                                                      <div class="col-md-3 col-sm-3 ">
                                        <asp:LinkButton ID="NewCMD" runat="server" CssClass="btn btn-success btn-sm" OnClick="NewCMD_Click"><i class="fa fa-plus"></i> New</asp:LinkButton>

                                        <asp:LinkButton ID="SaveCMD" runat="server" CssClass="btn btn-success btn-sm" ValidationGroup="isValid" OnClick="SaveCMD_Click"><i class="fa fa-floppy-o"></i> Save</asp:LinkButton>
                                    </div>
                                    <div class="col-md-3 col-sm-3 ">
                                        <asp:HiddenField ID="isDataChanged" runat="server" />
                                        <asp:HiddenField ID="DataStatus" runat="server" />
                                    </div>
                                </div>
                             
                            </div>

                                                 <div class="col-md-12 col-sm-12">
                                 <hr />
                                                     <div class="x_content bs-example-popovers">
                                                         <div class="alert alert-info alert-dismissible " role="alert">
                                                             <strong>
                                                                 <asp:Label runat="server" ID="lbl_Count" ClientIDMode="Static"></asp:Label>
                                                             </strong>
                                                         </div>
                                                     </div>
                                 <div id="divResult" runat="server" class="table-responsive">
                                     <asp:Repeater ID="RepterDetails" runat="server">
                                         <HeaderTemplate>
                                             <table id='datatable' class='table table-striped table-bordered' style='width: 100%'>
                                                 <thead>
                                                     <tr class='headings'>
                                                         <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending" width="50px">#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" width="50px">Supplier ID</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Supplier Name</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" >Supplier Phone</th>  
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" >FAX</th>  
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending" >PO Box</th>  
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Actions</th>
                                                     </tr>
                                                 </thead>
                                         </HeaderTemplate>
                                         <ItemTemplate>
                                             <tr>
                                                 <td align='center'><%# Container.ItemIndex+1 %></td>
                                                 <td><%#Eval("iSupplier")%></td>
                                                 <td><%#Eval("sSupplierName")%></td>
                                                 <td><%#Eval("sPhone")%></td>
                                                 <td><%#Eval("sFax")%></td>
                                                 <td><%#Eval("sPOBox")%></td>
                                                 <td>
                                                     <div class="btn-group">
                                                         <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                             Actions
                                                         </button>
                                                         <div class="dropdown-menu">
                                                             <asp:LinkButton ID="lnk_Edit" runat="server" CssClass="dropdown-item" CommandArgument='<%#Eval("iSupplier")%>' oncommand="EditBTN_Command"><i class="fa fa-edit"></i> View / Edit</asp:LinkButton>
                                                             <asp:LinkButton ID="lnk_Delete" runat="server" CssClass="dropdown-item" CommandArgument='<%#Eval("iSupplier")%>' oncommand="DeleteBTN_Command" OnClientClick="return confirm('Are you sure you want to delete?'); "><i class="fa fa-trash"></i> Delete</asp:LinkButton>
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
    </asp:Content>