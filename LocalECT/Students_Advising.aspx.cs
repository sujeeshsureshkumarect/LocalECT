using System;
using System.Collections;
using System.Configuration;
using System.Data;
////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Drawing;


namespace LocalECT
{
    public partial class Students_Advising : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        int CurrentRole = 0;
        List<MirrorCLS> myList = new List<MirrorCLS>();
        System.Web.UI.WebControls.Table MyGTable;
        System.Web.UI.WebControls.Table MyNewGTable = new System.Web.UI.WebControls.Table();
        System.Web.UI.WebControls.Table myTable;
        DataTable Suggesteddt = new DataTable();

        const int iCourseTypeCell = 0;
        const int iCourseCell = 1;
        const int iCreditsCell = 2;
        const int iGradeCell = 3;
        const int iPointsCell = 4;
        const int iSumCell = 5;



        //Event for the Search Control
        protected void Search1_ChangedEvent(object Sender, EventArgs e)
        {
            string sid = Request.QueryString["sid"];
            sSelectedValue.Value = sid;
            sSelectedText.Value = getstudentname(sid);
            Session["CurrentStudent"] = sSelectedValue.Value;
            Session["CurrentStudentName"] = sSelectedText.Value;

            lblSelectedStudent.Text = sSelectedValue.Value + " - " + sSelectedText.Value;

            string sNo = sSelectedValue.Value;

            bool isEnable = Enable_Disable(sNo);
            Print_btn.Enabled = isEnable;
            Run_btn.Enabled = isEnable;

            setStudentMajor(sSelectedValue.Value);

            if (rbnView.SelectedIndex == 1)
            {
                initCGPAData();
                lblCGPA.Text = String.Format("{0:0.00}", getCGPA());
            }

            Session["myAdvTable"] = null;
            divDetail.Controls.Clear();

            Suggesteddt.Rows.Clear();
            Session["Suggesteddt"] = Suggesteddt;
            grdSuggested.DataBind();


            divCRS.Visible = false;
            divDetail.Visible = true;
            rbnView.SelectedIndex = 0;
            MultiView1.ActiveViewIndex = rbnView.SelectedIndex;

            //Show recommended courses
            Get_Student_Advising();
            fill_Registered();
            Print_btn.Enabled = true;
            divCRS.Visible = false;
            divDetail.Visible = true;
            lngAdvisorComments.Visible = true;
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
            hdnDegree.Value = "";
            hdnMajor.Value = "";
            lblSelectedStudent.Text = "";
            if (Session["MyGTable"] != null)
            {
                MyGTable.Rows.Clear();
                Session["MyGTable"] = null;
            }

            if (Session["MyNewGTable"] != null)
            {
                MyNewGTable.Rows.Clear();
                Session["MyNewGTable"] = null;
            }

            lblCGPA.Text = "0.00";

            Session["myAdvTable"] = null;
            divDetail.Controls.Clear();

            Suggesteddt.Rows.Clear();
            Session["Suggesteddt"] = Suggesteddt;
            grdSuggested.DataBind();

            divCRS.Visible = false;
            divDetail.Visible = true;
            rbnView.SelectedIndex = 0;
            MultiView1.ActiveViewIndex = rbnView.SelectedIndex;
            lngAdvisorComments.Visible = true;
            SaveCMD.Enabled = true;
            txtComment.Enabled = true;
            txtStudentFeedback.Enabled = true;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Add Event Handler to the custom control
            //Search1.ChangedEvent += new Search.ChangedEventHandler(Search1_ChangedEvent);
            //Search1.NewEvent += new Search.ChangedEventHandler(Search1_NewEvent);


            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Advising,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }
                    if (Session["CurrentCampus"] != null)
                    {
                        string sCampus = Session["CurrentCampus"].ToString();
                        Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                        //Campus_ddl.SelectedValue = ((int)Campus).ToString();
                    }
                   
                }
            }
            else
            {
                Server.Transfer("Login.aspx");
            }
            //divMsg.InnerText = "";
            divConfirmation.InnerHtml = "";

            if (!IsPostBack)
            {
                //if (Session["CurrentCampus"] != null)
                //{
                //    string sCampus = Session["CurrentCampus"].ToString();
                //    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                //    //Campus_ddl.SelectedValue = ((int)Campus).ToString();
                //}
                FillTerms();
                Session["myList"] = null;

                int iYear = 0;
                int iSem = 0;
                iYear = (int)Session["RegYear"];
                iSem = (int)Session["RegSemester"];
                Term_ddl.SelectedValue = Convert.ToString((iYear * 10) + iSem);               
            }
            else
            {
                Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
            }


            //Search1.Campus = Campus;

            if (Session["myList"] != null)
            {

                myList = (List<MirrorCLS>)Session["myList"];
                //Enable_Disable(myList[0].Recommended.Count > 0);                
            }

            if (Session["MyGTable"] != null)
            {
                MyGTable = (System.Web.UI.WebControls.Table)Session["MyGTable"];
                setHandler();
                divGrades.Controls.Clear();
                divGrades.Controls.Add(MyGTable);

                if (Session["MyNewGTable"] != null)
                {
                    MyNewGTable = (System.Web.UI.WebControls.Table)Session["MyNewGTable"];
                    setNewHandler();
                    divNewGrades.Controls.Clear();
                    divNewGrades.Controls.Add(MyNewGTable);
                }
            }

            if (Session["myAdvTable"] != null)
            {
                myTable = (System.Web.UI.WebControls.Table)Session["myAdvTable"];
                setimg_ClickHandler();
                divDetail.Controls.Clear();
                divDetail.Controls.Add(myTable);
            }
            if (Session["Suggesteddt"] != null)
            {
                Suggesteddt = (DataTable)Session["Suggesteddt"];
                grdSuggested.DataSource = Suggesteddt;
                grdSuggested.DataBind();
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["selectedCampus"] != null)
                {
                    Get_Student_Advising();
                    fill_Registered();
                    Print_btn.Enabled = true;
                    divCRS.Visible = false;
                    divDetail.Visible = true;
                    lngAdvisorComments.Visible = true;
                }
                Search1_ChangedEvent(null, null);
            }


            //Run_btn.Visible = divDetail.Visible;
            //Print_btn.Visible = divDetail.Visible;
            //Term_ddl.Visible = divDetail.Visible;
            //Type_ddl.Visible = divDetail.Visible;
        }

        private void FillTerms()
        {
            List<Semesters> myTerms = new List<Semesters>();
            SemesterDAL myTermsDAL = new SemesterDAL();
            try
            {
                myTerms = myTermsDAL.GetTerms(InitializeModule.EnumCampus.ECTNew, "", false);
                for (int i = 0; i < myTerms.Count; i++)
                {
                    Term_ddl.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                    //Term2_ddl.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                }
                Term_ddl.SelectedIndex = 0;
                //Term2_ddl.SelectedIndex = 0;

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

        //Enable_Disable(iForm > 0 && DataStatus.Value != ((int)InitializeModule.enumModes.NewMode).ToString());

        private void Get_Student_Advising()
        {
            List<MirrorCLS> myMirror = new List<MirrorCLS>();
            Advising myAdvising = new Advising();
            Plans Plan = new Plans();
            myTable = new System.Web.UI.WebControls.Table();
            try
            {
                //myMirror[0].Recommended.Clear();
                int iYear = 0;
                int iSem = 0;
                int iCam = 0;
                if (Request.QueryString["selectedCampus"] != null)
                {
                    iCam = int.Parse(Request.QueryString["selectedCampus"].ToString());
                    if (iCam == 1 || iCam == 3)
                    {
                        iCam = 1;
                    }
                    else
                    {
                        iCam = 2;
                    }
                    Campus = (InitializeModule.EnumCampus)iCam;
                    Session["CurrentCampus"] = iCam;

                    //Campus_ddl.SelectedValue = iCam.ToString();

                    iYear = (int)Session["RegYear"];
                    iSem = (int)Session["RegSemester"];
                    Term_ddl.SelectedValue = Convert.ToString((iYear * 10) + iSem);
                    Term_ddl.Focus();
                    rbnView.Focus();
                }
                else
                {
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    iYear = LibraryMOD.SeperateTerm(int.Parse(Term_ddl.SelectedValue), out iSem);
                }

                string sNo = "";
                string sName = "";
                if (Session["CurrentStudent"] != null)
                {
                    sNo = Session["CurrentStudent"].ToString();
                    sName = Session["CurrentStudentName"].ToString();
                    sSelectedValue.Value = sNo;
                    sSelectedText.Value = sName;
                    //Session["CurrentCampus"] = Convert.ToInt32(Campus);
                    Session["CurrentCampus"] = Campus;
                }
                else
                {
                    sNo = sSelectedValue.Value;
                }

                lblSelectedStudent.Text = sSelectedValue.Value + " - " + sSelectedText.Value;

                bool isHidden = LibraryMOD.isGradesHidden(Campus);
                bool isRecIncluded = true;// (Type_ddl.SelectedIndex == 0);
                myMirror = myAdvising.GetAdvising(sNo, isRecIncluded, iYear, iSem, true, isHidden, out Plan, Campus);
                int iRec = myMirror[0].Recommended.Count;
                if (iRec > 0)
                {
                    lblCourse.Text = myMirror[0].Recommended[0].sCourse;
                }
                //string sPath = "";
                //string sTable = "";

                //int iCourses = myMirror[0].Mirror.GetUpperBound(0) + 1;
                //sTable = Get_Table(myMirror[0]);
                //Detail_lit.Text = sTable;
                myTable = Create_Table(myMirror[0]);
                divDetail.Controls.Clear();
                divDetail.Controls.Add(myTable);
                //Session["myAdvTable"] = myTable;

                Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);

                SqlDataSourceAdvisorsComments.ConnectionString = myConnection_String.Conn_string;

                string sSQL = "";

                sSQL = "SELECT AA.AcademicAdvisingID, AA.StudentID, SD.strLastDescEn AS StudentName";
                sSQL += ", AA.AdvisorID, L.LecturerNameEn AS AdvisorName, AA.AdvisorComments";
                sSQL += ", AA.AcademicYear, AA.Semester,AA.StudentComments";
                sSQL += ", S.sTerm,AA.CreationDate, AA.CurrentCGPA";
                sSQL += " FROM dbo.Reg_Students_Data AS SD INNER JOIN";
                sSQL += " dbo.Reg_Applications AS A ON SD.lngSerial = A.lngSerial INNER JOIN";
                sSQL += " dbo.Reg_AcademicAdvising AS AA ON A.lngStudentNumber = AA.StudentID INNER JOIN";
                sSQL += " LOCALECT.ECTDataNew.dbo.Reg_Semester AS S ON AA.AcademicYear = S.AcademicYear ";
                sSQL += " AND AA.Semester = S.Semester INNER JOIN";
                sSQL += " LOCALECT.ECTDataNew.dbo.Reg_Lecturers AS L ON AA.AdvisorID = L.LecturerID";
                sSQL += " WHERE (AA.StudentID ='" + sNo + "')";

                SqlDataSourceAdvisorsComments.SelectCommand = sSQL;
                SqlDataSourceAdvisorsComments.DataBind();
                grdAdvisorsComments.DataBind();
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
                myList = myMirror;
                Session["myList"] = myMirror;
                Session["myPlan"] = Plan;
                Session["myAdvTable"] = myTable;
                //Enable_Disable(myMirror[0].Recommended.Count > 0);
                //myMirror.Clear();
                //myList.Clear();

            }

        }

        private string Get_Table(MirrorCLS myMirror)
        {
            string sTable = "";
            try
            {
                string sPath = "";
                int iCourses = myMirror.Mirror.GetUpperBound(0) + 1;

                sTable += "<table style='width:100%'>";
                sTable += "<tr>";
                sTable += "<th>";
                sTable += sSelectedValue.Value + " | " + sSelectedText.Value;
                sTable += "</th>";
                sTable += "</tr>";

                ///////////////////////////Data
                sTable += "<tr>";
                sTable += "<th>";
                sTable += "CGPA : " + string.Format("{0:f}", myMirror.CGPA);
                sTable += "</th>";
                sTable += "</tr>";

                sTable += "<tr>";
                sTable += "<th>";
                sTable += "ENG : " + myMirror.ENG + " | Score : " + string.Format("{0:f}", myMirror.Score);
                sTable += "</th>";
                sTable += "</tr>";
                ///////////////////////////end Data

                ///////////////////////////General

                sTable += "<tr>";
                sTable += "<th>";
                sTable += "Student Mirror";
                sTable += "</th>";
                sTable += "</tr>";

                sTable += "<tr>";
                sTable += "<th>";
                sTable += "General Courses";
                sTable += "</th>";
                sTable += "</tr>";

                sTable += "<tr>";
                sTable += "<td>";

                sTable += "<table align='left' border='1' >";
                sTable += "<tr>";
                for (int i = 0; i < 9; i++)
                {
                    sPath = "Images/Majors/GIF/" + myMirror.Mirror[i].sCourse + ".gif";
                    sTable += "<td><img alt='' src='" + sPath + "' /></td>";
                }
                sTable += "</tr>";
                sTable += "<tr>";
                for (int i = 0; i < 9; i++)
                {

                    if (myMirror.Mirror[i].isRecommended)
                    {
                        sTable += "<td bgcolor='#CC3300'>" + myMirror.Mirror[i].sGrade + "</td>";
                    }
                    else
                    {
                        sTable += "<td>" + myMirror.Mirror[i].sGrade + "</td>";
                    }
                }
                sTable += "</tr>";
                sTable += "</table>";

                sTable += "</td>";
                sTable += "</tr>";
                ///////////////////////////end General

                ///////////////////////////Program
                sTable += "<tr>";
                sTable += "<th>";
                sTable += "Program Courses";
                sTable += "</th>";
                sTable += "</tr>";


                sTable += "<tr>";
                sTable += "<td>";

                sTable += "<table align='left' border='1'>";
                sTable += "<tr>";
                if (iCourses > 50) iCourses = 50;
                for (int i = 9; i < iCourses; i++)
                {
                    sPath = "Images/Majors/GIF/" + myMirror.Mirror[i].sCourse + ".gif";
                    sTable += "<td><img alt='' src='" + sPath + "' /></td>";
                }
                sTable += "</tr>";
                sTable += "<tr>";

                for (int i = 9; i < iCourses; i++)
                {

                    if (myMirror.Mirror[i].isRecommended)
                    {
                        sTable += "<td bgcolor='#CC3300'>" + myMirror.Mirror[i].sGrade + "</td>";
                    }
                    else
                    {
                        sTable += "<td>" + myMirror.Mirror[i].sGrade + "</td>";
                    }
                }
                sTable += "</tr>";
                sTable += "</table>";

                sTable += "</td>";
                sTable += "</tr>";
                ///////////////////////////end Program
                MirrorDAL myMirrorDAL = new MirrorDAL();

                string MElective = myMirrorDAL.GetMajorElectiveCourses(myMirror.StudentNumber, Campus);
                string FElective = myMirrorDAL.GetFreeElectiveCourses(myMirror.StudentNumber, Campus);
                if (MElective.Length > 0 || FElective.Length > 0)
                {
                    sTable += "<tr>";
                    sTable += "<th>";
                }

                if (MElective.Length > 0)
                {
                    sTable += "Major Electives: " + "[ " + MElective + " ]";
                }

                if (FElective.Length > 0)
                {
                    if (MElective.Length > 0)
                    {
                        sTable += " --- ";
                    }
                    sTable += "Free Electives [" + FElective + " ]";
                }

                if (MElective.Length > 0 || FElective.Length > 0)
                {
                    sTable += "</th>";
                    sTable += "</tr>";
                }

                ///////////////////////////Recommended
                bool isRecIncluded = (Type_ddl.SelectedIndex == 0);
                if (isRecIncluded)
                {
                    sTable += "<tr>";
                    sTable += "<th>";
                    sTable += "Recommended Courses";
                    sTable += "</th>";
                    sTable += "</tr>";

                    sTable += "<tr>";
                    sTable += "<td>";

                    sTable += "<table align='left' border='1'>";
                    sTable += "<tr>";

                    for (int i = 0; i < myMirror.Recommended.Count; i++)
                    {
                        sPath = "Images/Majors/GIF/" + myMirror.Recommended[i].sCourse + ".gif";
                        sTable += "<td><img alt='' src='" + sPath + "' /></td>";
                    }
                    sTable += "</tr>";

                    sTable += "</table>";

                    sTable += "</td>";
                    sTable += "</tr>";
                    ///////////////////////////end Recommended
                }


                sTable += "<tr>";
                sTable += "<td>";
                sTable += "<hr />";
                sTable += "</td>";
                sTable += "</tr>";
                sTable += "</table>";
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
            return sTable;

        }

        protected void Run_btn_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Advising,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
            {
                Server.Transfer("Authorization.aspx");

            }

            if (int.Parse(Term_ddl.SelectedValue) == 0)
            {
                //divMsg.InnerText = "Select term please ...";
                lbl_Msg.Text = "Select term please ...";
                div_msg.Visible = true;

                return; ;
            }

            if (string.IsNullOrEmpty(sSelectedValue.Value))
            {
                //divMsg.InnerText = "Select student please ...";
                lbl_Msg.Text = "Select student please ...";
                div_msg.Visible = true;
                return;
            }

            Get_Student_Advising();
            fill_Registered();
            Print_btn.Enabled = true;
            divCRS.Visible = false;
            divDetail.Visible = true;
            lngAdvisorComments.Visible = true;
        }

        private void Enable_Disable(bool isEnabled)
        {
            try
            {
                //Print_btn.ImageUrl = LibraryMOD.GetButtonImageURL(InitializeModule.ECT_Buttons.Print, isEnabled);
                //Reg_btn.ImageUrl = LibraryMOD.GetButtonImageURL(InitializeModule.ECT_Buttons.Setting, isEnabled);
                Print_btn.Enabled = isEnabled;
                //Reg_btn.Enabled = isEnabled;
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

        private System.Web.UI.WebControls.Table Create_Table(MirrorCLS myMirror)
        {
            System.Web.UI.WebControls.Table MyTable = new System.Web.UI.WebControls.Table();

            try
            {
                myList.Add(myMirror);
                //First Row
                MyTable.Width = Unit.Percentage(100);
                MyTable.BorderWidth = 1;
                MyTable.GridLines = GridLines.Horizontal;

                TableHeaderRow Hr = new TableHeaderRow();
                TableHeaderCell Hc = new TableHeaderCell();
                Hc.ColumnSpan = 4;
                Hc.Text = "Student Info";
                Hr.Cells.Add(Hc);
                MyTable.Rows.Add(Hr);//0

                //Second Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "Major : ";
                Hr.Cells.Add(Hc);

                Hc = new TableHeaderCell();
                Hc.ColumnSpan = 3;
                Hc.Text = myMirror.Major;
                Hr.Cells.Add(Hc);

                MyTable.Rows.Add(Hr);//1

                //Third Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "CGPA : ";
                Hr.Cells.Add(Hc);

                Hc = new TableHeaderCell();
                Hc.Text = string.Format("{0:F}", myMirror.CGPA);
                Hr.Cells.Add(Hc);

                Hc = new TableHeaderCell();
                Hc.Text = "Advisor : ";
                Hr.Cells.Add(Hc);

                Hc = new TableHeaderCell();
                //Get Max Esl

                //for (int i = 0; i < 5; i++)
                //{
                //    if (myMirror.Mirror[i].isPassed)
                //    {
                //        Hc.Text = myMirror.Mirror[i].sCourse;
                //        myList[0].MaxESL = i;
                //    }

                //}
                Hc.Text = myMirror.Advisor;
                Hr.Cells.Add(Hc);

                MyTable.Rows.Add(Hr);//2

                //Fourth Row
                Hr = new TableHeaderRow();

                Hc = new TableHeaderCell();
                Hc.Text = "ENG : ";
                Hr.Cells.Add(Hc);

                Hc = new TableHeaderCell();
                Hc.Text = myMirror.ENG;
                Hr.Cells.Add(Hc);

                Hc = new TableHeaderCell();
                Hc.Text = "Score : ";
                Hr.Cells.Add(Hc);

                Hc = new TableHeaderCell();

                Hc.Text = string.Format("{0:F}", myMirror.Score); ;

                Hr.Cells.Add(Hc);

                MyTable.Rows.Add(Hr);//3

                //Fifth
                Hr = new TableHeaderRow();
                Hc = new TableHeaderCell();
                Hc.ColumnSpan = 4;
                Hc.Text = "Student Mirror";
                Hr.Cells.Add(Hc);
                MyTable.Rows.Add(Hr);//4

                //Sixth
                Hr = new TableHeaderRow();
                Hc = new TableHeaderCell();
                Hc.ColumnSpan = 4;
                Hc.Text = "General Courses";
                Hr.Cells.Add(Hc);
                MyTable.Rows.Add(Hr);//5


                //Seventh
                TableRow Tr = new TableRow();
                TableCell Tc = new TableCell();
                Tc.ColumnSpan = 4;

                System.Web.UI.WebControls.Table GenCrsTable = new System.Web.UI.WebControls.Table();
                //GenCrsTable.Width = Unit.Percentage(100);
                GenCrsTable.CellPadding = 0;
                GenCrsTable.CellSpacing = 0;
                GenCrsTable.BorderWidth = 1;
                GenCrsTable.GridLines = GridLines.Both;

                int iMax = 0;
                string sDegree = myMirror.SDegree;
                string sMajor = myMirror.SMajor;
                //Get the count of general courses
                iMax = LibraryMOD.GetMajorGeneralIndex(sDegree, sMajor);

                TableRow GenTr = new TableRow();
                TableCell GenTc = new TableCell();
                ImageButton Crsimg = new ImageButton();

                for (int i = 0; i < iMax; i++)
                {
                    GenTc = new TableCell();
                    Crsimg = new ImageButton();
                    Crsimg.ImageUrl = "Images/Majors/GIF/" + myMirror.Mirror[i].sCourse + ".gif";
                    Crsimg.ID = myMirror.Mirror[i].sCourse;
                    Crsimg.Click += new ImageClickEventHandler(Crsimg_Click);
                    Crsimg.ToolTip = "Click to show (" + Crsimg.ID + ") availabe classes";
                    GenTc.Controls.Add(Crsimg);
                    GenTr.Cells.Add(GenTc);
                }

                GenCrsTable.Rows.Add(GenTr);

                //Eighth
                GenTr = new TableRow();


                Label Crslbl = new Label();
                for (int i = 0; i < iMax; i++)
                {
                    Crslbl = new Label();
                    //Crslbl.Width = 30;
                    Crslbl.Width = Unit.Percentage(100);
                    if (myMirror.Mirror[i].isRecommended)
                    {
                        Crslbl.BackColor = Color.OrangeRed;
                    }
                    Crslbl.Text = myMirror.Mirror[i].sGrade;
                    GenTc = new TableCell();
                    GenTc.Controls.Add(Crslbl);
                    GenTr.Cells.Add(GenTc);
                }
                GenCrsTable.Rows.Add(GenTr);
                Tc.Controls.Add(GenCrsTable);

                Tr.Cells.Add(Tc);

                MyTable.Rows.Add(Tr);//6

                //Ninght
                Hr = new TableHeaderRow();
                Hc = new TableHeaderCell();
                Hc.ColumnSpan = 4;
                Hc.Text = "Other Courses";
                Hr.Cells.Add(Hc);
                MyTable.Rows.Add(Hr);//7


                //Tenth
                Tr = new TableRow();
                Tc = new TableCell();
                Tc.ColumnSpan = 4;

                int iCourses = 0;
                iCourses = myMirror.Mirror.Length;

                System.Web.UI.WebControls.Table OtherCrsTable = new System.Web.UI.WebControls.Table();
                //OtherCrsTable.Width = Unit.Percentage(100);
                OtherCrsTable.CellPadding = 0;
                OtherCrsTable.CellSpacing = 0;
                OtherCrsTable.BorderWidth = 1;
                OtherCrsTable.GridLines = GridLines.Both;

                TableRow OtherTr = new TableRow();
                TableCell OtherTc = new TableCell();


                if (iCourses > 50) iCourses = 50;

                for (int i = iMax; i < iCourses; i++)
                {
                    OtherTc = new TableCell();
                    Crsimg = new ImageButton();
                    Crsimg.ImageUrl = "Images/Majors/GIF/" + myMirror.Mirror[i].sCourse + ".gif";
                    Crsimg.ID = myMirror.Mirror[i].sCourse;
                    Crsimg.Click += new ImageClickEventHandler(Crsimg_Click);
                    Crsimg.ToolTip = "Click to show (" + Crsimg.ID + ") availabe classes";
                    OtherTc.Controls.Add(Crsimg);
                    OtherTr.Cells.Add(OtherTc);
                }

                OtherCrsTable.Rows.Add(OtherTr);
                OtherTr = new TableRow();


                Crslbl = new Label();
                for (int i = iMax; i < iCourses; i++)
                {
                    Crslbl = new Label();
                    Crslbl.Width = Unit.Percentage(100);
                    if (myMirror.Mirror[i].isRecommended)
                    {
                        Crslbl.BackColor = Color.OrangeRed;
                    }
                    Crslbl.Text = myMirror.Mirror[i].sGrade;
                    OtherTc = new TableCell();
                    OtherTc.Controls.Add(Crslbl);
                    OtherTr.Cells.Add(OtherTc);
                }
                OtherCrsTable.Rows.Add(OtherTr);
                Tc.Controls.Add(OtherCrsTable);

                Tr.Cells.Add(Tc);

                MyTable.Rows.Add(Tr);//8

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

                int iCompletedHours = LibraryMOD.GetCompletedHours(myMirror.StudentNumber, Campus);

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
                        Tc.HorizontalAlign = HorizontalAlign.Center;
                        Tr.Cells.Add(Tc);

                        MyTable.Rows.Add(Tr);
                    }
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
            }
            return MyTable;
        }

        private void Export()
        {
            ReportDocument myReport = new ReportDocument();
            List<Programs_Advisors> myAdvisors = new List<Programs_Advisors>();
            Programs_AdvisorsDAL myAdvisorsDAL = new Programs_AdvisorsDAL();
            RecommendationDAL myRecommendationDAL = new RecommendationDAL();
            try
            {
                MirrorCLS myMirror = new MirrorCLS();
                MirrorDAL myMirrorDAL = new MirrorDAL();

                myMirror = myList[0];

                DataSet rptDS = new DataSet();
                string reportPath = "";

                //if ( myMirror.SDegree == Convert.ToInt32 (InitializeModule.EnumDegree.Bachelor).ToString ())
                //{

                //   reportPath=Server.MapPath("Reports/Recommended_Report2.rpt");
                //}
                //else
                //{
                //   reportPath = Server.MapPath("Reports/Recommended_Report.rpt");      
                //}
                reportPath = Server.MapPath("Reports/Recommended_Report3.rpt");

                switch (Type_ddl.SelectedIndex)
                {
                    case 0://Registration
                        rptDS = myRecommendationDAL.Prepare_RecommendationReport(myMirror);
                        break;
                    case 1://Add and Drop
                        rptDS = Prepare_Add_Drop_Report();
                        reportPath = Server.MapPath("Reports/Recommended_Add_Drop_Report.rpt");
                        break;
                    case 2://Empty
                        rptDS = myRecommendationDAL.Prepare_RecommendationReport(myMirror);
                        break;



                }

                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);


                TextObject txt;

                //if (myMirror.SDegree != "3")
                //{
                int iCount = myMirror.Mirror.Length;
                if (iCount > 60) iCount = 60;
                for (int i = 0; i < 60; i++)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["h" + (i + 1).ToString()];
                    txt.Text = "";
                    txt.Color = Color.White;
                    txt.Color = Color.White;
                    txt.Border.BorderColor = Color.White;
                    txt.Border.BackgroundColor = Color.White;
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["g" + (i + 1).ToString()];
                    txt.Text = "";
                    txt.Color = Color.White;
                    txt.Border.BorderColor = Color.White;
                    txt.Border.BackgroundColor = Color.White;
                }

                for (int i = 0; i < iCount; i++)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["h" + (i + 1).ToString()];
                    txt.Text = myMirror.Mirror[i].sCourse;
                    switch (myMirror.Mirror[i].iClass)
                    {
                        case 9://MEelect
                            txt.Text = myMirror.Mirror[i].sCourse + "*";
                            break;
                        case 11://CEelect
                            txt.Text = myMirror.Mirror[i].sCourse + "#";
                            break;
                    }


                    txt.Color = Color.Black;
                    txt.Border.BorderColor = Color.Black;
                    txt.Border.BackgroundColor = Color.Silver;
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["g" + (i + 1).ToString()];
                    txt.Text = myMirror.Mirror[i].sGrade;
                    txt.Color = Color.Black;
                    txt.Border.BorderColor = Color.Black;
                    txt.Border.BackgroundColor = Color.White;
                }
                //}

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Major_txt"];
                txt.Text = myMirror.Major;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["cgpa_txt"];
                txt.Text = string.Format("{0:f}", myMirror.CGPA);

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["esl_txt"];
                txt.Text = myMirror.Mirror[myMirror.MaxESL].sCourse;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["eng_txt"];
                txt.Text = myMirror.ENG;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["score_txt"];
                txt.Text = string.Format("{0:f}", myMirror.Score);

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Major_Free_Elective_txt"];
                string MElective = myMirrorDAL.GetMajorElectiveCourses(myMirror.StudentNumber, Campus);
                string FElective = myMirrorDAL.GetFreeElectiveCourses(myMirror.StudentNumber, Campus);
                txt.Text = "";
                if (MElective.Length > 0)
                {
                    txt.Text += "Major Electives: " + "[ " + MElective + " ]";

                }
                if (FElective.Length > 0)
                {
                    if (MElective.Length > 0)
                    {
                        txt.Text += " --- ";
                    }
                    txt.Text += "Free Electives [" + FElective + " ]";
                }

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Session_txt"];
                txt.Text = myMirror.Period;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Term_txt"];
                txt.Text = Term_ddl.SelectedItem.Text;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Advisor_txt"];
                txt.Text = myMirror.Advisor;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];

                txt.Text = myMirror.StudentNumber.Replace(".", "") + " - " + myMirror.Name;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                string sUserName = Session["CurrentUserName"].ToString();
                txt.Text = sUserName;

                //Previous Semester

                int iRegYear = int.Parse(Session["RegYear"].ToString());
                int iRegSem = int.Parse(Session["RegSemester"].ToString());

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtregisteredCourseInPrevSem"];
                if (iRegSem == 4)
                {
                    int iRegCoursesPrevSem = 0;
                    iRegCoursesPrevSem = LibraryMOD.GetRegCoursesPrevSem(myMirror.StudentNumber, iRegYear, iRegSem, Campus);

                    txt.Text = "Previous Semester Courses : " + iRegCoursesPrevSem.ToString();
                }
                else
                {
                    txt.Text = "";
                    txt.Width = 0;
                }


                //coordinator_txt

                //advisors_txt

                string sCoordinator = "";
                string sAdvisors = "";
                string sDegree = "";
                string sMajor = "";
                List<Applications> myStudent = new List<Applications>();
                ApplicationsDAL myApplicationsDAL = new ApplicationsDAL();
                myStudent = myApplicationsDAL.GetList(Campus, " lngStudentNumber='" + myMirror.StudentNumber + "'", false);
                if (myStudent.Count > 0)
                {
                    sMajor = myStudent[0].strSpecialization;
                    sDegree = myStudent[0].strDegree;
                }
                myStudent.Clear();

                myAdvisors = myAdvisorsDAL.GetPrograms_Advisors(Campus, sDegree, sMajor);
                for (int i = 0; i < myAdvisors.Count; i++)
                {
                    if (myAdvisors[i].byteCategory == 1)
                    {
                        sCoordinator += myAdvisors[i].SAdvisor;
                    }
                    else
                    {
                        sAdvisors += myAdvisors[i].SAdvisor + ",";
                    }

                }

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["coordinator_txt"];
                txt.Text = sCoordinator;
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["advisors_txt"];
                txt.Text = sAdvisors;

                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");

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
                myAdvisors.Clear();
                myReport.Close();
                myReport.Dispose();
            }
        }

        protected void Print_btn_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Advising,
                    InitializeModule.enumPrivilege.Print, CurrentRole) != true)
            {
                Server.Transfer("Authorization.aspx");

            }
            Export();
        }
        //protected void Reg_btn_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Advising,
        //            InitializeModule.enumPrivilege.Print, CurrentRole) != true)
        //    {
        //        Server.Transfer("Authorization.aspx");

        //    }

        //    string sStudentNumber = "";
        //    bool isHeaderExists = false;

        //    if (Session["myList"] != null)
        //    {
        //        List<MirrorCLS> myList = (List<MirrorCLS>)Session["myList"];
        //        sStudentNumber = myList[0].StudentNumber;
        //    }
        //    else
        //    {
        //        divMsg.InnerText = "Mirror list is empty.";
        //    }

        //        int iYear = 0;
        //        int iSemester = 0;

        //        int iFormNumber = 0;
        //        int iTerm = int.Parse(Term_ddl.SelectedValue);

        //        iYear = LibraryMOD.SeperateTerm(iTerm, out iSemester);
        //        Course_HeaderDAL myCourseHeader = new Course_HeaderDAL();
        //        iFormNumber = myCourseHeader.IsHeaderExists(this.Campus, iYear, iSemester, 1, sStudentNumber);

        //    if (iFormNumber == -1)
        //    {
        //        Connection_StringCLS MyConnection_string = new Connection_StringCLS(this.Campus);
        //        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
        //        Conn.Open();
        //        iFormNumber = LibraryMOD.GetMaxID(Conn, "intFormNumber", "Reg_Course_Header", "intStudyYear=" + iYear + " AND byteSemester=" + iSemester + " AND byteForm=1");
        //        iFormNumber++;
        //        Conn.Close();

        //        int iMode = (int)InitializeModule.enumModes.NewMode;
        //        string sPCName = System.Net.Dns.GetHostName();
        //        string sUserName = Session["CurrentUserName"].ToString();
        //        string sNetUserName = HttpContext.Current.User.Identity.Name;

        //        int iSuccess = myCourseHeader.UpdateCourse_Header(this.Campus, iMode, iYear, iSemester, 1, iFormNumber, sStudentNumber, DateTime.Now, 0, 0, 0, "", 0, "", DateTime.Now, "", "", DateTime.Now, sUserName, DateTime.Now, sPCName, sNetUserName);

        //    }

        //    Response.Redirect("StudentsCoursesRegistration.aspx?iFormNumber=" + iFormNumber + "&iYear=" + iYear + "&iSemester=" + iSemester);

        //}
        private DataSet Prepare_Add_Drop_Report()
        {

            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            int iYear = 0;
            int iSem = 0;
            List<TimeTable> myTimeTables = new List<TimeTable>();
            TimeTableDAL myTimeTableDAL = new TimeTableDAL();

            try
            {
                string sNo = sSelectedValue.Value;
                Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                iYear = LibraryMOD.SeperateTerm(int.Parse(Term_ddl.SelectedValue), out iSem);

                myTimeTables = myTimeTableDAL.GetStudentTimeTable(sNo, iYear, iSem, Campus);

                DataColumn dc;

                dc = new DataColumn("iOrder", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCourse", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDesc", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("bShift", Type.GetType("System.Int16"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sTimeFrom", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sTimeTo", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDays", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("bClass", Type.GetType("System.Int16"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sLecturer", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                for (int i = 0; i < myTimeTables.Count; i++)
                {
                    for (int iTimesIndex = 0; iTimesIndex < myTimeTables[i].ClassTimes.Count; iTimesIndex++)
                    {
                        dr = dt.NewRow();

                        dr["iOrder"] = i + 1;

                        dr["sCourse"] = myTimeTables[i].SCourse;
                        dr["sDesc"] = myTimeTables[i].SDesc;
                        dr["bShift"] = myTimeTables[i].IPeriod;

                        dr["sTimeFrom"] = myTimeTables[i].ClassTimes[iTimesIndex]._dFrom.ToShortTimeString();
                        dr["sTimeTo"] = myTimeTables[i].ClassTimes[iTimesIndex]._dTo.ToShortTimeString();
                        dr["sDays"] = myTimeTables[i].ClassTimes[iTimesIndex]._sDays;

                        dr["bClass"] = myTimeTables[i].IClass;
                        dr["sLecturer"] = ".";

                        dt.Rows.Add(dr);
                    }
                }
                ////Add 3 Empty Rows
                //for (int i = iRecommended; i < iRecommended + 2; i++)
                //{
                //    dr = dt.NewRow();

                //    dr["iOrder"] = i + 1;
                //    dr["sCourse"] = "-";
                //    dr["sDesc"] = "-";
                //    dr["bShift"] = 0;
                //    dr["sTimeFrom"] = ".";
                //    dr["sTimeTo"] = ".";
                //    dr["sDays"] = ".";
                //    dr["bClass"] = 0;
                //    dr["sLecturer"] = ".";

                //    dt.Rows.Add(dr);
                //    //Collect Additional Times
                //}
                dt.TableName = "Recommended";
                dt.AcceptChanges();
                ds.Tables.Add(dt);

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                myTimeTables.Clear();
            }
            return ds;
        }

        private bool Enable_Disable(string sSNo)
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
                isFinanceSkip = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Advising,
                       InitializeModule.enumPrivilege.SkipStudentFinanceProblem, CurrentRole);
                isActive = LibraryMOD.isActiveStudent(Campus, sSNo);
                isActiveSkip = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Advising,
                       InitializeModule.enumPrivilege.SkipStudentActive, CurrentRole);
                iStatus = LibraryMOD.GetStudentStatus(Campus, sSNo);
                isSkipStatus = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Advising,
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "errorSession", "$(function(){Sexy.error('" + sMSG + "'); });", true);
                    //divMsg.InnerHtml = sMSG;
                    lbl_Msg.Text = sMSG;
                    div_msg.Visible = true;

                }
            }

            return isEnable;
        }

        protected void rbnView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sSelectedValue.Value))
            {
                //divMsg.InnerText = "Select student please ...";
                lbl_Msg.Text = "Select student please ...";
                div_msg.Visible = true;

                return;
            }
            MultiView1.ActiveViewIndex = rbnView.SelectedIndex;
            if (rbnView.SelectedIndex == 1)
            {
                initCGPAData();
                lblCGPA.Text = String.Format("{0:0.00}", getCGPA());
                txtOldCGPA.Text = String.Format("{0:0.00}", GetCGPA(sSelectedValue.Value));
            }

        }
        private DataSet GetRegCourses()
        {
            DataSet ds_RegCourses = new DataSet();

            try
            {
                string strStudentNo = sSelectedValue.Value;
                int intStudyYear = Convert.ToInt32(Session["CurrentYear"]);
                int byteSemester = Convert.ToInt32(Session["CurrentSemester"]);

                int iRegYear = int.Parse(Session["RegYear"].ToString());
                int iRegSem = int.Parse(Session["RegSemester"].ToString());

                string sSQLReg = "SELECT iYear, Sem";
                sSQLReg += ", Student, Course";
                sSQLReg += " FROM dbo.Course_Balance_View";
                sSQLReg += " WHERE (iYear = " + intStudyYear + ")";
                sSQLReg += " AND (Sem = " + byteSemester + ")";
                sSQLReg += " AND (Student = '" + strStudentNo + "')";
                sSQLReg += " UNION";
                sSQLReg += " SELECT iYear, Sem, Student, Course";
                sSQLReg += " FROM dbo.Course_Balance_View";
                sSQLReg += " WHERE (iYear = " + iRegYear + ")";
                sSQLReg += " AND (Sem = " + iRegSem + ")";
                sSQLReg += " AND (Student = '" + strStudentNo + "')";

                if (sSelectedValue.Value == "") { return ds_RegCourses; }
                Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
                SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
                Conn.Open();

                SqlCommand cmd;
                SqlDataAdapter adptr;

                Conn = new SqlConnection(myConnection_String.Conn_string);
                Conn.Open();

                cmd = new SqlCommand(sSQLReg, Conn);
                adptr = new SqlDataAdapter();

                cmd.CommandType = CommandType.Text;
                adptr.SelectCommand = cmd;
                adptr.Fill(ds_RegCourses, "RegCourses");
                Conn.Close();

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;

            }
            return ds_RegCourses;
        }


        private void AddRecommendedCourses(DataSet dsRegCourses)
        {
            List<MirrorCLS> myMirror = new List<MirrorCLS>();
            Advising myAdvising = new Advising();
            Plans Plan = new Plans();
            try
            {
                Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                string sNo = sSelectedValue.Value;
                int iYear = 0;
                int iSem = 0;
                iYear = LibraryMOD.SeperateTerm(int.Parse(Term_ddl.SelectedValue), out iSem);
                bool isHidden = LibraryMOD.isGradesHidden(Campus);
                bool isRecIncluded = true;// (Type_ddl.SelectedIndex == 0);
                myMirror = myAdvising.GetAdvising(sNo, isRecIncluded, iYear, iSem, true, isHidden, out Plan, Campus);
                int iRec = myMirror[0].Recommended.Count;

                TableRow Tr = new TableRow();
                TableCell Td = new TableCell();
                Td.HorizontalAlign = HorizontalAlign.Center;
                Label lbl = new Label();
                double dCredits = 0;
                double dPoints = 0;
                double dSum = 0;
                DropDownList ddl = new DropDownList();
                TextBox txt = new TextBox();
                HiddenField hdn = new HiddenField();

                int iRow = 0;
                iRow = MyNewGTable.Rows.Count;
                int iCompletedHours = LibraryMOD.GetCompletedHours(sNo, Campus);
                string sCourse = "";
                for (int i = 0; i < iRec; i++)
                {
                    sCourse = myMirror[0].Recommended[i].sCourse;
                    DataRow[] drAry = null;
                    drAry = dsRegCourses.Tables["RegCourses"].Select("Course='" + sCourse + "'");
                    if ((iCompletedHours < 99 && sCourse.Contains("415") && sCourse != "RTV415") || (iCompletedHours < 99 && sCourse.Contains("419")))
                    {
                        //dont add Internship & graduation project in completed hours less than 99 credit hours
                    }
                    else
                    {
                        if (drAry.Length <= 0)
                        //if (myMirror[0].Mirror[i].isPassed) // exclude registered courses
                        {
                            //Course Type
                            lbl.ID = "lblNCourseType" + iRow;
                            lbl.Text = "Recommended";
                            Td.Controls.Add(lbl);
                            Tr.Cells.Add(Td);
                            //Course
                            lbl = new Label();
                            Td = new TableCell();
                            Td.HorizontalAlign = HorizontalAlign.Center;
                            lbl.ID = "lblNCourse" + iRow;
                            lbl.Text = sCourse;


                            Td.Controls.Add(lbl);
                            Tr.Cells.Add(Td);
                            //Credits
                            lbl = new Label();
                            Td = new TableCell();
                            Td.HorizontalAlign = HorizontalAlign.Center;
                            lbl.ID = "lblNCredits" + iRow;
                            lbl.Text = "3";
                            Td.Controls.Add(lbl);
                            Tr.Cells.Add(Td);
                            //Grade
                            ddl.ID = "ddlNGrade" + iRow;
                            ddl.AutoPostBack = true;
                            ddl.SelectedIndexChanged += new EventHandler(ddlNew_SelectedIndexChanged);

                            ddl.DataSource = dsGrades;
                            ddl.DataTextField = "strGrade";
                            ddl.DataValueField = "curCreditPoint";
                            ddl.DataBind();
                            //Rec Course
                            ddl.Items.Add(new ListItem("Canceled", "0"));
                            ddl.SelectedValue = "0";

                            Td = new TableCell();
                            Td.HorizontalAlign = HorizontalAlign.Center;
                            Td.Controls.Add(ddl);
                            Tr.Cells.Add(Td);
                            //Points
                            lbl = new Label();
                            Td = new TableCell();
                            Td.HorizontalAlign = HorizontalAlign.Center;
                            lbl.ID = "lblNPoints" + iRow;
                            lbl.Text = String.Format("{0:0.00}", 0);
                            Td.Controls.Add(lbl);
                            Tr.Cells.Add(Td);
                            //Sum
                            lbl = new Label();
                            Td = new TableCell();
                            Td.HorizontalAlign = HorizontalAlign.Center;
                            lbl.ID = "lblNSum" + iRow;
                            lbl.Text = String.Format("{0:0.00}", 0);
                            Td.Controls.Add(lbl);
                            Tr.Cells.Add(Td);
                            Tr.BackColor = Color.DarkOrange;
                            MyNewGTable.Rows.Add(Tr);

                            Tr = new TableRow();
                            Td = new TableCell();
                            Td.HorizontalAlign = HorizontalAlign.Center;
                            lbl = new Label();
                            ddl = new DropDownList();
                            dCredits = 0;
                            dPoints = 0;
                            dSum = 0;
                            iRow += 1;
                        }
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
                myList = myMirror;
                Session["myList"] = myMirror;
                Session["myPlan"] = Plan;
            }

        }
        private void AddRegCourses(string sRepeatedCourses)
        {
            List<MirrorCLS> myMirror = new List<MirrorCLS>();
            Advising myAdvising = new Advising();
            Plans Plan = new Plans();
            try
            {
                Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                string sNo = sSelectedValue.Value;
                int iYear = 0;
                int iSem = 0;
                iYear = LibraryMOD.SeperateTerm(int.Parse(Term_ddl.SelectedValue), out iSem);
                bool isHidden = LibraryMOD.isGradesHidden(Campus);

                TableRow Tr = new TableRow();
                TableCell Td = new TableCell();
                Td.HorizontalAlign = HorizontalAlign.Center;
                Label lbl = new Label();
                double dCredits = 0;
                double dPoints = 0;
                double dSum = 0;
                DropDownList ddl = new DropDownList();
                TextBox txt = new TextBox();
                HiddenField hdn = new HiddenField();

                DataSet dsRegCourses = new DataSet();
                dsRegCourses = GetRegCourses();

                int iRow = 0;
                iRow = MyNewGTable.Rows.Count;
                string sRegRepeated = "";
                string sCourse = "";
                for (int i = 0; i < dsRegCourses.Tables["RegCourses"].Rows.Count; i++)
                {
                    sCourse = dsRegCourses.Tables["RegCourses"].Rows[i]["Course"].ToString();
                    //DataRow[] drAry = null;
                    //drAry = dsRegCourses.Tables["RegCourses"].Select("Course='" + sCourse + "'");
                    if (!sRepeatedCourses.Contains(sCourse))
                    {
                        //Course Type
                        lbl.ID = "lblNCourseType" + iRow;
                        lbl.Text = "Registered";
                        Td.Controls.Add(lbl);
                        Tr.Cells.Add(Td);
                        //Course
                        lbl = new Label();
                        Td = new TableCell();
                        Td.HorizontalAlign = HorizontalAlign.Center;
                        lbl.ID = "lblNCourse" + iRow;
                        lbl.Text = sCourse;

                        Td.Controls.Add(lbl);
                        Tr.Cells.Add(Td);
                        //Credits
                        lbl = new Label();
                        Td = new TableCell();
                        Td.HorizontalAlign = HorizontalAlign.Center;
                        lbl.ID = "lblNCredits" + iRow;
                        lbl.Text = "3";
                        Td.Controls.Add(lbl);
                        Tr.Cells.Add(Td);
                        //Grade
                        ddl.ID = "ddlNGrade" + iRow;
                        ddl.AutoPostBack = true;

                        ddl.SelectedIndexChanged += new EventHandler(ddlNew_SelectedIndexChanged);
                        ddl.DataSource = dsGrades;
                        ddl.DataTextField = "strGrade";
                        ddl.DataValueField = "curCreditPoint";
                        ddl.DataBind();
                        //Reg Grade
                        ddl.Items.Add(new ListItem("Canceled", "0"));
                        ddl.SelectedValue = "0";

                        Td = new TableCell();
                        Td.HorizontalAlign = HorizontalAlign.Center;
                        Td.Controls.Add(ddl);
                        Tr.Cells.Add(Td);
                        //Points
                        lbl = new Label();
                        Td = new TableCell();
                        Td.HorizontalAlign = HorizontalAlign.Center;
                        lbl.ID = "lblNPoints" + iRow;
                        lbl.Text = String.Format("{0:0.00}", 0);
                        Td.Controls.Add(lbl);
                        Tr.Cells.Add(Td);
                        //Sum
                        lbl = new Label();
                        Td = new TableCell();
                        Td.HorizontalAlign = HorizontalAlign.Center;
                        lbl.ID = "lblNSum" + iRow;
                        lbl.Text = String.Format("{0:0.00}", 0);
                        Td.Controls.Add(lbl);
                        Tr.Cells.Add(Td);
                        Tr.BackColor = Color.SteelBlue;
                        MyNewGTable.Rows.Add(Tr);

                        Tr = new TableRow();
                        Td = new TableCell();
                        Td.HorizontalAlign = HorizontalAlign.Center;
                        lbl = new Label();
                        ddl = new DropDownList();
                        dCredits = 0;
                        dPoints = 0;
                        dSum = 0;
                        iRow += 1;
                    }
                    else
                    {
                        if (sRegRepeated != "")
                        {
                            sRegRepeated += " - ";
                        }
                        sRegRepeated += sCourse;
                    }
                }
                lblrepeatedCourses.Visible = false;
                if (sRegRepeated != "")
                {
                    lblrepeatedCourses.Visible = true;
                    lblrepeatedCourses.Text = " Student repeat the following courses: " + sRegRepeated;
                }
                //add recommended courses
                AddRecommendedCourses(dsRegCourses);

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
                myList = myMirror;
                Session["myList"] = myMirror;
                Session["myPlan"] = Plan;
            }

        }
        private void initCGPAData()
        {
            if (sSelectedValue.Value == "") { return; }

            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();

            try
            {
                string strStudentNo = sSelectedValue.Value;
                int intStudyYear = Convert.ToInt32(Session["CurrentYear"]);
                int byteSemester = Convert.ToInt32(Session["CurrentSemester"]);

                int iRegYear = int.Parse(Session["RegYear"].ToString());
                int iRegSem = int.Parse(Session["RegSemester"].ToString());

                if (byteSemester == 1)
                {
                    intStudyYear -= 1;
                    byteSemester = 4;
                }
                else
                {
                    byteSemester -= 1;
                }

                string sDegree = hdnDegree.Value;
                string sMajor = hdnMajor.Value;

                string sSQL = "SELECT  C.strCourse, GS.strGrade, GS.curCreditPoint, C.byteCreditHours, S.sTerm, STG.intStudyYear, STG.byteSemester";
                sSQL += " FROM Reg_Grade_System AS GS INNER JOIN dbo.Student_Trans_Grades('" + strStudentNo + "', " + intStudyYear + ", " + byteSemester + ", '" + sDegree + "', '" + sMajor + "') AS STG ON GS.strGrade = STG.strGrade INNER JOIN";
                sSQL += " dbo.GPA_All_CCount('" + strStudentNo + "', " + intStudyYear + ", " + byteSemester + ") AS GC ON STG.lngStudentNumber = GC.lngStudentNumber AND ";
                sSQL += " STG.strCourse = GC.strCourse INNER JOIN Reg_Courses AS C ON STG.strCourse = C.strCourse";
                sSQL += " INNER JOIN dbo.Lkp_Semesters ON ABS(STG.byteSemester ) = dbo.Lkp_Semesters.byteSemester";
                sSQL += " INNER JOIN localect.ECTDataNew.dbo.Reg_Semester AS S ON ABS(STG.intStudyYear) = S.AcademicYear AND ABS(STG.byteSemester) = S.Semester";
                sSQL += " WHERE (GC.CountG > 1) AND (GS.bCalc = 1) AND (STG.intStudyYear = " + intStudyYear + ") AND (STG.byteSemester <= " + byteSemester + ") AND (STG.bDisActivated = 0) AND ";
                sSQL += " (STG.lngStudentNumber = '" + strStudentNo + "') OR (GC.CountG > 1) AND (GS.bCalc = 1) AND (STG.intStudyYear < " + intStudyYear + ") AND (STG.bDisActivated = 0) AND (STG.lngStudentNumber = '" + strStudentNo + "') OR";
                sSQL += " (GC.CountG = 1) AND (GS.bCalc = 1) AND (STG.intStudyYear = " + intStudyYear + ") AND (STG.byteSemester <= " + byteSemester + ") AND ";
                sSQL += " (STG.lngStudentNumber = '" + strStudentNo + "') OR (GC.CountG = 1) AND (GS.bCalc = 1) AND (STG.intStudyYear < " + intStudyYear + ") AND (STG.lngStudentNumber = '" + strStudentNo + "')";
                //sSQL += " ORDER BY GS.curCreditPoint Desc,C.strCourse";
                sSQL += " ORDER BY STG.intStudyYear, STG.byteSemester, GS.curCreditPoint DESC, C.strCourse";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);

                SqlDataReader Rd = Cmd.ExecuteReader();

                MyGTable = new System.Web.UI.WebControls.Table();
                //First Row
                MyGTable.Width = Unit.Percentage(100);
                MyGTable.BorderWidth = 1;
                MyGTable.GridLines = GridLines.Horizontal;

                TableHeaderRow Hr = new TableHeaderRow();
                TableHeaderCell Hc = new TableHeaderCell();
                Hc.Text = "Term";
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hc);
                Hc = new TableHeaderCell();
                Hc.Text = "Course";
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hc);
                Hc = new TableHeaderCell();
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hc.Text = "Credits";
                Hr.Cells.Add(Hc);
                Hc = new TableHeaderCell();
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hc.Text = "Grade";
                Hr.Cells.Add(Hc);
                Hc = new TableHeaderCell();
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hc.Text = "Points";
                Hr.Cells.Add(Hc);
                Hc = new TableHeaderCell();
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hc.Text = "Credits*Points";
                Hr.Cells.Add(Hc);

                MyGTable.Rows.Add(Hr);

                TableRow Tr = new TableRow();
                TableCell Td = new TableCell();
                Td.HorizontalAlign = HorizontalAlign.Center;
                Label lbl = new Label();
                double dCredits = 0;
                double dPoints = 0;
                double dSum = 0;
                DropDownList ddl = new DropDownList();
                TextBox txt = new TextBox();
                HiddenField hdn = new HiddenField();
                int i = 1;
                string sRepeatedCourses = "";
                string sGrade = "";
                while (Rd.Read())
                {
                    //Course Type
                    lbl.ID = "Term" + i;
                    lbl.Text = Rd["sTerm"].ToString();
                    Td.Controls.Add(lbl);
                    Tr.Cells.Add(Td);
                    //Course
                    lbl = new Label();
                    Td = new TableCell();
                    Td.HorizontalAlign = HorizontalAlign.Center;
                    lbl.ID = "lblCourse" + i;
                    lbl.Text = Rd["strCourse"].ToString();
                    Td.Controls.Add(lbl);
                    Tr.Cells.Add(Td);
                    //Credits
                    lbl = new Label();
                    Td = new TableCell();
                    Td.HorizontalAlign = HorizontalAlign.Center;
                    lbl.ID = "lblCredits" + i;
                    dCredits = Convert.ToDouble(Rd["byteCreditHours"]);
                    lbl.Text = Rd["byteCreditHours"].ToString();
                    Td.Controls.Add(lbl);
                    Tr.Cells.Add(Td);
                    //Grade
                    sGrade = Rd["strGrade"].ToString();
                    if (sGrade == "F" || sGrade == "D")
                    {
                        if (sRepeatedCourses != "")
                        {
                            sRepeatedCourses += " - ";
                        }
                        sRepeatedCourses += Rd["strCourse"].ToString();
                        Tr.BackColor = Color.DarkOrange;
                    }
                    else
                    {
                        Tr.BackColor = Color.White;
                    }
                    ddl.ID = "ddlGrade" + i;
                    ddl.AutoPostBack = true;
                    ddl.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
                    ddl.DataSource = dsGrades;

                    ddl.DataTextField = "strGrade";
                    ddl.DataValueField = "curCreditPoint";
                    ddl.DataBind();
                    if (sGrade == "Pass")
                    {
                        ddl.SelectedValue = "-1.0000";
                    }
                    else if (sGrade == "Fail")
                    {
                        ddl.SelectedValue = "-2.0000";
                    }
                    else
                    {
                        ddl.SelectedValue = Rd["curCreditPoint"].ToString();
                    }


                    //ddl.Items.Add(new ListItem("Canceled", "0"));

                    Td = new TableCell();
                    Td.HorizontalAlign = HorizontalAlign.Center;
                    Td.Controls.Add(ddl);
                    Tr.Cells.Add(Td);
                    //Points
                    lbl = new Label();
                    Td = new TableCell();
                    Td.HorizontalAlign = HorizontalAlign.Center;
                    lbl.ID = "lblPoints" + i;
                    if (sGrade == "Pass" || sGrade == "Fail")
                    {
                        dPoints = Convert.ToDouble(0);
                    }
                    else
                    {
                        dPoints = Convert.ToDouble(Rd["curCreditPoint"]);
                    }

                    lbl.Text = String.Format("{0:0.00}", dPoints);
                    Td.Controls.Add(lbl);
                    Tr.Cells.Add(Td);
                    //Sum
                    lbl = new Label();
                    Td = new TableCell();
                    Td.HorizontalAlign = HorizontalAlign.Center;
                    lbl.ID = "lblSum" + i;
                    dSum = dCredits * dPoints;
                    lbl.Text = String.Format("{0:0.00}", dSum);
                    Td.Controls.Add(lbl);
                    Tr.Cells.Add(Td);
                    ////Index
                    //Td = new TableCell();
                    //hdn.ID = "hdn" + i;
                    //hdn.Value = i.ToString();
                    //Td.Controls.Add(hdn);
                    //Tr.Cells.Add(Td);

                    MyGTable.Rows.Add(Tr);

                    Tr = new TableRow();
                    Td = new TableCell();
                    Td.HorizontalAlign = HorizontalAlign.Center;
                    lbl = new Label();
                    ddl = new DropDownList();
                    dCredits = 0;
                    dPoints = 0;
                    dSum = 0;
                    i += 1;
                }

                Rd.Close();

                initNewGrades();


                //Add registered courses
                AddRegCourses(sRepeatedCourses);

                divGrades.Controls.Clear();
                divGrades.Controls.Add(MyGTable);
                Session["MyGTable"] = MyGTable;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

        }
        protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
        {

            initCGPAData();
            //MyNewGTable.Rows.Clear();
            lblCGPA.Text = String.Format("{0:0.00}", getCGPA());
            txtOldCGPA.Text = String.Format("{0:0.00}", GetCGPA(sSelectedValue.Value));
        }
        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = new DropDownList();
            ddl = (DropDownList)sender;
            ListItem lst = ddl.SelectedItem;
            string sText = lst.Text;
            string sValue = lst.Value;

            double dPoints = Convert.ToDouble(sValue);
            if (sText == "Pass" || sText == "Fail")
            {
                dPoints = Convert.ToDouble(0);
            }

            int iRow = getIndex(ddl.ID, "ddlGrade");
            Label lbl = new Label();
            lbl = (Label)MyGTable.Rows[iRow].Cells[iPointsCell].Controls[0];
            lbl.Text = String.Format("{0:0.00}", dPoints);

            double dCredits = 0;
            lbl = new Label();
            lbl = (Label)MyGTable.Rows[iRow].Cells[iCreditsCell].Controls[0];
            dCredits = Convert.ToDouble(lbl.Text);

            double dSum = 0;
            dSum = dPoints * dCredits;
            lbl = new Label();
            lbl = (Label)MyGTable.Rows[iRow].Cells[iSumCell].Controls[0];
            lbl.Text = String.Format("{0:0.00}", dSum);

            lblCGPA.Text = String.Format("{0:0.00}", getCGPA());

        }
        private void setHandler()
        {
            if (MyGTable.Rows.Count <= 1) { return; }
            DropDownList ddl = new DropDownList();
            for (int i = 1; i < MyGTable.Rows.Count; i++)
            {
                ddl = (DropDownList)MyGTable.Rows[i].Cells[iGradeCell].Controls[0];
                ddl.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
            }

        }

        private void setNewHandler()
        {
            if (MyNewGTable.Rows.Count <= 1) { return; }
            DropDownList ddl = new DropDownList();
            for (int i = 1; i < MyNewGTable.Rows.Count; i++)
            {
                ddl = (DropDownList)MyNewGTable.Rows[i].Cells[iGradeCell].Controls[0];
                ddl.SelectedIndexChanged += new EventHandler(ddlNew_SelectedIndexChanged);
            }

        }

        private int getIndex(string sID, string sRemove)
        {
            int iIndex = 0;
            sID = sID.Replace(sRemove, "");
            iIndex = Convert.ToInt32(sID);
            return iIndex;
        }

        private void setStudentMajor(string sSID)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT strDegree, strSpecialization FROM  Reg_Applications AS A";
                sSQL += " WHERE (lngStudentNumber = '" + sSID + "')";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    hdnDegree.Value = Rd["strDegree"].ToString();
                    hdnMajor.Value = Rd["strSpecialization"].ToString();
                }
                Rd.Close();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }

        protected void btnHideGrades_Click(object sender, ImageClickEventArgs e)
        {
            if (btnHideGrades.ImageUrl == "~/Images/Icons/Up.gif")
            {
                divGrades.Visible = false;
                btnHideGrades.ImageUrl = "~/Images/Icons/Down.gif";
                btnHideGrades.ToolTip = "Show old grades";
            }
            else
            {
                divGrades.Visible = true;
                btnHideGrades.ImageUrl = "~/Images/Icons/Up.gif";
                btnHideGrades.ToolTip = "Hide old grades";
            }
        }

        protected void ddlNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = new DropDownList();
            ddl = (DropDownList)sender;
            ListItem lst = ddl.SelectedItem;
            string sText = lst.Text;
            string sValue = lst.Value;
            double dPoints = Convert.ToDouble(sValue);
            if (sText == "Pass" || sText == "Fail")
            {
                dPoints = Convert.ToDouble(0);
            }
            int iRow = getIndex(ddl.ID, "ddlNGrade");
            Label lbl = new Label();
            lbl = (Label)MyNewGTable.Rows[iRow].Cells[iPointsCell].Controls[0];
            lbl.Text = String.Format("{0:0.00}", dPoints);

            double dCredits = 0;
            lbl = new Label();
            lbl = (Label)MyNewGTable.Rows[iRow].Cells[iCreditsCell].Controls[0];
            dCredits = Convert.ToDouble(lbl.Text);

            double dSum = 0;
            dSum = dPoints * dCredits;
            lbl = new Label();
            lbl = (Label)MyNewGTable.Rows[iRow].Cells[iSumCell].Controls[0];
            lbl.Text = String.Format("{0:0.00}", dSum);

            lblCGPA.Text = String.Format("{0:0.00}", getCGPA());

        }

        protected void lngNewGrdae_Click(object sender, EventArgs e)
        {
            if (MyNewGTable.Rows.Count > 0)
            {
                addnewgrades();
            }
            else
            {
                initNewGrades();
                addnewgrades();
            }
            lblCGPA.Text = String.Format("{0:0.00}", getCGPA());
        }

        private void initNewGrades()
        {
            if (sSelectedValue.Value == "") { return; }

            try
            {
                MyNewGTable = new System.Web.UI.WebControls.Table();
                //First Row
                MyNewGTable.Width = Unit.Percentage(100);
                MyNewGTable.BorderWidth = 1;
                MyNewGTable.GridLines = GridLines.Horizontal;

                TableHeaderRow Hr = new TableHeaderRow();
                TableHeaderCell Hc = new TableHeaderCell();
                Hc.Text = "Course Type";
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hc);
                Hc = new TableHeaderCell();
                Hc.Text = "Course";
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hr.Cells.Add(Hc);
                Hc = new TableHeaderCell();
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hc.Text = "Credits";
                Hr.Cells.Add(Hc);
                Hc = new TableHeaderCell();
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hc.Text = "Grade";
                Hr.Cells.Add(Hc);
                Hc = new TableHeaderCell();
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hc.Text = "Points";
                Hr.Cells.Add(Hc);
                Hc = new TableHeaderCell();
                Hc.HorizontalAlign = HorizontalAlign.Center;
                Hc.Text = "Credits*Points";
                Hr.Cells.Add(Hc);

                MyNewGTable.Rows.Add(Hr);

                //TableRow Tr = new TableRow();
                //TableCell Td = new TableCell();
                //Td.HorizontalAlign = HorizontalAlign.Center;
                //Label lbl = new Label();
                //DropDownList ddl = new DropDownList();
                //TextBox txt = new TextBox();

                ////Course Type
                //lbl.ID = "lblCourseType";
                //lbl.Text = "Recommended";
                //Td.Controls.Add(lbl);
                //Tr.Cells.Add(Td);
                ////Course
                //lbl.ID = "lblNCourse1";
                //lbl.Text = "Course #1";
                //Td.Controls.Add(lbl);
                //Tr.Cells.Add(Td);
                ////Credits
                //lbl = new Label();
                //Td = new TableCell();
                //Td.HorizontalAlign = HorizontalAlign.Center;
                //lbl.ID = "lblNCredits1";
                //lbl.Text = "3";
                //Td.Controls.Add(lbl);
                //Tr.Cells.Add(Td);
                ////Grade
                //ddl.ID = "ddlNGrade1";
                //ddl.AutoPostBack = true;
                //ddl.SelectedIndexChanged += new EventHandler(ddlNew_SelectedIndexChanged);
                //ddl.DataSource = dsGrades;
                //ddl.DataTextField = "strGrade";
                //ddl.DataValueField = "curCreditPoint";
                //ddl.DataBind();
                //ddl.SelectedIndex = 0;
                //Td = new TableCell();
                //Td.HorizontalAlign = HorizontalAlign.Center;
                //Td.Controls.Add(ddl);
                //Tr.Cells.Add(Td);
                ////Points
                //lbl = new Label();
                //Td = new TableCell();
                //Td.HorizontalAlign = HorizontalAlign.Center;
                //lbl.ID = "lblNPoints1";
                //lbl.Text = String.Format("{0:0.00}", 4);
                //Td.Controls.Add(lbl);
                //Tr.Cells.Add(Td);
                ////Sum
                //lbl = new Label();
                //Td = new TableCell();
                //Td.HorizontalAlign = HorizontalAlign.Center;
                //lbl.ID = "lblNSum1";
                //lbl.Text = String.Format("{0:0.00}", 12);
                //Td.Controls.Add(lbl);
                //Tr.Cells.Add(Td);
                //MyNewGTable.Rows.Add(Tr);

                divNewGrades.Controls.Clear();
                divNewGrades.Controls.Add(MyNewGTable);
                Session["MyNewGTable"] = MyNewGTable;
            }
            catch (Exception ex)
            {
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
        }
        private void addnewgrades()
        {
            try
            {
                int iRow = 0;
                iRow = MyNewGTable.Rows.Count;
                TableRow Tr = new TableRow();
                TableCell Td = new TableCell();
                Td.HorizontalAlign = HorizontalAlign.Center;
                Label lbl = new Label();
                DropDownList ddl = new DropDownList();
                TextBox txt = new TextBox();

                //Course Type
                lbl.ID = "lblNCourseType" + iRow;
                lbl.Text = "New";
                Td.Controls.Add(lbl);
                Tr.Cells.Add(Td);
                //Course
                // lbl = new Label();
                txt = new TextBox();
                Td = new TableCell();
                Td.HorizontalAlign = HorizontalAlign.Center;
                //lbl.ID = "lblNCourse" + iRow;
                //lbl.Text = "Course #" + iRow;
                //Td.Controls.Add(lbl);
                txt.ID = "txtNCourse" + iRow;
                txt.Text = "Course #" + iRow;
                txt.BorderStyle = BorderStyle.Double;
                //txt.BackColor = Color.SkyBlue  ; 
                Td.Controls.Add(txt);
                Tr.Cells.Add(Td);
                //Credits
                lbl = new Label();
                Td = new TableCell();
                Td.HorizontalAlign = HorizontalAlign.Center;
                lbl.ID = "lblNCredits" + iRow;
                lbl.Text = "3";
                Td.Controls.Add(lbl);
                Tr.Cells.Add(Td);
                //Grade
                ddl.ID = "ddlNGrade" + iRow;
                ddl.AutoPostBack = true;

                ddl.SelectedIndexChanged += new EventHandler(ddlNew_SelectedIndexChanged);
                ddl.DataSource = dsGrades;
                ddl.DataTextField = "strGrade";
                ddl.DataValueField = "curCreditPoint";
                ddl.DataBind();
                ddl.Items.Add(new ListItem("Canceled", "0"));
                ddl.SelectedValue = "0";

                Td = new TableCell();
                Td.HorizontalAlign = HorizontalAlign.Center;
                Td.Controls.Add(ddl);
                Tr.Cells.Add(Td);
                //Points
                lbl = new Label();
                Td = new TableCell();
                Td.HorizontalAlign = HorizontalAlign.Center;
                lbl.ID = "lblNPoints" + iRow;
                lbl.Text = String.Format("{0:0.00}", 0);
                Td.Controls.Add(lbl);
                Tr.Cells.Add(Td);
                //Sum
                lbl = new Label();
                Td = new TableCell();
                Td.HorizontalAlign = HorizontalAlign.Center;
                lbl.ID = "lblNSum" + iRow;
                lbl.Text = String.Format("{0:0.00}", 0);
                Td.Controls.Add(lbl);
                Tr.Cells.Add(Td);
                MyNewGTable.Rows.Add(Tr);
            }
            catch (Exception ex)
            {
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
        }
        private double GetCGPA(string sID)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            double CGPA = 0;
            try
            {
                string sSQL = "SELECT GPA FROM GPA_Until WHERE lngStudentNumber='" + sID + "'";
                SqlCommand cmd = new SqlCommand(sSQL, Conn);
                CGPA = Convert.ToDouble("0" + cmd.ExecuteScalar().ToString());
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
                Conn.Close();
                Conn.Dispose();
            }
            return CGPA;
        }
        private double getCGPA()
        {
            double dCredits = 0;
            double dPoints = 0;
            double dCGPA = 0;
            string sGrade = "";
            Label lblCredits = new Label();
            Label lblPoints = new Label();
            DropDownList ddlgrade = new DropDownList();

            //Real Grades
            if (Session["MyGTable"] != null)
            {
                if (MyGTable.Rows.Count > 1)
                {
                    for (int iRow = 1; iRow < MyGTable.Rows.Count; iRow++)
                    {
                        ddlgrade = (DropDownList)MyGTable.Rows[iRow].Cells[iGradeCell].Controls[0];
                        sGrade = ddlgrade.SelectedItem.Text;
                        if (sGrade != "Canceled" && sGrade != "Pass" && sGrade != "Fail")
                        {
                            lblCredits = (Label)MyGTable.Rows[iRow].Cells[iCreditsCell].Controls[0];
                            dCredits += Convert.ToDouble(lblCredits.Text);
                            lblPoints = (Label)MyGTable.Rows[iRow].Cells[iSumCell].Controls[0];
                            dPoints += Convert.ToDouble(lblPoints.Text);
                        }
                    }
                }
            }
            //New Grades
            if (Session["MyNewGTable"] != null)
            {
                if (MyNewGTable.Rows.Count > 1)
                {
                    for (int iRow = 1; iRow < MyNewGTable.Rows.Count; iRow++)
                    {
                        ddlgrade = (DropDownList)MyNewGTable.Rows[iRow].Cells[iGradeCell].Controls[0];
                        sGrade = ddlgrade.SelectedItem.Text;
                        if (sGrade != "Canceled" && sGrade != "Pass" && sGrade != "Fail")
                        {
                            lblCredits = (Label)MyNewGTable.Rows[iRow].Cells[iCreditsCell].Controls[0];
                            dCredits += Convert.ToDouble(lblCredits.Text);
                            lblPoints = (Label)MyNewGTable.Rows[iRow].Cells[iSumCell].Controls[0];
                            dPoints += Convert.ToDouble(lblPoints.Text);
                        }
                    }
                }
            }
            if (dCredits != 0)
            {
                dCGPA = dPoints / dCredits;
            }
            return dCGPA;
        }

        private DataSet Prepare_CGPA_Demo_Report()
        {

            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();

            try
            {
                DataColumn dc;

                dc = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCourseType", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCourse", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iCredits", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sGrade", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("dPoints", Type.GetType("System.Double"));
                dt.Columns.Add(dc);
                dc = new DataColumn("dSum", Type.GetType("System.Double"));
                dt.Columns.Add(dc);

                double dCredits = 0;
                double dPoints = 0;
                Label lblCourseType = new Label();
                Label lblCourse = new Label();
                Label lblCredits = new Label();
                DropDownList ddlGrade = new DropDownList();
                ListItem lst = new ListItem();

                CoursesCls TheCourse = new CoursesCls();

                int iSerial = 0;
                //Real Grades
                if (Session["MyGTable"] != null)
                {
                    if (MyGTable.Rows.Count > 1)
                    {
                        for (int iRow = 1; iRow < MyGTable.Rows.Count; iRow++)
                        {
                            dr = dt.NewRow();
                            iSerial += 1;
                            dr["iSerial"] = iSerial;
                            lblCourseType = (Label)MyGTable.Rows[iRow].Cells[iCourseTypeCell].Controls[0];
                            dr["sCourseType"] = lblCourseType.Text;
                            lblCourse = (Label)MyGTable.Rows[iRow].Cells[iCourseCell].Controls[0];
                            dr["sCourse"] = lblCourse.Text;
                            lblCourseName.Text = TheCourse.GetCourseName(Campus, lblCourse.Text.Replace("'", ""));


                            ddlGrade = (DropDownList)MyGTable.Rows[iRow].Cells[iGradeCell].Controls[0];
                            lst = ddlGrade.SelectedItem;
                            dr["sGrade"] = lst.Text;
                            lblCredits = (Label)MyGTable.Rows[iRow].Cells[iCreditsCell].Controls[0];

                            if (lst.Text == "Pass" || lst.Text == "Fail")
                            {
                                dPoints = 0;
                                dCredits = 0;
                            }
                            else
                            {
                                dPoints = Convert.ToDouble(lst.Value);
                                dCredits = Convert.ToDouble(lblCredits.Text);
                            }
                            dr["iCredits"] = Convert.ToInt32(dCredits);
                            dr["dPoints"] = dPoints;
                            dr["dSum"] = dCredits * dPoints;

                            dt.Rows.Add(dr);
                        }
                    }
                }

                //New Grades
                if (Session["MyNewGTable"] != null)
                {
                    if (MyNewGTable.Rows.Count > 1)
                    {
                        for (int iRow = 1; iRow < MyNewGTable.Rows.Count; iRow++)
                        {
                            dr = dt.NewRow();
                            iSerial += 1;
                            dr["iSerial"] = iSerial;
                            lblCourseType = (Label)MyNewGTable.Rows[iRow].Cells[iCourseTypeCell].Controls[0];
                            dr["sCourseType"] = lblCourseType.Text;
                            lblCourse = (Label)MyNewGTable.Rows[iRow].Cells[iCourseCell].Controls[0];
                            dr["sCourse"] = lblCourse.Text;
                            lblCourseName.Text = TheCourse.GetCourseName(Campus, lblCourse.Text.Replace("'", ""));

                            lblCredits = (Label)MyNewGTable.Rows[iRow].Cells[iCreditsCell].Controls[0];
                            //dCredits = Convert.ToDouble(lblCredits.Text);
                            //dr["iCredits"] = Convert.ToInt32(dCredits);
                            ddlGrade = (DropDownList)MyNewGTable.Rows[iRow].Cells[iGradeCell].Controls[0];
                            lst = ddlGrade.SelectedItem;
                            dr["sGrade"] = lst.Text;
                            if (lst.Text == "Pass" || lst.Text == "Fail")
                            {
                                dPoints = 0;
                                dCredits = 0;
                            }
                            else
                            {
                                dPoints = Convert.ToDouble(lst.Value);
                                dCredits = Convert.ToDouble(lblCredits.Text);
                            }
                            dr["iCredits"] = Convert.ToInt32(dCredits);
                            dr["dPoints"] = dPoints;
                            dr["dSum"] = dCredits * dPoints;

                            dt.Rows.Add(dr);
                        }
                    }
                }

                dt.TableName = "Grades";
                dt.AcceptChanges();
                ds.Tables.Add(dt);

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;

            }
            finally
            {

            }
            return ds;
        }

        private void ExportCGPADemo()
        {
            ReportDocument myReport = new ReportDocument();

            try
            {

                DataSet rptDS = new DataSet();
                rptDS = Prepare_CGPA_Demo_Report();
                string reportPath = "";

                reportPath = Server.MapPath("Reports/CGPADemo.rpt");

                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);


                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Page.Response, true, "ECTReport");

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
        protected void btnToExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportCGPADemo();
        }

        protected void ButPrint_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void Terms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButSave_Click(object sender, ImageClickEventArgs e)
        {

            int iEffected = 0;
            int iYear = Convert.ToInt32("0" + Session["CurrentYear"].ToString());
            int iSemester = Convert.ToInt32("0" + Session["CurrentSemester"].ToString());
            int iCampus = 2;
            if(Session["CurrentCampus"].ToString()=="Males")
            {
                iCampus = 1;
            }
            else
            {
                iCampus = 2;
            }

            Connection_StringCLS myConnection_String;
            SqlConnection Conn;
            //string sSQL = "";
            //DataSet ds = new DataSet();
            //SqlCommand cmd;
            //SqlDataAdapter adptr;

            try
            {
                myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);

                Conn = new SqlConnection(myConnection_String.Conn_string);
                Conn.Open();

                //sSQL = "SELECT StudentID, GPA_Before, StudentMajor_Short";
                //sSQL += " ,CourseID, byteClass, byteShift, intStudyYear, byteSemester";
                //sSQL += " FROM At_Risk_Students";

                //cmd = new SqlCommand(sSQL, Conn);
                //adptr = new SqlDataAdapter();

                //cmd.CommandType = CommandType.Text;
                //adptr.SelectCommand = cmd;
                //adptr.Fill(ds, "StudentsAtRisk");

                string sExpectedGrade = "";
                decimal dOldCGPA = 0;
                decimal dNewCGPA = 0;
                int iAdvisorID = 0;
                string sAdvisorComments = "";

                int iMaxID = 0;

                int iRow = 0;

                string sStudentID = sSelectedValue.Value;
                string sCourse = "";

                dOldCGPA = Convert.ToDecimal("0" + txtOldCGPA.Text);
                dNewCGPA = Convert.ToDecimal("0" + lblCGPA.Text);

                string sPCName = Convert.ToString(Session["CurrentPCName"]);
                string sNetUserName = Convert.ToString(Session["CurrentNetUserName"]);

                iRow = MyNewGTable.Rows.Count;
                // iCourseTypeCell = 0;
                // iCourseCell = 1;
                // iCreditsCell = 2;
                // iGradeCell = 3;


                // check if data is dose not exist for current semester
                // Insert records
                //else view saved data for update
                DataSet ds = new DataSet();
                //  = ds.Tables[0].Rows.Count; 

                //if (IsStudentAdvisingExistforCurrentSemester(iCampus,sStudentID, iYear, iSemester) != true)
                //{
                Advising_CGPA_TrackingDAL myAdvising_CGPA_TrackingDAL = new Advising_CGPA_TrackingDAL();
                // string[] strAry = null;
                // MyNewGTable.Rows.CopyTo(strAry, 1);  
                for (int i = 1; i < iRow; i++)
                {
                    if (((TextBox)MyNewGTable.Rows[i].Cells[iCourseCell].FindControl("txtNCourse" + i)) == null)
                    {
                        sCourse = ((Label)MyNewGTable.Rows[i].Cells[iCourseCell].FindControl("lblNCourse" + i)).Text;
                    }
                    else
                    {
                        sCourse = ((TextBox)MyNewGTable.Rows[i].Cells[iCourseCell].FindControl("txtNCourse" + i)).Text;
                    }
                    sExpectedGrade = ((DropDownList)MyNewGTable.Rows[i].Cells[iGradeCell].FindControl("ddlNGrade" + i)).SelectedItem.Text;

                    iMaxID = LibraryMOD.GetMaxID(Conn, "intTrackingID", "Reg_Advising_CGPA_Tracking") + 1;
                    // save students at risk and all registered courses except ESL, graduation project & Internship
                    iEffected += myAdvising_CGPA_TrackingDAL.UpdateAdvising_CGPA_Tracking((InitializeModule.EnumCampus)iCampus
                    , (int)InitializeModule.enumModes.NewMode, iMaxID, iYear, iSemester, sStudentID, sCourse, sExpectedGrade, dOldCGPA, dNewCGPA, iAdvisorID, sAdvisorComments, Convert.ToString(Session["CurrentUserName"].ToString()), DateTime.Today.Date, Convert.ToString(Session["CurrentUserName"].ToString()), DateTime.Today.Date, sPCName, sNetUserName, "", "");

                }
                //}
                Conn.Close();
                Conn.Dispose();
                //divMsg.InnerText = iEffected.ToString() + "Records Saved Successfully";
                lbl_Msg.Text = iEffected.ToString() + "Records Saved Successfully";
                div_msg.Visible = true;


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
            }
            finally
            {

            }
        }
        public DataSet GetStudentAdvisingforCurrentSemester(int iCampus, string sStudentID, int iYear, int iSemester)
        {
            String sSQL;
            DataSet ds = new DataSet();
            Connection_StringCLS MyConnection_string = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
            SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());

            try
            {

                sSQL = "SELECT intTrackingID,strCourse, strExpectedGrade";
                sSQL += " , dblOldCGPA, dblNewCGPA";
                sSQL += " , intAdvisorID, sAdvisorComments";
                sSQL += " FROM Reg_Advising_CGPA_Tracking ";
                sSQL += " WHERE intStudyYear =" + iYear;
                sSQL += " AND byteSemester =" + iSemester;
                sSQL += " AND lngStudentNumber ='" + sStudentID + "'";

                Conn.Open();

                System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);

                SqlDataAdapter adapter = new SqlDataAdapter(sSQL, Conn);
                adapter.Fill(ds);
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

            return ds;
        }

        protected void Crsimg_Click(object sender, EventArgs e)
        {
            Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
            try
            {
                int iYear = 0;
                int iSem = 0;
                iYear = LibraryMOD.SeperateTerm(int.Parse(Term_ddl.SelectedValue), out iSem);
                ImageButton img = (ImageButton)sender;
                string sCourse = img.ID;
                string sSQL = "";

                string sDegree = myList[0].SDegree;
                string sMajor = myList[0].SMajor;

                if (sCourse.Substring(0, 6) == "MELECT")//Major Elective
                {
                    Conn.Open();
                    sSQL = "SELECT sEelecive FROM Reg_Specialization_Elective AS M";
                    sSQL += " WHERE (sCollege = N'1') AND (sDegree = N'" + sDegree + "') AND (sMajor = N'" + sMajor + "')";
                    SqlCommand cmd = new SqlCommand(sSQL, Conn);
                    SqlDataReader rd = cmd.ExecuteReader();
                    sCourse = "";
                    while (rd.Read())
                    {
                        sCourse += " '" + rd["sEelecive"].ToString() + "',";
                    }
                    sCourse = sCourse.Substring(0, sCourse.Length - 1);
                    rd.Close();
                    Conn.Close();
                }
                else if (sCourse.Substring(0, 6) == "FELECT")//Free Elective (Out of major crs in the same level)
                {

                    sSQL = "SELECT intStudyYear, byteSemester, byteShift, strCourse, byteClass, byteCreditHours, strLecturerDescEn, dateTimeFrom, dateTimeTo, strDays, strHall, Max, Capacity,CourseDesc,IsArabicCourse";
                    sSQL += " FROM (SELECT CT.intStudyYear, CT.byteSemester, CT.byteShift, CT.strCourse, CT.byteClass, C.byteCreditHours, L.strLecturerDescEn, CT.dateTimeFrom, CT.dateTimeTo,";
                    sSQL += " dbo.ExtractDays(COALESCE (CT.byteDay, 0)) AS strDays, CT.strHall, (CASE WHEN H.intMaxSeats < MaxCapacity THEN H.intMaxSeats ELSE MaxCapacity END) AS Max, COALESCE (CC.RegCapacity, 0) AS Capacity, C.strCourseDescEn AS CourseDesc,C.IsArabicCourse";
                    sSQL += " FROM Reg_CourseTime_Schedule AS CT INNER JOIN Reg_Courses AS C ON CT.strCourse = C.strCourse INNER JOIN Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN";
                    sSQL += " Reg_Available_Courses AS AV ON CT.intStudyYear = AV.intStudyYear AND CT.byteSemester = AV.byteSemester AND CT.strCourse = AV.strCourse AND CT.byteClass = AV.byteClass AND CT.byteShift = AV.byteShift INNER JOIN";
                    sSQL += " Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN Lkp_Course_Classes AS CCL ON C.byteCourseClass = CCL.byteCourseClass INNER JOIN";
                    //Degree Crs
                    sSQL += " (SELECT DISTINCT strCourse FROM Reg_Specialization_Courses AS SC WHERE (strDegree = N'" + sDegree + "')) AS D ON C.strCourse = D.strCourse LEFT OUTER JOIN";
                    //Major Crs
                    sSQL += " (SELECT DISTINCT strCourse FROM Reg_Specialization_Courses AS SC WHERE (strDegree = N'" + sDegree + "') AND (strSpecialization = '" + sMajor + "')) AS P";

                    sSQL += " ON CT.strCourse = P.strCourse LEFT OUTER JOIN ClassCapacity AS CC ON CT.intStudyYear = CC.iYear AND CT.byteSemester = CC.Sem AND CT.strCourse = CC.Course AND CT.byteClass = CC.Class AND";
                    sSQL += " CT.byteShift = CC.Shift WHERE (CT.intStudyYear = " + iYear + ") AND (CT.byteSemester = " + iSem + ") AND (P.strCourse IS NULL)";
                    sSQL += " AND NOT(C.strCourse IN('ESL_GEN','PRD308', 'JOR308', 'RTV308', 'PRD407', 'JOR407', 'RTV407','HIM415',N'BIS200', N'BIT415', N'BUS415',";
                    sSQL += "'BIM415', 'HRM415', 'ACC415','BAF415', 'BIT419', 'BUS419', 'BIM419', 'HRM208', 'HRM419','ACC204', 'BAF207','BAF419'))) AS TM";
                    sSQL += " WHERE (Max > Capacity) AND (byteClass < 100) ";

                    //check if student study in english , dont suggest arabic courses
                    SpecializationsCls theSpecializations = new SpecializationsCls();
                    bool IsArabicProgram = theSpecializations.IsStudyLanguageArabic("1", sDegree, sMajor);

                    if (!IsArabicProgram)
                    {
                        sSQL += " AND (IsArabicCourse = 0)";
                    }
                    sSQL += " ORDER BY strCourse, byteShift, byteClass, dateTimeFrom";

                }
                else
                {
                    sCourse = "'" + img.ID + "'";
                }


                //divMsg.InnerText = sID;

                divCRS.Visible = true;
                lngAdvisorComments.Visible = false;
                divDetail.Visible = false;
                divTools.Visible = divDetail.Visible;
                if (sCourse.Substring(0, 6) != "FELECT")
                {
                    sSQL = "SELECT intStudyYear, byteSemester, byteShift, strCourse, byteClass, byteCreditHours, strLecturerDescEn, dateTimeFrom, dateTimeTo, strDays, strHall, Max, Capacity,CourseDesc,IsArabicCourse";
                    sSQL += " FROM (SELECT CT.intStudyYear, CT.byteSemester, CT.byteShift, CT.strCourse, CT.byteClass, C.byteCreditHours, L.strLecturerDescEn, CT.dateTimeFrom, CT.dateTimeTo,dbo.ExtractDays(COALESCE (CT.byteDay, 0)) AS strDays, CT.strHall,";
                    sSQL += " (CASE WHEN H.intMaxSeats < MaxCapacity THEN H.intMaxSeats ELSE MaxCapacity END) AS Max, COALESCE (CC.RegCapacity, 0) AS Capacity,C.strCourseDescEn AS CourseDesc,C.IsArabicCourse";
                    sSQL += " FROM Reg_CourseTime_Schedule AS CT INNER JOIN Reg_Courses AS C ON CT.strCourse = C.strCourse INNER JOIN Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN";
                    sSQL += " Reg_Available_Courses AS AV ON CT.intStudyYear = AV.intStudyYear AND CT.byteSemester = AV.byteSemester AND CT.strCourse = AV.strCourse AND CT.byteClass = AV.byteClass AND CT.byteShift = AV.byteShift INNER JOIN";
                    sSQL += " Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN Lkp_Course_Classes AS CCL ON C.byteCourseClass = CCL.byteCourseClass LEFT OUTER JOIN";
                    sSQL += " ClassCapacity AS CC ON CT.intStudyYear = CC.iYear AND CT.byteSemester = CC.Sem AND CT.strCourse = CC.Course AND CT.byteClass = CC.Class AND CT.byteShift = CC.Shift";
                    sSQL += " WHERE(CT.intStudyYear = " + iYear + ") AND (CT.byteSemester = " + iSem + ") AND (CT.strCourse IN (" + sCourse + "))) AS TM";
                    sSQL += " WHERE (Max > Capacity) AND (byteClass < 100) ORDER BY strCourse, byteShift, byteClass, dateTimeFrom";
                }

                Connection_StringCLS mycon = new Connection_StringCLS(Campus);
                TmDS.ConnectionString = mycon.Conn_string;
                TmDS.SelectCommand = sSQL;
                //TmDS.SelectParameters["iYear"].DefaultValue = iYear.ToString();
                //TmDS.SelectParameters["bSem"].DefaultValue = iSem.ToString();
                //TmDS.SelectParameters["sCourse"].DefaultValue = sCourse;
                TmDS.DataBind();
                lblCourse.Text = sCourse;
                CoursesCls TheCourse = new CoursesCls();
                lblCourseName.Text = TheCourse.GetCourseName(Campus, sCourse.Replace("'", ""));

                txtAdvisorName.Text = myList[0].Advisor;
                //int iAdvisorID = 0;
                //iAdvisorID = Convert.ToInt32("0" + Session["CurrentLecturer"].ToString());

                txtStudentCGPA.Text = String.Format("{0:0.00}", myList[0].CGPA);

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
            }
            finally
            {

                Conn.Dispose();

            }

        }

        private void setimg_ClickHandler()
        {
            try
            {
                if (myTable.Rows.Count <= 1) { return; }
                ImageButton img = new ImageButton();
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                System.Web.UI.WebControls.Table inTable = new System.Web.UI.WebControls.Table();
                inTable = (System.Web.UI.WebControls.Table)myTable.Rows[6].Cells[0].Controls[0];//Gen Crs
                for (int i = 0; i < inTable.Rows[0].Cells.Count; i++)
                {
                    img = (ImageButton)inTable.Rows[0].Cells[i].Controls[0];
                    img.Click += new ImageClickEventHandler(Crsimg_Click);
                }
                inTable = (System.Web.UI.WebControls.Table)myTable.Rows[8].Cells[0].Controls[0];//Other Crs
                for (int i = 0; i < inTable.Rows[0].Cells.Count; i++)
                {
                    img = (ImageButton)inTable.Rows[0].Cells[i].Controls[0];
                    img.Click += new ImageClickEventHandler(Crsimg_Click);
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
        protected void lngBack_Click(object sender, EventArgs e)
        {
            try
            {
                divCRS.Visible = false;
                divDetail.Visible = true;
                divTools.Visible = divDetail.Visible;
                lngAdvisorComments.Visible = true;
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
            }
            finally
            {

            }
        }
        protected void grdCrs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
            Conn.Open();
            try
            {
                //intStudyYear,byteSemester,strCourse,byteClass,byteShift
                int iSelectedIndex = grdCrs.SelectedIndex;
                int iYear = int.Parse(grdCrs.DataKeys[iSelectedIndex].Values["intStudyYear"].ToString());
                int iSem = int.Parse(grdCrs.DataKeys[iSelectedIndex].Values["byteSemester"].ToString());
                string sCourse = grdCrs.DataKeys[iSelectedIndex].Values["strCourse"].ToString();
                int iShift = int.Parse(grdCrs.DataKeys[iSelectedIndex].Values["byteShift"].ToString());
                int iClass = int.Parse(grdCrs.DataKeys[iSelectedIndex].Values["byteClass"].ToString());

                MirrorCLS myMirror = ((List<MirrorCLS>)Session["myList"])[0];
                Plans myPlan = (Plans)Session["myPlan"];
                RegValidation validation = new RegValidation(this.Campus, this.CurrentRole, myMirror, myPlan, sCourse, iYear, iSem, iShift, iClass);

                string sSQL = "";

                if (validation.validateAdvising(Page, iYear, iSem))
                {
                    sSQL = "SELECT strCourse AS Code, CourseDesc AS Course,";
                    sSQL += " (CASE byteShift WHEN 1 THEN 'FM' WHEN 2 THEN 'FE' WHEN 3 THEN 'MM' WHEN 4 THEN 'ME' WHEN 8 THEN 'WEM' WHEN 9 THEN 'WEF' END) AS Session,";
                    sSQL += " byteClass AS Class, strLecturerDescEn AS Lecturer, dateTimeFrom AS [From], dateTimeTo AS [To], strDays AS Days, strHall AS Hall";
                    sSQL += " FROM (SELECT CT.intStudyYear, CT.byteSemester, CT.byteShift, CT.strCourse,C.strCourseDescEn AS CourseDesc, CT.byteClass, C.byteCreditHours, L.strLecturerDescEn, CT.dateTimeFrom, CT.dateTimeTo,";
                    sSQL += " dbo.ExtractDays(COALESCE (CT.byteDay, 0)) AS strDays, CT.strHall,(CASE WHEN H.intMaxSeats < MaxCapacity THEN H.intMaxSeats ELSE MaxCapacity END) AS Max, COALESCE (CC.RegCapacity, 0) AS Capacity FROM Reg_CourseTime_Schedule as CT INNER JOIN Reg_Courses AS C ON CT.strCourse=C.strCourse INNER JOIN";
                    sSQL += " Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN Reg_Available_Courses AS AV ON CT.intStudyYear = AV.intStudyYear AND CT.byteSemester = AV.byteSemester AND CT.strCourse = AV.strCourse AND";
                    sSQL += " CT.byteClass = AV.byteClass AND CT.byteShift = AV.byteShift INNER JOIN Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN";
                    sSQL += " Lkp_Course_Classes AS CCL ON C.byteCourseClass = CCL.byteCourseClass LEFT OUTER JOIN ClassCapacity AS CC ON CT.intStudyYear = CC.iYear AND CT.byteSemester = CC.Sem AND CT.strCourse = CC.Course AND CT.byteClass = CC.Class AND";
                    sSQL += " CT.byteShift = CC.Shift WHERE (CT.intStudyYear = " + iYear + ") AND (CT.byteSemester = " + iSem + ") AND (CT.strCourse = '" + sCourse + "') AND (CT.byteShift = " + iShift + ") AND (CT.byteClass = " + iClass + ")) AS TM";
                    sSQL += " WHERE  (Max > Capacity) AND (byteClass < 100) ORDER BY [From]";


                    //string sSql = "SELECT  TOP (100) PERCENT TM.strCourse AS Code";
                    //sSql += " , TM.CourseDesc AS Course, TM.byteClass AS Class, TM.strLecturerDescEn AS Lecturer";
                    //sSql += " , TM.Session, TM.dateTimeFrom AS [From]";
                    //sSql += " , TM.dateTimeTo AS [To], TM.strDays AS Days, TM.strHall AS Hall, 'Males' AS Campus";
                    //sSql += " FROM Localect.ECTData.dbo.TimeTable_Males AS TM INNER JOIN";
                    //sSql += " Localect.ECTData.dbo.Course_Balance_View AS CV ON TM.intStudyYear = CV.iYear AND TM.byteSemester = CV.Sem ";
                    //sSql += " AND TM.strCourse = CV.Course AND TM.byteClass = CV.Class AND TM.byteShift = CV.Shift";
                    //sSql += " WHERE CV.iYear=" + iYear;
                    //sSql += " AND CV.Sem=" + iSem;
                    //sSql += " AND CV.Student='" + sSelectedValue.Value + "'";
                    //sSql += " UNION";
                    //sSql += " SELECT  TOP (100) PERCENT TM.strCourse AS Code, TM.CourseDesc AS Course";
                    //sSql += " , TM.byteClass AS Class, TM.strLecturerDescEn AS Lecturer, TM.Session, TM.dateTimeFrom AS [From]";
                    //sSql += " , TM.dateTimeTo AS [To], TM.strDays AS Days, TM.strHall AS Hall, 'Females' AS Campus";
                    //sSql += " FROM Sql_Server.ECTData.dbo.TimeTable_Females AS TM INNER JOIN";
                    //sSql += " Sql_Server.ECTData.dbo.Course_Balance_View AS CV ON TM.intStudyYear = CV.iYear ";
                    //sSql += " AND TM.byteSemester = CV.Sem AND TM.strCourse = CV.Course AND TM.byteClass = CV.Class ";
                    //sSql += " AND TM.byteShift = CV.Shift";
                    //sSql += " WHERE CV.iYear=" + iYear;
                    //sSql += " AND CV.Sem=" + iSem;
                    //sSql += " AND CV.Student='" + sSelectedValue.Value + "'";

                    //sSql += " ORDER BY Code, [From]";
                    DataRow dr = null;

                    if (Suggesteddt.Columns.Count == 0)
                    {
                        Initdt();
                    }
                    int iIndex = Suggesteddt.Rows.Count;

                    SqlCommand cmd = new SqlCommand(sSQL, Conn);
                    SqlDataReader rd = cmd.ExecuteReader();
                    txtComment.Text += " \n recommended to register: ";

                    while (rd.Read())
                    {
                        iIndex += 1;
                        dr = Suggesteddt.NewRow();
                        dr["Index"] = iIndex;
                        dr["Code"] = rd["Code"].ToString();
                        dr["Course"] = rd["Course"].ToString();
                        dr["Session"] = rd["Session"].ToString();
                        dr["Class"] = rd["Class"].ToString();
                        dr["Lecturer"] = rd["Lecturer"].ToString();
                        dr["From"] = string.Format("{0:hh:mm tt}", rd["From"]);
                        dr["To"] = string.Format("{0:hh:mm tt}", rd["To"]);
                        dr["Days"] = rd["Days"].ToString();
                        dr["Hall"] = rd["Hall"].ToString();
                        dr["isReg"] = "No";
                        dr["Campus"] = Campus.ToString();
                        Suggesteddt.Rows.Add(dr);
                        txtComment.Text += rd["Code"].ToString();
                        txtComment.Text += "-" + rd["Course"].ToString() + ";";
                    }
                    rd.Close();
                    grdSuggested.DataSource = Suggesteddt;
                    grdSuggested.DataBind();
                }
                else
                {
                    divConfirmation.InnerHtml = validation.ErrorMessage;
                    //string sScript = "$(function(){ $('#divConfirmation').html('" + validation.ErrorMessage + "').css({'background-color':'#fff','border':'2px solid red', 'color':'red'}).slideToggle('slow'); });";
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "testScript2", sScript, true);
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
            }
            finally
            {
                Session["Suggesteddt"] = Suggesteddt;
                Conn.Close();
                Conn.Dispose();
            }
        }

        private void Initdt()
        {
            try
            {
                DataColumn dc = null;
                dc = new DataColumn("Index");
                Suggesteddt.Columns.Add(dc);
                dc = new DataColumn("Code");
                Suggesteddt.Columns.Add(dc);
                dc = new DataColumn("Course");
                Suggesteddt.Columns.Add(dc);
                dc = new DataColumn("Session");
                Suggesteddt.Columns.Add(dc);
                dc = new DataColumn("Class");
                Suggesteddt.Columns.Add(dc);
                dc = new DataColumn("Lecturer");
                Suggesteddt.Columns.Add(dc);
                dc = new DataColumn("From");
                Suggesteddt.Columns.Add(dc);
                dc = new DataColumn("To");
                Suggesteddt.Columns.Add(dc);
                dc = new DataColumn("Days");
                Suggesteddt.Columns.Add(dc);
                dc = new DataColumn("Hall");
                Suggesteddt.Columns.Add(dc);
                dc = new DataColumn("isReg");
                Suggesteddt.Columns.Add(dc);
                dc = new DataColumn("Campus");
                Suggesteddt.Columns.Add(dc);

                Session["Suggesteddt"] = Suggesteddt;
                grdSuggested.DataSource = Suggesteddt;
                grdSuggested.DataBind();

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
            }
            finally
            {

            }

        }

        private void fill_Registered()
        {
            Connection_StringCLS MyConnection_string = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());
            Conn.Open();
            try
            {
                int iYear = 0;
                int iSem = 0;
                iYear = LibraryMOD.SeperateTerm(int.Parse(Term_ddl.SelectedValue), out iSem);

                //Get the student's registered courses
                //string sSql = "SELECT TM.strCourse AS Code, TM.CourseDesc AS Course,";
                //sSql += " (CASE byteShift WHEN 1 THEN 'FM' WHEN 2 THEN 'FE' WHEN 3 THEN 'MM' WHEN 4 THEN 'ME' WHEN 8 THEN 'WEM' WHEN 9 THEN 'WEF' END) AS Session,";
                //sSql += " TM.byteClass AS Class, TM.strLecturerDescEn AS Lecturer, TM.dateTimeFrom AS [From], TM.dateTimeTo AS [To], TM.strDays AS Days, TM.strHall AS Hall";
                //sSql += " FROM (SELECT CT.intStudyYear, CT.byteSemester, CT.byteShift, CT.strCourse, C.strCourseDescEn AS CourseDesc, CT.byteClass, C.byteCreditHours, L.strLecturerDescEn,";
                //sSql += " CT.dateTimeFrom, CT.dateTimeTo, dbo.ExtractDays(COALESCE (CT.byteDay, 0)) AS strDays, CT.strHall,";
                //sSql += " (CASE WHEN H.intMaxSeats < MaxCapacity THEN H.intMaxSeats ELSE MaxCapacity END) AS Max, COALESCE (CC.RegCapacity, 0) AS Capacity";
                //sSql += " FROM Reg_CourseTime_Schedule AS CT INNER JOIN Reg_Courses AS C ON CT.strCourse = C.strCourse INNER JOIN";
                //sSql += " Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN Reg_Available_Courses AS AV ON CT.intStudyYear = AV.intStudyYear AND CT.byteSemester = AV.byteSemester AND CT.strCourse = AV.strCourse AND";
                //sSql += " CT.byteClass = AV.byteClass AND CT.byteShift = AV.byteShift INNER JOIN Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN";
                //sSql += " Lkp_Course_Classes AS CCL ON C.byteCourseClass = CCL.byteCourseClass LEFT OUTER JOIN ClassCapacity AS CC ON CT.intStudyYear = CC.iYear AND CT.byteSemester = CC.Sem AND CT.strCourse = CC.Course AND CT.byteClass = CC.Class AND";
                //sSql += " CT.byteShift = CC.Shift) AS TM INNER JOIN Course_Balance_View AS CV ON TM.intStudyYear = CV.iYear AND TM.byteSemester = CV.Sem AND TM.byteShift = CV.Shift AND TM.strCourse = CV.Course AND TM.byteClass = CV.Class";

                string sSql = "SELECT  TOP (100) PERCENT TM.strCourse AS Code";
                sSql += " , TM.CourseDesc AS Course, TM.byteClass AS Class, TM.strLecturerDescEn AS Lecturer";
                sSql += " , TM.Session, TM.dateTimeFrom AS [From]";
                sSql += " , TM.dateTimeTo AS [To], TM.strDays AS Days, TM.strHall AS Hall, 'Males' AS Campus";
                sSql += " FROM Localect.ECTData.dbo.TimeTable_Males AS TM INNER JOIN";
                sSql += " Localect.ECTData.dbo.Course_Balance_View AS CV ON TM.intStudyYear = CV.iYear AND TM.byteSemester = CV.Sem ";
                sSql += " AND TM.strCourse = CV.Course AND TM.byteClass = CV.Class AND TM.byteShift = CV.Shift";
                sSql += " WHERE CV.iYear=" + iYear;
                sSql += " AND CV.Sem=" + iSem;
                sSql += " AND CV.Student='" + sSelectedValue.Value + "'";
                sSql += " UNION";
                sSql += " SELECT  TOP (100) PERCENT TM.strCourse AS Code, TM.CourseDesc AS Course";
                sSql += " , TM.byteClass AS Class, TM.strLecturerDescEn AS Lecturer, TM.Session, TM.dateTimeFrom AS [From]";
                sSql += " , TM.dateTimeTo AS [To], TM.strDays AS Days, TM.strHall AS Hall, 'Females' AS Campus";
                sSql += " FROM Sql_Server.ECTData.dbo.TimeTable_Females AS TM INNER JOIN";
                sSql += " Sql_Server.ECTData.dbo.Course_Balance_View AS CV ON TM.intStudyYear = CV.iYear ";
                sSql += " AND TM.byteSemester = CV.Sem AND TM.strCourse = CV.Course AND TM.byteClass = CV.Class ";
                sSql += " AND TM.byteShift = CV.Shift";
                sSql += " WHERE CV.iYear=" + iYear;
                sSql += " AND CV.Sem=" + iSem;
                sSql += " AND CV.Student='" + sSelectedValue.Value + "'";

                sSql += " ORDER BY Code, [From]";

                if (Suggesteddt.Columns.Count == 0)
                {
                    Initdt();
                }
                else
                {
                    Suggesteddt.Rows.Clear();
                }
                DataRow dr = null;
                SqlCommand Cmd = new SqlCommand(sSql, Conn);
                SqlDataReader rd = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
                int iIndex = 0;
                while (rd.Read())
                {
                    iIndex += 1;
                    dr = Suggesteddt.NewRow();
                    dr["Index"] = iIndex;
                    dr["Code"] = rd["Code"].ToString();
                    dr["Course"] = rd["Course"].ToString();
                    dr["Session"] = rd["Session"].ToString();
                    dr["Class"] = rd["Class"].ToString();
                    dr["Lecturer"] = rd["Lecturer"].ToString();
                    dr["From"] = string.Format("{0:hh:mm tt}", rd["From"]);
                    dr["To"] = string.Format("{0:hh:mm tt}", rd["To"]);
                    dr["Days"] = rd["Days"].ToString();
                    dr["Hall"] = rd["Hall"].ToString();
                    dr["isReg"] = "Yes";
                    dr["Campus"] = rd["Campus"].ToString();
                    Suggesteddt.Rows.Add(dr);
                }
                rd.Close();
                Session["Suggesteddt"] = Suggesteddt;
                grdSuggested.DataSource = Suggesteddt;
                grdSuggested.DataBind();
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
            }
            finally
            {

            }
        }
        protected void grdSuggested_SelectedIndexChanged(object sender, EventArgs e)
        {
            Suggesteddt.Rows[grdSuggested.SelectedIndex].Delete();
            Session["Suggesteddt"] = Suggesteddt;
            grdSuggested.DataBind();
        }

        private DataSet Prepare_Suggestion_Report()
        {

            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            int iYear = 0;
            int iSem = 0;

            try
            {
                iYear = LibraryMOD.SeperateTerm(int.Parse(Term_ddl.SelectedValue), out iSem);
                string sID = sSelectedValue.Value;
                string sName = sSelectedText.Value;
                string sTerm = "";
                if (iSem < 2)
                {
                    sTerm = iYear.ToString();
                }
                else
                {
                    sTerm = (iYear + 1).ToString();
                }
                switch (iSem)
                {
                    case 1:
                        sTerm += " Fall";
                        break;
                    case 2:
                        sTerm += " Spring";
                        break;
                    case 3:
                        sTerm += " Summer I";
                        break;
                    case 4:
                        sTerm += " Summer II";
                        break;
                }

                string sLec = Session["CurrentUserName"].ToString();
                if (Session["CurrentLecturerName"] != null)
                {
                    sLec = Session["CurrentLecturerName"].ToString();
                }

                string sComment = txtComment.Text;
                string sStudentFeedback = txtStudentFeedback.Text;
                string CGPA = txtStudentCGPA.Text;
                DataColumn dc;

                dc = new DataColumn("Term", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("SID", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("SName", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Advisor", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Comments", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                dc = new DataColumn("StudentFeedback", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                dc = new DataColumn("Index", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Code", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Course", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Session", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Section", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Lecturer", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("From", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("To", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Days", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("CGPA", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                int iIndex = 0;
                for (int i = 0; i < Suggesteddt.Rows.Count; i++)
                {

                    dr = dt.NewRow();
                    iIndex = i + 1;
                    dr["Index"] = iIndex;
                    dr["Term"] = sTerm;
                    dr["SID"] = sID;
                    dr["SName"] = sName;
                    dr["Advisor"] = sLec;
                    dr["Comments"] = sComment;
                    dr["StudentFeedback"] = sStudentFeedback;
                    dr["CGPA"] = string.Format("{0:f}", CGPA).ToString();
                    dr["Code"] = Suggesteddt.Rows[i]["Code"].ToString();
                    dr["Course"] = Suggesteddt.Rows[i]["Course"].ToString();
                    dr["Session"] = Suggesteddt.Rows[i]["Session"].ToString();
                    dr["Section"] = Suggesteddt.Rows[i]["Class"].ToString();
                    dr["Lecturer"] = Suggesteddt.Rows[i]["Lecturer"].ToString();
                    dr["From"] = Suggesteddt.Rows[i]["From"].ToString();
                    dr["To"] = Suggesteddt.Rows[i]["To"].ToString();
                    dr["Days"] = Suggesteddt.Rows[i]["Days"].ToString();

                    dt.Rows.Add(dr);
                }

                //Add 5 empty rows
                for (int i = 0; i < 5; i++)
                {
                    iIndex++;

                    dr = dt.NewRow();

                    dr["Index"] = iIndex;
                    dr["Term"] = sTerm;
                    dr["SID"] = sID;
                    dr["SName"] = sName;
                    dr["Advisor"] = sLec;
                    dr["Comments"] = sComment;
                    dr["StudentFeedback"] = sStudentFeedback;
                    dr["CGPA"] = CGPA;

                    dr["Code"] = "";
                    dr["Course"] = "";
                    dr["Session"] = "";
                    dr["Section"] = "";
                    dr["Lecturer"] = "";
                    dr["From"] = "";
                    dr["To"] = "";
                    dr["Days"] = "";

                    dt.Rows.Add(dr);

                }

                dt.TableName = "Suggesteddt";
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
        private DataSet Prepare_AllAdvisorsSuggestions_Report()
        {

            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();

            try
            {

                string sID = sSelectedValue.Value;
                string sName = sSelectedText.Value;

                DataColumn dc;

                dc = new DataColumn("Term", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("SID", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("SName", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Advisor", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Comments", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                dc = new DataColumn("StudentFeedback", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                dc = new DataColumn("Index", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Code", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Course", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Session", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Section", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Lecturer", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("From", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("To", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Days", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("CGPA", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("AdvisingDate", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                int iIndex = 0;
                for (int i = 0; i < grdAdvisorsComments.Rows.Count; i++)
                {

                    dr = dt.NewRow();
                    iIndex = i + 1;
                    dr["Index"] = iIndex;
                    dr["SID"] = sID;
                    dr["SName"] = sName;

                    dr["Term"] = grdAdvisorsComments.Rows[i].Cells[4].Text; //Term
                    dr["AdvisingDate"] = grdAdvisorsComments.Rows[i].Cells[5].Text; //AdvisingDate
                    dr["Advisor"] = grdAdvisorsComments.Rows[i].Cells[6].Text; //Advisonr name
                    dr["Comments"] = grdAdvisorsComments.Rows[i].Cells[7].Text; //AdvisorComments
                    dr["StudentFeedback"] = grdAdvisorsComments.Rows[i].Cells[8].Text; //StudentComments
                    dr["CGPA"] = grdAdvisorsComments.Rows[i].Cells[9].Text; //CGPA).ToString();

                    dr["Code"] = "";
                    dr["Course"] = "";
                    dr["Session"] = "";
                    dr["Section"] = "";
                    dr["Lecturer"] = "";
                    dr["From"] = "";
                    dr["To"] = "";
                    dr["Days"] = "";

                    dt.Rows.Add(dr);
                }

                dt.TableName = "Suggesteddt";
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
        private void ExportAllAdvisorsComments()
        {
            ReportDocument myReport = new ReportDocument();
            try
            {
                DataSet rptDS = new DataSet();
                string reportPath = "";


                reportPath = Server.MapPath("Reports/AllAdvisorsSuggestions.rpt");

                rptDS = Prepare_AllAdvisorsSuggestions_Report();



                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);

                TextObject txt;
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtCurrentCGPA"];
                txt.Text = String.Format("{0:0.00}", GetCGPA(sSelectedValue.Value));

                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "AdvisingComments");


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
        private void ExportSuggestion()
        {
            ReportDocument myReport = new ReportDocument();
            try
            {
                DataSet rptDS = new DataSet();
                string reportPath = "";


                reportPath = Server.MapPath("Reports/AdvisorSuggestion.rpt");

                rptDS = Prepare_Suggestion_Report();

                myReport.Load(reportPath);

                myReport.SetDataSource(rptDS);

                //TextObject txt;
                //txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtCGPA"];
                //txt.Text = string.Format("{0:f}", lblStudentGPA.Text);

                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "AdvisingComments");

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
        protected void Print_Adv_btn_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Advising,
                    InitializeModule.enumPrivilege.Print, CurrentRole) != true)
            {
                Server.Transfer("Authorization.aspx");

            }
            ExportSuggestion();
        }
        protected void Term_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_Registered();
        }
        protected void SaveCMD_Click(object sender, ImageClickEventArgs e)
        {
            if (txtComment.Text == "")
            {
                //divMsg.InnerText = "Please enter your comments to save";
                lbl_Msg.Text = "Please enter your comments to save";
                div_msg.Visible = true;
                return;
            }
            int iEffected = 0;


            int iCampus = 2;
            if(Session["CurrentCampus"].ToString()=="Males")//CurrentCampus
            {
                iCampus = 1;
            }
            else
            {
                iCampus = 2;
            }

            Connection_StringCLS myConnection_String;
            SqlConnection Conn;

            try
            {
                myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);

                Conn = new SqlConnection(myConnection_String.Conn_string);
                Conn.Open();

                decimal CurrentCGPA = 0;

                int iAdvisorID = 0;
                iAdvisorID = Convert.ToInt32("0" + Session["CurrentLecturer"].ToString());

                string sAdvisorComments = txtComment.Text;
                string sStudentComments = txtStudentFeedback.Text;
                string sRecommendation = "";

                int iMaxID = 0;


                string sStudentID = sSelectedValue.Value;

                CurrentCGPA = Convert.ToDecimal("0" + String.Format("{0:0.00}", GetCGPA(sStudentID)));// Convert.ToDecimal("0" + txtOldCGPA.Text);
                int iYear = 0;
                int iSemester = 0;

                iYear = LibraryMOD.SeperateTerm(int.Parse(Term_ddl.SelectedValue), out iSemester);

                string sPCName = Convert.ToString(Session["CurrentPCName"]);
                string sNetUserName = Convert.ToString(Session["CurrentNetUserName"]);

                AcademicAdvisingDAL myAcademicAdvisingDAL = new AcademicAdvisingDAL();

                iMaxID = LibraryMOD.GetMaxID(Conn, "AcademicAdvisingID", "Reg_AcademicAdvising") + 1;
                // save advisor comment
                iEffected += myAcademicAdvisingDAL.UpdateAcademicAdvising((InitializeModule.EnumCampus)iCampus
                , (int)InitializeModule.enumModes.NewMode, iMaxID, sStudentID, iYear, iSemester, CurrentCGPA, iAdvisorID, sAdvisorComments, sStudentComments, sRecommendation, Convert.ToInt32(Session["CurrentUserNo"].ToString()), DateTime.Now, Convert.ToInt32(Session["CurrentUserNo"].ToString()), DateTime.Now, sPCName, sNetUserName);


                Conn.Close();
                Conn.Dispose();
                //divMsg.InnerText = iEffected.ToString() + " Records Saved Successfully";
                lbl_Msg.Text = iEffected.ToString() + " Records Saved Successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;

                SqlDataSourceAdvisorsComments.DataBind();
                grdAdvisorsComments.DataBind();
                SaveCMD.Enabled = false;
                txtComment.Enabled = false;
                txtStudentFeedback.Enabled = false;

                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Advising,
                   InitializeModule.enumPrivilege.Print, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");

                }
                ExportSuggestion();
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
            }
            finally
            {

            }
        }
        protected void lngAdvisorComments_Click(object sender, EventArgs e)
        {
            divCRS.Visible = true;
            lngAdvisorComments.Visible = false;
            divDetail.Visible = false;
            divTools.Visible = divDetail.Visible;
            txtComment.Focus();

            txtAdvisorName.Text = myList[0].Advisor;
            //int iAdvisorID = 0;
            //iAdvisorID = Convert.ToInt32("0" + Session["CurrentLecturer"].ToString());

            txtStudentCGPA.Text = String.Format("{0:0.00}", myList[0].CGPA);

            //lblAdvisorName.Visible = false;
            //lblStudentGPA.Visible = false;

            if (grdAdvisorsComments.Rows.Count < 0)
            {
                PrintAllAdvisorsComments_btn.Visible = false;
            }
            else
            {
                PrintAllAdvisorsComments_btn.Visible = true;
            }

            //Show available times for first courses in recommended courses
            int iRec = myList[0].Recommended.Count;
            string sCourse = "";
            if (iRec > 0)
            {
                lblCourse.Text = myList[0].Recommended[0].sCourse;
                sCourse = lblCourse.Text;
            }
            else
            {
                sCourse = "No Course Selected";
            }

            string sSQL = "";
            int iYear = 0;
            int iSem = 0;
            iYear = LibraryMOD.SeperateTerm(int.Parse(Term_ddl.SelectedValue), out iSem);

            if (sCourse.Substring(0, 6) != "FELECT")
            {
                sSQL = "SELECT intStudyYear, byteSemester, byteShift, strCourse, byteClass, byteCreditHours, strLecturerDescEn, dateTimeFrom, dateTimeTo, strDays, strHall, Max, Capacity,CourseDesc";
                sSQL += " FROM (SELECT CT.intStudyYear, CT.byteSemester, CT.byteShift, CT.strCourse, CT.byteClass, C.byteCreditHours, L.strLecturerDescEn, CT.dateTimeFrom, CT.dateTimeTo,dbo.ExtractDays(COALESCE (CT.byteDay, 0)) AS strDays, CT.strHall,";
                sSQL += " (CASE WHEN H.intMaxSeats < MaxCapacity THEN H.intMaxSeats ELSE MaxCapacity END) AS Max, COALESCE (CC.RegCapacity, 0) AS Capacity,C.strCourseDescEn AS CourseDesc";
                sSQL += " FROM Reg_CourseTime_Schedule AS CT INNER JOIN Reg_Courses AS C ON CT.strCourse = C.strCourse INNER JOIN Reg_Lecturers AS L ON CT.intLecturer = L.intLecturer INNER JOIN";
                sSQL += " Reg_Available_Courses AS AV ON CT.intStudyYear = AV.intStudyYear AND CT.byteSemester = AV.byteSemester AND CT.strCourse = AV.strCourse AND CT.byteClass = AV.byteClass AND CT.byteShift = AV.byteShift INNER JOIN";
                sSQL += " Lkp_Halls AS H ON CT.strHall = H.strHall INNER JOIN Lkp_Course_Classes AS CCL ON C.byteCourseClass = CCL.byteCourseClass LEFT OUTER JOIN";
                sSQL += " ClassCapacity AS CC ON CT.intStudyYear = CC.iYear AND CT.byteSemester = CC.Sem AND CT.strCourse = CC.Course AND CT.byteClass = CC.Class AND CT.byteShift = CC.Shift";
                sSQL += " WHERE(CT.intStudyYear = " + iYear + ") AND (CT.byteSemester = " + iSem + ") AND (CT.strCourse IN ('" + sCourse + "'))) AS TM";
                sSQL += " WHERE (Max > Capacity) AND (byteClass < 100) ORDER BY strCourse, byteShift, byteClass, dateTimeFrom";
            }

            Connection_StringCLS mycon = new Connection_StringCLS(Campus);
            TmDS.ConnectionString = mycon.Conn_string;
            TmDS.SelectCommand = sSQL;
            //TmDS.SelectParameters["iYear"].DefaultValue = iYear.ToString();
            //TmDS.SelectParameters["bSem"].DefaultValue = iSem.ToString();
            //TmDS.SelectParameters["sCourse"].DefaultValue = sCourse;
            TmDS.DataBind();
            lblCourse.Text = sCourse;
            CoursesCls TheCourse = new CoursesCls();
            lblCourseName.Text = TheCourse.GetCourseName(Campus, sCourse.Replace("'", ""));
        }
        protected void grdAdvisorsComments_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdAdvisorsComments.SelectedIndex < grdAdvisorsComments.Rows.Count)
                {
                    if (grdAdvisorsComments.SelectedRow != null)
                    {
                        int iSelectedIndex = grdAdvisorsComments.SelectedIndex;
                        int iAcademicAdvisingID = int.Parse(grdAdvisorsComments.DataKeys[iSelectedIndex].Values["AcademicAdvisingID"].ToString());

                        string sAdvisorComment = grdAdvisorsComments.SelectedRow.Cells[7].Text; //AdvisorComments
                        string sStudentComments = grdAdvisorsComments.SelectedRow.Cells[8].Text; //StudentComments
                        string sCGPA = grdAdvisorsComments.SelectedRow.Cells[9].Text; //CGPA
                        string sAdvisorName = grdAdvisorsComments.SelectedRow.Cells[6].Text; //Advisonr name
                        string sterm = grdAdvisorsComments.SelectedRow.Cells[4].Text;

                        string sNewGPA = String.Format("{0:0.00}", GetCGPA(sSelectedValue.Value));
                        txtComment.Text = sAdvisorComment;
                        txtStudentFeedback.Text = sStudentComments;
                        txtAdvisorName.Text = sAdvisorName + " / " + sterm;
                        txtStudentCGPA.Text = String.Format("{0:0.00}", sCGPA);

                        divCRS.Visible = true;
                        lblAdvisorName.Visible = true;
                        lblStudentGPA.Visible = true;

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
        }
        protected void lnkStudenttranscript_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Advising,
                     InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
            {
                //divMsg.InnerText = "Sorry you dont have a permissions to print the transcript";
                lbl_Msg.Text = "Sorry you dont have a permissions to print the transcript";
                div_msg.Visible = true;
                return;

            }
            int iYear = 0;
            int iSem = 0;
            int iPrevYear = 0;
            byte bPrevSemester = 0;

            iYear = LibraryMOD.SeperateTerm(int.Parse(Term_ddl.SelectedValue), out iSem);

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

            //Open transcript page

            Session["CurrentStudent"] = sSelectedValue.Value;
            Session["CurrentStudentName"] = sSelectedText.Value;

            Response.Redirect("Transcript.aspx?PreviousTerm=" + iPrevTerm);
        }
        protected void PrintAllAdvisorsComments_btn_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Advising,
                   InitializeModule.enumPrivilege.Print, CurrentRole) != true)
            {
                Server.Transfer("Authorization.aspx");

            }
            ExportAllAdvisorsComments();
        }
    }
}