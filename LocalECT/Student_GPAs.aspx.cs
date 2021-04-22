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
  public partial class Student_GPAs : System.Web.UI.Page
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

      string Byshifts;
      string GenderExt;
      string Gender;

      if (drp_Campus.SelectedItem.Text == "Males")
      {
        Campus = InitializeModule.EnumCampus.Males;
        Byshifts = " AND (SD.byteShift = 3 OR SD.byteShift = 4 OR  SD.byteShift = 8) ";
        GenderExt = "M";
        Gender = "Male";
      }
      else
      {
        Campus = InitializeModule.EnumCampus.Females;
        Byshifts = " AND (SD.byteShift = 1 OR SD.byteShift = 2 OR  SD.byteShift = 9) ";
        GenderExt = "F";
        Gender = "Female";
      }


      Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
      SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
      string sSQL = "";
      if(ddlfaculty.SelectedValue == "0")
      {
        sSQL += "SELECT Term,intStudyYear as [Year], byteSemester as Semester, Major, SID, Name, Gender, Credits, Points  ";
        sSQL += ",(CASE WHEN Credits>0 THEN Points/Credits ELSE NULL END) AS GPA  ";
        sSQL += ", dbo.GetCGPA(SID,intStudyYear, byteSemester, strDegree, strMajor) AS CGPA  ";
        sSQL += "FROM         (SELECT        TOP (100) PERCENT G.intStudyYear * 10 + G.byteSemester AS Term, F.FacultyName AS Faculty, M.strCaption AS Major, A.lngStudentNumber AS SID, SD.strLastDescEn AS Name, (CASE WHEN bSex = 1 THEN 'M' ELSE 'F' END)   ";
        sSQL += "  AS Gender, SUM(C.byteCreditHours) AS Credits, SUM(GS.curCreditPoint * C.byteCreditHours) AS Points, G.intStudyYear, G.byteSemester, G.strDegree, G.strMajor  ";
        sSQL += "FROM            Reg_Courses AS C INNER JOIN  ";
        sSQL += " Reg_Grade_Header AS G ON C.strCourse = G.strCourse INNER JOIN  ";
        sSQL += " Reg_Grade_System AS GS ON G.strGrade = GS.strGrade INNER JOIN  ";
        sSQL += " Reg_Specializations AS M ON G.strDegree = M.strDegree AND G.strMajor = M.strSpecialization INNER JOIN  ";
        sSQL += " Reg_Applications AS A ON G.lngStudentNumber = A.lngStudentNumber INNER JOIN  ";
        sSQL += " Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN  ";
        sSQL += " Reg_Faculty AS F ON M.FacultyID = F.FacultyID WHERE        (GS.bCalc = 1) " + Byshifts + "  ";
        sSQL += "GROUP BY G.intStudyYear * 10 + G.byteSemester, M.strCaption, A.lngStudentNumber, SD.strLastDescEn, G.intStudyYear, G.byteSemester, G.strDegree, G.strMajor, F.FacultyName, (CASE WHEN bSex = 1 THEN 'M' ELSE 'F' END)  ";
        sSQL += "HAVING        (G.intStudyYear * 10 + G.byteSemester BETWEEN " + ddlRegTermFrom.SelectedValue + " AND " + ddlRegTermTo.SelectedValue + ")) AS MD  ";
        sSQL += "  ";
        sSQL += "   ";
        sSQL += "  ";
        sSQL += "ORDER BY SID,Term  ";
      }
      else
      {
        sSQL += "SELECT Term,intStudyYear as [Year], byteSemester as Semester, Major, SID, Name, Gender, Credits, Points  ";
        sSQL += ",(CASE WHEN Credits>0 THEN Points/Credits ELSE NULL END) AS GPA  ";
        sSQL += ", dbo.GetCGPA(SID,intStudyYear, byteSemester, strDegree, strMajor) AS CGPA  ";
        sSQL += "FROM         (SELECT        TOP (100) PERCENT G.intStudyYear * 10 + G.byteSemester AS Term, F.FacultyName AS Faculty, M.strCaption AS Major, A.lngStudentNumber AS SID, SD.strLastDescEn AS Name, (CASE WHEN bSex = 1 THEN 'M' ELSE 'F' END)   ";
        sSQL += "  AS Gender, SUM(C.byteCreditHours) AS Credits, SUM(GS.curCreditPoint * C.byteCreditHours) AS Points, G.intStudyYear, G.byteSemester, G.strDegree, G.strMajor  ";
        sSQL += "FROM            Reg_Courses AS C INNER JOIN  ";
        sSQL += " Reg_Grade_Header AS G ON C.strCourse = G.strCourse INNER JOIN  ";
        sSQL += " Reg_Grade_System AS GS ON G.strGrade = GS.strGrade INNER JOIN  ";
        sSQL += " Reg_Specializations AS M ON G.strDegree = M.strDegree AND G.strMajor = M.strSpecialization INNER JOIN  ";
        sSQL += " Reg_Applications AS A ON G.lngStudentNumber = A.lngStudentNumber INNER JOIN  ";
        sSQL += " Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN  ";
        sSQL += " Reg_Faculty AS F ON M.FacultyID = F.FacultyID WHERE        (GS.bCalc = 1) " + Byshifts + " AND (F.FacultyID = " + ddlfaculty.SelectedValue + ")  ";
        sSQL += "GROUP BY G.intStudyYear * 10 + G.byteSemester, M.strCaption, A.lngStudentNumber, SD.strLastDescEn, G.intStudyYear, G.byteSemester, G.strDegree, G.strMajor, F.FacultyName, (CASE WHEN bSex = 1 THEN 'M' ELSE 'F' END)  ";
        sSQL += "HAVING        (G.intStudyYear * 10 + G.byteSemester BETWEEN " + ddlRegTermFrom.SelectedValue + " AND " + ddlRegTermTo.SelectedValue + ")) AS MD  ";
        sSQL += "  ";
        sSQL += "   ";
        sSQL += "  ";
        sSQL += "ORDER BY SID,Term  ";
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
