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
  public partial class Applicants_Tracking : System.Web.UI.Page
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

        string script = "$(document).ready(function () { $('[id*=btnSubmit]').click(); });";
        ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);

        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Reg_Balance,
            InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
        {
          Server.Transfer("Authorization.aspx");

        }
        FillTerms();
        FacultyFill();
      }
    }
    private void FacultyFill()
    {

      SqlConnection sc = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ECTDataMales"].ConnectionString);
     
      string sSQL;
      sSQL = " SELECT   FacultyID, FacultyName FROM Reg_Faculty WHERE(FacultyID = 0  OR FacultyID = 1 OR  FacultyID = 2 OR FacultyID = 3 OR FacultyID = 4 OR  FacultyID = 7)";
      SqlCommand cmd1 = new SqlCommand(sSQL,sc );
      cmd1.CommandTimeout = 180;
      DataTable dt1 = new DataTable();
      SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            
        sc.Open();
        da1.Fill(dt1);
        sc.Close();
      
      ddlfaculty.DataSource = dt1;
      ddlfaculty.DataTextField = "FacultyName";
      ddlfaculty.DataValueField = "FacultyID";
      ddlfaculty.DataBind();



    }
      private void FillTerms()
    {
      List<Semesters> myTerms = new List<Semesters>();
      SemesterDAL myTermsDAL = new SemesterDAL();
      try
      {
        myTerms = myTermsDAL.GetTerms(InitializeModule.EnumCampus.ECTNew, "", true);
        for (int i = 0; i < myTerms.Count; i++)
        {
          ddlRegTermFrom.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
          ddlRegTermTo.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
        }
        int iYear = 0;
        int iSem = 0;
        int iTerm = 0;
        iYear = (int)Session["RegYear"];
        iSem = (int)Session["RegSemester"];
        iTerm = iYear * 10 + iSem;
       // ddlRegTermFrom.SelectedValue = iTerm.ToString();

      }
      catch (Exception ex)
      {
        LibraryMOD.ShowErrorMessage(ex);
        lbl_Msg.Text = ex.Message;
        div_msg.Visible = true;
      }
      finally
      {
        myTerms.Clear();
      }
    }

    protected void lnk_FieldGenerate_Click(object sender, EventArgs e)
    {     
      if (drp_Campus.SelectedItem.Text == "Males")
      {
        Campus = InitializeModule.EnumCampus.Males;
      }
      else
      {
        Campus = InitializeModule.EnumCampus.Females;
      }
      //string sWhere = " WHERE 1=1";
      //int iRegTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
      //int iYear, iSem;
      //iYear = LibraryMOD.SeperateTerm(iRegTerm, out iSem);
      //int iPYear, iPSem;
      //iPYear = iYear;
      //iPSem = iSem;
      //if (iSem == 1)
      //{
      //  iPSem = 4;
      //  iPYear -= 1;
      //}
      //else
      //{
      //  iPSem -= 1;
      //}

      Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
      SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
      string sSQL = "";
      if (ddlfaculty.SelectedValue == "0")
      {

        sSQL = "SELECT        UID,Accepted, InTerm, RTerm, STType, SID, Name, Gender, Nationality, City, Emirate, AGE, isWorking, WMajor, Major, MCRS, FCRS, MHRS, FHRS, OTerm, OStatus, Ref, RIn, RMajor, ROut, RStatus, strCert, Mark, CertSource,   ";
        sSQL += "  CertDate, RegDate, ExamcenterName, SchoolName, G12, G12_StreamDesc, HSScore, HSYear, Faculty, UserCreate_A, DateCreated_A, UserCreate_SD, DateCreated_SD   ";
        sSQL += "FROM    Applicants_Tracking AS T   WHERE (intStudyYear * 10 + byteSemester BETWEEN " + ddlRegTermFrom.SelectedValue + " AND " + ddlRegTermTo.SelectedValue + ")  ";

      }
      else
      {

        sSQL = "SELECT        UID,Accepted, InTerm, RTerm, STType, SID, Name, Gender, Nationality, City, Emirate, AGE, isWorking, WMajor, Major, MCRS, FCRS, MHRS, FHRS, OTerm, OStatus, Ref, RIn, RMajor, ROut, RStatus, strCert, Mark, CertSource,   ";
        sSQL += "  CertDate, RegDate, ExamcenterName, SchoolName, G12, G12_StreamDesc, HSScore, HSYear, Faculty, UserCreate_A, DateCreated_A, UserCreate_SD, DateCreated_SD   ";
        sSQL += "FROM    Applicants_Tracking AS T   WHERE (intStudyYear * 10 + byteSemester BETWEEN " + ddlRegTermFrom.SelectedValue + " AND " + ddlRegTermTo.SelectedValue + ") AND T.Faculty = "+ddlfaculty.SelectedValue+" ";

      }

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
