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
  public partial class ACC_Daily_Receipt : System.Web.UI.Page
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
          //  ddlRegTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));

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
      //int iRegTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);

      string[] PaymentModeList = PaymentMode.Items.Cast<ListItem>().Where(l => l.Selected)
                                         .Select(l => l.Value)
                                         .ToArray();
      //Create Comma Separated values from Array here
      string PaymentModevalues = String.Join(",", PaymentModeList);

      string[] StatusList = Status.Items.Cast<ListItem>().Where(l => l.Selected)
                                         .Select(l => l.Value)
                                         .ToArray();
      //Create Comma Separated values from Array here
      string Statusvalues = String.Join(",", StatusList);

      Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
        SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

        string sSQL = "";

      if (ddlDateType.SelectedValue == "DPayment")
      {

        sSQL = "SELECT (VD.intFy*10+VD.byteFSemester) AS Term,VH.strVoucherNo AS VNO, AC.strAccountNo AS ACC, A.lngStudentNumber AS SID, ISNULL(SD.strLastDescEn,AC.strStudentName + N'(' + isnull(VH.lngStudentNumber,'') + N')') AS Name, VD.lngEntryNo AS Serial , PF.strPaymentFor AS PaymentFor, VD.datePayment AS DPayment, VD.curCredit as Credit,VD.curVAT AS VAT, PT.strPaymentTypeEn AS PType, CS.strChequeStatusEn AS Status, C.strChequeNo AS ChequeNo, B.strBankEn AS Bank, ";
        sSQL += "VD.dateDue AS DueDate,(CASE WHEN VD.intCampus = 1 THEN 'Males' WHEN VD.intCampus = 2 THEN 'Females' WHEN VD.intCampus = 3 THEN 'Media' END) AS Campus, VH.strRemark AS Remark, VD.strUserCreate AS ReceivedBy, VD.dateCreate AS Received, VD.LastAudit , dbo.cleanphone( SD.strPhone1) as Phone1, dbo.cleanphone( SD.strPhone2) as Phone2 FROM Acc_Payment_For AS PF RIGHT OUTER JOIN Acc_Voucher_Header AS VH INNER JOIN Acc_Voucher_Detail AS VD ON VH.intFy = VD.intFy AND  ";
        sSQL += "VH.byteFSemester = VD.byteFSemester AND VH.strVoucherNo = VD.strVoucherNo INNER JOIN Reg_Student_Accounts AS AC ON VH.strAccountNo = AC.strAccountNo INNER JOIN Acc_PaymentsTypes AS PT ON VD.bytePaymentWay = PT.bytePaymentType INNER JOIN Acc_Cheques_Statuses AS CS ON VD.byteStatus = CS.byteChequeStatus ON PF.bytePaymentFor = VD.bytePaymentFor LEFT OUTER JOIN Reg_Students_Data AS SD RIGHT OUTER JOIN Reg_Applications AS A ON SD.lngSerial = A.lngSerial ON AC.lngStudentNumber =  ";
        sSQL += "A.lngStudentNumber LEFT OUTER JOIN Acc_Cheques AS C ON VD.lngCheque = C.lngCheque LEFT OUTER JOIN Acc_Banks AS B ON VD.intBank = B.intBank ";
       
      }
      else
      {
        sSQL = "SELECT (VD.intFy*10+VD.byteFSemester) AS Term,VH.strVoucherNo AS VNO, AC.strAccountNo AS ACC, A.lngStudentNumber AS SID, ISNULL(SD.strLastDescEn,AC.strStudentName + N'(' + isnull(VH.lngStudentNumber,'') + N')') AS Name, VD.lngEntryNo AS Serial , PF.strPaymentFor AS PaymentFor, VD.dateDue AS DueDate, VD.curCredit as Credit,VD.curVAT AS VAT, PT.strPaymentTypeEn AS PType, CS.strChequeStatusEn AS Status, C.strChequeNo AS ChequeNo, B.strBankEn AS Bank, ";
        sSQL += "VD.datePayment AS  DPayment,(CASE WHEN VD.intCampus = 1 THEN 'Males' WHEN VD.intCampus = 2 THEN 'Females' WHEN VD.intCampus = 3 THEN 'Media' END) AS Campus, VH.strRemark AS Remark, VD.strUserCreate AS ReceivedBy, VD.dateCreate AS Received, VD.LastAudit , dbo.cleanphone( SD.strPhone1) as Phone1, dbo.cleanphone( SD.strPhone2) as Phone2 FROM Acc_Payment_For AS PF RIGHT OUTER JOIN Acc_Voucher_Header AS VH INNER JOIN Acc_Voucher_Detail AS VD ON VH.intFy = VD.intFy AND  ";
        sSQL += "VH.byteFSemester = VD.byteFSemester AND VH.strVoucherNo = VD.strVoucherNo INNER JOIN Reg_Student_Accounts AS AC ON VH.strAccountNo = AC.strAccountNo INNER JOIN Acc_PaymentsTypes AS PT ON VD.bytePaymentWay = PT.bytePaymentType INNER JOIN Acc_Cheques_Statuses AS CS ON VD.byteStatus = CS.byteChequeStatus ON PF.bytePaymentFor = VD.bytePaymentFor LEFT OUTER JOIN Reg_Students_Data AS SD RIGHT OUTER JOIN Reg_Applications AS A ON SD.lngSerial = A.lngSerial ON AC.lngStudentNumber =  ";
        sSQL += "A.lngStudentNumber LEFT OUTER JOIN Acc_Cheques AS C ON VD.lngCheque = C.lngCheque LEFT OUTER JOIN Acc_Banks AS B ON VD.intBank = B.intBank ";
       
      }
        if (txtSID.Text != "")
        {
         // sWhere += " AND R.sSID like '%" + txtSID.Text + "%' ";
        }

        if (txtACC.Text != "")
        {
          sWhere += " AND R.sACC like '%" + txtACC.Text + "%' ";
        }

        sSQL += "" + sWhere + "AND VD.bytePaymentWay In(" + PaymentModevalues + ") AND VD.byteStatus In(" + Statusvalues + ") AND (CONVERT(DATE, CONVERT(VARCHAR, YEAR(VD.datePayment)) + '-' + CONVERT(VARCHAR, MONTH(VD.datePayment)) + '-' + CONVERT(VARCHAR, DAY(VD.datePayment))) Between '" + StartDate.Text.Trim() + "' AND '" + EndDate.Text.Trim() + "') ORDER BY "+ddlDateType.SelectedValue+", Serial ";

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
