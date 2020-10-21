<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Setup.aspx.cs" Inherits="LocalECT.User_Setup" MasterPageFile="~/LocalECT.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Setting /</a>
                        <a href="User_Setup">&nbsp;Users Setup</a>
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
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><i class="fa fa-user"></i> User Setup</h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <asp:LinkButton ID="NewCMD" runat="server"  onclick="NewCMD_Click" CssClass="btn btn-success btn-sm"><i class="fa fa-plus"></i> Create New User</asp:LinkButton>
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

                            <div class="col-md-9 col-sm-9">
                                 <div class="x_panel">
                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-4 col-sm-4 ">User ID *</label>
                                        <div class="col-md-8 col-sm-8 ">
                                            <asp:TextBox ID="UserIDLBL" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label class="col-form-label col-md-4 col-sm-4 ">Password *</label>
                                        <div class="col-md-8 col-sm-8 ">
                                            <asp:TextBox ID="PasswordTXT" runat="server" ValidationGroup="isValid"
                                                TabIndex="3" CssClass="form-control"></asp:TextBox>
                                            <asp:CustomValidator ID="CustomValidator1" runat="server"
                                                ControlToValidate="PasswordTXT" ErrorMessage="*Please enter password"
                                                OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="isValid" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                                        </div>
                                    </div>
                                    <div class="form-group row">

                                        <div class="col-md-3 col-sm-3 ">
                                            <asp:CheckBox ID="chkIsActive" runat="server" AutoPostBack="True"
                                                Checked="True" ForeColor="#0033CC"
                                                OnCheckedChanged="chkIsActive_CheckedChanged" Text="&nbsp;Active" />
                                        </div>
                                       <%-- <div class="col-md-6 col-sm-6 ">
                                            <asp:CheckBox ID="chkIsChangingPasswordRequired" runat="server" AutoPostBack="True"
                                                Checked="True" ForeColor="#E18700"
                                                OnCheckedChanged="chkIsActive_CheckedChanged"
                                                Text="&nbsp;Force Password Change " />
                                        </div>--%>
                                    </div>
                                     <div class="form-group row">
                                    <label class="col-form-label col-md-4 col-sm-4 ">Allowed Campus</label>
                                    <div class="col-md-8 col-sm-8 ">
                                        <asp:DropDownList ID="AllowedCampus_ddl"
                                            runat="server" CssClass="form-control">
                                            <asp:ListItem Selected="True" Value="-1">All</asp:ListItem>
                                            <asp:ListItem Value="1">Males</asp:ListItem>
                                            <asp:ListItem Value="2">Females</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-4 col-sm-4 ">Instructor</label>
                                        <div class="col-md-8 col-sm-8 ">
                                            <asp:DropDownList ID="LecturerCBO" runat="server" CssClass="form-control" TabIndex="6">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                     <div class="form-group row">
                                    <label class="col-form-label col-md-4 col-sm-4 ">Males</label>
                                    <div class="col-md-8 col-sm-8 ">
                                        <asp:DropDownList ID="LecturerMCBO" runat="server" CssClass="form-control" TabIndex="6">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                       <div class="form-group row">
                                        <label class="col-form-label col-md-4 col-sm-4 ">Profile Term</label>
                                        <div class="col-md-8 col-sm-8 ">
                                            <asp:DropDownList ID="PTermCBO" runat="server" CssClass="form-control" TabIndex="7">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label class="col-form-label col-md-4 col-sm-4 ">AD Username</label>
                                        <div class="col-md-8 col-sm-8 ">
                                            <asp:TextBox ID="txtADUserName" runat="server" ValidationGroup="isValid"
                                                CssClass="form-control" TabIndex="2"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-md-4 col-sm-4 ">
                                        <asp:Button ID="AddtoRoleCMD" runat="server" onclick="AddtoRoleCMD_Click" Text="Add User to Role" CssClass="btn btn-success btn-sm"/>
                                            </div>
                                        <div class="col-md-8 col-sm-8 ">
                                             <asp:DropDownList ID="RolesCBO" runat="server" CssClass="form-control" TabIndex="8">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-4 col-sm-4 ">User Name *</label>
                                        <div class="col-md-8 col-sm-8 ">
                                            <asp:TextBox ID="NameTXT" runat="server" CssClass="form-control" TabIndex="2" ValidationGroup="isValid"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="NameTXT" ErrorMessage="*Name is required"
                                                ValidationGroup="isValid" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label class="col-form-label col-md-4 col-sm-4 ">Confirm</label>
                                        <div class="col-md-8 col-sm-8 ">
                                            <asp:TextBox ID="ConfirmTXT" runat="server" ValidationGroup="isValid"
                                                CssClass="form-control" TabIndex="4"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server"
                                                ControlToCompare="PasswordTXT" ControlToValidate="ConfirmTXT"
                                                ErrorMessage="Password and confirm must be the same"
                                                ValidationGroup="isValid" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                                        </div>
                                    </div>
                                    <div class="form-group row">

                                        <%--<div class="col-md-3 col-sm-3 ">
                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True"
                                                Checked="True" ForeColor="#0033CC"
                                                OnCheckedChanged="chkIsActive_CheckedChanged" Text="&nbsp;Active" />
                                        </div>--%>
                                        <div class="col-md-6 col-sm-6 ">
                                            <asp:CheckBox ID="chkIsChangingPasswordRequired" runat="server" AutoPostBack="True"
                                                Checked="True" ForeColor="#E18700"
                                                OnCheckedChanged="chkIsActive_CheckedChanged"
                                                Text="&nbsp;Force Password Change " />
                                        </div>
                                    </div>
                                    
                                <div class="form-group row">
                                    <label class="col-form-label col-md-4 col-sm-4 ">Employee</label>
                                    <div class="col-md-8 col-sm-8 ">
                                        <asp:DropDownList ID="EmployeeCBO" runat="server" CssClass="form-control" TabIndex="5">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                     <div class="form-group row">
                                    <label class="col-form-label col-md-4 col-sm-4 ">&nbsp;&nbsp;</label>
                                    <div class="col-md-8 col-sm-8 ">
                                        <%--<asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" TabIndex="5">
                                        </asp:DropDownList>--%>
                                    </div>
                                </div>

                                    <div class="form-group row">
                                        <label class="col-form-label col-md-4 col-sm-4 ">Females</label>
                                        <div class="col-md-8 col-sm-8 ">
                                            <asp:DropDownList ID="LecturerFCBO" runat="server" CssClass="form-control" TabIndex="6" Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                      <div class="form-group row">
                                        <label class="col-form-label col-md-4 col-sm-4 ">Marks Term</label>
                                        <div class="col-md-8 col-sm-8 ">
                                            <asp:DropDownList ID="MTermCBO" runat="server" CssClass="form-control" TabIndex="8">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-form-label col-md-4 col-sm-4 ">Grades PC Name</label>
                                        <div class="col-md-8 col-sm-8 ">
                                            <asp:TextBox ID="txtGradesPCName" runat="server" ValidationGroup="isValid"
                                                CssClass="form-control" TabIndex="2">---</asp:TextBox>
                                            <asp:Label ID="lblCookie" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row" <%--style="float:right"--%>>
                                        <div class="col-md-12 col-sm-12 ">
                                    <div class="btn-group">
                                        <button type="button" class="btn btn-secondary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                            Actions
                                        </button>
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="lnkGetPc" runat="server" OnClick="lnkGetPc_Click" ToolTip="Get The Name" CssClass="dropdown-item"><i class="fa fa-laptop"></i> Get PC</asp:LinkButton>
                                            <asp:LinkButton ID="lnkSetCookie" runat="server" OnClick="lnkSetCookie_Click" ToolTip="Set a Cookie" CssClass="dropdown-item"><i class="fa fa-laptop"></i> Set PC</asp:LinkButton>
                                            <asp:LinkButton ID="lnkGetCookie" runat="server" OnClick="lnkGetCookie_Click" ToolTip="Read the Cookie" CssClass="dropdown-item"><i class="fa fa-laptop"></i> Check PC</asp:LinkButton>
                                            <div class="dropdown-divider"></div>
                                             <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Security_Roles.aspx" CssClass="dropdown-item"><i class="fa fa-angle-double-left"></i> Goto Roles Manager...</asp:LinkButton>
                                        </div>
                                    </div>
                                          &nbsp;&nbsp;   
                                                     <%--<asp:LinkButton ID="NewCMD" runat="server"  onclick="NewCMD_Click" CssClass="btn btn-success btn-sm"><i class="fa fa-plus"></i> New</asp:LinkButton>--%>
                                                    
                                                <asp:LinkButton ID="SaveCMD" runat="server"  onclick="SaveCMD_Click" CssClass="btn btn-success btn-sm" ValidationGroup="isValid"><i class="fa fa-floppy-o"></i> Save</asp:LinkButton>
                                                 
                                            <asp:LinkButton ID="DeleteCMD" runat="server"  onclick="DeleteCMD_Click" CssClass="btn btn-success btn-sm" ValidationGroup="isValid" OnClientClick="return confirm('Are you sure you want to delete this User?');"><i class="fa fa-trash"></i> Delete</asp:LinkButton>
                                            
                               </div>
                                        </div>

                                </div>
                                      <div class="col-md-6 col-sm-6" align="center">
                                          <asp:GridView ID="grdvUserRoles" runat="server" 
                    AutoGenerateColumns="False" BackColor="#ffffff" BorderColor="#ced4da" 
                    BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSourceUserRoles" 
                    ForeColor="#444444" GridLines="None" Width="100%">
                    <AlternatingRowStyle BackColor="#e9ecef" />
                    <Columns>
                        <asp:BoundField DataField="RoleID" HeaderText="Role ID" 
                            SortExpression="RoleID" />
                        <asp:BoundField DataField="RoleNameEn" HeaderText="Role Name" 
                            SortExpression="RoleNameEn" />
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="#3f658c" Font-Bold="True" ForeColor="White"/>
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
             
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceUserRoles" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ECTDataNew %>" 
                    SelectCommand="SELECT Cmn_UserRoles.RoleID, Cmn_Role.RoleNameEn FROM Cmn_Role INNER JOIN Cmn_UserRoles ON Cmn_Role.RoleID = Cmn_UserRoles.RoleID WHERE (Cmn_UserRoles.UserNo = @UserNo)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="UserIDLBL" DefaultValue="-1" Name="UserNo" 
                            PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
                                          </div>

                            </div>

</div>

                            <div class="col-md-3 col-sm-3">
                                <div class="x_panel">
                                    <div class="img_wrap" align="center">
                                <asp:Image ID="imagePreview" runat="server" CssClass="img-thumbnail"  Width="117" Height="137" ClientIDMode="Static" onerror="this.src='images/noimage.jpg'"/>                               
                                        <hr />
                            </div>
                                    <h2 align="center"><i class="fa fa-search"></i> User Search</h2>
                                    <div class="input-group">
													  <asp:TextBox ID="SearchTXT" runat="server" OnTextChanged="SearchTXT_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>    
													<span class="input-group-btn">
														<asp:LinkButton ID="SearchCMD" runat="server" OnClick="SearchCMD_Click" CssClass="btn btn-success btn-sm" style="float: right;" ToolTip="Users Search"><i class="fa fa-search"></i></asp:LinkButton>                                                
													</span>
												</div>
                                    <br />
                                     <asp:ListBox ID="UsersLST" runat="server" Height="140px" Width="100%" 
                    onselectedindexchanged="UsersLST_SelectedIndexChanged" AutoPostBack="True" 
                    TabIndex="1" CssClass="form-control">
                </asp:ListBox>
                                   <%-- <hr />--%>
                                   <%-- <div class="form-group row">
                                                     <asp:LinkButton ID="NewCMD" runat="server"  onclick="NewCMD_Click" CssClass="btn btn-success btn-sm"><i class="fa fa-plus"></i> New</asp:LinkButton>
                                                    
                                                <asp:LinkButton ID="SaveCMD" runat="server"  onclick="SaveCMD_Click" CssClass="btn btn-success btn-sm" ValidationGroup="isValid"><i class="fa fa-floppy-o"></i> Save</asp:LinkButton>
                                                 
                                            <asp:LinkButton ID="DeleteCMD" runat="server"  onclick="DeleteCMD_Click" CssClass="btn btn-success btn-sm" ValidationGroup="isValid"><i class="fa fa-trash"></i> Delete</asp:LinkButton>
                                             </div>--%> 
                                    </div>
                            </div>
                            <asp:HiddenField ID="isDataChanged" runat="server" />
                            <asp:HiddenField ID="DataStatus" runat="server" />
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   <%-- <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.searchabledropdown.js"></script>
        <script type="text/javascript">
            var $i = jQuery.noConflict();
            $i(document).ready(function () {
                $i("select").searchable({
                    maxListSize: 200, // if list size are less than maxListSize, show them all
                    maxMultiMatch: 300, // how many matching entries should be displayed
                    exactMatch: false, // Exact matching on search
                    wildcards: true, // Support for wildcard characters (*, ?)
                    ignoreCase: true, // Ignore case sensitivity
                    latency: 200, // how many millis to wait until starting search
                    warnMultiMatch: 'top {0} matches ...',
                    warnNoMatch: 'no matches ...',
                    zIndex: 'auto'
                });
            });

        </script>--%>
</asp:Content>
