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
namespace LocalECT
{
    public partial class TimeTableViewer : System.Web.UI.Page
    {
        List<TimeTable> myTimeTable = new List<TimeTable>();

        InitializeModule.EnumCampus CurrentCampus = InitializeModule.EnumCampus.Males;
        int iLecturer = 0;
        int CurrentRole = 0;
        bool isShowAll = false;
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_TimeTable,
                InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");

                }
            }

            //divMsg.InnerText = "";

            isShowAll = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_TimeTable,
               InitializeModule.enumPrivilege.ShowAll, CurrentRole);

            iLecturer = (int)Session["CurrentLecturer"];


            if (!IsPostBack)
            {
                FillTerms();
                FillPeriods();
                Fill_lecturers();
                FillUnits();
                FillCourses();
                Session["ReportDS"] = null;

                //CurrentCampus = (InitializeModule.EnumCampus)Session["CurrentCampus"];

                switch (CurrentCampus)
                {

                    case InitializeModule.EnumCampus.Males:
                    case InitializeModule.EnumCampus.ECTNew:
                        PeriodCBO.SelectedValue = "-1";
                        break;
                    case InitializeModule.EnumCampus.Females:
                        PeriodCBO.SelectedValue = "-2";
                        break;
                }
                switch (PeriodCBO.SelectedIndex)
                {
                    case 4:  //All Males
                    case 5:  //All Males
                    case 6:  //All Males
                    case 8:  //All Males
                        rbnCampus.Items[0].Text = "Media & Males";
                        rbnCampus.Items[1].Text = "Media";
                        rbnCampus.Items[2].Text = "Males";
                        break;
                    case 1:  //All Females
                    case 2:  //All Females
                    case 3:  //All Females
                    case 7:  //All Females
                        rbnCampus.Items[0].Text = "Media & Females";
                        rbnCampus.Items[1].Text = "Media";
                        rbnCampus.Items[2].Text = "Females";
                        break;

                }
                TermCBO.SelectedValue = Session["CurrentYear"].ToString() + Session["CurrentSemester"].ToString();
            }
            else
            {
                Session["CurrentLecturerName"] = LecturerCBO.SelectedItem.Text;
            }



            if (Session["ReportDS"] != null)
            {
                DataSet rptDS;
                rptDS = (DataSet)Session["ReportDS"];
                if (rptDS.Tables.Count > 0)
                {
                    DataTable dt = rptDS.Tables[0];
                    string sFilter = "sTFrom <> ''";

                    DataView dv = new DataView(dt, sFilter, "", DataViewRowState.CurrentRows);


                    //GridTM.DataSource = dv;
                    //GridTM.DataBind();
                    RepterDetails.DataSource = dv;
                    RepterDetails.DataBind();
                }
            }

            //testGrd();
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
                    TermCBO.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));

                }
                //TermCBO.Items.Add(new ListItem( "2013 Fall","20131"));

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

        private void FillPeriods()
        {
            List<St_Session> mySt_Session = new List<St_Session>();
            St_SessionDAL mySt_SessionDAL = new St_SessionDAL();
            try
            {
                mySt_Session = mySt_SessionDAL.GetList(InitializeModule.EnumCampus.ECTNew, " Where IsActive=1 ", true);
                for (int i = 0; i < mySt_Session.Count; i++)
                {
                    PeriodCBO.Items.Add(new ListItem(mySt_Session[i].SessionEn, mySt_Session[i].SessionID.ToString()));

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
                mySt_Session.Clear();

            }
        }
        private void Fill_lecturers()
        {

            List<ECTNewLecturers> MyLecturers = new List<ECTNewLecturers>();
            ECTNewLecturersDAL MyLecturersDAL = new ECTNewLecturersDAL();
            try
            {
                LecturerCBO.Items.Clear();

                MyLecturers = MyLecturersDAL.GetList(InitializeModule.EnumCampus.ECTNew, " Where IsActive=1", true);

                for (int i = 0; i < MyLecturers.Count; i++)
                {
                    ListItem lst = new ListItem(MyLecturers[i].LecturerNameEn, MyLecturers[i].LecturerID.ToString());
                    LecturerCBO.Items.Add(lst);
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                Session["myList"] = MyLecturers;
                //MyLecturers.Clear();

            }

        }
       
        private void Retrieve()
        {
            List<TimeTable> myTimeTable = new List<TimeTable>();
            TimeTableDAL myTimeTableDAL = new TimeTableDAL();
            DataSet Ds = new DataSet();
            try
            {

                int iTerm = 0;
                int iYear = 0;
                int iSem = 0;
                int iPeriod = 0;
                string sPeriod = "";
                string sCourse = "";
                int iClass = 0;
                string sHall = "";
                int iLecturer = 0;
                string sUnit = "";
                InitializeModule.EnumCampus Campus;

                iTerm = int.Parse(TermCBO.SelectedValue);
                iLecturer = int.Parse(LecturerCBO.SelectedValue);

                //if (iTerm == 0 && iLecturer == 0)

                if (iTerm == 0)
                {
                    //divMsg.InnerText = "Select Term Please ...";
                    lbl_Msg.Text = "Select Term Please ...";
                    div_msg.Visible = true;
                    return;
                }
                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

                sPeriod = PeriodCBO.SelectedValue;
                iPeriod = int.Parse(sPeriod);

                if (iPeriod == 0)
                {
                    //divMsg.InnerText = "Select Student Session Please";
                    lbl_Msg.Text = "Select Student Session Please";
                    div_msg.Visible = true;
                    return;
                }
                else
                {
                    Campus = LibraryMOD.SyncCampusAndSession(sPeriod, out iPeriod);
                }

                sCourse = CourseCBO.SelectedValue;
                iClass = int.Parse(ClassCBO.SelectedValue);

                if (iLecturer > 0)
                {
                    iLecturer = GetCampusLecturer(iLecturer, Campus);
                }
                sUnit = UnitCBO.SelectedValue;
                if (sUnit == "0")
                {
                    sUnit = "";
                }
                if (sCourse == "Select Course ...")
                {
                    sCourse = "";
                }

                //string sCampus = "";
                //sCampus = " AND (";
                //for (int i = 0; i < chkCampus.Items.Count; i++)
                //{
                //    if (chkCampus.Items[i].Selected == true)
                //    {
                //        if (sCampus == " AND (")
                //        {
                //            sCampus += " H.iCampus=" + chkCampus.Items[i].Value;
                //        }
                //        else
                //        {
                //            sCampus += " OR H.iCampus=" + chkCampus.Items[i].Value;
                //        }
                //    }
                //}
                //if (sCampus != " AND (")
                //{
                //    sCampus += ")";
                //}
                //else
                //{
                //    sCampus = "";
                //}

                myTimeTable = myTimeTableDAL.GetTimeTable(iYear, iSem, iPeriod, sCourse, iClass, iLecturer, "", sUnit, false, isShowAll, Campus, chkShowPassedOnly.Checked);
                Ds = Prepare_Report(myTimeTable);


            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                Enable_Disable(myTimeTable.Count > 0);
                Session["ReportDS"] = Ds;

            }

        }

        protected void RunCMD_Click(object sender, EventArgs e)
        {
            //testGrd();
            Enable_Disable(false);
            Retrieve();

        }

        private DataSet Prepare_Report(List<TimeTable> myTimeTable)
        {

            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            try
            {
                DataColumn dc;

                dc = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iPeriod", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sPeriod", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCourse", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDesc", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iClass", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sTFrom", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sTTo", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iLecturer", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sLecturer", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                //dc = new DataColumn("iLecturer1", Type.GetType("System.Int32"));
                //dt.Columns.Add(dc);
                //dc = new DataColumn("sLecturer1", Type.GetType("System.String"));
                //dt.Columns.Add(dc);


                dc = new DataColumn("iDay", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDay", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iMax", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iCapacity", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sHall", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sUnified", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCollege", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("CommitteeID", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDispalyUnified", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCampus", Type.GetType("System.String"));
                dt.Columns.Add(dc);


                int Serial = 0;
                for (int i = 1; i < myTimeTable.Count; i++)
                {
                    dr = dt.NewRow();
                    Serial += 1;
                    dr["iSerial"] = Serial;
                    dr["iPeriod"] = myTimeTable[i].IPeriod;
                    dr["sPeriod"] = myTimeTable[i].SPeriod;
                    dr["sCourse"] = myTimeTable[i].SCourse;
                    dr["sDesc"] = myTimeTable[i].SDesc;
                    dr["iClass"] = myTimeTable[i].IClass;
                    dr["sUnified"] = myTimeTable[i].sUnified;
                    dr["sDispalyUnified"] = myTimeTable[i].sDispalyUnified;
                    dr["sCollege"] = myTimeTable[i].sCollege;
                    dr["CommitteeID"] = myTimeTable[i].iCommitteeID;
                    //add Times


                    dr["iLecturer"] = myTimeTable[i].ClassTimes[0]._iLecturer;
                    dr["sLecturer"] = myTimeTable[i].ClassTimes[0]._sLecturer;

                    //dr["iLecturer1"] = myTimeTable[i].ClassTimes[0]._iLecturer1;
                    //dr["sLecturer1"] = myTimeTable[i].ClassTimes[0]._sLecturer1;

                    dr["sTFrom"] = myTimeTable[i].ClassTimes[0]._dFrom.ToShortTimeString();
                    dr["sTTo"] = myTimeTable[i].ClassTimes[0]._dTo.ToShortTimeString();

                    dr["iDay"] = myTimeTable[i].ClassTimes[0]._iDays;
                    dr["sDay"] = myTimeTable[i].ClassTimes[0]._sDays + "  " + myTimeTable[i].ClassTimes[0]._sNotes;
                    dr["sHall"] = myTimeTable[i].ClassTimes[0]._sHall;// +" | " + myTimeTable[i].ClassTimes[0]._sCampus;
                    dr["sCampus"] = myTimeTable[i].ClassTimes[0]._sCampus;

                    //*
                    if (chkShowRegCount.Checked)
                    {
                        dr["iMax"] = myTimeTable[i].IMax;
                        dr["iCapacity"] = myTimeTable[i].ICapacity;
                    }
                    else
                    {
                        dr["iMax"] = 0;
                        dr["iCapacity"] = 0;
                    }
                    switch (rbnCampus.SelectedIndex)
                    {
                        case 0:  //add all media and males and females
                            dt.Rows.Add(dr);
                            break;
                        case 1:  //add media only
                            if (myTimeTable[i].ClassTimes[0]._sCampus == "Media")
                            {
                                dt.Rows.Add(dr);
                            }
                            break;
                        case 2:
                            if (myTimeTable[i].ClassTimes[0]._sCampus == "Males" || myTimeTable[i].ClassTimes[0]._sCampus == "Females")
                            {
                                dt.Rows.Add(dr);
                            }
                            break;
                    }



                    //Collect Additional Times
                    for (int j = 1; j < myTimeTable[i].ClassTimes.Count; j++)
                    {
                        dr = dt.NewRow();
                        Serial += 1;
                        dr["iSerial"] = Serial;

                        dr["iPeriod"] = myTimeTable[i].IPeriod;
                        dr["sPeriod"] = myTimeTable[i].SPeriod;
                        dr["sCourse"] = myTimeTable[i].SCourse;
                        dr["sDesc"] = myTimeTable[i].SDesc;
                        dr["iClass"] = myTimeTable[i].IClass;
                        dr["sUnified"] = myTimeTable[i].sUnified;
                        dr["sDispalyUnified"] = myTimeTable[i].sDispalyUnified;
                        dr["sCollege"] = myTimeTable[i].sCollege;
                        dr["CommitteeID"] = myTimeTable[i].iCommitteeID;

                        dr["iLecturer"] = myTimeTable[i].ClassTimes[j]._iLecturer;
                        dr["sLecturer"] = myTimeTable[i].ClassTimes[j]._sLecturer;

                        //dr["iLecturer1"] = myTimeTable[i].ClassTimes[j]._iLecturer1;
                        //dr["sLecturer1"] = myTimeTable[i].ClassTimes[j]._sLecturer1;

                        if (myTimeTable[i].ClassTimes[j]._dFrom.ToShortTimeString() == "12:00 AM")
                        {
                            dr["sTFrom"] = "";
                            dr["sTTo"] = "";
                        }
                        else
                        {
                            dr["sTFrom"] = myTimeTable[i].ClassTimes[j]._dFrom.ToShortTimeString();
                            dr["sTTo"] = myTimeTable[i].ClassTimes[j]._dTo.ToShortTimeString();
                        }

                        dr["iDay"] = myTimeTable[i].ClassTimes[j]._iDays;
                        dr["sDay"] = myTimeTable[i].ClassTimes[j]._sDays + "  " + myTimeTable[i].ClassTimes[j]._sNotes;
                        dr["sHall"] = myTimeTable[i].ClassTimes[j]._sHall;// +" | " + myTimeTable[i].ClassTimes[j]._sCampus;
                        dr["sCampus"] = myTimeTable[i].ClassTimes[j]._sCampus;

                        if (chkShowRegCount.Checked)
                        {
                            dr["iMax"] = myTimeTable[i].IMax;
                            dr["iCapacity"] = myTimeTable[i].ICapacity;
                        }
                        else
                        {
                            dr["iMax"] = 0;
                            dr["iCapacity"] = 0;

                        }

                        switch (rbnCampus.SelectedIndex)
                        {
                            case 0:  //add all media and males and females
                                dt.Rows.Add(dr);
                                break;
                            case 1:  //add media only
                                if (myTimeTable[i].ClassTimes[j]._sCampus == "Media")
                                {
                                    dt.Rows.Add(dr);
                                }
                                break;
                            case 2:
                                if (myTimeTable[i].ClassTimes[j]._sCampus == "Males" || myTimeTable[i].ClassTimes[j]._sCampus == "Females")
                                {
                                    dt.Rows.Add(dr);
                                }
                                break;
                        }

                    }


                }
                dt.TableName = "TimeTable";
                dt.AcceptChanges();
                ds.Tables.Add(dt);
                //GridTM.PageIndex = 0;

                string sFilter = "sTFrom <> '' AND sTFrom <> '12:00 AM' AND sTFrom <> '12:00AM'";


                DataView dv = new DataView(dt, sFilter, "", DataViewRowState.CurrentRows);


                //GridTM.DataSource = dv;
                //GridTM.DataBind();

                RepterDetails.DataSource = dv;
                RepterDetails.DataBind();



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

        private DataSet Prepare_Attendance_Report(string sSQL, InitializeModule.EnumCampus campus)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            Connection_StringCLS myConnection_String = new Connection_StringCLS(campus);
            SqlConnection conn = new SqlConnection(myConnection_String.Conn_string);
            conn.Open();
            try
            {
                DataColumn dc;
                int Serial = 0;
                dc = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Lecturer", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Session", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Course", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Class", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Student", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Name", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Date", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("StatusNo", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Status", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Factor", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("isWEW", Type.GetType("System.String"));
                dt.Columns.Add(dc);


                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {

                    dr = dt.NewRow();
                    Serial += 1;
                    dr["iSerial"] = Serial;
                    dr["Lecturer"] = rd["Lecturer"].ToString();
                    dr["Session"] = rd["Session"].ToString();
                    dr["Course"] = rd["Course"].ToString();
                    dr["Class"] = rd["Class"].ToString();
                    dr["Student"] = rd["Student"].ToString();
                    dr["Name"] = rd["Name"].ToString();
                    dr["Date"] = rd["Date"].ToString();
                    dr["StatusNo"] = rd["StatusNo"].ToString();
                    dr["Status"] = rd["Status"].ToString();
                    dr["Factor"] = rd["Factor"].ToString();
                    dr["isWEW"] = rd["W/EW"].ToString();


                    dt.Rows.Add(dr);
                }

                dt.TableName = "Attendance";
                dt.AcceptChanges();
                ds.Tables.Add(dt);
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                conn.Close();
                conn.Dispose();

            }
            return ds;
        }
        private void Export(InitializeModule.ECT_Buttons iExport)
        {
            ReportDocument myReport = new ReportDocument();

            try
            {

                DataSet rptDS = new DataSet();


                rptDS = (DataSet)Session["ReportDS"];

                string reportPath = Server.MapPath("Reports/TimeTable.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);


                TextObject txt;
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];

                txt.Text = GetCaption();

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                string sUserName = Session["CurrentUserName"].ToString();
                txt.Text = "/ " + sUserName;

                if (!chkShowRegCount.Checked)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtMaxSeats"];
                    txt.Text = "";
                    txt.Color = System.Drawing.Color.White;
                    txt.ObjectFormat.EnableSuppress = true;

                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtRegCount"];
                    txt.Text = "";
                    txt.Color = System.Drawing.Color.White;
                    txt.ObjectFormat.EnableSuppress = true;
                }


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
                txt.Text = GetCaption();

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

        private void ExportAttendance()
        {
            ReportDocument myReport = new ReportDocument();

            try
            {

                DataSet rptDS = new DataSet();


                rptDS = (DataSet)Session["AttendanceDS"];

                string reportPath = Server.MapPath("Reports/AttReport.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);

                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Page.Response, true, "ECTReport");

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

        protected void PrintCMD_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_TimeTable,
                InitializeModule.enumPrivilege.Print, CurrentRole) != true)
            {
                //divMsg.InnerText = InitializeModule.MsgPrintAuthorization;
                lbl_Msg.Text = InitializeModule.MsgPrintAuthorization;
                div_msg.Visible = true;
                return;
            }

            Export(InitializeModule.ECT_Buttons.Print);
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //int iIndex = e.NewPageIndex;
            //GridTM.PageIndex = iIndex;  
        }

        private void FillUnits()
        {
            List<Colleges> myColleges = new List<Colleges>();
            CollegesDAL myCollegesDAL = new CollegesDAL();
            try
            {
                myColleges = myCollegesDAL.GetList(InitializeModule.EnumCampus.Males, " IsActive=1", true);
                for (int i = 0; i < myColleges.Count; i++)
                {
                    UnitCBO.Items.Add(new ListItem(myColleges[i].strCollegeDescEn, myColleges[i].strCollege));

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
                myColleges.Clear();

            }
        }

        private void FillCourses()
        {
            List<Courses> myCourses = new List<Courses>();
            CoursesDAL myCoursesDAL = new CoursesDAL();
            try
            {
                myCourses = myCoursesDAL.GetList(InitializeModule.EnumCampus.Males, "", true);
                for (int i = 0; i < myCourses.Count; i++)
                {
                    CourseCBO.Items.Add(new ListItem(myCourses[i].strCourse, myCourses[i].strCourse));
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
                myCourses.Clear();

            }
        }

        private void Enable_Disable(bool isEnabled)
        {
            try
            {
                PrintCMD.ImageUrl = LibraryMOD.GetButtonImageURL(InitializeModule.ECT_Buttons.Print, isEnabled);
                toExcelCMD.ImageUrl = LibraryMOD.GetButtonImageURL(InitializeModule.ECT_Buttons.ToExcel, isEnabled);
                toWordCMD.ImageUrl = LibraryMOD.GetButtonImageURL(InitializeModule.ECT_Buttons.ToWord, isEnabled);
                PrintCMD.Enabled = isEnabled;
                toExcelCMD.Enabled = isEnabled;
                toWordCMD.Enabled = isEnabled;
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





        protected void toExcelCMD_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_TimeTable,
                InitializeModule.enumPrivilege.TransferToExcel, CurrentRole) != true)
            {
                //divMsg.InnerText = InitializeModule.MsgTransferToExcelAuthorization;
                lbl_Msg.Text = InitializeModule.MsgTransferToExcelAuthorization;
                div_msg.Visible = true;
                return;
            }

            Export(InitializeModule.ECT_Buttons.ToExcel);

        }
        protected void toWordCMD_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_TimeTable,
                InitializeModule.enumPrivilege.TransferToWord, CurrentRole) != true)
            {
                //divMsg.InnerText = InitializeModule.MsgTransferToWordAuthorization;
                lbl_Msg.Text = InitializeModule.MsgTransferToWordAuthorization;
                div_msg.Visible = true;
                return;
            }

            Export(InitializeModule.ECT_Buttons.ToWord);

        }
        private int GetCampusLecturer(int iLecturer, InitializeModule.EnumCampus Campus)
        {
            int iResult = 0;
            try
            {
                List<ECTNewLecturers> MyLecturers = (List<ECTNewLecturers>)Session["myList"];
                int iIndex = 0;
                iIndex = MyLecturers.FindIndex(delegate (ECTNewLecturers L) { return L.LecturerID == iLecturer; });
                if (iIndex > 0)
                {
                    switch (Campus)
                    {
                        case InitializeModule.EnumCampus.Females:
                            iResult = MyLecturers[iIndex].FCampusID;
                            break;
                        case InitializeModule.EnumCampus.Males:
                            iResult = MyLecturers[iIndex].MCampusID;
                            break;
                    }
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
            return iResult;

        }
        private string GetCaption()
        {
            string sCaption = "";
            try
            {
                ListItem lst;
                lst = TermCBO.SelectedItem;
                sCaption = lst.Text + " - ";
                lst = PeriodCBO.SelectedItem;

                sCaption += lst.Text;
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
            return sCaption;

        }


        protected void BtnView_Command(object sender, CommandEventArgs e)
        {
            //View the selected class list.
            List<TimeTable> myTimeTable = new List<TimeTable>();
            TimeTableDAL myTimeTableDAL = new TimeTableDAL();
            DataSet Ds = new DataSet();
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
                InitializeModule.EnumCampus Campus;

                iTerm = int.Parse(TermCBO.SelectedValue);
                if (iTerm == 0)
                {
                    //divMsg.InnerText = "Select Term Please ...";
                    lbl_Msg.Text = "Select Term Please ...";
                    div_msg.Visible = true;
                    return;
                }
                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

                sPeriod = PeriodCBO.SelectedValue;
                iPeriod = int.Parse(sPeriod);

                if (iPeriod == 0)
                {
                    //divMsg.InnerText = "Select Student Session Please";
                    lbl_Msg.Text = "Select Student Session Please";
                    div_msg.Visible = true;
                    return;
                }
                else
                {
                    Campus = LibraryMOD.SyncCampusAndSession(sPeriod, out iPeriod);
                }

                //sCourse = CourseCBO.SelectedValue;
                //iClass = int.Parse(ClassCBO.SelectedValue);
                string commandArgument = e.CommandArgument.ToString();
                string[] args = commandArgument.Split(';');
                //Eval("sCourse")+ ";" + Eval("iClass") .. Period

                //sPeriod = GridTM.SelectedRow.Cells[1].Text;    

                sCourse = args[0];
                iClass = int.Parse(args[1]);
                iPeriod = int.Parse(args[2]);
                sPeriod = args[3];

                iLecturer = int.Parse(LecturerCBO.SelectedValue);
                if (iLecturer > 0)
                {
                    iLecturer = GetCampusLecturer(iLecturer, Campus);
                }
                sUnit = UnitCBO.SelectedValue;
                if (sUnit == "0")
                {
                    sUnit = "";
                }
                if (sCourse == "Select Course ...")
                {
                    sCourse = "";
                }

                myTimeTable = myTimeTableDAL.GetTimeTable(iYear, iSem, iPeriod, sCourse, iClass, iLecturer, "", sUnit, true, isShowAll, Campus);
                Ds = Prepare_ClassList_Report(myTimeTable);


            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                Enable_Disable(myTimeTable.Count > 0);
                Session["ClassListReportDS"] = Ds;
                ExportClassList(InitializeModule.ECT_Buttons.Print);
            }


        }
        protected void PeriodCBO_SelectedIndexChanged(object sender, EventArgs e)
        {





            switch (PeriodCBO.SelectedIndex)
            {
                case 4:  //All Males
                case 5:  //All Males
                case 6:  //All Males
                case 8:  //All Males
                    rbnCampus.Items[0].Text = "Media & Males";
                    rbnCampus.Items[1].Text = "Media";
                    rbnCampus.Items[2].Text = "Males";
                    break;
                case 1:  //All Females
                case 2:  //All Females
                case 3:  //All Females
                case 7:  //All Females
                    rbnCampus.Items[0].Text = "Media & Females";
                    rbnCampus.Items[1].Text = "Media";
                    rbnCampus.Items[2].Text = "Females";
                    break;

            }
        }
        protected void BtnAtt_Command(object sender, CommandEventArgs e)
        {
            DataSet Ds = new DataSet();
            try
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentCenter,
                InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    //divMsg.InnerText = "Sorry you dont have permission to view the attendance details from here...";
                    lbl_Msg.Text = "Sorry you dont have permission to view the attendance details from here...";
                    div_msg.Visible = true;
                    return;
                }

                int iTerm = 0;
                int iYear = 0;
                int iSem = 0;
                string sPeriod = "";
                int iPeriod = 0;
                string sCourse = "";
                int iClass = 0;

                InitializeModule.EnumCampus Campus;

                iTerm = int.Parse(TermCBO.SelectedValue);
                if (iTerm == 0)
                {
                    //divMsg.InnerText = "Select Term Please ...";
                    lbl_Msg.Text = "Select Term Please ...";
                    div_msg.Visible = true;
                    return;
                }
                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

                sPeriod = PeriodCBO.SelectedValue;
                iPeriod = int.Parse(sPeriod);

                if (iPeriod == 0)
                {
                    //divMsg.InnerText = "Select Student Session Please";
                    lbl_Msg.Text = "Select Student Session Please";
                    div_msg.Visible = true;
                    return;
                }
                else
                {
                    Campus = LibraryMOD.SyncCampusAndSession(sPeriod, out iPeriod);
                }

                //sCourse = CourseCBO.SelectedValue;
                //iClass = int.Parse(ClassCBO.SelectedValue);
                string commandArgument = e.CommandArgument.ToString();
                string[] args = commandArgument.Split(';');
                //Eval("sCourse")+ ";" + Eval("iClass") .. Period

                //sPeriod = GridTM.SelectedRow.Cells[1].Text;    

                sCourse = args[0];
                iClass = int.Parse(args[1]);
                iPeriod = int.Parse(args[2]);
                sPeriod = args[3];

                //string sSQL = "SELECT L.strLecturers AS Lecturer, P.strShortcut AS Session, R.Course, R.Class, R.Student, SD.strLastDescEn AS Name, AT.Date, AT.StatusNo, AT.Status, AT.Factor,ISNULL(W_EW.strGrade,'-') AS [W/EW]";
                //sSQL += " FROM (SELECT iYear, Sem, Shift, Course, Class, Student FROM Course_Balance_View AS CV";
                //sSQL += " WHERE (iYear = " + iYear + ") AND (Sem =" + iSem + ") AND (Shift = " + iPeriod + ") AND (Course = N'" + sCourse + "') AND (Class =" + iClass + ")) AS R INNER JOIN";
                //sSQL += " Reg_Students_Data AS SD INNER JOIN Reg_Applications AS A ON SD.lngSerial = A.lngSerial ON R.Student = A.lngStudentNumber INNER JOIN";
                //sSQL += " dbo.Collect_Lecturers() AS L ON R.iYear = L.intStudyYear AND R.Sem = L.byteSemester AND R.Shift = L.byteShift AND R.Course = L.strCourse AND";
                //sSQL += " R.Class = L.byteClass INNER JOIN Reg_Shifts AS P ON R.Shift = P.byteShift LEFT OUTER JOIN";
                //sSQL += " W_EW ON R.iYear = W_EW.intStudyYear AND R.Sem = W_EW.byteSemester AND R.Shift = W_EW.byteShift AND R.Course = W_EW.strCourse AND";
                //sSQL += " R.Class = W_EW.byteClass AND R.Student = W_EW.lngStudentNumber LEFT OUTER JOIN";
                //sSQL += " (SELECT TOP (100) PERCENT ATT.intStudyYear, ATT.byteSemester, ATT.byteShift, ATT.strCourse, ATT.byteClass, ATT.lngStudentNumber AS SID,";
                //sSQL += " CONVERT(VARCHAR, DAY(ATT.dateAttendance)) + '-' + CONVERT(VARCHAR, MONTH(ATT.dateAttendance)) + '-' + CONVERT(VARCHAR, ";
                //sSQL += " YEAR(ATT.dateAttendance)) AS Date, ATT.byteAttStatus AS StatusNo, S.strAttDescEn AS Status, S.curFactor AS Factor";
                //sSQL += " FROM Reg_Attendance AS ATT INNER JOIN Lkp_Att_Status AS S ON ATT.byteAttStatus = S.byteAttStatus";
                //sSQL += " WHERE (CONVERT(DATE, CONVERT(VARCHAR, YEAR(ATT.dateAttendance)) + '-' + CONVERT(VARCHAR, MONTH(ATT.dateAttendance)) + '-' + CONVERT(VARCHAR,";
                //sSQL += " DAY(ATT.dateAttendance))) BETWEEN CONVERT(DATE, '2017-10-06') AND CONVERT(DATE, '2018-01-16'))";
                //sSQL += " ORDER BY CONVERT(DATE, CONVERT(VARCHAR, YEAR(ATT.dateAttendance)) + '-' + CONVERT(VARCHAR, MONTH(ATT.dateAttendance)) + '-' + CONVERT(VARCHAR,";
                //sSQL += " DAY(ATT.dateAttendance)))) AS AT ON R.Student = AT.SID AND R.iYear = AT.intStudyYear AND R.Sem = AT.byteSemester AND R.Shift = AT.byteShift AND";
                //sSQL += " R.Course = AT.strCourse AND R.Class = AT.byteClass ORDER BY AT.Date, SD.strLastDescEn";

                //Ds = Prepare_Attendance_Report(sSQL, Campus);

                //Session["AttendanceDS"] = Ds;
                //ExportAttendance();

                Session["AttendanceArgs"] = iYear + ";" + iSem + ";" + iPeriod + ";" + sCourse + ";" + iClass;
                //SetArgs(e.CommandArgument.ToString());     
                Response.Redirect("ClassAttendanceDM.aspx?Campus=" + ((int)Campus).ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                //Enable_Disable(myTimeTable.Count > 0);
                //Session["AttendanceDS"] = Ds;
                //ExportAttendance();
            }

        }
        protected void SelectBTN_Command(object sender, CommandEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentCenter,
                 InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
            {
                //divMsg.InnerText = "Sorry you dont have permission to view the attendance details from here...";
                lbl_Msg.Text = "Sorry you dont have permission to view the Grades details from here...";
                div_msg.Visible = true;
                return;
            }

            int iTerm = 0;
            int iYear = 0;
            int iSem = 0;
            string sPeriod = "";
            int iPeriod = 0;
            string sCourse = "";
            int iClass = 0;

            InitializeModule.EnumCampus Campus;

            iTerm = int.Parse(TermCBO.SelectedValue);
            if (iTerm == 0)
            {
                //divMsg.InnerText = "Select Term Please ...";
                lbl_Msg.Text = "Select Term Please ...";
                div_msg.Visible = true;
                return;
            }
            iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

            sPeriod = PeriodCBO.SelectedValue;
            iPeriod = int.Parse(sPeriod);

            if (iPeriod == 0)
            {
                //divMsg.InnerText = "Select Student Session Please";
                lbl_Msg.Text = "Select Student Session Please";
                div_msg.Visible = true;
                return;
            }
            else
            {
                Campus = LibraryMOD.SyncCampusAndSession(sPeriod, out iPeriod);
            }

            //sCourse = CourseCBO.SelectedValue;
            //iClass = int.Parse(ClassCBO.SelectedValue);
            string commandArgument = e.CommandArgument.ToString();
            string[] args = commandArgument.Split(';');
            //Eval("sCourse")+ ";" + Eval("iClass") .. Period

            //sPeriod = GridTM.SelectedRow.Cells[1].Text;    

            sCourse = args[0];
            iClass = int.Parse(args[1]);
            iPeriod = int.Parse(args[2]);
            sPeriod = args[3];

            //CommandArgument = '<%# Eval("StudyYear") + ";" + Eval("Semester")+ ";" + Eval("Shift") + ";" + Eval("Course")+ ";" + Eval("AttClass") %>'

            Session["GradesArgs"] = iYear + ";" + iSem + ";" + iPeriod + ";" + sCourse + ";" + iClass;
            //Session["GradesArgs"] = e.CommandArgument.ToString();
            Session["OpenGradesType"] = InitializeModule.EnumGradeDMType.Entry;
            string sData = "";
            sData = "GradesDM.aspx?Campus=" + ((int)Campus).ToString();
            sData += "&Term=" + TermCBO.SelectedValue.ToString();
            Response.Redirect(sData);
        }
        protected void UnitCBO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UnitCBO.SelectedValue == "19") //language center
            {
                chkShowPassedOnly.Checked = true;
                chkShowPassedOnly.Visible = true;
            }
            else
            {
                chkShowPassedOnly.Checked = false;
                chkShowPassedOnly.Visible = false;
            }

        }
    }
}