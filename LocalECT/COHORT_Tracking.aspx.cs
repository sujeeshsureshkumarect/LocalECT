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
    public partial class Report_Cohort_Tracking : System.Web.UI.Page
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
            string gender = "";
            int byteShift1 = 3;
            int byteShift2 = 4;
            int byteShift3 = 8;
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                Campus = InitializeModule.EnumCampus.Males;
                gender = "M";
                 byteShift1 = 3;
                 byteShift2 = 4;
                 byteShift3 = 8;
            }
            else
            {
                Campus = InitializeModule.EnumCampus.Females;
                gender = "F";
                byteShift1 = 1;
                byteShift2 = 2;
                byteShift3 = 9;
            }
            int iCSem = 0;
            int iCYear = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out iCSem);
            int iCurrent = (iCYear * 10) + iCSem;
            int iTerm =Convert.ToInt32(ddlRegTerm.SelectedItem.Value);

            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("SELECT [intStudyYear]*10+[byteSemester] as Term FROM [ECTData].[dbo].[Reg_Semesters] where [intStudyYear]*10+[byteSemester] between @iTerm and @iCurrent", sc);
            cmd.Parameters.AddWithValue("@iTerm", ddlRegTerm.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@iCurrent", iCurrent);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    string subquery = "";
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        subquery += "MAX((CASE WHEN RTerm = " + dt.Rows[i]["Term"].ToString() + " THEN RSID + '-' + Major ELSE '1' END)) AS [" + dt.Rows[i]["Term"].ToString() + "],";
                    }
                    subquery = subquery.Remove(subquery.Length - 1, 1);

                    string remainquery = "SELECT DT.InTerm, DT.SID, '" + gender + "' AS Gender, DT.sReference, S_1.LTR, S_1.SID AS LSID, S_1.LMajor, S_1.ETerm, S_1.Status," + subquery + " ";
                    remainquery += "FROM         (SELECT     TOP (100) PERCENT A.intStudyYear * 10 + A.byteSemester AS InTerm, A.lngStudentNumber AS SID, SD.iUnifiedID AS UID, A.sReference, R.RTerm, ";
                    remainquery += "R.SID AS RSID, R.Major FROM Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial LEFT OUTER JOIN ";
                    remainquery += "(SELECT     SD.iUnifiedID AS UID, SM.intStudyYear * 10 + SM.byteSemester AS RTerm, SM.lngStudentNumber AS SID, M.sUnified AS Major ";
                    remainquery += "FROM Reg_Specializations AS M INNER JOIN Reg_Students_Data AS SD INNER JOIN Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN ";
                    remainquery += "Reg_Student_Majors AS SM ON A.lngStudentNumber = SM.lngStudentNumber ON M.strDegree = SM.strDegree AND ";
                    remainquery += "M.strSpecialization = SM.strMajor WHERE      (SM.intStudyYear * 10 + SM.byteSemester >= " + iTerm + ")) AS R ON SD.iUnifiedID = R.UID LEFT OUTER JOIN ";
                    remainquery += "Reg_Applications AS A0 ON A.sReference = A0.lngStudentNumber ";
                    remainquery += "WHERE      (A0.lngStudentNumber IS NULL) AND (A.intStudyYear * 10 + A.byteSemester = " + iTerm + ") AND (A.strSpecialization <> N'999') AND (SD.byteShift = " + byteShift1 + " OR ";
                    remainquery += "SD.byteShift = " + byteShift2 + " OR SD.byteShift = " + byteShift3 + ") OR (A.intStudyYear * 10 + A.byteSemester = " + iTerm + ") AND (A.strSpecialization <> N'999') AND (SD.byteShift = " + byteShift1 + " OR ";
                    remainquery += "SD.byteShift = " + byteShift2 + " OR SD.byteShift = " + byteShift3 + ") AND (A0.byteCancelReason = 3) ORDER BY SID, R.RTerm) AS DT INNER JOIN (SELECT     LT.UID, LT.LTR, LSM.SID, LSM.LMajor, LSM.ETerm, LSM.Status ";
                    remainquery += "FROM          (SELECT     SD.iUnifiedID AS UID, MAX(SM.intStudyYear * 10 + SM.byteSemester) AS LTR ";
                    remainquery += "FROM          Reg_Specializations AS M INNER JOIN Reg_Students_Data AS SD INNER JOIN Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN ";
                    remainquery += "Reg_Student_Majors AS SM ON A.lngStudentNumber = SM.lngStudentNumber ON M.strDegree = SM.strDegree AND M.strSpecialization = SM.strMajor ";
                    remainquery += "GROUP BY SD.iUnifiedID HAVING      (MAX(SM.intStudyYear * 10 + SM.byteSemester) >= " + iTerm + ")) AS LT INNER JOIN ";
                    remainquery += "(SELECT     SD.iUnifiedID AS UID, SM.intStudyYear * 10 + SM.byteSemester AS RTerm, SM.lngStudentNumber AS SID, M.sUnified AS LMajor,  ";
                    remainquery += "  A.intGraduationYear * 10 + A.byteGraduationSemester AS ETerm, S.strReasonDesc AS Status ";
                    remainquery += "FROM          Reg_Specializations AS M INNER JOIN Reg_Students_Data AS SD INNER JOIN Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN ";
                    remainquery += "Reg_Student_Majors AS SM ON A.lngStudentNumber = SM.lngStudentNumber ON M.strDegree = SM.strDegree AND ";
                    remainquery += "M.strSpecialization = SM.strMajor LEFT OUTER JOIN Lkp_Reasons AS S ON A.byteCancelReason = S.byteReason ";
                    remainquery += "WHERE      (SM.intStudyYear * 10 + SM.byteSemester >= " + iTerm + ")) AS LSM ON LT.UID = LSM.UID AND LT.LTR = LSM.RTerm) AS S_1 ON ";
                    remainquery += " DT.UID = S_1.UID GROUP BY DT.InTerm, DT.SID, DT.sReference, S_1.LTR, S_1.SID, S_1.LMajor, S_1.ETerm, S_1.Status ORDER BY DT.SID";

                    SqlCommand cmd1 = new SqlCommand(remainquery, sc);
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    try
                    {
                        sc.Open();
                        da1.Fill(dt1);
                        sc.Close();

                        if (dt1.Rows.Count > 0)
                        {
                            int colcount = dt1.Columns.Count;
                            foreach (DataRow row in dt1.Rows)
                            {
                                if(row["Status"].ToString()=="Graduated")
                                {
                                    if(!string.IsNullOrEmpty(row["ETerm"].ToString()))
                                    {
                                        int ETerm =Convert.ToInt32(row["ETerm"]);
                                        int iESem = 0;
                                        int iEYear = LibraryMOD.SeperateTerm(ETerm, out iESem);
                                        if(iESem == 4)//Next Sem
                                        {
                                            iESem = 1;
                                            iEYear = iEYear + 1;
                                            ETerm = (iEYear * 10) + iESem;
                                        }
                                        else
                                        {
                                            iESem = iESem + 1;
                                            ETerm= (iEYear * 10) + iESem;
                                        }
                                        //row[ETerm.ToString()] = "Graduated";
                                        int index = row.Table.Columns[ETerm.ToString()].Ordinal;
                                        for(int j= index; j<colcount;j++)
                                        {
                                            row[j] = row["Status"].ToString();
                                        }
                                    }                                    
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(row["ETerm"].ToString()))
                                    {
                                        int ETerm = Convert.ToInt32(row["ETerm"]);
                                        int iESem = 0;
                                        int iEYear = LibraryMOD.SeperateTerm(ETerm, out iESem);
                                        //if (iESem == 4)//Next Sem
                                        //{
                                        //    iESem = 1;
                                        //    iEYear = iEYear + 1;
                                        //    ETerm = (iEYear * 10) + iESem;
                                        //}
                                        //else
                                        //{
                                        //    iESem = iESem + 1;
                                        //    ETerm = (iEYear * 10) + iESem;
                                        //}
                                        ////row[ETerm.ToString()] = "Graduated";
                                        int index = row.Table.Columns[ETerm.ToString()].Ordinal;
                                        for (int j = index; j < colcount; j++)
                                        {
                                            row[j] = row["Status"].ToString();
                                        }
                                    }
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
                    catch(Exception ex)
                    {
                        sc.Close();
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sc.Close();
                    }
                }
                else
                {
                    DynamicTable.Text = "<p><b>No Results to show</b></p>";
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
        }
    }
}