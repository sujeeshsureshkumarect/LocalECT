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
using System.Text;

namespace LocalECT
{
    public partial class Attendance_Management : System.Web.UI.Page
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

                    if (Session["Attendace_Table"] != null)
                    {
                        DataTable dt1 = (DataTable)Session["Attendace_Table"];
                        RepterDetails.DataSource = dt1;
                        RepterDetails.DataBind();
                    }
                    FillTerms();


                    if (Session["AMRegYear"] != null && Session["AMRegSem"] != null)
                    {
                        int iYear = 0;
                        int iSem = 0;
                        int iTerm = 0;
                        iYear = (int)Session["AMRegYear"];
                        iSem = (int)Session["AMRegSem"];
                        iTerm = iYear * 10 + iSem;
                        ddlTerm.SelectedValue = iTerm.ToString();
                    }
                    if (Session["CurrentCampus"] != null)
                    {
                        drp_Campus.SelectedIndex = drp_Campus.Items.IndexOf(drp_Campus.Items.FindByText(Session["CurrentCampus"].ToString()));
                    }
                    if(Session["AMCourse"] !=null)
                    {
                        txt_Course.Text = Session["AMCourse"].ToString();
                    }
                    if (Session["AMStudentID"] != null)
                    {
                        txt_StudentID.Text = Session["AMStudentID"].ToString();
                    }
                    if (Session["AMDate"] != null)
                    {
                        txt_Date.Text = Session["AMDate"].ToString();
                    }
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
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
            String sqlcomd = "";
            int iRegYear = 0;
            int iRegSem = 0;
            int iRegTerm = 0;
            iRegTerm = Convert.ToInt32(ddlTerm.SelectedValue);
            iRegYear = LibraryMOD.SeperateTerm(iRegTerm, out iRegSem);
            if (drp_Campus.SelectedItem.Text == "Males")
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataMales"].ConnectionString;
                //sqlcomd = "SELECT  dbo.Reg_Applications.lngStudentNumber, dbo.Reg_Students_Data.strLastDescEn, dbo.Reg_Specializations.strCaption, dbo.Reg_Students_Data.sECTemail, dbo.Reg_Students_Data.dateCreate, dbo.Reg_Applications.byteCancelReason, dbo.Lkp_Reasons.strReasonDesc FROM            dbo.Reg_Applications INNER JOIN dbo.Reg_Students_Data ON dbo.Reg_Applications.lngSerial = dbo.Reg_Students_Data.lngSerial INNER JOIN dbo.Reg_Specializations ON dbo.Reg_Applications.strCollege = dbo.Reg_Specializations.strCollege AND dbo.Reg_Applications.strDegree = dbo.Reg_Specializations.strDegree AND dbo.Reg_Applications.strSpecialization = dbo.Reg_Specializations.strSpecialization LEFT OUTER JOIN dbo.Lkp_Reasons ON dbo.Reg_Applications.byteCancelReason = dbo.Lkp_Reasons.byteReason WHERE (dbo.Reg_Students_Data.byteShift = 3 OR dbo.Reg_Students_Data.byteShift = 4 OR dbo.Reg_Students_Data.byteShift = 8) AND";
                //sqlcomd = "SELECT sNo, sName, sAccount, sPhone1, ECTEmail,iSerial FROM Web_Students_Search where";
                sqlcomd = "SELECT Reg_Attendance.intStudyYear, Reg_Attendance.byteSemester, Reg_Attendance.strCourse, Reg_Attendance.lngStudentNumber, CONVERT(varchar(10), CONVERT(date, Reg_Attendance.dateAttendance), 23) as dateAttendance , Reg_Attendance.byteAttStatus, Lkp_Att_Status.strAttDescEn, Reg_Attendance.strNote, Reg_Attendance.strUserSave, Reg_Attendance.dateLastSave, Reg_Attendance.strMachine, Reg_Attendance.strNUser FROM Reg_Attendance INNER JOIN Lkp_Att_Status ON Reg_Attendance.byteAttStatus = Lkp_Att_Status.byteAttStatus WHERE (Reg_Attendance.intStudyYear = @intStudyYear) AND (Reg_Attendance.byteSemester = @byteSemester) ";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
            }
            else
            {
                constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
                //sqlcomd = "SELECT  dbo.Reg_Applications.lngStudentNumber, dbo.Reg_Students_Data.strLastDescEn, dbo.Reg_Specializations.strCaption, dbo.Reg_Students_Data.sECTemail, dbo.Reg_Students_Data.dateCreate, dbo.Reg_Applications.byteCancelReason, dbo.Lkp_Reasons.strReasonDesc FROM            dbo.Reg_Applications INNER JOIN dbo.Reg_Students_Data ON dbo.Reg_Applications.lngSerial = dbo.Reg_Students_Data.lngSerial INNER JOIN dbo.Reg_Specializations ON dbo.Reg_Applications.strCollege = dbo.Reg_Specializations.strCollege AND dbo.Reg_Applications.strDegree = dbo.Reg_Specializations.strDegree AND dbo.Reg_Applications.strSpecialization = dbo.Reg_Specializations.strSpecialization LEFT OUTER JOIN dbo.Lkp_Reasons ON dbo.Reg_Applications.byteCancelReason = dbo.Lkp_Reasons.byteReason WHERE (dbo.Reg_Students_Data.byteShift = 1 OR dbo.Reg_Students_Data.byteShift = 2 OR dbo.Reg_Students_Data.byteShift = 9) AND";
                //sqlcomd = "SELECT sNo, sName, sAccount, sPhone1, ECTEmail,iSerial FROM Web_Students_Search where ";
                sqlcomd = "SELECT Reg_Attendance.intStudyYear, Reg_Attendance.byteSemester, Reg_Attendance.strCourse, Reg_Attendance.lngStudentNumber, CONVERT(varchar(10), CONVERT(date, Reg_Attendance.dateAttendance), 23) as dateAttendance , Reg_Attendance.byteAttStatus, Lkp_Att_Status.strAttDescEn, Reg_Attendance.strNote, Reg_Attendance.strUserSave, Reg_Attendance.dateLastSave, Reg_Attendance.strMachine, Reg_Attendance.strNUser FROM Reg_Attendance INNER JOIN Lkp_Att_Status ON Reg_Attendance.byteAttStatus = Lkp_Att_Status.byteAttStatus WHERE (Reg_Attendance.intStudyYear = @intStudyYear) AND (Reg_Attendance.byteSemester = @byteSemester) ";
                Campus = (InitializeModule.EnumCampus)int.Parse(drp_Campus.SelectedItem.Value);
            }

            string where = "";
            if(!string.IsNullOrEmpty(txt_Course.Text))
            {
                where += " AND (Reg_Attendance.strCourse='"+txt_Course.Text.Trim()+"') ";
                Session["AMCourse"] = txt_Course.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txt_StudentID.Text))
            {
                where += " AND (Reg_Attendance.lngStudentNumber='"+txt_StudentID.Text.Trim()+"') ";
                Session["AMStudentID"] = txt_StudentID.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txt_Date.Text))
            {
                DateTime Date = DateTime.ParseExact(txt_Date.Text.Trim(), @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                where += " AND (Reg_Attendance.dateAttendance='" + Date + "') ";
                Session["AMDate"] = txt_Date.Text.Trim();
            }

            Session["CurrentCampus"] = Campus;
            Session["AMRegYear"] = iRegYear;
            Session["AMRegSem"] = iRegSem;

            //Session["iiRegTerm"] = Convert.ToInt32(ddlTerm.SelectedValue);

            SqlConnection sc = new SqlConnection(constr);
            //SqlCommand cmd = new SqlCommand(sqlcomd + " " + sqlcont+ " ORDER BY dbo.Reg_Students_Data.strLastDescEn ASC, dbo.Reg_Students_Data.dateCreate DESC", sc);
            SqlCommand cmd = new SqlCommand(sqlcomd+" "+ where, sc);
            cmd.Parameters.AddWithValue("@intStudyYear", iRegYear);
            cmd.Parameters.AddWithValue("@byteSemester", iRegSem);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Session["Attendace_Table"] = dt;
                RepterDetails.DataSource = dt;
                RepterDetails.DataBind();

                alertsearch.Visible = true;
                lbl_Count.Text = dt.Rows.Count.ToString() + " entry(s) found.";

            }
            catch (Exception ex)
            {
                sc.Close();
                throw ex;
            }
            finally
            {
                sc.Close();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string dateAttendance = button.CommandArgument;//dateAttendance
            DateTime dtime = Convert.ToDateTime(dateAttendance);
            string strCourse = button.CommandName;//strCourse
            string lngStudentNumber = button.ToolTip;//lngStudentNumber
            string byteAttStatus = button.ValidationGroup;//byteAttStatus
            string AccessKey = button.AccessKey;//strNote

            string text = dateAttendance + "_" + strCourse + "_" + lngStudentNumber + "_" + byteAttStatus + "_" + Session["CurrentCampus"].ToString() + "_" + Session["AMRegYear"].ToString() + "_" + Session["AMRegSem"].ToString() + "_" + AccessKey;
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
            string encrypted = Convert.ToBase64String(b);

            Response.Redirect("Attendance_Management_Update?i="+ encrypted + "");

            //string url = "Attendance_Management_Update?i=" + encrypted + "";
            //StringBuilder sb = new StringBuilder();
            //sb.Append("<script type = 'text/javascript'>");
            //sb.Append("window.open('");
            //sb.Append(url);
            //sb.Append("','_blank');");
            //sb.Append("</script>");
            //ClientScript.RegisterStartupScript(this.GetType(),
            //        "script", sb.ToString());

            //Response.Write("<script>");
            //Response.Write("window.open('Attendance_Management_Update?i=" + encrypted + "','_blank')");
            //Response.Write("</script>");
        }
    }
}