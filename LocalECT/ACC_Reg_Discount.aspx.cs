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
  public partial class ACC_Reg_Discount : System.Web.UI.Page
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

      sSQL = "SELECT R.intStudyYear * 10 + R.byteSemester AS Joined, R.sACC AS ACC, R.sSID AS SID, R.sReference AS RefID, SD.strLastDescEn AS Name, CM.strDisplay AS CMajor, HSchools.sngGrade AS HS, N.strNationalityDescEn AS Nationality, ISNULL(TM.strDisplay, CM.strDisplay) AS TMajor, R.CRS, R.HRS, GPA.GPA AS CGPA,  SP.strDelegationDescEn AS Sponsor, R.curDelegation AS SPAmount,(CASE WHEN CM.iCampus = 1 THEN 'Males' WHEN CM.iCampus = 2 THEN 'Females' ELSE 'Media' END) AS CCampus, R.RJoined, R.ROut, R.RStatus, R.RMajor,  DT.strDiscountDesc AS Discount, ";
      sSQL += "DC.strCategoryEn AS Category, (CASE WHEN D .byteDiscountType = 14 AND CF.byteFeesType = 3 THEN D .curDiscount WHEN D .byteDiscountType = 14 AND CF.byteFeesType <> 3 THEN 0  WHEN D .byteDiscountType = 18 AND CF.byteFeesType = 3 THEN D .curDiscount WHEN D .byteDiscountType = 18 AND CF.byteFeesType <> 3 THEN 0  ELSE (D .curDiscount / 100) END) AS Value, CF.FType AS Fees, CF.curDebit AS Debit,  (CASE WHEN D .byteDiscountType = 14 AND CF.byteFeesType = 3 THEN D .curDiscount  WHEN D .byteDiscountType = 14 AND CF.byteFeesType <> 3 THEN 0  WHEN D .byteDiscountType = 18 AND CF.byteFeesType = 3 THEN D .curDiscount  WHEN D .byteDiscountType = 18 AND CF.byteFeesType <> 3 THEN 0  ELSE (D .curDiscount / 100) * ISNULL(CF.curDebit, 0) END) AS Amount , D.strRemark AS Remark, D.strUserCreate AS CBy, D.dateCreate AS Created, D.LastAudit FROM HSchools RIGHT OUTER JOIN (SELECT CV.iYear AS iRYear, CV.Sem AS iRSem, ISNULL(ACC.strAccountNo, A.strAccountNo) AS sACC, A.lngStudentNumber AS sSID, CV.CRS, CV.HRS,isnull(ACC.intDelegation,0) as intDelegation, isnull(ACC.curDelegation,0) as curDelegation, A.lngSerial, A.strDegree AS CDegree, A.strSpecialization AS CMajor, A.byteCancelReason, A.bOtherCollege,  A.sReference, A.intStudyYear, ";
      sSQL += "A.byteSemester, RF.intStudyYear * 10 + RF.byteSemester AS RJoined,RF.intGraduationYear * 10 + RF.byteGraduationSemester AS ROut, S.strReasonDesc AS RStatus, RM.strDisplay AS RMajor FROM Reg_Applications AS RF LEFT OUTER JOIN Reg_Specializations AS RM ON RF.strCollege = RM.strCollege AND RF.strDegree = RM.strDegree AND RF.strSpecialization = RM.strSpecialization LEFT OUTER JOIN Lkp_Reasons AS S ON RF.byteCancelReason = S.byteReason RIGHT OUTER JOIN (SELECT CB.iYear, CB.Sem, CB.Student, COUNT(C.strCourse) AS CRS, SUM(C.byteCreditHours) AS HRS FROM Course_Balance_View AS CB INNER JOIN Reg_Courses AS C ON CB.Course = C.strCourse GROUP BY CB.iYear, CB.Sem, CB.Student) AS CV INNER JOIN Reg_Applications AS A ON CV.Student = A.lngStudentNumber ON RF.lngStudentNumber = A.sReference LEFT OUTER JOIN Reg_Student_Accounts AS ACC ON A.lngStudentNumber = ACC.lngStudentNumber WHERE (CV.iYear = 2020) AND (CV.Sem = 2)) AS R INNER JOIN Reg_Specializations AS CM ON R.CDegree = CM.strDegree AND R.CMajor = CM.strSpecialization INNER JOIN Lkp_Nationalities AS N INNER JOIN Reg_Students_Data AS SD ON N.byteNationality = SD.byteNationality ON R.lngSerial = SD.lngSerial INNER JOIN Reg_Student_Discounts AS D ON R.iRYear =  ";
      sSQL += "D.intStudyYear AND R.iRSem = D.byteSemester AND R.sSID = D.lngStudentNumber INNER JOIN Reg_Discounts AS DT ON D.byteDiscountType = DT.byteDiscountType INNER JOIN Reg_Discounts_Categories AS DC ON D.byteDiscountType = DC.byteDiscountType AND D.byteDiscountCategory = DC.byteDiscountCategory INNER JOIN Lkp_Delegations AS SP ON R.intDelegation = SP.intDelegation LEFT OUTER JOIN (SELECT F.intFy, F.byteFSemester, F.strAccount, F.byteFeesType, FT.strFeesTypeEn AS FType, F.curDebit FROM Acc_Voucher_Payments AS F INNER JOIN Reg_Fees_Type AS FT ON F.byteFeesType = FT.byteFeesType WHERE      (F.byteFeesType = 3) OR (F.byteFeesType = 36)) AS CF ON R.iRYear = CF.intFy AND R.iRSem = CF.byteFSemester AND R.sACC = CF.strAccount ON HSchools.lngSerial = SD.lngSerial LEFT OUTER JOIN Reg_Specializations AS TM RIGHT OUTER JOIN Reg_Student_Majors AS SM ON TM.strDegree = SM.strDegree AND TM.strSpecialization = SM.strMajor ON R.iRYear = SM.intStudyYear AND R.iRSem = SM.byteSemester AND R.sSID = SM.lngStudentNumber LEFT OUTER JOIN GPA_Until AS GPA ON R.sSID = GPA.lngStudentNumber ";

      if (txtSID.Text != "")
      {
        sWhere += " AND R.sSID like '%" + txtSID.Text + "%' ";
      }

      if (txtACC.Text != "")
      {
        sWhere += " AND R.sACC like '%" + txtACC.Text + "%' ";
      }

      sSQL += sWhere;

      sSQL += "AND D.bActive = "+ddlRptType.SelectedValue+" ORDER BY Name";

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
