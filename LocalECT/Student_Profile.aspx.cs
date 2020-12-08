using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint;
using ListItem = System.Web.UI.WebControls.ListItem;

class ENGCourse
{
    string sCourse;

    public string SCourse
    {
        get { return sCourse; }
        set { sCourse = value; }
    }
    string sGrade;

    public string SGrade
    {
        get { return sGrade; }
        set { sGrade = value; }
    }

}
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
                            chkActive.Enabled = isAllowed;
                            chkMissing.Enabled = isAllowed;
                        }
                        bResult = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_VerfiyTOEFL_HS,
                        InitializeModule.enumPrivilege.ShowAdmissionVerification, CurrentRole);
                        chkAdmissionVerfication.Visible = bResult;
                        txtAdmissionComments.Visible = bResult;
                        lblAdmissionVerfication.Visible = bResult;
                        lblAdmissionComments.Visible = bResult;

                        bResult = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_VerfiyTOEFL_HS,
                       InitializeModule.enumPrivilege.ShowRegistrarVerification, CurrentRole);
                        chkRegistrarVerfication.Visible = bResult;
                        txtRegistrarComments.Visible = bResult;
                        lblRegistrarVerification.Visible = bResult;
                        lblRegistrarComments.Visible = bResult;

                        //Update
                        if (Request.QueryString["sid"] != null && Request.QueryString["sid"] != "")
                        {
                            Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                            if (Campus.ToString() == "Males")
                            {
                                rbnGender.SelectedValue = "1";
                                rbnGender.Enabled = false;
                            }
                            else
                            {
                                rbnGender.SelectedValue = "0";
                                rbnGender.Enabled = false;
                            }
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
                            ddlMajor.Enabled = false;
                            ddlEnrollmentTerm.Enabled = false;
                        }
                        //New Student
                        else
                        {
                            if (Request.QueryString["cmp"] != null && Request.QueryString["cmp"] != "")
                            {
                                if (Request.QueryString["cmp"] == "m")
                                {
                                    Campus = InitializeModule.EnumCampus.Males;
                                    rbnGender.SelectedValue = "1";
                                    rbnGender.Enabled = false;
                                }
                                else
                                {
                                    Campus = InitializeModule.EnumCampus.Females;
                                    rbnGender.SelectedValue = "0";
                                    rbnGender.Enabled = false;
                                }
                            }
                            else
                            {
                                Campus = InitializeModule.EnumCampus.Females;
                                rbnGender.SelectedValue = "0";
                                rbnGender.Enabled = false;
                            }

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

                QCityDS.ConnectionString = sConn;
                BirthCityDS.ConnectionString = sConn;
                ResidentCityDS.ConnectionString = sConn;
                HomeCityDS.ConnectionString = sConn;
                SubReasonDS.ConnectionString = sConn;
                SearchDS.ConnectionString = sConn;
                StudentDS.ConnectionString = sConn;
                EnrollmentDS.ConnectionString = sConn;
                QualificationDS.ConnectionString = sConn;
                Q_Audit.ConnectionString = sConn;
                DocumentsDS.ConnectionString = sConn;
                DocsEditDS.ConnectionString = sConn;
                MajorDS.ConnectionString = sConn;
                MarksDS.ConnectionString = sConn;
                WMajorDS.ConnectionString = sConn;


                if (Session["CurrentStudent"] == null)//Insert  //string.IsNullOrEmpty(Session["CurrentStudent"].ToString())
                {
                    ddlWMajor1.Enabled = true;
                    ddlWMajor2.Enabled = true;
                    ddlWMajor3.Enabled = true;
                }
                else
                {
                    bool isAllowed = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                    InitializeModule.enumPrivilege.ChangePreferredMajor, CurrentRole);
                    ddlWMajor1.Enabled = isAllowed;
                    ddlWMajor2.Enabled = isAllowed;
                    ddlWMajor3.Enabled = isAllowed;

                }

                if (!IsPostBack)
                {
                    FillDDLs();
                    bool isAllowed = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                           InitializeModule.enumPrivilege.StatusGraduated, CurrentRole);

                    if (ddlStatus.SelectedValue == "3" && isAllowed == true)
                    {
                        chkCompleteBAFromOtherInstitution.Enabled = isAllowed;
                        chkCompleteMasterFromOtherInstitution.Enabled = isAllowed;
                    }



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
                        lblIsVerfiedFromRegistrar.Text = "Warning: Unverified from the Registrar";
                        lblIsVerfiedFromRegistrar.ForeColor = Color.Red;
                    }
                    if (iVerificationResult == InitializeModule.TRUE_VALUE)
                    {
                        lblIsVerfiedFromRegistrar.Text = "Verified from the Registrar";
                        lblIsVerfiedFromRegistrar.ForeColor = Color.Green;  //#009933
                    }
                    if (iVerificationResult == 2)
                    {
                        lblIsVerfiedFromRegistrar.Text = "Verification not mandatory for current file";
                        lblIsVerfiedFromRegistrar.ForeColor = Color.Green;  //#009933
                    }

                    if (txtECTEmail.Text != "" && txtECTEmail.Text != null)
                    {
                        btnCreateEmail.Visible = false;
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
        private void GetStudent(int iSerial)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                if (iSerial == 0)
                {
                    MultiTabs.ActiveViewIndex = 4;
                    lbl_Msg.Text = "Sorry this student has no ID yet (Not Enrolled),Use the following search , Then Select it.";
                    div_msg.Visible = true;
                    txtBirthDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
                    txtExpiry.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
                    txtMilitaryServiceDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
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
                    ddlReason.SelectedValue = "0";
                    SubReasonDS.DataBind();
                    ddlSubReason.DataBind();
                    ddlType.SelectedValue = "0";
                    MajorDS.DataBind();
                    ddlMajor.DataBind();
                    ddlMajor.SelectedValue = "010120";
                    ddlEnrollmentTerm.SelectedValue = (iRegYear * 10 + iRegSem).ToString();
                    ddlStatus.SelectedValue = "0";
                    ddlStatusTerm.SelectedValue = (iRegYear * 10 + iRegSem).ToString();
                    ddlSubReason.SelectedValue = "0";
                    ddlAdvisor.SelectedValue = "1000";
                    lblDateEnrolled.Text = "";
                    lblDateStatus.Text = "";
                    lblReference.Text = "";
                    lblStudentId.Text = "";
                    lblECTId.Text = "";
                    txtNote.Text = "";
                    txtReferredBy.Text = "";
                    chkActive.Checked = true;
                    chkMissing.Checked = false;

                    txtMilitaryServiceDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    ChkIsMilitaryService.Checked = false;

                    ddlWMajor1.SelectedValue = "0";
                    ddlWMajor2.SelectedValue = "0";
                    ddlWMajor3.SelectedValue = "0";
                    chkCompleteBAFromOtherInstitution.Checked = false;
                    chkCompleteMasterFromOtherInstitution.Checked = false;
                    txtEnrollmentSource.Text = "";
                    ddlEnrollmentSource.SelectedValue = "0";
                    ddlEnrollmentSource2.SelectedValue = "0";
                    ddlRegisteredThrough.SelectedValue = "1";

                    txtOpportunityID.Text = "0";
                    txtContactID.Text = "0";
                    ddlAcceptance.SelectedIndex = 0;
                    ddlAcceptanceCondition.SelectedIndex = 0;
                    ddlAdmissionStatus.SelectedIndex = 0;

                    mtvQualification.ActiveViewIndex = 0;
                    MultiTabs.ActiveViewIndex = 0;
                    rd.Close();
                    return;
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

                    MajorDS.DataBind();
                    ddlMajor.DataBind();
                    ddlMajor.SelectedValue = sMajor;

                    ddlType.SelectedValue = rd["byteStudentType"].ToString();
                    chkActive.Checked = Convert.ToBoolean(rd["bActive"]);
                    chkMissing.Checked = Convert.ToBoolean(rd["bContinue"]);
                    if (rd["dateMilitaryService"].ToString() == "")
                    {
                        txtMilitaryServiceDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    }
                    else
                    {
                        txtMilitaryServiceDate.Text = string.Format("{0:yyyy-MM-dd}", rd["dateMilitaryService"]);
                    }

                    ChkIsMilitaryService.Checked = Convert.ToBoolean(rd["isMilitaryService"]);

                    iYear = Convert.ToInt32(rd["intStudyYear"]);
                    iSem = Convert.ToInt32(rd["byteSemester"]);
                    iTerm = iYear * 10 + iSem;
                    ddlEnrollmentTerm.SelectedValue = iTerm.ToString();

                    int iStatus = 0;

                    if (!rd["byteCancelReason"].Equals(DBNull.Value))
                    {
                        iStatus = Convert.ToInt32(rd["byteCancelReason"]);
                    }
                    if (iStatus > 0)
                    {
                        ddlStatus.SelectedValue = iStatus.ToString();
                        iYear = Convert.ToInt32(rd["intGraduationYear"]);
                        iSem = Convert.ToInt32(rd["byteGraduationSemester"]);
                        iTerm = iYear * 10 + iSem;
                        ddlStatusTerm.SelectedValue = iTerm.ToString();

                        ddlReason.SelectedValue = rd["byteMainReason"].ToString();
                        SubReasonDS.DataBind();
                        ddlSubReason.DataBind();
                        ddlSubReason.SelectedValue = rd["byteSubReason"].ToString();
                        lblDateStatus.Text = string.Format("{0:yyyy-MM-dd}", rd["dateGraduation2"]);
                        if (iStatus == 3)
                        {
                            chkCompleteBAFromOtherInstitution.Enabled = true;
                            chkCompleteMasterFromOtherInstitution.Enabled = true;
                        }
                        chkCompleteBAFromOtherInstitution.Checked = Convert.ToBoolean(rd["IsCompleteBAFromOtherInstitution"]);
                        chkCompleteMasterFromOtherInstitution.Checked = Convert.ToBoolean(rd["IsCompleteMasterFromOtherInstitution"]);

                    }
                    else
                    {
                        ddlStatus.SelectedValue = null;
                        ddlStatusTerm.SelectedValue = null;
                        ddlReason.SelectedValue = "0";
                        SubReasonDS.DataBind();
                        ddlSubReason.DataBind();
                        ddlSubReason.SelectedValue = "0";
                        lblDateStatus.Text = "";
                        chkCompleteBAFromOtherInstitution.Checked = false;
                        chkCompleteMasterFromOtherInstitution.Enabled = false;
                    }

                    ddlEnrollmentSource.SelectedValue = rd["iEnrollmentSource"].ToString();
                    ddlEnrollmentSource2.SelectedValue = rd["iEnrollmentSource2"].ToString();

                    txtEnrollmentSource.Text = rd["sEnrollmentNotes"].ToString();

                    ddlRegisteredThrough.SelectedValue = rd["iRegisteredThrough"].ToString();

                    ddlWMajor1.SelectedValue = rd["WantedMajorID"].ToString();
                    ddlWMajor2.SelectedValue = rd["WantedMajorID2"].ToString();
                    ddlWMajor3.SelectedValue = rd["WantedMajorID3"].ToString();
                    ddlAdvisor.SelectedValue = rd["intAdvisor"].ToString();
                    lblDateEnrolled.Text = string.Format("{0:yyyy-MM-dd}", rd["dateApplication"]);
                    sSID = rd["lngStudentNumber"].ToString();
                    lblStudentId.Text = sSID;
                    lblReference.Text = rd["sReference"].ToString();
                    lblECTId.Text = rd["sECTId"].ToString();
                    txtNote.Text = rd["strNotes"].ToString();

                    txtReferredBy.Text = rd["sReferredBy"].ToString();

                    if (rd["sLastDegree"].Equals(DBNull.Value))
                    {
                        ddlLastDegree.SelectedValue = "0";
                    }
                    else
                    {
                        ddlLastDegree.SelectedValue = rd["sLastDegree"].ToString();
                    }
                    ddlLastInistitution.SelectedValue = rd["byteLastDegreeInistitution"].ToString();
                    ddlLastCountry.SelectedValue = rd["byteLastDegreeCountry"].ToString();
                    txtLastCGPA.Text = string.Format("{0:f}", rd["curLastCGPA"]);
                    txtLastYear.Text = rd["intLastDegreeYear"].ToString();

                    if (rd["LHEEquivalencyIndicator"].Equals(DBNull.Value))
                    {
                        ddlEquivalencyIndicator.SelectedValue = "M";
                    }
                    else
                    {
                        ddlLHEquivalencyIndicator.SelectedValue = rd["LHEEquivalencyIndicator"].ToString();
                    }
                    txtLHEquivalencyAppNo.Text = rd["LHEEquivalencyAppNo"].ToString();
                    txtORCID.Text = rd["Std_ORCID"].ToString();

                    //iContactID,iOpportunityID,iAcceptanceType
                    txtOpportunityID.Text = rd["iOpportunityID"].ToString();
                    txtContactID.Text = rd["iContactID"].ToString();
                    ddlAcceptance.SelectedValue = rd["iAcceptanceType"].ToString();
                    ddlAcceptanceCondition.SelectedValue = rd["iAcceptanceCondition"].ToString();
                    ddlAdmissionStatus.SelectedValue = rd["iAdmissionStatus"].ToString();

                    MultiTabs.ActiveViewIndex = 1;
                    grdQualification.DataBind();
                    grdDocs.DataBind();
                }


                if (lblStudentId.Text == "")
                {
                    Session["CurrentStudent"] = null;
                }
                else
                {
                    Session["CurrentStudent"] = sSID;
                    grdMarks.DataBind();
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
                    if (Campus.ToString() == "Males")
                    {
                        lblUnified.Text = "M" + Rd["iUnifiedID"].ToString();
                    }
                    else
                    {
                        lblUnified.Text = "F" + Rd["iUnifiedID"].ToString();
                    }
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
                    //ddlSponsor.SelectedValue = Rd["intDelegation"].ToString();
                    drp_determination.SelectedValue = Rd["intDelegation"].ToString();
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

                    if (System.IO.File.Exists(Server.MapPath(sURL)))
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
                txtMilitaryServiceDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);

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
                txtNote.Text = "";
                txtReferredBy.Text = "";
                txtCompany.Text = "NA";
                txtEmployeremail.Text = "xyz@xyz.com";
                txtEmployerIndustry.Text = "NA";
                txtEmployerName.Text = "NA";
                txtEmployerPhone.Text = "NA";
                txtEmployerPos.Text = "NA";
                ddlEmployerCountry.SelectedValue = "0";
                ddlEmployerEmirate.SelectedValue = "0";
                ddlLastDegree.SelectedValue = "0";
                ddlLastInistitution.SelectedValue = "-1";
                ddlLastCountry.SelectedValue = "-1";
                txtLastYear.Text = "";
                txtLastCGPA.Text = "";
                ddlLHEquivalencyIndicator.SelectedIndex = 0;
                txtLHEquivalencyAppNo.Text = "";
                txtORCID.Text = "NA";

                txtOpportunityID.Text = "0";
                txtContactID.Text = "0";
                ddlAcceptance.SelectedIndex = 0;
                ddlAcceptanceCondition.SelectedIndex = 0;
                ddlAdmissionStatus.SelectedIndex = 0;

                ddlBirthCountry.SelectedValue = "1";
                ddlEnrollmentTerm.SelectedValue = (iRegYear * 10 + iRegSem).ToString();

                ddlHomeCountry.SelectedValue = "1";
                //ddlIdentityType.SelectedValue = "0";
                ddlIWork.SelectedValue = "0";
                ddlEmploymentSector.SelectedValue = "0";
                ddlNationalityofMother.SelectedValue = "1";

                ddlMaritalStatus.SelectedValue = "0";

                ddlLanguage.SelectedValue = "1";
                ddlType.SelectedValue = "0";
                MajorDS.DataBind();
                ddlMajor.DataBind();
                ddlMajor.SelectedValue = "010120";
                ddlNationality.SelectedValue = "1";
                ddlReason.SelectedValue = "0";
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
                drp_determination.SelectedValue = "0";
                ddlStatus.SelectedIndex = -1;
                ddlStatusTerm.SelectedIndex = -1;
                SubReasonDS.DataBind();
                ddlSubReason.DataBind();
                ddlSubReason.SelectedValue = "0";
                ddlVisa.SelectedValue = "0";
                ddlAdvisor.SelectedValue = "1000";
                lblDateEnrolled.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
                lblDateStatus.Text = "";
                lblReference.Text = "";
                lblStudentId.Text = "";
                lblECTId.Text = "";

                BirthCityDS.DataBind();
                ddlBirthCity.DataBind();
                ddlBirthCity.SelectedValue = "1";
                HomeCityDS.DataBind();
                ddlQCity.DataBind();
                ddlQEngGrade.DataBind();


                ddlQEngExamCenter.DataBind();


                ddlHomeCity.DataBind();
                ddlHomeCity.SelectedValue = "1";
                ResidentCityDS.DataBind();
                ddlResidentCity.DataBind();
                ddlResidentCity.SelectedValue = "1";

                ChkIsMilitaryService.Checked = false;
                mtvQualification.ActiveViewIndex = 0;
                MultiTabs.ActiveViewIndex = -1;
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
                    ddlEmployerEmirate.Items.Add(new System.Web.UI.WebControls.ListItem(Rd["strEmirateEn"].ToString(), Rd["byteEmirate"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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

                ddlHSSystem.Items.Clear();

                while (Rd.Read())
                {
                    ddlHSSystem.Items.Add(new System.Web.UI.WebControls.ListItem(Rd["sSystem"].ToString(), Rd["iSerial"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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

                ddlLastDegree.Items.Clear();

                while (Rd.Read())
                {
                    ddlLastDegree.Items.Add(new ListItem(Rd["strDegreeDescEn"].ToString(), Rd["strDegree"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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

                ddlLastInistitution.Items.Clear();

                while (Rd.Read())
                {
                    ddlLastInistitution.Items.Add(new ListItem(Rd["strCollegeDescEn"].ToString(), Rd["byteCollege"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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

                ddlStatus.Items.Clear();
                while (Rd.Read())
                {
                    ddlStatus.Items.Add(new ListItem(Rd["Status"].ToString(), Rd["byteReason"].ToString()));
                }
                Rd.Close();

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                    ddlQCountry.Items.Add(new ListItem(myCountries[i].strCountryDescEn, myCountries[i].byteCountry.ToString()));
                    ddlBirthCountry.Items.Add(new ListItem(myCountries[i].strCountryDescEn, myCountries[i].byteCountry.ToString()));
                    ddlEmployerCountry.Items.Add(new ListItem(myCountries[i].strCountryDescEn, myCountries[i].byteCountry.ToString()));
                    ddlLastCountry.Items.Add(new ListItem(myCountries[i].strCountryDescEn, myCountries[i].byteCountry.ToString()));
                }

            }
            catch (Exception ex)
            {


                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
            }
            finally
            {
                myDelegations.Clear();
            }

            string constr = ConfigurationManager.ConnectionStrings["ECTDataMales"].ConnectionString;
            SqlConnection sc = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from Lkp_Determination_Type", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_determination.DataTextField = "DeterminationType";
                drp_determination.DataValueField = "iSerial";
                drp_determination.DataSource = dt;
                drp_determination.DataBind();
            }
            catch (Exception ex)
            {
                sc.Close();
                LibraryMOD.ShowErrorMessage(ex);
            }
            finally
            {
                sc.Close();
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
                    ddlQualification.Items.Add(new ListItem(myCertificates[i].strCertificateDescEn, myCertificates[i].intCertificate.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                    ddlQInstitutionType.Items.Add(new ListItem(myInstitutionType[i].InstitutionTypeDesc, myInstitutionType[i].InstitutionTypeID.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                    ddlQEngGrade.Items.Add(new ListItem(myIESOL_Equivalency[i].GradeDesc, myIESOL_Equivalency[i].GradeID.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                    ddlQEngExamCenter.Items.Add(new ListItem(myEngCertificate_ExamCenter[i].ExamcenterName, myEngCertificate_ExamCenter[i].ExamCenterID.ToString()));
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                    ddlQG12_Stream.Items.Add(new ListItem(myG12_Stream[i].G12_StreamDesc, myG12_Stream[i].G12_StreamID.ToString()));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                    ddlQMajor.Items.Add(new ListItem(Rd["strSpecializationDescEn"].ToString(), Rd["intSpecialization"].ToString()));
                    //ddlQMinor.Items.Add(new ListItem(Rd["strSpecializationDescEn"].ToString(), Rd["intSpecialization"].ToString()));
                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                    ddlAdvisor.Items.Add(new ListItem(Rd["strLecturerDescEn"].ToString(), Rd["intLecturer"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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

                ddlCourses.Items.Clear();

                while (Rd.Read())
                {
                    ddlCourses.Items.Add(new ListItem(Rd["strCourse"].ToString(), Rd["strCourse"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                    ddlStatusTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                    ddlEnrollmentTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
                    ddlReason.Items.Add(new ListItem(myMainReasons[i].strMainReasonEn, myMainReasons[i].byteMainReason.ToString()));
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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

                ddlMSource.Items.Clear();

                while (Rd.Read())
                {
                    ddlMSource.Items.Add(new ListItem(Rd["strCollegeDescEn"].ToString(), Rd["byteCollege"].ToString()));

                }
                Rd.Close();


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //lbl_Msg.Text = ex.Message;
                //div_msg.Visible = true;
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
            int iYear = 0;
            int iSemester = 0;
            iSemester = Convert.ToInt32(Session["CurrentSemester"].ToString());
            iYear = Convert.ToInt32(Session["CurrentYear"].ToString());

            int iRegisteredHours = LibraryMOD.GetCurrentRegisteredCourses(this.Campus, lblStudentId.Text, iYear, iSemester);

            if (iRegisteredHours == 0)
            {
                lbl_Msg.Text = "Student must register courses before creating email.";
                div_msg.Visible = true;
                return;
            }
            //======= Generate Student email
            CreateStudentEmail();
            if (txtECTEmail.Text.Length < 17)
            {
                return;
            }
            //======= Create email in Office365 & AD 
            CreateStudentEmailAD(this.Campus, lblStudentId.Text);

            //======= Create Moodle Account
            if (ClsMoodleAPI.CreateUpdateMoodleAccount(txtECTEmail.Text, lblStudentId.Text) == InitializeModule.SUCCESS_RET)
            {
                lbl_Msg.Text += " & Moodle";
            }
            //======== Enroll student in Moodle courses
            if (ClsMoodleAPI.EnrollStudentinMoodleCourses(txtECTEmail.Text, lblStudentId.Text) == InitializeModule.SUCCESS_RET)
            {
                lbl_Msg.Text += ", Student enrolled in Moodle courses";
            }
            //======= Create Zoom Account
            string sFirstName = txtFNameEn.Text + " " + txtLNameEn.Text;
            string sLastName = " - " + lblStudentId.Text;
            CreateZoomAccount(txtECTEmail.Text, sFirstName, sLastName);
            div_msg.Visible = true;
            div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
        }
        private void CreateStudentEmail()
        {
            //if (txtECTEmail.Text.Length > 17) 
            //{
            //    return;
            //    btnCreateEmail.Enabled = false;
            //}
            string sFName = "";
            string sECTEmail = "";
            if (txtLNameEn.Text.Trim().Length <= 1)
            {
                lbl_Msg.Text = "Please enter correct name in (Last Name) ";
                div_msg.Visible = true;
                return;
            }


            int iUnifiedID = LibraryMOD.GetMaxUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value), out sFName);
            //update Unified ID
            if (iUnifiedID > 0)
            {
                LibraryMOD.UpdateStudentUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value), iUnifiedID);
                //check reference number
                if (LibraryMOD.UpdateStudentUnifiedIDIfHasRefID(Campus, Convert.ToInt32(hdnSerial.Value)) == true)
                {
                    //Get updated UnifiedID
                    iUnifiedID = LibraryMOD.GetUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value));
                }
            }
            else
            {
                iUnifiedID = LibraryMOD.GetUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value), out sFName);
                if (iUnifiedID == 0)
                {
                    iUnifiedID = LibraryMOD.GetMaxUnifiedID_withoutCheckRefID(Campus, Convert.ToInt32(hdnSerial.Value), out sFName);
                }
                LibraryMOD.UpdateStudentUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value), iUnifiedID);
            }
            //Update student email    
            sECTEmail = sFName.ToString().Trim().Replace(" ", string.Empty) + iUnifiedID.ToString().PadLeft(6, Convert.ToChar("0")) + "@ect.ac.ae";
            if (LibraryMOD.UpdateStudentEmail(Campus, Convert.ToInt32(hdnSerial.Value), sECTEmail) == true)
            {
                lbl_Msg.Text = "Student email has been created successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;
                txtECTEmail.Text = sECTEmail;
            }
            else
            {
                lbl_Msg.Text = "The student's email has not been created";
                div_msg.Visible = true;
            }
            btnCreateEmail.Enabled = false;
        }
        public void CreateStudentEmailAD(InitializeModule.EnumCampus Campus, string sStudentID)
        {
            string sSQL = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Con = new SqlConnection(myConnection_String.Conn_string);
            try
            {
                sSQL = "SELECT  SD.strFirstDescEn + ' ' + SD.strSecondDescEn AS [Given_Name]";
                sSQL += ", ' - ' + REPLACE(A.lngStudentNumber, '.', '') AS Surname";
                sSQL += ", SD.strFirstDescEn + ' ' + SD.strSecondDescEn AS [Display_Name]";
                sSQL += ", SD.sECTemail AS [Email_Addresses], LEFT(SD.sECTemail, LEN(SD.sECTemail) - 10) AS [Sam_Account_Name]";
                sSQL += ", 'ect@12345' AS Password, 'ect@12345' AS [User_Password], 'ect@12345' AS ChangePasswordOnNextLogon";
                sSQL += ", 'SMTP:' + SD.sECTemail AS [Proxy_Addresses], 'Student' AS [Personal_Title]";
                sSQL += ", M.strMajor AS Department, (CASE WHEN iCampus = 1 THEN 'Males Campus' ";
                sSQL += " WHEN iCampus = 2 THEN 'Females Campus' ";
                sSQL += " WHEN iCampus = 3 AND bSex = 1 THEN 'Media-Males Campus' ";
                sSQL += " WHEN iCampus = 3 AND bSex = 0 THEN 'Media-Females Campus' END) AS Description";
                sSQL += ", 'Emirates College of Technology' AS Company ";
                sSQL += " FROM Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ";
                sSQL += " ON A.lngSerial = SD.lngSerial INNER JOIN Reg_Specializations AS M ";
                sSQL += " ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree ";
                sSQL += " AND A.strSpecialization = M.strSpecialization LEFT OUTER JOIN Last_Time_Registered ";
                sSQL += " ON A.lngStudentNumber = Last_Time_Registered.Student LEFT OUTER JOIN Lkp_Reasons ";
                sSQL += " ON A.byteCancelReason = Lkp_Reasons.byteReason ";
                sSQL += " WHERE  (SD.sECTemail IS NOT NULL) AND SD.sECTemail <> '' ";
                //if (sStudentID.Contains("M"))
                //{
                //    sSQL += " AND (SD.bSex = 1)";
                //}
                //else
                //{
                //    sSQL += " AND (SD.bSex = 0)";
                //}
                sSQL += " AND (SD.IsEmailCreationRequired = 1) ";
                sSQL += " AND A.lngStudentNumber ='" + sStudentID + "'";
                sSQL += " ORDER BY SD.iUnifiedID";

                SqlCommand cmd = new SqlCommand(sSQL, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                Con.Open();
                da.Fill(dt);
                Con.Close();

                if (dt.Rows.Count > 0)
                {
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{  
                    int i = 0;
                    CreateUserEmailAD(dt.Rows[i]["Given_Name"].ToString(), dt.Rows[i]["Surname"].ToString(), dt.Rows[i]["Display_Name"].ToString(), dt.Rows[i]["Description"].ToString(), dt.Rows[i]["Email_Addresses"].ToString(), dt.Rows[i]["Sam_Account_Name"].ToString(), dt.Rows[i]["Department"].ToString(), dt.Rows[i]["Company"].ToString(), true);
                    //}
                    UpdateEmailCreationRequired(Con, Convert.ToInt32(hdnSerial.Value));
                    lbl_Msg.Text = "Students Email Created Successfully in Office365";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    div_msg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Con.Close();
                throw ex;
            }
            finally
            {
                Con.Close();
            }
        }
        public void UpdateEmailCreationRequired(SqlConnection Con, int iSerialNo)
        {

            string sSQL = "";

            try
            {
                sSQL = "UPDATE Reg_Students_Data set IsEmailCreationRequired = 0";
                sSQL += " WHERE IsEmailCreationRequired = 1";
                sSQL += " AND lngSerial=" + iSerialNo;

                SqlCommand cmd = new SqlCommand(sSQL, Con);
                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                throw ex;
            }
            finally
            {
                Con.Close();
            }
        }
        public int CreateUserEmailAD(string firstName, string lastName, string displayname, string description, string emailAddress, string userLogonName, string department, string company, bool enabled)
        {
            string Ounames = "Females";
            if (description == "Females Campus")
            {
                Ounames = "Females";
            }
            else
            {
                Ounames = "Males";
            }
            // Creating the PrincipalContext
            PrincipalContext principalContext = null;
            string adminusername = "ets.services.admin";
            string adminpassword = "Ser71ces@328";
            string userdomainLdappath = "OU=" + Ounames + ",OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            string Server = "ectuae";
            try
            {
                principalContext = new PrincipalContext(ContextType.Domain, Server, userdomainLdappath, adminusername, adminpassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Check if user object already exists in the AD
            UserPrincipal usr = UserPrincipal.FindByIdentity(principalContext, userLogonName);
            if (usr != null)
            {
                //User Already Exists
            }
            else
            {
                //Create New User
                DirectoryEntry myLdapConnection = DirectEntry(Ounames);
                DirectoryEntry user = myLdapConnection.Children.Add("CN=" + userLogonName + " ", "user");

                // User name (Domain-Based)   
                user.Properties["userprincipalname"].Add(userLogonName + "@" + "ectuae.com");

                // User name (Older-Systems)  
                user.Properties["samaccountname"].Add(userLogonName);

                // Surname  
                user.Properties["sn"].Add(lastName);

                // Given-Name  
                user.Properties["givenname"].Add(firstName);

                // Display-Name  
                user.Properties["displayname"].Add(displayname);

                // Description  
                user.Properties["description"].Add(description);

                // E-mail  
                user.Properties["mail"].Add(emailAddress);

                // Department  
                user.Properties["department"].Add(department);

                // Company  
                user.Properties["company"].Add(company);

                // Personal-Title  
                user.Properties["personalTitle"].Add("Student");

                // Proxy-Addresses  
                user.Properties["proxyAddresses"].Add("SMTP:" + emailAddress + "");

                // User-Password  
                user.Properties["userPassword"].Add("ect@12345");

                user.CommitChanges();
                user.Invoke("SetPassword", "ect@12345");

                //Force Password Change on Next Login
                //user.Properties["pwdLastSet"].Value = 0;

                if (enabled)
                    user.Invoke("Put", new object[] { "userAccountControl", "544" });

                user.CommitChanges();

                //AddUserToGroup(userLogonName, "Males");
                AddUserToGroup(userLogonName, Ounames);
            }
            return 0;
        }
        public static DirectoryEntry DirectEntry(string ouname)
        {
            DirectoryEntry ldapConnection = new DirectoryEntry("rch");
            //ldapConnection.Path = "LDAP://OU=Males,OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            ldapConnection.Path = "LDAP://OU=" + ouname + ",OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            ldapConnection.Username = "ets.services.admin";
            ldapConnection.Password = "Ser71ces@328";
            return ldapConnection;
        }
        public static void AddUserToGroup(string userId, string groupName)
        {
            string adminusername = "ets.services.admin";
            string adminpassword = "Ser71ces@328";
            string Server = "ectuae";
            //string userdomainLdappath = "OU=Males,OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            string userdomainLdappath = "OU=" + groupName + ",OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, Server, userdomainLdappath, adminusername, adminpassword))
                {
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, groupName);
                    group.Members.Add(pc, IdentityType.SamAccountName, userId);
                    group.Save();
                }
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //doSomething with E.Message.ToString(); 
            }
        }
        public void CreateZoomAccount(string email, string firstname, string lastname)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            string userid = "";

            string JWTaccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOm51bGwsImlzcyI6IktUUUpsM1ZiU0k2aVBPNDl0VmVma1EiLCJleHAiOjE3MzU3MTEyMDAsImlhdCI6MTYwMDI0NDY5MX0.GgRVMlmMsmf0j_d5TUY4jKKO-4xZfSt7u5hmQb9QFks";

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.zoom.us/v2/users"))
                {
                    request.Headers.TryAddWithoutValidation("authorization", "Bearer " + JWTaccessToken + "");

                    request.Content = new StringContent("{\"action\":\"create\",\"user_info\":{\"email\":\"" + email + "\",\"type\":1,\"first_name\":\"" + firstname + "\",\"last_name\":\"" + lastname + "\"}}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    string s = response.Content.ReadAsStringAsync().Result;
                    var x = JObject.Parse(s);
                    var uID = x["id"];
                    if (uID != null) //added by bahaa 25-09-2020 //
                    {
                        userid = uID.ToString();
                    }


                }
            }

            if (userid != "" && userid != null)
            {
                string groupid = "OU8bD5WPTxSpMLMvtG5H4w";//Group Name-Student
                string emailID = email;

                AddZoomGroupMemebers(groupid, emailID, userid, JWTaccessToken);

                //string IMGroupID = "W6jUNfWfSuC-vY7VqWpwOQ";//Default IM Group - Restricted 
                //if (Gender == "Males")
                //{
                //    IMGroupID = "seOLrQ4DQFWA7WMZzqwZhQ";//Males Studnets         
                //}
                //else if (Gender == "Females")
                //{
                //    IMGroupID = "1ShdTaaERVKs3KZmgO6JuQ";//Females Studnet
                //}
                //else
                //{
                //    IMGroupID = "W6jUNfWfSuC-vY7VqWpwOQ";//Default IM Group - Restricted 
                //}
                //addZoomIMGroupMembers(IMGroupID, emailID, userid);

                //deleteZoomIMGroupMemeber("W6jUNfWfSuC-vY7VqWpwOQ", userid);//Remove the User from Default IM Group - Restricted 
            }
        }
        public void AddZoomGroupMemebers(string groupid, string email, string userid, string JWTaccessToken)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.zoom.us/v2/groups/" + groupid + "/members"))
                {
                    request.Headers.TryAddWithoutValidation("authorization", "Bearer " + JWTaccessToken + "");

                    request.Content = new StringContent("{\"members\":[{\"id\":\"" + userid + "\",\"email\":\"" + email + "\"}]}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    string s = response.Content.ReadAsStringAsync().Result;
                }
            }
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
                    else//Apply permission here later
                    {
                        lblReference.Enabled = true;
                    }
                    iEffected = StudentDS.Insert();
                    if (iEffected > 0)
                    {
                        lbl_Msg.Text = "Student Added Successfully";
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        div_msg.Visible = true;
                        QualificationDS.DataBind();
                        grdQualification.DataBind();
                        DocumentsDS.DataBind();
                        grdDocs.DataBind();
                        DocsEditDS.DataBind();
                        EnrollmentDS.DataBind();
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
                    else//Apply permission here later
                    {
                        lblReference.Enabled = true;
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

                    iEffected = Delete_Marks(lblStudentId.Text);
                    iEffected += EnrollmentDS.Delete();
                    iEffected += DocsEditDS.Delete();

                    iEffected += QualificationDS.Delete();

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
        private int Delete_Marks(string sID)
        {
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            int iDeleted = 1;
            try
            {
                string sSQL = "DELETE FROM Reg_Grade_Header WHERE lngStudentNumber='" + sID + "'";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                iDeleted = Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                iDeleted = 0;
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

            }
            return iDeleted;

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
                    Server.Transfer("Authorization.aspx");
                    return;
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

                        MultiTabs.ActiveViewIndex = 4;
                        RunSearch();
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
            try
            {
                mtvQualification.ActiveViewIndex = 0;
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

        protected void SaveQ_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    bool IsAllowShowAdmissionVerification = false;
                    bool IsAllowShowRegistrarVerification = false;

                    IsAllowShowAdmissionVerification = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_VerfiyTOEFL_HS,
                   InitializeModule.enumPrivilege.ShowAdmissionVerification, CurrentRole);

                    IsAllowShowRegistrarVerification = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_VerfiyTOEFL_HS,
                  InitializeModule.enumPrivilege.ShowRegistrarVerification, CurrentRole);


                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                      InitializeModule.enumPrivilege.AddQualification, CurrentRole) != true)
                    {
                        lbl_Msg.Text = "Sorry you cannot add qualification for student";
                        div_msg.Visible = true;
                        return;
                    }

                    string sQualification = ddlQualification.SelectedValue;

                    switch (sQualification)
                    {
                        case "1"://High School
                            bool IsAllowHSCertificateAdd = false;
                            IsAllowHSCertificateAdd = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                                InitializeModule.enumPrivilege.HSCertificateAdd, CurrentRole);

                            if (!IsAllowShowAdmissionVerification && !IsAllowShowRegistrarVerification && !IsAllowHSCertificateAdd)
                            {
                                lbl_Msg.Text = "Sorry you cannot add high school to students";
                                div_msg.Visible = true;
                                return;
                            }
                            break;
                        case "6"://TOEFL
                        case "7"://IELTS
                        case "8"://TOEFL CBT
                        case "9"://TOEFL IBT
                        case "10"://TOEIC
                        case "14"://Cambridge FCE
                        case "15"://City & Guilds IESOL
                        case "16"://EmSAT English Test
                        case "26"://EmSAT Arabic Test


                            bool IsAllowEnglishCertificateAdd = false;
                            IsAllowEnglishCertificateAdd = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                                InitializeModule.enumPrivilege.EnglishCertificateAdd, CurrentRole);

                            if (!IsAllowShowAdmissionVerification && !IsAllowShowRegistrarVerification && !IsAllowEnglishCertificateAdd)
                            {
                                lbl_Msg.Text = "Sorry you cannot add english certificate to students";
                                div_msg.Visible = true;
                                return;
                            }
                            if (sQualification == "15")
                            {
                                if (ddlQEngExamCenter.SelectedValue.ToString() == "" || ddlQEngExamCenter.SelectedValue.ToString() == "0")
                                {
                                    lbl_Msg.Text = "Please select exam center";
                                    div_msg.Visible = true;
                                    ddlQEngExamCenter.Focus();
                                    return;
                                }
                                if (ddlQEngGrade.SelectedValue.ToString() == "-" || ddlQEngGrade.SelectedValue.ToString() == "")
                                {
                                    lbl_Msg.Text = "Please select exam grade";
                                    div_msg.Visible = true;
                                    ddlQEngGrade.Focus();
                                    return;
                                }
                            }
                            break;
                    }


                    int iAdded = 0;
                    if (HiddenFieldQMode.Value == InitializeModule.enumModes.NewMode.ToString())
                    {
                        iAdded = QualificationDS.Insert();
                        if (iAdded > 0)
                        {
                            lbl_Msg.Text = "Qualification Added Successfully ...";
                            div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                            div_msg.Visible = true;
                        }
                    }
                    if (HiddenFieldQMode.Value == InitializeModule.enumModes.EditMode.ToString())
                    {
                        iAdded = QualificationDS.Update();
                        if (iAdded > 0)
                        {
                            lbl_Msg.Text = "Qualification Updated Successfully ...";
                            div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                            div_msg.Visible = true;
                        }
                        //if (LibraryMOD.IsFileVerifiedFromRegistrar(lblStudentId.Text, Campus) == InitializeModule.FALSE_VALUE)
                        //{
                        //    lblIsVerfiedFromRegistrar.Text = "Warning: UnVerfied from the Registrar";
                        //    lblIsVerfiedFromRegistrar.ForeColor = Color.Red;
                        //}
                        //else
                        //{
                        //    lblIsVerfiedFromRegistrar.Text = "Verfied from the Registrar";
                        //    lblIsVerfiedFromRegistrar.ForeColor = Color.Green;  //#009933

                        //}

                    }
                    mtvQualification.ActiveViewIndex = 0;

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

        protected void grdQualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Q = Convert.ToInt32("0" + grdQualification.SelectedDataKey["byteQualification"].ToString());
            Q_Audit.SelectParameters["Qualification"].DefaultValue = Q.ToString();
            QDV.DataBind();
        }
        private void enable_disable_Q()
        {
            bool IsAllowEditHS = false;
            bool IsAllowEditEnCertificates = false;
            bool isAdd = false;


            isAdd = (txtQScore.Text == "");
            IsAllowEditHS = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
            InitializeModule.enumPrivilege.HSCertificateEdit, CurrentRole);



            IsAllowEditEnCertificates = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
            InitializeModule.enumPrivilege.EnglishCertificateEdit, CurrentRole);

            ddlQMajor.Enabled = false;
            ddlQCountry.Enabled = false;
            ddlQualification.Enabled = false;
            ddlQInstitutionType.Enabled = false;
            ddlQCity.Enabled = false;
            ddlQG12_Stream.Enabled = false;
            ddlQEngGrade.Enabled = false;
            ddlQEngExamCenter.Enabled = false;
            txtQScoreofMath.Enabled = false;
            txtQScoreofChemistry.Enabled = false;
            txtQScoreofBiology.Enabled = false;
            txtQScoreofPhysics.Enabled = false;
            txtQScore.Enabled = false;
            txtSource.Enabled = false;
            txtQYear.Enabled = false;
            txtQDate.Enabled = false;
            ddlHSSystem.Enabled = false;
            ddlEquivalencyIndicator.Enabled = false;
            txtEquivalencyAppNo.Enabled = false;


            ddlQEngGrade.SelectedValue = "-";

            switch (ddlQualification.SelectedValue)
            {
                case "6":
                case "7":
                case "8":
                case "9":
                case "15":

                    if (IsAllowEditEnCertificates || isAdd)
                    {
                        if (txtQScore.Text == "")
                        {
                            ddlQMajor.SelectedValue = "5";
                        }
                        ddlQMajor.Enabled = true;
                        ddlQCountry.Enabled = true;
                        ddlQualification.Enabled = true;
                        ddlQInstitutionType.Enabled = false;
                        ddlQCity.Enabled = true;
                        ddlQG12_Stream.Enabled = false;
                        ddlQEngGrade.Enabled = true;
                        ddlQEngExamCenter.Enabled = true;
                        txtQScoreofMath.Enabled = false;
                        txtQScoreofChemistry.Enabled = false;
                        txtQScoreofBiology.Enabled = false;
                        txtQScoreofPhysics.Enabled = false;
                        txtQScore.Enabled = true;
                        txtSource.Enabled = true;
                        txtQYear.Enabled = true;
                        txtQDate.Enabled = true;
                        ddlHSSystem.Enabled = false;
                        ddlEquivalencyIndicator.Enabled = false;
                        txtEquivalencyAppNo.Enabled = false;
                        if (ddlQualification.SelectedValue == "15")
                        {
                            ddlQEngGrade.Enabled = true;
                            txtQScore.Enabled = false;
                            txtSource.Text = "City & Guilds";
                            txtSource.Enabled = false;
                        }
                        else
                        {
                            ddlQEngGrade.Enabled = false;
                            txtQScore.Enabled = true;
                            txtSource.Enabled = true;
                        }

                    }
                    break;
                case "1":
                    if (IsAllowEditHS || isAdd)
                    {
                        if (txtQScore.Text == "")
                        {
                            ddlQMajor.SelectedValue = "21";
                        }
                        ddlQMajor.Enabled = true;
                        ddlQCountry.Enabled = true;
                        ddlQualification.Enabled = true;
                        ddlQInstitutionType.Enabled = true;
                        ddlQCity.Enabled = true;
                        ddlQG12_Stream.Enabled = true;
                        ddlQEngGrade.Enabled = false;
                        ddlQEngExamCenter.Enabled = false;
                        txtQScoreofMath.Enabled = true;
                        txtQScoreofChemistry.Enabled = true;
                        txtQScoreofBiology.Enabled = true;
                        txtQScoreofPhysics.Enabled = true;
                        txtQScore.Enabled = true;
                        txtSource.Enabled = true;
                        txtQYear.Enabled = true;
                        txtQDate.Enabled = true;
                        ddlHSSystem.Enabled = true;
                        ddlEquivalencyIndicator.Enabled = true;
                        txtEquivalencyAppNo.Enabled = true;
                        ddlQEngGrade.SelectedValue = "-";
                    }
                    break;
                default:
                    if (txtQScore.Text == "")
                    {
                        ddlQMajor.SelectedIndex = 0;
                    }
                    ddlQMajor.Enabled = true;
                    ddlQCountry.Enabled = true;
                    ddlQualification.Enabled = true;
                    ddlQInstitutionType.Enabled = false;
                    ddlQCity.Enabled = true;
                    ddlQG12_Stream.Enabled = false;
                    ddlQEngGrade.Enabled = false;
                    ddlQEngExamCenter.Enabled = false;
                    txtQScoreofMath.Enabled = false;
                    txtQScoreofChemistry.Enabled = false;
                    txtQScoreofBiology.Enabled = false;
                    txtQScoreofPhysics.Enabled = false;
                    txtQScore.Enabled = true;
                    txtSource.Enabled = true;
                    txtQYear.Enabled = true;
                    txtQDate.Enabled = true;
                    ddlHSSystem.Enabled = false;
                    ddlEquivalencyIndicator.Enabled = true;
                    txtEquivalencyAppNo.Enabled = true;

                    break;

            }
            ddlQualification.Focus();
        }
        private void GetStudentQualification(int iSerialNo, int iQualificationNo)
        {
            //List<Student_Qualifications> myStudentQualification = new List<Student_Qualifications>();
            //Student_QualificationsDAL myStudentQualificationDAL = new Student_QualificationsDAL();
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT lngSerial, byteQualification, intCertificate, intMajor,";
                sSQL += "intGraduationYear, byteInstituteCountry, sngGrade, strCertificateSource,";
                sSQL += "dateENG, strUserCreate, dateCreate, VerifiedByAdmission, AdmissionComments,";
                sSQL += "VerifiedByRegistrar, RegistrarComments, HS_InstitutionType,";
                sSQL += "HS_InstitutionCity,G12_Stream, ScoreOfMath, IESOL_Grade, ExamCenterID, HSSystem,";
                sSQL += "HSEquivalencyIndicator,HSEquivalencyAppNo,ScoreOfChemistry,ScoreOfBiology,ScoreOfPhysics";
                sSQL += " FROM Reg_Student_Qualifications";



                string sCond = " WHERE lngSerial =" + iSerialNo + " AND byteQualification =" + iQualificationNo;

                sSQL += sCond;

                SqlCommand cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {

                    ddlQMajor.SelectedValue = rd["intMajor"].ToString();
                    ddlQCountry.SelectedValue = rd["byteInstituteCountry"].ToString();
                    ddlQualification.SelectedValue = rd["intCertificate"].ToString();

                    ddlQInstitutionType.SelectedValue = rd["HS_InstitutionType"].ToString();
                    ddlQCity.SelectedValue = rd["HS_InstitutionCity"].ToString();
                    ddlQG12_Stream.SelectedValue = rd["G12_Stream"].ToString();
                    txtQScoreofMath.Text = rd["ScoreOfMath"].ToString();
                    txtQScoreofChemistry.Text = rd["ScoreOfChemistry"].ToString();
                    txtQScoreofBiology.Text = rd["ScoreOfBiology"].ToString();
                    txtQScoreofPhysics.Text = rd["ScoreOfPhysics"].ToString();

                    txtQScore.Text = rd["sngGrade"].ToString();
                    txtSource.Text = rd["strCertificateSource"].ToString();
                    txtQYear.Text = rd["intGraduationYear"].ToString();

                    txtQDate.Text = string.Format("{0:yyyy-MM-dd}", rd["dateENG"]);

                    if (rd["HSSystem"].Equals(DBNull.Value))
                    {
                        ddlHSSystem.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlHSSystem.SelectedValue = rd["HSSystem"].ToString();
                    }


                    if (rd["HSEquivalencyIndicator"].Equals(DBNull.Value))
                    {
                        ddlEquivalencyIndicator.SelectedValue = "M";
                    }
                    else
                    {
                        ddlEquivalencyIndicator.SelectedValue = rd["HSEquivalencyIndicator"].ToString();
                    }

                    txtEquivalencyAppNo.Text = rd["HSEquivalencyAppNo"].ToString();


                    //enable / disable

                    enable_disable_Q();



                    chkRegistrarVerfication.Checked = Convert.ToBoolean(rd["VerifiedByregistrar"]);
                    txtRegistrarComments.Text = rd["RegistrarComments"].ToString();
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_VerfiyTOEFL_HS,
                                 InitializeModule.enumPrivilege.ShowRegistrarVerification, CurrentRole) != true)
                    {
                        chkRegistrarVerfication.Enabled = false;
                        txtRegistrarComments.Enabled = false;
                    }
                    chkAdmissionVerfication.Checked = Convert.ToBoolean(rd["VerifiedByAdmission"]);
                    txtAdmissionComments.Text = rd["AdmissionComments"].ToString();
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_VerfiyTOEFL_HS,
                                 InitializeModule.enumPrivilege.ShowAdmissionVerification, CurrentRole) != true)
                    {
                        chkAdmissionVerfication.Enabled = false;
                        txtAdmissionComments.Enabled = false;
                    }
                    // this.ddlQEngGrade.SelectedIndex = ddlQEngGrade.Items.IndexOf( ddlQEngGrade.Items.FindByText(myStudentQualification[0].IESOL_Grade.ToString()));
                    this.ddlQEngGrade.SelectedValue = rd["IESOL_Grade"].ToString().Trim();
                    this.ddlQEngExamCenter.SelectedValue = rd["ExamCenterID"].ToString();


                }

                rd.Close();

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
        protected void grdQualification_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdEditQ")
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.AddQualification, CurrentRole) != true)
                {
                    lbl_Msg.Text = "Sorry you cannot edit student qualification";
                    div_msg.Visible = true;
                    return;
                }

                // Convert the row index stored in the CommandArgument

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = grdQualification.Rows[index];
                int iQ = int.Parse("0" + grdQualification.Rows[index].Cells[2].Text);
                lblQualification.Text = iQ.ToString();

                string sStudentID = lblStudentId.Text;
                int iSerial = Convert.ToInt32(hdnSerial.Value); //LibraryMOD.GetStudentSerialNo(sStudentID,(int) Campus);

                GetStudentQualification(iSerial, iQ);
                HiddenFieldQMode.Value = InitializeModule.enumModes.EditMode.ToString();
                mtvQualification.ActiveViewIndex = 1;
            }
        }

        protected void NewQ_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.AddQualification, CurrentRole) != true)
                {
                    lbl_Msg.Text = "Sorry you cannot add qualification to students";
                    div_msg.Visible = true;
                    return;
                }

                if (hdnSerial.Value != "")
                {
                    SqlConnection Conn = new SqlConnection(QualificationDS.ConnectionString);
                    Conn.Open();
                    int iQualification = LibraryMOD.GetMaxID(Conn, "byteQualification", "Reg_Student_Qualifications", "lngSerial=" + hdnSerial.Value) + 1;
                    lblQualification.Text = iQualification.ToString();
                    Conn.Close();

                    txtQYear.Text = "";
                    txtSource.Text = "";
                    txtQScore.Text = "";
                    txtQDate.Text = "";
                    ddlQEngGrade.SelectedValue = "-";
                    ddlQCountry.SelectedValue = "1";
                    ddlQCity.SelectedValue = "1";
                    ddlQInstitutionType.SelectedValue = "0";
                    ddlQG12_Stream.SelectedValue = "0";
                    txtQScoreofMath.Text = "0";
                    txtQScoreofChemistry.Text = "0";
                    txtQScoreofBiology.Text = "0";
                    txtQScoreofPhysics.Text = "0";
                    ddlQEngExamCenter.SelectedValue = "0";
                    ddlQualification.SelectedIndex = 0;
                    ddlQMajor.SelectedIndex = 0;
                    ddlHSSystem.SelectedIndex = 0;
                    ddlEquivalencyIndicator.SelectedIndex = 0;
                    txtEquivalencyAppNo.Text = "";
                    //ddlQMinor.SelectedIndex = 0;
                    txtAdmissionComments.Text = "";
                    txtRegistrarComments.Text = "";
                    chkAdmissionVerfication.Checked = false;
                    chkRegistrarVerfication.Checked = false;
                    mtvQualification.ActiveViewIndex = 1;
                    HiddenFieldQMode.Value = InitializeModule.enumModes.NewMode.ToString();
                    enable_disable_Q();

                }
                else
                {
                    lbl_Msg.Text = "Select or Add Student Please ...";
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

        protected void ESLEX_btn_Click(object sender, EventArgs e)
        {
            ESL_Exemption();
        }

        protected void DeleteQ_btn_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                    InitializeModule.enumPrivilege.DeleteQualification, CurrentRole) != true)
            {
                lbl_Msg.Text = "Sorry you cannot delete a qualification";
                div_msg.Visible = true;
                return;
            }

            if (hdnSerial.Value != "" && grdQualification.SelectedIndex >= 0)
            {
                int iDeleted = QualificationDS.Delete();
                lbl_Msg.Text = iDeleted.ToString() + " Qualification Deleted.";
                div_msg.Visible = true;
            }
            else
            {
                lbl_Msg.Text = "Select Qualification Please.";
                div_msg.Visible = true;
            }
        }

        protected void ddlQualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlQEngGrade.SelectedValue = "-";
            switch (ddlQualification.SelectedValue)
            {

            }
            enable_disable_Q();
        }

        protected void ddlQCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlQCity.DataBind();
        }

        protected void ddlQEngGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQualification.SelectedValue == "15")
            {
                switch (ddlQEngGrade.SelectedValue)
                {
                    case "B1":
                        txtQScore.Text = "500";

                        break;
                    case "B2":
                        txtQScore.Text = "550";
                        break;
                    case "-":
                        txtQScore.Text = "0";
                        break;
                }

                txtQScore.Enabled = false;
            }
            else
            {
                txtQScore.Enabled = true;

            }
        }

        protected void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                chkActive.Text = "Active";
                chkActive.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                chkActive.Text = "In Active";
                chkActive.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void ESL_Exemption()
        {
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            try
            {
                if (lblStudentId.Text == "")
                {
                    return;
                }

                string sSQL = "SELECT M.intCertificate, M.Mark, A.strDegree, A.strSpecialization";
                sSQL += " FROM MaxEngCertMark AS M INNER JOIN Reg_Applications AS A ON M.lngStudentNumber = A.lngStudentNumber";
                sSQL += " WHERE  (M.lngStudentNumber = '" + lblStudentId.Text + "')";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                int iCert = 0;
                double dScore = 0;
                string sMajor = "";
                string sDegree = "";

                while (Rd.Read())
                {
                    iCert = Convert.ToInt32(Rd["intCertificate"]);
                    dScore = Convert.ToDouble(Rd["Mark"]);
                    sDegree = Rd["strDegree"].ToString();
                    sMajor = Rd["strSpecialization"].ToString();
                }
                Rd.Close();
                bool isArabic = false;
                if ((sDegree == "1" && (sMajor == "24" || sMajor == "25")) || (sDegree == "3" && (sMajor == "4" || sMajor == "5" || sMajor == "6" || sMajor == "21")))
                {
                    isArabic = true;
                }

                if (isArabic == true)
                {
                    switch (iCert)//Arabic Pass Score
                    {
                        case 6://TOEFL
                            dScore = (dScore * 500) / 450;
                            break;
                        case 7://IELTS
                            dScore = (dScore * 5) / 4;
                            break;
                        case 8://TOEFL CBT
                            dScore = (dScore * 173) / 133;
                            break;
                        case 9://TOEFL iBT
                            dScore = (dScore * 61) / 45;
                            break;
                        case 10://TOEIC
                            dScore = (dScore * 550) / 480;
                            break;
                    }

                }

                sSQL = "Select byteLevel From Reg_Levels";
                sSQL += " Where intCert=" + iCert;
                sSQL += " And curMin<=" + dScore;
                sSQL += " And curMax>=" + dScore;

                Cmd.CommandText = sSQL;
                int iLevel = Convert.ToInt32("0" + Cmd.ExecuteScalar().ToString());
                sSQL = "Insert Into Reg_Grade_Header";
                sSQL += " (intStudyYear, byteSemester,lngStudentNumber,byteRefCollege, strCourse, byteClass, byteShift, strGrade, strUserCreate, dateCreate,curUseMark, bDisActivated,bCanceled)";
                sSQL += "SELECT 0,0,'" + lblStudentId.Text + "',-1,CL.strCourse,1,1,'EX','LocalECT',GETDATE(),333,0,0 FROM Reg_Course_Levels AS CL LEFT OUTER JOIN ";
                sSQL += " (SELECT strCourse FROM Reg_Grade_Header AS GH";
                sSQL += " WHERE (strGrade = N'NC' OR strGrade = N'EX') AND (lngStudentNumber = '" + lblStudentId.Text + "')) AS DT ON CL.strCourse = DT.strCourse";
                sSQL += " Where intCert=" + iCert;
                sSQL += " And byteLevel=" + iLevel;
                sSQL += " And bReg=0";
                sSQL += " And DT.strCourse IS NULL";

                Cmd.CommandText = sSQL;

                int iEffected = 0;
                iEffected = Cmd.ExecuteNonQuery();

                lbl_Msg.Text = iEffected.ToString() + " ESL Courses Calculated";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

        }
        protected void chkMissing_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMissing.Checked)
            {
                chkMissing.Text = "File Not Complete";
                chkMissing.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                chkMissing.Text = "Is File Not Complete";
                chkMissing.ForeColor = System.Drawing.Color.Black;
            }
        }
        protected void lnkGet_Command(object sender, CommandEventArgs e)
        {
            //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "getContact();", true);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string accessToken = InitializeModule.CxPwd;
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://ect.custhelp.com/services/rest/connect/v1.4/contacts?q=customFields.c.ect_student_id%3D%27" + lblStudentId.Text + "%27"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", accessToken);
                    request.Headers.TryAddWithoutValidation("OSvC-CREST-Application-Context", "application/x-www-form-urlencoded");
                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    string s = response.Content.ReadAsStringAsync().Result;
                    var x = JObject.Parse(s);
                    if (x["items"].HasValues)
                    {
                        var id = x["items"][0]["id"];
                        txtContactID.Text = id.ToString();
                    }
                    else
                    {
                        lbl_contacterror.Text = "No Contact ID found in CX.";
                    }
                }
            }
        }
        protected void lnkOpportunity_Command(object sender, CommandEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                      InitializeModule.enumPrivilege.UpdateCRMOpportunity, CurrentRole) != true)
            {
                lbl_Msg.Text = "Sorry you cannot update CRM Opportunity";
                div_msg.Visible = true;
                return;
            }

            string sSID = lblStudentId.Text;
            int iOpportunity = 0;
            if (!isPaid(sSID))
            {
                lbl_Msg.Text = "Opportunity must be set after the student payment.";
                div_msg.Visible = true;
                return;
            }
            if (isOpportunitySet(sSID, out iOpportunity))
            {
                lbl_Msg.Text = "Opportunity must be set one time only.";
                div_msg.Visible = true;
            }
            else
            {
                if (iOpportunity > 0 && iOpportunity.ToString() == txtOpportunityID.Text)
                {
                    //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "setOpportunity();", true);
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.DefaultConnectionLimit = 9999;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    string accessToken = InitializeModule.CxPwd;

                    using (var httpClient = new HttpClient())
                    {
                        using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://ect.custhelp.com/services/rest/connect/v1.4/opportunities/" + txtOpportunityID.Text + ""))
                        {
                            request.Headers.TryAddWithoutValidation("Authorization", accessToken);
                            request.Headers.TryAddWithoutValidation("OSvC-CREST-Application-Context", "application/x-www-form-urlencoded");

                            request.Content = new StringContent("{\n\t\"customFields\": {\n\t\t\"c\": {\n\t\t\t\"paymentstatus\": {\n                \"id\": 1094,\n                \"lookupName\": \"Payment Succeeded\"\n            }\n\t\t}\n\t},\n\t\"statusWithType\": {\n        \"status\": {\n            \"id\": 11\n        }\n    }\n}");
                            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                            var task = httpClient.SendAsync(request);
                            task.Wait();
                            var response = task.Result;
                            string s = response.Content.ReadAsStringAsync().Result;
                            //If Status 200
                            if (response.IsSuccessStatusCode == true)
                            {
                                SetOpportunity(sSID);
                            }
                        }
                    }
                }
                else
                {
                    lbl_Msg.Text = "Opportunity ID must be saved first.";
                    div_msg.Visible = true;
                }
            }
        }
        private bool isPaid(string sSID)
        {
            bool isIt = false;
            Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
            SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
            conn.Open();
            try
            {
                double iPaid = 0;
                string sSQL = "SELECT SA.lngStudentNumber, SUM(VD.curCredit) AS Paid";
                sSQL += " FROM Acc_Voucher_Header AS VH INNER JOIN Acc_Voucher_Detail AS VD ON VH.intFy = VD.intFy AND VH.byteFSemester = VD.byteFSemester";
                sSQL += " AND VH.strVoucherNo = VD.strVoucherNo INNER JOIN Reg_Student_Accounts AS SA ON VH.strAccountNo = SA.strAccountNo";
                sSQL += " WHERE (VD.byteStatus < 2)";
                sSQL += " GROUP BY SA.lngStudentNumber";
                sSQL += " HAVING (SA.lngStudentNumber = '" + sSID + "')";

                SqlCommand cmd = new SqlCommand(sSQL, conn);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    iPaid = Convert.ToDouble(rd["Paid"].ToString());
                }
                rd.Close();

                isIt = (iPaid >= 1000);

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return isIt;
        }
        private bool isOpportunitySet(string sSID, out int iOpportunity)
        {
            bool isSet = false;
            iOpportunity = 0;
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {

                string sSQL = "SELECT iOpportunityID, isOpportunitySet";
                sSQL += " FROM Reg_Applications";
                sSQL += " WHERE (lngStudentNumber = '" + sSID + "')";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                while (Rd.Read())
                {
                    iOpportunity = Convert.ToInt32(Rd["iOpportunityID"].ToString());
                    isSet = Convert.ToBoolean(Rd["isOpportunitySet"].ToString());
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
            return isSet;
        }
        [System.Web.Services.WebMethod]//to call it from the client side + u must add also EnablePageMethods="true" to ScriptManager
        public static bool SetOpportunity(string sSID)
        {
            bool isSet = false;
            //U cannot use var from out of the scope. (Campus)
            InitializeModule.EnumCampus campus = InitializeModule.EnumCampus.Males;
            if (sSID.Contains("AF") || sSID.Contains("ESF"))
            {
                campus = InitializeModule.EnumCampus.Females;
            }
            Connection_StringCLS myConnection_String = new Connection_StringCLS(campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {

                string sSQL = "UPDATE Reg_Applications SET isOpportunitySet=1";
                sSQL += " WHERE (lngStudentNumber = '" + sSID + "')";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                isSet = (Cmd.ExecuteNonQuery() > 0);


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return isSet;
        }
        protected void lnkCheck_Command(object sender, CommandEventArgs e)
        {
            if (txtContactID.Text != "0" || txtContactID.Text != null || txtContactID.Text != "")
            {
                //this.ClientScript.RegisterStartupScript(this.GetType(), "test", "getContact();", true);
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.DefaultConnectionLimit = 9999;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                string accessToken = InitializeModule.CxPwd;
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://ect.custhelp.com/services/rest/connect/v1.4/contacts/" + txtContactID.Text.Trim() + ""))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", accessToken);
                        request.Headers.TryAddWithoutValidation("OSvC-CREST-Application-Context", "application/x-www-form-urlencoded");
                        var task = httpClient.SendAsync(request);
                        task.Wait();
                        var response = task.Result;
                        string s = response.Content.ReadAsStringAsync().Result;
                        var x = JObject.Parse(s);
                        //If Status 200 OK
                        if (response.IsSuccessStatusCode == true)
                        {
                            if (x["customFields"].HasValues)
                            {
                                var unifiedid = x["customFields"]["c"]["local_ect_unique_id"];
                                var studentid = x["customFields"]["c"]["ect_student_id"];
                                var studentname = x["lookupName"];
                                Response.Write("<script>alert('Unified ID: " + unifiedid + "" + "\\n" + "ECT Student ID: " + studentid + "" + "\\n" + "Student Name: " + studentname + "');</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('No Data Available in CX.');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('" + s + "');</script>");
                        }
                    }
                }
            }
            else
            {
                //Enter a Valid Contact ID to check
                Response.Write("<script>alert('Enter a Valid Contact ID to check');</script>");
            }
        }
        protected void ddlMajor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlWMajor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change student advisor to the Dean of faculty

            ddlAdvisor.SelectedValue = SetAdvisorAsWantedMajor(Convert.ToInt32(ddlWMajor1.SelectedValue)).ToString();
            ddlWMajor2.Focus();
        }
        private int SetAdvisorAsWantedMajor(int iWantedMajor)
        {
            int iFacultyID = 0;
            int iAdvisor = 0;
            iFacultyID = LibraryMOD.GetFacultyIDFromWantedMjor(iWantedMajor);
            int iDean = LibraryMOD.GetDeanofFacultyID(iFacultyID);
            switch (Campus)
            {
                case InitializeModule.EnumCampus.Males:
                    iAdvisor = LibraryMOD.GetLecturerMaleID(iDean);
                    break;
                case InitializeModule.EnumCampus.Females:
                    iAdvisor = LibraryMOD.GetLecturerFemaleID(iDean);
                    break;
            }
            return iAdvisor;
        }
        private int SetAdvisorAsCurrentMajor(string sDegreeID, string sMajorID)
        {
            int iFacultyID = 0;
            int iAdvisor = 0;
            iFacultyID = LibraryMOD.GetFacultyIDFromMjor(sDegreeID, Convert.ToInt32(sMajorID.Substring(4, 2)).ToString());
            int iDean = LibraryMOD.GetDeanofFacultyID(iFacultyID);
            switch (Campus)
            {
                case InitializeModule.EnumCampus.Males:
                    iAdvisor = LibraryMOD.GetLecturerMaleID(iDean);
                    break;
                case InitializeModule.EnumCampus.Females:
                    iAdvisor = LibraryMOD.GetLecturerFemaleID(iDean);
                    break;
            }
            return iAdvisor;
        }

        protected void btnSetAdvisor_Click(object sender, EventArgs e)
        {
            ddlAdvisor.SelectedValue = SetAdvisorAsCurrentMajor(ddlType.SelectedValue, ddlMajor.SelectedValue).ToString();
            txtNote.Focus();
        }

        protected void ddlEnrollmentSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (ddlEnrollmentSource.SelectedValue)
            //{ 
            //    case "2":
            //        txtEnrollmentSource.Text = "";
            //        txtEnrollmentSource.Visible = true;
            //        lblotherSource.Visible = true; 
            //        lblotherSource.Text = "Exhibition Name & Year";
            //        break;
            //    case "7":

            //        //txtEnrollmentSource.Text = "";
            //        txtEnrollmentSource.Visible = true ;
            //        lblotherSource.Visible = true;
            //        lblotherSource.Text = "Other Source";
            //        txtEnrollmentSource.Focus();

            //        break ;
            //    default:
            //       // txtEnrollmentSource.Text = "-"; 
            //        txtEnrollmentSource.Visible = false;
            //        lblotherSource.Visible = false ; 
            //        break;
            //}
        }

        protected void txtEnrollmentSource_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ChkIsMilitaryService_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkIsMilitaryService.Checked)
            {
                txtMilitaryServiceDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today);
            }
            //else
            //{
            //    txtMilitaryServiceDate.Text = ""; 
            //}
            ChkIsMilitaryService.Focus();
        }
        private void CreateNewId(int iType, int iYear, int iSem)
        {

            try
            {
                //SidDS.SelectParameters.Clear(); 
                SidDS.ConnectionString = sConn;
                SidDS.SelectParameters["iType"].DefaultValue = iType.ToString();
                SidDS.SelectParameters["iYear"].DefaultValue = iYear.ToString();
                SidDS.SelectParameters["iSem"].DefaultValue = iSem.ToString();
                SidDS.SelectParameters["iCampus"].DefaultValue = ((int)Campus).ToString();
                SidDS.Select(DataSourceSelectArguments.Empty);
                lblECTId.Text = LibraryMOD.GetECTId("", Campus);

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
        private bool isMajorAvailable(string sKey)
        {
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            bool isIt = false;
            try
            {

                string sSQL = "SELECT bAvailable FROM Reg_Specializations Where strKey='" + sKey + "'";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    isIt = Convert.ToBoolean(Rd["bAvailable"]);
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
            return isIt;

        }
        protected void SidDS_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            DbCommand command = e.Command;
            lblStudentId.Text = command.Parameters["@RETURN_VALUE"].Value.ToString();
        }
        public bool is_EmSAT_Required(string sDegree, string sMajorID)
        {
            bool isRequired = false;

            try
            {
                if (sDegree == "3")
                {
                    switch (sMajorID)  //BA_PRA,BA_RTV,BA_JOR
                    {
                        case "4":
                        case "5":
                        case "6":
                            isRequired = true;
                            break;
                    }
                }
                if (sDegree == "1" && sMajorID == "24") //Diploma of public relation
                {
                    isRequired = true;
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                isRequired = true;
            }
            finally
            {

            }
            return isRequired;
        }
        private bool isQualified(int iSerial, string sDegree, string sMajor)
        {
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            bool isIt = false;
            try
            {
                int iHSPassed = 0;
                int iEmSAT_Passed = 0;
                bool isFNDPassed = false;
                bool isDiplomaTC = false;
                bool isBscTC = false;
                int iCert = 0;

                string sSQL = "SELECT intCertificate FROM  dbo.Reg_Student_Qualifications AS Q WHERE (intCertificate = 12 or intCertificate = 2 or intCertificate = 3 ) AND (lngSerial =" + iSerial + ")";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    iCert = Convert.ToInt32(Rd["intCertificate"].ToString());
                    switch (iCert)
                    {
                        case 2:
                            isDiplomaTC = true;
                            break;
                        case 3:
                            isBscTC = true;
                            break;
                        case 12:
                            isFNDPassed = true;
                            break;

                    }

                }
                Rd.Close();


                sSQL = "Select isDiploma from HS Where lngSerial=" + iSerial;
                Cmd.CommandText = sSQL;
                iHSPassed = (int)Cmd.ExecuteScalar();

                if ((sDegree == "1" || sDegree == "3" || (sDegree == "2" && (sMajor == "1" || sMajor == "5" || sMajor == "6" || sMajor == "7"))) && (iHSPassed == 1 || iCert > 0))
                {
                    isIt = true;
                }
                else if (sDegree == "2" && iHSPassed == 2 && iCert == 0)
                {
                    isIt = true;
                }
                else
                {
                    isIt = false;
                }

                //======================================================
                if (is_EmSAT_Required(sDegree, sMajor) && isIt == true)
                {
                    //check if EmSAt Arabic test entered in the system and get score>=1000

                    Rd.Close();

                    sSQL = "SELECT  (CASE WHEN SQ.sngGrade >= C.curPassed THEN 1 ELSE 2 END) AS isPass_EmSAT ";
                    sSQL += " FROM Reg_Student_Qualifications AS SQ INNER JOIN ";
                    sSQL += " Lkp_Certificates AS C ON SQ.intCertificate = C.intCertificate";
                    sSQL += " Where SQ.lngSerial=" + iSerial;
                    sSQL += " AND SQ.intCertificate = 26";

                    Cmd.CommandText = sSQL;

                    Rd = Cmd.ExecuteReader();

                    while (Rd.Read())
                    {
                        iEmSAT_Passed = Convert.ToInt32("0" + Rd["isPass_EmSAT"].ToString());
                    }
                    if (iEmSAT_Passed == 1)
                    {
                        isIt = true;
                    }
                    else
                    {
                        isIt = false;
                    }
                }
                if (isIt == true)//Check ENG
                {
                    sSQL = "SELECT strCert,Mark FROM MaxEngCertMark WHERE lngSerial=" + iSerial;
                    Cmd.CommandText = sSQL;
                    Rd = Cmd.ExecuteReader();

                    string sCert = "";
                    float fScore = 0;

                    while (Rd.Read())
                    {
                        sCert = Rd["strCert"].ToString();
                        fScore = float.Parse(Rd["Mark"].ToString());

                    }
                    Rd.Close();

                    bool isGeneral = false;
                    sSQL = "SELECT isGeneral FROM Reg_Specializations WHERE strDegree='" + sDegree + "' AND strSpecialization='" + sMajor + "'";
                    Cmd.CommandText = sSQL;
                    Rd = Cmd.ExecuteReader();
                    while (Rd.Read())
                    {
                        isGeneral = bool.Parse(Rd["isGeneral"].ToString());
                    }
                    Rd.Close();
                    bool isPassed = LibraryMOD.isENGPassed(fScore, sCert, sDegree, sMajor);
                    isIt = (isPassed || isGeneral);
                }


                //check if its Literary HS and student want to reg in HIM program
                //if (isIt == true && sDegree == "3" && sMajor == "11")//check HS for HIM
                //{
                //    
                //    //must finish MTH001,CHEM001 & BIOL001 before enter HIM program
                //    string sQuery = "SELECT intMajor,ScoreOfMath FROM  dbo.Reg_Student_Qualifications AS Q WHERE (intCertificate = 1 ) AND (lngSerial =" + iSerial + ")";
                //    int iMajor = 0;
                //    Cmd.CommandText = sQuery; 
                //    Rd = Cmd.ExecuteReader();
                //    while (Rd.Read())
                //    {
                //        iMajor = int.Parse("0" + Rd["intMajor"].ToString());
                //    }
                //    Rd.Close();
                //    //check if finished MTH001,CHEM001 & BIOL001
                //    if (iMajor == 4 && isMTH001_CHEM001_BIOL001_Passed() == false)
                //    {
                //        isIt = false;
                //    }
                //}
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
            return isIt;

        }
        protected void SaveE_btn_Click(object sender, EventArgs e)
        {
            try
            {

                if (hdnSerial.Value == "")
                {
                    lbl_Msg.Text = "Select or Add Student Please ...";
                    div_msg.Visible = true;
                    return;
                }
                int iEffected = 0;


                if (ddlEnrollmentSource.SelectedValue == "0")
                {
                    lbl_Msg.Text = "Please choose how did you hear about ECT?";
                    div_msg.Visible = true;
                    ddlEnrollmentSource.Focus();
                    return;
                }

                if (ddlEnrollmentSource.SelectedValue == "51")
                {
                    if (txtEnrollmentSource.Text == "-")
                    {
                        lbl_Msg.Text = "Please Enter the Other Source?";
                        div_msg.Visible = true;
                        txtEnrollmentSource.Focus();
                        return;
                    }
                }
                else
                {
                    txtEnrollmentSource.Text = "-";
                }

                if (Session["CurrentStudent"] == null)
                {
                    Session["CurrentStudent"] = "";
                }
                if (Session["CurrentStudent"].ToString() == "") //Insert //string.IsNullOrEmpty(Session["CurrentStudent"].ToString ()
                {

                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.AcceptStudent, CurrentRole) != true)
                    {
                        lbl_Msg.Text = "Sorry you cannot enrolled students";
                        div_msg.Visible = true;
                        return;
                    }

                    string sKey = ddlMajor.SelectedValue;

                    if (isMajorAvailable(sKey) == false)
                    {
                        lbl_Msg.Text = "The selected major is not available !";
                        div_msg.Visible = true;
                        return;
                    }

                    if (ddlWMajor1.SelectedValue == "0")
                    {
                        lbl_Msg.Text = "Select the First Preferred Major Please.";
                        div_msg.Visible = true;
                        ddlWMajor1.Focus();
                        return;
                    }

                    if (ddlWMajor2.SelectedValue == "0")
                    {
                        lbl_Msg.Text = "Select the Second Preferred Major Please.";
                        div_msg.Visible = true;
                        ddlWMajor2.Focus();
                        return;
                    }

                    if (ddlWMajor3.SelectedValue == "0")
                    {
                        lbl_Msg.Text = "Select the Third Preferred Major Please.";
                        div_msg.Visible = true;
                        ddlWMajor3.Focus();
                        return;
                    }


                    string sCollege, sDegree, sMajor;
                    int iHours = 0;
                    sCollege = int.Parse(ddlMajor.SelectedValue.Substring(0, 2)).ToString();
                    sDegree = int.Parse(ddlMajor.SelectedValue.Substring(2, 2)).ToString();
                    sMajor = int.Parse(ddlMajor.SelectedValue.Substring(4, 2)).ToString();

                    bool isLegal = true;

                    if (sDegree == "2" && sMajor == "3")
                    {
                        isLegal = true;
                    }
                    else
                    {

                        if (sMajor != "99")//Visiting
                        {
                            //Check HS if it is meeting the major requirement
                            isLegal = isQualified(int.Parse(hdnSerial.Value), sDegree, sMajor);
                        }
                        else
                        {
                            sMajor = "999";
                        }
                    }
                    //isLegal = true;//delete later
                    if (isLegal)
                    {
                        SpecializationsDAL mySpecDAL = new SpecializationsDAL();
                        iHours = mySpecDAL.GetHours(Campus, sCollege, sDegree, sMajor);
                        int iEnTerm = Convert.ToInt32(ddlEnrollmentTerm.SelectedValue);

                        int iRegTerm = iRegYear * 10 + iRegSem;

                        if (iEnTerm < iRegTerm)
                        {
                            lbl_Msg.Text = "Sorry you cannot enrolled a students on old term ...";
                            div_msg.Visible = true;
                            return;

                        }

                        int iEnYear = 0;
                        int iEnSem = 0;
                        iEnYear = LibraryMOD.SeperateTerm(iEnTerm, out iEnSem);



                        CreateNewId(int.Parse(ddlType.SelectedValue), iEnYear, iEnSem);
                        if (lblStudentId.Text != "")
                        {

                            EnrollmentDS.InsertParameters["intStudyYear"].DefaultValue = iEnYear.ToString();
                            EnrollmentDS.InsertParameters["byteSemester"].DefaultValue = iEnSem.ToString();
                            EnrollmentDS.InsertParameters["strCollege"].DefaultValue = sCollege;
                            EnrollmentDS.InsertParameters["strDegree"].DefaultValue = sDegree;
                            EnrollmentDS.InsertParameters["strSpecialization"].DefaultValue = sMajor;
                            EnrollmentDS.InsertParameters["intRemind"].DefaultValue = iHours.ToString();

                            iEffected = EnrollmentDS.Insert();
                            if (iEffected > 0)
                            {
                                lbl_Msg.Text = "Student Enrolled Successfully ...";
                                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                                div_msg.Visible = true;
                                grdMarks.DataBind();
                                FillCourses(sCollege, sDegree, sMajor);
                                Session["CurrentStudent"] = lblStudentId.Text;
                                //Create Financial Account or Connect to Old one if Reference ID is there.
                                Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
                                SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
                                //SqlTransaction objTrans = null;
                                if (lblReference.Text.Length >0)
                                {
                                    //Reference Found-Update Existing Student Account 
                                    string sAcc = "";
                                    SqlCommand cmd1 = new SqlCommand("SELECT [strAccountNo] FROM [ECTData].[dbo].[Reg_Student_Accounts] where lngStudentNumber=@lngStudentNumber", sc);
                                    cmd1.Parameters.AddWithValue("@lngStudentNumber", lblReference.Text);
                                    DataTable dt1 = new DataTable();
                                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                                    try
                                    {
                                        sc.Open();
                                        da1.Fill(dt1);
                                        sc.Close();

                                        if (dt1.Rows.Count > 0)
                                        {
                                            sAcc = dt1.Rows[0]["strAccountNo"].ToString();
                                            Session["sAcc"] = sAcc;
                                            SqlCommand cmd = new SqlCommand("update Reg_Student_Accounts set lngStudentNumber=@lngStudentNumbernew,strPhone1=@strPhone1,strPhone2=@strPhone2,intRegYear=@intRegYear,byteRegSem=@byteRegSem,strUserSave=@strUserSave,dateLastSave=@dateLastSave where strAccountNo=@strAccountNo", sc);
                                            cmd.Parameters.AddWithValue("@strAccountNo", sAcc);
                                            cmd.Parameters.AddWithValue("@lngStudentNumbernew", lblStudentId.Text.Trim());
                                            cmd.Parameters.AddWithValue("@strPhone1", txtPhone1.Text.Trim());
                                            cmd.Parameters.AddWithValue("@strPhone2", txtPhone2.Text.Trim());
                                            cmd.Parameters.AddWithValue("@intRegYear", Convert.ToInt32(Session["CurrentYear"]));
                                            cmd.Parameters.AddWithValue("@byteRegSem", Session["CurrentSemester"].ToString());
                                            cmd.Parameters.AddWithValue("@strUserSave", Session["CurrentUserName"].ToString());
                                            //cmd.Parameters.AddWithValue("@dateCreate", DateTime.Now);
                                            cmd.Parameters.AddWithValue("@dateLastSave", DateTime.Now);
                                            try
                                            {
                                                sc.Open();
                                               // objTrans = sc.BeginTransaction();
                                                cmd.ExecuteNonQuery();
                                                //Select Account Number of Student
                                                sc.Close();

                                                //Create SIS User(111)
                                                SqlCommand Cmd = new SqlCommand();
                                                Cmd.Connection = sc;
                                                Cmd.CommandText = "Create_Online_User";
                                                Cmd.CommandType = CommandType.StoredProcedure;
                                                Cmd.Parameters.Add("@sNo", SqlDbType.VarChar).Value = lblStudentId.Text;
                                                Cmd.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = sAcc;
                                                Cmd.Parameters.Add("@iRole", SqlDbType.Int).Value = 111;
                                                try
                                                {
                                                    sc.Open();
                                                    Cmd.ExecuteNonQuery();
                                                    sc.Close();
                                                }
                                                catch (Exception ex)
                                                {
                                                    sc.Close();
                                                    Console.WriteLine(ex.Message);
                                                }
                                                finally
                                                {
                                                    sc.Close();
                                                }

                                                int iStatus = 1;
                                                string sSQL = "UPDATE Reg_Student_Accounts";
                                                sSQL += " SET intOnlineStatus =" + iStatus;
                                                sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate()";
                                                sSQL += " Where strAccountNo='" + sAcc + "'";
                                                Cmd.CommandType = CommandType.Text;
                                                Cmd.CommandText = sSQL;
                                                try
                                                {
                                                    sc.Open();
                                                    Cmd.ExecuteNonQuery();
                                                    sc.Close();
                                                }
                                                catch (Exception ex)
                                                {
                                                    sc.Close();
                                                    Console.WriteLine(ex.Message);
                                                }
                                                finally
                                                {
                                                    sc.Close();
                                                }
                                                string sFName = "";
                                                int iSerial = GetSerial(lblReference.Text.Trim());                                             
                                                //int iUnifiedID = LibraryMOD.GetMaxUnifiedID(Campus, Convert.ToInt32(Session["StudentSerialNo"]), out sFName);
                                                int iUnifiedID = LibraryMOD.GetMaxUnifiedID(Campus, iSerial, out sFName);
                                                //update Unified ID
                                                if (iUnifiedID > 0)
                                                {
                                                    LibraryMOD.UpdateStudentUnifiedID(Campus, Convert.ToInt32(Session["StudentSerialNo"]), iUnifiedID);
                                                    //check reference number
                                                    if (LibraryMOD.UpdateStudentUnifiedIDIfHasRefID(Campus, Convert.ToInt32(Session["StudentSerialNo"])) == true)
                                                    {
                                                        //Get updated UnifiedID
                                                        iUnifiedID = LibraryMOD.GetUnifiedID(Campus, Convert.ToInt32(Session["StudentSerialNo"]));
                                                    }
                                                }
                                                else
                                                {
                                                    iUnifiedID = LibraryMOD.GetUnifiedID(Campus, Convert.ToInt32(Session["StudentSerialNo"]), out sFName);
                                                    if (iUnifiedID == 0)
                                                    {
                                                        iUnifiedID = LibraryMOD.GetMaxUnifiedID_withoutCheckRefID(Campus, Convert.ToInt32(Session["StudentSerialNo"]), out sFName);
                                                    }
                                                    LibraryMOD.UpdateStudentUnifiedID(Campus, Convert.ToInt32(Session["StudentSerialNo"]), iUnifiedID);
                                                }

                                                //Update CX API Registration Status
                                                if (txtContactID.Text!="0"||txtContactID.Text!=""||txtContactID.Text!=null)
                                                {
                                                    updatecxapiregistration(txtContactID.Text);
                                                }
                                                //Sharepoint List Creation
                                                sentdatatoSPLIst();
                                            }
                                            catch (Exception ex)
                                            {
                                                //objTrans.Rollback();
                                                sc.Close();
                                                Console.WriteLine(ex.Message);
                                            }
                                            finally
                                            {
                                                sc.Close();
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        sc.Close();
                                        Console.WriteLine(ex.Message);
                                    }
                                    finally
                                    {
                                        sc.Close();
                                    }
                                }
                                else
                                {
                                    //Create New Student Account

                                    string sAcc = Update_Acc();

                                    if(sAcc!=null || sAcc!=""||sAcc!="0")
                                    {
                                        Session["sAcc"] = sAcc;
                                        //Create SIS User(111)
                                        SqlCommand Cmd = new SqlCommand();
                                        Cmd.Connection = sc;
                                        Cmd.CommandText = "Create_Online_User";
                                        Cmd.CommandType = CommandType.StoredProcedure;
                                        Cmd.Parameters.Add("@sNo", SqlDbType.VarChar).Value = lblStudentId.Text;
                                        Cmd.Parameters.Add("@sAccount", SqlDbType.VarChar).Value = sAcc;
                                        Cmd.Parameters.Add("@iRole", SqlDbType.Int).Value = 111;
                                        try
                                        {
                                            sc.Open();
                                            Cmd.ExecuteNonQuery();
                                            sc.Close();
                                        }
                                        catch(Exception ex)
                                        {
                                            sc.Close();
                                            Console.WriteLine(ex.Message);
                                        }
                                        finally
                                        {
                                            sc.Close();
                                        }


                                        int iStatus = 1;
                                        string sSQL = "UPDATE Reg_Student_Accounts";
                                        sSQL += " SET intOnlineStatus =" + iStatus;
                                        sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=getDate()";
                                        sSQL += " Where strAccountNo='" + sAcc + "'";
                                        Cmd.CommandType = CommandType.Text;
                                        Cmd.CommandText = sSQL;
                                        try
                                        {
                                            sc.Open();
                                            Cmd.ExecuteNonQuery();
                                            sc.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            sc.Close();
                                            Console.WriteLine(ex.Message);
                                        }
                                        finally
                                        {
                                            sc.Close();
                                        }

                                        string sFName = "";
                                        int iUnifiedID = LibraryMOD.GetMaxUnifiedID(Campus, Convert.ToInt32(Session["StudentSerialNo"]), out sFName);
                                        //update Unified ID
                                        if (iUnifiedID > 0)
                                        {
                                            LibraryMOD.UpdateStudentUnifiedID(Campus, Convert.ToInt32(Session["StudentSerialNo"]), iUnifiedID);
                                            //check reference number
                                            if (LibraryMOD.UpdateStudentUnifiedIDIfHasRefID(Campus, Convert.ToInt32(Session["StudentSerialNo"])) == true)
                                            {
                                                //Get updated UnifiedID
                                                iUnifiedID = LibraryMOD.GetUnifiedID(Campus, Convert.ToInt32(Session["StudentSerialNo"]));
                                            }
                                        }
                                        else
                                        {
                                            iUnifiedID = LibraryMOD.GetUnifiedID(Campus, Convert.ToInt32(Session["StudentSerialNo"]), out sFName);
                                            if (iUnifiedID == 0)
                                            {
                                                iUnifiedID = LibraryMOD.GetMaxUnifiedID_withoutCheckRefID(Campus, Convert.ToInt32(Session["StudentSerialNo"]), out sFName);
                                            }
                                            LibraryMOD.UpdateStudentUnifiedID(Campus, Convert.ToInt32(Session["StudentSerialNo"]), iUnifiedID);
                                        }

                                        //Update CX API Registration Status
                                        if (txtContactID.Text != "0" || txtContactID.Text != "" || txtContactID.Text != null)
                                        {
                                            updatecxapiregistration(txtContactID.Text);
                                        }
                                        //Sharepoint List Creation
                                        sentdatatoSPLIst();
                                    }
                                }


                            }
                        }
                        else
                        {
                            lbl_Msg.Text = "Student not Enrolled !";
                            div_msg.Visible = true;
                        }
                    }
                    else
                    {
                        lbl_Msg.Text = "HS AVG or ENG Score doesn’t meet the major requirement …!";
                        div_msg.Visible = true;
                        MultiTabs.ActiveViewIndex = 0;
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

                    if (ddlWMajor1.SelectedValue == "0")
                    {
                        lbl_Msg.Text = "Select the First Preferred Major Please.";
                        div_msg.Visible = true;
                        ddlWMajor1.Focus();
                        return;
                    }

                    //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                    //    InitializeModule.enumPrivilege.AcceptStudent, CurrentRole) != true)
                    //{
                    //    divMsg.InnerText = "Sorry you cannot update enrollment data";
                    //    return;
                    //}

                    int iTerm, iGraduationYear, iGraduationSem;
                    iTerm = int.Parse(ddlStatusTerm.SelectedValue);
                    iGraduationYear = LibraryMOD.SeperateTerm(iTerm, out iGraduationSem);

                    //EnrollmentDS.UpdateParameters.Add("@intGraduationYear", iGraduationYear.ToString());
                    //EnrollmentDS.UpdateParameters.Add("@byteGraduationSemester", iGraduationSem.ToString());

                    iEffected = EnrollmentDS.Update();
                    if (iEffected > 0)
                    {
                        lbl_Msg.Text = "Student Enrollment Updated Successfully ...";
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        div_msg.Visible = true;
                    }
                    LibraryMOD.UpdateCRM_StudentID(lblStudentId.Text, txtPhone1.Text);

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
        public void sentdatatoSPLIst()
        {
            int sem = 0;
            int Year = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out sem);

            int iYear = Year;
            int iSem = sem;
            string sSemester = LibraryMOD.GetSemesterString(iSem);
            int iTerm = iYear * 10 + iSem;

            string Addedby = "";
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * from ACMS_User where ACMS_User.Personnelnr='E" + Session["EmployeeID"].ToString() + "'", sc);            
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    Addedby= dt.Rows[0]["Email"].ToString();
                }
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                sc.Close();
            }

            string AlertTo = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc1 = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd1 = new SqlCommand("SELECT sACCAlert from Cmn_Firm", sc1);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            try
            {
                sc1.Open();
                da1.Fill(dt1);
                sc1.Close();

                if (dt1.Rows.Count > 0)
                {
                    AlertTo = dt1.Rows[0]["sACCAlert"].ToString();
                }
            }
            catch (Exception ex)
            {
                sc1.Close();
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                sc1.Close();
            }
            string gender = "";
            if(rbnGender.SelectedValue=="0")
            {
                gender = "Female";
            }
            else
            {
                gender = "Male";
            }

            string login = "ets.services.admin@ect.ac.ae"; //give your username here  
            string password = "Ser71ces@328"; //give your password  
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices";
            ClientContext clientContext = new ClientContext(siteUrl);
            Microsoft.SharePoint.Client.List myList = clientContext.Web.Lists.GetByTitle("New Admission");
            ListItemCreationInformation itemInfo = new ListItemCreationInformation();
            Microsoft.SharePoint.Client.ListItem myItem = myList.AddItem(itemInfo);            
            myItem["Term"] = Convert.ToInt32(ddlEnrollmentTerm.SelectedValue);
            myItem["UID"] = lblUnified.Text.Trim();
            myItem["ACC"] = Session["sAcc"].ToString();
            myItem["SID"] = lblStudentId.Text.Trim();
            myItem["Name"] = txtNameEn.Text.Trim();
            myItem["Gender"] = gender;
            myItem["eMail"] = ""; //Student Email    
            myItem["CXID"] = txtContactID.Text.Trim();
            //myItem["AddedBy"] = clientContext.Web.EnsureUser("ihab.awad@ect.ac.ae");//Addedby
            myItem["AddedBy"] = clientContext.Web.EnsureUser(Addedby);
            //myItem["AlertTo"] = clientContext.Web.EnsureUser("sujeesh.sureshkumar@ect.ac.ae");//AlertTo  
            myItem["AlertTo"] = clientContext.Web.EnsureUser(AlertTo);
            try
            {
                myItem.Update();
                var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
                clientContext.Credentials = onlineCredentials;
                clientContext.ExecuteQuery();        
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Console.ReadLine();
        }
        private string Get_New_Acc()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            string sNewAcc = "";
            try
            {

                string sSQL = "SELECT sNewACC FROM New_ACC";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);

                sNewAcc = Cmd.ExecuteScalar().ToString();

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sNewAcc;
        }
        private string Update_Acc()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            string newAcc= Get_New_Acc();
            try
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandText = "Add_Account";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Conn;
                Cmd.Parameters.Add("@strAccountNo", SqlDbType.VarChar).Value = newAcc;
                Cmd.Parameters.Add("@strStudentName", SqlDbType.VarChar).Value = txtNameEn.Text;
                Cmd.Parameters.Add("@lngStudentNumber", SqlDbType.VarChar).Value = lblStudentId.Text.Trim();
                Cmd.Parameters.Add("@strPhone1", SqlDbType.VarChar).Value = txtPhone1.Text;
                Cmd.Parameters.Add("@byteAccountStatus", SqlDbType.SmallInt).Value = 0;
                //int iTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
                //int iYear = 0;
                //int iSem = 0;
                //iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);
                int iCSem = 0;
                int iCYear = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out iCSem);
                Cmd.Parameters.Add("@intRegYear", SqlDbType.Int).Value = iCYear;
                Cmd.Parameters.Add("@byteRegSem", SqlDbType.SmallInt).Value = iCSem;
                Cmd.Parameters.Add("@intDelegation", SqlDbType.Int).Value = 0;
                Cmd.Parameters.Add("@curDelegation", SqlDbType.Decimal).Value = 0;
                Cmd.Parameters.Add("@strDelegationNote", SqlDbType.VarChar).Value = DBNull.Value;
                Cmd.Parameters.Add("@strNote", SqlDbType.VarChar).Value = DBNull.Value;
                Cmd.Parameters.Add("@byteType", SqlDbType.SmallInt).Value = 0;
                Cmd.Parameters.Add("@intOnlineStatus", SqlDbType.Int).Value = 1;
                //Cmd.Parameters.Add("@intOnlineUser", SqlDbType.Int).Value = 0;
                //Cmd.Parameters.Add("@strOnlinePWD", SqlDbType.VarChar).Value = "";
                string sUser = Session["CurrentUserName"].ToString();
                Cmd.Parameters.Add("@sUser", SqlDbType.VarChar).Value = sUser;
                Cmd.ExecuteNonQuery();

                
                //if (ddlIDs.SelectedValue != "0")
                //{
                //    Cmd.CommandText = "UPDATE Reg_Applications SET bOtherCollege =" + rbnStatus.SelectedValue + "  WHERE lngStudentNumber='" + ddlIDs.SelectedValue + "'";
                //    Cmd.CommandType = CommandType.Text;
                //    Cmd.ExecuteNonQuery();
                //}

                // divMsg.InnerText = "Data Updated Successfully";
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return newAcc;
        }
        public void updatecxapiregistration(string contactid)
        {
            string registrationstatus = "Unregistered";
            string retention_status = "Opened";
            string numberofregisteredcourses = "0";
            string cgpa = "0";
            string ect_student_id = lblStudentId.Text;
            string financialbalance = "A";
            string sisusername = lblStudentId.Text;
            string sispassword = "ect@12345";
            string ectemailpassword = "ect@12345";
            string major = ddlMajor.SelectedItem.Text;
            string Credit_Completed = "0";

            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("SELECT  [UserNo],[UserName],[Password] FROM [ECTDataNew].[dbo].[Cmn_User] where UserNo in (SELECT intOnlineUser from [ECTData].[dbo].[Reg_Student_Accounts] where lngStudentNumber=@lngStudentNumber)", sc);
            cmd.Parameters.AddWithValue("@lngStudentNumber", lblStudentId.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    sisusername = dt.Rows[0]["UserName"].ToString();
                    sispassword = dt.Rows[0]["Password"].ToString();
                }
            }
            catch(Exception ex)
            {
                sc.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sc.Close();
            }

            //API Call

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string accessToken = InitializeModule.CxPwd;
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), "https://ect.custhelp.com/services/rest/connect/v1.4/contacts/" + contactid + ""))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", accessToken);
                    request.Headers.TryAddWithoutValidation("OSvC-CREST-Application-Context", "application/x-www-form-urlencoded");

                    request.Content = new StringContent("{\n    \"customFields\": {\n        \"c\": {\n            \"registrationstatus\": {\n                \"lookupName\": \"" + registrationstatus + "\"\n            },\n            \"numberofregisteredcourses\": " + numberofregisteredcourses + ",\n            \"cgpa\": " + cgpa + ",\n            \"retention_status\": {\n                \"lookupName\": \"" + retention_status + "\"\n            },\n            \"ect_student_id\": \"" + ect_student_id + "\",\n            \"financialbalance\": \"" + financialbalance + "\",\n            \"sisusername\": \"" + sisusername + "\",\n            \"sispassword\": \"" + sispassword + "\",\n            \"ectemailpassword\": \"" + ectemailpassword + "\"\n        },\n        \"CO\": {\n            \"Major\": \"" + major + "\",\n            \"Credit_Completed\": " + Credit_Completed + "\n        }\n    }\n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    string s = response.Content.ReadAsStringAsync().Result;
                    //If Status 200
                    if (response.IsSuccessStatusCode == true)
                    {
                        //API Call-Update Registration Status-SUCCESS
                    }

                }
            }
        }




        protected void AddESLs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblStudentId.Text))
            {
                lbl_Msg.Text = "Select or Enroll a Student First";
                div_msg.Visible = true;
                return;
            }
            int iCalculated = Calc_ESLs(lblStudentId.Text);
            lbl_Msg.Text = "( " + iCalculated + " ) ESLs Courses Exempted Successfully ...";
            div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
            div_msg.Visible = true;

            mtvMarks.ActiveViewIndex = 0;
            grdMarks.DataBind();

            MultiTabs.ActiveViewIndex = 3;
        }
        private int Calc_ESLs(string sID)
        {
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            int iCalc = 0;
            try
            {
                string sSQL = "SELECT  ENG.lngStudentNumber, ENG.intCertificate, ENG.strCert, ENG.Mark, L.byteLevel";
                sSQL += " FROM MaxEngCertMark AS ENG INNER JOIN Reg_Levels AS L ON ENG.intCertificate = L.intCert AND ENG.Mark >= L.curMin AND ENG.Mark <= L.curMax";
                sSQL += " WHERE ENG.lngStudentNumber='" + sID + "'";

                int iCert = 0;
                double iMark = 0;
                int iLevel = 0;

                bool isArabic = false;
                ApplicationsDAL theStudentApplication = new ApplicationsDAL();

                InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;

                Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];

                string sMajorID = theStudentApplication.GetMajor(Campus, sID);

                if (sMajorID == "24" || sMajorID == "25")
                {
                    isArabic = true;
                }
                else
                {
                    isArabic = false;
                }

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);

                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    iCert = int.Parse(Rd["intCertificate"].ToString());
                    iMark = double.Parse(Rd["Mark"].ToString());
                    iLevel = int.Parse(Rd["byteLevel"].ToString());
                }
                Rd.Close();

                sSQL = " SELECT strCourse FROM Reg_Course_Levels";
                sSQL += " WHERE intCert=" + iCert + " AND byteLevel=" + iLevel + " AND bReg=0";

                Cmd.CommandText = sSQL;

                Rd = Cmd.ExecuteReader();
                List<ENGCourse> myENGs = new List<ENGCourse>();
                ENGCourse myENG;
                while (Rd.Read())
                {
                    myENG = new ENGCourse();
                    if (isArabic)
                    {
                        if ((Rd["strCourse"].ToString() == "ESL100") || (Rd["strCourse"].ToString() == "ESL101")) //|| (Rd["strCourse"].ToString() == "ESL102")
                        {
                            myENG.SCourse = "ESL101A";
                        }
                        else
                        {
                            myENG.SCourse = "ESL102A";
                        }

                    }
                    else
                    {
                        myENG.SCourse = Rd["strCourse"].ToString();
                    }
                    myENG.SGrade = "EX";
                    myENGs.Add(myENG);
                }
                Rd.Close();

                string sUser = Session["CurrentUserName"].ToString();
                bool isPassed = false;
                for (int i = 0; i < myENGs.Count; i++)
                {
                    isPassed = false;
                    sSQL = "SELECT GS.bPassIt FROM Reg_Grade_Header AS GH INNER JOIN Reg_Grade_System AS GS ON GH.strGrade = GS.strGrade";
                    sSQL += " WHERE GH.strCourse ='" + myENGs[i].SCourse + "' AND GH.lngStudentNumber ='" + sID + "'";

                    Cmd.CommandText = sSQL;
                    isPassed = Convert.ToBoolean(Cmd.ExecuteScalar());
                    if (!isPassed)
                    {
                        sSQL = "Insert Into Reg_Grade_Header";
                        sSQL += " (lngStudentNumber, intStudyYear, byteSemester, strCourse, byteClass, byteShift, strGrade, strUserCreate, dateCreate, curUseMark, bDisActivated)";
                        sSQL += " Values('" + sID + "',0,0,'" + myENGs[i].SCourse + "',1,1,'" + myENGs[i].SGrade + "',";
                        sSQL += "'" + sUser + "',GETDATE(),333,0)";
                        Cmd.CommandText = sSQL;
                        iCalc += Cmd.ExecuteNonQuery();
                    }
                }

                myENGs.Clear();
                //iCalc = Cmd.ExecuteNonQuery();

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
            return iCalc;

        }

        protected void Print_btn_Click(object sender, EventArgs e)
        {
            if (CurrentRole == 169 && ddlPrinting.SelectedValue != "4")//Staff Part time
            {              
                lbl_Msg.Text = "Sorry you cannot print " + ddlPrinting.SelectedItem.Text;
                div_msg.Visible = true;
                return;
            }
            Retrieve(Convert.ToInt32(ddlPrinting.SelectedValue));
            Export(Convert.ToInt32(ddlPrinting.SelectedValue));
        }
        private void Retrieve(int iReport)
        {
            DataSet Ds = new DataSet();
            try
            {

                string sSno = lblStudentId.Text;

                if (iReport != 2)//Admission Form
                {

                    Ds = Prepare_Report(sSno);
                }
                else
                {
                    Ds = Prepare_Admission(sSno);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {

                Session["ReportDS"] = Ds;

            }

        }
        private DataSet Prepare_Admission(string sSno)
        {
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            try
            {
                DataColumn dc;

                dc = new DataColumn("No", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("SYear", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("SSem", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("SSession", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Gender", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("SProgram", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("SMajor", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Title", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("FName", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("SName", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("LName", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("FullName", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("BirthDate", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Nationality", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("EID", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Language", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Phone1", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Phone2", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Fax", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("eMail", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sECTemail", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Address", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("EName", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("EPhone1", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("EPhone2", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Degree", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Institute", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("DegreeDate", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("EUser", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("EDate", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sRegisteredThrough", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iImage", Type.GetType("System.Byte[]"));
                dt.Columns.Add(dc);

                string sSQL = "";
                sSQL += "SELECT A.lngStudentNumber AS No, CONVERT(varchar(4), A.intStudyYear) + '/' + CONVERT(varchar(4), A.intStudyYear + 1) AS SYear, S.strSemesterDescEn AS SSem,";
                sSQL += " SE.strShiftEn AS SSession, (CASE WHEN bSex = 0 THEN 'Female' ELSE 'Male' END) AS Gender, D.strDegreeDescEn AS SProgram, M.strDisplay AS SMajor, '' AS Title,";
                sSQL += " SD.strFirstDescEn AS FName, '' AS SName, SD.strSecondDescEn AS LName, SD.strLastDescEn AS FullName, SD.dateBirth AS BirthDate,";
                sSQL += " N.strNationalityDescEn AS Nationality, SD.strNationalID AS EID, L.strLanguageDescEn AS Language, dbo.CleanPhone(SD.strPhone1) AS Phone1,";
                sSQL += " dbo.CleanPhone(SD.strPhone2) AS Phone2, SD.strFax AS Fax, SD.strEmail AS eMail,sECTemail, SD.strAddress AS Address, '' AS EName, '' AS EPhone1, '' AS EPhone2,";
                sSQL += " '' AS Degree, '' AS Institute, '' AS DegreeDate, SD.strUserCreate AS EUser, SD.dateCreate AS EDate,Lkp_RegisteredThrough.RegisteredThroughDesc AS sRegisteredThrough";

                sSQL += " , FM1.MajorDescEn AS FMajor1, FC.FacultyName AS Faculty, FM2.MajorDescEn AS FMajor2,FM3.MajorDescEn AS FMajor3,A.sReference AS Ref";

                sSQL += " FROM Lkp_Languages AS L RIGHT OUTER JOIN Lkp_FoundationMajors AS FM2 RIGHT OUTER JOIN Reg_Applications AS A INNER JOIN";
                sSQL += " Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN";
                sSQL += " Lkp_Semesters AS S ON A.byteSemester = S.byteSemester INNER JOIN Reg_Shifts AS SE ON SD.byteShift = SE.byteShift INNER JOIN";
                sSQL += " Reg_Degrees AS D ON M.strCollege = D.strCollege AND M.strDegree = D.strDegree INNER JOIN Lkp_FoundationMajors AS FM1 ON A.WantedMajorID = FM1.MajorID LEFT OUTER JOIN";
                sSQL += " Reg_Faculty AS FC ON FM1.FacultyID = FC.FacultyID LEFT OUTER JOIN Lkp_FoundationMajors AS FM3 ON A.WantedMajorID3 = FM3.MajorID ON FM2.MajorID = A.WantedMajorID2 LEFT OUTER JOIN";
                sSQL += " Lkp_RegisteredThrough ON A.iRegisteredThrough = Lkp_RegisteredThrough.ID ON L.byteLanguage = SD.byteReligion LEFT OUTER JOIN Lkp_Nationalities AS N ON SD.byteNationality = N.byteNationality";

                //sSQL += " FROM Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ";
                //sSQL += " ON A.lngSerial = SD.lngSerial INNER JOIN";
                //sSQL += " Reg_Specializations AS M ON A.strCollege = M.strCollege ";
                //sSQL += " AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization";
                //sSQL += " INNER JOIN Lkp_Semesters AS S ON A.byteSemester = S.byteSemester ";
                //sSQL += " INNER JOIN Reg_Shifts AS SE ON SD.byteShift = SE.byteShift ";
                //sSQL += " INNER JOIN Reg_Degrees AS D ON M.strCollege = D.strCollege AND M.strDegree = D.strDegree ";
                //sSQL += " LEFT OUTER JOIN  Lkp_RegisteredThrough ON A.iRegisteredThrough = dbo.lkp_RegisteredThrough.ID ";
                //sSQL += " LEFT OUTER JOIN Lkp_Languages AS L ON SD.byteReligion = L.byteLanguage ";
                //sSQL += " LEFT OUTER JOIN Lkp_Nationalities AS N ON SD.byteNationality = N.byteNationality";

                sSQL += " Where A.lngStudentNumber='" + sSno + "'";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                string sGender = "";
                string sTile = "";
                string sEmp = "";
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    dr = dt.NewRow();
                    dr["No"] = Rd["No"].ToString().Replace(".", "");
                    dr["SYear"] = Rd["SYear"].ToString();
                    dr["SSem"] = Rd["SSem"].ToString();
                    dr["SSession"] = Rd["SSession"].ToString();
                    sGender = Rd["Gender"].ToString();
                    dr["Gender"] = sGender;
                    dr["SProgram"] = Rd["FMajor1"].ToString();
                    dr["SMajor"] = Rd["SMajor"].ToString();
                    if (sGender == "Male")
                    {
                        sTile = "MR";
                    }
                    else
                    {
                        sTile = "MS/MRS";
                    }
                    dr["Title"] = sTile;
                    dr["FName"] = Rd["FName"].ToString();
                    dr["SName"] = "-";//Rd["SName"].ToString();
                    dr["LName"] = Rd["LName"].ToString();
                    dr["FullName"] = Rd["FullName"].ToString();
                    dr["BirthDate"] = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Rd["BirthDate"]));
                    dr["Nationality"] = Rd["Nationality"].ToString();
                    dr["EID"] = Rd["EID"].ToString();
                    dr["Language"] = Rd["FMajor2"].ToString();
                    dr["Phone1"] = Rd["Phone1"].ToString();
                    if (Rd["Phone2"].ToString() == "0")
                    {
                        dr["Phone2"] = "-";
                    }
                    else
                    {
                        dr["Phone2"] = Rd["Phone2"].ToString();
                    }
                    dr["Fax"] = Rd["Ref"].ToString();
                    dr["eMail"] = Rd["eMail"].ToString();
                    dr["sECTemail"] = Rd["sECTemail"].ToString();
                    dr["Address"] = Rd["Address"].ToString();
                    dr["EName"] = Rd["FMajor3"].ToString();
                    dr["EPhone1"] = Rd["EPhone1"].ToString();
                    dr["EPhone2"] = Rd["EPhone2"].ToString();
                    dr["Degree"] = Rd["Degree"].ToString();
                    dr["Institute"] = Rd["Faculty"].ToString();
                    dr["DegreeDate"] = Rd["DegreeDate"].ToString();
                    sEmp = LibraryMOD.GetTheUserEmpName(Rd["EUser"].ToString());
                    dr["EUser"] = sEmp;
                    dr["EDate"] = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Rd["EDate"]));
                    dr["sRegisteredThrough"] = Rd["sRegisteredThrough"].ToString();

                    //if (File.Exists(Server.MapPath(imgStudent.ImageUrl)))
                    //{
                    //    FileStream fstr = new FileStream(Server.MapPath(imgStudent.ImageUrl), FileMode.Open);
                    //    BinaryReader br = new BinaryReader(fstr);
                    //    dr["iImage"] = br.ReadBytes((int)br.BaseStream.Length);
                    //    fstr.Close();
                    //    br.Close();
                    //}
                    if (imgStudent.ImageUrl != "~/Images/Students/Student.jpeg" && imgStudent.ImageUrl != "~/Images/Students/PIC999999999999999.jpeg")
                    {
                        if (System.IO.File.Exists(Server.MapPath(imgStudent.ImageUrl)))
                        {
                            FileStream fstr = new FileStream(Server.MapPath(imgStudent.ImageUrl), FileMode.Open);
                            BinaryReader br = new BinaryReader(fstr);
                            dr["iImage"] = br.ReadBytes((int)br.BaseStream.Length);
                            fstr.Close();
                            br.Close();
                        }
                    }
                    dt.Rows.Add(dr);
                }
                Rd.Close();
                dt.TableName = "Admission";
                dt.AcceptChanges();
                ds.Tables.Add(dt);

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }

            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return ds;
        }
        private DataSet Prepare_Report(string sSno)
        {
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            try
            {
                DataColumn dc;

                dc = new DataColumn("sSno", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sName", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sPeriod", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sMajor", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sWMajor", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sWMajor2", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sWMajor3", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("dHS", Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sENG", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("dScore", Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sPhone1", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sPhone2", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("dEntered", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sEntered", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("dEnrolled", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sYear", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sSem", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sHSType", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sHSSource", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sPwd", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sEmail", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sECTemail", Type.GetType("System.String"));
                dt.Columns.Add(dc);



                string sSQL = "SELECT A.lngStudentNumber AS sSno, SD.strLastDescEn AS sName, P.strShiftEn AS sPeriod,";
                sSQL += "M.strSpecializationDescEn AS sMajor, HS.sngGrade AS dHS,E.strCert AS sENG, E.Mark AS dScore,";
                sSQL += "SD.strPhone1 AS sPhone1, SD.strPhone2 AS sPhone2, A.dateCreate AS dEntered, A.strUserCreate AS sEntered, SD.strEmail AS sEmail,sECTemail, AC.strOnlinePWD AS sPWD";
                sSQL += ",A.dateApplication AS dEnrolled, A.intStudyYear AS iYear, S.strSemesterDescEn AS sSem, SP.strSpecializationDescEn AS sHSType, Q.strCertificateSource AS sHSSource,sECTId";

                sSQL += " FROM Reg_Student_Accounts AS AC RIGHT OUTER JOIN Reg_Applications AS A INNER JOIN";
                sSQL += " Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN Reg_Shifts AS P ON SD.byteShift = P.byteShift INNER JOIN";
                sSQL += " Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN";
                sSQL += " Lkp_Semesters AS S ON A.byteSemester = S.byteSemester ON AC.lngStudentNumber = A.lngStudentNumber LEFT OUTER JOIN";
                sSQL += " Reg_Student_Qualifications AS Q LEFT OUTER JOIN Lkp_Specializations AS SP ON Q.intMajor = SP.intSpecialization RIGHT OUTER JOIN";
                sSQL += " HS ON Q.lngSerial = HS.lngSerial AND Q.intCertificate = HS.intCertificate ON SD.lngSerial = HS.lngSerial LEFT OUTER JOIN MaxEngCertMark AS E ON A.lngStudentNumber = E.lngStudentNumber";

                sSQL += " Where A.lngStudentNumber='" + sSno + "'";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                int iYear = 0;
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    dr = dt.NewRow();
                    if (ddlPrinting.SelectedValue == "0")
                    {
                        dr["sSno"] = Rd["sECTId"].ToString();
                    }
                    else
                    {
                        dr["sSno"] = Rd["sSno"].ToString().Replace(".", "");
                    }
                    dr["sName"] = Rd["sName"].ToString();
                    dr["sPeriod"] = Rd["sPeriod"].ToString();
                    dr["sMajor"] = Rd["sMajor"].ToString();
                    dr["sWMajor"] = ddlWMajor1.SelectedItem.Text;
                    dr["sWMajor2"] = ddlWMajor2.SelectedItem.Text;
                    dr["sWMajor3"] = ddlWMajor3.SelectedItem.Text;
                    if (!Rd["dHS"].Equals(DBNull.Value))
                    {
                        dr["dHS"] = Convert.ToDecimal(Rd["dHS"].ToString());
                    }
                    if (!Rd["dScore"].Equals(DBNull.Value))
                    {
                        dr["dScore"] = Convert.ToDecimal(Rd["dScore"].ToString());
                        dr["sENG"] = Rd["sENG"].ToString();
                    }
                    dr["sPhone1"] = Rd["sPhone1"].ToString();
                    dr["sPhone2"] = Rd["sPhone2"].ToString();
                    dr["dEntered"] = Rd["dEntered"].ToString();
                    dr["sEntered"] = Rd["sEntered"].ToString();
                    dr["dEnrolled"] = Rd["dEnrolled"].ToString();
                    iYear = Convert.ToInt32(Rd["iYear"].ToString());
                    dr["sYear"] = iYear.ToString() + " / " + (iYear + 1).ToString();
                    dr["sSem"] = Rd["sSem"].ToString();
                    dr["sHSType"] = Rd["sHSType"].ToString();
                    dr["sHSSource"] = Rd["sHSSource"].ToString();
                    dr["sPwd"] = Rd["sPWD"].ToString();
                    dr["sEmail"] = sSno.Replace(".", "") + "@ect.ac.ae";//Rd["sEmail"].ToString();
                    dr["sECTemail"] = Rd["sECTemail"].ToString();
                    dt.Rows.Add(dr);

                }
                Rd.Close();
                dt.TableName = "Profile";
                dt.AcceptChanges();
                ds.Tables.Add(dt);

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return ds;
        }
        private void Export(int iType)
        {
            ReportDocument myReport = new ReportDocument();

            try
            {
                DataSet rptDS = new DataSet();

                rptDS = (DataSet)Session["ReportDS"];
                string reportPath = "";
                TextObject txt;
                switch (iType)
                {
                    case 0://Welcome Letter
                        reportPath = Server.MapPath("Reports/ST_Welcome.rpt");
                        break;
                    case 1://Admission Letter
                        if (LibraryMOD.IsFileVerifiedFromRegistrar(lblStudentId.Text, Campus) == InitializeModule.FALSE_VALUE)
                        {                            
                            lbl_Msg.Text = "Please contact the Registrar to verfiy student file";
                            div_msg.Visible = true;
                            myReport.Close();
                            myReport.Dispose();
                            return;
                        }
                        if (lblStudentId.Text.StartsWith("ESM") || lblStudentId.Text.StartsWith("ESF"))
                        {
                            reportPath = Server.MapPath("Reports/ST_Admission_ESL.rpt");
                        }
                        else
                        {
                            reportPath = Server.MapPath("Reports/ST_Admission_Regular.rpt");
                        }
                        break;
                    case 2://Admission From
                        reportPath = Server.MapPath("Reports/ST_Admission_Form.rpt");

                        break;
                    case 3://Profile Cover
                        reportPath = Server.MapPath("Reports/ST_Profile.rpt");

                        break;
                    case 4://PWD
                        reportPath = Server.MapPath("Reports/ST_Pwds.rpt");

                        break;

                }
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);

                //if (iType == 2)
                //{
                //    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtYears"];
                //    switch (ddlType.SelectedIndex)
                //    {
                //        case 0:
                //            txt.Text = " to the ECT foundation certificate program";
                //            break;
                //        case 1:
                //            txt.Text = " to the ECT two-year diploma program in ";
                //            break;
                //        case 2:
                //            txt.Text = " to the ECT four-year bachelor program in";
                //            break;
                //        case 3:
                //            txt.Text = " as visiting student";
                //            txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtMajor"];
                //            txt.ObjectFormat.EnableSuppress = true;
                //            break;
                //        case 4:
                //            txt.Text = " as language center student";
                //            txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtMajor"];
                //            txt.ObjectFormat.EnableSuppress = true;
                //            break;
                //    }
                //}                 


                //txt.Text = GetCaption();
                if (iType != 2)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                    string sUserName = Session["CurrentUserName"].ToString();
                    txt.Text = sUserName;
                }

                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                myReport.Close();
                myReport.Dispose();
            }
        }

        protected void grdDocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvDocs.DataBind();
            mtvDocs.ActiveViewIndex = 1;
        }

        protected void btnAddDocs_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            try
            {

                if (hdnSerial.Value == "")
                {                    
                    lbl_Msg.Text = "Select or Add Student Please ...";
                    div_msg.Visible = true;
                    return;
                }

                string sSQL = "Delete From Reg_Students_Documents Where lngSerial=" + hdnSerial.Value;
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                int iEffected = 0;
                iEffected = Cmd.ExecuteNonQuery();

                sSQL = "INSERT INTO Reg_Students_Documents";
                sSQL += " (lngSerial, intDocument, isMandatory, isAvailable, strRemark, strUserCreate, dateCreate)";
                sSQL += " SELECT " + hdnSerial.Value + " AS lSerial, intDocument, isMandatory, (CASE LD.intDocument WHEN 10 THEN 1 ELSE LD.isMandatory END) AS isAvailable, '' AS sRemark, ";
                sSQL += " '" + Session["CurrentUserName"].ToString() + "' AS sUser, GETDATE() AS dDate FROM Lkp_Student_Documents AS LD";

                Cmd.CommandText = sSQL;

                iEffected = Cmd.ExecuteNonQuery();
                if (iEffected > 0)
                {       
                    lbl_Msg.Text = "Documents Initiated Successfully ...";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    div_msg.Visible = true;
                    grdDocs.DataBind();
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

        protected void dvDocs_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            try
            {
                string sUser = Session["CurrentUserName"].ToString();
                grdDocs.DataBind();
                mtvDocs.ActiveViewIndex = 0;

                string sSQL = "SELECT lngStudentNumber,Docs FROM Student_Missed_Docs Where lngSerial=" + hdnSerial.Value;
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                int iDocs = 0;
                string sSno = "";
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    sSno = Rd["lngStudentNumber"].ToString();
                    iDocs = Convert.ToInt32("0" + Rd["Docs"].ToString());
                }
                Rd.Close();
                if (iDocs > 0)
                {
                    sSQL = "UPDATE Reg_Applications  SET bActive = 0,bContinue = 1,strUserSave='" + sUser + "',dateLastSave=getdate() WHERE lngSerial=" + hdnSerial.Value;
                    Cmd.CommandText = sSQL;
                    int iEffected = Cmd.ExecuteNonQuery();
                    if (iEffected > 0)
                    {
                        chkActive.Checked = false;
                        chkMissing.Checked = true;
                    }
                }
                else
                {
                    sSQL = "UPDATE Reg_Applications  SET bActive = 1,bContinue = 0,strUserSave='" + sUser + "',dateLastSave=getdate() WHERE lngSerial=" + hdnSerial.Value;
                    Cmd.CommandText = sSQL;
                    int iEffected = Cmd.ExecuteNonQuery();
                    if (iEffected > 0)
                    {
                        chkActive.Checked = true;
                        chkMissing.Checked = false;
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
                Conn.Close();
                Conn.Dispose();

            }
        }

        protected void AddM_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.ESLCalc, CurrentRole) != true)
                {
                    lbl_Msg.Text = "Sorry you cannot add mark to students";
                    div_msg.Visible = true;
                    return;
                }

                if (lblStudentId.Text != "")
                {
                    mtvMarks.ActiveViewIndex = 1;
                }
                else
                {                    
                    lbl_Msg.Text = "Select or Add Student Please ...";
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

        protected void SaveM_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int iEffected = 0;
                iEffected = MarksDS.Insert();
                if (iEffected > 0)
                {                    
                    lbl_Msg.Text = "Mark Added Successfully ...";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    div_msg.Visible = true;
                    grdMarks.DataBind();
                    mtvMarks.ActiveViewIndex = 0;
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

        protected void UndoM_btn_Click(object sender, EventArgs e)
        {
            mtvMarks.ActiveViewIndex = 0;
            ddlMark.SelectedValue = "EX";
            ddlCourses.SelectedValue = null;
        }
        protected void lnkSelect_Command(object sender, CommandEventArgs e)
        {
            int iKey = int.Parse(e.CommandArgument.ToString());
            GetStudent(iKey);
            lblReference.Enabled = true;
        }
        protected void Search_Print_Command(object sender, CommandEventArgs e)
        {
            DataSet Ds = new DataSet();
            try
            {

                string sSno = e.CommandArgument.ToString();

                Ds = Prepare_Report(sSno);

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {

                Session["ReportDS"] = Ds;
                Export(0);
            }

        }

        protected void RunCMD_Click(object sender, EventArgs e)
        {
            try
            {
                RunSearch();
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
        private void RunSearch()
        {
            try
            {
                string sSQL = "SELECT  SD.lngSerial, A.lngStudentNumber, SD.strLastDescEn, SD.dateCreate";
                sSQL += " FROM Reg_Applications AS A RIGHT OUTER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial";
                if (!string.IsNullOrEmpty(txtSearchID.Text) || !string.IsNullOrEmpty(txtSearchName.Text))
                {

                    sSQL += " Where 1=1";
                    if (!string.IsNullOrEmpty(txtSearchID.Text))
                    {
                        sSQL += " And A.lngStudentNumber LIKE '%" + txtSearchID.Text + "%'";
                    }
                    if (!string.IsNullOrEmpty(txtSearchName.Text))
                    {
                        sSQL += " And SD.strLastDescEn LIKE '%" + txtSearchName.Text + "%'";
                    }
                }
                else
                {
                    sSQL += " Where 1<>1";
                }
                sSQL += " ORDER BY SD.dateCreate DESC";

                SearchDS.SelectCommand = sSQL;
                SearchDS.DataBind();
                grdSearch.DataBind();
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
        protected void ddlIWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlIWork.SelectedItem.Text!="Other")
            {
                txtCompany.Text = ddlIWork.SelectedItem.Text;
                txtCompany.Enabled = false;
            }
            else
            {
                txtCompany.Text = "NA";
                txtCompany.Enabled = true;
            }
        }
    }
}