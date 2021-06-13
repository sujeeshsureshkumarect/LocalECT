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
    public partial class Strategy_Customer_Experience_Evidence_Sub_Category_Update : System.Web.UI.Page
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
                        string CustomerExperienceEvidenceCategoryID = Request.QueryString["id"];//CustomerExperienceEvidenceCategoryID
                        string CustomerExperienceEvidenceSubCategoryID = Request.QueryString["sid"];//CustomerExperienceEvidenceSubCategoryID
                        fillCustomerExperienceEvidenceCategory();
                        if (CustomerExperienceEvidenceSubCategoryID != null)
                        {
                            bindCustomerExperienceEvidenceSubCategory(CustomerExperienceEvidenceSubCategoryID);
                            btn_Create.Text = "Update";
                            lbl_Header.Text = "Edit Customer Experience Evidence Sub Category";
                        }
                        else
                        {
                            btn_Create.Text = "Create";
                            lbl_Header.Text = "Create New Customer Experience Evidence Sub Category";
                            drp_CustomerExperienceEvidenceCategory.SelectedIndex = drp_CustomerExperienceEvidenceCategory.Items.IndexOf(drp_CustomerExperienceEvidenceCategory.Items.FindByValue(CustomerExperienceEvidenceCategoryID));
                            drp_CustomerExperienceEvidenceCategory.Enabled = false;
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
        public void fillCustomerExperienceEvidenceCategory()
        {
            SqlCommand cmd = new SqlCommand("select iSerial,sCustomerExperienceEvidenceCategory from CS_Customer_Experience_Evidence_Category", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_CustomerExperienceEvidenceCategory.DataSource = dt;
                drp_CustomerExperienceEvidenceCategory.DataTextField = "sCustomerExperienceEvidenceCategory";
                drp_CustomerExperienceEvidenceCategory.DataValueField = "iSerial";
                drp_CustomerExperienceEvidenceCategory.DataBind();
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
        public void bindCustomerExperienceEvidenceSubCategory(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from CS_Customer_Experience_Evidence_Sub_Category where iSerial=@iSerial", sc);
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
                    txt_CustomerExperienceEvidenceSubCategory.Text = dt.Rows[0]["sCustomerExperienceEvidenceSubCategory"].ToString();                    
                    drp_CustomerExperienceEvidenceCategory.SelectedIndex = drp_CustomerExperienceEvidenceCategory.Items.IndexOf(drp_CustomerExperienceEvidenceCategory.Items.FindByValue(dt.Rows[0]["iCustomerExperienceEvidenceCategory"].ToString()));
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
            string CustomerExperienceEvidenceSubCategoryID = Request.QueryString["sid"];//CustomerExperienceEvidenceSubCategoryID
            if (CustomerExperienceEvidenceSubCategoryID != null)
            {
                //Update
                SqlCommand cmd = new SqlCommand("update CS_Customer_Experience_Evidence_Sub_Category set sCustomerExperienceEvidenceSubCategory=@sCustomerExperienceEvidenceSubCategory,iCustomerExperienceEvidenceCategory=@iCustomerExperienceEvidenceCategory,dUpdated=@dUpdated,sUpdatedBy=@sUpdatedBy where iSerial=@iSerial", sc);
                cmd.Parameters.AddWithValue("@sCustomerExperienceEvidenceSubCategory", txt_CustomerExperienceEvidenceSubCategory.Text.Trim());
                cmd.Parameters.AddWithValue("@iCustomerExperienceEvidenceCategory", drp_CustomerExperienceEvidenceCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@sUpdatedBy", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@iSerial", CustomerExperienceEvidenceSubCategoryID);
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    div_msg.Visible = true;
                    lbl_Msg.Text = "Customer Experience Evidence Sub Category Updated Successfully";

                    bindCustomerExperienceEvidenceSubCategory(CustomerExperienceEvidenceSubCategoryID);
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
                SqlCommand cmd = new SqlCommand("insert into CS_Customer_Experience_Evidence_Sub_Category values (@sCustomerExperienceEvidenceSubCategory,@iCustomerExperienceEvidenceCategory,@dAdded,@sAddedBy,@dUpdated,@sUpdatedBy)", sc);
                cmd.Parameters.AddWithValue("@sCustomerExperienceEvidenceSubCategory", txt_CustomerExperienceEvidenceSubCategory.Text.Trim());
                cmd.Parameters.AddWithValue("@iCustomerExperienceEvidenceCategory", drp_CustomerExperienceEvidenceCategory.SelectedItem.Value);
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
                    lbl_Msg.Text = "Customer Experience Evidence Sub Category Created Successfully";

                    txt_CustomerExperienceEvidenceSubCategory.Text = "";
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
            Response.Redirect("Strategy_Customer_Experience_Evidence_Sub_Category_Home?id=" + Request.QueryString["id"] + "");
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Customer_Experience_Evidence_Sub_Category_Home?id=" + Request.QueryString["id"] + "");
        }
    }
}