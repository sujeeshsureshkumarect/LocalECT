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
    public partial class Strategy_Inspection_Compliance_Guidelines_Update : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Compliance_Standard,
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
                        string InspectionComplianceStandardID = Request.QueryString["sid"];//InspectionComplianceStandardID
                        string InspectionComplianceDomainID = Request.QueryString["did"];//InspectionComplianceDomainID
                        //string InspectionComplianceIndicatorID = Request.QueryString["iid"];//InspectionComplianceIndicatorID
                        string InspectionComplianceGuidelinesID = Request.QueryString["gid"];//InspectionComplianceIndicatorID
                        fillInspectionComplianceStandard();
                        fillInspectionComplianceDomain();
                        if (InspectionComplianceGuidelinesID != null)
                        {
                            bindInspection_Compliance_Guidelines(InspectionComplianceGuidelinesID);
                            btn_Create.Text = "Update";
                            txt_InspectionComplianceGuidelines_ID.Enabled = false;
                            lbl_Header.Text = "Edit Inspection Compliance Guideline";
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            txt_InspectionComplianceGuidelines_ID.Enabled = true;
                            lbl_Header.Text = "Create New Inspection Compliance Guideline";
                            drp_InspectionComplianceStandard.SelectedIndex = drp_InspectionComplianceStandard.Items.IndexOf(drp_InspectionComplianceStandard.Items.FindByValue(InspectionComplianceStandardID));
                            fillInspectionComplianceDomain();
                            drp_InspectionComplianceDomain.SelectedIndex = drp_InspectionComplianceDomain.Items.IndexOf(drp_InspectionComplianceDomain.Items.FindByValue(InspectionComplianceDomainID));
                            //fillInspectionComplianceIndicator();
                            //drp_InspectionComplianceIndicator.SelectedIndex = drp_InspectionComplianceIndicator.Items.IndexOf(drp_InspectionComplianceIndicator.Items.FindByValue(InspectionComplianceIndicatorID));
                            drp_InspectionComplianceStandard.Enabled = false;
                            drp_InspectionComplianceDomain.Enabled = false;
                            //drp_InspectionComplianceIndicator.Enabled = false;
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
        public void fillInspectionComplianceStandard()
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

                fillInspectionComplianceDomain();
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

                fillInspectionComplianceIndicator();
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

        public void fillInspectionComplianceIndicator()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sInspectionComplianceIndicatorID from CS_Inspection_Compliance_Indicator where iInspectionComplianceStandard=@iInspectionComplianceStandard and iInspectionComplianceDomain=@iInspectionComplianceDomain", sc);
            cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", drp_InspectionComplianceStandard.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@iInspectionComplianceDomain", drp_InspectionComplianceDomain.SelectedItem.Value);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                //drp_InspectionComplianceIndicator.DataSource = dt;
                //drp_InspectionComplianceIndicator.DataTextField = "sInspectionComplianceIndicatorID";
                //drp_InspectionComplianceIndicator.DataValueField = "iSerial";
                //drp_InspectionComplianceIndicator.DataBind();
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
        public void bindInspection_Compliance_Guidelines(string InspectionComplianceGuidelinesID)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Inspection_Compliance_Guidelines where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", InspectionComplianceGuidelinesID);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    txt_InspectionComplianceGuidelines_ID.Text = dt.Rows[0]["sInspectionComplianceGuidelinesID"].ToString();
                    txt_InspectionComplianceGuidelines_Desc.Text = dt.Rows[0]["sInspectionComplianceGuidelinesDesc"].ToString();
                    txt_InspectionComplianceGuidelines_Order.Text = dt.Rows[0]["iOrder"].ToString();
                    drp_InspectionComplianceStandard.SelectedIndex = drp_InspectionComplianceStandard.Items.IndexOf(drp_InspectionComplianceStandard.Items.FindByValue(dt.Rows[0]["iInspectionComplianceStandard"].ToString()));
                    fillInspectionComplianceDomain();
                    drp_InspectionComplianceDomain.SelectedIndex = drp_InspectionComplianceDomain.Items.IndexOf(drp_InspectionComplianceDomain.Items.FindByValue(dt.Rows[0]["iInspectionComplianceDomain"].ToString()));
                    //fillInspectionComplianceIndicator();
                    //drp_InspectionComplianceIndicator.SelectedIndex = drp_InspectionComplianceIndicator.Items.IndexOf(drp_InspectionComplianceIndicator.Items.FindByValue(dt.Rows[0]["iInspectionComplianceIndicator"].ToString()));
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
            string InspectionComplianceGuidelinesID = Request.QueryString["gid"];//GuidelineID
            if (InspectionComplianceGuidelinesID != null)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Compliance_Standard,
                                 InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Edit";
                    return;
                }
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Inspection_Compliance_Guidelines set sInspectionComplianceGuidelinesID=@sInspectionComplianceGuidelinesID,sInspectionComplianceGuidelinesDesc=@sInspectionComplianceGuidelinesDesc,iInspectionComplianceStandard=@iInspectionComplianceStandard,iInspectionComplianceDomain=@iInspectionComplianceDomain,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy,iOrder=@iOrder where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sInspectionComplianceGuidelinesID", txt_InspectionComplianceGuidelines_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sInspectionComplianceGuidelinesDesc", txt_InspectionComplianceGuidelines_Desc.Text.Trim());
                cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", drp_InspectionComplianceStandard.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInspectionComplianceDomain", drp_InspectionComplianceDomain.SelectedItem.Value);
                //cmd.Parameters.AddWithValue("@iInspectionComplianceIndicator", drp_InspectionComplianceIndicator.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iOrder", txt_InspectionComplianceGuidelines_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iSerial", InspectionComplianceGuidelinesID);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Inspection Compliance Guidelines Updated Successfully";

                    bindInspection_Compliance_Guidelines(InspectionComplianceGuidelinesID);
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Compliance_Standard,
                                 InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Add";
                    return;
                }
                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Inspection_Compliance_Guidelines values (@sInspectionComplianceGuidelinesID,@sInspectionComplianceGuidelinesDesc,@iInspectionComplianceStandard,@iInspectionComplianceDomain,@iOrder,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy)", sc);
                cmd.Parameters.AddWithValue("@sInspectionComplianceGuidelinesID", txt_InspectionComplianceGuidelines_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sInspectionComplianceGuidelinesDesc", txt_InspectionComplianceGuidelines_Desc.Text.Trim());
                cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", drp_InspectionComplianceStandard.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInspectionComplianceDomain", drp_InspectionComplianceDomain.SelectedItem.Value);
                //cmd.Parameters.AddWithValue("@iInspectionComplianceIndicator", drp_InspectionComplianceIndicator.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iOrder", txt_InspectionComplianceGuidelines_Order.Text.Trim());
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Inspection Compliance Guidelines Created Successfully";

                    txt_InspectionComplianceGuidelines_ID.Text = "";
                    txt_InspectionComplianceGuidelines_Desc.Text = "";
                    txt_InspectionComplianceGuidelines_Order.Text = "";
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
            Response.Redirect("Strategy_Inspection_Compliance_Guidelines_Home?sid=" + Request.QueryString["sid"] + "&did=" + Request.QueryString["did"] + "");
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Inspection_Compliance_Guidelines_Home?sid=" + Request.QueryString["sid"] + "&did=" + Request.QueryString["did"] + "");
        }

        protected void drp_InspectionComplianceStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillInspectionComplianceStandard();
        }

        protected void drp_InspectionComplianceDomain_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillInspectionComplianceDomain();
        }
    }
}