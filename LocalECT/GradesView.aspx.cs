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

namespace LocalECT
{
    public partial class GradesView : System.Web.UI.Page
    {
        InitializeModule.EnumCampus CurrentCampus = InitializeModule.EnumCampus.Males;

        int iStudyYear = 0;
        byte bSemester = 0;
        byte bShift = 0;
        string sCourse = "";
        byte bClass = 0;
        int iLecturer = 0;
        int CurrentRole = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Security
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesView,
                InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                {
                    Server.Transfer("Authorization.aspx");

                }
            }

            iLecturer = (int)Session["CurrentLecturer"];


            if (!IsPostBack)
            {
                //Session["CurrentYear"] = null;
                //Session["CurrentSemester"] = null;
                CurrentCampus = InitializeModule.EnumCampus.Females;//(InitializeModule.EnumCampus)Session["CurrentCampus"];
                FillTerms();
                Fill_lecturers();
                Fill_Campus();
                CampusCBO.SelectedValue = ((int)CurrentCampus).ToString();
            }
            else
            {
                Session["CurrentLecturerName"] = LecturersCBO.SelectedItem.Text;
                CurrentCampus = (InitializeModule.EnumCampus)int.Parse(CampusCBO.SelectedValue);
            }

            //divDetail.Controls.Add(MyTable);
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
        private void Fill_lecturers()
        {

            List<ECTNewLecturers> MyLecturers = new List<ECTNewLecturers>();
            ECTNewLecturersDAL MyLecturersDAL = new ECTNewLecturersDAL();
            try
            {
                bool isAllLecturerShown = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesView,
                                          InitializeModule.enumPrivilege.ShowAllLecturer, CurrentRole);
                bool isUnitLecturerShown = LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_GradesView,
                                           InitializeModule.enumPrivilege.ShowUnitLecturer, CurrentRole);

                string sCondition = "";
                bool isDefaultIncluded = true;
                LecturersCBO.Items.Clear();
                //default Admin Condition
                sCondition = " Where IsActive=1";
                if (!isAllLecturerShown)//Admin & Deans
                {
                    if (isUnitLecturerShown)
                    {
                        //Coordinators
                        sCondition += " AND CollegeID=" + MyLecturersDAL.GetLecturerCollege(iLecturer, InitializeModule.EnumCampus.ECTNew);
                    }
                    else
                    {
                        //Faculty
                        isDefaultIncluded = false;
                        sCondition += " And LecturerID=" + iLecturer;
                    }
                }

                MyLecturers = MyLecturersDAL.GetList(InitializeModule.EnumCampus.ECTNew, sCondition, isDefaultIncluded);
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
            Session["GradesArgs"] = e.CommandArgument.ToString();
            Session["OpenGradesType"] = InitializeModule.EnumGradeDMType.View;

            string sData = "";
            sData = "GradesDM.aspx?Campus=" + int.Parse(CampusCBO.SelectedValue).ToString();
            sData += "&Term=" + Terms.SelectedValue.ToString();


            Response.Redirect(sData);

        }
        //protected void RunCMD_Click(object sender, ImageClickEventArgs e)
        //{
        //    Session["CurrentYear"] =int.Parse( Terms.SelectedValue.ToString().Substring(0, 4));
        //    Session["CurrentSemester"] =byte.Parse( Terms.SelectedValue.ToString().Substring(4, 1));

        //    //ClassesGRD.DataSourceID = "ClassesDS";
        //    ClassesGRD.DataBind();
        //}
        protected void Terms_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CurrentYear"] = int.Parse(Terms.SelectedValue.ToString().Substring(0, 4));
            Session["CurrentSemester"] = byte.Parse(Terms.SelectedValue.ToString().Substring(4, 1));

            //ClassesGRD.DataSourceID = "ClassesDS";
            ClassesGRD.DataBind();
        }
    }
}