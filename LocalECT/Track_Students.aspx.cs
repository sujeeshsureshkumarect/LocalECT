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
using System.Collections.Generic;

namespace LocalECT
{
    public partial class Track_Students : System.Web.UI.Page
    {
        InitializeModule.EnumCampus CurrentCampus = InitializeModule.EnumCampus.Males;
        int iCurrentCampus = 0;
        //int iCurrentLecturer = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //iCurrentLecturer = (int)Session["CurrentLecturer"];
            iCurrentCampus = int.Parse(Request.QueryString["Campus"]);
            CurrentCampus = (InitializeModule.EnumCampus)iCurrentCampus;
            if (!IsPostBack)
            {

                int CurrentLecturer = int.Parse(Session["CurrentLecturer"].ToString());
                Lecturer.Value = GetCampusLecturer(CurrentLecturer, CurrentCampus).ToString();

            }

            Connection_StringCLS ConnectionString = new Connection_StringCLS(CurrentCampus);
            string sConn = ConnectionString.Conn_string;

            Class_DS.ConnectionString = sConn;
            Timing_ds.ConnectionString = sConn;
            StudentsDS.ConnectionString = sConn;
            Student_DS2.ConnectionString = sConn;
            Topic_DS.ConnectionString = sConn;
            Track_DS.ConnectionString = sConn;
            Insert_DS.ConnectionString = sConn;
            Date_FLD.Value = LibraryMOD.GetUniversalDate(string.Format("{0:dd/MM/yyyy}", DateTime.Today.Date));
            //Response.Write(Date_FLD.Value);

        }


        protected void StudentsGRD_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }
        protected void Back_LNK_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Add_LNK_Click(object sender, EventArgs e)
        {
            Student_TXT.Text = StudentsGRD.SelectedValue.ToString();
            MultiView1.ActiveViewIndex = 2;
        }

        protected void Edit_LNK_Command(object sender, CommandEventArgs e)
        {
            SetArgs(e.CommandArgument.ToString());
            MultiView1.ActiveViewIndex = 3;
        }

        private void SetArgs(string sArgs)
        {

            try
            {
                string[] Args = sArgs.Split(';');

                GradeType.Value = Args[0];
                TrackDegree.Value = Args[1];
                TrackType.Value = Args[2];
                Note_TXT.Text = Args[3];

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex.Message);
            }
            finally
            {


            }

        }

        protected void Update_LNK_Click(object sender, EventArgs e)
        {
            //InitializeModule.EnumCampus Campus;
            //int iPeriod = 0;
            //string sPeriod = PeriodCBO.SelectedValue;
            //Campus = LibraryMOD.SyncCampusAndSession(sPeriod, out iPeriod);

            Connection_StringCLS myConnection_String = new Connection_StringCLS(CurrentCampus);

            string sConn = myConnection_String.Conn_string;

            TrackEditDS.ConnectionString = sConn;
            int iEffected = TrackEditDS.Update();
            if (iEffected > 0)
            {
                divMsg.InnerText = "Data Updated Successfully ...";
                Track_GRD.DataBind();
            }
            else
            {
                divMsg.InnerText = "Error : No Record Effected.";
            }
            MultiView1.ActiveViewIndex = 1;
        }
        protected void Undo_LNK_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }


        protected void SaveCMD_Click(object sender, EventArgs e)
        {
            try
            {
                int i = Insert_DS.Insert();
                MultiView1.ActiveViewIndex = 1;
                Track_GRD.DataBind();

            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                divMsg.InnerText = ex.Message;
            }
            finally
            {

            }

        }

        private int GetCampusLecturer(int iLecturer, InitializeModule.EnumCampus Campus)
        {
            int iResult = 0;
            try
            {
                ECTNewLecturersDAL myLecturersDAL = new ECTNewLecturersDAL();
                List<ECTNewLecturers> MyLecturers = myLecturersDAL.GetList(InitializeModule.EnumCampus.ECTNew, " Where 1=1", false);
                int iIndex = 0;
                iIndex = MyLecturers.FindIndex(delegate (ECTNewLecturers L) { return L.LecturerID == iLecturer; });
                if (iIndex > 0)
                {
                    switch (Campus)
                    {
                        case InitializeModule.EnumCampus.Females:
                            iResult = MyLecturers[iIndex].FCampusID;
                            break;
                        case InitializeModule.EnumCampus.Males:
                            iResult = MyLecturers[iIndex].MCampusID;
                            break;
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
                divMsg.InnerText = exp.Message;
            }
            finally
            {

            }
            return iResult;

        }
    }
}