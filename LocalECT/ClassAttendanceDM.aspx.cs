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
using System.Drawing;

namespace LocalECT
{
    public partial class ClassAttendanceDM : System.Web.UI.Page
    {
        string sDate;
        InitializeModule.EnumCampus CurrentCampus = InitializeModule.EnumCampus.Males;
        int iCurrentCampus = 0;
        Table MyTable = new Table();

        int iStudyYear = 0;
        byte bSemester = 0;
        byte bShift = 0;
        string sCourse = "";
        string sUnifiedCode = "";
        byte bAttClass = 0;
        int CurrentRole = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    //----------------------- Log History --------------------------------
                    int iDataStatus = (int)InitializeModule.enumModes.NewMode;
                    int iEffected = 0;

                    int iUserNo = Convert.ToInt32(Session["CurrentUserNo"]);
                    string sPCName = Convert.ToString(Session["CurrentPCName"]);
                    string sNetUserName = Convert.ToString(Session["CurrentNetUserName"]);
                    int iSystem = Convert.ToInt32(Session["CurrentSystem"]);
                    int iYear = Convert.ToInt32(Session["CurrentYear"]);
                    int iSemester = Convert.ToInt32(Session["CurrentSemester"]);

                    LogHistoryDAL myLogHistoryDAL = new LogHistoryDAL();

                    iEffected = myLogHistoryDAL.UpdateLogHistory(InitializeModule.EnumCampus.ECTNew,
                        iDataStatus, 0, iUserNo, DateTime.Now, sPCName, sNetUserName,
                        iSystem, (int)InitializeModule.enumPrivilegeObjects.ECT_Attendance,
                        iYear, iSemester);

                    if (iEffected > 0)
                    {

                    }
                    else
                    {
                        //divMsg.InnerText = "Error in Update log";
                        lbl_Msg.Text = "Error in Update log";
                        div_msg.Visible = true;
                    }
                    //----------------------- Log History --------------------------------
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Attendance,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");

                    }
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }

            iCurrentCampus = int.Parse(Request.QueryString["Campus"]);
            CurrentCampus = (InitializeModule.EnumCampus)iCurrentCampus;//Session["CurrentCampus"];
            MyTable.ID = "MyTable";


            if (Session["AttendanceArgs"] != null)
            {
                string sArgs = Session["AttendanceArgs"].ToString();
                SetArgs(sArgs);
            }


            if (!IsPostBack)
            {
                sDate = string.Format("{0:dd/MM/yyyy}", DateTime.Today.Date);
                txt_date.Text = sDate;
                dCalender.SelectedDate = LibraryMOD.GetDateFromString(sDate);
                Retrieve();
            }
            else
            {
                sDate = string.Format("{0:dd/MM/yyyy}", dCalender.SelectedDate);
                if (Session["AttendanceTable"] != null)
                {
                    MyTable = (Table)Session["AttendanceTable"];
                }
                EnableDisable(MyTable.Rows.Count >= 1);
            }
        }

        protected void CalendarBTN_Click(object sender, ImageClickEventArgs e)
        {
            dCalender.Visible = (!dCalender.Visible);
        }

        protected void dCalender_SelectionChanged(object sender, EventArgs e)
        {
            sDate = string.Format("{0:dd/MM/yyyy}", dCalender.SelectedDate.Date);
            txt_date.Text = sDate;
            Retrieve();
            dCalender.Visible = false;
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

                CoursesDAL theCourse = new CoursesDAL();
                sUnifiedCode = theCourse.GetUnifiedCourseCode_FromAvailableCourses(CurrentCampus, sCourse, iStudyYear, bSemester);

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {


            }

        }

        private string CreateCaption()
        {

            List<ClassesCLS> myCurrenClass = new List<ClassesCLS>();
            ClassesDAL myClassesDAL = new ClassesDAL();
            string sCaption = "";
            try
            {

                string sCondition = " Where intStudyYear=" + iStudyYear;
                sCondition += " And byteSemester=" + bSemester;
                sCondition += " And byteShift=" + bShift;
                sCondition += " And strCourse='" + sCourse + "'";
                sCondition += " And byteClass=" + bAttClass;

                myCurrenClass = myClassesDAL.GetClasses(CurrentCampus, sCondition);
                for (int i = 0; i < myCurrenClass.Count; i++)
                {
                    sCaption += myCurrenClass[i].Course + " Class # " + myCurrenClass[i].AttClass + " / " + myCurrenClass[i].Shortcut + " ( " + myCurrenClass[i].TimeFrom + " - " + myCurrenClass[i].TimeTo + " - " + myCurrenClass[i].Days + " )</br>";
                }



            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = "Error: " + exp.Message;
                lbl_Msg.Text = "Error: " + exp.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myCurrenClass.Clear();
            }
            return sCaption;


        }


        private void Retrieve()
        {
            List<AttendanceCLS> myClass = new List<AttendanceCLS>();
            AttendanceDAL myAttendance = new AttendanceDAL();

            try
            {

                int r = 0;
                //string sCondition = " CB.iYear=" + iStudyYear;
                //sCondition += " And CB.Sem=" + bSemester;
                //sCondition += " And CB.Shift=" + bShift;
                //sCondition += " And CB.Course='" + sCourse + "'";
                //sCondition += " And CB.Class=" + bAttClass;
                string sCondition = " CB.iYear=" + iStudyYear;
                sCondition += " And CB.Sem=" + bSemester;
                sCondition += " And CB.Shift=" + bShift;
                //sCondition += " And CB.Course='" + sCourse + "'";
                //sCondition += " And CB.sUnified='" + sUnifiedCode + "'";
                sCondition += " And C.sTMCode='" + sUnifiedCode + "'";
                sCondition += " And CB.Class=" + bAttClass;

                myClass = myAttendance.GetAttendance(CurrentCampus, sCondition, sDate);

                MyTable.Rows.Clear();
                r = Show_Data(myClass);

                EnableDisable(r >= 1);


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = "Error: " + exp.Message;
                lbl_Msg.Text = "Error: " + exp.Message;
                div_msg.Visible = true;
            }

        }

        //private int Show_Data(List<AttendanceCLS> myClass)
        //{
        //    int r = 0;
        //    AttStatusDAL myStatusDAL = new AttStatusDAL();
        //    bool isMilitary = false;
        //    bool isACCWanted = false;
        //    try
        //    {
        //        TableHeaderRow H = new TableHeaderRow();
        //        TableHeaderCell HCHeader = new TableHeaderCell();
        //        Literal Lt = new Literal();
        //        Lt.Text = CreateCaption();
        //        HCHeader.ColumnSpan = 5;
        //        HCHeader.Controls.Add(Lt);
        //        H.Cells.Add(HCHeader);
        //        MyTable.Rows.Add(H);

        //        //string sStyle = "background-color: #FFFFFF color: #0033CC";
        //        TableHeaderRow Hr = new TableHeaderRow();
        //        //Hr.Attributes.Add("style", sStyle);

        //        TableHeaderCell HCSerial = new TableHeaderCell();
        //        HCSerial.Text = "#";
        //        Hr.Cells.Add(HCSerial);

        //        TableHeaderCell HCNo = new TableHeaderCell();
        //        HCNo.Text = "No";
        //        Hr.Cells.Add(HCNo);

        //        TableHeaderCell HCName = new TableHeaderCell();
        //        HCName.Text = "Name";
        //        Hr.Cells.Add(HCName);

        //        TableHeaderCell HCStatus = new TableHeaderCell();
        //        HCStatus.Text = "Status";
        //        Hr.Cells.Add(HCStatus);

        //        //TableHeaderCell HCRemind = new TableHeaderCell();
        //        //HCRemind.Text = "*";
        //        //Hr.Cells.Add(HCRemind);

        //        //removed by bahaa addin in 7/11/2012
        //        //retunned as contact the administration in 4th floor 10-3-2013
        //        TableHeaderCell HCFinance = new TableHeaderCell();
        //        HCFinance.Text = "?";
        //        Hr.Cells.Add(HCFinance);

        //        MyTable.BorderStyle = BorderStyle.Solid;
        //        MyTable.BorderWidth = 1;
        //        MyTable.GridLines = GridLines.Both;

        //        MyTable.Rows.Add(Hr);

        //        TableRow TR = new TableRow();

        //        TableCell TDSerial = new TableCell();
        //        TableCell TDNo = new TableCell();
        //        TableCell TDName = new TableCell();
        //        TableCell TDStatus = new TableCell();
        //        TableCell TDFinance = new TableCell();
        //        TableCell TDRemind = new TableCell();

        //        DropDownList cbo = new DropDownList();               
        //        CheckBox chk = new CheckBox();
        //        System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();

        //        for (r = 0; r < myClass.Count; r++)
        //        {

        //            TR = new TableRow();
        //            TR.ID = "tr" + r;

        //            TDSerial = new TableCell();
        //            TDNo = new TableCell();
        //            TDName = new TableCell();
        //            TDStatus = new TableCell();


        //            TDFinance = new TableCell();
        //            //TDRemind = new TableCell();

        //            TDSerial.ID = "tdSerial" + r;
        //            TDSerial.Text = (r + 1).ToString();
        //            TDNo.ID = "tdNo" + r;
        //            TDNo.Text = myClass[r].StudentNumber;
        //            TDName.ID = "tdName" + r;
        //            TDName.Text = myClass[r].StudentName;
        //            TDStatus.ID = "tdStatus" + r;

        //            cbo = new DropDownList();
        //            cbo.ID = "Status" + r;
        //            cbo.CssClass = "form-control";

        //            //TDRemind.ID = "tdRemind" + r;

        //            //if (myClass[r].Remind == "0")
        //            //{
        //            //    img = new System.Web.UI.WebControls.Image();
        //            //    img.ImageUrl = "~/Images/Icons/star.gif";
        //            //    //img.Height = 35;
        //            //    //img.Width = 35;
        //            //    img.ToolTip = "Student Expected to Graduate";
        //            //    TDRemind.Controls.Add(img);
        //            //}

        //            //removed in 7/11/2012 upon  an official email from Dean Dr.emad
        //            //Would u please remove the $ from the attendance sheet 
        //            //on the on-line system and let me know when it is done.Emad
        //            //retunned as contact administration at 4th floor 10-3-2013

        //            TDFinance.ID = "tdFinance" + r;


        //            //chk = new CheckBox();

        //            //chk.Checked = myClass[r].BFainance;
        //            //chk.ToolTip = "Please contact administration";
        //            //chk.Enabled = false;
        //            //TDFinance.Controls.Add(chk);


        //            //removed in 7/11/2012 by Bahaa Addin Ghaleb upon an official email from Dean Dr.emad
        //            //Would u please remove the $ from the attendance sheet 
        //            //on the on-line system and let me know when it is done.Emad
        //            //retunned as contact administration at 4th floor 10-3-2013

        //            isMilitary = false;
        //            isMilitary = LibraryMOD.isMilitaryService(myClass[r].StudentNumber);
        //            isACCWanted = false;
        //            isACCWanted = LibraryMOD.isACCWanted(myClass[r].StudentNumber, CurrentCampus);

        //            if (myClass[r].BFainance && !isMilitary && !isACCWanted)
        //            {
        //                img = new System.Web.UI.WebControls.Image();
        //                img.ImageUrl = "~/Images/Icons/Info.jpg";
        //                img.Height = 35;
        //                img.Width = 35;
        //                img.ToolTip = "Please contact the administration";
        //                TDFinance.Controls.Add(img);
        //            }

        //            if (isMilitary && !isACCWanted)
        //            {
        //                img = new System.Web.UI.WebControls.Image();
        //                img.ImageUrl = "~/Images/Icons/Flag.gif";
        //                img.Height = 35;
        //                img.Width = 35;
        //                img.ToolTip = "Student in military service";
        //                TDFinance.Controls.Add(img);
        //            }

        //            if (isACCWanted)
        //            {
        //                img = new System.Web.UI.WebControls.Image();
        //                img.ImageUrl = "~/Images/Icons/Question.png";
        //                img.Height = 35;
        //                img.Width = 35;
        //                img.ToolTip = "Strictly contact the administration";
        //                TDFinance.Controls.Add(img);
        //            }


        //            List<AttStatusesCLS> myStatuses = new List<AttStatusesCLS>();
        //            myStatuses = myStatusDAL.GetAttStatuses(CurrentCampus, " byteAttStatus<>3 and byteAttStatus<>8 and byteAttStatus<>6 and byteAttStatus<>6");

        //            cbo.Items.Add(new ListItem("Select Status", "0"));
        //            for (int i = 0; i < myStatuses.Count; i++)
        //            {

        //                cbo.Items.Add(new ListItem(myStatuses[i].AttDescEn, myStatuses[i].AttStatus.ToString()));
        //                if (myStatuses[i].AttStatus == myClass[r].Status)
        //                {
        //                    cbo.Items[i + 1].Selected = true;
        //                }

        //            }

        //            TDStatus.Controls.Add(cbo);

        //            TR.Cells.Add(TDSerial);
        //            TR.Cells.Add(TDNo);
        //            TR.Cells.Add(TDName);
        //            TR.Cells.Add(TDStatus);
        //            //TR.Cells.Add(TDRemind);

        //            //removed by bahaa addin in 7/11/2012
        //            TR.Cells.Add(TDFinance);


        //            if (r % 2 > 0)
        //            {
        //                TR.Attributes.Add("Class", "R_NormalWhite");
        //                //sTable += "<tr Class='R_NormalWhite'>";
        //            }
        //            else
        //            {
        //                TR.Attributes.Add("Class", "R_NormalGray");
        //                //sTable += "<tr Class='R_NormalGray'>";
        //            }

        //            MyTable.Rows.Add(TR);


        //        }

        //    }

        //    catch (Exception exp)
        //    {
        //        Console.WriteLine("{0} Exception caught.", exp);
        //        divMsg.InnerText = exp.Message;
        //    }
        //    finally
        //    {
        //        Session["AttendanceTable"] = MyTable;
        //        Session["AttCount"] = r;


        //    }
        //    return r;


        //}
        private int Show_Data(List<AttendanceCLS> myClass)
        {
            int r = 0;
            AttStatusDAL myStatusDAL = new AttStatusDAL();
            bool isMilitary = false;
            bool isACCWanted = false;
            try
            {
                TableHeaderRow H = new TableHeaderRow();
                TableHeaderCell HCHeader = new TableHeaderCell();
                Literal Lt = new Literal();
                Lt.Text = CreateCaption();
                HCHeader.ColumnSpan = 6; //course added
                HCHeader.Controls.Add(Lt);
                H.Cells.Add(HCHeader);
                MyTable.Rows.Add(H);

                //string sStyle = "background-color: #FFFFFF color: #0033CC";
                TableHeaderRow Hr = new TableHeaderRow();
                //Hr.Attributes.Add("style", sStyle);

                TableHeaderCell HCSerial = new TableHeaderCell();
                HCSerial.Text = "#";
                Hr.Cells.Add(HCSerial);

                TableHeaderCell HCNo = new TableHeaderCell();
                HCNo.Text = "No";
                Hr.Cells.Add(HCNo);

                TableHeaderCell HCName = new TableHeaderCell();
                HCName.Text = "Name";
                Hr.Cells.Add(HCName);
                //=====================
                TableHeaderCell HCCourse = new TableHeaderCell();
                HCCourse.Text = "Course";
                Hr.Cells.Add(HCCourse);
                //====================
                TableHeaderCell HCStatus = new TableHeaderCell();
                HCStatus.Text = "Status";
                Hr.Cells.Add(HCStatus);

                //TableHeaderCell HCRemind = new TableHeaderCell();
                //HCRemind.Text = "*";
                //Hr.Cells.Add(HCRemind);

                //removed by bahaa addin in 7/11/2012
                //retunned as contact the administration in 4th floor 10-3-2013
                TableHeaderCell HCFinance = new TableHeaderCell();
                HCFinance.Text = "?";
                Hr.Cells.Add(HCFinance);

                MyTable.BorderStyle = BorderStyle.Solid;
                MyTable.BorderWidth = 1;
                MyTable.GridLines = GridLines.Both;

                MyTable.Rows.Add(Hr);

                TableRow TR = new TableRow();

                TableCell TDSerial = new TableCell();
                TableCell TDNo = new TableCell();
                TableCell TDName = new TableCell();
                TableCell TDCourse = new TableCell();
                TableCell TDStatus = new TableCell();
                TableCell TDFinance = new TableCell();
                TableCell TDRemind = new TableCell();

                DropDownList cbo = new DropDownList();
                CheckBox chk = new CheckBox();
                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();

                for (r = 0; r < myClass.Count; r++)
                {

                    TR = new TableRow();
                    TR.ID = "tr" + r;

                    TDSerial = new TableCell();
                    TDNo = new TableCell();
                    TDName = new TableCell();
                    TDStatus = new TableCell();
                    TDCourse = new TableCell();

                    TDFinance = new TableCell();
                    //TDRemind = new TableCell();

                    TDSerial.ID = "tdSerial" + r;
                    TDSerial.Text = (r + 1).ToString();
                    TDNo.ID = "tdNo" + r;
                    TDNo.Text = myClass[r].StudentNumber;
                    TDName.ID = "tdName" + r;
                    TDName.Text = myClass[r].StudentName;

                    TDCourse.ID = "tdCourse" + r;
                    TDCourse.Text = myClass[r].Course;

                    TDStatus.ID = "tdStatus" + r;

                    cbo = new DropDownList();
                    cbo.ID = "Status" + r;

                    //TDRemind.ID = "tdRemind" + r;

                    //if (myClass[r].Remind == "0")
                    //{
                    //    img = new System.Web.UI.WebControls.Image();
                    //    img.ImageUrl = "~/Images/Icons/star.gif";
                    //    //img.Height = 35;
                    //    //img.Width = 35;
                    //    img.ToolTip = "Student Expected to Graduate";
                    //    TDRemind.Controls.Add(img);
                    //}

                    //removed in 7/11/2012 upon  an official email from Dean Dr.emad
                    //Would u please remove the $ from the attendance sheet 
                    //on the on-line system and let me know when it is done.Emad
                    //retunned as contact administration at 4th floor 10-3-2013

                    TDFinance.ID = "tdFinance" + r;


                    //chk = new CheckBox();

                    //chk.Checked = myClass[r].BFainance;
                    //chk.ToolTip = "Please contact administration";
                    //chk.Enabled = false;
                    //TDFinance.Controls.Add(chk);


                    //removed in 7/11/2012 by Bahaa Addin Ghaleb upon an official email from Dean Dr.emad
                    //Would u please remove the $ from the attendance sheet 
                    //on the on-line system and let me know when it is done.Emad
                    //retunned as contact administration at 4th floor 10-3-2013

                    isMilitary = false;
                    isMilitary = LibraryMOD.isMilitaryService(myClass[r].StudentNumber);
                    isACCWanted = false;
                    isACCWanted = LibraryMOD.isACCWanted(myClass[r].StudentNumber, CurrentCampus);

                    if (myClass[r].BFainance && !isMilitary && !isACCWanted)
                    {
                        img = new System.Web.UI.WebControls.Image();
                        img.ImageUrl = "~/Images/Icons/Info.jpg";
                        img.Height = 35;
                        img.Width = 35;
                        img.ToolTip = "Please contact the administration";
                        TDFinance.Controls.Add(img);
                    }

                    if (isMilitary && !isACCWanted)
                    {
                        img = new System.Web.UI.WebControls.Image();
                        img.ImageUrl = "~/Images/Icons/Flag.gif";
                        img.Height = 35;
                        img.Width = 35;
                        img.ToolTip = "Student in military service";
                        TDFinance.Controls.Add(img);
                    }

                    if (isACCWanted)
                    {
                        img = new System.Web.UI.WebControls.Image();
                        img.ImageUrl = "~/Images/Icons/Question.png";
                        img.Height = 35;
                        img.Width = 35;
                        img.ToolTip = "Strictly contact the administration";
                        TDFinance.Controls.Add(img);
                    }


                    List<AttStatusesCLS> myStatuses = new List<AttStatusesCLS>();
                    myStatuses = myStatusDAL.GetAttStatuses(CurrentCampus, " byteAttStatus<>3 and byteAttStatus<>8 and byteAttStatus<>6 and byteAttStatus<>6");

                    cbo.Items.Add(new ListItem("Select Status", "0"));
                    for (int i = 0; i < myStatuses.Count; i++)
                    {

                        cbo.Items.Add(new ListItem(myStatuses[i].AttDescEn, myStatuses[i].AttStatus.ToString()));
                        if (myStatuses[i].AttStatus == myClass[r].Status)
                        {
                            cbo.Items[i + 1].Selected = true;
                        }

                    }

                    TDStatus.Controls.Add(cbo);

                    TR.Cells.Add(TDSerial);
                    TR.Cells.Add(TDNo);
                    TR.Cells.Add(TDName);
                    TR.Cells.Add(TDCourse);
                    TR.Cells.Add(TDStatus);

                    //TR.Cells.Add(TDRemind);

                    //removed by bahaa addin in 7/11/2012
                    TR.Cells.Add(TDFinance);


                    if (r % 2 > 0)
                    {
                        TR.Attributes.Add("Class", "R_NormalWhite");
                        //sTable += "<tr Class='R_NormalWhite'>";
                    }
                    else
                    {
                        TR.Attributes.Add("Class", "R_NormalGray");
                        //sTable += "<tr Class='R_NormalGray'>";
                    }

                    MyTable.Rows.Add(TR);


                }

            }

            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                divMsg.InnerText = exp.Message;
            }
            finally
            {
                Session["AttendanceTable"] = MyTable;
                Session["AttCount"] = r;


            }
            return r;


        }

        private List<AttStatusesCLS> FillStatuses()
        {
            List<AttStatusesCLS> myAttStatuses = new List<AttStatusesCLS>();
            AttStatusDAL myAttStatusDAL = new AttStatusDAL();
            try
            {
                myAttStatuses = myAttStatusDAL.GetAttStatuses(CurrentCampus, "");

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {


            }
            return myAttStatuses;
        }
        protected void BackCMD_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ClassAttendance.aspx");
        }
        protected void SaveCMD_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Attendance,
                InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
            {
                divMsg.InnerText = InitializeModule.MsgEditAuthorization;
                return;
            }
            SaveData();

        }

        private void EnableDisable(bool isEnabled)
        {
            if (isEnabled)
            {
                divDetail.Controls.Add(MyTable);
                SaveCMD.ImageUrl = LibraryMOD.GetButtonImageURL(InitializeModule.ECT_Buttons.Save, true);
                SaveCMD.Enabled = true;
                divMsg.InnerText = "";
            }
            else
            {
                divMsg.InnerText = "No Students or No Class Today";
                divDetail.Controls.Clear();
                SaveCMD.Enabled = false;
                SaveCMD.ImageUrl = LibraryMOD.GetButtonImageURL(InitializeModule.ECT_Buttons.Save, false);
            }
        }

        //private void SaveData()
        //{
        //    int r = 0;
        //    AttendanceDAL myAttendance = new AttendanceDAL();
        //    List<AttendanceCLS> myClass = new List<AttendanceCLS>();
        //    Connection_StringCLS sConn = new Connection_StringCLS(CurrentCampus);
        //    SqlConnection Conn = new SqlConnection(sConn.Conn_string);
        //    string sUserName = Session["CurrentUserName"].ToString();
        //    string sNetUser = Session["CurrentNetUserName"].ToString();
        //    string sPCName = Session["CurrentPCName"].ToString();

        //    try
        //    {

        //        string sCondition = " CB.iYear=" + iStudyYear;
        //        sCondition += " And CB.Sem=" + bSemester;
        //        sCondition += " And CB.Shift=" + bShift;
        //        sCondition += " And CB.Course='" + sCourse + "'";
        //        sCondition += " And CB.Class=" + bAttClass;

        //        Conn.Open();

        //        myClass = myAttendance.GetAttendance(CurrentCampus, sCondition, sDate);

        //        byte bValue = 0;

        //        int iEffected = 0;
        //        for (int i = 0; i < myClass.Count; i++)
        //        {
        //            TableRow tr = new TableRow();
        //            tr = (TableRow)MyTable.FindControl("tr" + i);
        //            TableCell tdStatus = new TableCell();
        //            tdStatus = (TableCell)tr.FindControl("tdStatus" + i);
        //            DropDownList cbo = new DropDownList();
        //            cbo = (DropDownList)tdStatus.FindControl("Status" + i);
        //            bValue = 0;
        //            bValue = byte.Parse(cbo.SelectedValue);

        //            //if (bValue != myClass[i].Status)
        //            //{
        //            iEffected = myAttendance.UpdateAttendance(iStudyYear, bSemester, bShift, sCourse, bAttClass, myClass[i].StudentNumber, myClass[i].StudentName, sDate, myClass[i].Hours, bValue, myClass[i].DataStatus, CurrentCampus, sUserName, sNetUser, sPCName);
        //            r += iEffected;
        //            //}


        //        }

        //        Retrieve();
        //        //divMsg.InnerText = "( " + r + " )Records Saved Successfully …";
        //        lbl_Msg.Text = "( " + r + " )Records Saved Successfully …";
        //        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
        //        div_msg.Visible = true;
        //        lblSaveNotification.Visible = false;
        //    }
        //    catch (Exception exp)
        //    {
        //        Console.WriteLine("{0} Exception caught.", exp);
        //        //divMsg.InnerText = "Error: " + exp.Message;
        //        lbl_Msg.Text = "Error: " + exp.Message;
        //        div_msg.Visible = true;
        //    }
        //    finally
        //    {
        //        myClass.Clear();
        //        Conn.Close();
        //        Conn.Dispose();
        //    }
        //}

        //private void ChangeStatus(string NewStatus)
        //{

        //    AttendanceDAL myAttendance = new AttendanceDAL();
        //    List<AttendanceCLS> myClass = new List<AttendanceCLS>();
        //    Connection_StringCLS sConn = new Connection_StringCLS(CurrentCampus);
        //    SqlConnection Conn = new SqlConnection(sConn.Conn_string);


        //    try
        //    {

        //        string sCondition = " CB.iYear=" + iStudyYear;
        //        sCondition += " And CB.Sem=" + bSemester;
        //        sCondition += " And CB.Shift=" + bShift;
        //        sCondition += " And CB.Course='" + sCourse + "'";
        //        sCondition += " And CB.Class=" + bAttClass;

        //        Conn.Open();

        //        myClass = myAttendance.GetAttendance(CurrentCampus, sCondition, sDate);



        //        for (int i = 0; i < myClass.Count; i++)
        //        {
        //            TableRow tr = new TableRow();
        //            tr = (TableRow)MyTable.FindControl("tr" + i);
        //            TableCell tdStatus = new TableCell();
        //            tdStatus = (TableCell)tr.FindControl("tdStatus" + i);
        //            DropDownList cbo = new DropDownList();
        //            cbo = (DropDownList)tdStatus.FindControl("Status" + i);

        //            cbo.SelectedValue = NewStatus.ToString();
        //        }

        //        //Retrieve();
        //        //divMsg.InnerText = "( " + r + " )Records Saved Successfully …";
        //        //lblSaveNotification.Visible = false;
        //    }
        //    catch (Exception exp)
        //    {
        //        Console.WriteLine("{0} Exception caught.", exp);
        //        //divMsg.InnerText = "Error: " + exp.Message;

        //        lbl_Msg.Text = "Error: " + exp.Message;
        //        div_msg.Visible = true;
        //    }
        //    finally
        //    {
        //        myClass.Clear();
        //        Conn.Close();
        //        Conn.Dispose();
        //    }
        //}

        //protected void btnChangeStatus_Click(object sender, EventArgs e)
        //{
        //    if (ddlChangeAllStatuses.SelectedValue != "-1")
        //    {
        //        ChangeStatus(ddlChangeAllStatuses.SelectedValue);
        //    }
        //}

        private void SaveData()
        {
            int r = 0;
            AttendanceDAL myAttendance = new AttendanceDAL();
            List<AttendanceCLS> myClass = new List<AttendanceCLS>();
            Connection_StringCLS sConn = new Connection_StringCLS(CurrentCampus);
            SqlConnection Conn = new SqlConnection(sConn.Conn_string);
            string sUserName = Session["CurrentUserName"].ToString();
            string sNetUser = Session["CurrentNetUserName"].ToString();
            string sPCName = Session["CurrentPCName"].ToString();

            try
            {
                CoursesDAL theCourse = new CoursesDAL();
                sUnifiedCode = theCourse.GetUnifiedCourseCode_FromAvailableCourses(CurrentCampus, sCourse, iStudyYear, bSemester);

                string sCondition = " CB.iYear=" + iStudyYear;
                sCondition += " And CB.Sem=" + bSemester;
                sCondition += " And CB.Shift=" + bShift;
                //sCondition += " And CB.Course='" + sCourse + "'";
                //sCondition += " And CB.sUnified='" + sUnifiedCode + "'";
                sCondition += " And CB.sTMCode='" + sUnifiedCode + "'";
                sCondition += " And CB.Class=" + bAttClass;

                Conn.Open();

                myClass = myAttendance.GetAttendance(CurrentCampus, sCondition, sDate);

                byte bValue = 0;
                string sCourseCode = "";

                int iEffected = 0;
                for (int i = 0; i < myClass.Count; i++)
                {
                    TableRow tr = new TableRow();
                    tr = (TableRow)MyTable.FindControl("tr" + i);
                    TableCell tdStatus = new TableCell();
                    tdStatus = (TableCell)tr.FindControl("tdStatus" + i);

                    DropDownList cbo = new DropDownList();
                    cbo = (DropDownList)tdStatus.FindControl("Status" + i);
                    bValue = 0;
                    bValue = byte.Parse(cbo.SelectedValue);


                    TableCell tdCourse = new TableCell();
                    tdCourse = (TableCell)tr.FindControl("tdCourse" + i);
                    //TextBox txt = new TextBox();
                    //txt = (TextBox)tdCourse.FindControl("Course" + i);

                    sCourseCode = tdCourse.Text;

                    //if (bValue != myClass[i].Status)
                    //{
                    // iEffected= myAttendance.UpdateAttendance(iStudyYear, bSemester, bShift, sCourse, bAttClass, myClass[i].StudentNumber, myClass[i].StudentName, sDate, myClass[i].Hours, bValue, myClass[i].DataStatus, CurrentCampus, sUserName,sNetUser,sPCName);
                    iEffected = myAttendance.UpdateAttendance(iStudyYear, bSemester, bShift, sCourseCode, bAttClass, myClass[i].StudentNumber, myClass[i].StudentName, sDate, myClass[i].Hours, bValue, myClass[i].DataStatus, CurrentCampus, sUserName, sNetUser, sPCName);
                    r += iEffected;
                    //}


                }

                Retrieve();
                divMsg.InnerText = "( " + r + " )Records Saved Successfully …";
                lblSaveNotification.Visible = false;
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                divMsg.InnerText = "Error: " + exp.Message;
            }
            finally
            {
                myClass.Clear();
                Conn.Close();
                Conn.Dispose();
            }
        }

        private void ChangeStatus(string NewStatus)
        {

            AttendanceDAL myAttendance = new AttendanceDAL();
            List<AttendanceCLS> myClass = new List<AttendanceCLS>();
            Connection_StringCLS sConn = new Connection_StringCLS(CurrentCampus);
            SqlConnection Conn = new SqlConnection(sConn.Conn_string);


            try
            {

                string sCondition = " CB.iYear=" + iStudyYear;
                sCondition += " And CB.Sem=" + bSemester;
                sCondition += " And CB.Shift=" + bShift;
                //sCondition += " And CB.Course='" + sCourse + "'";
                sCondition += " And CB.sUnified='" + sUnifiedCode + "'";

                sCondition += " And CB.Class=" + bAttClass;

                Conn.Open();

                myClass = myAttendance.GetAttendance(CurrentCampus, sCondition, sDate);



                for (int i = 0; i < myClass.Count; i++)
                {
                    TableRow tr = new TableRow();
                    tr = (TableRow)MyTable.FindControl("tr" + i);
                    TableCell tdStatus = new TableCell();
                    tdStatus = (TableCell)tr.FindControl("tdStatus" + i);
                    DropDownList cbo = new DropDownList();
                    cbo = (DropDownList)tdStatus.FindControl("Status" + i);

                    cbo.SelectedValue = NewStatus.ToString();
                }

                //Retrieve();
                //divMsg.InnerText = "( " + r + " )Records Saved Successfully …";
                //lblSaveNotification.Visible = false;
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                divMsg.InnerText = "Error: " + exp.Message;
            }
            finally
            {
                myClass.Clear();
                Conn.Close();
                Conn.Dispose();
            }
        }

        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (ddlChangeAllStatuses.SelectedValue != "-1")
            {
                ChangeStatus(ddlChangeAllStatuses.SelectedValue);
            }
        }
    }
}