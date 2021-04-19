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
    public partial class CHEDS_New_Attrition : System.Web.UI.Page
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
            //int byteShift1 = 3;
            //int byteShift2 = 4;
            //int byteShift3 = 8;
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                Campus = InitializeModule.EnumCampus.Males;
                //byteShift1 = 3;
                //byteShift2 = 4;
                //byteShift3 = 8;
            }
            else
            {
                Campus = InitializeModule.EnumCampus.Females;
                //byteShift1 = 1;
                //byteShift2 = 2;
                //byteShift3 = 9;
            }

            int selectedYear = 0;
            int selectedSemester = 0;
            int selectedTerm = 0;
            selectedTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
            selectedYear = LibraryMOD.SeperateTerm(selectedTerm, out selectedSemester);
            int previousYear = selectedYear;
            int previousSemestrer = selectedSemester - 1;
            if (selectedSemester == 1)
            {
                previousYear = selectedYear - 1;
                previousSemestrer = 4;
            }
            int prevterm = (previousYear * 10) + previousSemestrer;

            int iRegYear = 0;
            int iRegSem = 0;
            int iRegTerm = 0;
            int iSubmission = 202003;
            //int iEXYear = 2020;
            //int iEXSem = 2;
            iRegTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
            iRegYear = LibraryMOD.SeperateTerm(iRegTerm, out iRegSem);

            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("select iCHEDSCode from Reg_Semesters where iTerm=@iTerm", sc);
            cmd.Parameters.AddWithValue("@iTerm", iRegTerm);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    iSubmission=Convert.ToInt32(dt.Rows[0]["iCHEDSCode"]);
                }
            }
            catch(Exception ex)
            {
                sc.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sc.Close();
            }

            
           
            string remainquery = "Declare @iAYear int ";
            remainquery += "Declare @iASem int ";
            remainquery += "Declare @iATerm int ";
            remainquery += "Declare @iSubmission int ";
            remainquery += "Declare @iEXYear int ";
            remainquery += "Declare @iEXSem int ";
            remainquery += "Declare @iEXTerm int ";
           
            remainquery += "SET @iAYear="+ previousYear + " ";
            remainquery += "SET @iASem="+ previousSemestrer + " ";
            
            remainquery += "SET @iATerm=@iAYear*10+@iASem ";
           
            remainquery += "SET @iSubmission="+ iSubmission + " ";
           
            remainquery += "SET @iEXYear="+ iRegYear + " ";
            remainquery += "SET @iEXSem="+ iRegSem + " ";
           
            remainquery += "SET @iEXTerm=@iEXYear*10+@iEXSem ";

            //remainquery += "SELECT     32 AS [Institution Code], 'Emirates College of Technology' AS [Institution Name], @iSubmission AS STerm, ATS.iCHEDSCode AS [G Academic Period],  ";
            //remainquery += "                      REPLACE(A.lngStudentNumber, '.', '') AS [Student ID], REPLACE(SD.strNationalID, '-', '') AS [Emirates ID], SD.strLastDescEn AS [Student Name (English)],  ";
            //remainquery += "                      SD.strLastDescAr AS [Student Name (Arabic)], (CASE WHEN SD.bSex = 1 THEN 'M' ELSE 'F' END) AS Gender, CONVERT(VARCHAR, YEAR(SD.dateBirth))  ";
            //remainquery += "                      + '-' + CONVERT(VARCHAR, MONTH(SD.dateBirth)) + '-' + CONVERT(VARCHAR, DAY(SD.dateBirth)) AS [Student DOB], N.sCHEDSCode AS Nationality,  ";
            //remainquery += "                      dbo.GetCHEDSSTLevelNew(dbo.Completed_Successfully(A.lngStudentNumber, @iEXYear, @iEXSem, ATT.strDegree, ATT.strMajor), ATT.strDegree, ATT.strMajor) AS [Student Level],  ";
            //remainquery += "                      LEFT(M.strClass, 2) AS [Area of Specialization], M.sCHEDProgCode AS [Program Code], '' AS [Att Category], '' AS [Att Reason], ST.strReasonDesc AS Status ";
            //remainquery += "FROM         Lkp_Nationalities AS N INNER JOIN ";
            //remainquery += "                      Reg_Applications AS A INNER JOIN ";
            //remainquery += "                      Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON N.byteNationality = SD.byteNationality INNER JOIN ";
            //remainquery += "                          (SELECT     ATT0.intStudyYear, ATT0.byteSemester, ATT0.lngStudentNumber, SM1.strDegree, SM1.strMajor ";
            //remainquery += "                            FROM          (SELECT     S.intStudyYear, S.byteSemester, A1.lngStudentNumber, LT.sECTemail, LT.Term ";
            //remainquery += "                                                    FROM          Reg_Students_Data AS SD1 INNER JOIN ";
            //remainquery += "                                                                           Reg_Applications AS A1 ON SD1.lngSerial = A1.lngSerial INNER JOIN ";
            //remainquery += "                                                                               (SELECT     SD.sECTemail, MAX(SM.intStudyYear * 10 + SM.byteSemester) AS Term ";
            //remainquery += "                                                                                 FROM          Reg_Applications AS A INNER JOIN ";
            //remainquery += "                                                                                                        Reg_Student_Majors AS SM ON A.lngStudentNumber = SM.lngStudentNumber INNER JOIN ";
            //remainquery += "                                                                                                        Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ";
            //remainquery += "                                                                                 GROUP BY SD.sECTemail ";
            //remainquery += "                                                                                 HAVING      (MAX(SM.intStudyYear * 10 + SM.byteSemester) >= @iATerm)) AS LT INNER JOIN ";
            //remainquery += "                                                                           Reg_Semesters AS S ON LT.Term = S.iTerm ON SD1.sECTemail = LT.sECTemail ";
            //remainquery += "                                                    WHERE      (LT.Term < @iEXTerm)) AS ATT0 INNER JOIN ";
            //remainquery += "                                                   Reg_Student_Majors AS SM1 ON ATT0.intStudyYear = SM1.intStudyYear AND ATT0.byteSemester = SM1.byteSemester AND  ";
            //remainquery += "                                                   ATT0.lngStudentNumber = SM1.lngStudentNumber) AS ATT ON A.lngStudentNumber = ATT.lngStudentNumber INNER JOIN ";
            //remainquery += "                      Reg_Semesters AS ATS ON ATT.intStudyYear = ATS.intStudyYear AND ATT.byteSemester = ATS.byteSemester INNER JOIN ";
            //remainquery += "                      Reg_Specializations AS M ON ATT.strDegree = M.strDegree AND ATT.strMajor = M.strSpecialization LEFT OUTER JOIN ";
            //remainquery += "                      Lkp_Reasons AS ST ON A.byteCancelReason = ST.byteReason ";
            //remainquery += "WHERE     (A.byteCancelReason IS NULL) AND (M.strSpecialization <> N'999') OR ";
            //remainquery += "                      (A.byteCancelReason <> 3) AND (M.strSpecialization <> N'999') AND (A.byteCancelReason <> 29) AND (A.byteCancelReason <> 25) ";

            remainquery += "SELECT     32 AS [Institution Code], 'Emirates College of Technology' AS [Institution Name], @iSubmission AS STerm, ATS.iCHEDSCode AS [G Academic Period], ";
            remainquery += "                      REPLACE(A.lngStudentNumber, '.', '') AS [Student ID], REPLACE(SD.strNationalID, '-', '') AS [Emirates ID], SD.strLastDescEn AS [Student Name (English)], ";
            remainquery += "                      SD.strLastDescAr AS [Student Name (Arabic)], (CASE WHEN SD.bSex = 1 THEN 'M' ELSE 'F' END) AS Gender, CONVERT(VARCHAR, YEAR(SD.dateBirth)) ";
            remainquery += "                      + '-' + CONVERT(VARCHAR, MONTH(SD.dateBirth)) + '-' + CONVERT(VARCHAR, DAY(SD.dateBirth)) AS [Student DOB], N.sCHEDSCode AS Nationality, ";
            remainquery += "                      dbo.GetCHEDSSTLevelNew(dbo.Completed_Successfully(A.lngStudentNumber, @iEXYear, @iEXSem, ATT.strDegree, ATT.strMajor), ATT.strDegree, ATT.strMajor) ";
            remainquery += "                      AS [Student Level], LEFT(M.strClass, 2) AS [Area of Specialization], M.sCHEDProgCode AS [Program Code], ST.sCHDESCode AS [Att Category], ";
            remainquery += "                      MR.sCHDESCode AS [Att Reason], ST.strReasonDesc AS Status, MR.strMainReasonEn AS Reason ";
            remainquery += "FROM         Lkp_Nationalities AS N INNER JOIN ";
            remainquery += "                      Reg_Applications AS A INNER JOIN ";
            remainquery += "                      Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON N.byteNationality = SD.byteNationality INNER JOIN ";
            remainquery += "                          (SELECT     ATT0.intStudyYear, ATT0.byteSemester, ATT0.lngStudentNumber, SM1.strDegree, SM1.strMajor ";
            remainquery += "                            FROM          (SELECT     S.intStudyYear, S.byteSemester, A1.lngStudentNumber, LT.sECTemail, LT.Term ";
            remainquery += "                                                    FROM          Reg_Students_Data AS SD1 INNER JOIN ";
            remainquery += "                                                                           Reg_Applications AS A1 ON SD1.lngSerial = A1.lngSerial INNER JOIN ";
            remainquery += "                                                                               (SELECT     SD.sECTemail, MAX(SM.intStudyYear * 10 + SM.byteSemester) AS Term ";
            remainquery += "                                                                                 FROM          Reg_Applications AS A INNER JOIN ";
            remainquery += "                                                                                                        Reg_Student_Majors AS SM ON A.lngStudentNumber = SM.lngStudentNumber INNER JOIN ";
            remainquery += "                                                                                                        Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ";
            remainquery += "                                                                                 GROUP BY SD.sECTemail ";
            remainquery += "                                                                                 HAVING      (MAX(SM.intStudyYear * 10 + SM.byteSemester) >= @iATerm)) AS LT INNER JOIN ";
            remainquery += "                                                                           Reg_Semesters AS S ON LT.Term = S.iTerm ON SD1.sECTemail = LT.sECTemail ";
            remainquery += "                                                    WHERE      (LT.Term < @iEXTerm)) AS ATT0 INNER JOIN ";
            remainquery += "                                                   Reg_Student_Majors AS SM1 ON ATT0.intStudyYear = SM1.intStudyYear AND ATT0.byteSemester = SM1.byteSemester AND ";
            remainquery += "                                                   ATT0.lngStudentNumber = SM1.lngStudentNumber) AS ATT ON A.lngStudentNumber = ATT.lngStudentNumber INNER JOIN ";
            remainquery += "                      Reg_Semesters AS ATS ON ATT.intStudyYear = ATS.intStudyYear AND ATT.byteSemester = ATS.byteSemester INNER JOIN ";
            remainquery += "                      Reg_Specializations AS M ON ATT.strDegree = M.strDegree AND ATT.strMajor = M.strSpecialization LEFT OUTER JOIN ";
            remainquery += "                      Lkp_MainReasons AS MR ON A.byteMainReason = MR.byteMainReason LEFT OUTER JOIN ";
            remainquery += "                      Lkp_Reasons AS ST ON A.byteCancelReason = ST.byteReason ";
            remainquery += "WHERE     (A.byteCancelReason IS NULL) AND (M.strSpecialization <> N'999') OR ";
            remainquery += "                      (A.byteCancelReason <> 3) AND (M.strSpecialization <> N'999') AND (A.byteCancelReason <> 29) AND (A.byteCancelReason <> 25) ";

            SqlCommand cmd1 = new SqlCommand(remainquery, sc);
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
                    string columnnames = "Attrition_Institution_Code,Attrition_Institution_Name,Attrition_Submission_Term,Attrition_Academic_Period,Attrition_Student_ID,Attrition_Emirates_ID,Attrition_Student_Name_English,Attrition_Name_Arabic,Attrition_Gender,Attrition_Student_DOB,Attrition_Nationality,Attrition_Student_Level,Attrition_Area_of_Specialization,Attrition_Program_Code,Attrition_Category,Attrition_Reason,Status,Reason";
                    string[] columns = columnnames.Split(new string[] { "," }, StringSplitOptions.None);
                    if (dt1.Columns.Count > 0)
                    {
                        for (int j = 0; j < dt1.Columns.Count; j++)
                        {
                            dt1.Columns[j].ColumnName = columns[j].ToString();
                        }
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