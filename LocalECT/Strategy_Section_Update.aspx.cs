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

namespace LocalECT
{
    public partial class Strategy_Section_Update : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Manage_Department_Section,
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
                        bindemployee();
                        binddepartment();
                        string id = Request.QueryString["id"];
                        if (id != null)
                        {
                            bindsection(id);
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
        public void bindsection(String SectionID)
        {
            SqlCommand cmd = new SqlCommand("select * from Lkp_Section where SectionID=@SectionID", sc);
            cmd.Parameters.AddWithValue("@SectionID", SectionID);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    txt_Sect_ID.Text = dt.Rows[0]["SectionID"].ToString();
                    txt_Sect_Name.Text = dt.Rows[0]["DescEN"].ToString();
                    txt_Sect_Abrv.Text = dt.Rows[0]["SectionAbbreviation"].ToString();
                    drp_Department.SelectedIndex = drp_Department.Items.IndexOf(drp_Department.Items.FindByValue(dt.Rows[0]["DepartmentID"].ToString()));
                    drp_Manager.SelectedIndex = drp_Manager.Items.IndexOf(drp_Manager.Items.FindByValue(dt.Rows[0]["ManagerID"].ToString()));
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
        public void bindemployee()
        {
            SqlCommand cmd = new SqlCommand("SELECT [EmployeeID],[FirstNameEn]+' '+[FamilyNameEn] as Manager_Name,[IsActive]FROM [ECTDataNew].[dbo].[Hr_Employee] where IsActive=1 order by Manager_Name", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Manager.DataSource = dt;
                drp_Manager.DataTextField = "Manager_Name";
                drp_Manager.DataValueField = "EmployeeID";
                drp_Manager.DataBind();

                drp_Manager.Items.Insert(0, new ListItem("-- Select Manager --", "-1"));
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
        public void binddepartment()
        {
            SqlCommand cmd = new SqlCommand("SELECT [DepartmentID],[DescEN] FROM [ECTDataNew].[dbo].[Lkp_Department] order by DescEN", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Department.DataSource = dt;
                drp_Department.DataTextField = "DescEN";
                drp_Department.DataValueField = "DepartmentID";
                drp_Department.DataBind();                
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
        protected void btn_Create_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Manage_Department_Section,
                              InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
            {
                div_msg.Visible = true;
                div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                lbl_Msg.Text = "Sorry-You cannot Edit";
                return;
            }

            SqlCommand cmd = new SqlCommand("update Lkp_Section set DescEN=@DescEN,ManagerID=@ManagerID,SectionAbbreviation=@SectionAbbreviation,LastUpdateDate=@LastUpdateDate,NetUserName=@NetUserName,PCName=@PCName,LastUpdateUserID=@LastUpdateUserID where SectionID=@SectionID", sc);
            cmd.Parameters.AddWithValue("@DescEN", txt_Sect_Name.Text.Trim());
            cmd.Parameters.AddWithValue("@ManagerID", drp_Manager.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@SectionAbbreviation", txt_Sect_Abrv.Text.Trim());
            cmd.Parameters.AddWithValue("@LastUpdateDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@NetUserName", Session["CurrentUserName"].ToString());
            cmd.Parameters.AddWithValue("@PCName", "LocalECT");
            cmd.Parameters.AddWithValue("@LastUpdateUserID", Session["EmployeeID"].ToString());
            cmd.Parameters.AddWithValue("@DepartmentID", drp_Department.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@SectionID", txt_Sect_ID.Text.Trim());
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                lbl_Msg.Text = "Section Updated Successfully";
                div_msg.Visible = true;

                bindsection(txt_Sect_ID.Text.Trim());
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
            Response.Redirect("Strategy_Section_Home");
        }
    }
}