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
    public partial class Strategy_Strategic_Evidence_Update : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Evidence,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        {
                            //Server.Transfer("Authorization.aspx");
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
                        fillEvidenceType();
                        fillStrategyVersion();

                        fillDepartment();
                        fillSection();

                        fillCustomerExperienceEvidenceCategory();
                        fillCustomerExperienceEvidenceSubCategory();

                        string id = Request.QueryString["id"];
                        string t = Request.QueryString["t"];
                        if (id != null)
                        {
                            bindStrategic_Evidence(id);
                            btn_Create.Text = "Update";
                            lbl_Header.Text = "Edit Strategic Evidence";
                            if (t == "v")//View
                            {
                                btn_Create.Visible = false;
                                lbl_Header.Text = "View Strategic Evidence";

                                drp_EvidenceType.Enabled = false;
                                txt_EvidenceTitle.Enabled = false;
                                txt_EvidenceSerial.Enabled = false;
                                drp_Department.Enabled = false;
                                drp_Section.Enabled = false;
                                txt_EvidenceRecored.Enabled = false;
                                drp_isIRQASurveyReportRequired.Enabled = false;
                                drp_CustomerExperienceEvidenceCategory.Enabled = false;
                                drp_CustomerExperienceEvidenceSubCategory.Enabled = false;                                                              
                                txt_Order.Enabled = false;
                                txt_Abbreviation.Enabled = false;
                            }
                            else if (t == "e")//Edit
                            {
                                btn_Create.Visible = true;
                                lbl_Header.Text = "Edit Strategic Evidence";

                                drp_EvidenceType.Enabled = true;
                                txt_EvidenceTitle.Enabled = true;
                                txt_EvidenceSerial.Enabled = true;
                                drp_Department.Enabled = true;
                                drp_Section.Enabled = true;
                                txt_EvidenceRecored.Enabled = true;
                                drp_isIRQASurveyReportRequired.Enabled = true;
                                drp_CustomerExperienceEvidenceCategory.Enabled = true;
                                drp_CustomerExperienceEvidenceSubCategory.Enabled = true;
                                txt_Order.Enabled = true;
                                txt_Abbreviation.Enabled = true;
                            }
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New Strategic Evidence";
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
        public void fillEvidenceType()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sEvidenceType from CS_Evidence_Type", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_EvidenceType.DataSource = dt;
                drp_EvidenceType.DataTextField = "sEvidenceType";
                drp_EvidenceType.DataValueField = "iSerial";
                drp_EvidenceType.DataBind();
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
            SqlCommand cmd = new SqlCommand("select iSerial,sStrategyVersion from CS_Strategy_Version where isActive = 1", sc);
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
        public void fillDepartment()
        {
            SqlCommand cmd = new SqlCommand("select DepartmentID,DescEN from Lkp_Department where (Lkp_Department.IsActive = 1) and (Lkp_Department.DepartmentID<>-1)", sc);
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
                SqlCommand cmd = new SqlCommand("select SectionID,DescEN from Lkp_Section where DepartmentID=@DepartmentID", sc);
                cmd.Parameters.AddWithValue("@DepartmentID", drp_Department.SelectedItem.Value);
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

        public void fillCustomerExperienceEvidenceCategory()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sCustomerExperienceEvidenceCategory from CS_Customer_Experience_Evidence_Category", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_CustomerExperienceEvidenceCategory.DataSource = dt;
                drp_CustomerExperienceEvidenceCategory.DataTextField = "sCustomerExperienceEvidenceCategory";
                drp_CustomerExperienceEvidenceCategory.DataValueField = "iSerial";
                drp_CustomerExperienceEvidenceCategory.DataBind();
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
        public void fillCustomerExperienceEvidenceSubCategory()
        {
            if (!string.IsNullOrEmpty(drp_CustomerExperienceEvidenceCategory.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sCustomerExperienceEvidenceSubCategory from CS_Customer_Experience_Evidence_Sub_Category where iCustomerExperienceEvidenceCategory=@iCustomerExperienceEvidenceCategory", sc);
                cmd.Parameters.AddWithValue("@iCustomerExperienceEvidenceCategory", drp_CustomerExperienceEvidenceCategory.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_CustomerExperienceEvidenceSubCategory.DataSource = dt;
                    drp_CustomerExperienceEvidenceSubCategory.DataTextField = "sCustomerExperienceEvidenceSubCategory";
                    drp_CustomerExperienceEvidenceSubCategory.DataValueField = "iSerial";
                    drp_CustomerExperienceEvidenceSubCategory.DataBind();
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
        public void bindStrategic_Evidence(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Strategic_Evidence where iSerial=@iSerial", sc);
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
                    drp_EvidenceType.SelectedIndex = drp_EvidenceType.Items.IndexOf(drp_EvidenceType.Items.FindByValue(dt.Rows[0]["iEvidenceType"].ToString()));
                    txt_EvidenceTitle.Text = dt.Rows[0]["sEvidenceTitle"].ToString();
                    txt_EvidenceSerial.Text = dt.Rows[0]["sEvidenceSerial"].ToString();
                    drp_Department.SelectedIndex = drp_Department.Items.IndexOf(drp_Department.Items.FindByValue(dt.Rows[0]["iDepartment"].ToString()));
                    fillSection();
                    drp_Section.SelectedIndex = drp_Section.Items.IndexOf(drp_Section.Items.FindByValue(dt.Rows[0]["iSection"].ToString()));
                    txt_EvidenceRecored.Text = dt.Rows[0]["sEvidenceRecored"].ToString();

                    string isIRQASurveyReportRequired = dt.Rows[0]["isIRQASurveyReportRequired"].ToString();
                    int i = 0;
                    if (isIRQASurveyReportRequired == "False")
                    {
                        i = 0;
                    }
                    else
                    {
                        i = 1;
                    }
                    drp_isIRQASurveyReportRequired.SelectedIndex = drp_isIRQASurveyReportRequired.Items.IndexOf(drp_isIRQASurveyReportRequired.Items.FindByValue(i.ToString()));

                    drp_CustomerExperienceEvidenceCategory.SelectedIndex = drp_CustomerExperienceEvidenceCategory.Items.IndexOf(drp_CustomerExperienceEvidenceCategory.Items.FindByValue(dt.Rows[0]["iCustomerExperienceEvidenceCategory"].ToString()));
                    fillCustomerExperienceEvidenceSubCategory();
                    drp_CustomerExperienceEvidenceSubCategory.SelectedIndex = drp_CustomerExperienceEvidenceSubCategory.Items.IndexOf(drp_CustomerExperienceEvidenceSubCategory.Items.FindByValue(dt.Rows[0]["iCustomerExperienceEvidenceSubCategory"].ToString()));

                    txt_Order.Text = dt.Rows[0]["iOrder"].ToString();
                    drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(dt.Rows[0]["iStrategyVersion"].ToString()));

                    txt_Abbreviation.Text = dt.Rows[0]["sAbbreviation"].ToString();
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
        protected void btn_Create_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (id != null)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Evidence,
                              InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Edit";
                    return;
                }
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Strategic_Evidence set iEvidenceType=@iEvidenceType,sEvidenceTitle=@sEvidenceTitle,sEvidenceSerial=@sEvidenceSerial,iDepartment=@iDepartment,iSection=@iSection,sEvidenceRecored=@sEvidenceRecored,isIRQASurveyReportRequired=@isIRQASurveyReportRequired,iCustomerExperienceEvidenceCategory=@iCustomerExperienceEvidenceCategory,iCustomerExperienceEvidenceSubCategory=@iCustomerExperienceEvidenceSubCategory,iOrder=@iOrder,iStrategyVersion=@iStrategyVersion,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy,sAbbreviation=@sAbbreviation where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@iEvidenceType", drp_EvidenceType.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@sEvidenceTitle", txt_EvidenceTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@sEvidenceSerial", txt_EvidenceSerial.Text.Trim());
                cmd.Parameters.AddWithValue("@iDepartment", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSection", drp_Section.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@sEvidenceRecored", txt_EvidenceRecored.Text.Trim());
                cmd.Parameters.AddWithValue("@isIRQASurveyReportRequired", drp_isIRQASurveyReportRequired.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iCustomerExperienceEvidenceCategory", drp_CustomerExperienceEvidenceCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iCustomerExperienceEvidenceSubCategory", drp_CustomerExperienceEvidenceSubCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@sAbbreviation", txt_Abbreviation.Text.Trim());
                cmd.Parameters.AddWithValue("@iSerial", id);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic Evidence Updated Successfully";

                    bindStrategic_Evidence(id);
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
            else
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Evidence,
                             InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Add";
                    return;
                }
                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Strategic_Evidence values (@iEvidenceType,@sEvidenceTitle,@sEvidenceSerial,@iDepartment,@iSection,@sEvidenceRecored,@isIRQASurveyReportRequired,@iCustomerExperienceEvidenceCategory,@iCustomerExperienceEvidenceSubCategory,@iOrder,@iStrategyVersion,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy,@sAbbreviation)", sc);
                cmd.Parameters.AddWithValue("@iEvidenceType", drp_EvidenceType.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@sEvidenceTitle", txt_EvidenceTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@sEvidenceSerial", txt_EvidenceSerial.Text.Trim());
                cmd.Parameters.AddWithValue("@iDepartment", drp_Department.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSection", drp_Section.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@sEvidenceRecored", txt_EvidenceRecored.Text.Trim());
                cmd.Parameters.AddWithValue("@isIRQASurveyReportRequired", drp_isIRQASurveyReportRequired.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iCustomerExperienceEvidenceCategory", drp_CustomerExperienceEvidenceCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iCustomerExperienceEvidenceSubCategory", drp_CustomerExperienceEvidenceSubCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@sAbbreviation", txt_Abbreviation.Text.Trim());
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic Evidence Created Successfully";

                    txt_EvidenceTitle.Text = "";
                    txt_EvidenceSerial.Text = "";
                    txt_EvidenceRecored.Text = "";
                    txt_Order.Text = "";
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

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Strategic_Evidence_Home");
        }

        protected void drp_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSection();
        }

        protected void drp_CustomerExperienceEvidenceCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillCustomerExperienceEvidenceSubCategory();
        }
    }
}