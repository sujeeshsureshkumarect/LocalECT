using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class ChangeMajor : System.Web.UI.Page
    {
        int CurrentRole = 0;
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;

        int iRegYear = 2019;
        int iRegSem = 2;
        int iRegTerm;
        string sConn = "";
        string sCCollege = "";
        string sCDegree = "";
        string sCMajor = "";
        string sUser = "";
        string sNCollege, sNDegree, sNMajor;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    iRegTerm = LibraryMOD.GetRegTerm();
                    iRegYear = LibraryMOD.SeperateTerm(iRegTerm, out iRegSem);
                    Session["RegYear"] = iRegYear;
                    Session["RegSemester"] = iRegSem;
                }
                else
                {
                    if (Session["RegYear"] != null)
                    {
                        iRegYear = Convert.ToInt32(Session["RegYear"].ToString());
                        iRegSem = Convert.ToInt32(Session["RegSemester"].ToString());
                    }
                }

                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    sUser = Session["CurrentUserName"].ToString();
                    if (!IsPostBack)
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.ChangeMajor, CurrentRole) != true)
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
                lbl_Msg.Text = "";

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

                CopyDS.ConnectionString = sConn;

                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.ChangeMajor, CurrentRole) != true)
                    {
                        //chkMajorOnly.Enabled = false;
                    }
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.CopyStudent, CurrentRole) != true)
                    {
                        //RunCMD.Enabled = false;
                    }
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.ImportGrades, CurrentRole) != true)
                    {
                        //cmdImport.Enabled = false;
                    }
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                        InitializeModule.enumPrivilege.ChangeID, CurrentRole) != true)
                    {
                        //chkNoOnly.Enabled = false;
                    }

                    if (Request.QueryString["sid"] != null && Request.QueryString["sid"] != "")
                    {
                        Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                        string sid = Request.QueryString["sid"];
                        hdnSerial.Value = GetSerial(sid).ToString();
                        lblStudentNo.Text = sid;
                        bindstudentdata(sid);

                        FillDDLs();

                        ddlTerm.SelectedValue = (iRegYear * 10 + iRegSem).ToString();
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
        }
        protected void lnkNewId_Command(object sender, CommandEventArgs e)
        {
            if (lnkNewId.Text != "")
            {
                Session["CurrentStudent"] = lnkNewId.Text;
                Session["StudentSerialNo"] = hdnNewSerial.Value;
                Response.Redirect("Student_Profile?sid="+ lnkNewId.Text + "");
            }

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
        public void bindstudentdata(string sid)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("select [strAccountNo],[strStudentName],[lngStudentNumber],iAdmissionPaymentType,cAdmissionPaymentValue from [Reg_Student_Accounts] where [lngStudentNumber]=@lngStudentNumber", sc);
            cmd.Parameters.AddWithValue("@lngStudentNumber", sid);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    lblName.Text = dt.Rows[0]["strStudentName"].ToString();
                }
            }
            catch (Exception ex)
            {
                sc.Close();
                lbl_Msg.Text = ex.Message;
                div_msg.Visible = true;
            }
            finally
            {
                sc.Close();
            }
        }
        private void FillDDLs()
        {
            try
            {
                string sKey = "";
                lblOldMajor.Text = GetCurrentMajor(lblStudentNo.Text, out sKey, out sCCollege, out sCDegree, out sCMajor);
                FillTerms();
                FillMajors(sKey);
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
                    ddlTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
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

        private void FillMajors(string sCurrentMajor)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sAltMajor = "";


                string sSQL = "SELECT strKey, strMajor FROM Reg_Specializations";
                //sSQL += " WHERE strKey<>'" + sCurrentMajor + "' AND bAvailable=1";
                sSQL += " WHERE bAvailable=1";
                sSQL += " ORDER BY intSerial";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                ddlMajor.Items.Clear();

                while (Rd.Read())
                {
                    ddlMajor.Items.Add(new ListItem(Rd["strMajor"].ToString(), Rd["strKey"].ToString()));

                }
                Rd.Close();


                string sDegree = sCurrentMajor.Substring(2, 2);

                //Get the Parent Major
                if (sDegree != "03")//not Bachelor
                {
                    sSQL = "SELECT strAltMajor FROM Reg_Specializations";
                    sSQL += " WHERE strKey='" + sCurrentMajor + "'";
                    Cmd.CommandText = sSQL;
                    Rd = Cmd.ExecuteReader();

                    while (Rd.Read())
                    {

                        sAltMajor = Rd["strAltMajor"].ToString();

                    }
                    Rd.Close();
                    if (sAltMajor.Length != 2)
                    {
                        sAltMajor = '0' + sAltMajor;
                    }
                    sAltMajor = sCurrentMajor.Substring(0, 4) + sAltMajor;

                    //Add the inactive parent major to the list
                    sSQL = "SELECT strKey, strMajor FROM Reg_Specializations";
                    sSQL += " WHERE strKey='" + sAltMajor + "' AND (bAvailable = 0) and strKey<>'" + sCurrentMajor + "'";
                    Cmd.CommandText = sSQL;
                    Rd = Cmd.ExecuteReader();

                    while (Rd.Read())
                    {

                        ddlMajor.Items.Add(new ListItem(Rd["strMajor"].ToString(), Rd["strKey"].ToString()));

                    }
                    Rd.Close();
                }
                else
                {

                    //Add the inactive bachelor parents major to the list
                    sSQL = "SELECT strKey, strMajor FROM Reg_Specializations";
                    sSQL += " WHERE strDegree='3' AND (bAvailable = 0) and strKey<>'" + sCurrentMajor + "'";
                    Cmd.CommandText = sSQL;
                    Rd = Cmd.ExecuteReader();

                    while (Rd.Read())
                    {
                        ddlMajor.Items.Add(new ListItem(Rd["strMajor"].ToString(), Rd["strKey"].ToString()));
                    }
                    Rd.Close();
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
                Conn.Close();
                Conn.Dispose();
            }
        }

        private string GetCurrentMajor(string sID, out string sKey, out string sCollege, out string sDegree, out string sMajor)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            string sCurrentMajor = "";
            sKey = "";
            sCollege = "";
            sDegree = "";
            sMajor = "";
            try
            {
                string sSQL = "SELECT S.strKey, S.strMajor, S.strCollege, S.strDegree, S.strSpecialization";
                sSQL += " FROM  Reg_Specializations AS S INNER JOIN Reg_Applications AS A ON S.strCollege = A.strCollege AND S.strDegree = A.strDegree AND S.strSpecialization = A.strSpecialization";
                sSQL += " WHERE A.lngStudentNumber = '" + sID + "'";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                while (Rd.Read())
                {
                    sCurrentMajor = Rd["strMajor"].ToString();
                    sKey = Rd["strKey"].ToString();
                    hdnKey.Value = sKey;
                    sCollege = Rd["strCollege"].ToString();
                    sDegree = Rd["strDegree"].ToString();
                    sMajor = Rd["strSpecialization"].ToString();
                }
                Rd.Close();

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
            return sCurrentMajor;
        }

        protected void RunCMD_Click(object sender, EventArgs e)
        {
            try
            {
                int iStatus = 0;

                string sNewID = lblStudentNo.Text;
                string sOldID = lblStudentNo.Text;

                iStatus = GetStatus(sOldID);
                //iStatus = 26;
                sCCollege = int.Parse(hdnKey.Value.Substring(0, 2)).ToString();
                sCDegree = int.Parse(hdnKey.Value.Substring(2, 2)).ToString();
                sCMajor = int.Parse(hdnKey.Value.Substring(4, 2)).ToString();

                sNCollege = int.Parse(ddlMajor.SelectedValue.Substring(0, 2)).ToString();
                sNDegree = int.Parse(ddlMajor.SelectedValue.Substring(2, 2)).ToString();
                sNMajor = int.Parse(ddlMajor.SelectedValue.Substring(4, 2)).ToString();

                //if (sNDegree == "2" && sNMajor == "1")
                //{
                //    divMsg.InnerText = "Not Allowed to change to ESL";
                //    return;
                //}
                bool IsMTH001Required = false;
                bool IsCHEM001Required = false;
                bool IsBIOL001Required = false;
                bool IsPHYS001Required = false;

                double CGPA = 0;

                if (sNDegree != "2" && sNMajor != "99")
                {
                    int iSerial = int.Parse(hdnSerial.Value);
                    if (isQualified(iSerial, sNDegree, sNMajor, iStatus) != true && iStatus != 3 && sCMajor != "24") //and not graduated from diploma of public relations
                    {
                        lbl_Msg.Text = "HS Score, EmSAT or ENG Score doesn’t meet the major requirement …!";
                        div_msg.Visible = true;
                        return;
                    }
                }
                if (AdmissionRequirments.IsFulfilledAdmissionRequirements(Campus, sOldID, out IsMTH001Required, out IsCHEM001Required, out IsBIOL001Required, out IsPHYS001Required))
                {

                    if (IsMTH001Required)
                    {
                        lbl_Msg.Text = "Mathematics score (HS certificate or MTH001) is lower than the admission requirement …!";
                        div_msg.Visible = true;
                        return;
                    }

                    if (IsCHEM001Required)
                    {
                        lbl_Msg.Text = "Chemistry score (HS certificate or CHEM001) is lower than the admission requirement …!";
                        div_msg.Visible = true;
                        return;
                    }

                    if (IsBIOL001Required)
                    {
                        lbl_Msg.Text = "Biology score (HS certificate or BIOL001) is lower than the admission requirement …!";
                        div_msg.Visible = true;
                        return;
                    }

                    if (IsPHYS001Required)
                    {                        
                        lbl_Msg.Text = "Physics score (HS certificate or PHYS001) is lower than the admission requirement …!";
                        div_msg.Visible = true;
                        return;
                    }
                }
                //if (chkNoOnly.Checked == true)
                //{
                //    sNewID = CreateNewApp(sNCollege, sNDegree, sNMajor, sCDegree, iStatus);
                //    lnkNewId.Text = sNewID;
                //    if (sNewID == "")
                //    {
                //        return;
                //    }
                //    return;
                //}

                //if (chkMajorOnly.Checked == true)
                //{
                //    bool isChanged = ChangeStudentMajor(sOldID, sNCollege, sNDegree, sNMajor);
                //    lbl_Msg.Text = "Major Changed Successfully ...";
                //    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                //    div_msg.Visible = true;
                //    return;
                //}

                if (sCDegree == sNDegree && iStatus != 0)//Has Status then create new profile
                {

                    CGPA = GetCGPA(sOldID);

                    //rbnType.SelectedIndex = 1;

                    sNewID = CreateNewApp(sNCollege, sNDegree, sNMajor, sCDegree, iStatus);
                    lnkNewId.Text = sNewID;
                    if (sNewID == "")
                    {
                        return;
                    }
                    CopyPreviousGrades(sOldID, sNewID, (sCDegree == "2" && (sCMajor == "2" || sCMajor == "3" || sCMajor == "4")));//Not Foundation
                    CalculateGrades(sNewID, CGPA);
                }
                else if (sCDegree == sNDegree && iStatus == 0)//Change Major in the same profile
                {
                    //rbnType.SelectedIndex = 0;
                    bool isChanged = false;
                    CGPA = GetCGPA(sOldID);
                    isChanged = ChangeStudentMajor(sOldID, sNCollege, sNDegree, sNMajor);

                    if (!isChanged)
                    {
                        return;
                    }
                    DeleteAL_EQ(sOldID);
                    CalculateGrades(sOldID, CGPA);
                }
                else if (sCDegree != sNDegree)//Upgrade
                {
                    if (sNDegree == "2" && (sNMajor != "2" && sNMajor != "3" && sNMajor != "4"))//Not Foundation
                    {
                        SetStatus(sOldID, 31);//Convert to ESL
                    }
                    else
                    {
                        switch (sCDegree)
                        {
                            case "1":

                                SetStatus(sOldID, 27);//Convert to Bachelor
                                break;
                            case "2":
                                if (sCMajor != "2" && sCMajor != "3" && sCMajor != "4")//Not Foundation
                                {
                                    SetStatus(sOldID, 29);//English Proficiency Passed
                                }
                                break;
                            case "3":
                                SetStatus(sOldID, 28);//Convert to Diploma
                                break;
                        }
                    }
                    //rbnType.SelectedIndex = 1;
                    sNewID = CreateNewApp(sNCollege, sNDegree, sNMajor, sCDegree, iStatus);
                    lnkNewId.Text = sNewID;
                    if (sNewID == "")
                    {
                        return;
                    }
                    CopyPreviousGrades(sOldID, sNewID, (sCDegree == "2" && (sCMajor == "2" || sCMajor == "3" || sCMajor == "4")));//Not Foundation
                    CGPA = GetCGPA(sOldID);
                    CalculateGrades(sNewID, CGPA);

                }
                else
                {                    
                    lbl_Msg.Text = "Changing Major is not Allowed due the Status of the Student !";
                    div_msg.Visible = true;
                    return;
                }

                //Create AL Grades
                if (sCDegree != "2" || (sCDegree == "2" && (sCMajor != "2" && sCMajor != "3" && sCMajor != "4")))//Not Foundation
                {
                    Recreate_AL(sNewID, iRegYear, iRegSem);
                    if (sNDegree == "3" && sCDegree == "1")//Bachelor
                    {
                        SetFreeElective(sNewID);
                    }
                }

                //Change student advisor to the Dean of faculty
                int iFacultyID = 0;
                if (sNDegree != "2")
                {
                    iFacultyID = LibraryMOD.GetFacultyIDFromMjor(sNDegree, sNMajor);
                }
                else
                {
                    int iWantedMajorID = LibraryMOD.GetWantedMjorID(Campus, sNewID);

                    iFacultyID = LibraryMOD.GetFacultyIDFromWantedMjor(Convert.ToInt32(iWantedMajorID));
                }

                int iDean = LibraryMOD.GetDeanofFacultyID(iFacultyID);
                int iAdvisor = 1000;
                switch (Campus)
                {
                    case InitializeModule.EnumCampus.Males:
                        iAdvisor = LibraryMOD.GetLecturerMaleID(iDean);
                        break;
                    case InitializeModule.EnumCampus.Females:
                        iAdvisor = LibraryMOD.GetLecturerFemaleID(iDean);
                        break;
                }

                lbl_Msg.Text = "Student Major Changed Successfully ...";
                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                div_msg.Visible = true;

                if (LibraryMOD.UpdateStudentAdvisor(Campus, sNewID, iAdvisor) == false)
                {
                    lbl_Msg.Text += " - Student Advisor Not Updated";
                    div_msg.Visible = true;
                }


            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                lbl_Msg.Text = ex.Message + "Student Major Not Changed Successfully !";
                div_msg.Visible = true;
            }
            finally
            {

            }
        }
        private bool ChangeStudentMajor(string sID, string sNCollege, string sNDegree, string sNMajor)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            bool isChanged = false;
            try
            {
                //Change the major
                string sSQL = "update Reg_Applications set strCollege='" + sNCollege + "',strDegree='" + sNDegree + "'";
                sSQL += ",strSpecialization='" + sNMajor + "',strUserSave='" + sUser + "',dateLastSave=GETDATE()";
                sSQL += " where lngStudentNumber='" + sID + "'";

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                int iEffected = 0;

                iEffected = Cmd.ExecuteNonQuery();
                isChanged = (iEffected > 0);
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
            return isChanged;
        }
        private void SetStatus(string sNO, int iStatus)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "SELECT byteCancelReason FROM Reg_Applications Where lngStudentNumber='" + sNO + "'";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                int iCStatus = Convert.ToInt32("0" + Cmd.ExecuteScalar().ToString());
                if (iCStatus == 0)
                {
                    int iTerm = int.Parse(ddlTerm.SelectedValue);
                    int iYear, iSem;
                    iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);

                    sSQL = "Update Reg_Applications Set byteCancelReason=" + iStatus;
                    sSQL += ",intGraduationYear=" + iYear + ",byteGraduationSemester=" + iSem;
                    sSQL += ",byteMainReason=0,byteSubReason=0,dateGraduation2=GETDATE()";
                    sSQL += ",strUserSave='" + Session["CurrentUserName"].ToString() + "',dateLastSave=GETDATE()";
                    sSQL += " Where lngStudentNumber='" + sNO + "'";

                    Cmd.CommandText = sSQL;
                    int iEffected = Cmd.ExecuteNonQuery();

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
                Conn.Close();
                Conn.Dispose();
            }
        }
        private int CopyPreviousGrades(string sOldID, string sNewID, bool isESLOnly)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            int iCopied = 0;
            try
            {


                //string sSQL = "SELECT  GH.intStudyYear,GH.byteSemester, GH.strCourse, GH.strGrade, GH.sAlt, GH.sEQ, GS.curSeq";
                //sSQL += " FROM Reg_Grade_Header AS GH INNER JOIN Reg_Grade_System AS GS ON GH.strGrade = GS.strGrade";
                //sSQL += " WHERE (GH.lngStudentNumber = '"+sOldID+"') AND (GH.bCanceled = 0) AND (GH.bDisActivated = 0) ";
                //sSQL += " AND (GH.strGrade NOT IN('EW','W','I','NG','AL','EQ','F'))";

                string sSQL = "SELECT intStudyYear, byteSemester, lngStudentNumber, strCourse, sRealCourse,";
                sSQL += " curSeq, strGrade, bPassIt, sAlternative, sEquivelant,College";
                sSQL += " FROM Calc_Real_Courses";
                sSQL += " WHERE (lngStudentNumber = '" + sOldID + "') AND bDisActivated=0 AND bCanceled=0 ";
                sSQL += " AND (strGrade NOT IN('EW','W','I','NG','AL','EQ','F','EX','NC'))";
                if (isESLOnly)
                {
                    sSQL += " AND (left(strCourse,3)='ESL')";
                }

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);

                SqlDataReader Rd = Cmd.ExecuteReader();
                List<CalcMark> CalcMarks = new List<CalcMark>();

                string sRealCourse = "";
                string sCourse = "";
                string sAlt = "";
                string sEQ = "";
                double dSequence = 0;
                string sGrade = "";
                int iYear = 0;
                int iSem = 0;
                int iFound = 0;
                string sCollege = "Null";

                CalcMark myMark;
                while (Rd.Read())//Collect Alternative
                {

                    iYear = int.Parse(Rd["intStudyYear"].ToString());
                    iSem = int.Parse(Rd["byteSemester"].ToString());
                    sRealCourse = Rd["sRealCourse"].ToString();
                    sCourse = Rd["strCourse"].ToString();
                    sAlt = Rd["sAlternative"].ToString();
                    sEQ = Rd["sEquivelant"].ToString();
                    dSequence = Convert.ToDouble(Rd["curSeq"].ToString());
                    sGrade = Rd["strGrade"].ToString();

                    iFound = CalcMarks.FindIndex(delegate (CalcMark C) { return (C.Sreal == sRealCourse); });
                    sCollege = Rd["College"].ToString();

                    if (iFound >= 0)
                    {
                        if (CalcMarks[iFound].Dsequence < dSequence)
                        {
                            if (sGrade == "EX" || sGrade == "TC" || isESLOnly)
                            {
                                CalcMarks[iFound].Iyear = 0;
                                CalcMarks[iFound].Isem = 0;
                            }
                            else
                            {
                                if (iYear > 0)
                                {
                                    CalcMarks[iFound].Iyear = -1 * iYear;
                                    CalcMarks[iFound].Isem = -1 * iSem;
                                }
                                else
                                {
                                    CalcMarks[iFound].Iyear = iYear;
                                    CalcMarks[iFound].Isem = iSem;
                                }
                            }
                            CalcMarks[iFound].Dsequence = dSequence;
                            CalcMarks[iFound].Sgrade = sGrade;
                            CalcMarks[iFound].SAlt = sAlt;
                            CalcMarks[iFound].SEQ = sEQ;
                            if (sCollege == "")
                            {
                                CalcMarks[iFound].SCollege = "Null";
                            }
                            else
                            {
                                CalcMarks[iFound].SCollege = sCollege;
                            }


                        }

                    }
                    else
                    {
                        myMark = new CalcMark();
                        if (sGrade == "EX" || sGrade == "TC" || isESLOnly)
                        {
                            myMark.Iyear = 0;
                            myMark.Isem = 0;
                        }
                        else
                        {
                            if (iYear > 0)
                            {
                                myMark.Iyear = -1 * iYear;
                                myMark.Isem = -1 * iSem;
                            }
                            else
                            {
                                myMark.Iyear = iYear;
                                myMark.Isem = iSem;
                            }
                        }
                        myMark.Sreal = sRealCourse;
                        myMark.Scourse = sCourse;
                        myMark.SAlt = sAlt;
                        myMark.SEQ = sEQ;
                        myMark.Dsequence = dSequence;
                        myMark.Sgrade = sGrade;
                        if (sCollege == "")
                        {
                            myMark.SCollege = "Null";
                        }
                        else
                        {
                            myMark.SCollege = sCollege;
                        }
                        CalcMarks.Add(myMark);
                    }
                }

                Rd.Close();



                for (int i = 0; i < CalcMarks.Count; i++)
                {

                    sSQL = "INSERT INTO Reg_Grade_Header (intStudyYear,byteSemester,byteShift,strCourse,byteClass,";
                    sSQL += "lngStudentNumber,byteRefCollege,strGrade,bCanceled,bDisActivated,sAlt,sEQ,strDegree,strMajor,strUserCreate,dateCreate)";
                    sSQL += " VALUES(" + CalcMarks[i].Iyear + "," + CalcMarks[i].Isem + ",1,'" + CalcMarks[i].Scourse + "',1,";
                    sSQL += "'" + sNewID + "'," + CalcMarks[i].SCollege + ",'" + CalcMarks[i].Sgrade + "',0,0,'" + CalcMarks[i].SAlt + "','" + CalcMarks[i].SEQ + "','" + sCDegree + "','" + sCMajor + "','" + sUser + "',GETDATE())";
                    Cmd.CommandText = sSQL;
                    iCopied += Cmd.ExecuteNonQuery();
                }
                CalcMarks.Clear();


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
            return iCopied;
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
                var value = cmd.ExecuteScalar();
                string result = "0";
                if (value != null)
                {
                    result = value.ToString();
                }

                CGPA = Convert.ToDouble("0" + result);
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
            return CGPA;
        }
        private int Recreate_AL(string sID, int iCYear, int iCSem)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            int iCreated = 0;
            try
            {
                //CRU.bPassIt=1
                string sSQL = "SELECT CRU.intStudyYear, CRU.byteSemester, CRU.strCourse,";
                sSQL += " CRU.sRealCourse, CRU.sUnified, CRU.strGrade, CRU.curSeq,MC.strCourse AS sAlternated ";
                sSQL += " FROM Calc_Real_Unified AS CRU INNER JOIN Majors_Courses AS MC ON CRU.sUnified = MC.sUnified AND CRU.strCourse <> MC.strCourse";
                sSQL += " WHERE (MC.strCollege = '" + sNCollege + "' AND MC.strDegree = '" + sNDegree + "' AND MC.strSpecialization = '" + sNMajor + "'";
                sSQL += " AND CRU.lngStudentNumber='" + sID + "' AND CRU.intStudyYear=" + iCYear + " AND CRU.byteSemester<" + iCSem + ")";
                sSQL += " OR (MC.strCollege = '" + sNCollege + "' AND MC.strDegree = '" + sNDegree + "' AND MC.strSpecialization = '" + sNMajor + "'";
                sSQL += " AND CRU.lngStudentNumber='" + sID + "' AND CRU.intStudyYear<" + iCYear + ")";


                SqlCommand Cmd = new SqlCommand(sSQL, Conn);

                SqlDataReader Rd = Cmd.ExecuteReader();
                List<CalcMark> CalcMarks = new List<CalcMark>();
                int iYear = 0;
                int iSem = 0;
                string sCourse = "";
                string sAlternated = "";
                double dSequence = 0;
                string sGrade = "";
                int iFound = 0;
                CalcMark myMark;
                while (Rd.Read())//Collect Alternative
                {
                    iYear = int.Parse(Rd["intStudyYear"].ToString());
                    iSem = int.Parse(Rd["byteSemester"].ToString());
                    sCourse = Rd["strCourse"].ToString();
                    sAlternated = Rd["sAlternated"].ToString();
                    dSequence = Convert.ToDouble(Rd["curSeq"].ToString());
                    sGrade = Rd["strGrade"].ToString();


                    iFound = CalcMarks.FindIndex(delegate (CalcMark C) { return (C.Scourse == sCourse && C.Salternated == sAlternated); });
                    if (iFound >= 0)
                    {
                        if (CalcMarks[iFound].Dsequence < dSequence)
                        {
                            CalcMarks[iFound].Iyear = iYear;
                            CalcMarks[iFound].Isem = iSem;
                            CalcMarks[iFound].Dsequence = dSequence;
                            CalcMarks[iFound].Sgrade = sGrade;
                        }
                    }
                    else
                    {
                        myMark = new CalcMark();
                        myMark.Iyear = iYear;
                        myMark.Isem = iSem;
                        myMark.Scourse = sCourse;
                        myMark.Salternated = sAlternated;
                        myMark.Dsequence = dSequence;
                        myMark.Sgrade = sGrade;
                        CalcMarks.Add(myMark);
                    }
                }

                Rd.Close();

                //Clear the Current Alternative
                sSQL = "UPDATE Reg_Grade_Header SET sAlt='',sEq=''";
                sSQL += " WHERE lngStudentNumber='" + sID + "'";
                Cmd.CommandText = sSQL;
                Cmd.ExecuteNonQuery();

                //List<CalcMark> myAlternated = new List<CalcMark>();
                //CalcMark myAlternative;
                iCreated = 0;
                for (int i = 0; i < CalcMarks.Count; i++)
                {
                    sSQL = "UPDATE Reg_Grade_Header SET sAlt='" + CalcMarks[i].Salternated + "'";
                    sSQL += " WHERE strCourse='" + CalcMarks[i].Scourse + "' AND intStudyYear=" + CalcMarks[i].Iyear;
                    sSQL += " AND byteSemester=" + CalcMarks[i].Isem + " AND lngStudentNumber='" + sID + "'";
                    Cmd.CommandText = sSQL;
                    iCreated += Cmd.ExecuteNonQuery();
                    //sAlternated = CalcMarks[i].Salternated;
                    //iFound = myAlternated.FindIndex(delegate(CalcMark C) { return (C.Salternated == sAlternated); });
                    //if (iFound < 0)
                    //{
                    //    myAlternative = new CalcMark();
                    //    myAlternative.Iyear = 0;
                    //    myAlternative.Isem = 0;
                    //    myAlternative.Scourse = CalcMarks[i].Scourse;
                    //    myAlternative.Salternated = CalcMarks[i].Salternated;
                    //    myAlternative.Dsequence = 0;
                    //    myAlternative.Sgrade = "AL";
                    //    myAlternated.Add(myAlternative);
                    //}
                }

                CalcMarks.Clear();

                //iCreated = 0;
                //for (int i = 0; i < myAlternated.Count; i++)
                //{
                //    sSQL = "INSERT INTO Reg_Grade_Header (intStudyYear,byteSemester,byteShift,strCourse,byteClass,";
                //    sSQL += "lngStudentNumber,strGrade,bCanceled,bDisActivated,strUserCreate,dateCreate)";
                //    sSQL += " VALUES(" + myAlternated[i].Iyear + "," + myAlternated[i].Isem + ",1,'" + myAlternated[i].Salternated + "',1,";
                //    sSQL += "'" + sID + "','AL',0,0,'" + sUser + "',GETDATE())";
                //    Cmd.CommandText = sSQL;
                //    iCreated += Cmd.ExecuteNonQuery();
                //}
                //myAlternated.Clear();




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
            return iCreated;
        }
        private void SetFreeElective(string sID)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {


                string sSQL = "SELECT R.intStudyYear, R.byteSemester, R.strCourse, R.sRealCourse, F.sUnified,R.strGrade,R.curSeq";
                sSQL += " FROM Calc_Real_Courses AS R INNER JOIN Reg_Specialization_Free_Unified AS F ON R.sRealCourse = F.sCourse";
                sSQL += " WHERE (R.bPassIt = 1) AND (R.lngStudentNumber = N'" + sID + "') ";
                sSQL += " AND (F.sToCollege = '" + sNCollege + "') AND (F.sToDegree = '" + sNDegree + "') AND (F.sToMajor = '" + sNMajor + "')";
                sSQL += " AND (F.sCollege = '" + sCCollege + "') AND (F.sDegree = '" + sCDegree + "') AND (F.sMajor = '" + sCMajor + "')";


                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                List<CalcMark> CalcMarks = new List<CalcMark>();
                int iCreated = 0;
                int iYear = 0;
                int iSem = 0;
                string sCourse = "";
                string sAlternated = "";
                double dSequence = 0;
                string sGrade = "";
                int iFound = 0;
                CalcMark myMark;
                while (Rd.Read())//Collect Alternative
                {
                    iYear = int.Parse(Rd["intStudyYear"].ToString());
                    iSem = int.Parse(Rd["byteSemester"].ToString());
                    sCourse = Rd["strCourse"].ToString();
                    sAlternated = Rd["sUnified"].ToString();
                    dSequence = Convert.ToDouble(Rd["curSeq"].ToString());
                    sGrade = Rd["strGrade"].ToString();


                    iFound = CalcMarks.FindIndex(delegate (CalcMark C) { return (C.Scourse == sCourse && C.Salternated == sAlternated); });
                    if (iFound >= 0)
                    {
                        if (CalcMarks[iFound].Dsequence < dSequence)
                        {
                            CalcMarks[iFound].Iyear = iYear;
                            CalcMarks[iFound].Isem = iSem;
                            CalcMarks[iFound].Dsequence = dSequence;
                            CalcMarks[iFound].Sgrade = sGrade;
                        }
                    }
                    else
                    {
                        myMark = new CalcMark();
                        myMark.Iyear = iYear;
                        myMark.Isem = iSem;
                        myMark.Scourse = sCourse;
                        myMark.Salternated = sAlternated;
                        myMark.Dsequence = dSequence;
                        myMark.Sgrade = sGrade;
                        CalcMarks.Add(myMark);
                    }
                }

                Rd.Close();

                //CalcMark myAlternative;
                iCreated = 0;
                for (int i = 0; i < CalcMarks.Count; i++)
                {
                    sSQL = "UPDATE Reg_Grade_Header SET sAlt='" + CalcMarks[i].Salternated + "'";
                    sSQL += " WHERE strCourse='" + CalcMarks[i].Scourse + "' AND intStudyYear=" + CalcMarks[i].Iyear;
                    sSQL += " AND byteSemester=" + CalcMarks[i].Isem + " AND lngStudentNumber='" + sID + "'";
                    Cmd.CommandText = sSQL;
                    iCreated += Cmd.ExecuteNonQuery();

                }

                CalcMarks.Clear();
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
        private int GetStatus(string sID)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            int iStatus = 0;
            try
            {
                string sStatus = "";
                sStatus = LibraryMOD.GetColValue(Conn, "byteCancelReason", "Reg_Applications", "lngStudentNumber='" + sID + "'");
                if (!string.IsNullOrEmpty(sStatus))
                {
                    iStatus = int.Parse(sStatus);
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
                Conn.Close();
                Conn.Dispose();
            }
            return iStatus;
        }
        private bool isQualified(int iSerial, string sDegree, string sMajor, int iStatus)
        {
            SqlConnection Conn = new SqlConnection(sConn);
            Conn.Open();
            bool isIt = false;
            try
            {
                int iHSPassed = 0;
                int iEmSAT_Passed = 0;
                bool isFNDPassed = false;
                bool isDiplomaTC = false;
                bool isBscTC = false;
                int iCert = 0;

                string sSQL = "SELECT intCertificate FROM  dbo.Reg_Student_Qualifications AS Q WHERE (intCertificate = 12 or intCertificate = 2 or intCertificate = 3 ) AND (lngSerial =" + iSerial + ")";
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    iCert = Convert.ToInt32(Rd["intCertificate"].ToString());
                    switch (iCert)
                    {
                        case 2:
                            isDiplomaTC = true;
                            break;
                        case 3:
                            isBscTC = true;
                            break;
                        case 12:
                            isFNDPassed = true;
                            break;
                    }
                }
                Rd.Close();
                //HS
                sSQL = "Select isDiploma from HS Where lngSerial=" + iSerial;
                Cmd.CommandText = sSQL;
                iHSPassed = (int)Cmd.ExecuteScalar();

                if ((sDegree == "1" || sDegree == "3") && (iHSPassed == 1 || iCert > 0 || iStatus == 3))
                {
                    isIt = true;
                }
                else if (sDegree == "2" && iHSPassed == 2 && iCert == 0)
                {
                    isIt = true;
                }
                else
                {
                    isIt = false;
                }
                //======================================================
                if (is_EmSAT_Required(sDegree, sMajor) && isIt == true)
                {
                    //check if EmSAt Arabic test entered in the system and get score>=1000

                    Rd.Close();

                    sSQL = "SELECT  (CASE WHEN SQ.sngGrade >= C.curPassed THEN 1 ELSE 2 END) AS isPass_EmSAT ";
                    sSQL += " FROM Reg_Student_Qualifications AS SQ INNER JOIN ";
                    sSQL += " Lkp_Certificates AS C ON SQ.intCertificate = C.intCertificate";
                    sSQL += " Where SQ.lngSerial=" + iSerial;
                    sSQL += " AND SQ.intCertificate = 26";

                    Cmd.CommandText = sSQL;

                    Rd = Cmd.ExecuteReader();

                    while (Rd.Read())
                    {
                        iEmSAT_Passed = Convert.ToInt32("0" + Rd["isPass_EmSAT"].ToString());
                    }
                    if (iEmSAT_Passed == 1)
                    {
                        isIt = true;
                    }
                    else
                    {
                        isIt = false;
                    }
                }
                if (isIt == true)//Check ENG
                {
                    sSQL = "SELECT strCert,Mark FROM MaxEngCertMark WHERE lngSerial=" + iSerial;
                    Cmd.CommandText = sSQL;
                    Rd = Cmd.ExecuteReader();

                    string sCert = "";
                    float fScore = 0;

                    while (Rd.Read())
                    {
                        sCert = Rd["strCert"].ToString();
                        fScore = float.Parse(Rd["Mark"].ToString());
                    }
                    Rd.Close();

                    bool isGeneral = false;
                    sSQL = "SELECT isGeneral FROM Reg_Specializations WHERE strDegree='" + sDegree + "' AND strSpecialization='" + sMajor + "'";
                    Cmd.CommandText = sSQL;
                    Rd = Cmd.ExecuteReader();
                    while (Rd.Read())
                    {
                        isGeneral = bool.Parse(Rd["isGeneral"].ToString());
                    }
                    Rd.Close();
                    bool isPassed = LibraryMOD.isENGPassed(fScore, sCert, sDegree, sMajor);
                    isIt = (isPassed || isGeneral);
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
                Conn.Close();
                Conn.Dispose();
            }
            return isIt;

        }
        public bool is_EmSAT_Required(string sDegree, string sMajorID)
        {
            bool isRequired = false;

            try
            {
                if (sDegree == "3")
                {
                    switch (sMajorID)  //BA_PRA,BA_RTV,BA_JOR
                    {
                        case "4":
                        case "5":
                        case "6":
                            isRequired = true;
                            break;
                    }
                }
                if (sDegree == "1" && sMajorID == "24") //Diploma of public relation
                {
                    isRequired = true;
                }
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                isRequired = true;
            }
            finally
            {

            }
            return isRequired;
        }
        private string CreateNewApp(string sNCollege, string sNDegree, string sNMajor, string sCDegree, int iStatus)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            string sCreated = "";
            try
            {
                int iTerm = int.Parse(ddlTerm.SelectedValue);
                int iYear, iSem;
                iYear = LibraryMOD.SeperateTerm(iTerm, out iSem);
                int iStudentType = 0;
                switch (sNDegree)
                {
                    case "1":
                        iStudentType = 0;//Diploma
                        break;
                    case "2":
                        if (sNMajor != "2" && sNMajor != "3" && sNMajor != "4")//ESL//Not Foundation
                        {
                            iStudentType = 5;
                        }
                        else
                        {
                            iStudentType = 2;//Foundation
                        }

                        break;
                    case "3":
                        iStudentType = 3;//Bsc
                        break;
                }

                CreateNewId(iStudentType, iYear, iSem, iStatus, sCDegree);
                string sNewId = lnkNewId.Text;
                CopyDS.Insert();
                int iNewSerial = int.Parse(hdnNewSerial.Value);
                //if NewID (year and semester) = ESL file (year & semester) then copy qualifications
                int iNewIDTerm = iYear * 10 + iSem;
                int iOldIDTerm = LibraryMOD.GetStudentTerm(Campus, int.Parse(hdnSerial.Value));

                if (iNewIDTerm == iOldIDTerm)
                {
                    CopyQualification(int.Parse(hdnSerial.Value), iNewSerial);
                }

                int iHours = 0;
                SpecializationsDAL mySpecDAL = new SpecializationsDAL();
                iHours = mySpecDAL.GetHours(Campus, sNCollege, sNDegree, sNMajor);

                //string sSQL = "INSERT INTO Reg_Applications";
                //sSQL += " (intStudyYear, byteSemester, strApplicationNumber, lngStudentNumber,sReference, dateApplication, lngSerial, strCollege, strDegree, strSpecialization, bAccepted,";
                //sSQL += " dateAccepted, strNotes, bActive, bContinue, bOtherCollege, intAdvisor, byteStudentType, strUserCreate, dateCreate, intRemind)";
                //sSQL += " VALUES(" + iYear + "," + iSem + ",'" + sNewId + "','" + sNewId + "','" + lblStudentNo.Text + "', GETDATE()," + iNewSerial + ",'" + sNCollege + "','" + sNDegree + "','" + sNMajor + "', 1,";
                //sSQL += " GETDATE(), '', 1, 1, 0, 1000,"+iStudentType+",'"+sUser+"', GETDATE(), "+iHours+")";

                string sSQL = "INSERT INTO Reg_Applications";
                sSQL += " (intStudyYear, byteSemester, strApplicationNumber, lngStudentNumber,sReference, dateApplication, lngSerial, strCollege, strDegree, strSpecialization, bAccepted,";
                sSQL += " dateAccepted, strNotes, bActive, bContinue, bOtherCollege, intAdvisor, byteStudentType, strUserCreate, dateCreate, intRemind,";
                sSQL += " WantedMajorID, strAccountNo, iEnrollmentSource, sEnrollmentNotes, iRegisteredThrough, iEnrollmentSource2, IsCompleteBAFromOtherInstitution,IsCompleteMasterFromOtherInstitution,WantedMajorID2, WantedMajorID3, sReferredBy,iContactID,iOpportunityID,iAcceptanceType,iAcceptanceCondition,iAdmissionStatus,isOpportunitySet)";
                sSQL += " SELECT " + iYear + "," + iSem + ",'" + sNewId + "','" + sNewId + "','" + lblStudentNo.Text + "', GETDATE()," + iNewSerial + ",'" + sNCollege + "','" + sNDegree + "','" + sNMajor + "', 1,";
                sSQL += " GETDATE(), '', 1, 1, 0, 1000," + iStudentType + ",'" + sUser + "', GETDATE(), " + iHours + ",";
                sSQL += " WantedMajorID, strAccountNo, iEnrollmentSource, sEnrollmentNotes, iRegisteredThrough, iEnrollmentSource2, IsCompleteBAFromOtherInstitution,IsCompleteMasterFromOtherInstitution,WantedMajorID2, WantedMajorID3, sReferredBy,iContactID,iOpportunityID,iAcceptanceType,iAcceptanceCondition,iAdmissionStatus,isOpportunitySet";
                sSQL += " FROM Reg_Applications AS Src";
                sSQL += " WHERE (Src.lngStudentNumber = '" + lblStudentNo.Text + "')";



                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                int iEffected = 0;

                iEffected = Cmd.ExecuteNonQuery();
                if (iEffected > 0)
                {
                    sCreated = sNewId;

                    SqlCommand cmd1 = new SqlCommand("Select strAccountNo from Reg_Student_Accounts where lngStudentNumber=@lngStudentNumber", sc);
                    cmd1.Parameters.AddWithValue("@lngStudentNumber", lblStudentNo.Text);
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    try
                    {
                        sc.Open();
                        da1.Fill(dt1);
                        sc.Close();

                        if(dt1.Rows.Count>0)
                        {
                            SqlCommand cmd2 = new SqlCommand("UPDATE Reg_Student_Accounts SET lngStudentNumber=@sNewId WHERE lngStudentNumber=@lngStudentNumber", sc);
                            cmd2.Parameters.AddWithValue("@sNewId", sNewId);
                            cmd2.Parameters.AddWithValue("@lngStudentNumber", lblStudentNo.Text);
                            try
                            {
                                sc.Open();
                                cmd2.ExecuteNonQuery();
                                sc.Close();
                            }
                            catch(Exception ex)
                            {
                                sc.Close();
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                sc.Close();
                            }

                            SqlCommand cmd3 = new SqlCommand("UPDATE Reg_Applications SET strAccountNo=@sACC where lngStudentNumber=@lngStudentNumber", sc);
                            cmd3.Parameters.AddWithValue("@sACC", dt1.Rows[0]["strAccountNo"].ToString());
                            cmd3.Parameters.AddWithValue("@lngStudentNumber", sNewId);
                            try
                            {
                                sc.Open();
                                cmd3.ExecuteNonQuery();
                                sc.Close();
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

                            SqlCommand cmd4 = new SqlCommand("UPDATE [ECTDataNew].dbo.Cmn_User set UserName= replace(@sNewId,'.','') where UserName=@UserName", sc);
                            cmd4.Parameters.AddWithValue("@sNewId", sNewId);
                            cmd4.Parameters.AddWithValue("@UserName", lblStudentNo.Text);
                            try
                            {
                                sc.Open();
                                cmd4.ExecuteNonQuery();
                                sc.Close();
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

                            //Sent SMS
                            sentsms(sNewId);

                            //Get ContactID
                            SqlCommand cmd5 = new SqlCommand("select iContactID from Reg_Applications where lngStudentNumber=@lngStudentNumber", sc);
                            cmd5.Parameters.AddWithValue("@lngStudentNumber", sNewId);
                            DataTable dt5 = new DataTable();
                            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
                            try
                            {
                                sc.Open();
                                da5.Fill(dt5);
                                sc.Close();

                                if(dt5.Rows.Count>0)
                                {
                                    string iContactID = dt5.Rows[0]["iContactID"].ToString();
                                    if (iContactID != "0" || iContactID != "" || iContactID != null)
                                    {
                                        updatecxapiregistration(iContactID,sNewId);
                                    }
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

                        }
                    }
                    catch(Exception ex)
                    {
                        sc.Close();
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sc.Close();
                    }
                }

                if ((sCDegree == "2" && (sCMajor == "2") || (sCMajor == "3") || (sCMajor == "4")) || iStatus == 20 || iStatus == 7)//Not Foundation
                {
                    int iNewStatus = 4;//Readmitted
                    if (sCDegree == "2" || iStatus == 20)
                    {
                        iNewStatus = 20;//Foundation Compelete
                    }

                    sSQL = "UPDATE Reg_Applications SET byteCancelReason=" + iNewStatus + ",byteMainReason=0,byteSubReason=0,";
                    sSQL += " intGraduationYear=" + iYear + ",byteGraduationSemester=" + iSem + ",strUserSave='" + sUser + "', dateGraduation2=GETDATE(),dateLastSave=GETDATE()";
                    sSQL += " WHERE lngStudentNumber='" + lblStudentNo.Text + "'";
                    Cmd.CommandText = sSQL;
                    iEffected = Cmd.ExecuteNonQuery();
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
                Conn.Close();
                Conn.Dispose();
            }
            return sCreated;
        }
        public void sentsms(string sID)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string phone1 = LibraryMOD.GetStudentMobileNo(Campus, sID);
            if (!string.IsNullOrEmpty(phone1))
            {
                phone1 = LibraryMOD.CleanPhone(phone1);
                if (phone1.Substring(0, 1) == "0")
                {
                    phone1 = "+971" + phone1.Remove(0, 1);
                }
                phone1 = phone1.Trim();
                string sisusername = sID;
                string sispassword = "";
                Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
                SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
                SqlCommand cmd = new SqlCommand("SELECT  [UserNo],[UserName],[Password] FROM [localect].[ECTDataNew].[dbo].[Cmn_User] where UserNo in (SELECT intOnlineUser from [ECTData].[dbo].[Reg_Student_Accounts] where lngStudentNumber=@lngStudentNumber)", sc);
                cmd.Parameters.AddWithValue("@lngStudentNumber", sID);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    if (dt.Rows.Count > 0)
                    {
                        sisusername = dt.Rows[0]["UserName"].ToString();
                        sispassword = dt.Rows[0]["Password"].ToString();

                        string txt = "Welcome to ECT\r\nKindly find the following ECT SIS Credentials:\r\nUser : " + sisusername + "\r\nPassword : " + sispassword + "\r\nLink : https://ectsis.ect.ac.ae/Balance";
                        string textmessage = txt.Trim().Replace("\r\n", "\\r\\n");
                        if (phone1.Trim().StartsWith("+971") && phone1.Substring(4, 1) == "5")
                        {
                            using (var httpClient = new HttpClient())
                            {
                                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://c-eu.linkmobility.io/sms/send"))
                                {
                                    request.Headers.TryAddWithoutValidation("Authorization", "Basic cE9UZ1oyTFc6R2NuMzU1MzJHcXc=");

                                    request.Content = new StringContent("{\n    \"source\": \"AD-ECT\",\n    \"sourceTON\":\"ALPHANUMERIC\",\n    \"destination\": \"" + phone1.Trim() + "\",\n    \"userData\": \"" + textmessage + "\",\n    \"platformId\": \"SMSC\",\n    \"platformPartnerId\": \"3759\",\n    \"useDeliveryReport\": false,\n    \"customParameters\": {\n\"replySmsCount\": \"true\"\n}\n}");
                                    //request.Content = new StringContent("{\n    \"source\": \"LINK\",\n    \"destination\": \"" + txt_Mobile.Text.Trim() + "\",\n    \"userData\": \"" + txt_Text.Text.Trim() + "\",\n    \"platformId\": \"SMSC\",\n    \"platformPartnerId\": \"3759\",\n    \"useDeliveryReport\": false\n}");
                                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                                    var task = httpClient.SendAsync(request);
                                    task.Wait();
                                    var response = task.Result;
                                    string s = response.Content.ReadAsStringAsync().Result;
                                    if (response.IsSuccessStatusCode == true)
                                    {
                                        //Success
                                        //lbl_Msg.Text = "SMS Sent";
                                        //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                                        //div_msg.Visible = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            //lbl_Msg.Text = "Invalid Mobile Number";
                            //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                            //return;
                        }
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
            }
            else
            {

            }
        }
        public void updatecxapiregistration(string contactid,string sID)
        {
            string registrationstatus = "Unregistered";
            string retention_status = "Opened";
            string numberofregisteredcourses = "0";
            string cgpa = "0";
            string ect_student_id = sID;
            string financialbalance = "A";
            string sisusername = sID;
            string sispassword = "ect@12345";
            string ectemailpassword = "ect@12345";
            string major = ddlMajor.SelectedItem.Text;
            string Credit_Completed = "0";

            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            SqlCommand cmd = new SqlCommand("SELECT  [UserNo],[UserName],[Password] FROM [localect].[ECTDataNew].[dbo].[Cmn_User] where UserNo in (SELECT intOnlineUser from [ECTData].[dbo].[Reg_Student_Accounts] where lngStudentNumber=@lngStudentNumber)", sc);
            cmd.Parameters.AddWithValue("@lngStudentNumber", sID);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    sisusername = dt.Rows[0]["UserName"].ToString();
                    sispassword = dt.Rows[0]["Password"].ToString();
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
                        //API Call-Update Registration Status-SUCCESS
                    }

                }
            }
        }
        private void CopyQualification(int iOldSerial, int iNewSerial)
        {

            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "INSERT INTO Reg_Student_Qualifications";
                sSQL += " (lngSerial,byteQualification,intCertificate,intMajor,intMinor,intGraduationYear,byteSemester";
                sSQL += ",byteYears,byteInstituteCountry,byteStudyLanguage,byteStudyType,sngGrade,byteGrade,IESOL_Grade";
                sSQL += ",strCertificateSource,ExamCenterID,byteLevel,intLecturer,dateENG,VerifiedByAdmission,AdmissionComments";
                sSQL += ",AdmissionUserID,AdmissionUpdateDate,VerifiedByRegistrar,RegistrarComments,RegistrarUserID";
                sSQL += ",RegistrarUpdateDate,VerifiedByDirector,DirectorComments,DirectorUserID,DirectorUpdateDate,strUserCreate";
                sSQL += ",dateCreate,strUserSave,dateLastSave,strMachine,strNUser,byteEmirate,sGrade,HS_InstitutionType";
                sSQL += ",HS_InstitutionCity,G12_Stream,HSSystem,ScoreOfMath,ScoreOfChemistry,ScoreOfBiology,ScoreOfPhysics)";

                sSQL += " SELECT " + iNewSerial + " AS Serial,byteQualification,intCertificate ,intMajor,intMinor,intGraduationYear,byteSemester";
                sSQL += ",byteYears,byteInstituteCountry,byteStudyLanguage,byteStudyType,sngGrade,byteGrade,IESOL_Grade";
                sSQL += ",strCertificateSource,ExamCenterID,byteLevel,intLecturer,dateENG,VerifiedByAdmission,AdmissionComments";
                sSQL += ",AdmissionUserID,AdmissionUpdateDate,VerifiedByRegistrar,RegistrarComments,RegistrarUserID";
                sSQL += ",RegistrarUpdateDate,VerifiedByDirector,DirectorComments,DirectorUserID,DirectorUpdateDate,strUserCreate";
                sSQL += ",dateCreate,strUserSave,dateLastSave,strMachine,strNUser,byteEmirate,sGrade,HS_InstitutionType";
                sSQL += ",HS_InstitutionCity,G12_Stream,HSSystem,ScoreOfMath,ScoreOfChemistry,ScoreOfBiology,ScoreOfPhysics";
                sSQL += " FROM Reg_Student_Qualifications";
                sSQL += " WHERE [lngSerial]=" + iOldSerial;

                SqlCommand Cmd = new SqlCommand(sSQL, Conn);

                Cmd.ExecuteNonQuery();

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
        private void CreateNewId(int iType, int iYear, int iSem, int iStatus, string sCDegree)
        {

            try
            {
                //Extention
                if ((iStatus == 3 || iStatus == 25) && (sCDegree != "2"))
                {
                    lnkNewId.Text = lblStudentNo.Text + ".";
                }
                else
                {
                    //SidDS.SelectParameters.Clear(); 
                    SidDS.ConnectionString = sConn;
                    SidDS.SelectParameters["iType"].DefaultValue = iType.ToString();
                    SidDS.SelectParameters["iYear"].DefaultValue = iYear.ToString();
                    SidDS.SelectParameters["iSem"].DefaultValue = iSem.ToString();
                    SidDS.SelectParameters["iCampus"].DefaultValue = ((int)Campus).ToString();
                    SidDS.Select(DataSourceSelectArguments.Empty);
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

        }

        private int CalculateGrades(string sID, double CGPA)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            int iCalculated = 0;
            try
            {
                DeleteAL_EQ(sID);

                //double CGPA = 0;
                //CGPA =double.Parse( "0"+ LibraryMOD.GetColValue(Conn, "CGPA", "GPA_Until", " lngStudentNumber='" + sID +"'"));

                //Dont Cancel for ESL Re-Medial
                bool dontcancel = ((sCDegree == "2" && ((sCMajor != "2") && (sCMajor != "3") && (sCMajor != "4"))) || (sNDegree == "2" && ((sNMajor != "2") && (sNMajor != "3") && (sNMajor != "4"))));//Not Foundation
                if (CGPA < 2 && (dontcancel != true))
                {
                    Cancel_Grades(sID, iRegYear, iRegSem);
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
                Conn.Close();
                Conn.Dispose();
            }
            return iCalculated;
        }
        private void DeleteAL_EQ(string sID)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                string sSQL = "DELETE FROM Reg_Grade_Header";
                sSQL += " WHERE lngStudentNumber='" + sID + "'";
                sSQL += " AND strGrade IN ('EQ','AL')";

                SqlCommand cmd = new SqlCommand(sSQL, Conn);

                int iEffected = cmd.ExecuteNonQuery();

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

        private void Cancel_Grades(string sID, int iYear, int iSem)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {

                string sSQL = "UPDATE Reg_Grade_Header";
                sSQL += " SET bCanceled = 1, intCanceledYear = " + iYear + ", byteCanceledSem = " + iSem;
                sSQL += " WHERE ((lngStudentNumber = '" + sID + "') AND (strGrade IN";
                sSQL += " (SELECT strGrade FROM Reg_Grade_System";
                sSQL += " WHERE (curSeq <= 0.5) OR (curSeq = 1)OR (curSeq = 1.3) OR (curSeq = 1.7))) ";
                sSQL += " AND (intStudyYear = " + iYear + ") AND (byteSemester < " + iSem + "))";
                sSQL += " or ((lngStudentNumber = '" + sID + "') AND (strGrade IN";
                sSQL += " (SELECT strGrade FROM Reg_Grade_System ";
                sSQL += " WHERE (curSeq <= 0.5) OR (curSeq = 1) OR (curSeq = 1.3) OR (curSeq = 1.7))) ";
                sSQL += " AND (intStudyYear < " + iYear + "))";


                SqlCommand cmd = new SqlCommand(sSQL, Conn);

                int iEffected = cmd.ExecuteNonQuery();

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
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentSearch");
        }

        protected void SidDS_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            DbCommand command = e.Command;
            lnkNewId.Text = command.Parameters["@RETURN_VALUE"].Value.ToString();
        }
        protected void CopyDS_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            try
            {
                DbCommand command = e.Command;
                hdnNewSerial.Value = command.Parameters["@RETURN_VALUE"].Value.ToString();
                Session["StudentSerialNo"] = int.Parse(hdnNewSerial.Value);
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
        }
    }
}