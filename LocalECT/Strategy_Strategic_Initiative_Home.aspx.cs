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
    public partial class Strategy_Strategic_Initiative_Home : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Initiative,
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
                        bindStrategic_Initiative();
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

        public void bindStrategic_Initiative()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            string sSQL = "";
            sSQL  = " SELECT        CS_Strategic_Initiative.iSerial, CS_Strategic_Initiative.sInitiativeID, CS_Strategic_Initiative.sInitiativeDesc, CS_Strategic_Initiative.iUniversityStatus, CS_Strategic_Initiative.iInitiativePriority,  ";
            sSQL += "                          CS_Strategic_Initiative.iInitiativeMaturity, CS_Strategic_Initiative.iDigitalTransformationProgram, CS_Strategic_Initiative.iDigitalUseCase, CS_Strategic_Initiative.iEnterpriseModel, CS_Strategic_Initiative.iDepartment,  ";
            sSQL += "                          CS_Strategic_Initiative.iSection, CS_Strategic_Initiative.iTheme, CS_Strategic_Initiative.iGoal, CS_Strategic_Initiative.iProject, CS_Strategic_Initiative.iObjective, CS_Strategic_Initiative.iOrder,  ";
            sSQL += "                          CS_Strategic_Initiative.iStrategyVersion, CS_Strategic_Initiative.sAbbreviation, CS_Strategic_Initiative.sImagePath, CS_Strategic_Initiative.dAdded, CS_Strategic_Initiative.sAddedBy, CS_Strategic_Initiative.dUpdated,  ";
            sSQL += "                          CS_Strategic_Initiative.sUpdatedBy, CS_Strategic_Initiative.iValuePropositionImpact, CS_Strategic_Initiative.iLevel, CS_University_Status.sUniversityStatus, CS_Initiative_Priority.sInitiativePriority,  ";
            sSQL += "                          CS_Initiative_Maturity.sInitiativeMaturity, CS_Digital_Transformation_Program.sDigitalTransformationProgram, CS_Digital_Use_Case.sDigitalUseCase, CS_Enterprise_Model.sEnterpriseModel,  ";
            sSQL += "                          CS_Strategic_Theme.sThemeCode, CS_Strategic_Goal.sStrategicGoalID, CS_Strategic_Project.sStrategicProjectID, CS_Strategic_Objective.sStrategicObjectiveID, CS_Strategy_Version.sStrategyVersion,  ";
            sSQL += "                          CS_Value_Proposition_Impact.sValuePropositionImpact, CS_Strategic_Theme.sThemeDesc, CS_Strategic_Goal.sStrategicGoalDesc, CS_Strategic_Project.sStrategicProjectDesc, CS_Strategic_Objective.sStrategicObjectiveDesc,  ";
            sSQL += "                          Lkp_Section.SectionAbbreviation, Lkp_Department.DepartmentAbbreviation, Lkp_Section.DescEN, Lkp_Department.DescEN AS Expr1 ";
            sSQL += " FROM            CS_Value_Proposition_Impact INNER JOIN ";
            sSQL += "                          CS_Strategic_Goal INNER JOIN ";
            sSQL += "                          CS_Strategic_Theme INNER JOIN ";
            sSQL += "                          Lkp_Section INNER JOIN ";
            sSQL += "                          CS_Digital_Use_Case INNER JOIN ";
            sSQL += "                          CS_Digital_Transformation_Program INNER JOIN ";
            sSQL += "                          CS_Initiative_Maturity INNER JOIN ";
            sSQL += "                          CS_University_Status INNER JOIN ";
            sSQL += "                          CS_Strategic_Initiative ON CS_University_Status.iSerial = CS_Strategic_Initiative.iUniversityStatus INNER JOIN ";
            sSQL += "                          CS_Initiative_Priority ON CS_Strategic_Initiative.iInitiativePriority = CS_Initiative_Priority.iSerial ON CS_Initiative_Maturity.iSerial = CS_Strategic_Initiative.iInitiativeMaturity ON  ";
            sSQL += "                          CS_Digital_Transformation_Program.iSerial = CS_Strategic_Initiative.iDigitalTransformationProgram ON CS_Digital_Use_Case.iSerial = CS_Strategic_Initiative.iDigitalUseCase INNER JOIN ";
            sSQL += "                          CS_Enterprise_Model ON CS_Strategic_Initiative.iEnterpriseModel = CS_Enterprise_Model.iSerial INNER JOIN ";
            sSQL += "                          Lkp_Department ON CS_Strategic_Initiative.iDepartment = Lkp_Department.DepartmentID ON Lkp_Section.SectionID = CS_Strategic_Initiative.iSection ON CS_Strategic_Theme.iSerial = CS_Strategic_Initiative.iTheme ON  ";
            sSQL += "                          CS_Strategic_Goal.iSerial = CS_Strategic_Initiative.iGoal INNER JOIN ";
            sSQL += "                          CS_Strategic_Project ON CS_Strategic_Initiative.iProject = CS_Strategic_Project.iSerial INNER JOIN ";
            sSQL += "                          CS_Strategic_Objective ON CS_Strategic_Initiative.iObjective = CS_Strategic_Objective.iSerial INNER JOIN ";
            sSQL += "                          CS_Strategy_Version ON CS_Strategic_Initiative.iStrategyVersion = CS_Strategy_Version.iSerial ON CS_Value_Proposition_Impact.iSerial = CS_Strategic_Initiative.iValuePropositionImpact ";
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