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
    public partial class Strategy_Inspection_Compliance_Indicator_Update : System.Web.UI.Page
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
                        //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.LinkManager,
                        //InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                        //{
                        //    Server.Transfer("Authorization.aspx");
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
                        string InspectionComplianceStandardID = Request.QueryString["sid"];//InspectionComplianceStandardID
                        string InspectionComplianceDomainID = Request.QueryString["did"];//InspectionComplianceDomainID
                        string InspectionComplianceIndicatorID = Request.QueryString["iid"];//InspectionComplianceIndicatorID
                        fillInspectionComplianceStandard();
                        if (InspectionComplianceIndicatorID != null)
                        {
                            bindInspectionComplianceIndicator(InspectionComplianceIndicatorID);
                            btn_Create.Text = "Update";
                            txt_Inspection_Compliance_Indicator_ID.Enabled = false;
                            lbl_Header.Text = "Edit Inspection Compliance Indicator";
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            txt_Inspection_Compliance_Indicator_ID.Enabled = true;
                            lbl_Header.Text = "Create New Inspection Compliance Indicator";
                            drp_InspectionComplianceStandard.SelectedIndex = drp_InspectionComplianceStandard.Items.IndexOf(drp_InspectionComplianceStandard.Items.FindByValue(InspectionComplianceStandardID));
                            fillInspectionComplianceDomain();
                            drp_InspectionComplianceDomain.SelectedIndex = drp_InspectionComplianceDomain.Items.IndexOf(drp_InspectionComplianceDomain.Items.FindByValue(InspectionComplianceDomainID));
                            drp_InspectionComplianceStandard.Enabled = false;
                            drp_InspectionComplianceDomain.Enabled = false;
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
        public void bindInspectionComplianceIndicator(string iid)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Inspection_Compliance_Indicator where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", iid);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    txt_Inspection_Compliance_Indicator_ID.Text = dt.Rows[0]["sInspectionComplianceIndicatorID"].ToString();
                    txt_Inspection_Compliance_Indicator_Desc.Text = dt.Rows[0]["sInspectionComplianceIndicatorDesc"].ToString();
                    txt_Inspection_Compliance_Indicator_Order.Text = dt.Rows[0]["iOrder"].ToString();
                    drp_InspectionComplianceStandard.SelectedIndex = drp_InspectionComplianceStandard.Items.IndexOf(drp_InspectionComplianceStandard.Items.FindByValue(dt.Rows[0]["iInspectionComplianceStandard"].ToString()));
                    fillInspectionComplianceDomain();
                    drp_InspectionComplianceDomain.SelectedIndex = drp_InspectionComplianceDomain.Items.IndexOf(drp_InspectionComplianceDomain.Items.FindByValue(dt.Rows[0]["iInspectionComplianceDomain"].ToString()));
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
            string InspectionComplianceIndicatorID = Request.QueryString["iid"];//InspectionComplianceIndicatorID
            if (InspectionComplianceIndicatorID != null)
            {
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Inspection_Compliance_Indicator set sInspectionComplianceIndicatorID=@sInspectionComplianceIndicatorID,sInspectionComplianceIndicatorDesc=@sInspectionComplianceIndicatorDesc,iInspectionComplianceStandard=@iInspectionComplianceStandard,iInspectionComplianceDomain=@iInspectionComplianceDomain,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy,iOrder=@iOrder where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sInspectionComplianceIndicatorID", txt_Inspection_Compliance_Indicator_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sInspectionComplianceIndicatorDesc", txt_Inspection_Compliance_Indicator_Desc.Text.Trim());
                cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", drp_InspectionComplianceStandard.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInspectionComplianceDomain", drp_InspectionComplianceDomain.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iOrder", txt_Inspection_Compliance_Indicator_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iSerial", InspectionComplianceIndicatorID);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Inspection Compliance Indicator Updated Successfully";

                    bindInspectionComplianceIndicator(InspectionComplianceIndicatorID);
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
                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Inspection_Compliance_Indicator values (@sInspectionComplianceIndicatorID,@sInspectionComplianceIndicatorDesc,@iInspectionComplianceStandard,@iInspectionComplianceDomain,@iOrder,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy)", sc);
                cmd.Parameters.AddWithValue("@sInspectionComplianceIndicatorID", txt_Inspection_Compliance_Indicator_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sInspectionComplianceIndicatorDesc", txt_Inspection_Compliance_Indicator_Desc.Text.Trim());
                cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", drp_InspectionComplianceStandard.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInspectionComplianceDomain", drp_InspectionComplianceDomain.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Inspection_Compliance_Indicator_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());                
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Inspection Compliance Indicator Created Successfully";

                    txt_Inspection_Compliance_Indicator_ID.Text = "";
                    txt_Inspection_Compliance_Indicator_Desc.Text = "";
                    txt_Inspection_Compliance_Indicator_Order.Text = "";
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
            Response.Redirect("Strategy_Inspection_Compliance_Indicator_Home?sid=" + Request.QueryString["sid"] + "&did=" + Request.QueryString["did"] + "");
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Inspection_Compliance_Indicator_Home?sid=" + Request.QueryString["sid"] + "&did=" + Request.QueryString["did"] + "");
        }

        protected void drp_InspectionComplianceStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillInspectionComplianceDomain();
        }
    }
}