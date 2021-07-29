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
using System.Globalization;
using System.IO;

namespace LocalECT
{
    public partial class Strategy_Strategic_Task_Update : System.Web.UI.Page
    {
        int CurrentRole = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
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
                        fillInitiative();                        
                        drp_Initiative.SelectedIndex = drp_Initiative.Items.IndexOf(drp_Initiative.Items.FindByValue(Request.QueryString["id"]));
                        fillStrategyVersion();
                        if (!string.IsNullOrEmpty(drp_Initiative.SelectedValue))
                        {
                            drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_Initiative.SelectedItem.Value)));
                        }
                        fillStrategic_Period();

                        fillDepartment();
                        fillSection();

                        fillStipulation();
                        fillsubStipulation();
                        fillGuideline();



                        //fillRiskManagement();
                        fillSurveyFormReference();
                        //fillIRQARecommendation();
                        fillEvidence();
                        fillDuration();

                        //fillInspectionComplianceGuidelines();
                        //fillInspectionCompliance();

                        fillInspection_Compliance_Standard();
                        fillInspectionComplianceDomain();
                        fillInspectionComplianceGuidelines();

                        fillDigitalTransformationProgram();
                        if (!string.IsNullOrEmpty(drp_Initiative.SelectedValue))
                        {
                            drp_DigitalTransformationProgram.SelectedIndex = drp_DigitalTransformationProgram.Items.IndexOf(drp_DigitalTransformationProgram.Items.FindByValue(getDigitalTransformationProgram(drp_Initiative.SelectedItem.Value)));
                        }
                        fillDigitalUseCase();

                        string id = Request.QueryString["id"];//Initiative ID
                        string sid = Request.QueryString["sid"];//Task ID
                        string t = Request.QueryString["t"];
                        if (sid != null)
                        {
                            bindStrategic_Task(sid);
                            btn_Create.Text = "Update";
                            lbl_Header.Text = "Edit Strategic Task";
                            if (t == "v")//View
                            {
                                btn_Create.Visible = false;
                                lbl_Header.Text = "View Strategic Task";

                                txt_TaskID.Enabled = false;
                                txt_TaskDesc.Enabled = false;
                                drp_Period.Enabled = false;
                                //txt_dStart.Enabled = false;
                                //txt_dEnd.Enabled = false;
                                //drp_Department.Enabled = false;
                                //drp_Section.Enabled = false;
                                drp_Stipulation.Enabled = false;
                                drp_SubStipulation.Enabled = false;
                                drp_Guideline.Enabled = false;
                                drp_InspectionComplianceGuidelines.Enabled = false;
                                //drp_RiskManagement.Enabled = false;
                                drp_SurveyFormReference.Enabled = false;
                                //drp_IRQARecommendation.Enabled = false;
                                drp_Evidence.Enabled = false;
                                drp_Duration.Enabled = false;
                                txt_DurationValue.Enabled = false;
                                txt_Order.Enabled = false;
                                txt_EV.Enabled = false;
                                //drp_DigitalTransformationProgram.Enabled = false;
                                drp_DigitalUseCase.Enabled = false;                                
                            }
                            else if (t == "e")//Edit
                            {
                                btn_Create.Visible = true;
                                lbl_Header.Text = "Edit Strategic Task";

                                txt_TaskID.Enabled = true;
                                txt_TaskDesc.Enabled = true;
                                drp_Period.Enabled = true;
                                //txt_dStart.Enabled = true;
                                //txt_dEnd.Enabled = true;
                                //drp_Department.Enabled = true;
                                //drp_Section.Enabled = true;
                                drp_Stipulation.Enabled = true;
                                drp_SubStipulation.Enabled = true;
                                drp_Guideline.Enabled = true;
                                drp_InspectionComplianceGuidelines.Enabled = true;
                                //drp_RiskManagement.Enabled = true;
                                drp_SurveyFormReference.Enabled = true;
                                //drp_IRQARecommendation.Enabled = true;
                                drp_Evidence.Enabled = true;
                                drp_Duration.Enabled = true;
                                txt_DurationValue.Enabled = true;
                                txt_Order.Enabled = true;
                                txt_EV.Enabled = true;
                                //drp_DigitalTransformationProgram.Enabled = true;
                                drp_DigitalUseCase.Enabled = true;
                            }
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New Task";
                        }
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
        public void fillInitiative()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sInitiativeID from CS_Strategic_Initiative", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Initiative.DataSource = dt;
                drp_Initiative.DataTextField = "sInitiativeID";
                drp_Initiative.DataValueField = "iSerial";
                drp_Initiative.DataBind();                
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
        public void fillStrategyVersion()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sStrategyVersion from CS_Strategy_Version", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_StrategyVersion.DataSource = dt;
                drp_StrategyVersion.DataTextField = "sStrategyVersion";
                drp_StrategyVersion.DataValueField = "iSerial";
                drp_StrategyVersion.DataBind();
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
        public string getStrategy_Version(string id)
        {
            string sid = "";
            SqlCommand cmd = new SqlCommand("select iStrategyVersion from CS_Strategic_Initiative where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    sid = dt.Rows[0]["iStrategyVersion"].ToString();
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
            return sid;
        }
        public string getDigitalTransformationProgram(string id)
        {
            string sid = "";
            SqlCommand cmd = new SqlCommand("select iDigitalTransformationProgram from CS_Strategic_Initiative where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    sid = dt.Rows[0]["iDigitalTransformationProgram"].ToString();
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
            return sid;
        }
        public void fillStrategic_Period()
        {
            if (!string.IsNullOrEmpty(drp_StrategyVersion.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sPeriod from CS_Strategic_Period where iStrategyVersion=@iStrategyVersion", sc);
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_Period.DataSource = dt;
                    drp_Period.DataTextField = "sPeriod";
                    drp_Period.DataValueField = "iSerial";
                    drp_Period.DataBind();
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
        }
        public void fillDepartment()
        {
            SqlCommand cmd = new SqlCommand("select DepartmentID,DescEN from Lkp_Department where (Lkp_Department.IsActive = 1) and (Lkp_Department.DepartmentID<>-1) and Lkp_Department.DepartmentID in (SELECT [iDepartment] FROM [CS_Initiative_Dpartment_Section] where iInitiative=@iInitiative)", sc);
            cmd.Parameters.AddWithValue("@iInitiative", Request.QueryString["id"]);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Department.DataSource = dt;
                drp_Department.DataTextField = "DescEN";
                drp_Department.DataValueField = "DepartmentID";
                drp_Department.DataBind();                
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
        public void fillSection()
        {
            if (!string.IsNullOrEmpty(drp_Department.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select SectionID,DescEN from Lkp_Section where DepartmentID=@DepartmentID and Lkp_Section.SectionID in (SELECT [iSection] FROM [CS_Initiative_Dpartment_Section] where iInitiative=@iInitiative and iDepartment=@DepartmentID)", sc);
                cmd.Parameters.AddWithValue("@DepartmentID", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInitiative", Request.QueryString["id"]);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_Section.DataSource = dt;
                    drp_Section.DataTextField = "DescEN";
                    drp_Section.DataValueField = "SectionID";
                    drp_Section.DataBind();
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
        }
        public void fillStipulation()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sStipulationID from CS_Stipulation", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Stipulation.DataSource = dt;
                drp_Stipulation.DataTextField = "sStipulationID";
                drp_Stipulation.DataValueField = "iSerial";
                drp_Stipulation.DataBind();
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
        public void fillsubStipulation()
        {
            if (!string.IsNullOrEmpty(drp_Stipulation.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sSubStipulationID from CS_Sub_Stipulation where iStipulation=@iStipulation", sc);
                cmd.Parameters.AddWithValue("@iStipulation", drp_Stipulation.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_SubStipulation.DataSource = dt;
                    drp_SubStipulation.DataTextField = "sSubStipulationID";
                    drp_SubStipulation.DataValueField = "iSerial";
                    drp_SubStipulation.DataBind();
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
        }
        public void fillGuideline()
        {
            if (!string.IsNullOrEmpty(drp_SubStipulation.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sGuidelinesID from CS_Stipulation_Guidelines where iSubStipulation=@iSubStipulation", sc);
                cmd.Parameters.AddWithValue("@iSubStipulation", drp_SubStipulation.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_Guideline.DataSource = dt;
                    drp_Guideline.DataTextField = "sGuidelinesID";
                    drp_Guideline.DataValueField = "iSerial";
                    drp_Guideline.DataBind();
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
        }
        //public void fillRiskManagement()
        //{
        //    SqlCommand cmd = new SqlCommand("select iSerial,sRiskManagement from CS_Risk_Management", sc);
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    try
        //    {
        //        sc.Open();
        //        da.Fill(dt);
        //        sc.Close();

        //        drp_RiskManagement.DataSource = dt;
        //        drp_RiskManagement.DataTextField = "sRiskManagement";
        //        drp_RiskManagement.DataValueField = "iSerial";
        //        drp_RiskManagement.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        sc.Close();
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        sc.Close();
        //    }
        //}
        public void fillSurveyFormReference()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sSurveyFormReference from CS_Survey_Form", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_SurveyFormReference.DataSource = dt;
                drp_SurveyFormReference.DataTextField = "sSurveyFormReference";
                drp_SurveyFormReference.DataValueField = "iSerial";
                drp_SurveyFormReference.DataBind();
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
        //public void fillIRQARecommendation()
        //{
        //    SqlCommand cmd = new SqlCommand("select iSerial,sIRQARecommendation from CS_IRQA_Recommendation", sc);
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    try
        //    {
        //        sc.Open();
        //        da.Fill(dt);
        //        sc.Close();

        //        drp_IRQARecommendation.DataSource = dt;
        //        drp_IRQARecommendation.DataTextField = "sIRQARecommendation";
        //        drp_IRQARecommendation.DataValueField = "iSerial";
        //        drp_IRQARecommendation.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        sc.Close();
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        sc.Close();
        //    }
        //}
        public void fillEvidence()
        {
            if (!string.IsNullOrEmpty(drp_StrategyVersion.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sEvidenceTitle from CS_Strategic_Evidence where iStrategyVersion=@iStrategyVersion and iDepartment=@iDepartment and iSection=@iSection", sc);
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDepartment", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSection", drp_Section.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_Evidence.DataSource = dt;
                    drp_Evidence.DataTextField = "sEvidenceTitle";
                    drp_Evidence.DataValueField = "iSerial";
                    drp_Evidence.DataBind();
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
        }
        //public void fillInspectionComplianceGuidelines()
        //{
        //    DataTable dtGuideline = new DataTable();
        //    dtGuideline.Clear();
        //    dtGuideline.Columns.Add("iSerial");
        //    dtGuideline.Columns.Add("sInspectionComplianceGuidelinesID");

        //    SqlCommand cmd1 = new SqlCommand("select * from CS_Initiative_Inspection_Compliance where iInatiative=@iInatiative", sc);
        //    cmd1.Parameters.AddWithValue("@iInatiative", Request.QueryString["id"]);
        //    DataTable dt1 = new DataTable();
        //    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        //    try
        //    {
        //        sc.Open();
        //        da1.Fill(dt1);
        //        sc.Close();

        //        if(dt1.Rows.Count>0)
        //        {
        //            for(int i=0;i<dt1.Rows.Count;i++)
        //            {
        //                SqlCommand cmd2 = new SqlCommand("select * from CS_Inspection_Compliance_Guidelines where iInspectionComplianceStandard=@iInspectionComplianceStandard and iInspectionComplianceDomain=@iInspectionComplianceDomain", sc);
        //                cmd2.Parameters.AddWithValue("@iInspectionComplianceStandard", dt1.Rows[i]["iInspectionComplianceStandard"].ToString());
        //                cmd2.Parameters.AddWithValue("@iInspectionComplianceDomain", dt1.Rows[i]["iInspectionComplianceDomain"].ToString());
        //                //cmd2.Parameters.AddWithValue("@iInspectionComplianceIndicator", dt1.Rows[i]["InspectionComplianceIndicator"].ToString());
        //                DataTable dt2 = new DataTable();
        //                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        //                try
        //                {
        //                    sc.Open();
        //                    da2.Fill(dt2);
        //                    sc.Close();

        //                    if(dt2.Rows.Count>0)
        //                    {
        //                        DataRow dr = dtGuideline.NewRow();
        //                        dr["iSerial"] = dt2.Rows[0]["iSerial"].ToString();
        //                        dr["sInspectionComplianceGuidelinesID"] = dt2.Rows[0]["sInspectionComplianceGuidelinesID"].ToString();
        //                        dtGuideline.Rows.Add(dr);
        //                    }
        //                }
        //                catch(Exception ex)
        //                {
        //                    sc.Close();
        //                    Console.WriteLine(ex.Message);
        //                }
        //                finally
        //                {
        //                    sc.Close();
        //                }
        //            }

        //            drp_InspectionComplianceGuidelines.DataSource = dtGuideline;
        //            drp_InspectionComplianceGuidelines.DataTextField = "sInspectionComplianceGuidelinesID";
        //            drp_InspectionComplianceGuidelines.DataValueField = "iSerial";
        //            drp_InspectionComplianceGuidelines.DataBind();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        sc.Close();
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        sc.Close();
        //    }
        //}
        //public void fillInspectionCompliance()
        //{
        //    hdn_InspectionComplianceStandard.Value = "";
        //    hdn_InspectionComplianceDomain.Value = "";
        //    //hdn_InspectionComplianceIndicator.Value = "";

        //    if (!string.IsNullOrEmpty(drp_InspectionComplianceGuidelines.SelectedValue))
        //    {
        //        SqlCommand cmd = new SqlCommand("SELECT CS_Inspection_Compliance_Guidelines.iSerial, CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesID, CS_Inspection_Compliance_Guidelines.sInspectionComplianceGuidelinesDesc, CS_Inspection_Compliance_Guidelines.iInspectionComplianceStandard, CS_Inspection_Compliance_Guidelines.iInspectionComplianceDomain, CS_Inspection_Compliance_Guidelines.iOrder, CS_Inspection_Compliance_Guidelines.dAdded, CS_Inspection_Compliance_Guidelines.sAddedBy, CS_Inspection_Compliance_Guidelines.dUpdated, CS_Inspection_Compliance_Guidelines.sUpdatedBy, CS_Inspection_Compliance_Standard.sInspectionComplianceStandardID, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID FROM CS_Inspection_Compliance_Guidelines INNER JOIN CS_Inspection_Compliance_Standard ON CS_Inspection_Compliance_Guidelines.iInspectionComplianceStandard = CS_Inspection_Compliance_Standard.iSerial INNER JOIN CS_Inspection_Compliance_Domain ON CS_Inspection_Compliance_Guidelines.iInspectionComplianceDomain = CS_Inspection_Compliance_Domain.iSerial where CS_Inspection_Compliance_Guidelines.iSerial=@iSerial", sc);
        //        cmd.Parameters.AddWithValue("@iSerial", drp_InspectionComplianceGuidelines.SelectedItem.Value);
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        try
        //        {
        //            sc.Open();
        //            da.Fill(dt);
        //            sc.Close();
                    
        //            if(dt.Rows.Count>0)
        //            {
        //                txt_InspectionComplianceStandard.Text = dt.Rows[0]["sInspectionComplianceStandardID"].ToString();
        //                hdn_InspectionComplianceStandard.Value = dt.Rows[0]["iInspectionComplianceStandard"].ToString();

        //                txt_InspectionComplianceDomain.Text = dt.Rows[0]["sInspectionComplianceDomainID"].ToString();
        //                hdn_InspectionComplianceDomain.Value = dt.Rows[0]["iInspectionComplianceDomain"].ToString();

        //                //txt_InspectionComplianceIndicator.Text = dt.Rows[0]["sInspectionComplianceIndicatorDesc"].ToString();
        //                //hdn_InspectionComplianceIndicator.Value = dt.Rows[0]["iInspectionComplianceIndicator"].ToString();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            sc.Close();
        //            Console.WriteLine(ex.Message);
        //        }
        //        finally
        //        {
        //            sc.Close();
        //        }
        //    }
        //}

        public void fillDuration()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sDuration from CS_Strategic_Task_Duration", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Duration.DataSource = dt;
                drp_Duration.DataTextField = "sDuration";
                drp_Duration.DataValueField = "iSerial";
                drp_Duration.DataBind();
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

        public void fillDigitalTransformationProgram()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sDigitalTransformationProgram from CS_Digital_Transformation_Program", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_DigitalTransformationProgram.DataSource = dt;
                drp_DigitalTransformationProgram.DataTextField = "sDigitalTransformationProgram";
                drp_DigitalTransformationProgram.DataValueField = "iSerial";
                drp_DigitalTransformationProgram.DataBind();
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
        public void fillDigitalUseCase()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sDigitalUseCase from CS_Digital_Use_Case", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_DigitalUseCase.DataSource = dt;
                drp_DigitalUseCase.DataTextField = "sDigitalUseCase";
                drp_DigitalUseCase.DataValueField = "iSerial";
                drp_DigitalUseCase.DataBind();
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

        public void fillInspection_Compliance_Standard()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sInspectionComplianceStandardID from CS_Inspection_Compliance_Standard", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_InspectionComplianceStandard.DataSource = dt;
                drp_InspectionComplianceStandard.DataTextField = "sInspectionComplianceStandardID";
                drp_InspectionComplianceStandard.DataValueField = "iSerial";
                drp_InspectionComplianceStandard.DataBind();
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
        public void fillInspectionComplianceDomain()
        {
            if (!string.IsNullOrEmpty(drp_InspectionComplianceStandard.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sInspectionComplianceDomainID from CS_Inspection_Compliance_Domain where iInspectionComplianceStandard=@iInspectionComplianceStandard", sc);
                cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", drp_InspectionComplianceStandard.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_InspectionComplianceDomain.DataSource = dt;
                    drp_InspectionComplianceDomain.DataTextField = "sInspectionComplianceDomainID";
                    drp_InspectionComplianceDomain.DataValueField = "iSerial";
                    drp_InspectionComplianceDomain.DataBind();
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
        }
        public void fillInspectionComplianceGuidelines()
        {
            if (!string.IsNullOrEmpty(drp_InspectionComplianceDomain.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sInspectionComplianceGuidelinesID from CS_Inspection_Compliance_Guidelines where iInspectionComplianceDomain=@iInspectionComplianceDomain", sc);
                cmd.Parameters.AddWithValue("@iInspectionComplianceDomain", drp_InspectionComplianceDomain.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_InspectionComplianceGuidelines.DataSource = dt;
                    drp_InspectionComplianceGuidelines.DataTextField = "sInspectionComplianceGuidelinesID";
                    drp_InspectionComplianceGuidelines.DataValueField = "iSerial";
                    drp_InspectionComplianceGuidelines.DataBind();
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
        }

        public void bindStrategic_Task(string sid)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Strategic_Task where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", sid);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    txt_TaskID.Text = dt.Rows[0]["sTaskID"].ToString();
                    txt_TaskDesc.Text = dt.Rows[0]["sTaskDesc"].ToString();
                    drp_Period.SelectedIndex = drp_Period.Items.IndexOf(drp_Period.Items.FindByValue(dt.Rows[0]["iPeriod"].ToString()));
                    //txt_dStart.Text = Convert.ToDateTime(dt.Rows[0]["dStart"]).ToString("dd/MM/yyyy");
                    //txt_dEnd.Text = Convert.ToDateTime(dt.Rows[0]["dEnd"]).ToString("dd/MM/yyyy");
                    drp_Department.SelectedIndex = drp_Department.Items.IndexOf(drp_Department.Items.FindByValue(dt.Rows[0]["iDepartment"].ToString()));
                    fillSection();
                    drp_Section.SelectedIndex = drp_Section.Items.IndexOf(drp_Section.Items.FindByValue(dt.Rows[0]["iSection"].ToString()));
                    fillEvidence();
                    drp_Stipulation.SelectedIndex = drp_Stipulation.Items.IndexOf(drp_Stipulation.Items.FindByValue(dt.Rows[0]["iStipulation"].ToString()));
                    fillsubStipulation();
                    drp_SubStipulation.SelectedIndex = drp_SubStipulation.Items.IndexOf(drp_SubStipulation.Items.FindByValue(dt.Rows[0]["iSubStipulation"].ToString()));
                    fillGuideline();
                    drp_Guideline.SelectedIndex = drp_Guideline.Items.IndexOf(drp_Guideline.Items.FindByValue(dt.Rows[0]["iGuideline"].ToString()));
                    
                    drp_InspectionComplianceStandard.SelectedIndex = drp_InspectionComplianceStandard.Items.IndexOf(drp_InspectionComplianceStandard.Items.FindByValue(dt.Rows[0]["iInspectionComplianceStandard"].ToString()));
                    fillInspectionComplianceDomain();
                    drp_InspectionComplianceDomain.SelectedIndex = drp_InspectionComplianceDomain.Items.IndexOf(drp_InspectionComplianceDomain.Items.FindByValue(dt.Rows[0]["iInspectionComplianceDomain"].ToString()));
                    fillInspectionComplianceGuidelines();
                    drp_InspectionComplianceGuidelines.SelectedIndex = drp_InspectionComplianceGuidelines.Items.IndexOf(drp_InspectionComplianceGuidelines.Items.FindByValue(dt.Rows[0]["iInspectionComplianceGuidelines"].ToString()));

                    //drp_InspectionComplianceGuidelines.SelectedIndex = drp_InspectionComplianceGuidelines.Items.IndexOf(drp_InspectionComplianceGuidelines.Items.FindByValue(dt.Rows[0]["iInspectionComplianceGuidelines"].ToString()));                    
                    //drp_RiskManagement.SelectedIndex = drp_RiskManagement.Items.IndexOf(drp_RiskManagement.Items.FindByValue(dt.Rows[0]["iRiskManagement"].ToString()));
                    drp_SurveyFormReference.SelectedIndex = drp_SurveyFormReference.Items.IndexOf(drp_SurveyFormReference.Items.FindByValue(dt.Rows[0]["iSurveyFormReference"].ToString()));
                    //drp_IRQARecommendation.SelectedIndex = drp_IRQARecommendation.Items.IndexOf(drp_IRQARecommendation.Items.FindByValue(dt.Rows[0]["iIRQARecommendation"].ToString()));
                    drp_Evidence.SelectedIndex = drp_Evidence.Items.IndexOf(drp_Evidence.Items.FindByValue(dt.Rows[0]["iEvidence"].ToString()));
                    drp_Initiative.SelectedIndex = drp_Initiative.Items.IndexOf(drp_Initiative.Items.FindByValue(dt.Rows[0]["iInitiative"].ToString()));
                    drp_Duration.SelectedIndex = drp_Duration.Items.IndexOf(drp_Duration.Items.FindByValue(dt.Rows[0]["iDuration"].ToString()));
                    txt_DurationValue.Text = dt.Rows[0]["iDurationValue"].ToString();
                    txt_EV.Text= dt.Rows[0]["sEV"].ToString();
                    drp_DigitalTransformationProgram.SelectedIndex = drp_DigitalTransformationProgram.Items.IndexOf(drp_DigitalTransformationProgram.Items.FindByValue(dt.Rows[0]["iDigitalTransformationProgram"].ToString()));
                    drp_DigitalUseCase.SelectedIndex = drp_DigitalUseCase.Items.IndexOf(drp_DigitalUseCase.Items.FindByValue(dt.Rows[0]["iDigitalUseCase"].ToString()));
                    drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(dt.Rows[0]["iStrategyVersion"].ToString()));
                    txt_Order.Text = dt.Rows[0]["iOrder"].ToString();
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
        }


        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            //string id = Request.QueryString["id"];
            //Response.Redirect("Strategy_Strategic_Task_Home.aspx?id="+ id + "");

            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Task_Home.aspx?f=m&id=" + id + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_Task_Home.aspx?id=" + id + "");
            }
        }

        protected void drp_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSection();
            fillEvidence();
        }

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            string sid = Request.QueryString["sid"];
            if (sid != null)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Initiative,
                              InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Edit";
                    return;
                }

                //Update
                SqlCommand cmd = new SqlCommand("update CS_Strategic_Task set sTaskID=@sTaskID,sTaskDesc=@sTaskDesc,iPeriod=@iPeriod,iDepartment=@iDepartment,iSection=@iSection,iStipulation=@iStipulation,iSubStipulation=@iSubStipulation,iGuideline=@iGuideline,iInspectionComplianceStandard=@iInspectionComplianceStandard,iInspectionComplianceDomain=@iInspectionComplianceDomain,iInspectionComplianceGuidelines=@iInspectionComplianceGuidelines,iEvidence=@iEvidence,iInitiative=@iInitiative,iOrder=@iOrder,iStrategyVersion=@iStrategyVersion,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy,iSurveyFormReference=@iSurveyFormReference,iDuration=@iDuration,iDurationValue=@iDurationValue,sEV=@sEV,iDigitalTransformationProgram=@iDigitalTransformationProgram,iDigitalUseCase=@iDigitalUseCase where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sTaskID", txt_TaskID.Text.Trim());
                cmd.Parameters.AddWithValue("@sTaskDesc", txt_TaskDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iPeriod", drp_Period.SelectedItem.Value);
                //DateTime StartDate = DateTime.ParseExact(txt_dStart.Text, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                //DateTime EndDate = DateTime.ParseExact(txt_dEnd.Text, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                //cmd.Parameters.AddWithValue("@dStart", StartDate);
                //cmd.Parameters.AddWithValue("@dEnd", EndDate);
                cmd.Parameters.AddWithValue("@iDepartment", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSection", drp_Section.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iStipulation", drp_Stipulation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSubStipulation", drp_SubStipulation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iGuideline", drp_Guideline.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", drp_InspectionComplianceStandard.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInspectionComplianceDomain", drp_InspectionComplianceDomain.SelectedItem.Value);
                //cmd.Parameters.AddWithValue("@iInspectionComplianceIndicator", hdn_InspectionComplianceIndicator.Value);
                cmd.Parameters.AddWithValue("@iInspectionComplianceGuidelines", drp_InspectionComplianceGuidelines.SelectedItem.Value);
                //cmd.Parameters.AddWithValue("@iRiskManagement", drp_RiskManagement.SelectedItem.Value);                
                //cmd.Parameters.AddWithValue("@iIRQARecommendation", drp_IRQARecommendation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iEvidence", drp_Evidence.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInitiative", drp_Initiative.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iSurveyFormReference", drp_SurveyFormReference.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDuration", drp_Duration.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDurationValue", txt_DurationValue.Text.Trim());
                cmd.Parameters.AddWithValue("@sEV", txt_EV.Text.Trim());
                cmd.Parameters.AddWithValue("@iDigitalTransformationProgram", drp_DigitalTransformationProgram.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDigitalUseCase", drp_DigitalUseCase.SelectedItem.Value);

                cmd.Parameters.AddWithValue("@iSerial", sid);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic Task Updated Successfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");

                    bindStrategic_Task(sid);
                }
                catch(Exception ex)
                {
                    sc.Close();
                    Console.WriteLine(ex.Message);

                    div_msg.Visible = true;
                    lbl_Msg.Text = ex.Message;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                }
                finally
                {
                    sc.Close();
                }
            }
            else
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Initiative,
                             InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Add";
                    return;
                }

                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Strategic_Task values (@sTaskID,@sTaskDesc,@iPeriod,@iDepartment,@iSection,@iStipulation,@iSubStipulation,@iGuideline,@iInspectionComplianceStandard,@iInspectionComplianceDomain,@iInspectionComplianceGuidelines,@iEvidence,@iInitiative,@iOrder,@iStrategyVersion,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy,@iSurveyFormReference,@iDuration,@iDurationValue,@sEV,@iDigitalTransformationProgram,@iDigitalUseCase)", sc);
                cmd.Parameters.AddWithValue("@sTaskID", txt_TaskID.Text.Trim());
                cmd.Parameters.AddWithValue("@sTaskDesc", txt_TaskDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iPeriod", drp_Period.SelectedItem.Value);
                //DateTime StartDate = DateTime.ParseExact(txt_dStart.Text, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                //DateTime EndDate = DateTime.ParseExact(txt_dEnd.Text, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                //cmd.Parameters.AddWithValue("@dStart", StartDate);
                //cmd.Parameters.AddWithValue("@dEnd", EndDate);
                cmd.Parameters.AddWithValue("@iDepartment", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSection", drp_Section.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iStipulation", drp_Stipulation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSubStipulation", drp_SubStipulation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iGuideline", drp_Guideline.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", drp_InspectionComplianceStandard.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInspectionComplianceDomain", drp_InspectionComplianceDomain.SelectedItem.Value);                
                cmd.Parameters.AddWithValue("@iInspectionComplianceGuidelines", drp_InspectionComplianceGuidelines.SelectedItem.Value);
                //cmd.Parameters.AddWithValue("@iRiskManagement", drp_RiskManagement.SelectedItem.Value);
                
                //cmd.Parameters.AddWithValue("@iIRQARecommendation", drp_IRQARecommendation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iEvidence", drp_Evidence.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInitiative", drp_Initiative.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iSurveyFormReference", drp_SurveyFormReference.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDuration", drp_Duration.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDurationValue", txt_DurationValue.Text.Trim());
                cmd.Parameters.AddWithValue("@sEV", txt_EV.Text.Trim());
                cmd.Parameters.AddWithValue("@iDigitalTransformationProgram", drp_DigitalTransformationProgram.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDigitalUseCase", drp_DigitalUseCase.SelectedItem.Value);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic Task Created Successfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");

                    txt_TaskID.Text = "";
                    txt_TaskDesc.Text = "";
                    //txt_dStart.Text = "";
                    //txt_dEnd.Text = "";
                    //fillInspectionComplianceGuidelines();
                    //fillInspectionCompliance();
                    txt_DurationValue.Text = "";
                    txt_EV.Text = "";
                    txt_Order.Text = "";
                }
                catch (Exception ex)
                {
                    sc.Close();
                    Console.WriteLine(ex.Message);

                    div_msg.Visible = true;
                    lbl_Msg.Text = ex.Message;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                }
                finally
                {
                    sc.Close();
                }
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            //string id = Request.QueryString["id"];
            //Response.Redirect("Strategy_Strategic_Task_Home.aspx?id=" + id + "");
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Task_Home.aspx?f=m&id=" + id + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_Task_Home.aspx?id=" + id + "");
            }
        }

        protected void drp_Stipulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillsubStipulation();
            fillGuideline();
        }

        protected void drp_SubStipulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGuideline();
        }      
        protected void drp_Section_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillEvidence();
        }

        protected void drp_InspectionComplianceStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillInspectionComplianceDomain();
            fillInspectionComplianceGuidelines();
        }

        protected void drp_InspectionComplianceDomain_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillInspectionComplianceGuidelines();
        }
    }
}