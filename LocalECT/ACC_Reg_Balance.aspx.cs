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
  public partial class ACC_Reg_Balance : System.Web.UI.Page
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

      if (ddlRptType.SelectedItem.Value == "1")
      {
        sSQL = "SELECT  R.intStudyYear * 10 + R.byteSemester AS Joined, R.sAcc AS ACC, R.sSID AS SID, R.sReference AS RefID, R.strLastDescEn AS Name, HS.sngGrade AS HS, ";
        sSQL += "N.strNationalityDescEn AS Nationality, CM.strDisplay AS CMajor, ISNULL(TM.strDisplay, CM.strDisplay) AS TMajor, ISNULL(TM.cCreditFees, CM.cCreditFees) ";
        sSQL += "AS HRate, dbo.Completed_Successfully(R.sSID," + iPYear + ", " + iPSem + ", ISNULL(SM.strDegree, R.CDegree), ISNULL(SM.strMajor, R.CMajor)) AS Completed, R.CRS, R.HRS, LT.LTR, ";
        sSQL += "GPA.GPA AS CGPA, D.strDelegationDescEn AS Sponsor, R.curDelegation AS SPAmount, LP.LastDate AS LPMT, ";
        sSQL += "(CASE WHEN CM.iCampus = 1 THEN 'Males' WHEN CM.iCampus = 2 THEN 'Females' ELSE 'Media' END) AS CCampus, R.RJoined, R.RStatus, ";
        sSQL += "R.sECTemail AS ECTemail, FC.sFinDesc AS FinDesc, B.Debit, B.Credit, B.VAT, CD.sDiscounts AS Discounts ";
        sSQL += "FROM(SELECT RBS.iYear AS iRYear, RBS.Sem AS iRSem, ACC.strAccountNo AS sAcc, A.lngStudentNumber AS sSID, RBS.MCRS + RBS.FCRS AS CRS, ";
        sSQL += "RBS.MHRS + RBS.FHRS AS HRS, ACC.intDelegation, ACC.curDelegation, A.strDegree AS CDegree, A.strSpecialization AS CMajor, A.byteCancelReason, ";
        sSQL += "A.bOtherCollege, A.sReference, A.intStudyYear, A.byteSemester, RF.intStudyYear * 10 + RF.byteSemester AS RJoined, S.strReasonDesc AS RStatus, ";
        sSQL += "ACC.intFinanceCategory, SD.strLastDescEn, A.lngSerial, SD.sECTemail, SD.byteNationality, SD.iUnifiedID ";
        sSQL += "FROM Reg_Student_Accounts AS ACC INNER JOIN ";
        sSQL += "Reg_Applications AS A ON ACC.strAccountNo = A.strAccountNo INNER JOIN ";
        sSQL += "Reg_Both_Side AS RBS ON A.lngStudentNumber = RBS.Student INNER JOIN ";
        sSQL += "Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial LEFT OUTER JOIN ";
        sSQL += "Reg_Applications AS RF LEFT OUTER JOIN ";
        sSQL += "Lkp_Reasons AS S ON RF.byteCancelReason = S.byteReason ON A.sReference = RF.lngStudentNumber ";
        sSQL += "WHERE(RBS.iYear = "+iYear+") AND(RBS.Sem = "+iSem+")) AS R INNER JOIN ";
        sSQL += "Reg_Specializations AS CM ON R.CDegree = CM.strDegree AND R.CMajor = CM.strSpecialization INNER JOIN ";
        sSQL += "Acc_Finance_Category AS FC ON R.intFinanceCategory = FC.iFinCategory INNER JOIN ";
        sSQL += "Lkp_Nationalities AS N ON R.byteNationality = N.byteNationality INNER JOIN ";
        sSQL += "AccBalanceSemBothSide AS B ON R.iRYear = B.intFy AND R.iRSem = B.byteFSemester AND R.sSID = B.lngStudentNumber LEFT OUTER JOIN ";
        sSQL += "dbo.Collect_Discounts() AS CD ON R.iRYear = CD.intStudyYear AND R.iRSem = CD.byteSemester AND R.sSID = CD.lngStudentNumber LEFT OUTER JOIN ";
        sSQL += "(SELECT     TOP(100) PERCENT SDT.iUnifiedID, MAX(DISTINCT CB.iYear * 10 + CB.Sem) AS LTR ";
        sSQL += "FROM          Course_Balance_View AS CB INNER JOIN ";
        sSQL += "Reg_Applications AS A ON CB.Student = A.lngStudentNumber INNER JOIN ";
        sSQL += "Reg_Students_Data AS SDT ON A.lngSerial = SDT.lngSerial ";
        sSQL += "WHERE(CB.iYear * 10 + CB.Sem < "+ iRegTerm + ") ";
        sSQL += "GROUP BY SDT.iUnifiedID ";
        sSQL += "HAVING(SDT.iUnifiedID <> 0)) AS LT ON R.iUnifiedID = LT.iUnifiedID LEFT OUTER JOIN ";
        sSQL += "HSchools AS HS ON R.lngSerial = HS.lngSerial LEFT OUTER JOIN ";
        sSQL += "Lkp_Delegations AS D ON R.intDelegation = D.intDelegation LEFT OUTER JOIN ";
        sSQL += "LastPayment AS LP ON R.iRYear = LP.intFy AND R.iRSem = LP.byteFSemester AND R.sAcc = LP.strAccountNo LEFT OUTER JOIN ";
        sSQL += "Reg_Specializations AS TM RIGHT OUTER JOIN ";
        sSQL += "Reg_Student_Majors AS SM ON TM.strDegree = SM.strDegree AND TM.strSpecialization = SM.strMajor ON R.iRYear = SM.intStudyYear AND ";
        sSQL += "R.iRSem = SM.byteSemester AND R.sSID = SM.lngStudentNumber LEFT OUTER JOIN ";
        sSQL += "GPA_Until AS GPA ON R.sSID = GPA.lngStudentNumber ";
         }
        else
        {
        sSQL = "SELECT  R.intStudyYear * 10 + R.byteSemester AS Joined, R.sAcc AS ACC, R.sSID AS SID, R.sReference AS RefID, R.strLastDescEn AS Name, HS.sngGrade AS HS, ";
        sSQL += "N.strNationalityDescEn AS Nationality, CM.strDisplay AS CMajor, ISNULL(TM.strDisplay, CM.strDisplay) AS TMajor, ISNULL(TM.cCreditFees, CM.cCreditFees) ";
        sSQL += "AS HRate, dbo.Completed_Successfully(R.sSID," + iPYear + ", " + iPSem + ", ISNULL(SM.strDegree, R.CDegree), ISNULL(SM.strMajor, R.CMajor)) AS Completed, R.CRS, R.HRS, LT.LTR, ";
        sSQL += "GPA.GPA AS CGPA, D.strDelegationDescEn AS Sponsor, R.curDelegation AS SPAmount, LP.LastDate AS LPMT, ";
        sSQL += "(CASE WHEN CM.iCampus = 1 THEN 'Males' WHEN CM.iCampus = 2 THEN 'Females' ELSE 'Media' END) AS CCampus, R.RJoined, R.RStatus, ";
        sSQL += "R.sECTemail AS ECTemail, FC.sFinDesc AS FinDesc, B.Debit, B.Credit, B.VAT, CD.sDiscounts AS Discounts ";
        sSQL += "FROM(SELECT     RBS.iYear AS iRYear, RBS.Sem AS iRSem, ACC.strAccountNo AS sAcc, A.lngStudentNumber AS sSID, RBS.MCRS + RBS.FCRS AS CRS, ";
        sSQL += "RBS.MHRS + RBS.FHRS AS HRS, ACC.intDelegation, ACC.curDelegation, A.strDegree AS CDegree, A.strSpecialization AS CMajor, A.byteCancelReason, ";
        sSQL += "A.bOtherCollege, A.sReference, A.intStudyYear, A.byteSemester, RF.intStudyYear * 10 + RF.byteSemester AS RJoined, S.strReasonDesc AS RStatus, ";
        sSQL += "ACC.intFinanceCategory, SD.strLastDescEn, A.lngSerial, SD.sECTemail, SD.byteNationality, SD.iUnifiedID ";
        sSQL += "FROM   Reg_Student_Accounts AS ACC INNER JOIN ";
        sSQL += "Reg_Applications AS A ON ACC.strAccountNo = A.strAccountNo INNER JOIN ";
        sSQL += "Reg_Both_Side AS RBS ON A.lngStudentNumber = RBS.Student INNER JOIN ";
        sSQL += "Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial LEFT OUTER JOIN ";
        sSQL += "Reg_Applications AS RF LEFT OUTER JOIN ";
        sSQL += "Lkp_Reasons AS S ON RF.byteCancelReason = S.byteReason ON A.sReference = RF.lngStudentNumber ";
        sSQL += "WHERE(RBS.iYear = "+iYear+") AND(RBS.Sem = "+iSem+")) AS R INNER JOIN ";
        sSQL += "Reg_Specializations AS CM ON R.CDegree = CM.strDegree AND R.CMajor = CM.strSpecialization INNER JOIN ";
        sSQL += "Acc_Finance_Category AS FC ON R.intFinanceCategory = FC.iFinCategory INNER JOIN ";
        sSQL += "Lkp_Nationalities AS N ON R.byteNationality = N.byteNationality INNER JOIN ";
        sSQL += "AccBalanceSTBothSide AS B ON R.sSID = B.lngStudentNumber LEFT OUTER JOIN ";
        sSQL += "dbo.Collect_Discounts() AS CD ON R.iRYear = CD.intStudyYear AND R.iRSem = CD.byteSemester AND R.sSID = CD.lngStudentNumber LEFT OUTER JOIN ";
        sSQL += "(SELECT     TOP(100) PERCENT SDT.iUnifiedID, MAX(DISTINCT CB.iYear * 10 + CB.Sem) AS LTR ";
        sSQL += "FROM   Course_Balance_View AS CB INNER JOIN ";
        sSQL += "Reg_Applications AS A ON CB.Student = A.lngStudentNumber INNER JOIN  ";
        sSQL += "Reg_Students_Data AS SDT ON A.lngSerial = SDT.lngSerial ";
        sSQL += "WHERE(CB.iYear * 10 + CB.Sem < "+iRegTerm+") ";
        sSQL += "GROUP BY SDT.iUnifiedID ";
        sSQL += "HAVING(SDT.iUnifiedID <> 0)) AS LT ON R.iUnifiedID = LT.iUnifiedID LEFT OUTER JOIN ";
        sSQL += "HSchools AS HS ON R.lngSerial = HS.lngSerial LEFT OUTER JOIN ";
        sSQL += "Lkp_Delegations AS D ON R.intDelegation = D.intDelegation LEFT OUTER JOIN ";
        sSQL += "LastPayment AS LP ON R.iRYear = LP.intFy AND R.iRSem = LP.byteFSemester AND R.sAcc = LP.strAccountNo LEFT OUTER JOIN ";
        sSQL += "Reg_Specializations AS TM RIGHT OUTER JOIN ";
        sSQL += "Reg_Student_Majors AS SM ON TM.strDegree = SM.strDegree AND TM.strSpecialization = SM.strMajor ON R.iRYear = SM.intStudyYear AND ";
        sSQL += "R.iRSem = SM.byteSemester AND R.sSID = SM.lngStudentNumber LEFT OUTER JOIN ";
        sSQL += "GPA_Until AS GPA ON R.sSID = GPA.lngStudentNumber ";

        }

     

      if (txtSID.Text != "")
      {
        sWhere += " AND R.sSID like '%" + txtSID.Text + "%' ";
      }

      if (txtACC.Text != "")
      {
        sWhere += " AND R.sACC like '%" + txtACC.Text + "%' ";
      }

      sSQL += sWhere;

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
