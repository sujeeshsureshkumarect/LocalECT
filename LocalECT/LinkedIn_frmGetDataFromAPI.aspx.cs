using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class LinkedIn_frmGetDataFromAPI : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Males;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString;
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
        int CurrentRole = 0;
        string LinkedInAccessToken = "";
        DataSet dsClassification = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                CurrentRole = (int)Session["CurrentRole"];
                if (!IsPostBack)
                {
                    //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_StudentSearch,
                    //InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                    //{
                    //    Server.Transfer("Authorization.aspx");
                    //}
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        protected void lnk_Get_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txt_StartDate.Text)) && (!string.IsNullOrEmpty(txt_EndDate.Text)))
            {
                DateTime StartDate = DateTime.ParseExact(txt_StartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime EndDate = DateTime.ParseExact(txt_EndDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                String TotalDays = (EndDate - StartDate).TotalDays.ToString();
                int NoOfDays = int.Parse(TotalDays) + 1;
                if (NoOfDays < 0)
                {
                    //Response.Write("<script>alert('End date must be after start date');</script>");
                    lbl_Msg.Text = "End date must be after Start date";
                    lbl_Msg.Visible = true;
                    div_msg.Visible = true;
                    div_Alert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                }
                else
                {
                    int iStart = 0;
                    int iCount = 500;
                    int iDaysCount = 14;
                    if (iCount > 500)
                    {
                        //lblErrorMessage.Text = "Max allowed 500";
                        return;
                    }
                    if (iDaysCount > 14)
                    {
                        //lblErrorMessage.Text = "Duration is limited to a max of 14 days/2 weeks from start date.";
                        return;
                    }
                    long iUTCStartFromDate;



                    DateTime dtFromDate = DateTime.ParseExact(txt_StartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dtEndDate = DateTime.ParseExact(txt_EndDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    iUTCStartFromDate = LibraryMOD.ToUnixTimestamp(dtFromDate);
                    int iStartDate = 0;
                    int iEndDate = 0;
                    iStartDate = dtFromDate.DayOfYear;
                    iEndDate = dtEndDate.DayOfYear;
                    int iYearsDiff = 0;
                    iYearsDiff = dtEndDate.Year - dtFromDate.Year;
                    iEndDate = iEndDate + (iYearsDiff * 365);

                    if (Session["LinkedInAccessToken"] is null)
                    {
                        LinkedInAccessToken = ClsLinkedInAPI.LinkedIn_Generating_Access_Token("773cqg20giin95", "t45WXRErCLlrOzVV");
                    }
                    else
                    {
                        LinkedInAccessToken = Session["LinkedInAccessToken"].ToString();
                    }
                    dsClassification = Prepare_LearningActivityReportDataset();
                    int iMax = iCount + iStart;

                    for (int i = iStartDate; i <= iEndDate;)
                    {
                        lbl_Msg.Visible = true;
                        div_msg.Visible = true;
                        div_Alert.Attributes.Add("class", "alert alert-success  alert-dismissible");
                        lbl_Msg.Text = ClsLinkedInActivityRepAPI.LinkedIn_GetEmpActivityReport(LinkedInAccessToken, dsClassification, iStart, iCount, iUTCStartFromDate, iDaysCount);
                        i += Convert.ToInt32(14);
                        dtFromDate = dtFromDate.AddDays(Convert.ToInt64(14));
                        iUTCStartFromDate = LibraryMOD.ToUnixTimestamp(dtFromDate);
                        if (dtEndDate.Subtract(dtFromDate).TotalDays < iDaysCount)
                        {
                            iDaysCount = Convert.ToInt32(dtEndDate.Subtract(dtFromDate).TotalDays) + 1;
                        }
                    }
                    //string sFileName = "D:\\LinkedInLearningClassificationsSkills" + iStart.ToString() + "_" + iCount.ToString() + ".xml";
                    //+ DateTime.Today.ToShortDateString()
                    Session["ReportDS"] = dsClassification;

                    if(lbl_Msg.Text=="completed")
                    {
                        //Delete all existing Data in the table "HR_EmployeeAllLinkedInCourses"
                        SqlCommand cmd = new SqlCommand("delete from HR_EmployeeAllLinkedInCourses", sc);
                        try
                        {
                            sc.Open();
                            cmd.ExecuteNonQuery();
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

                        int iDataStatus = (int)InitializeModule.enumModes.NewMode;
                        int iEffected = 0;
                        int iRow = 0;

                        string sEmpEmail = "";
                        string sEngagmentType = "";
                        string sAssetType = "";
                        DateTime dtFirstViewDate = DateTime.MinValue;
                        DateTime dtLastEngagedCompletedDate = DateTime.MinValue;

                        int iCourseID = 0;
                        int iEngagmentValue = 0;
                        EmployeeAllLinkedInCoursesDAL theEmployeeLinkedInCourses = new EmployeeAllLinkedInCoursesDAL();

                        DataSet ds = new DataSet();

                        ds = (DataSet)Session["ReportDS"];
                        for (iRow = 0; iRow <= ds.Tables[0].Rows.Count - 1; iRow++)
                        {
                            iCourseID = Convert.ToInt32("0" + ds.Tables[0].Rows[iRow]["iCourseID"].ToString());
                            iEngagmentValue = Convert.ToInt32("0" + ds.Tables[0].Rows[iRow]["sEngagmentValue"].ToString());

                            sEmpEmail = ds.Tables[0].Rows[iRow]["sEmpEmail"].ToString();
                            sEngagmentType = ds.Tables[0].Rows[iRow]["sEngagmentType"].ToString();
                            sAssetType = ds.Tables[0].Rows[iRow]["sAssetType"].ToString();
                            dtFirstViewDate = Convert.ToDateTime(ds.Tables[0].Rows[iRow]["FirstViewDate"].ToString());
                            dtLastEngagedCompletedDate = Convert.ToDateTime(ds.Tables[0].Rows[iRow]["LastEngagedCompletedDate"].ToString());

                            iEffected = theEmployeeLinkedInCourses.UpdateEmployeeAllLinkedInCourses(InitializeModule.EnumCampus.ECTNew, iDataStatus
                                , iRow + 1, sEmpEmail, "", iCourseID, "", sEngagmentType, iEngagmentValue, sAssetType, dtFirstViewDate, dtLastEngagedCompletedDate);
                        }

                        SqlCommand cmd1 = new SqlCommand("select * from HR_EmployeeLinkedInActivityReport", sc);
                        DataTable dt1 = new DataTable();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                        try
                        {
                            sc.Open();
                            da1.Fill(dt1);
                            sc.Close();

                            RepterDetails.DataSource = dt1;
                            RepterDetails.DataBind();

                            alertsearch.Visible = true;
                            lbl_Count.Text = dt1.Rows.Count.ToString() + " entry(s) found.";
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
                }
            }            
        }
        private DataSet Prepare_LearningActivityReportDataset()
        {

            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            try
            {
                DataColumn dc;

                dc = new DataColumn("sEmpEmail", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sEmpName", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("iCourseID", Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sCourseName", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sEngagmentType", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sEngagmentValue", Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("sAssetType", Type.GetType("System.String"));
                dt.Columns.Add(dc);

                dc = new DataColumn("FirstViewDate", Type.GetType("System.DateTime"));
                dt.Columns.Add(dc);
                dc = new DataColumn("LastEngagedCompletedDate", Type.GetType("System.DateTime"));
                dt.Columns.Add(dc);

                dt.TableName = "ActivityReport";
                dt.AcceptChanges();
                ds.Tables.Add(dt);

                //dt = new DataTable();
                //dt.TableName = "TrainingPlan";
                //dc = new DataColumn("sEmpEmail", Type.GetType("System.String"));
                //dt.Columns.Add(dc);
                //dc = new DataColumn("iCourseID", Type.GetType("System.Int32"));
                //dt.Columns.Add(dc);
                //dt.AcceptChanges();

                ds.AcceptChanges();
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }
            return ds;
        }
    }
}