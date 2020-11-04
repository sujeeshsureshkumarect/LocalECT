using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

                        if(Request.QueryString["sid"] !=null && Request.QueryString["sid"] !="")
                        {
                            Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                            Session["StudentSerialNo"] = GetSerial(Request.QueryString["sid"]);
                        }
                    }
                }
                else
                {
                    Session.RemoveAll();
                    Response.Redirect("Login.aspx");
                }

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
            }
            catch (Exception ex)
            {

            }
            finally
            {

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
    }
}