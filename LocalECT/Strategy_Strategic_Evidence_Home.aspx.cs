using System;
using System.Collections;
using System.Configuration;
using LocalECT.DAL;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;

namespace LocalECT
{
    public partial class Strategy_Strategic_Evidence_Home : System.Web.UI.Page
    {
        int CurrentRole = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];
                    if (!IsPostBack)
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Evidence,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        {
                            Server.Transfer("Authorization.aspx");
                        }
                    }
                }
                else
                {
                    Session.RemoveAll();
                    Response.Redirect("Login.aspx");

                }
                if (Session["CurrentUserName"] != null)
                {
                    if (!IsPostBack)
                    {
                        bindStrategic_Evidence();
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }
        }

        public void bindStrategic_Evidence()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            string sSQL = "";
            sSQL += " SELECT        CS_Strategic_Evidence.iSerial, CS_Strategic_Evidence.sRevisionNo, CS_Strategic_Evidence.iEvidenceType, CS_Strategic_Evidence.sEvidenceTitle, CS_Strategic_Evidence.sAbbreviation,  ";
            sSQL += "                          CS_Strategic_Evidence.sEvidenceSerial, CS_Strategic_Evidence.iDepartment, CS_Strategic_Evidence.iSection, CS_Strategic_Evidence.sEvidenceRecored, CS_Strategic_Evidence.isIRQASurveyReportRequired,  ";
            sSQL += "                          CS_Strategic_Evidence.iCustomerExperienceEvidenceCategory, CS_Strategic_Evidence.iCustomerExperienceEvidenceSubCategory, CS_Strategic_Evidence.iOrder, CS_Strategic_Evidence.iStrategyVersion,  ";
            sSQL += "                          CS_Strategic_Evidence.dAdded, CS_Strategic_Evidence.sAddedBy, CS_Strategic_Evidence.dUpdated, CS_Strategic_Evidence.sUpdatedBy, CS_Evidence_Type.sEvidenceType, Lkp_Department.DescEN,  ";
            sSQL += "                          Lkp_Department.DepartmentAbbreviation, Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1, CS_Customer_Experience_Evidence_Category.sCustomerExperienceEvidenceCategory,  ";
            sSQL += "                          CS_Customer_Experience_Evidence_Sub_Category.sCustomerExperienceEvidenceSubCategory, CS_Strategy_Version.sStrategyVersion, CS_Strategic_Evidence.iProject, CS_Strategic_Project.sStrategicProjectID,  ";
            sSQL += "                          CS_Strategic_Project.sStrategicProjectDesc ";
            sSQL += " FROM            CS_Strategy_Version INNER JOIN ";
            sSQL += "                          CS_Customer_Experience_Evidence_Sub_Category INNER JOIN ";
            sSQL += "                          CS_Customer_Experience_Evidence_Category INNER JOIN ";
            sSQL += "                          Lkp_Section INNER JOIN ";
            sSQL += "                          CS_Evidence_Type INNER JOIN ";
            sSQL += "                          CS_Strategic_Evidence ON CS_Evidence_Type.iSerial = CS_Strategic_Evidence.iEvidenceType INNER JOIN ";
            sSQL += "                          Lkp_Department ON CS_Strategic_Evidence.iDepartment = Lkp_Department.DepartmentID ON Lkp_Section.SectionID = CS_Strategic_Evidence.iSection ON  ";
            sSQL += "                          CS_Customer_Experience_Evidence_Category.iSerial = CS_Strategic_Evidence.iCustomerExperienceEvidenceCategory ON  ";
            sSQL += "                          CS_Customer_Experience_Evidence_Sub_Category.iSerial = CS_Strategic_Evidence.iCustomerExperienceEvidenceSubCategory ON CS_Strategy_Version.iSerial = CS_Strategic_Evidence.iStrategyVersion INNER JOIN ";
            sSQL += "                          CS_Strategic_Project ON CS_Strategic_Evidence.iProject = CS_Strategic_Project.iSerial ";

            SqlCommand cmd = new SqlCommand(sSQL, sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex);
            }
            finally
            {
                sc.Close();
            }
        }
    }
}