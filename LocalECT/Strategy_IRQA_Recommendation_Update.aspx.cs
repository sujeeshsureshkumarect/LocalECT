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
    public partial class Strategy_IRQA_Recommendation_Update : System.Web.UI.Page
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
                        fillStrategyVersion();
                        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                        {
                            drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(getStrategy_Version(Request.QueryString["id"])));
                        }
                        fillStrategic_Period();
                        fillStrategic_Sub_Period();

                        if (!string.IsNullOrEmpty(Request.QueryString["sid"]))
                        {
                            fillKPI(Request.QueryString["sid"]);
                        }                            

                        string id = Request.QueryString["id"];

                        btn_Create.Text = "Create";
                        lbl_Header.Text = "Create New IRQA Recommendation";

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
        public void fillStrategic_Sub_Period()
        {
            if (!string.IsNullOrEmpty(drp_Period.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select iSerial,sSubPeriod from CS_Strategic_Sub_Period where iPeriod=@iPeriod", sc);
                cmd.Parameters.AddWithValue("@iPeriod", drp_Period.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_SubPeriod.DataSource = dt;
                    drp_SubPeriod.DataTextField = "sSubPeriod";
                    drp_SubPeriod.DataValueField = "iSerial";
                    drp_SubPeriod.DataBind();
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
        public void fillKPI(string sid)
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sKPIID from CS_Strategic_KPI where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", sid);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_KPI.DataSource = dt;
                drp_KPI.DataTextField = "sKPIID";
                drp_KPI.DataValueField = "iSerial";
                drp_KPI.DataBind();
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
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Initiative,
                             InitializeModule.enumPrivilege.CS_Manage_IRQA_Recommendation, CurrentRole) != true)
            {
                div_msg.Visible = true;
                div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                lbl_Msg.Text = "Sorry-You cannot Add";
                return;
            }
            string id = Request.QueryString["id"];//InitiativeID
            string sid = Request.QueryString["sid"];//KPIID

            SqlCommand cmd = new SqlCommand("insert into CS_IRQA_Recommendation values (@sIRQARecommendation,@iPeriod,@iSubPeriod,@iStrategyVersion,@iKPI,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy)", sc);
            cmd.Parameters.AddWithValue("@sIRQARecommendation", txt_IRQARecommendation.Text.Trim());
            cmd.Parameters.AddWithValue("@iPeriod", drp_Period.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@iSubPeriod", drp_SubPeriod.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@iKPI", drp_KPI.SelectedItem.Value);
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
                lbl_Msg.Text = "IRQA Recommendation Created Successfully";

                txt_IRQARecommendation.Text = "";

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
            Response.Redirect("Strategy_IRQA_Recommendation_Home?id=" + Request.QueryString["id"] + "&sid=" + Request.QueryString["sid"] + "");
        }

        protected void lnk_Create_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_IRQA_Recommendation_Home?id=" + Request.QueryString["id"] + "&sid=" + Request.QueryString["sid"] + "");
        }
    }
}