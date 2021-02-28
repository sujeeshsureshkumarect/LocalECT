using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace LocalECT
{
    public partial class Track_Classes : System.Web.UI.Page
    {
        InitializeModule.EnumCampus CurrentCampus = InitializeModule.EnumCampus.Males;

        int iStudyYear = 0;
        byte bSemester = 0;
        byte bShift = 0;
        string sCourse = "";
        byte bAttClass = 0;
        int iLecturer = 0;
        int CurrentRole = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Security
            //int CurrentRole = 0;
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Track_Classes,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");

                    }
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Track_Classes,
                    InitializeModule.enumPrivilege.ShowAllLecturer, CurrentRole) == true)
                    {
                        Term_ddl.Enabled = true;
                        Session["CurrentLecturer"] = 0;

                    }

                }
            }
            else
            {
                Server.Transfer("Login.aspx");
            }

            iLecturer = (int)Session["CurrentLecturer"];

            if (!IsPostBack)
            {
                //CurrentCampus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                CurrentCampus = InitializeModule.EnumCampus.Females;
                FillTerms();
                Fill_lecturers();
                Fill_Campus();
                CampusCBO.SelectedValue = ((int)CurrentCampus).ToString();
                //Session["AttendanceTable"] = null;
                Session["AttendanceArgs"] = null;
            }
            else
            {
                CurrentCampus = (InitializeModule.EnumCampus)int.Parse(CampusCBO.SelectedValue);
            }

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
                    Term_ddl.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));

                }
                int iYear = (int)Session["CurrentYear"];
                int iSem = (int)Session["CurrentSemester"];
                int iTerm = iYear * 10 + iSem;
                Term_ddl.SelectedValue = iTerm.ToString();
                ClassesDS.SelectParameters["iYear"].DefaultValue = iYear.ToString();
                ClassesDS.SelectParameters["bSemester"].DefaultValue = iSem.ToString();

                ClassesDS.DataBind();
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

        private void Fill_lecturers()
        {

            List<ECTNewLecturers> MyLecturers = new List<ECTNewLecturers>();
            ECTNewLecturersDAL MyLecturersDAL = new ECTNewLecturersDAL();
            string sCondition = " Where IsActive=1";
            bool isDefaultIncleded = true;
            try
            {
                LecturersCBO.Items.Clear();
                if (iLecturer > 0)
                {
                    sCondition += " And LecturerID=" + iLecturer;
                    isDefaultIncleded = false;

                }

                MyLecturers = MyLecturersDAL.GetList(InitializeModule.EnumCampus.ECTNew, sCondition, isDefaultIncleded);

                for (int i = 0; i < MyLecturers.Count; i++)
                {
                    ListItem lst = new ListItem(MyLecturers[i].LecturerNameEn, MyLecturers[i].LecturerID.ToString());
                    LecturersCBO.Items.Add(lst);
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                MyLecturers.Clear();

            }

        }

        private void Fill_Campus()
        {

            List<LookupDetails> MyLookup = new List<LookupDetails>();
            LookupDetailsDAL MyLookupDAL = new LookupDetailsDAL();
            try
            {
                CampusCBO.Items.Clear();
                MyLookup = MyLookupDAL.GetLookupDetails(InitializeModule.EnumCampus.ECTNew, " And MinorID<3", false, "", InitializeModule.enumLookupType.Campus);

                for (int i = 0; i < MyLookup.Count; i++)
                {
                    ListItem lst = new ListItem(MyLookup[i].DescEn, MyLookup[i].MinorID.ToString());
                    CampusCBO.Items.Add(lst);
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {
                MyLookup.Clear();

            }

        }


        protected void SelectBTN_Command(object sender, CommandEventArgs e)
        {
            string sArgs = "";

            //Session["AttendanceArgs"] = e.CommandArgument.ToString();
            sArgs = SetArgs(e.CommandArgument.ToString());
            Session["CurrentLecturer"] = Convert.ToInt32(LecturersCBO.SelectedValue);
            Response.Redirect("Track_Students.aspx?Campus=" + int.Parse(CampusCBO.SelectedValue).ToString() + sArgs);

        }

        private string SetArgs(string sArgs)
        {
            string sSTR = "";
            try
            {
                string[] Args = sArgs.Split(';');

                sSTR = "&iStudyYear=" + Args[0];
                sSTR += "&bSemester=" + Args[1];
                sSTR += "&bShift=" + Args[2];
                sSTR += "&sCourse=" + Args[3];
                sSTR += "&bClass=" + Args[4];

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {


            }
            return sSTR;

        }

        protected void Term_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sYear = Term_ddl.SelectedValue.ToString().Substring(0, 4);
            string sSem = Term_ddl.SelectedValue.ToString().Substring(4, 1);

            ClassesDS.SelectParameters["iYear"].DefaultValue = sYear;
            ClassesDS.SelectParameters["bSemester"].DefaultValue = sSem;

            ClassesDS.DataBind();

        }
    }
}