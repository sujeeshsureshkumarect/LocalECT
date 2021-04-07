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
    public partial class CHEDS_New_Internship : System.Web.UI.Page
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
            remainquery += "SET @iRegYear="+ iRegYear + " ";
            remainquery += "SET @iRegSem="+ iRegSem + " ";
            remainquery += "SET @iRegTerm=@iRegYear*10+@iRegSem ";
            remainquery += "SET @iPrvYear=@iRegYear ";
            remainquery += "SET @iPrvSem=@iRegSem-1 ";
            remainquery += "IF @iRegSem=1 ";
            remainquery += "BEGIN ";
            remainquery += "	SET @iPrvSem=4 ";
            remainquery += "	SET @iPrvYear=@iRegYear-1 ";
            remainquery += "END ";
            remainquery += "SELECT     32 AS [Institution Code], 'Emirates College of Technology' AS [Institution Name], RS.iCHEDSCode AS [Academic Period], REPLACE(A.lngStudentNumber, '.', '')  ";
            remainquery += "                      AS [Student ID], REPLACE(SD.strNationalID, '-', '') AS [Emirates ID], (CASE WHEN SD.byteIDType = 2 THEN (CASE WHEN ISNULL(SD.strID, 'NA')  ";
            remainquery += "                      = '0' THEN 'NA' ELSE ISNULL(SD.strID, 'NA') END) ELSE 'NA' END) AS Passport, SD.strLastDescEn AS [Student Name (English)],  ";
            remainquery += "                      SD.strLastDescAr AS [Student Name (Arabic)], (CASE WHEN SD.bSex = 1 THEN 'M' ELSE 'F' END) AS Gender, CONVERT(VARCHAR, YEAR(SD.dateBirth))  ";
            remainquery += "                      + '-' + CONVERT(VARCHAR, MONTH(SD.dateBirth)) + '-' + CONVERT(VARCHAR, DAY(SD.dateBirth)) AS [Student DOB], N.sCHEDSCode AS Nationality,  ";
            remainquery += "                      dbo.GetCHEDSSTLevelNew(dbo.Completed_Successfully(SM.lngStudentNumber, @iPrvYear, @iPrvSem, SM.strDegree, SM.strMajor), SM.strDegree, SM.strMajor)  ";
            remainquery += "                      AS [Student Level], LEFT(M.strClass, 2) AS [Area of Specialization], M.sCHEDProgCode AS [Program Code], '' AS [Internship Organization], '' AS [Internship Sector],  ";
            remainquery += "                      '' AS [Internship Industry], '' AS [Internship Duration], M.strCaption AS Major, Intern.Course ";
            remainquery += "FROM         (SELECT     iYear, Sem, Student, MHRS, FHRS ";
            remainquery += "                       FROM          Reg_Both_Side AS RBS ";
            remainquery += "                       WHERE      (iYear = @iRegYear) AND (Sem = @iRegSem)) AS R INNER JOIN ";
            remainquery += "                      Reg_Student_Majors AS SM ON R.iYear = SM.intStudyYear AND R.Sem = SM.byteSemester AND R.Student = SM.lngStudentNumber INNER JOIN ";
            remainquery += "                      Reg_Applications AS A INNER JOIN ";
            remainquery += "                      Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON R.Student = A.lngStudentNumber INNER JOIN ";
            remainquery += "                      Reg_Semesters AS RS ON SM.intStudyYear = RS.intStudyYear AND SM.byteSemester = RS.byteSemester INNER JOIN ";
            remainquery += "                      Lkp_Nationalities AS N ON SD.byteNationality = N.byteNationality INNER JOIN ";
            remainquery += "                      Reg_Specializations AS M ON SM.strDegree = M.strDegree AND SM.strMajor = M.strSpecialization INNER JOIN ";
            remainquery += "                          (SELECT     iYear, Sem, Student, Course ";
            remainquery += "                            FROM          Course_Balance_View ";
            remainquery += "                            WHERE      (iYear * 10 + Sem = @iRegTerm) AND (Course IN ";
            remainquery += "                                                       (SELECT     strCourse ";
            remainquery += "                                                         FROM          Reg_Courses ";
            remainquery += "                                                         WHERE      (strCourseDescEn LIKE N'%nternship%') OR ";
            remainquery += "                                                                                (strCourseDescEn LIKE N'%تدريب%')))) AS Intern ON SM.intStudyYear = Intern.iYear AND SM.byteSemester = Intern.Sem AND  ";
            remainquery += "                      SM.lngStudentNumber = Intern.Student ";
            remainquery += "WHERE     (SM.intStudyYear * 10 + SM.byteSemester = @iRegTerm) ";
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
                    string columnnames = "Internship_Institution_Code,Internship_Institution_Name,Internship_Academic_Period,Internship_Student_ID,Internship_Emirates_ID,Internship_Passport_Number,Internship_Student_Name_English,Internship_Student_Name_Arabic,Internship_Gender,Internship_Student_DOB,Internship_Nationality,Internship_Student_Level,Internship_Area_of_Specialization,Internship_Program_Code,Internship_Organization,Internship_Sector,Internship_Industry,Internship_Duration,Major,Course";
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