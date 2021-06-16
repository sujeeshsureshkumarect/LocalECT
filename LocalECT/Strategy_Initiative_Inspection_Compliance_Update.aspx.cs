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
    public partial class Strategy_Initiative_Inspection_Compliance_Update : System.Web.UI.Page
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
                        fillStrategy_Version();
                        filliInspectionComplianceStandard();
                        filliInspectionComplianceDomain();
                        fillInspectionComplianceIndicator();
                        string id = Request.QueryString["id"];                        
                                                    
                            
                            
                        
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New Initiative Inspection Compliance";                            
                        
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

                if(dt.Rows.Count>0)
                {
                    sid = dt.Rows[0]["iStrategyVersion"].ToString();
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
            return sid;
        }
        public void fillStrategy_Version()
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

                drp_StrategyVersion.Enabled = false;
                drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(Request.QueryString["id"])));                
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
        public void filliInspectionComplianceStandard()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sInspectionComplianceStandardID from CS_Inspection_Compliance_Standard", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_iInspectionComplianceStandard.DataSource = dt;
                drp_iInspectionComplianceStandard.DataTextField = "sInspectionComplianceStandardID";
                drp_iInspectionComplianceStandard.DataValueField = "iSerial";
                drp_iInspectionComplianceStandard.DataBind();
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
        public void filliInspectionComplianceDomain()
        {
            if(!string.IsNullOrEmpty(drp_iInspectionComplianceStandard.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sInspectionComplianceDomainID from CS_Inspection_Compliance_Domain where iInspectionComplianceStandard=@iInspectionComplianceStandard", sc);
                cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", drp_iInspectionComplianceStandard.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_iInspectionComplianceDomain.DataSource = dt;
                    drp_iInspectionComplianceDomain.DataTextField = "sInspectionComplianceDomainID";
                    drp_iInspectionComplianceDomain.DataValueField = "iSerial";
                    drp_iInspectionComplianceDomain.DataBind();
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
        public void fillInspectionComplianceIndicator()
        {
            if (!string.IsNullOrEmpty(drp_iInspectionComplianceDomain.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sInspectionComplianceIndicatorID from CS_Inspection_Compliance_Indicator where iInspectionComplianceDomain=@iInspectionComplianceDomain", sc);
                cmd.Parameters.AddWithValue("@iInspectionComplianceDomain", drp_iInspectionComplianceDomain.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_InspectionComplianceIndicator.DataSource = dt;
                    drp_InspectionComplianceIndicator.DataTextField = "sInspectionComplianceIndicatorID";
                    drp_InspectionComplianceIndicator.DataValueField = "iSerial";
                    drp_InspectionComplianceIndicator.DataBind();
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
       

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            
                SqlCommand cmd = new SqlCommand("insert into CS_Initiative_Inspection_Compliance values (@iInatiative,@iInspectionComplianceStandard,@iInspectionComplianceDomain,@InspectionComplianceIndicator,@iStrategyVersion,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy)", sc);
                cmd.Parameters.AddWithValue("@iInspectionComplianceStandard", drp_iInspectionComplianceStandard.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iInspectionComplianceDomain", drp_iInspectionComplianceDomain.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@InspectionComplianceIndicator", drp_InspectionComplianceIndicator.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iInatiative", id);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Initiative Inspection Compliance Created Successfully";
                    
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

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Initiative_Inspection_Compliance_Home?id=" + Request.QueryString["id"] + "");
        }

        protected void lnk_Create_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Initiative_Inspection_Compliance_Home?id=" + Request.QueryString["id"] + "");
        }
    }
}