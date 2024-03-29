﻿using System;
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
    public partial class Strategy_Section_Home : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Manage_Department_Section,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        {
                            //Server.Transfer("Authorization.aspx");
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
                        bindsection();
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

        public void bindsection()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            string sSQL = "";
            sSQL += " SELECT        Lkp_Section.DepartmentID, Lkp_Section.SectionID, Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN, Lkp_Section.ManagerID, Hr_Employee_1.FirstNameEn + ' ' + Hr_Employee_1.FamilyNameEn AS Manager_Name,  ";
            sSQL += "                          Lkp_Department.DescEN AS Dept_Name, Lkp_Section.ApproverID,Hr_Employee.FirstNameEn + ' ' + Hr_Employee.FamilyNameEn AS Approver_Name, Lkp_Section.JobIDofSectionManager, Lkp_JobTitle.JobTitleEn ";
            sSQL += " FROM            Lkp_Section LEFT OUTER JOIN ";
            sSQL += "                          Lkp_Department ON Lkp_Section.DepartmentID = Lkp_Department.DepartmentID LEFT OUTER JOIN ";
            sSQL += "                          Hr_Employee ON Lkp_Section.ApproverID = Hr_Employee.EmployeeID LEFT OUTER JOIN ";
            sSQL += "                          Lkp_JobTitle ON Lkp_Section.JobIDofSectionManager = Lkp_JobTitle.JobTitleID LEFT OUTER JOIN ";
            sSQL += "                          Hr_Employee AS Hr_Employee_1 ON Lkp_Section.ManagerID = Hr_Employee_1.EmployeeID ";
            sSQL += " WHERE        (Lkp_Section.SectionID <> - 1) ";
            //SqlCommand cmd = new SqlCommand("SELECT Lkp_Section.DepartmentID, Lkp_Section.SectionID, Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN, Lkp_Section.ManagerID, Hr_Employee.EmployeeID, Hr_Employee.FirstNameEn + ' ' + Hr_Employee.FamilyNameEn AS Manager_Name, Hr_Employee.Designation, Lkp_Department.DescEN AS Dept_Name FROM Lkp_Section INNER JOIN Lkp_Department ON Lkp_Section.DepartmentID = Lkp_Department.DepartmentID LEFT OUTER JOIN Hr_Employee ON Lkp_Section.ManagerID = Hr_Employee.EmployeeID WHERE (Lkp_Section.SectionID <> - 1)", sc);
            SqlCommand cmd = new SqlCommand(sSQL, sc);
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
    }
}