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
    public partial class Strategy_KPI_Sub_Level_Update : System.Web.UI.Page
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
                        string KPILevelID = Request.QueryString["id"];//KPILevelID
                        string KPISubLevelID = Request.QueryString["sid"];//KPISubLevelID
                        fillKPILevel();
                        if (KPISubLevelID != null)
                        {
                            bindKPISubLevel(KPISubLevelID);
                            btn_Create.Text = "Update";
                            lbl_Header.Text = "Edit KPI Sub Level";
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New KPI Sub Level";
                            drp_KPILevel.SelectedIndex = drp_KPILevel.Items.IndexOf(drp_KPILevel.Items.FindByValue(KPILevelID));
                            drp_KPILevel.Enabled = false;
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
        public void bindKPISubLevel(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_KPI_Sub_Level where iSerial=@iSerial", sc);
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
                    txt_KPI_Sub_Level.Text = dt.Rows[0]["sKPISubLevel"].ToString();
                    drp_KPILevel.SelectedIndex = drp_KPILevel.Items.IndexOf(drp_KPILevel.Items.FindByValue(dt.Rows[0]["iKPILevel"].ToString()));
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
            string KPISubLevelID = Request.QueryString["sid"];//CustomerExperienceEvidenceSubCategoryID
            if (KPISubLevelID != null)
            {
                //Update
                SqlCommand cmd = new SqlCommand("update CS_KPI_Sub_Level set sKPISubLevel=@sKPISubLevel,iKPILevel=@iKPILevel,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sKPISubLevel", txt_KPI_Sub_Level.Text.Trim());
                cmd.Parameters.AddWithValue("@iKPILevel", drp_KPILevel.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iSerial", KPISubLevelID);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "KPI Sub Level Updated Successfully";

                    bindKPISubLevel(KPISubLevelID);
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
                SqlCommand cmd = new SqlCommand("insert into CS_KPI_Sub_Level values (@sKPISubLevel,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy,@iKPILevel)", sc);
                cmd.Parameters.AddWithValue("@sKPISubLevel", txt_KPI_Sub_Level.Text.Trim());                
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iKPILevel", drp_KPILevel.SelectedItem.Value);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "KPI Sub Level Created Successfully";

                    txt_KPI_Sub_Level.Text = "";
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
            Response.Redirect("Strategy_KPI_Sub_Level_Home?id=" + Request.QueryString["id"] + "");
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_KPI_Sub_Level_Home?id=" + Request.QueryString["id"] + "");
        }
    }
}