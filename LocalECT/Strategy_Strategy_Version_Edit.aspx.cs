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

namespace LocalECT
{
    public partial class CS_Strategy_Version_Edit : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategy_Version,
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

                        string id = Request.QueryString["id"];
                        if (id != null)
                        {
                            bindlink(id);
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

        public void bindlink(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Strategy_Version where iSerial=@iLink", sc);
            cmd.Parameters.AddWithValue("@iLink", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    txt_Version.Text = dt.Rows[0]["sStrategyVersion"].ToString();
                    txt_sDate.Text = Convert.ToDateTime(dt.Rows[0]["dStart"]).ToString("dd/MM/yyyy");
                    txt_eDate.Text = Convert.ToDateTime(dt.Rows[0]["dEnd"]).ToString("dd/MM/yyyy");
                    txt_Order.Text = dt.Rows[0]["iOrder"].ToString();
                    //txt_IsActive.Text = dt.Rows[0]["isActive"].ToString();
                    string active = dt.Rows[0]["isActive"].ToString();
                    int i = 0;
                    if (active == "False")
                    {
                        i = 0;
                    }
                    else
                    {
                        i = 1;
                    }
                    txt_IsActive.SelectedIndex = txt_IsActive.Items.IndexOf(txt_IsActive.Items.FindByValue(i.ToString()));
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
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategy_Version,
                              InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
            {
                div_msg.Visible = true;
                div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                lbl_Msg.Text = "Sorry-You cannot Edit";
                return;
            }
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("update CS_Strategy_Version set sStrategyVersion=@sVer,dStart=@sDate,dEnd=@eDate,iOrder=@sOrder,isActive=@sActive,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedby where iSerial=@iLink", sc);

            cmd.Parameters.AddWithValue("@sVer", txt_Version.Text.Trim());
            DateTime StartDate = DateTime.ParseExact(txt_sDate.Text, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime EndDate = DateTime.ParseExact(txt_eDate.Text, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
            cmd.Parameters.AddWithValue("@sDate", StartDate);
            cmd.Parameters.AddWithValue("@eDate", EndDate);
            cmd.Parameters.AddWithValue("@sOrder", txt_Order.Text.Trim());
            cmd.Parameters.AddWithValue("@sActive", int.Parse(txt_IsActive.SelectedValue));

            cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
            cmd.Parameters.AddWithValue("@sUpdatedby", Session["CurrentUserName"].ToString());


            cmd.Parameters.AddWithValue("@iLink", Request.QueryString["id"]);
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
            Response.Redirect("Strategy_Strategy_Version");
        }
    }
}
