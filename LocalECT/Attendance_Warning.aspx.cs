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
    public partial class Attendance_Warning : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        int CurrentRole = 0;
        string sName = "";
        string sNo = "";
        int iRegYear = 0;
        int iRegSem = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                iRegYear = (int)Session["RegYear"];
                iRegSem = (int)Session["RegSemester"];
                Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                if (Request.QueryString["sid"] != null && Request.QueryString["sid"] != "")
                {                   
                    if (!IsPostBack)
                    {
                        bindmyattendancewrnigns();                       
                    }
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
        public void bindmyattendancewrnigns()
        {
            int iCSem = 0;
            int iCYear = LibraryMOD.SeperateTerm(LibraryMOD.GetCurrentTerm(), out iCSem);
            Connection_StringCLS myConnection_String = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);
            //SqlCommand cmd = new SqlCommand("SELECT [strCourse],max([byteWarningType]) as max FROM [ECTData].[dbo].[Reg_Students_Warning] where intStudyYear=@intStudyYear and byteSemester=@byteSemester and lngStudentNumber=@lngStudentNumber GROUP BY [strCourse] order by strCourse", sc);
            SqlCommand cmd = new SqlCommand("SELECT iYear, Sem, Student, Course, Warning FROM  Warning_Both_Side WHERE (iYear = @intStudyYear) AND (Sem = @byteSemester) AND (Student=@lngStudentNumber) order by course asc", sc);
            cmd.Parameters.AddWithValue("@intStudyYear", iCYear);
            cmd.Parameters.AddWithValue("@byteSemester", iCSem);
            cmd.Parameters.AddWithValue("@lngStudentNumber", Request.QueryString["sid"].ToString());//BAM1906016 Session["CurrentStudent"].ToString()
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
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
        public void ClearSession()
        {
            Session["CurrentUserName"] = null;
            Session["CurrentUserNo"] = null;
            Session["CurrentYear"] = null;
            Session["CurrentSemester"] = null;
            Session["CurrentCampus"] = null;
            Session["CurrentRole"] = null;
            Session["CurrentSystem"] = null;
            Session["CurrentLecturer"] = null;
            Session["MarkYear"] = null;
            Session["MarkSemester"] = null;
            Session["CurrentStudent"] = null;
            Session["CurrentStudentName"] = null;
            Session["CurrentMajorCampus"] = null;
        }
        private void showErr(string sMsg)
        {
            Session["errMsg"] = sMsg;
            Response.Redirect("ErrPage.aspx");
        }
    }
}