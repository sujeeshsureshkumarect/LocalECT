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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Compliance_Domain_Type,
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
                        
                        string InspectionComplianceIndicatorID = Request.QueryString["iid"];//InspectionComplianceIndicatorID                        
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Compliance_Domain_Type,
                                 InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Edit";
                    return;
                }
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Inspection_Compliance_Indicator set sInspectionComplianceIndicatorID=@sInspectionComplianceIndicatorID,sInspectionComplianceIndicatorDesc=@sInspectionComplianceIndicatorDesc,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy,iOrder=@iOrder where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sInspectionComplianceIndicatorID", txt_Inspection_Compliance_Indicator_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sInspectionComplianceIndicatorDesc", txt_Inspection_Compliance_Indicator_Desc.Text.Trim());                
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Compliance_Domain_Type,
                                   InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Add";
                    return;
                }
                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Inspection_Compliance_Indicator values (@sInspectionComplianceIndicatorID,@sInspectionComplianceIndicatorDesc,@iOrder,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy)", sc);
                cmd.Parameters.AddWithValue("@sInspectionComplianceIndicatorID", txt_Inspection_Compliance_Indicator_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sInspectionComplianceIndicatorDesc", txt_Inspection_Compliance_Indicator_Desc.Text.Trim());                
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
            Response.Redirect("Strategy_Inspection_Compliance_Indicator_Home");
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Inspection_Compliance_Indicator_Home");
        }       
    }
}