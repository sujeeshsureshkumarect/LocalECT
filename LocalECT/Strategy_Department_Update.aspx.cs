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
    public partial class Strategy_Department_Update : System.Web.UI.Page
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
                        //InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
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
                        bindemployee();
                        string id = Request.QueryString["id"];
                        if (id != null)
                        {
                            binddepartment(id);
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
        public void binddepartment(String Dept_ID)
        {
            SqlCommand cmd = new SqlCommand("select * from Lkp_Department where DepartmentID=@DepartmentID", sc);
            cmd.Parameters.AddWithValue("@DepartmentID", Dept_ID);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    txt_Dept_ID.Text = dt.Rows[0]["DepartmentID"].ToString();
                    txt_Dept_Name.Text = dt.Rows[0]["DescEN"].ToString();
                    txt_Dept_Abrv.Text = dt.Rows[0]["DepartmentAbbreviation"].ToString();
                    drp_Manager.SelectedIndex = drp_Manager.Items.IndexOf(drp_Manager.Items.FindByValue(dt.Rows[0]["ManagerID"].ToString()));
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
        protected void btn_Create_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Lkp_Department set DescEN=@DescEN,ManagerID=@ManagerID,DepartmentAbbreviation=@DepartmentAbbreviation,LastUpdateDate=@LastUpdateDate,NetUserName=@NetUserName,PCName=@PCName,LastUpdateUserID=@LastUpdateUserID where DepartmentID=@DepartmentID", sc);
            cmd.Parameters.AddWithValue("@DescEN", txt_Dept_Name.Text.Trim());
            cmd.Parameters.AddWithValue("@ManagerID", drp_Manager.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@DepartmentAbbreviation", txt_Dept_Abrv.Text.Trim());
            cmd.Parameters.AddWithValue("@LastUpdateDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@NetUserName", Session["CurrentUserName"].ToString());
            cmd.Parameters.AddWithValue("@PCName", "LocalECT");
            cmd.Parameters.AddWithValue("@LastUpdateUserID", Session["EmployeeID"].ToString());
            cmd.Parameters.AddWithValue("@DepartmentID", txt_Dept_ID.Text.Trim());
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                lbl_Msg.Text = "Department Updated Successfully";
                div_msg.Visible = true;

                binddepartment(txt_Dept_ID.Text.Trim());
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

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Department_Home");
        }
    }
}