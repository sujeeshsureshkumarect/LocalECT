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
  public partial class Registered_Tracking : System.Web.UI.Page
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

        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration_Tracking,
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

      sSQL = " SELECT DISTINCT  RBS.iYear * 10 + RBS.Sem AS RTerm, A.intStudyYear * 10 + A.byteSemester AS InTerm, dbo.GetStType(RBS.iYear * 10 + RBS.Sem, A.intStudyYear * 10 + A.byteSemester, R.RIn, R.RStatus) AS STType, ";
      sSQL += " '"+GenderExt+"' + CONVERT(VARCHAR, SD.iUnifiedID) AS UID, A.lngStudentNumber AS SID, SD.strLastDescEn AS Name, '" + Gender+"' AS Gender, N.strNationalityDescEn AS Nationality, C.strCityDescEn AS City, E.strEmirateEn AS Emirate, DATEDIFF(year, SD.dateBirth, RS.dateStartSemester) ";
      sSQL += " AS AGE, SD.isWorking, CM.strCaption AS CMajor, ISNULL(RM.strCaption, CM.strCaption) AS RTMajor, RBS.MCRS, RBS.FCRS, RBS.MHRS, RBS.FHRS, A.intGraduationYear * 10 + A.byteGraduationSemester AS OTerm, ";
      sSQL += " S.strReasonDesc AS OStatus, R.Ref, R.RIn, R.RMajor, R.ROut, R.RStatus, MEC.strCert, MEC.Mark, Q.strCertificateSource AS CertSource, CONVERT(VARCHAR, DAY(Q.dateENG)) + '-' + CONVERT(VARCHAR, MONTH(Q.dateENG)) ";
      sSQL += " + '-' + CONVERT(VARCHAR, YEAR(Q.dateENG)) AS CertDate, CONVERT(VARCHAR, DAY(CH.dateCreate)) +'-' + CONVERT(VARCHAR, MONTH(CH.dateCreate)) + '-' + CONVERT(VARCHAR, YEAR(CH.dateCreate)) AS RegDate, ";
      sSQL += " ISNULL(RM.FacultyID, CM.FacultyID) AS Faculty FROM Lkp_Cities AS C INNER JOIN Lkp_Emirates AS E ON C.byteEmirate = E.byteEmirate RIGHT OUTER JOIN Reg_Student_Qualifications AS Q RIGHT OUTER JOIN MaxEngCertMark AS MEC ON Q.lngSerial = MEC.lngSerial AND Q.sngGrade = MEC.Mark RIGHT OUTER JOIN ";
      sSQL += " Reg_Both_Side AS RBS INNER JOIN Reg_Students_Data AS SD INNER JOIN Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN  Reg_Specializations AS CM ON A.strCollege = CM.strCollege AND A.strDegree = CM.strDegree AND A.strSpecialization = CM.strSpecialization ON RBS.Student = A.lngStudentNumber INNER JOIN  ";
      sSQL += " Reg_Semesters AS RS ON RBS.iYear = RS.intStudyYear AND RBS.Sem = RS.byteSemester ON MEC.lngSerial = SD.lngSerial LEFT OUTER JOIN Reg_Course_Header AS CH ON RBS.iYear = CH.intStudyYear AND RBS.Sem = CH.byteSemester AND RBS.Student = CH.lngStudentNumber ON C.byteCountry = SD.byteHomeCountry AND ";
      sSQL += " C.byteCity = SD.byteHomeCity LEFT OUTER JOIN Lkp_Nationalities AS N ON SD.byteNationality = N.byteNationality LEFT OUTER JOIN Reg_Specializations AS RM RIGHT OUTER JOIN Reg_Student_Majors AS SM ON RM.strDegree = SM.strDegree AND RM.strSpecialization = SM.strMajor ON RBS.iYear = SM.intStudyYear AND RBS.Sem = SM.byteSemester AND ";
      sSQL += " RBS.Student = SM.lngStudentNumber LEFT OUTER JOIN (SELECT        A0.lngStudentNumber AS Ref, A0.intStudyYear * 10 + A0.byteSemester AS RIn, M0.strCaption AS RMajor, A0.intGraduationYear * 10 + A0.byteGraduationSemester AS ROut, S0.strReasonDesc AS RStatus  FROM   Reg_Applications AS A0 INNER JOIN  Reg_Specializations AS M0 ON A0.strCollege = M0.strCollege AND A0.strDegree = M0.strDegree AND A0.strSpecialization = M0.strSpecialization INNER JOIN ";
      sSQL += " Lkp_Reasons AS S0 ON A0.byteCancelReason = S0.byteReason) AS R ON A.sReference = R.Ref LEFT OUTER JOIN  Lkp_Reasons AS S ON A.byteCancelReason = S.byteReason WHERE(RBS.iYear * 10 + RBS.Sem BETWEEN "+ddlRegTermFrom.SelectedValue+" AND "+ddlRegTermTo.SelectedValue+") "+Byshifts+" ORDER BY Name, RTerm ";//AND (ISNULL(RM.FacultyID, CM.FacultyID) = 1) 


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
