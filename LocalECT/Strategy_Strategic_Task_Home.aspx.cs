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
    public partial class Strategy_Strategic_Task_Home : System.Web.UI.Page
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
                        string id = Request.QueryString["id"];//iInitiative
                        bindStrategic_Task(id);
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

        public void bindStrategic_Task(string id)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            string sSQL = "";
            //sSQL  = " SELECT        CS_Strategic_Task.iSerial, CS_Strategic_Task.sTaskID, CS_Strategic_Task.sTaskDesc, CS_Strategic_Task.iPeriod, CS_Strategic_Task.dStart, CS_Strategic_Task.dEnd, CS_Strategic_Task.iDepartment,  ";
            //sSQL += "                          CS_Strategic_Task.iSection, CS_Strategic_Task.iStipulation, CS_Strategic_Task.iSubStipulation, CS_Strategic_Task.iGuideline, CS_Strategic_Task.iInspectionComplianceStandard,  ";
            //sSQL += "                          CS_Strategic_Task.iInspectionComplianceDomain, CS_Strategic_Task.iInspectionComplianceIndicator, CS_Strategic_Task.iInspectionComplianceGuidelines, CS_Strategic_Task.iRiskManagement,  ";
            //sSQL += "                          CS_Strategic_Task.iSurveyFormReference, CS_Strategic_Task.iIRQARecommendation, CS_Strategic_Task.iEvidence, CS_Strategic_Task.iInitiative, CS_Strategic_Task.iOrder, CS_Strategic_Task.iStrategyVersion,  ";
            //sSQL += "                          CS_Strategic_Task.dAdded, CS_Strategic_Task.sAddedBy, CS_Strategic_Task.dUpdated, CS_Strategic_Task.sUpdatedBy, CS_Strategic_Period.sPeriod, Lkp_Department.DescEN, Lkp_Department.DepartmentAbbreviation,  ";
            //sSQL += "                          Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1, CS_Stipulation.sStipulationID, CS_Stipulation.sStipulationDesc, CS_Sub_Stipulation.sSubStipulationID, CS_Sub_Stipulation.sSubStipulationDesc,  ";
            //sSQL += "                          CS_Stipulation_Guidelines.sGuidelinesID, CS_Stipulation_Guidelines.sGuidelinesDesc, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardID,  ";
            //sSQL += "                          CS_Inspection_Compliance_Standard.sInspectionComplianceStandardDesc, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainDesc,  ";
            //sSQL += "                          CS_Inspection_Compliance_Indicator.sInspectionComplianceIndicatorID, CS_Inspection_Compliance_Indicator.sInspectionComplianceIndicatorDesc, CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesID,  ";
            //sSQL += "                          CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesDesc, CS_Risk_Management.sRiskManagement, CS_IRQA_Recommendation.sIRQARecommendation, CS_Strategic_Initiative.sInitiativeID,  ";
            //sSQL += "                          CS_Strategic_Initiative.sInitiativeDesc, CS_Strategy_Version.sStrategyVersion, CS_Survey_Form.sSurveyName, CS_Survey_Form.sSurveyFormReference, CS_Strategic_Evidence.sEvidenceTitle ";
            //sSQL += " FROM            CS_Survey_Form INNER JOIN ";
            //sSQL += "                          CS_Strategic_Initiative INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Domain INNER JOIN ";
            //sSQL += "                          CS_Strategic_Task INNER JOIN ";
            //sSQL += "                          CS_Strategic_Period ON CS_Strategic_Task.iPeriod = CS_Strategic_Period.iSerial INNER JOIN ";
            //sSQL += "                          Lkp_Department ON CS_Strategic_Task.iDepartment = Lkp_Department.DepartmentID INNER JOIN ";
            //sSQL += "                          Lkp_Section ON CS_Strategic_Task.iSection = Lkp_Section.SectionID INNER JOIN ";
            //sSQL += "                          CS_Stipulation ON CS_Strategic_Task.iStipulation = CS_Stipulation.iSerial INNER JOIN ";
            //sSQL += "                          CS_Sub_Stipulation ON CS_Strategic_Task.iSubStipulation = CS_Sub_Stipulation.iSerial INNER JOIN ";
            //sSQL += "                          CS_Stipulation_Guidelines ON CS_Strategic_Task.iGuideline = CS_Stipulation_Guidelines.iSerial INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Standard ON CS_Strategic_Task.iInspectionComplianceStandard = CS_Inspection_Compliance_Standard.iSerial ON  ";
            //sSQL += "                          CS_Inspection_Compliance_Domain.iSerial = CS_Strategic_Task.iInspectionComplianceDomain INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Indicator ON CS_Strategic_Task.iInspectionComplianceIndicator = CS_Inspection_Compliance_Indicator.iSerial INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Guidelines ON CS_Strategic_Task.iInspectionComplianceGuidelines = CS_Inspection_Compliance_Guidelines.iSerial INNER JOIN ";
            //sSQL += "                          CS_Risk_Management ON CS_Strategic_Task.iRiskManagement = CS_Risk_Management.iSerial INNER JOIN ";
            //sSQL += "                          CS_IRQA_Recommendation ON CS_Strategic_Task.iIRQARecommendation = CS_IRQA_Recommendation.iSerial ON CS_Strategic_Initiative.iSerial = CS_Strategic_Task.iInitiative INNER JOIN ";
            //sSQL += "                          CS_Strategy_Version ON CS_Strategic_Task.iStrategyVersion = CS_Strategy_Version.iSerial ON CS_Survey_Form.iSerial = CS_Strategic_Task.iSurveyFormReference INNER JOIN ";
            //sSQL += "                          CS_Strategic_Evidence ON CS_Strategic_Task.iEvidence = CS_Strategic_Evidence.iSerial ";

            //sSQL  = " SELECT        CS_Strategic_Task.iSerial, CS_Strategic_Task.sTaskID, CS_Strategic_Task.sTaskDesc, CS_Strategic_Task.iPeriod, CS_Strategic_Task.dStart, CS_Strategic_Task.dEnd, CS_Strategic_Task.iDepartment,  ";
            //sSQL += "                          CS_Strategic_Task.iSection, CS_Strategic_Task.iStipulation, CS_Strategic_Task.iSubStipulation, CS_Strategic_Task.iGuideline, CS_Strategic_Task.iInspectionComplianceStandard,  ";
            //sSQL += "                          CS_Strategic_Task.iInspectionComplianceDomain, CS_Strategic_Task.iInspectionComplianceIndicator, CS_Strategic_Task.iInspectionComplianceGuidelines, CS_Strategic_Task.iRiskManagement,  ";
            //sSQL += "       CS_Strategic_Task.iEvidence, CS_Strategic_Task.iInitiative, CS_Strategic_Task.iOrder, CS_Strategic_Task.iStrategyVersion,  ";
            //sSQL += "                          CS_Strategic_Task.dAdded, CS_Strategic_Task.sAddedBy, CS_Strategic_Task.dUpdated, CS_Strategic_Task.sUpdatedBy, CS_Strategic_Period.sPeriod, Lkp_Department.DescEN, Lkp_Department.DepartmentAbbreviation,  ";
            //sSQL += "                          Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1, CS_Stipulation.sStipulationID, CS_Stipulation.sStipulationDesc, CS_Sub_Stipulation.sSubStipulationID, CS_Sub_Stipulation.sSubStipulationDesc,  ";
            //sSQL += "                          CS_Stipulation_Guidelines.sGuidelinesID, CS_Stipulation_Guidelines.sGuidelinesDesc, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardID,  ";
            //sSQL += "                          CS_Inspection_Compliance_Standard.sInspectionComplianceStandardDesc, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainDesc,  ";
            //sSQL += "                          CS_Inspection_Compliance_Indicator.sInspectionComplianceIndicatorID, CS_Inspection_Compliance_Indicator.sInspectionComplianceIndicatorDesc, CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesID,  ";
            //sSQL += "                          CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesDesc, CS_Risk_Management.sRiskManagement,  CS_Strategic_Initiative.sInitiativeID,  ";
            //sSQL += "                          CS_Strategic_Initiative.sInitiativeDesc, CS_Strategy_Version.sStrategyVersion, CS_Strategic_Evidence.sEvidenceTitle ";
            //sSQL += " FROM            CS_Strategy_Version INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Domain INNER JOIN ";
            //sSQL += "                          CS_Strategic_Task INNER JOIN ";
            //sSQL += "                          CS_Strategic_Period ON CS_Strategic_Task.iPeriod = CS_Strategic_Period.iSerial INNER JOIN ";
            //sSQL += "                          Lkp_Department ON CS_Strategic_Task.iDepartment = Lkp_Department.DepartmentID INNER JOIN ";
            //sSQL += "                          Lkp_Section ON CS_Strategic_Task.iSection = Lkp_Section.SectionID INNER JOIN ";
            //sSQL += "                          CS_Stipulation ON CS_Strategic_Task.iStipulation = CS_Stipulation.iSerial INNER JOIN ";
            //sSQL += "                          CS_Sub_Stipulation ON CS_Strategic_Task.iSubStipulation = CS_Sub_Stipulation.iSerial INNER JOIN ";
            //sSQL += "                          CS_Stipulation_Guidelines ON CS_Strategic_Task.iGuideline = CS_Stipulation_Guidelines.iSerial INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Standard ON CS_Strategic_Task.iInspectionComplianceStandard = CS_Inspection_Compliance_Standard.iSerial ON  ";
            //sSQL += "                          CS_Inspection_Compliance_Domain.iSerial = CS_Strategic_Task.iInspectionComplianceDomain INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Indicator ON CS_Strategic_Task.iInspectionComplianceIndicator = CS_Inspection_Compliance_Indicator.iSerial INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Guidelines ON CS_Strategic_Task.iInspectionComplianceGuidelines = CS_Inspection_Compliance_Guidelines.iSerial INNER JOIN ";
            //sSQL += "                          CS_Risk_Management ON CS_Strategic_Task.iRiskManagement = CS_Risk_Management.iSerial INNER JOIN ";
            //sSQL += "                          CS_Strategic_Initiative ON CS_Strategic_Task.iInitiative = CS_Strategic_Initiative.iSerial ON CS_Strategy_Version.iSerial = CS_Strategic_Task.iStrategyVersion INNER JOIN ";
            //sSQL += "                          CS_Strategic_Evidence ON CS_Strategic_Task.iEvidence = CS_Strategic_Evidence.iSerial ";
            //sSQL  = " SELECT        CS_Strategic_Task.iSerial, CS_Strategic_Task.sTaskID, CS_Strategic_Task.sTaskDesc, CS_Strategic_Task.iPeriod, CS_Strategic_Task.dStart, CS_Strategic_Task.dEnd, CS_Strategic_Task.iDepartment,  ";
            //sSQL += "                          CS_Strategic_Task.iSection, CS_Strategic_Task.iStipulation, CS_Strategic_Task.iSubStipulation, CS_Strategic_Task.iGuideline, CS_Strategic_Task.iInspectionComplianceStandard,  ";
            //sSQL += "                          CS_Strategic_Task.iInspectionComplianceDomain, CS_Strategic_Task.iInspectionComplianceGuidelines, CS_Strategic_Task.iRiskManagement, CS_Strategic_Task.iEvidence,  ";
            //sSQL += "                          CS_Strategic_Task.iInitiative, CS_Strategic_Task.iOrder, CS_Strategic_Task.iStrategyVersion, CS_Strategic_Task.dAdded, CS_Strategic_Task.sAddedBy, CS_Strategic_Task.dUpdated, CS_Strategic_Task.sUpdatedBy,  ";
            //sSQL += "                          CS_Strategic_Period.sPeriod, Lkp_Department.DescEN, Lkp_Department.DepartmentAbbreviation, Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1, CS_Stipulation.sStipulationID,  ";
            //sSQL += "                          CS_Stipulation.sStipulationDesc, CS_Sub_Stipulation.sSubStipulationID, CS_Sub_Stipulation.sSubStipulationDesc, CS_Stipulation_Guidelines.sGuidelinesID, CS_Stipulation_Guidelines.sGuidelinesDesc,  ";
            //sSQL += "                          CS_Inspection_Compliance_Standard.sInspectionComplianceStandardID, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardDesc, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID,  ";
            //sSQL += "                          CS_Inspection_Compliance_Domain.sInspectionComplianceDomainDesc, CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesID,  ";
            //sSQL += "                          CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesDesc, CS_Risk_Management.sRiskManagement, CS_Strategic_Initiative.sInitiativeID, CS_Strategic_Initiative.sInitiativeDesc,  ";
            //sSQL += "                          CS_Strategy_Version.sStrategyVersion, CS_Strategic_Evidence.sEvidenceTitle ";
            //sSQL += " FROM            CS_Strategic_Evidence INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Domain INNER JOIN ";
            //sSQL += "                          CS_Strategic_Task INNER JOIN ";
            //sSQL += "                          CS_Strategic_Period ON CS_Strategic_Task.iPeriod = CS_Strategic_Period.iSerial INNER JOIN ";
            //sSQL += "                          Lkp_Department ON CS_Strategic_Task.iDepartment = Lkp_Department.DepartmentID INNER JOIN ";
            //sSQL += "                          Lkp_Section ON CS_Strategic_Task.iSection = Lkp_Section.SectionID INNER JOIN ";
            //sSQL += "                          CS_Stipulation ON CS_Strategic_Task.iStipulation = CS_Stipulation.iSerial INNER JOIN ";
            //sSQL += "                          CS_Sub_Stipulation ON CS_Strategic_Task.iSubStipulation = CS_Sub_Stipulation.iSerial INNER JOIN ";
            //sSQL += "                          CS_Stipulation_Guidelines ON CS_Strategic_Task.iGuideline = CS_Stipulation_Guidelines.iSerial INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Standard ON CS_Strategic_Task.iInspectionComplianceStandard = CS_Inspection_Compliance_Standard.iSerial ON  ";
            //sSQL += "                          CS_Inspection_Compliance_Domain.iSerial = CS_Strategic_Task.iInspectionComplianceDomain INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Guidelines ON CS_Strategic_Task.iInspectionComplianceGuidelines = CS_Inspection_Compliance_Guidelines.iSerial INNER JOIN ";
            //sSQL += "                          CS_Risk_Management ON CS_Strategic_Task.iRiskManagement = CS_Risk_Management.iSerial INNER JOIN ";
            //sSQL += "                          CS_Strategic_Initiative ON CS_Strategic_Task.iInitiative = CS_Strategic_Initiative.iSerial INNER JOIN ";
            //sSQL += "                          CS_Strategy_Version ON CS_Strategic_Task.iStrategyVersion = CS_Strategy_Version.iSerial ON CS_Strategic_Evidence.iSerial = CS_Strategic_Task.iEvidence ";
            //sSQL  = " SELECT        CS_Strategic_Task.iSerial, CS_Strategic_Task.sTaskID, CS_Strategic_Task.sTaskDesc, CS_Strategic_Task.iPeriod, CS_Strategic_Task.dStart, CS_Strategic_Task.dEnd, CS_Strategic_Task.iDepartment,  ";
            //sSQL += "                          CS_Strategic_Task.iSection, CS_Strategic_Task.iStipulation, CS_Strategic_Task.iSubStipulation, CS_Strategic_Task.iGuideline, CS_Strategic_Task.iInspectionComplianceStandard,  ";
            //sSQL += "                          CS_Strategic_Task.iInspectionComplianceDomain, CS_Strategic_Task.iInspectionComplianceGuidelines,  CS_Strategic_Task.iEvidence, CS_Strategic_Task.iInitiative,  ";
            //sSQL += "                          CS_Strategic_Task.iOrder, CS_Strategic_Task.iStrategyVersion, CS_Strategic_Task.dAdded, CS_Strategic_Task.sAddedBy, CS_Strategic_Task.dUpdated, CS_Strategic_Task.sUpdatedBy, CS_Strategic_Period.sPeriod,  ";
            //sSQL += "                          Lkp_Department.DescEN, Lkp_Department.DepartmentAbbreviation, Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1, CS_Stipulation.sStipulationID, CS_Stipulation.sStipulationDesc,  ";
            //sSQL += "                          CS_Sub_Stipulation.sSubStipulationID, CS_Sub_Stipulation.sSubStipulationDesc, CS_Stipulation_Guidelines.sGuidelinesID, CS_Stipulation_Guidelines.sGuidelinesDesc,  ";
            //sSQL += "                          CS_Inspection_Compliance_Standard.sInspectionComplianceStandardID, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardDesc, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID,  ";
            //sSQL += "                          CS_Inspection_Compliance_Domain.sInspectionComplianceDomainDesc, CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesID,  ";
            //sSQL += "                          CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesDesc, CS_Strategic_Initiative.sInitiativeID, CS_Strategic_Initiative.sInitiativeDesc, CS_Strategy_Version.sStrategyVersion,  ";
            //sSQL += "                          CS_Strategic_Evidence.sEvidenceTitle ";
            //sSQL += " FROM            CS_Inspection_Compliance_Domain INNER JOIN ";
            //sSQL += "                          CS_Strategic_Task INNER JOIN ";
            //sSQL += "                          CS_Strategic_Period ON CS_Strategic_Task.iPeriod = CS_Strategic_Period.iSerial INNER JOIN ";
            //sSQL += "                          Lkp_Department ON CS_Strategic_Task.iDepartment = Lkp_Department.DepartmentID INNER JOIN ";
            //sSQL += "                          Lkp_Section ON CS_Strategic_Task.iSection = Lkp_Section.SectionID INNER JOIN ";
            //sSQL += "                          CS_Stipulation ON CS_Strategic_Task.iStipulation = CS_Stipulation.iSerial INNER JOIN ";
            //sSQL += "                          CS_Sub_Stipulation ON CS_Strategic_Task.iSubStipulation = CS_Sub_Stipulation.iSerial INNER JOIN ";
            //sSQL += "                          CS_Stipulation_Guidelines ON CS_Strategic_Task.iGuideline = CS_Stipulation_Guidelines.iSerial INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Standard ON CS_Strategic_Task.iInspectionComplianceStandard = CS_Inspection_Compliance_Standard.iSerial ON  ";
            //sSQL += "                          CS_Inspection_Compliance_Domain.iSerial = CS_Strategic_Task.iInspectionComplianceDomain INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Guidelines ON CS_Strategic_Task.iInspectionComplianceGuidelines = CS_Inspection_Compliance_Guidelines.iSerial INNER JOIN ";
            //sSQL += "                          CS_Strategic_Initiative ON CS_Strategic_Task.iInitiative = CS_Strategic_Initiative.iSerial INNER JOIN ";
            //sSQL += "                          CS_Strategy_Version ON CS_Strategic_Task.iStrategyVersion = CS_Strategy_Version.iSerial INNER JOIN ";
            //sSQL += "                          CS_Strategic_Evidence ON CS_Strategic_Task.iEvidence = CS_Strategic_Evidence.iSerial ";
            //sSQL  = " SELECT        CS_Strategic_Task.iSerial, CS_Strategic_Task.sTaskID, CS_Strategic_Task.sTaskDesc, CS_Strategic_Task.iPeriod, CS_Strategic_Task.iDepartment, CS_Strategic_Task.iSection, CS_Strategic_Task.iStipulation,  ";
            //sSQL += "                          CS_Strategic_Task.iSubStipulation, CS_Strategic_Task.iGuideline, CS_Strategic_Task.iInspectionComplianceStandard, CS_Strategic_Task.iInspectionComplianceDomain, CS_Strategic_Task.iInspectionComplianceGuidelines,  ";
            //sSQL += "                          CS_Strategic_Task.iEvidence, CS_Strategic_Task.iInitiative, CS_Strategic_Task.iOrder, CS_Strategic_Task.iStrategyVersion, CS_Strategic_Task.dAdded, CS_Strategic_Task.sAddedBy, CS_Strategic_Task.dUpdated,  ";
            //sSQL += "                          CS_Strategic_Task.sUpdatedBy, CS_Strategic_Period.sPeriod, Lkp_Department.DescEN, Lkp_Department.DepartmentAbbreviation, Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1,  ";
            //sSQL += "                          CS_Stipulation.sStipulationID, CS_Stipulation.sStipulationDesc, CS_Sub_Stipulation.sSubStipulationID, CS_Sub_Stipulation.sSubStipulationDesc, CS_Stipulation_Guidelines.sGuidelinesID,  ";
            //sSQL += "                          CS_Stipulation_Guidelines.sGuidelinesDesc, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardID, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardDesc,  ";
            //sSQL += "                          CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainDesc, CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesID,  ";
            //sSQL += "                          CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesDesc, CS_Strategic_Initiative.sInitiativeID, CS_Strategic_Initiative.sInitiativeDesc, CS_Strategy_Version.sStrategyVersion,  ";
            //sSQL += "                          CS_Strategic_Evidence.sEvidenceTitle, CS_Strategic_Task.iSurveyFormReference, CS_Strategic_Task.iDuration, CS_Strategic_Task.iDurationValue, CS_Strategic_Task_Duration.sDuration,  ";
            //sSQL += "                          CS_Survey_Form.sSurveyFormReference,  CS_Survey_Form.sSurveyName ";
            //sSQL += " FROM            CS_Inspection_Compliance_Domain INNER JOIN ";
            //sSQL += "                          CS_Strategic_Task INNER JOIN ";
            //sSQL += "                          CS_Strategic_Period ON CS_Strategic_Task.iPeriod = CS_Strategic_Period.iSerial INNER JOIN ";
            //sSQL += "                          Lkp_Department ON CS_Strategic_Task.iDepartment = Lkp_Department.DepartmentID INNER JOIN ";
            //sSQL += "                          Lkp_Section ON CS_Strategic_Task.iSection = Lkp_Section.SectionID INNER JOIN ";
            //sSQL += "                          CS_Stipulation ON CS_Strategic_Task.iStipulation = CS_Stipulation.iSerial INNER JOIN ";
            //sSQL += "                          CS_Sub_Stipulation ON CS_Strategic_Task.iSubStipulation = CS_Sub_Stipulation.iSerial INNER JOIN ";
            //sSQL += "                          CS_Stipulation_Guidelines ON CS_Strategic_Task.iGuideline = CS_Stipulation_Guidelines.iSerial INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Standard ON CS_Strategic_Task.iInspectionComplianceStandard = CS_Inspection_Compliance_Standard.iSerial ON  ";
            //sSQL += "                          CS_Inspection_Compliance_Domain.iSerial = CS_Strategic_Task.iInspectionComplianceDomain INNER JOIN ";
            //sSQL += "                          CS_Inspection_Compliance_Guidelines ON CS_Strategic_Task.iInspectionComplianceGuidelines = CS_Inspection_Compliance_Guidelines.iSerial INNER JOIN ";
            //sSQL += "                          CS_Strategic_Initiative ON CS_Strategic_Task.iInitiative = CS_Strategic_Initiative.iSerial INNER JOIN ";
            //sSQL += "                          CS_Strategy_Version ON CS_Strategic_Task.iStrategyVersion = CS_Strategy_Version.iSerial INNER JOIN ";
            //sSQL += "                          CS_Strategic_Evidence ON CS_Strategic_Task.iEvidence = CS_Strategic_Evidence.iSerial INNER JOIN ";
            //sSQL += "                          CS_Strategic_Task_Duration ON CS_Strategic_Task.iDuration = CS_Strategic_Task_Duration.iSerial INNER JOIN ";
            //sSQL += "                          CS_Survey_Form ON CS_Strategic_Task.iSurveyFormReference = CS_Survey_Form.iSerial ";
            sSQL  = " SELECT        CS_Strategic_Task.iSerial, CS_Strategic_Task.sTaskID, CS_Strategic_Task.sTaskDesc, CS_Strategic_Task.iPeriod, CS_Strategic_Task.iDepartment, CS_Strategic_Task.iSection, CS_Strategic_Task.iStipulation,  ";
            sSQL += "                          CS_Strategic_Task.iSubStipulation, CS_Strategic_Task.iGuideline, CS_Strategic_Task.iInspectionComplianceStandard, CS_Strategic_Task.iInspectionComplianceDomain, CS_Strategic_Task.iInspectionComplianceGuidelines,  ";
            sSQL += "                          CS_Strategic_Task.iEvidence, CS_Strategic_Task.iInitiative, CS_Strategic_Task.iOrder, CS_Strategic_Task.iStrategyVersion, CS_Strategic_Task.dAdded, CS_Strategic_Task.sAddedBy, CS_Strategic_Task.dUpdated,  ";
            sSQL += "                          CS_Strategic_Task.sUpdatedBy, CS_Strategic_Period.sPeriod, Lkp_Department.DescEN, Lkp_Department.DepartmentAbbreviation, Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1,  ";
            sSQL += "                          CS_Stipulation.sStipulationID, CS_Stipulation.sStipulationDesc, CS_Sub_Stipulation.sSubStipulationID, CS_Sub_Stipulation.sSubStipulationDesc, CS_Stipulation_Guidelines.sGuidelinesID,  ";
            sSQL += "                          CS_Stipulation_Guidelines.sGuidelinesDesc, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardID, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardDesc,  ";
            sSQL += "                          CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainDesc, CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesID,  ";
            sSQL += "                          CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesDesc, CS_Strategic_Initiative.sInitiativeID, CS_Strategic_Initiative.sInitiativeDesc, CS_Strategy_Version.sStrategyVersion,  ";
            sSQL += "                          CS_Strategic_Evidence.sEvidenceRecored, CS_Strategic_Task.iSurveyFormReference, CS_Strategic_Task.iDuration, CS_Strategic_Task.iDurationValue, CS_Strategic_Task_Duration.sDuration,  ";
            sSQL += "                          CS_Survey_Form.sSurveyFormReference, CS_Survey_Form.sSurveyName, CS_Strategic_Task.sEV, CS_Strategic_Task.iDigitalTransformationProgram, CS_Strategic_Task.iDigitalUseCase,  ";
            sSQL += "                          CS_Digital_Transformation_Program.sDigitalTransformationProgram, CS_Digital_Use_Case.sDigitalUseCase ";
            sSQL += " FROM            CS_Inspection_Compliance_Domain INNER JOIN ";
            sSQL += "                          CS_Strategic_Task INNER JOIN ";
            sSQL += "                          CS_Strategic_Period ON CS_Strategic_Task.iPeriod = CS_Strategic_Period.iSerial INNER JOIN ";
            sSQL += "                          Lkp_Department ON CS_Strategic_Task.iDepartment = Lkp_Department.DepartmentID INNER JOIN ";
            sSQL += "                          Lkp_Section ON CS_Strategic_Task.iSection = Lkp_Section.SectionID INNER JOIN ";
            sSQL += "                          CS_Stipulation ON CS_Strategic_Task.iStipulation = CS_Stipulation.iSerial INNER JOIN ";
            sSQL += "                          CS_Sub_Stipulation ON CS_Strategic_Task.iSubStipulation = CS_Sub_Stipulation.iSerial INNER JOIN ";
            sSQL += "                          CS_Stipulation_Guidelines ON CS_Strategic_Task.iGuideline = CS_Stipulation_Guidelines.iSerial INNER JOIN ";
            sSQL += "                          CS_Inspection_Compliance_Standard ON CS_Strategic_Task.iInspectionComplianceStandard = CS_Inspection_Compliance_Standard.iSerial ON  ";
            sSQL += "                          CS_Inspection_Compliance_Domain.iSerial = CS_Strategic_Task.iInspectionComplianceDomain INNER JOIN ";
            sSQL += "                          CS_Inspection_Compliance_Guidelines ON CS_Strategic_Task.iInspectionComplianceGuidelines = CS_Inspection_Compliance_Guidelines.iSerial INNER JOIN ";
            sSQL += "                          CS_Strategic_Initiative ON CS_Strategic_Task.iInitiative = CS_Strategic_Initiative.iSerial INNER JOIN ";
            sSQL += "                          CS_Strategy_Version ON CS_Strategic_Task.iStrategyVersion = CS_Strategy_Version.iSerial INNER JOIN ";
            sSQL += "                          CS_Strategic_Evidence ON CS_Strategic_Task.iEvidence = CS_Strategic_Evidence.iSerial INNER JOIN ";
            sSQL += "                          CS_Strategic_Task_Duration ON CS_Strategic_Task.iDuration = CS_Strategic_Task_Duration.iSerial INNER JOIN ";
            sSQL += "                          CS_Survey_Form ON CS_Strategic_Task.iSurveyFormReference = CS_Survey_Form.iSerial INNER JOIN ";
            sSQL += "                          CS_Digital_Transformation_Program ON CS_Strategic_Task.iDigitalTransformationProgram = CS_Digital_Transformation_Program.iSerial INNER JOIN ";
            sSQL += "                          CS_Digital_Use_Case ON CS_Strategic_Task.iDigitalUseCase = CS_Digital_Use_Case.iSerial ";
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
            //Response.Redirect("Strategy_Strategic_Task_Update?id=" + Request.QueryString["id"] + "");
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                //Response.Redirect("Strategy_Strategic_Initiative_Home.aspx?f=m&id=" + id + "");
                Response.Redirect("Strategy_Strategic_Task_Update?f=m&id=" + Request.QueryString["id"] + "");
            }
            else
            {
                //Response.Redirect("Strategy_Strategic_Initiative_Home");
                Response.Redirect("Strategy_Strategic_Task_Update?id=" + Request.QueryString["id"] + "");
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
                Response.Redirect("Strategy_Strategic_Task_Update.aspx?f=m&id=" + id + "&sid=" + commandArgument + "&t=v");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_Task_Update.aspx?id=" + id + "&sid=" + commandArgument + "&t=v");
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
                Response.Redirect("Strategy_Strategic_Task_Update.aspx?f=m&id=" + id + "&sid=" + commandArgument + "&t=e");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_Task_Update.aspx?id=" + id + "&sid=" + commandArgument + "&t=e");
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
                Response.Redirect("Strategy_Strategic_Task_Detail_Home.aspx?f=m&id=" + id + "&sid=" + commandArgument + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_Task_Detail_Home.aspx?id=" + id + "&sid=" + commandArgument + "");
            }
        }
    }
}