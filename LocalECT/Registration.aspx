<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="LocalECT.Registration" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="Registration">&nbsp;Registration</a>                       
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
                                    .table {
                        color:#444444;
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
                                            <h2><i class="fa fa-dashboard"></i> Registration</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                                         <div class="x_content">
                                             <div class="col-md-9 col-sm-12">
                                <div class="form-group row">
                                    <label class="col-form-label col-md-3 col-sm-3 ">Campus</label>
                                    <div class="col-md-6 col-sm-6 ">
                                        <asp:DropDownList ID="Campus_ddl" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Males" Value="1" />
                                            <asp:ListItem Text="Females" Value="2" Selected="True"/>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                              <%--   <div class="form-group row">
                                                     <label class="col-form-label col-md-3 col-sm-3 ">Term</label>
                                                     <div class="col-md-6 col-sm-6 ">
                                                            <asp:DropDownList ID="Terms" runat="server" 
                     AutoPostBack="True" onselectedindexchanged="Terms_SelectedIndexChanged" CssClass="form-control" >                                
            </asp:DropDownList>
                                                     </div>
                                                 </div>--%>
                                <div class="form-group row">
                                    <label class="col-form-label col-md-3 col-sm-3 ">Search Criteria</label>
                                    <div class="col-md-6 col-sm-6 ">
                                        <asp:DropDownList ID="drp_Criteria" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Student ID" Value="sNo" />
                                            <asp:ListItem Text="Student Name" Value="sName" />
                                            <asp:ListItem Text="Phone Number" Value="sPhone1" />  
                                            <asp:ListItem Text="ECT Email" Value="ECTEmail" />                                             
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-form-label col-md-3 col-sm-3 ">Search Text <span class="required">*</span></label>
                                    <div class="col-md-6 col-sm-6 ">
                                        <asp:TextBox ID="txt_Search" runat="server" CssClass="form-control" OnTextChanged="lnk_Search_Click"></asp:TextBox>
                                         <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="*Search Text Required" ControlToValidate="txt_Search" ForeColor="Red" ValidationGroup="no">
                                            </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3 col-sm-3 ">
                                        <asp:LinkButton ID="lnk_Search" runat="server" CssClass="btn btn-success btn-sm" OnClick="lnk_Search_Click" ValidationGroup="no"><i class="fa fa-search"></i> Search</asp:LinkButton>
                                    </div>
                                </div>
                            </div> 
                                                      <div class="col-md-12 col-sm-12">
                                 <hr />
                                 <div class="x_content bs-example-popovers">
                                  <div class="alert alert-info alert-dismissible " role="alert" runat="server" id="alertsearch" visible="false">

                            <strong>Search Result - </strong><asp:Label runat="server" ID="lbl_Count" ClientIDMode="Static"></asp:Label>
                            
                        </div>
                                     </div>
                                 <div id="divResult" runat="server" class="table-responsive">
                                     <asp:Repeater ID="RepterDetails" runat="server">
                                         <HeaderTemplate>
                                             <table id='datatable' class='table table-striped table-bordered' style='width: 100%'>
                                                 <thead>
                                                     <tr class='headings'>
                                                         <th class="sorting_asc" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Name: activate to sort column descending">#</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">ID</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Student Name</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Account No.</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Phone No.</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Email</th>
                                                         <th class="sorting" tabindex="0" aria-controls="datatable" rowspan="1" colspan="1" aria-label="Salary: activate to sort column ascending">Actions</th>
                                                     </tr>
                                                 </thead>
                                         </HeaderTemplate>
                                         <ItemTemplate>
                                             <tr>
                                                 <td align='center'><%# Container.ItemIndex+1 %></td>
                                                 <td><%#Eval("sNo")%></td>
                                                 <td><%#Eval("sName")%></td>
                                                 <td><%#Eval("sAccount")%></td>
                                                 <td><%#Eval("sPhone1")%></td>
                                                 <td><%#Eval("ECTEmail")%></td>
                                                 <td>
                                                     <div class="btn-group">
                                                         <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                             Actions
                                                         </button>
                                                         <div class="dropdown-menu">
                                                             <a class="dropdown-item" href="Acc_Search_Edit?sAcc=<%#Eval("sAccount")%>">Edit</a>
                                                             <a class="dropdown-item" href="Acc_Search_Fee_Payment?sAcc=<%#Eval("sAccount")%>">Receive Fees Payment</a>
                                                             <a class="dropdown-item" href="Acc_Search_Other_Revenue_Payment?sAcc=<%#Eval("sAccount")%>">Receive Other Revenue Payment</a>                                                         
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
                                           <%-- <asp:HiddenField ID="hdnMF" runat="server" />--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>