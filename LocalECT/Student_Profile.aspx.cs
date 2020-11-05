using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class Student_Profile : System.Web.UI.Page
    {
        int CurrentRole = 0;
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;
        int iRegYear = 2018;
        int iRegSem = 3;
        string sConn = "";
        private enum enumQualification
        {

            QualificationNo = 2,
            CertificateID = 3,
            Major = 4,
            Minor = 5,
            GraduationYear = 6,
            CertificateSource = 7,
            countryID = 8,
            QDate = 9,
            mark = 10,
            VerifiedByRegistrar = 10,
            RegistrarComments = 11,

            VerifiedByAdmission = 12,
            AdmissionComments = 13
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            bool bResult = false;
            try
            {
                if (Session["CurrentRole"] != null)
                {
                    iRegYear = (int)Session["RegYear"];
                    iRegSem = (int)Session["RegSemester"];
                    CurrentRole = (int)Session["CurrentRole"];
                    if (!IsPostBack)
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        {
                            Server.Transfer("Authorization.aspx");
                        }
                        else
                        {
                            bool isAllowed = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                            InitializeModule.enumPrivilege.ChangeActivity, CurrentRole);
                            //chkActive.Enabled = isAllowed;
                            //chkMissing.Enabled = isAllowed;                            
                        }
                        bResult = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_VerfiyTOEFL_HS,
                        InitializeModule.enumPrivilege.ShowAdmissionVerification, CurrentRole);
                        //chkAdmissionVerfication.Visible = bResult;
                        //txtAdmissionComments.Visible = bResult;
                        //lblAdmissionVerfication.Visible = bResult;
                        //lblAdmissionComments.Visible = bResult;

                        bResult = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_VerfiyTOEFL_HS,
                       InitializeModule.enumPrivilege.ShowRegistrarVerification, CurrentRole);
                        //chkRegistrarVerfication.Visible = bResult;
                        //txtRegistrarComments.Visible = bResult;
                        //lblRegistrarVerification.Visible = bResult;
                        //lblRegistrarComments.Visible = bResult;

                        //Update
                        if(Request.QueryString["sid"] !=null && Request.QueryString["sid"] !="")
                        {
                            Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                            Session["StudentSerialNo"] = GetSerial(Request.QueryString["sid"]);
                            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.Delete, CurrentRole) != true)
                            {
                                lnk_delete.Visible = false;
                            }
                            else
                            {
                                lnk_delete.Visible = true;
                            }
                            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                            {
                                lnk_Save.Visible = false;
                            }
                            else
                            {
                                lnk_Save.Visible = true;
                            }
                        }
                        //New Student
                        else
                        {
                            lnk_delete.Visible = false;
                            Session["StudentSerialNo"] = null;
                            New();
                            lnk_Save.Visible = true;
                        }
                    }
                }
                else
                {
                    Session.RemoveAll();
                    Response.Redirect("Login.aspx");
                }
               lbl_Msg.Text = "";
               Connection_StringCLS ConnectionString;

                switch (Campus)
                {
                    case InitializeModule.EnumCampus.Males:
                        ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
                        sConn = ConnectionString.Conn_string;
                        break;
                    case InitializeModule.EnumCampus.Females:
                        ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Females);
                        sConn = ConnectionString.Conn_string;
                        break;
                }

                //QCityDS.ConnectionString = sConn;
                BirthCityDS.ConnectionString = sConn;
                ResidentCityDS.ConnectionString = sConn;
                HomeCityDS.ConnectionString = sConn;


                if (!IsPostBack)
                {
                    FillDDLs();
                    bool isAllowed = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                           InitializeModule.enumPrivilege.StatusGraduated, CurrentRole);

                    //if (ddlStatus.SelectedValue == "3" && isAllowed == true)
                    //{
                    //    chkCompleteBAFromOtherInstitution.Enabled = isAllowed;
                    //    chkCompleteMasterFromOtherInstitution.Enabled = isAllowed;
                    //}


                    
                    if (Session["StudentSerialNo"] != null)
                    {
                        hdnSerial.Value = Session["StudentSerialNo"].ToString();
                        GetStudent((int.Parse(hdnSerial.Value)));

                        bResult = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.ChangeStudentName, CurrentRole);
                        if (lblStudentId.Text != "")
                        {
                            txtNameAr.Enabled = bResult;
                            txtFNameAr.Enabled = bResult;
                            txtLNameAr.Enabled = bResult;

                            txtNameEn.Enabled = bResult;
                            txtFNameEn.Enabled = bResult;
                            txtLNameEn.Enabled = bResult;
                        }

                    }

                    else
                    {
                        Empty_Controls();
                    }


                    //EID Data

                    if (Session["CallerID"] != null)
                    {
                        if (Session["CallerID"].ToString() == "STD")
                            getEIDData();
                    }

                    //End EID Data


                    int iVerificationResult = 0;
                    iVerificationResult = LibraryMOD.IsFileVerifiedFromRegistrar(lblStudentId.Text, Campus);
                    if (iVerificationResult == InitializeModule.FALSE_VALUE)
                    {
                        lblIsVerfiedFromRegistrar.Text = "Warning: UnVerfied from the Registrar";
                        lblIsVerfiedFromRegistrar.ForeColor = Color.Red;
                    }
                    if (iVerificationResult == InitializeModule.TRUE_VALUE)
                    {
                        lblIsVerfiedFromRegistrar.Text = "Verfied from the Registrar";
                        lblIsVerfiedFromRegistrar.ForeColor = Color.Green;  //#009933
                    }
                    if (iVerificationResult == 2)
                    {
                        lblIsVerfiedFromRegistrar.Text = "verification not mandatory for current file";
                        lblIsVerfiedFromRegistrar.ForeColor = Color.Green;  //#009933
                    }


                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void GetStudent(int iSerial)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                if (iSerial == 0)
                {
                    //MultiTabs.ActiveViewIndex = 4;                    
                    lbl_Msg.Text = "Sorry this student has no ID yet (Not Enrolled),Use the following search , Then Select it.";
                    div_msg.Visible = true;
                    txtBirthDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
                    txtExpiry.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
                    //txtMilitaryServiceDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
                    return;
                }

                hdnSerial.Value = iSerial.ToString();
                Session["StudentSerialNo"] = iSerial;
                GetStudentData(iSerial);

                string sSQL = "SELECT intStudyYear, byteSemester, strApplicationNumber, lngStudentNumber, dateApplication,";
                sSQL += "lngSerial, strCollege, strDegree, strSpecialization, bAccepted, dateAccepted, strNotes,";
                sSQL += "bActive, bContinue, bOtherCollege, intAdvisor, byteStudentType, IsCompleteBAFromOtherInstitution,";
                sSQL += "IsCompleteMasterFromOtherInstitution, strUserCreate, dateCreate, strNUser, sReference, intRemind,";
                sSQL += "byteCancelReason,intGraduationYear,byteGraduationSemester,byteMainReason,byteSubReason,dateGraduation2,";
                sSQL += "WantedMajorID, sReferredBy, iEnrollmentSource, sEnrollmentNotes, iRegisteredThrough, sECTId,";
                sSQL += "iEnrollmentSource2, WantedMajorID2, WantedMajorID3, byteLastDegreeInistitution, byteLastDegreeCountry,";
                sSQL += "curLastCGPA, intLastDegreeYear, sLastDegree, LHEEquivalencyIndicator, LHEEquivalencyAppNo, Std_ORCID";
                sSQL += ",dateMilitaryService,isMilitaryService,iContactID,iOpportunityID,iAcceptanceType,iAcceptanceCondition,iAdmissionStatus";
                sSQL += " FROM Reg_Applications";
                sSQL += " Where lngSerial=" + iSerial;


                SqlCommand cmd = new SqlCommand(sSQL, Conn);

                SqlDataReader rd = cmd.ExecuteReader();
                if (!rd.HasRows)
                {
                    //ddlReason.SelectedValue = "0";
                    //SubReasonDS.DataBind();
                    //ddlSubReason.DataBind();
                    //ddlType.SelectedValue = "0";
                    //MajorDS.DataBind();
                    //ddlMajor.DataBind();
                    //ddlMajor.SelectedValue = "010120";
                    //ddlEnrollmentTerm.SelectedValue = (iRegYear * 10 + iRegSem).ToString();
                    //ddlStatus.SelectedValue = "0";
                    //ddlStatusTerm.SelectedValue = (iRegYear * 10 + iRegSem).ToString();
                    //ddlSubReason.SelectedValue = "0";
                    //ddlAdvisor.SelectedValue = "1000";
                    //lblDateEnrolled.Text = "";
                    //lblDateStatus.Text = "";
                    //lblReference.Text = "";
                    lblStudentId.Text = "";
                    //lblECTId.Text = "";
                    //txtNote.Text = "";
                    //txtReferredBy.Text = "";
                    //chkActive.Checked = true;
                    //chkMissing.Checked = false;

                    //txtMilitaryServiceDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    //ChkIsMilitaryService.Checked = false;

                    //ddlWMajor1.SelectedValue = "0";
                    //ddlWMajor2.SelectedValue = "0";
                    //ddlWMajor3.SelectedValue = "0";
                    //chkCompleteBAFromOtherInstitution.Checked = false;
                    //chkCompleteMasterFromOtherInstitution.Checked = false;
                    //txtEnrollmentSource.Text = "";
                    //ddlEnrollmentSource.SelectedValue = "0";
                    //ddlEnrollmentSource2.SelectedValue = "0";
                    //ddlRegisteredThrough.SelectedValue = "1";

                    //txtOpportunityID.Text = "0";
                    //txtContactID.Text = "0";
                    //ddlAcceptance.SelectedIndex = 0;
                    //ddlAcceptanceCondition.SelectedIndex = 0;
                    //ddlAdmissionStatus.SelectedIndex = 0;

                    //mtvQualification.ActiveViewIndex = 0;
                    //MultiTabs.ActiveViewIndex = 0;
                    //rd.Close();
                    //return;
                }

                int iYear = 0;
                int iSem = 0;
                int iTerm = 0;

                string sSID = "";

                string sCollege = "";
                string sDegree = "";
                string sSpec = "";

                while (rd.Read())
                {
                    sCollege = rd["strCollege"].ToString();
                    sDegree = rd["strDegree"].ToString();
                    sSpec = rd["strSpecialization"].ToString();

                    string sKey = "0" + sCollege + "0" + sDegree;
                    if (sSpec.Length > 1)
                    {
                        sKey += sSpec.Substring(0, 2);
                    }
                    else
                    {
                        sKey += "0" + sSpec;
                    }

                    string sMajor = sKey;

                    //MajorDS.DataBind();
                    //ddlMajor.DataBind();
                    //ddlMajor.SelectedValue = sMajor;

                    //ddlType.SelectedValue = rd["byteStudentType"].ToString();
                    //chkActive.Checked = Convert.ToBoolean(rd["bActive"]);
                    //chkMissing.Checked = Convert.ToBoolean(rd["bContinue"]);
                    //if (rd["dateMilitaryService"].ToString() == "")
                    //{
                    //    txtMilitaryServiceDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    //}
                    //else
                    //{
                    //    txtMilitaryServiceDate.Text = string.Format("{0:yyyy-MM-dd}", rd["dateMilitaryService"]);
                    //}

                    //ChkIsMilitaryService.Checked = Convert.ToBoolean(rd["isMilitaryService"]);

                    iYear = Convert.ToInt32(rd["intStudyYear"]);
                    iSem = Convert.ToInt32(rd["byteSemester"]);
                    iTerm = iYear * 10 + iSem;
                    //ddlEnrollmentTerm.SelectedValue = iTerm.ToString();

                    int iStatus = 0;

                    if (!rd["byteCancelReason"].Equals(DBNull.Value))
                    {
                        iStatus = Convert.ToInt32(rd["byteCancelReason"]);
                    }
                    if (iStatus > 0)
                    {
                        //ddlStatus.SelectedValue = iStatus.ToString();
                        iYear = Convert.ToInt32(rd["intGraduationYear"]);
                        iSem = Convert.ToInt32(rd["byteGraduationSemester"]);
                        iTerm = iYear * 10 + iSem;
                        //ddlStatusTerm.SelectedValue = iTerm.ToString();

                        //ddlReason.SelectedValue = rd["byteMainReason"].ToString();
                        //SubReasonDS.DataBind();
                        //ddlSubReason.DataBind();
                        //ddlSubReason.SelectedValue = rd["byteSubReason"].ToString();
                        //lblDateStatus.Text = string.Format("{0:yyyy-MM-dd}", rd["dateGraduation2"]);
                        //if (iStatus == 3)
                        //{
                        //    chkCompleteBAFromOtherInstitution.Enabled = true;
                        //    chkCompleteMasterFromOtherInstitution.Enabled = true;
                        //}
                        //chkCompleteBAFromOtherInstitution.Checked = Convert.ToBoolean(rd["IsCompleteBAFromOtherInstitution"]);
                        //chkCompleteMasterFromOtherInstitution.Checked = Convert.ToBoolean(rd["IsCompleteMasterFromOtherInstitution"]);

                    }
                    else
                    {
                        //ddlStatus.SelectedValue = null;
                        //ddlStatusTerm.SelectedValue = null;
                        //ddlReason.SelectedValue = "0";
                        //SubReasonDS.DataBind();
                        //ddlSubReason.DataBind();
                        //ddlSubReason.SelectedValue = "0";
                        //lblDateStatus.Text = "";
                        //chkCompleteBAFromOtherInstitution.Checked = false;
                        //chkCompleteMasterFromOtherInstitution.Enabled = false;
                    }

                    //ddlEnrollmentSource.SelectedValue = rd["iEnrollmentSource"].ToString();
                    //ddlEnrollmentSource2.SelectedValue = rd["iEnrollmentSource2"].ToString();

                    //txtEnrollmentSource.Text = rd["sEnrollmentNotes"].ToString();

                    //ddlRegisteredThrough.SelectedValue = rd["iRegisteredThrough"].ToString();

                    //ddlWMajor1.SelectedValue = rd["WantedMajorID"].ToString();
                    //ddlWMajor2.SelectedValue = rd["WantedMajorID2"].ToString();
                    //ddlWMajor3.SelectedValue = rd["WantedMajorID3"].ToString();
                    //ddlAdvisor.SelectedValue = rd["intAdvisor"].ToString();
                    //lblDateEnrolled.Text = string.Format("{0:yyyy-MM-dd}", rd["dateApplication"]);
                    sSID = rd["lngStudentNumber"].ToString();
                    lblStudentId.Text = sSID;
                    //lblReference.Text = rd["sReference"].ToString();
                    //lblECTId.Text = rd["sECTId"].ToString();
                    //txtNote.Text = rd["strNotes"].ToString();

                    //txtReferredBy.Text = rd["sReferredBy"].ToString();

                    //if (rd["sLastDegree"].Equals(DBNull.Value))
                    //{
                    //    ddlLastDegree.SelectedValue = "0";
                    //}
                    //else
                    //{
                    //    ddlLastDegree.SelectedValue = rd["sLastDegree"].ToString();
                    //}
                    //ddlLastInistitution.SelectedValue = rd["byteLastDegreeInistitution"].ToString();
                    //ddlLastCountry.SelectedValue = rd["byteLastDegreeCountry"].ToString();
                    //txtLastCGPA.Text = string.Format("{0:f}", rd["curLastCGPA"]);
                    //txtLastYear.Text = rd["intLastDegreeYear"].ToString();

                    //if (rd["LHEEquivalencyIndicator"].Equals(DBNull.Value))
                    //{
                    //    ddlEquivalencyIndicator.SelectedValue = "M";
                    //}
                    //else
                    //{
                    //    ddlLHEquivalencyIndicator.SelectedValue = rd["LHEEquivalencyIndicator"].ToString();
                    //}
                    //txtLHEquivalencyAppNo.Text = rd["LHEEquivalencyAppNo"].ToString();
                    //txtORCID.Text = rd["Std_ORCID"].ToString();

                    ////iContactID,iOpportunityID,iAcceptanceType
                    //txtOpportunityID.Text = rd["iOpportunityID"].ToString();
                    //txtContactID.Text = rd["iContactID"].ToString();
                    //ddlAcceptance.SelectedValue = rd["iAcceptanceType"].ToString();
                    //ddlAcceptanceCondition.SelectedValue = rd["iAcceptanceCondition"].ToString();
                    //ddlAdmissionStatus.SelectedValue = rd["iAdmissionStatus"].ToString();

                    //MultiTabs.ActiveViewIndex = 1;
                    //grdQualification.DataBind();
                    //grdDocs.DataBind();
                }


                if (lblStudentId.Text == "")
                {
                    Session["CurrentStudent"] = null;
                }
                else
                {
                    Session["CurrentStudent"] = sSID;
                    //grdMarks.DataBind();
                    FillCourses(sCollege, sDegree, sSpec);
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }

        private void GetStudentData(int iSerial)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT lngSerial, iUnifiedID, strFirstDescEn, strSecondDescEn, strLastDescEn, strFirstDescAr, strSecondDescAr, strLastDescAr,";
                sSQL += "bSex, dateBirth, byteBirthCountry,byteBirthCity, byteNationality,byteHomeCountry, byteHomeCity,strID,";
                sSQL += "byteOriginCountry, byteOriginCity, strPhone1, strPhone2, strEmail,strAddress, byteShift, strNationalID, intWorkPlace, strWorkPhone,";
                sSQL += "strJopTitle, intDelegation, intSponsor, dateEndSponsorship, isWorking, EthbaraNo, FitnessStatus,MaritalStatus, NationalityofMother,";
                sSQL += "EmploymentSector, strNationalNumber, FamilyBookNumber, FamilyID, CityNumber, PUnifiedID, EmployerName, EmployerEmail,EmployerPhone,";
                sSQL += "EmployerPosition, EmployerIndustry, EmployerCompanyName, EmployerCountry, EmployerEmirate, iACMSCategory, sECTemail,strStudentPic";



                sSQL += " FROM Reg_Students_Data";
                sSQL += " WHERE lngSerial=" + iSerial;

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                //ddlLastInistitution.Items.Clear();

                bool bGender = true;
                while (Rd.Read())
                {
                    hdnSerial.Value = Rd["lngSerial"].ToString();
                    txtUnifiedNo.Text = Rd["iUnifiedID"].ToString();
                    txtFNameEn.Text = Rd["strFirstDescEn"].ToString();
                    txtLNameEn.Text = Rd["strSecondDescEn"].ToString();
                    txtNameEn.Text = Rd["strLastDescEn"].ToString();
                    txtFNameAr.Text = Rd["strFirstDescAr"].ToString();
                    txtLNameAr.Text = Rd["strSecondDescAr"].ToString();
                    txtNameAr.Text = Rd["strLastDescAr"].ToString();
                    rbnGender.SelectedValue = "0";
                    bGender = Convert.ToBoolean(Rd["bSex"].ToString());
                    if (bGender)
                    {
                        rbnGender.SelectedValue = "1";
                    }
                    txtBirthDate.Text = string.Format("{0:yyyy-MM-dd}", Rd["dateBirth"]);
                    ddlBirthCountry.SelectedValue = Rd["byteBirthCountry"].ToString();
                    ddlBirthCity.DataBind();
                    ddlBirthCity.SelectedValue = Rd["byteBirthCity"].ToString();
                    ddlNationality.SelectedValue = Rd["byteNationality"].ToString();
                    ddlResidentCountry.SelectedValue = Rd["byteHomeCountry"].ToString();
                    ddlResidentCity.DataBind();
                    ddlResidentCity.SelectedValue = Rd["byteHomeCity"].ToString();
                    txtIdentityNo.Text = Rd["strID"].ToString();
                    ddlHomeCountry.SelectedValue = Rd["byteOriginCountry"].ToString();
                    ddlHomeCity.DataBind();
                    ddlHomeCity.SelectedValue = Rd["byteOriginCity"].ToString();
                    txtPhone1.Text = Rd["strPhone1"].ToString();
                    txtPhone2.Text = Rd["strPhone2"].ToString();
                    txtEmail.Text = Rd["strEmail"].ToString();
                    txtAddress.Text = Rd["strAddress"].ToString();
                    ddlSession.SelectedValue = Rd["byteShift"].ToString();
                    txtIDNo.Text = Rd["strNationalID"].ToString();
                    ddlIWork.SelectedValue = Rd["intWorkPlace"].ToString();
                    txtWorkPhone.Text = Rd["strWorkPhone"].ToString();
                    txtJob.Text = Rd["strJopTitle"].ToString();
                    ddlSponsor.SelectedValue = Rd["intDelegation"].ToString();
                    ddlVisa.SelectedValue = Rd["intSponsor"].ToString();
                    txtExpiry.Text = string.Format("{0:yyyy-MM-dd}", Rd["dateEndSponsorship"]);

                    rbnEmploymentStatus.SelectedValue = Rd["isWorking"].ToString();
                    txtEthbara.Text = Rd["EthbaraNo"].ToString();
                    rbnFitnessStatus.SelectedValue = Rd["FitnessStatus"].ToString();
                    ddlMaritalStatus.SelectedValue = Rd["MaritalStatus"].ToString();
                    ddlNationalityofMother.SelectedValue = Rd["NationalityofMother"].ToString();
                    ddlEmploymentSector.SelectedValue = Rd["EmploymentSector"].ToString();
                    txtNationalNo.Text = Rd["strNationalNumber"].ToString();
                    txtFamilyBookNo.Text = Rd["FamilyBookNumber"].ToString();
                    txtFamilyNo.Text = Rd["FamilyID"].ToString();
                    txtCityNo.Text = Rd["CityNumber"].ToString();
                    txtUnifiedNo.Text = Rd["PUnifiedID"].ToString();
                    txtEmployerName.Text = Rd["EmployerName"].ToString();
                    txtEmployeremail.Text = Rd["EmployerEmail"].ToString();
                    txtEmployerPhone.Text = Rd["EmployerPhone"].ToString();
                    txtEmployerPos.Text = Rd["EmployerPosition"].ToString();
                    txtEmployerIndustry.Text = Rd["EmployerIndustry"].ToString();
                    txtCompany.Text = Rd["EmployerCompanyName"].ToString();
                    ddlEmployerCountry.SelectedValue = Rd["EmployerCountry"].ToString();
                    ddlEmployerEmirate.SelectedValue = Rd["EmployerEmirate"].ToString();
                    ddlAccess.SelectedValue = Rd["iACMSCategory"].ToString();
                    txtECTEmail.Text = Rd["sECTemail"].ToString();

                    Pic.Value = Rd["strStudentPic"].ToString();

                    if (Pic.Value == "")
                    {
                        Pic.Value = txtIDNo.Text;
                    }

                    string sURL = "~/Images/Students/PIC" + Pic.Value + ".jpeg";

                    if (File.Exists(Server.MapPath(sURL)))
                    {
                        imgStudent.ImageUrl = sURL;
                    }
                    else
                    {
                        imgStudent.ImageUrl = "~/Images/Students/Student.jpg";
                    }

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }


        }
        private int GetSerial(string sNumber)
        {
            int iserial = 0;
            try
            {
                ApplicationsDAL myapp = new ApplicationsDAL();
                iserial = myapp.GetSerial(Campus, sNumber);
            }
            catch (Exception ex)
            {
            }
            return iserial;
        }
        private void getEIDData()
        {
            try
            {
                //Session["EIDsID"] = hdnID.Value;
                if (Session["EIDID"] != null)
                {
                    txtIDNo.Text = Session["EIDID"].ToString();
                }

                if (Session["EIDGender"] != null)
                {
                    string sGender = Session["EIDGender"].ToString();
                    rbnGender.SelectedValue = sGender;
                }
                if (Session["EIDBirthDate"] != null)
                {
                    txtBirthDate.Text = Session["EIDBirthDate"].ToString();
                }
                if (Session["EIDMarital"] != null)
                {
                    ddlMaritalStatus.SelectedValue = Session["EIDMarital"].ToString();
                }


                if (Session["EIDExpiry"] != null)
                {
                    txtExpiry.Text = Session["EIDExpiry"].ToString();
                }

                if (txtExpiry.Text == "")
                {
                    txtExpiry.Text = string.Format("yyyy-MM-dd", DateTime.Today.Date);
                }

                if (Session["EIDFirstNameAr"] != null)
                {
                    txtFNameAr.Text = Session["EIDFirstNameAr"].ToString();
                }
                if (Session["EIDLastNameAr"] != null)
                {
                    txtLNameAr.Text = Session["EIDLastNameAr"].ToString();
                }
                if (Session["EIDFullNameAr"] != null)
                {
                    txtNameAr.Text = Session["EIDFullNameAr"].ToString();
                }

                if (Session["EIDFirstNameEn"] != null)
                {
                    txtFNameEn.Text = Session["EIDFirstNameEn"].ToString();
                }
                if (Session["EIDLastNameEn"] != null)
                {
                    txtLNameEn.Text = Session["EIDLastNameEn"].ToString();
                }
                if (Session["EIDFullNameEn"] != null)
                {
                    txtNameEn.Text = Session["EIDFullNameEn"].ToString();
                }

                if (Session["EIDNationality"] != null)
                {
                    string sNationality = Session["EIDNationality"].ToString();
                    string sNationalityID = GetNationalityID_ByCountryCode3((int)Campus, sNationality);
                    if (sNationalityID != "")
                    {
                        ddlNationality.SelectedValue = sNationalityID;
                    }
                }

                if (Session["EIDPassport"] != null)
                {
                    // ddlIdentityType.SelectedValue = "2";//Passport                    
                    txtIdentityNo.Text = Session["EIDPassport"].ToString();
                }

                if (Session["EIDWorkingPlace"] != null)
                {
                    txtCompany.Text = Session["EIDWorkingPlace"].ToString();
                    if (Session["EIDJob"] != null)
                    {
                        txtJob.Text = Session["EIDJob"].ToString();
                    }
                    if (Session["EIDWorkField"] != null)
                    {
                        txtEmployerIndustry.Text = Session["EIDWorkField"].ToString();
                    }
                    rbnEmploymentStatus.SelectedValue = "1";
                    ddlIWork.SelectedValue = "1";
                }
                else
                {
                    rbnEmploymentStatus.SelectedValue = "0";
                    ddlIWork.SelectedValue = "0";
                }

                if (Session["EIDFamilyID"] != null)
                {
                    string sFamily = Session["EIDFamilyID"].ToString();
                    int iLen = sFamily.Length;
                    if (sFamily.Length >= 6)
                    {
                        txtCityNo.Text = sFamily.Substring(0, 3);
                        txtFamilyNo.Text = sFamily.Substring(3, iLen - 3);
                    }
                    else
                    {
                        txtFamilyNo.Text = "999";
                    }
                }


                if (Session["EIDPhone"] != null)
                {
                    txtPhone1.Text = Session["EIDPhone"].ToString();

                }
                if (Session["EIDAddress"] != null)
                {
                    txtAddress.Text += "," + Session["EIDAddress"].ToString();
                }
                if (Session["EIDImgUrl"] != null)
                {
                    imgStudent.ImageUrl = Session["EIDImgUrl"].ToString();
                    Pic.Value = Session["EIDID"].ToString();
                }

                //Kill Session Data
                Session["CallerID"] = null;
                Session["EIDID"] = null;
                Session["EIDGender"] = null;
                Session["EIDBirthDate"] = null;
                Session["EIDMarital"] = null;
                Session["EIDExpiry"] = null;
                Session["EIDFirstNameAr"] = null;
                Session["EIDLastNameAr"] = null;
                Session["EIDFullNameAr"] = null;
                Session["EIDFirstNameEn"] = null;
                Session["EIDLastNameEn"] = null;
                Session["EIDFullNameEn"] = null;
                Session["EIDNationality"] = null;
                Session["EIDPassport"] = null;
                Session["EIDWorkingPlace"] = null;
                Session["EIDPhone"] = null;
                Session["EIDAddress"] = null;
                Session["EIDImgUrl"] = null;
                Session["EIDFamilyID"] = null;
                Session["EIDWorkField"] = null;
                Session["EIDJob"] = null;

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }

        }

        private void Empty_Controls()
        {
            try
            {
                Session["CurrentStudent"] = null;
                Session["StudentSerialNo"] = null;
                hdnSerial.Value = "";
                txtAddress.Text = "";
                txtBirthDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
                txtEmail.Text = "xyz@xyz.com";
                txtECTEmail.Text = "";
                txtExpiry.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
                //txtMilitaryServiceDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);

                txtFNameAr.Text = "";
                txtFNameEn.Text = "";
                txtIdentityNo.Text = "";
                txtIDNo.Text = "999999999999999";
                txtJob.Text = "";
                ddlAccess.SelectedValue = "0";
                txtLNameAr.Text = "";
                txtLNameEn.Text = "";
                txtNameAr.Text = "";
                txtNameEn.Text = "";
                txtPhone1.Text = "";
                txtPhone2.Text = "";
                txtWorkPhone.Text = "";
                txtEthbara.Text = "NA";
                txtUnifiedNo.Text = "NA";
                txtFamilyBookNo.Text = "999999";
                txtFamilyNo.Text = "999";
                txtCityNo.Text = "999";
                //txtNote.Text = "";
                //txtReferredBy.Text = "";
                txtCompany.Text = "NA";
                txtEmployeremail.Text = "xyz@xyz.com";
                txtEmployerIndustry.Text = "NA";
                txtEmployerName.Text = "NA";
                txtEmployerPhone.Text = "NA";
                txtEmployerPos.Text = "NA";
                ddlEmployerCountry.SelectedValue = "0";
                ddlEmployerEmirate.SelectedValue = "0";
                //ddlLastDegree.SelectedValue = "0";
                //ddlLastInistitution.SelectedValue = "-1";
                //ddlLastCountry.SelectedValue = "-1";
                //txtLastYear.Text = "";
                //txtLastCGPA.Text = "";
                //ddlLHEquivalencyIndicator.SelectedIndex = 0;
                //txtLHEquivalencyAppNo.Text = "";
                //txtORCID.Text = "NA";

                //txtOpportunityID.Text = "0";
                //txtContactID.Text = "0";
                //ddlAcceptance.SelectedIndex = 0;
                //ddlAcceptanceCondition.SelectedIndex = 0;
                //ddlAdmissionStatus.SelectedIndex = 0;

                ddlBirthCountry.SelectedValue = "1";
                //ddlEnrollmentTerm.SelectedValue = (iRegYear * 10 + iRegSem).ToString();

                ddlHomeCountry.SelectedValue = "1";
                //ddlIdentityType.SelectedValue = "0";
                ddlIWork.SelectedValue = "0";
                ddlEmploymentSector.SelectedValue = "0";
                ddlNationalityofMother.SelectedValue = "1";

                ddlMaritalStatus.SelectedValue = "0";

                ddlLanguage.SelectedValue = "1";
                //ddlType.SelectedValue = "0";
                //MajorDS.DataBind();
                //ddlMajor.DataBind();
                //ddlMajor.SelectedValue = "010120";
                ddlNationality.SelectedValue = "1";
                //ddlReason.SelectedValue = "0";
                ddlResidentCountry.SelectedValue = "1";

                switch (Campus)
                {
                    case InitializeModule.EnumCampus.Males:
                        ddlSession.SelectedValue = "4";
                        break;
                    case InitializeModule.EnumCampus.Females:
                        ddlSession.SelectedValue = "1";
                        break;
                }
                ddlSponsor.SelectedValue = "0";
                //ddlStatus.SelectedIndex = -1;
                //ddlStatusTerm.SelectedIndex = -1;
                //SubReasonDS.DataBind();
                //ddlSubReason.DataBind();
                //ddlSubReason.SelectedValue = "0";
                ddlVisa.SelectedValue = "0";
                //ddlAdvisor.SelectedValue = "1000";
                //lblDateEnrolled.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
                //lblDateStatus.Text = "";
                //lblReference.Text = "";
                lblStudentId.Text = "";
                //lblECTId.Text = "";

                BirthCityDS.DataBind();
                ddlBirthCity.DataBind();
                ddlBirthCity.SelectedValue = "1";
                HomeCityDS.DataBind();
                //ddlQCity.DataBind();
                //ddlQEngGrade.DataBind();
                

                //ddlQEngExamCenter.DataBind();
                

                ddlHomeCity.DataBind();
                ddlHomeCity.SelectedValue = "1";
                ResidentCityDS.DataBind();
                ddlResidentCity.DataBind();
                ddlResidentCity.SelectedValue = "1";

                //ChkIsMilitaryService.Checked = false;
                //mtvQualification.ActiveViewIndex = 0;
                //MultiTabs.ActiveViewIndex = -1;
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }

        }

        #region "Fill DDLs"

        private void FillDDLs()
        {
            try
            {
                FillAdvisers();
                FillCertificates();
                FillQInstitutionType();
                FillQG12Stream();
                FillQEngGrade();
                FillQEngExamCenter();
                //FillCities();
                FillCountries();
                FillLanguages();
                FillMainReasons();
                //FillMajors();
                FillNationalities();
                FillQMajors();
                FillSessions();
                FillSponsors();
                FillStatuses();
                //FillSubReasons();
                FillTerms();
                FillVisa();
                FillWork_Places();
                FillEmploymentSector();
                FillMarkSource();
                FillEmirates();
                FillDegrees();
                FillInistitutions();
                FillHSSystem();

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
        }
        private void FillEmirates()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT byteEmirate, strEmirateEn";
                sSQL += " FROM Lkp_Emirates";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                ddlEmployerEmirate.Items.Clear();

                while (Rd.Read())
                {
                    ddlEmployerEmirate.Items.Add(new ListItem(Rd["strEmirateEn"].ToString(), Rd["byteEmirate"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }


        }


        private void FillHSSystem()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT iSerial, sSystem";
                sSQL += " FROM Lkp_HS_System";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                //ddlHSSystem.Items.Clear();

                while (Rd.Read())
                {
                    //ddlHSSystem.Items.Add(new ListItem(Rd["sSystem"].ToString(), Rd["iSerial"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }


        }

        private void FillDegrees()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT strDegree,strDegreeDescEn";
                sSQL += " FROM Reg_Degrees";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                //ddlLastDegree.Items.Clear();

                while (Rd.Read())
                {
                    //ddlLastDegree.Items.Add(new ListItem(Rd["strDegreeDescEn"].ToString(), Rd["strDegree"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }


        }

        private void FillInistitutions()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT byteCollege ,strCollegeDescEn";
                sSQL += " FROM Lkp_Foreign_Colleges";
                sSQL += " ORDER BY strCollegeDescEn";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                //ddlLastInistitution.Items.Clear();

                while (Rd.Read())
                {
                    //ddlLastInistitution.Items.Add(new ListItem(Rd["strCollegeDescEn"].ToString(), Rd["byteCollege"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }


        }
        private void FillStatuses()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT byteReason, strReasonDesc AS Status";
                sSQL += " FROM dbo.Lkp_Reasons AS S";
                sSQL += " WHERE (byteReason <> 100 AND byteReason <> 9)";
                sSQL += " ORDER BY byteReason";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                //ddlStatus.Items.Clear();
                while (Rd.Read())
                {
                    //ddlStatus.Items.Add(new ListItem(Rd["Status"].ToString(), Rd["byteReason"].ToString()));
                }
                Rd.Close();

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }

        private void FillSessions()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {

                string sSQL = "SELECT byteShift, strShiftEn FROM Reg_Shifts";
                switch (Campus)
                {
                    case InitializeModule.EnumCampus.Males:
                        sSQL += " WHERE (byteShift BETWEEN 3 AND 4) OR (byteShift = 8)";
                        break;
                    case InitializeModule.EnumCampus.Females:
                        sSQL += " WHERE (byteShift BETWEEN 1 AND 2) OR (byteShift = 9)";
                        break;
                }

                sSQL += " ORDER BY intCampus, byteShift";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                while (Rd.Read())
                {
                    ddlSession.Items.Add(new ListItem(Rd["strShiftEn"].ToString(), Rd["byteShift"].ToString()));
                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }

        //private void FillMajors()
        //{
        //    List<Specializations> mySpecializations = new List<Specializations>();
        //    SpecializationsDAL mySpecializationsDAL = new SpecializationsDAL();
        //    try
        //    {
        //        ddlMajor.Items.Clear();
        //        mySpecializations = mySpecializationsDAL.GetList(Campus, "", false);
        //        for (int i = 0; i < mySpecializations.Count; i++)
        //        {
        //            ddlMajor.Items.Add(new ListItem(mySpecializations[i].strMajor, mySpecializations[i].strKey.ToString()));

        //        }

        //    }
        //    catch (Exception ex)
        //    {


        //        LibraryMOD.ShowErrorMessage(ex);
        //        divMsg.InnerText = ex.Message;
        //    }
        //    finally
        //    {
        //        mySpecializations.Clear();

        //    }
        //}

        private void FillCountries()
        {
            List<Countries> myCountries = new List<Countries>();
            CountriesDAL myCountriesDAL = new CountriesDAL();
            try
            {
                myCountries = myCountriesDAL.GetCountries(Campus, "", false);
                for (int i = 0; i < myCountries.Count; i++)
                {
                    ddlHomeCountry.Items.Add(new ListItem(myCountries[i].strCountryDescEn, myCountries[i].byteCountry.ToString()));
                    ddlResidentCountry.Items.Add(new ListItem(myCountries[i].strCountryDescEn, myCountries[i].byteCountry.ToString()));
                    //ddlQCountry.Items.Add(new ListItem(myCountries[i].strCountryDescEn, myCountries[i].byteCountry.ToString()));
                    ddlBirthCountry.Items.Add(new ListItem(myCountries[i].strCountryDescEn, myCountries[i].byteCountry.ToString()));
                    ddlEmployerCountry.Items.Add(new ListItem(myCountries[i].strCountryDescEn, myCountries[i].byteCountry.ToString()));
                    //ddlLastCountry.Items.Add(new ListItem(myCountries[i].strCountryDescEn, myCountries[i].byteCountry.ToString()));
                }

            }
            catch (Exception ex)
            {


                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myCountries.Clear();

            }
        }

        //private void FillCities()
        //{
        //    List<Cities> myCities = new List<Cities>();
        //    CitiesDAL myCitiesDAL = new CitiesDAL();
        //    try
        //    {
        //        myCities = myCitiesDAL.GetCities(Campus,"",false);
        //        for (int i = 0; i < myCities.Count; i++)
        //        {
        //            ddlHomeCity.Items.Add(new ListItem(myCities[i].strCityDescEn, myCities[i].byteCity.ToString()));
        //            ddlResidentCity.Items.Add(new ListItem(myCities[i].strCityDescEn, myCities[i].byteCity.ToString()));
        //            ddlBirthCity.Items.Add(new ListItem(myCities[i].strCityDescEn, myCities[i].byteCity.ToString()));       
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        LibraryMOD.ShowErrorMessage(ex);
        //        divMsg.InnerText = ex.Message;
        //    }
        //    finally
        //    {
        //        myCities.Clear();

        //    }
        //}
        public string GetNationalityID_ByCountryCode3(int iCampus, string sCountryCode3)
        {
            String sSQL;
            string sNationality = "0";
            Connection_StringCLS MyConnection_string = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
            SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
            try
            {


                sSQL = "SELECT byteNationality";
                sSQL += " FROM Lkp_Nationalities ";
                sSQL += " WHERE CountryCode3 = '" + sCountryCode3 + "'";

                Conn.Open();

                System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
                System.Data.SqlClient.SqlDataReader datReader;
                datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


                if (datReader.Read())
                {
                    sNationality = datReader.GetInt16(0).ToString();
                }
                datReader.Close();

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return sNationality;
        }
        private void FillNationalities()
        {
            List<Nationalities> myNationalities = new List<Nationalities>();
            NationalitiesDAL myNationalitiesDAL = new NationalitiesDAL();
            try
            {
                myNationalities = myNationalitiesDAL.GetNationalities(Campus, "", false);
                for (int i = 0; i < myNationalities.Count; i++)
                {
                    ddlNationality.Items.Add(new ListItem(myNationalities[i].strNationalityDescEn, myNationalities[i].byteNationality.ToString()));
                    ddlNationalityofMother.Items.Add(new ListItem(myNationalities[i].strNationalityDescEn, myNationalities[i].byteNationality.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myNationalities.Clear();

            }
        }

        private void FillLanguages()
        {
            List<Languages> myLanguages = new List<Languages>();
            LanguagesDAL myLanguagesDAL = new LanguagesDAL();
            try
            {
                myLanguages = myLanguagesDAL.GetLanguages(Campus, "", false);
                for (int i = 0; i < myLanguages.Count; i++)
                {
                    ddlLanguage.Items.Add(new ListItem(myLanguages[i].strLanguageDescEn, myLanguages[i].byteLanguage.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myLanguages.Clear();

            }
        }



        private void FillEmploymentSector()
        {
            List<Sector> mySector = new List<Sector>();
            SectorDAL mySectorDAL = new SectorDAL();
            try
            {
                mySector = mySectorDAL.GetSector(Campus, "", false);
                for (int i = 0; i < mySector.Count; i++)
                {
                    ddlEmploymentSector.Items.Add(new ListItem(mySector[i].SectorNameEn, mySector[i].SectorID.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                mySector.Clear();
            }

        }
        private void FillWork_Places()
        {
            List<Work_Places> myWork_Places = new List<Work_Places>();
            Work_PlacesDAL myWork_PlacesDAL = new Work_PlacesDAL();
            try
            {
                myWork_Places = myWork_PlacesDAL.GetWork_Places(Campus, "", false);
                for (int i = 0; i < myWork_Places.Count; i++)
                {
                    ddlIWork.Items.Add(new ListItem(myWork_Places[i].strWorkPlaceEn, myWork_Places[i].intWorkPlace.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myWork_Places.Clear();
            }

        }

        private void FillVisa()
        {
            List<Sponsors> mySponsors = new List<Sponsors>();
            SponsorsDAL mySponsorsDAL = new SponsorsDAL();
            try
            {
                mySponsors = mySponsorsDAL.GetSponsors(Campus, "", false);
                for (int i = 0; i < mySponsors.Count; i++)
                {
                    ddlVisa.Items.Add(new ListItem(mySponsors[i].strSponsorEn, mySponsors[i].intSponsor.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                mySponsors.Clear();
            }
        }

        private void FillSponsors()
        {
            List<Delegations> myDelegations = new List<Delegations>();
            DelegationsDAL myDelegationsDAL = new DelegationsDAL();
            try
            {
                myDelegations = myDelegationsDAL.GetDelegations(Campus, "", false);
                for (int i = 0; i < myDelegations.Count; i++)
                {
                    ddlSponsor.Items.Add(new ListItem(myDelegations[i].strDelegationDescEn, myDelegations[i].intDelegation.ToString()));
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myDelegations.Clear();
            }

        }

        private void FillCertificates()
        {
            List<Certificates> myCertificates = new List<Certificates>();
            CertificatesDAL myCertificatesDAL = new CertificatesDAL();
            try
            {
                myCertificates = myCertificatesDAL.GetCertificates(Campus, "", false);
                for (int i = 0; i < myCertificates.Count; i++)
                {
                    //ddlQualification.Items.Add(new ListItem(myCertificates[i].strCertificateDescEn, myCertificates[i].intCertificate.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myCertificates.Clear();
            }

        }
        private void FillQInstitutionType()
        {
            List<InstitutionType> myInstitutionType = new List<InstitutionType>();
            InstitutionTypeDAL myInstitutionTypeDAL = new InstitutionTypeDAL();
            try
            {
                myInstitutionType = myInstitutionTypeDAL.GetInstitutionType(Campus, "", false);
                for (int i = 0; i < myInstitutionType.Count; i++)
                {
                    //ddlQInstitutionType.Items.Add(new ListItem(myInstitutionType[i].InstitutionTypeDesc, myInstitutionType[i].InstitutionTypeID.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myInstitutionType.Clear();
            }

        }

        private void FillQEngGrade()
        {
            List<IESOL_Equivalency> myIESOL_Equivalency = new List<IESOL_Equivalency>();
            IESOL_EquivalencyDAL myIESOL_EquivalencyDAL = new IESOL_EquivalencyDAL();
            try
            {
                myIESOL_Equivalency = myIESOL_EquivalencyDAL.GetIESOL_Equivalency(Campus, "", false);
                for (int i = 0; i < myIESOL_Equivalency.Count; i++)
                {
                    //ddlQEngGrade.Items.Add(new ListItem(myIESOL_Equivalency[i].GradeDesc, myIESOL_Equivalency[i].GradeID.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myIESOL_Equivalency.Clear();
            }

        }

        private void FillQEngExamCenter()
        {
            List<EngCertificate_ExamCenter> myEngCertificate_ExamCenter = new List<EngCertificate_ExamCenter>();
            EngCertificate_ExamCenterDAL myEngCertificate_ExamCenterDAL = new EngCertificate_ExamCenterDAL();
            try
            {
                myEngCertificate_ExamCenter = myEngCertificate_ExamCenterDAL.GetEngCertificate_ExamCenter(Campus, "", false);
                for (int i = 0; i < myEngCertificate_ExamCenter.Count; i++)
                {
                    //ddlQEngExamCenter.Items.Add(new ListItem(myEngCertificate_ExamCenter[i].ExamcenterName, myEngCertificate_ExamCenter[i].ExamCenterID.ToString()));
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myEngCertificate_ExamCenter.Clear();
            }
        }
        private void FillQG12Stream()
        {
            List<G12_Stream> myG12_Stream = new List<G12_Stream>();
            G12_StreamDAL myG12_StreamDAL = new G12_StreamDAL();
            try
            {
                myG12_Stream = myG12_StreamDAL.GetG12_Stream(Campus, "", false);
                for (int i = 0; i < myG12_Stream.Count; i++)
                {
                    //ddlQG12_Stream.Items.Add(new ListItem(myG12_Stream[i].G12_StreamDesc, myG12_Stream[i].G12_StreamID.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myG12_Stream.Clear();
            }

        }
        private void FillQMajors()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT intSpecialization,strSpecializationDescEn FROM Lkp_Specializations";
                sSQL += " ORDER BY strSpecializationDescEn";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                while (Rd.Read())
                {
                    //ddlQMajor.Items.Add(new ListItem(Rd["strSpecializationDescEn"].ToString(), Rd["intSpecialization"].ToString()));
                    //ddlQMinor.Items.Add(new ListItem(Rd["strSpecializationDescEn"].ToString(), Rd["intSpecialization"].ToString()));
                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }

        private void FillAdvisers()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT intLecturer, strLecturerDescEn FROM Reg_Lecturers";
                sSQL += " ORDER BY strLecturerDescEn";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                while (Rd.Read())
                {
                    //ddlAdvisor.Items.Add(new ListItem(Rd["strLecturerDescEn"].ToString(), Rd["intLecturer"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }

        private void FillCourses(string sCollege, string sDegree, string sMajor)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT strCourse FROM Majors_Courses";
                sSQL += " WHERE strCollege='" + sCollege + "' AND strDegree='" + sDegree + "' AND strSpecialization='" + sMajor + "'";
                sSQL += " AND strCourse not in('FELECT1','FELECT2','FELECT3','MELECT1','MELECT2','MELECT3')";
                sSQL += " ORDER BY byteOrder";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                //ddlCourses.Items.Clear();

                while (Rd.Read())
                {
                    //ddlCourses.Items.Add(new ListItem(Rd["strCourse"].ToString(), Rd["strCourse"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }

        private void FillTerms()
        {
            List<Semesters> myTerms = new List<Semesters>();
            SemesterDAL myTermsDAL = new SemesterDAL();
            try
            {
                myTerms = myTermsDAL.GetTerms(InitializeModule.EnumCampus.ECTNew, "", true);
                for (int i = 0; i < myTerms.Count; i++)
                {
                    //ddlStatusTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                    //ddlEnrollmentTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myTerms.Clear();
            }
        }

        private void FillMainReasons()
        {
            List<MainReasons> myMainReasons = new List<MainReasons>();
            MainReasonsDAL myMainReasonsDAL = new MainReasonsDAL();
            try
            {
                myMainReasons = myMainReasonsDAL.GetMainReasons(Campus, "", false);
                for (int i = 0; i < myMainReasons.Count; i++)
                {
                    //ddlReason.Items.Add(new ListItem(myMainReasons[i].strMainReasonEn, myMainReasons[i].byteMainReason.ToString()));
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myMainReasons.Clear();
            }
        }

        private void FillMarkSource()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT byteCollege,strCollegeDescEn";
                sSQL += " FROM Lkp_Foreign_Colleges";
                sSQL += " ORDER BY strCollegeDescEn";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                //ddlMSource.Items.Clear();

                while (Rd.Read())
                {
                    //ddlMSource.Items.Add(new ListItem(Rd["strCollegeDescEn"].ToString(), Rd["byteCollege"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }


        }

        //private void FillSubReasons()
        //{
        //    List<SubReasons> mySubReasons = new List<SubReasons>();
        //    SubReasonsDAL mySubReasonsDAL = new SubReasonsDAL();
        //    try
        //    {
        //        mySubReasons = mySubReasonsDAL.GetSubReasons(Campus, "", false);
        //        for (int i = 0; i < mySubReasons.Count; i++)
        //        {
        //            ddlSubReason.Items.Add(new ListItem(mySubReasons[i].strSubReasonEn, mySubReasons[i].byteSubReson.ToString()));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LibraryMOD.ShowErrorMessage(ex);
        //        divMsg.InnerText = ex.Message;
        //    }
        //    finally
        //    {
        //        mySubReasons.Clear();
        //    }
        //}

        #endregion
        protected void btnCreateEmail_Click(object sender, EventArgs e)
        {
            //int iYear = 0;
            //int iSemester = 0;
            //iSemester = Convert.ToInt32(Session["CurrentSemester"].ToString());
            //iYear = Convert.ToInt32(Session["CurrentYear"].ToString());

            //int iRegisteredHours = LibraryMOD.GetCurrentRegisteredCourses(this.Campus, lblStudentId.Text, iYear, iSemester);

            //if (iRegisteredHours == 0)
            //{
            //    divMsg.InnerText = "Student must register courses before creating email.";
            //    return;
            //}
            ////======= Generate Student email
            //CreateStudentEmail();
            //if (txtECTEmail.Text.Length < 17)
            //{
            //    return;
            //}
            ////======= Create email in Office365 & AD 
            //CreateStudentEmailAD(this.Campus, lblStudentId.Text);

            ////======= Create Moodle Account
            //if (ClsMoodleAPI.CreateUpdateMoodleAccount(txtECTEmail.Text, lblStudentId.Text) == InitializeModule.SUCCESS_RET)
            //{
            //    divMsg.InnerText += " & Moodle";
            //}
            ////======== Enroll student in Moodle courses
            //if (ClsMoodleAPI.EnrollStudentinMoodleCourses(txtECTEmail.Text, lblStudentId.Text) == InitializeModule.SUCCESS_RET)
            //{
            //    divMsg.InnerText += ", Student enrolled in Moodle courses";
            //}
            ////======= Create Zoom Account
            //string sFirstName = txtFNameEn.Text + " " + txtLNameEn.Text;
            //string sLastName = " - " + lblStudentId.Text;
            //CreateZoomAccount(txtECTEmail.Text, sFirstName, sLastName);

        }

        protected void btnGetEID_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                    InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
            {               
                lbl_Msg.Text = "Sorry you cannot update students";
                div_msg.Visible = true;
                return;
            }
            Response.Redirect("EIDInterface.aspx?CallerID=STD");
        }

        //Start Student Information
        protected void lnk_Save_Click(object sender, EventArgs e)
        {
            try
            {

                int iEffected = 0;
                TimeSpan difference = DateTime.Today - Convert.ToDateTime(txtBirthDate.Text);

                var days = difference.TotalDays;

                if (days / 365 < 16)
                {                    
                    lbl_Msg.Text = "Invalid birth date - Age less than 16 years";
                    div_msg.Visible = true;
                    return;
                }    

                if (txtIDNo.Text.Length < 15)
                {
                    txtIDNo.Text = "999999999999999";
                    lbl_Msg.Text = "EID need to be scanned";
                    div_msg.Visible = true;
                }
                else if (txtIDNo.Text.Length > 15)
                {
                    txtIDNo.Text = txtIDNo.Text.Replace("-", "");
                }

                if (txtPhone1.Text.Length < 10)
                {
                    lbl_Msg.Text = "Invalid Phone number, shold be at least 10 numbers: [0001234567]";
                    div_msg.Visible = true;
                    return;
                }
                txtPhone1.Text = LibraryMOD.CleanPhone(txtPhone1.Text);
                txtPhone2.Text = LibraryMOD.CleanPhone(txtPhone2.Text);

                if (hdnSerial.Value == "")//New
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.AddNew, CurrentRole) != true)
                    {
                        lbl_Msg.Text = "Sorry you cannot add students";
                        div_msg.Visible = true;
                        return;
                    }
                    iEffected = StudentDS.Insert();
                    if (iEffected > 0)
                    {
                        lbl_Msg.Text = "Student Added Successfully";
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        div_msg.Visible = true;
                        //QualificationDS.DataBind();
                        //grdQualification.DataBind();
                        //DocumentsDS.DataBind();
                        //grdDocs.DataBind();
                        //DocsEditDS.DataBind();
                        //EnrollmentDS.DataBind();
                        Session["StudentSerialNo"] = hdnSerial.Value;
                    }

                }
                else//Update
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                    {
                        lbl_Msg.Text = "Sorry you cannot update students";
                        div_msg.Visible = true;
                        return;
                    }

                    iEffected = StudentDS.Update();
                    if (iEffected > 0)
                    {
                        lbl_Msg.Text = "Student Saved Successfully";
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        div_msg.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
        }
        protected void StudentDS_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            try
            {
                DbCommand command = e.Command;
                hdnSerial.Value = command.Parameters["@RETURN_VALUE"].Value.ToString();
                Session["StudentSerialNo"] = int.Parse(hdnSerial.Value);
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
        }
        protected void lnk_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.Delete, CurrentRole) != true)
                {                    
                    lbl_Msg.Text = "Sorry you cannot delete students";
                    div_msg.Visible = true;
                    return;
                }

                if (hdnSerial.Value != "")
                {
                    int iEffected = 0;

                    //iEffected = Delete_Marks(lblStudentId.Text);
                    //iEffected += EnrollmentDS.Delete();
                    //iEffected += DocsEditDS.Delete();

                    //iEffected += QualificationDS.Delete();

                    iEffected += StudentDS.Delete();

                    Empty_Controls();

                    lbl_Msg.Text = "Student Deleted Successfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    div_msg.Visible = true;


                }
                else
                {
                    lbl_Msg.Text = "Select a Student Please";
                    div_msg.Visible = true;
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
        }

        protected void lnk_Cancel_Click(object sender, EventArgs e)
        {
            Session["StudentSerialNo"] = null;
            Response.Redirect("StudentSearch");
        }
        public void New()
        {
            try
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.AddNew, CurrentRole) != true)
                {
                    //Server.Transfer("Authorization.aspx");
                    //return;
                }
                Empty_Controls();
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
        }
        //End Student Information

        //Start Academic Information
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            try
            {

                string sSender = e.Item.Value;

                if (sSender != "4")
                {
                    if (hdnSerial.Value == "")
                    {                        
                        lbl_Msg.Text = "Select or add a student please...";
                        div_msg.Visible = true;
                        return;
                    }
                }
                System.Threading.Thread.Sleep(500);

                switch (sSender)
                {
                    case "0"://Qualification

                        MultiTabs.ActiveViewIndex = 0;

                        break;
                    case "1"://Enrollment

                        MultiTabs.ActiveViewIndex = 1;


                        break;
                    case "2"://Document

                        MultiTabs.ActiveViewIndex = 2;

                        break;
                    case "3"://Marks

                        MultiTabs.ActiveViewIndex = 3;

                        break;
                    case "4"://Search

                        //ddlCampus.SelectedValue = ((int)Campus).ToString();
                        MultiTabs.ActiveViewIndex = 4;
                        //RunSerach();
                        break;
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
        }

        protected void UndoQ_btn_Click(object sender, EventArgs e)
        {

        }

        protected void SaveQ_btn_Click(object sender, EventArgs e)
        {

        }

        protected void grdQualification_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdQualification_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void NewQ_btn_Click(object sender, EventArgs e)
        {

        }

        protected void ESLEX_btn_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteQ_btn_Click(object sender, EventArgs e)
        {

        }

        protected void ddlQualification_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlQCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlQEngGrade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}