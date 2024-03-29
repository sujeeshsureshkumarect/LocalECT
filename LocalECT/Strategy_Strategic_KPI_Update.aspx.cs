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
using System.Globalization;
using System.IO;

namespace LocalECT
{
    public partial class Strategy_Strategic_KPI_Update : System.Web.UI.Page
    {
        int CurrentRole = 0;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
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
                        fillInitiative();
                        fillKPIValueType();
                        fillKPIManagementPracticeType();
                        fillKPIManagementPracticeSubType();
                        fillKPIOutcome();

                        drp_Initiative.SelectedIndex = drp_Initiative.Items.IndexOf(drp_Initiative.Items.FindByValue(Request.QueryString["id"]));
                        fillStrategyVersion();
                        if (!string.IsNullOrEmpty(drp_Initiative.SelectedValue))
                        {
                            drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(drp_Initiative.SelectedItem.Value)));
                        }
                        fillStrategic_Period();

                        fillDepartment();
                        fillSection();

                        fillFormula();
                        fillKPISource();

                        fillKPILevel();
                        fillKPISubLevel();

                        fillMOEClassificationPillars();
                        fillMarketPositioningPillars();

                        fillSurveyFormReference();

                        fillEvidence();
                        //fillRiskManagement();

                        string id = Request.QueryString["id"];//Initiative ID
                        string sid = Request.QueryString["sid"];//Task ID
                        string t = Request.QueryString["t"];
                        if (sid != null)
                        {
                            bindStrategic_KPI(sid);
                            btn_Create.Text = "Update";
                            lbl_Header.Text = "Edit Strategic KPI";
                            if (t == "v")//View
                            {
                                btn_Create.Visible = false;
                                lbl_Header.Text = "View Strategic KPI";

                                txt_KPIID.Enabled = false;
                                txt_KPIDesc.Enabled = false;
                                drp_Period.Enabled = false;
                                drp_Formula.Enabled = false;
                                txt_TargetKPI.Enabled = false;
                                txt_Min.Enabled = false;
                                txt_Max.Enabled = false;
                                txt_OverallKPI.Enabled = false;
                                drp_KPISource.Enabled = false;
                                drp_KPILevel.Enabled = false;
                                drp_KPISubLevel.Enabled = false;
                                drp_IsInstitutionalClass.Enabled = false;
                                drp_MOEClassificationPillars.Enabled = false;
                                drp_MarketPositioningPillars.Enabled = false;
                                //drp_Department.Enabled = false;
                                //drp_Section.Enabled = false;
                                txt_Order.Enabled = false;
                                drp_SurveyFormReference.Enabled = false;
                                //drp_RiskManagement.Enabled = false;
                                drp_isQSWorldUniversityRanking.Enabled = false;
                                drp_Evidence.Enabled = false;
                                txt_EV.Enabled = false;

                                drp_KPIValueType.Enabled = false;
                                drp_KPIManagementPracticeType.Enabled = false;
                                drp_KPIManagementPracticeSubType.Enabled = false;
                                drp_KPIOutcome.Enabled = false;
                                drp_isDuplicate.Enabled = false;
                                txt_DuplicationSource.Enabled = false;
                            }
                            else if (t == "e")//Edit
                            {
                                btn_Create.Visible = true;
                                lbl_Header.Text = "Edit Strategic KPI";

                                txt_KPIID.Enabled = true;
                                txt_KPIDesc.Enabled = true;
                                drp_Period.Enabled = true;
                                drp_Formula.Enabled = true;
                                txt_TargetKPI.Enabled = true;
                                txt_Min.Enabled = true;
                                txt_Max.Enabled = true;
                                txt_OverallKPI.Enabled = true;
                                drp_KPISource.Enabled = true;
                                drp_KPILevel.Enabled = true;
                                drp_KPISubLevel.Enabled = true;
                                drp_IsInstitutionalClass.Enabled = true;
                                drp_MOEClassificationPillars.Enabled = true;
                                drp_MarketPositioningPillars.Enabled = true;
                                //drp_Department.Enabled = true;
                                //drp_Section.Enabled = true;
                                txt_Order.Enabled = true;
                                drp_SurveyFormReference.Enabled = true;
                                //drp_RiskManagement.Enabled = true;
                                drp_isQSWorldUniversityRanking.Enabled = true;
                                drp_Evidence.Enabled = true;
                                txt_EV.Enabled = true;

                                drp_KPIValueType.Enabled = true;
                                drp_KPIManagementPracticeType.Enabled = true;
                                drp_KPIManagementPracticeSubType.Enabled = true;
                                drp_KPIOutcome.Enabled = true;
                                drp_isDuplicate.Enabled = true;
                                txt_DuplicationSource.Enabled = true;
                            }
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New KPI";
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
            SqlCommand cmd = new SqlCommand("select iSerial,sInitiativeID+' '+sInitiativeDesc as sInitiativeDesc from CS_Strategic_Initiative", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Initiative.DataSource = dt;
                drp_Initiative.DataTextField = "sInitiativeDesc";
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

        public void fillKPIValueType()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sKPIValueType from CS_KPI_Value_Type", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_KPIValueType.DataSource = dt;
                drp_KPIValueType.DataTextField = "sKPIValueType";
                drp_KPIValueType.DataValueField = "iSerial";
                drp_KPIValueType.DataBind();
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

        public void fillKPIManagementPracticeType()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sManagementPracticeType from CS_KPI_Management_Practice_Type", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_KPIManagementPracticeType.DataSource = dt;
                drp_KPIManagementPracticeType.DataTextField = "sManagementPracticeType";
                drp_KPIManagementPracticeType.DataValueField = "iSerial";
                drp_KPIManagementPracticeType.DataBind();
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

        public void fillKPIManagementPracticeSubType()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sManagementPracticeSubType from CS_KPI_Management_Practice_Sub_Type", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_KPIManagementPracticeSubType.DataSource = dt;
                drp_KPIManagementPracticeSubType.DataTextField = "sManagementPracticeSubType";
                drp_KPIManagementPracticeSubType.DataValueField = "iSerial";
                drp_KPIManagementPracticeSubType.DataBind();
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

        public void fillKPIOutcome()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sKPIOutcome from CS_KPI_Outcome", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_KPIOutcome.DataSource = dt;
                drp_KPIOutcome.DataTextField = "sKPIOutcome";
                drp_KPIOutcome.DataValueField = "iSerial";
                drp_KPIOutcome.DataBind();
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
        public void fillFormula()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sKPIFormula from CS_KPI_Formula", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Formula.DataSource = dt;
                drp_Formula.DataTextField = "sKPIFormula";
                drp_Formula.DataValueField = "iSerial";
                drp_Formula.DataBind();
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
        public void fillKPISource()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sKPISource from CS_KPI_Source", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_KPISource.DataSource = dt;
                drp_KPISource.DataTextField = "sKPISource";
                drp_KPISource.DataValueField = "iSerial";
                drp_KPISource.DataBind();
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
        public void fillKPILevel()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sKPILevel from CS_KPI_Level", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_KPILevel.DataSource = dt;
                drp_KPILevel.DataTextField = "sKPILevel";
                drp_KPILevel.DataValueField = "iSerial";
                drp_KPILevel.DataBind();
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
        public void fillKPISubLevel()
        {
            if (!string.IsNullOrEmpty(drp_KPILevel.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sKPISubLevel from CS_KPI_Sub_Level where iKPILevel=@iKPILevel", sc);
                cmd.Parameters.AddWithValue("@iKPILevel", drp_KPILevel.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_KPISubLevel.DataSource = dt;
                    drp_KPISubLevel.DataTextField = "sKPISubLevel";
                    drp_KPISubLevel.DataValueField = "iSerial";
                    drp_KPISubLevel.DataBind();
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
        public void fillMOEClassificationPillars()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sMOEClassificationPillars from CS_MOE_Classification_Pillars", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_MOEClassificationPillars.DataSource = dt;
                drp_MOEClassificationPillars.DataTextField = "sMOEClassificationPillars";
                drp_MOEClassificationPillars.DataValueField = "iSerial";
                drp_MOEClassificationPillars.DataBind();
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
        public void fillMarketPositioningPillars()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sMarketPositioningPillars from CS_Market_Positioning_Pillars", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_MarketPositioningPillars.DataSource = dt;
                drp_MarketPositioningPillars.DataTextField = "sMarketPositioningPillars";
                drp_MarketPositioningPillars.DataValueField = "iSerial";
                drp_MarketPositioningPillars.DataBind();
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
        public void fillEvidence()
        {
            if (!string.IsNullOrEmpty(drp_StrategyVersion.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sEvidenceRecored from CS_Strategic_Evidence where iStrategyVersion=@iStrategyVersion and iDepartment=@iDepartment and iSection=@iSection", sc);
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
                    drp_Evidence.DataTextField = "sEvidenceRecored";
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
        public void bindStrategic_KPI(string sid)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Strategic_KPI where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", sid);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    txt_KPIID.Text = dt.Rows[0]["sKPIID"].ToString();
                    txt_KPIDesc.Text = dt.Rows[0]["sKPIDesc"].ToString();
                    drp_Period.SelectedIndex = drp_Period.Items.IndexOf(drp_Period.Items.FindByValue(dt.Rows[0]["iPeriod"].ToString()));
                    drp_Formula.SelectedIndex = drp_Formula.Items.IndexOf(drp_Formula.Items.FindByValue(dt.Rows[0]["iFormula"].ToString()));
                    txt_TargetKPI.Text = dt.Rows[0]["cTargetKPI"].ToString();
                    txt_Min.Text = dt.Rows[0]["cMin"].ToString();
                    txt_Max.Text = dt.Rows[0]["cMax"].ToString();
                    txt_OverallKPI.Text = dt.Rows[0]["cOverallKPI"].ToString();
                    drp_KPISource.SelectedIndex = drp_KPISource.Items.IndexOf(drp_KPISource.Items.FindByValue(dt.Rows[0]["iKPISource"].ToString()));
                    
                    drp_KPILevel.SelectedIndex = drp_KPILevel.Items.IndexOf(drp_KPILevel.Items.FindByValue(dt.Rows[0]["iKPILevel"].ToString()));
                    fillKPISubLevel();
                    drp_KPISubLevel.SelectedIndex = drp_KPISubLevel.Items.IndexOf(drp_KPISubLevel.Items.FindByValue(dt.Rows[0]["iKPISubLevel"].ToString()));

                    string IsInstitutionalClass = dt.Rows[0]["IsInstitutionalClass"].ToString();
                    int i = 0;
                    if (IsInstitutionalClass == "False")
                    {
                        i = 0;
                    }
                    else
                    {
                        i = 1;
                    }
                    drp_IsInstitutionalClass.SelectedIndex = drp_IsInstitutionalClass.Items.IndexOf(drp_IsInstitutionalClass.Items.FindByValue(i.ToString()));

                    drp_MOEClassificationPillars.SelectedIndex = drp_MOEClassificationPillars.Items.IndexOf(drp_MOEClassificationPillars.Items.FindByValue(dt.Rows[0]["iMOEClassificationPillars"].ToString()));
                    drp_MarketPositioningPillars.SelectedIndex = drp_MarketPositioningPillars.Items.IndexOf(drp_MarketPositioningPillars.Items.FindByValue(dt.Rows[0]["iMarketPositioningPillars"].ToString()));

                    drp_Department.SelectedIndex = drp_Department.Items.IndexOf(drp_Department.Items.FindByValue(dt.Rows[0]["iDepartment"].ToString()));
                    fillSection();
                    drp_Section.SelectedIndex = drp_Section.Items.IndexOf(drp_Section.Items.FindByValue(dt.Rows[0]["iSection"].ToString()));
                    fillEvidence();
                    drp_Initiative.SelectedIndex = drp_Initiative.Items.IndexOf(drp_Initiative.Items.FindByValue(dt.Rows[0]["iInitiative"].ToString()));
                    drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(dt.Rows[0]["iStrategyVersion"].ToString()));
                    txt_Order.Text = dt.Rows[0]["iOrder"].ToString();
                    drp_SurveyFormReference.SelectedIndex = drp_SurveyFormReference.Items.IndexOf(drp_SurveyFormReference.Items.FindByValue(dt.Rows[0]["iSurveyFormReference"].ToString()));
                    //drp_RiskManagement.SelectedIndex = drp_RiskManagement.Items.IndexOf(drp_RiskManagement.Items.FindByValue(dt.Rows[0]["iRiskManagement"].ToString()));
                    drp_Evidence.SelectedIndex = drp_Evidence.Items.IndexOf(drp_Evidence.Items.FindByValue(dt.Rows[0]["iEvidence"].ToString()));
                    txt_EV.Text = dt.Rows[0]["sEV"].ToString();
                    string isQSWorldUniversityRanking = dt.Rows[0]["isQSWorldUniversityRanking"].ToString();
                    int j = 0;
                    if (isQSWorldUniversityRanking == "False")
                    {
                        j = 0;
                    }
                    else
                    {
                        j = 1;
                    }
                    drp_isQSWorldUniversityRanking.SelectedIndex = drp_isQSWorldUniversityRanking.Items.IndexOf(drp_isQSWorldUniversityRanking.Items.FindByValue(j.ToString()));

                    drp_KPIValueType.SelectedIndex = drp_KPIValueType.Items.IndexOf(drp_KPIValueType.Items.FindByValue(dt.Rows[0]["iKPIValueType"].ToString()));
                    drp_KPIManagementPracticeType.SelectedIndex = drp_KPIManagementPracticeType.Items.IndexOf(drp_KPIManagementPracticeType.Items.FindByValue(dt.Rows[0]["iKPIManagementPracticeType"].ToString()));
                    drp_KPIManagementPracticeSubType.SelectedIndex = drp_KPIManagementPracticeSubType.Items.IndexOf(drp_KPIManagementPracticeSubType.Items.FindByValue(dt.Rows[0]["iKPIManagementPracticeSubType"].ToString()));
                    drp_KPIOutcome.SelectedIndex = drp_KPIOutcome.Items.IndexOf(drp_KPIOutcome.Items.FindByValue(dt.Rows[0]["iKPIOutcome"].ToString()));

                    string isDuplicate = dt.Rows[0]["isDuplicate"].ToString();
                    int k = 0;
                    if (isDuplicate == "False")
                    {
                        k = 0;
                    }
                    else
                    {
                        k = 1;
                    }
                    drp_isDuplicate.SelectedIndex = drp_isDuplicate.Items.IndexOf(drp_isDuplicate.Items.FindByValue(k.ToString()));

                    txt_DuplicationSource.Text = dt.Rows[0]["iDuplicationSource"].ToString();
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
        protected void drp_KPILevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillKPISubLevel();
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
                SqlCommand cmd = new SqlCommand("update CS_Strategic_KPI set sKPIID=@sKPIID,sKPIDesc=@sKPIDesc,iPeriod=@iPeriod,iFormula=@iFormula,cTargetKPI=@cTargetKPI,cMin=@cMin,cMax=@cMax,cOverallKPI=@cOverallKPI,iKPISource=@iKPISource,iKPILevel=@iKPILevel,iKPISubLevel=@iKPISubLevel,IsInstitutionalClass=@IsInstitutionalClass,iMOEClassificationPillars=@iMOEClassificationPillars,iMarketPositioningPillars=@iMarketPositioningPillars,iDepartment=@iDepartment,iSection=@iSection,iInitiative=@iInitiative,iOrder=@iOrder,iStrategyVersion=@iStrategyVersion,iSurveyFormReference=@iSurveyFormReference,isQSWorldUniversityRanking=@isQSWorldUniversityRanking,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy,iEvidence=@iEvidence,sEV=@sEV,iKPIValueType=@iKPIValueType,iKPIManagementPracticeType=@iKPIManagementPracticeType,iKPIManagementPracticeSubType=@iKPIManagementPracticeSubType,iKPIOutcome=@iKPIOutcome,isDuplicate=@isDuplicate,iDuplicationSource=@iDuplicationSource where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sKPIID", txt_KPIID.Text.Trim());
                cmd.Parameters.AddWithValue("@sKPIDesc", txt_KPIDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iPeriod", drp_Period.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iFormula", drp_Formula.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@cTargetKPI", txt_TargetKPI.Text.Trim());
                cmd.Parameters.AddWithValue("@cMin", txt_Min.Text.Trim());
                cmd.Parameters.AddWithValue("@cMax", txt_Max.Text.Trim());
                cmd.Parameters.AddWithValue("@cOverallKPI", txt_OverallKPI.Text.Trim());
                cmd.Parameters.AddWithValue("@iKPISource", drp_KPISource.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iKPILevel", drp_KPILevel.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iKPISubLevel", drp_KPISubLevel.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@IsInstitutionalClass", drp_IsInstitutionalClass.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iMOEClassificationPillars", drp_MOEClassificationPillars.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iMarketPositioningPillars", drp_MarketPositioningPillars.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDepartment", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSection", drp_Section.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInitiative", drp_Initiative.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                //cmd.Parameters.AddWithValue("@iRiskManagement", drp_RiskManagement.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@isQSWorldUniversityRanking", drp_isQSWorldUniversityRanking.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSurveyFormReference", drp_SurveyFormReference.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iEvidence", drp_Evidence.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@sEV", txt_EV.Text.Trim());

                cmd.Parameters.AddWithValue("@iKPIValueType", drp_KPIValueType.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iKPIManagementPracticeType", drp_KPIManagementPracticeType.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iKPIManagementPracticeSubType", drp_KPIManagementPracticeSubType.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iKPIOutcome", drp_KPIOutcome.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@isDuplicate", drp_isDuplicate.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDuplicationSource", txt_DuplicationSource.Text.Trim());

                cmd.Parameters.AddWithValue("@iSerial", sid);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic KPI Updated Successfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");

                    bindStrategic_KPI(sid);
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
                SqlCommand cmd = new SqlCommand("insert into CS_Strategic_KPI values (@sKPIID,@sKPIDesc,@iPeriod,@iFormula,@cTargetKPI,@cMin,@cMax,@cOverallKPI,@iKPISource,@iKPILevel,@iKPISubLevel,@IsInstitutionalClass,@iMOEClassificationPillars,@iMarketPositioningPillars,@iDepartment,@iSection,@iInitiative,@iOrder,@iStrategyVersion,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy,@iSurveyFormReference,@isQSWorldUniversityRanking,@iEvidence,@sEV,@iKPIValueType,@iKPIManagementPracticeType,@iKPIManagementPracticeSubType,@iKPIOutcome,@isDuplicate,@iDuplicationSource)", sc);
                cmd.Parameters.AddWithValue("@sKPIID", txt_KPIID.Text.Trim());
                cmd.Parameters.AddWithValue("@sKPIDesc", txt_KPIDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@iPeriod", drp_Period.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iFormula", drp_Formula.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@cTargetKPI", txt_TargetKPI.Text.Trim());
                cmd.Parameters.AddWithValue("@cMin", txt_Min.Text.Trim());
                cmd.Parameters.AddWithValue("@cMax", txt_Max.Text.Trim());
                cmd.Parameters.AddWithValue("@cOverallKPI", txt_OverallKPI.Text.Trim());
                cmd.Parameters.AddWithValue("@iKPISource", drp_KPISource.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iKPILevel", drp_KPILevel.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iKPISubLevel", drp_KPISubLevel.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@IsInstitutionalClass", drp_IsInstitutionalClass.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iMOEClassificationPillars", drp_MOEClassificationPillars.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iMarketPositioningPillars", drp_MarketPositioningPillars.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDepartment", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSection", drp_Section.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInitiative", drp_Initiative.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                //cmd.Parameters.AddWithValue("@iRiskManagement", drp_RiskManagement.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@isQSWorldUniversityRanking", drp_isQSWorldUniversityRanking.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSurveyFormReference", drp_SurveyFormReference.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iEvidence", drp_Evidence.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@sEV", txt_EV.Text.Trim());
                cmd.Parameters.AddWithValue("@iKPIValueType", drp_KPIValueType.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iKPIManagementPracticeType", drp_KPIManagementPracticeType.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iKPIManagementPracticeSubType", drp_KPIManagementPracticeSubType.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iKPIOutcome", drp_KPIOutcome.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@isDuplicate", drp_isDuplicate.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iDuplicationSource", txt_DuplicationSource.Text.Trim());
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic KPI Created Successfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");

                    txt_KPIID.Text = "";
                    txt_KPIDesc.Text = "";
                    txt_Min.Text = "";
                    txt_Max.Text = "";
                    txt_OverallKPI.Text = "";
                    txt_TargetKPI.Text = "";
                    txt_Order.Text = "";
                    txt_EV.Text = "";
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
            string id = Request.QueryString["id"];            
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_KPI_Home.aspx?f=m&id=" + id + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_KPI_Home.aspx?id=" + id + "");
            }
        }

        protected void drp_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSection();
            fillEvidence();
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            //string id = Request.QueryString["id"];
            //Response.Redirect("Strategy_Strategic_KPI_Home.aspx?id=" + id + "");
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_KPI_Home.aspx?f=m&id=" + id + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_KPI_Home.aspx?id=" + id + "");
            }
        }

        protected void drp_Section_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillEvidence();
        }
    }
}