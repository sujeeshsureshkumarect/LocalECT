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
  public partial class Registered_Courses : System.Web.UI.Page
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
      SqlCommand cmd1 = new SqlCommand(sSQL, sc);
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
         ddlRegTermFrom.SelectedValue = iTerm.ToString();
        ddlRegTermTo.SelectedValue = iTerm.ToString();
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

      string byshift;

      if (drp_Campus.SelectedItem.Text == "Males")
      {
        Campus = InitializeModule.EnumCampus.Males;
        byshift = " (SD.byteShift = 3 OR SD.byteShift = 4 OR SD.byteShift = 8 ) ";
      }
      else
      {
        Campus = InitializeModule.EnumCampus.Females;
        byshift = " (SD.byteShift = 1 OR SD.byteShift = 2 OR SD.byteShift = 9) ";
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

      sSQL += " SELECT   CB.iYear * 10 + CB.Sem AS Term, F.FacultyName AS Faculty, CB.Course AS Code, C.strCourseDescEn AS Course, A.lngStudentNumber AS SID, GH.curUseMark AS Mark, GH.strGrade AS Grade,  ";
      sSQL += "  (CASE WHEN bPassIt = 1 THEN 'Yes' ELSE 'No' END) AS ISPassed FROM  Reg_Colleges AS CO INNER JOIN  Reg_Courses AS C INNER JOIN ";
      sSQL += "  Course_Balance_View_BothSides AS CB ON C.strCourse = CB.Course INNER JOIN  Reg_Applications AS A INNER JOIN ";
      sSQL += "  Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON CB.Student = A.lngStudentNumber ON CO.strCollege = C.strCollege INNER JOIN ";
      sSQL += "   Reg_Faculty AS F ON CO.FacultyID = F.FacultyID LEFT OUTER JOIN  Reg_Grade_Header AS GH LEFT OUTER JOIN ";
      sSQL += "   Reg_Grade_System AS GS ON GH.strGrade = GS.strGrade ON CB.iYear = GH.intStudyYear AND CB.Sem = GH.byteSemester AND CB.Course = GH.strCourse AND CB.Student = GH.lngStudentNumber ";
      sSQL += " WHERE        (CB.iYear * 10 + CB.Sem BETWEEN "+ddlRegTermFrom.SelectedValue+" AND "+ddlRegTermTo.SelectedValue+")  AND "+byshift+" ";
      sSQL += "  AND (CB.Course IN (SELECT strCourse FROM Reg_Courses AS Reg_Courses_1 ";
     

     

     
     

      if (ddlInternalShip.SelectedValue == "1")
      {
        sSQL += " WHERE (strCourseDescEn LIKE '%Internship%') OR (strCourseDescEn LIKE '%تدريب%')))   ";
      }
      else
      {
        sSQL += " WHERE (strCourseDescEn NOT LIKE '%Internship%') OR (strCourseDescEn NOT LIKE '%تدريب%'))) ";
      }

      if (ddlfaculty.SelectedValue != "0")
      {

        sSQL += " AND F.FacultyID = " + ddlfaculty.SelectedValue + " ";

      }

      sSQL += " ORDER BY Term ";

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
