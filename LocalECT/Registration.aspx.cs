using CrystalDecisions.CrystalReports.Engine;
using Microsoft.SharePoint.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class Registration : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        int CurrentRole = 0;
        List<MirrorCLS> myList = new List<MirrorCLS>();
        Plans myPlan = new Plans();
        int iRegYear = 0;
        int iRegSem = 0;
        int iTerm = 0;
        byte bShift = 0;
        string sCourse = "";
        byte bClass = 0;
        string sNo = "";
        string sName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                iRegYear = (int)Session["RegYear"];
                iRegSem = (int)Session["RegSemester"];
                CurrentRole = (int)Session["CurrentRole"];

                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                   InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }
                }
                if (!IsPostBack)
                {
                    if (Session["CurrentCampus"] != null)
                    {
                        string sCampus = Session["CurrentCampus"].ToString();
                        Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    }
                    Session["myList"] = null;
                    Session["myPlan"] = null;
                    //if (Session["CurrentStudent"] != null)
                    //{
                    //    sSelectedValue.Value = Session["CurrentStudent"].ToString();
                    //    sSelectedText.Value = Session["CurrentStudentName"].ToString();
                    //    sNo = sSelectedValue.Value;
                    //    sName = sSelectedText.Value;
                    //    if (LibraryMOD.IsFileVerifiedFromRegistrar(sNo, Campus) == InitializeModule.FALSE_VALUE)
                    //    {
                    //        Server.Transfer("Authorization.aspx");
                    //        return;
                    //    }
                    //}
                    if (Request.QueryString["sid"] != null && Request.QueryString["sid"] != "")
                    {
                        string sid = Request.QueryString["sid"];
                        getregconditions(sid);
                        sSelectedValue.Value = sid;
                        sSelectedText.Value = getstudentname(sid);
                        sNo = sSelectedValue.Value;
                        sName = sSelectedText.Value;
                        if (LibraryMOD.IsFileVerifiedFromRegistrar(sNo, Campus) == InitializeModule.FALSE_VALUE)
                        {
                            Server.Transfer("Authorization.aspx");
                            return;
                        }
                        bool isEnable = Enable_Disable(sNo, sName);
                        if (!isEnable)
                        {                           
                            return;
                        }
                        divPlan.Controls.Clear();
                        divRec.Controls.Clear();
                        MultiTabs.ActiveViewIndex = -1;
                        MultiAdd.ActiveViewIndex = -1;
                        if (isStudentHasAccount(sNo) == true)
                        {

                            Get_Student_Advising();
                            Session["iFormNumber"] = this.CreateHeader();
                            Menu1.Enabled = true;
                            System.Web.UI.WebControls.Table myTable;
                            List<MirrorCLS> myList = (List<MirrorCLS>)Session["myList"];
                            myTable = Create_Table(myList[0]);
                            divPlan.Controls.Clear();
                            divPlan.Controls.Add(myTable);
                            MultiTabs.ActiveViewIndex = 0;
                        }
                        else
                        {                            
                            lbl_Msg.Text = "The Student Hasn't Account yet !";
                            div_msg.Visible = true;
                            Menu1.Enabled = false;
                        }
                        string sConn1 = "";
                        Connection_StringCLS ConnectionString1;
                        switch (Campus)
                        {
                            case InitializeModule.EnumCampus.Males:
                                ConnectionString1 = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
                                sConn1 = ConnectionString1.Conn_string;
                                break;
                            case InitializeModule.EnumCampus.Females:
                                ConnectionString1 = new Connection_StringCLS(InitializeModule.EnumCampus.Females);
                                sConn1 = ConnectionString1.Conn_string;
                                break;
                        }

                        TMDS.ConnectionString = sConn1;
                        TMDS.SelectCommand = GetSQL(sSelectedValue.Value, iRegYear, iRegSem);
                        TMDS.DataBind();
                        grdTimeTable.DataBind();
                        btnCopy.Visible = (Campus.ToString() == "Females");
                    }
                    FillTerms();
                    fill_Alt();
                    iTerm = iRegYear * 10 + iRegSem;
                    Terms.SelectedValue = iTerm.ToString();
                }
                else
                {
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    if (Session["myList"] != null)
                    {
                        myList = (List<MirrorCLS>)Session["myList"];
                        myPlan = (Plans)Session["myPlan"];

                    }
                    sNo = sSelectedValue.Value;
                    sName = sSelectedText.Value;
                }
                string sConn = "";
                Connection_StringCLS ConnectionString;
                switch (Campus)
                {
                    case InitializeModule.EnumCampus.Males:
                        ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
                        sConn = ConnectionString.Conn_string;
                        break;
                    case InitializeModule.EnumCampus.Females:
                        ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Females);
                        sConn = ConnectionString.Conn_string;
                        break;
                }
                CTMDS.ConnectionString = sConn;
                TMDS.ConnectionString = sConn;
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        public void getregconditions(string studentid)
        {
            studentid = Request.QueryString["sid"];
            string sSID = studentid;
            int iSerial = GetSerial(sSID);
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd=new SqlCommand("select iAcceptanceCondition,iAcceptanceType from Reg_Applications where lngSerial=@lngSerial", Conn);
            cmd.Parameters.AddWithValue("@lngSerial", iSerial);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                Conn.Open();
                da.Fill(dt);
                Conn.Close();

                if(dt.Rows.Count>0)
                {
                    string acceptance_type = "";
                    string acceptance_condition = "";

                    if (dt.Rows[0]["iAcceptanceType"].ToString() == "1")
                    {
                        acceptance_type = "Permanently Accepted";
                    }
                    else if (dt.Rows[0]["iAcceptanceType"].ToString() == "2")
                    {
                        acceptance_type = "One Academic Semester(Conditional)";
                    }
                    else if (dt.Rows[0]["iAcceptanceType"].ToString() == "3")
                    {
                        acceptance_type = "Two Academic Semesters(Conditional)";
                    }
                    else if (dt.Rows[0]["iAcceptanceType"].ToString() == "4")
                    {
                        acceptance_type = "One Academic Year(Conditional)";
                    }

                    if (dt.Rows[0]["iAcceptanceCondition"].ToString()=="1")
                    {
                        acceptance_condition = "All conditions have been met";
                    }
                    else if (dt.Rows[0]["iAcceptanceCondition"].ToString() == "2")
                    {
                        acceptance_condition = "High school equivalency needed";
                    }
                    else if (dt.Rows[0]["iAcceptanceCondition"].ToString() == "3")
                    {
                        acceptance_condition = "EmSAT needed";
                    }
                    else if (dt.Rows[0]["iAcceptanceCondition"].ToString() == "4")
                    {
                        acceptance_condition = "Major requirements are not met";
                    }
                    lbl_AT.Text = acceptance_type;
                    lbl_AC.Text = acceptance_condition;
                }
            }
            catch(Exception ex)
            {
                Conn.Close();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }
        private void FillTerms()
        {
            List<Semesters> myTerms = new List<Semesters>();
            SemesterDAL myTermsDAL = new SemesterDAL();
            try
            {
                myTerms = myTermsDAL.GetTerms(InitializeModule.EnumCampus.ECTNew, "", true);
                for (int i = 0; i < 3; i++)//for (int i = 0; i < myTerms.Count; i++)
                {
                    Terms.Items.Add(new System.Web.UI.WebControls.ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));

                }

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
                if(dt.Rows.Count>0)
                {
                    sName = dt.Rows[0]["sName"].ToString();
                }
            }
            catch(Exception ex)
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
        private void Get_Student_Advising()
        {
            List<MirrorCLS> myMirror = new List<MirrorCLS>();
            Advising myAdvising = new Advising();
            Plans Plan = new Plans();
            try
            {
                Session["myList"] = null;
                Session["myPlan"] = null;

                int iYear = iRegYear;
                int iSem = iRegSem;
                //Is Grades Hidden
                bool isHidden = LibraryMOD.isGradesHidden(Campus);
                myMirror = myAdvising.GetAdvising(sNo, true, iYear, iSem, true, isHidden, out Plan, Campus, Session["sCSemester"].ToString());
                int i = myMirror.Count;
                int iRec = myMirror[0].Recommended.Count;

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
            finally
            {                
                Session["myList"] = myMirror;
                Session["myPlan"] = Plan;

            }
        }

        private System.Web.UI.WebControls.Table Create_Table(MirrorCLS myMirror)
        {
            System.Web.UI.WebControls.Table MyTable = new System.Web.UI.WebControls.Table();
            try
            {
                //First Row
                MyTable.Width = Unit.Percentage(100);
                MyTable.BorderWidth = 1;
                MyTable.GridLines = GridLines.Horizontal;
                MyTable.ID = "tblDetail";

                TableHeaderRow Hr = new TableHeaderRow();
                TableHeaderCell Hc = new TableHeaderCell();
                TableCell Hd = new TableCell();
                Hc.ColumnSpan = 4;
                Hc.Text = "Student Information";
                Hr.Cells.Add(Hc);
                MyTable.Rows.Add(Hr);

                //No
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "No : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.Text = sNo;
                Hr.Cells.Add(Hd);
                //Name
                Hc = new TableHeaderCell();
                Hc.Text = "Name : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.Text = sName;
                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);


                //Second Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "Major : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.ColumnSpan = 3;
                Hd.Text = myMirror.Major;
                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);
                //----------------------------------------
                //Hc = new TableHeaderCell();
                //Hc.Text = "Registered Courses : ";
                //Hr.Cells.Add(Hc);

                //Hd = new TableCell();
                ////Hd.ColumnSpan = 3;
                //Hd.Text = Convert.ToString(LibraryMOD.GetRegCoursesPrevSem(sNo, iRegYear, iRegSem, (InitializeModule.EnumCampus)Campus));

                //Hr.Cells.Add(Hd);

                //MyTable.Rows.Add(Hr);
                //-------------------------------------------
                //Third Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "CGPA : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                if (myMirror.CGPA != 101)
                {
                    Hd.Text = string.Format("{0:F}", myMirror.CGPA);
                }

                Hr.Cells.Add(Hd);

                Hc = new TableHeaderCell();
                Hc.Text = "ESL : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                //Get Max Esl
                for (int i = 0; i < 5; i++)
                {
                    if (myMirror.Mirror[i].isPassed)
                    {
                        Hd.Text = myMirror.Mirror[i].sCourse;
                        myMirror.MaxESL = i;

                    }

                }
                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);

                //Fourth Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "ENG : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();
                Hd.Text = myMirror.ENG;
                Hr.Cells.Add(Hd);

                Hc = new TableHeaderCell();
                Hc.Text = "Score : ";
                Hr.Cells.Add(Hc);

                Hd = new TableCell();

                Hd.Text = string.Format("{0:F}", myMirror.Score); ;

                Hr.Cells.Add(Hd);

                MyTable.Rows.Add(Hr);




            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);

            }
            finally
            {


            }
            return MyTable;
        }

        private System.Web.UI.WebControls.Table Create_Rec_Table(MirrorCLS myMirror)
        {
            System.Web.UI.WebControls.Table MyTable = new System.Web.UI.WebControls.Table();
            try
            {
                //myList.Add(myMirror);
                //First Row
                MyTable.Width = Unit.Percentage(100);
                MyTable.BorderWidth = 1;
                MyTable.GridLines = GridLines.Horizontal;
                MyTable.ID = "tbl_advising";

                TableHeaderRow Hr = new TableHeaderRow();
                TableHeaderCell Hc = new TableHeaderCell();

                //Fifth
                Hr = new TableHeaderRow();
                Hc = new TableHeaderCell();
                Hc.ColumnSpan = 4;
                Hc.Text = "Student Mirror";
                Hr.Cells.Add(Hc);
                MyTable.Rows.Add(Hr);

                Hr = new TableHeaderRow();
                Hc = new TableHeaderCell();
                Hc.ColumnSpan = 4;
                Hc.Text = "General Courses";
                Hr.Cells.Add(Hc);
                MyTable.Rows.Add(Hr);

                TableRow Tr = new TableRow();
                TableCell Tc = new TableCell();
                Tc.ColumnSpan = 4;


                string sPath = "";
                string sTable = "<table align='left' border='1' >";
                sTable += "<tr>";

                int iMax = 0;
                string sDegree = myMirror.SDegree;
                string sMajor = myMirror.SMajor;
                //Get the count of general courses
                iMax = LibraryMOD.GetMajorGeneralIndex(sDegree, sMajor);

                for (int i = 0; i < iMax; i++)
                {
                    sPath = "Images/Majors/GIF/" + myMirror.Mirror[i].sCourse + ".gif";
                    sTable += "<td><img alt='' src='" + sPath + "' /></td>";
                }
                sTable += "</tr>";
                sTable += "<tr>";
                for (int i = 0; i < iMax; i++)
                {

                    //if (myMirror.Mirror[i].isRecommended)
                    //{
                    //    sTable += "<td bgcolor='#CC3300'>" + myMirror.Mirror[i].sGrade + "</td>";
                    //}
                    //else
                    //{
                    //    sTable += "<td>" + myMirror.Mirror[i].sGrade + "</td>";
                    //}

                    if (myMirror.Mirror[i].isRecommended)
                    {
                        sTable += "<td style='font-family: Arial, Helvetica, sans-serif; font-size: small; color: #000000; text-align: center; vertical-align: top; background-color: #F2B702'>" + myMirror.Mirror[i].sGrade + "</td>";
                    }
                    else
                    {
                        sTable += "<td style='font-family: Arial, Helvetica, sans-serif; font-size: small; color: #000000; text-align: center; vertical-align: top'>" + myMirror.Mirror[i].sGrade + "</td>";
                    }
                }
                sTable += "</tr>";
                sTable += "</table>";

                Literal Lt = new Literal();
                Lt.Text = sTable;
                Tc.Controls.Add(Lt);
                Tr.Cells.Add(Tc);

                MyTable.Rows.Add(Tr);


                //Sixth
                Hr = new TableHeaderRow();
                Hc = new TableHeaderCell();
                Hc.ColumnSpan = 4;
                Hc.Text = "Other Courses";
                Hr.Cells.Add(Hc);
                MyTable.Rows.Add(Hr);

                Tr = new TableRow();
                Tc = new TableCell();
                Tc.ColumnSpan = 4;

                int iCourses = 0;
                iCourses = myMirror.Mirror.Length;

                sPath = "";
                sTable = "<table align='left' border='1' >";
                sTable += "<tr>";
                for (int i = iMax; i < iCourses; i++)
                {
                    sPath = "Images/Majors/GIF/" + myMirror.Mirror[i].sCourse + ".gif";
                    sTable += "<td><img alt='' src='" + sPath + "' /></td>";
                }
                sTable += "</tr>";
                sTable += "<tr>";
                for (int i = iMax; i < iCourses; i++)
                {

                    //if (myMirror.Mirror[i].isRecommended)
                    //{
                    //    sTable += "<td bgcolor='#CC3300'>" + myMirror.Mirror[i].sGrade + "</td>";
                    //}
                    //else
                    //{
                    //    sTable += "<td>" + myMirror.Mirror[i].sGrade + "</td>";
                    //}
                    if (myMirror.Mirror[i].isRecommended)
                    {
                        sTable += "<td style='font-family: Arial, Helvetica, sans-serif; font-size: small; color: #000000; text-align: center; vertical-align: top; background-color: #F2B702'>" + myMirror.Mirror[i].sGrade + "</td>";
                    }
                    else
                    {
                        sTable += "<td style='font-family: Arial, Helvetica, sans-serif; font-size: small; color: #000000; text-align: center; vertical-align: top'>" + myMirror.Mirror[i].sGrade + "</td>";
                    }
                }
                sTable += "</tr>";
                sTable += "</table>";

                Lt = new Literal();
                Lt.Text = sTable;
                Tc.Controls.Add(Lt);
                Tr.Cells.Add(Tc);

                MyTable.Rows.Add(Tr);

                //Majoe Electives & Free Electives
                MirrorDAL myMirrorDAL = new MirrorDAL();


                string MElective = myMirrorDAL.GetMajorElectiveCourses(myMirror.StudentNumber, Campus);
                string FElective = myMirrorDAL.GetFreeElectiveCourses(myMirror.StudentNumber, Campus);
                if (MElective.Length > 0 || FElective.Length > 0)
                {
                    Hr = new TableHeaderRow();
                    Hc = new TableHeaderCell();
                    Hc.ColumnSpan = 4;
                }
                Hc.Text = "";
                if (MElective.Length > 0)
                {
                    Hc.Text += "Major Electives: " + "[ " + MElective + " ]";
                }

                if (FElective.Length > 0)
                {
                    if (MElective.Length > 0)
                    {
                        Hc.Text += " --- ";
                    }
                    Hc.Text += "Free Electives [" + FElective + " ]";
                }
                if (MElective.Length > 0 || FElective.Length > 0)
                {
                    Hr.Cells.Add(Hc);
                    MyTable.Rows.Add(Hr);
                }
                //Recommended
                Hr = new TableHeaderRow();
                Hc = new TableHeaderCell();
                Hc.ColumnSpan = 4;
                Hc.Text = "Recommended Courses";
                Hr.Cells.Add(Hc);
                MyTable.Rows.Add(Hr);

                int iRegCoursesPrevSem = 0;
                int iAllowedCourses = 0;
                iRegCoursesPrevSem = LibraryMOD.GetRegCoursesPrevSem(sNo, iRegYear, iRegSem, (InitializeModule.EnumCampus)Campus);
                if (iRegCoursesPrevSem < 4)
                {
                    iAllowedCourses = 4 - iRegCoursesPrevSem;
                }

                int iCompletedHours = LibraryMOD.GetCompletedHours(sNo, Campus);

                for (int i = 0; i < myMirror.Recommended.Count; i++)
                {
                    if ((iCompletedHours < 99 && myMirror.Recommended[i].sCourse.Contains("415") && myMirror.Recommended[i].sCourse != "RTV415") || (iCompletedHours < 99 && myMirror.Recommended[i].sCourse.Contains("419")))
                    {
                        //dont add Internship & graduation project in completed hours less than 99 credit hours
                    }
                    else
                    {
                        Tr = new TableRow();
                        if (myMirror.Recommended[i].isOver)
                        {
                            Tr.CssClass = "R_Critical";
                        }
                        else
                        {
                            if (i % 2 == 0)
                            {
                                Tr.CssClass = "R_NormalWhite";
                            }
                            else
                            {
                                Tr.CssClass = "R_NormalGray";
                            }
                        }
                        Tc = new TableCell();
                        Tc.Text = (i + 1).ToString();
                        Tc.HorizontalAlign = HorizontalAlign.Center;
                        Tr.Cells.Add(Tc);

                        Tc = new TableCell();
                        Tc.Text = myMirror.Recommended[i].sCourse;
                        Tc.HorizontalAlign = HorizontalAlign.Center;
                        Tr.Cells.Add(Tc);

                        Tc = new TableCell();
                        Tc.ColumnSpan = 2;
                        Tc.Text = myMirror.Recommended[i].sDesc;
                        Tc.HorizontalAlign = HorizontalAlign.Left;
                        Tr.Cells.Add(Tc);

                        MyTable.Rows.Add(Tr);
                    }
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);

            }
            finally
            {


            }
            return MyTable;
        }


        private void SetArgs(string sArgs)
        {

            try
            {
                string[] Args = sArgs.Split(';');

                bShift = byte.Parse(Args[0]);
                sCourse = Args[1];
                bClass = byte.Parse(Args[2]);
                ddlAlt.SelectedValue = sCourse;

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {


            }

        }

        private int CreateHeader()
        {
            int iFormNumber = 0;
            try
            {
                string sStudentNumber = "";

                if (Session["myList"] != null)
                {
                    List<MirrorCLS> myList = (List<MirrorCLS>)Session["myList"];
                    sStudentNumber = myList[0].StudentNumber;
                }
                else
                {                    
                    lbl_Msg.Text = "Mirror is empty.";
                    div_msg.Visible = true;
                    return -1;
                }



                Course_HeaderDAL myCourseHeader = new Course_HeaderDAL();
                iFormNumber = myCourseHeader.IsHeaderExists(this.Campus, iRegYear, iRegSem, 1, sStudentNumber);



                if (iFormNumber == -1)
                {
                    Connection_StringCLS MyConnection_string = new Connection_StringCLS(this.Campus);
                    SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
                    Conn.Open();
                    iFormNumber = LibraryMOD.GetMaxID(Conn, "intFormNumber", "Reg_Course_Header", "intStudyYear=" + iRegYear + " AND byteSemester=" + iRegSem + " AND byteForm=1");
                    iFormNumber++;
                    Conn.Close();

                    int iMode = (int)InitializeModule.enumModes.NewMode;

                    string sPCName = Session["CurrentPCName"].ToString();
                    string sUserName = Session["CurrentUserName"].ToString();
                    string sNetUserName = Session["CurrentNetUserName"].ToString();

                    int iSuccess = myCourseHeader.UpdateCourse_Header(this.Campus, iMode, iRegYear, iRegSem, 1, iFormNumber, sStudentNumber, DateTime.Now, 0, 0, 0, "", 0, "", DateTime.Now, "", "", DateTime.Now, sUserName, DateTime.Now, sPCName, sNetUserName);

                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);

            }
            finally
            {


            }
            return iFormNumber;

        }
        //Add Course
        protected void Addbtn_Command(object sender, CommandEventArgs e)
        {
            try
            {
                SetArgs(e.CommandArgument.ToString());//Get bShift,sCourse,bClass

                //set the campus as of course session 
                int iPeriod = 0;
                int iFormNumber = 0;
                InitializeModule.EnumCampus CourseCampus = LibraryMOD.SyncCampusAndSession(bShift.ToString(), out iPeriod);
                if (CourseCampus != Campus)
                {
                    Campus = CourseCampus;
                    if (isStudentHasAccount(sNo) == true)
                    {

                        Get_Student_Advising();
                        Session["iFormNumber"] = this.CreateHeader();
                        Menu1.Enabled = true;
                    }
                    else
                    {                        
                        lbl_Msg.Text = "The Student Hasn't Account yet !";
                        div_msg.Visible = true;
                        Menu1.Enabled = false;
                    }
                }

                iFormNumber = int.Parse(Session["iFormNumber"].ToString());
                if (iFormNumber == 0) return;

                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                        InitializeModule.enumPrivilege.AddCourse, this.CurrentRole) != true)
                {
                    UpdateConfirm("Sorry you are not allowed to add a course.", true);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "$(document).ready(function(){ $('#divConfirmation').text('Sorry you are not allowed to add a course.').slideToggle('slow'); });", true);
                    return;
                }

                if (LibraryMOD.IsFileVerifiedFromRegistrar(sNo, Campus) == InitializeModule.FALSE_VALUE)
                {
                    UpdateConfirm("Please contact the Registrar to verfiy student file.", true);
                    return;
                }


                //MirrorCLS MyMirror = myList[0];

                string sMsg = "";

                if (isValid(true, out sMsg))
                {
                    if (sMsg == "")//All Valid
                    {
                        int iAdded = AddCourse(iFormNumber);

                    }
                    else//Valid need confirmation
                    {
                        Session["CurrentSession"] = bShift;
                        Session["CurrentCourse"] = sCourse;
                        Session["CurrentClass"] = bClass;
                        Session["CurrentMsg"] = sMsg;
                        Session["CurrentStudent"] = sSelectedValue.Value;
                        divAdd.InnerHtml = sMsg;
                        MultiAdd.ActiveViewIndex = 1;

                    }
                }
                else
                {
                    //string sScript = "$(function(){ $('#divConfirmation').html('" + sMsg + "').css({'background-color':'#fff','border':'2px solid red', 'color':'red'}).slideToggle('slow'); });";
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript2", sScript, true);
                    UpdateConfirm(sMsg, true);
                }

            }

            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);

            }
            finally
            {


            }

        }
        //Drop Course
        protected void Dropbtn_Command(object sender, CommandEventArgs e)
        {
            try
            {
                SetArgs(e.CommandArgument.ToString());//Get bShift,sCourse,bClass

                //set the campus as of course session 
                int iPeriod = 0;
                int iFormNumber = 0;
                InitializeModule.EnumCampus CourseCampus = LibraryMOD.SyncCampusAndSession(bShift.ToString(), out iPeriod);
                if (CourseCampus != Campus)
                {
                    Campus = CourseCampus;
                    if (isStudentHasAccount(sNo) == true)
                    {

                        Get_Student_Advising();
                        Session["iFormNumber"] = this.CreateHeader();
                        Menu1.Enabled = true;
                    }
                    else
                    {                        
                        lbl_Msg.Text = "The Student Hasn't Account yet !";
                        div_msg.Visible = true;
                        Menu1.Enabled = false;
                    }
                }

                iFormNumber = int.Parse(Session["iFormNumber"].ToString());

                if (iFormNumber == 0) return;

                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                InitializeModule.enumPrivilege.DropCourse, CurrentRole) != true)
                {
                    UpdateConfirm("Sorry you are not allowed to drop a course.", true);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "$(document).ready(function(){ $('#divConfirmation').text('Sorry you are not allowed to drop a course.').slideToggle('slow'); });", true);
                    return;
                }

                bool isEsl = sCourse.Contains("ESL");
                if (isEsl)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                    InitializeModule.enumPrivilege.SkipESLs, CurrentRole) != true)
                    {
                        UpdateConfirm("Sorry you are not allowed to drop an ESL course.", true);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "$(document).ready(function(){ $('#divConfirmation').text('Sorry you are not allowed to drop a course.').slideToggle('slow'); });", true);
                        return;
                    }
                }
                //Check if the dropped course is a co-requisite for registered course
                string sCorequisite = "";
                RegValidation TheValidation = new RegValidation();

                // SetArgs(e.CommandArgument.ToString());//Get bShift,sCourse,bClass


                sCorequisite = TheValidation.IsCorequisiteofRegisteredCourse(iRegYear, iRegSem, sSelectedValue.Value, sCourse);

                if (sCorequisite != "")
                {
                    UpdateConfirm("Sorry you can not drop co-requisite course. before dropping:" + sCorequisite, true);
                    return;
                }

                Connection_StringCLS MyConnection_string = new Connection_StringCLS(this.Campus);
                SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
                Conn.Open();
                int iTrans = LibraryMOD.GetMaxID(Conn, "byteTrans", "Reg_Course_Detail", "intStudyYear=" + iRegYear + " AND byteSemester=" + iRegSem + " AND byteForm=1 AND intFormNumber=" + iFormNumber + " AND strCourse='" + sCourse + "' AND byteClass=" + bClass + " AND byteShift=" + bShift);
                iTrans++;
                Conn.Close();
                int iMode = (int)InitializeModule.enumModes.NewMode;
                string sPCName = System.Net.Dns.GetHostName();
                string sUserName = Session["CurrentUserName"].ToString();
                string sNetUserName = HttpContext.Current.User.Identity.Name;

                Course_DetailDAL myCourseDetail = new Course_DetailDAL();
                myCourseDetail.UpdateCourse_Detail(this.Campus, iMode, iRegYear, iRegSem, 1, iFormNumber, sCourse, bClass, bShift, iTrans, "False", "", "", 0, sUserName, DateTime.Now, sUserName, DateTime.Now, sPCName, sNetUserName);
                UpdateAlternative(false, sCourse, "");

                TMDS.SelectCommand = GetSQL(sSelectedValue.Value, iRegYear, iRegSem);
                TMDS.DataBind();
                grdTimeTable.DataBind();
                grdTimeTable.DataBind();

                //Update Registration Status-CX API if no courses Found
                if (grdTimeTable.Rows.Count <= 0)
                {
                    string studentid = Request.QueryString["sid"];
                    var services = new DAL.DAL();
                    Connection_StringCLS connstr = new Connection_StringCLS(Campus);
                    DataTable dtStudentServices = services.GetStudentDetailsID(studentid, connstr.Conn_string);
                    //string emailid = dtStudentServices.Rows[0]["sECTemail"].ToString();
                    //string fname = dtStudentServices.Rows[0]["strFirstDescEn"].ToString();
                    //string lname = dtStudentServices.Rows[0]["strSecondDescEn"].ToString();
                    hdnStudentMajor.Value = dtStudentServices.Rows[0]["strCaption"].ToString();
                    //Update Registration Status
                    //API Call-Update Registration Status
                    apicall_UpdateRegistrationStatus(grdTimeTable.Rows.Count, studentid);
                }

                UpdateConfirm("Course " + sCourse + " dropped successfully.", false);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "$(document).ready(function(){ $('#divConfirmation').text('Course " + sCourse + " dropped successfully.').slideToggle('slow'); });", true);

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);

            }
            finally
            {


            }
        }


        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            System.Web.UI.WebControls.Table myTable;
            string sSender = e.Item.Value;//0:Academic 1:Advising 2:Add course
            if (myList.Count == 0)
            {
               
                lbl_Msg.Text = "Select Student Please ...";
                div_msg.Visible = true;
                return;
            }


            MultiAdd.ActiveViewIndex = -1;

            System.Threading.Thread.Sleep(500);

            switch (sSender)
            {
                case "0":
                    myTable = Create_Table(myList[0]);
                    divPlan.Controls.Clear();
                    divPlan.Controls.Add(myTable);
                    MultiTabs.ActiveViewIndex = 0;

                    break;
                case "1":
                    myTable = Create_Rec_Table(myList[0]);
                    divRec.Controls.Clear();
                    divRec.Controls.Add(myTable);
                    MultiTabs.ActiveViewIndex = 1;

                    break;
                case "2":
                    txtCourse.Text = "";
                    grdCourses.DataBind();
                    MultiTabs.ActiveViewIndex = 2;
                    MultiAdd.ActiveViewIndex = 0;
                    break;
            }
        }

        private bool isValid(bool isInMajor, out string sMsg)
        {
            bool isit = true;
            sMsg = "";

            try
            {

                MirrorCLS myMirror = myList[0];
                MirrorDAL myMirrorDAL = new MirrorDAL();

                bool isVisiting = myMirror.StudentNumber.Contains("VA");

                int iMElective = myMirrorDAL.GetMajorElectiveCoursesCount(myMirror.StudentNumber, Campus);
                int iFElective = myMirrorDAL.GetFreeElectiveCoursesCount(myMirror.StudentNumber, Campus);

                RegValidation validation = new RegValidation(this.Campus, this.CurrentRole, myMirror, myPlan, sCourse, iRegYear, iRegSem, bShift, bClass);

                if (validation.isCourseRegistered())
                {
                    sMsg = "Course is already registered.";
                    return false;
                }

                bool isESL = sCourse.Contains("ESL");
                string sReturn = "";
                if (!isESL && !isVisiting)
                {
                    if (validation.isESLRequired(out sReturn) && !validation.isESLRegistered())
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                            InitializeModule.enumPrivilege.SkipESLs, CurrentRole) != true)
                        {

                            sMsg = sReturn + " Must be Registered First.";
                            return false;
                        }
                        else
                        {
                            sMsg += "<br/>* " + sReturn + " Must be Registered First.";
                        }
                    }
                }
                //Is must register MTH001

                sReturn = "";
                bool isMTH001 = sCourse.Contains("MTH001");
                bool isCHEM001 = sCourse.Contains("CHEM001");
                bool isBIOL001 = sCourse.Contains("BIOL001");
                bool isPHYS001 = sCourse.Contains("PHYS001");

                bool IsMTH001Required = false;
                bool IsCHEM001Required = false;
                bool IsBIOL001Required = false;
                bool IsPHYS001Required = false;
                string sFndCourse = "";

                //if (validation.isFNDCoursesRequired(myMirror.StudentNumber, out IsMTH001Required, out IsCHEM001Required, out IsBIOL001Required, out IsPHYS001Required))
                if (AdmissionRequirments.IsFulfilledAdmissionRequirements(Campus, myMirror.StudentNumber, out IsMTH001Required, out IsCHEM001Required, out IsBIOL001Required, out IsPHYS001Required))
                {
                    sFndCourse = "MTH001";
                    if (!isMTH001 && IsMTH001Required)
                    {
                        if (!validation.isFndCourseRegistered(sFndCourse) && !validation.isFndCoursePassed(sFndCourse))
                        {
                            //iErrorCounter++;
                            sMsg += "<br />*Your score in Math less than admission requirment, You must register " + sFndCourse + " first";
                        }
                    }
                    sFndCourse = "CHEM001";
                    if (!isCHEM001 && IsCHEM001Required)
                    {
                        if (!validation.isFndCourseRegistered(sFndCourse) && !validation.isFndCoursePassed(sFndCourse))
                        {
                            //iErrorCounter++;
                            sMsg += "<br />*Your score in Chemistry less than admission requirment, You must register " + sFndCourse + " first";
                        }
                    }
                    sFndCourse = "BIOL001";
                    if (!isBIOL001 && IsBIOL001Required)
                    {
                        if (!validation.isFndCourseRegistered(sFndCourse) && !validation.isFndCoursePassed(sFndCourse))
                        {
                            //iErrorCounter++;
                            sMsg += "<br />*Your score in Biology less than admission requirment, You must register " + sFndCourse + " first";
                        }
                    }
                    sFndCourse = "PHYS001";
                    if (!isPHYS001 && IsPHYS001Required)
                    {
                        if (!validation.isFndCourseRegistered(sFndCourse) && !validation.isFndCoursePassed(sFndCourse))
                        {
                            //iErrorCounter++;
                            sMsg += "<br />*Your score in Physics less than admission requirment, You must register " + sFndCourse + " first";
                        }
                    }
                }
                bool is50 = sCourse.Contains("%");
                int iSelectedCourseCR = 0;
                double iRegisteredCoursesCR = LibraryMOD.GetStudentRegisteredCredit(iRegYear, iRegSem, myMirror.StudentNumber, (int)Campus);



                //free elective courses - not in major plan and not major elective ourse
                if (!validation.isCourseInPlan() && !is50 && !isVisiting)
                {

                    //major elective
                    if (validation.isMajorElectiveCourse(sCourse, myMirror.SDegree, myMirror.SMajor) != false)
                    {
                        if (iMElective > 2)
                        {
                            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                            InitializeModule.enumPrivilege.SkipMaxMajorElective, CurrentRole) != true)
                            {
                                sMsg = "You already registered maximum major elective courses.";
                                return false;
                            }
                            else
                            {
                                sMsg += "<br />*You already registered maximum major elective courses.";
                            }
                        }
                    }
                    else
                    { //free elective
                        if (iFElective > 2)
                        {
                            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                            InitializeModule.enumPrivilege.SkipMaxFreeElective, CurrentRole) != true)
                            {
                                sMsg = "You already registered maximum free elective courses.";
                                return false;
                            }
                            else
                            {
                                sMsg += "<br />*You already registered maximum free elective courses.";
                            }
                        }
                    }
                }



                if (!is50)
                {
                    if (validation.isCourseTimeConflicts(out iSelectedCourseCR))
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                        InitializeModule.enumPrivilege.SkipTimeConflict, CurrentRole) != true)
                        {
                            sMsg = "Course time conflict.";
                            return false;
                        }
                        else
                        {
                            sMsg += "<br/>*Course time conflict.";
                        }

                    }
                }

                validation.iCurrentCR = iSelectedCourseCR;
                validation.iTotal = iRegisteredCoursesCR;
                float CGPA = float.Parse(myMirror.CGPA.ToString());
                int iMaxESL = myMirror.MaxESL;
                bool isToeflRequired = myMirror.IsENGRequired;
                float Score = float.Parse(myMirror.Score.ToString());
                bool isToeflPassed = LibraryMOD.isENGPassed(Score, myMirror.ENG, myMirror.SDegree, myMirror.SMajor);

                int iHours = LibraryMOD.GetMaxHours(iRegSem, isToeflRequired, isToeflPassed, iMaxESL, CGPA, myMirror.SDegree, myMirror.SMajor);
                if (!((validation.iTotal + validation.iCurrentCR) <= iHours) && !isVisiting)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                    InitializeModule.enumPrivilege.SkipAcademicLoad, CurrentRole) != true)
                    {

                        sMsg = "Registered courses credit hours exceed semester limit.";
                        return false;
                    }
                    else
                    {
                        sMsg += "<br />*Registered courses credit hours exceed semester limit.";
                    }


                }


                //if Two Summers

                if (iRegSem > 2)
                {
                    int iSummers = LibraryMOD.GetSummersHours(iRegYear, sSelectedValue.Value, Campus);

                    if (!((iSummers + validation.iCurrentCR) <= 12))
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                        InitializeModule.enumPrivilege.SkipAcademicLoad, CurrentRole) != true)
                        {

                            sMsg = "Registered courses credit hours exceed the two summers limit.";
                            return false;
                        }
                        else
                        {
                            sMsg += "<br />*Registered courses credit hours exceed the two summers limit.";
                        }

                    }

                }

                if (!validation.isCourseInPlan() && !is50 && isInMajor && !isVisiting)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                    InitializeModule.enumPrivilege.SkipOutOfMajor, CurrentRole) != true)
                    {

                        sMsg = "Course is not in student\"s plan.";
                        return false;
                    }
                    else
                    {
                        sMsg += "<br />*Course is not in student\"s plan.";
                    }
                }
                else
                {
                    if (!validation.isPrerequisitePassed(iRegSem) && !is50 && !isVisiting)
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                        InitializeModule.enumPrivilege.SkipPrerequisite, CurrentRole) != true)
                        {
                            sMsg = "Course prerequisite(s) are not passed.";
                            return false;
                        }
                        else
                        {
                            sMsg += "<br />*Course prerequisite(s) are not passed.";
                        }
                    }

                    if (!isVisiting)
                    {
                        if (validation.isHasCorequisites() && !is50)
                        {
                            //update student mirror

                            Get_Student_Advising();
                            myMirror = myList[0];

                            if (!validation.isCorequisites_Registered())
                            {
                                //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                                //InitializeModule.enumPrivilege.SkipPrerequisite, CurrentRole) != true)
                                //{
                                sMsg = "Course co-requisite is not registered.";
                                return false;
                                //}
                                //else
                                //{
                                //    sMsg += "<br />*Course co-requisite is not registered.";
                                //}

                            }
                        }
                    }


                }

                if (!validation.isCourseRegisterable() && !is50)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                    InitializeModule.enumPrivilege.AllowRepeatPassedCoursesNot_D, CurrentRole) != true)
                    {
                        sMsg = "Course is passed with a grade that is not D";
                        return false;
                    }
                    else
                    {
                        sMsg += "<br />*Course is passed with a grade that is not D";
                    }

                }

                if (validation.isClassFull() && !is50)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                    InitializeModule.enumPrivilege.SkipMaxCapacity, CurrentRole) != true)
                    {
                        sMsg = "Class is full.";
                        return false;
                    }
                    else
                    {
                        sMsg += "<br />*Class is full.";
                    }

                }

                bool isFinance = true;
                bool isActive = true;
                bool isFinanceSkip = false;
                bool isActiveSkip = false;

                isFinance = LibraryMOD.isFinanceProblems(Campus, myMirror.StudentNumber, iRegYear * 10 + iRegSem);
                isFinanceSkip = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                       InitializeModule.enumPrivilege.SkipStudentFinanceProblem, CurrentRole);
                isActive = LibraryMOD.isActiveStudent(Campus, myMirror.StudentNumber);
                isActiveSkip = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                       InitializeModule.enumPrivilege.SkipStudentActive, CurrentRole);


                if (isFinance)
                {
                    if (!isFinanceSkip)
                    {
                        sMsg = "Student having financial problems.";
                        return false;
                    }
                    else
                    {
                        sMsg += "<br />*Student having financial problems.";
                    }
                }

                if (!isActive)
                {
                    if (!isActiveSkip)
                    {
                        sMsg = "Student is inactive.";
                        return false;
                    }
                    else
                    {
                        sMsg += "<br />*Student is inactive.";
                    }
                }

                if (!validation.isGraduationAllowed(sCourse))
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                    InitializeModule.enumPrivilege.Skip99, CurrentRole) != true)
                    {
                        sMsg = "Graduation Project & Internship courses can be registered after completing 99 Ch Only";
                        return false;
                    }
                    else
                    {
                        sMsg += "<br />*Graduation Project & Internship courses can be registered after completing 99 Ch Only";
                    }
                }
                //if (validation.isInactiveOrHasFinanceProblems())
                //{
                //    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                //      InitializeModule.enumPrivilege.SkipStudentFinanceProblem, CurrentRole) != true || LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                //      InitializeModule.enumPrivilege.SkipStudentActive, CurrentRole) != true)
                //    {
                //        sMsg = "Student is inactive or having financial problems.";
                //        return false; 

                //    }
                //    else
                //    {
                //        sMsg += "<br />*Student is inactive or having financial problems.";
                //    }
                //}


            }

            catch (Exception ex)
            {
                isit = false;
                sMsg = ex.Message;
                LibraryMOD.ShowErrorMessage(ex);

            }
            finally
            {


            }
            return isit;
        }

        private int AddCourse(int iFormNumber)
        {
            Connection_StringCLS MyConnection_string = new Connection_StringCLS(this.Campus);
            SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
            Conn.Open();
            int iAdded = 0;
            try
            {
                int iTrans = LibraryMOD.GetMaxID(Conn, "byteTrans", "Reg_Course_Detail", "intStudyYear=" + iRegYear + " AND byteSemester=" + iRegSem + " AND byteForm=1 AND intFormNumber=" + iFormNumber + " AND strCourse='" + sCourse + "' AND byteClass=" + bClass + " AND byteShift=" + bShift);
                iTrans++;
                Conn.Close();
                int iMode = (int)InitializeModule.enumModes.NewMode;
                string sPCName = Session["CurrentPCName"].ToString();
                string sUserName = Session["CurrentUserName"].ToString();
                string sNetUserName = Session["CurrentNetUserName"].ToString();

                Course_DetailDAL myCourseDetail = new Course_DetailDAL();
                myCourseDetail.UpdateCourse_Detail(this.Campus, iMode, iRegYear, iRegSem, 1, iFormNumber, sCourse, bClass, bShift, iTrans, "True", "", "", 0, sUserName, DateTime.Now, sUserName, DateTime.Now, sPCName, sNetUserName);
                iAdded++;

                if (sCourse != ddlAlt.SelectedValue)//Alternative
                {
                    UpdateAlternative(true, sCourse, ddlAlt.SelectedValue);
                }
                TMDS.SelectCommand = GetSQL(sSelectedValue.Value, iRegYear, iRegSem);
                TMDS.DataBind();
                grdTimeTable.DataBind();
                if (grdTimeTable.Rows.Count > 0)
                {
                    //Update Registration Status - Status Registered

                    //Check Email exists or not
                    string studentid = Request.QueryString["sid"];
                    var services = new DAL.DAL();
                    Connection_StringCLS connstr = new Connection_StringCLS(Campus);
                    DataTable dtStudentServices = services.GetStudentDetailsID(studentid, connstr.Conn_string);
                    string emailid = dtStudentServices.Rows[0]["sECTemail"].ToString();
                    string fname = dtStudentServices.Rows[0]["strFirstDescEn"].ToString();
                    string lname = dtStudentServices.Rows[0]["strSecondDescEn"].ToString();
                    hdnStudentMajor.Value = dtStudentServices.Rows[0]["strCaption"].ToString();

                    //API Call-Update Registration Status
                    apicall_UpdateRegistrationStatus(grdTimeTable.Rows.Count, studentid);

                    if (emailid != "" && emailid != null)
                    {
                        //Don't Call Email Creation function
                    }
                    else
                    {
                        string sSID = studentid;
                        int iSerial = GetSerial(sSID);
                        Session["StudentSerialNo"] = iSerial;
                        hdnSerial.Value = iSerial.ToString();
                        int iCSem = 0;
                        int iTerm = Convert.ToInt32(Terms.SelectedValue);
                        //int iCYear = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out iCSem);
                        int iCYear = LibraryMOD.SeperateTerm(iTerm, out iCSem);
                        Session["CurrentYear"] = iCYear;
                        Session["CurrentSemester"] = iCSem;
                        int iRegisteredHours = LibraryMOD.GetCurrentRegisteredCourses(this.Campus, sSID, iCYear, iCSem);
                        if (iRegisteredHours == 0)
                        {
                            //lbl_Msg.Text = "Student must register courses before creating email.";
                            //div_msg.Visible = true;
                            return 0;
                        }
                        //======= Generate Student email
                        CreateStudentEmail(lname);
                        if (hdnStudentEmail.Value.Length < 17)
                        {
                            return 0;
                        }
                        //======= Create email in Office365 & AD 
                        CreateStudentEmailAD(this.Campus, sSID);

                        //======= Create Moodle Account
                        if (ClsMoodleAPI.CreateUpdateMoodleAccount(hdnStudentEmail.Value, sSID) == InitializeModule.SUCCESS_RET)
                        {
                            hdnMsg.Value += " & Moodle";
                        }
                        //======== Enroll student in Moodle courses
                        if (ClsMoodleAPI.EnrollStudentinMoodleCourses(hdnStudentEmail.Value, sSID) == InitializeModule.SUCCESS_RET)
                        {
                            hdnMsg.Value += ", Student enrolled in Moodle courses";
                        }
                        //======= Create Zoom Account
                        string sFirstName = fname + " " + lname;
                        string sLastName = " - " + sSID;
                        CreateZoomAccount(hdnStudentEmail.Value, sFirstName, sLastName);
                    }                    
                }

                UpdateConfirm("Course " + sCourse + " added successfully.", false);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "$(document).ready(function(){ $('#divConfirmation').text('Course " + sCourse + " added successfully.').slideToggle('slow'); });", true);

            }
            catch (Exception ex)
            {
                iAdded = 0;
                LibraryMOD.ShowErrorMessage(ex);

            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return iAdded;
        }
        private int GetSerial(string sNumber)
        {
            int iserial = 0;
            try
            {
                ApplicationsDAL myapp = new ApplicationsDAL();
                iserial = myapp.GetSerial(Campus, sNumber);
            }
            catch (Exception ex)
            {
            }
            return iserial;
        }
        public void CreateZoomAccount(string email, string firstname, string lastname)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            string userid = "";

            //string JWTaccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOm51bGwsImlzcyI6IktUUUpsM1ZiU0k2aVBPNDl0VmVma1EiLCJleHAiOjE3MzU3MTEyMDAsImlhdCI6MTYwMDI0NDY5MX0.GgRVMlmMsmf0j_d5TUY4jKKO-4xZfSt7u5hmQb9QFks";
            string JWTaccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOm51bGwsImlzcyI6IktUUUpsM1ZiU0k2aVBPNDl0VmVma1EiLCJleHAiOjE2NzUxODA4MDAsImlhdCI6MTYxNDA2OTU5Mn0.co_ApVI-0jkM3quY7igEvSZOsJIDkITCoRI0aoquHl8";

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.zoom.us/v2/users"))
                {
                    request.Headers.TryAddWithoutValidation("authorization", "Bearer " + JWTaccessToken + "");

                    request.Content = new StringContent("{\"action\":\"create\",\"user_info\":{\"email\":\"" + email + "\",\"type\":1,\"first_name\":\"" + firstname + "\",\"last_name\":\"" + lastname + "\"}}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    string s = response.Content.ReadAsStringAsync().Result;
                    var x = JObject.Parse(s);
                    var uID = x["id"];
                    if (uID != null) //added by bahaa 25-09-2020 //
                    {
                        userid = uID.ToString();
                        hdnMsg.Value += ",Zoom Account Created";
                    }


                }
            }

            if (userid != "" && userid != null)
            {
                string groupid = "OU8bD5WPTxSpMLMvtG5H4w";//Group Name-Student
                string emailID = email;

                AddZoomGroupMemebers(groupid, emailID, userid, JWTaccessToken);

                //string IMGroupID = "W6jUNfWfSuC-vY7VqWpwOQ";//Default IM Group - Restricted 
                //if (Gender == "Males")
                //{
                //    IMGroupID = "seOLrQ4DQFWA7WMZzqwZhQ";//Males Studnets         
                //}
                //else if (Gender == "Females")
                //{
                //    IMGroupID = "1ShdTaaERVKs3KZmgO6JuQ";//Females Studnet
                //}
                //else
                //{
                //    IMGroupID = "W6jUNfWfSuC-vY7VqWpwOQ";//Default IM Group - Restricted 
                //}
                //addZoomIMGroupMembers(IMGroupID, emailID, userid);

                //deleteZoomIMGroupMemeber("W6jUNfWfSuC-vY7VqWpwOQ", userid);//Remove the User from Default IM Group - Restricted 
                hdnMsg.Value += ",Zoom Account User Added to Group";
            }
        }
        public void AddZoomGroupMemebers(string groupid, string email, string userid, string JWTaccessToken)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.zoom.us/v2/groups/" + groupid + "/members"))
                {
                    request.Headers.TryAddWithoutValidation("authorization", "Bearer " + JWTaccessToken + "");

                    request.Content = new StringContent("{\"members\":[{\"id\":\"" + userid + "\",\"email\":\"" + email + "\"}]}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    string s = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
        public void CreateStudentEmailAD(InitializeModule.EnumCampus Campus, string sStudentID)
        {
            string sSQL = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Con = new SqlConnection(myConnection_String.Conn_string);
            try
            {
                sSQL = "SELECT  SD.strFirstDescEn + ' ' + SD.strSecondDescEn AS [Given_Name]";
                sSQL += ", ' - ' + REPLACE(A.lngStudentNumber, '.', '') AS Surname";
                sSQL += ", SD.strFirstDescEn + ' ' + SD.strSecondDescEn AS [Display_Name]";
                sSQL += ", SD.sECTemail AS [Email_Addresses], LEFT(SD.sECTemail, LEN(SD.sECTemail) - 10) AS [Sam_Account_Name]";
                sSQL += ", 'ect@12345' AS Password, 'ect@12345' AS [User_Password], 'ect@12345' AS ChangePasswordOnNextLogon";
                sSQL += ", 'SMTP:' + SD.sECTemail AS [Proxy_Addresses], 'Student' AS [Personal_Title]";
                sSQL += ", M.strMajor AS Department, (CASE WHEN iCampus = 1 THEN 'Males Campus' ";
                sSQL += " WHEN iCampus = 2 THEN 'Females Campus' ";
                sSQL += " WHEN iCampus = 3 AND bSex = 1 THEN 'Media-Males Campus' ";
                sSQL += " WHEN iCampus = 3 AND bSex = 0 THEN 'Media-Females Campus' END) AS Description";
                sSQL += ", 'Emirates College of Technology' AS Company ";
                sSQL += " FROM Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ";
                sSQL += " ON A.lngSerial = SD.lngSerial INNER JOIN Reg_Specializations AS M ";
                sSQL += " ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree ";
                sSQL += " AND A.strSpecialization = M.strSpecialization LEFT OUTER JOIN Last_Time_Registered ";
                sSQL += " ON A.lngStudentNumber = Last_Time_Registered.Student LEFT OUTER JOIN Lkp_Reasons ";
                sSQL += " ON A.byteCancelReason = Lkp_Reasons.byteReason ";
                sSQL += " WHERE  (SD.sECTemail IS NOT NULL) AND SD.sECTemail <> '' ";
                //if (sStudentID.Contains("M"))
                //{
                //    sSQL += " AND (SD.bSex = 1)";
                //}
                //else
                //{
                //    sSQL += " AND (SD.bSex = 0)";
                //}
                sSQL += " AND (SD.IsEmailCreationRequired = 1) ";
                sSQL += " AND A.lngStudentNumber ='" + sStudentID + "'";
                sSQL += " ORDER BY SD.iUnifiedID";

                SqlCommand cmd = new SqlCommand(sSQL, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                Con.Open();
                da.Fill(dt);
                Con.Close();

                if (dt.Rows.Count > 0)
                {
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{  
                    int i = 0;
                    CreateUserEmailAD(dt.Rows[i]["Given_Name"].ToString(), dt.Rows[i]["Surname"].ToString(), dt.Rows[i]["Display_Name"].ToString(), dt.Rows[i]["Description"].ToString(), dt.Rows[i]["Email_Addresses"].ToString(), dt.Rows[i]["Sam_Account_Name"].ToString(), dt.Rows[i]["Department"].ToString(), dt.Rows[i]["Company"].ToString(), true);
                    //}
                    UpdateEmailCreationRequired(Con, Convert.ToInt32(hdnSerial.Value));
                    hdnMsg.Value += ",Students Email Created Successfully in Office365";
                    //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    //div_msg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Con.Close();
                throw ex;
            }
            finally
            {
                Con.Close();
            }
        }
        public void UpdateEmailCreationRequired(SqlConnection Con, int iSerialNo)
        {

            string sSQL = "";

            try
            {
                sSQL = "UPDATE Reg_Students_Data set IsEmailCreationRequired = 0";
                sSQL += " WHERE IsEmailCreationRequired = 1";
                sSQL += " AND lngSerial=" + iSerialNo;

                SqlCommand cmd = new SqlCommand(sSQL, Con);
                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                throw ex;
            }
            finally
            {
                Con.Close();
            }
        }
        public int CreateUserEmailAD(string firstName, string lastName, string displayname, string description, string emailAddress, string userLogonName, string department, string company, bool enabled)
        {
            string Ounames = "Females";
            if (description == "Females Campus")
            {
                Ounames = "Females";
            }
            else
            {
                Ounames = "Males";
            }
            // Creating the PrincipalContext
            PrincipalContext principalContext = null;
            string adminusername = "ets.services.admin";
            string adminpassword = "Ser71ces@328";
            string userdomainLdappath = "OU=" + Ounames + ",OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            string Server = "ectuae";
            try
            {
                principalContext = new PrincipalContext(ContextType.Domain, Server, userdomainLdappath, adminusername, adminpassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Check if user object already exists in the AD
            UserPrincipal usr = UserPrincipal.FindByIdentity(principalContext, userLogonName);
            if (usr != null)
            {
                //User Already Exists
            }
            else
            {
                //Create New User
                DirectoryEntry myLdapConnection = DirectEntry(Ounames);
                DirectoryEntry user = myLdapConnection.Children.Add("CN=" + userLogonName + " ", "user");

                // User name (Domain-Based)   
                user.Properties["userprincipalname"].Add(userLogonName + "@" + "ectuae.com");

                // User name (Older-Systems)  
                user.Properties["samaccountname"].Add(userLogonName);

                // Surname  
                user.Properties["sn"].Add(lastName);

                // Given-Name  
                user.Properties["givenname"].Add(firstName);

                // Display-Name  
                user.Properties["displayname"].Add(displayname);

                // Description  
                user.Properties["description"].Add(description);

                // E-mail  
                user.Properties["mail"].Add(emailAddress);

                // Department  
                user.Properties["department"].Add(department);

                // Company  
                user.Properties["company"].Add(company);

                // Personal-Title  
                user.Properties["personalTitle"].Add("Student");

                // Proxy-Addresses  
                user.Properties["proxyAddresses"].Add("SMTP:" + emailAddress + "");

                // User-Password  
                user.Properties["userPassword"].Add("ect@12345");

                user.CommitChanges();
                user.Invoke("SetPassword", "ect@12345");

                //Force Password Change on Next Login
                //user.Properties["pwdLastSet"].Value = 0;

                if (enabled)
                    user.Invoke("Put", new object[] { "userAccountControl", "544" });

                user.CommitChanges();

                //AddUserToGroup(userLogonName, "Males");
                AddUserToGroup(userLogonName, Ounames);

                //Call Sharepoint function New Student
                sentdatatoSPLIstNewStudentsTracking(emailAddress);
            }
            return 0;
        }
        public void sentdatatoSPLIstNewStudentsTracking(string mailid)
        {
            int sem = 0;
            int Year = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out sem);

            int iYear = Year;
            int iSem = sem;
            string sSemester = LibraryMOD.GetSemesterString(iSem);
            int iTerm = iYear * 10 + iSem;

            string Addedby = "";
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from HR_Employee_Academic_Admin_Managers where EmployeeID='" + Session["EmployeeID"].ToString() + "'", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    Addedby = dt.Rows[0]["EmployeeEmail"].ToString();
                }
            }
            catch (Exception ex)
            {
                sc.Close();
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                sc.Close();
            }


            string SIS_PWD = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc1 = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd1 = new SqlCommand("SELECT strPhone1,strPhone2,strStudentName,strOnlinePWD from Reg_Student_Accounts where lngStudentNumber=@lngStudentNumber", sc1);
            cmd1.Parameters.AddWithValue("@lngStudentNumber", sSelectedValue.Value);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            try
            {
                sc1.Open();
                da1.Fill(dt1);
                sc1.Close();

                if (dt1.Rows.Count > 0)
                {
                    SIS_PWD = dt1.Rows[0]["strOnlinePWD"].ToString();
                }
            }
            catch (Exception ex)
            {
                sc1.Close();
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                sc1.Close();
            }

            string login = "ets.services.admin@ect.ac.ae"; //give your username here  
            string password = "Ser71ces@328"; //give your password  
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            string siteUrl = "https://ectacae.sharepoint.com/sites/ECTPortal/eservices/studentservices";
            ClientContext clientContext = new ClientContext(siteUrl);
            Microsoft.SharePoint.Client.List myList = clientContext.Web.Lists.GetByTitle("New Students Tracking");
            ListItemCreationInformation itemInfo = new ListItemCreationInformation();
            Microsoft.SharePoint.Client.ListItem myItem = myList.AddItem(itemInfo);
            myItem["Title"] = iTerm;//Term                     
            myItem["SID"] = sSelectedValue.Value;//SID
            myItem["Email"] = clientContext.Web.EnsureUser(mailid);//Student Email   
            //myItem["Email"] = clientContext.Web.EnsureUser("sujeesh.sureshkumar@ect.ac.ae");//Student Email  
            myItem["Password"] = SIS_PWD;//SIS Password
            myItem["Phone1"] = dt1.Rows[0]["strPhone1"].ToString();//Phone1
            myItem["Phone2"] = dt1.Rows[0]["strPhone2"].ToString();//Phone2  
            myItem["Author"] = clientContext.Web.EnsureUser(Addedby);//Added By
            //myItem["Author"] = clientContext.Web.EnsureUser("ihab.awad@ect.ac.ae");//Addedby
            myItem["FirstUpdate"] = null;//1st Update
            myItem["SecondUpdate"] = null;//2nd Update
            myItem["ThirdUpdate"] = null;//3rd Update
            myItem["Remarks"] = "";//Remarks
            myItem["Status"] = "Initiated";//Status
            myItem["StudentName"] = dt1.Rows[0]["strStudentName"].ToString();//Student Name
            //myItem["Modified"] = null;//Updated
            //myItem["Created"] = DateTime.Now;//Created
            myItem["Editor"] = clientContext.Web.EnsureUser(Addedby);//Updated By
            //myItem["AlertTo"] = clientContext.Web.EnsureUser("ihab.awad@ect.ac.ae");//AlertTo  
            //myItem["AlertTo"] = clientContext.Web.EnsureUser(AlertTo);
            try
            {
                myItem.Update();
                var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
                clientContext.Credentials = onlineCredentials;
                clientContext.ExecuteQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Console.ReadLine();
        }
        public static DirectoryEntry DirectEntry(string ouname)
        {
            DirectoryEntry ldapConnection = new DirectoryEntry("rch");
            //ldapConnection.Path = "LDAP://OU=Males,OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            ldapConnection.Path = "LDAP://OU=" + ouname + ",OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            ldapConnection.Username = "ets.services.admin";
            ldapConnection.Password = "Ser71ces@328";
            return ldapConnection;
        }
        public static void AddUserToGroup(string userId, string groupName)
        {
            string adminusername = "ets.services.admin";
            string adminpassword = "Ser71ces@328";
            string Server = "ectuae";
            //string userdomainLdappath = "OU=Males,OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            string userdomainLdappath = "OU=" + groupName + ",OU=ECT Students,OU=Emirates College of Technology,DC=ectuae,DC=com";
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, Server, userdomainLdappath, adminusername, adminpassword))
                {
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, groupName);
                    group.Members.Add(pc, IdentityType.SamAccountName, userId);
                    group.Save();
                }
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //doSomething with E.Message.ToString(); 
            }
        }
        private void CreateStudentEmail(string lname)
        {
            //if (txtECTEmail.Text.Length > 17) 
            //{
            //    return;
            //    btnCreateEmail.Enabled = false;
            //}
            string sFName = "";
            string sECTEmail = "";
            if (lname.Trim().Length <= 1)
            {
                hdnMsg.Value = "Please enter correct name in (Last Name) ";
                //div_msg.Visible = true;
                return;
            }
            int iUnifiedID = LibraryMOD.GetMaxUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value), out sFName);
            //update Unified ID
            if (iUnifiedID > 0)
            {
                LibraryMOD.UpdateStudentUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value), iUnifiedID);
                //check reference number
                if (LibraryMOD.UpdateStudentUnifiedIDIfHasRefID(Campus, Convert.ToInt32(hdnSerial.Value)) == true)
                {
                    //Get updated UnifiedID
                    iUnifiedID = LibraryMOD.GetUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value));
                }
            }
            else
            {
                iUnifiedID = LibraryMOD.GetUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value), out sFName);
                if (iUnifiedID == 0)
                {
                    iUnifiedID = LibraryMOD.GetMaxUnifiedID_withoutCheckRefID(Campus, Convert.ToInt32(hdnSerial.Value), out sFName);
                }
                LibraryMOD.UpdateStudentUnifiedID(Campus, Convert.ToInt32(hdnSerial.Value), iUnifiedID);
            }
            //Update student email    
            sECTEmail = sFName.ToString().Trim().Replace(" ", string.Empty) + iUnifiedID.ToString().PadLeft(6, Convert.ToChar("0")) + "@ect.ac.ae";
            if (LibraryMOD.UpdateStudentEmail(Campus, Convert.ToInt32(hdnSerial.Value), sECTEmail) == true)
            {
                hdnMsg.Value = "Student email has been created successfully";
                //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                //div_msg.Visible = true;
                hdnStudentEmail.Value = sECTEmail;
            }
            else
            {
                hdnMsg.Value = "The student's email has not been created";
                //div_msg.Visible = true;
            }
            //btnCreateEmail.Enabled = false;
        }
        public void apicall_UpdateRegistrationStatus(int count, string sSID)
        {
            string registrationstatus = "Registered";
            string retention_status = "Opened";
            string numberofregisteredcourses = "0";
            string cgpa = "0";
            string ect_student_id = sSID;
            string financialbalance = "A";
            string sisusername = sSID;
            string sispassword = "ect@12345";
            string ectemailpassword = "ect@12345";
            string major = hdnStudentMajor.Value;
            string Credit_Completed = "0";
            string contactid = "0";
            if (count > 0)
            {
                registrationstatus = "Registered";
                retention_status = "Registered";
                numberofregisteredcourses = count.ToString();
            }
            else
            {
                registrationstatus = "Unregistered";
                retention_status = "Opened";
                numberofregisteredcourses = "0";
            }
            int iCSem = 0;
            int iTerm=Convert.ToInt32(Terms.SelectedValue);
            int iCYear = LibraryMOD.SeperateTerm(iTerm, out iCSem);
            int hrs = 18;
            if (iCSem == 1 || iCSem == 2)//Fall & Spring
            {
                hrs = 18;
            }
            else if (iCSem == 3 || iCSem == 4)//Summer 1 & Summer 2
            {
                hrs = 9;
            }
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("SELECT  A.lngStudentNumber AS SID, dbo.Completed_Successfully(A.lngStudentNumber, " + iCYear + ", " + iCSem + ", A.strDegree, A.strSpecialization) AS Completed, dbo.GetSARFinanceCategory(" + iCYear + ", " + iCSem + ", A.lngStudentNumber, " + hrs + ") AS Balance, ISNULL(G.GPA, 0) AS CGPA, SD.sECTemail AS EMail, ISNULL(AC.intOnlineUser, 0) AS [User] FROM Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial LEFT OUTER JOIN Reg_Student_Accounts AS AC ON A.lngStudentNumber = AC.lngStudentNumber LEFT OUTER JOIN GPA_Until AS G ON A.lngStudentNumber = G.lngStudentNumber WHERE (A.lngStudentNumber = @lngStudentNumber);SELECT  [UserNo],[UserName],[Password] FROM [ECTDataNew].[dbo].[Cmn_User] where UserNo in (SELECT intOnlineUser from [ECTData].[dbo].[Reg_Student_Accounts] where lngStudentNumber=@lngStudentNumber);SELECT GPA FROM GPA_Until WHERE lngStudentNumber=@lngStudentNumber;  select icontactid FROM [ECTData].[dbo].[Reg_Applications] where lngStudentNumber=@lngStudentNumber", sc);
            cmd.Parameters.AddWithValue("@lngStudentNumber", sSID);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(ds);
                sc.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Credit_Completed = ds.Tables[0].Rows[0]["Completed"].ToString();
                    financialbalance = ds.Tables[0].Rows[0]["Balance"].ToString();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    sisusername = ds.Tables[1].Rows[0]["UserName"].ToString();
                    sispassword = ds.Tables[1].Rows[0]["Password"].ToString();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    cgpa = ds.Tables[2].Rows[0]["GPA"].ToString();
                }
                else
                {
                    cgpa = "0";
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    contactid = ds.Tables[3].Rows[0]["icontactid"].ToString();
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

            //API Call

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string accessToken = InitializeModule.CxPwd;
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), "https://ect.custhelp.com/services/rest/connect/v1.4/contacts/" + contactid + ""))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", accessToken);
                    request.Headers.TryAddWithoutValidation("OSvC-CREST-Application-Context", "application/x-www-form-urlencoded");

                    request.Content = new StringContent("{\n    \"customFields\": {\n        \"c\": {\n            \"registrationstatus\": {\n                \"lookupName\": \"" + registrationstatus + "\"\n            },\n            \"numberofregisteredcourses\": " + numberofregisteredcourses + ",\n            \"cgpa\": " + cgpa + ",\n            \"retention_status\": {\n                \"lookupName\": \"" + retention_status + "\"\n            },\n            \"ect_student_id\": \"" + ect_student_id + "\",\n            \"financialbalance\": \"" + financialbalance + "\",\n            \"sisusername\": \"" + sisusername + "\",\n            \"sispassword\": \"" + sispassword + "\",\n            \"ectemailpassword\": \"" + ectemailpassword + "\"\n        },\n        \"CO\": {\n            \"Major\": \"" + major + "\",\n            \"Credit_Completed\": " + Credit_Completed + "\n        }\n    }\n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    string s = response.Content.ReadAsStringAsync().Result;
                    //If Status 200
                    if (response.IsSuccessStatusCode == true)
                    {
                        hdnMsg.Value += ", API Call-Update Registration Status-SUCCESS";
                    }

                }
            }
        }
        private string GetSQL(string sID, int iYear, int iSem)
        {
            string sSQL = "";
            try
            {
                string sServer = "SQL_SERVER.ECTData.dbo.";

                sSQL = "SELECT 'Females' AS sCampus,P.strShiftEn AS Session, TT.strCourse AS Course";
                sSQL += " , TT.byteClass AS Class, TT.Lecturer, TT.TimeFrom, TT.TimeTo";
                sSQL += " , TT.Sun, TT.Mon, TT.Tus, TT.Wed, TT.Thu, TT.Fri";
                sSQL += " , TT.Sat, TT.Hall, CB.Shift AS iSession, AL.strAlternativeTo AS sAL";
                sSQL += " FROM " + sServer + "Course_Balance_View AS CB INNER JOIN";
                sSQL += " " + sServer + "Time_Table_Times AS TT ON CB.Shift = TT.byteShift AND CB.Course = TT.strCourse ";
                sSQL += " AND CB.Class = TT.byteClass AND CB.iYear = TT.intStudyYear  ";
                sSQL += " AND CB.Sem = TT.byteSemester INNER JOIN";
                sSQL += " " + sServer + "Reg_Shifts AS P ON TT.byteShift = P.byteShift LEFT OUTER JOIN";
                sSQL += " " + sServer + "Reg_Course_Alternative AS AL ON CB.iYear = AL.intStudyYear AND CB.Sem = AL.byteSemester";
                sSQL += " AND CB.Student = AL.lngStudentNumber AND CB.Course = AL.strAlternative";
                sSQL += " WHERE (CB.Student ='" + sID + "')";
                sSQL += " AND (CB.iYear = " + iYear + ") ";
                sSQL += " AND (CB.Sem = " + iSem + ") ";

                sServer = "LOCALECT.ECTData.dbo.";

                sSQL += " UNION ";
                sSQL += "SELECT 'Males' AS sCampus,P.strShiftEn AS Session, TT.strCourse AS Course";
                sSQL += " , TT.byteClass AS Class, TT.Lecturer, TT.TimeFrom, TT.TimeTo";
                sSQL += " , TT.Sun, TT.Mon, TT.Tus, TT.Wed, TT.Thu, TT.Fri";
                sSQL += " , TT.Sat, TT.Hall, CB.Shift AS iSession, AL.strAlternativeTo AS sAL";
                sSQL += " FROM " + sServer + "Course_Balance_View AS CB INNER JOIN";
                sSQL += " " + sServer + "Time_Table_Times AS TT ON CB.Shift = TT.byteShift AND CB.Course = TT.strCourse ";
                sSQL += " AND CB.Class = TT.byteClass AND CB.iYear = TT.intStudyYear  ";
                sSQL += " AND CB.Sem = TT.byteSemester INNER JOIN";
                sSQL += " " + sServer + "Reg_Shifts AS P ON TT.byteShift = P.byteShift LEFT OUTER JOIN";
                sSQL += " " + sServer + "Reg_Course_Alternative AS AL ON CB.iYear = AL.intStudyYear AND CB.Sem = AL.byteSemester";
                sSQL += " AND CB.Student = AL.lngStudentNumber AND CB.Course = AL.strAlternative";
                sSQL += " WHERE (CB.Student ='" + sID + "')";
                sSQL += " AND (CB.iYear = " + iYear + ") ";
                sSQL += " AND (CB.Sem = " + iSem + ") ";

                sSQL += " ORDER BY Course, TT.TimeFrom";
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);                
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }

            return sSQL;
        }
        protected void Proceedbtn_Click(object sender, EventArgs e)
        {
            if (Session["CurrentSession"] != null && Session["CurrentCourse"] != null && Session["CurrentClass"] != null)
            {

                bShift = (byte)Session["CurrentSession"];
                sCourse = Session["CurrentCourse"].ToString();

                if (sCourse != ddlAlt.SelectedValue)//Validate Aternative
                {
                    string sAlt = ddlAlt.SelectedValue;
                    MirrorCLS myMirror = myList[0];
                    MirrorDAL myMirrorDAL = new MirrorDAL();


                    RegValidation validation = new RegValidation(this.Campus, this.CurrentRole, myMirror, myPlan, sAlt, iRegYear, iRegSem, bShift, bClass);
                    if (validation.isCourseRegistered())
                    {
                        divAdd.InnerText = "The alternative (" + sAlt + ") is registered already.";
                        ddlAlt.SelectedValue = sCourse;
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript", "alert('The alternative is registered already.');", true);
                        return;

                    }
                    if (!validation.isCourseRegisterable())
                    {
                        divAdd.InnerText = "The alternative (" + sAlt + ") is passed already";
                        ddlAlt.SelectedValue = sCourse;
                        return;

                    }
                    //if (!validation.isPrerequisitePassed())
                    //{
                    //    divAdd.InnerText = "The alternative prerequisit should be taken first.";
                    //    return;
                    //}

                    if (!validation.isGraduationAllowed(sCourse))
                    {
                        divAdd.InnerText = "Graduation Project & Internship courses as alternative (" + sAlt + ") can be registered after completing 99 Ch Only.";
                        ddlAlt.SelectedValue = sCourse;
                        return;
                    }

                }

                bClass = (byte)Session["CurrentClass"];
                int iFormNumber = int.Parse(Session["iFormNumber"].ToString());
                int iAdded = AddCourse(iFormNumber);
                Session["CurrentSession"] = null;
                Session["CurrentCourse"] = null;
                Session["CurrentClass"] = null;
                Session["CurrentMsg"] = null;
                divAdd.InnerHtml = "";

            }
            TMDS.SelectCommand = GetSQL(sSelectedValue.Value, iRegYear, iRegSem);
            TMDS.DataBind();
            grdTimeTable.DataBind();
            MultiAdd.ActiveViewIndex = 0;

        }
        protected void Cancelbtn_Click(object sender, EventArgs e)
        {
            Session["CurrentSession"] = null;
            Session["CurrentCourse"] = null;
            Session["CurrentClass"] = null;
            Session["CurrentMsg"] = null;
            divAdd.InnerHtml = "";
            sNo = Session["CurrentStudent"].ToString();
            sSelectedValue.Value = sNo;
            MultiAdd.ActiveViewIndex = 0;
        }


        private void UpdateConfirm(string sMsg, bool isError)
        {
            divConfirmation.Attributes.Remove("class");
            if (sMsg != "")
            {
                if (isError)
                {
                    divConfirmation.Attributes.Add("class", "Error");
                }
                else
                {
                    divConfirmation.Attributes.Add("class", "Confirm");
                }
                divConfirmation.InnerHtml = sMsg;
            }
        }
        private void UpdateConfirm()
        {
            divConfirmation.Attributes.Remove("class");
            divConfirmation.InnerHtml = "";
        }
        protected void crsSearch_Click(object sender, EventArgs e)
        {
            MultiAdd.ActiveViewIndex = 0;
            CTMDS.DataBind();
            grdCourses.DataBind();
            if (LibraryMOD.IsFileVerifiedFromRegistrar(sNo, Campus) == InitializeModule.FALSE_VALUE)
            {
                UpdateConfirm("Please contact the Registrar to verfiy student file.", true);
                return;
            }
        }

        private void ExportStudentTimeTable()
        {
            ReportDocument myReport = new ReportDocument();

            try
            {
                DataSet rptDS = new DataSet();

                rptDS = (DataSet)Session["ReportDS"];

                string reportPath = Server.MapPath("Reports/StudentTimeTable_eBooksRPT.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);

                int iSemester = Convert.ToInt32("0" + Session["RegSemester"].ToString());
                int iRegYear = Convert.ToInt32("0" + Session["RegYear"].ToString());

                TextObject txt;
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];

                txt.Text = GetCaption();
                txt.Text += "     -   Total Credit Hours: [ " + LibraryMOD.GetStudentRegisteredCredit(iRegYear, iSemester, sSelectedValue.Value, Convert.ToInt32((InitializeModule.EnumCampus)this.Campus)).ToString() + " ]";

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtMajor"];
                txt.Text = LibraryMOD.GetStudentMajor(this.Campus, sSelectedValue.Value);

                string sSemester = LibraryMOD.GetSemesterString(iSemester);

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtAcademicYear"];
                txt.Text += " - " + iRegYear.ToString() + " / " + (iRegYear + 1).ToString() + " " + sSemester;


                txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                string sUserName = Session["CurrentUserName"].ToString();
                txt.Text = "/ " + sUserName;


                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECT_StudentTimeTable");

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                myReport.Close();
                myReport.Dispose();
            }
        }
        private string GetCaption()
        {
            string sCaption = "";
            try
            {

                sCaption = this.sNo + " - " + this.sName;

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);                
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }

            return sCaption;
        }
        private DataSet Prepare_TimeTable_Report(List<TimeTable> myTimeTable)
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
                dc = new DataColumn("dFrom", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("dTo", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iLecturer", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sLecturer", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iDays", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDay", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sHall", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("seBookCode", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                int Serial = 0;
                for (int i = 0; i < myTimeTable.Count; i++)
                {
                    dr = dt.NewRow();
                    Serial += 1;
                    dr["iSerial"] = Serial;
                    dr["sPeriod"] = myTimeTable[i].SPeriod;
                    dr["sCourse"] = myTimeTable[i].SCourse;
                    dr["sDesc"] = myTimeTable[i].SDesc;
                    dr["iClass"] = myTimeTable[i].IClass;
                    //add Times
                    dr["sLecturer"] = myTimeTable[i].ClassTimes[0]._sLecturer;
                    dr["dFrom"] = myTimeTable[i].ClassTimes[0]._dFrom.ToShortTimeString();
                    dr["dTo"] = myTimeTable[i].ClassTimes[0]._dTo.ToShortTimeString();
                    dr["iDays"] = myTimeTable[i].ClassTimes[0]._iDays;
                    dr["sDay"] = myTimeTable[i].ClassTimes[0]._sDays + "  " + myTimeTable[i].ClassTimes[0]._sNotes;
                    dr["sHall"] = myTimeTable[i].ClassTimes[0]._sHall;
                    dr["seBookCode"] = myTimeTable[i].ClassTimes[0]._seBookCode;
                    dt.Rows.Add(dr);
                    //Collect Additional Times
                    for (int j = 1; j < myTimeTable[i].ClassTimes.Count; j++)
                    {
                        dr = dt.NewRow();
                        Serial += 1;
                        dr["iSerial"] = Serial;
                        dr["sPeriod"] = myTimeTable[i].SPeriod;
                        dr["sCourse"] = myTimeTable[i].SCourse;
                        dr["sDesc"] = myTimeTable[i].SDesc;
                        dr["iClass"] = myTimeTable[i].IClass;
                        dr["sLecturer"] = myTimeTable[i].ClassTimes[j]._sLecturer;
                        dr["dFrom"] = myTimeTable[i].ClassTimes[j]._dFrom.ToShortTimeString();
                        dr["dTo"] = myTimeTable[i].ClassTimes[j]._dTo.ToShortTimeString();
                        dr["iDays"] = myTimeTable[i].ClassTimes[j]._iDays;
                        dr["sDay"] = myTimeTable[i].ClassTimes[j]._sDays + "  " + myTimeTable[i].ClassTimes[j]._sNotes;
                        dr["sHall"] = myTimeTable[i].ClassTimes[j]._sHall;
                        dt.Rows.Add(dr);
                    }


                }
                dt.TableName = "StudentTimeTable";
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

        private void Retrieve()
        {
            List<TimeTable> myTimeTables = new List<TimeTable>();
            TimeTableDAL myTimeTableDAL = new TimeTableDAL();
            DataSet Ds = new DataSet();
            try
            {
                int iYear = iRegYear;
                int iSem = iRegSem;
                string sStudentNumber = this.sNo;

                myTimeTables = myTimeTableDAL.GetStudentTimeTable(sStudentNumber, iYear, iSem, this.Campus);
                Ds = Prepare_TimeTable_Report(myTimeTables);

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {

                Session["ReportDS"] = Ds;

            }

        }
        protected void PrintCMD_Click(object sender, EventArgs e)
        {
            Retrieve();
            ExportStudentTimeTable();
        }

        private bool isStudentHasAccount(string sID)
        {
            bool isIt = false;

            Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSql = "select strAccountNo  from Reg_Student_Accounts";
                sSql += " where lngStudentNumber='" + sID + "'";

                string sAccount = "";
                SqlCommand Cmd = new SqlCommand(sSql, Conn);
                SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    sAccount = reader["strAccountNo"].ToString();
                }

                reader.Close();

                isIt = !string.IsNullOrEmpty(sAccount);

            }
            catch (Exception ex)
            {

                LibraryMOD.ShowErrorMessage(ex);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return isIt;
        }

        private bool Enable_Disable(string sSNo, string sName)
        {
            bool isEnable = false;
            string sMSG = "";
            try
            {
                //20042020
                int iFinCat = 0;
                string sOAcc = "";
                iFinCat = LibraryMOD.getFinanceCategory(sSNo, out sOAcc);
                Session["CurrentFinCat"] = iFinCat;


                bool isFinance = (iFinCat > 1);
                bool isActive = true;
                int iStatus = 0;
                bool isFinanceSkip = false;
                bool isActiveSkip = false;
                bool isSkipStatus = false;

                bool flag1 = false, flag2 = false, flag3 = false;

                //bool isEnabled = false;

                //isFinance = LibraryMOD.isFinanceProblems(Campus, sSNo);
                isFinanceSkip = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                       InitializeModule.enumPrivilege.SkipStudentFinanceProblem, CurrentRole);
                isActive = LibraryMOD.isActiveStudent(Campus, sSNo);
                isActiveSkip = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
                       InitializeModule.enumPrivilege.SkipStudentActive, CurrentRole);
                iStatus = LibraryMOD.GetStudentStatus(Campus, sSNo);
                isSkipStatus = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Registration,
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

                if (iStatus != 0 && !isSkipStatus)
                {
                    flag3 = true;
                    sMSG += "<br />Student has Status and it Should be Removed first";
                }
                else if (iStatus != 0 && isSkipStatus)
                {
                    sMSG += "<br />Student has Status and you Skipped that...";
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
                    sMSG = "Student :" + sName + ", Holding ID :" + sNo + ", has the following problem(s)..." + sMSG;
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "errorSession", "$(function(){Sexy.error('" + sMSG + "'); });", true);                    
                    lbl_Msg.Text = sMSG;
                    div_msg.Visible = true;
                }
            }

            return isEnable;
        }
        protected void Terms_SelectedIndexChanged(object sender, EventArgs e)
        {
            iTerm = Convert.ToInt32(Terms.SelectedValue);
            iRegYear = LibraryMOD.SeperateTerm(iTerm, out iRegSem);
            Session["RegYear"] = iRegYear;
            Session["RegSemester"] = iRegSem;
            if (!string.IsNullOrEmpty(sNo) && !string.IsNullOrEmpty(sSelectedValue.Value))
            {
                Session["iFormNumber"] = this.CreateHeader();
            }
            grdCourses.DataBind();
            grdTimeTable.DataBind();

        }

        private void fill_Alt()
        {
            List<Courses> myCourses = new List<Courses>();
            CoursesDAL myCoursesDAL = new CoursesDAL();
            try
            {

                myCourses = myCoursesDAL.GetCourses(InitializeModule.EnumCampus.Males, " WHERE VOCCode IS NULL", true);
                for (int i = 0; i < myCourses.Count; i++)
                {
                    ddlAlt.Items.Add(new System.Web.UI.WebControls.ListItem(myCourses[i].strCourse, myCourses[i].strCourse));
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);               
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;

            }
            finally
            {
                myCourses.Clear();

            }

        }

        private void UpdateAlternative(bool isAdd, string sCourse, string sAlt)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(this.Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sUserName = Session["CurrentUserName"].ToString();
                string sNetUserName = Session["CurrentNetUserName"].ToString();
                string sSQL = "";
                if (isAdd)
                {
                    sSQL = "INSERT INTO Reg_Course_Alternative (intStudyYear,byteSemester,lngStudentNumber,strAlternative";
                    sSQL += ",strAlternativeTo,isGradeRegistered,strUserCreate,dateCreate,strNUser)";
                    sSQL += " VALUES(" + iRegYear + "," + iRegSem + ",'" + sSelectedValue.Value + "','" + sCourse + "'";
                    sSQL += ",'" + sAlt + "',0,'" + sUserName + "',GETDATE(),'" + sNetUserName + "')";
                }
                else
                {
                    sSQL = "Delete from Reg_Course_Alternative Where intStudyYear=" + iRegYear;
                    sSQL += " And byteSemester=" + iRegSem;
                    sSQL += " And lngStudentNumber='" + sSelectedValue.Value + "'";
                    sSQL += " And strAlternative='" + sCourse + "'";
                }
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                int iEffected = Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);                
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

            }

        }

        protected void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sSelectedValue.Value))
            {               
                lbl_Msg.Text = "Select female student please.";
                div_msg.Visible = true;
                return;
            }
            if (CopyDS.Insert() > 0)
            {                
                lbl_Msg.Text = "Female student copied or updated to Males and Campus changed to Males.";
                Session["CurrentCampus"] = InitializeModule.EnumCampus.Males;
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;
                btnCopy.Visible = false;
            }
        }
    }
}