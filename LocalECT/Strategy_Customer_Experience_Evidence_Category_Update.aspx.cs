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
    public partial class Strategy_Customer_Experience_Evidence_Category_Update : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Customer_Experience_Evidence_Category,
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
                        string id = Request.QueryString["id"];
                        if (id != null)
                        {
                            bindCustomer_Experience_Evidence_Category(id);
                            btn_Create.Text = "Update";
                            lbl_Header.Text = "Edit Customer Experience Evidence Category";
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New Customer Experience Evidence Category";
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
        public void bindCustomer_Experience_Evidence_Category(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Customer_Experience_Evidence_Category where iSerial=@iSerial", sc);
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
                    txt_CustomerExperienceEvidenceCategory.Text = dt.Rows[0]["sCustomerExperienceEvidenceCategory"].ToString();                   
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
            string id = Request.QueryString["id"];
            if (id != null)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Customer_Experience_Evidence_Category,
                              InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Edit";
                    return;
                }
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Customer_Experience_Evidence_Category set sCustomerExperienceEvidenceCategory=@sCustomerExperienceEvidenceCategory,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sCustomerExperienceEvidenceCategory", txt_CustomerExperienceEvidenceCategory.Text.Trim());
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iSerial", id);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Customer Experience Evidence Category Updated Successfully";

                    bindCustomer_Experience_Evidence_Category(id);
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Customer_Experience_Evidence_Category,
                          InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                {
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                    lbl_Msg.Text = "Sorry-You cannot Add";
                    return;
                }
                //Insert
                SqlCommand cmd = new SqlCommand("insert into CS_Customer_Experience_Evidence_Category values (@sCustomerExperienceEvidenceCategory,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy)", sc);
                cmd.Parameters.AddWithValue("@sCustomerExperienceEvidenceCategory", txt_CustomerExperienceEvidenceCategory.Text.Trim());               
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
                    lbl_Msg.Text = "Customer Experience Evidence Category Created Successfully";

                    txt_CustomerExperienceEvidenceCategory.Text = "";
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
            Response.Redirect("Strategy_Customer_Experience_Evidence_Category_Home");
        }
    }
}