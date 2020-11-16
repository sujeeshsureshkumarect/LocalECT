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
    public partial class Acc_Search_Fee_Payment : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        int CurrentRole = 0;
        int iCYear = 0;
        int iCSem = 0;
        int iTerm = 0;
        string sOAcc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                if (Session["CurrentCampus"].ToString() == "Males")
                {
                    Campus = InitializeModule.EnumCampus.Males;
                }
                else
                {
                    Campus = InitializeModule.EnumCampus.Females;
                }
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ACC_Search,
                    InitializeModule.enumPrivilege.ACCAddStPayment, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }
                    iCYear = Convert.ToInt32(Session["CurrentYear"].ToString());
                    iCSem = Convert.ToInt32(Session["CurrentSemester"].ToString()); ;
                    iTerm = iCYear * 10 + iCSem;
                    if (Request.QueryString["sAcc"] != null && Request.QueryString["sAcc"] != "")
                    {
                        string sAcc = Request.QueryString["sAcc"];
                    }
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
    }
}