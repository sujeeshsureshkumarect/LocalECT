﻿using System;
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
    public partial class Strategy_Strategic_KPI_Home : System.Web.UI.Page
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
                        string id = Request.QueryString["id"];//iInitiative
                        bindStrategic_KPI(id);
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

        public void bindStrategic_KPI(string id)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            string sSQL = "";
            //sSQL  = "SELECT					 CS_Strategic_KPI.iSerial, CS_Strategic_KPI.sKPIID, CS_Strategic_KPI.sKPIDesc, CS_Strategic_KPI.iPeriod, CS_Strategic_KPI.iFormula, CS_Strategic_KPI.cTargetKPI, CS_Strategic_KPI.cMin, CS_Strategic_KPI.cMax,  ";
            //sSQL += "                          CS_Strategic_KPI.cOverallKPI, CS_Strategic_KPI.iKPISource, CS_Strategic_KPI.iKPILevel, CS_Strategic_KPI.iKPISubLevel, CS_Strategic_KPI.IsInstitutionalClass, CS_Strategic_KPI.iMOEClassificationPillars,  ";
            //sSQL += "                          CS_Strategic_KPI.iMarketPositioningPillars, CS_Strategic_KPI.iDepartment, CS_Strategic_KPI.iSection, CS_Strategic_KPI.iInitiative, CS_Strategic_KPI.iOrder, CS_Strategic_KPI.iStrategyVersion, CS_Strategic_KPI.dAdded,  ";
            //sSQL += "                          CS_Strategic_KPI.sAddedBy, CS_Strategic_KPI.dUpdated, CS_Strategic_KPI.sUpdatedBy, CS_Strategic_Period.sPeriod, CS_KPI_Formula.sKPIFormula, CS_KPI_Source.sKPISource, CS_KPI_Level.sKPILevel,  ";
            //sSQL += "                          CS_KPI_Sub_Level.sKPISubLevel, CS_MOE_Classification_Pillars.sMOEClassificationPillars, CS_Market_Positioning_Pillars.sMarketPositioningPillars, Lkp_Department.DescEN, Lkp_Department.DepartmentAbbreviation,  ";
            //sSQL += "                          Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1, CS_Strategic_Initiative.sInitiativeID, CS_Strategic_Initiative.sInitiativeDesc, CS_Strategy_Version.sStrategyVersion ";
            //sSQL += " FROM            CS_Strategy_Version INNER JOIN ";
            //sSQL += "                          Lkp_Section INNER JOIN ";
            //sSQL += "                          CS_KPI_Sub_Level INNER JOIN ";
            //sSQL += "                          CS_Strategic_Period INNER JOIN ";
            //sSQL += "                          CS_Strategic_KPI ON CS_Strategic_Period.iSerial = CS_Strategic_KPI.iPeriod INNER JOIN ";
            //sSQL += "                          CS_KPI_Formula ON CS_Strategic_KPI.iFormula = CS_KPI_Formula.iSerial INNER JOIN ";
            //sSQL += "                          CS_KPI_Source ON CS_Strategic_KPI.iKPISource = CS_KPI_Source.iSerial INNER JOIN ";
            //sSQL += "                          CS_KPI_Level ON CS_Strategic_KPI.iKPILevel = CS_KPI_Level.iSerial ON CS_KPI_Sub_Level.iSerial = CS_Strategic_KPI.iKPISubLevel INNER JOIN ";
            //sSQL += "                          CS_MOE_Classification_Pillars ON CS_Strategic_KPI.iMOEClassificationPillars = CS_MOE_Classification_Pillars.iSerial INNER JOIN ";
            //sSQL += "                          CS_Market_Positioning_Pillars ON CS_Strategic_KPI.iMarketPositioningPillars = CS_Market_Positioning_Pillars.iSerial INNER JOIN ";
            //sSQL += "                          Lkp_Department ON CS_Strategic_KPI.iDepartment = Lkp_Department.DepartmentID ON Lkp_Section.SectionID = CS_Strategic_KPI.iSection INNER JOIN ";
            //sSQL += "                          CS_Strategic_Initiative ON CS_Strategic_KPI.iInitiative = CS_Strategic_Initiative.iSerial ON CS_Strategy_Version.iSerial = CS_Strategic_KPI.iStrategyVersion ";
            //sSQL  = " SELECT        CS_Strategic_KPI.iSerial, CS_Strategic_KPI.sKPIID, CS_Strategic_KPI.sKPIDesc, CS_Strategic_KPI.iPeriod, CS_Strategic_KPI.iFormula, CS_Strategic_KPI.cTargetKPI, CS_Strategic_KPI.cMin, CS_Strategic_KPI.cMax,  ";
            //sSQL += "                          CS_Strategic_KPI.cOverallKPI, CS_Strategic_KPI.iKPISource, CS_Strategic_KPI.iKPILevel, CS_Strategic_KPI.iKPISubLevel, CS_Strategic_KPI.IsInstitutionalClass, CS_Strategic_KPI.iMOEClassificationPillars,  ";
            //sSQL += "                          CS_Strategic_KPI.iMarketPositioningPillars, CS_Strategic_KPI.iDepartment, CS_Strategic_KPI.iSection, CS_Strategic_KPI.iInitiative, CS_Strategic_KPI.iOrder, CS_Strategic_KPI.iStrategyVersion, CS_Strategic_KPI.dAdded,  ";
            //sSQL += "                          CS_Strategic_KPI.sAddedBy, CS_Strategic_KPI.dUpdated, CS_Strategic_KPI.sUpdatedBy, CS_Strategic_Period.sPeriod, CS_KPI_Formula.sKPIFormula, CS_KPI_Source.sKPISource, CS_KPI_Level.sKPILevel,  ";
            //sSQL += "                          CS_KPI_Sub_Level.sKPISubLevel, CS_MOE_Classification_Pillars.sMOEClassificationPillars, CS_Market_Positioning_Pillars.sMarketPositioningPillars, Lkp_Department.DescEN, Lkp_Department.DepartmentAbbreviation,  ";
            //sSQL += "                          Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1, CS_Strategic_Initiative.sInitiativeID, CS_Strategic_Initiative.sInitiativeDesc, CS_Strategy_Version.sStrategyVersion, CS_Strategic_KPI.iSurveyFormReference,  ";
            //sSQL += "                          CS_Strategic_KPI.sIRQARecommendation, CS_Survey_Form.sSurveyFormReference ";
            //sSQL += " FROM            CS_Strategy_Version INNER JOIN ";
            //sSQL += "                          Lkp_Section INNER JOIN ";
            //sSQL += "                          CS_KPI_Sub_Level INNER JOIN ";
            //sSQL += "                          CS_Strategic_Period INNER JOIN ";
            //sSQL += "                          CS_Strategic_KPI ON CS_Strategic_Period.iSerial = CS_Strategic_KPI.iPeriod INNER JOIN ";
            //sSQL += "                          CS_KPI_Formula ON CS_Strategic_KPI.iFormula = CS_KPI_Formula.iSerial INNER JOIN ";
            //sSQL += "                          CS_KPI_Source ON CS_Strategic_KPI.iKPISource = CS_KPI_Source.iSerial INNER JOIN ";
            //sSQL += "                          CS_KPI_Level ON CS_Strategic_KPI.iKPILevel = CS_KPI_Level.iSerial ON CS_KPI_Sub_Level.iSerial = CS_Strategic_KPI.iKPISubLevel INNER JOIN ";
            //sSQL += "                          CS_MOE_Classification_Pillars ON CS_Strategic_KPI.iMOEClassificationPillars = CS_MOE_Classification_Pillars.iSerial INNER JOIN ";
            //sSQL += "                          CS_Market_Positioning_Pillars ON CS_Strategic_KPI.iMarketPositioningPillars = CS_Market_Positioning_Pillars.iSerial INNER JOIN ";
            //sSQL += "                          Lkp_Department ON CS_Strategic_KPI.iDepartment = Lkp_Department.DepartmentID ON Lkp_Section.SectionID = CS_Strategic_KPI.iSection INNER JOIN ";
            //sSQL += "                          CS_Strategic_Initiative ON CS_Strategic_KPI.iInitiative = CS_Strategic_Initiative.iSerial ON CS_Strategy_Version.iSerial = CS_Strategic_KPI.iStrategyVersion INNER JOIN ";
            //sSQL += "                          CS_Survey_Form ON CS_Strategic_KPI.iSurveyFormReference = CS_Survey_Form.iSerial ";
            //sSQL  = " SELECT        CS_Strategic_KPI.iSerial, CS_Strategic_KPI.sKPIID, CS_Strategic_KPI.sKPIDesc, CS_Strategic_KPI.iPeriod, CS_Strategic_KPI.iFormula, CS_Strategic_KPI.cTargetKPI, CS_Strategic_KPI.cMin, CS_Strategic_KPI.cMax,  ";
            //sSQL += "                          CS_Strategic_KPI.cOverallKPI, CS_Strategic_KPI.iKPISource, CS_Strategic_KPI.iKPILevel, CS_Strategic_KPI.iKPISubLevel, CS_Strategic_KPI.IsInstitutionalClass, CS_Strategic_KPI.iMOEClassificationPillars,  ";
            //sSQL += "                          CS_Strategic_KPI.iMarketPositioningPillars, CS_Strategic_KPI.iDepartment, CS_Strategic_KPI.iSection, CS_Strategic_KPI.iInitiative, CS_Strategic_KPI.iOrder, CS_Strategic_KPI.iStrategyVersion, CS_Strategic_KPI.dAdded,  ";
            //sSQL += "                          CS_Strategic_KPI.sAddedBy, CS_Strategic_KPI.dUpdated, CS_Strategic_KPI.sUpdatedBy, CS_Strategic_Period.sPeriod, CS_KPI_Formula.sKPIFormula, CS_KPI_Source.sKPISource, CS_KPI_Level.sKPILevel,  ";
            //sSQL += "                          CS_KPI_Sub_Level.sKPISubLevel, CS_MOE_Classification_Pillars.sMOEClassificationPillars, CS_Market_Positioning_Pillars.sMarketPositioningPillars, Lkp_Department.DescEN, Lkp_Department.DepartmentAbbreviation,  ";
            //sSQL += "                          Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1, CS_Strategic_Initiative.sInitiativeID, CS_Strategic_Initiative.sInitiativeDesc, CS_Strategy_Version.sStrategyVersion, CS_Strategic_KPI.iSurveyFormReference,  ";
            //sSQL += "                           CS_Survey_Form.sSurveyFormReference, CS_Strategic_KPI.iRiskManagement, CS_Strategic_KPI.isQSWorldUniversityRanking, CS_Risk_Management.sRiskManagement ";
            //sSQL += " FROM            CS_Strategy_Version INNER JOIN ";
            //sSQL += "                          Lkp_Section INNER JOIN ";
            //sSQL += "                          CS_KPI_Sub_Level INNER JOIN ";
            //sSQL += "                          CS_Strategic_Period INNER JOIN ";
            //sSQL += "                          CS_Strategic_KPI ON CS_Strategic_Period.iSerial = CS_Strategic_KPI.iPeriod INNER JOIN ";
            //sSQL += "                          CS_KPI_Formula ON CS_Strategic_KPI.iFormula = CS_KPI_Formula.iSerial INNER JOIN ";
            //sSQL += "                          CS_KPI_Source ON CS_Strategic_KPI.iKPISource = CS_KPI_Source.iSerial INNER JOIN ";
            //sSQL += "                          CS_KPI_Level ON CS_Strategic_KPI.iKPILevel = CS_KPI_Level.iSerial ON CS_KPI_Sub_Level.iSerial = CS_Strategic_KPI.iKPISubLevel INNER JOIN ";
            //sSQL += "                          CS_MOE_Classification_Pillars ON CS_Strategic_KPI.iMOEClassificationPillars = CS_MOE_Classification_Pillars.iSerial INNER JOIN ";
            //sSQL += "                          CS_Market_Positioning_Pillars ON CS_Strategic_KPI.iMarketPositioningPillars = CS_Market_Positioning_Pillars.iSerial INNER JOIN ";
            //sSQL += "                          Lkp_Department ON CS_Strategic_KPI.iDepartment = Lkp_Department.DepartmentID ON Lkp_Section.SectionID = CS_Strategic_KPI.iSection INNER JOIN ";
            //sSQL += "                          CS_Strategic_Initiative ON CS_Strategic_KPI.iInitiative = CS_Strategic_Initiative.iSerial ON CS_Strategy_Version.iSerial = CS_Strategic_KPI.iStrategyVersion INNER JOIN ";
            //sSQL += "                          CS_Survey_Form ON CS_Strategic_KPI.iSurveyFormReference = CS_Survey_Form.iSerial INNER JOIN ";
            //sSQL += "                          CS_Risk_Management ON CS_Strategic_KPI.iRiskManagement = CS_Risk_Management.iSerial ";
            //sSQL  = "SELECT        CS_Strategic_KPI.iSerial, CS_Strategic_KPI.sKPIID, CS_Strategic_KPI.sKPIDesc, CS_Strategic_KPI.iPeriod, CS_Strategic_KPI.iFormula, CS_Strategic_KPI.cTargetKPI, CS_Strategic_KPI.cMin, CS_Strategic_KPI.cMax,  ";
            //sSQL += "                         CS_Strategic_KPI.cOverallKPI, CS_Strategic_KPI.iKPISource, CS_Strategic_KPI.iKPILevel, CS_Strategic_KPI.iKPISubLevel, CS_Strategic_KPI.IsInstitutionalClass, CS_Strategic_KPI.iMOEClassificationPillars,  ";
            //sSQL += "                         CS_Strategic_KPI.iMarketPositioningPillars, CS_Strategic_KPI.iDepartment, CS_Strategic_KPI.iSection, CS_Strategic_KPI.iInitiative, CS_Strategic_KPI.iOrder, CS_Strategic_KPI.iStrategyVersion, CS_Strategic_KPI.dAdded,  ";
            //sSQL += "                         CS_Strategic_KPI.sAddedBy, CS_Strategic_KPI.dUpdated, CS_Strategic_KPI.sUpdatedBy, CS_Strategic_Period.sPeriod, CS_KPI_Formula.sKPIFormula, CS_KPI_Source.sKPISource, CS_KPI_Level.sKPILevel,  ";
            //sSQL += "                         CS_KPI_Sub_Level.sKPISubLevel, CS_MOE_Classification_Pillars.sMOEClassificationPillars, CS_Market_Positioning_Pillars.sMarketPositioningPillars, Lkp_Department.DescEN, Lkp_Department.DepartmentAbbreviation,  ";
            //sSQL += "                         Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1, CS_Strategic_Initiative.sInitiativeID, CS_Strategic_Initiative.sInitiativeDesc, CS_Strategy_Version.sStrategyVersion, CS_Strategic_KPI.iSurveyFormReference,  ";
            //sSQL += "                         CS_Survey_Form.sSurveyFormReference, CS_Strategic_KPI.isQSWorldUniversityRanking ";
            //sSQL += "FROM            CS_Strategy_Version INNER JOIN ";
            //sSQL += "                         Lkp_Section INNER JOIN ";
            //sSQL += "                         CS_KPI_Sub_Level INNER JOIN ";
            //sSQL += "                         CS_Strategic_Period INNER JOIN ";
            //sSQL += "                         CS_Strategic_KPI ON CS_Strategic_Period.iSerial = CS_Strategic_KPI.iPeriod INNER JOIN ";
            //sSQL += "                         CS_KPI_Formula ON CS_Strategic_KPI.iFormula = CS_KPI_Formula.iSerial INNER JOIN ";
            //sSQL += "                         CS_KPI_Source ON CS_Strategic_KPI.iKPISource = CS_KPI_Source.iSerial INNER JOIN ";
            //sSQL += "                         CS_KPI_Level ON CS_Strategic_KPI.iKPILevel = CS_KPI_Level.iSerial ON CS_KPI_Sub_Level.iSerial = CS_Strategic_KPI.iKPISubLevel INNER JOIN ";
            //sSQL += "                         CS_MOE_Classification_Pillars ON CS_Strategic_KPI.iMOEClassificationPillars = CS_MOE_Classification_Pillars.iSerial INNER JOIN ";
            //sSQL += "                         CS_Market_Positioning_Pillars ON CS_Strategic_KPI.iMarketPositioningPillars = CS_Market_Positioning_Pillars.iSerial INNER JOIN ";
            //sSQL += "                         Lkp_Department ON CS_Strategic_KPI.iDepartment = Lkp_Department.DepartmentID ON Lkp_Section.SectionID = CS_Strategic_KPI.iSection INNER JOIN ";
            //sSQL += "                         CS_Strategic_Initiative ON CS_Strategic_KPI.iInitiative = CS_Strategic_Initiative.iSerial ON CS_Strategy_Version.iSerial = CS_Strategic_KPI.iStrategyVersion INNER JOIN ";
            //sSQL += "                         CS_Survey_Form ON CS_Strategic_KPI.iSurveyFormReference = CS_Survey_Form.iSerial ";
            sSQL += " SELECT        CS_Strategic_KPI.iSerial, CS_Strategic_KPI.sKPIID, CS_Strategic_KPI.sKPIDesc, CS_Strategic_KPI.iPeriod, CS_Strategic_KPI.iFormula, CS_Strategic_KPI.cTargetKPI, CS_Strategic_KPI.cMin, CS_Strategic_KPI.cMax,  ";
            sSQL += "                          CS_Strategic_KPI.cOverallKPI, CS_Strategic_KPI.iKPISource, CS_Strategic_KPI.iKPILevel, CS_Strategic_KPI.iKPISubLevel, CS_Strategic_KPI.IsInstitutionalClass, CS_Strategic_KPI.iMOEClassificationPillars,  ";
            sSQL += "                          CS_Strategic_KPI.iMarketPositioningPillars, CS_Strategic_KPI.iDepartment, CS_Strategic_KPI.iSection, CS_Strategic_KPI.iInitiative, CS_Strategic_KPI.iOrder, CS_Strategic_KPI.iStrategyVersion, CS_Strategic_KPI.dAdded,  ";
            sSQL += "                          CS_Strategic_KPI.sAddedBy, CS_Strategic_KPI.dUpdated, CS_Strategic_KPI.sUpdatedBy, CS_Strategic_Period.sPeriod, CS_KPI_Formula.sKPIFormula, CS_KPI_Source.sKPISource, CS_KPI_Level.sKPILevel,  ";
            sSQL += "                          CS_KPI_Sub_Level.sKPISubLevel, CS_MOE_Classification_Pillars.sMOEClassificationPillars, CS_Market_Positioning_Pillars.sMarketPositioningPillars, Lkp_Department.DescEN, Lkp_Department.DepartmentAbbreviation,  ";
            sSQL += "                          Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1, CS_Strategic_Initiative.sInitiativeID, CS_Strategic_Initiative.sInitiativeDesc, CS_Strategy_Version.sStrategyVersion, CS_Strategic_KPI.iSurveyFormReference,  ";
            sSQL += "                          CS_Survey_Form.sSurveyFormReference, CS_Strategic_KPI.isQSWorldUniversityRanking, CS_Strategic_KPI.iEvidence, CS_Strategic_KPI.sEV, CS_Strategic_Evidence.iSerial as iSerial1,CS_Strategic_Evidence.sEvidenceRecored, CS_Strategic_KPI.isDuplicate,  ";
            sSQL += "                          CS_Strategic_KPI.iDuplicationSource, CS_KPI_Value_Type.sKPIValueType, CS_Strategic_KPI.iKPIValueType, CS_KPI_Management_Practice_Type.sManagementPracticeType,  ";
            sSQL += "                          CS_KPI_Management_Practice_Sub_Type.sManagementPracticeSubType, CS_KPI_Outcome.sKPIOutcome ";
            sSQL += " FROM            CS_Strategy_Version INNER JOIN ";
            sSQL += "                          Lkp_Section INNER JOIN ";
            sSQL += "                          CS_KPI_Sub_Level INNER JOIN ";
            sSQL += "                          CS_Strategic_Period INNER JOIN ";
            sSQL += "                          CS_Strategic_KPI ON CS_Strategic_Period.iSerial = CS_Strategic_KPI.iPeriod INNER JOIN ";
            sSQL += "                          CS_KPI_Formula ON CS_Strategic_KPI.iFormula = CS_KPI_Formula.iSerial INNER JOIN ";
            sSQL += "                          CS_KPI_Source ON CS_Strategic_KPI.iKPISource = CS_KPI_Source.iSerial INNER JOIN ";
            sSQL += "                          CS_KPI_Level ON CS_Strategic_KPI.iKPILevel = CS_KPI_Level.iSerial ON CS_KPI_Sub_Level.iSerial = CS_Strategic_KPI.iKPISubLevel INNER JOIN ";
            sSQL += "                          CS_MOE_Classification_Pillars ON CS_Strategic_KPI.iMOEClassificationPillars = CS_MOE_Classification_Pillars.iSerial INNER JOIN ";
            sSQL += "                          CS_Market_Positioning_Pillars ON CS_Strategic_KPI.iMarketPositioningPillars = CS_Market_Positioning_Pillars.iSerial INNER JOIN ";
            sSQL += "                          Lkp_Department ON CS_Strategic_KPI.iDepartment = Lkp_Department.DepartmentID ON Lkp_Section.SectionID = CS_Strategic_KPI.iSection INNER JOIN ";
            sSQL += "                          CS_Strategic_Initiative ON CS_Strategic_KPI.iInitiative = CS_Strategic_Initiative.iSerial ON CS_Strategy_Version.iSerial = CS_Strategic_KPI.iStrategyVersion INNER JOIN ";
            sSQL += "                          CS_Survey_Form ON CS_Strategic_KPI.iSurveyFormReference = CS_Survey_Form.iSerial INNER JOIN ";
            sSQL += "                          CS_Strategic_Evidence ON CS_Strategic_KPI.iEvidence = CS_Strategic_Evidence.iSerial INNER JOIN ";
            sSQL += "                          CS_KPI_Value_Type ON CS_Strategic_KPI.iKPIValueType = CS_KPI_Value_Type.iSerial INNER JOIN ";
            sSQL += "                          CS_KPI_Management_Practice_Type ON CS_Strategic_KPI.iKPIManagementPracticeType = CS_KPI_Management_Practice_Type.iSerial INNER JOIN ";
            sSQL += "                          CS_KPI_Management_Practice_Sub_Type ON CS_Strategic_KPI.iKPIManagementPracticeSubType = CS_KPI_Management_Practice_Sub_Type.iSerial INNER JOIN ";
            sSQL += "                          CS_KPI_Outcome ON CS_Strategic_KPI.iKPIOutcome = CS_KPI_Outcome.iSerial ";
            sSQL += " where iInitiative=@iInitiative ";

            SqlCommand cmd = new SqlCommand(sSQL, sc);
            cmd.Parameters.AddWithValue("@iInitiative", id);
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

        protected void lnk_Create_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                //Response.Redirect("Strategy_Strategic_Initiative_Home.aspx?f=m&id=" + id + "");
                Response.Redirect("Strategy_Strategic_KPI_Update?f=m&id=" + Request.QueryString["id"] + "");
            }
            else
            {
                //Response.Redirect("Strategy_Strategic_Initiative_Home");
                Response.Redirect("Strategy_Strategic_KPI_Update?id=" + Request.QueryString["id"] + "");
            }            
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Initiative_Home.aspx?f=m&id=" + id + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_Initiative_Home");
            }
        }

        protected void lnk_View_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];

            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string commandArgument = button.CommandArgument;

            if (id != null && f != null)
            {                
                Response.Redirect("Strategy_Strategic_KPI_Update.aspx?f=m&id=" + id + "&sid="+ commandArgument + "&t=v");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_KPI_Update.aspx?id=" + id + "&sid=" + commandArgument + "&t=v");
            }
        }

        protected void lnk_Edit_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];

            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string commandArgument = button.CommandArgument;

            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_KPI_Update.aspx?f=m&id=" + id + "&sid=" + commandArgument + "&t=e");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_KPI_Update.aspx?id=" + id + "&sid=" + commandArgument + "&t=e");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];

            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string commandArgument = button.CommandArgument;

            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_KPI_Detail_Home.aspx?f=m&id=" + id + "&sid=" + commandArgument + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_KPI_Detail_Home.aspx?id=" + id + "&sid=" + commandArgument + "");
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];

            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string commandArgument = button.CommandArgument;

            if (id != null && f != null)
            {
                Response.Redirect("Strategy_IRQA_Recommendation_Home.aspx?f=m&id=" + id + "&sid=" + commandArgument + "");
            }
            else
            {
                Response.Redirect("Strategy_IRQA_Recommendation_Home.aspx?id=" + id + "&sid=" + commandArgument + "");
            }
        }
    }
}