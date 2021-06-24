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
    public partial class Strategy_Risk_Management_Registry_Framework_Update : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Risk_Management_Framework,
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
                        string iFramework = Request.QueryString["id"];//iFramework
                        string iRegistryFramework = Request.QueryString["sid"];//iRegistryFramework
                        fillRegistryFramework();
                        if (iRegistryFramework != null)
                        {
                            bindRisk_Management_Registry_Framework(iRegistryFramework);
                            btn_Create.Text = "Update";
                            lbl_Header.Text = "Edit Risk Management Registry Framework";
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New Risk Management Registry Framework";
                            drp_Framework.SelectedIndex = drp_Framework.Items.IndexOf(drp_Framework.Items.FindByValue(iFramework));
                            drp_Framework.Enabled = false;
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
        public void fillRegistryFramework()
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
        public void bindRisk_Management_Registry_Framework(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Risk_Management_Registry_Framework where iSerial=@iSerial", sc);
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
                    txt_RegistryFramework.Text = dt.Rows[0]["sRegistryFramework"].ToString();
                    drp_Framework.SelectedIndex = drp_Framework.Items.IndexOf(drp_Framework.Items.FindByValue(dt.Rows[0]["iFramework"].ToString()));
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
            string iRegistryFramework = Request.QueryString["sid"];//iRegistryFramework
            if (iRegistryFramework != null)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Risk_Management_Framework,
                              InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Edit";
                    return;
                }
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Risk_Management_Registry_Framework set sRegistryFramework=@sRegistryFramework,iFramework=@iFramework,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sRegistryFramework", txt_RegistryFramework.Text.Trim());
                cmd.Parameters.AddWithValue("@iFramework", drp_Framework.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iSerial", iRegistryFramework);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Risk Management Registry Framework Updated Successfully";

                    bindRisk_Management_Registry_Framework(iRegistryFramework);
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Risk_Management_Framework,
                             InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Add";
                    return;
                }
                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Risk_Management_Registry_Framework values (@sRegistryFramework,@iFramework,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy)", sc);
                cmd.Parameters.AddWithValue("@sRegistryFramework", txt_RegistryFramework.Text.Trim());
                cmd.Parameters.AddWithValue("@iFramework", drp_Framework.SelectedItem.Value);
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
                    lbl_Msg.Text = "Risk Management Registry Framework Created Successfully";

                    txt_RegistryFramework.Text = "";
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
            Response.Redirect("Strategy_Risk_Management_Registry_Framework_Home?id=" + Request.QueryString["id"] + "");
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Risk_Management_Registry_Framework_Home?id=" + Request.QueryString["id"] + "");
        }
    }
}