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
    public partial class Strategy_Inspection_Compliance_Domain_Update : System.Web.UI.Page
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
                        fillInspectionComplianceStandard();
                        filliCompliance_Indicator();
                        if (InspectionComplianceDomainID != null)
                        {
                            bindInspectionComplianceDomain(InspectionComplianceDomainID);
                            btn_Create.Text = "Update";
                            txt_Inspection_Compliance_Domain_ID.Enabled = false;
                            lbl_Header.Text = "Edit Inspection Compliance Domain";
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            txt_Inspection_Compliance_Domain_ID.Enabled = true;
                            lbl_Header.Text = "Create Inspection Compliance Domain";
                            drp_Inspection_Compliance_Standard.SelectedIndex = drp_Inspection_Compliance_Standard.Items.IndexOf(drp_Inspection_Compliance_Standard.Items.FindByValue(InspectionComplianceStandardID));
                            drp_Inspection_Compliance_Standard.Enabled = false;
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

                drp_Inspection_Compliance_Standard.DataSource = dt;
                drp_Inspection_Compliance_Standard.DataTextField = "sInspectionComplianceStandardID";
                drp_Inspection_Compliance_Standard.DataValueField = "iSerial";
                drp_Inspection_Compliance_Standard.DataBind();
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
        public void filliCompliance_Indicator()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sInspectionComplianceIndicatorID from CS_Inspection_Compliance_Indicator", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Inspection_Compliance_Indicator.DataSource = dt;
                drp_Inspection_Compliance_Indicator.DataTextField = "sInspectionComplianceIndicatorID";
                drp_Inspection_Compliance_Indicator.DataValueField = "iSerial";
                drp_Inspection_Compliance_Indicator.DataBind();
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
        public void bindInspectionComplianceDomain(string did)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Inspection_Compliance_Domain where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", did);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    txt_Inspection_Compliance_Domain_ID.Text = dt.Rows[0]["sInspectionComplianceDomainID"].ToString();
                    txt_Inspection_Compliance_Domain_Desc.Text = dt.Rows[0]["sInspectionComplianceDomainDesc"].ToString();
                    txt_Inspection_Compliance_Domain_Order.Text = dt.Rows[0]["iOrder"].ToString();
                    drp_Inspection_Compliance_Standard.SelectedIndex = drp_Inspection_Compliance_Standard.Items.IndexOf(drp_Inspection_Compliance_Standard.Items.FindByValue(dt.Rows[0]["iInspectionComplianceStandard"].ToString()));
                    drp_Inspection_Compliance_Indicator.SelectedIndex = drp_Inspection_Compliance_Indicator.Items.IndexOf(drp_Inspection_Compliance_Indicator.Items.FindByValue(dt.Rows[0]["iCompliance_Indicator"].ToString()));
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
            string InspectionComplianceDomainID = Request.QueryString["did"];//InspectionComplianceDomainID
            if (InspectionComplianceDomainID != null)
            {
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Inspection_Compliance_Domain set sInspectionComplianceDomainID=@sInspectionComplianceDomainID,sInspectionComplianceDomainDesc=@sInspectionComplianceDomainDesc,iInspectionComplianceStandard=@iInspectionComplianceStandard,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy,iOrder=@iOrder,iCompliance_Indicator=@iCompliance_Indicator where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sInspectionComplianceDomainID", txt_Inspection_Compliance_Domain_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sInspectionComplianceDomainDesc", txt_Inspection_Compliance_Domain_Desc.Text.Trim());
                cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", drp_Inspection_Compliance_Standard.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iCompliance_Indicator", drp_Inspection_Compliance_Indicator.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iOrder", txt_Inspection_Compliance_Domain_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iSerial", InspectionComplianceDomainID);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Inspection Compliance Domain Updated Successfully";

                    bindInspectionComplianceDomain(InspectionComplianceDomainID);
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
                SqlCommand cmd = new SqlCommand("insert into CS_Inspection_Compliance_Domain values (@sInspectionComplianceDomainID,@sInspectionComplianceDomainDesc,@iInspectionComplianceStandard,@iOrder,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy,@iCompliance_Indicator)", sc);
                cmd.Parameters.AddWithValue("@sInspectionComplianceDomainID", txt_Inspection_Compliance_Domain_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sInspectionComplianceDomainDesc", txt_Inspection_Compliance_Domain_Desc.Text.Trim());
                cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", drp_Inspection_Compliance_Standard.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iCompliance_Indicator", drp_Inspection_Compliance_Indicator.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iOrder", txt_Inspection_Compliance_Domain_Order.Text.Trim());
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Inspection Compliance Domain Created Successfully";

                    txt_Inspection_Compliance_Domain_ID.Text = "";
                    txt_Inspection_Compliance_Domain_Desc.Text = "";
                    txt_Inspection_Compliance_Domain_Order.Text = "";
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
            Response.Redirect("Strategy_Inspection_Compliance_Domain_Home?sid=" + Request.QueryString["sid"] + "");
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Inspection_Compliance_Domain_Home?sid=" + Request.QueryString["sid"] + "");
        }
    }
}