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
    public partial class CHEDS_New_Graduated : System.Web.UI.Page
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
            int byteShift1 = 3;
            int byteShift2 = 4;
            int byteShift3 = 8;
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                Campus = InitializeModule.EnumCampus.Males;
                byteShift1 = 3;
                byteShift2 = 4;
                byteShift3 = 8;
            }
            else
            {
                Campus = InitializeModule.EnumCampus.Females;
                byteShift1 = 1;
                byteShift2 = 2;
                byteShift3 = 9;
            }

            int iRegYear = 0;
            int iRegSem = 0;
            int iRegTerm = 0;
            int iSubmission = 202003;

            int currentterm = LibraryMOD.GetCurrentTerm();
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("select iCHEDSCode from Reg_Semesters where iTerm=@iTerm", sc);
            cmd.Parameters.AddWithValue("@iTerm", currentterm);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    currentterm = Convert.ToInt32(dt.Rows[0]["iCHEDSCode"]);
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

            iRegTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
            iRegYear = LibraryMOD.SeperateTerm(iRegTerm, out iRegSem);

            //Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            //SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            string remainquery = "Declare @iGYear int Declare @iGSem int Declare @iGTerm int Declare @iSubmission int Declare @iPrvSem int ";
            remainquery += "SET @iGYear="+ iRegYear + " SET @iGSem="+ iRegSem + " SET @iGTerm=@iGYear*10+@iGSem SET @iSubmission="+ iSubmission + " ";
            remainquery += "SELECT     32 AS [Institution Code], 'Emirates College of Technology' AS [Institution Name], GS.iCHEDSCode AS [G Academic Period], REPLACE(A.lngStudentNumber, '.', '')  ";
            remainquery += "                      AS [Student ID], (CASE WHEN ISNULL(CONVERT(VARCHAR, SD.EthbaraNo), '0') = '0' THEN 'NA' ELSE CONVERT(VARCHAR, SD.EthbaraNo) END) AS [Al Ethbara],  ";
            remainquery += "                      REPLACE(SD.strNationalID, '-', '') AS [Emirates ID], '' AS [EID Missing?], (CASE WHEN SD.byteIDType = 2 THEN (CASE WHEN ISNULL(SD.strID, 'NA')  ";
            remainquery += "                      = '0' THEN 'NA' ELSE ISNULL(SD.strID, 'NA') END) ELSE 'NA' END) AS Passport, SD.strLastDescEn AS [Student Name (English)],  ";
            remainquery += "                      SD.strLastDescAr AS [Student Name (Arabic)], (CASE WHEN SD.bSex = 1 THEN 'M' ELSE 'F' END) AS Gender, CONVERT(VARCHAR, YEAR(SD.dateBirth))  ";
            remainquery += "                      + '-' + CONVERT(VARCHAR, MONTH(SD.dateBirth)) + '-' + CONVERT(VARCHAR, DAY(SD.dateBirth)) AS [Student DOB], SD.sECTemail AS [Student Email Address],  ";
            remainquery += "                      dbo.CleanPhone(SD.strPhone1) AS [Student Mobile Number], (CASE WHEN ISNULL(DT.iSerial, 0) = 0 THEN 'N' ELSE 'Y' END) AS [Determination Indicator],  ";
            remainquery += "                      MS.sCHEDSCode AS [Marital Status], N.sCHEDSCode AS Nationality, ISNULL(MN.sCHEDSCode, N.sCHEDSCode) AS [Nationality of Mother], ISNULL(HE.sCHEDSCode,  ";
            remainquery += "                      'AD') AS [Home Emirate], 'AD' AS [Student Campus], FS.iCHEDSCode AS [1st Academic Period],  ";
            remainquery += "                      (CASE WHEN A.strDegree = '3' THEN 'BA' WHEN A.strDegree = '2' THEN 'FD' WHEN A.strDegree = '1' AND A.strSpecialization <> '999' THEN 'DP' ELSE 'UD' END)  ";
            remainquery += "                      AS [Student Degree], LEFT(M.strClass, 2) AS [Area of Specialization], M.strCaption AS Major, M.strClass AS [CIP Major], '' AS Minor,  ";
            remainquery += "                      M.sCHEDProgCode AS [Program Code], (CASE WHEN A.strSpecialization = '999' THEN 'PT' ELSE 'FT' END) AS [Mode of Study], '' AS [Master Thesis],  ";
            remainquery += "                      '' AS [PhD Dissertation], M.intStudyHours AS [Total Credits], G.GPA AS CGPA, ISNULL(RTerm.RTerms, 0) AS ACPRegular, ISNULL(STerm.STerms, 0) AS ACPSUB,  ";
            remainquery += "                      @iSubmission AS Term ";
            remainquery += "FROM         Lkp_Emirates AS HE RIGHT OUTER JOIN ";
            remainquery += "                      Lkp_Cities AS HC ON HE.byteEmirate = HC.byteEmirate RIGHT OUTER JOIN ";
            remainquery += "                          (SELECT     SID, COUNT(Term) AS RTerms ";
            remainquery += "                            FROM          (SELECT     lngStudentNumber AS SID, intStudyYear * 10 + byteSemester AS Term, COUNT(strCourse) AS CRS ";
            remainquery += "                                                    FROM          Reg_Grade_Header AS GH ";
            remainquery += "                                                    WHERE      (byteSemester < 3) ";
            remainquery += "                                                    GROUP BY lngStudentNumber, intStudyYear * 10 + byteSemester ";
            remainquery += "                                                    HAVING      (intStudyYear * 10 + byteSemester > 0)) AS RT ";
            remainquery += "                            GROUP BY SID) AS RTerm RIGHT OUTER JOIN ";
            remainquery += "                      Lkp_Nationalities AS N INNER JOIN ";
            remainquery += "                      Reg_Applications AS A INNER JOIN ";
            remainquery += "                      Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON N.byteNationality = SD.byteNationality INNER JOIN ";
            remainquery += "                      Reg_Semesters AS FS ON A.intStudyYear = FS.intStudyYear AND A.byteSemester = FS.byteSemester INNER JOIN ";
            remainquery += "                      Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN ";
            remainquery += "                      Reg_Semesters AS GS ON A.intGraduationYear = GS.intStudyYear AND A.byteGraduationSemester = GS.byteSemester INNER JOIN ";
            remainquery += "                      GPA_Until AS G ON A.lngStudentNumber = G.lngStudentNumber LEFT OUTER JOIN ";
            remainquery += "                          (SELECT     SID, COUNT(Term) AS STerms ";
            remainquery += "                            FROM          (SELECT     lngStudentNumber AS SID, intStudyYear * 10 + byteSemester AS Term, COUNT(strCourse) AS CRS ";
            remainquery += "                                                    FROM          Reg_Grade_Header AS GH ";
            remainquery += "                                                    WHERE      (byteSemester > 2) ";
            remainquery += "                                                    GROUP BY lngStudentNumber, intStudyYear * 10 + byteSemester ";
            remainquery += "                                                    HAVING      (intStudyYear * 10 + byteSemester > 0)) AS RT_1 ";
            remainquery += "                            GROUP BY SID) AS STerm ON A.lngStudentNumber = STerm.SID ON RTerm.SID = A.lngStudentNumber ON HC.byteCountry = SD.byteHomeCountry AND  ";
            remainquery += "                      HC.byteCity = SD.byteOriginCountry LEFT OUTER JOIN ";
            remainquery += "                      Lkp_Nationalities AS MN ON SD.NationalityofMother = MN.byteNationality LEFT OUTER JOIN ";
            remainquery += "                      Lkp_Marital_Status AS MS ON SD.MaritalStatus = MS.iStatus LEFT OUTER JOIN ";
            remainquery += "                      Lkp_Determination_Type AS DT ON SD.intDelegation = DT.iSerial ";
            remainquery += "WHERE     (A.intGraduationYear * 10 + A.byteGraduationSemester >= @iGTerm) AND (A.byteCancelReason = 3) AND (SD.byteShift = "+ byteShift1 + " OR ";
            remainquery += "                      SD.byteShift = "+ byteShift2 + " OR ";
            remainquery += "                      SD.byteShift = "+ byteShift3 + ") ";
            remainquery += "ORDER BY A.intGraduationYear * 10 + A.byteGraduationSemester ";



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
                    string columnnames = "Grad_Institution_Code,Grad_Institution_Name,Grad_Academic_Period,Grad_Student_ID,Grad_Al_Ethbara,Grad_Emirates_ID,Grad_Missing_EID,Grad_Passport_Number,Grad_Student_Name_English,Grad_Student_Name_Arabic,Grad_Gender,Grad_Student_DOB,Grad_Student_Email_Address,Grad_Student_Mobile_Number,Grad_Health_Fitness_Certificate,Grad_Marital_Status_Code,Grad_Nationality,Grad_Nationality_of_Mother,Grad_Home_Emirate,Grad_Student_Campus,Grad_1st_Academic_Period,Grad_Student_Degree,Grad_Area_of_Specialization,Grad_Student_Major,Grad_Major_CIP,Grad_Minor,Grad_Program_Code,Grad_Mode_of_Study,Grad_Master_Thesis_Title,Grad_PhD_Dissertation_Title,Grad_Total_Credits_Cumulated,Grad_GPA_Cumulative,Grad_Total_Academic_Periods_Regular,Grad_Total_Academic_Periods_Supplementary,Grad_Submission_Term";
                    string[] columns = columnnames.Split(new string[] { "," },StringSplitOptions.None);
                    if (dt1.Columns.Count>0)
                    {
                        for(int j=0;j<dt1.Columns.Count;j++)
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