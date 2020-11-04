<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Profile.aspx.cs" Inherits="LocalECT.Student_Profile" MasterPageFile="~/LocalECT.Master"%>

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

                                            <%--Column1--%>
                                            <div class="col-md-6 col-sm-6"> 
                                               <%-- <div class="col-md-12 col-sm-12"> --%>
                                                <div class="x_panel">
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
                                                             <asp:RadioButtonList ID="RadioButtonList1" runat="server"
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
                                                                Text="Create Email" />
                                                        </div>
                                                    </div>
                                                       <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">Address</label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TabIndex="26">NA</asp:TextBox>
                                                        </div>
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
    </asp:Content>