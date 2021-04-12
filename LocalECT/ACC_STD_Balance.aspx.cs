
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
  public partial class ACC_STD_Balance : System.Web.UI.Page
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
          ddlFromTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
          ddlToTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));

        }
        int iYear = 0;
        int iSem = 0;
        int iTerm = 0;
        iYear = (int)Session["RegYear"];
        iSem = (int)Session["RegSemester"];
        iTerm = iYear * 10 + iSem;
       // ddlRegTerm.SelectedValue = iTerm.ToString();
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
    private string getIDsCondition(string sIDs, string columnname)
    {      
      string sCon = " AND (";
      try
      {
        string[] sSeperated;
        sSeperated = sIDs.Split(';');
        int iCount = sSeperated.Length;



        foreach (string sID in sSeperated)
        {
          sCon += " " + columnname + " like '%" + sID + "%'";
          iCount -= 1;
          if (iCount > 0)
          {
            sCon += " Or";
          }
          else
          {
            sCon += ")";
          }
        }
      }
      catch (Exception exp)
      {
        //Console.WriteLine("{0} Exception caught.", exp);
        //divMsg.InnerText = exp.Message;
      }
      finally
      {



      }



      return sCon;
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
      string sWhere = " WHERE (1=1)";
     // int iRegTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
     // int iYear, iSem;
     // iYear = LibraryMOD.SeperateTerm(iRegTerm, out iSem);
    //  int iPYear, iPSem;
     // iPYear = iYear;
     // iPSem = iSem;
     // if (iSem == 1)
     // {
    //    iPSem = 4;
       // iPYear -= 1;
    //  }
     // else
     // {
    // //   iPSem -= 1;
    //  }

      Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
      SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

      string sSQL = "";

      sSQL = "SELECT     A.lngStudentNumber AS SID, SD.strLastDescEn AS Name, M.strCaption AS Major, AC.strAccountNo AS MainACC, D.strDelegationDescEn AS Sponsor,  ";
      sSQL += " S.strReasonDesc AS Status, BTS.intFy as FYear, BTS.byteFSemester AS FSemester, T.Term, T.LongDesc AS TermDesc, BTS.Debit, BTS.Credit, BTS.VAT, CD.sDiscounts AS Discounts, dbo.CleanPhone(SD.strPhone1) AS Phone1, dbo.CleanPhone(SD.strPhone2) AS Phone2, SD.sECTemail AS Email  ";
      sSQL += " FROM         Lkp_Reasons AS S RIGHT OUTER JOIN  Reg_Applications AS A INNER JOIN  Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN  Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN ";
      sSQL += " Reg_Student_Accounts AS AC ON A.strAccountNo = AC.strAccountNo INNER JOIN   AccBalanceSemBothSide AS BTS INNER JOIN ";
      sSQL += " (SELECT     AcademicYear, Semester, Term, ShortDesc, LongDesc, sTerm FROM localect.ECTDataNew.dbo.Reg_Semester) AS T ON BTS.intFy = T.AcademicYear AND BTS.byteFSemester = T.Semester ON  A.lngStudentNumber = BTS.lngStudentNumber LEFT OUTER JOIN ";
      sSQL += " dbo.Collect_Discounts() AS CD ON BTS.intFy = CD.intStudyYear AND BTS.byteFSemester = CD.byteSemester AND BTS.lngStudentNumber = CD.lngStudentNumber ON S.byteReason = A.byteCancelReason LEFT OUTER JOIN  Lkp_Delegations AS D ON AC.intDelegation = D.intDelegation ";


      if (txtSID.Text != "")
      {
        if (drp_Type.SelectedItem.Text == "Like")
        {
          string sIDs = txtSID.Text.Replace("\r\n", ";");
          int iLen = sIDs.Length;
          string sLast = sIDs.Substring(iLen - 1, 1);
          if (sLast == ";")
          {
            sIDs = sIDs.Remove(iLen - 1, 1);
          }
          string sIDsCon = "";
          sIDsCon = getIDsCondition(sIDs, "A.lngStudentNumber");
          sWhere += sIDsCon;
        }
        else
        {
          string sIDs = txtSID.Text.Replace("\r\n", ",");
          int iLen = sIDs.Length;
          string sLast = sIDs.Substring(iLen - 1, 1);
          if (sLast == ",")
          {
            sIDs = sIDs.Remove(iLen - 1, 1);
          }
          string s = sIDs;
          sIDs = "'" + s.Replace(",", "','") + "'";
          string sIDsCon = "";
          sIDsCon = "A.lngStudentNumber in (" + sIDs + ")";
          sWhere += " AND ("+ sIDsCon + ")  ";
        }


      }

      if (txtACC.Text != "")
      {
        sWhere += "  AND A.strAccountNo like '%" + txtACC.Text + "%' ";
      }

      sSQL += sWhere;

         sSQL += " AND (T.Term BETWEEN "+ddlFromTerm.SelectedValue+" AND "+ddlToTerm.SelectedValue+") ORDER BY SID, T.Term ";

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
