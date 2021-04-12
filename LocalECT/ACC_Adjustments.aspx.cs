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
  public partial class Acc_Adjustments : System.Web.UI.Page
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

      if (ddlRptType.SelectedIndex == 0)//Fees
      {
        sSQL = "SELECT VP.intFy * 10 + VP.byteFSemester AS Term, VP.strAccount AS ACC, SA.lngStudentNumber AS SID, SA.strStudentName AS Name, VP.byteFeesNo AS VNo,";
        sSQL += " FT.strFeesTypeEn AS Type, VP.curDebit AS Debit, VP.curCredit AS Credit, VP.curVAT AS VAT, S.strChequeStatusEn AS Status, VP.strRemark AS Remark,";
        sSQL += " VP.strUserCreate AS CreatedBy, VP.dateCreate AS Created, VP.strUserSave AS UpdatedBy, VP.dateLastSave AS Updated, VP.LastAudit";
        sSQL += " FROM Acc_Voucher_Payments AS VP INNER JOIN Reg_Student_Accounts AS SA ON VP.strAccount = SA.strAccountNo INNER JOIN";
        sSQL += " Reg_Fees_Type AS FT ON VP.byteFeesType = FT.byteFeesType INNER JOIN Acc_Cheques_Statuses AS S ON VP.byteStatus = S.byteChequeStatus";
        sSQL += " Where VP.intFy * 10 + VP.byteFSemester=" + iRegTerm;
        if (ddlCreated.SelectedIndex == 0)
        {
          sSQL += " AND (VP.strUserCreate<>'anas')";
        }
        else
        {
          sSQL += " AND (VP.strUserCreate='anas' OR VP.strUserSave='anas')";
        }

      }
      else
      {
        sSQL = "SELECT D.intStudyYear * 10 + D.byteSemester AS Term, D.lngStudentNumber AS SID, SD.strLastDescEn AS Name, DT.strDiscountDesc AS Discount,";
        sSQL += " DC.strCategoryEn AS Category, D.curDiscount AS Amount, D.strRemark AS Remark, (CASE WHEN D .bActive = 1 THEN 'Yes' ELSE 'No' END) AS IsActive,";
        sSQL += " D.strUserCreate AS CreatedBy, D.dateCreate AS Created, D.strUserSave AS UpdatedBy, D.dateLastSave AS Updated";
        sSQL += " FROM Reg_Student_Discounts AS D INNER JOIN Reg_Discounts AS DT ON D.byteDiscountType = DT.byteDiscountType INNER JOIN";
        sSQL += " Reg_Discounts_Categories AS DC ON D.byteDiscountType = DC.byteDiscountType AND D.byteDiscountCategory = DC.byteDiscountCategory INNER JOIN";
        sSQL += " Reg_Applications AS A ON D.lngStudentNumber = A.lngStudentNumber INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial";
        sSQL += " Where D.intStudyYear *10+D.byteSemester=" + iRegTerm;
        if (ddlCreated.SelectedIndex == 0)
        {
          sSQL += " AND (D.strUserCreate<>'anas')";
        }
        else
        {
          sSQL += " AND (D.strUserCreate='anas' OR D.strUserSave='anas')";
        }


      }

      sSQL += " ORDER BY Created DESC";






    //  sSQL += sWhere;




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
