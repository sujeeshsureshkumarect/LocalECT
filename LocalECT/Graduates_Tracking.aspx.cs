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
  public partial class Graduates_Tracking : System.Web.UI.Page
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

        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Graduaes_Tracking,
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

      string Byshifts ;
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

            //sSQL = "SELECT   A.intStudyYear AS InYear, A.intStudyYear * 10 + A.byteSemester AS InTerm, FTRMajor.FTR, dbo.GetStType(A.intStudyYear * 10 + A.byteSemester, A.intStudyYear * 10 + A.byteSemester, R.RIn, R.RStatus) AS STType,  ";
            //sSQL += " '" + GenderExt + "' + CONVERT(VARCHAR, SD.iUnifiedID) AS UID,A.lngStudentNumber AS SID, SD.strLastDescEn AS Name, '" + Gender + "' AS Gender, H.sngGrade AS HS, E.strCert AS ENG, E.Mark AS Score, G.GPA AS CGPA, N.strNationalityDescEn AS Nationality, M.strCaption AS InMajor,  ";
            //sSQL += "  A.intGraduationYear AS OYear, A.intGraduationYear * 10 + A.byteGraduationSemester AS OTerm, S.strReasonDesc AS OStatus, LT.MaxYear AS LTR, CM.strCaption AS CMajor, R.Ref, R.RIn, R.RMajor, R.ROut, R.RStatus  ";
            //sSQL += "FROM  Lkp_Nationalities AS N INNER JOIN  Reg_Students_Data AS SD INNER JOIN  Reg_Applications AS A ON SD.lngSerial = A.lngSerial ON N.byteNationality = SD.byteNationality INNER JOIN  ";
            //sSQL += " Reg_Specializations AS CM ON A.strCollege = CM.strCollege AND A.strDegree = CM.strDegree AND A.strSpecialization = CM.strSpecialization INNER JOIN  ";
            //sSQL += "  Last_Time_Registered AS LT ON A.lngStudentNumber = LT.Student INNER JOIN  FTRMajor ON A.lngStudentNumber = FTRMajor.Student INNER JOIN  ";
            //sSQL += "  Reg_Specializations AS M ON FTRMajor.strDegree = M.strDegree AND FTRMajor.strMajor = M.strSpecialization LEFT OUTER JOIN  ";
            //sSQL += "  MaxEngCertMark AS E ON A.lngStudentNumber = E.lngStudentNumber LEFT OUTER JOIN  ";
            //sSQL += "  GPA_Until AS G ON A.lngStudentNumber = G.lngStudentNumber LEFT OUTER JOIN  ";
            //sSQL += "  HSchools AS H ON SD.lngSerial = H.lngSerial LEFT OUTER JOIN  ";
            //sSQL += "   (SELECT        A0.lngStudentNumber AS Ref, A0.intStudyYear * 10 + A0.byteSemester AS RIn, M0.strCaption AS RMajor, A0.intGraduationYear * 10 + A0.byteGraduationSemester AS ROut, S0.strReasonDesc AS RStatus  ";
            //sSQL += "   FROM  Reg_Applications AS A0 INNER JOIN  ";
            //sSQL += "   Reg_Specializations AS M0 ON A0.strCollege = M0.strCollege AND A0.strDegree = M0.strDegree AND A0.strSpecialization = M0.strSpecialization INNER JOIN  ";
            //sSQL += "  Lkp_Reasons AS S0 ON A0.byteCancelReason = S0.byteReason) AS R ON A.sReference = R.Ref LEFT OUTER JOIN  ";
            //sSQL += "       Lkp_Reasons AS S ON A.byteCancelReason = S.byteReason  ";
            //sSQL += "WHERE        (A.byteCancelReason = 3 OR  ";
            //sSQL += "   A.byteCancelReason = 25) AND (A.intGraduationYear * 10 + A.byteGraduationSemester BETWEEN " + ddlRegTermFrom.SelectedValue + " AND " + ddlRegTermTo.SelectedValue + ") AND (FTRMajor.strDegree = '1' OR  ";
            //sSQL += "            FTRMajor.strDegree = '3') AND (FTRMajor.strMajor <> '999') " + Byshifts + "  ";

            sSQL  = " SELECT        A.intStudyYear AS InYear, A.intStudyYear * 10 + A.byteSemester AS InTerm, dbo.GetStType(A.intStudyYear * 10 + A.byteSemester, A.intStudyYear * 10 + A.byteSemester, R.RIn, R.RStatus) AS STType, '" + GenderExt + "' + CONVERT(VARCHAR,  ";
            sSQL += "                          SD.iUnifiedID) AS UID, A.lngStudentNumber AS SID, SD.strLastDescEn AS Name, '" + Gender + "' AS Gender, H.sngGrade AS HS, E.strCert AS ENG, E.Mark AS Score, G.GPA AS CGPA, N.strNationalityDescEn AS Nationality,  ";
            sSQL += "                          A.intGraduationYear AS OYear, A.intGraduationYear * 10 + A.byteGraduationSemester AS OTerm, S.strReasonDesc AS OStatus, LT.MaxYear AS LTR, CM.strCaption AS CMajor, R.Ref, R.RIn, R.RMajor, R.ROut, R.RStatus  ";
            sSQL += " FROM            MaxEngCertMark AS E RIGHT OUTER JOIN  ";
            sSQL += "                          Lkp_Nationalities AS N INNER JOIN  ";
            sSQL += "                          Reg_Students_Data AS SD INNER JOIN  ";
            sSQL += "                          Reg_Applications AS A ON SD.lngSerial = A.lngSerial ON N.byteNationality = SD.byteNationality INNER JOIN  ";
            sSQL += "                          Reg_Specializations AS CM ON A.strCollege = CM.strCollege AND A.strDegree = CM.strDegree AND A.strSpecialization = CM.strSpecialization INNER JOIN  ";
            sSQL += "                          Last_Time_Registered AS LT ON A.lngStudentNumber = LT.Student ON E.lngStudentNumber = A.lngStudentNumber LEFT OUTER JOIN  ";
            sSQL += "                          GPA_Until AS G ON A.lngStudentNumber = G.lngStudentNumber LEFT OUTER JOIN  ";
            sSQL += "                          HSchools AS H ON SD.lngSerial = H.lngSerial LEFT OUTER JOIN  ";
            sSQL += "                              (SELECT        A0.lngStudentNumber AS Ref, A0.intStudyYear * 10 + A0.byteSemester AS RIn, M0.strCaption AS RMajor, A0.intGraduationYear * 10 + A0.byteGraduationSemester AS ROut, S0.strReasonDesc AS RStatus  ";
            sSQL += "                                FROM            Reg_Applications AS A0 INNER JOIN  ";
            sSQL += "                                                          Reg_Specializations AS M0 ON A0.strCollege = M0.strCollege AND A0.strDegree = M0.strDegree AND A0.strSpecialization = M0.strSpecialization INNER JOIN  ";
            sSQL += "                                                          Lkp_Reasons AS S0 ON A0.byteCancelReason = S0.byteReason) AS R ON A.sReference = R.Ref LEFT OUTER JOIN  ";
            sSQL += "                          Lkp_Reasons AS S ON A.byteCancelReason = S.byteReason  ";
            sSQL += " WHERE        (A.byteCancelReason = 3 or A.byteCancelReason = 25) AND (A.intGraduationYear * 10 + A.byteGraduationSemester BETWEEN " + ddlRegTermFrom.SelectedValue + " AND " + ddlRegTermTo.SelectedValue + ") " + Byshifts + "  ";
            sSQL += " AND (A.strDegree = N'1' OR  ";
            sSQL += "                          A.strDegree = N'3')  ";

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
