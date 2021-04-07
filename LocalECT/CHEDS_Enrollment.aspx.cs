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
    public partial class CHEDS_Enrollment : System.Web.UI.Page
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
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                Campus = InitializeModule.EnumCampus.Males;
            }
            else
            {
                Campus = InitializeModule.EnumCampus.Females;
            }

            int iRegYear = 0;
            int iRegSem = 0;
            int iRegTerm = 0;
            iRegTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
            iRegYear = LibraryMOD.SeperateTerm(iRegTerm, out iRegSem);

            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            string remainquery = "Declare @iRegYear int ";
            remainquery += "Declare @iRegSem int ";
            remainquery += "Declare @iRegTerm int ";
            remainquery += "Declare @iPrvYear int ";
            remainquery += "Declare @iPrvSem int ";
            remainquery += "SET @iRegYear=" + iRegYear + " ";
            remainquery += "SET @iRegSem=" + iRegSem + " ";
            remainquery += "SET @iRegTerm=@iRegYear*10+@iRegSem ";
            remainquery += "SET @iPrvYear=@iRegYear ";
            remainquery += "SET @iPrvSem=@iRegSem-1 ";
            remainquery += "IF @iRegSem=1 BEGIN SET @iPrvSem=4 SET @iPrvYear=@iRegYear-1 END ";
            remainquery += "SELECT     32 AS [Institution Code], 'Emirates College of Technology' AS [Institution Name], RS.iCHEDSCode AS [Academic Period], REPLACE(A.lngStudentNumber, '.', '')  ";
            remainquery += "AS [Student ID], (CASE WHEN ISNULL(CONVERT(VARCHAR, SD.EthbaraNo), '0') = '0' THEN 'NA' ELSE CONVERT(VARCHAR, SD.EthbaraNo) END) AS [Al Ethbara],  ";
            remainquery += "REPLACE(SD.strNationalID, '-', '') AS [Emirates ID], (CASE WHEN SD.byteIDType = 2 THEN (CASE WHEN ISNULL(SD.strID, 'NA') = '0' THEN 'NA' ELSE ISNULL(SD.strID,  ";
            remainquery += "'NA') END) ELSE 'NA' END) AS Passport, '' AS [EID Missing?], ISNULL(SD.FamilyBookNumber, '999999') AS [Family Book Number], ISNULL(SD.FamilyID, '999')  ";
            remainquery += "AS [Family Number], ISNULL(SD.CityNumber, '999') AS [City Number], SD.strLastDescEn AS [Student Name (English)], SD.strLastDescAr AS [Student Name (Arabic)], ";
            remainquery += "(CASE WHEN SD.bSex = 1 THEN 'M' ELSE 'F' END) AS Gender, CONVERT(VARCHAR, YEAR(SD.dateBirth)) + '-' + CONVERT(VARCHAR, MONTH(SD.dateBirth)) ";
            remainquery += "+ '-' + CONVERT(VARCHAR, DAY(SD.dateBirth)) AS [Student DOB], SD.sECTemail AS [Student Email Address], dbo.CleanPhone(SD.strPhone1) ";
            remainquery += "AS [Student Mobile Number], (CASE WHEN ISNULL(DT.iSerial, 0) = 0 THEN 'N' ELSE 'Y' END) AS [Determination Indicator], ";
            remainquery += "DT.CHEDSCode AS [Determination Category], MS.sCHEDSCode AS [Marital Status], N.sCHEDSCode AS Nationality, ISNULL(MN.sCHEDSCode, N.sCHEDSCode) ";
            remainquery += "AS [Nationality of Mother], ISNULL(HE.sCHEDSCode, 'AD') AS [Home Emirate], 'AD' AS [Student Campus], dbo.GetCHEDSSTTypeNew(@iRegYear, @iRegSem, ";
            remainquery += "A.lngStudentNumber) AS [Student Type], FS.iCHEDSCode AS [1st Academic Period], dbo.GetCHEDSSTLevelNew(dbo.Completed_Successfully(SM.lngStudentNumber, ";
            remainquery += "@iPrvYear, @iPrvSem, SM.strDegree, SM.strMajor), SM.strDegree, SM.strMajor) AS [Student Level], ";
            remainquery += "(CASE WHEN SM.strDegree = '3' THEN 'BA' WHEN SM.strDegree = '2' THEN 'FD' WHEN SM.strDegree = '1' AND SM.strMajor <> '999' THEN 'DP' ELSE 'UD' END) ";
            remainquery += "AS [Student Degree], LEFT(M.strClass, 2) AS [Area of Specialization], M.strCaption AS Major, M.strClass AS [CIP Major], '' AS Minor, ";
            remainquery += "M.sCHEDProgCode AS [Program Code], (CASE WHEN SM.strMajor = '999' THEN 'PT' ELSE 'FT' END) AS [Mode of Study], (CASE WHEN ISNULL(W.strWorkPlaceEn, ";
            remainquery += "'Not Working') = 'Not Working' THEN 'N' ELSE 'Y' END) AS [Employment Status], ES.sEmpSector AS [Employment Sector], SD.strJopTitle AS [Employment Position], ";
            remainquery += "0 AS [Required academic periods], 0 AS [Required Credits for Graduation], R.FHRS + R.MHRS AS [Currently Registered Credits], ISNULL(CRCRS.TReg, 0) ";
            remainquery += "AS [Total Credits Registered], dbo.Completed_Successfully(SM.lngStudentNumber, @iPrvYear, @iPrvSem, SM.strDegree, SM.strMajor) AS [Total Credits Completed], ";
            remainquery += "dbo.GetCGPA(SM.lngStudentNumber, @iPrvYear, @iPrvSem, SM.strDegree, SM.strMajor) AS CGPA, ISNULL(dbo.GetMaxTCCollege(A.lngStudentNumber), '') ";
            remainquery += "AS [Transfer Institution], ISNULL(TC.TC_Hours, 0) AS [Transfer Credits], (CASE WHEN ISNULL(ENG.Mark, 0) = 0 THEN '' ELSE ENG.iCHEDSCode END) AS ENG, ";
            remainquery += "(CASE WHEN ISNULL(ENG.Mark, 0) = 0 THEN '' ELSE LEFT(CONVERT(varchar, ENGD.ENGDate, 121), 10) END) AS ENG_Date, ISNULL(ENG.Mark, '') AS SCORE, ";
            remainquery += "'' AS [Standardized Test Name], '' AS [Standardized Test Score], ISNULL(HSchools.CountryCode, N'UN') AS HS_Country, ISNULL(HSchools.HSSystem, N'UN') ";
            remainquery += "AS HS_SYS, ISNULL(HSchools.sngGrade, 0) AS HS_Score, ISNULL(dbo.CHEDS_Year_Format(HSchools.intGraduationYear), 999999) AS HSYear, ";
            remainquery += "ISNULL(HSchools.HSIndicator, N'U') AS HSIndicator, ISNULL(HSchools.HSAppNo, N'') AS HSAppNo, HSchools.G12, ISNULL(LD.sCHEDSCode, N'UD') AS RDegree, ";
            remainquery += "(CASE WHEN ISNULL(LD.sCHEDSCode, 'UD') = 'UD' THEN 'NA' WHEN ISNULL(LD.sCHEDSCode, 'UD') = 'NE' THEN 'NA' ELSE ISNULL(strCollegeDescEn, 'NA') END) ";
            remainquery += "AS [LD College], (CASE WHEN ISNULL(LD.sCHEDSCode, 'UD') = 'UD' THEN 'UN' WHEN ISNULL(LD.sCHEDSCode, 'UD') = 'NE' THEN 'UN' ELSE LDC.sCHEDSCode END) ";
            remainquery += "AS [LD Country], '' AS [Institution CODE], (CASE WHEN ISNULL(LD.sCHEDSCode, 'UD') = 'UD' THEN 0 WHEN ISNULL(LD.sCHEDSCode, 'UD') ";
            remainquery += "= 'NE' THEN '' ELSE isnull(A.curLastCGPA, 0) END) AS [LD CGPA], (CASE WHEN ISNULL(LD.sCHEDSCode, 'UD') = 'UD' THEN 999999 WHEN ISNULL(LD.sCHEDSCode, ";
            remainquery += "'UD') = 'NE' THEN 999999 ELSE ISNULL(dbo.CHEDS_Year_Format(A.intLastDegreeYear), 999999) END) AS [LD Year], (CASE WHEN ISNULL(LD.sCHEDSCode, 'UD') ";
            remainquery += "= 'UD' THEN 'U' WHEN ISNULL(LD.sCHEDSCode, 'UD') = 'NE' THEN 'U' ELSE ISNULL(LHEEquivalencyIndicator, 'U') END) AS [LD Indicator], ";
            remainquery += "(CASE WHEN ISNULL(LHEEquivalencyIndicator, 'U') = 'U' THEN '' WHEN ISNULL(LHEEquivalencyIndicator, 'U') = 'T' THEN '' WHEN ISNULL(LHEEquivalencyIndicator, ";
            remainquery += "'U') = 'N' THEN '' ELSE ISNULL(LHEEquivalencyAppNo, '') END) AS [LD APP NO], '' AS [Research Topic], '' AS [Research Area], '' AS ORCID, 'N' AS Outgoing, ";
            remainquery += "'N' AS Ingoing, '' AS Exchange, M.intStudyHours AS [PLAN], S.strReasonDesc AS Status, A.intGraduationYear * 10 + A.byteGraduationSemester AS STerm ";
            remainquery += "FROM         (SELECT     iYear, Sem, Student, MHRS, FHRS ";
            remainquery += "FROM          Reg_Both_Side AS RBS ";
            remainquery += "WHERE      (iYear = @iRegYear) AND (Sem = @iRegSem)) AS R INNER JOIN ";
            remainquery += "Reg_Student_Majors AS SM ON R.iYear = SM.intStudyYear AND R.Sem = SM.byteSemester AND R.Student = SM.lngStudentNumber INNER JOIN ";
            remainquery += "Reg_Applications AS A INNER JOIN ";
            remainquery += "Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON R.Student = A.lngStudentNumber INNER JOIN ";
            remainquery += "Reg_Semesters AS RS ON SM.intStudyYear = RS.intStudyYear AND SM.byteSemester = RS.byteSemester INNER JOIN ";
            remainquery += "Lkp_Nationalities AS N ON SD.byteNationality = N.byteNationality INNER JOIN ";
            remainquery += "Reg_Semesters AS FS ON A.intStudyYear = FS.intStudyYear AND A.byteSemester = FS.byteSemester INNER JOIN ";
            remainquery += "Reg_Specializations AS M ON SM.strDegree = M.strDegree AND SM.strMajor = M.strSpecialization INNER JOIN ";
            remainquery += "Lkp_Work_Places AS W ON SD.intWorkPlace = W.intWorkPlace LEFT OUTER JOIN ";
            remainquery += "Lkp_Employment_Sector AS ES ON SD.EmploymentSector = ES.iSector LEFT OUTER JOIN ";
            remainquery += "Lkp_Reasons AS S ON A.byteCancelReason = S.byteReason LEFT OUTER JOIN ";
            remainquery += "(SELECT     Student, SUM(MHRS + FHRS) AS TReg ";
            remainquery += "FROM          Reg_Both_Side AS RBSR ";
            remainquery += "WHERE      (iYear * 10 + Sem < @iRegTerm) ";
            remainquery += "GROUP BY Student) AS CRCRS ON A.lngStudentNumber = CRCRS.Student LEFT OUTER JOIN ";
            remainquery += "Lkp_Foreign_Colleges AS LDCL ON A.byteLastDegreeInistitution = LDCL.byteCollege LEFT OUTER JOIN ";
            remainquery += "Lkp_Countries AS LDC ON A.byteLastDegreeCountry = LDC.byteCountry LEFT OUTER JOIN ";
            remainquery += "Reg_Degrees AS LD ON A.sLastDegree = LD.strDegree LEFT OUTER JOIN ";
            remainquery += "HSchools ON SD.lngSerial = HSchools.lngSerial LEFT OUTER JOIN ";
            remainquery += "CHEDS_ENG_DATES AS ENGD ON A.lngStudentNumber = ENGD.lngStudentNumber LEFT OUTER JOIN ";
            remainquery += "MaxEngCertMark AS ENG ON A.lngStudentNumber = ENG.lngStudentNumber LEFT OUTER JOIN ";
            remainquery += "CHEDS_TC_Courses AS TC ON A.lngStudentNumber = TC.lngStudentNumber LEFT OUTER JOIN ";
            remainquery += "Lkp_Emirates AS HE RIGHT OUTER JOIN ";
            remainquery += "Lkp_Cities AS HC ON HE.byteEmirate = HC.byteEmirate ON SD.byteHomeCountry = HC.byteCountry AND SD.byteOriginCountry = HC.byteCity LEFT OUTER JOIN ";
            remainquery += "Lkp_Nationalities AS MN ON SD.NationalityofMother = MN.byteNationality LEFT OUTER JOIN ";
            remainquery += "Lkp_Marital_Status AS MS ON SD.MaritalStatus = MS.iStatus LEFT OUTER JOIN ";
            remainquery += "Lkp_Determination_Type AS DT ON SD.intDelegation = DT.iSerial ";


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

                    foreach (DataRow row in dt1.Rows)
                    {
                        int Plan = 0;
                        int Total_Credits_Completed = 0;
                        int Total_Credits_Registered = 0;
                        double Required_Credits_for_Graduation = 0;
                        if (!string.IsNullOrEmpty(row["Plan"].ToString()))
                        {
                            Plan = Convert.ToInt32(row["Plan"]);
                        }
                        if (!string.IsNullOrEmpty(row["Total Credits Completed"].ToString()))
                        {
                            Total_Credits_Completed = Convert.ToInt32(row["Total Credits Completed"]);
                        }
                        if (!string.IsNullOrEmpty(row["Total Credits Registered"].ToString()))
                        {
                            Total_Credits_Registered = Convert.ToInt32(row["Total Credits Registered"]);
                        }
                        Required_Credits_for_Graduation = Plan - (Total_Credits_Completed + Total_Credits_Registered);
                        if(Required_Credits_for_Graduation<0)
                        {
                            Required_Credits_for_Graduation = 0;
                        }
                        row["Required Credits for Graduation"] = Required_Credits_for_Graduation;
                        double Required_academic_periods = Math.Ceiling(Required_Credits_for_Graduation / 15);
                        row["Required academic periods"] = Required_academic_periods;
                    }

                    string columnnames = "Institution Code,Institution Name,Academic Period,Student ID,Al Ethbara,Emirates ID,Passport Number,Reason why Emirates ID is missing,Family Book Number,Family Number,City Number,Student Name (English),Student Name (Arabic),Gender,Student DOB,Student Email Address,Student Mobile Number,People of Determination (Special Needs Indicator),People of Determination Category (Special Needs Category),Marital Status,Nationality,Nationality of Mother,Home Emirate(Emirates_Code),Student Campus(Campus_Code),Student Type(Type Code),1st Academic Period,Student Level(Level Code),Student Degree (Degree Code),Area of Specialization (CIP Family code),Student Major (text),Student Major (CIP Major Classification),Student Minor,Student Program (Program Code),Mode of Study(FT/PT),Employment Status,Employment Sector,Employment Position,Required academic periods for Graduation,Required Credits for Graduation,Currently Registered Credits,Total Credits Registered (cumulative - till last Academic period),Total Credits Completed (cumulative - till last Academic period),Overall GPA (cumulative - till last Academic period),Transfer Institution,Transfer Credits Cumulative,Language Test Proficiency Exam,Language Test Proficiency Exam Pass Date,Language Test Proficiency Exam Score,Standardized Test Name (for Masters and Above),Standardized Test Score (for Masters and Above),High School - Country Code,High School System,High School Exit Score,High School Completion Year,High School Equivalency Indicator,High School Equivalency Number,12th Grade stream (Stream Code),Last Completed Higher Education Degree,Last Completed Higher Education Institution Name,Last Completed Higher Education Institution Country,Last Completed Higher Education Institution CODE,Last Completed Higher Education Degree CGPA,Last Completed Higher Education - Year,Last Completed Higher Education - Equivalency Indicator,Last Completed Higher Education Equivalency Number,Research Topic,Research Area,ORCID,Outgoing Exchange student Indicator,Incoming Exchange Student Indicator,Exchange partner university code,PLAN,Status,STerm";
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