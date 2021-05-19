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
  public partial class Extra_LeavesBalances : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      int CurrentRole = 0;
      InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;
      
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

          if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.CheckLeaveBalance,
              InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
          {
            Server.Transfer("Authorization.aspx");

          }
          FillData();
        }
      }
    public void FillData()
    {
      Connection_StringCLS Connection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
      string sCon = Connection_String.Conn_string;
      SqlConnection Con = new SqlConnection(sCon);
      Con.Open();
      try
      {
        if (Session["EmployeeID"] == null) { return; }



        double dblBalance = 0;
        int iEmpNo = 0;

        iEmpNo = Convert.ToInt32(Session["EmployeeID"].ToString());
        LibraryMOD.EmpData emp = new LibraryMOD.EmpData();
        emp = LibraryMOD.GetEmployeeData(iEmpNo);


         dblBalance = LibraryMOD.GetEmployeeVacationBalance(iEmpNo, 1, Con);



        dblBalance += LibraryMOD.GetAnnualLeaveBalance(Con, iEmpNo);



        lblAnnual.Text = " (" + string.Format("{0:f}", dblBalance) + " ) Days";




        dblBalance = LibraryMOD.GetEmployeeInitialVacationBalance(iEmpNo, 2, Con);
        dblBalance -= (-1 * LibraryMOD.GetEmployeeVacationBalance(iEmpNo, 2, Con));



        lblExtra.Text = " (" + string.Format("{0:f}", dblBalance) + " ) Days";
      }
      catch (Exception ex)
      {
      }
      finally
      {
        Con.Close();
        Con.Dispose();
      }
    }
  }
}
