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
  public partial class Semester_In_Out : System.Web.UI.Page
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

      }
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
        ddlRegTerm.SelectedValue = iTerm.ToString();

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
        Byshifts = " SD.byteShift = 3 OR SD.byteShift = 4 OR  SD.byteShift = 8";
        GenderExt = "M";
        Gender = "Male";
      }
      else
      {
        Campus = InitializeModule.EnumCampus.Females;
        Byshifts = " SD.byteShift = 1 OR SD.byteShift = 2 OR  SD.byteShift = 9 ";
        GenderExt = "F";
        Gender = "Female";
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

      sSQL = "SELECT        Din.RTerm, Din.RYear, Din.RSem, Din.Faculty , Din.Major , Din.Registered, Din.Continuing, Din.New, SUM((CASE WHEN Status = 'Graduated' OR Status = 'Expected to Graduate' THEN 1 ELSE 0 END)) AS Graduated, SUM((CASE WHEN Status = 'Discontinued' THEN 1 ELSE 0 END)) AS Discontinued, ";
      sSQL += " SUM((CASE WHEN Status = 'Transferred to another institution' THEN 1 ELSE 0 END)) AS Transferred, SUM((CASE WHEN Status = 'Withdrawn' THEN 1 ELSE 0 END)) AS Withdrawn, ";
      sSQL += "  SUM((CASE WHEN Status = 'Dismissed from the College' THEN 1 ELSE 0 END)) AS Dismissed ";
      sSQL += "FROM   (SELECT        A.intGraduationYear * 10 + A.byteGraduationSemester AS OTerm, A.intGraduationYear AS OYear, A.byteGraduationSemester AS OSem, A.lngStudentNumber AS SID, SD.strLastDescEn AS Name, '"+GenderExt+"' AS Gender,  DATEDIFF(year, SD.dateBirth, RS.dateEndSemester) AS AGE, N.strNationalityDescEn AS Nationality, F.FacultyName AS Faculty, M.strCaption AS Major, S.strReasonDesc AS Status ";
      sSQL += " FROM    Reg_Applications AS A INNER JOIN ";
      sSQL += "  Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN ";
      sSQL += " Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN ";
      sSQL += " Lkp_Reasons AS S ON A.byteCancelReason = S.byteReason INNER JOIN  Reg_Faculty AS F ON M.FacultyID = F.FacultyID INNER JOIN Lkp_Nationalities AS N ON SD.byteNationality = N.byteNationality INNER JOIN ";
      sSQL += "  Reg_Semesters AS RS ON A.intGraduationYear = RS.intStudyYear AND A.byteGraduationSemester = RS.byteSemester ";
      sSQL += "  WHERE  ("+Byshifts+") AND (A.intGraduationYear * 10 + A.byteGraduationSemester = "+ddlRegTerm.SelectedValue+") AND (S.strReasonDesc = N'Withdrawn' OR ";
      sSQL += "  S.strReasonDesc = N'Graduated' OR   S.strReasonDesc = N'Dismissed from the College' OR    S.strReasonDesc = N'Discontinued' OR  S.strReasonDesc = N'Expected to Graduate' OR ";
      sSQL += "  S.strReasonDesc = N'Transferred to another institution')) AS DT RIGHT OUTER JOIN ";
      sSQL += "  (SELECT        DT_1.RTerm, DT_1.RYear, DT_1.RSem, F.FacultyName AS Faculty, DT_1.Major, COUNT(DT_1.SID) AS Registered, SUM((CASE WHEN STType <> 'New' THEN 1 ELSE 0 END)) AS Continuing, ";
      sSQL += "   SUM((CASE WHEN STType = 'New' THEN 1 ELSE 0 END)) AS New   FROM            (SELECT DISTINCT ";
      sSQL += "  TOP (100) PERCENT RBS.iYear * 10 + RBS.Sem AS RTerm, RBS.iYear AS RYear, RBS.Sem AS RSem, dbo.GetStType(RBS.iYear * 10 + RBS.Sem, A.intStudyYear * 10 + A.byteSemester, R.RIn, R.RStatus) AS STType, ";
      sSQL += "  A.lngStudentNumber AS SID, SD.strLastDescEn AS Name, 'M' AS Gender, DATEDIFF(year, SD.dateBirth, RS.dateStartSemester) AS AGE, ISNULL(RM.FacultyID, CM.FacultyID) AS Faculty, ISNULL(RM.strCaption, ";
      sSQL += "  CM.strCaption) AS Major, RBS.MCRS + RBS.FCRS AS CRS, RBS.MHRS + RBS.FHRS AS HRS, A.intGraduationYear * 10 + A.byteGraduationSemester AS OTerm ";
      sSQL += "  FROM  Reg_Both_Side AS RBS INNER JOIN  Reg_Students_Data AS SD INNER JOIN  Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN ";
      sSQL += "  Reg_Specializations AS CM ON A.strCollege = CM.strCollege AND A.strDegree = CM.strDegree AND A.strSpecialization = CM.strSpecialization ON RBS.Student = A.lngStudentNumber INNER JOIN ";
      sSQL += "  Reg_Semesters AS RS ON RBS.iYear = RS.intStudyYear AND RBS.Sem = RS.byteSemester LEFT OUTER JOIN    Reg_Specializations AS RM RIGHT OUTER JOIN ";
      sSQL += "  Reg_Student_Majors AS SM ON RM.strDegree = SM.strDegree AND RM.strSpecialization = SM.strMajor ON RBS.iYear = SM.intStudyYear AND RBS.Sem = SM.byteSemester AND ";
      sSQL += "  RBS.Student = SM.lngStudentNumber LEFT OUTER JOIN ";
      sSQL += "  (SELECT  A0.lngStudentNumber AS Ref, A0.intStudyYear * 10 + A0.byteSemester AS RIn, M0.strCaption AS RMajor, A0.intGraduationYear * 10 + A0.byteGraduationSemester AS ROut, ";
      sSQL += "  S0.strReasonDesc AS RStatus    FROM            Reg_Applications AS A0 INNER JOIN ";
      sSQL += " Reg_Specializations AS M0 ON A0.strCollege = M0.strCollege AND A0.strDegree = M0.strDegree AND A0.strSpecialization = M0.strSpecialization INNER JOIN ";
      sSQL += "   Lkp_Reasons AS S0 ON A0.byteCancelReason = S0.byteReason) AS R ON A.sReference = R.Ref  WHERE  ("+Byshifts+") AND (RBS.iYear * 10 + RBS.Sem = "+ddlRegTerm.SelectedValue+")) AS DT_1 INNER JOIN ";
      sSQL += "  Reg_Faculty AS F ON DT_1.Faculty = F.FacultyID ";
      sSQL += "GROUP BY DT_1.RTerm, DT_1.RYear, DT_1.RSem, DT_1.Major, F.FacultyName) AS Din ON DT.OTerm = Din.RTerm AND DT.OYear = Din.RYear AND DT.OSem = Din.RSem AND DT.Faculty = Din.Faculty AND DT.Major = Din.Major ";
      sSQL += "GROUP BY Din.RTerm, Din.RYear, Din.RSem, Din.Faculty, Din.Major, Din.Registered, Din.Continuing, Din.New ";
   

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
