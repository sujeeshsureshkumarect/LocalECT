using System;
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
  public partial class ACC_Reg_Fees : System.Web.UI.Page
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
        ddlRegTerm.SelectedValue = Session["CurrentYear"].ToString() + Session["CurrentSemester"].ToString();
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

      System.Threading.Thread.Sleep(5000);

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
      if (ddlRptType.SelectedIndex == 1)//details
      {
       
        sSQL = "SELECT R.intStudyYear * 10 + R.byteSemester AS Joined, R.sACC AS ACC, R.sSID AS SID, R.sReference AS RefID, SD.strLastDescEn AS Name, CM.strDisplay AS CMajor,ISNULL(TM.strDisplay, CM.strDisplay) AS TMajor, ISNULL(TM.cCreditFees, CM.cCreditFees) AS HourRate, R.CRS, R.HRS, FT.strFeesTypeEn AS Fees, ";
        sSQL += "F.curDebit AS Debit, F.curCredit AS Credit, F.curVAT AS VAT, CD.sDiscounts,(CASE WHEN CM.iCampus = 1 THEN 'Males' WHEN CM.iCampus = 2 THEN 'Females' ELSE 'Media' END) AS CCampus, R.RJoined, R.RStatus FROM  Acc_Voucher_Payments AS F INNER JOIN Reg_Fees_Type AS FT ON F.byteFeesType = FT.byteFeesType RIGHT OUTER JOIN ";
        sSQL += "(SELECT  CV.iYear AS iRYear, CV.Sem AS iRSem, A.strAccountNo AS sACC, A.lngStudentNumber AS sSID, CV.CRS, CV.HRS, ACC.intDelegation, ACC.curDelegation, A.lngSerial, A.strDegree AS CDegree, A.strSpecialization AS CMajor, A.byteCancelReason, A.bOtherCollege, A.sReference, A.intStudyYear, ";
        sSQL += "A.byteSemester, RF.intStudyYear * 10 + RF.byteSemester AS RJoined, S.strReasonDesc AS RStatus  FROM  Reg_Student_Accounts AS ACC INNER JOIN (SELECT     CB.iYear, CB.Sem, CB.Student, COUNT(C.strCourse) AS CRS, SUM(C.byteCreditHours) AS HRS FROM Course_Balance_View AS CB INNER JOIN ";
        sSQL += "Reg_Courses AS C ON CB.Course = C.strCourse  GROUP BY CB.iYear, CB.Sem, CB.Student) AS CV INNER JOIN Reg_Applications AS A ON CV.Student = A.lngStudentNumber ON ACC.strAccountNo = A.strAccountNo LEFT OUTER JOIN Reg_Applications AS RF LEFT OUTER JOIN  Lkp_Reasons AS S ON RF.byteCancelReason = S.byteReason ON A.sReference = RF.lngStudentNumber ";
        sSQL += "WHERE(CV.iYear = "+iYear+") AND(CV.Sem = "+iSem+")) AS R INNER JOIN  Reg_Specializations AS CM ON R.CDegree = CM.strDegree AND R.CMajor = CM.strSpecialization INNER JOIN Reg_Students_Data AS SD ON R.lngSerial = SD.lngSerial ON F.intFy = R.iRYear AND F.byteFSemester = R.iRSem AND F.strAccount = R.sACC LEFT OUTER JOIN ";
        sSQL += "dbo.Collect_Discounts() AS CD ON R.iRYear = CD.intStudyYear AND R.iRSem = CD.byteSemester AND R.sSID = CD.lngStudentNumber LEFT OUTER JOIN  Reg_Specializations AS TM RIGHT OUTER JOIN Reg_Student_Majors AS SM ON TM.strDegree = SM.strDegree AND TM.strSpecialization = SM.strMajor ON R.iRYear = SM.intStudyYear AND R.iRSem = SM.byteSemester AND R.sSID = SM.lngStudentNumber ";

      }
      else
      {
        

        sSQL = "SELECT R.intStudyYear * 10 + R.byteSemester AS Joined, R.sACC AS ACC, R.sSID AS SID, R.sReference AS RefID, SD.strLastDescEn AS Name, CM.strDisplay AS CMajor, ";
        sSQL += "HS.sngGrade AS HS, N.strNationalityDescEn AS Nationality, ISNULL(TM.strDisplay, CM.strDisplay) AS TMajor, ISNULL(TM.cCreditFees, CM.cCreditFees) AS HourRate, ";
        sSQL += "R.CRS, R.HRS, SUM(F.curDebit) AS Debit, SUM(F.curCredit) AS Credit, SUM(F.curVAT) AS VAT, GPA.GPA AS CGPA, D.strDelegationDescEn AS Sponsor, ";
        sSQL += "R.curDelegation AS SPAmount, CD.sDiscounts, (CASE WHEN CM.iCampus = 1 THEN 'Males' WHEN CM.iCampus = 2 THEN 'Females' ELSE 'Media' END) AS CCampus, ";
        sSQL += "dbo.CleanPhone(SD.strPhone1) AS Phone1, dbo.CleanPhone(SD.strPhone2) AS Phone2, R.RJoined, R.RStatus FROM Acc_Voucher_Payments AS F RIGHT OUTER JOIN ";
        sSQL += "(SELECT CV.iYear AS iRYear, CV.Sem AS iRSem, A.strAccountNo AS sACC, A.lngStudentNumber AS sSID, CV.CRS, CV.HRS, ISNULL(ACC.intDelegation, 0) ";
        sSQL += "AS intDelegation, ISNULL(ACC.curDelegation, 0) AS curDelegation, A.lngSerial, A.strDegree AS CDegree, A.strSpecialization AS CMajor, ";
        sSQL += "A.byteCancelReason, A.bOtherCollege, A.sReference, A.intStudyYear, A.byteSemester, RF.intStudyYear * 10 + RF.byteSemester AS RJoined,S.strReasonDesc AS RStatus ";
        sSQL += "FROM Reg_Student_Accounts AS ACC INNER JOIN (SELECT     CB.iYear, CB.Sem, CB.Student, COUNT(C.strCourse) AS CRS, SUM(C.byteCreditHours) AS HRS ";
        sSQL += "FROM Course_Balance_View AS CB INNER JOIN Reg_Courses AS C ON CB.Course = C.strCourse  GROUP BY CB.iYear, CB.Sem, CB.Student) AS CV INNER JOIN ";
        sSQL += "Reg_Applications AS A ON CV.Student = A.lngStudentNumber ON ACC.strAccountNo = A.strAccountNo LEFT OUTER JOIN Reg_Applications AS RF LEFT OUTER JOIN ";
        sSQL += "Lkp_Reasons AS S ON RF.byteCancelReason = S.byteReason ON A.sReference = RF.lngStudentNumber WHERE(CV.iYear = "+iYear+") AND(CV.Sem = "+iSem+")) AS R INNER JOIN ";
        sSQL += "Lkp_Delegations AS D ON R.intDelegation = D.intDelegation INNER JOIN Reg_Specializations AS CM ON R.CDegree = CM.strDegree AND R.CMajor = CM.strSpecialization INNER JOIN ";
        sSQL += "Lkp_Nationalities AS N INNER JOIN Reg_Students_Data AS SD ON N.byteNationality = SD.byteNationality ON R.lngSerial = SD.lngSerial ON F.intFy = R.iRYear AND F.byteFSemester = R.iRSem AND ";
        sSQL += "F.strAccount = R.sACC LEFT OUTER JOIN HSchools AS HS ON SD.lngSerial = HS.lngSerial LEFT OUTER JOIN dbo.Collect_Discounts() AS CD ON R.iRYear = CD.intStudyYear AND R.iRSem = CD.byteSemester AND R.sSID = CD.lngStudentNumber LEFT OUTER JOIN ";
        sSQL += "Reg_Specializations AS TM RIGHT OUTER JOIN Reg_Student_Majors AS SM ON TM.strDegree = SM.strDegree AND TM.strSpecialization = SM.strMajor ON R.iRYear = SM.intStudyYear AND ";
        sSQL += "R.iRSem = SM.byteSemester AND R.sSID = SM.lngStudentNumber LEFT OUTER JOIN GPA_Until AS GPA ON R.sSID = GPA.lngStudentNumber "; 



      }






      if (txtSID.Text != "")
      {
        sWhere += " AND R.sSID like '%" + txtSID.Text + "%'";
      }



      if (txtACC.Text != "")
      {
        sWhere += " AND R.sACC like '%" + txtACC.Text + "%'";
      }




      sSQL += sWhere;



      if (ddlRptType.SelectedIndex == 0)//Summary
      {

        sSQL +=  "GROUP BY R.intStudyYear * 10 + R.byteSemester, R.sACC, R.sSID, R.sReference, SD.strLastDescEn, CM.strDisplay, HS.sngGrade, N.strNationalityDescEn, ";
        sSQL += "ISNULL(TM.strDisplay, CM.strDisplay), ISNULL(TM.cCreditFees, CM.cCreditFees), R.CRS, R.HRS, GPA.GPA, D.strDelegationDescEn, R.curDelegation, CD.sDiscounts, dbo.CleanPhone(SD.strPhone1), dbo.CleanPhone(SD.strPhone2), R.RJoined, R.RStatus, ";
        sSQL += "(CASE WHEN CM.iCampus = 1 THEN 'Males' WHEN CM.iCampus = 2 THEN 'Females' ELSE 'Media' END) ";

       
      }



      sSQL += " ORDER BY Name";

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
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentCenter,
                InitializeModule.enumPrivilege.ShowPhones, CurrentRole) != true)
                    {
                        dt1.Columns.Remove("Phone1");
                        dt1.Columns.Remove("Phone2");
                    }

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
