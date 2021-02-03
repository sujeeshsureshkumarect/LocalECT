using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Threading;

namespace LocalECT
{
    public partial class Transcript : System.Web.UI.Page
    {
        public struct MCourse
        {
            public string sCourse;
            public bool isElective;
        }

        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        int CurrentRole = 0;
        string sNo = "";
        //Event for the Search Control
        protected void Search1_ChangedEvent(object Sender, EventArgs e)
        {
            string sid = Request.QueryString["sid"];
            sSelectedValue.Value = sid;
            sSelectedText.Value = getstudentname(sid);
            //sSelectedValue.Value = e.SValue1;
            //sSelectedText.Value = e.SValue2;
            sNo = sSelectedValue.Value;

            bool isEnable = Enable_Disable(sNo, false);

            Print_btn.Enabled = isEnable;


        }
        public string getstudentname(string sid)
        {
            string sName = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("select * from Web_Students_Search where sNo=@sNo", Conn);
            cmd.Parameters.AddWithValue("@sNo", sid);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                Conn.Open();
                da.Fill(dt);
                Conn.Close();
                if (dt.Rows.Count > 0)
                {
                    sName = dt.Rows[0]["sName"].ToString();
                }
            }
            catch (Exception ex)
            {
                Conn.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
            return sName;
        }
        protected void Search1_NewEvent(object Sender, EventArgs e)
        {
            sSelectedValue.Value = "";
            sSelectedText.Value = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Add Event Handler to the custom control
            //Search1.ChangedEvent += new Search.ChangedEventHandler(Search1_ChangedEvent);
            //Search1.NewEvent += new Search.ChangedEventHandler(Search1_NewEvent);

            sNo = sSelectedValue.Value;

            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {

                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Transcript,
                    InitializeModule.enumPrivilege.Transcript_ShowSignature, CurrentRole) == true)
                    {
                        chkSign.Visible = true;
                    }
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Transcript,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Transcript,
                    InitializeModule.enumPrivilege.ShowAll, CurrentRole) != true)
                    {
                        chkPrintAllStudents.Checked = false;
                        chkPrintAllStudents.Visible = false;
                        lblPath.Visible = false;
                        Path_txt.Visible = false;
                    }


                }
            }
            else
            {
                Server.Transfer("Login.aspx");
            }
            divMsg.InnerText = "";

            if (!IsPostBack)
            {
                if (Session["CurrentCampus"] != null)
                {
                    string sCampus = Session["CurrentCampus"].ToString();
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    //Campus_ddl.SelectedValue = ((int)Campus).ToString();
                }
                FillTerms();
                //============================


                if (Request.QueryString["PreviousTerm"] != null)
                {
                    Term_ddl.SelectedValue = Request.QueryString["PreviousTerm"].ToString();
                    isCurrent_chk.Checked = false;

                    sSelectedValue.Value = Session["CurrentStudent"].ToString();
                    sSelectedText.Value = Session["CurrentStudentName"].ToString();
                    sNo = sSelectedValue.Value;
                    Export(InitializeModule.ECT_Buttons.Print);
                }
                else
                {
                    int iYear = 0;
                    int iSem = 0;
                    int iPrevYear = 0;
                    byte bPrevSemester = 0;
                    int iTerm = LibraryMOD.GetCurrentTerm();

                    Term_ddl.SelectedValue = iTerm.ToString();

                    iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

                    if (iSem == 1)
                    {
                        bPrevSemester = 4;
                        iPrevYear = iYear - 1;
                    }
                    else
                    {
                        bPrevSemester = byte.Parse((iSem - 1).ToString());
                        iPrevYear = iYear;
                    }

                    int iPrevTerm = (iPrevYear * 10) + bPrevSemester;

                    Term_ddl.SelectedValue = iPrevTerm.ToString();
                }

                //=========================
            }
            else
            {
                //switch (Campus_ddl.SelectedIndex)
                //{
                //    case 0:
                //    case 2:
                //        Campus = InitializeModule.EnumCampus.Males;
                //        break;
                //    case 1:
                //    case 3:
                //        Campus = InitializeModule.EnumCampus.Females;
                //        break;
                //}
            }
            //Search1.Campus = Campus;

        }

        private void FillTerms()
        {
            List<Semesters> myTerms = new List<Semesters>();
            SemesterDAL myTermsDAL = new SemesterDAL();
            try
            {
                int iTerm = 0;

                iTerm = LibraryMOD.GetCurrentTerm();
                myTerms = myTermsDAL.GetTerms(InitializeModule.EnumCampus.ECTNew, " Where Term<" + iTerm, true);
                for (int i = 0; i < myTerms.Count; i++)
                {
                    Term_ddl.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));

                }

            }
            catch (Exception ex)
            {

                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myTerms.Clear();

            }
        }

        protected void PrintCMD_Click(object sender, ImageClickEventArgs e)
        {


            if (!chkPrintAllStudents.Checked)
            {
                bool isEnable = Enable_Disable(sNo, true);
                Print_btn.Enabled = isEnable;
                if (!isEnable)
                {
                    return;
                }
                Export(InitializeModule.ECT_Buttons.Print);
            }
            else
            {
                if (Path_txt.Text.Trim().Length == 0)
                {
                    //divMsg.InnerText = "Please enter files path. Ex: c:" + "\\" + "FolderName";
                    lbl_Msg.Text = "Please enter files path. Ex: c:" + "\\" + "FolderName";
                    div_msg.Visible = true;
                }
                Export(InitializeModule.ECT_Buttons.Print, true, Path_txt.Text);
            }
        }
        private string GetStudentMaxEnglishMark(string sStudentID, out string sENG)
        {
            string sMark = "";
            sENG = "";
            Connection_StringCLS MyConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(MyConnection_String.Conn_string);
            try
            {


                Conn.Open();
                string sSQL = "SELECT strCert,Mark FROM MaxEngCertMark WHERE lngStudentNumber='" + sStudentID + "'";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);

                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    sENG = Rd["strCert"].ToString();
                    sMark = string.Format("{0:F}", Convert.ToDecimal(Rd["Mark"]));
                }

                Rd.Close();
            }
            catch (Exception ex)
            {

                LibraryMOD.ShowErrorMessage(ex);
                divMsg.InnerText = ex.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sMark;
        }


        private void Export(InitializeModule.ECT_Buttons iExport, bool PrintAllStudents, string sFile)
        {
            ReportDocument myReport = new ReportDocument();
            Connection_StringCLS MyConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(MyConnection_String.Conn_string);
            Conn.Open();
            try

            {

                int iTerm = 0;
                int iYear = 0;
                int iSem = 0;

                iTerm = int.Parse(Term_ddl.SelectedValue);
                if (iTerm == 0)
                {
                    //divMsg.InnerText = "Select Term Please ...";
                    lbl_Msg.Text = "Select Term Please ...";
                    div_msg.Visible = true;
                    return;
                }

                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);
                //Get Trans Header
                DataSet rptDS = new DataSet();

                string sSQL = "SELECT A.lngStudentNumber AS sSNO ";
                sSQL += " , SD.strLastDescEn AS sName, M.strDisplay AS sMajor";
                sSQL += " ,  HS.dHS, HS.sSchool, HS.sCountry";
                sSQL += " , A.strCollege, A.strDegree";
                sSQL += " , A.strSpecialization, R.strReasonDesc AS sStatus,";
                sSQL += " bOtherCollege as ACCStatus,A.byteStudentType,COUNT(GH.strGrade) AS Grades";

                ////Without Indexing

                //sSQL += " FROM Reg_Specializations AS M INNER JOIN Reg_Applications AS A INNER JOIN";
                //sSQL += " Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON M.strCollege = A.strCollege AND M.strDegree = A.strDegree AND ";
                //sSQL += " M.strSpecialization = A.strSpecialization INNER JOIN Reg_Grade_Header AS GH ON A.lngStudentNumber = GH.lngStudentNumber LEFT OUTER JOIN";
                //sSQL += " (SELECT Q.lngSerial, Q.sngGrade AS dHS, Q.strCertificateSource AS sSchool, C.strCountryDescEn AS sCountry FROM Lkp_Countries AS C RIGHT OUTER JOIN";
                //sSQL += " Reg_Student_Qualifications AS Q ON C.byteCountry = Q.byteInstituteCountry WHERE     (Q.intCertificate = 1)) AS HS ON";
                //sSQL += " A.lngSerial = HS.lngSerial LEFT OUTER JOIN Lkp_Reasons AS R ON A.byteCancelReason = R.byteReason";

                ////With Indexing

                sSQL += " FROM Reg_Specializations AS M INNER JOIN Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON M.strCollege = A.strCollege AND M.strDegree = A.strDegree AND ";
                sSQL += " M.strSpecialization = A.strSpecialization INNER JOIN Reg_Grade_Header AS GH ON A.lngStudentNumber = GH.lngStudentNumber INNER JOIN";
                sSQL += " Student_Indexing AS SI ON A.lngStudentNumber = SI.sID LEFT OUTER JOIN (SELECT Q.lngSerial, Q.sngGrade AS dHS, Q.strCertificateSource AS sSchool, C.strCountryDescEn AS sCountry";
                sSQL += " FROM Lkp_Countries AS C RIGHT OUTER JOIN Reg_Student_Qualifications AS Q ON C.byteCountry = Q.byteInstituteCountry";
                sSQL += " WHERE (Q.intCertificate = 1)) AS HS ON A.lngSerial = HS.lngSerial LEFT OUTER JOIN Lkp_Reasons AS R ON A.byteCancelReason = R.byteReason";

                ////Current                       
                sSQL += " WHERE (GH.intStudyYear = " + iYear + ")";
                sSQL += " AND (GH.byteSemester = " + iSem + ")";
                //////All
                //sSQL += " WHERE ((GH.intStudyYear = " + iYear + ")";
                //sSQL += " AND (GH.byteSemester <= " + iSem + ") or (GH.intStudyYear < " + iYear + "))";

                ////With Indexing
                //sSQL += " AND SI.iSerial>110";

                if(Campus.ToString()=="Males")
                {
                    sSQL += " AND (M.iCampus = 1)";
                }
                else
                {
                    sSQL += " AND (M.iCampus = 2)";
                }

                //switch (Campus_ddl.SelectedIndex)
                //{
                //    case 0:
                //        sSQL += " AND (M.iCampus = 1)";
                //        break;
                //    case 1:
                //        sSQL += " AND (M.iCampus = 2)";
                //        break;
                //    case 2:
                //    case 3:
                //        sSQL += " AND (M.iCampus = 3)";
                //        break;
                //}
                //sSQL += " AND (SD.byteShift = 4)";
                sSQL += " GROUP BY A.lngStudentNumber, SD.strLastDescEn, M.strDisplay, HS.dHS, HS.sSchool, HS.sCountry, A.strCollege, A.strDegree, A.strSpecialization,R.strReasonDesc, A.byteStudentType, A.bOtherCollege";
                sSQL += " ORDER BY sSNO";


                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                //SELECT Transfered, Passed, curMarks, curGPA
                //FROM dbo.Trans_Record_Cumulative(,,,,) AS Trans_Record_Cumulative_1
                //SqlDataReader Rd_AllStudents = Cmd.ExecuteReader();
                DataSet ds_AllStudents = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(ds_AllStudents, "AllStudents");

                string sStudentNo = "";
                int i = 0;

                while (ds_AllStudents.Tables["AllStudents"].Rows.Count - 1 >= i)
                {
                    sStudentNo = ds_AllStudents.Tables["AllStudents"].Rows[i]["sSNO"].ToString();
                    string sName = "";
                    string sMajor = "";
                    string sSchool = "";
                    string sCountry = "";
                    string sStatus = "";
                    decimal dHS = 0;
                    string sCDegree = "";
                    string sCMajor = "";
                    bool isAccProblem = false;
                    int iType = 0;
                    bool isVisiting = false;
                    string sEnglishScore = "";
                    string sENG = "";
                    sEnglishScore = GetStudentMaxEnglishMark(sStudentNo, out sENG);
                    //while (Rd_AllStudents.Read())
                    //{
                    //    sStudentNo = Rd_AllStudents["sSNO"].ToString();
                    sName = ds_AllStudents.Tables["AllStudents"].Rows[i]["sName"].ToString();
                    sMajor = ds_AllStudents.Tables["AllStudents"].Rows[i]["sMajor"].ToString();
                    sSchool = ds_AllStudents.Tables["AllStudents"].Rows[i]["sSchool"].ToString();
                    sCountry = ds_AllStudents.Tables["AllStudents"].Rows[i]["sCountry"].ToString();
                    sStatus = ds_AllStudents.Tables["AllStudents"].Rows[i]["sStatus"].ToString();
                    sCDegree = ds_AllStudents.Tables["AllStudents"].Rows[i]["strDegree"].ToString();
                    sCMajor = ds_AllStudents.Tables["AllStudents"].Rows[i]["strSpecialization"].ToString();
                    dHS = Convert.ToDecimal("0" + ds_AllStudents.Tables["AllStudents"].Rows[i]["dHS"]);
                    isAccProblem = bool.Parse(ds_AllStudents.Tables["AllStudents"].Rows[i]["ACCStatus"].ToString());

                    if (ds_AllStudents.Tables["AllStudents"].Rows[i]["byteStudentType"].Equals(DBNull.Value))
                    {
                        iType = 0;
                    }
                    else
                    {
                        iType = int.Parse(ds_AllStudents.Tables["AllStudents"].Rows[i]["byteStudentType"].ToString());
                    }
                    isVisiting = (iType == 1);


                    //}
                    //Rd_AllStudents.Close();

                    //Ignore finance problem
                    //if (isAccProblem)
                    //{
                    //    divMsg.InnerText = "Warning ... The Students Has Finance Problem !";
                    //}


                    //Get Trans Total


                    decimal Passed = 0;
                    decimal Transfer = 0;
                    decimal Points = 0;
                    double CGPA = 0.0;
                    int iEQ = 0;
                    int iAL = 0;

                    if (!isVisiting)
                    {
                        sSQL = "SELECT Transfered,EQ,AL, Passed, curMarks, curGPA";
                        sSQL += " FROM dbo.Trans_Record_Cumulative('" + sStudentNo + "'," + iYear + "," + iSem + ",'" + sCDegree + "','" + sCMajor + "') AS Trans_Record_Cumulative_1";


                        Cmd.CommandText = sSQL;

                        SqlDataReader Rd = Cmd.ExecuteReader();

                        while (Rd.Read())
                        {
                            Passed = Convert.ToDecimal("0" + Rd["Passed"].ToString());
                            Transfer = Convert.ToDecimal(Rd["Transfered"].ToString());
                            Points = Convert.ToDecimal("0" + Rd["curMarks"].ToString());
                            CGPA = Convert.ToDouble("0" + Rd["curGPA"].ToString());
                            iEQ = int.Parse(Rd["EQ"].ToString());
                            iAL = int.Parse(Rd["AL"].ToString());

                        }
                        Rd.Close();
                    }
                    rptDS = Retrieve(sCDegree, sCMajor, isVisiting, sStudentNo);
                    //Thread.Sleep(1000);
                    string reportPath = "";
                    //if (sCMajor == "24" || sCMajor == "25")
                    //{
                    //    reportPath = Server.MapPath("Reports/Transcript_AR.rpt");
                    //}
                    //else
                    //{
                    reportPath = Server.MapPath("Reports/Transcript_New.rpt");
                    //}

                    myReport.Load(reportPath);
                    myReport.SetDataSource(rptDS);

                    myReport.ReportDefinition.ReportObjects["Sign1"].ObjectFormat.EnableSuppress = true;
                    //myReport.ReportDefinition.ReportObjects["Sign2"].ObjectFormat.EnableSuppress = true;

                    //Header Data
                    TextObject txt;
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["MajorTXT"];
                    txt.Text = sMajor;
                    //txt = (TextObject)myReport.ReportDefinition.ReportObjects["HsTXT"];
                    //txt.Text = string.Format("{0:F}", dHS);
                    //txt = (TextObject)myReport.ReportDefinition.ReportObjects["SchoolTXT"];
                    //txt.Text = sSchool + " - " + sCountry;
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["NameTXT"];
                    txt.Text = sName;
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["NoTXT"];
                    txt.Text = sStudentNo.Replace(".", "");

                    //txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtEnglishScoreText"];
                    //txt.Text = sENG + " :";
                    //txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtEnglishScore"];
                    //txt.Text = sEnglishScore;

                    if (isVisiting != true)
                    {
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["HsTXT"];
                        txt.Text = string.Format("{0:F}", dHS);
                        txt.ObjectFormat.EnableSuppress = false;
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["SchoolTXT"];
                        txt.Text = sSchool + " - " + sCountry;
                        txt.ObjectFormat.EnableSuppress = false;

                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtEnglishScoreText"];
                        txt.Text = sENG + " :";
                        txt.ObjectFormat.EnableSuppress = false;
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtEnglishScore"];
                        txt.Text = sEnglishScore;
                        txt.ObjectFormat.EnableSuppress = false;

                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["HS1"];
                        txt.ObjectFormat.EnableSuppress = false;
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["HS2"];
                        txt.ObjectFormat.EnableSuppress = false;

                    }

                    //if (!string.IsNullOrEmpty(sStatus))
                    //{
                    //    if (sStatus == "Graduated")
                    //    {
                    //        txt = (TextObject)myReport.ReportDefinition.ReportObjects["Status2TXT"];
                    //        txt.Text = "Degree : Two Years Diploma";
                    //    }
                    //    txt = (TextObject)myReport.ReportDefinition.ReportObjects["StatusTXT"];
                    //    txt.Text = "Status : " + sStatus;
                    //}
                    //else
                    //{
                    //    txt = (TextObject)myReport.ReportDefinition.ReportObjects["Status2TXT"];
                    //    txt.Text = "";
                    //    txt = (TextObject)myReport.ReportDefinition.ReportObjects["StatusTXT"];
                    //    txt.Text = "";
                    //}

                    myReport.ReportDefinition.ReportObjects["Logo"].ObjectFormat.EnableSuppress = (chkLogo.Checked == false);
                    myReport.ReportDefinition.ReportObjects["Sign1"].ObjectFormat.EnableSuppress = (chkSign.Checked == false);
                    //myReport.ReportDefinition.ReportObjects["Sign2"].ObjectFormat.EnableSuppress = (chkSign.Checked == false);

                    if (Trans_rbn.Checked)
                    {
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TitleTXT"];
                        txt.Text = "Transcript";
                        myReport.ReportDefinition.ReportObjects["PrintDate2"].ObjectFormat.EnableSuppress = true;
                        myReport.ReportDefinition.ReportObjects["PrintTime1"].ObjectFormat.EnableSuppress = true;
                        myReport.ReportDefinition.ReportObjects["UserTXT"].ObjectFormat.EnableSuppress = true;


                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTranscriptTotalBegin"];
                        txt.Text = "*******************************************TRANSCRIPT TOTAL*******************************************";

                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTranscriptTotalEnd"];
                        txt.Text = "******************************************END  OF TRANSCRIPT******************************************";

                    }
                    else
                    {
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TitleTXT"];
                        txt.Text = "Mark Sheet";

                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTranscriptTotalBegin"];
                        txt.Text = "*******************************************MARK SHEET TOTAL*******************************************";

                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTranscriptTotalEnd"];
                        txt.Text = "******************************************END  OF MARK SHEET******************************************";

                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                        string sUserName = Session["CurrentUserName"].ToString();
                        txt.Text = "/ " + sUserName;
                    }

                    if (!isVisiting)
                    {
                        myReport.ReportDefinition.Sections["TransTotal"].SectionFormat.EnableSuppress = false;
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["PassedCRtxt"];
                        txt.Text = string.Format("{0:F}", Passed);
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TransferCRtxt"];
                        txt.Text = string.Format("{0:F}", Transfer);
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["EQCRtxt"];
                        txt.Text = string.Format("{0:F}", iEQ);
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TotalCRtxt"];
                        txt.Text = string.Format("{0:F}", Transfer + Passed + iEQ);

                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["PassedPntxt"];
                        txt.Text = string.Format("{0:F}", Points);
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TransferPNtxt"];
                        txt.Text = string.Format("{0:F}", 0);
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["EQPNtxt"];
                        txt.Text = string.Format("{0:F}", 0);
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TotalPNtxt"];
                        txt.Text = string.Format("{0:F}", Points);

                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["PassedGPtxt"];
                        txt.Text = string.Format("{0:F}", CGPA);
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TransferGPtxt"];
                        txt.Text = string.Format("{0:F}", 0);
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["EQGPtxt"];
                        txt.Text = string.Format("{0:F}", 0);
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TotalGPtxt"];
                        txt.Text = string.Format("{0:F}", CGPA);
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtRank"];

                        CGPA = Convert.ToDouble(string.Format("{0:F}", CGPA));

                        if (CGPA >= 2 && CGPA < 2.5)
                        {
                            txt.Text = "(Satisfactory)";
                        }
                        else if (CGPA >= 2.5 && CGPA < 3)
                        {
                            txt.Text = "(Good)";
                        }
                        else if (CGPA >= 3 && CGPA < 3.6)
                        {
                            txt.Text = "(Very Good)";
                        }
                        else if (CGPA >= 3.6)
                        {
                            txt.Text = "(Excellent)";
                        }
                        else
                        {
                            txt.Text = "(Under Probation)";
                        }
                    }
                    else
                    {

                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["PassedCRtxt"];
                        txt.Text = "";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TransferCRtxt"];
                        txt.Text = "";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["EQCRtxt"];
                        txt.Text = "";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TotalCRtxt"];
                        txt.Text = "";

                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["PassedPntxt"];
                        txt.Text = "";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TransferPNtxt"];
                        txt.Text = "";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["EQPNtxt"];
                        txt.Text = "";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TotalPNtxt"];
                        txt.Text = "";

                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["PassedGPtxt"];
                        txt.Text = "";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TransferGPtxt"];
                        txt.Text = "";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["EQGPtxt"];
                        txt.Text = "";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["TotalGPtxt"];
                        txt.Text = "";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtRank"];
                        txt.Text = "";
                        myReport.ReportDefinition.Sections["TransTotal"].SectionFormat.EnableSuppress = true;
                    }
                    ////txt.Text = GetCaption(iSession);

                    //txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                    //string sUserName = Session["CurrentUserName"].ToString();
                    //txt.Text = "/ " + sUserName;


                    // myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");
                    myReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Path_txt.Text + "\\" + sStudentNo.Replace(".", "") + ".pdf");
                    lblProgress.Text = "Exporting record number : " + i + 1 + " for StudentID:" + sStudentNo;
                    i++;
                    //  Thread.Sleep(1000);

                }
                //ds_AllStudents.Close();
                //divMsg.InnerText = "All marks sheets exported to specified path";
                lbl_Msg.Text = "All marks sheets exported to specified path";
                div_msg.Visible = true;

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = "No Data to Preview ...";
                lbl_Msg.Text = "No Data to Preview ...";
                div_msg.Visible = true;
            }
            finally
            {

                myReport.Close();
                myReport.Dispose();
                Conn.Close();
                Conn.Dispose();
            }
        }

        private void Export(InitializeModule.ECT_Buttons iExport)
        {
            ReportDocument myReport = new ReportDocument();
            Connection_StringCLS MyConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(MyConnection_String.Conn_string);
            Conn.Open();
            try
            {

                //Get Trans Header
                DataSet rptDS = new DataSet();
                //string sSQL = "SELECT DISTINCT  A.lngStudentNumber AS sSNO, SD.strLastDescEn AS sName, M.strDisplay AS sMajor, Q.sngGrade AS dHS, Q.strCertificateSource AS sSchool,";
                //sSQL += " C.strCountryDescEn AS sCountry, A.strCollege, A.strDegree, A.strSpecialization, R.strReasonDesc AS sStatus,bOtherCollege as ACCStatus,A.byteStudentType";
                //sSQL += " FROM Reg_Specializations AS M INNER JOIN Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial INNER JOIN";
                //sSQL += " Reg_Student_Qualifications AS Q ON SD.lngSerial = Q.lngSerial ON M.strCollege = A.strCollege AND M.strDegree = A.strDegree AND";
                //sSQL += " M.strSpecialization = A.strSpecialization LEFT OUTER JOIN Lkp_Reasons AS R ON A.byteCancelReason = R.byteReason LEFT OUTER JOIN";
                //sSQL += " Lkp_Countries AS C ON Q.byteInstituteCountry = C.byteCountry";
                //sSQL += " WHERE (Q.intCertificate = 1) ";
                //sSQL += " AND A.lngStudentNumber='" + sNo + "'";

                string sSQL = "SELECT DISTINCT  A.lngStudentNumber AS sSNO, SD.strLastDescEn AS sName, M.strDisplay AS sMajor,HS.dHS, HS.sSchool, HS.sCountry,";
                sSQL += " A.strCollege, A.strDegree, A.strSpecialization, R.strReasonDesc AS sStatus,bOtherCollege as ACCStatus,A.byteStudentType";
                sSQL += " FROM Reg_Specializations AS M INNER JOIN Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON M.strCollege = A.strCollege AND M.strDegree = A.strDegree AND ";
                sSQL += " M.strSpecialization = A.strSpecialization LEFT OUTER JOIN (SELECT DISTINCT Q.lngSerial, Q.sngGrade AS dHS, Q.strCertificateSource AS sSchool, C.strCountryDescEn AS sCountry";
                sSQL += " FROM Lkp_Countries AS C RIGHT OUTER JOIN Reg_Student_Qualifications AS Q ON C.byteCountry = Q.byteInstituteCountry";
                sSQL += " WHERE (Q.intCertificate = 1)) AS HS ON SD.lngSerial = HS.lngSerial LEFT OUTER JOIN Lkp_Reasons AS R ON A.byteCancelReason = R.byteReason";
                sSQL += " WHERE A.lngStudentNumber='" + sNo + "'";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                //SELECT Transfered, Passed, curMarks, curGPA
                //FROM dbo.Trans_Record_Cumulative(,,,,) AS Trans_Record_Cumulative_1
                SqlDataReader Rd = Cmd.ExecuteReader();

                string sName = "";
                string sMajor = "";
                string sSchool = "";
                string sCountry = "";
                string sStatus = "";
                decimal dHS = 0;
                string sCDegree = "";
                string sCMajor = "";
                bool isAccProblem = false;
                int iType = 0;
                bool isVisiting = false;
                string sEnglishScore = "";
                string sENG = "";
                sEnglishScore = GetStudentMaxEnglishMark(sNo, out sENG);
                while (Rd.Read())
                {
                    sName = Rd["sName"].ToString();
                    sMajor = Rd["sMajor"].ToString();
                    sSchool = Rd["sSchool"].ToString();
                    sCountry = Rd["sCountry"].ToString();
                    sStatus = Rd["sStatus"].ToString();
                    sCDegree = Rd["strDegree"].ToString();
                    sCMajor = Rd["strSpecialization"].ToString();


                    if (Rd["dHS"].Equals(DBNull.Value))
                    {
                        dHS = 0;
                    }
                    else
                    {
                        dHS = Convert.ToDecimal(Rd["dHS"]);
                    }

                    isAccProblem = bool.Parse(Rd["ACCStatus"].ToString());
                    if (Rd["byteStudentType"].Equals(DBNull.Value))
                    {
                        iType = 0;
                    }
                    else
                    {
                        iType = int.Parse(Rd["byteStudentType"].ToString());
                    }
                    isVisiting = (iType == 1);

                }
                Rd.Close();

                if (isAccProblem)
                {
                    //divMsg.InnerText = "Warning ... The Students Has Finance Problem !";
                    lbl_Msg.Text = "Warning ... The Students Has Finance Problem !";
                    div_msg.Visible = true;
                }
                //Get Trans Total
                int iTerm = 0;
                int iYear = 0;
                int iSem = 0;

                iTerm = int.Parse(Term_ddl.SelectedValue);
                if (iTerm == 0)
                {
                    //divMsg.InnerText = "Select Term Please ...";
                    lbl_Msg.Text = "Select Term Please ...";
                    div_msg.Visible = true;
                    return;
                }

                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

                decimal Passed = 0;
                decimal Transfer = 0;
                decimal Points = 0;
                double CGPA = 0;
                int iEQ = 0;
                int iAL = 0;

                if (!isVisiting)
                {
                    sSQL = "SELECT Transfered,EQ,AL, Passed, curMarks, curGPA";
                    sSQL += " FROM dbo.Trans_Record_Cumulative('" + sNo + "'," + iYear + "," + iSem + ",'" + sCDegree + "','" + sCMajor + "') AS Trans_Record_Cumulative_1";

                    Cmd.CommandText = sSQL;
                    Rd = Cmd.ExecuteReader();

                    while (Rd.Read())
                    {
                        Passed = Convert.ToDecimal("0" + Rd["Passed"].ToString());
                        Transfer = Convert.ToDecimal(Rd["Transfered"].ToString());
                        Points = Convert.ToDecimal("0" + Rd["curMarks"].ToString());
                        CGPA = Convert.ToDouble("0" + Rd["curGPA"].ToString());
                        iEQ = int.Parse(Rd["EQ"].ToString());
                        iAL = int.Parse(Rd["AL"].ToString());

                    }
                    Rd.Close();
                }
                rptDS = Retrieve(sCDegree, sCMajor, isVisiting, sNo);

                string reportPath = "";
                //if (sCMajor == "24" || sCMajor == "25")
                //{
                //    reportPath = Server.MapPath("Reports/Transcript_AR.rpt");
                //}
                //else
                //{
                reportPath = Server.MapPath("Reports/Transcript_New.rpt");
                //}

                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);


                //Header Data
                TextObject txt;
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["MajorTXT"];
                txt.Text = sMajor;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["NameTXT"];
                txt.Text = sName;
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["NoTXT"];
                txt.Text = sNo.Replace(".", "");

                if (isVisiting != true)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["HsTXT"];
                    txt.Text = string.Format("{0:F}", dHS);
                    txt.ObjectFormat.EnableSuppress = false;
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["SchoolTXT"];
                    txt.Text = sSchool + " - " + sCountry;
                    txt.ObjectFormat.EnableSuppress = false;

                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtEnglishScoreText"];
                    txt.Text = sENG + " :";
                    txt.ObjectFormat.EnableSuppress = false;
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtEnglishScore"];
                    txt.Text = sEnglishScore;
                    txt.ObjectFormat.EnableSuppress = false;

                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["HS1"];
                    txt.ObjectFormat.EnableSuppress = false;
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["HS2"];
                    txt.ObjectFormat.EnableSuppress = false;

                }

                if (!string.IsNullOrEmpty(sStatus))
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["Status2TXT"];
                    if (sStatus == "Graduated")
                    {
                        switch (iType)
                        {
                            case 0:
                                txt.Text = "Degree : Two Years Diploma";
                                break;
                            case 3:
                                txt.Text = "Degree : Four Years Bachelor";
                                break;
                        }
                    }
                    else if (sStatus == "Foundation Complete")
                    {
                        if (!string.IsNullOrEmpty(sEnglishScore))
                        {
                            bool isEngPassed = LibraryMOD.isENGPassed(float.Parse(sEnglishScore), sENG, "1", "20");
                            if (!isEngPassed)
                            {
                                //txt.Text = "Student is entitled only to progress into Higher Education Programs delivered in Arabic language medium.";
                                txt.Text = "Student is entitled only to enter Higher Education Programs with Arabic as the medium of instruction, unless a certificate of English language proficiency is presented at a level that permits entry to English-medium programs";
                            }
                        }
                    }
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["StatusTXT"];
                    txt.Text = "Status : " + sStatus;
                }

                myReport.ReportDefinition.ReportObjects["Logo"].ObjectFormat.EnableSuppress = (chkLogo.Checked == false);
                myReport.ReportDefinition.ReportObjects["Sign1"].ObjectFormat.EnableSuppress = (chkSign.Checked == false);
                //myReport.ReportDefinition.ReportObjects["Sign2"].ObjectFormat.EnableSuppress = (chkSign.Checked == false);
                if (!chkSign.Checked)
                {
                    myReport.ReportDefinition.Sections["RFooter"].SectionFormat.EnableSuppress = true;
                }

                if (Trans_rbn.Checked)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["TitleTXT"];
                    txt.Text = "Transcript";
                    myReport.ReportDefinition.ReportObjects["PrintDate2"].ObjectFormat.EnableSuppress = true;
                    myReport.ReportDefinition.ReportObjects["PrintTime1"].ObjectFormat.EnableSuppress = true;
                    myReport.ReportDefinition.ReportObjects["UserTXT"].ObjectFormat.EnableSuppress = true;


                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTranscriptTotalBegin"];
                    txt.Text = "**********************************************************TRANSCRIPT TOTAL**********************************************************";

                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTranscriptTotalEnd"];
                    txt.Text = "*********************************************************END  OF TRANSCRIPT*********************************************************";
                    myReport.ReportDefinition.Sections["RFooter"].SectionFormat.EnablePrintAtBottomOfPage = true;
                }
                else
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["TitleTXT"];
                    txt.Text = "Mark Sheet";

                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTranscriptTotalBegin"];
                    txt.Text = "**********************************************************MARK SHEET TOTAL**********************************************************";

                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTranscriptTotalEnd"];
                    txt.Text = "*********************************************************END  OF MARK SHEET*********************************************************";

                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                    string sUserName = Session["CurrentUserName"].ToString();
                    txt.Text = "/ " + sUserName;
                }

                if (!isVisiting)
                {
                    myReport.ReportDefinition.Sections["TransTotal"].SectionFormat.EnableSuppress = false;
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["PassedCRtxt"];
                    txt.Text = string.Format("{0:F}", Passed);
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["TransferCRtxt"];
                    txt.Text = string.Format("{0:F}", Transfer);
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["EQCRtxt"];
                    txt.Text = string.Format("{0:F}", iEQ);
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["TotalCRtxt"];
                    txt.Text = string.Format("{0:F}", Transfer + Passed + iEQ);

                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["PassedPntxt"];
                    txt.Text = string.Format("{0:F}", Points);
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["TransferPNtxt"];
                    txt.Text = string.Format("{0:F}", 0);
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["EQPNtxt"];
                    txt.Text = string.Format("{0:F}", 0);
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["TotalPNtxt"];
                    txt.Text = string.Format("{0:F}", Points);

                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["PassedGPtxt"];
                    txt.Text = string.Format("{0:F}", CGPA);
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["TransferGPtxt"];
                    txt.Text = string.Format("{0:F}", 0);
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["EQGPtxt"];
                    txt.Text = string.Format("{0:F}", 0);
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["TotalGPtxt"];
                    txt.Text = string.Format("{0:F}", CGPA);
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtRank"];
                    txt.Text = "";

                    CGPA = Convert.ToDouble(string.Format("{0:F}", CGPA));

                    if (CGPA >= 2 && CGPA < 2.5)
                    {
                        txt.Text = "(Satisfactory)";
                    }
                    else if (CGPA >= 2.5 && CGPA < 3)
                    {
                        txt.Text = "(Good)";
                    }
                    else if (CGPA >= 3 && CGPA < 3.6)
                    {
                        txt.Text = "(Very Good)";
                    }
                    else if (CGPA >= 3.6)
                    {
                        txt.Text = "(Excellent)";
                    }
                    else
                    {
                        txt.Text = "(Under Probation)";
                    }
                }
                ////txt.Text = GetCaption(iSession);

                //txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                //string sUserName = Session["CurrentUserName"].ToString();
                //txt.Text = "/ " + sUserName;

                switch (iExport)
                {
                    case InitializeModule.ECT_Buttons.Print:
                        myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");
                        break;
                    case InitializeModule.ECT_Buttons.ToExcel:
                        myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Page.Response, true, "ECTReport");
                        break;
                    case InitializeModule.ECT_Buttons.ToWord:
                        myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Page.Response, true, "ECTReport");
                        break;

                }



            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = "No Data to Preview ...";
                lbl_Msg.Text = "No Data to Preview ...";
                div_msg.Visible = true;
            }
            finally
            {
                myReport.Close();
                myReport.Dispose();
                Conn.Close();
                Conn.Dispose();
            }
        }

        private DataSet Prepare_Report(int iTerm, bool isCurrent, string stdNO, string sSQL, string sDegree, string sMajor, bool isVisiting, InitializeModule.EnumCampus Campus)
        {

            DataTable Transdt = new DataTable();
            DataTable GPAdt = new DataTable();
            DataTable CGPAdt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                Transdt = Get_TransDT(sSQL, sDegree, sMajor, isVisiting, Campus);

                string sGPASQL = GetGPAsSQL(iTerm, isCurrent, stdNO, Campus);
                GPAdt = Get_GPADT(sGPASQL, Campus);

                string sCGPASQL = GetCGPAsSQL(iTerm, isCurrent, stdNO, isVisiting, Campus);
                CGPAdt = Get_CGPADT(sCGPASQL, isVisiting, Campus);

                ds.Tables.Add(Transdt);
                ds.Tables.Add(GPAdt);
                ds.Tables.Add(CGPAdt);

                //ds.Relations.Add("Trans_GPAs", Transdt.Columns["iTerm"], GPAdt.Columns["iTerm"]);
                //ds.Relations.Add("Trans_CGPAs", Transdt.Columns["iTerm"], CGPAdt.Columns["iTerm"]);


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                //Conn.Close();
                //Conn.Close();
            }
            return ds;
        }

        private DataSet Retrieve(string sDegree, string sMajor, bool isVisiting, string sStudentNo)
        {

            DataSet Ds = new DataSet();
            try
            {

                if (sStudentNo == "")
                {
                    //divMsg.InnerText = "Select Student Please ...";
                    lbl_Msg.Text = "Select Student Please ...";
                    div_msg.Visible = true;
                    return Ds;
                }

                string sSQL = "SELECT [GH].[intStudyYear]*10+[GH].[byteSemester] AS iTerm, M.strDisplay AS sMajor, C.strCourse AS sCode, C.strCourseDescEn AS sCourse, GH.strGrade AS sGrade, C.byteCreditHours AS iCredit, GS.curCreditPoint AS dPoint, GS.bCalc, GH.bDisActivated, GS.bPassIt, [intCanceledYear]*10+[byteCanceledSem] AS iCancelTerm, GH.sAlt,GH.sEQ,";
                sSQL += " M.strDegree AS GDegree, M.strSpecialization AS GMajor, FC.strCollegeDescEn AS FCollege";

                //sSQL += " FROM (((Reg_Courses AS C INNER JOIN Reg_Grade_Header AS GH ON C.strCourse = GH.strCourse) INNER JOIN Reg_Grade_System AS GS ON GH.strGrade = GS.strGrade) INNER JOIN (Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial) ON GH.lngStudentNumber = A.lngStudentNumber) INNER JOIN Reg_Specializations AS M ON (GH.strDegree = M.strDegree) AND (GH.strMajor = M.strSpecialization)";
                //sSQL+=" FROM  Reg_Courses AS C INNER JOIN  Reg_Grade_Header AS GH ON C.strCourse = GH.strCourse INNER JOIN";
                //sSQL+=" Reg_Grade_System AS GS ON GH.strGrade = GS.strGrade INNER JOIN  Reg_Applications AS A INNER JOIN";
                //sSQL+=" Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON GH.lngStudentNumber = A.lngStudentNumber INNER JOIN";
                //sSQL+=" Reg_Specializations AS M ON GH.strDegree = M.strDegree AND GH.strMajor = M.strSpecialization LEFT OUTER JOIN";
                //sSQL+=" Lkp_Foreign_Colleges AS FC ON GH.byteRefCollege = FC.byteCollege";
                sSQL += " FROM Reg_Courses AS C INNER JOIN Reg_Grade_Header AS GH ON C.strCourse = GH.strCourse INNER JOIN";
                sSQL += " Reg_Grade_System AS GS ON GH.strGrade = GS.strGrade INNER JOIN Reg_Applications AS A INNER JOIN";
                sSQL += " Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON GH.lngStudentNumber = A.lngStudentNumber LEFT OUTER JOIN";
                sSQL += " Reg_Specializations AS M ON GH.strDegree = M.strDegree AND GH.strMajor = M.strSpecialization LEFT OUTER JOIN";
                sSQL += " Lkp_Foreign_Colleges AS FC ON GH.byteRefCollege = FC.byteCollege";

                int iTerm = 0;
                int iYear = 0;
                int iSem = 0;


                //InitializeModule.EnumCampus Campus;

                iTerm = int.Parse(Term_ddl.SelectedValue);

                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);


                if (isCurrent_chk.Checked)
                {
                    sSQL += " Where ([GH].[intStudyYear]*10+[GH].[byteSemester])=" + iTerm;
                }
                else
                {
                    sSQL += " Where ([GH].[intStudyYear]*10+[GH].[byteSemester])<=" + iTerm;
                }


                sSQL += " And GH.lngStudentNumber='" + sStudentNo + "'";


                sSQL += " ORDER BY [GH].[intStudyYear]*10+[GH].[byteSemester], C.strCourse";


                Ds = Prepare_Report(iTerm, isCurrent_chk.Checked, sStudentNo, sSQL, sDegree, sMajor, isVisiting, Campus);


            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {

            }
            return Ds;
        }

        private decimal GetCGPA(int iTerm, string StdNO, string sDegree, string sMajor, InitializeModule.EnumCampus Campus)
        {
            decimal CGPA = 0;
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();

            try
            {
                int iYear = 0;
                int iSem = 0;
                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

                string sSQL = "SELECT curGPA AS CGPA";
                sSQL += " FROM dbo.GPA_All('" + StdNO + "'," + iYear + "," + iSem + ",'" + sDegree + "','" + sMajor + "') AS GPA_All_1";


                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                while (Rd.Read())
                {
                    CGPA = Convert.ToDecimal(Rd["CGPA"]);
                }
                Rd.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return CGPA;

        }

        private DataTable Get_TransDT(string sSQL, string sSDegree, string sSMajor, bool isVisiting, InitializeModule.EnumCampus Campus)
        {
            Connection_StringCLS MyConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(MyConnection_String.Conn_string);
            Conn.Open();
            DataTable dt = new DataTable();
            DataRow dr;
            List<MCourse> myCourses = new List<MCourse>();
            try
            {
                DataColumn dc;

                dc = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dc.AutoIncrement = true;
                dc.AutoIncrementSeed = 1;
                dc.AutoIncrementStep = 1;
                dt.Columns.Add(dc);

                dc = new DataColumn("iTerm", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);

                dc = new DataColumn("sYear", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sSem", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sMajor", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCode", Type.GetType("System.String"));
                dt.Columns.Add(dc);


                DataColumn[] Pr = new DataColumn[1];
                Pr[0] = dt.Columns["iSerial"];
                //Pr[0] = dt.Columns["iTerm"];
                //Pr[1] = dt.Columns["sCode"];

                dt.PrimaryKey = Pr;


                dc = new DataColumn("sCourse", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sGrade", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCredit", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sPoint", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sNote", Type.GetType("System.String"));
                dt.Columns.Add(dc);


                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                int iTerm, iYear, iSem, iCancel, iIndex, iCredit = 0;
                decimal dPoint = 0;
                bool isCalc, isDisactivated, isIn, isPassed = false;
                bool isEelective = false;
                string sAlt, sEQ, sDegree, sMajor, sNote, sCourse, sCDegree, sCMajor, sGrade = "";
                sCDegree = sSDegree;
                sCMajor = sSMajor;


                myCourses = MajorCourses(sSDegree, sSMajor, Campus);

                while (Rd.Read())
                {
                    dr = dt.NewRow();
                    //iTerm, sMajor, sCode, sCourse, sGrade, iCredit, dPoint, GS.bCalc,
                    //GH.bDisActivated,GS.bPassIt,iCancelTerm, GH.sAlt, GDegree,GMajor";
                    iTerm = int.Parse(Rd["iTerm"].ToString());

                    iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

                    if (iTerm < 0)
                    {
                        iTerm = -11;
                        iYear = -1;
                        iSem = -1;
                    }

                    dr["iTerm"] = iTerm;

                    if (iYear > 0)
                    {
                        dr["sYear"] = iYear.ToString() + " / " + (iYear + 1).ToString();
                        dr["sSem"] = LibraryMOD.GetSemesterString(iSem);
                    }
                    else
                    {
                        switch (iYear)
                        {
                            case -1:
                                dr["sYear"] = "Previous Registration";
                                dr["sSem"] = "";
                                break;
                            case 0:
                                dr["sYear"] = "Transferred and Exempted";
                                dr["sSem"] = "";
                                break;
                        }

                    }
                    dr["sMajor"] = Rd["sMajor"].ToString();
                    dr["sCode"] = Rd["sCode"].ToString();
                    sCourse = Rd["sCode"].ToString();
                    dr["sCourse"] = Rd["sCourse"].ToString();

                    sGrade = Rd["sGrade"].ToString();
                    dr["sGrade"] = sGrade;

                    iCredit = Convert.ToInt32(Rd["iCredit"]);
                    dPoint = Convert.ToDecimal(Rd["dPoint"]);

                    dr["sCredit"] = iCredit;
                    dr["sPoint"] = string.Format("{0:f}", iCredit * dPoint);

                    isCalc = Convert.ToBoolean(Rd["bCalc"]);
                    isDisactivated = Convert.ToBoolean(Rd["bDisActivated"]);
                    isPassed = Convert.ToBoolean(Rd["bPassIt"]);

                    if (!Rd["iCancelTerm"].Equals(DBNull.Value))
                    {
                        iCancel = Convert.ToInt32(Rd["iCancelTerm"]);
                    }
                    else
                    {
                        iCancel = 0;
                    }
                    sAlt = Rd["sAlt"].ToString();
                    sEQ = Rd["sEQ"].ToString();
                    sDegree = Rd["GDegree"].ToString();
                    sMajor = Rd["GMajor"].ToString();


                    sNote = Rd["FCollege"].ToString();

                    if (sNote == "" && iYear <= 0)
                    {
                        sNote = "-";
                    }
                    if (iYear > 0)
                    {
                        iIndex = myCourses.FindIndex(delegate (MCourse M) { return M.sCourse == sCourse; });
                        isIn = iIndex >= 0;
                        isEelective = false;
                        if (isIn == true)
                        {
                            isEelective = myCourses[iIndex].isElective;
                        }

                        if (isDisactivated || (iCancel > 0 && isIn))
                        {
                            sNote = "*";
                        }
                        else
                        {
                            //if the course out of main major courses
                            if (!isIn || isEelective)
                            {
                                if (sAlt != "")
                                {
                                    sNote = "****";
                                }
                                else if (sEQ != "")
                                {
                                    sNote = "***";
                                }
                                else if (!isEelective)
                                {
                                    sNote = "**";
                                }
                            }
                        }

                    }

                    if (!isVisiting)
                    {
                        dr["sNote"] = sNote;
                    }

                    if (sGrade != "EQ" && sGrade != "AL")
                    {

                        dt.Rows.Add(dr);
                    }

                }
                dt.TableName = "Trans_tbl";
                dt.AcceptChanges();

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                myCourses.Clear();
                Conn.Close();
                Conn.Close();
            }
            return dt;
        }

        private DataTable Get_GPADT(string sSQL, InitializeModule.EnumCampus Campus)
        {
            Connection_StringCLS MyConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(MyConnection_String.Conn_string);
            Conn.Open();
            DataTable dt = new DataTable();
            DataRow dr;

            try
            {
                DataColumn dc;

                dc = new DataColumn("iTerm", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);

                DataColumn[] Pr = new DataColumn[1];
                Pr[0] = dt.Columns["iTerm"];
                dt.PrimaryKey = Pr;

                dc = new DataColumn("sAttCredit", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sPassedCredit", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCompletedCredit", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sPoints", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sGPA", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                if (!isCurrent_chk.Checked)
                {
                    //-1 Previeous Registration
                    //0 Transferred & Exempted
                    dr = dt.NewRow();
                    dr["iTerm"] = -11;
                    dr["sAttCredit"] = 0;
                    dr["sPassedCredit"] = 0;
                    dr["sCompletedCredit"] = 0;
                    dr["sPoints"] = 0;
                    dr["sGPA"] = 0;
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["iTerm"] = 0;
                    dr["sAttCredit"] = 0;
                    dr["sPassedCredit"] = 0;
                    dr["sCompletedCredit"] = 0;
                    dr["sPoints"] = 0;
                    dr["sGPA"] = 0;
                    dt.Rows.Add(dr);
                }


                if (string.IsNullOrEmpty(sSQL))
                {
                    dt.TableName = "GPAs";
                    dt.AcceptChanges();
                    return dt;
                }

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();



                int iTerm = 0;
                int iPassed = 0;
                decimal dMark = 0;
                decimal dGPA = 0;
                while (Rd.Read())
                {
                    dr = dt.NewRow();

                    iTerm = int.Parse(Rd["iTerm"].ToString());
                    dr["iTerm"] = iTerm;

                    if (!Rd["Passed"].Equals(DBNull.Value))
                    {
                        iPassed = int.Parse(Rd["Passed"].ToString());
                    }
                    else
                    {
                        iPassed = 0;
                    }
                    if (!Rd["Attempted"].Equals(DBNull.Value))
                    {
                        dr["sAttCredit"] = Rd["Attempted"].ToString();
                    }
                    else
                    {
                        dr["sAttCredit"] = "0.00";
                    }
                    dr["sPassedCredit"] = iPassed.ToString();
                    dr["sCompletedCredit"] = iPassed.ToString();
                    if (!Rd["curMarks"].Equals(DBNull.Value))
                    {
                        dMark = decimal.Parse(Rd["curMarks"].ToString());
                    }
                    else
                    {
                        dMark = 0;
                    }
                    dr["sPoints"] = string.Format("{0:F}", dMark);
                    if (!Rd["curGPA"].Equals(DBNull.Value))
                    {
                        dGPA = decimal.Parse(Rd["curGPA"].ToString());
                    }
                    else
                    {
                        dGPA = 0;
                    }
                    dr["sGPA"] = string.Format("{0:F}", dGPA);

                    dt.Rows.Add(dr);


                }
                dt.TableName = "GPAs";
                dt.AcceptChanges();

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                Conn.Close();
                Conn.Close();
            }
            return dt;
        }

        private DataTable Get_CGPADT(string sSQL, bool isVisiting, InitializeModule.EnumCampus Campus)
        {
            Connection_StringCLS MyConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(MyConnection_String.Conn_string);
            Conn.Open();
            DataTable dt = new DataTable();
            DataRow dr;

            try
            {
                DataColumn dc;

                dc = new DataColumn("iTerm", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);

                DataColumn[] Pr = new DataColumn[1];
                Pr[0] = dt.Columns["iTerm"];
                dt.PrimaryKey = Pr;


                dc = new DataColumn("sCAttCredit", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCPassedCredit", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sEQCredit", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sALCredit", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCCompletedCredit", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCPoints", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCGPA", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                if (!isCurrent_chk.Checked)
                {
                    //-11 Previeous Registration
                    //0 Transferred & Exempted
                    dr = dt.NewRow();
                    dr["iTerm"] = -11;
                    dr["sCAttCredit"] = 0;
                    dr["sCPassedCredit"] = 0;
                    dr["sEQCredit"] = 0;
                    dr["sALCredit"] = 0;
                    dr["sCCompletedCredit"] = 0;
                    dr["sCPoints"] = 0;
                    dr["sCGPA"] = 0;
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["iTerm"] = 0;
                    dr["sCAttCredit"] = 0;
                    dr["sCPassedCredit"] = 0;
                    dr["sEQCredit"] = 0;
                    dr["sALCredit"] = 0;
                    dr["sCCompletedCredit"] = 0;
                    dr["sCPoints"] = 0;
                    dr["sCGPA"] = 0;
                    dt.Rows.Add(dr);

                }

                if (string.IsNullOrEmpty(sSQL))
                {
                    dt.TableName = "CGPAs";
                    dt.AcceptChanges();
                    return dt;

                }

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                int iTerm = 0;
                int iCompleted = 0;
                int iPassed = 0;
                int iTC = 0;
                int iEQ = 0;
                int iAL = 0;
                decimal dMark = 0;
                decimal dGPA = 0;
                while (Rd.Read())
                {
                    dr = dt.NewRow();

                    iTerm = int.Parse(Rd["iTerm"].ToString());
                    dr["iTerm"] = iTerm;

                    if (!Rd["Passed"].Equals(DBNull.Value))
                    {
                        iPassed = int.Parse(Rd["Passed"].ToString());
                    }
                    else
                    {
                        iPassed = 0;
                    }
                    if (!Rd["Transfered"].Equals(DBNull.Value))
                    {
                        iTC = int.Parse(Rd["Transfered"].ToString());
                    }
                    else
                    {
                        iTC = 0;
                    }


                    iCompleted = 0;
                    if (!isVisiting)
                    {
                        if (!Rd["Completed"].Equals(DBNull.Value))
                        {
                            iCompleted = int.Parse(Rd["Completed"].ToString());
                        }
                    }
                    else
                    {
                        iCompleted = iPassed;
                    }

                    //iCompleted =iPassed + iTC;

                    if (!Rd["Attempted"].Equals(DBNull.Value))
                    {
                        dr["sCAttCredit"] = Rd["Attempted"].ToString();
                    }
                    else
                    {
                        dr["sCAttCredit"] = "0";
                    }
                    dr["sCPassedCredit"] = iPassed.ToString();
                    dr["sCCompletedCredit"] = iCompleted.ToString();
                    if (!Rd["EQ"].Equals(DBNull.Value))
                    {
                        iEQ = int.Parse(Rd["EQ"].ToString());
                    }
                    else
                    {
                        iEQ = 0;
                    }

                    if (!Rd["AL"].Equals(DBNull.Value))
                    {
                        iAL = int.Parse(Rd["AL"].ToString());
                    }
                    else
                    {
                        iAL = 0;
                    }
                    dr["sEQCredit"] = string.Format("{0:F}", iEQ);
                    dr["sALCredit"] = string.Format("{0:F}", iAL);
                    if (!Rd["curMarks"].Equals(DBNull.Value))
                    {
                        dMark = decimal.Parse(Rd["curMarks"].ToString());
                    }
                    else
                    {
                        dMark = 0;
                    }

                    dr["sCPoints"] = string.Format("{0:F}", dMark);
                    if (!Rd["curGPA"].Equals(DBNull.Value))
                    {
                        dGPA = decimal.Parse(Rd["curGPA"].ToString());
                    }
                    else
                    {
                        dGPA = 0;
                    }

                    dr["sCGPA"] = string.Format("{0:F}", dGPA);

                    dt.Rows.Add(dr);


                }
                dt.TableName = "CGPAs";
                dt.AcceptChanges();

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                Conn.Close();
                Conn.Close();
            }
            return dt;
        }

        string GetGPAsSQL(int iTerm, bool isCurrent, string StdNO, InitializeModule.EnumCampus Campus)
        {
            Connection_StringCLS MyConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(MyConnection_String.Conn_string);
            Conn.Open();

            string sSQL = "";
            try
            {
                string sTerms = "SELECT intStudyYear * 10 + byteSemester AS iTerm, intStudyYear AS iYear, byteSemester AS iSem, strDegree AS sDegree, strMajor AS sMajor,COUNT(strCourse) AS Courses";
                sTerms += " FROM Reg_Grade_Header AS GH";
                if (isCurrent)
                {
                    sTerms += " WHERE (intStudyYear * 10 + byteSemester)=" + iTerm + " AND lngStudentNumber = '" + StdNO + "'";
                }
                else
                {
                    //sTerms+=" WHERE (intStudyYear * 10 + byteSemester)<="+iTerm +" AND lngStudentNumber = '"+sNO+"'";
                    sTerms += " WHERE (intStudyYear * 10 + byteSemester)>0 AND (intStudyYear * 10 + byteSemester)<=" + iTerm + " AND lngStudentNumber = '" + StdNO + "'";
                }
                sTerms += " GROUP BY intStudyYear, byteSemester, intStudyYear * 10 + byteSemester, strDegree, strMajor";

                sTerms += " ORDER BY intStudyYear, byteSemester";

                SqlCommand Cmd = new SqlCommand(sTerms, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                int iYear = 0;
                int iSem = 0;
                string sDegree = "";
                string sMajor = "";
                while (Rd.Read())
                {
                    iYear = int.Parse(Rd["iYear"].ToString());
                    iSem = int.Parse(Rd["iSem"].ToString());
                    sDegree = Rd["sDegree"].ToString();
                    sMajor = Rd["sMajor"].ToString();

                    if (sSQL != "")
                    {
                        sSQL += " Union ";
                    }

                    sSQL += "SELECT " + (iYear * 10 + iSem) + " as iTerm,Attempted ,Passed , byteHours ,curMarks ,curGPA";
                    sSQL += " FROM Trans_Record_Semester";
                    sSQL += "('" + StdNO + "'," + iYear + "," + iSem + ")";



                }
                Rd.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sSQL;
        }
        string GetCGPAsSQL(int iTerm, bool isCurrent, string StdNO, bool isVisiting, InitializeModule.EnumCampus Campus)
        {
            Connection_StringCLS MyConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(MyConnection_String.Conn_string);
            Conn.Open();
            string sSQL = "";
            try
            {
                string sTerms = "SELECT intStudyYear * 10 + byteSemester AS iTerm, intStudyYear AS iYear, byteSemester AS iSem, strDegree AS sDegree, strMajor AS sMajor,COUNT(strCourse) AS Courses";
                sTerms += " FROM Reg_Grade_Header AS GH";
                if (isCurrent)
                {
                    sTerms += " WHERE (intStudyYear * 10 + byteSemester)=" + iTerm + " AND lngStudentNumber = '" + StdNO + "'";
                }
                else
                {
                    //sTerms += " WHERE (intStudyYear * 10 + byteSemester)<=" + iTerm + " AND lngStudentNumber = '" + sNO + "'";
                    sTerms += " WHERE (intStudyYear * 10 + byteSemester)>0 AND (intStudyYear * 10 + byteSemester)<=" + iTerm + " AND lngStudentNumber = '" + StdNO + "'";
                }
                sTerms += " GROUP BY intStudyYear, byteSemester, intStudyYear * 10 + byteSemester, strDegree, strMajor";

                sTerms += " ORDER BY intStudyYear, byteSemester";

                SqlCommand Cmd = new SqlCommand(sTerms, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                int iYear = 0;
                int iSem = 0;
                string sDegree = "";
                string sMajor = "";
                while (Rd.Read())
                {
                    iYear = int.Parse(Rd["iYear"].ToString());
                    iSem = int.Parse(Rd["iSem"].ToString());
                    sDegree = Rd["sDegree"].ToString();
                    sMajor = Rd["sMajor"].ToString();

                    if (sSQL != "")
                    {
                        sSQL += " Union ";
                    }
                    if (!isVisiting)
                    {
                        sSQL += "SELECT " + (iYear * 10 + iSem) + " as iTerm,Attempted ,Transfered ,EQ,AL,Completed,Passed , byteHours ,curMarks ,curGPA";
                        sSQL += " FROM [ECTData].[dbo].[Trans_Record_Cumulative]";
                        sSQL += "('" + StdNO + "'," + iYear + "," + iSem + ",'" + sDegree + "','" + sMajor + "')";
                    }
                    else
                    {
                        sSQL += "SELECT " + (iYear * 10 + iSem) + " as iTerm,Attempted ,0 as Transfered ,0 as EQ,0 as AL,Passed , byteHours ,curMarks ,curGPA";
                        sSQL += " FROM Trans_Record_Semester";
                        sSQL += "('" + StdNO + "'," + iYear + "," + iSem + ")";
                    }

                }
                Rd.Close();

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return sSQL;
        }

        private List<MCourse> MajorCourses(string sDegree, string sMajor, InitializeModule.EnumCampus Campus)
        {
            Connection_StringCLS MyConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(MyConnection_String.Conn_string);
            Conn.Open();
            List<MCourse> myCourses = new List<MCourse>();
            try
            {
                int iBool = 0;
                string sSQL = "SELECT [strCourse],[isElective] FROM [ECTData].[dbo].[Majors_Courses]";
                sSQL += " WHERE strCollege='1' AND strDegree='" + sDegree + "' AND strSpecialization='" + sMajor + "'";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                MCourse myCourse;
                while (Rd.Read())
                {
                    myCourse = new MCourse();
                    myCourse.sCourse = Rd["strCourse"].ToString();
                    iBool = int.Parse(Rd["isElective"].ToString());
                    if (iBool == 0)
                    {
                        myCourse.isElective = false;
                    }
                    else
                    {
                        myCourse.isElective = true;
                    }
                    myCourses.Add(myCourse);
                }
                Rd.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return myCourses;
        }


        private bool Enable_Disable(string sSNo, bool showdivonly)
        {
            bool isEnable = false;
            string sMSG = "";
            try
            {
                bool isFinance = true;
                bool isActive = true;
                int iStatus = 0;
                bool isFinanceSkip = false;
                bool isActiveSkip = false;
                bool isSkipStatus = false;

                bool flag1 = false, flag2 = false, flag3 = false;

                //bool isEnabled = false;

                isFinance = LibraryMOD.isFinanceProblems(Campus, sSNo);
                isFinanceSkip = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Transcript,
                       InitializeModule.enumPrivilege.SkipStudentFinanceProblem, CurrentRole);
                isActive = LibraryMOD.isActiveStudent(Campus, sSNo);
                isActiveSkip = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Transcript,
                       InitializeModule.enumPrivilege.SkipStudentActive, CurrentRole);
                iStatus = LibraryMOD.GetStudentStatus(Campus, sSNo);
                isSkipStatus = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Transcript,
                        InitializeModule.enumPrivilege.ChangeStudentStatus, CurrentRole);

                if (isFinance && !isFinanceSkip)
                {
                    flag1 = true;
                    sMSG += "<br />Student Has Finance Problems";
                }
                else if (isFinance && isFinanceSkip)
                {
                    sMSG += "<br />Student Has Finance Problems and you Skipped that...";
                }

                if (!isActive && !isActiveSkip)
                {
                    flag2 = true;
                    sMSG += "<br />Student is Inactive";
                }
                else if (!isActive && isActiveSkip)
                {
                    sMSG += "<br />Student is Inactive and you Skipped that...";
                }

                if (iStatus == 6 && !isSkipStatus)
                {
                    flag3 = true;
                    sMSG += "<br />Student is Dismissed from the College";
                }
                else if (iStatus == 6 && isSkipStatus)
                {
                    sMSG += "<br />Student is Dismissed from the College and you Skipped that...";
                }

                isEnable = !(flag1 || flag2 || flag3);


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                return false;
            }
            finally
            {
                if (sMSG != "")
                {
                    if (!showdivonly)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "errorSession", "$(function(){Sexy.error('" + sMSG + "'); });", true);
                    }
                    //divMsg.InnerHtml = sMSG;
                    lbl_Msg.Text = sMSG;
                    div_msg.Visible = true;
                }
            }

            return isEnable;
        }

        protected void Trans_rbn_CheckedChanged(object sender, EventArgs e)
        {
            chkLogo.Checked = false;
            chkLogo.Enabled = false;
            chkSign.Enabled = true;
        }
        protected void Sheet_rbn_CheckedChanged(object sender, EventArgs e)
        {
            chkLogo.Checked = true;
            chkLogo.Enabled = true;
            chkSign.Checked = false;
            chkSign.Enabled = false;
        }
    }
}