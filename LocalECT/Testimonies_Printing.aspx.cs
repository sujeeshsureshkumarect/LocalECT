using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LocalECT
{
    public partial class Testimonies_Printing : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;
        int CurrentRole = 0;
        int iCYear = 0;
        int iCSem = 0;
        int iTerm = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];

                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.TestimoniesPrinting, CurrentRole) != true)
                {
                    //divMsg.InnerText = "Sorry you cannot print testimonies";
                    lbl_Msg.Text = "Sorry you cannot print testimonies";
                    div_msg.Visible = true;
                    return;
                }
                Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];

                if (!IsPostBack)
                {
                    iCYear = Convert.ToInt32(Session["CurrentYear"].ToString());
                    iCSem = Convert.ToInt32(Session["CurrentSemester"].ToString()); ;
                    iTerm = iCYear * 10 + iCSem;
                    setDates();
                    string sid = Request.QueryString["sid"];
                    lblID.Text = sid;
                    string sname = getstudentname(sid);
                    lblName.Text = sname;
                    FillTerms();
                    Terms.SelectedValue = iTerm.ToString();
                    Fill_Included();
                    
                    if (LibraryMOD.IsFileVerifiedFromRegistrar(lblID.Text, Campus) == InitializeModule.FALSE_VALUE)
                    {
                        //divMsg.InnerText = "Please contact the Registrar to verfiy student file";
                        lbl_Msg.Text = "Please contact the Registrar to verfiy student file";
                        div_msg.Visible = true;
                        //Server.Transfer("Authorization.aspx");
                        return;
                    }

                    //if (LibraryMOD.isFinanceProblems((InitializeModule.EnumCampus)Campus, lblID.Text) == true)
                    //{
                    //    divMsg.InnerText = "Please contact accounting department to get clearance card";
                    //    return;
                    //}
                    //txtDateFrom.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date);
                    //txtDateTo.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Today.Date.AddDays(1));
                }
                else
                {

                    iTerm = Convert.ToInt32(Terms.SelectedValue);
                    iCYear = LibraryMOD.SeperateTerm(iTerm, out iCSem);
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
        private void setDates()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            string sConn = myConnection_String.Conn_string;
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            try
            {
                string sSQL = "SELECT dateStartSemester,dateEndSemester FROM Reg_Semesters WHERE intStudyYear=" + iCYear + " AND byteSemester=" + iCSem;
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                string sDate1 = "";
                string sDate2 = "";

                while (Rd.Read())
                {
                    sDate1 = string.Format("{0:dd-MM-yyyy}", Rd["dateStartSemester"]);
                    sDate2 = string.Format("{0:dd-MM-yyyy}", Rd["dateEndSemester"]);
                    txtDateFrom.Text = string.Format("{0:yyyy-MM-dd}", Rd["dateStartSemester"]);
                    txtDateTo.Text = string.Format("{0:yyyy-MM-dd}", Rd["dateEndSemester"]);
                }
                switch (rbnTestimony.SelectedIndex)
                {
                    case 1://Final
                    case 2://Final Attend
                        txtDateFrom.Text = GetFinalExamsStartDate(0);
                        txtDateTo.Text = GetFinalExamsStartDate(1);
                        break;
                    default:

                        break;
                }
                Rd.Close();

            }

            catch (Exception exp)
            {

            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }
        private string GetFinalExamsStartDate(int iStartEnd)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            string sConn = myConnection_String.Conn_string;
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            string sDate1 = string.Format("{0:yyyy-MM-dd}", "1900-12-31");
            try
            {

                string sSQL = "";

                if (iStartEnd == 0)
                {
                    sSQL += "SELECT MIN(dTime) AS dDate ";
                }
                else
                {
                    sSQL += "SELECT MAX(dTime) AS dDate ";
                }

                sSQL += " FROM Reg_Final_Group ";
                sSQL += " WHERE Year=" + iCYear + " AND Semester=" + iCSem;
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                while (Rd.Read())
                {
                    if (Rd["dDate"] == null)
                    {
                        sDate1 = string.Format("{0:yyyy-MM-dd}", "1900-12-31");
                    }
                    sDate1 = string.Format("{0:yyyy-MM-dd}", Rd["dDate"]);
                }

                if (sDate1 == "")
                { sDate1 = string.Format("{0:yyyy-MM-dd}", "1900-12-31"); }
            }
            catch (Exception exp)
            {

            }
            finally
            {

            }
            return sDate1;
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
        private void Fill_Included()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            string sConn = myConnection_String.Conn_string;
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();

            try
            {
                //int iTerm = Convert.ToInt32(Terms.SelectedValue);

                //int iSem = 0;//Convert.ToInt32("0" + Session["RegSemester"].ToString());
                //int iYear = 0;// Convert.ToInt32("0" + Session["RegYear"].ToString());
                //iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

                string sStudentNumber = lblID.Text;

                string sSQL = "SELECT CB.Course, C.strCourseDescEn,'Females' as Campus ";
                sSQL += " FROM SQL_Server.ECTData.dbo.Course_Balance_View AS CB INNER JOIN ";
                sSQL += " SQL_Server.ECTData.dbo.Reg_Courses AS C ON CB.Course = C.strCourse";
                sSQL += " WHERE (CB.iYear = " + iCYear + ") AND (CB.Sem = " + iCSem + ") ";
                sSQL += " AND (CB.Student = '" + sStudentNumber + "')";
                sSQL += " UNION ";
                sSQL += " SELECT CB.Course, C.strCourseDescEn,'Males' as Campus ";
                sSQL += " FROM Localect.ECTData.dbo.Course_Balance_View AS CB INNER JOIN ";
                sSQL += " Localect.ECTData.dbo.Reg_Courses AS C ON CB.Course = C.strCourse";
                sSQL += " WHERE (CB.iYear = " + iCYear + ") AND (CB.Sem = " + iCSem + ") ";
                sSQL += " AND (CB.Student = '" + sStudentNumber + "')";

                sSQL += " ORDER BY CB.Course";

                SqlCommand cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader rd = cmd.ExecuteReader();

                System.Web.UI.WebControls.ListItem lst;

                chkIncluded.Items.Clear();
                while (rd.Read())
                {
                    lst = new System.Web.UI.WebControls.ListItem(rd["Course"].ToString());
                    lst.Selected = true;
                    chkIncluded.Items.Add(lst);
                }

                rd.Close();


            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();

            }

        }
        protected void rbnTestimony_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbnLanguage.SelectedIndex = 0;
            rbnLanguage.Enabled = true;
            if (rbnTestimony.SelectedIndex == 0 || rbnTestimony.SelectedIndex == 1 || rbnTestimony.SelectedIndex == 5)
            {
                rbnLanguage.Enabled = true;
            }
            if (rbnTestimony.SelectedIndex == 6)
            {
                rbnLanguage.Enabled = true;
                rbnLanguage.SelectedIndex = 1;
                rbnLanguage.Enabled = false;

            }
            txtDateFrom.Enabled = true;
            //PopCalendar1.Enabled = true;
            txtDateTo.Enabled = true;
            //PopCalendar2.Enabled = true;
            //Word_btn.Visible  = true;

            setDates();

            switch (rbnTestimony.SelectedIndex)
            {
                case 0://Registered
                    if (chkTable.Checked == false)
                    {
                        txtDateFrom.Enabled = false;
                        //PopCalendar1.Enabled = false;
                        txtDateTo.Enabled = false;
                        //PopCalendar2.Enabled = false;
                        //Word_btn.Visible = false;
                    }
                    break;
                case 1://Final
                case 2://Final Attend
                case 5://Graduation
                case 6://Graduate verfication form
                    txtDateFrom.Enabled = false;
                    //PopCalendar1.Enabled = false;
                    txtDateTo.Enabled = false;
                    //PopCalendar2.Enabled = false;
                    //Word_btn.Visible = false;
                    break;
                case 3://Training
                    break;
                case 4://Admission
                    break;
            }
        }

        protected void Terms_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDates();
            Fill_Included();
        }

        protected void rbnLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chkTable_CheckedChanged(object sender, EventArgs e)
        {
            //txtDateFrom.Enabled = true;
            //PopCalendar1.Enabled = true;
            //txtDateTo.Enabled = true;
            //PopCalendar2.Enabled = true;
            //Word_btn.Visible = true;

            switch (rbnTestimony.SelectedIndex)
            {
                case 0://Registered
                    if (chkTable.Checked == false)
                    {
                        txtDateFrom.Enabled = false;
                        //PopCalendar1.Enabled = false;
                        txtDateTo.Enabled = false;
                        //PopCalendar2.Enabled = false;
                        //Word_btn.Visible = false;
                    }
                    break;
                case 1://Final
                case 2://Final Attend
                case 5://Graduation
                case 6://Graduate verfication form
                    txtDateFrom.Enabled = false;
                    //PopCalendar1.Enabled = false;
                    txtDateTo.Enabled = false;
                    //PopCalendar2.Enabled = false;
                    //Word_btn.Visible = false;
                    break;
                case 3://Training
                    break;
                case 4://Admission
                    break;
            }
        }       
        protected void Print_btn_Click(object sender, EventArgs e)
        {
            PrintTestimony("Print_btn");
        }
        protected void PrintTestimony(string sbtnID)
        {
            //Testimonies_Reg
            //Testimonies_Final
            //Testimonies_FinalAttend
            //Testimonies_Training
            //Testimonies_Admission
            //Testimonies_Graduation
            //Form_Graduate Verfication

            if (LibraryMOD.IsFileVerifiedFromRegistrar(lblID.Text, Campus) == InitializeModule.FALSE_VALUE)
            {
                //divMsg.InnerText = "Please contact the Registrar to verfiy student file";
                lbl_Msg.Text = "Please contact the Registrar to verfiy student file";
                div_msg.Visible = true;
                //Server.Transfer("Authorization.aspx");
                return;
            }

            if (LibraryMOD.isFinanceProblems((InitializeModule.EnumCampus)Campus, lblID.Text) == true && rbnTestimony.SelectedIndex == 5)//Graduation letter need clearnace card
            {
                //divMsg.InnerText = "Please contact accounting department to get clearance card";
                lbl_Msg.Text = "Please contact accounting department to get clearance card";
                div_msg.Visible = true;
                //Server.Transfer("Authorization.aspx");
                return;
            }

            switch (rbnTestimony.SelectedIndex)
            {
                case 0://Registered

                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                       InitializeModule.enumPrivilege.Testimonies_Reg, CurrentRole) != true)
                    {
                        //divMsg.InnerText = "Sorry you cannot print registration testimony";
                        lbl_Msg.Text = "Sorry you cannot print registration testimony";
                        div_msg.Visible = true;
                        return;
                    }
                    break;
                case 1://Final
                case 2://Final Attend

                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                      InitializeModule.enumPrivilege.Testimonies_Final, CurrentRole) != true)
                    {
                        //divMsg.InnerText = "Sorry you cannot print final exam testimony";
                        lbl_Msg.Text = "Sorry you cannot print final exam testimony";
                        div_msg.Visible = true;
                        return;
                    }
                    break;
                case 3://Training

                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                      InitializeModule.enumPrivilege.Testimonies_Training, CurrentRole) != true)
                    {
                        //divMsg.InnerText = "Sorry you cannot print training testimony";
                        lbl_Msg.Text = "Sorry you cannot print training testimony";
                        div_msg.Visible = true;
                        return;
                    }
                    break;
                case 4://Admission

                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                      InitializeModule.enumPrivilege.Testimonies_Admission, CurrentRole) != true)
                    {
                        //divMsg.InnerText = "Sorry you cannot print admission testimony";
                        lbl_Msg.Text = "Sorry you cannot print admission testimony";
                        div_msg.Visible = true;
                        return;
                    }
                    break;
                case 5://Graduation

                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                      InitializeModule.enumPrivilege.Testimonies_Graduation, CurrentRole) != true)
                    {
                        //divMsg.InnerText = "Sorry you cannot print graduation testimony";
                        lbl_Msg.Text = "Sorry you cannot print graduation testimony";
                        div_msg.Visible = true;
                        return;
                    }
                    break;
                case 6://Graduate verfication form

                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                      InitializeModule.enumPrivilege.Testimonies_Graduation, CurrentRole) != true)
                    {
                        //divMsg.InnerText = "Sorry you cannot print graduate verfication form";
                        lbl_Msg.Text = "Sorry you cannot print graduate verfication form";
                        div_msg.Visible = true;
                        return;
                    }
                    break;
            }

            Retrieve(sbtnID);
        }
        private string Get_Condition()
        {
            string sReturn = "";
            try
            {
                for (int i = 0; i < chkIncluded.Items.Count; i++)
                {
                    if (chkIncluded.Items[i].Selected)
                    {
                        if (string.IsNullOrEmpty(sReturn))
                        {
                            sReturn = " AND ( C.strCourse='" + chkIncluded.Items[i].Text + "'";
                        }
                        else
                        {
                            sReturn += " OR C.strCourse='" + chkIncluded.Items[i].Text + "'";
                        }
                    }
                }
                if (!string.IsNullOrEmpty(sReturn))
                {
                    sReturn += ")";
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {

            }
            return sReturn;
        }
        private void Retrieve(string sbtn)
        {
            string sYear = "";
            string sSem = "";
            string sDate1 = "";
            string sDate2 = "";
            bool isMale = false;

            DataSet Ds = new DataSet();
            try
            {

                int iTerm = Convert.ToInt32(Terms.SelectedValue);

                int iSem = 0;//Convert.ToInt32("0" + Session["RegSemester"].ToString());
                int iYear = 0;// Convert.ToInt32("0" + Session["RegYear"].ToString());
                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

                string sStudentNumber = lblID.Text;

                string sSQL = "";

                if (rbnTestimony.SelectedIndex == 1 || rbnTestimony.SelectedIndex == 2)
                {
                    //Females
                    sSQL = "SELECT CB.iYear, CB.Sem AS bSem, A.lngStudentNumber AS sSno";
                    if (rbnLanguage.SelectedIndex == 0)//Arabic
                    {
                        sSQL += " , ISNULL(SD.strLastDescAr, N'No Arabic Name') AS sName";
                        sSQL += " , M.strDisplay AS sMajor";
                    }
                    else  // English
                    {
                        sSQL += " ,SD.strLastDescEn AS sName";
                        sSQL += " ,M.strDisplay AS sMajor";
                    }


                    sSQL += " , SD.bSex, C.strCourse, C.strCourseDescEn";
                    sSQL += " , FG.dTime, FG.sDesc,'Females' as Campus";
                    sSQL += " FROM SQL_Server.ECTData.dbo.Course_Balance_View AS CB INNER JOIN ";
                    sSQL += " SQL_Server.ECTData.dbo.Lkp_Semesters AS S ON CB.Sem = S.byteSemester INNER JOIN";
                    sSQL += " SQL_Server.ECTData.dbo.Reg_Applications AS A ";
                    sSQL += " INNER JOIN SQL_Server.ECTData.dbo.Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON CB.Student = A.lngStudentNumber INNER JOIN";
                    sSQL += " SQL_Server.ECTData.dbo.Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN";
                    sSQL += " SQL_Server.ECTData.dbo.Reg_Courses AS C ON CB.Course = C.strCourse INNER JOIN ";
                    sSQL += " SQL_Server.ECTData.dbo.Reg_Final_Exam_Checker AS F ON CB.Course = F.Course AND CB.iYear = F.Year AND CB.Sem = F.Semester INNER JOIN";
                    sSQL += " SQL_Server.ECTData.dbo.Reg_Final_Group AS FG ON F.GroupID = FG.iGroupID AND F.Year = FG.Year AND F.Semester = FG.Semester LEFT OUTER JOIN";
                    sSQL += " SQL_Server.ECTData.dbo.W_EW AS W ON CB.iYear = W.intStudyYear AND CB.Sem = W.byteSemester AND CB.Course = W.strCourse AND CB.Student = W.lngStudentNumber";
                    sSQL += " WHERE W.lngStudentNumber IS NULL";
                    sSQL += " AND  A.lngStudentNumber = '" + sStudentNumber + "'";
                    sSQL += " AND CB.iYear = " + iYear + " AND CB.Sem = " + iSem;
                    if (chkTable.Checked)
                    {
                        string sCondition = Get_Condition();
                        if (!string.IsNullOrEmpty(sCondition))
                        {
                            sSQL += sCondition;
                        }
                    }
                    //Males
                    sSQL += " UNION ";
                    sSQL += " SELECT CB.iYear, CB.Sem AS bSem, A.lngStudentNumber AS sSno";
                    if (rbnLanguage.SelectedIndex == 0)//Arabic
                    {
                        sSQL += " , ISNULL(SD.strLastDescAr, N'No Arabic Name') AS sName";
                        sSQL += " , M.strDisplay AS sMajor";
                    }
                    else  // English
                    {
                        sSQL += " ,SD.strLastDescEn AS sName";
                        sSQL += " ,M.strDisplay AS sMajor";
                    }

                    sSQL += " , SD.bSex, C.strCourse, C.strCourseDescEn";
                    sSQL += " , FG.dTime, FG.sDesc,'Males' as Campus";
                    sSQL += " FROM Localect.ECTData.dbo.Course_Balance_View AS CB INNER JOIN ";
                    sSQL += " Localect.ECTData.dbo.Lkp_Semesters AS S ON CB.Sem = S.byteSemester INNER JOIN";
                    sSQL += " Localect.ECTData.dbo.Reg_Applications AS A INNER JOIN ";
                    sSQL += " Localect.ECTData.dbo.Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON CB.Student = A.lngStudentNumber INNER JOIN";
                    sSQL += " Localect.ECTData.dbo.Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN";
                    sSQL += " Localect.ECTData.dbo.Reg_Courses AS C ON CB.Course = C.strCourse INNER JOIN ";
                    sSQL += " Localect.ECTData.dbo.Reg_Final_Exam_Checker AS F ON CB.Course = F.Course AND CB.iYear = F.Year AND CB.Sem = F.Semester INNER JOIN";
                    sSQL += " Localect.ECTData.dbo.Reg_Final_Group AS FG ON F.GroupID = FG.iGroupID AND F.Year = FG.Year AND F.Semester = FG.Semester LEFT OUTER JOIN";
                    sSQL += " Localect.ECTData.dbo.W_EW AS W ON CB.iYear = W.intStudyYear AND CB.Sem = W.byteSemester AND CB.Course = W.strCourse AND CB.Student = W.lngStudentNumber";
                    sSQL += " WHERE W.lngStudentNumber IS NULL";
                    sSQL += " AND  A.lngStudentNumber = '" + sStudentNumber + "'";
                    sSQL += " AND CB.iYear = " + iYear + " AND CB.Sem = " + iSem;

                }
                else if (rbnTestimony.SelectedIndex == 4)
                {
                    sSQL = "SELECT A.intStudyYear as iYear, A.byteSemester as bSem, A.lngStudentNumber AS sSno";
                    sSQL += " , ISNULL(SD.strLastDescAr, N'No Arabic Name') AS sName, M.strSpecializationDescAr AS sMajor,";
                    sSQL += " SD.bSex, 'AD1' AS strCourse, 'Admission' AS strCourseDescEn";
                    sSQL += " , CONVERT(varchar, GETDATE(), 108) AS dateTimeFrom ";
                    sSQL += " , CONVERT(varchar, GETDATE(), 108) AS dateTimeTo";
                    sSQL += " ,CONVERT(varchar, GETDATE(), 105) AS dTime, '' AS sDesc";
                    sSQL += " FROM Reg_Specializations AS M INNER JOIN Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON M.strCollege = A.strCollege AND M.strDegree = A.strDegree AND M.strSpecialization = A.strSpecialization";
                    sSQL += " AND  A.lngStudentNumber = '" + sStudentNumber + "'";

                }
                else if (rbnTestimony.SelectedIndex == 0 || rbnTestimony.SelectedIndex == 3)
                {

                    //Females
                    sSQL = "SELECT CB.iYear, CB.Sem AS bSem, A.lngStudentNumber AS sSno";
                    if (rbnLanguage.SelectedIndex == 0)//Arabic
                    {
                        sSQL += " ,ISNULL(SD.strLastDescAr, N'No Arabic Name') AS sName";
                        sSQL += " ,M.strSpecializationDescAr AS sMajor";
                    }
                    else  // English
                    {
                        sSQL += " ,SD.strLastDescEn AS sName";
                        sSQL += " ,M.strDisplay AS sMajor";
                    }
                    sSQL += " ,SD.bSex, C.strCourse";
                    sSQL += " ,C.strCourseDescEn,CONVERT(varchar,CT.dateTimeFrom, 108) AS dateTimeFrom ";
                    sSQL += " ,CONVERT(varchar,CT.dateTimeTo, 108) AS dateTimeTo ";
                    sSQL += " ,CONVERT(varchar, GETDATE(), 105) AS dTime, '' AS sDesc,'Females' as Campus";
                    sSQL += " FROM SQL_Server.ECTData.dbo.Reg_CourseTime_Schedule AS CT INNER JOIN ";
                    sSQL += " SQL_Server.ECTData.dbo.Course_Balance_View AS CB INNER JOIN ";
                    sSQL += " SQL_Server.ECTData.dbo.Lkp_Semesters AS S ON CB.Sem = S.byteSemester INNER JOIN";
                    sSQL += " SQL_Server.ECTData.dbo.Reg_Applications AS A INNER JOIN ";
                    sSQL += " SQL_Server.ECTData.dbo.Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON CB.Student = A.lngStudentNumber INNER JOIN";
                    sSQL += " SQL_Server.ECTData.dbo.Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN";
                    sSQL += " SQL_Server.ECTData.dbo.Reg_Courses AS C ON CB.Course = C.strCourse ON CT.intStudyYear = CB.iYear AND CT.byteSemester = CB.Sem AND CT.strCourse = CB.Course ";
                    sSQL += " AND CT.byteShift = CB.Shift AND CT.byteClass = CB.Class ";
                    sSQL += " LEFT OUTER JOIN SQL_Server.ECTData.dbo.W_EW AS W ON CB.iYear = W.intStudyYear AND CB.Sem = W.byteSemester AND CB.Course = W.strCourse AND CB.Student = W.lngStudentNumber";
                    sSQL += " WHERE W.lngStudentNumber IS NULL";
                    sSQL += " AND  A.lngStudentNumber = '" + sStudentNumber + "'";
                    sSQL += " AND CB.iYear = " + iYear + " AND CB.Sem = " + iSem;
                    if (chkTable.Checked)
                    {
                        string sCondition = Get_Condition();
                        if (!string.IsNullOrEmpty(sCondition))
                        {
                            sSQL += sCondition;
                        }
                    }
                    sSQL += " UNION ";
                    //Males
                    sSQL += " SELECT CB.iYear, CB.Sem AS bSem, A.lngStudentNumber AS sSno";
                    if (rbnLanguage.SelectedIndex == 0)//Arabic
                    {
                        sSQL += " ,ISNULL(SD.strLastDescAr, N'No Arabic Name') AS sName";
                        sSQL += " ,M.strSpecializationDescAr AS sMajor";
                    }
                    else  // English
                    {
                        sSQL += " ,SD.strLastDescEn AS sName";
                        sSQL += " ,M.strDisplay AS sMajor";
                    }

                    sSQL += " ,SD.bSex, C.strCourse";
                    sSQL += " ,C.strCourseDescEn,CONVERT(varchar,CT.dateTimeFrom, 108) AS dateTimeFrom ";
                    sSQL += " ,CONVERT(varchar,CT.dateTimeTo, 108) AS dateTimeTo ";
                    sSQL += " ,CONVERT(varchar, GETDATE(), 105) AS dTime, '' AS sDesc,'Males' as Campus";
                    sSQL += " FROM Localect.ECTData.dbo.Reg_CourseTime_Schedule AS CT INNER JOIN ";
                    sSQL += " Localect.ECTData.dbo.Course_Balance_View AS CB INNER JOIN ";
                    sSQL += " Localect.ECTData.dbo.Lkp_Semesters AS S ON CB.Sem = S.byteSemester INNER JOIN";
                    sSQL += " Localect.ECTData.dbo.Reg_Applications AS A INNER JOIN ";
                    sSQL += " Localect.ECTData.dbo.Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON CB.Student = A.lngStudentNumber INNER JOIN";
                    sSQL += " Localect.ECTData.dbo.Reg_Specializations AS M ON A.strCollege = M.strCollege AND A.strDegree = M.strDegree AND A.strSpecialization = M.strSpecialization INNER JOIN";
                    sSQL += " Localect.ECTData.dbo.Reg_Courses AS C ON CB.Course = C.strCourse ON CT.intStudyYear = CB.iYear AND CT.byteSemester = CB.Sem AND CT.strCourse = CB.Course ";
                    sSQL += " AND CT.byteShift = CB.Shift AND CT.byteClass = CB.Class ";
                    sSQL += " LEFT OUTER JOIN SQL_Server.ECTData.dbo.W_EW AS W ON CB.iYear = W.intStudyYear AND CB.Sem = W.byteSemester AND CB.Course = W.strCourse AND CB.Student = W.lngStudentNumber";
                    sSQL += " WHERE W.lngStudentNumber IS NULL";
                    sSQL += " AND  A.lngStudentNumber = '" + sStudentNumber + "'";
                    sSQL += " AND CB.iYear = " + iYear + " AND CB.Sem = " + iSem;

                }
                else//Graduation
                {
                    if (rbnLanguage.SelectedIndex == 0)//Arabic
                    {
                        sSQL = "SELECT A.intGraduationYear AS iYear, A.byteGraduationSemester AS bSem";
                        sSQL += " , A.lngStudentNumber AS sSno";
                        sSQL += " , ISNULL(SD.strLastDescAr, N'No Arabic Name') AS sName,M.strSpecializationDescAr AS sMajor, SD.bSex, CG.GPA AS CGPA";
                        sSQL += " , Degree=CASE A.strDegree WHEN '1' THEN 'دبلوم' WHEN '3' THEN 'Bachelor' WHEN 'بكالوريوس' THEN '-' END";
                        sSQL += " FROM Reg_Specializations AS M INNER JOIN Reg_Applications AS A INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON M.strCollege = A.strCollege AND M.strDegree = A.strDegree AND ";
                        sSQL += " M.strSpecialization = A.strSpecialization INNER JOIN GPA_Until AS CG ON A.lngStudentNumber = CG.lngStudentNumber";

                    }
                    else
                    {
                        sSQL = "SELECT A.intGraduationYear AS iYear, A.byteGraduationSemester AS bSem";
                        sSQL += " , A.lngStudentNumber AS sSno";
                        sSQL += " , SD.strLastDescEn AS sName,M.strDisplay AS sMajor, SD.bSex, CG.GPA AS CGPA";
                        sSQL += " , Degree=CASE A.strDegree WHEN '1' THEN 'Diploma' WHEN '3' THEN 'Bachelor' WHEN '2' THEN 'Foundation' END";
                        sSQL += " FROM Reg_Specializations AS M INNER JOIN Reg_Applications AS A ";
                        sSQL += " INNER JOIN Reg_Students_Data AS SD ON A.lngSerial = SD.lngSerial ON M.strCollege = A.strCollege AND M.strDegree = A.strDegree AND ";
                        sSQL += " M.strSpecialization = A.strSpecialization INNER JOIN GPA_Until AS CG ON A.lngStudentNumber = CG.lngStudentNumber";
                    }
                    sSQL += " WHERE (A.byteCancelReason = 3 OR A.byteCancelReason = 25) ";
                    sSQL += " AND  A.lngStudentNumber = '" + sStudentNumber + "'";
                }

                if (chkTable.Checked && rbnTestimony.SelectedIndex != 4 && rbnTestimony.SelectedIndex != 5 && rbnTestimony.SelectedIndex != 6)
                {
                    string sCondition = Get_Condition();
                    if (!string.IsNullOrEmpty(sCondition))
                    {
                        sSQL += sCondition;
                    }
                }
                if (rbnTestimony.SelectedIndex == 1 || rbnTestimony.SelectedIndex == 2)
                {
                    sSQL += " ORDER BY FG.dTime";
                }
                else
                {
                    if (rbnTestimony.SelectedIndex != 4 && rbnTestimony.SelectedIndex != 5 && rbnTestimony.SelectedIndex != 6)
                    {
                        sSQL += " ORDER BY C.strCourse";
                    }
                }

                Ds = Prepare_Report(sSQL);

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {

                Session["ReportDS"] = Ds;
                Export(Campus == InitializeModule.EnumCampus.Males, sbtn);
            }

        }
        private void SetTXT(string sID, bool isMale, string sYear, string sSem, string sDate1, string sDate2, string sMajor, out string stxt1, out string stxt2, out string stxt3, out string stxt4)
        {
            stxt1 = "";
            stxt2 = "";
            stxt3 = "";
            stxt4 = "";
            try
            {
                bool IsESLorVisitingStudent = false;
                bool IsFoundationStudent = false;

                if (sID.Contains("ES") || sID.Contains("V"))
                {
                    IsESLorVisitingStudent = true;
                }
                if (sID.Contains("FA"))
                {
                    IsFoundationStudent = true;
                }

                switch (rbnTestimony.SelectedIndex)
                {
                    case 0://Registered
                        if (rbnLanguage.SelectedIndex == 0)
                        {
                            if (isMale)
                            {
                                stxt1 = " تشهد كلية الإمارات للتكنولوجيا في أبو ظبي بأن الطالب المذكور أعلاه مسجل لدينا ";
                                stxt3 = "أعطيت له هذه الشهادة بناء على طلبه، دون تحمل أدنى مسؤولية تجاه الغير";
                            }
                            else
                            {
                                stxt1 = " تشهد إدارة كلية الإمارات للتكنولوجيا في أبوظبي بأن الطالبة المذكورة أعلاه مسجلة لدينا ";
                                stxt3 = "أعطيت لها هذه الشهادة بناء على طلبها، دون تحمل أدنى مسؤولية تجاه الغير";
                            }
                            stxt1 += " " + "في الفصل الدراسي" + " " + sSem + " " + "من العام الاكاديمي" + " " + sYear;
                            if (!IsESLorVisitingStudent && !IsFoundationStudent)
                            {
                                stxt1 += "  في تخصص ";
                                stxt1 += sMajor;
                            }
                            if (IsFoundationStudent)
                            {
                                stxt1 += " في ";
                                stxt1 += sMajor;
                            }

                            if (chkTable.Checked != true)
                            {
                                stxt2 += "علما بأن الفصل الدراسي  يبدأ بتاريخ" + " " + sDate1 + " " + "وينتهي بتاريخ" + " " + sDate2 + " .";
                            }
                            else
                            {
                                if (isMale)
                                {
                                    stxt2 += "علما بأن الطالب لديه امتحانات بالكلية وفقا للجدول المبين أدناه.";
                                }
                                else
                                {
                                    stxt2 += "علما بأن الطالبة لديها امتحانات بالكلية وفقا للجدول المبين أدناه.";
                                }
                            }
                        }
                        else
                        {

                            stxt1 = "    This is to certify that the above-mentioned student is studying at Emirates College of Technology ";

                            if (isMale)
                            {
                                stxt3 = "This letter has been given upon his request, without bearing any responsibility towards others.";
                            }
                            else
                            {
                                stxt3 = "This letter has been given upon her request, without bearing any responsibility towards others.";
                            }
                            stxt1 += " in ";
                            stxt1 += sMajor;

                            stxt1 += " at " + sSem + " semester " + "in the academic year of" + " " + sYear + ".";


                            if (chkTable.Checked != true)
                            {
                                stxt2 += "The Semester Started on " + sDate1 + " " + " and will end on " + sDate2 + " .";
                            }
                            else
                            {
                                if (isMale)
                                {
                                    stxt2 += " and he has the following exams as shown below:";
                                }
                                else
                                {
                                    stxt2 += " and she has the following exams as shown below:";
                                }

                            }

                        }
                        break;
                    case 1://Final
                        if (rbnLanguage.SelectedIndex == 0)
                        {
                            if (isMale)
                            {
                                stxt1 = "تشهد إدارة كلية الإمارات للتكنولوجيا في أبوظبي بأن الطالب المذكور أعلاه مسجل لدينا";
                                stxt2 = "علما بأن الامتحانات النهائية بالكلية تقع في الفترة من" + " " + sDate1 + " " + "وحتى" + " " + sDate2;
                                stxt3 = "أعطيت له هذه الشهادة بناء على طلبه ، دون تحمل أدنى مسؤولية تجاه الغير";
                            }
                            else
                            {
                                stxt1 = "تشهد إدارة كلية الإمارات للتكنولوجيا في أبوظبي بأن الطالبة المذكورة أعلاه مسجلة لدينا";
                                stxt2 = "علما بأن الامتحانات النهائية بالكلية تقع في الفترة من" + " " + sDate1 + " " + "وحتى" + " " + sDate2;
                                stxt3 = "أعطيت لها هذه الشهادة بناء على طلبها ، دون تحمل أدنى مسؤولية تجاه الغير";
                            }
                            if (chkTable.Checked)
                            {
                                stxt2 += " " + "وفقا للجدول المبين أدناه.";
                            }
                            else
                            {
                                stxt2 += " " + "وفقا لجدول الامتحانات المرفق.";
                            }
                            stxt1 += " " + "في الفصل الدراسي" + " " + sSem + " " + "من العام الاكاديمي" + " " + sYear + " .";
                        }
                        else
                        {
                            stxt1 = "    This is to certify that the above mentioned student is studying at Emirates College of Technology ";
                            stxt1 += " in ";
                            stxt1 += sMajor;

                            stxt1 += " at " + sSem + " semester " + "in the academic year of" + " " + sYear + ".";
                            stxt2 += "Final exams will be from " + sDate1 + " " + " to " + sDate2 + " .";

                            if (chkTable.Checked)
                            {
                                stxt2 += " " + "The above-mentioned student has the following final exams as shown below:";
                            }
                            else
                            {
                                stxt2 += " According to the attached final exams schedule.";
                            }

                            if (isMale)
                            {
                                stxt3 = "This letter has been given upon his request, without bearing any responsibility towards others.";
                            }
                            else
                            {
                                stxt3 = "This letter has been given upon her request, without bearing any responsibility towards others.";
                            }



                        }
                        break;
                    case 2://Final Attend
                        if (rbnLanguage.SelectedIndex == 0)
                        {
                            if (isMale)
                            {
                                stxt1 = "تشهد إدارة كلية الإمارات للتكنولوجيا في أبوظبي بأن الطالب المذكور أعلاه مسجل لدينا";
                                stxt2 = "علما بأن الطالب حضر الامتحانات النهائية في الفترة الواقعة ما بين" + " " + sDate1 + " " + "وحتى" + " " + sDate2;
                                stxt3 = "أعطيت له هذه الشهادة بناء على طلبه ، دون تحمل أدنى مسؤولية تجاه الغير";
                            }
                            else
                            {
                                stxt1 = "تشهد إدارة كلية الإمارات للتكنولوجيا في أبوظبي بأن الطالبة المذكورة أعلاه مسجلة لدينا";
                                stxt2 = "علما بأن الطالبة حضرت الامتحانات النهائية في الفترة الواقعة ما بين" + " " + sDate1 + " " + "وحتى" + " " + sDate2;
                                stxt3 = "أعطيت لها هذه الشهادة بناء على طلبها ، دون تحمل أدنى مسؤولية تجاه الغير";
                            }
                            if (chkTable.Checked)
                            {
                                stxt2 += " " + "وفقا للجدول المبين أدناه.";
                            }
                            else
                            {
                                stxt2 += " " + "وفقا لجدول الامتحانات المرفق.";
                            }
                            stxt1 += " " + "في الفصل الدراسي" + " " + sSem + " " + "من العام الاكاديمي" + " " + sYear + " .";
                        }
                        else
                        {
                            stxt1 = "    This is to certify that the above mentioned student is studying at Emirates College of Technology ";
                            stxt1 += " in ";
                            stxt1 += sMajor;

                            stxt1 += " at " + sSem + " semester " + "in the academic year of" + " " + sYear + ".";

                            stxt2 = "The above-mentioned student has attend the following final exams as shown below:";
                            stxt2 += " Final exams was from " + sDate1 + " " + " to " + sDate2 + " .";

                            stxt2 += " Final exams was from " + sDate1 + " " + " to " + sDate2 + " .";
                            if (isMale)
                            {
                                stxt3 = "This letter has been given upon his request, without bearing any responsibility towards others.";
                            }
                            else
                            {
                                stxt3 = "This letter has been given upon her request, without bearing any responsibility towards others.";
                            }
                        }
                        break;
                    case 3://Training
                        if (isMale)
                        {
                            stxt1 = "تهديكم كلية الإمارات للتكنولوجيا أسمى التحيات،  ونرجو من سيادتكم التفضل بالموافقة على";
                            stxt1 += " " + "تدريب الطالب المذكورة بياناته أدناه،إستكمالا لمتطلبات مادة التدريب العملي في تخصص";
                            stxt2 = sMajor;
                            stxt3 = "فترة التدريب: من" + " " + sDate1 + " " + "الى" + " " + sDate2;

                        }
                        else
                        {
                            stxt1 = "تهديكم كلية الإمارات للتكنولوجيا أسمى التحيات،  ونرجو من سيادتكم التفضل بالموافقة على";
                            stxt1 += " " + "تدريب الطالبة المذكورة بياناتها أدناه،إستكمالا لمتطلبات مادة التدريب العملي في تخصص";
                            stxt2 = sMajor;
                            stxt3 = "فترة التدريب: من" + " " + sDate1 + " " + "الى" + " " + sDate2;
                        }
                        break;
                    case 4://Admission
                        if (isMale)
                        {
                            stxt1 = "تشهد إدارة كلية الإمارات للتكنولوجيا بأبوظبي بأن الطالب المذكور أعلاه قد تم قبوله في";
                            stxt3 = "أعطيت له هذه الشهادة بناء على طلبه ، دون تحمل أدنى مسؤولية تجاه الغير";
                        }
                        else
                        {
                            stxt1 = "تشهد إدارة كلية الإمارات للتكنولوجيا بأبوظبي بأن الطالبة المذكورة أعلاه قد تم قبولها في";
                            stxt3 = "أعطيت لها هذه الشهادة بناء على طلبها ، دون تحمل أدنى مسؤولية تجاه الغير";
                        }
                        stxt2 = sMajor + " " + "في الفصل الدراسي" + " " + sSem + " " + "من العام الاكاديمي" + " " + sYear + " .";

                        break;
                    case 5://Graduation
                        if (rbnLanguage.SelectedIndex == 0)
                        {
                            if (isMale)
                            {
                                stxt1 = "تفيد  كلية الإمارات للتكنولوجيا بأن الطالب المذكور أعلاه قد أتم بنجاح متطلبات التخرج في";
                                stxt3 = "أعطيت له هذه الشهادة بناء على طلبه ، دون تحمل أدنى مسؤولية تجاه الغير";
                            }
                            else
                            {
                                stxt1 = "تفيد  كلية الإمارات للتكنولوجيا بأن الطالبة المذكورة أعلاه قد أتمت بنجاح متطلبات التخرج في";
                                stxt3 = "أعطيت لها هذه الشهادة بناء على طلبها ، دون تحمل أدنى مسؤولية تجاه الغير.";
                            }
                            stxt2 = sMajor + " " + "في الفصل الدراسي" + " " + sSem + " " + "من العام الاكاديمي" + " " + sYear + " .";
                            stxt4 = "علما بأن الفصل الدراسي قد انتهى بتاريخ" + " " + sDate2 + " .";

                        }
                        else
                        {
                            stxt1 = "This is to certify that the above mentioned student has completed the graduation requirements at the Emirates College of Technology at";
                            if (isMale)
                            {
                                stxt3 = "This certificate has been given to him upon his request temporarily until his original certificate is issued without bearing any responsibility towards others.";
                            }
                            else
                            {
                                stxt3 = "This certificate has been given to her upon her request temporarily until her original certificate is issued without bearing any responsibility towards others.";
                            }

                            stxt2 = sSem + " semester" + " " + "of the academic year" + " " + sYear + "  in " + sMajor;
                            stxt4 = "The semester was ended on" + " " + sDate2 + " .";
                        }

                        break;

                }

            }
            catch (Exception exp)
            {
                //Console.WriteLine("{0} Exception caught.", exp);
                //divMsg.InnerText = exp.Message;
            }
            finally
            {

            }
        }
        private DataSet Prepare_Report(string sSQL)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            string sConn = myConnection_String.Conn_string;
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            int iYear = 0;
            int iSem = 0;
            string sYear = "";
            string sSem = "";
            string sDate1 = "";
            string sDate2 = "";
            bool isMale = false;
            try
            {
                DataColumn dc;

                dc = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sID", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sName", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDest", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sText1", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sText2", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sText3", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sText4", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sMajor", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCourse", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDesc", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sTime", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sDate", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("CGPA", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Rate", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Degree", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                int Serial = 0;

                string sID = "";
                string sText1 = "";
                string sText2 = "";
                string sText3 = "";
                string sText4 = "";

                isMale = false;

                sDate1 = string.Format("{0:dd-MM-yyyy}", Convert.ToDateTime(txtDateFrom.Text));
                sDate2 = string.Format("{0:dd-MM-yyyy}", Convert.ToDateTime(txtDateTo.Text));
                bool isTexted = false;
                string sCourse = "";
                string sDesc = "";
                string sTime = "";
                string sDate = "";
                string sMajor = "";
                double dCGPA = 0;
                string sCGPA = "";
                string sRate = "";
                DateTime myDate = DateTime.Today.Date;


                while (Rd.Read())
                {
                    dr = dt.NewRow();
                    Serial += 1;

                    dr["iSerial"] = Serial;
                    dr["sID"] = Rd["sSno"].ToString().Replace(".", "");
                    dr["sName"] = Rd["sName"].ToString();
                    dr["sDest"] = txtDestination.Text;
                    sMajor = Rd["sMajor"].ToString();
                    dr["sMajor"] = sMajor;
                    isMale = Convert.ToBoolean(Rd["bSex"]);
                    sID = Rd["sSno"].ToString();
                    if (!isTexted)
                    {
                        iYear = Convert.ToInt32(Rd["iYear"]);
                        iSem = Convert.ToInt32(Rd["bSem"]);


                        if (rbnLanguage.SelectedIndex == 0)
                        {
                            sYear = (iYear + 1) + " / " + (iYear);
                            switch (iSem)
                            {
                                case 1:
                                    sSem = " الاول";
                                    break;
                                case 2:
                                    sSem = " الثاني";
                                    break;
                                case 3:
                                    sSem = "الصيفي الاول";
                                    break;
                                case 4:
                                    sSem = "الصيفي الثاني";
                                    break;
                            }
                        }
                        else
                        {
                            sYear = iYear + " / " + (iYear + 1);
                            switch (iSem)
                            {
                                case 1:
                                    sSem = " Fall";
                                    break;
                                case 2:
                                    sSem = " Spring";
                                    break;
                                case 3:
                                    sSem = " Summer I";
                                    break;
                                case 4:
                                    sSem = " Summer II";
                                    break;
                            }
                        }
                        SetTXT(sID, isMale, sYear, sSem, sDate1, sDate2, sMajor, out sText1, out sText2, out sText3, out sText4);
                        isTexted = true;
                    }

                    hfText1.Value = sText1;
                    hfText2.Value = sText2;
                    hfText3.Value = sText3;
                    hfText4.Value = sText4;

                    dr["sText1"] = sText1;
                    dr["sText2"] = sText2;
                    dr["sText3"] = sText3;
                    dr["sText4"] = sText4;

                    if (rbnTestimony.SelectedIndex == 5 || rbnTestimony.SelectedIndex == 6)
                    {
                        dCGPA = Convert.ToDouble(Rd["CGPA"]);
                        sCGPA = string.Format("{0:f}", dCGPA);

                        if (rbnLanguage.SelectedIndex == 0)
                        {
                            if (dCGPA >= 2 && dCGPA < 2.5)
                            {
                                sRate = "مقبول";
                            }
                            else if (dCGPA >= 2.5 && dCGPA < 3)
                            {
                                sRate = "جيد";
                            }
                            else if (dCGPA >= 3 && dCGPA < 3.6)
                            {
                                sRate = "جيد جدا";
                            }
                            else if (dCGPA >= 3.6)
                            {
                                sRate = "إمتياز";
                            }
                            else
                            {
                                sRate = "لم ينجح";
                            }
                        }
                        else
                        {
                            if (dCGPA >= 2 && dCGPA < 2.5)
                            {
                                sRate = "Satisfactory";
                            }
                            else if (dCGPA >= 2.5 && dCGPA < 3)
                            {
                                sRate = "Good";
                            }
                            else if (dCGPA >= 3 && dCGPA < 3.6)
                            {
                                sRate = "Very Good";
                            }
                            else if (dCGPA >= 3.6)
                            {
                                sRate = "Excellent";
                            }
                            else
                            {
                                sRate = "Not Passed";
                            }


                        }

                        dr["CGPA"] = sCGPA;
                        dr["Rate"] = sRate;
                        dr["Degree"] = Rd["Degree"].ToString(); ;

                    }

                    if (chkTable.Checked)
                    {
                        sCourse = Rd["strCourse"].ToString();
                        sDesc = Rd["strCourseDescEn"].ToString();
                        dr["sCourse"] = sCourse;
                        dr["sDesc"] = sDesc;
                        if (rbnTestimony.SelectedIndex != 0)
                        {
                            if (!Rd["dTime"].Equals(DBNull.Value))
                            {
                                myDate = Convert.ToDateTime(Rd["dTime"]);
                                sTime = myDate.ToShortTimeString() + " - " + myDate.AddHours(2).ToShortTimeString();
                                //sDate = myDate.ToShortDateString();
                                sDate = string.Format("{0:dd-MM-yyyy}", Rd["dTime"]);
                            }
                        }
                        else
                        {
                            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                            //sDate = DateTime.Parse(Convert.ToDateTime(Rd["dTime"]).ToShortDateString() ).ToString(); //uses the current Thread's culture

                            //=========================================================

                            sTime = Convert.ToDateTime(Rd["dateTimeFrom"]).ToShortTimeString() + " - " + Convert.ToDateTime(Rd["dateTimeTo"]).ToShortTimeString();
                            sDate = string.Format("{0:dd-MM-yyyy}", Rd["dTime"]);
                        }
                        //sDate=Rd["sDesc"].ToString();
                        dr["sTime"] = sTime;
                        dr["sDate"] = sDate;
                    }

                    dt.Rows.Add(dr);

                }
                Rd.Close();
                dt.TableName = "StudentTestimony";
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
        private string getVerificationCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);

            return finalString;
        }
        private void Export(bool isMales, string sbtn)
        {
            ReportDocument myReport = new ReportDocument();

            try
            {
                DataSet rptDS = new DataSet();

                string sVerification = getVerificationCode();

                rptDS = (DataSet)Session["ReportDS"];
                string reportPath = "";
                if (rbnTestimony.SelectedIndex == 0)
                {
                    if (rbnLanguage.SelectedIndex == 0)
                    {
                        reportPath = Server.MapPath("Reports/Testimonies.rpt");
                    }
                    else
                    {
                        reportPath = Server.MapPath("Reports/Testimonies_En.rpt");
                    }
                }
                //case 0://Registered
                //case 1://Final Exams
                //case 2://Attend Final Exams
                //case 3://Training
                //case 4://Admission
                //case 5://Graduation
                //case 6://graduate verification form

                else if (rbnTestimony.SelectedIndex == 1 || rbnTestimony.SelectedIndex == 2)
                {
                    if (chkTable.Checked)
                    {

                        if (rbnLanguage.SelectedIndex == 0)
                        {
                            reportPath = Server.MapPath("Reports/Testimonies_tbl.rpt");
                        }
                        else
                        {
                            reportPath = Server.MapPath("Reports/Testimonies_En.rpt");
                        }
                    }
                    else
                    {

                        if (rbnLanguage.SelectedIndex == 0)
                        {
                            reportPath = Server.MapPath("Reports/Testimonies.rpt");
                        }
                        else
                        {
                            reportPath = Server.MapPath("Reports/Testimonies_En.rpt");
                        }
                    }
                }
                else if (rbnTestimony.SelectedIndex == 3)
                {
                    reportPath = Server.MapPath("Reports/Testimonies_Tr.rpt");
                }
                else if (rbnTestimony.SelectedIndex == 4)
                {
                    reportPath = Server.MapPath("Reports/Testimonies.rpt");
                }

                else if (rbnTestimony.SelectedIndex == 5)
                {
                    if (rbnLanguage.SelectedIndex == 0)
                    {
                        reportPath = Server.MapPath("Reports/Testimonies_G_AR.rpt");
                    }
                    else
                    {
                        reportPath = Server.MapPath("Reports/Testimonies_G_EN.rpt");
                    }
                }
                else if (rbnTestimony.SelectedIndex == 6)
                {
                    reportPath = Server.MapPath("Reports/Forms_GraduateVerification.rpt");
                }

                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);

                TextObject txt;
                //Testimonies_Reg
                //Testimonies_Final
                //Testimonies_FinalAttend
                //Testimonies_Training
                //Testimonies_Admission
                //Testimonies_Graduation
                //Form_Graduate Verfication
                if (chkPrintHeaderFooter.Checked == false)
                {
                    //TextObject txt1;
                    //txt1 = (TextObject)myReport.ReportDefinition.ReportObjects["sTextelectronicSignature"];
                    //txt1.ObjectFormat.EnableSuppress = true;
                    //txt1.Text = "";

                    PictureObject pic1;
                    pic1 = (PictureObject)myReport.ReportDefinition.ReportObjects["picLogo"];
                    pic1.ObjectFormat.EnableSuppress = true;

                    pic1 = (PictureObject)myReport.ReportDefinition.ReportObjects["picfooter"];
                    pic1.ObjectFormat.EnableSuppress = true;

                }

                //Testimonies only ( ecxlude graduate verification form)
                if (rbnLanguage.SelectedIndex == 0 && rbnTestimony.SelectedIndex != 6)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtName"];
                    if (isMales)
                    {
                        txt.Text = " " + "اسم الطالب";
                    }
                    else
                    {
                        txt.Text = " " + "اسم الطالبة";
                    }
                    if (ddlSignedBy.SelectedValue == "1")
                    {
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtSignedBy_Name"];
                        txt.Text = "صهيب أحمد العامرية";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtSignedBy_JobTitle"];
                        txt.Text = "مديرالتسجيل";
                    }
                    else
                    {
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtSignedBy_Name"];
                        txt.Text = "مهند طاهر الشايب";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtSignedBy_JobTitle"];
                        txt.Text = "مدير شؤون الطلبة والتسجيل";
                    }
                }
                else if (rbnLanguage.SelectedIndex != 0 && rbnTestimony.SelectedIndex != 6)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtName"];
                    txt.Text = " " + "Name";
                    if (ddlSignedBy.SelectedValue == "1")
                    {
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtSignedBy_Name"];
                        txt.Text = "Suhib Ahmed Al Amereyyeh";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtSignedBy_JobTitle"];
                        txt.Text = "Manager - Student Registration";
                    }
                    else
                    {
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtSignedBy_Name"];
                        txt.Text = "Mohannad Taher Al-Shayeb";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtSignedBy_JobTitle"];
                        txt.Text = "Director - Student Affairs and Registration";
                    }
                }

                if (rbnTestimony.SelectedIndex == 3)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtHeader"];
                    if (isMales)
                    {

                        txt.Text = "الموضوع : تدريب طالب";
                    }
                    else
                    {
                        txt.Text = "الموضوع : تدريب طالبة";
                    }
                }
                if (rbnTestimony.SelectedIndex == 5)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtHeader"];
                    if (rbnLanguage.SelectedIndex == 0)
                    {

                        txt.Text = "إفــادة تــخــرج";
                    }
                    else
                    {
                        txt.Text = "Graduation Certificate";
                    }
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["sTextPart4"];
                    txt.Text = hfText4.Value;
                }

                if (rbnTestimony.SelectedIndex != 6)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["sTextPart1"];
                    txt.Text = hfText1.Value;
                    //
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["sTextPart2"];
                    txt.Text = hfText2.Value;
                    //
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["sTextPart3"];
                    txt.Text = hfText3.Value;


                }

                if ((rbnTestimony.SelectedIndex != 5) && (rbnTestimony.SelectedIndex != 6))
                {
                    bool isShown = false;
                    isShown = ((chkTable.Checked) && (rbnTestimony.SelectedIndex != 4));

                    if (rbnTestimony.SelectedIndex != 3)
                    {
                        //    if (!chkTable.Checked)
                        //    {

                        for (int i = 1; i < 5; i++)
                        {
                            txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtH" + i];
                            txt.ObjectFormat.EnableSuppress = !isShown;
                        }
                        Section sec;
                        sec = (Section)myReport.ReportDefinition.Sections["Section3"];
                        sec.SectionFormat.EnableSuppress = !isShown;

                        //    }
                    }
                }
                if (rbnTestimony.SelectedIndex == 6)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtAcademicYear"];
                    txt.Text = Terms.SelectedValue.ToString().Substring(0, 4) + "/" + (Convert.ToInt32(Terms.SelectedValue.ToString().Substring(0, 4)) + 1).ToString();
                    //
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtSemester"];
                    txt.Text = Terms.SelectedItem.Text.Substring(4).Trim();
                    if (ddlSignedBy.SelectedValue == "1")
                    {
                        //txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtSignedBy_Name"];
                        //txt.Text = "Suhib Ahmed Al Amereyyeh";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtSignedBy_JobTitle"];
                        txt.Text = "Manager - Student Registration";
                    }
                    else
                    {
                        //txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtSignedBy_Name"];
                        //txt.Text = "Mohannad Taher Al-Shayeb";
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtSignedBy_JobTitle"];
                        txt.Text = "Director - Student Affairs and Registration";
                    }

                }
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtUser"];
                txt.Text = Session["CurrentUserName"].ToString();

                if (rbnTestimony.SelectedIndex != 6)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtRef"];
                    txt.Text = sVerification;
                }

                switch (sbtn)
                {
                    case "Print_btn":
                        myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Page.Response, true, "ECTReport");
                        break;
                    case "Word_btn":
                        myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Page.Response, true, "ECTReport");
                        break;

                }
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

        protected void Word_btn_Click(object sender, EventArgs e)
        {
            PrintTestimony("Word_btn");
        }
    }
}