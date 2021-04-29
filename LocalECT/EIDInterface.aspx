<%@ Page Language="C#" AutoEventWireup="true" Inherits="ZFDemoSite.Default_activex" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    //InitializeModule.EnumCampus Campus=InitializeModule.EnumCampus.Females;
    int CurrentRole = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CurrentRole"] != null)
        {
            CurrentRole = (int)Session["CurrentRole"];
        }



        string CallerID = Request.QueryString["CallerID"].ToString();
        hdnCallerID.Value = CallerID;
        if (CallerID == "STD")
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                   InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
            {
                Server.Transfer("Authorization.aspx");
            }

            if (Session["StudentSerialNo"] != null)
            {
                hdnID.Value = Session["StudentSerialNo"].ToString();
            }
        }
        else//EMP
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Active_Employees,
                   InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
            {
                Server.Transfer("Authorization.aspx");
            }

            if (Session["EMPID"] != null)
            {
                hdnID.Value = Session["EMPID"].ToString();
            }
        }


    }
    protected void btnRead_Click(object sender, EventArgs e)
    {
        try
        {
            FillEID();
            btnUpdate.Enabled = true;
        }
        catch (Exception ex)
        {
            btnUpdate.Enabled = false;
            Console.WriteLine(ex.Message);
        }
        finally
        {

        }
        //txtFullNameAr.Text = hdnef_idn_cn.Value;
    }

    private void FillEID()
    {

        //--------------------------------------Emirates ID Reader
        string ef_idn_cn = hdnef_idn_cn.Value;
        string ef_non_mod_data = hdnef_non_mod_data.Value;
        string ef_mod_data = hdnef_mod_data.Value;
        string ef_sign_image = hdnef_sign_image.Value;
        string ef_photo = hdnef_photo.Value;
        string ef_root_cert = hdnef_root_cert.Value;
        string ef_home_address = hdnef_home_address.Value;
        string ef_work_address = hdnef_work_address.Value;

        string certsPath = Request.MapPath("~/data_signing_certs");

        bool nonMod = false;
        bool mod = false;
        bool signImage = false;
        bool photo = false;
        bool homeAddress = false;
        bool workAddress = false;
        EmiratesId.AE.PublicData.PublicDataParser parser = null;
        //End ---------------------------------Emirates ID Reader

        //--------------------------------------Emirates ID Reader
        parser = new EmiratesId.AE.PublicData.PublicDataParser(ef_idn_cn, certsPath);
        nonMod = parser.parseNonModifiableData(ef_non_mod_data);
        mod = parser.parseModifiableData(ef_mod_data);
        photo = parser.parsePhotography(ef_photo);
        signImage = parser.parseSignatureImage(ef_sign_image);
        homeAddress = parser.parseHomeAddressData(ef_home_address);
        workAddress = parser.parseWorkAddressData(ef_work_address);
        parser.parseRootCertificate(ef_root_cert);
        //--------------------------------------Emirates ID Reader

        //Fill Data--------------------------------------Emirates ID Reader
        //NonMod.Text = nonMod.ToString();
        //Mod.Text = mod.ToString();
        //SignImage.Text = "".Equals(ef_sign_image) ? "N/A" : signImage.ToString();
        //Photo.Text = "".Equals(ef_photo) ? "N/A" : photo.ToString();
        //HomeAddress.Text = "".Equals(ef_home_address) ? "N/A" : homeAddress.ToString();
        //WorkAddress.Text = "".Equals(ef_work_address) ? "N/A" : workAddress.ToString();

        string sFullNameEn = parser.getFullName();
        string sFullNameAr = parser.getArabicFullName();

        txtEID.Text = parser.getIdNumber();
        Session["EIDID"] = txtEID.Text;

        string Sex = parser.getSex();
        if (Sex == "M")
        { rbnGender.SelectedValue = "1"; }
        else
        { rbnGender.SelectedValue = "0"; }

        Session["EIDGender"] = rbnGender.SelectedValue;

        string sDate = "";
        sDate = parser.getDateOfBirth() == null ? "" : parser.getDateOfBirth().Value.ToString("yyyy-MM-dd");
        txtBirthDate.Text = sDate;
        Session["EIDBirthDate"] = txtBirthDate.Text;


        //sDate = string.Format("{0:yyyy-MM-dd}", myStudent[0].dateBirth);

        string[] aEnNameParts = new string[5];
        aEnNameParts = sFullNameEn.Split(',');

        txtFirstNameEn.Text = aEnNameParts[0];
        txtLastNameEn.Text = aEnNameParts[4];
        txtFullNameEn.Text = aEnNameParts[0] + ' ' + aEnNameParts[1] + ' ' + aEnNameParts[2] + ' ' + aEnNameParts[4];
        Session["EIDFirstNameEn"] = txtFirstNameEn.Text;
        Session["EIDLastNameEn"] = txtLastNameEn.Text;
        Session["EIDFullNameEn"] = txtFullNameEn.Text;
        //===================================
        string[] aArNameParts = new string[5];
        aArNameParts = sFullNameAr.Split(',');

        txtFirstNameAr.Text = aArNameParts[0];
        txtLastNameAr.Text = aArNameParts[4];
        txtFullNameAr.Text = aArNameParts[0] + ' ' + aArNameParts[1] + ' ' + aArNameParts[2] + ' ' + aArNameParts[4];
        Session["EIDFirstNameAr"] = txtFirstNameAr.Text;
        Session["EIDLastNameAr"] = txtLastNameAr.Text;
        Session["EIDFullNameAr"] = txtFullNameAr.Text;

        txtPhone.Text = parser.getHomeAddressMobilePhoneNo() == null ? "" : parser.getHomeAddressMobilePhoneNo();
        Session["EIDPhone"] = txtPhone.Text;


        txtAddress.Text = parser.getHomeAddressEmirateCode() == null ? "" : parser.getHomeAddressEmirateCode().ToString();
        txtAddress.Text += " /" + parser.getHomeAddressCityDesc() == null ? "" : parser.getHomeAddressCityDesc().ToString();
        txtAddress.Text += " /Po.Box: " + parser.getHomeAddressPOBox() == null ? "" : parser.getHomeAddressPOBox().ToString();

        Session["EIDAddress"] = txtAddress.Text;

        sDate = parser.getResidencyExpiryDate() == null ? "" : parser.getResidencyExpiryDate().Value.ToString("yyyy-MM-dd");
        if (sDate == "")
        {
            sDate=string.Format("yyyy-MM-dd", DateTime.Today.Date);
        }
        txtExpiry.Text = sDate;
        Session["EIDExpiry"] = txtExpiry.Text;

        txtIdentityNo.Text = parser.getPassportNumber() == null ? "" : parser.getPassportNumber();
        Session["EIDPassport"] = txtIdentityNo.Text;
        string sCompanyName = parser.getCompanyName() == null ? "" : parser.getCompanyName();
        Session["EIDWorkingPlace"] = sCompanyName;

        string sJob = parser.getOccupation() == null ? "" : parser.getOccupation().ToString();
        txtJob.Text = sJob;
        Session["EIDJob"] = txtJob.Text;



        if (sCompanyName == "")
        {
            rbnIsWorking.SelectedValue = (0).ToString();

        }
        else
        {
            rbnIsWorking.SelectedValue = (1).ToString();
            txtWork.Text = sCompanyName;
        }

        switch (parser.getMaritalStatus() == null ? "01" : parser.getMaritalStatus())
        {
            case "02":
                rbnMarital.SelectedValue = "1";// Married 
                break;
            default:
                rbnMarital.SelectedValue = "0";// 
                break;

        }
        Session["EIDMarital"] = rbnMarital.SelectedValue;

        int iCampus = Convert.ToInt32(Session["CurrentCampus"]);
        txtNationality.Text = parser.getNationality() == null ? "" : parser.getNationality().ToString();
        Session["EIDNationality"] = txtNationality.Text;

        //New added
        txtFamilyNo.Text = parser.getFamilyID() == null ? "" : parser.getFamilyID().ToString();
        Session["EIDFamilyID"] = txtFamilyNo.Text;
        txtWorkField.Text= parser.getOccupationField() == null ? "" : parser.getOccupationField().ToString();
        Session["EIDWorkField"] = txtWorkField.Text;



        //ddlNationality.SelectedValue = GetNationalityID_ByCountryCode3(iCampus, txtNationality.Text).ToString();

        //parser.getHomeAddressCityDesc ()
        //parser.getHomeAddressEmirateCode ()
        //parser.getPassportCountry ()
        //parser.getPassportCountryDesc ()
        //parser.getPassportExpiryDate ()
        //parser.getPassportIssueDate ()
        //parser.getPassportType ()
        //parser.getPlaceOfBirth ()
        //parser.getQualificationLevel()
        //parser.getQualificationLevelDesc()

        //SponsorName.Text = parser.getSponsorName();

        //txtMotherName.Text = parser.getMotherFullName() == null ? "" : parser.getMotherFullName();
        //CardNumber.Text = parser.getCardNumber();

        //Nationality_ar.Text = parser.getArabicNationality();

        //Title.Text = parser.getTitle();

        //IssueDate.Text = parser.getIssueDate().Value.ToString("dd/MM/yyyy");
        //ExpiryDate.Text = parser.getExpiryDate().Value.ToString("dd/MM/yyyy");

        //IdType.Text = parser.getIdType();
        //Occupation.Text = parser.getOccupation() == null ? "" : parser.getOccupation();
        //OccupationField.Text = parser.getOccupationField() == null ? "" : parser.getOccupationField();
        //Title_ar.Text = parser.getArabicTitle();

        //MotherName_ar.Text = parser.getMotherFullName_ar() == null ? "" : parser.getMotherFullName_ar();
        //FamilyId.Text = parser.getFamilyID();
        //HusbandIDN.Text = parser.getHusbandIDN();
        //SponsorType.Text = parser.getSponsorType();

        //SponsorUnifiedNumber.Text = parser.getSponsorUnifiedNumber();
        //ResidencyType.Text = parser.getResidencyType();
        //ResidencyNumber.Text = parser.getResidencyNumber();
        //ResidencyExpiryDate.Text = parser.getResidencyExpiryDate() == null ? "" : parser.getResidencyExpiryDate().Value.ToString("dd/MM/yyyy");

        //PhotoBase64.Src
        string sUrl=CreateImage(Convert.ToBase64String(parser.getPhotography()),"PIC"+ txtEID.Text);
        Img.ImageUrl = sUrl;
        Img.DataBind();
        Session["EIDImgUrl"] = sUrl;
        //if (parser.getPhotography() != null)
        //    Img.p = "data:image/jpeg;base64," + Convert.ToBase64String(parser.getPhotography());
        //if (parser.getHolderSignatureImage() != null)
        //    SignaturePhotoBase64.Src = "data:image/tiff;base64," + Convert.ToBase64String(parser.getHolderSignatureImage());
        //Fill Data--------------------------------------Emirates ID Reader
    }

    private string CreateImage(string base64String,string sPic)
    {
        string sURL = "";

        //***Save Base64 Encoded string as Image File***//

        //Convert Base64 Encoded string to Byte Array.
        byte[] imageBytes = Convert.FromBase64String(base64String);

        //Save the Byte Array as Image File.
        string filePath = "";
        if (hdnCallerID.Value == "STD")
        {
            filePath = Server.MapPath("~/Images/Students/" + sPic + ".jpeg");
            sURL = "~/Images/Students/" + sPic + ".jpeg";
        }
        else
        {
            filePath = Server.MapPath("~/Images/Employees/" + sPic + ".jpeg");
            sURL = "~/Images/Employees/" + sPic + ".jpeg";
        }
        System.IO.File.WriteAllBytes(filePath, imageBytes);



        return sURL;
    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //Defaults
        Session["EIDsID"] = hdnID.Value;
        Session["CallerID"] = hdnCallerID.Value;

        //Session["EIDID"] = txtEID.Text;
        //Session["EIDGender"] = rbnGender.SelectedValue;
        //Session["EIDBirthDate"] = txtBirthDate.Text;
        //Session["EIDMarital"] = rbnMarital.SelectedValue;
        //Session["EIDExpiry"] = txtExpiry.Text;
        if (!CheckBox1.Checked)
        {
            Session["EIDFirstNameAr"] = null;
        }
        if (!CheckBox2.Checked)
        {
            Session["EIDLastNameAr"] = null;
        }
        if (!CheckBox3.Checked)
        {
            Session["EIDFullNameAr"] = null;
        }

        if (!CheckBox4.Checked)
        {
            Session["EIDFirstNameEn"] = null;
        }
        if (!CheckBox5.Checked)
        {
            Session["EIDLastNameEn"] = null;
        }
        if (!CheckBox6.Checked)
        {
            Session["EIDFullNameEn"] = null;
        }

        if (!CheckBox11.Checked)
        {
            Session["EIDNationality"] = null;
        }

        if (!CheckBox14.Checked)
        {
            Session["EIDPassport"] = null;
        }
        if (!CheckBox15.Checked)
        {
            Session["EIDWorkingPlace"] = null;
        }
        if (!CheckBox16.Checked)
        {
            Session["EIDJob"] = null;
        }
        if (!CheckBox17.Checked)
        {
            Session["EIDPhone"] = null;
        }
        if (!CheckBox18.Checked)
        {
            Session["EIDAddress"] = null;
        }
        if (!CheckBox19.Checked)
        {
            Session["EIDImgUrl"] = null;
        }

        if (!CheckBox20.Checked)
        {
            Session["EIDWorkField"] = null;
        }

        if (!CheckBox21.Checked)
        {
            Session["EIDFamilyID"] = null;
        }



        switch(hdnCallerID.Value )
        {
            case "STD":
                Response.Redirect("Student_Profile.aspx?sid="+ Request.QueryString["sid"] + "&isr=" + Request.QueryString["isr"] + "");
                break;
            case "EMP":

                Response.Redirect("ActiveEmployees.aspx");
                break;

        }
    }

    protected void lnk_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Student_Profile.aspx?sid="+ Request.QueryString["sid"] + "&isr=" + Request.QueryString["isr"] + "");
    }
</script>


   <html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>EID Reader</title>
    <link rel="shortcut icon" href="images/favicon32.png" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
     <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <%--<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/top_menu.css" rel="stylesheet" type="text/css" />
<link href="css/jquery-ui-1.9.0.css" rel="stylesheet" type="text/css" />--%>

<link href="StyleSheet.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="js/base64.js"></script>
<script type="text/javascript" language="javascript" src="js/jquery-1.8.2.js"></script>
<script type="text/javascript" language="javascript" src="js/errors.js"></script>
<script type="text/javascript" language="javascript" src="js/zfcomponent.js"></script>
<script type="text/javascript" language="javascript" src="js/jquery-ui-1.9.0.js"></script>

<script type="text/javascript">
    function doReadPublicData() {
        var Ret = Initialize();
        if (Ret == false)
            return;

        Ret = ReadPublicData(true, true, true, true, true, true);
        if (Ret == false)
            return;

        $("#ef_idn_cn").val(GetEF_IDN_CN());
        document.getElementById("hdnef_idn_cn").value = document.getElementById("ef_idn_cn").value
        $("#ef_non_mod_data").val(GetEF_NonModifiableData());
        document.getElementById("hdnef_non_mod_data").value = document.getElementById("ef_non_mod_data").value
        $("#ef_mod_data").val(GetEF_ModifiableData());
        document.getElementById("hdnef_mod_data").value = document.getElementById("ef_mod_data").value
        $("#ef_sign_image").val(GetEF_HolderSignatureImage());
        document.getElementById("hdnef_sign_image").value = document.getElementById("ef_sign_image").value
        $("#ef_photo").val(GetEF_Photography());
        document.getElementById("hdnef_photo").value = document.getElementById("ef_photo").value
        $("#ef_root_cert").val(GetEF_RootCertificate());
        document.getElementById("hdnef_root_cert").value = document.getElementById("ef_root_cert").value
        $("#ef_home_address").val(GetEF_HomeAddressData());
        document.getElementById("hdnef_home_address").value = document.getElementById("ef_home_address").value
        $("#ef_work_address").val(GetEF_WorkAddressData());
        document.getElementById("hdnef_work_address").value = document.getElementById("ef_work_address").value

        //        $("#btnUpdate").removeAttr("disabled");
        $("#msg p:last").html("Public data read successfully");
        $("#msg").show("fade", {}, 500);
    }
    function doReadPublicDataEx() {
        var Ret = Initialize();
        if (Ret == false)
            return;

        Ret = ReadPublicDataEx(true, true, true, true, true, true);
        if (Ret == false)
            return;

        $("#ef_idn_cn").val(GetEF_IDN_CN());
        $("#ef_non_mod_data").val(GetEF_NonModifiableData());
        $("#ef_mod_data").val(GetEF_ModifiableData());
        $("#ef_sign_image").val(GetEF_HolderSignatureImage());
        $("#ef_photo").val(GetEF_Photography());
        $("#ef_root_cert").val(GetEF_RootCertificate());
        $("#ef_home_address").val(GetEF_HomeAddressData());
        $("#ef_work_address").val(GetEF_WorkAddressData());

        $("#btnVerifyPubData").removeAttr("disabled");
        $("#msg p:last").html("Public data read successfully");
        $("#msg").show("fade", {}, 500);
    }
    function doSignData() {
        var Ret = Initialize();
        if (Ret == false)
            return;

        var pin = $("#txtPin").val();
        var data = $("#txtSignData").val();

        if (pin == null || pin == "" || pin.length != 4) {
            alert("Empty or invalid PIN size!");
            return;
        }

        if (data == null || data == "") {
            alert("Data field is empty!");
            return;
        }

        data = window.btoa(data);

        Ret = SignData(pin, data);
        if (Ret == "")
            return;

        $("#certificate").val(ExportSignCertificate());
        $("#signature").val(Ret);
        $("#btnVerifySignature").removeAttr("disabled");

        $("#btnVerifyPubData").removeAttr("disabled");
        $("#msg p:last").html("Data Signed successfully");
        $("#msg").show("fade", {}, 500);
    }

    function doSignChallenge() {
        var Ret = Initialize();
        if (Ret == false)
            return;

        var pin = $("#txtPin").val();
        if (pin == null || pin == "" || pin.length != 4) {
            alert("Empty or invalid PIN size!");
            return;
        }


        var challenge = "";
        $.ajax({
            url: "GenerateChallenge.aspx",
            type: "POST",
            async: false,
            dataType: 'text',
            context: document.body,
            success: function (data) {
                challenge = data;
            }
        });

        Ret = SignChallenge(pin, challenge);
        if (Ret == "")
            return;

        $("#certificate").val(ExportAuthCertificate());
        $("#signature").val(Ret);
        $("#btnVerifySignature").removeAttr("disabled");

        $("#msg p:last").html("Server Challenge Signed successfully");
        $("#msg").show("fade", {}, 500);
    }

    function verifySignature() {
        $("#form1").attr("action", "VerifySignature");
        $('#form1').submit();
    }

    function onSignChange(rd) {
        if (rd.value == "Auth")
            $("#TR_Data").hide();
        else
            $("#TR_Data").show();
    }

    function doSign() {
        if ($("#rdSign").is(':checked'))
            doSignData();
        else
            doSignChallenge();
    }
</script>
</head>
<body>
      <style>
            .fusion-secondary-header {
    background-image: linear-gradient(to right, #051937, #052045, #062754, #082e63, #0c3573);
    font-size: 14px;
    color: #ffffff;
    height:25px;
}
            .btn1{
                background: #ffc315 !important;
    color: #042e6a !important;
    font-family: Cairo !important;
    font-weight: 600 !important;
    font-style: normal !important;
    letter-spacing: 0px !important; 
    border-width: 0px !important;
    border-style: solid !important;
    border-radius: 2px !important;
    text-transform: none !important;
    transition: all .2s !important;
    width: 100px !important;
    border-color: #042e6a !important;
    padding: 9px 20px;
    line-height: 14px;
    font-size: 12px;
    display: inline-block;
    position: relative;
    zoom: 1;
    border: 1px solid transparent;
    text-align: center;
    
    text-decoration: none;
    
    cursor: pointer;
    box-sizing: border-box;
    
}
            .pull-right {
    float: right;
}
            .pull-left {
    float: left;
}
            .footer {
   /* background: #fff;*/
    
    display: block;
    padding-left:10px;
    padding-right:10px;
    padding-bottom:10px;
}
            span{
                color:#042e6a;
            }
            .btn-success{
                background: #3f658c !important;
    border: 1px solid #3f658c !important;
            }
            
        </style>
     <div class="clearfix"></div>
    <div class="row">
    
    <div class="col-md-12 col-sm-12">
 
    <div class="content">
      
    <form id="form1" runat="server">

        
        <div class="fusion-secondary-header">

        </div>

    <div class="col-md-12 col-sm-12">
        <table width="100%">
            <tr>
                <td align="left">
                    <asp:Image ID="imgEct" runat="server" 
                        ImageUrl="https://ect.ac.ae/wp-content/uploads/2020/04/resolution-logo-ect-60-1.png"  />
                </td>                
                <td align="right">
                    <asp:Image ID="imgEid" runat="server" 
                        ImageUrl="https://smartservices.ica.gov.ae/echannels/web/client/images/ica/icalogo.png" Width="415px" Height="99px"/>
                </td>
            </tr>
        </table>
        <hr />
    </div>
    <div id="divMsg" runat="server"></div>

    <% if (Request.UserAgent.Contains("x64") && Request.UserAgent.Contains("MSIE")) {%>
        <object id="ZFComponent" width="0" height="0"
          classid="CLSID:502A94C0-E6CB-4910-846D-6F4F261E98C0"
          codebase="EIDA_ZF_ActiveX64.CAB">
          <strong style="color: red;display:flex;justify-content:center;">ActiveX is not supported by this browser, please use Internet Explorer</strong>
        </object>
    <%} else { %>
        <object id="ZFComponent" width="0" height="0"
          classid="CLSID:502A94C0-E6CB-4910-846D-6F4F261E98C0"
          codebase="EIDA_ZF_ActiveX.CAB">
          <strong style="color: red;display:flex;justify-content:center;">ActiveX is not supported by this browser, please use Internet Explorer</strong>
        </object>
    <%} %>
    <div>
        <input type="hidden" id="ef_idn_cn" name="ef_idn_cn" value=""  />
        <input type="hidden" id="ef_non_mod_data" name="ef_non_mod_data" value="" />
        <input type="hidden" id="ef_mod_data" name="ef_mod_data" value="" />
        <input type="hidden" id="ef_photo" name="ef_photo" value="" />
        <input type="hidden" id="ef_sign_image" name="ef_sign_image" value="" />
        <input type="hidden" id="ef_work_address" name="ef_work_address" value="" />
        <input type="hidden" id="ef_home_address" name="ef_home_address" value="" />
        <input type="hidden" id="ef_root_cert" name="ef_root_cert" value="" />
        <input type="hidden" id="certificate" name="certificate" value="" />
        <input type="hidden" id="signature" name="signature" value="" />
         <link href="gentelella-master/vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="gentelella-master/vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
        
     
           
             <div class="col-md-12 col-sm-12">
                 <div style="text-align:center">
   <asp:Button ID="btnRead" runat="server" onclick="btnRead_Click" 
                        onclientclick="doReadPublicData()" Text="Read EID"  CssClass="btn1" ToolTip="Click to Read Emirates ID"/>

                     <asp:LinkButton ID="lnk_Back" runat="server" OnClick="lnk_Back_Click" CssClass="btn btn-success btn-sm" style="float:right"><i class="fa fa-backward"></i> Back to Student Profile</asp:LinkButton>                    
                 </div>
               
                 <div class="row">
                     <div class="col-md-2 col-sm-12">
                                <table style="text-align:center">                 
            <tr>
                <td align="right" width="50%">
                    <asp:Image ID="Img" runat="server" Height="120px" Width="110px" 
                        BorderStyle="Solid" ImageUrl="~/Images/Students/Student.jpg" />
                </td>
                <td align="left" width="30%">
                    <asp:CheckBox ID="CheckBox19" runat="server" Checked="True" />
                </td>
                <td align="left" width="20%">
                    &nbsp;</td>
            </tr>
            </table>
                     </div>
        <div class="col-md-4 col-sm-12">
              <table width="100%">
         
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label1" runat="server" Text="Full Name (Ar)"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtFullNameAr" runat="server" ReadOnly="True" Width="250px"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label2" runat="server" Text="First Name (Ar)"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtFirstNameAr" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox2" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label3" runat="server" Text="Last Name (Ar)"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtLastNameAr" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox3" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label4" runat="server" Text="Full Name (En)"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtFullNameEn" runat="server" ReadOnly="True" Width="250px"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox4" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label5" runat="server" Text="First Name (En)"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtFirstNameEn" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox5" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label6" runat="server" Text="Last Name (En)"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtLastNameEn" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox6" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label8" runat="server" Text="Gender"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:RadioButtonList ID="rbnGender" runat="server" RepeatDirection="Horizontal" 
                        Enabled="False">
                        <asp:ListItem Value="1">Males</asp:ListItem>
                        <asp:ListItem Value="0">Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox7" runat="server" Checked="True" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label9" runat="server" Text="Birth Date"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtBirthDate" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox8" runat="server" Checked="True" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label16" runat="server" Text="Marital Status"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:RadioButtonList ID="rbnMarital" runat="server" 
                        RepeatDirection="Horizontal" Enabled="False">
                        <asp:ListItem Value="1">Married</asp:ListItem>
                        <asp:ListItem Value="0">Not Married</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox9" runat="server" Checked="True" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label18" runat="server" Text="Nationality"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtNationality" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox11" runat="server" />
                </td>
            </tr>
            
        </table>
        </div>
        <div class="col-md-4 col-sm-12">
           <table>
               <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label7" runat="server" Text="EID"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtEID" runat="server" ReadOnly="True" Width="250px"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox12" runat="server" Checked="True" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label12" runat="server" Text="Expiry"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtExpiry" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox13" runat="server" Checked="True" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label13" runat="server" Text="Passport"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtIdentityNo" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox14" runat="server" Checked="True" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label21" runat="server" Text="Family No"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtFamilyNo" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox21" runat="server" Checked="True" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label14" runat="server" Text="Is Working ?"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:RadioButtonList ID="rbnIsWorking" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="left" width="20%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label15" runat="server" Text="Work Place"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtWork" runat="server" ReadOnly="True" Width="250px"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox15" runat="server" Checked="True" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label20" runat="server" Text="Work Field"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtWorkField" runat="server" ReadOnly="True" Width="250px"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox20" runat="server" Checked="True" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label19" runat="server" Text="Job"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtJob" runat="server" Width="250px"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox16" runat="server" Checked="True" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label10" runat="server" Text="Phone"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox17" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label11" runat="server" Text="Address"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtAddress" runat="server" Width="250px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
                <td align="left" width="20%">
                    <asp:CheckBox ID="CheckBox18" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="width: 100%" width="50%">
                
                    &nbsp;</td>
            </tr>
           <%-- <tr>
                <td align="center" colspan="3" style="width: 100%" width="50%">
                
                    <asp:Button ID="btnUpdate" runat="server" Enabled="False" Text="Update" 
                        onclick="btnUpdate_Click" CssClass="btn" />
                </td>
            </tr>--%>
            <tr>
                <td align="center" colspan="3" style="width: 100%" width="50%">
                
                    <asp:HiddenField ID="hdnef_idn_cn" runat="server" />
                    <asp:HiddenField ID="hdnef_non_mod_data" runat="server" />
                    <asp:HiddenField ID="hdnef_mod_data" runat="server" />
                    <asp:HiddenField ID="hdnef_sign_image" runat="server" />
                    <asp:HiddenField ID="hdnef_photo" runat="server" />
                    <asp:HiddenField ID="hdnef_root_cert" runat="server" />
                    <asp:HiddenField ID="hdnef_home_address" runat="server" />
                    <asp:HiddenField ID="hdnef_work_address" runat="server" />
                    <asp:HiddenField ID="hdnCallerID" runat="server" />
                    <asp:HiddenField ID="hdnID" runat="server" />
                </td>
            </tr>
           </table>
        </div>
                     </div>
                 <div style="text-align:center">
                      <asp:Button ID="btnUpdate" runat="server" Enabled="False" Text="Update" 
                        onclick="btnUpdate_Click" CssClass="btn1" />
                 </div>
        </div>
     <br />
    
    </div>
         <div class="fusion-secondary-header footer">
             <div class="pull-left">
                        Copyright © 2021 <a href="https://ect.ac.ae" target="_blank" style="color:white">Emirates College of Technology</a>                        
                    </div>
             <div class="pull-right">
                        Developed by <a href="https://ect.ac.ae" target="_blank" style="color:white">ETS Team</a>
                    </div>
        </div>
    </form>
    </div>
    </div>
</body>
</html>
  