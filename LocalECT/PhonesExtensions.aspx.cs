using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
  public partial class PhoneExtensions : System.Web.UI.Page
  {
  
      int CurrentRole = 0;
      InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;
      protected void Page_Load(object sender, EventArgs e)
      {
        if (Session["CurrentRole"] != null)
        {

          CurrentRole = (int)Session["CurrentRole"];

        }
        else
        {
          Session.RemoveAll();
          Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {

          //string script = "$(document).ready(function () { $('[id*=btnSubmit]').click(); });";
          //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);

          if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_PhonesExtensions,
              InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
          {
            Server.Transfer("Authorization.aspx");

          }
        FillData();
        }
      }
    public void FillData()
    {

      SqlConnection sc = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

      string sSQL = "";

      sSQL += "SELECT Lkp_Department.DescEN AS Department, Lkp_Section.DescEN AS Section, HR_PhonesExtensions.EmployeeID AS EID, Hr_Employee.SurnameEn + ' ' + Hr_Employee.FirstNameEn + ' ' + Hr_Employee.SecondNameEn + ' ' + Hr_Employee.ThirdNameEn + ' ' + Hr_Employee.FamilyNameEn AS Name, Lkp_JobTitle.JobTitleEn AS[Job Title], ";
      sSQL += " HR_PhonesExtensions.NormalPhoneExtension AS Phone FROM HR_PhonesExtensions INNER JOIN Hr_Employee ON HR_PhonesExtensions.EmployeeID = Hr_Employee.EmployeeID INNER JOIN ";
      sSQL += " Lkp_Department ON Hr_Employee.DepartmentID = Lkp_Department.DepartmentID INNER JOIN  Lkp_JobTitle ON Hr_Employee.JobTitleID = Lkp_JobTitle.JobTitleID INNER JOIN  Lkp_Section ON Hr_Employee.SectionID = Lkp_Section.SectionID ORDER BY Hr_Employee.SectionID, EID ";

      SqlCommand cmd1 = new SqlCommand(sSQL, sc);
      cmd1.CommandTimeout = 180;
      DataTable dt1 = new DataTable();
      SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
      try
      {
        sc.Open();
        da1.Fill(dt1);
        sc.Close();

        if (dt1.Rows.Count > 0)
        {
          StringBuilder sb = new StringBuilder();
          sb.Append("<table id='example' class='table table-striped table-bordered' style='width: 100%'>" + Environment.NewLine + "");

          //Add Table Header
          sb.Append("<thead>" + Environment.NewLine + "<tr class='headings'>" + Environment.NewLine + "");
          sb.Append("<th>#</th> " + Environment.NewLine + "");
          foreach (DataColumn column in dt1.Columns)
          {
            sb.Append("<th>" + column.ColumnName + "</th> " + Environment.NewLine + "");
          }
          sb.Append("</tr>" + Environment.NewLine + "</thead>" + Environment.NewLine + "");


          //Add Table Rows
          int i = 1;
          foreach (DataRow row in dt1.Rows)
          {
            sb.Append("<tr>" + Environment.NewLine + "");
            sb.Append("<td>" + i + "</td>" + Environment.NewLine + "");
            //Add Table Columns
            foreach (DataColumn column in dt1.Columns)
            {
              sb.Append("<td>" + row[column.ColumnName].ToString() + "</td>" + Environment.NewLine + "");
            }
            sb.Append("</tr>" + Environment.NewLine + "");
            i++;
          }

          sb.Append("</table>" + Environment.NewLine + "");
          DynamicTable.Text = sb.ToString();
        }
        else
        {
          DynamicTable.Text = "<p><b>No Results to show</b></p>";
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
    }
  
}
