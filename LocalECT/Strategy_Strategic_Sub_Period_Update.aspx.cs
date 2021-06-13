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
    public partial class Strategy_Strategic_Sub_Period_Update : System.Web.UI.Page
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
                        string Strategic_PeriodID = Request.QueryString["id"];//Strategic_PeriodID
                        string Strategic_Sub_PeriodID = Request.QueryString["sid"];//Strategic_Sub_PeriodID
                        string sver = Request.QueryString["sver"];//Strategic_Sub_PeriodID
                        fillStrategy_Version();
                        fillStrategic_Period();
                        if (Strategic_Sub_PeriodID != null)
                        {
                            bindStrategic_Sub_Period(Strategic_Sub_PeriodID);
                            btn_Create.Text = "Update";
                            lbl_Header.Text = "Edit Strategic Sub Period";
                            drp_Strategic_Period.Enabled = false;
                            drp_StrategyVersion.Enabled = false;
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New Strategic Sub Period";
                            drp_Strategic_Period.SelectedIndex = drp_Strategic_Period.Items.IndexOf(drp_Strategic_Period.Items.FindByValue(Strategic_PeriodID));
                            drp_Strategic_Period.Enabled = false;
                            drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(sver));
                            drp_StrategyVersion.Enabled = false;
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
        public void fillStrategic_Period()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sPeriod from CS_Strategic_Period", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Strategic_Period.DataSource = dt;
                drp_Strategic_Period.DataTextField = "sPeriod";
                drp_Strategic_Period.DataValueField = "iSerial";
                drp_Strategic_Period.DataBind();
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
        public void bindStrategic_Sub_Period(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Strategic_Sub_Period where iSerial=@iSerial", sc);
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
                    txt_Strategic_Sub_Period.Text = dt.Rows[0]["sSubPeriod"].ToString();
                    drp_Strategic_Period.SelectedIndex = drp_Strategic_Period.Items.IndexOf(drp_Strategic_Period.Items.FindByValue(dt.Rows[0]["iPeriod"].ToString()));
                    txt_Order.Text = dt.Rows[0]["iOrder"].ToString();
                    drp_StrategyVersion.SelectedIndex = drp_StrategyVersion.Items.IndexOf(drp_StrategyVersion.Items.FindByValue(dt.Rows[0]["iStrategyVersion"].ToString()));
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
            string Strategic_Sub_PeriodID = Request.QueryString["sid"];//Strategic_Sub_PeriodID
            if (Strategic_Sub_PeriodID != null)
            {
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Strategic_Sub_Period set sSubPeriod=@sSubPeriod,iPeriod=@iPeriod,iOrder=@iOrder,iStrategyVersion=@iStrategyVersion,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sSubPeriod", txt_Strategic_Sub_Period.Text.Trim());
                cmd.Parameters.AddWithValue("@iPeriod", drp_Strategic_Period.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iSerial", Strategic_Sub_PeriodID);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Strategic Sub Period Updated Successfully";

                    bindStrategic_Sub_Period(Strategic_Sub_PeriodID);
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
                SqlCommand cmd = new SqlCommand("insert into CS_Strategic_Sub_Period values (@sSubPeriod,@iPeriod,@iOrder,@iStrategyVersion,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy)", sc);
                cmd.Parameters.AddWithValue("@sSubPeriod", txt_Strategic_Sub_Period.Text.Trim());
                cmd.Parameters.AddWithValue("@iPeriod", drp_Strategic_Period.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iOrder", txt_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iStrategyVersion", drp_StrategyVersion.SelectedItem.Value);
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
                    lbl_Msg.Text = "Strategic Sub Period Created Successfully";

                    txt_Strategic_Sub_Period.Text = "";
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
            string sver = Request.QueryString["sver"];
            Response.Redirect("Strategy_Strategic_Sub_Period_Home?id=" + Request.QueryString["id"] + "&sver=" + sver + "");
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            string sver = Request.QueryString["sver"];
            Response.Redirect("Strategy_Strategic_Sub_Period_Home?id=" + Request.QueryString["id"] + "&sver=" + sver + "");
        }
    }
}