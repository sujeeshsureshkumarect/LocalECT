<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="LocalECT.MyProfile" MasterPageFile="~/LocalECT.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                   <%-- <h3>Welcome To Emirates College Of Technology (ECT)</h3>--%>
                                </div>
                                <style>
                                    .page-title .title_left {
                                        width: 100%;
                                        float: left;
                                        display: block;
                                    }
                                </style>
                                <%--  <div class="title_right">
                <div class="col-md-5 col-sm-5   form-group pull-right top_search">
                  <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search for...">
                    <span class="input-group-btn">
                      <button class="btn btn-default" type="button">Go!</button>
                    </span>
                  </div>
                </div>
              </div>--%>
                            </div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-user"></i> My Profile</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                                </li>                                              
                                                <li><a class="close-link"><i class="fa fa-close"></i></a>
                                                </li>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="x_content">
                                      
                                             <div class="card">  
                <div class="card-header bg-primary text-white">  
                    <h5 class="card-title">Employee Information</h5>  
                </div>  
                <div class="card-body">  
                    <div class="row">  
                        <div class="col-sm-9 col-md-9 col-xs-12">  
                            <div class="row">  
                                       <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Employee ID</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-user"></i></span>  
                                            </div>  
                                            <asp:TextBox ID="txt_EmployeeID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>  
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rvfLastName" ValidationGroup="no" ControlToValidate="txtLastName" CssClass="text-danger" runat="server" ErrorMessage="Last Name is required."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div> 
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Employee Name</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-user"></i></span>  
                                            </div>  
                                            <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>  
                                        </div>  
                                       <%-- <asp:RequiredFieldValidator ID="rfvFirstName" ValidationGroup="no" ControlToValidate="txtFisrtName" CssClass="text-danger" runat="server" ErrorMessage="First Name is required."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div> 
                                <asp:HiddenField ID="hdfiUnifiedID" runat="server" />
                          
                            </div> 
                        
                                        <div class="row">  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Designation</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-graduation-cap"></i></span>  
                                            </div>  
                                              <asp:TextBox ID="txt_Designation" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>   
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvGender" ValidationGroup="no" ControlToValidate="ddlGender" InitialValue="-1" CssClass="text-danger" runat="server" ErrorMessage="Choose gender."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div>  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Department</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-calendar-o"></i></span>  
                                            </div>  
                                            <asp:TextBox ID="txt_Department" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>  
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvDateofBith" ValidationGroup="no" ControlToValidate="txtDateofBirth" CssClass="text-danger" runat="server" ErrorMessage="Choose date of birth."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div>  
                            </div> 

                            <div class="row">  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Gender</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-user"></i></span>  
                                            </div>  
                                              <asp:TextBox ID="txt_Gender" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>   
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvGender" ValidationGroup="no" ControlToValidate="ddlGender" InitialValue="-1" CssClass="text-danger" runat="server" ErrorMessage="Choose gender."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div>  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Category</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-calendar"></i></span>  
                                            </div>  
                                            <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>  
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvDateofBith" ValidationGroup="no" ControlToValidate="txtDateofBirth" CssClass="text-danger" runat="server" ErrorMessage="Choose date of birth."></asp:RequiredFieldValidator>  --%>
                                    </div>  
                                </div>  
                            </div>                                                    
                            <div class="row">  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Contact Number</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-phone"></i></span>  
                                            </div>  
                                            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>  
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvPhoneNumber" ControlToValidate="txtPhoneNumber" CssClass="text-danger" runat="server" ErrorMessage="Phone Number is required."  Display="Dynamic" ValidationGroup="no"></asp:RequiredFieldValidator>  
                                        <asp:RegularExpressionValidator ID="revPhoneNumber" ControlToValidate="txtPhoneNumber" runat="server" ErrorMessage="Please enter digit only" Display="Dynamic" ValidationExpression="^([7-9]{1})([0-9]{9})$" ValidationGroup="no" CssClass="text-danger"></asp:RegularExpressionValidator>  --%>
                                    </div>  
                                </div>  
                                <div class="col-sm-6 col-md-6 col-xs-12">  
                                    <div class="form-group">  
                                        <label>Email</label>  
                                        <div class="input-group">  
                                            <div class="input-group-prepend">  
                                                <span class="input-group-text"><i class="fa fa-envelope"></i></span>  
                                            </div>  
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ReadOnly="true" style = "text-transform:lowercase;"></asp:TextBox>  
                                        </div>  
                                        <%--<asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" CssClass="text-danger" runat="server" ErrorMessage="Email is required." Display="Dynamic" ValidationGroup="no"></asp:RequiredFieldValidator>  
                                        <asp:RegularExpressionValidator ID="revEmail" ControlToValidate="txtEmail" runat="server" ErrorMessage="Please enter valid email" Display="Dynamic" CssClass="text-danger" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="no"></asp:RegularExpressionValidator>  --%>
                                    </div>  
                                </div>  
                            </div>  
                        </div>
                        <style>
                            .img_description {
                                position: absolute;
                                top: 0;
                                bottom: 0;
                                left: 0;
                                right: 0;
                                /*background: rgba(29, 106, 154, 0.72);*/
                                background: rgba(42, 63, 84, 0.72);
                                padding-top: 50px;
                                padding-bottom: 50px;
                                color: #fff;
                                visibility: hidden;
                                opacity: 0;
                                /* transition effect. not necessary */
                                transition: opacity .2s, visibility .2s;
                            }

                            .img_wrap:hover .img_description {
                                visibility: visible;
                                opacity: 1;
                            }

                            .img_wrap {
                                position: relative;
                                height: 190px;
                                width: 150px;
                            }
                            .bg-primary {
    background-color: #3f658c!important;
}
                        </style>
                        <div class="col-sm-3 col-md-3 col-xs-12" align="center">
                            <div class="img_wrap">
                                <asp:Image ID="imagePreview" runat="server" CssClass="img-thumbnail" ImageUrl="Handler1.ashx" Width="150" Height="175" ClientIDMode="Static" />
                                <%--<p class="img_description" style="text-align: center; font-weight: bold">Click on the Below Browse Button to Change the Profile Picture.</p>--%>
                            </div>

                           <%-- <div class="form-group">  --%>
                                <%--<label>Profile Picture</label>  --%>
                              <%--  <div class="custom-file">  
                                    <asp:FileUpload ID="ProfileFileUpload" runat="server" CssClass="custom-file-input" ToolTip="Change Profile Pictire"/>  
                                    <label class="custom-file-label">Profile Picture</label>  
                                </div>  
                                <asp:RequiredFieldValidator ID="rfvProfileFileUpload" ControlToValidate="ProfileFileUpload" runat="server" CssClass="text-danger" ErrorMessage="Choose image to upload" ValidationGroup="no"></asp:RequiredFieldValidator>  
                            </div>--%>  
                            <%--<asp:Button ID="btnSubmit" runat="server" Text="Update Profile" CssClass="btn btn-success btn-sm" OnClick="btnSubmit_Click" ValidationGroup="no"/>--%>  
                        </div>  
                    </div>  
                  <%--  <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-info rounded-0" OnClick="btnReset_Click" />  --%>                   
                </div>  
            </div>  

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    </asp:Content>