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
    public partial class Strategy_Initiative_Dpartment_Section_Update : System.Web.UI.Page
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
                        fillDepartment();
                        fillSection();                        
                        string id = Request.QueryString["id"];

                        btn_Create.Text = "Create";
                        lbl_Header.Text = "Create New Support Department/Section";

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

        public void fillDepartment()
        {
            SqlCommand cmd = new SqlCommand("select DepartmentID,DescEN from Lkp_Department where (Lkp_Department.IsActive = 1) and (Lkp_Department.DepartmentID<>-1)", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_iDepartment.DataSource = dt;
                drp_iDepartment.DataTextField = "DescEN";
                drp_iDepartment.DataValueField = "DepartmentID";
                drp_iDepartment.DataBind();
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
        public void fillSection()
        {
            if (!string.IsNullOrEmpty(drp_iDepartment.SelectedValue))
            {
                SqlCommand cmd = new SqlCommand("select SectionID,DescEN from Lkp_Section where DepartmentID=@DepartmentID", sc);
                cmd.Parameters.AddWithValue("@DepartmentID", drp_iDepartment.SelectedItem.Value);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    drp_iSection.DataSource = dt;
                    drp_iSection.DataTextField = "DescEN";
                    drp_iSection.DataValueField = "SectionID";
                    drp_iSection.DataBind();
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

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            SqlCommand cmd = new SqlCommand("insert into CS_Initiative_Dpartment_Section values (@iInitiative,@iDepartment,@iSection,@isPrincipal)", sc);
            cmd.Parameters.AddWithValue("@iDepartment", drp_iDepartment.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@iSection", drp_iSection.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@isPrincipal", 0);            
            cmd.Parameters.AddWithValue("@iInitiative", id);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                div_msg.Visible = true;
                lbl_Msg.Text = "Support Department/Section Created Successfully";

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

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Initiative_Dpartment_Section_Home?id=" + Request.QueryString["id"] + "");
        }

        protected void lnk_Create_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Initiative_Dpartment_Section_Home?id=" + Request.QueryString["id"] + "");
        }
     

        protected void drp_iDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSection();
        }
    }
}