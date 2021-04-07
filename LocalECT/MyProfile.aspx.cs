using Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataTable = System.Data.DataTable;

namespace LocalECT
{
    public partial class MyProfile : System.Web.UI.Page
    {
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                if (!IsPostBack)
                {
                    bindemployeeprofile();
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        public void bindemployeeprofile()
        {
            SqlCommand cmd = new SqlCommand("SELECT * from Hr_EmployeeProfileRpt where EmployeeID=" + Session["EmployeeID"].ToString() + "", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    txt_EmployeeID.Text = dt.Rows[0]["EmpID_ACMS"].ToString();
                    txtEmployeeName.Text = dt.Rows[0]["EmployeeDisplayName"].ToString();
                    txt_Designation.Text = dt.Rows[0]["JobTitleEn"].ToString();
                    txt_Department.Text = dt.Rows[0]["DepartmentDesc"].ToString();
                    if(dt.Rows[0]["Sex"].ToString()=="1")
                    {
                        txt_Gender.Text = "Male";
                    }
                    else
                    {
                        txt_Gender.Text = "Female";
                    }                    
                    txtCategory.Text = dt.Rows[0]["EmpGroup"].ToString();
                    txtPhoneNumber.Text = dt.Rows[0]["Mobile"].ToString();
                    txtEmail.Text = dt.Rows[0]["InternalEmail"].ToString();
                }
            }
            catch(Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                sc.Close();
            }

        }
            
    }
}