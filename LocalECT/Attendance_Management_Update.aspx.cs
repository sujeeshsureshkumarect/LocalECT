using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Globalization;

namespace LocalECT
{
    public partial class Attendance_Management_Update : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        int CurrentRole = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentSearch,
                    InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    {
                        //Server.Transfer("Authorization.aspx");
                    }                   
                    FillTerms();
                    string i = Request.QueryString["i"];
                    if(i!=null)
                    {
                        byte[] b;
                        string decrypted;
                        try
                        {
                            b = Convert.FromBase64String(i);
                            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
                        }
                        catch (FormatException fe)
                        {
                            decrypted = "";
                            Console.WriteLine(fe.Message);
                        }
                        string[] items = decrypted.Split('_');
                        string dateAttendance = items[0];
                        string strCourse = items[1];
                        string lngStudentNumber = items[2];
                        string byteAttStatus = items[3];
                        string campus = items[4];
                        string Year = items[5];
                        string Semeseter = items[6];
                        string Note = items[7];

                        drp_Campus.SelectedIndex = drp_Campus.Items.IndexOf(drp_Campus.Items.FindByText(campus));
                        int iYear = 0;
                        int iSem = 0;
                        int iTerm = 0;
                        iYear = Convert.ToInt32(Year);
                        iSem = Convert.ToInt32(Semeseter);
                        iTerm = iYear * 10 + iSem;
                        ddlTerm.SelectedValue = iTerm.ToString();
                        txt_Course.Text = strCourse;
                        txt_StudentID.Text = lngStudentNumber;
                        txt_Date.Text = dateAttendance;
                        FillAttendanceStatus(byteAttStatus);
                        drp_Status.SelectedIndex = drp_Status.Items.IndexOf(drp_Status.Items.FindByValue(byteAttStatus));
                        txt_Note.Text = Note;
                    }
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
        public void FillAttendanceStatus(string Current)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value));
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

            SqlCommand cmd = new SqlCommand("select byteAttStatus,strAttDescEn from Lkp_Att_Status where (byteAttStatus=@byteAttStatus) OR (byteAttStatus=@byteAttStatus1)", sc);
            cmd.Parameters.AddWithValue("@byteAttStatus", Current);
            cmd.Parameters.AddWithValue("@byteAttStatus1", "3");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                drp_Status.DataSource = dt;
                drp_Status.DataTextField = "strAttDescEn";
                drp_Status.DataValueField = "byteAttStatus";
                drp_Status.DataBind();
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
        private void FillTerms()
        {
            List<Semesters> myTerms = new List<Semesters>();
            SemesterDAL myTermsDAL = new SemesterDAL();
            try
            {
                myTerms = myTermsDAL.GetTerms(InitializeModule.EnumCampus.ECTNew, "", true);
                for (int i = 0; i < myTerms.Count; i++)
                {
                    ddlTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));

                }
                int iYear = 0;
                int iSem = 0;
                int iTerm = 0;
                iYear = (int)Session["CurrentYear"];
                iSem = (int)Session["CurrentSemester"];
                iTerm = iYear * 10 + iSem;
                ddlTerm.SelectedValue = iTerm.ToString();
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
        protected void lnk_Search_Click(object sender, EventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS((InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value));
            SqlConnection sc = new SqlConnection(myConnection_String.Conn_string);

            string i = Request.QueryString["i"];
            if (i != null)
            {
                byte[] b;
                string decrypted;
                try
                {
                    b = Convert.FromBase64String(i);
                    decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
                }
                catch (FormatException fe)
                {
                    decrypted = "";
                    Console.WriteLine(fe.Message);
                }
                string[] items = decrypted.Split('_');
                string dateAttendance = items[0];
                string strCourse = items[1];
                string lngStudentNumber = items[2];
                string byteAttStatus = items[3];
                string campus = items[4];
                string Year = items[5];
                string Semeseter = items[6];

                SqlCommand cmd = new SqlCommand("update Reg_Attendance set byteAttStatus=@byteAttStatus,strNote=@strNote,strUserSave=@strUserSave,dateLastSave=@dateLastSave,strMachine=@strMachine,strNUser=@strNUser where (intStudyYear=@intStudyYear) AND (byteSemester=@byteSemester) AND (strCourse=@strCourse) AND (lngStudentNumber=@lngStudentNumber) AND (dateAttendance=@dateAttendance)", sc);
                cmd.Parameters.AddWithValue("@byteAttStatus", drp_Status.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@strNote", txt_Note.Text.Trim());
                cmd.Parameters.AddWithValue("@strUserSave", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@dateLastSave", DateTime.Now);
                cmd.Parameters.AddWithValue("@strMachine", "LOCALECT");
                cmd.Parameters.AddWithValue("@strNUser", Session["CurrentUserName"].ToString());
                cmd.Parameters.AddWithValue("@intStudyYear", Year);
                cmd.Parameters.AddWithValue("@byteSemester", Semeseter);
                cmd.Parameters.AddWithValue("@strCourse", strCourse);
                cmd.Parameters.AddWithValue("@lngStudentNumber", lngStudentNumber);
                cmd.Parameters.AddWithValue("@dateAttendance", Convert.ToDateTime(dateAttendance));
                try
                {
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();

                    lbl_Msg.Text = "Attendance Updated Successfully";
                    div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    div_msg.Visible = true;
                }
                catch(Exception ex)
                {
                    sc.Close();
                    lbl_Msg.Text = ex.Message;
                    div_msg.Visible = true;
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sc.Close();
                }
            }                
        }
    }
}