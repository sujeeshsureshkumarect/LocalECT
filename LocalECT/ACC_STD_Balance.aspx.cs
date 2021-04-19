
using CrystalDecisions.CrystalReports.Engine;
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
            //string sWhere = " WHERE (1=1)";
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

            //string sSQL = "";

            //sSQL = "SELECT     A.lngStudentNumber AS SID, SD.strLastDescEn AS Name, M.strCaption AS Major, AC.strAccountNo AS MainACC, D.strDelegationDescEn AS Sponsor,  ";
            //sSQL += " S.strReasonDesc AS Status, BTS.intFy as FYear, BTS.byteFSemester AS FSemester, T.Term, T.LongDesc AS TermDesc, BTS.Debit, BTS.Credit, BTS.VAT, CD.sDiscounts AS Discounts, dbo.CleanPhone(SD.strPhone1) AS Phone1, dbo.CleanPhone(SD.strPhone2) AS Phone2, SD.sECTemail AS Email  ";
            //sSQL += " FROM         Lkp_Reasons AS S RIGHT OUTER JOIN  Reg_Applications AS A INNER JOIN  Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN  Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN ";
            //sSQL += " Reg_Student_Accounts AS AC ON A.strAccountNo = AC.strAccountNo INNER JOIN   AccBalanceSemBothSide AS BTS INNER JOIN ";
            //sSQL += " (SELECT     AcademicYear, Semester, Term, ShortDesc, LongDesc, sTerm FROM localect.ECTDataNew.dbo.Reg_Semester) AS T ON BTS.intFy = T.AcademicYear AND BTS.byteFSemester = T.Semester ON  A.lngStudentNumber = BTS.lngStudentNumber LEFT OUTER JOIN ";
            //sSQL += " dbo.Collect_Discounts() AS CD ON BTS.intFy = CD.intStudyYear AND BTS.byteFSemester = CD.byteSemester AND BTS.lngStudentNumber = CD.lngStudentNumber ON S.byteReason = A.byteCancelReason LEFT OUTER JOIN  Lkp_Delegations AS D ON AC.intDelegation = D.intDelegation ";


            //if (txtSID.Text != "")
            //{
            //  if (drp_Type.SelectedItem.Text == "Like")
            //  {
            //    string sIDs = txtSID.Text.Replace("\r\n", ";");
            //    int iLen = sIDs.Length;
            //    string sLast = sIDs.Substring(iLen - 1, 1);
            //    if (sLast == ";")
            //    {
            //      sIDs = sIDs.Remove(iLen - 1, 1);
            //    }
            //    string sIDsCon = "";
            //    sIDsCon = getIDsCondition(sIDs, "A.lngStudentNumber");
            //    sWhere += sIDsCon;
            //  }
            //  else
            //  {
            //    string sIDs = txtSID.Text.Replace("\r\n", ",");
            //    int iLen = sIDs.Length;
            //    string sLast = sIDs.Substring(iLen - 1, 1);
            //    if (sLast == ",")
            //    {
            //      sIDs = sIDs.Remove(iLen - 1, 1);
            //    }
            //    string s = sIDs;
            //    sIDs = "'" + s.Replace(",", "','") + "'";
            //    string sIDsCon = "";
            //    sIDsCon = "A.lngStudentNumber in (" + sIDs + ")";
            //    sWhere += " AND ("+ sIDsCon + ")  ";
            //  }


            //}

            //if (txtACC.Text != "")
            //{
            //  sWhere += "  AND A.strAccountNo like '%" + txtACC.Text + "%' ";
            //}

            //sSQL += sWhere;

            //sSQL += " AND (T.Term BETWEEN "+ddlFromTerm.SelectedValue+" AND "+ddlToTerm.SelectedValue+") ORDER BY SID, T.Term ";

            SqlCommand cmd1 = new SqlCommand(getSQL(), sc);
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
                    lnk_ExportPDF.Visible = true;
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_STD_Balance_Tracking,
                InitializeModule.enumPrivilege.ShowPhones, CurrentRole) != true)
                    {
                        dt1.Columns.Remove("Phone1");
                        dt1.Columns.Remove("Phone2");
                    }

                    Session["ACC_STD_Balance"] = dt1;

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
                    Session["ACC_STD_Balance"] = null;
                    DynamicTable.Text = "<p><b>No Results to show</b></p>";
                    lnk_ExportPDF.Visible = false;
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

        private string getSQL()
        {
            string sReturn = "";
            try
            {
                string sWhere = " WHERE (1=1)";
                string sSQL = "";

                //sSQL = "SELECT     A.lngStudentNumber AS SID, SD.strLastDescEn AS Name, M.strCaption AS Major, AC.strAccountNo AS MainACC, D.strDelegationDescEn AS Sponsor,  ";
                //sSQL += " S.strReasonDesc AS Status, BTS.intFy as FYear, BTS.byteFSemester AS FSemester, T.Term, T.LongDesc AS TermDesc, BTS.Debit, BTS.Credit, BTS.VAT, CD.sDiscounts AS Discounts, dbo.CleanPhone(SD.strPhone1) AS Phone1, dbo.CleanPhone(SD.strPhone2) AS Phone2, SD.sECTemail AS Email  ";
                //sSQL += " FROM         Lkp_Reasons AS S RIGHT OUTER JOIN  Reg_Applications AS A INNER JOIN  Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN  Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN ";
                //sSQL += " Reg_Student_Accounts AS AC ON A.strAccountNo = AC.strAccountNo INNER JOIN   AccBalanceSemBothSide AS BTS INNER JOIN ";
                //sSQL += " (SELECT     AcademicYear, Semester, Term, ShortDesc, LongDesc, sTerm FROM localect.ECTDataNew.dbo.Reg_Semester) AS T ON BTS.intFy = T.AcademicYear AND BTS.byteFSemester = T.Semester ON  A.lngStudentNumber = BTS.lngStudentNumber LEFT OUTER JOIN ";
                //sSQL += " dbo.Collect_Discounts() AS CD ON BTS.intFy = CD.intStudyYear AND BTS.byteFSemester = CD.byteSemester AND BTS.lngStudentNumber = CD.lngStudentNumber ON S.byteReason = A.byteCancelReason LEFT OUTER JOIN  Lkp_Delegations AS D ON AC.intDelegation = D.intDelegation ";

                sSQL += " SELECT     A.lngStudentNumber AS SID, SD.strLastDescEn AS Name, M.strCaption AS Major, AC.strAccountNo AS MainACC, D.strDelegationDescEn AS Sponsor, ";
                sSQL += "                       S.strReasonDesc AS Status, B.intFy AS FY, B.byteFSemester AS FS, T.Term, T.LongDesc AS TermDesc, B.Side, B.strAccountNo AS SubACC, B.curDebitSum AS Debit, ";
                sSQL += "                       B.curCreditSum AS Credit, B.curVATSum AS VAT, CD.sDiscounts AS Discounts, dbo.CleanPhone(SD.strPhone1) AS Phone1, dbo.CleanPhone(SD.strPhone2) AS Phone2, ";
                sSQL += "                       SD.sECTemail AS Email ";
                sSQL += " FROM         Reg_Applications AS A INNER JOIN ";
                sSQL += "                       Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN ";
                sSQL += "                       Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN ";
                sSQL += "                       Reg_Student_Accounts AS AC ON A.lngStudentNumber = AC.lngStudentNumber INNER JOIN ";
                sSQL += "                       ACC_Balance_Semester_BTS AS B ON A.lngStudentNumber = B.lngStudentNumber INNER JOIN ";
                sSQL += "                           (SELECT     AcademicYear, Semester, Term, ShortDesc, LongDesc, sTerm ";
                sSQL += "                             FROM          LOCALECT.ECTDataNew.dbo.Reg_Semester) AS T ON B.intFy = T.AcademicYear AND B.byteFSemester = T.Semester LEFT OUTER JOIN ";
                sSQL += "                       dbo.Collect_Discounts() AS CD ON B.intFy = CD.intStudyYear AND B.byteFSemester = CD.byteSemester AND ";
                sSQL += "                       B.lngStudentNumber = CD.lngStudentNumber LEFT OUTER JOIN ";
                sSQL += "                       Lkp_Delegations AS D ON AC.intDelegation = D.intDelegation LEFT OUTER JOIN ";
                sSQL += "                       Lkp_Reasons AS S ON A.byteCancelReason = S.byteReason ";


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
                        sWhere += " AND (" + sIDsCon + ")  ";
                    }
                }
                if (txtACC.Text != "")
                {
                    sWhere += "  AND A.strAccountNo like '%" + txtACC.Text + "%' ";
                }
                sSQL += sWhere;
                sSQL += " AND (T.Term BETWEEN " + ddlFromTerm.SelectedValue + " AND " + ddlToTerm.SelectedValue + ") ORDER BY SID, T.Term ";
                sReturn = sSQL;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
            return sReturn;
        }

        protected void lnk_ExportPDF_Click(object sender, EventArgs e)
        {
            InitializeModule.EnumCampus campus = InitializeModule.EnumCampus.Males;

            //switch (ddlCampus.SelectedIndex)
            //{

            //    case 0:  //All Males
            //        campus = InitializeModule.EnumCampus.Males;
            //        break;

            //    case 1:  //All Females

            //        campus = InitializeModule.EnumCampus.Females;
            //        break;
            //}
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                campus = InitializeModule.EnumCampus.Males;
            }
            else
            {
                campus = InitializeModule.EnumCampus.Females;
            }
            DataSet ds = Prepare_Report(getSQL(), campus);
            Export(ds, false);
        }
        private DataSet Prepare_Report(string sSQL, InitializeModule.EnumCampus Campus)
        {

            //Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            //SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            //Conn.Open();

            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            try
            {
                DataColumn dc;
                //SELECT A.lngStudentNumber AS SID, SD.strLastDescEn AS Name, M.strCaption AS Major, AC.strAccountNo AS MainACC,
                //D.strDelegationDescEn AS Sponsor,S.strReasonDesc AS Status, B.intFy AS FY, B.byteFSemester AS FS, T.Term, T.LongDesc AS TermDesc,
                //B.Side, B.strAccountNo AS SubACC, B.curDebitSum AS Debit,B.curCreditSum AS Credit, B.curVATSum AS VAT, CD.sDiscounts ,dbo.CleanPhone(SD.strPhone1) as Phone1,dbo.CleanPhone(SD.strPhone2) as Phone2           
                dc = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("SID", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Name", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Major", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("MainACC", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Sponsor", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Status", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Term", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("TermDesc", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Side", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("SubACC", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Debit", Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Credit", Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("VAT", Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Discounts", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Phone1", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Phone2", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Email", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("CurrentBalance", Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);

                DataTable dt1 = new DataTable();
                if (Session["ACC_STD_Balance"] != null)
                {
                    dt1 = (DataTable)Session["ACC_STD_Balance"];                   
                }

                //Retrieve Data
                //SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                //SqlDataReader Rd = Cmd.ExecuteReader();
                DataTableReader Rd = dt1.CreateDataReader();
                int i = 0;
                while (Rd.Read())
                {
                    dr = dt.NewRow();
                    i += 1;
                    dr["iSerial"] = i;
                    dr["SID"] = Rd["SID"].ToString();
                    dr["Name"] = Rd["Name"].ToString();
                    dr["Major"] = Rd["Major"].ToString();
                    dr["MainACC"] = Rd["MainACC"].ToString();
                    dr["Sponsor"] = Rd["Sponsor"].ToString();
                    dr["Status"] = Rd["Status"].ToString();
                    dr["Term"] = Convert.ToInt32(Rd["Term"].ToString());
                    dr["TermDesc"] = Rd["TermDesc"].ToString();
                    dr["Side"] = Rd["Side"].ToString();
                    dr["SubACC"] = Rd["SubACC"].ToString();

                    if (!Rd["Debit"].Equals(DBNull.Value))
                    {
                        dr["Debit"] = string.Format("{0:f}", Rd["Debit"]);
                    }

                    if (!Rd["Credit"].Equals(DBNull.Value))
                    {
                        dr["Credit"] = string.Format("{0:f}", Rd["Credit"]);
                    }

                    if (!Rd["VAT"].Equals(DBNull.Value))
                    {
                        dr["VAT"] = string.Format("{0:f}", Rd["VAT"]);
                    }

                    dr["Discounts"] = Rd["Discounts"].ToString();
                    dr["Email"] = Rd["Email"].ToString();


                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_STD_Balance_Tracking,
                    InitializeModule.enumPrivilege.ShowPhones, CurrentRole) == true)
                    {
                        dr["Phone1"] = Rd["Phone1"].ToString();
                        dr["Phone2"] = Rd["Phone2"].ToString();
                    }

                    dr["CurrentBalance"] = string.Format("{0:f}", LibraryMOD.GetStudentBalanceBTS(Rd["SID"].ToString(), Campus));

                    dt.Rows.Add(dr);
                }

                dt.TableName = "STDBalance";
                dt.AcceptChanges();
                ds.Tables.Add(dt);

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                //Conn.Close();
                //Conn.Dispose();
            }
            return ds;
        }

        private void Export(DataSet ds, bool isExcel)
        {
            ReportDocument myReport = new ReportDocument();

            try
            {
                CrystalDecisions.Shared.ExportFormatType RPTType = CrystalDecisions.Shared.ExportFormatType.Excel;
                string reportPath = "";
                if (isExcel)
                {
                    reportPath = Server.MapPath("Reports/ACCSTDBalance.rpt");
                    myReport.Load(reportPath);
                    myReport.SetDataSource(ds);
                }
                else
                {
                    reportPath = Server.MapPath("Reports/ACCSTDBalancePDF.rpt");
                    RPTType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
                    myReport.Load(reportPath);
                    myReport.SetDataSource(ds);

                    TextObject txt;
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                    string sUserName = Session["CurrentUserName"].ToString();
                    txt.Text = "/ " + sUserName;
                }




                myReport.ExportToHttpResponse(RPTType, Page.Response, true, "ECTReport");

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                myReport.Close();
                myReport.Dispose();
            }
        }
    }
}
