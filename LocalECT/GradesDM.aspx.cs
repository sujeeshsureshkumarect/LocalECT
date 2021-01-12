using System;
using System.Collections;
using System.Configuration;
using System.Data;
////////using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//////using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;

namespace LocalECT
{
    public partial class GradesDM : System.Web.UI.Page
    {
        InitializeModule.EnumCampus CurrentCampus = InitializeModule.EnumCampus.Males;

        InitializeModule.EnumGradeDMType GradeDMType = InitializeModule.EnumGradeDMType.Entry;

        List<Grades> myGrades = new List<Grades>();
        GradesDAL myGradesDAL = new GradesDAL();

        List<GradesTypes> myGradesType = new List<GradesTypes>();
        GradesTypesDAL MyGradesTypeDal = new GradesTypesDAL();

        string sTitle = "";
        int iStudyYear = 0;
        byte bSemester = 0;
        byte bShift = 0;
        string sCourse = "";
        byte bClass = 0;
        int DetailCount = 0;
        int CurrentRole = 0;
        string sLecturer;
        string sUserName = "";
        string sStudent = "";



        protected void Page_Load(object sender, EventArgs e)
        {
            //Security
            //int CurrentRole = 0;

            if (Session["OpenGradesType"] != null)
            {
                GradeDMType = (InitializeModule.EnumGradeDMType)Session["OpenGradesType"];
                lnkbtnExportAllSectionsMarks.Visible = true;
            }
            else
            {
                GradeDMType = InitializeModule.EnumGradeDMType.View;
                lnkbtnExportAllSectionsMarks.Visible = false;
            }

            if (Session["CurrentRole"] != null)
            {

                CurrentRole = Convert.ToInt32(Session["CurrentRole"]);
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                    InitializeModule.enumPrivilege.MakeAllPassed, CurrentRole) == true)
                {
                    AllPassedCHK.Visible = true;//(Session["CurrentUserName"].ToString().ToLower() == "admin");
                }

                if (Session["CurrentUserName"] != null)
                {
                    sUserName = Session["CurrentUserName"].ToString();
                }

                if (IsPostBack)
                {

                    //string sss=  Request.Form[0];  
                }
                if (!IsPostBack)
                {


                    int iDataStatus = (int)InitializeModule.enumModes.NewMode;
                    int iEffected = 0;

                    int iUserNo = Convert.ToInt32(Session["CurrentUserNo"]);
                    string sPCName = Convert.ToString(Session["CurrentPCName"]);
                    string sCookie = GetCookie(sUserName);
                    string sDataPC = LibraryMOD.GetCurrentUserPcName(iUserNo).ToLower();
                    string sNetUserName = Convert.ToString(Session["CurrentNetUserName"]);
                    int iSystem = Convert.ToInt32(Session["CurrentSystem"]);
                    int iYear = Convert.ToInt32(Session["CurrentYear"]);
                    int iSemester = Convert.ToInt32(Session["CurrentSemester"]);


                    if (GradeDMType == InitializeModule.EnumGradeDMType.Entry)
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                        InitializeModule.enumPrivilege.AllowGradesFromAnyPC, CurrentRole) != true)
                        {
                            if (sDataPC != sPCName)
                            {
                                if (sDataPC != sCookie)
                                {
                                    Response.Redirect("Authorization.aspx? Sorry you are not allowed to enter grades from this PC");
                                }
                                else
                                {
                                    sPCName = sCookie;
                                }
                            }
                        }
                    }

                    LogHistoryDAL myLogHistoryDAL = new LogHistoryDAL();

                    iEffected = myLogHistoryDAL.UpdateLogHistory(InitializeModule.EnumCampus.ECTNew,
                        iDataStatus, 0, iUserNo, DateTime.Now, sPCName, sNetUserName,
                        iSystem, (int)InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
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

                    if ((LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true) &&
                    (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesView,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true))
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

            CurrentCampus = (InitializeModule.EnumCampus)int.Parse(Request.QueryString["Campus"]);
            if (Request.QueryString.Count > 2)
            {
                sStudent = Request.QueryString["sStudent"];
                lnkbtnExportAllSectionsMarks.Visible = false;
            }


            if (Session["GradesArgs"] != null)
            {
                string sArgs = Session["GradesArgs"].ToString();
                SetArgs(sArgs);

            }


            if (Session["MyGrades"] != null)
            {
                myGrades = (List<Grades>)Session["MyGrades"];
            }

            if (Session["CurrentLecturerName"] != null)
            {
                sLecturer = Session["CurrentLecturerName"].ToString();
            }

            if (!IsPostBack)
            {

                bool isFinalShown = false;
                switch (GradeDMType)
                {
                    case InitializeModule.EnumGradeDMType.Entry:
                        SaveCMD.Visible = true;
                        isFinalShown = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                                        InitializeModule.enumPrivilege.ShowFinalGrades, CurrentRole);
                        break;
                    case InitializeModule.EnumGradeDMType.View:
                        SaveCMD.Visible = false;
                        isFinalShown = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesView,
                                        InitializeModule.enumPrivilege.ShowFinalGrades, CurrentRole);

                        lnkbtnExportAllSectionsMarks.Visible = false;
                        break;
                    default:
                        break;
                }

                myGradesType = MyGradesTypeDal.GetGradesTypes(CurrentCampus, sCourse, iStudyYear, bSemester);
                DetailCount = myGradesType.Count;
                Session["GradesDCount"] = DetailCount;
                //Here
                myGrades = myGradesDAL.GetGrades(CurrentCampus, iStudyYear, bSemester, bShift, sCourse, bClass.ToString(), DetailCount, isFinalShown, sStudent);
                Session["GradesHCount"] = myGrades.Count;

                ShowData();
                Session["MyGrades"] = myGrades;

            }


        }

        private void ShowData()
        {

            string sTable = null;
            string sClass = null;
            int rCounter = 0;
            int dCounter = 0;

            decimal dGrade = default(decimal);
            decimal dMax = default(decimal);
            decimal dCGPA = default(decimal);

            string sID = null;
            string sTxtStyle = null;
            string sStyle = null;
            string sGrade = null;
            string sType = null;
            int iLength = 0;
            List<string> sCaptions = new List<string>();
            try
            {
                bool bAllowEditGradeAfterSubmit = false;
                bool bChangeF = false;
                bool bChangeI = false;
                bool bChangeW = false;
                bool isBlocked = false;

                bAllowEditGradeAfterSubmit = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                      InitializeModule.enumPrivilege.AllowEditGradeAfterSubmitting, CurrentRole);

                bChangeF = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                      InitializeModule.enumPrivilege.ChangeGrade_F, CurrentRole);
                bChangeI = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                      InitializeModule.enumPrivilege.ChangeGrade_I, CurrentRole);
                bChangeW = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                      InitializeModule.enumPrivilege.ChangeGrade_EW_W, CurrentRole);

                //int r = 0;
                //string sCondition = " CB.iYear=" + iStudyYear;
                //sCondition += " And CB.Sem=" + bSemester;
                //sCondition += " And CB.Shift=" + bShift;
                //sCondition += " And CB.Course='" + sCourse + "'";
                //sCondition += " And CB.Class=" + bClass;

                if (myGrades.Count == 0)
                {
                    //divMsg.InnerHtml = "<H2>Empty Class</H2>";
                    lbl_Msg.Text = "<H2>Empty Class</H2>";
                    div_msg.Visible = true;
                    return;
                }
                // iStudyYear, bSemester, sCourse
                Session["sCourseCode"] = sCourse;

                sCaptions = CreateCaption();
                sTitle = sCaptions[0];

                sTable = "<table>";
                sTable += "<tr><th colspan='" + (8 + DetailCount).ToString() + " '>" + sTitle + "</th></tr>";
                sTable += "<tr>";
                //
                sTable += "<Th>*</Th><Th>Serial</Th><Th>No</Th><Th>Name</Th><Th>GPA</Th>";
                for (dCounter = 0; dCounter <= DetailCount - 1; dCounter++)
                {
                    iLength = myGradesType[dCounter].GradeDesc.Length;
                    if (iLength > 7)
                    {
                        iLength = 7;
                    }
                    sTable += "<th>" + myGradesType[dCounter].GradeDesc.Substring(0, iLength) + "-" + myGradesType[dCounter].Percentage.ToString("00") + "%</th>";
                }

                sTable += "<Th>Mark</Th>";
                sTable += "<Th>Grade</Th>";
                sTable += "<Th style ='width: 80px;'>At Risk</Th>";
                sTable += "</tr>";

                for (rCounter = 0; rCounter < myGrades.Count; rCounter++)
                {
                    if ((rCounter % 2 > 0))
                    {
                        sTable += "<tr Class='R_NormalWhite'>";
                    }
                    else
                    {
                        sTable += "<tr Class='R_NormalGray'>";
                    }



                    //Get Status 
                    int iStatus = LibraryMOD.GetStudentStatus(CurrentCampus, myGrades[rCounter].Stno);
                    //"~/Images/Icons/star.gif"
                    if (myGrades[rCounter].Remind == "0")
                    {
                        sTable += "<td><img id='ImgRemind" + rCounter + "' name='ImgRemind" + rCounter + "' alt='' src='Images/Icons/star.gif' /></td>";
                    }
                    else
                    {
                        sTable += "<td></td>";

                    }


                    sTable += "<td><input type='hidden' id='StNo" + rCounter + "' value='" + myGrades[rCounter].Stno + "'/>" + (rCounter + 1) + "</td>";

                    //======================
                    //sTable += "<td>" + myGrades[rCounter].Stno + "</td>";
                    sStyle = "style='vertical-align: bottom; width: 85px; text-align: left'";
                    sTable += "<td><input name='StudentID" + rCounter + "' id='StudentID" + rCounter + "' type='text' readonly='readonly' " + sStyle + " value='" + myGrades[rCounter].Stno + "'/></td>";
                    //======================

                    sTable += "<td><input name='TextName" + rCounter + "' id='TextName" + rCounter + "' type='text' size='40' readonly='readonly' value='" + myGrades[rCounter].SName + "'/></td>";

                    if (myGrades[rCounter].CGPA <= decimal.Parse("2.0")) //&&  Convert.ToInt32( myGrades[rCounter].IsIncluded_AtRisk) == 1
                    {
                        sStyle = "style='vertical-align: bottom; background-color: #EC3C00; width: 30px; text-align: center'";
                    }
                    else if (myGrades[rCounter].CGPA > decimal.Parse("2.0") && myGrades[rCounter].CGPA <= decimal.Parse("2.2"))
                    {
                        sStyle = "style='vertical-align: bottom; background-color: #FF9900; width: 30px; text-align: center'";
                    }
                    else
                    {
                        sStyle = "style='vertical-align: bottom; width: 30px; text-align: center'";
                    }
                    if (myGrades[rCounter].CGPA != 101)
                    {
                        sTable += "<td><input name='TextCGPA" + rCounter + "' id='TextCGPA" + rCounter + "' type='text' readonly='readonly' " + sStyle + " value='" + string.Format("{0:F2}", myGrades[rCounter].CGPA) + "'/></td>";
                    }
                    if (myGrades[rCounter].CGPA == 101)
                    {
                        sTable += "<td><input name='TextCGPA" + rCounter + "' id='TextCGPA" + rCounter + "' type='text' readonly='readonly' " + sStyle + " value=''/></td>";
                    }


                    sGrade = myGrades[rCounter].Grade;
                    sTxtStyle = "style='vertical-align: bottom; width: 60px; text-align: center' maxlength='5'";

                    switch (GradeDMType)
                    {
                        case InitializeModule.EnumGradeDMType.Entry:

                            if ((sGrade == "EQ") | (sGrade == "EX") | (sGrade == "TC"))
                            {
                                isBlocked = true;
                            }
                            else if (((sGrade == "W") | (sGrade == "EW")) && bChangeW == false)
                            {
                                isBlocked = true;
                            }
                            else if ((sGrade == "I") && bChangeI == false)
                            {
                                isBlocked = true;
                            }
                            else if ((sGrade == "F") && bChangeF == false && iStatus > 0)//Block it if no permission and there is status
                            {
                                isBlocked = true;
                            }
                            else
                            {
                                isBlocked = false;
                            }
                            break;
                        case InitializeModule.EnumGradeDMType.View:
                            isBlocked = true;

                            break;
                        default:
                            isBlocked = false;
                            break;
                    }

                    for (dCounter = 0; dCounter < myGrades[rCounter].GradesDatails.Count; dCounter++)
                    {
                        dMax = myGrades[rCounter].GradesDatails[dCounter].Percentage;

                        sID = "R" + rCounter + "C" + dCounter;
                        //& "T" & Format(myGrades(rCounter).Grades(dCounter).GradeType, "000") 
                        dGrade = myGrades[rCounter].GradesDatails[dCounter].Grade;
                        if (isBlocked == true)
                        {
                            sTxtStyle = "style='vertical-align: bottom; width: 60px; text-align: center; background-color: #FFFF00' maxlength='5' readonly='readOnly'";
                        }
                        else
                        {
                            sTxtStyle = "style='vertical-align: bottom; width: 60px; text-align: center' maxlength='5'";
                            if (myGrades[rCounter].GradesDatails[dCounter].GradeType == 103) // Extra credit activities  - allowed for students CGPA <= 2.2
                            {
                                if (myGrades[rCounter].CGPA > decimal.Parse("2.2") && Convert.ToInt32(myGrades[rCounter].IsIncluded_AtRisk) == 0)
                                {
                                    sTxtStyle = "style='vertical-align: bottom; width: 60px; text-align: center; background-color: #FFFF00' maxlength='5' readonly='readOnly'";
                                    myGrades[rCounter].GradesDatails[dCounter].Grade = 0;
                                    dGrade = 0;
                                }
                                else
                                {
                                    sTxtStyle = "style='vertical-align: bottom; width: 60px; text-align: center' maxlength='5' readonly='readOnly'";
                                }
                            }

                            if (dGrade != -1 && bAllowEditGradeAfterSubmit == false)
                            {
                                sTxtStyle = "style='vertical-align: bottom; width: 60px; text-align: center; background-color: #FFFF00' maxlength='5' readonly='readOnly'";
                            }
                        }

                        sType = "<input type='hidden' id='Text" + sID + "T' value='" + myGrades[rCounter].GradesDatails[dCounter].GradeType + "'/>";
                        if (dGrade == -1)
                        {
                            sTable += "<td><input name='Text" + sID + "' id='Text" + sID + "' type='text' " + sTxtStyle + " value='' onchange='txtChanged(this.id," + dMax + "," + rCounter + "," + DetailCount + ")' onkeypress='return txtCleaner(event)' />";
                            sTable += sType + "</td>";
                        }
                        else
                        {
                            sTable += "<td><input name='Text" + sID + "' id='Text" + sID + "' type='text' " + sTxtStyle + " value='" + string.Format("{0:F2}", dGrade) + "' onchange='txtChanged(this.id," + dMax + "," + rCounter + "," + DetailCount + ")' onkeypress='return txtCleaner(event)' />";
                            sTable += sType + "</td>";
                        }

                    }

                    if (isBlocked == true)
                    {
                        sTxtStyle = "style='vertical-align: bottom; width: 60px; text-align: center; background-color: #FFFF00' maxlength='5' readonly='readOnly'";
                    }
                    else
                    {
                        sTxtStyle = "style='vertical-align: bottom; width: 60px; text-align: center' maxlength='5' readonly='readOnly'";
                    }
                    //if (sGrade != "F")
                    //{
                    //    sTable += "<td><input  id='TextM" + rCounter + "' type='text' " + sTxtStyle + " value='" + string.Format("{0:F2}", System.Math.Round(myGrades[rCounter].Mark),MidpointRounding.AwayFromZero) + "'/></td>";
                    //}
                    //else
                    //{
                    sTable += "<td><input  id='TextM" + rCounter + "' type='text' " + sTxtStyle + " value='" + string.Format("{0:F2}", myGrades[rCounter].Mark) + "'/></td>";
                    //}
                    sTable += "<td><input  id='TextG" + rCounter + "' type='text' " + sTxtStyle + " value='" + sGrade + "'/>";

                    sTable += "<input type='hidden' id='DataStatus" + rCounter + "' value='" + myGrades[rCounter].DataStatus + "'/>";
                    sTable += "<input type='hidden' id='isDataGhanged" + rCounter + "' id='isDataGhanged" + rCounter + "' value='" + myGrades[rCounter].isDataChanged + "'/></td>";

                    sStyle = "style='vertical-align: bottom; width: 80px; text-align: center'";
                    // using form post will cause not firing onclickclient (data not saved)
                    //sTable += "<form method='post' action=StudentsAtRisk_Form.aspx>"; // begin form tag
                    //sTable += "<form method='post' action='StudentsAtRisk_Form.aspx'>"; //begin form tag

                    if (Convert.ToInt32(myGrades[rCounter].IsIncluded_AtRisk) == 1)
                    {
                        //System.Math.Round(myGrades[rCounter].CGPA, MidpointRounding.AwayFromZero) <= decimal.Parse("2.2049") && 
                        //add link to at risk page
                        //sTable += "<td><input name='submitAtRisk" + rCounter + "' id='submitAtRisk" + rCounter + "' type='submit' " + sStyle + " value='submit'/></td>";
                        if (myGrades[rCounter].Grade != "EW" && myGrades[rCounter].Grade != "W")
                        {
                            //sTable += "<td " + sStyle +" ><a href='http://localect/StudentsAtRisk_Form.aspx?StudentID=" + myGrades[rCounter].Stno + "&StudentName=" + myGrades[rCounter].SName + "&CGPA=" + myGrades[rCounter].CGPA + "'" + " >At Risk</a></td>";
                        }
                    }
                    else
                    {

                        sTable += "<td><input name='TextAtRisk" + rCounter + "' id='TextAtRisk" + rCounter + "' type='hidden' readonly='readonly' " + sStyle + " value=''/></td>";

                    }

                    sTable += "</tr>";
                }

                sTable += "<tr><td style='background-color: #b0c4de' colspan='" + (6 + DetailCount).ToString() + "'> </td></tr>";
                //<td><input type='submit' value='Save' onclick='SetPost()' style='height: 39px; width: 70px;'/></td>
                sTable += "</table><br/>";
                //rCounter -= 1;
                sClass = "<input type='hidden' id='Count' value='" + rCounter + "'/>";
                sClass += "<input type='hidden' name='Year' value='" + myGrades[0].StudyYear + "'/>";
                sClass += "<input type='hidden' name='Semester' value='" + myGrades[0].Semester + "'/>";
                sClass += "<input type='hidden' name='Shift' value='" + myGrades[0].Shift + "'/>";
                sClass += "<input type='hidden' name='Course' value='" + myGrades[0].Course + "'/>";
                sClass += "<input type='hidden' name='Class' value='" + myGrades[0].bClass + "'/>";
                sClass += "<input type='hidden' id='DetailCount' value='" + DetailCount + "'/>";
                int iGradeSystem = GetGradeSystem();
                sClass += "<input type='hidden' id='GradesSystem' value='" + iGradeSystem + "'/>";



                divDetail.InnerHtml = sTable + sClass;


                //divMsg.InnerText = "";


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
                sCaptions.Clear();
            }

        }

        private List<string> CreateCaption()
        {
            List<string> myCaptions = new List<string>();

            List<ClassesCLS> myCurrenClass = new List<ClassesCLS>();
            ClassesDAL myClassesDAL = new ClassesDAL();
            try
            {
                string sCaption;

                myCurrenClass = myClassesDAL.GetClasses(CurrentCampus, iStudyYear, bSemester, bShift, sCourse, bClass);

                sCaption = myCurrenClass[0].Course + " Class # " + myCurrenClass[0].AttClass + " / " + myCurrenClass[0].Shortcut;
                myCaptions.Add(sCaption);

                for (int i = 0; i < myCurrenClass.Count; i++)
                {
                    sCaption = " ( " + myCurrenClass[i].TimeFrom + " - " + myCurrenClass[i].TimeTo + " - " + myCurrenClass[i].Days + " )";
                    myCaptions.Add(sCaption);
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
            return myCaptions;


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
                bClass = byte.Parse(Args[4]);

                hdnTerm.Value = ((iStudyYear * 10) + bSemester).ToString();

                decimal dAVG = LibraryMOD.GetClassMarksAVG(iStudyYear, bSemester, bShift, sCourse, bClass, CurrentCampus);
                string sGrade = LibraryMOD.ConvertMarktoGrade(System.Math.Round(dAVG, MidpointRounding.AwayFromZero));

                AvgLBL.Text = "* The Average of Class Marks = " + string.Format("{0:f}", dAVG) + " ( " + sGrade + " )";


            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {


            }

        }
        protected void SaveCMD_Click(object sender, ImageClickEventArgs e)
        {
            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
            {
                //divMsg.InnerText = InitializeModule.MsgEditAuthorization;
                lbl_Msg.Text = InitializeModule.MsgEditAuthorization;
                div_msg.Visible = true;
                return;
            }
            lblEffectedRecords.Text = "step0 ";
            int iMarkYear = (int)Session["MarkYear"];
            byte iMarkSem = byte.Parse(Session["MarkSemester"].ToString());

            if (iMarkYear != iStudyYear || iMarkSem != bSemester)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                InitializeModule.enumPrivilege.ChangeGrades, CurrentRole) != true)
                {
                    //divMsg.InnerText = InitializeModule.MsgChangeGrades;
                    lbl_Msg.Text = InitializeModule.MsgChangeGrades;
                    div_msg.Visible = true;
                    return;
                }
            }

            lblEffectedRecords.Text = "step00 ";
            int iSaved = Save();
            myGradesType.Clear();
            myGradesType = MyGradesTypeDal.GetGradesTypes(CurrentCampus, sCourse, iStudyYear, bSemester);
            DetailCount = myGradesType.Count;
            Session["GradesDCount"] = DetailCount;
            ShowData();

        }

        private int Save()
        {
            string sUpdate = "";
            int HCount, DCount;
            HCount = (int)Session["GradesHCount"];
            DCount = (int)Session["GradesDCount"];
            lblEffectedRecords.Text = "step04";
            int iIndex = 0;
            try
            {
                sUpdate = txtUpdates.Value;
                // lblEffectedRecords.Text = "step05: split values: " + txtUpdates.Value;
                string[] aUpdates = sUpdate.Split(';');
                if (int.Parse(aUpdates[0]) == 0)
                {

                    return 0;
                }
                int iCounts = 0;

                //contain the array count
                iCounts = int.Parse(aUpdates[0]) * (4 + (DCount * 2));


                //After the second cell that contain start
                //(DCount*2) Detail Grdaes + Types
                for (int i = 2; i < iCounts; i += (4 + (DCount * 2)))
                {
                    Grades grd = new Grades();
                    grd.StudyYear = iStudyYear;
                    grd.Semester = bSemester;
                    grd.Shift = bShift;
                    grd.Course = sCourse;
                    grd.bClass = bClass;
                    grd.Stno = aUpdates[i];
                    grd.GradesDatails = new List<GradesTypes>();
                    for (int iDetail = i + 1; iDetail < i + ((DCount * 2) + 1); iDetail += 2)
                    {
                        lblEffectedRecords.Text = "step2 ";
                        GradesTypes grdDetail = new GradesTypes();
                        if (!string.IsNullOrEmpty(aUpdates[iDetail + 1]))
                        {
                            grdDetail.Grade = decimal.Parse(aUpdates[iDetail + 1]);
                        }
                        else
                        {
                            //will not added by the Class
                            if (AllPassedCHK.Checked == true)
                            {
                                grdDetail.Grade = 0;
                            }
                            else
                            {
                                grdDetail.Grade = -1;
                            }
                            if (byte.Parse(aUpdates[iDetail]) == 103)
                            {
                                grdDetail.Grade = 0;
                            }
                        }
                        grdDetail.GradeType = byte.Parse(aUpdates[iDetail]);

                        lblEffectedRecords.Text = "step3 ";
                        grd.GradesDatails.Add(grdDetail);
                    }
                    int iAfter = i + ((DCount * 2) + 1);
                    if (AllPassedCHK.Checked == false)
                    {
                        grd.Mark = decimal.Parse(aUpdates[iAfter]);
                        grd.Grade = aUpdates[iAfter + 1];
                    }
                    else
                    {
                        grd.Mark = 0;
                        grd.Grade = "NC";
                    }
                    grd.DataStatus = int.Parse(aUpdates[iAfter + 2]);

                    //iIndex = Array.FindIndex(myGrades,delegate(Grades G){return G.Stno==grd.Stno;});
                    iIndex = myGrades.FindIndex(delegate (Grades G) { return G.Stno == grd.Stno; });
                    lblEffectedRecords.Text = "step4 ";
                    SetUpdatedGrades(iIndex, grd);
                }

                string sSQLGrades = "";
                sSQLGrades = "SELECT  lngStudentNumber, byteGradeType, curGrade";
                sSQLGrades += " FROM Reg_Grade_Detail";
                sSQLGrades += " WHERE intStudyYear = " + iStudyYear;
                sSQLGrades += " AND byteSemester =" + bSemester;
                sSQLGrades += " AND byteShift = " + bShift;
                sSQLGrades += " AND strCourse ='" + sCourse + "'";
                sSQLGrades += " AND byteClass = " + bClass;

                Connection_StringCLS myConnection_String = new Connection_StringCLS(CurrentCampus);
                string sConn = myConnection_String.Conn_string;
                SqlConnection Conn = new SqlConnection();
                SqlDataAdapter da = new SqlDataAdapter(sSQLGrades, Conn);
                DataSet ds = new DataSet();
                lblEffectedRecords.Text = "step5 ";
                Conn.ConnectionString = sConn;
                Conn.Open();
                da.Fill(ds, "Grades");
                DataView dv = new DataView(ds.Tables["Grades"], "", "", DataViewRowState.OriginalRows);
                int iEffectedRec = 0;
                for (int i = 0; i < myGrades.Count; i++)
                {
                    if (myGrades[i].isDataChanged == 1)
                    {
                        iEffectedRec = myGradesDAL.UpdateGrades(iStudyYear, bSemester, bShift, sCourse, bClass,
                        myGrades[i].Stno, myGrades[i].Mark, myGrades[i].Grade, myGrades[i].Degree,
                        myGrades[i].Major, myGrades[i].FGP, myGrades[i].FGPReady,
                        myGrades[i].GradesDatails, myGrades[i].DataStatus,
                        CurrentCampus, Convert.ToString(Session["CurrentUserName"]),
                        Convert.ToString("" + Session["CurrentNetUserName"]),
                        Convert.ToString("" + Session["CurrentPCName"]));

                        //lblEffectedRecords.Text  = iEffectedRec.ToString() + "details records updated";
                        //===================== Update Grade History ===============
                        int iGradeType = 0;
                        double dblOldGradeValue = 0;
                        double dblNewGradeValue = 0;
                        int k = 0;
                        GradesHistoryDAL myGradesHistoryDAL = new GradesHistoryDAL();
                        for (k = 0; k < myGrades[i].GradesDatails.Count - 1; k++)
                        {
                            iGradeType = Convert.ToInt32(myGrades[i].GradesDatails[k].GradeType);
                            dblNewGradeValue = Convert.ToDouble(myGrades[i].GradesDatails[k].Grade);
                            dv.RowFilter = "lngStudentNumber='" + myGrades[i].Stno + "' AND byteGradeType =" + iGradeType;

                            if (dv.Count > 0)
                            {
                                dblOldGradeValue = Convert.ToDouble("0" + dv[0]["curGrade"]);
                            }
                            else
                            {
                                dblOldGradeValue = 0;
                            }


                            if (dblNewGradeValue != -1 && dblNewGradeValue != dblOldGradeValue ||
                                (dblNewGradeValue >= 0 && dblNewGradeValue != dblOldGradeValue) ||
                                 (dblNewGradeValue == -1 && dblOldGradeValue > 0))
                            {

                                myGradesHistoryDAL.UpdateGradesHistory(InitializeModule.EnumCampus.ECTNew, (int)InitializeModule.enumModes.NewMode,
                                    0, myGrades[i].Stno,
                                    iStudyYear, bSemester, bShift,
                                    sCourse, bClass, iGradeType,
                                    dblOldGradeValue, dblNewGradeValue,
                                     Convert.ToInt32(Session["CurrentUserNo"]),
                                     DateTime.Now, Convert.ToString("" + Session["CurrentPCName"]),
                                     Convert.ToString("" + Session["CurrentNetUserName"]));
                            }
                        }
                        //===================== Enf Updating Grade History ===============
                        //    iStudyYear, bSemester, bShift, sCourse, bClass,
                        //myGrades[i].Stno, myGrades[i].Mark, myGrades[i].Grade, myGrades[i].Degree,
                        //myGrades[i].Major, myGrades[i].FGP, myGrades[i].FGPReady,
                        //myGrades[i].GradesDatails, myGrades[i].DataStatus, CurrentCampus, Convert.ToString(Session["CurrentUserName"]), Convert.ToString("" + Session["CurrentNetUserName"]), Convert.ToString("" + Session["CurrentPCName"]));


                        myGrades[i].DataStatus = 1;
                        myGrades[i].isDataChanged = 0;
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {


            }
            return HCount;

        }

        private void SetUpdatedGrades(int iIndex, Grades myGrade)
        {
            try
            {
                for (int i = 0; i < myGrades[iIndex].GradesDatails.Count; i++)
                {
                    myGrades[iIndex].GradesDatails[i].Grade = myGrade.GradesDatails[i].Grade;
                }
                myGrades[iIndex].Mark = myGrade.Mark;
                myGrades[iIndex].Grade = myGrade.Grade;
                myGrades[iIndex].DataStatus = myGrade.DataStatus;
                myGrades[iIndex].isDataChanged = 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {


            }


        }

        private string getGradesTypesSQL()
        {
            string sGrades = "";

            try
            {

                myGradesType = MyGradesTypeDal.GetGradesTypes(CurrentCampus, sCourse, iStudyYear, bSemester);

                for (int i = 0; i < myGradesType.Count; i++)
                {
                    sGrades += "MAX(CASE byteGradeType WHEN " + myGradesType[i].GradeType + " THEN curGrade  ELSE NULL END) AS [" + myGradesType[i].GradeDesc + "],";
                }

            }


            catch (Exception e)
            {
                sGrades = "";
                Console.WriteLine("{0} Exception caught.", e);
                //divMsg.InnerText = e.Message;
                lbl_Msg.Text = e.Message;
                div_msg.Visible = true;
            }
            finally
            {
                myGradesType.Clear();
            }
            return sGrades;
        }

        private string GetSQLQuery()
        {
            string sSQL = "";
            try
            {
                sSQL = "SELECT lngStudentNumber AS No, Name,";
                sSQL += getGradesTypesSQL();
                sSQL += "curUseMark AS Mark, strGrade as Grade";
                sSQL += " FROM GD_Dis";
                sSQL += " WHERE intStudyYear=" + iStudyYear;
                sSQL += " AND byteSemester=" + bSemester;
                sSQL += " AND byteShift=" + bShift;
                sSQL += " AND strCourse='" + sCourse + "'";
                sSQL += " AND byteClass=" + bClass;
                sSQL += " GROUP BY lngStudentNumber, Name, curUseMark, strGrade";
                sSQL += " Order by Name";



            }
            catch (Exception e)
            {
                sSQL = "";
                Console.WriteLine("{0} Exception caught.", e);
                //divMsg.InnerText = e.Message;
                lbl_Msg.Text = e.Message;
                div_msg.Visible = true;
            }
            finally
            {

            }
            return sSQL;

        }

        private void Retrieve(bool isToExcel)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(CurrentCampus);
            string sConn = myConnection_String.Conn_string;
            SqlConnection Conn = new SqlConnection();
            string sSQL = "";
            try
            {
                Conn.ConnectionString = sConn;
                Conn.Open();
                sSQL = GetSQLQuery();
                SqlCommand Cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader Rd = Cmd.ExecuteReader();

                int r = 0;

                if (isToExcel)
                {
                    r = TransferToExcel(Rd);
                }
                else
                {

                }
                Rd.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                //divMsg.InnerText = e.Message;
                lbl_Msg.Text = e.Message;
                div_msg.Visible = true;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }

        private int TransferToExcel(SqlDataReader rd)
        {
            int r = 0;
            try
            {
                //toExcel.toExcel MyExcel = new toExcel.toExcel();
                //r = MyExcel.Transfer(rd, "Class Grades", 2);
                XLS myXLS = new XLS();
                string sMsg = myXLS.Transfer(rd, "Class Grades", 2);
                //divMsg.InnerText = sMsg;
                lbl_Msg.Text = sMsg;
                div_msg.Visible = true;
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

            return r;
        }
        protected void BackCMD_Click(object sender, ImageClickEventArgs e)
        {
            switch (GradeDMType)
            {
                case InitializeModule.EnumGradeDMType.Entry:
                    Response.Redirect("GradesEntry.aspx");
                    break;
                case InitializeModule.EnumGradeDMType.View:
                    Response.Redirect("GradesView.aspx");
                    break;
            }

        }
        protected void ToExcelCMD_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                switch (GradeDMType)
                {
                    case InitializeModule.EnumGradeDMType.Entry:

                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                        InitializeModule.enumPrivilege.TransferToExcel, CurrentRole) != true)
                        {
                            //divMsg.InnerText = InitializeModule.MsgPrintAuthorization;
                            lbl_Msg.Text = InitializeModule.MsgPrintAuthorization;
                            div_msg.Visible = true;
                            return;
                        }
                        break;

                    case InitializeModule.EnumGradeDMType.View:

                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesView,
                        InitializeModule.enumPrivilege.TransferToExcel, CurrentRole) != true)
                        {
                            //divMsg.InnerText = InitializeModule.MsgPrintAuthorization;
                            lbl_Msg.Text = InitializeModule.MsgPrintAuthorization;
                            div_msg.Visible = true;
                            return;
                        }
                        break;

                }

                int rptType = int.Parse(rptTypeCBO.SelectedValue);

                Export(InitializeModule.ECT_Buttons.ToExcel, rptType);


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }
        }
        protected void ReportCMD_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                switch (GradeDMType)
                {
                    case InitializeModule.EnumGradeDMType.Entry:

                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                        InitializeModule.enumPrivilege.Print, CurrentRole) != true)
                        {
                            //divMsg.InnerText = InitializeModule.MsgPrintAuthorization;
                            lbl_Msg.Text = InitializeModule.MsgPrintAuthorization;
                            div_msg.Visible = true;
                            return;
                        }
                        break;

                    case InitializeModule.EnumGradeDMType.View:

                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesView,
                        InitializeModule.enumPrivilege.Print, CurrentRole) != true)
                        {
                            //divMsg.InnerText = InitializeModule.MsgPrintAuthorization;
                            lbl_Msg.Text = InitializeModule.MsgPrintAuthorization;
                            div_msg.Visible = true;
                            return;
                        }
                        break;

                }
                int rptType = int.Parse(rptTypeCBO.SelectedValue);

                Export(InitializeModule.ECT_Buttons.Print, rptType);


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }

        }

        private DataSet Prepare_Report(int rptType)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            try
            {
                DataColumn SerialCol = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dt.Columns.Add(SerialCol);
                DataColumn NoCol = new DataColumn("sNo", Type.GetType("System.String"));
                dt.Columns.Add(NoCol);
                DataColumn NameCol = new DataColumn("sName", Type.GetType("System.String"));
                dt.Columns.Add(NameCol);
                DataColumn EmailCol = new DataColumn("sEmail", Type.GetType("System.String"));
                dt.Columns.Add(EmailCol);

                myGradesType = MyGradesTypeDal.GetGradesTypes(CurrentCampus, sCourse, iStudyYear, bSemester);

                for (int i = 0; i < myGradesType.Count; i++)
                {
                    DataColumn Col = new DataColumn("Detail" + i, Type.GetType("System.String"));
                    dt.Columns.Add(Col);
                }

                DataColumn MarkCol = new DataColumn("sMark", Type.GetType("System.String"));
                dt.Columns.Add(MarkCol);
                DataColumn GradeCol = new DataColumn("sGrade", Type.GetType("System.String"));
                dt.Columns.Add(GradeCol);

                for (int i = 0; i < myGrades.Count; i++)
                {
                    dr = dt.NewRow();
                    dr["iSerial"] = (i + 1);
                    dr["sNo"] = myGrades[i].Stno;
                    dr["sName"] = myGrades[i].SName;
                    dr["sEmail"] = myGrades[i].SEmail;

                    if (rptType == 0)
                    {
                        for (int j = 0; j < myGradesType.Count; j++)
                        {

                            if (myGrades[i].GradesDatails[j].Grade >= 0)
                            {

                                dr["Detail" + j] = string.Format("{0:F2}", myGrades[i].GradesDatails[j].Grade);
                            }
                            else
                            {
                                dr["Detail" + j] = "";
                            }
                        }
                    }
                    dr["sMark"] = string.Format("{0:F2}", myGrades[i].Mark);
                    if (rptType == 1)//Without Names Must Hide Students with Fainancial Problem
                    {
                        if (myGrades[i].IsHidden == true)
                        {
                            dr["sGrade"] = "*";
                        }
                        else
                        {
                            dr["sGrade"] = myGrades[i].Grade;
                        }
                    }
                    else
                    {
                        dr["sGrade"] = myGrades[i].Grade;
                    }

                    dt.Rows.Add(dr);

                }

                dt.TableName = "datatable1";
                dt.AcceptChanges();
                ds.Tables.Add(dt);


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                myGradesType.Clear();

            }
            return ds;
        }
        private DataSet Prepare_AllSectionsMarksReport()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            try
            {
                DataColumn SerialCol = new DataColumn("iSerial", Type.GetType("System.Int32"));
                dt.Columns.Add(SerialCol);
                DataColumn NoCol = new DataColumn("sNo", Type.GetType("System.String"));
                dt.Columns.Add(NoCol);
                DataColumn NameCol = new DataColumn("sName", Type.GetType("System.String"));
                dt.Columns.Add(NameCol);
                DataColumn EmailCol = new DataColumn("sEmail", Type.GetType("System.String"));
                dt.Columns.Add(EmailCol);

                myGradesType = MyGradesTypeDal.GetGradesTypes(CurrentCampus, sCourse, iStudyYear, bSemester, false);
                int iGradesCount = myGradesType.Count;

                for (int i = 0; i < myGradesType.Count; i++)
                {
                    DataColumn Col = new DataColumn("Detail" + i, Type.GetType("System.String"));
                    dt.Columns.Add(Col);
                }

                //DataColumn MarkCol = new DataColumn("sMark", Type.GetType("System.String"));
                //dt.Columns.Add(MarkCol);
                //DataColumn GradeCol = new DataColumn("sGrade", Type.GetType("System.String"));
                //dt.Columns.Add(GradeCol);

                List<Grades> mySectionsGrades = new List<Grades>();

                //Get All Course codes
                CoursesDAL myCoursesDAL = new CoursesDAL();

                DataView dvCoursesCodes = myCoursesDAL.GetCourseCodes(InitializeModule.EnumCampus.Males, sCourse);
                string sCourseCode = "";

                int iLecturer = 0;
                iLecturer = Convert.ToInt32("0" + Session["CurrentLecturer"].ToString());

                int iCourseLeader = LibraryMOD.GetCourseLeader(iStudyYear, bSemester, myCoursesDAL.GetUnifiedCourseCode(sCourse));

                if (iCourseLeader == iLecturer) //current lecturer is the course leader
                {
                    iLecturer = 0;
                }

                for (int i = 0; i < dvCoursesCodes.Count; i++)
                {
                    sCourseCode = dvCoursesCodes[i][0].ToString();
                    //Females
                    iLecturer = LibraryMOD.GetLecturerFemaleID(iLecturer);

                    mySectionsGrades.AddRange(myGradesDAL.GetGrades(InitializeModule.EnumCampus.Females, iStudyYear, bSemester, 0, sCourseCode, "0", iGradesCount, false, "", iLecturer, false));
                    //Males

                    iLecturer = LibraryMOD.GetLecturerMaleID(iLecturer);
                    mySectionsGrades.AddRange(myGradesDAL.GetGrades(InitializeModule.EnumCampus.Males, iStudyYear, bSemester, 0, sCourseCode, "0", iGradesCount, false, "", iLecturer, false));
                }


                for (int i = 0; i < mySectionsGrades.Count; i++)
                {
                    dr = dt.NewRow();
                    dr["iSerial"] = (i + 1);
                    //dr["sNo"] = mySectionsGrades[i].Stno;
                    //dr["sName"] = mySectionsGrades[i].SName;
                    dr["sEmail"] = mySectionsGrades[i].SEmail;

                    for (int j = 0; j < myGradesType.Count; j++)
                    {
                        if (mySectionsGrades[i].GradesDatails[j].Grade >= 0)
                        {
                            dr["Detail" + j] = string.Format("{0:F2}", mySectionsGrades[i].GradesDatails[j].Grade);
                        }
                        else
                        {
                            dr["Detail" + j] = "";
                        }
                    }
                    //dr["sMark"] = string.Format("{0:F2}", mySectionsGrades[i].Mark);
                    //dr["sGrade"] = mySectionsGrades[i].Grade;
                    dt.Rows.Add(dr);
                }
                dt.TableName = "datatable1";
                dt.AcceptChanges();
                ds.Tables.Add(dt);
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                myGradesType.Clear();

            }
            return ds;
        }
        private void ShowGradesReport(InitializeModule.ECT_Buttons iExport, int rptType)
        {
            ReportDocument myReport = new ReportDocument();
            List<string> sCaptions = new List<string>();
            try
            {

                DataSet rptDS = new DataSet();

                rptDS = Prepare_Report(rptType);

                string reportPath = Server.MapPath("Reports/GrdRPT.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);

                TextObject txt;
                int iLeft = 0;
                int iWidth = 0;
                switch (rptType)
                {
                    case 0:
                        myGradesType = MyGradesTypeDal.GetGradesTypes(CurrentCampus, sCourse, iStudyYear, bSemester);
                        int iMax = 0;

                        for (int i = 0; i < myGradesType.Count; i++)
                        {
                            myReport.ReportDefinition.ReportObjects["txtD" + i].ObjectFormat.EnableSuppress = false;
                            txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtD" + i];
                            txt.Text = myGradesType[i].GradeDesc;

                            //iMax = i+1;
                        }
                        myReport.ReportDefinition.ReportObjects["AVGtxt"].ObjectFormat.EnableSuppress = false;
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["AVGtxt"];
                        txt.Text = AvgLBL.Text;


                        //for (int i = iMax; i < 15; i++){

                        //    //if (i > 5)
                        //    //{
                        //        myReport.ReportDefinition.ReportObjects["txtD" + i].ObjectFormat.EnableSuppress = true;
                        //    //}
                        //    //myReport.ReportDefinition.ReportObjects["fldD" + i].ObjectFormat.EnableSuppress = true;
                        //}
                        myGradesType.Clear();
                        break;
                    case 1:
                        //for (int i = 0; i <15; i++)
                        //{
                        //    //if (i > 5)
                        //    //{
                        //        myReport.ReportDefinition.ReportObjects["txtD" + i].ObjectFormat.EnableSuppress = true;
                        //    //}//myReport.ReportDefinition.ReportObjects["fldD" + i].ObjectFormat.EnableSuppress = true;
                        //}
                        //myReport.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                        iLeft = myReport.ReportDefinition.ReportObjects["txtName"].Left;
                        myReport.ReportDefinition.ReportObjects["txtName"].ObjectFormat.EnableSuppress = true;
                        myReport.ReportDefinition.ReportObjects["fldName"].ObjectFormat.EnableSuppress = true;
                        myReport.ReportDefinition.ReportObjects["txtMark"].ObjectFormat.EnableSuppress = true;
                        myReport.ReportDefinition.ReportObjects["fldMark"].ObjectFormat.EnableSuppress = true;
                        myReport.ReportDefinition.ReportObjects["txtGrade"].Left = iLeft;
                        myReport.ReportDefinition.ReportObjects["fldGrade"].Left = iLeft;

                        myReport.ReportDefinition.ReportObjects["AVGtxt"].ObjectFormat.EnableSuppress = true;
                        break;
                    case 2:


                        iLeft = myReport.ReportDefinition.ReportObjects["txtD0"].Left;
                        iWidth = myReport.ReportDefinition.ReportObjects["txtMark"].Width;
                        //for (int i = 0; i < 15; i++)
                        //{
                        //    //if (i > 5)
                        //    //{
                        //        myReport.ReportDefinition.ReportObjects["txtD" + i].ObjectFormat.EnableSuppress = true;
                        //    //}//myReport.ReportDefinition.ReportObjects["fldD" + i].ObjectFormat.EnableSuppress = true;
                        //}

                        myReport.ReportDefinition.ReportObjects["txtMark"].Left = iLeft;
                        myReport.ReportDefinition.ReportObjects["fldMark"].Left = iLeft; ;
                        myReport.ReportDefinition.ReportObjects["txtGrade"].Left = iLeft + iWidth;
                        myReport.ReportDefinition.ReportObjects["fldGrade"].Left = iLeft + iWidth;

                        iWidth = myReport.ReportDefinition.ReportObjects["txtGrade"].Width;
                        iLeft = myReport.ReportDefinition.ReportObjects["txtGrade"].Left;
                        iWidth += iLeft;
                        myReport.ReportDefinition.ReportObjects["AVGtxt"].ObjectFormat.EnableSuppress = false;
                        myReport.ReportDefinition.ReportObjects["AVGtxt"].Width = iWidth;
                        myReport.ReportDefinition.ReportObjects["AVGtxt"].Left = 0;
                        txt = (TextObject)myReport.ReportDefinition.ReportObjects["AVGtxt"];
                        txt.Text = AvgLBL.Text;
                        break;


                }


                sCaptions = CreateCaption();
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];
                sTitle = sCaptions[0];

                txt.Text = sTitle;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtYear"];
                txt.Text = GetYearHeader();

                for (int i = 1; i < sCaptions.Count; i++)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["DetailTXT" + i];
                    sTitle = sCaptions[i];
                    txt.Text = sTitle;

                }

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Lectxt"];
                txt.Text = sLecturer;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                txt.Text = sUserName;

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
            }
            finally
            {
                myGradesType.Clear();
                myReport.Close();
                myReport.Dispose();
                sCaptions.Clear();
            }
        }
        private void ExportAllSectionsMarkstoLMS()
        {
            ReportDocument myReport = new ReportDocument();
            List<string> sCaptions = new List<string>();
            try
            {
                DataSet rptDS = new DataSet();
                rptDS = Prepare_AllSectionsMarksReport();
                string reportPath = Server.MapPath("Reports/GrdRPT.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);

                TextObject txt;

                myGradesType = MyGradesTypeDal.GetGradesTypes(CurrentCampus, sCourse, iStudyYear, bSemester, false);

                for (int i = 0; i < myGradesType.Count; i++)
                {
                    myReport.ReportDefinition.ReportObjects["txtD" + i].ObjectFormat.EnableSuppress = false;
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtD" + i];
                    txt.Text = myGradesType[i].GradeDesc;
                }

                myGradesType.Clear();

                myReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Page.Response, true, "Exportto_LMS_" + sCourse + "_" + LibraryMOD.GetSemesterString(bSemester) + iStudyYear);

            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {
                myGradesType.Clear();
                myReport.Close();
                myReport.Dispose();
                sCaptions.Clear();
            }
        }
        private void ShowGradesStatistcs(InitializeModule.ECT_Buttons iExport)
        {
            ReportDocument myReport = new ReportDocument();
            List<string> sCaptions = new List<string>();
            try
            {

                string reportPath = Server.MapPath("Reports/GradesDistribution.rpt");
                myReport.Load(reportPath);
                DataSet ds = Prepare_Statistics();

                myReport.SetDataSource(ds);

                TextObject txt;

                sCaptions = CreateCaption();
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];
                sTitle = sCaptions[0];
                txt.Text = sTitle;

                for (int i = 1; i < sCaptions.Count; i++)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["DetailTXT" + i];
                    sTitle = sCaptions[i];
                    txt.Text = sTitle;

                }

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Lectxt"];
                txt.Text = sLecturer;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                txt.Text = sUserName;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtGradesAverage"];
                txt.Text = AvgLBL.Text;

                //Session["CurrentReport"] = myReport;
                //Response.Redirect("RPTViewer.aspx");

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
            }
            finally
            {
                myReport.Close();
                myReport.Dispose();
                sCaptions.Clear();
            }
        }

        private DataSet Prepare_Statistics()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            DataSet ds = new DataSet();
            Connection_StringCLS myConnection_String = new Connection_StringCLS(CurrentCampus);
            SqlConnection Conn = new SqlConnection(myConnection_String.Conn_string);
            Conn.Open();
            try
            {
                DataColumn CourseCol = new DataColumn("sCourse", Type.GetType("System.String"));
                dt.Columns.Add(CourseCol);
                DataColumn sStudentNoCol = new DataColumn("sStudentNo", Type.GetType("System.String"));
                dt.Columns.Add(sStudentNoCol);
                DataColumn GradeCol = new DataColumn("sGrade", Type.GetType("System.String"));
                dt.Columns.Add(GradeCol);

                DataColumn OrderCol = new DataColumn("iOrder", Type.GetType("System.Int32"));
                dt.Columns.Add(OrderCol);

                string sSQL = "SELECT GH.strCourse, GH.lngStudentNumber, GH.strGrade, GS.byteOrder AS iOrder";
                sSQL += " FROM dbo.Reg_Grade_Header AS GH INNER JOIN dbo.Reg_Grade_System AS GS ON GH.strGrade = GS.strGrade";
                sSQL += " Where GH.intStudyYear = " + iStudyYear + " and";
                sSQL += " GH.byteSemester = " + bSemester + " and";
                sSQL += " GH.strCourse = '" + sCourse + "' and";
                sSQL += " GH.byteClass = " + bClass + " and";
                sSQL += " GH.byteShift = " + bShift;
                sSQL += " Order By GS.byteOrder";

                SqlCommand cmd = new SqlCommand(sSQL, Conn);
                SqlDataReader rd = cmd.ExecuteReader();
                int iOrder = 0;
                string sOrder = "";
                while (rd.Read())
                {
                    dr = dt.NewRow();

                    dr["sCourse"] = rd["strCourse"].ToString();
                    dr["sStudentNo"] = rd["lngStudentNumber"].ToString();
                    iOrder = Convert.ToInt32(rd["iOrder"]);
                    sOrder = iOrder.ToString() + " ( " + rd["strGrade"].ToString() + " )";
                    // dr["sGrade"] = sOrder;
                    dr["sGrade"] = rd["strGrade"].ToString();

                    dr["iOrder"] = iOrder;
                    dt.Rows.Add(dr);

                }

                dt.TableName = "Grades";
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

        private int GetGradeSystem()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(CurrentCampus);
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

        //private void Enable_Disable(bool isEnabled)
        //{
        //    try
        //    {
        //        PrintCMD.ImageUrl = LibraryMOD.GetButtonImageURL(InitializeModule.ECT_Buttons.Print, isEnabled);
        //        toExcelCMD.ImageUrl = LibraryMOD.GetButtonImageURL(InitializeModule.ECT_Buttons.ToExcel, isEnabled);
        //        toWordCMD.ImageUrl = LibraryMOD.GetButtonImageURL(InitializeModule.ECT_Buttons.ToWord, isEnabled);
        //        PrintCMD.Enabled = isEnabled;
        //        toExcelCMD.Enabled = isEnabled;
        //        toWordCMD.Enabled = isEnabled;
        //    }
        //    catch (Exception exp)
        //    {
        //        Console.WriteLine("{0} Exception caught.", exp);
        //        divMsg.InnerText = exp.Message;
        //    }
        //    finally
        //    {

        //    }
        //}

        private void Export(InitializeModule.ECT_Buttons iExport, int iReport)
        {
            ReportDocument myReport = new ReportDocument();

            try
            {
                switch (iReport)
                {
                    case 0:
                    case 2:
                        ShowGradesReport(iExport, iReport);
                        break;
                    case 1:
                        ShowBoardReport(iExport);
                        break;
                    case 3:
                        ShowGradesStatistcs(iExport);
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

            }
        }


        protected void ToWordCMD_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                switch (GradeDMType)
                {
                    case InitializeModule.EnumGradeDMType.Entry:

                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                        InitializeModule.enumPrivilege.TransferToWord, CurrentRole) != true)
                        {
                            //divMsg.InnerText = InitializeModule.MsgPrintAuthorization;
                            lbl_Msg.Text = InitializeModule.MsgPrintAuthorization;
                            div_msg.Visible = true;
                            return;
                        }
                        break;

                    case InitializeModule.EnumGradeDMType.View:

                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesView,
                        InitializeModule.enumPrivilege.TransferToWord, CurrentRole) != true)
                        {
                            //divMsg.InnerText = InitializeModule.MsgPrintAuthorization;
                            lbl_Msg.Text = InitializeModule.MsgPrintAuthorization;
                            div_msg.Visible = true;
                            return;
                        }
                        break;

                }

                int rptType = int.Parse(rptTypeCBO.SelectedValue);

                Export(InitializeModule.ECT_Buttons.ToWord, rptType);


            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }
        }

        private void ShowBoardReport(InitializeModule.ECT_Buttons iExport)
        {
            ReportDocument myReport = new ReportDocument();
            List<string> sCaptions = new List<string>();
            try
            {

                DataSet rptDS = new DataSet();

                rptDS = Prepare_Report(1);

                string reportPath = Server.MapPath("Reports/Grd_BoardRPT.rpt");
                myReport.Load(reportPath);
                myReport.SetDataSource(rptDS);

                TextObject txt;

                sCaptions = CreateCaption();
                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtTitle"];
                sTitle = sCaptions[0];
                txt.Text = sTitle;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["txtYear"];
                int iTerm = LibraryMOD.GetCurrentTerm();
                txt.Text = GetYearHeader();

                for (int i = 1; i < sCaptions.Count; i++)
                {
                    txt = (TextObject)myReport.ReportDefinition.ReportObjects["DetailTXT" + i];
                    sTitle = sCaptions[i];
                    txt.Text = sTitle;

                }

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["Lectxt"];
                txt.Text = sLecturer;

                txt = (TextObject)myReport.ReportDefinition.ReportObjects["UserTXT"];
                txt.Text = sUserName;

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
            }
            finally
            {
                myReport.Close();
                myReport.Dispose();
                sCaptions.Clear();
            }
        }
        private string GetYearHeader()
        {
            string sHeader = "";
            try
            {
                int iYear, iSem = 0;
                iYear = iStudyYear;
                string sSem = bSemester.ToString();
                iSem = int.Parse(sSem);
                sSem = LibraryMOD.GetSemesterString(iSem);
                sHeader = iYear.ToString() + "/" + (iYear + 1).ToString() + " - " + sSem;
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }
            return sHeader;
        }
        private string GetCookie(string sCookie)
        {
            string sValue = "";
            if (Request.Cookies[sCookie.ToLower()] != null)
            {
                HttpCookie aCookie = Request.Cookies[sCookie.ToLower()];
                sValue = Server.HtmlEncode(aCookie.Value.ToLower());
            }
            return sValue;
        }
        protected void txtUpdates_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void lnkbtnExportAllSectionsMarks_Click(object sender, EventArgs e)
        {

            if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesEntry,
                   InitializeModule.enumPrivilege.TransferToExcel, CurrentRole) != true)
            {
                //divMsg.InnerText = InitializeModule.MsgPrintAuthorization;
                lbl_Msg.Text = InitializeModule.MsgPrintAuthorization;
                div_msg.Visible = true;
                return;
            }

            switch (GradeDMType)
            {
                case InitializeModule.EnumGradeDMType.Entry:
                    ExportAllSectionsMarkstoLMS();
                    break;
                case InitializeModule.EnumGradeDMType.View:

                    break;
                default:
                    break;
            }


        }
    }
}