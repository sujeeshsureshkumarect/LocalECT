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
    public partial class CHEDS_New_Scholarship : System.Web.UI.Page
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
            remainquery += "SET @iRegYear="+ iRegYear + " ";
            remainquery += "SET @iRegSem="+ iRegSem + " ";
            remainquery += "SET @iRegTerm=@iRegYear*10+@iRegSem ";
            remainquery += "SELECT     TOP (100) PERCENT 32 AS [Institution Code], 'Emirates College of Technology' AS [Institution Name], DS.iCHEDSCode AS [Academic Period],  ";
            remainquery += "                      REPLACE(A.lngStudentNumber, '.', '') AS [Student ID], ISNULL(REPLACE(SD.strNationalID, '-', ''),'999999999999999') AS [Emirates ID], SD.strLastDescEn AS [Name (EN)], ISNULL(SD.strLastDescAr,  ";
            remainquery += "                      N'') AS [Name (AR)], (CASE WHEN SD.bSex = 1 THEN 'M' ELSE 'F' END) AS Gender, CONVERT(VARCHAR, YEAR(SD.dateBirth)) + '-' + CONVERT(VARCHAR,  ";
            remainquery += "                      MONTH(SD.dateBirth)) + '-' + CONVERT(VARCHAR, DAY(SD.dateBirth)) AS [Student DOB], N.sCHEDSCode AS Nationality, 'CN' AS [Level], 0 AS [CIP Family code],  ";
            remainquery += "                      0 AS [Program Code], ST.sCHEDSCode AS [Scholarship Type], 'IN' AS [Provider type], 'Emirates College of Technology' AS PName, ISNULL(SSD.curDiscount, 0)  ";
            remainquery += "                      AS SValue, ISNULL(SSD.cTuitionFees, 0) AS SAmount, SDU.sCHEDSCode AS Duration, D.strDiscountDesc, AC.strAccountNo ";
            remainquery += "FROM         Reg_Applications AS A INNER JOIN ";
            remainquery += "                      Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN ";
            remainquery += "                      Reg_Student_Accounts AS AC ON A.lngStudentNumber = AC.lngStudentNumber INNER JOIN ";
            remainquery += "                      Reg_Discounts AS D INNER JOIN ";
            remainquery += "                      Reg_Student_Discounts AS SSD ON D.byteDiscountType = SSD.byteDiscountType INNER JOIN ";
            remainquery += "                      Lkp_Scholarship_Duration AS SDU ON D.iDuration = SDU.iSerial INNER JOIN ";
            remainquery += "                      Lkp_Scholarship_Type AS ST ON D.iScholarshipType = ST.iSerial ON A.lngStudentNumber = SSD.lngStudentNumber INNER JOIN ";
            remainquery += "                      Reg_Semesters AS DS ON SSD.intStudyYear = DS.intStudyYear AND SSD.byteSemester = DS.byteSemester INNER JOIN ";
            remainquery += "                      Lkp_Nationalities AS N ON SD.byteNationality = N.byteNationality ";
            remainquery += "WHERE     (SSD.intStudyYear * 10 + SSD.byteSemester = @iRegTerm) ";
            remainquery += "ORDER BY [Student ID], D.strDiscountDesc ";
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
                    string columnnames = "Sch_Institution_Code,Sch_Institution_Name,Sch_Academic_Period,Sch_Student_ID,Sch_Emirates_ID,Sch_Student_Name_English,Sch_Student_Name_Arabic,Sch_Gender,Sch_Student_DOB,Sch_Nationality,Sch_Student_Level,Sch_Area_of_Specialization,Sch_Program_Code,Sch_Scholarship_Type,Sch_Scholarship_Provider_Type ,Sch_Scholarship_Provider_Name ,Sch_Scholarship_Value,Sch_Scholarship_Amount,Sch_Scholarship_Duration,strDiscountDesc,strAccountNo";
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