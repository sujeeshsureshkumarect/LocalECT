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
    public partial class Student_Report_Center : System.Web.UI.Page
    {
        int CurrentRole = 0;
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;

        struct previous
        {
            public int iTerm;
            public string sSID;
            public string sMajor;
        }
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

            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentCenter,
            InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
            {
                //Server.Transfer("Authorization.aspx");
            }



            //divMsg.InnerText = "";

            if (!IsPostBack)
            {
                FillTerms();
                //FillNationalities();
                //FillFaculty();
                //FillMajors();
                //FillStatuses();
                //FillGroup();
            }
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentCenter,
           InitializeModule.enumPrivilege.ShowUnRegisteredStudents, CurrentRole) != true)
            {
                //chkJoinTerm.Checked = true;
                //chkJoinTerm.Enabled = false;

                //ddlJoinTerm.Enabled = false;
            }
        }

        protected void lnk_FieldGenerate_Click(object sender, EventArgs e)
        {
            int selectedYear= 0;
            int selectedSemester= 0;
            int selectedTerm = 0;
            selectedTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
            selectedYear = LibraryMOD.SeperateTerm(selectedTerm, out selectedSemester);

            int previousYear = selectedYear;
            int previousSemestrer = selectedSemester-1;
            if(selectedSemester==1)
            {
                previousYear = selectedYear - 1;
                previousSemestrer = 4;
            }
            int prevterm = (previousYear * 10)+ previousSemestrer;

            string selectquery = string.Empty;
            int selectcount = 0;
            for (int i = 0; i < chk_Fields.Items.Count; i++)
            {
                if (chk_Fields.Items[i].Selected)
                {
                    string value = chk_Fields.Items[i].Value;
                    if (value == "condition1")
                    {
                        //value = "dbo.GetCHEDSSTTypeNew("+ selectedYear + ", "+ selectedSemester + ", SD.SID) AS STtype";
                        value = "(CASE WHEN ISNULL(LT.LTR, 0) = 0 THEN 'NEW' WHEN ISNULL(LT.LTR, 0) <> 0 AND (SD.RSTATUS = 3 OR SD.RSTATUS = 25) AND SD.Joined = " + selectedTerm + " THEN 'Extended' WHEN ISNULL(LT.LTR, 0) <> 0 AND SD.RSTATUS <> 0 AND SD.RSTATUS <> 3 AND SD.RSTATUS <> 25 AND SD.RSTATUS <> 29 AND SD.RSTATUS <> 20 AND SD.RSTATUS <> 27 AND SD.RSTATUS <> 28 AND SD.RSTATUS <> 31 AND SD.Joined = " + selectedTerm + " THEN 'Re-admitted' ELSE 'Continuing' END) AS STType";
                    }
                    if (value == "condition2")
                    {
                        value = "dbo.Completed_Successfully(SD.SID, "+ previousYear + ", "+ previousSemestrer + ", SM.strDegree, SM.strMajor) AS Completed";
                    }
                    selectquery += value + ",";
                    selectcount++;
                }
            }

            if(selectcount>10)
            {
                //You exceeds the maximum limit of allowed selection.
                lbl_Msg.Text = "You exceeds the maximum limit (10) of allowed selections.";
                div_msg.Visible = true;
                DynamicTable.Text = "";
            }
            else
            {
                lbl_Msg.Text = "";
                div_msg.Visible = false;

                if(selectquery==string.Empty)
                {
                    selectquery = "SD.SID, SD.NameEn, SD.Gender, RBS.HRS,  M.strMajor AS MajorPlan,SD.UID, FT.FTR, LT.LTR, TR.TC";
                }
                else
                {
                    selectquery = selectquery.Remove(selectquery.Length - 1, 1);
                }                

                string remainquery = "SELECT " + selectquery + " ";
                remainquery += "FROM (SELECT     TOP (100) PERCENT SDT.iUnifiedID, MIN(DISTINCT CB.iYear * 10 + CB.Sem) AS FTR ";
                remainquery += "FROM          Course_Balance_View AS CB INNER JOIN ";
                remainquery += "Reg_Applications AS A ON CB.Student = A.lngStudentNumber INNER JOIN ";
                remainquery += "Reg_Students_Data AS SDT ON A.lngSerial = SDT.lngSerial ";
                remainquery += "GROUP BY SDT.iUnifiedID ";
                remainquery += "HAVING      (SDT.iUnifiedID <> 0)) AS FT RIGHT OUTER JOIN ";
                remainquery += "(SELECT     iYear, Sem, Student, MCRS, FCRS, MHRS + FHRS AS HRS ";
                remainquery += "FROM          Reg_Both_Side ";
                remainquery += "WHERE(iYear = " + selectedYear + ") AND(Sem = " + selectedSemester + ")) AS RBS INNER JOIN  ";
                remainquery += "ECT_Student_Data AS SD ON RBS.Student = SD.SID ON FT.iUnifiedID = SD.UID LEFT OUTER JOIN ";
                remainquery += "(SELECT     GH.lngStudentNumber, COUNT(GH.strCourse) AS TC ";
                remainquery += "FROM          Reg_Grade_Header AS GH INNER JOIN ";
                remainquery += "Lkp_Foreign_Colleges AS FC ON GH.byteRefCollege = FC.byteCollege ";
                remainquery += "WHERE      (GH.strGrade = N'TC') AND (FC.isAnotherCollege = 1) ";
                remainquery += "GROUP BY GH.lngStudentNumber) AS TR ON SD.SID = TR.lngStudentNumber LEFT OUTER JOIN ";
                remainquery += "(SELECT     SDP.iUnifiedID AS UID, SMP.intStudyYear * 10 + SMP.byteSemester AS Term, MP.sUnified AS Major ";
                remainquery += " FROM          Reg_Students_Data AS SDP INNER JOIN ";
                remainquery += "Reg_Applications AS AP ON SDP.lngSerial = AP.lngSerial INNER JOIN ";
                remainquery += "Reg_Student_Majors AS SMP ON AP.lngStudentNumber = SMP.lngStudentNumber INNER JOIN ";
                remainquery += "Reg_Specializations AS MP ON SMP.strDegree = MP.strDegree AND SMP.strMajor = MP.strSpecialization) AS PMJ RIGHT OUTER JOIN ";                
                remainquery += "(SELECT     TOP (100) PERCENT SDT.iUnifiedID, MAX(DISTINCT CB.iYear * 10 + CB.Sem) AS LTR ";
                remainquery += "FROM          Course_Balance_View AS CB INNER JOIN ";
                remainquery += "Reg_Applications AS A ON CB.Student = A.lngStudentNumber INNER JOIN ";
                remainquery += "Reg_Students_Data AS SDT ON A.lngSerial = SDT.lngSerial ";
                remainquery += "WHERE (CB.iYear * 10 + CB.Sem < " + selectedTerm + ") ";
                remainquery += "GROUP BY SDT.iUnifiedID ";
                remainquery += "HAVING      (SDT.iUnifiedID <> 0)) AS LT ON PMJ.UID = LT.iUnifiedID AND PMJ.Term = LT.LTR ON SD.UID = LT.iUnifiedID LEFT OUTER JOIN ";
                remainquery += "RDateBothSide AS RDBS ON RBS.iYear = RDBS.intStudyYear AND RBS.Sem = RDBS.byteSemester AND RBS.Student = RDBS.SID LEFT OUTER JOIN ";
                remainquery += "(SELECT     SMH.intStudyYear, SMH.byteSemester, SMH.lngStudentNumber, SMH.strDegree, SMH.strMajor, SMH.intRegistered ";
                remainquery += "FROM          Reg_Student_Majors AS SMH INNER JOIN ";
                remainquery += "Cmn_Firm AS F ON SMH.intStudyYear * 10 + SMH.byteSemester < F.intRegYear * 10 + F.byteRegSemester ";
                remainquery += "UNION ";
                remainquery += "SELECT     F.intRegYear, F.byteRegSemester, A.lngStudentNumber, A.strDegree, A.strSpecialization, 0 AS Registered ";
                remainquery += "FROM         Reg_Applications AS A CROSS JOIN ";
                remainquery += "Cmn_Firm AS F) AS SM LEFT OUTER JOIN ";
                remainquery += "Reg_Specializations AS M LEFT OUTER JOIN ";
                remainquery += "Reg_Faculty AS MF ON M.FacultyID = MF.FacultyID ON SM.strDegree = M.strDegree AND SM.strMajor = M.strSpecialization ON ";

                remainquery += "RBS.Student = SM.lngStudentNumber AND RBS.iYear = SM.intStudyYear AND RBS.Sem = SM.byteSemester LEFT OUTER JOIN ";
                remainquery += "(SELECT     lngStudentNumber, Debit - Credit + VAT AS Balance ";
                remainquery += "FROM          AccBalanceSTBothSide) AS ACBS ON SD.SID = ACBS.lngStudentNumber ";

                Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
                SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
                SqlCommand cmd = new SqlCommand(remainquery, sc);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    if (dt.Rows.Count > 0)
                    {
                        //Results.DataSource = dt;
                        //Results.DataBind();

                        StringBuilder sb = new StringBuilder();
                        sb.Append("<table id='example' class='table table-striped table-bordered' style='width: 100%'>" + Environment.NewLine + "");

                        //Add Table Header
                        sb.Append("<thead>" + Environment.NewLine + "<tr class='headings'>" + Environment.NewLine + "");
                        sb.Append("<th>#</th> " + Environment.NewLine + "");
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<th>" + column.ColumnName + "</th> "+Environment.NewLine+"");
                        }
                        sb.Append("</tr>" + Environment.NewLine + "</thead>" + Environment.NewLine + "");


                        //Add Table Rows
                        int i = 1;
                        foreach (DataRow row in dt.Rows)
                        {
                            sb.Append("<tr>" + Environment.NewLine + "");
                            sb.Append("<td>" + i + "</td>" + Environment.NewLine + "");
                            //Add Table Columns
                            foreach (DataColumn column in dt.Columns)
                            {
                                sb.Append("<td>" + row[column.ColumnName].ToString() + "</td>" + Environment.NewLine + "");
                            }
                            sb.Append("</tr>" + Environment.NewLine + "");
                            i++;
                        }

                        sb.Append("</table>" + Environment.NewLine + "");
                        DynamicTable.Text = sb.ToString();
                    }
                }
                catch (Exception ex)
                {
                    sc.Close();
                    Console.WriteLine(ex.Message);
                    lbl_Msg.Text = ex.Message;
                    div_msg.Visible = true;
                }
                finally
                {
                    sc.Close();
                }
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
    }
}