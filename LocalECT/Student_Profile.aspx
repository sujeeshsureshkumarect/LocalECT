<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Profile.aspx.cs" Inherits="LocalECT.Student_Profile" MasterPageFile="~/LocalECT.Master" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
                        <div class="">
                            <div class="page-title">
                                <div class="title_left">
                                    <h3 class="breadcrumb">
                        <a href="Home">Home /</a>
                        <a href="#">&nbsp;Registration /</a>
                        <a href="StudentSearch">&nbsp;Student Search /</a>
                        <a href="#">&nbsp;Student Profile</a>
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
                                            <h2><i class="fa fa-user"></i> Student Profile</h2>
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

                                            <div class="x_content bs-example-popovers">
                                                <div class="alert alert-info alert-dismissible " role="alert">
                                                    <strong>Student Information</strong>
                                                </div>
                                            </div>

                                            <%--Column1--%>
                                            <div class="col-md-6 col-sm-6"> 
                                               <%-- <div class="col-md-12 col-sm-12"> --%>
                                                <div class="x_panel">
                                                    <div id="img" align="middle">
                                                        <asp:Label ID="lblIsVerfiedFromRegistrar" runat="server" Text="Verified from the Registrar" style="color: #009933; font-weight: 700"></asp:Label>
                                                        <asp:HiddenField ID="hdnSerial" runat="server" />
                                                        <asp:HiddenField ID="Pic" runat="server" />
                                                        <br />
                                                        <asp:LinkButton ID="btnGetEID" runat="server" CssClass="btn btn-success btn-sm" OnClick="btnGetEID_Click"><i class="fa fa-download"></i> Read from EID</asp:LinkButton>
                                                        <br />
                                                        <asp:Image ID="imgStudent" runat="server" ClientIDMode="Static" Height="130px" 
                                ImageUrl="~/Images/Students/Student.jpg" Width="110px" />
                                                        <hr />
                                                    </div>
                                                    <style>
                                                        #imgStudent {
                                                            padding: .25rem;
                                                            background-color: #fff;
                                                            border: 1px solid #dee2e6;
                                                            border-radius: .25rem;
                                                            max-width: 100%;
                                                            height: auto;
                                                        }
                                                    </style>

                                                <div class="form-group row">
                                                    <label class="col-form-label col-md-3 col-sm-3">Unified No.</label>
                                                    <div class="col-md-9 col-sm-9 ">
                                                        <asp:TextBox ID="lblUnified" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-form-label col-md-3 col-sm-3">Student Session</label>
                                                    <div class="col-md-9 col-sm-9 ">
                                                        <asp:DropDownList ID="ddlSession" runat="server" TabIndex="1"
                                                            DataTextField="strShiftEn"
                                                            DataValueField="byteShift" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                 <div class="form-group row">
                                                    <label class="col-form-label col-md-3 col-sm-3">Full Name (EN)</label>
                                                     <div class="col-md-9 col-sm-9 ">
                                                         <asp:TextBox ID="txtNameEn" runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                             ControlToValidate="txtNameEn" ErrorMessage="Full Name (En) is requied."
                                                             SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Full Name (En) is requied.</asp:RequiredFieldValidator>
                                                     </div>
                                                </div>
                                                 <div class="form-group row">
                                                    <label class="col-form-label col-md-3 col-sm-3">First Name (EN)</label>
                                                    <div class="col-md-9 col-sm-9 ">
                                                        <asp:TextBox ID="txtFNameEn" runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="txtFNameEn" ErrorMessage="First Name (En) is requied."
                                                            SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*First Name (En) is requied.</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-form-label col-md-3 col-sm-3">Last Name (EN)</label>
                                                    <div class="col-md-9 col-sm-9 ">
                                                        <asp:TextBox ID="txtLNameEn" runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                            ControlToValidate="txtLNameEn" ErrorMessage="Last Name (En) is requied."
                                                            SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Last Name (En) is requied.</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                 <div class="form-group row">
                                                    <label class="col-form-label col-md-3 col-sm-3">Full Name (AR)</label>
                                                    <div class="col-md-9 col-sm-9 ">
                                                        <asp:TextBox ID="txtNameAr" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                            ControlToValidate="txtNameAr" ErrorMessage="Full Name (Ar) is requied."
                                                            SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Full Name (Ar) is requied.</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                    <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">First Name (AR)</label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtFNameAr" runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                                ControlToValidate="txtFNameAr" ErrorMessage="First Name (Ar) is requied."
                                                                SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*First Name (Ar) is requied.</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                       <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">Last Name (AR)</label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtLNameAr" runat="server" CssClass="form-control" TabIndex="7"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                                ControlToValidate="txtLNameAr" ErrorMessage="Last Name (Ar) is requied."
                                                                SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*LAst Name (Ar) is requied.</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3" style="color: #FF3300;">Access Category</label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:DropDownList ID="ddlAccess" runat="server" DataSourceID="AccessDs"
                                                                DataTextField="sAccessCategory" DataValueField="iAccessCategory"
                                                                CssClass="form-control" Enabled="False" TabIndex="8">
                                                            </asp:DropDownList>
                                                            <asp:SqlDataSource ID="AccessDs" runat="server"
                                                                ConnectionString="<%$ ConnectionStrings:ECTDataNew %>"
                                                                SelectCommand="SELECT [iAccessCategory], [sAccessCategory] FROM [ACMS_Category]"></asp:SqlDataSource>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-5 col-sm-5">Health Fitness Certificate ?</label>
                                                         <div class="col-md-7 col-sm-7 ">
                                                             <asp:RadioButtonList ID="rbnFitnessStatus" runat="server"
                                                                 RepeatDirection="Horizontal" TabIndex="20" CssClass="form-control">
                                                                 <asp:ListItem Value="0">Yes</asp:ListItem>
                                                                 <asp:ListItem Selected="True" Value="1">No</asp:ListItem>
                                                             </asp:RadioButtonList>
                                                         </div>
                                                     </div>
                                                    <div class="form-group row">
                                                    <label class="col-form-label col-md-5 col-sm-5">People of Determination ?</label>
                                                    <div class="col-md-7 col-sm-7 ">
                                                        <asp:DropDownList ID="DropDownList1" runat="server" TabIndex="21"
                                                            DataTextField="strShiftEn"
                                                            DataValueField="byteShift" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                    <hr />
                                                    <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">Phone 1</label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtPhone1" runat="server" CssClass="form-control" TabIndex="22">9999999999</asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                                ControlToValidate="txtPhone1" ErrorMessage="Phone 1  is requied."
                                                                SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Phone 1  is requied.</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">Phone 2</label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtPhone2" runat="server" CssClass="form-control" TabIndex="23">NA</asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">E-Mail</label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TabIndex="24">xyz@xyz.com</asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                ControlToValidate="txtEmail" ErrorMessage="Valid email only."
                                                                SetFocusOnError="True"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Valid email only.</asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">ECT E-Mail</label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtECTEmail" runat="server" CssClass="form-control" TabIndex="25"
                                                                Enabled="False" ReadOnly="True"></asp:TextBox>
                                                            <asp:Button ID="btnCreateEmail" runat="server" CssClass="btn btn-success btn-sm"
                                                                Text="Create Email" Visible="false" onclick="btnCreateEmail_Click" />
                                                        </div>
                                                    </div>
                                                       <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">Address</label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TabIndex="26">NA</asp:TextBox>
                                                        </div>
                                                    </div>   
                                                    <hr />
                                                    
                                                      <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">Emirates ID</label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtIDNo" runat="server" CssClass="form-control" TabIndex="27">999999999999999</asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                                ControlToValidate="txtIDNo" ErrorMessage="EID is required."
                                                                SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*EID is required.</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div> 
                                                     <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">Passport No</label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtIdentityNo" runat="server" CssClass="form-control" TabIndex="28">NA</asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                                ControlToValidate="txtIdentityNo" ErrorMessage="Passport no is required."
                                                                SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Passport no is required.</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div> 
                                                     <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3" style="color:#FF3300;">Unified No</label>
                                                        <div class="col-md-4 col-sm-4 ">
                                                            <asp:TextBox ID="txtUnifiedNo" runat="server" CssClass="form-control" TabIndex="29" ToolTip="Passport Unified No or Visa Unified No">NA</asp:TextBox>
                                                        </div>
                                                          <label class="col-form-label col-md-5 col-sm-5" style="color:#993300;">locals passport or expats visa</label>
                                                    </div> 

                                                     <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">Al Ethbara#</label>
                                                        <div class="col-md-4 col-sm-4 ">
                                                            <asp:TextBox ID="txtEthbara" runat="server" CssClass="form-control" TabIndex="30">NA</asp:TextBox>
                                                        </div>
                                                          <label class="col-form-label col-md-5 col-sm-5" style="color:#993300;">from locals only</label>
                                                    </div> 

                                                      <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3" style="color:#FF3300;">City No</label>
                                                        <div class="col-md-4 col-sm-4 ">
                                                            <asp:TextBox ID="txtCityNo" runat="server" CssClass="form-control" TabIndex="31" >999</asp:TextBox>
                                                        </div>
                                                          <label class="col-form-label col-md-5 col-sm-5" style="color:#993300;">from Family Book</label>
                                                    </div> 

                                                       <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3" style="color:#FF3300;">Family No</label>
                                                        <div class="col-md-4 col-sm-4 ">
                                                            <asp:TextBox ID="txtFamilyNo" runat="server" CssClass="form-control" TabIndex="32" >999</asp:TextBox>
                                                        </div>
                                                          <label class="col-form-label col-md-5 col-sm-5" style="color:#993300;">from Family Book</label>
                                                    </div>
                                                       <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3" style="color:#FF3300;">Family Book No</label>
                                                        <div class="col-md-4 col-sm-4 ">
                                                            <asp:TextBox ID="txtFamilyBookNo" runat="server" CssClass="form-control" TabIndex="33" >999999</asp:TextBox>
                                                        </div>
                                                          <label class="col-form-label col-md-5 col-sm-5" style="color:#993300;">from locals only</label>
                                                    </div>

                                                      <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3" style="color:#FF3300;">National No</label>
                                                        <div class="col-md-4 col-sm-4 ">
                                                            <asp:TextBox ID="txtNationalNo" runat="server" CssClass="form-control" TabIndex="34" >NA</asp:TextBox>
                                                        </div>
                                                          <label class="col-form-label col-md-5 col-sm-5" style="color:#993300;">from expat passport if founded</label>
                                                    </div>


                                                    <%--</div>--%>
                                                    </div>
                                            </div>

                                            <%--Column2--%>
                                            <div class="col-md-6 col-sm-6">
                                                 <div class="x_panel">
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Gender</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:RadioButtonList ID="rbnGender" runat="server"
                                                                 RepeatDirection="Horizontal" TabIndex="9" CssClass="form-control">
                                                                 <asp:ListItem Value="0">Female</asp:ListItem>
                                                                 <asp:ListItem Selected="True" Value="1">Male</asp:ListItem>
                                                             </asp:RadioButtonList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Marital Status</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlMaritalStatus" runat="server" TabIndex="10"
                                                                 CssClass="form-control">
                                                                 <asp:ListItem Selected="True" Value="0">Not Married</asp:ListItem>
                                                                 <asp:ListItem Value="1">Married</asp:ListItem>
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Birth Date</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control" TabIndex="11" ValidationGroup="SD" ToolTip="mm/dd/yyyy" TextMode="Date"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                                 ControlToValidate="txtBirthDate" ErrorMessage="Birth Date is requied."
                                                                 SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Birth Date is requied.</asp:RequiredFieldValidator>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Birth Country</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlBirthCountry" runat="server" TabIndex="12"
                                                                 CssClass="form-control" AutoPostBack="True"
                                                                 DataTextField="strCountryDescEn" DataValueField="byteCountry">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Birth City</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlBirthCity" runat="server" TabIndex="13" CssClass="form-control"
                                                                 DataSourceID="BirthCityDS" DataTextField="strCityDescEn"
                                                                 DataValueField="byteCity">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Resident Country</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlResidentCountry" runat="server" TabIndex="14"
                                                                 AutoPostBack="True"
                                                                 DataTextField="strCountryDescEn" DataValueField="byteCountry" CssClass="form-control">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Resident City</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlResidentCity" runat="server" TabIndex="15"
                                                                 CssClass="form-control" DataSourceID="ResidentCityDS" DataTextField="strCityDescEn"
                                                                 DataValueField="byteCity">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Home Country</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlHomeCountry" runat="server" TabIndex="16"
                                                                 CssClass="form-control" AutoPostBack="True"
                                                                 DataTextField="strCountryDescEn" DataValueField="byteCountry">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Home City</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlHomeCity" runat="server" TabIndex="17" CssClass="form-control"
                                                                 DataSourceID="HomeCityDS" DataTextField="strCityDescEn"
                                                                 DataValueField="byteCity">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Nationality</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlNationality" runat="server" TabIndex="18"
                                                                 CssClass="form-control"
                                                                 DataTextField="strNationalityDescEn" DataValueField="byteNationality">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Nationality of Mother</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlNationalityofMother" runat="server" TabIndex="19"
                                                                 CssClass="form-control"
                                                                 DataTextField="strNationalityDescEn" DataValueField="byteNationality">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Language</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlLanguage" runat="server" TabIndex="21" CssClass="form-control" DataTextField="strLanguageDescEn"
                                                                 DataValueField="byteLanguage">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <hr />
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-4 col-sm-4">Employment Status</label>
                                                         <div class="col-md-8 col-sm-8 ">
                                                             <asp:RadioButtonList ID="rbnEmploymentStatus" runat="server"
                                                                 RepeatDirection="Horizontal" TabIndex="35" CssClass="form-control">
                                                                 <asp:ListItem Value="0" Selected="True">Not Employed</asp:ListItem>
                                                                 <asp:ListItem Value="1">Employed</asp:ListItem>
                                                             </asp:RadioButtonList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Work Place</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlIWork" runat="server" TabIndex="36"
                                                                 CssClass="form-control" DataTextField="strWorkPlaceEn"
                                                                 DataValueField="intWorkPlace">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3" style="color:#FF3300;">Company Name</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtCompany" runat="server"  TabIndex="37" CssClass="form-control">NA</asp:TextBox>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3" style="color: #FF3300;">Country</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlEmployerCountry" runat="server" TabIndex="38"
                                                                 CssClass="form-control" DataTextField="strCountryDescEn" DataValueField="byteCountry">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                      <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3" style="color: #FF3300;">Emirate</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlEmployerEmirate" runat="server" TabIndex="39"
                                                                 CssClass="form-control" DataTextField="strEmirateEn" DataValueField="byteEmirate">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                      <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Sector</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlEmploymentSector" runat="server" TabIndex="40"
                                                                 CssClass="form-control" DataTextField="SectorNameEn" DataValueField="SectorID">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                      <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3" style="color:#FF3300;">Industry</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtEmployerIndustry" runat="server"  TabIndex="41" CssClass="form-control">NA</asp:TextBox>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Work Phone</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:TextBox ID="txtWorkPhone" runat="server" TabIndex="42" CssClass="form-control">999999999</asp:TextBox>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Job Title</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:TextBox ID="txtJob" runat="server" TabIndex="43" CssClass="form-control">NA</asp:TextBox>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Visa On</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlVisa" runat="server" TabIndex="44"
                                                                 CssClass="form-control" DataTextField="strSponsorEn"
                                                                 DataValueField="intSponsor">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Expiry</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:TextBox ID="txtExpiry" runat="server" TabIndex="45" CssClass="form-control" TextMode="Date" ToolTip="mm/dd/yyyy"></asp:TextBox>
                                                             <asp:RangeValidator ID="RangeValidator2" runat="server"
                                                                 ControlToValidate="txtExpiry" Display="Dynamic" ErrorMessage="Date Only"
                                                                 MaximumValue="01/01/3000" MinimumValue="01/01/1900" SetFocusOnError="True"
                                                                 Type="Date" ValidationGroup="SD" ForeColor="Red">mm/dd/yyyy</asp:RangeValidator>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3">Sponsor</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlSponsor" runat="server" TabIndex="46"
                                                                 CssClass="form-control" DataTextField="strDelegationDescEn"
                                                                 DataValueField="intDelegation">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-5 col-sm-5" style="color:#FF3300;">Employer Name(Supervisor)</label>
                                                         <div class="col-md-7 col-sm-7 ">
                                                            <asp:TextBox ID="txtEmployerName" runat="server"  TabIndex="47" CssClass="form-control">NA</asp:TextBox>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-5 col-sm-5" style="color:#FF3300;">Employer Position</label>
                                                         <div class="col-md-7 col-sm-7 ">
                                                            <asp:TextBox ID="txtEmployerPos" runat="server"  TabIndex="48" CssClass="form-control">NA</asp:TextBox>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-5 col-sm-5" style="color:#FF3300;">Employer Phone</label>
                                                         <div class="col-md-7 col-sm-7 ">
                                                            <asp:TextBox ID="txtEmployerPhone" runat="server"  TabIndex="48" CssClass="form-control">999999999</asp:TextBox>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-5 col-sm-5" style="color: #FF3300;">Employer E-Mail</label>
                                                         <div class="col-md-7 col-sm-7 ">
                                                             <asp:TextBox ID="txtEmployeremail" runat="server" TabIndex="48" CssClass="form-control">xyz@xyz.com</asp:TextBox>
                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                                 ControlToValidate="txtEmployeremail" ErrorMessage="Valid email only."
                                                                 SetFocusOnError="True"
                                                                 ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                 ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Valid email only.</asp:RegularExpressionValidator>
                                                         </div>
                                                     </div>
                                                     <hr />
                                                     <div align="middle">
                                                         <asp:LinkButton ID="lnk_Save" runat="server" CssClass="btn btn-success btn-sm" ToolTip="Save Student Info" ValidationGroup="SD" OnClick="lnk_Save_Click"><i class="fa fa-floppy-o"></i> Save</asp:LinkButton>
                                                         <asp:LinkButton ID="lnk_delete" runat="server" CssClass="btn btn-danger btn-sm" ToolTip="Delete Student" ValidationGroup="SD" OnClick="lnk_delete_Click" onclientclick="return DeleteConfirm();"><i class="fa fa-close"></i> Delete</asp:LinkButton>
                                                         <asp:LinkButton ID="lnk_Cancel" runat="server" CssClass="btn btn-success btn-sm" ToolTip="Back" OnClick="lnk_Cancel_Click"><i class="fa fa-close"></i> Cancel</asp:LinkButton>

                                                           <asp:Label ID="lblStudentId" runat="server" Font-Size="Small" Width="100px" 
                                                        CssClass="style11"></asp:Label>
                                                     </div>

                                                     </div>
                                            </div>
            
                                               <div class="x_content bs-example-popovers">
                                                <div class="alert alert-info alert-dismissible " role="alert">
                                                    <strong>Academic Information</strong>
                                                </div>
                                            </div>

                                            <div class="col-md-12 col-sm-12">
                                                <div class="x_panel">
                                                    <div id="divTabs" runat="server">
                                                        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick"
                                                            Orientation="Horizontal" BackColor="#ededed" DynamicHorizontalOffset="2"
                                                            Font-Bold="True" ForeColor="#284E98"
                                                            StaticSubMenuIndent="10px" Width="100%">
                                                            <StaticSelectedStyle BackColor="#3f658c" ForeColor="White" />
                                                            <StaticMenuItemStyle HorizontalPadding="7px" VerticalPadding="7px" />
                                                            <DynamicHoverStyle BackColor="#3f658c" ForeColor="White" />
                                                            <DynamicMenuStyle BackColor="#B5C7DE" />
                                                            <DynamicSelectedStyle BackColor="#3f658c" ForeColor="White" />
                                                            <DynamicMenuItemStyle HorizontalPadding="7px" VerticalPadding="7px" />
                                                            <StaticHoverStyle BackColor="#3f658c" ForeColor="White" />
                                                            <Items>
                                                                <asp:MenuItem Text="Qualifications" Value="0"></asp:MenuItem>
                                                                <asp:MenuItem Text="    |   Enrollment" Value="1"></asp:MenuItem>
                                                                <asp:MenuItem Text="    |   Documents" Value="2"></asp:MenuItem>
                                                                <asp:MenuItem Text="    |   Marks" Value="3"></asp:MenuItem>
                                                                <asp:MenuItem Text="    |   Search" Value="4"></asp:MenuItem>
                                                            </Items>
                                                        </asp:Menu>
                                                    </div>

                                                    <asp:MultiView ID="MultiTabs" runat="server">
                                                        <%--Start View 1--%>

                                                       <%-- End View 1--%>

                                                        <%--Start View 2--%>
                                                       

                                                        <%--End View 2--%>
                                                    </asp:MultiView>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
     <asp:SqlDataSource ID="BirthCityDS" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                SelectCommand="SELECT [byteCity], [strCityDescEn] FROM [Lkp_Cities] WHERE ([byteCountry] = @byteCountry) ORDER BY [strCityDescEn]">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlBirthCountry" DefaultValue="1" 
                                        Name="byteCountry" PropertyName="SelectedValue" Type="Int16" />
                                </SelectParameters>
                            </asp:SqlDataSource>
      <asp:SqlDataSource ID="ResidentCityDS" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                SelectCommand="SELECT [byteCity], [strCityDescEn] FROM [Lkp_Cities] WHERE ([byteCountry] = @byteCountry) ORDER BY [strCityDescEn]">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlResidentCountry" DefaultValue="1" 
                                        Name="byteCountry" PropertyName="SelectedValue" Type="Int16" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="HomeCityDS" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                SelectCommand="SELECT [byteCity], [strCityDescEn] FROM [Lkp_Cities] WHERE ([byteCountry] = @byteCountry) ORDER BY [strCityDescEn]">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlHomeCountry" DefaultValue="1" 
                                        Name="byteCountry" PropertyName="SelectedValue" Type="Int16" />
                                </SelectParameters>
                            </asp:SqlDataSource>
    <script type="text/javascript">
        function DeleteConfirm() {
            var b = confirm('Are you sure want to delete this student ?');
            return b;
        }
    </script>
    <style>
        .Center
        {
            text-align: center;
        }
        .style9
        {
            width: 50%;
        }
    </style>
    </asp:Content>