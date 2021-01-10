using System;
using System.Collections;
using System.Configuration;
using System.Data;
//////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
////using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing;
using QRCoder;
using System.IO;

namespace LocalECT
{
    public partial class ClassAttendance : System.Web.UI.Page
    {
        InitializeModule.EnumCampus CurrentCampus = InitializeModule.EnumCampus.Males;

        System.Web.UI.WebControls.Table MyTable = new System.Web.UI.WebControls.Table();

        int iStudyYear = 0;
        byte bSemester = 0;
        byte bShift = 0;
        string sCourse = "";
        byte bAttClass = 0;
        int iLecturer = 0;
        int CurrentRole = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Attendance,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");

                    }
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Attendance,
                    InitializeModule.enumPrivilege.ShowAllLecturer, CurrentRole) == true)
                    {
                        Session["CurrentLecturer"] = 0;
                    }
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Attendance,
               InitializeModule.enumPrivilege.ChangeRegistrationYearSem, CurrentRole) != true)
                    {
                        //lblTerm.Visible = false;
                        terms1.Visible = false;
                    }

                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
            iLecturer = (int)Session["CurrentLecturer"];

            if (!IsPostBack)
            {
                CurrentCampus = InitializeModule.EnumCampus.Females;//(InitializeModule.EnumCampus)Session["CurrentCampus"];
                Fill_lecturers();
                Fill_Campus();
                FillTerms();
                Terms.SelectedValue = Session["CurrentYear"].ToString() + Session["CurrentSemester"].ToString();

                CampusCBO.SelectedValue = ((int)CurrentCampus).ToString();
                Session["AttendanceTable"] = null;
                Session["AttendanceArgs"] = null;

                iSemester.Value = Session["CurrentSemester"].ToString();
                iYear.Value = Session["CurrentYear"].ToString();
            }
            else
            {
                CurrentCampus = (InitializeModule.EnumCampus)int.Parse(CampusCBO.SelectedValue);

            }
        }
        private void Fill_lecturers()
        {

            List<ECTNewLecturers> MyLecturers = new List<ECTNewLecturers>();
            ECTNewLecturersDAL MyLecturersDAL = new ECTNewLecturersDAL();
            string sCondition = " Where IsActive=1";
            bool isDefaultIncleded = true;
            try
            {
                LecturersCBO.Items.Clear();
                if (iLecturer > 0)
                {
                    sCondition += " And LecturerID=" + iLecturer;
                    isDefaultIncleded = false;

                }

                MyLecturers = MyLecturersDAL.GetList(InitializeModule.EnumCampus.ECTNew, sCondition, isDefaultIncleded);

                for (int i = 0; i < MyLecturers.Count; i++)
                {
                    ListItem lst = new ListItem(MyLecturers[i].LecturerNameEn, MyLecturers[i].LecturerID.ToString());
                    LecturersCBO.Items.Add(lst);
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                MyLecturers.Clear();

            }

        }

        private void Fill_Campus()
        {

            List<LookupDetails> MyLookup = new List<LookupDetails>();
            LookupDetailsDAL MyLookupDAL = new LookupDetailsDAL();
            try
            {
                CampusCBO.Items.Clear();
                MyLookup = MyLookupDAL.GetLookupDetails(InitializeModule.EnumCampus.ECTNew, " And MinorID<3", false, "", InitializeModule.enumLookupType.Campus);

                for (int i = 0; i < MyLookup.Count; i++)
                {
                    ListItem lst = new ListItem(MyLookup[i].DescEn, MyLookup[i].MinorID.ToString());
                    CampusCBO.Items.Add(lst);
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                MyLookup.Clear();

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
                    Terms.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));

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
        protected void SelectBTN_Command(object sender, CommandEventArgs e)
        {
            Session["AttendanceArgs"] = e.CommandArgument.ToString();
            //SetArgs(e.CommandArgument.ToString());     
            Response.Redirect("ClassAttendanceDM.aspx?Campus=" + int.Parse(CampusCBO.SelectedValue).ToString());

        }

        protected void ShowBTN_Command(object sender, CommandEventArgs e)
        {
            SetArgs(e.CommandArgument.ToString());
            Export(InitializeModule.ECT_Buttons.Print);
        }
        private void SetArgs(string sArgs)
        {
            try
            {
                string[] Args = sArgs.Split(';');

                iStudyYear = int.Parse(Args[0]);
                bSemester = byte.Parse(Args[1]);
                bShift = byte.Parse(Args[2]);
                sCourse = Args[3];
                bAttClass = byte.Parse(Args[4]);

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {


            }

        }

        private DataSet Prepare_Report()
        {

            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            Connection_StringCLS myConnection_String = new Connection_StringCLS(CurrentCampus);
            string sConn = myConnection_String.Conn_string;
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            try
            {

                DataColumn iSerialCol = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dt.Columns.Add(iSerialCol);
                DataColumn sSnoCol = new DataColumn("sSno", Type.GetType("System.String"));
                dt.Columns.Add(sSnoCol);
                DataColumn sNameCol = new DataColumn("sName", Type.GetType("System.String"));
                dt.Columns.Add(sNameCol);
                DataColumn sSessionsCol = new DataColumn("sSessions", Type.GetType("System.String"));
                dt.Columns.Add(sSessionsCol);
                DataColumn sAllCol = new DataColumn("sAll", Type.GetType("System.String"));
                dt.Columns.Add(sAllCol);
                DataColumn sPerCol = new DataColumn("sPer", Type.GetType("System.String"));
                dt.Columns.Add(sPerCol);

                DataColumn sWarningTypeCol = new DataColumn("sWarningType", Type.GetType("System.String"));
                dt.Columns.Add(sWarningTypeCol);

                string sSQL = "SELECT AT.sSno, SD.strLastDescEn AS sName";
                sSQL += " , AT.Sessions as dSessions, AT.[All] as dAll ";
                sSQL += " , AT.Per as dPer, AT.sWarningType";
                sSQL += " FROM Reg_Students_Data AS SD INNER JOIN Reg_Applications AS AP ON SD.lngSerial = AP.lngSerial";
                sSQL += " INNER JOIN Web_Att AS AT ON AP.lngStudentNumber = AT.sSno";
                sSQL += " WHERE AT.iYear =" + iStudyYear;
                sSQL += " AND AT.iSem =" + bSemester;
                sSQL += " AND AT.iShift =" + bShift;
                sSQL += " AND AT.sCourse ='" + sCourse + "'";
                sSQL += " AND AT.iClass =" + bAttClass;
                sSQL += " ORDER BY SD.strLastDescEn";

                //string sSQL = "SELECT AT.lngStudentNumber AS sSno, SD.strLastDescEn AS sName";
                //sSQL += " , AT.SumofAbsentHours As dSessions, AT.TotalHours As dAll, AT.AbsentPercentage as dPer";
                //sSQL += " FROM Reg_Students_Data AS SD INNER JOIN Reg_Applications AS AP ON SD.lngSerial = AP.lngSerial";
                //sSQL += " INNER JOIN AttendanceSummeryRpt AS AT ON AP.lngStudentNumber = AT.lngStudentNumber";
                //sSQL += " WHERE AT.intStudyYear =" + iStudyYear;
                //sSQL += " AND AT.byteSemester ="+bSemester;
                //sSQL += " AND AT.byteShift ="+ bShift;
                //sSQL += " AND AT.strCourse ='" + sCourse +"'";
                //sSQL += " AND AT.byteClass =" + bAttClass;
                //sSQL += " ORDER BY SD.strLastDescEn";


                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                int i = 0;
                while (Rd.Read())
                {
                    i += 1;

                    dr = dt.NewRow();

                    dr["iSerial"] = i;
                    dr["sSno"] = Rd["sSno"].ToString();
                    dr["sName"] = Rd["sName"].ToString();
                    dr["sSessions"] = string.Format("{0:F2}", Convert.ToDecimal(Rd["dSessions"]));
                    dr["sAll"] = string.Format("{0:F2}", Convert.ToDecimal(Rd["dAll"]));
                    dr["sPer"] = string.Format("{0:F2}", Convert.ToDecimal(Rd["dPer"]));
                    dr["sWarningType"] = Rd["sWarningType"].ToString();

                    dt.Rows.Add(dr);

                }
                Rd.Close();

                dt.TableName = "Att_Summary_tbl";
                dt.AcceptChanges();
                ds.Tables.Add(dt);


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
            return ds;
        }


        private void Export(InitializeModule.ECT_Buttons iExport)
        {
            ReportDocument myReport = new ReportDocument();

            try
            {

                DataSet rptDS = new DataSet();


                rptDS = Prepare_Report();

                string reportPath = Server.MapPath("Reports/Att_Summary_rpt.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);


                TextObject txt;
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];

                string sTitle = sCourse + " - ";

                switch (bShift)
                {
                    case 1:
                        sTitle += "FM";
                        break;
                    case 2:
                        sTitle += "FE";
                        break;
                    case 4:
                        sTitle += "ME";
                        break;
                    case 8:
                        sTitle += "WEM";
                        break;
                    case 9:
                        sTitle += "WEF";
                        break;

                }

                sTitle += " - Section " + bAttClass.ToString();

                txt.Text = sTitle;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                string sUserName = Session["CurrentUserName"].ToString();
                txt.Text = "/ " + sUserName;



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



                //Session["CurrentReport"] = myReport;
                //Response.Redirect("RPTViewer.aspx?sPage=ProgramMirror.aspx");

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
                myReport.Close();
                myReport.Dispose();
            }
        }
        protected void ClassesGRD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ListBTN_Command(object sender, CommandEventArgs e)
        {

            //View the selected class list.
            List<TimeTable> myTimeTable = new List<TimeTable>();
            TimeTableDAL myTimeTableDAL = new TimeTableDAL();
            DataSet Ds = new DataSet();
            Connection_StringCLS myConnection_String = new Connection_StringCLS(CurrentCampus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                int iTerm = 0;
                int iYear = 0;
                int iSem = 0;
                int iPeriod = 0;
                string sPeriod = "";
                string sCourse = "";
                int iClass = 0;
                int iLecturer = 0;
                string sUnit = "";

                InitializeModule.EnumCampus Campus = CurrentCampus;

                string commandArgument = e.CommandArgument.ToString();
                string[] args = commandArgument.Split(';');

                //Eval("StudyYear") + ";" + Eval("Semester")+ ";" + Eval("Shift") + ";" + Eval("Course")+ ";" + Eval("AttClass")

                iYear = int.Parse(args[0]);
                iSem = int.Parse(args[1]);
                iPeriod = int.Parse(args[2]);
                sCourse = args[3];
                iClass = int.Parse(args[4]);


                iLecturer = 0;//int.Parse(LecturersCBO.SelectedValue);
                              //if (iLecturer > 0)
                              //{
                              //    if (Campus == InitializeModule.EnumCampus.Females)
                              //    {
                              //        iLecturer = LibraryMOD.GetLecturerFemaleID(Conn, iLecturer);
                              //    }
                              //    else
                              //    {
                              //        iLecturer = LibraryMOD.GetLecturerMaleID(Conn, iLecturer);
                              //    }

                //    //iLecturer = GetCampusLecturer(iLecturer, Campus);
                //}


                myTimeTable = myTimeTableDAL.GetTimeTable(iYear, iSem, iPeriod, sCourse, iClass, iLecturer, "", sUnit, true, true, Campus);
                Ds = Prepare_ClassList_Report(myTimeTable);


            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
                Session["ClassListReportDS"] = Ds;
                ExportClassList(InitializeModule.ECT_Buttons.Print);
            }
        }

        private DataSet Prepare_ClassList_Report(List<TimeTable> myTimeTable)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            try
            {
                DataColumn dc;

                dc = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sNo", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sName", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sPeriod", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sMajor", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("CGPA", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("ENG", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Score", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sPhone1", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sPhone2", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sECTemail", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iCPeriod", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCPeriod", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCourse", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iClass", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDetail1", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDetail2", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDetail3", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sClass", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                int iCPeriod = 0;
                string sCPeriod = "";
                string sCourse = "";
                int iClass = 0;
                string sClass = "";

                string sDetail1 = "";
                string sDetail2 = "";
                string sDetail3 = "";
                string sDetail = "";

                int Serial = 0;
                for (int i = 1; i < myTimeTable.Count; i++)
                {
                    iCPeriod = myTimeTable[i].IPeriod;
                    sCPeriod = myTimeTable[i].SPeriod;
                    sCourse = myTimeTable[i].SCourse;
                    iClass = myTimeTable[i].IClass;
                    sClass = sCPeriod + " - " + sCourse + " ( " + iClass + " )";

                    sDetail1 = "";
                    sDetail2 = "";
                    sDetail3 = "";

                    //Collect Additional Times
                    for (int j = 0; j < myTimeTable[i].ClassTimes.Count; j++)
                    {
                        sDetail = myTimeTable[i].ClassTimes[j]._sLecturer;
                        sDetail += " / " + myTimeTable[i].ClassTimes[j]._dFrom.ToShortTimeString();
                        sDetail += "-" + myTimeTable[i].ClassTimes[j]._dTo.ToShortTimeString();
                        sDetail += " ( " + myTimeTable[i].ClassTimes[j]._sDays + " ) ";
                        sDetail += " ( " + myTimeTable[i].ClassTimes[j]._sHall + " ) ";

                        switch (j)
                        {
                            case 0:
                                sDetail1 = sDetail;
                                break;
                            case 1:
                                sDetail2 = sDetail;
                                break;
                            case 2:
                                sDetail3 = sDetail;
                                break;
                        }

                    }
                    Serial = 0;
                    for (int s = 0; s < myTimeTable[i].ClassStudents.Count; s++)
                    {

                        dr = dt.NewRow();
                        Serial += 1;
                        dr["iSerial"] = Serial;
                        dr["sNo"] = myTimeTable[i].ClassStudents[s]._StudentNumber;
                        dr["sName"] = myTimeTable[i].ClassStudents[s]._Name;
                        dr["sPeriod"] = myTimeTable[i].ClassStudents[s]._Period;
                        dr["sMajor"] = myTimeTable[i].ClassStudents[s]._Major;
                        if (myTimeTable[i].ClassStudents[s]._CGPA != null)
                        {
                            dr["CGPA"] = string.Format("{0:f}", myTimeTable[i].ClassStudents[s]._CGPA);
                        }
                        dr["ENG"] = myTimeTable[i].ClassStudents[s]._ENG;
                        if (myTimeTable[i].ClassStudents[s]._Score != null)
                        {
                            dr["Score"] = string.Format("{0:f}", myTimeTable[i].ClassStudents[s]._Score);
                        }


                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ClassList,
                            InitializeModule.enumPrivilege.ShowPhones, CurrentRole) == true)
                        {
                            dr["sPhone1"] = myTimeTable[i].ClassStudents[s]._Phone1;
                            dr["sPhone2"] = myTimeTable[i].ClassStudents[s]._Phone2;
                        }

                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_ClassList,
                            InitializeModule.enumPrivilege.ShowECTemail, CurrentRole) == true)
                        {
                            dr["sECTemail"] = myTimeTable[i].ClassStudents[s]._sECTemail;
                        }


                        dr["iCPeriod"] = iCPeriod;
                        dr["sCPeriod"] = sCPeriod;
                        dr["sCourse"] = sCourse;
                        dr["iClass"] = iClass;
                        dr["sDetail1"] = sDetail1;
                        dr["sDetail2"] = sDetail2;
                        dr["sDetail3"] = sDetail3;
                        dr["sClass"] = sClass;

                        dt.Rows.Add(dr);
                    }
                }
                dt.TableName = "Students";
                dt.AcceptChanges();
                ds.Tables.Add(dt);
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }
            return ds;
        }

        private void ExportClassList(InitializeModule.ECT_Buttons iExport)
        {
            ReportDocument myReport = new ReportDocument();

            try
            {

                DataSet rptDS = new DataSet();


                rptDS = (DataSet)Session["ClassListReportDS"];

                string reportPath = Server.MapPath("Reports/ClassList.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);


                TextObject txt;
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];
                txt.Text = "";

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                string sUserName = Session["CurrentUserName"].ToString();
                txt.Text = "/ " + sUserName;


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
                //divMsg.InnerText = exp.Message;
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myReport.Close();
                myReport.Dispose();
            }
        }
        protected void Terms_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetYearSemester();
        }
        private void GetYearSemester()
        {
            int iY = 0;
            int iYTmp = 0;
            byte iSem = 0;

            iYTmp = Convert.ToInt32(Terms.SelectedValue);
            iY = iYTmp / 10;
            iSem = byte.Parse((iYTmp - (iY * 10)).ToString());

            iSemester.Value = iSem.ToString();
            iYear.Value = iY.ToString();
        }
        protected void CampusCBO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imgQrCode_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string sCode = "";

                string[] Args = e.CommandArgument.ToString().Split(';');

                string sCourse = Args[3];
                if (sCourse.Length < 8)
                {
                    sCourse = "0" + sCourse;
                }
                string sYear = Args[0];
                string sSem = "0" + Args[1];
                string sSession = "0" + Args[2];
                string sClass = Args[4];
                if (sClass.Length == 1)
                {
                    sClass = "0" + sClass;
                }

                sCode = sCourse + sYear + sSem + sSession + sClass;

                generateqrcode(sCode);
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

            }
        }
        private void generateqrcode(string sCode)
        {
            try
            {
                QRCodeGenerator qrCodeGen = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrCodeGen.CreateQrCode(sCode, QRCodeGenerator.ECCLevel.Q);
                System.Web.UI.WebControls.Image imgQrCode = new System.Web.UI.WebControls.Image();
                imgQrCode.Width = 150;
                imgQrCode.Height = 150;
                using (Bitmap bitmap = qrCode.GetGraphic(20))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] byteImage = ms.ToArray();
                        imgQrCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    }
                    phQr.Controls.Add(imgQrCode);
                }
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

            }

        }
    }
}