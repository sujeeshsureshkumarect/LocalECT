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
    public partial class CHEDS_New_Applicants : System.Web.UI.Page
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
            iRegTerm = Convert.ToInt32(ddlRegTerm.SelectedValue);
            iRegYear = LibraryMOD.SeperateTerm(iRegTerm, out iRegSem);

            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            string remainquery = "Declare @iRegYear int ";
            remainquery += "Declare @iRegSem int ";
            remainquery += "Declare @iRegTerm int ";
            remainquery += "SET @iRegYear="+ iRegYear + " ";
            remainquery += "SET @iRegSem="+ iRegSem + " ";
            remainquery += "SET @iRegTerm=@iRegYear*10+@iRegSem ";
            remainquery += "SELECT        32 AS [Institution Code], 'Emirates College of Technology' AS [Institution Name], RS.iCHEDSCode AS [Academic Period], (CASE WHEN ISNULL(SM.strDegree, A.strDegree) = '3' THEN 'BA' WHEN ISNULL(SM.strDegree,  ";
            remainquery += "                         A.strDegree) = '2' THEN 'FD' WHEN ISNULL(SM.strDegree, A.strDegree) = '1' AND ISNULL(SM.strMajor, A.strSpecialization) <> '999' THEN 'DP' ELSE 'UD' END) AS [Student Degree], LEFT(ISNULL(RM.strClass, CM.strClass), 2)  ";
            remainquery += "                         AS [Area of Specialization], MEC.iCHEDSCode AS [Test/Exam], MEC.Mark AS [Exam Score],A.lngStudentNumber AS SID, SD.strLastDescEn AS Name, RBS.MCRS + RBS.FCRS AS Registered,   ";
            remainquery += "                         Lkp_Reasons.strReasonDesc ";
            remainquery += "FROM            Reg_Semesters AS RS INNER JOIN ";
            remainquery += "                         Reg_Students_Data AS SD INNER JOIN ";
            remainquery += "                         Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN ";
            remainquery += "                         Reg_Specializations AS CM ON A.strCollege = CM.strCollege AND A.strDegree = CM.strDegree AND A.strSpecialization = CM.strSpecialization ON RS.intStudyYear = A.intStudyYear AND  ";
            remainquery += "                         RS.byteSemester = A.byteSemester LEFT OUTER JOIN ";
            remainquery += "                         Lkp_Reasons ON A.byteCancelReason = Lkp_Reasons.byteReason LEFT OUTER JOIN ";
            remainquery += "                         MaxEngCertMark AS MEC ON SD.lngSerial = MEC.lngSerial LEFT OUTER JOIN ";
            remainquery += "                         Reg_Applications AS EXS ON A.intStudyYear = EXS.intStudyYear AND A.byteSemester = EXS.byteSemester AND A.lngStudentNumber = EXS.sReference LEFT OUTER JOIN ";
            remainquery += "                         Reg_Both_Side AS RBS ON A.lngStudentNumber = RBS.Student AND A.intStudyYear = RBS.iYear AND A.byteSemester = RBS.Sem LEFT OUTER JOIN ";
            remainquery += "                         Reg_Specializations AS RM RIGHT OUTER JOIN ";
            remainquery += "                         Reg_Student_Majors AS SM ON RM.strDegree = SM.strDegree AND RM.strSpecialization = SM.strMajor ON RBS.iYear = SM.intStudyYear AND RBS.Sem = SM.byteSemester AND RBS.Student = SM.lngStudentNumber ";
            remainquery += "WHERE        (SD.byteShift = "+ byteShift1 + " OR ";
            remainquery += "                         SD.byteShift = "+ byteShift2 + " OR ";
            remainquery += "                         SD.byteShift = "+ byteShift3 + ") AND (EXS.sReference IS NULL) AND (A.intStudyYear = @iRegYear) AND (A.byteSemester = @iRegSem)	 ";
            remainquery += "						 ";
            remainquery += "ORDER BY Name ";
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
                    //string columnnames = "Sch_Institution_Code,Sch_Institution_Name,Sch_Academic_Period,Sch_Student_ID,Sch_Emirates_ID,Sch_Student_Name_English,Sch_Student_Name_Arabic,Sch_Gender,Sch_Student_DOB,Sch_Nationality,Sch_Student_Level,Sch_Area_of_Specialization,Sch_Program_Code,Sch_Scholarship_Type,Sch_Scholarship_Provider_Type ,Sch_Scholarship_Provider_Name ,Sch_Scholarship_Value,Sch_Scholarship_Amount,Sch_Scholarship_Duration,strDiscountDesc,strAccountNo";
                    //string[] columns = columnnames.Split(new string[] { "," }, StringSplitOptions.None);
                    //if (dt1.Columns.Count > 0)
                    //{
                    //    for (int j = 0; j < dt1.Columns.Count; j++)
                    //    {
                    //        dt1.Columns[j].ColumnName = columns[j].ToString();
                    //    }
                    //}

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