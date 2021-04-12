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
using CrystalDecisions.CrystalReports.Engine;

namespace LocalECT
{
    public partial class CourseCalc : System.Web.UI.Page
    {
        int RoleID = 0;
        int CurrentRole = 0;
        int iCampus = 0;
        string sUserName = "";
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;

        Grade_HeaderDAL myGrade_HeaderDAL = new Grade_HeaderDAL();
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

            sUserName = Convert.ToString("" + Session["CurrentUserName"]);
            //CurrentRole = Convert.ToInt32(Session["CurrentRole"]);

            //Add Event Handler to the custom control
            //Search1.ChangedEvent += new Search1.ChangedEventHandler(Search1_ChangedEvent);
            //Search1.NewEvent += new Search1.ChangedEventHandler(Search1_NewEvent);

            //divMsg.InnerText = "";
            lbl_Msg.Text = "";
            div_msg.Visible = false;

            if (!IsPostBack)
            {
                //Update
                if (Request.QueryString["sid"] != null && Request.QueryString["sid"] != "")
                {
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    string sid = Request.QueryString["sid"];
                    sSelectedValue.Value = sid;
                    sSelectedText.Value = getstudentname(sid);
                    Session["CurrentStudent"] = sSelectedValue.Value;
                    Session["CurrentStudentName"] = sSelectedText.Value;
                }
                if (Campus.ToString() == "Males")
                {
                    iCampus = 1;                    
                }
                else
                {
                    iCampus = 0;                    
                }

                //iCampus = Convert.ToInt32(Session["CurrentCampus"]);

                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_CourseCalc,
                InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");

                }

                Session["myList"] = null;
               
                    if (Session["CurrentStudent"] != null)
                {
                    sSelectedValue.Value = Session["CurrentStudent"].ToString();
                    sSelectedText.Value = Session["CurrentStudentName"].ToString();
                }
                //RunCMD_Click(null,null);
                grdStudentGrades.DataBind();

                DataStatus.Value = ((int)InitializeModule.enumModes.NewMode).ToString();
                SaveCMD.Text = "Add";
                //CampusCBO.SelectedValue = Convert.ToString(iCampus);

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
                    iCampus = 0;
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
            SqlDataSourceInstitute.ConnectionString = sConn;

            //DdlInstitute.DataBind();


            if (!string.IsNullOrEmpty(Request.QueryString["RoleID"]))
            {
                RoleID = int.Parse(Request.QueryString["RoleID"]);

            }

        }
        private void GetStudentData()
        {
            grdStudentGrades.DataBind();
            if (grdStudentGrades.Rows.Count <= 0)
            {
                //lblrecordsCounts.Text = "No TC,EX,NC,EQ Grades for " + sSelectedText.Value;
                lbl_Msg.Text = "No TC,EX,NC,EQ Grades for " + sSelectedText.Value;
                div_msg.Visible = true;
                btnESLExemption.Visible = false;
            }
            else
            {
                //lblrecordsCounts.Text = "";
                lbl_Msg.Text = "";
                div_msg.Visible = false;
                btnESLExemption.Visible = true;
            }
        }
        //Event for the Search Control

        protected void Search1_NewEvent(object Sender, Search1.ChangedEventArgs e)
        {
            sSelectedValue.Value = "";
            sSelectedText.Value = "";
        }
        protected void Search1_ChangedEvent(object Sender, Search1.ChangedEventArgs e)
        {
            sSelectedValue.Value = e.SValue1;

            sSelectedText.Value = e.SValue2;

            iCampus = Convert.ToInt32(Session["CurrentCampus"]);
            //int iSerialNo = LibraryMOD.GetStudentSerialNo(sSelectedValue.Value.ToString(), iCampus);
            int iSerialNo = Convert.ToInt32(e.SValue3);
            Session["StudentSerialNo"] = iSerialNo;

            GetStudentData();
        }

        #region FillDropDownList




        #endregion
        protected void RunCMD_Click(object sender, EventArgs e)
        {
            GetStudentData();
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
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_CourseCalc,
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
                    string sCourse = DdlCourses.SelectedValue;
                    string sCond = "";
                    int iRetShift = 1;
                    sCond = " AND " + myGrade_HeaderDAL.lngStudentNumberFN + "='" + sSelectedValue.Value + "'";
                    sCond += " AND " + myGrade_HeaderDAL.strCourseFN + "='" + sCourse + "'";
                    sCond += " AND " + myGrade_HeaderDAL.intStudyYearFN + "<=0";

                    iRetShift = myGrade_HeaderDAL.IsGradeShiftExists((InitializeModule.EnumCampus)iCampus, sCond);

                    int iEffected = myGrade_HeaderDAL.DeleteGrade_Header((InitializeModule.EnumCampus)iCampus, 0, 0, iRetShift, sCourse, 1, sSelectedValue.Value);
                    if (iEffected > 0)
                    {
                        //iEffected=myStudents_DataDAL.DeleteStudentsFromRole(" Where " + myStudents_DataDAL.lngSerialFN  + "=" + lblStudentSerialNo.Text,Conn,"");
                        //divMsg.InnerText = "Record Deleted Successfully";
                        lbl_Msg.Text = "Record Deleted Successfully";
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        div_msg.Visible = true;
                        Initialize_Controls();
                        GetStudentData();
                    }
                }
                else
                {                    
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
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_CourseCalc,
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

                if (DdlCourses.SelectedValue == "-1" && txtCourse.Text == "")
                {
                    //divMsg.InnerText = "Please Select Course!";
                    lbl_Msg.Text = "Please Select Course!";
                    div_msg.Visible = true;
                    return;
                }
                if (DdlCourses.SelectedValue == "-1" && txtCourse.Text != "")
                {
                    //divMsg.InnerText = "Invalid Course!";
                    lbl_Msg.Text = "Invalid Course!";
                    div_msg.Visible = true;
                    return;
                }
                //if (DdlInstitute.SelectedValue == "-1")
                //{
                //    divMsg.InnerText = "Please Select Institute!";
                //    return;
                //}
                //SaveCMD.Enabled = false;
                //SaveCMD.ImageUrl = "~/Images/Icons/Save.gif";

                string sStudentID = sSelectedValue.Value;

                string sCourse = DdlCourses.SelectedValue;

                string sGrade = DdlGrade.Text;

                ApplicationsDAL myApplicationsDAL = new ApplicationsDAL();
                List<Applications> myApplications = new List<Applications>();


                myApplications = myApplicationsDAL.GetApplications((InitializeModule.EnumCampus)iCampus, " Where " + myApplicationsDAL.lngStudentNumberFN + "='" + sStudentID + "'", false);

                string sDegree = myApplications[0].strDegree;
                string sMajor = myApplications[0].strSpecialization;

                int iInstitute = int.Parse(DdlInstitute.SelectedValue);



                int iEffected = 0;
                int iDataStatus = int.Parse(DataStatus.Value);
                //Check If Course grade exist

                string sCond = "";
                int iRetShift = 1;
                sCond = " AND " + myGrade_HeaderDAL.lngStudentNumberFN + "='" + sStudentID + "'";
                sCond += " AND " + myGrade_HeaderDAL.strCourseFN + "='" + sCourse + "'";
                sCond += " AND " + myGrade_HeaderDAL.intStudyYearFN + "<=0";

                iRetShift = myGrade_HeaderDAL.IsGradeShiftExists((InitializeModule.EnumCampus)iCampus, sCond);

                if (iRetShift > 0 && iDataStatus == (int)InitializeModule.enumModes.NewMode)
                {
                    //System.Windows.Forms.DialogResult  iResult ;
                    //iResult =System.Windows.Forms.MessageBox.Show ("Course already exist.Do you want to edit the grade?","Registration", System.Windows.Forms.MessageBoxButtons.YesNo   );
                    //if (iResult == System.Windows.Forms.DialogResult.Yes)
                    //{
                    //    DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();
                    //}
                    //else
                    //{ 
                    //divMsg.InnerText = "Grade alraedy exist.Duplicate not allowed";
                    lbl_Msg.Text = "Grade alraedy exist.Duplicate not allowed";
                    div_msg.Visible = true;
                    return;
                    //}

                }
                iDataStatus = int.Parse(DataStatus.Value);
                iEffected = myGrade_HeaderDAL.UpdateGrade_Header((InitializeModule.EnumCampus)iCampus, iDataStatus,
                    0, 0, iRetShift, sCourse, 1, sStudentID, iInstitute, 0, sGrade, "0", "0", 0,
                    0, sDegree, sMajor, 0, "", "",
                     Session["CurrentUserName"].ToString(), DateTime.Today.Date, Session["CurrentUserName"].ToString(), DateTime.Today.Date, "", "");

                if (iEffected > 0)
                {
                    //divMsg.InnerText = "Data Updated Successfully";
                    lbl_Msg.Text = "Data Updated Successfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    div_msg.Visible = true;
                    GetStudentData();
                }

                DataStatus.Value = ((int)InitializeModule.enumModes.NewMode).ToString();
                SaveCMD.Text = "Add";
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
                        DataStatus.Value = ((int)InitializeModule.enumModes.EditMode).ToString();
                        SaveCMD.Text = "Save";
                        SaveCMD.Enabled = true;
                        //SaveCMD.ImageUrl = "~/Images/Icons/Save.gif";
                        //DeleteCMD.ImageUrl = "~/Images/Icons/Delete.gif";

                        DeleteCMD.Enabled = true;
                        this.DdlCourses.SelectedValue = grdStudentGrades.SelectedRow.Cells[5].Text;
                        txtCourse.Text = this.DdlCourses.SelectedValue;
                        this.DdlCourseName.SelectedValue = this.DdlCourses.SelectedValue;

                        //int Inst = Convert.ToInt16((grdStudentGrades.Rows[grdStudentGrades.SelectedIndex].FindControl("ddlInstitute") as DropDownList).SelectedValue);
                        //this.DdlInstitute.SelectedValue = Inst.ToString ();

                        this.DdlInstitute.SelectedValue = grdStudentGrades.SelectedRow.Cells[9].Text;

                        //int g = Convert.ToInt32((grdStudentGrades.Rows[grdStudentGrades.SelectedIndex].FindControl("byteShift") as BoundField).  );

                        //if (Inst == null || Inst == "" || Inst == "&nbsp;")
                        //{
                        //    this.DdlInstitute.SelectedValue = "-1";
                        //}
                        //else
                        //{
                        //    this.DdlInstitute.SelectedValue = grdStudentGrades.SelectedRow.Cells[8].Text ;
                        //}


                        this.DdlGrade.SelectedValue = grdStudentGrades.SelectedRow.Cells[8].Text;
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
        protected void DdlInstitute_DataBound(object sender, EventArgs e)
        {
            //DdlInstitute.Items.Insert(0, new ListItem("Select Institute...", "-1"));
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (LibraryMOD.CalcESL(sSelectedValue.Value, Convert.ToInt32(Session["StudentSerialNo"]), iCampus, Session["CurrentUserName"].ToString()) == InitializeModule.TRUE_VALUE)
            {
                DataStatus.Value = InitializeModule.enumModes.EditMode.ToString();
                GetStudentData();
                //divMsg.InnerText = "Data Updated successfully";
                lbl_Msg.Text = "Data Updated successfully";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;
            }
            else
            {
                //divMsg.InnerText = "Fail,Please select student";
                lbl_Msg.Text = "Fail,Please select student";                
                div_msg.Visible = true;
            }


        }




        //protected void CampusCBO_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["CurrentCampus"] = Convert.ToInt32(CampusCBO.SelectedValue);
        //    iCampus = Convert.ToInt32(CampusCBO.SelectedValue);
        //    string sConn = "";

        //    if (iCampus == (int)ECTGlobalDll.InitializeModule.EnumCampus.Males)
        //    {
        //        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
        //        sConn = MyConnection_string.Conn_string;

        //    }
        //    else
        //    {

        //        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Females);
        //        sConn = MyConnection_string.Conn_string;

        //    }

        //    SqlDataSourceStudentGrades.ConnectionString = sConn;
        //    SqlDataSourceInstitute.ConnectionString = sConn;
        //    DdlInstitute.DataBind();

        //}

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
        protected void grdStudentGrades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //string sConn = "";
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (iCampus == (int)ECTGlobalDll.InitializeModule.EnumCampus.Males)
            //    {
            //        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
            //        sConn = MyConnection_string.Conn_string;

            //    }
            //    else
            //    {

            //        Connection_StringCLS MyConnection_string = new Connection_StringCLS(InitializeModule.EnumCampus.Females);
            //        sConn = MyConnection_string.Conn_string;

            //    }

            //    SqlDataSource sqldsrc = (SqlDataSource)e.Row.FindControl("SqlDataSourceInstitute");
            //    if (sqldsrc != null)
            //    {
            //        sqldsrc.ConnectionString = sConn;
            //        //sqldsrc.DataBind();

            //        DropDownList ddl = (DropDownList)e.Row.FindControl("ddlInstitute");
            //        if (ddl != null)
            //        {
            //            ddl.DataValueField = "byteCollege";
            //            ddl.DataTextField = "strCollegeDescEn";
            //            ddl.DataSource = sqldsrc;
            //            ddl.DataBind();
            //        }
            //        //ddl.SelectedValue = "<%# Bind("byteRefCollege") %>";
            //       // ddl.SelectedValue = Eval("byteRefCollege").ToString();

            //    }
            //}


        }

        protected void ddlInstitute_DataBound1(object sender, EventArgs e)
        {
            //DropDownList ddl;
            //ddl=(DropDownList )sender ;
            //ddl.SelectedValue = Eval("byteRefCollege").ToString(); 
        }

        private void Export(DataSet ds)
        {
            ReportDocument myReport = new ReportDocument();
            //TextObject txt;
            try
            {
                string reportPath = "";

                reportPath = Server.MapPath("Reports/CalculatedCrs.rpt");

                myReport.Load(reportPath);
                myReport.SetDataSource(ds);

                //txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtHeader"];
                //txt.Text = "( " + iEffected.ToString() + " ) Record(s) Effected";

                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");

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

        private DataSet Prepare_Report(string sSQL, InitializeModule.EnumCampus Campus)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            Connection_StringCLS sConn = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(sConn.Conn_string);
            Conn.Open();
            try
            {
                DataColumn dc;

                dc = new DataColumn("Serial", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("SID", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Name", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Code", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Course", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Grade", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("From", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("CreatedBy", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Created", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                Cmd.CommandTimeout = 100;
                SqlDataReader Rd = Cmd.ExecuteReader();
                int i = 0;
                while (Rd.Read())
                {
                    dr = dt.NewRow();
                    i += 1;
                    dr["Serial"] = i;
                    dr["SID"] = Rd["SID"].ToString();
                    dr["Name"] = Rd["Name"].ToString();
                    dr["Code"] = Rd["Code"].ToString();
                    dr["Course"] = Rd["Course"].ToString();
                    dr["Grade"] = Rd["Grade"].ToString();
                    dr["From"] = Rd["From"].ToString();
                    dr["CreatedBy"] = Rd["CreatedBy"].ToString();

                    dr["Created"] = string.Format("{0:yyyy-MM-dd}", Rd["Created"]);

                    dt.Rows.Add(dr);
                }

                dt.TableName = "Calculated";
                dt.AcceptChanges();
                ds.Tables.Add(dt);

            }
            catch (Exception ex)
            {
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return ds;
        }

        private string getSQL()
        {
            string sSQL = "";
            try
            {
                sSQL = "SELECT GH.lngStudentNumber AS SID, SD.strLastDescEn AS Name, GH.strCourse AS Code, C.strCourseDescEn AS Course, GH.strGrade AS Grade,";
                sSQL += " FC.strCollegeDescEn as [From], ISNULL(U.EmployeeName,GH.strUserCreate) AS CreatedBy, GH.dateCreate AS Created";
                sSQL += " FROM Reg_Grade_Header AS GH INNER JOIN Reg_Applications AS A ON GH.lngStudentNumber = A.lngStudentNumber INNER JOIN";
                sSQL += " Lkp_Foreign_Colleges AS FC ON GH.byteRefCollege = FC.byteCollege INNER JOIN Reg_Courses AS C ON GH.strCourse = C.strCourse INNER JOIN";
                sSQL += " Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial LEFT OUTER JOIN";
                sSQL += " (SELECT UserName, EmployeeName FROM Localect.ECTDataNew.dbo.Cmn_User) AS U ON GH.strUserCreate = U.UserName COLLATE Arabic_CI_AS";
                sSQL += " WHERE (GH.lngStudentNumber = '" + sSelectedValue.Value + "') AND (GH.strGrade = N'TC')";
                sSQL += " ORDER BY Created DESC";


            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return sSQL;

        }
        protected void printCMD_Click(object sender, EventArgs e)
        {
            InitializeModule.EnumCampus Campus = (InitializeModule.EnumCampus)iCampus;
            Export(Prepare_Report(getSQL(), Campus));
        }

        protected void NewCMD_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}