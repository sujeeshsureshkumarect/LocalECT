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
  public partial class ACC_Balance_Tracking : System.Web.UI.Page
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
       // ddlRegTerm.SelectedValue = Session["CurrentYear"].ToString() + Session["CurrentSemester"].ToString();
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
          ddlRegTermLTR.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
        }
        int iYear = 0;
        int iSem = 0;
        int iTerm = 0;
        iYear = (int)Session["RegYear"];
        iSem = (int)Session["RegSemester"];
        iTerm = iYear * 10 + iSem;
       // ddlRegTermFrom.SelectedValue = iTerm.ToString();
      //  ddlRegTermTo.SelectedValue = iTerm.ToString();
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

     // string sWhere = " WHERE 1=1";
  

      Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
      SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

      string sSQL = "";

      sSQL = "SELECT     A.intStudyYear * 10 + A.byteSemester AS Joined, AC.strAccountNo AS ACC, A.lngStudentNumber AS SID, SD.strLastDescEn AS Name,  ";
      sSQL += "(CASE WHEN M.iCampus = 1 THEN 'Males' WHEN M.iCampus = 2 THEN 'Females' WHEN M.iCampus = 3 THEN 'Media' END) AS Campus, M.strDisplay AS Major,    ";
      sSQL += " M.intStudyHours AS [Plan], dbo.Completed_Successfully(A.lngStudentNumber, 2020, 2, A.strDegree, A.strSpecialization) AS Completed, R.HRS, R.CRS,    ";
      sSQL += " N.strNationalityDescEn AS Nationality, A.intGraduationYear * 10 + A.byteGraduationSemester AS OTerm, S.strReasonDesc AS Status, ISNULL(LT.MaxYear,       ";
      sSQL += " A.intStudyYear * 10 + A.byteSemester) AS LTR, A.sReference AS Ref, B.Debit, B.Credit, B.VAT, LP.LPMT, dbo.CleanPhone(SD.strPhone1) AS Phone1,       ";
      sSQL += " dbo.CleanPhone(SD.strPhone2) AS Phone2, SP.strDelegationDescEn AS Sponsor, AC.curDelegation AS SPAmount, SD.sECTemail, FPCQ.FPC      ";
      sSQL += "FROM Lkp_Delegations AS SP RIGHT OUTER JOIN  ";
      sSQL += " (SELECT     lngStudentNumber AS STD, SUM(curCredit) AS FPC  ";
      sSQL += "  FROM          ACC_Future_PCheque_BTS      ";
      sSQL += " GROUP BY lngStudentNumber) AS FPCQ RIGHT OUTER JOIN  ";
      sSQL += " Reg_Specializations AS M INNER JOIN  ";
      sSQL += " Reg_Applications AS A INNER JOIN  ";
      sSQL += " Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON M.strCollege = A.strCollege AND M.strDegree = A.strDegree AND   ";
      sSQL += " M.strSpecialization = A.strSpecialization INNER JOIN      ";
      sSQL += " AccBalanceSTBothSide AS B ON A.lngStudentNumber = B.lngStudentNumber INNER JOIN  ";
      sSQL += " Reg_Student_Accounts AS AC ON A.lngStudentNumber = AC.lngStudentNumber ON FPCQ.STD = A.lngStudentNumber LEFT OUTER JOIN ";
      sSQL += " AccLastPaymmentBothSide AS LP ON A.lngStudentNumber = LP.lngStudentNumber LEFT OUTER JOIN      ";
      sSQL += "(SELECT     Student, MHRS + FHRS AS HRS, MCRS + FCRS AS CRS      ";
      sSQL += " FROM  Reg_Both_Side      ";
      sSQL += " WHERE      (iYear = 2020) AND (Sem = 2)) AS R ON A.lngStudentNumber = R.Student LEFT OUTER JOIN  ";
      sSQL += " Last_Time_Registered AS LT ON A.lngStudentNumber = LT.Student LEFT OUTER JOIN  ";
      sSQL += " Lkp_Reasons AS S ON A.byteCancelReason = S.byteReason LEFT OUTER JOIN  ";
      sSQL += " Lkp_Nationalities AS N ON SD.byteNationality = N.byteNationality ON SP.intDelegation = AC.intDelegation  ";
      sSQL += "WHERE     (A.intStudyYear * 10 + A.byteSemester BETWEEN "+ddlRegTermFrom.SelectedValue+" AND "+ddlRegTermTo.SelectedValue+") AND (ISNULL(LT.MaxYear, A.intStudyYear * 10 + A.byteSemester) >= "+ddlRegTermLTR.SelectedValue+") ";
      sSQL += "ORDER BY Name ";
      

      //sSQL += sWhere;

     // sSQL += "AND D.bActive = " + ddlRptType.SelectedValue + " ORDER BY Name";

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
