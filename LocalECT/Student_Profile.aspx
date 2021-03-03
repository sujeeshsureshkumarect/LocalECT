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

                                <%--<script src="Includes/jQuery/jquery-1.4.1.min.js" type="text/javascript"></script>--%>
<%--<script src="Scripts/jquery-1.10.2.min.js"></script>--%>
                                <script src="Scripts/jquery-1.4.1.min.js"></script>
                                <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#divConfirmation").hide();

            //            $('#btnContact').click(getContact()); //btnContact

            //            $('#btnOpportunity').click(); //btnOpportunity



        });   //$(document).ready

        function getContact() {

            var sid = $("#<%=lblStudentId.ClientID %>").val();
            //alert(sid);
            var authorization = '<%=InitializeModule.CxPwd%>'
            $("#<%=txtContactID.ClientID %>").val('');

                        alert(sid + ' ' + authorization);
            var surl = 'https://ect.custhelp.com/services/rest/connect/v1.4/contacts?q=customFields.c.ect_student_id%3D%27' + sid + '%27';
            //                alert(surl);

            $.ajax({
                type: 'GET',

                url: surl,
                dataType: 'json',

                headers: {
                    'Authorization': authorization,
                    'OSvC-CREST-Application-Context': 'application/x-www-form-urlencoded'
                },
                success: function (data) {
                    alert('success');
                    //ulStudents.empty();
                    //                        alert(JSON.stringify(data));
                    $.each(data.items, function (index, val) {
                        var id = val.id;
                        var fullName = val.lookupName;
                        $("#<%=txtContactID.ClientID %>").val(id);
                        //ulStudents.append('<li>' + id + ' (' + fullName + ')</li>')
                    });

                    //alert($("#<%=txtContactID.ClientID %>").val());
                },
                complete: function (jqXHR) {
                    //                    alert(jqXHR.status + ':' + jqXHR.statusText);
                    if (jqXHR.status == '200') {
                        alert('CRM Contact ID Pulled from the CRM,Save it please.');
                    }
                }
            });
        }

        function setOpportunity() {

            var sid = $("#<%=lblStudentId.ClientID %>").text();
            var oid = $("#<%=txtOpportunityID.ClientID %>").val();
            var authorization = '<%=InitializeModule.CxPwd%>'
            //                $("#<%=txtContactID.ClientID %>").val('');

//            alert(oid + ' ' + authorization);
            var surl = 'https://ect.custhelp.com/services/rest/connect/v1.4/opportunities/' + oid;
//            alert(surl);

            $.ajax({
                type: 'PATCH',

                url: surl,
                dataType: 'json',

                headers: {
                    'Authorization': authorization,
                    'OSvC-CREST-Application-Context': 'application/x-www-form-urlencoded'
                },
                data: "{\n\t\"customFields\": {\n\t\t\"c\": {\n\t\t\t\"paymentstatus\": {\n\"id\": 1094,\n\"lookupName\": \"Payment Succeeded\"\n}\n\t\t}\n\t},\n\t\"statusWithType\": {\n\"status\": {\n\"id\": 11\n}\n}\n}",
                success: function (data) {
                    //                    alert('success');
                    //ulStudents.empty();
                    //                    alert(JSON.stringify(data));
                    //                        $.each(data.items, function (index, val) {
                    //                            var id = val.id;
                    //                            var fullName = val.lookupName;
                    //                            $("#<%=txtContactID.ClientID %>").val(id);
                    //                            //ulStudents.append('<li>' + id + ' (' + fullName + ')</li>')
                    //                        });

                    //alert($("#<%=txtContactID.ClientID %>").val());
                },
                complete: function (jqXHR) {
                    //                    alert(jqXHR.status + ':' + jqXHR.statusText);
                    if (jqXHR.status == '200') {
                        alert('CRM Opportunity Updated.');
                        UpdateOpportunitySet(sid);
                    }
                }

            });

        }

        function DeleteConfirm() {
            var b = confirm('Are you sure want to delete this ?');
            return b;
        }

        function UpdateOpportunitySet(sid) {
            PageMethods.SetOpportunity(sid, OnOpportunitySuccess);
        }

        function OnOpportunitySuccess(response, userContext, methodName) {
            if (response == true) {
                alert('Opportunity updated.');
            }
            else {
                alert('Opportunity not updated.');
            }
        }

    </script> 

                            </div>
                                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                    <div class="x_panel">
                                        <div class="x_title">
                                            <h2><i class="fa fa-user"></i> Student Profile</h2>
                                            <ul class="nav navbar-right panel_toolbox">
                                                <a href="StudentSearch.aspx" class="btn btn-success btn-sm"><i class="fa fa-search"></i> Student Search</a>
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
                                                        <asp:HiddenField ID="hdniUnifiedID" runat="server" />
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
                                                    <label class="col-form-label col-md-3 col-sm-3">Full Name (EN)<span style="color: red">*</span></label>
                                                     <div class="col-md-9 col-sm-9 ">
                                                         <asp:TextBox ID="txtNameEn" runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                             ControlToValidate="txtNameEn" ErrorMessage="Full Name (En) is requied."
                                                             SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Full Name (En) is requied.</asp:RequiredFieldValidator>
                                                     </div>
                                                </div>
                                                 <div class="form-group row">
                                                    <label class="col-form-label col-md-3 col-sm-3">First Name (EN)<span style="color: red">*</span></label>
                                                    <div class="col-md-9 col-sm-9 ">
                                                        <asp:TextBox ID="txtFNameEn" runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="txtFNameEn" ErrorMessage="First Name (En) is requied."
                                                            SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*First Name (En) is requied.</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-form-label col-md-3 col-sm-3">Last Name (EN)<span style="color: red">*</span></label>
                                                    <div class="col-md-9 col-sm-9 ">
                                                        <asp:TextBox ID="txtLNameEn" runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                            ControlToValidate="txtLNameEn" ErrorMessage="Last Name (En) is requied."
                                                            SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Last Name (En) is requied.</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                 <div class="form-group row">
                                                    <label class="col-form-label col-md-3 col-sm-3">Full Name (AR)<span style="color: red">*</span></label>
                                                    <div class="col-md-9 col-sm-9 ">
                                                        <asp:TextBox ID="txtNameAr" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                            ControlToValidate="txtNameAr" ErrorMessage="Full Name (Ar) is requied."
                                                            SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Full Name (Ar) is requied.</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                    <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">First Name (AR)<span style="color: red">*</span></label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtFNameAr" runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                                ControlToValidate="txtFNameAr" ErrorMessage="First Name (Ar) is requied."
                                                                SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*First Name (Ar) is requied.</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                       <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">Last Name (AR)<span style="color: red">*</span></label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtLNameAr" runat="server" CssClass="form-control" TabIndex="7"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                                ControlToValidate="txtLNameAr" ErrorMessage="Last Name (Ar) is requied."
                                                                SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*LAst Name (Ar) is requied.</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3" >Access Category</label>
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
                                                        <asp:DropDownList ID="drp_determination" runat="server" TabIndex="21"
                                                            DataTextField="DeterminationType"
                                                            DataValueField="iSerial" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                    <hr />
                                                    <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">Phone 1<span style="color: red">*</span></label>
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
                                                        <label class="col-form-label col-md-3 col-sm-3">E-Mail<span style="color: red">*</span></label>
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
                                                            <asp:LinkButton ID="btnCreateEmail" runat="server" ForeColor="blue"
                                                                Text="Create Email" Visible="true" onclick="btnCreateEmail_Click" Enabled="false"/>
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
                                                        <label class="col-form-label col-md-3 col-sm-3">Emirates ID<span style="color: red">*</span></label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtIDNo" runat="server" CssClass="form-control" TabIndex="27">999999999999999</asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                                ControlToValidate="txtIDNo" ErrorMessage="EID is required."
                                                                SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*EID is required.</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div> 
                                                     <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3">Passport No<span style="color: red">*</span></label>
                                                        <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtIdentityNo" runat="server" CssClass="form-control" TabIndex="28">NA</asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                                ControlToValidate="txtIdentityNo" ErrorMessage="Passport no is required."
                                                                SetFocusOnError="True" ValidationGroup="SD" Display="Dynamic" ForeColor="Red">*Passport no is required.</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div> 
                                                     <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3"  >Unified No</label>
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
                                                        <label class="col-form-label col-md-3 col-sm-3"  >City No</label>
                                                        <div class="col-md-4 col-sm-4 ">
                                                            <asp:TextBox ID="txtCityNo" runat="server" CssClass="form-control" TabIndex="31" >999</asp:TextBox>
                                                        </div>
                                                          <label class="col-form-label col-md-5 col-sm-5" style="color:#993300;">from Family Book</label>
                                                    </div> 

                                                       <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3"  >Family No</label>
                                                        <div class="col-md-4 col-sm-4 ">
                                                            <asp:TextBox ID="txtFamilyNo" runat="server" CssClass="form-control" TabIndex="32" >999</asp:TextBox>
                                                        </div>
                                                          <label class="col-form-label col-md-5 col-sm-5" style="color:#993300;">from Family Book</label>
                                                    </div>
                                                       <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3"  >Family Book No</label>
                                                        <div class="col-md-4 col-sm-4 ">
                                                            <asp:TextBox ID="txtFamilyBookNo" runat="server" CssClass="form-control" TabIndex="33" >999999</asp:TextBox>
                                                        </div>
                                                          <label class="col-form-label col-md-5 col-sm-5" style="color:#993300;">from locals only</label>
                                                    </div>

                                                      <div class="form-group row">
                                                        <label class="col-form-label col-md-3 col-sm-3"  >National No</label>
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
                                                         <label class="col-form-label col-md-3 col-sm-3">Gender<span style="color: red">*</span></label>
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
                                                         <label class="col-form-label col-md-3 col-sm-3">Birth Date<span style="color: red">*</span></label>
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
                                                                 DataValueField="intWorkPlace" AutoPostBack="true" OnSelectedIndexChanged="ddlIWork_SelectedIndexChanged">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3"  >Company Name</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                            <asp:TextBox ID="txtCompany" runat="server"  TabIndex="37" CssClass="form-control">NA</asp:TextBox>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3" >Country</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlEmployerCountry" runat="server" TabIndex="38"
                                                                 CssClass="form-control" DataTextField="strCountryDescEn" DataValueField="byteCountry">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                      <div class="form-group row">
                                                         <label class="col-form-label col-md-3 col-sm-3" >Emirate</label>
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
                                                         <label class="col-form-label col-md-3 col-sm-3"  >Industry</label>
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
                                                     <div class="form-group row" runat="server" visible="false">
                                                         <label class="col-form-label col-md-3 col-sm-3">Sponsor</label>
                                                         <div class="col-md-9 col-sm-9 ">
                                                             <asp:DropDownList ID="ddlSponsor" runat="server" TabIndex="46"
                                                                 CssClass="form-control" DataTextField="strDelegationDescEn"
                                                                 DataValueField="intDelegation">
                                                             </asp:DropDownList>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-5 col-sm-5"  >Employer Name(Supervisor)</label>
                                                         <div class="col-md-7 col-sm-7 ">
                                                            <asp:TextBox ID="txtEmployerName" runat="server"  TabIndex="47" CssClass="form-control">NA</asp:TextBox>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-5 col-sm-5"  >Employer Position</label>
                                                         <div class="col-md-7 col-sm-7 ">
                                                            <asp:TextBox ID="txtEmployerPos" runat="server"  TabIndex="48" CssClass="form-control">NA</asp:TextBox>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-5 col-sm-5"  >Employer Phone</label>
                                                         <div class="col-md-7 col-sm-7 ">
                                                            <asp:TextBox ID="txtEmployerPhone" runat="server"  TabIndex="48" CssClass="form-control">999999999</asp:TextBox>
                                                         </div>
                                                     </div>
                                                     <div class="form-group row">
                                                         <label class="col-form-label col-md-5 col-sm-5" >Employer E-Mail</label>
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
                                                         <asp:LinkButton ID="lnk_Cancel" runat="server" CssClass="btn btn-success btn-sm" ToolTip="Back" OnClick="lnk_Cancel_Click"><i class="fa fa-reply"></i> Back</asp:LinkButton>

                                                           <%--<asp:Label ID="lblStudentId" runat="server" Font-Size="Small" Width="100px" 
                                                        CssClass="style11"></asp:Label>--%>
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
                                                            StaticSubMenuIndent="10px" Width="100%" >
                                                            <StaticSelectedStyle BackColor="#3f658c" ForeColor="White" />
                                                            <StaticMenuItemStyle HorizontalPadding="7px" VerticalPadding="7px" />
                                                            <DynamicHoverStyle BackColor="#3f658c" ForeColor="White" />
                                                            <DynamicMenuStyle BackColor="#B5C7DE" />
                                                            <DynamicSelectedStyle BackColor="#3f658c" ForeColor="White" />
                                                            <DynamicMenuItemStyle HorizontalPadding="7px" VerticalPadding="7px" />
                                                            <StaticHoverStyle BackColor="#3f658c" ForeColor="White" />
                                                            <Items>
                                                                <asp:MenuItem Text="Qualifications" Value="0" ></asp:MenuItem>
                                                                <asp:MenuItem Text="    |   Enrollment" Value="1"></asp:MenuItem>
                                                                <asp:MenuItem Text="    |   Files" Value="2"></asp:MenuItem>
                                                                <asp:MenuItem Text="    |   Marks" Value="3"></asp:MenuItem>
                                                                <asp:MenuItem Text="    |   Search" Value="4"></asp:MenuItem>
                                                            </Items>
                                                        </asp:Menu>
                                                    </div>

                                                    <asp:MultiView ID="MultiTabs" runat="server">
                                                        <%--Start View 1--%>
                                                        <asp:View ID="View1" runat="server" >
                                                            <div class="col-md-12 col-sm-12">
                                                                
                                                                    <h3 style="text-align:center;"><i class="fa fa-graduation-cap"></i> Qualifications</h3>
                                                                <hr />
                                                                    <asp:MultiView ID="mtvQualification" runat="server" ActiveViewIndex="0">
                                                    <table width=100% align="center">
                                                        <tr>
                                                            <td align="center">
                                                            
                                                                <asp:View ID="View5" runat="server">
                                                                    <table width=100% align="center">
                                                                        <tr>
                                                                            <td align="center">
                                                                            
                                                                                <asp:GridView ID="grdQualification" runat="server" AutoGenerateColumns="False" 
                                                                                    CellPadding="4" DataKeyNames="byteQualification" DataSourceID="QualificationDS" 
                                                                                    ForeColor="#444444" GridLines="None" Width="100%" 
                                                                                    onselectedindexchanged="grdQualification_SelectedIndexChanged" 
                                                                                    onrowcommand="grdQualification_RowCommand">
                                                                                    <RowStyle BackColor="#ffffff" />
                                                                                    <Columns>
                                                                                        <asp:ButtonField CommandName="cmdEditQ" HeaderText="Edit" Text="Select" ControlStyle-Font-Underline="true" ControlStyle-ForeColor="Blue"/>
                                                                                        <asp:CommandField ShowSelectButton="True" SelectText="Show Audit Info" ControlStyle-Font-Underline="true" ControlStyle-ForeColor="Blue"/>
                                                                                        <asp:BoundField DataField="byteQualification" HeaderText="#" 
                                                                                            SortExpression="byteQualification">
                                                                                            <HeaderStyle   />
                                                                                            <ItemStyle  HorizontalAlign="Center" 
                                                                                                VerticalAlign="Middle" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="Q" HeaderText="Q" ReadOnly="True" SortExpression="Q">
                                                                                            <HeaderStyle  />
                                                                                            <ItemStyle   />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="Major" HeaderText="Major" ReadOnly="True" 
                                                                                            SortExpression="Major">
                                                                                            <HeaderStyle  />
                                                                                            <ItemStyle/>
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="intGraduationYear" HeaderText="Year" ReadOnly="True" 
                                                                                            SortExpression="intGraduationYear">
                                                                                            <HeaderStyle  />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="Source" HeaderText="Source" ReadOnly="True" 
                                                                                            SortExpression="Source">
                                                                                            <HeaderStyle  />
                                                                                            <ItemStyle  Wrap="True" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="Score" DataFormatString="{0:0.00}" 
                                                                                            HeaderText="Score" ReadOnly="True" SortExpression="Score">
                                                                                            <HeaderStyle  />
                                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="InstitutionTypeDesc" HeaderText="Institution Type" 
                                                                                            SortExpression="InstitutionTypeDesc" />
                                                                                        <asp:BoundField DataField="G12_Stream" HeaderText="G12 Stream" 
                                                                                            SortExpression="G12_Stream" />
                                                                                        <asp:CheckBoxField DataField="VerifiedByRegistrar" 
                                                                                            HeaderText="Verified By Registrar" ReadOnly="True" 
                                                                                            SortExpression="VerifiedByRegistrar">
                                                                                        <HeaderStyle  HorizontalAlign="Center" 
                                                                                            VerticalAlign="Middle" />
                                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                        </asp:CheckBoxField>
                                                                                        <asp:BoundField DataField="RegistrarComments" HeaderText="Registrar Comments" 
                                                                                            ReadOnly="True" SortExpression="RegistrarComments">
                                                                                        <HeaderStyle  HorizontalAlign="Center" 
                                                                                            VerticalAlign="Middle" />
                                                                                        </asp:BoundField>
                                                                                        <asp:CheckBoxField DataField="VerifiedByAdmission" 
                                                                                            HeaderText="Verfied By Admission" ReadOnly="True" 
                                                                                            SortExpression="VerifiedByAdmission">
                                                                                        <HeaderStyle  HorizontalAlign="Center" 
                                                                                            VerticalAlign="Middle" />
                                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                        </asp:CheckBoxField>
                                                                                        <asp:BoundField DataField="AdmissionComments" HeaderText="Admission Comments" 
                                                                                            ReadOnly="True" SortExpression="AdmissionComments">
                                                                                        <HeaderStyle  HorizontalAlign="Center" 
                                                                                            VerticalAlign="Middle" />
                                                                                        </asp:BoundField>
                                                                                    </Columns>
                                                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#444444" />
                                                                                    <HeaderStyle BackColor="#3f658c" Font-Bold="false"  
                                                                                        ForeColor="White" />
                                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                                    <AlternatingRowStyle BackColor="White" />
                                                                                </asp:GridView>
                                                                            
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center"> 
                                                                                <asp:DetailsView ID="QDV" runat="server" AutoGenerateRows="False" 
                                                                                    Caption="Selected Qualification Audit" CaptionAlign="Top" CellPadding="4" 
                                                                                    DataSourceID="Q_Audit" ForeColor="#333333" GridLines="None" Height="50px" 
                                                                                    Width="100%" BackColor="#D1DDF1">
                                                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                    <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                                                                                    <RowStyle BackColor="#EFF3FB" />
                                                                                    <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                                                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <Fields>
                                                                                        <asp:BoundField DataField="strUserCreate" HeaderText="Created By" 
                                                                                            SortExpression="strUserCreate" />
                                                                                        <asp:BoundField DataField="dateCreate" HeaderText="Created On" 
                                                                                            SortExpression="dateCreate" />
                                                                                    </Fields>
                                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                                    <AlternatingRowStyle BackColor="White" />
                                                                                </asp:DetailsView>
                                                                                <asp:SqlDataSource ID="Q_Audit" runat="server" 
                                                                                    ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                                                                    ProviderName="<%$ ConnectionStrings:ECTDataMales.ProviderName %>" 
                                                                                    SelectCommand="SELECT strUserCreate, dateCreate FROM Reg_Student_Qualifications AS Q WHERE (lngSerial = @Serial) AND (byteQualification = @Qualification) ORDER BY byteQualification">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="hdnSerial" DefaultValue="1" Name="Serial" 
                                                                                            PropertyName="Value" />
                                                                                        <asp:Parameter DefaultValue="1" Name="Qualification" />
                                                                                    </SelectParameters>
                                                                                </asp:SqlDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">                                                                            
                                                                                <div style="background-color: #FFFFFF">
                                                                                    <asp:LinkButton ID="NewQ_btn" runat="server" OnClick="NewQ_btn_Click" CausesValidation="False" CssClass="btn btn-success btn-sm" ToolTip="Add New Qualification"><i class="fa fa-plus"></i> Add New</asp:LinkButton>
                                                                                    <asp:LinkButton ID="ESLEX_btn" runat="server" OnClick="ESLEX_btn_Click" CssClass="btn btn-success btn-sm" ToolTip="ESL Exemption Calculation" Visible="false"><i class="fa fa-calculator"></i> ESL Exemption Calculation</asp:LinkButton>
                                                                                     <asp:LinkButton ID="DeleteQ_btn" runat="server" OnClick="DeleteQ_btn_Click" CssClass="btn btn-danger btn-sm" ToolTip="Delete Qualification" onclientclick="return DeleteConfirm();" ><i class="fa fa-trash"></i> Delete</asp:LinkButton>
                                                                                </div>
                                                                            
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <style>
                                                                        caption {
    padding-top: .75rem;
    padding-bottom: .75rem;
    color: #6c757d;
    text-align: center;
    caption-side: top;
    background:#e8eff7;
    color:#444444;
    font-weight:bold;
}
                                                                        th, td {
  border: 1px solid #ced4da;
  border-collapse:collapse;
}
                                                                    </style>
                                                                    <asp:SqlDataSource ID="QualificationDS" runat="server" 
                                                                        ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                                                        DeleteCommand="DELETE FROM Reg_Student_Qualifications WHERE (lngSerial = @Serial) AND (byteQualification = @byteQualification)" 
                                                                        InsertCommand="INSERT INTO Reg_Student_Qualifications(lngSerial, byteQualification, intCertificate, intMajor, intMinor, intGraduationYear, byteInstituteCountry, sngGrade, strCertificateSource, dateENG, strUserCreate, dateCreate, VerifiedByAdmission, AdmissionComments, VerifiedByRegistrar, RegistrarComments, HS_InstitutionType, HS_InstitutionCity, G12_Stream, ScoreOfMath, IESOL_Grade, ExamCenterID, HSSystem, HSEquivalencyIndicator, HSEquivalencyAppNo, ScoreOfChemistry, ScoreOfBiology, ScoreOfPhysics) VALUES (@lngSerial, @byteQualification, @intCertificate, @intMajor, @intMinor, @intGraduationYear, @byteInstituteCountry, @sngGrade, @strCertificateSource, @dateENG, @strUserCreate, GETDATE(), @VerifiedByAdmission, @AdmissionComments, @VerifiedByRegistrar, @RegistrarComments, @HS_InstitutionType, @HS_InstitutionCity, @G12_Stream, @ScoreOfMath, @IESOL_Grade, @ExamCenterID, @HSSystem, @HSEquivalencyIndicator, @HSEquivalencyAppNo, @ScoreOfChemistry, @ScoreOfBiology, @ScoreOfPhysics)" 
                                                                        UpdateCommand="UPDATE Reg_Student_Qualifications SET intCertificate = @intCertificate, intMajor = @intMajor, intMinor = @intMinor, intGraduationYear = @intGraduationYear, byteInstituteCountry = @byteInstituteCountry, sngGrade = @sngGrade, strCertificateSource = @strCertificateSource, dateENG = @dateENG, VerifiedByAdmission = @VerifiedByAdmission, AdmissionComments = @AdmissionComments, VerifiedByRegistrar = @VerifiedByRegistrar, RegistrarComments = @RegistrarComments, HS_InstitutionType = @HS_InstitutionType, HS_InstitutionCity = @HS_InstitutionCity, G12_Stream = @G12_Stream, ScoreOfMath = @ScoreOfMath, IESOL_Grade = @IESOL_Grade, ExamCenterID = @ExamCenterID, HSSystem = @HSSystem, HSEquivalencyIndicator = @HSEquivalencyIndicator, HSEquivalencyAppNo = @HSEquivalencyAppNo, ScoreOfChemistry = @ScoreOfChemistry, ScoreOfBiology = @ScoreOfBiology, ScoreOfPhysics = @ScoreOfPhysics WHERE (lngSerial = @lngSerial) AND (byteQualification = @byteQualification)"
                                                                        
                                                                        
                                                                        
                                                                        
                                                                        
                                                                        
                                                                        
                                                                        
                                                                        SelectCommand="SELECT Q.byteQualification, C.strCertificateDescEn AS Q, S1.strSpecializationDescEn AS Major, S2.strSpecializationDescEn AS Minor, Q.intGraduationYear, Q.strCertificateSource AS Source, CO.strCountryDescEn, Q.dateENG, Q.sngGrade AS Score, Q.VerifiedByAdmission, Q.AdmissionComments, Q.VerifiedByRegistrar, Q.RegistrarComments, Q.strUserCreate, Q.dateCreate, Lkp_Cities.strCityDescEn AS City, Lkp_InstitutionType.InstitutionTypeDesc, Lkp_G12_Stream.G12_StreamDesc AS G12_Stream, Q.ScoreOfMath, Lkp_EngCertificate_ExamCenter.ExamcenterName, Q.ScoreOfChemistry, Q.ScoreOfBiology, Q.ScoreOfPhysics FROM Lkp_Specializations AS S1 INNER JOIN Reg_Student_Qualifications AS Q INNER JOIN Lkp_Certificates AS C ON Q.intCertificate = C.intCertificate INNER JOIN Lkp_Countries AS CO ON Q.byteInstituteCountry = CO.byteCountry ON S1.intSpecialization = Q.intMajor INNER JOIN Lkp_Specializations AS S2 ON Q.intMinor = S2.intSpecialization LEFT OUTER JOIN Lkp_EngCertificate_ExamCenter ON Q.ExamCenterID = Lkp_EngCertificate_ExamCenter.ExamCenterID LEFT OUTER JOIN Lkp_G12_Stream ON Q.G12_Stream = Lkp_G12_Stream.G12_StreamID LEFT OUTER JOIN Lkp_InstitutionType ON Q.HS_InstitutionType = Lkp_InstitutionType.InstitutionTypeID LEFT OUTER JOIN Lkp_Cities ON Q.HS_InstitutionCity = Lkp_Cities.byteCity AND Q.byteInstituteCountry = Lkp_Cities.byteCountry WHERE (Q.lngSerial = @Serial) ORDER BY Q.byteQualification" >
                                                                        
                                                                        <SelectParameters>
                                                                            <asp:ControlParameter ControlID="hdnSerial" DefaultValue="0" Name="Serial" 
                                                                                PropertyName="Value" />
                                                                        </SelectParameters>
                                                                        <DeleteParameters>
                                                                            <asp:ControlParameter ControlID="hdnSerial" DefaultValue="0" Name="Serial" 
                                                                                PropertyName="Value" />
                                                                            <asp:ControlParameter ControlID="grdQualification" DefaultValue="0" 
                                                                                Name="byteQualification" PropertyName="SelectedValue" />
                                                                        </DeleteParameters>
                                                                        <InsertParameters>
                                                                            <asp:ControlParameter ControlID="hdnSerial" DefaultValue="0" Name="lngSerial" 
                                                                                PropertyName="Value" />
                                                                            <asp:ControlParameter ControlID="lblQualification" DefaultValue="0" 
                                                                                Name="byteQualification" PropertyName="Text" />
                                                                            <asp:ControlParameter ControlID="ddlQualification" DefaultValue="0" 
                                                                                Name="intCertificate" PropertyName="SelectedValue" />
                                                                            <asp:ControlParameter ControlID="ddlQMajor" DefaultValue="0" Name="intMajor" 
                                                                                PropertyName="SelectedValue" />
                                                                            <asp:ControlParameter ControlID="ddlQMajor" DefaultValue="0" Name="intMinor" 
                                                                                PropertyName="SelectedValue" />
                                                                            <asp:ControlParameter ControlID="txtQYear" DefaultValue="" 
                                                                                Name="intGraduationYear" PropertyName="Text" />
                                                                            <asp:ControlParameter ControlID="ddlQCountry" DefaultValue="1" 
                                                                                Name="byteInstituteCountry" PropertyName="SelectedValue" />
                                                                            <asp:ControlParameter ControlID="txtQScore" DefaultValue="0" Name="sngGrade" 
                                                                                PropertyName="Text" />
                                                                            <asp:ControlParameter ControlID="txtSource" DefaultValue="-" 
                                                                                Name="strCertificateSource" PropertyName="Text" />
                                                                            <asp:ControlParameter ControlID="txtQDate" DefaultValue="" Name="dateENG" 
                                                                                PropertyName="Text" />
                                                                            <asp:SessionParameter DefaultValue="-" Name="strUserCreate" 
                                                                                SessionField="CurrentUserName" />
                                                                            <asp:ControlParameter ControlID="chkAdmissionVerfication" DefaultValue="0" 
                                                                                Name="VerifiedByAdmission" PropertyName="Checked" />
                                                                            <asp:ControlParameter ControlID="txtAdmissionComments" DefaultValue="" 
                                                                                Name="AdmissionComments" PropertyName="Text" />
                                                                            <asp:ControlParameter ControlID="chkRegistrarVerfication" DefaultValue="0" 
                                                                                Name="VerifiedByRegistrar" PropertyName="Checked" />
                                                                            <asp:ControlParameter ControlID="txtRegistrarComments" DefaultValue="-" 
                                                                                Name="RegistrarComments" PropertyName="Text" />
                                                                            <asp:ControlParameter ControlID="ddlQInstitutionType" DefaultValue="0" 
                                                                                Name="HS_InstitutionType" PropertyName="SelectedValue" />
                                                                            <asp:ControlParameter ControlID="ddlQCity" DefaultValue="0" 
                                                                                Name="HS_InstitutionCity" PropertyName="SelectedValue" />
                                                                            <asp:ControlParameter ControlID="ddlQG12_Stream" DefaultValue="0" 
                                                                                Name="G12_Stream" PropertyName="SelectedValue" />
                                                                          
                                                                            <asp:ControlParameter ControlID="txtQScoreofMath" DefaultValue="0" 
                                                                                Name="ScoreOfMath" PropertyName="Text" />
                                                                            <asp:ControlParameter ControlID="ddlQEngGrade" DefaultValue="-" 
                                                                                Name="IESOL_Grade" PropertyName="SelectedValue" />
                                                                            <asp:ControlParameter ControlID="ddlQEngExamCenter" DefaultValue="0" 
                                                                                Name="ExamCenterID" PropertyName="SelectedValue" />
                
                                                                            <asp:ControlParameter ControlID="ddlHSSystem" DefaultValue="1" Name="HSSystem" 
                                                                                PropertyName="SelectedValue" />
                                                                            <asp:ControlParameter ControlID="ddlEquivalencyIndicator" DefaultValue="M" 
                                                                                Name="HSEquivalencyIndicator" PropertyName="SelectedValue" />
                                                                            <asp:ControlParameter ControlID="txtEquivalencyAppNo" DefaultValue="NA" 
                                                                                Name="HSEquivalencyAppNo" PropertyName="Text" />
                                                                            
                                                                            <asp:ControlParameter ControlID="txtQScoreofChemistry" DefaultValue="0" 
                                                                                 Name="ScoreOfChemistry" PropertyName="Text" />
                                                                             <asp:ControlParameter ControlID="txtQScoreofBiology" DefaultValue="0" 
                                                                                 Name="ScoreOfBiology" PropertyName="Text" />
                                                                             <asp:ControlParameter ControlID="txtQScoreofPhysics" DefaultValue="0" 
                                                                                 Name="ScoreOfPhysics" PropertyName="Text" />
                
                                                                        </InsertParameters>
                                                                        <UpdateParameters>

                                                                             <asp:ControlParameter ControlID="ddlQualification" DefaultValue="0" 
                                                                                 Name="intCertificate" PropertyName="SelectedValue" />
                                                                             <asp:ControlParameter ControlID="ddlQMajor" DefaultValue="0" Name="intMajor" 
                                                                                 PropertyName="SelectedValue" />
                                                                             <asp:ControlParameter ControlID="ddlQMajor" DefaultValue="0" Name="intMinor" 
                                                                                 PropertyName="SelectedValue" />
                                                                             <asp:ControlParameter ControlID="txtQYear" DefaultValue="" 
                                                                                 Name="intGraduationYear" PropertyName="Text" />
                                                                             <asp:ControlParameter ControlID="ddlQCountry" DefaultValue="1" 
                                                                                 Name="byteInstituteCountry" PropertyName="SelectedValue" />
                                                                             <asp:ControlParameter ControlID="txtQScore" DefaultValue="0" Name="sngGrade" 
                                                                                 PropertyName="Text" />
                                                                             <asp:ControlParameter ControlID="txtSource" DefaultValue="-" 
                                                                                 Name="strCertificateSource" PropertyName="Text" />
                                                                             <asp:ControlParameter ControlID="txtQDate" DefaultValue="" Name="dateENG" 
                                                                                 PropertyName="Text" />
                                                                             <asp:ControlParameter ControlID="chkAdmissionVerfication" DefaultValue="0" 
                                                                                 Name="VerifiedByAdmission" PropertyName="Checked" />
                                                                             <asp:ControlParameter ControlID="txtAdmissionComments" DefaultValue="" 
                                                                                 Name="AdmissionComments" PropertyName="Text" />
                                                                             <asp:ControlParameter ControlID="chkRegistrarVerfication" DefaultValue="0" 
                                                                                 Name="VerifiedByRegistrar" PropertyName="Checked" />
                                                                             <asp:ControlParameter ControlID="txtRegistrarComments" DefaultValue="-" 
                                                                                 Name="RegistrarComments" PropertyName="Text" />

                                                                              <asp:ControlParameter ControlID="ddlQInstitutionType" DefaultValue="0" 
                                                                                Name="HS_InstitutionType" PropertyName="SelectedValue" />
                                                                             <asp:ControlParameter ControlID="ddlQCity" DefaultValue="0" 
                                                                                 Name="HS_InstitutionCity" PropertyName="SelectedValue" />
                                                                            <asp:ControlParameter ControlID="ddlQG12_Stream" DefaultValue="0" 
                                                                                Name="G12_Stream" PropertyName="SelectedValue" />

                                                                             <asp:ControlParameter ControlID="txtQScoreofMath" DefaultValue="0" 
                                                                                 Name="ScoreOfMath" PropertyName="Text" />

                                                                             <asp:ControlParameter ControlID="ddlQEngGrade" DefaultValue="-" 
                                                                                Name="IESOL_Grade" PropertyName="SelectedValue" />
                                                                            <asp:ControlParameter ControlID="ddlQEngExamCenter" DefaultValue="0" 
                                                                                Name="ExamCenterID" PropertyName="SelectedValue" />

                                                                             <asp:ControlParameter ControlID="ddlHSSystem" DefaultValue="1" Name="HSSystem" 
                                                                                 PropertyName="SelectedValue" />
                                                                             <asp:ControlParameter ControlID="ddlEquivalencyIndicator" DefaultValue="M" 
                                                                                 Name="HSEquivalencyIndicator" PropertyName="SelectedValue" />
                                                                             <asp:ControlParameter ControlID="txtLHEquivalencyAppNo" DefaultValue="NA" 
                                                                                 Name="HSEquivalencyAppNo" PropertyName="Text" />
                                                                            
                                                                              <asp:ControlParameter ControlID="txtQScoreofChemistry" DefaultValue="0" 
                                                                                 Name="ScoreOfChemistry" PropertyName="Text" />
                                                                             <asp:ControlParameter ControlID="txtQScoreofBiology" DefaultValue="0" 
                                                                                 Name="ScoreOfBiology" PropertyName="Text" />
                                                                             <asp:ControlParameter ControlID="txtQScoreofPhysics" DefaultValue="0" 
                                                                                 Name="ScoreOfPhysics" PropertyName="Text" />
                                                                             <asp:ControlParameter ControlID="hdnSerial" DefaultValue="0" Name="lngSerial" 
                                                                                PropertyName="Value" />
                                                                            <asp:ControlParameter ControlID="lblQualification" DefaultValue="0" 
                                                                                Name="byteQualification" PropertyName="Text" />
                                                                        </UpdateParameters>
                                                                    </asp:SqlDataSource>
                                                                    <asp:SqlDataSource ID="QCityDS" runat="server" 
                                                                        ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                                                        SelectCommand="SELECT [byteCity], [strCityDescEn] FROM [Lkp_Cities] WHERE ([byteCountry] = @byteCountry) ORDER BY [strCityDescEn]">
                                                                        <SelectParameters>
                                                                            <asp:ControlParameter ControlID="ddlQCountry" DefaultValue="1" 
                                                                                Name="byteCountry" PropertyName="SelectedValue" Type="Int16" />
                                                                        </SelectParameters>
                                                                    </asp:SqlDataSource>
                                                                </asp:View>
                                                            
                                                            </td>
                                                        </tr>
                                                        <tr>                                                      
                                                            <td align="right" class="style9">
                                                                
                                                                <asp:View ID="View6" runat="server">
                                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                                                                                    ValidationGroup="Q" />
                                                                     <asp:Label ID="Label28" runat="server" Text="#" ></asp:Label> 
                                                                     <asp:Label ID="lblQualification" runat="server" ></asp:Label>
                                                                    <br />
                                                                    <div class="col-md-6 col-sm-6">
                                                                        <div class="x_panel">
                                                                            <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Qualification<span style="color: red">*</span></label>
                                                                                <div class="col-md-9 col-sm-9 ">
                                                                                     <asp:DropDownList ID="ddlQualification" runat="server" 
                                                                                    DataTextField="strCertificateDescEn" DataValueField="intCertificate" 
                                                                                    TabIndex="51" CssClass="form-control"
                                                                                    onselectedindexchanged="ddlQualification_SelectedIndexChanged" 
                                                                                    AutoPostBack="True">
                                                                                </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Year<span style="color: red">*</span></label>
                                                                                <div class="col-md-9 col-sm-9 ">
                                                                                      <asp:TextBox ID="txtQYear" runat="server" TabIndex="53" ValidationGroup="Q" 
                                                                                    CssClass="form-control">9999</asp:TextBox>
                                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                                                    ControlToValidate="txtQYear" ErrorMessage="Qualification Year is required." 
                                                                                    SetFocusOnError="True" ValidationGroup="Q" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Source<span style="color: red">*</span></label>
                                                                                <div class="col-md-9 col-sm-9 ">
                                                                                     <asp:TextBox ID="txtSource" runat="server" TabIndex="55" ValidationGroup="Q" 
                                                                                    CssClass="form-control">NA</asp:TextBox>
                                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                                                    ControlToValidate="txtSource" ErrorMessage="Qualification Source is required." 
                                                                                    SetFocusOnError="True" ValidationGroup="Q" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Institution <br />Type</label>
                                                                                <div class="col-md-9 col-sm-9 ">
                                                                                     <asp:DropDownList ID="ddlQInstitutionType" runat="server" 
                                                                                    DataTextField="InstitutionTypeDesc" DataValueField="InstitutionTypeID" 
                                                                                    TabIndex="57" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                             <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3"  >HS System<br />&nbsp;</label>
                                                                                <div class="col-md-5 col-sm-5 ">
                                                                                     <asp:DropDownList ID="ddlHSSystem" runat="server" 
                                                                                    DataTextField="sSystem" DataValueField="iSerial" TabIndex="59" 
                                                                                    CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                                </div>
                                                                                 <div class="col-md-4 col-sm-4 ">
                                                                                      <asp:Label ID="Label86" runat="server" ForeColor="#993300" 
                                                                                    Text="only for high school"></asp:Label>
                                                                                     </div>
                                                                            </div>
                                                                                <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3"  >Equivalency App No.</label>
                                                                                <div class="col-md-5 col-sm-5 ">
                                                                                      <asp:TextBox ID="txtEquivalencyAppNo" runat="server" TabIndex="61" 
                                                                                    ValidationGroup="Q" CssClass="form-control">NA</asp:TextBox>                                                                              
                                                                                </div>
                                                                                 <div class="col-md-4 col-sm-4 ">
                                                                                     <asp:Label ID="Label5" runat="server" Font-Size="Small" ForeColor="#993300" 
                                                                                    Text="only for high school"></asp:Label>
                                                                                     </div>
                                                                            </div>
                                                                             <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Country</label>
                                                                                <div class="col-md-9 col-sm-9 ">
                                                                                   <asp:DropDownList ID="ddlQCountry" runat="server" 
                                                                                    DataTextField="strCountryDescEn" DataValueField="byteCountry" TabIndex="62" 
                                                                                   CssClass="form-control" AutoPostBack="True" 
                                                                                    onselectedindexchanged="ddlQCountry_SelectedIndexChanged">
                                                                                </asp:DropDownList>                                                                                
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Score<span style="color: red">*</span></label>
                                                                                <div class="col-md-4 col-sm-4 ">
                                                                                    <asp:TextBox ID="txtQScore" runat="server" TabIndex="65" CssClass="form-control"></asp:TextBox>

                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                                                        ControlToValidate="txtQScore" ErrorMessage="Qualification Score is required."
                                                                                        SetFocusOnError="True" ValidationGroup="Q" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                              <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Score of Chemistry</label>
                                                                                <div class="col-md-4 col-sm-4 ">
                                                                                    <asp:TextBox ID="txtQScoreofChemistry" runat="server" TabIndex="66" 
                                                                                    CssClass="form-control">0</asp:TextBox>
                                                                           
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                                                                    ControlToValidate="txtQScoreofChemistry" ErrorMessage="Enter numbers only" 
                                                                                    ValidationExpression="\d+" ValidationGroup="Q" Display="Dynamic">#</asp:RegularExpressionValidator>
                                                                                <asp:RangeValidator ID="RangeValidator5" runat="server" 
                                                                                    ControlToValidate="txtQScoreofChemistry" 
                                                                                    ErrorMessage="Score must be from 0 to 100" MaximumValue="100" MinimumValue="0" 
                                                                                    SetFocusOnError="True" Type="Integer" ValidationGroup="Q" Display="Dynamic">#</asp:RangeValidator>
                                                                                </div>
                                                                                <div class="col-md-5 col-sm-5 ">                                                                                   
                                                                                </div>
                                                                            </div>
                                                                              <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Score of Physics</label>
                                                                                <div class="col-md-4 col-sm-4 ">
                                                                                    <asp:TextBox ID="txtQScoreofPhysics" runat="server" TabIndex="66" CssClass="form-control">0</asp:TextBox>
                                                                           
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                                                                                    ControlToValidate="txtQScoreofPhysics" ErrorMessage="Enter numbers only" 
                                                                                    ValidationExpression="\d+" ValidationGroup="Q" Display="Dynamic">#</asp:RegularExpressionValidator>
                                                                                <asp:RangeValidator ID="RangeValidator7" runat="server" 
                                                                                    ControlToValidate="txtQScoreofPhysics" 
                                                                                    ErrorMessage="Score must be from 0 to 100" MaximumValue="100" MinimumValue="0" 
                                                                                    SetFocusOnError="True" Type="Integer" ValidationGroup="Q" Display="Dynamic">#</asp:RangeValidator>
                                                                                </div>
                                                                                <div class="col-md-5 col-sm-5 ">                                                                                   
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 col-sm-6">
                                                                        <div class="x_panel">
                                                                             <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Major</label>
                                                                                <div class="col-md-9 col-sm-9 ">
                                                                                    <asp:DropDownList ID="ddlQMajor" runat="server" 
                                                                                    DataTextField="strSpecializationDescEn" DataValueField="intSpecialization" 
                                                                                    TabIndex="52" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Date</label>
                                                                                <div class="col-md-9 col-sm-9 ">
                                                                                     <asp:TextBox ID="txtQDate" runat="server" TabIndex="54" 
                                                                                    CssClass="form-control" ToolTip="mm/dd/yyyy" TextMode="Date"></asp:TextBox>
                                                                               
                                                                                <asp:RangeValidator ID="RangeValidator3" runat="server" 
                                                                                    ControlToValidate="txtQDate" Display="Dynamic" ErrorMessage="Date Only" 
                                                                                    MaximumValue="01/01/3000" MinimumValue="01/01/1900" SetFocusOnError="True" 
                                                                                    Type="Date" ValidationGroup="Q">mm/dd/yyyy</asp:RangeValidator>
                                                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                                                    ControlToValidate="txtQDate" ErrorMessage="Qualification Date is required." 
                                                                                    SetFocusOnError="True" ValidationGroup="Q" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                             <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Exam Center</label>
                                                                                <div class="col-md-5 col-sm-5 ">
                                                                                     <asp:DropDownList ID="ddlQEngExamCenter" runat="server" TabIndex="56" 
                                                                                    CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                                </div>
                                                                                 <div class="col-md-4 col-sm-4 ">
                                                                                    <asp:Label ID="Label75" runat="server" Font-Size="Small" ForeColor="#993300" 
                                                                                    Text=" for English certificates"></asp:Label>
                                                                                     </div>
                                                                            </div>
                                                                               <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">12th Grade Stream</label>
                                                                                <div class="col-md-3 col-sm-3 ">
                                                                                     <asp:DropDownList ID="ddlQG12_Stream" runat="server" 
                                                                                    DataTextField="G12_StreamDesc" DataValueField="G12_StreamID" TabIndex="58" 
                                                                                   CssClass="form-control">
                                                                                </asp:DropDownList>                                                                               
                                                                                </div>
                                                                                 <div class="col-md-6 col-sm-6 ">
                                                                                    <asp:Label ID="Label69" runat="server" ForeColor="#993300" 
                                                                                    Text="only for the UAE Public school graduates"></asp:Label>
                                                                                     </div>
                                                                            </div>
                                                                              <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3"  >Equivalency Indicator</label>
                                                                                <div class="col-md-5 col-sm-5 ">
                                                                                      <asp:DropDownList ID="ddlEquivalencyIndicator" runat="server" TabIndex="60" 
                                                                                   CssClass="form-control">
                                                                                    <asp:ListItem Selected="True" Value="M">UAE-MOE national curriculum</asp:ListItem>
                                                                                    <asp:ListItem Value="Y">Equivalency has been received</asp:ListItem>
                                                                                    <asp:ListItem Value="R">Rejected</asp:ListItem>
                                                                                    <asp:ListItem Value="A">Applied</asp:ListItem>
                                                                                    <asp:ListItem Value="N">Not Applied Yet</asp:ListItem>
                                                                                    <asp:ListItem Value="U">Equivalency status unknown</asp:ListItem>
                                                                                </asp:DropDownList>                                                                               
                                                                                </div>
                                                                                 <div class="col-md-4 col-sm-4 ">
                                                                                      <asp:Label ID="Label4" runat="server" Font-Size="Small" ForeColor="#993300" 
                                                                                    Text="only for high school"></asp:Label>
                                                                                     </div>
                                                                            </div>
                                                                              <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">City<br />&nbsp;</label>
                                                                                <div class="col-md-9 col-sm-9 ">
                                                                                    <asp:DropDownList ID="ddlQCity" runat="server" DataTextField="strCityDescEn" 
                                                                                    DataValueField="byteCity" TabIndex="63" CssClass="form-control"
                                                                                    DataSourceID="QCityDS">
                                                                                </asp:DropDownList>                                                                             
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Grade</label>
                                                                                <div class="col-md-5 col-sm-5 ">
                                                                                    <asp:DropDownList ID="ddlQEngGrade" runat="server" TabIndex="64"
                                                                                        CssClass="form-control" OnSelectedIndexChanged="ddlQEngGrade_SelectedIndexChanged"
                                                                                        AutoPostBack="True">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div class="col-md-4 col-sm-4 ">
                                                                                    <asp:Label ID="Label76" runat="server" ForeColor="#993300"
                                                                                        Text=" for IESOL"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                              <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Score of Math</label>
                                                                                <div class="col-md-4 col-sm-4 ">
                                                                                    <asp:TextBox ID="txtQScoreofMath" runat="server" TabIndex="66" CssClass="form-control">0</asp:TextBox>
                                                                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                                                    ControlToValidate="txtQScoreofMath" ErrorMessage="Enter numbers only" 
                                                                                    ValidationExpression="\d+" ValidationGroup="Q" Display="Dynamic">#</asp:RegularExpressionValidator>
                                                                                <asp:RangeValidator ID="RangeValidator4" runat="server" 
                                                                                    ControlToValidate="txtQScoreofMath" ErrorMessage="Score must be from 0 to 100" 
                                                                                    MaximumValue="100" MinimumValue="0" SetFocusOnError="True" Type="Integer" 
                                                                                    ValidationGroup="Q" Display="Dynamic">#</asp:RangeValidator>
                                                                                </div>
                                                                                <div class="col-md-5 col-sm-5 ">
                                                                                    <asp:Label ID="Label1" runat="server" ForeColor="#993300"
                                                                                        Text="only for scientific majors"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                             <div class="form-group row">
                                                                                <label class="col-form-label col-md-3 col-sm-3">Score of Biology</label>
                                                                                <div class="col-md-4 col-sm-4 ">
                                                                                     <asp:TextBox ID="txtQScoreofBiology" runat="server" TabIndex="66" CssClass="form-control">0</asp:TextBox>                                                                           
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                                                                    ControlToValidate="txtQScoreofBiology" ErrorMessage="Enter numbers only" 
                                                                                    ValidationExpression="\d+" ValidationGroup="Q" Display="Dynamic">#</asp:RegularExpressionValidator>
                                                                                <asp:RangeValidator ID="RangeValidator6" runat="server" 
                                                                                    ControlToValidate="txtQScoreofBiology" 
                                                                                    ErrorMessage="Score must be from 0 to 100" MaximumValue="100" MinimumValue="0" 
                                                                                    SetFocusOnError="True" Type="Integer" ValidationGroup="Q" Display="Dynamic">#</asp:RangeValidator>
                                                                                </div>
                                                                                <div class="col-md-5 col-sm-5 ">                                                                                   
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                     <div class="col-md-12 col-sm-12">
                                                                         <div class="x_panel">
                                                                              <div class="col-md-6 col-sm-6 ">
                                                                                  <asp:Label ID="lblRegistrarVerification" runat="server"
                                                                                              ForeColor="#FF9900" Text="Registrar Verification"
                                                                                              Visible="False" Font-Bold="true"></asp:Label>
                                                                                  <div class="form-group row">
                                                                                      <div class="col-md-4 col-sm-4 ">                                                                                          
                                                                                      </div>
                                                                                      <div class="col-md-8 col-sm-8 ">
                                                                                          <asp:CheckBox ID="chkRegistrarVerfication" runat="server"
                                                                                              TabIndex="67" Text="Verified By Registrar" Visible="false" />
                                                                                      </div>
                                                                                  </div>
                                                                                  <div class="form-group row">
                                                                                      <div class="col-md-4 col-sm-4 ">
                                                                                          <asp:Label ID="lblRegistrarComments" runat="server" Font-Size="Small"
                                                                                              Text="Registrar Comments" Visible="false"></asp:Label>
                                                                                      </div>
                                                                                      <div class="col-md-8 col-sm-8 ">
                                                                                          <asp:TextBox ID="txtRegistrarComments" runat="server" TabIndex="68"
                                                                                              CssClass="form-control" Visible="false"></asp:TextBox>
                                                                                      </div>
                                                                                  </div>
                                                                                  <hr />
                                                                                        <asp:Label ID="lblAdmissionVerfication" runat="server"
                                                                                              ForeColor="#FF9900" Text="First Audit" Visible="false" Font-Bold="true"></asp:Label>
                                                                                  <div class="form-group row">
                                                                                      <div class="col-md-4 col-sm-4 ">
                                                                                    
                                                                                      </div>
                                                                                      <div class="col-md-8 col-sm-8 ">
                                                                                          <asp:CheckBox ID="chkAdmissionVerfication" runat="server"
                                                                                              TabIndex="69" Text="Student Profile First - Audit" Visible="true" />
                                                                                      </div>
                                                                                  </div>
                                                                                  <div class="form-group row">
                                                                                      <div class="col-md-4 col-sm-4 ">
                                                                                          <asp:Label ID="lblAdmissionComments" runat="server"
                                                                                              Text="Auditor Comments" Visible="false"></asp:Label>
                                                                                      </div>
                                                                                      <div class="col-md-8 col-sm-8 ">
                                                                                          <asp:TextBox ID="txtAdmissionComments" runat="server" TabIndex="70"
                                                                                              CssClass="form-control" Visible="false"></asp:TextBox><br />
                                                                                          <asp:HiddenField ID="HiddenFieldQMode" runat="server" />
                                                                                      </div>
                                                                                  </div>
                                                                                  <div class="form-group row">
                                                                                      <asp:LinkButton ID="SaveQ_btn" runat="server" ValidationGroup="Q" onclick="SaveQ_btn_Click" CssClass="btn btn-success btn-sm"><i class="fa fa-floppy-o"></i> Save</asp:LinkButton>
                                                                                      <asp:LinkButton ID="UndoQ_btn" runat="server" CausesValidation="False"  onclick="UndoQ_btn_Click" ToolTip="Undo" CssClass="btn btn-success btn-sm"><i class="fa fa-reply"></i> Undo</asp:LinkButton>
                                                                                      </div>
                                                                                </div>
                                                                         </div>
                                                                         </div>                                                               
                                                                </asp:View>
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:MultiView>
                                                                </div>
                                                            
                                                        </asp:View>
                                                       <%-- End View 1--%>
                                                    
                                                        <%--Start View 2--%>
                                                        <asp:View ID="View2" runat="server">
                                                            <div class="col-md-12 col-sm-12">
                                                                <h3 style="text-align: center; "><i class="fa fa-flag-checkered"></i> Enrollment</h3>
                                                                <hr />
                                                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" 
                                                        ValidationGroup="E" />
                                                                <div class="col-md-6 col-sm-6">
                                                                    <div class="x_panel">
                                                                    <div class="form-group row">
                                                                        <label class="col-form-label col-md-4 col-sm-4">Term</label>
                                                                        <div class="col-md-8 col-sm-8 ">
                                                                            <asp:DropDownList ID="ddlEnrollmentTerm" runat="server"
                                                                                DataTextField="LongDesc" DataValueField="Term" TabIndex="71" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                           <div class="form-group row">
                                                                               &nbsp;&nbsp; &nbsp;
                                                                    <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="&nbsp;&nbsp;Active"
                                                                        TabIndex="72"  ForeColor="Blue"
                                                                        AutoPostBack="True" OnCheckedChanged="chkActive_CheckedChanged" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:CheckBox ID="chkMissing" runat="server" Text="&nbsp;&nbsp;Is File Not Complete"
                                                                        TabIndex="73"  ForeColor="Black" OnCheckedChanged="chkMissing_CheckedChanged" />
                                                                    </div>
                                                                    <div class="form-group row">
                                                                        <label class="col-form-label col-md-4 col-sm-4">Opportunity ID<span style="color: red">*</span></label>
                                                                        <div class="col-md-8 col-sm-8 ">
                                                                            <asp:TextBox ID="txtOpportunityID" runat="server" TabIndex="75"
                                                                                ToolTip="Can be changed by Admission and Head of Registration" CssClass="form-control"></asp:TextBox>
                                                                            <asp:LinkButton ID="lnkOpportunity" runat="server" 
                                                                            Font-Underline="True" OnCommand="lnkOpportunity_Command"
                                                                            ToolTip="Do that after you save please." ForeColor="Blue" Visible="false">Set CRM Opportunity</asp:LinkButton>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                                                                                ControlToValidate="txtOpportunityID" Display="Dynamic"
                                                                                ErrorMessage="Opportunity ID is required" SetFocusOnError="True"
                                                                                ToolTip="Provided by CX" ValidationGroup="E">*</asp:RequiredFieldValidator>
                                                                            <asp:RangeValidator ID="RangeValidator9" runat="server"
                                                                                ControlToValidate="txtOpportunityID" Display="Dynamic"
                                                                                ErrorMessage="Numeric Only" MaximumValue="1000000" MinimumValue="0"
                                                                                SetFocusOnError="True" ToolTip="Provided by CX" Type="Integer"
                                                                                ValidationGroup="E">*</asp:RangeValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group row">
                                                                        <label class="col-form-label col-md-4 col-sm-4">Contact ID<span style="color: red">*</span></label>
                                                                        <div class="col-md-8 col-sm-8 ">
                                                                            <asp:TextBox ID="txtContactID" runat="server" TabIndex="75"
                                                                                ToolTip="Can be changed by Admission and Head of Registration" CssClass="form-control"></asp:TextBox>
                                                                            <asp:LinkButton ID="lnkGet" runat="server" OnCommand="lnkGet_Command"
                                                                             Font-Strikeout="False" Font-Underline="True"
                                                                            ToolTip="Get current student CX contact ID." ForeColor="Blue">Get from CRM</asp:LinkButton>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="lnkCheck" runat="server" OnCommand="lnkCheck_Command"
                                                                             Font-Strikeout="False" Font-Underline="True"
                                                                            ToolTip="Check student detail using CX contact ID." ForeColor="Blue">Check</asp:LinkButton>
                                                                            <asp:Label ID="lbl_contacterror" runat="server" ForeColor="Red"></asp:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"
                                                                                ControlToValidate="txtContactID" Display="Dynamic"
                                                                                ErrorMessage="Contact ID is required" SetFocusOnError="True"
                                                                                ToolTip="Provided by CX" ValidationGroup="E">*</asp:RequiredFieldValidator>
                                                                            <asp:RangeValidator ID="RangeValidator10" runat="server"
                                                                                ControlToValidate="txtContactID" Display="Dynamic" ErrorMessage="Numeric Only"
                                                                                MaximumValue="1000000" MinimumValue="0" SetFocusOnError="True"
                                                                                ToolTip="Provided by CX" Type="Integer" ValidationGroup="E">*</asp:RangeValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group row">
                                                                        <label class="col-form-label col-md-4 col-sm-4">Acceptance Type</label>
                                                                        <div class="col-md-8 col-sm-8 ">
                                                                            <asp:DropDownList ID="ddlAcceptance" runat="server" DataSourceID="AcceptanceDs"
                                                                                DataTextField="sAcceptanceTypeEn" DataValueField="iAcceptanceType"
                                                                                TabIndex="71" ToolTip="Can be changed by Admission and Head of Registration"
                                                                                CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                            <asp:SqlDataSource ID="AcceptanceDs" runat="server"
                                                                                ConnectionString="<%$ ConnectionStrings:ECTDataMales %>"
                                                                                SelectCommand="SELECT [iAcceptanceType], [sAcceptanceTypeEn] FROM [Lkp_Acceptance_Type] ORDER BY [iAcceptanceType]"></asp:SqlDataSource>
                                                                        </div>
                                                                    </div>
                                                                        <div class="form-group row">
                                                                        <label class="col-form-label col-md-4 col-sm-4">Acceptance Condition</label>
                                                                        <div class="col-md-8 col-sm-8 ">
                                                                            <asp:DropDownList ID="ddlAcceptanceCondition" runat="server"
                                                                                DataSourceID="AcceptanceConditionDs" DataTextField="sAcceptanceConditionEn"
                                                                                DataValueField="iAcceptanceCondition" TabIndex="71"
                                                                                ToolTip="Can be changed by Admission and Head of Registration" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                            <asp:SqlDataSource ID="AcceptanceConditionDs" runat="server"
                                                                                ConnectionString="<%$ ConnectionStrings:ECTDataMales %>"
                                                                                SelectCommand="SELECT [iAcceptanceCondition], [sAcceptanceConditionEn] FROM [Lkp_Acceptance_Condition] ORDER BY [iAcceptanceCondition]"></asp:SqlDataSource>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group row">
                                                                        <label class="col-form-label col-md-4 col-sm-4">Admission Status</label>
                                                                        <div class="col-md-8 col-sm-8 ">
                                                                            <asp:DropDownList ID="ddlAdmissionStatus" runat="server"
                                                                                DataSourceID="AdmissionStatusDs" DataTextField="sAdmissionStatusEn"
                                                                                DataValueField="iAdmissionStatus" TabIndex="71"
                                                                                ToolTip="Can be changed by Admission and Head of Registration" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                            <asp:SqlDataSource ID="AdmissionStatusDs" runat="server"
                                                                                ConnectionString="<%$ ConnectionStrings:ECTDataMales %>"
                                                                                SelectCommand="SELECT [iAdmissionStatus], [sAdmissionStatusEn] FROM [Lkp_Admission_Status] ORDER BY [iAdmissionStatus]"></asp:SqlDataSource>
                                                                        </div>
                                                                    </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Application No</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:TextBox ID="lblECTId" runat="server" ReadOnly="true"
                                                                                    CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    <div class="form-group row">
                                                                        <label class="col-form-label col-md-4 col-sm-4">Student ID</label>
                                                                        <div class="col-md-8 col-sm-8 ">
                                                                            <asp:TextBox ID="lblStudentId" runat="server" ReadOnly="true"
                                                                                CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Date</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:TextBox ID="lblDateEnrolled" runat="server" ReadOnly="true"
                                                                                    CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Reference ID</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:TextBox ID="lblReference" runat="server" 
                                                                                    CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                       
                                                                         <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4" >ORCID</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:TextBox ID="txtORCID" runat="server"  TabIndex="75"
                                                                                    CssClass="form-control">NA</asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <hr />
                                                                            <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Is Military Service</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:CheckBox ID="ChkIsMilitaryService" runat="server" AutoPostBack="True"
                                                                                    OnCheckedChanged="ChkIsMilitaryService_CheckedChanged" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Date of Military Service</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:TextBox ID="txtMilitaryServiceDate" runat="server" TabIndex="45"
                                                                                    ToolTip="mm/dd/yyyy" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                                                <asp:RangeValidator ID="RangeValidator8" runat="server"
                                                                                    ControlToValidate="txtMilitaryServiceDate" Display="Dynamic"
                                                                                    ErrorMessage="Date Only" MaximumValue="01/01/3000" MinimumValue="01/01/1900"
                                                                                    SetFocusOnError="True" Type="Date" ValidationGroup="E">mm/dd/yyyy</asp:RangeValidator>
                                                                            </div>
                                                                        </div>
                                                                        <hr />
                                                                        <p class="text-muted well well-sm no-shadow" style="margin-top: 5px;">
                                                                            Status
                                                                        </p>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Status</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlStatus" runat="server" DataTextField="strReasonDesc"
                                                                                    DataValueField="byteReason" Enabled="False" TabIndex="87" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Term</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlStatusTerm" runat="server" DataTextField="LongDesc"
                                                                                    DataValueField="Term" Enabled="False" TabIndex="88" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Major Reason</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlReason" runat="server" AutoPostBack="True"
                                                                                    DataTextField="strMainReasonEn" DataValueField="byteMainReason" Enabled="False"
                                                                                    TabIndex="89" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Minor Reason</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlSubReason" runat="server" DataSourceID="SubReasonDS"
                                                                                    DataTextField="strSubReasonEn" DataValueField="byteSubReson" Enabled="False"
                                                                                    TabIndex="90" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Date</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:TextBox ID="lblDateStatus" runat="server" ReadOnly="true"
                                                                                    CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4"></label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:CheckBox ID="chkCompleteBAFromOtherInstitution" runat="server"
                                                                                    Enabled="False" Style="font-weight: bold" TabIndex="91"
                                                                                    Text="&nbsp;&nbsp;Is complete BA from other  institution" />
                                                                            </div>
                                                                        </div>
                                                                          <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4"></label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:CheckBox ID="chkCompleteMasterFromOtherInstitution" runat="server" 
                                                        Enabled="False" style="font-weight: bold" TabIndex="92" 
                                                        Text="&nbsp;&nbsp;Is complete Master from other  institution" />
                                                                            </div>
                                                                        </div>
                                                                        </div>
                                                                </div>

                                                                <style>
                                                                    .well {
    min-height: 20px;
    padding: 0px;
    margin-bottom: 20px;
    background-color: #3f658c;
    border: 1px solid #e3e3e3;
    border-radius: 4px;
    -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,0.05);
    box-shadow: inset 0 1px 1px rgba(0,0,0,0.05);
}
                                                                    .text-muted {
    color: #ffffff!important;
    font-size: large;
    text-align: center;
}
                                                                </style>
                                                                <div class="col-md-6 col-sm-6">
                                                                    <div class="x_panel">
                                                                            <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Type</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True"
                                                                                    TabIndex="74" CssClass="form-control">
                                                                                    <asp:ListItem Value="2">Foundation</asp:ListItem>
                                                                                    <asp:ListItem Value="5">ESL (Re-medial)</asp:ListItem>
                                                                                    <asp:ListItem Selected="True" Value="0">Diploma</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Bachelor</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Visiting</asp:ListItem>
                                                                                    <asp:ListItem Value="4">Language Center</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Current Major</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlMajor" runat="server" DataSourceID="MajorDS"
                                                                                    DataTextField="strMajor" DataValueField="strKey" TabIndex="76"
                                                                                    CssClass="form-control" OnSelectedIndexChanged="ddlMajor_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Preferred Major 1</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlWMajor1" runat="server" DataSourceID="WMajorDS"
                                                                                    DataTextField="MajorDescEn" DataValueField="MajorID" TabIndex="77"
                                                                                    CssClass="form-control" AutoPostBack="True"
                                                                                    OnSelectedIndexChanged="ddlWMajor1_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Preferred Major 2</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlWMajor2" runat="server" DataSourceID="WMajorDS"
                                                                                    DataTextField="MajorDescEn" DataValueField="MajorID" TabIndex="78"
                                                                                    CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Preferred Major 3</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlWMajor3" runat="server" DataSourceID="WMajorDS"
                                                                                    DataTextField="MajorDescEn" DataValueField="MajorID" TabIndex="79"
                                                                                    CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Advisor</label>
                                                                            <div class="col-md-6 col-sm-6 ">
                                                                                <asp:DropDownList ID="ddlAdvisor" runat="server"
                                                                                    DataTextField="strLecturerDescEn" DataValueField="intLecturer" TabIndex="80"
                                                                                    CssClass="form-control" Enabled="False">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="col-md-2 col-sm-2 ">
                                                                                <asp:Button ID="btnSetAdvisor" runat="server" OnClick="btnSetAdvisor_Click"
                                                                                    Text="Set" CssClass="btn btn-success btn-sm"/>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Note</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:TextBox ID="txtNote" runat="server" Height="90px" TabIndex="81"
                                                                                    TextMode="MultiLine" CssClass="form-control">-</asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <hr />
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Referred By</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:TextBox ID="txtReferredBy" runat="server" TabIndex="82"
                                                                                    ToolTip="The ID of the studet that referred the current" CssClass="form-control">NA</asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">How did you hear about ECT (Source)?</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlEnrollmentSource" runat="server" CssClass="form-control"
                                                                                    OnSelectedIndexChanged="ddlEnrollmentSource_SelectedIndexChanged"
                                                                                    DataSourceID="SourcesDS"
                                                                                    DataTextField="DescEn" DataValueField="MinorID" TabIndex="83">
                                                                                </asp:DropDownList>
                                                                                <asp:SqlDataSource ID="SourcesDS" runat="server"
                                                                                    ConnectionString="<%$ ConnectionStrings:ECTDataNew %>"
                                                                                    SelectCommand="SELECT MinorID, DescEn FROM Cmn_LookupDetails WHERE (MajorID = @MajorID) ORDER BY DescEn">
                                                                                    <SelectParameters>
                                                                                        <asp:Parameter DefaultValue="3004" Name="MajorID" Type="Int32" />
                                                                                    </SelectParameters>
                                                                                </asp:SqlDataSource>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Other Source<span style="color: red">*</span></label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:TextBox ID="txtEnrollmentSource" runat="server" OnTextChanged="txtEnrollmentSource_TextChanged"
                                                                                    CssClass="form-control" TabIndex="84">-</asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                                                                    ControlToValidate="txtEnrollmentSource"
                                                                                    ErrorMessage="Please enter the other source" ValidationGroup="E">*</asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">How did you hear about ECT (Second Source)?</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlEnrollmentSource2" runat="server"
                                                                                    DataSourceID="SourcesDS" DataTextField="DescEn" DataValueField="MinorID"
                                                                                    OnSelectedIndexChanged="ddlEnrollmentSource_SelectedIndexChanged"
                                                                                    CssClass="form-control" TabIndex="85">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Registered through</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlRegisteredThrough" runat="server"
                                                                                    CssClass="form-control" TabIndex="86">
                                                                                    <asp:ListItem Selected="True" Value="1">General</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Corporate agreements</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Schools Visits</asp:ListItem>
                                                                                    <asp:ListItem Value="4">Ana Wasadeeqi</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <hr />
                                                                    <%--    <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Is Military Service</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:CheckBox ID="ChkIsMilitaryService" runat="server" AutoPostBack="True"
                                                                                    OnCheckedChanged="ChkIsMilitaryService_CheckedChanged" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Date of Military Service</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:TextBox ID="txtMilitaryServiceDate" runat="server" TabIndex="45"
                                                                                    ToolTip="mm/dd/yyyy" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                                                <asp:RangeValidator ID="RangeValidator8" runat="server"
                                                                                    ControlToValidate="txtMilitaryServiceDate" Display="Dynamic"
                                                                                    ErrorMessage="Date Only" MaximumValue="01/01/3000" MinimumValue="01/01/1900"
                                                                                    SetFocusOnError="True" Type="Date" ValidationGroup="E">mm/dd/yyyy</asp:RangeValidator>
                                                                            </div>
                                                                        </div>
                                                                        <hr />--%>
                                                                        <p class="text-muted well well-sm no-shadow" style="margin-top: 5px;">
                                                                            Last Degree
                                                                        </p>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Last Degree</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlLastDegree" runat="server"
                                                                                    DataTextField="strDegreeDescEn" DataValueField="strDegree"
                                                                                    TabIndex="93" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Institution</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlLastInistitution" runat="server" DataTextField="strCollegeDescEn"
                                                                                    DataValueField="byteCollege" TabIndex="94" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Country</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlLastCountry" runat="server" AutoPostBack="True" DataTextField="strCountryDescEn"
                                                                                    DataValueField="byteCountry"
                                                                                    OnSelectedIndexChanged="ddlQCountry_SelectedIndexChanged" TabIndex="95"
                                                                                    CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Year</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                 <asp:TextBox ID="txtLastYear" runat="server" TabIndex="96" CssClass="form-control">9999</asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">CGPA</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                 <asp:TextBox ID="txtLastCGPA" runat="server" TabIndex="97" CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Equivalency Indicator</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:DropDownList ID="ddlLHEquivalencyIndicator" runat="server" TabIndex="98"
                                                                                    CssClass="form-control">
                                                                                    <asp:ListItem Selected="True" Value="T">CAA accredited UAE universities</asp:ListItem>
                                                                                    <asp:ListItem Value="Y">Equivalency has been received</asp:ListItem>
                                                                                    <asp:ListItem Value="R">Rejected</asp:ListItem>
                                                                                    <asp:ListItem Value="A">Applied</asp:ListItem>
                                                                                    <asp:ListItem Value="N">Not Applied Yet</asp:ListItem>
                                                                                    <asp:ListItem Value="U">Equivalency status unknown</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <label class="col-form-label col-md-4 col-sm-4">Equivalency App No.</label>
                                                                            <div class="col-md-8 col-sm-8 ">
                                                                                <asp:TextBox ID="txtLHEquivalencyAppNo" runat="server" TabIndex="99"
                                                                                    CssClass="form-control">NA</asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <hr />
                                                                        <br />
                                                                        <div class="form-group row">
                                                                            <asp:LinkButton ID="SaveE_btn" runat="server" CssClass="btn btn-success btn-sm" ToolTip="Save Enrollment" ValidationGroup="E" OnClick="SaveE_btn_Click"><i class="fa fa-floppy-o"></i> Save</asp:LinkButton>
                                                                            <asp:LinkButton ID="UndoE_btn" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="False" ToolTip="Undo" ValidationGroup="None" OnClick="UndoQ_btn_Click"><i class="fa fa-reply"></i> Undo</asp:LinkButton>
                                                                            <asp:LinkButton ID="AddESLs" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="False" ToolTip="Add ESLs" OnClick="AddESLs_Click" Visible="false"><i class="fa fa-plus"></i> Add ESLs</asp:LinkButton>
                                                                            <asp:LinkButton ID="Print_btn" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="False" ToolTip="Print as PDF" OnClick="Print_btn_Click"><i class="fa fa-print"></i> Print</asp:LinkButton>
                                                                            <asp:DropDownList ID="ddlPrinting" runat="server" TabIndex="100" CssClass="form-control" Width="27%">
                                                                                <asp:ListItem Value="0">Welcome letter</asp:ListItem>
                                                                                <asp:ListItem Value="1">Admission Letter</asp:ListItem>
                                                                                <asp:ListItem Value="2">Admission Form</asp:ListItem>
                                                                                <asp:ListItem Value="3">Profile Cover</asp:ListItem>
                                                                                <asp:ListItem Value="4" Selected="True">Pwd</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>


                                                            </div>
                                                        </asp:View>
                                                        <%--End View 2--%>

                                                        <%--Start View 3--%>
                                                        <asp:View ID="View3" runat="server">
                                                            <div class="col-md-12 col-sm-12">
                                                                <h3 style="text-align: center; "><i class="fa fa-folder-open"></i> Files</h3>
                                                                <hr />
                                                                 <table  align="center">
                                    <tr>
                                        <td align="center">
                                        
                                            <div>
                                                <asp:MultiView ID="mtvDocs" runat="server" ActiveViewIndex="0">
                                                    <asp:View ID="View8" runat="server">
                                                        <table  align="center">
                                                            <tr>
                                                                <td align="center">
                                                                
                                                                    <asp:GridView ID="grdDocs" runat="server" AutoGenerateColumns="False" 
                                                                        CellPadding="4" DataKeyNames="intDocument" DataSourceID="DocumentsDS" 
                                                                        ForeColor="#444444" GridLines="None" 
                                                                        onselectedindexchanged="grdDocs_SelectedIndexChanged">
                                                                        <RowStyle BackColor="#EFF3FB" />
                                                                        <Columns>
                                                                            <asp:CommandField ShowSelectButton="True" ControlStyle-ForeColor="Blue" ControlStyle-Font-Underline="true"/>
                                                                            <asp:BoundField DataField="lngSerial" HeaderText="#" ReadOnly="True" 
                                                                                SortExpression="lngSerial" Visible="False" />
                                                                            <asp:BoundField DataField="intDocument" HeaderText="#" ReadOnly="True" 
                                                                                SortExpression="intDocument">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="strDocumentEn" HeaderText="Doc" 
                                                                                SortExpression="strDocumentEn">
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <asp:CheckBoxField DataField="isMandatory" HeaderText="Mandatory" 
                                                                                SortExpression="isMandatory">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:CheckBoxField>
                                                                            <asp:CheckBoxField DataField="isAvailable" HeaderText="Available" 
                                                                                SortExpression="isAvailable">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:CheckBoxField>
                                                                            <asp:BoundField DataField="strRemark" HeaderText="Remark" 
                                                                                SortExpression="strRemark">
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <%--<asp:BoundField DataField="strURL" HeaderText="Files" 
                                                                                SortExpression="strURL">
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>--%>
                                                                             <%-- <asp:BoundField DataField="strURL" HtmlEncode="False" HeaderText="Files"
                                                                                  DataFormatString="<a target='_blank' href='{0}'>{0}</a>" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true"/>--%>
                                                                            <asp:HyperLinkField DataTextField="strTitle" DataNavigateUrlFields="strURL" 
                                                                                DataNavigateUrlFormatString="{0}" HeaderText="Files" 
                                                                                SortExpression="strURL" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true" Target="_blank"/>

                                                                        </Columns>
                                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                        <EmptyDataTemplate>                                                                            
                                                                            <asp:LinkButton ID="btnAddDocs" runat="server" onclick="btnAddDocs_Click" 
                                                                                ToolTip="Initiate Documents" ValidationGroup="SD"><i class="fa fa-plus"></i> Add Docs</asp:LinkButton>
                                                                        </EmptyDataTemplate>
                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#444444" />
                                                                        <HeaderStyle BackColor="#3f658c" Font-Bold="True" ForeColor="White" />
                                                                        <EditRowStyle BackColor="White" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    </asp:GridView>
                                                                
                                                                </td>
                                                            </tr>
                                                            </table>
                                                    </asp:View>
                                                    <asp:View ID="View9" runat="server">
                                                        <table class="style7">
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:SqlDataSource ID="DocsEditDS" runat="server" 
                                                                        ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                                                        DeleteCommand="DELETE FROM Reg_Students_Files WHERE (intUnified = @intUnified)" 
                                                                        SelectCommand="SELECT [intFile],[intUnified], [intDocument], [isMandatory], [isAvailable], [strRemark],[strURL],[strTitle] FROM [Reg_Students_Files] WHERE (([intUnified] = @intUnified) AND ([intDocument] = @intDocument))" 
                                                                        UpdateCommand="UPDATE Reg_Students_Files SET isMandatory = @isMandatory, isAvailable = @isAvailable, strRemark = @strRemark, strUserSave = @strUserSave, dateLastSave = GETDATE() WHERE (intUnified = @intUnified) AND (intDocument = @intDocument)">
                                                                        <SelectParameters>
                                                                            <asp:ControlParameter ControlID="hdniUnifiedID" DefaultValue="0" Name="intUnified" 
                                                                                PropertyName="Value" Type="Int32" />
                                                                            <asp:ControlParameter ControlID="grdDocs" DefaultValue="0" Name="intDocument" 
                                                                                PropertyName="SelectedValue" Type="Int16" />
                                                                        </SelectParameters>
                                                                        <DeleteParameters>
                                                                            <asp:ControlParameter ControlID="hdniUnifiedID" DefaultValue="0" Name="intUnified" 
                                                                                PropertyName="Value" />
                                                                        </DeleteParameters>
                                                                        <UpdateParameters>
                                                                            <asp:Parameter Name="intUnified" />
                                                                            <asp:Parameter Name="intDocument" />
                                                                            <asp:Parameter Name="isMandatory" />
                                                                            <asp:Parameter Name="isAvailable" />
                                                                            <asp:Parameter Name="strRemark" />
                                                                            <asp:Parameter Name="intFile" />
                                                                            <asp:SessionParameter DefaultValue="-" Name="strUserSave" 
                                                                                SessionField="CurrentUserName" />
                                                                        </UpdateParameters>
                                                                    </asp:SqlDataSource>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:DetailsView ID="dvDocs" runat="server" AutoGenerateEditButton="True"
                                                                        AutoGenerateRows="False" CellPadding="4" DataKeyNames="intUnified,intDocument,intFile"
                                                                        DataSourceID="DocsEditDS" DefaultMode="Edit" ForeColor="#333333"
                                                                        GridLines="None" Height="50px" OnItemUpdated="dvDocs_ItemUpdated" Width="125px">
                                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                        <Fields>
                                                                            <asp:CheckBoxField DataField="isMandatory" HeaderText="Mandatory"
                                                                                SortExpression="isMandatory" />
                                                                            <asp:CheckBoxField DataField="isAvailable" HeaderText="Available"
                                                                                SortExpression="isAvailable" />
                                                                            <asp:BoundField DataField="strRemark" HeaderText="Remark"
                                                                                SortExpression="strRemark" />
                                                                            <asp:TemplateField HeaderText="Upload">
                                                                                <EditItemTemplate>
                                                                                    <asp:FileUpload ID="FileUpload" runat="server" />
                                                                                </EditItemTemplate>
                                                                            </asp:TemplateField>
                                                                             <asp:HyperLinkField DataTextField="strTitle" DataNavigateUrlFields="strURL" 
                                                                                DataNavigateUrlFormatString="{0}" HeaderText="Files" 
                                                                                SortExpression="strURL" ItemStyle-ForeColor="Blue" ItemStyle-Font-Underline="true" Target="_blank"/>

                                                                        </Fields>
                                                                        <HeaderStyle BackColor="#3f658c" Font-Bold="True" ForeColor="White" />
                                                                        <EditRowStyle BackColor="#999999" />
                                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                    </asp:DetailsView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:View>
                                                </asp:MultiView>
                                                <asp:SqlDataSource ID="DocumentsDS" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                                    SelectCommand="SELECT SD.intUnified, SD.intDocument,SD.strTitle, D.strDocumentEn, SD.isMandatory, SD.isAvailable, SD.strRemark,SD.strURL FROM Reg_Students_Files AS SD INNER JOIN Lkp_Student_Documents AS D ON SD.intDocument = D.intDocument WHERE (SD.intUnified = @hdniUnifiedID) ORDER BY SD.intDocument">
                                                    <%--SelectCommand="SELECT SD.lngSerial, SD.intDocument, D.strDocumentEn, SD.isMandatory, SD.isAvailable, SD.strRemark FROM Reg_Students_Documents AS SD INNER JOIN Lkp_Student_Documents AS D ON SD.intDocument = D.intDocument WHERE (SD.lngSerial = @lngSerial) ORDER BY SD.intDocument">--%>
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="hdniUnifiedID" DefaultValue="0" Name="hdniUnifiedID" 
                                                            PropertyName="Value" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </div>
                                        
                                        </td>
                                    </tr>
                                </table>   
                                                                </div>
                                                        </asp:View>
                                                        <%--End View 3--%>

                                                         <%--Start View 4--%>
                                                        <asp:View ID="View4" runat="server">
                                                            <div class="col-md-12 col-sm-12">
                                                                <h3 style="text-align: center; "><i class="fa fa-table"></i> Marks</h3>
                                                                <hr />

                                                                 <div>
                                                <asp:MultiView ID="mtvMarks" runat="server" ActiveViewIndex="0">
                                                    <table  align="center">
                                                        <tr>
                                                            <td align="center">                                                                
                                                                <asp:View ID="View10" runat="server">
                                                                    <table align="center">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:GridView ID="grdMarks" runat="server" AutoGenerateColumns="False" 
                                                                                    CellPadding="4" DataSourceID="MarksDS" ForeColor="#444444" GridLines="None">
                                                                                    <RowStyle BackColor="#EFF3FB" />
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="lngStudentNumber" HeaderText="lngStudentNumber" 
                                                                                            SortExpression="lngStudentNumber" Visible="False" />
                                                                                        <asp:BoundField DataField="strCourse" HeaderText="Code" 
                                                                                            SortExpression="strCourse" />
                                                                                        <asp:BoundField DataField="strCourseDescEn" HeaderText="Course" 
                                                                                            SortExpression="strCourseDescEn" />
                                                                                        <asp:BoundField DataField="byteCreditHours" HeaderText="Hours" 
                                                                                            SortExpression="byteCreditHours" />
                                                                                        <asp:BoundField DataField="strGrade" HeaderText="Mark" 
                                                                                            SortExpression="strGrade" />
                                                                                    </Columns>
                                                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#444444" />
                                                                                    <HeaderStyle BackColor="#3f658c" Font-Bold="True" ForeColor="White" />
                                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                                    <AlternatingRowStyle BackColor="White" />
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <div style="background-color: #FFFFFF">                                                                                   
                                                                                     <asp:LinkButton ID="AddM_btn" runat="server" onclick="AddM_btn_Click" 
                                                                                ToolTip="Add Mark" CausesValidation="False" CssClass="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add Mark</asp:LinkButton>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:SqlDataSource ID="MarksDS" runat="server" 
                                                                                    ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                                                                    InsertCommand="INSERT INTO Reg_Grade_Header(intStudyYear, byteSemester, byteShift, strCourse, byteClass, lngStudentNumber, curUseMark, strGrade, bDisActivated, bCanceled, strUserCreate, dateCreate, byteRefCollege) VALUES (0, 0, 1, @strCourse, 1, @lngStudentNumber, 0, @strGrade, 0, 0, @strUserCreate, GETDATE(), @byteRefCollege)" 
                                                                                    SelectCommand="SELECT Reg_Grade_Header.lngStudentNumber, Reg_Grade_Header.strCourse, Reg_Courses.strCourseDescEn, Reg_Courses.byteCreditHours, Reg_Grade_Header.strGrade FROM Reg_Grade_Header INNER JOIN Reg_Courses ON Reg_Grade_Header.strCourse = Reg_Courses.strCourse WHERE (Reg_Grade_Header.lngStudentNumber = @lngStudentNumber) AND (Reg_Grade_Header.strGrade = N'TC' OR Reg_Grade_Header.strGrade = N'EX') ORDER BY Reg_Grade_Header.strCourse">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="lblStudentId" DefaultValue="-" 
                                                                                            Name="lngStudentNumber" PropertyName="Text" />
                                                                                    </SelectParameters>
                                                                                    <InsertParameters>
                                                                                        <asp:ControlParameter ControlID="ddlCourses" DefaultValue="-" Name="strCourse" 
                                                                                            PropertyName="SelectedValue" />
                                                                                        <asp:ControlParameter ControlID="lblStudentId" DefaultValue="-" 
                                                                                            Name="lngStudentNumber" PropertyName="Text" />
                                                                                        <asp:ControlParameter ControlID="ddlMark" DefaultValue="-" Name="strGrade" 
                                                                                            PropertyName="SelectedValue" />
                                                                                        <asp:SessionParameter DefaultValue="-" Name="strUserCreate" 
                                                                                            SessionField="CurrentUserName" />
                                                                                        <asp:ControlParameter ControlID="ddlMSource" DefaultValue="0" 
                                                                                            Name="byteRefCollege" PropertyName="SelectedValue" />
                                                                                    </InsertParameters>
                                                                                </asp:SqlDataSource>
                                                                            </td>
                                                                        </tr>
                                                                    </table>                                                                                                                                                                                                                                
                                                                </asp:View>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:View ID="View11" runat="server">
                                                                    <table  align="center">
                                                                        <tr>
                                                                            <td align="center" colspan="3">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" width="40%">
                                                                                <asp:Label ID="Label51" runat="server" Font-Size="Small" Text="Course" 
                                                                                    Width="100px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" width="50%">
                                                                                <asp:DropDownList ID="ddlCourses" runat="server" TabIndex="101" Width="100px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td align="left" width="10%">
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" width="40%">
                                                                                <asp:Label ID="Label52" runat="server" Font-Size="Small" Text="Mark" 
                                                                                    Width="100px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" width="50%">
                                                                                <asp:DropDownList ID="ddlMark" runat="server" DataTextField="LongDesc" 
                                                                                    DataValueField="Term" TabIndex="102" Width="75px">
                                                                                    <asp:ListItem Selected="True">EX</asp:ListItem>
                                                                                    <asp:ListItem>TC</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td align="left" width="10%">
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" width="40%">
                                                                                <asp:Label ID="Label53" runat="server" Font-Size="Small" Text="Source" 
                                                                                    Width="100px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" width="50%">
                                                                                <asp:DropDownList ID="ddlMSource" runat="server" TabIndex="103" Width="200px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td align="left" width="10%">
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" width="40%">
                                                                                &nbsp;</td>
                                                                            <td align="left" width="50%">
                                                                                &nbsp;</td>
                                                                            <td align="left" width="10%">
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" class="style9" colspan="3">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" class="style9" colspan="3">
                                                                                <div style="background-color: #FFFFFF">
                                                                                 <%--   <asp:ImageButton ID="SaveM_btn" runat="server" CausesValidation="False" 
                                                                                        ImageUrl="~/Images/Icons/Save.gif" onclick="SaveM_btn_Click" 
                                                                                        ToolTip="Save Mark" Width="43px" />
                                                                                    <asp:ImageButton ID="UndoM_btn" runat="server" CausesValidation="False" 
                                                                                        ImageUrl="~/Images/Icons/GoBack.jpg" onclick="UndoM_btn_Click" ToolTip="Undo" />--%>

                                                                                    <asp:LinkButton ID="SaveM_btn" runat="server" onclick="SaveM_btn_Click" 
                                                                                ToolTip="Save Mark" CausesValidation="False" CssClass="btn btn-success btn-sm"><i class="fa fa-floppy-o"></i> Save Mark</asp:LinkButton>

                                                                                    <asp:LinkButton ID="UndoM_btn" runat="server" onclick="UndoM_btn_Click" 
                                                                                ToolTip="Undo" CausesValidation="False" CssClass="btn btn-success btn-sm"><i class="fa fa-reply"></i> Undo</asp:LinkButton>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>  
                                                                </asp:View>
                                                            </td>
                                                        </tr>
                                                    </table>                                                                                                                    
                                                </asp:MultiView>
                                            </div>

                                                                </div>
                                                        </asp:View>
                                                        <%--End View 4--%>

                                                         <%--Start View 7--%>
                                                        <asp:View ID="View7" runat="server">
                                                            <div class="col-md-12 col-sm-12">
                                                                <h3 style="text-align: center;"><i class="fa fa-search"></i> Search</h3>
                                                                <hr />
                                                                  <div>
                                    <table align="center">
                                        <%-- <tr>
                                            <td align="right" width="40%">
                                                &nbsp;</td>
                                            <td align="left" width="50%">
                                                &nbsp;</td>
                                            <td align="left" width="10%">
                                                &nbsp;</td>
                                        </tr>--%>
                                        <tr>
                                            <td align="right" width="40%">
                                                <asp:LinkButton ID="lnkAdvanced" runat="server" CausesValidation="False" 
                                                    PostBackUrl="~/StudentSearch.aspx" CssClass="btn btn-success btn-sm"><i class="fa fa-search"></i> Advanced Search</asp:LinkButton>
                                            </td>
                                            <td align="left" width="50%">
                                                &nbsp;</td>
                                            <td align="left" width="10%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="40%">
                                                <asp:Label ID="Label58" runat="server" Font-Size="Small" Text="Student ID" 
                                                    Width="100px"></asp:Label>
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:TextBox ID="txtSearchID" runat="server" Width="250px" TabIndex="104" CssClass="form-control"></asp:TextBox>
                                            </td>
                                            <td align="left" width="10%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="40%">
                                                <asp:Label ID="Label59" runat="server" Font-Size="Small" Text="Student Name" 
                                                    Width="100px"></asp:Label>
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:TextBox ID="txtSearchName" runat="server" Width="250px" TabIndex="105" CssClass="form-control"></asp:TextBox>
                                            </td>
                                            <td align="left" width="10%">
                                                &nbsp;</td>
                                        </tr>
                                              <tr>
                                            <td align="right" class="style9" colspan="3">
                                                <div align="center" style="background-color: #FFFFFF">
                                                    <asp:LinkButton ID="RunCMD" runat="server" CausesValidation="False" 
                                                        onclick="RunCMD_Click" 
                                                        CssClass="btn btn-success btn-sm"
                                                        ToolTip="Run"><i class="fa fa-search"></i> Search</asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style9" colspan="3">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="style9" colspan="3">
                                                <asp:GridView ID="grdSearch" runat="server" AutoGenerateColumns="False" 
                                                    CellPadding="4" DataKeyNames="lngSerial" DataSourceID="SearchDS" 
                                                    ForeColor="#444444" GridLines="None">
                                                    <RowStyle BackColor="#EFF3FB" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="#" InsertVisible="False" 
                                                            SortExpression="lngSerial">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("lngSerial") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkSelect" runat="server" CausesValidation="False" 
                                                                    CommandArgument='<%# Bind("lngSerial") %>' oncommand="lnkSelect_Command" Font-Underline="true" ForeColor="Blue">Select</asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle  Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="lngStudentNumber" HeaderText="ID" 
                                                            SortExpression="lngStudentNumber">
                                                            <ItemStyle  Width="150px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="strLastDescEn" HeaderText="Name" 
                                                            SortExpression="strLastDescEn">
                                                            <ItemStyle  Width="250px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="dateCreate" DataFormatString="{0:dd/MM/yyyy}" 
                                                            HeaderText="Created" SortExpression="dateCreate">
                                                            <ItemStyle  Width="100px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Print">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="Search_Print" runat="server" 
                                                                    CommandArgument='<%# Eval("lngStudentNumber") %>' 
                                                                     oncommand="Search_Print_Command" 
                                                                    CssClass="btn btn-success btn-sm"
                                                                    ToolTip="Audit Form Print"><i class="fa fa-print"></i> Print</asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle  Width="50px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#3f658c" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#444444" />
                                                    <HeaderStyle BackColor="#3f658c" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="40%">
                                                &nbsp;</td>
                                            <td align="left" width="50%">
                                                <asp:SqlDataSource ID="SearchDS" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                                    SelectCommand="SELECT SD.lngSerial, A.lngStudentNumber, SD.strLastDescEn, SD.dateCreate FROM Reg_Applications AS A RIGHT OUTER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial WHERE (1 &lt;&gt; 1)">
                                                </asp:SqlDataSource>
                                            </td>
                                            <td align="left" width="10%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style9" colspan="3">
                                                <hr />
                                            </td>
                                        </tr>                                  
                                    </table>
                                </div>                 
                                                                </div>
                                                        </asp:View>
                                                        <%--End View 7--%>
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
    <asp:SqlDataSource ID="WMajorDS" runat="server"
        ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>"
        SelectCommand="SELECT [MajorID], [MajorDescEn] FROM [Lkp_FoundationMajors] ORDER BY [MajorID]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="MajorDS" runat="server"
        ConnectionString="<%$ ConnectionStrings:ECTDataMales %>"
        SelectCommand="SELECT [strKey], [strMajor] FROM [Reg_Specializations] WHERE ([intCenter] = @intCenter) ORDER BY [intSerial]">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlType" DefaultValue="0" Name="intCenter"
                PropertyName="SelectedValue" Type="Int16" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SubReasonDS" runat="server"
        ConnectionString="<%$ ConnectionStrings:ECTDataMales %>"
        SelectCommand="SELECT [byteSubReson], [strSubReasonEn] FROM [Lkp_SubReasons] WHERE ([byteMainReason] = @byteMainReason) ORDER BY [strSubReasonEn]">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlReason" DefaultValue="0"
                Name="byteMainReason" PropertyName="SelectedValue" Type="Int16" />
        </SelectParameters>
    </asp:SqlDataSource>
   
                            <asp:SqlDataSource ID="StudentDS" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                InsertCommand="AddStudent" 
                                
                                UpdateCommand="UPDATE Reg_Students_Data SET strFirstDescEn = @strFirstDescEn, strSecondDescEn = @strSecondDescEn, strLastDescEn = @strLastDescEn, strFirstDescAr = @strFirstDescAr, strSecondDescAr = @strSecondDescAr, strLastDescAr = @strLastDescAr, bSex = @bSex, dateBirth = @dateBirth, byteBirthCountry = @byteBirthCountry, byteBirthCity = @byteBirthCity, byteNationality = @byteNationality, byteIDType = @byteIDType, strID = @strID, byteHomeCountry = @byteHomeCountry, byteHomeCity = @byteHomeCity, byteOriginCountry = @byteOriginCountry, byteOriginCity = @byteOriginCity, strPhone1 = @strPhone1, strPhone2 = @strPhone2, strEmail = @strEmail, strAddress = @strAddress, byteShift = @byteShift, strNationalID = @strNationalID, intWorkPlace = @intWorkPlace, strWorkPhone = @strWorkPhone, strJopTitle = @strJopTitle, intDelegation = @intDelegation, intSponsor = @intSponsor, dateEndSponsorship = @dateEndSponsorship, strUserSave = @strUserSave, dateLastSave = GETDATE(), strNUser = @strUserSave, byteReligion = @byteReligion, isWorking = @isWorking, EthbaraNo = @EthbaraNo, FitnessStatus = @FitnessStatus, MaritalStatus = @MaritalStatus, NationalityofMother = @NationalityofMother, EmploymentSector = @EmploymentSector, strNationalNumber = @strNationalNumber, FamilyBookNumber = @FamilyBookNumber, FamilyID = @FamilyID, CityNumber = @CityNumber, PUnifiedID = @PUnifiedID, EmployerName = @EmployerName, EmployerEmail = @EmployerEmail, EmployerPhone = @EmployerPhone, EmployerPosition = @EmployerPosition, EmployerIndustry = @EmployerIndustry, EmployerCompanyName = @EmployerCompanyName, EmployerCountry = @EmployerCountry, EmployerEmirate = @EmployerEmirate, iACMSCategory = @iACMSCategory, strStudentPic = @strStudentPic WHERE (lngSerial = @lngSerial)" 
                                InsertCommandType="StoredProcedure" oninserted="StudentDS_Inserted" 
                                
                                SelectCommand="SELECT Reg_Students_Data.lngSerial, Reg_Applications.lngStudentNumber, Reg_Students_Data.strLastDescEn, Reg_Students_Data.dateCreate FROM Reg_Applications RIGHT OUTER JOIN Reg_Students_Data ON Reg_Applications.lngSerial = Reg_Students_Data.lngSerial ORDER BY Reg_Students_Data.dateCreate DESC" 
                                
                                
                                
                                DeleteCommand="DELETE FROM Reg_Students_Data WHERE (lngSerial = @lngSerial)">
                                <DeleteParameters>
                                    <asp:ControlParameter ControlID="hdnSerial" DefaultValue="0" Name="lngSerial" 
                                        PropertyName="Value" />
                                </DeleteParameters>
                                <UpdateParameters>
                                    <asp:ControlParameter ControlID="txtFNameEn" DefaultValue="-" 
                                        Name="strFirstDescEn" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtLNameEn" DefaultValue="-" 
                                        Name="strSecondDescEn" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtNameEn" DefaultValue="-" 
                                        Name="strLastDescEn" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtFNameAr" DefaultValue="-" 
                                        Name="strFirstDescAr" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtLNameAr" DefaultValue="-" 
                                        Name="strSecondDescAr" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtNameAr" DefaultValue="-" 
                                        Name="strLastDescAr" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="rbnGender" DefaultValue="1" Name="bSex" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtBirthDate" DefaultValue="'1977-01-01'" Name="dateBirth" 
                                        PropertyName="Text" DbType="Date" />
                                    <asp:ControlParameter ControlID="ddlBirthCountry" DefaultValue="1" 
                                        Name="byteBirthCountry" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlBirthCity" DefaultValue="1" 
                                        Name="byteBirthCity" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlNationality" DefaultValue="1" 
                                        Name="byteNationality" PropertyName="SelectedValue" />
                                    <asp:Parameter DefaultValue="2" Name="byteIDType" />
                                    <asp:ControlParameter ControlID="txtIdentityNo" DefaultValue="0" Name="strID" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlResidentCountry" DefaultValue="1" 
                                        Name="byteHomeCountry" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlResidentCity" DefaultValue="1" 
                                        Name="byteHomeCity" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlHomeCountry" DefaultValue="1" 
                                        Name="byteOriginCountry" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlHomeCity" DefaultValue="1" 
                                        Name="byteOriginCity" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtPhone1" DefaultValue="-" Name="strPhone1" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtPhone2" DefaultValue="-" Name="strPhone2" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtEmail" DefaultValue="default@ectuae.com" 
                                        Name="strEmail" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtAddress" DefaultValue="-" Name="strAddress" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlSession" DefaultValue="1" Name="byteShift" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtIDNo" DefaultValue="0" Name="strNationalID" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlIWork" DefaultValue="0" Name="intWorkPlace" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtWorkPhone" DefaultValue="" 
                                        Name="strWorkPhone" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtJob" DefaultValue="-" Name="strJopTitle" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="drp_determination" DefaultValue="0" 
                                        Name="intDelegation" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlVisa" DefaultValue="0" Name="intSponsor" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtExpiry" DefaultValue="'1977-01-01'" 
                                        Name="dateEndSponsorship" PropertyName="Text" DbType="Date" />
                                    <asp:SessionParameter DefaultValue="-" Name="strUserSave" 
                                        SessionField="CurrentUserName" />
                                    <asp:ControlParameter ControlID="ddlLanguage" DefaultValue="1" 
                                        Name="byteReligion" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="rbnEmploymentStatus" DefaultValue="0" Name="isWorking" 
                                        PropertyName="SelectedValue" />
                                     <asp:ControlParameter ControlID="txtEthbara" DefaultValue="0" Name="EthbaraNo" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="rbnFitnessStatus" DefaultValue="1" Name="FitnessStatus" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlMaritalStatus" DefaultValue="0" Name="MaritalStatus" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlNationalityofMother" DefaultValue="1" Name="NationalityofMother" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlEmploymentSector" DefaultValue="0" Name="EmploymentSector" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="hdnSerial" DefaultValue="" Name="lngSerial" 
                                        PropertyName="Value" />
                                    <asp:ControlParameter ControlID="txtNationalNo" DefaultValue="NA" 
                                        Name="strNationalNumber" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtFamilyBookNo" DefaultValue="999999" 
                                        Name="FamilyBookNumber" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtFamilyNo" DefaultValue="999" 
                                        Name="FamilyID" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtCityNo" DefaultValue="999" 
                                        Name="CityNumber" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtUnifiedNo" DefaultValue="NA" 
                                        Name="PUnifiedID" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtEmployerName" DefaultValue="NA" 
                                        Name="EmployerName" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtEmployeremail" DefaultValue="xxyy@xyz.com" 
                                        Name="EmployerEmail" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtEmployerPhone" DefaultValue="9999999999" 
                                        Name="EmployerPhone" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtEmployerPos" DefaultValue="NA" 
                                        Name="EmployerPosition" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtEmployerIndustry" DefaultValue="NA" 
                                        Name="EmployerIndustry" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtCompany" DefaultValue="NA" 
                                        Name="EmployerCompanyName" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlEmployerCountry" DefaultValue="1" 
                                        Name="EmployerCountry" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlEmployerEmirate" DefaultValue="1" 
                                        Name="EmployerEmirate" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlAccess" DefaultValue="0" 
                                        Name="iACMSCategory" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="Pic" DefaultValue="" Name="strStudentPic" 
                                        PropertyName="Value" />
                                </UpdateParameters>
                                <InsertParameters>
                                    <asp:Parameter DefaultValue="" Direction="ReturnValue" 
                                        Name="RETURN_VALUE" Type="Int32" />
                                    <asp:ControlParameter ControlID="txtFNameEn" DefaultValue="-" 
                                        Name="strFirstDescEn" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtLNameEn" DefaultValue="-" 
                                        Name="strSecondDescEn" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtNameEn" DefaultValue="-" 
                                        Name="strLastDescEn" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtFNameAr" DefaultValue="-" 
                                        Name="strFirstDescAr" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtLNameAr" DefaultValue="-" 
                                        Name="strSecondDescAr" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtNameAr" DefaultValue="-" 
                                        Name="strLastDescAr" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="rbnGender" DefaultValue="1" Name="bSex" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtBirthDate" DefaultValue="getdate()" Name="dateBirth" 
                                        PropertyName="Text" DbType="Date" />
                                    <asp:ControlParameter ControlID="ddlBirthCountry" DefaultValue="1" 
                                        Name="byteBirthCountry" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlBirthCity" DefaultValue="1" 
                                        Name="byteBirthCity" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlNationality" DefaultValue="1" 
                                        Name="byteNationality" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlLanguage" DefaultValue="1" Name="byteReligion" 
                                        PropertyName="SelectedValue" />
                                    <asp:Parameter DefaultValue="2" Name="byteIDType" />
                                    <asp:ControlParameter ControlID="txtIdentityNo" DefaultValue="0" Name="strID" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlResidentCountry" DefaultValue="1" 
                                        Name="byteHomeCountry" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlResidentCity" DefaultValue="1" 
                                        Name="byteHomeCity" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlHomeCountry" DefaultValue="1" 
                                        Name="byteOriginCountry" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlHomeCity" DefaultValue="1" 
                                        Name="byteOriginCity" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtPhone1" DefaultValue="-" Name="strPhone1" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtPhone2" DefaultValue="-" Name="strPhone2" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtEmail" DefaultValue="default@ectuae.com" 
                                        Name="strEmail" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtAddress" DefaultValue="-" Name="strAddress" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlSession" DefaultValue="1" Name="byteShift" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtIDNo" DefaultValue="0" Name="strNationalID" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlIWork" DefaultValue="0" Name="intWorkPlace" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtWorkPhone" DefaultValue="" Name="strWorkPhone" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtJob" DefaultValue="-" Name="strJopTitle" 
                                        PropertyName="Text" />
                                     <asp:ControlParameter ControlID="rbnEmploymentStatus" DefaultValue="0" Name="isWorking" 
                                        PropertyName="SelectedValue" />
                                     <asp:ControlParameter ControlID="txtEthbara" DefaultValue="0" Name="EthbaraNo" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="rbnFitnessStatus" DefaultValue="1" Name="FitnessStatus" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlMaritalStatus" DefaultValue="0" Name="MaritalStatus" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlNationalityofMother" DefaultValue="1" Name="NationalityofMother" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlEmploymentSector" DefaultValue="0" Name="EmploymentSector" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="drp_determination" DefaultValue="0" Name="intDelegation" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlVisa" DefaultValue="0" Name="intSponsor" 
                                        PropertyName="SelectedValue" />

                                    <asp:ControlParameter ControlID="txtExpiry" DefaultValue="getdate()" Name="dateEndSponsorship" 
                                        PropertyName="Text" DbType="Date" />
                                    <asp:SessionParameter Name="strUserCreate" SessionField="CurrentUserName" />
                                    <asp:ControlParameter ControlID="txtNationalNo" DefaultValue="999999" 
                                        Name="NationalNumber" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="txtFamilyBookNo" DefaultValue="999999" 
                                        Name="FamilyBookNumber" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="txtFamilyNo" DefaultValue="999" 
                                        Name="FamilyID" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="txtCityNo" DefaultValue="999" 
                                        Name="CityNumber" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="txtUnifiedNo" DefaultValue="NA" 
                                        Name="PUnifiedID" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="txtEmployerName" DefaultValue="NA" 
                                        Name="EmployerName" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="txtEmployeremail" DefaultValue="xxyy@xyz.com" 
                                        Name="EmployerEmail" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="txtEmployerPhone" DefaultValue="9999999999" 
                                        Name="EmployerPhone" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="txtEmployerPos" DefaultValue="NA" 
                                        Name="EmployerPosition" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="txtEmployerIndustry" DefaultValue="NA" 
                                        Name="EmployerIndustry" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="txtCompany" DefaultValue="NA" 
                                        Name="EmployerCompanyName" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="ddlEmployerCountry" DefaultValue="1" 
                                        Name="EmployerCountry" PropertyName="SelectedValue" Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlEmployerEmirate" DefaultValue="1" 
                                        Name="EmployerEmirate" PropertyName="SelectedValue" Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlAccess" DefaultValue="0" 
                                        Name="iACMSCategory" PropertyName="SelectedValue" Type="Int32" />
                                    <asp:ControlParameter ControlID="Pic" DefaultValue="" Name="strStudentPic" 
                                        PropertyName="Value" Type="String" />
                                </InsertParameters>
                            </asp:SqlDataSource>

                            <asp:SqlDataSource ID="EnrollmentDS" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ECTDataMales %>" 
                                InsertCommand="INSERT INTO Reg_Applications(intStudyYear, byteSemester, strApplicationNumber, lngStudentNumber, dateApplication, lngSerial, strCollege, strDegree, strSpecialization, bAccepted, dateAccepted, strNotes, bActive, bContinue, bOtherCollege, intAdvisor, byteStudentType, IsCompleteBAFromOtherInstitution, IsCompleteMasterFromOtherInstitution, strUserCreate, dateCreate, strNUser, sReference, intRemind, WantedMajorID, sReferredBy, iEnrollmentSource, sEnrollmentNotes, iRegisteredThrough, sECTId, iEnrollmentSource2, WantedMajorID2, WantedMajorID3, byteLastDegreeInistitution, byteLastDegreeCountry, curLastCGPA, intLastDegreeYear, sLastDegree, LHEEquivalencyIndicator, LHEEquivalencyAppNo, Std_ORCID, isMilitaryService, dateMilitaryService, iContactID, iOpportunityID, iAcceptanceType, iAcceptanceCondition, iAdmissionStatus) VALUES (@intStudyYear, @byteSemester, @lngStudentNumber, @lngStudentNumber, GETDATE(), @lngSerial, @strCollege, @strDegree, @strSpecialization, 1, GETDATE(), @strNotes, @bActive, @bContinue, 0, @intAdvisor, @byteStudentType, @IsCompleteBAFromOtherInstitution, @IsCompleteMasterFromOtherInstitution, @strUserCreate, GETDATE(), @strUserCreate, @sReference, @intRemind, @WMajor, @sReferredBy, @iEnrollmentSource, @sEnrollmentNotes, @iRegisteredThrough, @sECTId, @iEnrollmentSource2, @WMajor2, @WMajor3, @byteLastDegreeInistitution, @byteLastDegreeCountry, @curLastCGPA, @intLastDegreeYear, @sLastDegree, @LHEEquivalencyIndicator, @LHEEquivalencyAppNo, @Std_ORCID, @isMilitaryService, @dateMilitaryService, @iContactID, @iOpportunityID, @iAcceptanceType, @iAcceptanceCondition, @iAdmissionStatus)" 
                                ProviderName="<%$ ConnectionStrings:ECTDataMales.ProviderName %>" 
                                
                                UpdateCommand="UPDATE Reg_Applications SET strNotes = @strNotes, intAdvisor = @intAdvisor, IsCompleteBAFromOtherInstitution = @IsCompleteBAFromOtherInstitution, IsCompleteMasterFromOtherInstitution = @IsCompleteMasterFromOtherInstitution, iEnrollmentSource = @iEnrollmentSource, sEnrollmentNotes = @sEnrollmentNotes, iRegisteredThrough = @iRegisteredThrough, strUserSave = @strUserSave, dateLastSave = GETDATE(), strNUser = @strUserSave, bActive = @bActive, bContinue = @bContinue, WantedMajorID = @WMajor, sReferredBy = @sReferredBy, iEnrollmentSource2 = @iEnrollmentSource2, WantedMajorID2 = @WMajor2, WantedMajorID3 = @WMajor3, byteLastDegreeInistitution = @byteLastDegreeInistitution, byteLastDegreeCountry = @byteLastDegreeCountry, curLastCGPA = @curLastCGPA, intLastDegreeYear = @intLastDegreeYear, sLastDegree = @sLastDegree, LHEEquivalencyIndicator = @LHEEquivalencyIndicator, LHEEquivalencyAppNo = @LHEEquivalencyAppNo, Std_ORCID = @Std_ORCID, isMilitaryService = @isMilitaryService, dateMilitaryService = @dateMilitaryService, iContactID = @iContactID, iOpportunityID = @iOpportunityID, iAcceptanceType = @iAcceptanceType, iAcceptanceCondition = @iAcceptanceCondition, iAdmissionStatus = @iAdmissionStatus WHERE (lngStudentNumber = @lngStudentNumber) AND (lngSerial = @lngSerial)" 
                                
                                
                                
                                DeleteCommand="DELETE FROM Reg_Applications WHERE (lngSerial = @lngSerial)">
                                <DeleteParameters>
                                    <asp:ControlParameter ControlID="hdnSerial" DefaultValue="0" Name="lngSerial" 
                                        PropertyName="Value" />
                                </DeleteParameters>
                                <UpdateParameters>
                                    <asp:ControlParameter ControlID="ddlAdvisor" DefaultValue="1000" 
                                        Name="intAdvisor" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtNote" Name="strNotes" PropertyName="Text" />
                                    <asp:SessionParameter DefaultValue="-" Name="strUserSave" 
                                        SessionField="CurrentUserName" />
                                    <asp:ControlParameter ControlID="lblStudentId" DefaultValue="-" 
                                        Name="lngStudentNumber" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="hdnSerial" DefaultValue="0" Name="lngSerial" 
                                        PropertyName="Value" />
                                    <asp:ControlParameter ControlID="chkActive" DefaultValue="1" Name="bActive" 
                                        PropertyName="Checked" />
                                    <asp:ControlParameter ControlID="chkMissing" DefaultValue="0" Name="bContinue" 
                                        PropertyName="Checked" />
                                    <asp:ControlParameter ControlID="ddlWMajor1" DefaultValue="0" Name="WMajor" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtReferredBy" DefaultValue="-" 
                                        Name="sReferredBy" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="chkCompleteBAFromOtherInstitution" DefaultValue="1" Name="IsCompleteBAFromOtherInstitution" 
                                        PropertyName="Checked" />
                                    <asp:ControlParameter ControlID="chkCompleteMasterFromOtherInstitution" DefaultValue="1" Name="IsCompleteMasterFromOtherInstitution" 
                                        PropertyName="Checked" />
                                     <asp:ControlParameter ControlID="ddlEnrollmentSource" DefaultValue="-1" 
                                        Name="iEnrollmentSource" PropertyName="SelectedValue" />
                                      <asp:ControlParameter ControlID="txtEnrollmentSource" DefaultValue="-" 
                                        Name="sEnrollmentNotes" PropertyName="Text" />  
                                        <asp:ControlParameter ControlID="ddlRegisteredThrough" DefaultValue="-1" 
                                        Name="iRegisteredThrough" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlEnrollmentSource2" DefaultValue="0" 
                                        Name="iEnrollmentSource2" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlWMajor2" DefaultValue="0" Name="WMajor2" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlWMajor3" DefaultValue="0" Name="WMajor3" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlLastInistitution" DefaultValue="-1" 
                                        Name="byteLastDegreeInistitution" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlLastCountry" DefaultValue="1" 
                                        Name="byteLastDegreeCountry" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtLastCGPA" DefaultValue="0" 
                                        Name="curLastCGPA" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtLastYear" DefaultValue="999999" 
                                        Name="intLastDegreeYear" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlLastDegree" DefaultValue="0" 
                                        Name="sLastDegree" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlLHEquivalencyIndicator" DefaultValue="0" 
                                        Name="LHEEquivalencyIndicator" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtLHEquivalencyAppNo" DefaultValue="NA" 
                                        Name="LHEEquivalencyAppNo" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtORCID" DefaultValue="NA" Name="Std_ORCID" 
                                        PropertyName="Text" />
                                     <asp:ControlParameter ControlID="ChkIsMilitaryService" DefaultValue="1" Name="isMilitaryService" 
                                        PropertyName="Checked" />
                                    <asp:ControlParameter ControlID="txtMilitaryServiceDate" DefaultValue="'1977-01-01'" 
                                        Name="dateMilitaryService" PropertyName="Text" DbType="Date"/>
                                    <asp:ControlParameter ControlID="txtContactID" DefaultValue="0" 
                                        Name="iContactID" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtOpportunityID" DefaultValue="0" 
                                        Name="iOpportunityID" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlAcceptance" DefaultValue="1" 
                                        Name="iAcceptanceType" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlAcceptanceCondition" DefaultValue="1" 
                                        Name="iAcceptanceCondition" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlAdmissionStatus" DefaultValue="1" 
                                        Name="iAdmissionStatus" PropertyName="SelectedValue" />
                                </UpdateParameters>
                                <InsertParameters>
                                    <asp:Parameter DefaultValue="0" Name="intStudyYear" />
                                    <asp:Parameter DefaultValue="0" Name="byteSemester" />
                                    <asp:Parameter Name="strCollege" DefaultValue="1" />
                                    <asp:Parameter Name="strDegree" DefaultValue="1" />
                                    <asp:Parameter Name="strSpecialization" DefaultValue="20" />
                                    <asp:Parameter Name="intRemind" DefaultValue="80" />
                                    <asp:ControlParameter ControlID="lblStudentId" DefaultValue="-" 
                                        Name="lngStudentNumber" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="hdnSerial" DefaultValue="0" Name="lngSerial" 
                                        PropertyName="Value" />
                                    <asp:ControlParameter ControlID="txtNote" DefaultValue="-" Name="strNotes" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlType" DefaultValue="0" 
                                        Name="byteStudentType" PropertyName="SelectedValue" />
                                    <asp:SessionParameter DefaultValue="-" Name="strUserCreate" 
                                        SessionField="CurrentUserName" />
                                    <asp:ControlParameter ControlID="lblReference" DefaultValue="" 
                                        Name="sReference" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlAdvisor" DefaultValue="1000" 
                                        Name="intAdvisor" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="chkActive" DefaultValue="1" Name="bActive" 
                                        PropertyName="Checked" />
                                    <asp:ControlParameter ControlID="chkMissing" DefaultValue="0" Name="bContinue" 
                                        PropertyName="Checked" />
                                    <asp:ControlParameter ControlID="ddlWMajor1" DefaultValue="0" Name="WMajor" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtReferredBy" DefaultValue="-" 
                                        Name="sReferredBy" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="chkCompleteBAFromOtherInstitution" DefaultValue="1" Name="IsCompleteBAFromOtherInstitution" 
                                        PropertyName="Checked" />
                                    <asp:ControlParameter ControlID="chkCompleteMasterFromOtherInstitution" DefaultValue="1" Name="IsCompleteMasterFromOtherInstitution" 
                                        PropertyName="Checked" />
                                    <asp:ControlParameter ControlID="ddlEnrollmentSource" DefaultValue="0" 
                                        Name="iEnrollmentSource" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtEnrollmentSource" DefaultValue="-" 
                                        Name="sEnrollmentNotes" PropertyName="Text" />  
                                         <asp:ControlParameter ControlID="ddlRegisteredThrough" DefaultValue="0" 
                                        Name="iRegisteredThrough" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="lblECTId" DefaultValue="0" Name="sECTId" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlEnrollmentSource2" DefaultValue="0" 
                                        Name="iEnrollmentSource2" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlWMajor2" DefaultValue="0" Name="WMajor2" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlWMajor3" DefaultValue="0" Name="WMajor3" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlLastInistitution" DefaultValue="-1" 
                                        Name="byteLastDegreeInistitution" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlLastCountry" DefaultValue="1" 
                                        Name="byteLastDegreeCountry" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtLastCGPA" DefaultValue="0" 
                                        Name="curLastCGPA" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtLastYear" DefaultValue="999999" 
                                        Name="intLastDegreeYear" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlLastDegree" DefaultValue="0" 
                                        Name="sLastDegree" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlLHEquivalencyIndicator" DefaultValue="M" 
                                        Name="LHEEquivalencyIndicator" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="txtLHEquivalencyAppNo" DefaultValue="NA" 
                                        Name="LHEEquivalencyAppNo" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtORCID" DefaultValue="NA" Name="Std_ORCID" 
                                        PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ChkIsMilitaryService" DefaultValue="1" Name="isMilitaryService" 
                                        PropertyName="Checked" />
                                    <asp:ControlParameter ControlID="txtMilitaryServiceDate" DefaultValue="getdate()" 
                                        Name="dateMilitaryService" PropertyName="Text" DbType="Date"/>
                                    <asp:ControlParameter ControlID="txtContactID" DefaultValue="0" 
                                        Name="iContactID" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtOpportunityID" DefaultValue="0" 
                                        Name="iOpportunityID" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="ddlAcceptance" DefaultValue="1" 
                                        Name="iAcceptanceType" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlAcceptanceCondition" DefaultValue="1" 
                                        Name="iAcceptanceCondition" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlAdmissionStatus" DefaultValue="1" 
                                        Name="iAdmissionStatus" PropertyName="SelectedValue" />
                                </InsertParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SidDS" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ECTDataFemales %>" 
                                onselected="SidDS_Selected" 
                                ProviderName="<%$ ConnectionStrings:ECTDataFemales.ProviderName %>" 
                                SelectCommand="GetNew_StId" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="String" />
                                    <asp:Parameter DefaultValue="0" Name="iType" Type="Int32" />
                                    <asp:Parameter DefaultValue="2019" Name="iYear" Type="Int32" />
                                    <asp:Parameter DefaultValue="2" Name="iSem" Type="Int32" />
                                    <asp:Parameter DefaultValue="1" Name="iCampus" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>


<%--    <script type="text/javascript">
        function DeleteConfirm() {
            var b = confirm('Are you sure want to delete this ?');
            return b;
        }
    </script>--%> 
    <style>
        table{
            width:100%;
        }
    </style>
    </asp:Content>