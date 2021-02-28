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
    public partial class GradesEdit_Alt : System.Web.UI.Page
    {
        int RoleID = 0;
        int CurrentRole = 0;
        int iCampus = 0;
        string sUserName = "";
        Grade_HeaderDAL myGrade_HeaderDAL = new Grade_HeaderDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Security
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
            }
            else
            {
                Server.Transfer("Login.aspx");
            }
            //int CurrentRole = 0;
            sUserName = Convert.ToString("" + Session["CurrentUserName"]);
            //CurrentRole = Convert.ToInt32(Session["CurrentRole"]);

            //Add Event Handler to the custom control
            Search1.ChangedEvent += new Search1.ChangedEventHandler(Search1_ChangedEvent);
            Search1.NewEvent += new Search1.ChangedEventHandler(Search1_NewEvent);

            divMsg.InnerText = "";

            if (!IsPostBack)
            {
                iCampus = Convert.ToInt32(Session["CurrentCampus"]);

                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_AlternativeSetup,
                InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");

                }
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_AlternativeSetup,
                InitializeModule.enumPrivilege.ChangeRegistrationYearSem, CurrentRole) != true)
                {
                    Terms.Enabled = false;
                }
                Session["myList"] = null;
                FillTerms();

                Terms.SelectedValue = Session["CurrentYear"].ToString() + Session["CurrentSemester"].ToString();

                //ddlAcademicYear.SelectedValue = Convert.ToString(Session["CurrentYear"]);
                //ddlSemester.SelectedValue = Convert.ToString(Session["CurrentSemester"]);

                CampusCBO.SelectedValue = Convert.ToString(iCampus);

            }
            else
            {
                iCampus = Convert.ToInt32(CampusCBO.SelectedValue);
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
            GetYearSemester();

            GetSource();

            SqlDataSourceStudentGrades.ConnectionString = sConn;

            Search1.Campus = (InitializeModule.EnumCampus)iCampus;
            // grdStudentGrades.DataBind();

            //foreach (GridViewRow row in grdStudentGrades.Rows)
            //{

            //    SqlDataSource SQldataStudents = row.FindControl("SqlDataStudents") as SqlDataSource;
            //    SQldataStudents.ConnectionString = sConn;
            //}


            if (!string.IsNullOrEmpty(Request.QueryString["RoleID"]))
            {
                RoleID = int.Parse(Request.QueryString["RoleID"]);

            }
            if (!IsPostBack)
            {
                grdStudentGrades.DataBind();
            }


        }
        //Event for the Search Control

        protected void Search1_NewEvent(object Sender, Search1.ChangedEventArgs e)
        {
            sSelectedValue.Value = "";
            sSelectedText.Value = "";
            GetSource();
            grdStudentGrades.DataBind();
        }
        protected void Search1_ChangedEvent(object Sender, Search1.ChangedEventArgs e)
        {
            sSelectedValue.Value = e.SValue1;

            sSelectedText.Value = e.SValue2;

            iCampus = Convert.ToInt32(Session["CurrentCampus"]);
            //int iSerialNo = LibraryMOD.GetStudentSerialNo(sSelectedValue.Value.ToString(), iCampus);
            int iSerialNo = Convert.ToInt32(e.SValue3);
            Session["StudentSerialNo"] = iSerialNo;
            GetSource();
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
                divMsg.InnerText = ex.Message;
            }
            finally
            {
                myTerms.Clear();

            }
        }

        #endregion
        protected void RunCMD_Click(object sender, ImageClickEventArgs e)
        {

            string sSQL = "";
            if (rdbShowAllOutofMajor.Checked)
            {
                sSQL = GetSQL_AllOutofMajor();
            }

            if (rdbStudentGrades.Checked)
            {
                sSQL = GetSQL_StudentAllGrades();
            }

            if (sSQL != "")
            {
                SqlDataSourceStudentGrades.SelectCommand = sSQL;
            }
            grdStudentGrades.DataBind();



        }


        private void Initialize_Controls()
        {
            //DdlGrade.SelectedValue = "-1";

        }


        protected void SaveCMD_Click(object sender, ImageClickEventArgs e)
        {
            //SaveData();

        }

        //private void SaveData()
        //{


        //    try
        //    {
        //        //Check for permission of Update or not
        //        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_AlternativeSetup,
        //            InitializeModule.enumPrivilege.AddNew, CurrentRole) != true)
        //        {
        //            divMsg.InnerText = InitializeModule.MsgEditAuthorization;
        //            return;
        //        }

        //        if (string.IsNullOrEmpty(sSelectedValue.Value))
        //        {
        //            divMsg.InnerText = "Please Select Student!";
        //            return;
        //        }

        //        if (DdlGrade.SelectedValue == "-1")
        //        {
        //            divMsg.InnerText = "Please Select Grade!";
        //            return;
        //        }
        //        if (DdlCourses.SelectedValue == "-1")
        //        {
        //            divMsg.InnerText = "Please Select Course!";
        //            return;
        //        }

        //        //SaveCMD.Enabled = false;
        //        //SaveCMD.ImageUrl = "~/Images/Icons/Save.gif";




        //        string sStudentID = sSelectedValue.Value;

        //        string sCourse = DdlCourses.SelectedValue;

        //        string sGrade = DdlGrade.Text;



        //        ApplicationsDAL myApplicationsDAL = new ApplicationsDAL();
        //        List<Applications> myApplications = new List<Applications>();

        //        myApplications = myApplicationsDAL.GetApplications((InitializeModule.EnumCampus)iCampus, " Where " + myApplicationsDAL.lngStudentNumberFN + "='" + sStudentID + "'", false);

        //        string sDegree = myApplications[0].strDegree;
        //        string sMajor = myApplications[0].strSpecialization;

        //        int iInstitute =-1 ;
        //        int iYear = Convert.ToInt32 ( ddlAcademicYear.SelectedValue);
        //        int iSem = Convert.ToInt32(ddlSemester.SelectedValue);

        //        string sSQL ="";

        //        sSQL ="SELECT Shift,Class";
        //        sSQL +=" FROM Course_Balance_View_Eq";
        //        sSQL += " WHERE iYear = " + iYear;
        //        sSQL += " AND Sem = " + iSem;
        //        sSQL +=" AND Course ='" + sCourse + "'";
        //        sSQL +=" AND Student = '" + sStudentID + "'";

        //        Connection_StringCLS MyConnection_string = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
        //        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());

        //        Conn.Open();

        //        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        //        System.Data.SqlClient.SqlDataReader datReader;
        //        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);

        //        int iShift = 0;
        //        int iClass = 0;
        //        if (datReader.Read())
        //        {
        //            iShift = datReader.GetInt32 (0);
        //            iClass = datReader.GetInt32(1);

        //            datReader.Close();

        //            string sCond = "";
        //            string sRetCourse = "";
        //            sCond = " AND " + myGrade_HeaderDAL.lngStudentNumberFN + "='" + sStudentID + "'";
        //            sCond += " AND " + myGrade_HeaderDAL.strCourseFN + "='" + sCourse + "'";
        //            sCond += " AND " + myGrade_HeaderDAL.intStudyYearFN + "=" + iYear;
        //            sCond += " AND " + myGrade_HeaderDAL.byteSemesterFN  + "=" + iSem;

        //            sRetCourse = myGrade_HeaderDAL.IsGradeExists((InitializeModule.EnumCampus)iCampus, sCond);

        //            if (sRetCourse != "")
        //            {
        //               divMsg.InnerText = "Grade alraedy exist  for this course.";
        //               return;
        //            }

        //            int iDataStatus = (int)InitializeModule.enumModes.NewMode; //int.Parse(DataStatus.Value);

        //            int iEffected = 0;
        //            iEffected = myGrade_HeaderDAL.UpdateGrade_Header((InitializeModule.EnumCampus)iCampus, iDataStatus,
        //                iYear, iSem, iShift, sCourse, iClass, sStudentID, iInstitute,0, sGrade, "0", "0", 0,
        //                0, sDegree, sMajor, 0, "","",
        //                  Session["CurrentUserName"].ToString(), DateTime.Today.Date, Session["CurrentUserName"].ToString(), DateTime.Today.Date,sPCName, sNetUserName);

        //            if (iEffected > 0)
        //            {
        //                divMsg.InnerText = "Data Updated Successfully";
        //                GetStudentData();
        //            }

        //            DataStatus.Value = InitializeModule.enumModes.EditMode.ToString();

        //        }
        //        else
        //        {
        //            datReader.Close();
        //            divMsg.InnerText = "This course not registered in current semester";

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        LibraryMOD.ShowErrorMessage(ex);
        //        divMsg.InnerText = ex.Message;
        //    }
        //    finally
        //    {


        //    }

        //}

        private void GetStudentData()
        {
            grdStudentGrades.DataBind();

        }
        //protected void DdlCourses_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DdlCourseName.SelectedValue = DdlCourses.SelectedValue;
        //    txtCourse.Text = DdlCourses.SelectedValue; 
        //}
        //protected void DdlCourseName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DdlCourses.SelectedValue = DdlCourseName.SelectedValue;
        //    txtCourse.Text = DdlCourseName.SelectedValue; 
        //}
        //protected void DdlCourses_DataBound(object sender, EventArgs e)
        //{
        //    DdlCourses.Items.Insert(0, new ListItem("Select Course...", "-1"));
        //}
        //protected void DdlCourseName_DataBound(object sender, EventArgs e)
        //{
        //    DdlCourseName.Items.Insert(0, new ListItem("Select Course...", "-1"));
        //}



        protected void CampusCBO_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CurrentCampus"] = Convert.ToInt32(CampusCBO.SelectedValue);
            iCampus = Convert.ToInt32(CampusCBO.SelectedValue);

        }

        //protected void txtCourse_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string sSQL = "";

        //        sSQL = "SELECT strCourse,strCourseDescEn";
        //        sSQL += " FROM Reg_Courses";
        //        sSQL += " WHERE strCourse ='" + txtCourse.Text + "'";


        //        Connection_StringCLS MyConnection_string = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
        //        SqlConnection Conn = new SqlConnection(MyConnection_string.Conn_string.ToString());

        //        Conn.Open();

        //        System.Data.SqlClient.SqlCommand CommandSQL = new System.Data.SqlClient.SqlCommand(sSQL, Conn);
        //        System.Data.SqlClient.SqlDataReader datReader;
        //        datReader = CommandSQL.ExecuteReader(CommandBehavior.CloseConnection);


        //        if (datReader.Read())
        //        {
        //            DdlCourses.SelectedValue = datReader.GetString(0);
        //            DdlCourseName.SelectedValue = datReader.GetString(0);
        //        }



        //    }
        //    catch (Exception exp)
        //    {
        //        Console.WriteLine("{0} Exception caught.", exp);
        //        divMsg.InnerText = exp.Message;
        //    }
        //}

        protected void grdStudentGrades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void grdStudentGrades_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string sGrade = "";
            string sAlt = "";
            //string sAlt_OldValue = "";


            string sStudentID = "";

            sGrade = grdStudentGrades.Rows[e.RowIndex].Cells[9].Text;

            sStudentID = grdStudentGrades.Rows[e.RowIndex].Cells[1].Text;
            //sAlt_OldValue=e.OldValues[0].ToString();
            sAlt = Convert.ToString("" + e.NewValues[0]); //grdStudentGrades.Rows[e.RowIndex].Cells[10].Text;//Convert.ToString ("" +  e.NewValues[1]);// 
                                                          //sAlt_OldValue = Convert.ToString("" + e.OldValues[2]);


            bool bValue = false;

            if (sAlt != "")
            {
                switch (sGrade)
                {
                    case "EW":
                    case "W":
                    case "F":
                    case "I":
                    case "NG":
                        bValue = true;
                        divMsg.InnerText = "Grade not passed. Alternative not allowed";
                        break;
                    default:
                        Specialization_CoursesDAL mySpecialization_CoursesDAL = new Specialization_CoursesDAL();
                        ApplicationsDAL myApplicationsDAL = new ApplicationsDAL();
                        Specialization_ElectiveDAL mySpecialization_ElectiveDAL = new Specialization_ElectiveDAL();


                        Boolean IsExist = false;
                        IsExist = mySpecialization_CoursesDAL.IsCourseInMajorPlan(myApplicationsDAL.GetDegree((InitializeModule.EnumCampus)iCampus, sStudentID), myApplicationsDAL.GetMajor((InitializeModule.EnumCampus)iCampus, sStudentID), sAlt) || mySpecialization_ElectiveDAL.IsElectivsInMajorPlan(myApplicationsDAL.GetDegree((InitializeModule.EnumCampus)iCampus, sStudentID), myApplicationsDAL.GetMajor((InitializeModule.EnumCampus)iCampus, sStudentID), sAlt);

                        if (IsExist)
                        {
                            bValue = false;
                            divMsg.InnerText = "";
                        }
                        else
                        {
                            bValue = true;
                            divMsg.InnerText = sAlt + " not in student paln";
                        }
                        //check if the course duplicated (calced before as Major Elective or Free Elective)
                        //sAlt should be uniuqe

                        string sCourseExist = "";
                        string sCond = " AND  sAlt='" + sAlt + "' " + " AND lngStudentNumber ='" + sStudentID + "'";

                        sCourseExist = myGrade_HeaderDAL.IsGradeExists((InitializeModule.EnumCampus)iCampus, sCond);

                        if (sCourseExist == "")
                        {
                            bValue = false;
                            divMsg.InnerText = "";
                        }
                        else
                        {
                            bValue = true;
                            divMsg.InnerText = sAlt + " already calculated as alternative course for " + sCourseExist;
                        }
                        break;
                }

            }
            string sSQL = "";
            int iEffected = 0;


            sSQL = "UPDATE  [dbo].[Reg_Grade_Header] ";
            sSQL += " SET strUserSave ='" + Session["CurrentUserName"].ToString() + "'";
            sSQL += ",dateLastSave=GETDATE()";
            sSQL += " WHERE [intStudyYear]=" + grdStudentGrades.DataKeys[e.RowIndex].Values[0].ToString(); //iYear.Value;
            sSQL += " AND [byteSemester]=" + grdStudentGrades.DataKeys[e.RowIndex].Values[1].ToString();//iSemester.Value;
            sSQL += " AND [strCourse]='" + grdStudentGrades.Rows[e.RowIndex].Cells[6].Text + "'";
            sSQL += " AND [lngStudentNumber]='" + sStudentID + "'";

            Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)iCampus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand Cmd = new SqlCommand(sSQL, Conn);

            Conn.Open();
            if (bValue == false)
            {
                iEffected = Cmd.ExecuteNonQuery();
            }

            e.Cancel = bValue;
        }
        protected void grdStudentGrades_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {


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
        private string GetSQL_AllOutofMajor()
        {
            string sSQL = "";
            try
            {

                sSQL = "SELECT Reg_Grade_Header.intStudyYear";
                sSQL += ",Reg_Grade_Header.byteSemester";
                sSQL += ",Reg_Grade_Header.byteShift ";
                sSQL += ",Reg_Grade_Header.strCourse";
                sSQL += ", Reg_Courses.strCourseDescEn";
                sSQL += ",Reg_Grade_Header.byteClass";
                sSQL += ",Reg_Grade_Header.lngStudentNumber";
                sSQL += ",Reg_Students_Data.strLastDescEn";
                sSQL += ",Reg_Grade_Header.strGrade";
                sSQL += ",Reg_Grade_Header.sAlt ";

                sSQL += " FROM Reg_Students_Data INNER JOIN Reg_Applications ON Reg_Students_Data.lngSerial = Reg_Applications.lngSerial INNER JOIN";
                sSQL += " Reg_Grade_Header ON Reg_Applications.lngStudentNumber = Reg_Grade_Header.lngStudentNumber INNER JOIN";
                sSQL += " Reg_Courses ON Reg_Grade_Header.strCourse = Reg_Courses.strCourse LEFT OUTER JOIN Reg_Specilization_Courses_And_Elective ON Reg_Grade_Header.strMajor = Reg_Specilization_Courses_And_Elective.strSpecialization AND ";
                sSQL += " Reg_Grade_Header.strDegree = Reg_Specilization_Courses_And_Elective.strDegree AND Reg_Grade_Header.strCourse = Reg_Specilization_Courses_And_Elective.strCourse";
                sSQL += " WHERE Reg_Grade_Header.bDisActivated=0 AND Reg_Grade_Header.bCanceled=0 AND Reg_Grade_Header.strGrade<>'AL'";


                if (Convert.ToInt32(iYear.Value) > 0)
                {
                    sSQL += " AND (Reg_Grade_Header.intStudyYear = " + Convert.ToInt32(iYear.Value) + ")";
                }

                if (Convert.ToInt32(iSemester.Value) > 0)
                {
                    sSQL += " AND (Reg_Grade_Header.byteSemester = " + Convert.ToInt32(iSemester.Value) + ")";
                }
                sSQL += " AND (Reg_Specilization_Courses_And_Elective.strCourse IS NULL) ";
                sSQL += " AND (Reg_Grade_Header.strMajor <> N'999')";
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                divMsg.InnerText = ex.Message;
            }
            finally
            {
                //Conn.Close();

            }
            return sSQL;
        }
        private string GetSQL_StudentAllGrades()
        {
            string sSQL = "";
            try
            {

                sSQL = "SELECT Reg_Grade_Header.intStudyYear";
                sSQL += " ,Reg_Grade_Header.byteSemester";
                sSQL += " ,Reg_Grade_Header.byteShift";
                sSQL += " ,Reg_Grade_Header.strCourse ";
                sSQL += ", Reg_Courses.strCourseDescEn";
                sSQL += " ,Reg_Grade_Header.byteClass";
                sSQL += " ,Reg_Grade_Header.lngStudentNumber";
                sSQL += " ,Reg_Students_Data.strLastDescEn ";
                sSQL += " ,Reg_Grade_Header.strGrade";
                sSQL += " ,Reg_Grade_Header.sAlt";

                sSQL += " FROM Reg_Students_Data INNER JOIN Reg_Applications ON Reg_Students_Data.lngSerial = Reg_Applications.lngSerial INNER JOIN";
                sSQL += " Reg_Grade_Header ON Reg_Applications.lngStudentNumber = Reg_Grade_Header.lngStudentNumber INNER JOIN Reg_Courses ON Reg_Grade_Header.strCourse = Reg_Courses.strCourse";

                sSQL += " WHERE Reg_Grade_Header.bDisActivated=0 AND Reg_Grade_Header.bCanceled=0 AND Reg_Grade_Header.strGrade<>'AL'";


                if (Convert.ToInt32(iYear.Value) > 0)
                {
                    sSQL += " AND (Reg_Grade_Header.intStudyYear = " + Convert.ToInt32(iYear.Value) + ")";
                }

                if (Convert.ToInt32(iSemester.Value) > 0)
                {
                    sSQL += " AND (Reg_Grade_Header.byteSemester = " + Convert.ToInt32(iSemester.Value) + ")";
                }

                if ("" + sSelectedValue.Value != "")
                {
                    sSQL += " AND (Reg_Grade_Header.lngStudentNumber = '" + sSelectedValue.Value + "')";
                }

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                divMsg.InnerText = ex.Message;
            }
            finally
            {
                //Conn.Close();

            }
            return sSQL;
        }
        protected void rdbShowAllOutofMajor_CheckedChanged(object sender, EventArgs e)
        {
            switch (((CheckBox)sender).ID)
            {
                case "rdbShowAllOutofMajor":
                    Search1.Visible = false;
                    break;
                case "rdbStudentGrades":
                    Search1.Visible = true;
                    break;
                default:
                    Search1.Visible = false;
                    break;
            }
        }

        private void GetSource()
        {
            string sSQL = "";
            if (rdbShowAllOutofMajor.Checked)
            {
                sSQL = GetSQL_AllOutofMajor();
            }

            if (rdbStudentGrades.Checked)
            {
                sSQL = GetSQL_StudentAllGrades();
            }

            if (sSQL != "")
            {
                SqlDataSourceStudentGrades.SelectCommand = sSQL;
            }

        }
    }
}