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
    public partial class Strategy_Department_Home : System.Web.UI.Page
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
                        binddept();
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

        public void binddept()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            
            SqlCommand cmd = new SqlCommand("SELECT Lkp_Department.DepartmentID, Lkp_Department.DepartmentAbbreviation, Lkp_Department.DescEN, Lkp_Department.ManagerID, Hr_Employee.EmployeeID, Hr_Employee.FirstNameEn +' '+ Hr_Employee.FamilyNameEn as Manager_Name, Hr_Employee.Designation FROM Lkp_Department LEFT OUTER JOIN Hr_Employee ON Lkp_Department.ManagerID = Hr_Employee.EmployeeID WHERE (Lkp_Department.IsActive = 1) and (Lkp_Department.DepartmentID<>-1)", sc);
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