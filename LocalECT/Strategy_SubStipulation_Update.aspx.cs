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
    public partial class Strategy_SubStipulation_Update : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Stipulation,
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
                        string StipulationID = Request.QueryString["id"];//StipulationID
                        string SubStipulationID = Request.QueryString["sid"];//SubStipulationID
                        fillStipulation();
                        if (SubStipulationID != null)
                        {
                            bindsubstipulation(SubStipulationID);
                            btn_Create.Text = "Update";
                            txt_SubStipulation_ID.Enabled = false;
                            lbl_Header.Text = "Edit MOE Re-licensure Sub Stipulation";
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            txt_SubStipulation_ID.Enabled = true;
                            lbl_Header.Text = "Create New MOE Re-licensure Sub Stipulation";
                            drp_Stipulation.SelectedIndex = drp_Stipulation.Items.IndexOf(drp_Stipulation.Items.FindByValue(StipulationID));
                            drp_Stipulation.Enabled = false;
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
        }
        public void bindsubstipulation(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Sub_Stipulation where iSerial=@iSerial", sc);
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
                    txt_SubStipulation_ID.Text = dt.Rows[0]["sSubStipulationID"].ToString();
                    txt_SubStipulation_Desc.Text = dt.Rows[0]["sSubStipulationDesc"].ToString();
                    txt_SubStipulation_Order.Text = dt.Rows[0]["iOrder"].ToString();
                    drp_Stipulation.SelectedIndex = drp_Stipulation.Items.IndexOf(drp_Stipulation.Items.FindByValue(dt.Rows[0]["iStipulation"].ToString()));
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
            string SubStipulationID = Request.QueryString["sid"];//SubStipulationID
            if (SubStipulationID != null)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Stipulation,
                              InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Edit";
                    return;
                }
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Sub_Stipulation set sSubStipulationID=@sSubStipulationID,sSubStipulationDesc=@sSubStipulationDesc,iStipulation=@iStipulation,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy,iOrder=@iOrder where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sSubStipulationID", txt_SubStipulation_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sSubStipulationDesc", txt_SubStipulation_Desc.Text.Trim());
                cmd.Parameters.AddWithValue("@iStipulation", drp_Stipulation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iOrder", txt_SubStipulation_Order.Text.Trim());
                cmd.Parameters.AddWithValue("@iSerial", SubStipulationID);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "MOE Re-licensure Sub Stipulation Updated Successfully";

                    bindsubstipulation(SubStipulationID);
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Stipulation,
                                 InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Add";
                    return;
                }
                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Sub_Stipulation values (@sSubStipulationID,@sSubStipulationDesc,@iStipulation,@iOrder,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy)", sc);
                cmd.Parameters.AddWithValue("@sSubStipulationID", txt_SubStipulation_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@sSubStipulationDesc", txt_SubStipulation_Desc.Text.Trim());
                cmd.Parameters.AddWithValue("@iStipulation", drp_Stipulation.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@sAddedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iOrder", txt_SubStipulation_Order.Text.Trim());
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "MOE Re-licensure Sub Stipulation Created Successfully";

                    txt_SubStipulation_ID.Text = "";
                    txt_SubStipulation_Desc.Text = "";
                    txt_SubStipulation_Order.Text = "";
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
            Response.Redirect("Strategy_SubStipulation_Home?id="+ Request.QueryString["id"] + "");
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_SubStipulation_Home?id=" + Request.QueryString["id"] + "");
        }
    }
}