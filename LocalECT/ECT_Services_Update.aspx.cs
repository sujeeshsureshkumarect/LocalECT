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
    public partial class ECT_Services_Update : System.Web.UI.Page
    {
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
                        string id = Request.QueryString["id"];
                        if (id != null)
                        {
                            bindservices(id);
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

        public void bindservices(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from ECT_Services where ServiceID=@ServiceID", sc);
            cmd.Parameters.AddWithValue("@ServiceID", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    lbl_ID.Text = dt.Rows[0]["ServiceID"].ToString();
                    txt_ServiceEn.Text = dt.Rows[0]["ServiceEn"].ToString();
                    txt_ServiceAr.Text = dt.Rows[0]["ServiceAr"].ToString();
                    txt_ServiceHeaderEn.Text = dt.Rows[0]["ServiceHeaderEn"].ToString();
                    txt_ServiceHeaderAr.Text = dt.Rows[0]["ServiceHeaderAr"].ToString();
                    txt_ServiceDescEn.Text = dt.Rows[0]["ServiceDescEn"].ToString();
                    txt_ServiceDescAr.Text = dt.Rows[0]["ServiceDescAr"].ToString();
                    txt_Audience.Text = dt.Rows[0]["Audience"].ToString();
                    txt_Host.Text = dt.Rows[0]["Host"].ToString();
                    txt_Finance.Text = dt.Rows[0]["Finance"].ToString();
                    drp_Status.SelectedIndex = drp_Status.Items.IndexOf(drp_Status.Items.FindByValue(dt.Rows[0]["isActive"].ToString()));
                }
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
        protected void btn_Create_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ECT_Services_Management");
        }
    }
}