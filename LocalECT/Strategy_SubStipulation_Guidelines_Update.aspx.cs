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
    public partial class Strategy_SubStipulation_Guidelines_Update : System.Web.UI.Page
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
                        string StipulationID = Request.QueryString["id"];//StipulationID
                        string SubStipulationID = Request.QueryString["sid"];//SubStipulationID
                        string GuidelineID = Request.QueryString["gid"];//GuidelineID
                        fillStipulation();
                        if (GuidelineID != null)
                        {
                            bindguidelines(GuidelineID);
                            btn_Create.Text = "Update";
                            txt_Guidelines_ID.Enabled = false;
                            lbl_Header.Text = "Edit Guideline";
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            txt_Guidelines_ID.Enabled = true;
                            lbl_Header.Text = "Create New Guideline";
                            drp_Stipulation.SelectedIndex = drp_Stipulation.Items.IndexOf(drp_Stipulation.Items.FindByValue(StipulationID));
                            fillsubStipulation();
                            drp_SubStipulation.SelectedIndex = drp_SubStipulation.Items.IndexOf(drp_SubStipulation.Items.FindByValue(SubStipulationID));
                            drp_Stipulation.Enabled = false;
                            drp_SubStipulation.Enabled = false;
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
        public void fillStipulation()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sStipulationID from CS_Stipulation", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Stipulation.DataSource = dt;
                drp_Stipulation.DataTextField = "sStipulationID";
                drp_Stipulation.DataValueField = "iSerial";
                drp_Stipulation.DataBind();

                fillsubStipulation();
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
        public void fillsubStipulation()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sSubStipulationID from CS_Sub_Stipulation where iStipulation=@iStipulation", sc);
            cmd.Parameters.AddWithValue("@iStipulation", drp_Stipulation.SelectedItem.Value);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_SubStipulation.DataSource = dt;
                drp_SubStipulation.DataTextField = "sSubStipulationID";
                drp_SubStipulation.DataValueField = "iSerial";
                drp_SubStipulation.DataBind();
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
        public void bindguidelines(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Stipulation_Guidelines where iSerial=@iSerial", sc);
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
                    txt_Guidelines_ID.Text = dt.Rows[0]["sGuidelinesID"].ToString();
                    txt_Guidelines_Desc.Text = dt.Rows[0]["sGuidelinesDesc"].ToString();
                    txt_Guidelines_Order.Text = dt.Rows[0]["iOrder"].ToString();
                    drp_Stipulation.SelectedIndex = drp_Stipulation.Items.IndexOf(drp_Stipulation.Items.FindByValue(dt.Rows[0]["iStipulation"].ToString()));
                    fillsubStipulation();
                    drp_SubStipulation.SelectedIndex = drp_SubStipulation.Items.IndexOf(drp_SubStipulation.Items.FindByValue(dt.Rows[0]["iSubStipulation"].ToString()));
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
            string GuidelineID = Request.QueryString["gid"];//SubStipulationID
            if (GuidelineID != null)
            {
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Stipulation_Guidelines set sGuidelinesID=@sGuidelinesID,sGuidelinesDesc=@sGuidelinesDesc,iStipulation=@iStipulation,iSubStipulation=@iSubStipulation,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy,iOrder=@iOrder where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sGuidelinesID", txt_Guidelines_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sGuidelinesDesc", txt_Guidelines_Desc.Text.Trim());
                cmd.Parameters.AddWithValue("@iStipulation", drp_Stipulation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSubStipulation", drp_SubStipulation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iOrder", txt_Guidelines_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iSerial", GuidelineID);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Guideline Updated Successfully";

                    bindguidelines(GuidelineID);
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
                SqlCommand cmd = new SqlCommand("insert into CS_Stipulation_Guidelines values (@sGuidelinesID,@sGuidelinesDesc,@iStipulation,@iSubStipulation,@iOrder,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy)", sc);
                cmd.Parameters.AddWithValue("@sGuidelinesID", txt_Guidelines_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sGuidelinesDesc", txt_Guidelines_Desc.Text.Trim());
                cmd.Parameters.AddWithValue("@iStipulation", drp_Stipulation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@iSubStipulation", drp_SubStipulation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iOrder", txt_Guidelines_Order.Text.Trim());
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Guideline Created Successfully";

                    txt_Guidelines_ID.Text = "";
                    txt_Guidelines_Desc.Text = "";
                    txt_Guidelines_Order.Text = "";
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
            Response.Redirect("Strategy_SubStipulation_Guidelines_Home?id=" + Request.QueryString["id"] + "&sid=" + Request.QueryString["sid"] + "");
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_SubStipulation_Guidelines_Home?id=" + Request.QueryString["id"] + "&sid=" + Request.QueryString["sid"] + "");
        }

        protected void drp_Stipulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillsubStipulation();
        }
    }
}