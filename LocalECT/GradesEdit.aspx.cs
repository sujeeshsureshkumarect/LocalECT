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
////using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace LocalECT
{
    public partial class GradesEdit : System.Web.UI.Page
    {
        int RoleID = 0;
        int CurrentRole = 0;
        int iCampus = 1;
        string sUserName = "";
        Grade_HeaderDAL myGrade_HeaderDAL = new Grade_HeaderDAL();
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                sUserName = Convert.ToString("" + Session["CurrentUserName"]);
                string sSQL = "SELECT CB.Shift AS byteShift, CB.Class AS byteClass, CB.Course AS strCourse, C.strCourseDescEn AS strDesc, GH.strGrade";
                sSQL += " FROM Reg_Courses AS C INNER JOIN Course_Balance_View_Eq AS CB ON C.strCourse = CB.Course LEFT OUTER JOIN Reg_Grade_Header AS GH ON CB.iYear = GH.intStudyYear AND CB.Sem = GH.byteSemester AND CB.Shift = GH.byteShift AND CB.Course = GH.strCourse AND CB.Class = GH.byteClass AND CB.Student = GH.lngStudentNumber";
                sSQL += " WHERE (CB.iYear = @iYear) AND (CB.Sem = @Sem) AND (CB.Student = @Student)";

                //sSQL += " AND (CB.Course<>'ESL001')";

                if (CurrentRole != 91 && CurrentRole != 98 && CurrentRole != 129 && CurrentRole != 119 && CurrentRole != 151)//Admin or Head of Registration or Assistant Registrar or Senior or Alaa
                {
                    sSQL += " AND (GH.strGrade = N'EW' OR GH.strGrade = N'W' OR GH.strGrade = N'I' OR GH.strGrade = N'F' OR";
                    sSQL += " GH.strGrade = N'NG' OR GH.strGrade = N'Fail' OR GH.strGrade IS NULL)";

                }
                SqlDataSourceStudentGrades.SelectCommand = sSQL;
                lbl_Msg.Text = "";
                div_msg.Visible = false;



                if (!IsPostBack)
                {
                    if (Request.QueryString["sid"] != null && Request.QueryString["sid"] != "")
                    {
                        Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                        string sid = Request.QueryString["sid"];
                        sSelectedValue.Value = sid;
                        sSelectedText.Value = getstudentname(sid);
                        Session["CurrentStudent"] = sSelectedValue.Value;
                        Session["CurrentStudentName"] = sSelectedText.Value;
                    }
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    if (Campus.ToString() == "Males")
                    {
                        iCampus = 1;
                    }
                    else
                    {
                        iCampus = 2;
                    }
                    //iCampus = Convert.ToInt32(Session["CurrentCampus"]);
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEdit,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");

                    }

                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEdit,
                    InitializeModule.enumPrivilege.ChangeRegistrationYearSem, CurrentRole) != true)
                    {
                        Terms.Enabled = false;

                    }
                    Session["myList"] = null;
                    FillTerms();

                    Terms.SelectedValue = Session["CurrentYear"].ToString() + Session["CurrentSemester"].ToString();

                    iSemester.Value = Session["CurrentSemester"].ToString();
                    iYear.Value = Session["CurrentYear"].ToString();

                    //CampusCBO.SelectedValue = Convert.ToString(iCampus);

                    if (Session["CurrentStudent"] != null)
                    {
                        sSelectedValue.Value = Session["CurrentStudent"].ToString();
                        sSelectedText.Value = Session["CurrentStudentName"].ToString();
                    }

                    DataStatus.Value = ((int)InitializeModule.enumModes.NewMode).ToString();
                }
                else
                {
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    if (Campus.ToString() == "Males")
                    {
                        iCampus = 1;
                    }
                    else
                    {
                        iCampus = 2;
                    }
                    Session["CurrentCampus"] = iCampus;
                }
                string sConn = "";


                if (iCampus == (int)ECTGlobalDll.InitializeModule.EnumCampus.Males)
                {
                    Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
                    sConn = MyConnection_string.Conn_string;

                }
                else
                {

                    Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Females);
                    sConn = MyConnection_string.Conn_string;

                }

                SqlDataSourceStudentGrades.ConnectionString = sConn;

                //Search1.Campus = (InitializeModule.EnumCampus)iCampus;



                if (!string.IsNullOrEmpty(Request.QueryString["RoleID"]))
                {
                    RoleID = int.Parse(Request.QueryString["RoleID"]);

                }

                if (!IsPostBack)
                {
                    grdStudentGrades.DataBind();
                    //rdbShowAllOutofMajor_CheckedChanged(null,null);
                    Search1_ChangedEvent(null, null);
                    RunCMD_Click(null, null);
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
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
        //Event for the Search Control

        protected void Search1_NewEvent(object Sender, EventArgs e)
        {
            sSelectedValue.Value = "";
            sSelectedText.Value = "";

            txtCourse.Text = "";
            DdlCourses.SelectedValue = "-1";
            DdlCourseName.SelectedValue = "-1";
            DdlGrade.SelectedValue = "-1";

            grdStudentGrades.DataBind();
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
        protected void Search1_ChangedEvent(object Sender, EventArgs e)
        {
            //sSelectedValue.Value = e.SValue1;

            //sSelectedText.Value = e.SValue2;
            sSelectedValue.Value = Session["CurrentStudent"].ToString();
            sSelectedText.Value = Session["CurrentStudentName"].ToString();

            //iCampus = Convert.ToInt32(Session["CurrentCampus"]);
            //int iSerialNo = LibraryMOD.GetStudentSerialNo(sSelectedValue.Value.ToString(), iCampus);
            int iSerialNo = GetSerial(sSelectedValue.Value.ToString());
            Session["StudentSerialNo"] = iSerialNo;
            grdStudentGrades.DataBind();

        }

        #region FillDropDownList


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

        #endregion
        protected void RunCMD_Click(object sender, ImageClickEventArgs e)
        {

            GetYearSemester();
            grdStudentGrades.DataBind();


        }

        protected void grdStudentGrades_RowUpdating(Object sender, GridViewUpdateEventArgs e)
        {
            if (Page.IsValid)
            {
                //Update here
                //course=e.OldValues [0]
                //grade=e.OldValues [2]

                // string sSQl = "UPDATE ";
                //divMsg.InnerText = "";
                lbl_Msg.Text = "";
                div_msg.Visible = false;
            }
            else
            {

                //divMsg.InnerText = e.NewValues[4].ToString() + "Not Allowed Grade";
                lbl_Msg.Text = e.NewValues[4].ToString() + "Not Allowed Grade";
                div_msg.Visible = true;
            }
        }

        protected void grdStudentGrades_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        private void Initialize_Controls()
        {
            DdlGrade.SelectedValue = "-1";

        }
        protected void NewCMD_Click(object sender, ImageClickEventArgs e)
        {
            // AddNew();
        }
        //private void AddNew()
        //{
        //    //Check for permission of Add new

        //    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEdit,
        //        InitializeModule.enumPrivilege.AddNew, CurrentRole) != true)
        //    {
        //        divMsg.InnerText = InitializeModule.MsgAddNewAuthorization;
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(sSelectedValue.Value))
        //    {
        //        divMsg.InnerText = "Please Select Student !";
        //        return;
        //    }
        //    SaveCMD.Enabled = true;
        //    SaveCMD.ImageUrl = "~/Images/Icons/Save.gif";

        //    NewCMD.Enabled = false;
        //    //Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
        //    //SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
        //    try
        //    {
        //        //Conn.Open();
        //        Initialize_Controls();
        //        //iMax += LibraryMOD.GetMaxID(Conn, ColName, TableName);
        //        //Session["StudentSerialNo"] = iMax;
        //        //lblStudentSerialNo.Text = iMax.ToString();
        //        DataStatus.Value = ((int)InitializeModule.enumModes.NewMode).ToString();

        //    }
        //    catch (Exception ex)
        //    {
        //        LibraryMOD.ShowErrorMessage(ex);
        //        divMsg.InnerText = ex.Message;
        //    }
        //    finally
        //    {
        //        //Conn.Close();

        //    }
        //}
        protected void SaveCMD_Click(object sender, EventArgs e)
        {
            SaveData();

        }
        protected void DeleteCMD_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void DeleteData()
        {
            //Check for permission of Delete or not
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEdit,
                InitializeModule.enumPrivilege.Delete, CurrentRole) != true)
            {
                //divMsg.InnerText = InitializeModule.MsgDeleteAuthorization;
                lbl_Msg.Text = InitializeModule.MsgDeleteAuthorization;
                div_msg.Visible = true;
                return;
            }
            Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            try
            {
                Conn.Open();
                if (!string.IsNullOrEmpty(sSelectedValue.Value))
                {
                    //CB.Shift AS byteShift, CB.Class AS byteClass, CB.Course AS strCourse
                    int iShift = 0;
                    int iClass = 0;
                    iShift = Convert.ToInt32(grdStudentGrades.DataKeys[grdStudentGrades.SelectedIndex].Values[0].ToString());
                    iClass = Convert.ToInt32(grdStudentGrades.DataKeys[grdStudentGrades.SelectedIndex].Values[1].ToString());

                    int iEffected = myGrade_HeaderDAL.DeleteGrade_Header((InitializeModule.EnumCampus)iCampus, Convert.ToInt16(iYear.Value), Convert.ToInt16(iSemester.Value), iShift, DdlCourses.SelectedValue, iClass, sSelectedValue.Value);
                    if (iEffected > 0)
                    {
                        //iEffected=myStudents_DataDAL.DeleteStudentsFromRole(" Where " + myStudents_DataDAL.lngSerialFN  + "=" + lblStudentSerialNo.Text,Conn,"");
                        //divMsg.InnerText = "Record Deleted Successfully";
                        lbl_Msg.Text = "Record Deleted Successfully";
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        div_msg.Visible = true;
                        Initialize_Controls();
                    }
                }
                else
                {
                    //divMsg.InnerText = "No Record Selected !";
                    lbl_Msg.Text = "No Record Selected !";
                    div_msg.Visible = true;
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
                Conn.Close();

            }
        }
        private void SaveData()
        {


            try
            {
                //Check for permission of Update or not
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEdit,
                    InitializeModule.enumPrivilege.AddNew, CurrentRole) != true)
                {
                    //divMsg.InnerText = InitializeModule.MsgEditAuthorization;
                    lbl_Msg.Text = InitializeModule.MsgEditAuthorization;
                    div_msg.Visible = true;
                    return;
                }

                if (string.IsNullOrEmpty(sSelectedValue.Value))
                {
                    //divMsg.InnerText = "Please Select Student!";
                    lbl_Msg.Text = "Please Select Student!";
                    div_msg.Visible = true;
                    return;
                }

                if (DdlGrade.SelectedValue == "-1")
                {
                    //divMsg.InnerText = "Please Select Grade!";
                    lbl_Msg.Text = "Please Select Grade!";
                    div_msg.Visible = true;
                    return;
                }
                if (DdlCourses.SelectedValue == "-1")
                {
                    //divMsg.InnerText = "Please Select Course!";
                    lbl_Msg.Text = "Please Select Course!";
                    div_msg.Visible = true;
                    return;
                }

                //SaveCMD.Enabled = false;
                //SaveCMD.ImageUrl = "~/Images/Icons/Save.gif";

                //has permission for [F] grade
                if (DdlGrade.SelectedValue == "F" || DdlGrade.SelectedValue == "Fail")
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEdit,
                    InitializeModule.enumPrivilege.ChangeGrade_F, CurrentRole) != true)
                    {
                        //divMsg.InnerText = "You dont have a permission to assign [F]/[Fail] grade";
                        lbl_Msg.Text = "You dont have a permission to assign [F]/[Fail] grade";
                        div_msg.Visible = true;
                        return;
                    }
                }
                //has permission for [I] grade
                if (DdlGrade.SelectedValue == "I")
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEdit,
                       InitializeModule.enumPrivilege.ChangeGrade_I, CurrentRole) != true)
                    {
                        //divMsg.InnerText = "You dont have a permission to assign Incomplete [I] grade";
                        lbl_Msg.Text = "You dont have a permission to assign Incomplete [I] grade";
                        div_msg.Visible = true;
                        return;
                    }
                }
                //has permission for [NG] grade
                if (DdlGrade.SelectedValue == "NG")
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEdit,
                       InitializeModule.enumPrivilege.ChangeGrade_NG, CurrentRole) != true)
                    {
                        //divMsg.InnerText = "You dont have a permission to assign [NG] grade";
                        lbl_Msg.Text = "You dont have a permission to assign [NG] grade";
                        div_msg.Visible = true;
                        return;
                    }
                }
                string sStudentID = sSelectedValue.Value;

                string sCourse = DdlCourses.SelectedValue;

                string sGrade = DdlGrade.Text;



                ApplicationsDAL myApplicationsDAL = new ApplicationsDAL();
                List<Applications> myApplications = new List<Applications>();

                myApplications = myApplicationsDAL.GetApplications((InitializeModule.EnumCampus)iCampus, " Where " + myApplicationsDAL.lngStudentNumberFN + "='" + sStudentID + "'", false);

                string sDegree = myApplications[0].strDegree;
                string sMajor = myApplications[0].strSpecialization;

                int iInstitute = 0;
                int iY = Convert.ToInt32(iYear.Value);
                int iSem = Convert.ToInt32(iSemester.Value);

                int iShift = 0;
                int iClass = 0;

                iShift = Convert.ToInt32(grdStudentGrades.DataKeys[grdStudentGrades.SelectedIndex].Values[0].ToString());
                iClass = Convert.ToInt32(grdStudentGrades.DataKeys[grdStudentGrades.SelectedIndex].Values[1].ToString());


                string sCond = "";
                string sRetCourse = "";
                sCond = " AND " + myGrade_HeaderDAL.lngStudentNumberFN + "='" + sStudentID + "'";
                sCond += " AND " + myGrade_HeaderDAL.strCourseFN + "='" + sCourse + "'";
                sCond += " AND " + myGrade_HeaderDAL.intStudyYearFN + "=" + iY;
                sCond += " AND " + myGrade_HeaderDAL.byteSemesterFN + "=" + iSem;

                sRetCourse = myGrade_HeaderDAL.IsGradeExists((InitializeModule.EnumCampus)iCampus, sCond);

                int iDataStatus = int.Parse(DataStatus.Value);
                if (sRetCourse != "" && iDataStatus == (int)InitializeModule.enumModes.NewMode)
                {
                    //divMsg.InnerText = "Grade alraedy exist  for this course.";
                    lbl_Msg.Text = "Grade already exist for this course.";
                    div_msg.Visible = true;
                    return;
                }

                if (sRetCourse == "")
                {
                    DataStatus.Value = ((int)InitializeModule.enumModes.NewMode).ToString();
                }
                int iEffected = 0;
                string sPCName = Convert.ToString(Session["CurrentPCName"]);
                string sNetUserName = Convert.ToString(Session["CurrentNetUserName"]);

                iEffected = myGrade_HeaderDAL.UpdateGrade_Header_ForGradesEdit((InitializeModule.EnumCampus)iCampus, iDataStatus,
                    iY, iSem, iShift, sCourse, iClass, sStudentID, iInstitute, 0, sGrade, "0", "0", 0,
                    0, sDegree, sMajor, 0, "", "",
                      Session["CurrentUserName"].ToString(), DateTime.Today.Date, Session["CurrentUserName"].ToString(), DateTime.Today.Date, sPCName, sNetUserName);

                if (iEffected > 0)
                {
                    //divMsg.InnerText = "Data Updated Successfully";
                    lbl_Msg.Text = "Data Updated Successfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    div_msg.Visible = true;
                    GetStudentData();
                }

                DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();




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


            }

        }

        private void GetStudentData()
        {
            grdStudentGrades.DataBind();

        }
        protected void DdlCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlCourseName.SelectedValue = DdlCourses.SelectedValue;
            txtCourse.Text = DdlCourses.SelectedValue;
        }
        protected void DdlCourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlCourses.SelectedValue = DdlCourseName.SelectedValue;
            txtCourse.Text = DdlCourseName.SelectedValue;
        }
        protected void DdlCourses_DataBound(object sender, EventArgs e)
        {
            DdlCourses.Items.Insert(0, new ListItem("Select Course...", "-1"));
        }
        protected void DdlCourseName_DataBound(object sender, EventArgs e)
        {
            DdlCourseName.Items.Insert(0, new ListItem("Select Course...", "-1"));
        }

        protected void CampusCBO_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Session["CurrentCampus"] = Convert.ToInt32(CampusCBO.SelectedValue);
            //iCampus = Convert.ToInt32(CampusCBO.SelectedValue);
        }

        protected void txtCourse_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "";

                sSQL = "SELECT strCourse,strCourseDescEn";
                sSQL += " FROM Reg_Courses";
                sSQL += " WHERE strCourse ='" + txtCourse.Text + "'";


                Connection_StringCLS MyConnection_string = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
                SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());

                Conn.Open();

                System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
                System.Data.SqlClient.SqlDataReader datReader;
                datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


                if (datReader.Read())
                {
                    DdlCourses.SelectedValue = datReader.GetString(0);
                    DdlCourseName.SelectedValue = datReader.GetString(0);
                }



            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
        }
        protected void Terms_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetYearSemester();
        }

        protected void grdStudentGrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Record();
        }
        private void Fill_Record()
        {
            try
            {

                if (grdStudentGrades.SelectedIndex < grdStudentGrades.Rows.Count)
                {
                    if (grdStudentGrades.SelectedRow != null)
                    {

                        string sGrade = "";
                        if (grdStudentGrades.SelectedRow.Cells[5].Text != "&nbsp;")
                        {
                            sGrade = grdStudentGrades.SelectedRow.Cells[5].Text;
                        }

                        if (sGrade == "F" || sGrade == "Fail" || sGrade == "Pass")
                        {
                            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEdit,
                            InitializeModule.enumPrivilege.ChangeGrade_F, CurrentRole) != true)
                            {
                                //divMsg.InnerText = "You dont have a permission to assign [F]/[Fail] or [Pass] grade";
                                lbl_Msg.Text = "You dont have a permission to assign [F]/[Fail] or [Pass] grade";
                                div_msg.Visible = true;
                                return;
                            }
                        }
                        //has permission for [I] grade
                        if (sGrade == "I")
                        {
                            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEdit,
                               InitializeModule.enumPrivilege.ChangeGrade_I, CurrentRole) != true)
                            {
                                //divMsg.InnerText = "You dont have a permission to assign Incomplete [I] grade";
                                lbl_Msg.Text = "You dont have a permission to assign Incomplete [I] grade";
                                div_msg.Visible = true;
                                return;
                            }
                        }
                        //Always allow to change NG to EW or W

                        ////has permission for [NG] grade
                        //if (sGrade == "NG")
                        //{
                        //    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEdit,
                        //       InitializeModule.enumPrivilege.ChangeGrade_NG, CurrentRole) != true)
                        //    {
                        //        divMsg.InnerText = "You dont have a permission to assign [NG] grade";
                        //        return;
                        //    }
                        //}

                        DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();

                        SaveCMD.Enabled = true;
                        //SaveCMD.ImageUrl = "~/Images/Icons/Save.gif";
                        //DeleteCMD.ImageUrl = "~/Images/Icons/Delete.gif";

                        DeleteCMD.Enabled = true;


                        string sCourse = grdStudentGrades.SelectedRow.Cells[3].Text;

                        this.DdlCourses.SelectedValue = sCourse;
                        txtCourse.Text = this.DdlCourses.SelectedValue;
                        this.DdlCourseName.SelectedValue = this.DdlCourses.SelectedValue;


                        if (sGrade == "")
                        {
                            DataStatus.Value = ((int)InitializeModule.enumModes.NewMode).ToString();
                        }
                        else
                        {
                            this.DdlGrade.SelectedValue = sGrade;//grdStudentGrades.SelectedRow.Cells[7].Text;
                        }
                    }
                    // Enable_Disable(grdStudentGrades.SelectedRow != null);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
                lbl_Msg.Text = exp.Message;
                div_msg.Visible = true;
            }
        }
        protected void btnGradesRounding_Click(object sender, EventArgs e)
        {

            string sCourse = "";
            string sStudentID = "";
            string sSQLGrades = "";
            string sGrade = "";
            decimal dMark = 0;
            int iShift = 0;
            int iClass = 0;
            string sGradeNew = "";
            decimal dMarkNew = 0;

            sSQLGrades = "SELECT  lngStudentNumber";
            sSQLGrades += " , strCourse, curUseMark,strGrade";
            sSQLGrades += " ,byteShift, byteClass";

            sSQLGrades += " FROM Reg_Grade_Header";
            sSQLGrades += " WHERE intStudyYear = 2015";
            sSQLGrades += " AND byteSemester =2";
            sSQLGrades += " AND strGrade <> 'NG'";
            sSQLGrades += " AND strGrade <> 'EW'";
            sSQLGrades += " AND strGrade <> 'W'";
            sSQLGrades += " AND strGrade <> 'I'";

            int iCampus = 1;
            Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
            if (Campus.ToString() == "Males")
            {
                iCampus = 1;
            }
            else
            {
                iCampus = 2;
            }

            SqlCommand myCommand = new SqlCommand();
            Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
            string sConn = myConnection_String.Conn_string;
            SqlConnection Conn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sSQLGrades, Conn);
            DataSet ds = new DataSet();

            Conn.ConnectionString = sConn;
            Conn.Open();
            da.Fill(ds, "Grades");
            DataView dv = new DataView(ds.Tables["Grades"], "", "", DataViewRowState.OriginalRows);


            for (int i = 0; i < dv.Count - 1; i++)
            {

                //update grade header
                sCourse = dv[i]["strCourse"].ToString();
                sStudentID = dv[i]["lngStudentNumber"].ToString();
                sGrade = dv[i]["strGrade"].ToString();
                iShift = Convert.ToInt32(dv[i]["byteShift"].ToString());
                iClass = Convert.ToInt32(dv[i]["byteClass"].ToString());
                dMark = Convert.ToDecimal(dv[i]["curUseMark"].ToString());

                //dMarkNew =Convert.ToDouble ( string.Format("{0:F2}",System.Math.Round(dMark))) ;
                dMarkNew = System.Math.Round(dMark, MidpointRounding.AwayFromZero);
                if (dMark != dMarkNew)
                {
                    sGradeNew = GetGradeString(sCourse, dMarkNew);

                    UpdateGradeHeader(iCampus, 2015, 2, sCourse, iClass, iShift, sStudentID, dMarkNew, sGradeNew);
                }
            }
            Conn.Close();
            Conn.Dispose();

        }
        private int GetGradeSystem(string sCourse)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            int iReturn = 0;
            try
            {
                string sSQL = "SELECT byteGradeSystem FROM Reg_Courses WHERE strCourse='" + sCourse + "'";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                iReturn = int.Parse(Cmd.ExecuteScalar().ToString());
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
            return iReturn;
        }
        private string GetGradeString(string sCourse, decimal dMark)
        {
            int iGradeSystem = GetGradeSystem(sCourse);

            if (iGradeSystem == 0)//Normal
            {
                if (dMark < 60)
                {
                    return "F";
                }
                else if (dMark >= 60 && dMark < 64)
                {
                    return "D";
                }
                else if (dMark >= 64 && dMark < 67)
                {
                    return "D+";
                }
                else if (dMark >= 67 && dMark < 70)
                {
                    return "C-";
                }
                else if (dMark >= 70 && dMark < 74)
                {
                    return "C";
                }
                else if (dMark >= 74 && dMark < 77)
                {
                    return "C+";
                }
                else if (dMark >= 77 && dMark < 80)
                {
                    return "B-";
                }
                else if (dMark >= 80 && dMark < 84)
                {
                    return "B";
                }
                else if (dMark >= 84 && dMark < 87)
                {
                    return "B+";
                }
                else if (dMark >= 87 && dMark < 90)
                {
                    return "A-";
                }
                else if (dMark >= 90)
                {
                    return "A";
                }

            }

            else if (iGradeSystem == 1)//ESL
            {
                if (dMark >= 50)
                {
                    return "NC";
                }
                else
                {
                    return "F";
                }

            }
            else if (iGradeSystem == 2)//Pass Fail
            {
                if (dMark >= 60)
                {
                    return "Pass";
                }
                else
                {
                    return "Fail";
                }

            }
            return "";
        }
        private int UpdateGradeHeader(int iCampus, int iYear, int iSem, string sCourse, int bClass, int iShift, string sStudentNumber, decimal dMark, string sGrade)
        {


            int iResult = 0;
            string sSQL = null;
            string sCon = null;
            string sExec = null;


            SqlCommand myCommand = new SqlCommand();
            Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
            string sConn = myConnection_String.Conn_string;

            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();

            //'//Update Header 
            sSQL = "Update Reg_Grade_Header Set";
            sSQL = sSQL + " curUseMark=@Mark,";
            sSQL = sSQL + " strGrade=@Grade";

            sCon = " Where ";
            sCon = sCon + " intStudyYear=@StudyYear";
            sCon = sCon + " And byteSemester=@Semester";
            sCon = sCon + " And strCourse=@Course";
            sCon = sCon + " And byteClass=@Class";
            sCon = sCon + " And byteShift=@Shift";
            sCon = sCon + " And lngStudentNumber=@StudentNumber";

            sExec = sSQL + sCon;

            myCommand = new SqlCommand(sExec, Conn);

            myCommand.Parameters.Add(new SqlParameter("@StudyYear", iYear));
            myCommand.Parameters.Add(new SqlParameter("@Semester", iSem));
            myCommand.Parameters.Add(new SqlParameter("@Shift", iShift));
            myCommand.Parameters.Add(new SqlParameter("@Course", sCourse));
            myCommand.Parameters.Add(new SqlParameter("@Class", bClass));
            myCommand.Parameters.Add(new SqlParameter("@StudentNumber", sStudentNumber));
            myCommand.Parameters.Add(new SqlParameter("@Mark", dMark));
            myCommand.Parameters.Add(new SqlParameter("@Grade", sGrade));


            iResult = myCommand.ExecuteNonQuery();
            Conn.Close();
            Conn.Dispose();
            return iResult;
        }
    }
}