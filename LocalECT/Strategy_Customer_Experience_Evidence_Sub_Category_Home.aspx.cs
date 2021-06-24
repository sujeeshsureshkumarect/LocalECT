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
    public partial class Strategy_Customer_Experience_Evidence_Sub_Category_Home : System.Web.UI.Page
    {
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
                            bindCustomer_Experience_Evidence_Sub_Category(id);
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

        public void bindCustomer_Experience_Evidence_Sub_Category(string id)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SELECT CS_Customer_Experience_Evidence_Sub_Category.iSerial, CS_Customer_Experience_Evidence_Sub_Category.sCustomerExperienceEvidenceSubCategory, CS_Customer_Experience_Evidence_Sub_Category.iCustomerExperienceEvidenceCategory, CS_Customer_Experience_Evidence_Sub_Category.dAdded, CS_Customer_Experience_Evidence_Sub_Category.sAddedBy, CS_Customer_Experience_Evidence_Sub_Category.dUpdated, CS_Customer_Experience_Evidence_Sub_Category.sUpdatedBy, CS_Customer_Experience_Evidence_Category.sCustomerExperienceEvidenceCategory FROM CS_Customer_Experience_Evidence_Sub_Category INNER JOIN CS_Customer_Experience_Evidence_Category ON CS_Customer_Experience_Evidence_Sub_Category.iCustomerExperienceEvidenceCategory = CS_Customer_Experience_Evidence_Category.iSerial where iCustomerExperienceEvidenceCategory=@iCustomerExperienceEvidenceCategory", sc);
            cmd.Parameters.AddWithValue("@iCustomerExperienceEvidenceCategory", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
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

        protected void lnk_Create_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            Response.Redirect("Strategy_Customer_Experience_Evidence_Sub_Category_Update?id=" + id + "");
        }
    }
}