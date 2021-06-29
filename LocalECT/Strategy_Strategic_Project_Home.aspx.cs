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
    public partial class Strategy_Strategic_Project_Home : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Project,
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
                        bindStrategic_Project();
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

        public void bindStrategic_Project()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            string sSQL = "";
            sSQL = " SELECT        CS_Strategic_Project.iSerial, CS_Strategic_Project.sStrategicProjectID, CS_Strategic_Project.sStrategicProjectDesc, CS_Strategic_Project.iHierarchyProjectOwner, CS_Strategic_Project.iProjectOwner,  ";
            sSQL += "                          CS_Strategic_Project.iStrategicGoal, CS_Strategic_Project.iOrder, CS_Strategic_Project.iStrategyVersion, CS_Strategic_Project.dAdded, CS_Strategic_Project.sAddedBy, CS_Strategic_Project.dUpdated,  ";
            sSQL += "                          CS_Strategic_Project.sUpdatedBy, CS_Strategic_Project.sAbbreviation, CS_Strategic_Project.sImagePath, CS_Strategic_Project.iMarketCompetitiveImplication, CS_Strategic_Project.iOwnerDepartment,  ";
            sSQL += "                          CS_Strategic_Project.iOwnerSection, CS_Strategic_Project.iLevel,CS_Strategic_Goal.sStrategicGoalDesc, CS_Strategic_Goal.sStrategicGoalID, CS_Strategy_Version.sStrategyVersion, CS_Market_Competitive_Implication.sMarketCompetitiveImplication,  ";
            sSQL += "                          Lkp_JobTitle.JobTitleEn, Lkp_JobTitle.JobTitleID, Hr_Employee.EmployeeID, Hr_Employee.FirstNameEn, Hr_Employee.FamilyNameEn, Hr_Employee.SurnameEn, Lkp_Department.DescEN,  ";
            sSQL += "                          Lkp_Department.DepartmentAbbreviation, Lkp_Section.DescEN AS Expr1, Lkp_Section.SectionAbbreviation ";
            sSQL += " FROM            CS_Strategic_Project INNER JOIN ";
            sSQL += "                          CS_Strategic_Goal ON CS_Strategic_Project.iStrategicGoal = CS_Strategic_Goal.iSerial INNER JOIN ";
            sSQL += "                          CS_Strategy_Version ON CS_Strategic_Project.iStrategyVersion = CS_Strategy_Version.iSerial INNER JOIN ";
            sSQL += "                          CS_Market_Competitive_Implication ON CS_Strategic_Project.iMarketCompetitiveImplication = CS_Market_Competitive_Implication.iSerial INNER JOIN ";
            sSQL += "                          Lkp_JobTitle ON CS_Strategic_Project.iHierarchyProjectOwner = Lkp_JobTitle.JobTitleID INNER JOIN ";
            sSQL += "                          Hr_Employee ON CS_Strategic_Project.iProjectOwner = Hr_Employee.EmployeeID INNER JOIN ";
            sSQL += "                          Lkp_Department ON CS_Strategic_Project.iOwnerDepartment = Lkp_Department.DepartmentID INNER JOIN ";
            sSQL += "                          Lkp_Section ON CS_Strategic_Project.iOwnerSection = Lkp_Section.SectionID ";

            //SqlCommand cmd = new SqlCommand("SELECT CS_Strategic_Project.iSerial, CS_Strategic_Project.sStrategicProjectID, CS_Strategic_Project.sStrategicProjectDesc, CS_Strategic_Project.iHierarchyProjectOwner, CS_Strategic_Project.iProjectOwner, CS_Strategic_Project.iStrategicGoal, CS_Strategic_Project.iOrder, CS_Strategic_Project.iStrategyVersion, CS_Strategic_Project.dAdded, CS_Strategic_Project.sAddedBy, CS_Strategic_Project.dUpdated, CS_Strategic_Project.sUpdatedBy, CS_Strategic_Project.sAbbreviation, CS_Strategic_Project.sImagePath, CS_Strategic_Project.iMarketCompetitiveImplication, CS_Strategic_Project.iOwnerDepartment, CS_Strategic_Project.iOwnerSection, CS_Strategic_Project.iLevel, CS_Strategic_Goal.sStrategicGoalID, CS_Strategy_Version.sStrategyVersion, CS_Market_Competitive_Implication.sMarketCompetitiveImplication, HR_Employee_Academic_Admin_Managers.JobTitleEn, HR_Employee_Academic_Admin_Managers.EmployeeDisplayName, HR_Employee_Academic_Admin_Managers.DepartmentDesc, HR_Employee_Academic_Admin_Managers.Section FROM CS_Strategic_Project INNER JOIN HR_Employee_Academic_Admin_Managers ON CS_Strategic_Project.iProjectOwner = HR_Employee_Academic_Admin_Managers.EmployeeID INNER JOIN CS_Strategic_Goal ON CS_Strategic_Project.iStrategicGoal = CS_Strategic_Goal.iSerial INNER JOIN CS_Strategy_Version ON CS_Strategic_Project.iStrategyVersion = CS_Strategy_Version.iSerial INNER JOIN CS_Market_Competitive_Implication ON CS_Strategic_Project.iMarketCompetitiveImplication = CS_Market_Competitive_Implication.iSerial", sc);
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