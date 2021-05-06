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
  public partial class Attendance_Grades : System.Web.UI.Page
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
          ddlRegTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
         
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

      //System.Threading.Thread.Sleep(5000);

      if (drp_Campus.SelectedItem.Text == "Males")
      {
        Campus = InitializeModule.EnumCampus.Males;
      }
      else
      {
        Campus = InitializeModule.EnumCampus.Females;
      }
      string sWhere = " WHERE 1=1";
      int iRegTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
      int iYear, iSem;
      iYear = LibraryMOD.SeperateTerm(iRegTerm, out iSem);
      int iPYear, iPSem;
      iPYear = iYear;
      iPSem = iSem;
      if (iSem == 1)
      {
        iPSem = 4;
        iPYear -= 1;
      }
      else
      {
        iPSem -= 1;
      }

      Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
      SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
      string sSQL = "";
      if (ddlfaculty.SelectedValue == "0")
      {

        sSQL = "SELECT     GH.lngStudentNumber AS SID, SD.strLastDescEn AS Name, F.FacultyName AS Faculty, M.strCaption AS Major, GH.strCourse AS Course, GH.strGrade AS Grade,  ";
        sSQL += "                      ISNULL(ATT.Absent, 0) AS Absence, MAT.Days AS Required, ISNULL(SW.MWarning, 0) AS Warning  ";
        sSQL += "FROM         Reg_Applications AS A INNER JOIN  ";
        sSQL += "                      Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN  ";
        sSQL += "                      Reg_Grade_Header AS GH ON A.lngStudentNumber = GH.lngStudentNumber INNER JOIN  ";
        sSQL += "                      Reg_Specializations AS M ON GH.strDegree = M.strDegree AND GH.strMajor = M.strSpecialization INNER JOIN  ";
        sSQL += "                      Reg_Faculty AS F ON M.FacultyID = F.FacultyID INNER JOIN  ";
        sSQL += "                          (SELECT     intStudyYear, byteSemester, byteShift, strCourse, byteClass,curDay1, curDay2, curDay3, curDay4, curDay5, curDay6, curDay7,(CASE WHEN byteSemester < 3 THEN 14 ELSE 7 END) as Weeks, (curDay1 + curDay2 + curDay3 + curDay4 + curDay5 + curDay6 + curDay7)  ";
        sSQL += "                                                   * (CASE WHEN byteSemester < 3 THEN 14 ELSE 7 END) AS Days  ";
        sSQL += "                            FROM          Reg_Available_Courses_Hours AS AVH) AS MAT ON GH.intStudyYear = MAT.intStudyYear AND GH.byteSemester = MAT.byteSemester AND  ";
        sSQL += "                      GH.byteShift = MAT.byteShift AND GH.strCourse = MAT.strCourse AND GH.byteClass = MAT.byteClass LEFT OUTER JOIN  ";
        sSQL += "                          (SELECT     intStudyYear, byteSemester, byteShift, strCourse, byteClass, lngStudentNumber, MAX(byteWarningType) AS MWarning  ";
        sSQL += "                            FROM          Reg_Students_Warning AS W  ";
        sSQL += "                            GROUP BY intStudyYear, byteSemester, byteShift, strCourse, byteClass, lngStudentNumber) AS SW ON GH.intStudyYear = SW.intStudyYear AND  ";
        sSQL += "                      GH.byteSemester = SW.byteSemester AND GH.byteShift = SW.byteShift AND GH.strCourse = SW.strCourse AND GH.byteClass = SW.byteClass AND  ";
        sSQL += "                      GH.lngStudentNumber = SW.lngStudentNumber LEFT OUTER JOIN  ";
        sSQL += "                          (SELECT     AT.intStudyYear, AT.byteSemester, AT.byteShift, AT.strCourse, AT.byteClass, AT.lngStudentNumber, SUM(ATS.curFactor) AS Absent  ";
        sSQL += "                            FROM          Reg_Attendance AS AT INNER JOIN  ";
        sSQL += "                                                   Lkp_Att_Status AS ATS ON AT.byteAttStatus = ATS.byteAttStatus  ";
        sSQL += "                            WHERE      (AT.byteAttStatus = 3 OR  ";
        sSQL += "                                                   AT.byteAttStatus = 4 OR  ";
        sSQL += "                                                   AT.byteAttStatus = 5 OR  ";
        sSQL += "                                                   AT.byteAttStatus = 10 OR  ";
        sSQL += "                                                   AT.byteAttStatus = 11 OR  ";
        sSQL += "                                                   AT.byteAttStatus = 12) AND (AT.dateAttendance BETWEEN '" + fromDate.Text + "' AND '" + toDate.Text + "')  ";
        sSQL += "                            GROUP BY AT.intStudyYear, AT.byteSemester, AT.byteShift, AT.strCourse, AT.byteClass, AT.lngStudentNumber) AS ATT ON GH.intStudyYear = ATT.intStudyYear AND  ";
        sSQL += "                       GH.byteSemester = ATT.byteSemester AND GH.byteShift = ATT.byteShift AND GH.strCourse = ATT.strCourse AND GH.byteClass = ATT.byteClass AND  ";
        sSQL += "                      GH.lngStudentNumber = ATT.lngStudentNumber  ";
        sSQL += "WHERE     (GH.intStudyYear = " + iYear + ") AND (GH.byteSemester = " + iSem + ")  ";
        sSQL += "ORDER BY Name, Course  ";

      }
      else
      {
        sSQL = "SELECT     GH.lngStudentNumber AS SID, SD.strLastDescEn AS Name, F.FacultyName AS Faculty, M.strCaption AS Major, GH.strCourse AS Course, GH.strGrade AS Grade,  ";
        sSQL += "                      ISNULL(ATT.Absent, 0) AS Absence, MAT.Days AS Required, ISNULL(SW.MWarning, 0) AS Warning  ";
        sSQL += "FROM         Reg_Applications AS A INNER JOIN  ";
        sSQL += "                      Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN  ";
        sSQL += "                      Reg_Grade_Header AS GH ON A.lngStudentNumber = GH.lngStudentNumber INNER JOIN  ";
        sSQL += "                      Reg_Specializations AS M ON GH.strDegree = M.strDegree AND GH.strMajor = M.strSpecialization INNER JOIN  ";
        sSQL += "                      Reg_Faculty AS F ON M.FacultyID = F.FacultyID INNER JOIN  ";
        sSQL += "                          (SELECT     intStudyYear, byteSemester, byteShift, strCourse, byteClass,curDay1, curDay2, curDay3, curDay4, curDay5, curDay6, curDay7,(CASE WHEN byteSemester < 3 THEN 14 ELSE 7 END) as Weeks, (curDay1 + curDay2 + curDay3 + curDay4 + curDay5 + curDay6 + curDay7)  ";
        sSQL += "                                                   * (CASE WHEN byteSemester < 3 THEN 14 ELSE 7 END) AS Days  ";
        sSQL += "                            FROM          Reg_Available_Courses_Hours AS AVH) AS MAT ON GH.intStudyYear = MAT.intStudyYear AND GH.byteSemester = MAT.byteSemester AND  ";
        sSQL += "                      GH.byteShift = MAT.byteShift AND GH.strCourse = MAT.strCourse AND GH.byteClass = MAT.byteClass LEFT OUTER JOIN  ";
        sSQL += "                          (SELECT     intStudyYear, byteSemester, byteShift, strCourse, byteClass, lngStudentNumber, MAX(byteWarningType) AS MWarning  ";
        sSQL += "                            FROM          Reg_Students_Warning AS W  ";
        sSQL += "                            GROUP BY intStudyYear, byteSemester, byteShift, strCourse, byteClass, lngStudentNumber) AS SW ON GH.intStudyYear = SW.intStudyYear AND  ";
        sSQL += "                      GH.byteSemester = SW.byteSemester AND GH.byteShift = SW.byteShift AND GH.strCourse = SW.strCourse AND GH.byteClass = SW.byteClass AND  ";
        sSQL += "                      GH.lngStudentNumber = SW.lngStudentNumber LEFT OUTER JOIN  ";
        sSQL += "                          (SELECT     AT.intStudyYear, AT.byteSemester, AT.byteShift, AT.strCourse, AT.byteClass, AT.lngStudentNumber, SUM(ATS.curFactor) AS Absent  ";
        sSQL += "                            FROM          Reg_Attendance AS AT INNER JOIN  ";
        sSQL += "                                                   Lkp_Att_Status AS ATS ON AT.byteAttStatus = ATS.byteAttStatus  ";
        sSQL += "                            WHERE      (AT.byteAttStatus = 3 OR  ";
        sSQL += "                                                   AT.byteAttStatus = 4 OR  ";
        sSQL += "                                                   AT.byteAttStatus = 5 OR  ";
        sSQL += "                                                   AT.byteAttStatus = 10 OR  ";
        sSQL += "                                                   AT.byteAttStatus = 11 OR  ";
        sSQL += "                                                   AT.byteAttStatus = 12) AND (AT.dateAttendance BETWEEN '"+fromDate.Text+"' AND '"+toDate.Text+"')  ";
        sSQL += "                            GROUP BY AT.intStudyYear, AT.byteSemester, AT.byteShift, AT.strCourse, AT.byteClass, AT.lngStudentNumber) AS ATT ON GH.intStudyYear = ATT.intStudyYear AND  ";
        sSQL += "                       GH.byteSemester = ATT.byteSemester AND GH.byteShift = ATT.byteShift AND GH.strCourse = ATT.strCourse AND GH.byteClass = ATT.byteClass AND  ";
        sSQL += "                      GH.lngStudentNumber = ATT.lngStudentNumber  ";
        sSQL += "WHERE     (GH.intStudyYear = "+iYear+") AND (GH.byteSemester = "+iSem+ ") AND F.FacultyID = "+ddlfaculty.SelectedValue+" ";
        sSQL += "ORDER BY Name, Course  ";

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

        protected void ddlRegTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                Campus = InitializeModule.EnumCampus.Males;
            }
            else
            {
                Campus = InitializeModule.EnumCampus.Females;
            }            
            int iRegTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
            int iYear, iSem;
            iYear = LibraryMOD.SeperateTerm(iRegTerm, out iSem);

            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("SELECT intStudyYear, byteSemester, DATEADD(Day, 1, dateEndRegistration) AS AttendanceStart, DATEADD(Week, (CASE WHEN byteSemester < 3 THEN 14 ELSE 7 END), dateStartSemester) AS AttendanceEnd FROM Reg_Semesters where intStudyYear=@intStudyYear and byteSemester=@byteSemester", sc);
            cmd.Parameters.AddWithValue("@intStudyYear", iYear);
            cmd.Parameters.AddWithValue("@byteSemester", iSem);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {

                    if (dt.Rows[0]["AttendanceStart"] is DBNull || dt.Rows[0]["AttendanceStart"].ToString() == "")
                    {
                        fromDate.Text = "";
                    }
                    else
                    {
                        string dob = dt.Rows[0]["AttendanceStart"].ToString();
                        DateTime date4;
                        string dateString = dob;
                        bool result = DateTime.TryParse(dateString, out date4);
                        if (result == false)
                        {
                            fromDate.Text = "";
                        }
                        else if (result == true)
                        {
                            fromDate.Text = date4.ToString("yyyy-MM-dd");
                        }
                    }

                    if (dt.Rows[0]["AttendanceEnd"] is DBNull || dt.Rows[0]["AttendanceEnd"].ToString() == "")
                    {
                        toDate.Text = "";
                    }
                    else
                    {                       
                        string dob1 = dt.Rows[0]["AttendanceEnd"].ToString();
                        DateTime date41;
                        string dateString1 = dob1;
                        bool result1 = DateTime.TryParse(dateString1, out date41);
                        if (result1 == false)
                        {
                            toDate.Text = "";
                        }
                        else if (result1 == true)
                        {
                            toDate.Text = date41.ToString("yyyy-MM-dd");
                        }
                    }
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
    }
}
