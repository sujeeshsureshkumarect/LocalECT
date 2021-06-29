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
    public partial class CS_Risk_Management_Edit : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Risk_Management,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        {
                            Server.Transfer("Authorization.aspx");
                        }
                    }
                }
                else
                {
                    //showErr("Session is expired, Login again please...");
                    Session.RemoveAll();
                    Response.Redirect("Login.aspx");

                }
                if (Session["CurrentUserName"] != null)
                {
                    if (!IsPostBack)
                    {
                        fillInitiative();
                        drp_Initiative.SelectedIndex = drp_Initiative.Items.IndexOf(drp_Initiative.Items.FindByValue(Request.QueryString["id"]));
                        fillRisk_Management_Framework();
                        fillRisk_Management_Registry_Framework();
                        fillStipulationGuidelines();
                        string rid = Request.QueryString["rid"];
                        if (rid != null)
                        {
                            bindInitiative_Risk(rid);
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
        public void fillRisk_Management_Framework()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sFramework from CS_Risk_Management_Framework", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Framework.DataSource = dt;
                drp_Framework.DataTextField = "sFramework";
                drp_Framework.DataValueField = "iSerial";
                drp_Framework.DataBind();
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
        public void fillRisk_Management_Registry_Framework()
        {
            if (!string.IsNullOrEmpty(drp_Framework.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sRegistryFramework from CS_Risk_Management_Registry_Framework where iFramework=@iFramework", sc);
                cmd.Parameters.AddWithValue("@iFramework", drp_Framework.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_RegisatryFramework.DataSource = dt;
                    drp_RegisatryFramework.DataTextField = "sRegistryFramework";
                    drp_RegisatryFramework.DataValueField = "iSerial";
                    drp_RegisatryFramework.DataBind();
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
        public void fillStipulationGuidelines()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sGuidelinesID from CS_Stipulation_Guidelines", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_StipulationGuidelines.DataSource = dt;
                drp_StipulationGuidelines.DataTextField = "sGuidelinesID";
                drp_StipulationGuidelines.DataValueField = "iSerial";
                drp_StipulationGuidelines.DataBind();
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
        public void bindInitiative_Risk(string rid)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Initiative_Risk where iSerial=@iLink", sc);
            cmd.Parameters.AddWithValue("@iLink", rid);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    drp_Initiative.SelectedIndex = drp_Initiative.Items.IndexOf(drp_Initiative.Items.FindByValue(dt.Rows[0]["iInitiative"].ToString()));
                    drp_Framework.SelectedIndex = drp_Framework.Items.IndexOf(drp_Framework.Items.FindByValue(dt.Rows[0]["iFramework"].ToString()));
                    fillRisk_Management_Registry_Framework();
                    drp_RegisatryFramework.SelectedIndex = drp_RegisatryFramework.Items.IndexOf(drp_RegisatryFramework.Items.FindByValue(dt.Rows[0]["iRegisatryFramework"].ToString()));
                    txt_StatementSerialNo.Text = dt.Rows[0]["sStatementSerialNo"].ToString();
                    txt_Statement.Text = dt.Rows[0]["sStatement"].ToString();
                    drp_StipulationGuidelines.SelectedIndex = drp_StipulationGuidelines.Items.IndexOf(drp_StipulationGuidelines.Items.FindByValue(dt.Rows[0]["iReLicensureGuideline"].ToString()));
                }
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

        private void showErr(string sMsg)
        {
            Session["errMsg"] = sMsg;
            Response.Redirect("ErrPage.aspx");
        }

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Risk_Management,
                              InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
            {
                div_msg.Visible = true;
                div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                lbl_Msg.Text = "Sorry-You cannot Edit";
                return;
            }

            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("update CS_Initiative_Risk set iInitiative=@iInitiative,iFramework=@iFramework,iRegisatryFramework=@iRegisatryFramework,sStatementSerialNo=@sStatementSerialNo,sStatement=@sStatement,iReLicensureGuideline=@iReLicensureGuideline,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy where iSerial=@iSerial", sc);

            cmd.Parameters.AddWithValue("@iInitiative", drp_Initiative.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@iFramework", drp_Framework.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@iRegisatryFramework", drp_RegisatryFramework.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@sStatementSerialNo", txt_StatementSerialNo.Text.Trim());
            cmd.Parameters.AddWithValue("@sStatement", txt_Statement.Text.Trim());
            cmd.Parameters.AddWithValue("@iReLicensureGuideline", drp_StipulationGuidelines.SelectedItem.Value);

            cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
            cmd.Parameters.AddWithValue("@sUpdatedby", Session["CurrentUserName"].ToString());

            cmd.Parameters.AddWithValue("@iSerial", Request.QueryString["rid"]);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                div_msg.Visible = true;
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

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            Response.Redirect("Strategy_Risk_Management?id=" + id + "");
        }
        protected void drp_Framework_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillRisk_Management_Registry_Framework();
        }
        protected void lnk_Create_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            Response.Redirect("Strategy_Risk_Management?id=" + id + "");
        }
    }
}
