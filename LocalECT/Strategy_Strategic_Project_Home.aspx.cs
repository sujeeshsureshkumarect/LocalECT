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
            string strRefPage = "";
            if (Request.UrlReferrer != null)
            {
                strRefPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
            }
            else
            {
                Server.Transfer("Authorization.aspx");
            }
            try
            {
                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];
                    if (!IsPostBack)
                    {                       
                        string f = Request.QueryString["f"];
                        if (f == "m")
                        {

                        }
                        //else
                        //{
                        //    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Project,
                        //InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        //    {
                        //        Server.Transfer("Authorization.aspx");
                        //    }
                        //}
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
                        string id = Request.QueryString["id"];
                        string f = Request.QueryString["f"];
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
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            string where = "";
            if (id != null && f != null)
            {
                lnk_Create.Visible = false;
                Img_Header.Visible = true;
                //row1.Style.Add("margin-top", "18% !important");
                Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Strategy/dttable.css") + "\" />"));
                where = " where CS_Strategic_Project.iSerial=" + id + " ";                
            }
            else if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Project,
                        InitializeModule.enumPrivilege.ShowAll, CurrentRole) != true)
            {
                where = "where CS_Strategic_Project.iSerial in (";
                //string sSQL1 = "SELECT CS_Strategic_Goal.iSerial, CS_Strategic_Goal.sStrategicGoalID, CS_Strategic_Goal.sStrategicGoalDesc, CS_Strategic_Goal.iStipulation, CS_Strategic_Goal.iInspectioncomplianceStandard, CS_Strategic_Goal.iOrder, CS_Strategic_Goal.iStrategyVersion, CS_Strategic_Goal.dAdded, CS_Strategic_Goal.sAddedBy, CS_Strategic_Goal.dUpdated, CS_Strategic_Goal.sUpdatedBy, CS_Strategic_Goal.sAbbreviation, CS_Strategic_Goal.iTheme, CS_Strategic_Goal.sImagePath, CS_Strategic_Goal.iLevel, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardDesc, CS_Stipulation.sStipulationDesc, CS_Strategic_Theme.sThemeCode,CS_Strategic_Theme.sThemeDesc, CS_Strategy_Version.sStrategyVersion FROM CS_Strategic_Theme INNER JOIN CS_Strategy_Version INNER JOIN CS_Stipulation INNER JOIN CS_Strategic_Goal ON CS_Stipulation.iSerial = CS_Strategic_Goal.iStipulation INNER JOIN CS_Inspection_Compliance_Standard ON CS_Strategic_Goal.iInspectioncomplianceStandard = CS_Inspection_Compliance_Standard.iSerial ON CS_Strategy_Version.iSerial = CS_Strategic_Goal.iStrategyVersion ON CS_Strategic_Theme.iSerial = CS_Strategic_Goal.iTheme where CS_Strategic_Goal.iSerial in (";

                string sSQL1 = " SELECT        ObjectID ";
                sSQL1 += "        FROM            (SELECT        TH.iSerial AS ObjectID, TH.sThemeDesc AS ObjectNameEn, TH.sThemeCode AS DisplayObjectName, TH.iOrder AS ShowOrder, 14 AS SystemID, 1299 AS ParentID, 'Strategy_Strategic_Theme_Home.aspx?f=m&id=' + CONVERT(varchar, TH.iSerial)   ";
                sSQL1 += "                                                            AS sURL, TH.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL1 += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL1 += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL1 += "                                                        WHERE        (ES.EmployeeID = " + Session["EmployeeID"].ToString() + ")    ) AS C INNER JOIN  ";
                sSQL1 += "                                                            CS_Strategic_Theme AS TH ON C.iTheme = TH.iSerial  ";
                sSQL1 += "                                  UNION ALL  ";
                sSQL1 += "                                  SELECT        SG.iSerial as ObjectID,CONVERT(varchar(100),SG.sStrategicGoalDesc) AS ObjectNameEn, SG.sAbbreviation AS DisplayObjectName, SG.iOrder AS ShowOrder, 14 AS SystemID, C_4.iTheme AS ParentID,   ";
                sSQL1 += "                                                           'Strategy_Strategic_Goal_Home.aspx?f=m&id=' + CONVERT(varchar, SG.iSerial) AS sURL, SG.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL1 += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL1 += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL1 += "                                                          WHERE        (ES.EmployeeID = " + Session["EmployeeID"].ToString() + ")      ) AS C_4 INNER JOIN  ";
                sSQL1 += "                                                           CS_Strategic_Goal AS SG ON C_4.iGoal = SG.iSerial  ";
                sSQL1 += "                                  UNION ALL  ";
                sSQL1 += "                                  SELECT        SP.iSerial as ObjectID, CONVERT(varchar(100),SP.sStrategicProjectDesc) AS ObjectNameEn, SP.sAbbreviation AS DisplayObjectName, SP.iOrder, 14 AS SystemID, C_3.iGoal * 10 AS ParentID, 'Strategy_Strategic_Project_Home.aspx?f=m&id=' + CONVERT(varchar,   ";
                sSQL1 += "                                                           SP.iSerial) AS sURL, SP.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL1 += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL1 += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL1 += "                                                            WHERE        (ES.EmployeeID = "+ Session["EmployeeID"].ToString() + ")     ) AS C_3 INNER JOIN  ";
                sSQL1 += "                                                           CS_Strategic_Project AS SP ON C_3.iProject = SP.iSerial  ";
                sSQL1 += "                                  UNION ALL  ";
                sSQL1 += "                                  SELECT        SO.iSerial AS ObjectID, CONVERT(varchar(100),SO.sStrategicObjectiveDesc) AS ObjectNameEn, SO.sAbbreviation AS DisplayObjectName, SO.iOrder, 14 AS SystemID, C_2.iProject * 100 AS ParentID,   ";
                sSQL1 += "                                                           'Strategy_Strategic_Objective_Home.aspx?f=m&id=' + CONVERT(varchar, SO.iSerial) AS sURL, SO.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL1 += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL1 += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL1 += "                                                       WHERE        (ES.EmployeeID = " + Session["EmployeeID"].ToString() + ")          ) AS C_2 INNER JOIN  ";
                sSQL1 += "                                                           CS_Strategic_Objective AS SO ON C_2.iObjective = SO.iSerial  ";
                sSQL1 += "                                  UNION ALL  ";
                sSQL1 += "                                  SELECT        SInit.iSerial  AS ObjectID, CONVERT(varchar(150),SInit.sInitiativeDesc) AS ObjectNameEn, SInit.sAbbreviation AS DisplayObjectName, SInit.iOrder, 14 AS SystemID, C_1.iObjective * 1000 AS ParentID,   ";
                sSQL1 += "                                                           'Strategy_Strategic_Initiative_Home.aspx?f=m&id=' + CONVERT(varchar, SInit.iSerial) AS sURL, SInit.iLevel + 1 AS iLevel, 1 AS Privilege  ";
                sSQL1 += "                                  FROM            (SELECT        ES.EmployeeID, SI.iSerial AS SIID, SI.iTheme, SI.iGoal, SI.iProject, SI.iObjective, SI.iOrder, SIDS.isPrincipal  ";
                sSQL1 += "                                                            FROM            CS_Strategic_Initiative AS SI INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Initiative_Dpartment_Section AS SIDS ON SI.iSerial = SIDS.iInitiative INNER JOIN  ";
                sSQL1 += "                                                                                      CS_Employees_Sections AS ES ON SIDS.iDepartment = ES.DepartmentID AND SIDS.iSection = ES.SectionID  ";
                sSQL1 += "                                                        WHERE        (ES.EmployeeID = " + Session["EmployeeID"].ToString() + ")        ) AS C_1 INNER JOIN  ";
                sSQL1 += "                                                           CS_Strategic_Initiative AS SInit ON C_1.SIID = SInit.iSerial) AS MNU  ";
                sSQL1 += " 														  where iLevel=4 ";
                sSQL1 += "        GROUP BY ObjectID, ObjectNameEn, DisplayObjectName, ShowOrder, SystemID, ParentID, sURL, iLevel  )";
                //sSQL += "        order by ObjectID ";
                where = where + sSQL1;
                //sSQL1 += ") order by CS_Strategic_Goal.iOrder";
            }
            else
            {
                where = "";
            }
            //else
            //{
            //    row1.Style.Add("margin-top", "0px !important");
            //    where = "";
            //}
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
            sSQL += where;
            sSQL += " order by CS_Strategic_Project.iOrder ";

            //SqlCommand cmd = new SqlCommand("SELECT CS_Strategic_Project.iSerial, CS_Strategic_Project.sStrategicProjectID, CS_Strategic_Project.sStrategicProjectDesc, CS_Strategic_Project.iHierarchyProjectOwner, CS_Strategic_Project.iProjectOwner, CS_Strategic_Project.iStrategicGoal, CS_Strategic_Project.iOrder, CS_Strategic_Project.iStrategyVersion, CS_Strategic_Project.dAdded, CS_Strategic_Project.sAddedBy, CS_Strategic_Project.dUpdated, CS_Strategic_Project.sUpdatedBy, CS_Strategic_Project.sAbbreviation, CS_Strategic_Project.sImagePath, CS_Strategic_Project.iMarketCompetitiveImplication, CS_Strategic_Project.iOwnerDepartment, CS_Strategic_Project.iOwnerSection, CS_Strategic_Project.iLevel, CS_Strategic_Goal.sStrategicGoalID, CS_Strategy_Version.sStrategyVersion, CS_Market_Competitive_Implication.sMarketCompetitiveImplication, HR_Employee_Academic_Admin_Managers.JobTitleEn, HR_Employee_Academic_Admin_Managers.EmployeeDisplayName, HR_Employee_Academic_Admin_Managers.DepartmentDesc, HR_Employee_Academic_Admin_Managers.Section FROM CS_Strategic_Project INNER JOIN HR_Employee_Academic_Admin_Managers ON CS_Strategic_Project.iProjectOwner = HR_Employee_Academic_Admin_Managers.EmployeeID INNER JOIN CS_Strategic_Goal ON CS_Strategic_Project.iStrategicGoal = CS_Strategic_Goal.iSerial INNER JOIN CS_Strategy_Version ON CS_Strategic_Project.iStrategyVersion = CS_Strategy_Version.iSerial INNER JOIN CS_Market_Competitive_Implication ON CS_Strategic_Project.iMarketCompetitiveImplication = CS_Market_Competitive_Implication.iSerial", sc);
            SqlCommand cmd = new SqlCommand(sSQL, sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (id != null && f != null)
                {
                    Img_Header.Src = dt.Rows[0]["sImagePath"].ToString();
                }

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
        protected void lnk_View_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Project_Update.aspx?f=m&id=" + id + "&t=v");
            }
            else
            {
                //Get the reference of the clicked button.
                LinkButton button = (sender as LinkButton);

                //Get the command argument
                string commandArgument = button.CommandArgument;
                Response.Redirect("Strategy_Strategic_Project_Update.aspx?id=" + commandArgument + "&t=v");
            }
        }

        protected void lnk_Edit_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Project_Update.aspx?f=m&id=" + id + "&t=e");
            }
            else
            {
                //Get the reference of the clicked button.
                LinkButton button = (sender as LinkButton);

                //Get the command argument
                string commandArgument = button.CommandArgument;
                Response.Redirect("Strategy_Strategic_Project_Update.aspx?id=" + commandArgument + "&t=e");
            }
        }
    }
}