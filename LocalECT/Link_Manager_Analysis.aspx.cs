using System;
using System.Collections;
using System.Configuration;
using LocalECT.DAL;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text;

namespace LocalECT
{
    public partial class Link_Manager_Analysis : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        int CurrentRole = 0;
        string sName = "";
        string sNo = "";
        int iRegYear = 0;
        int iRegSem = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];

                    iRegYear = (int)Session["RegYear"];
                    iRegSem = (int)Session["RegSemester"];

                    if (!IsPostBack)
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.LinkManager,
                        InitializeModule.enumPrivilege.Print, CurrentRole) != true)
                        {
                           Server.Transfer("Authorization.aspx");
                        }
                    }
                }
                else
                {                    
                    ClearSession();
                    Response.Redirect("Login.aspx");

                }             
                if (Session["CurrentUserName"] != null)
                {
                    sNo = Session["CurrentUserName"].ToString();
                    sName = Session["CurrentUserName"].ToString();
                    if (!IsPostBack)
                    {
                        string id = Request.QueryString["id"];
                        if (id != null)
                        {
                            showanalysis(id);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0} Exception caught.", exp);
            }
            finally
            {

            }
        }
        public void showanalysis(string id)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(10), CONVERT(date, dClicked), 23) AS Date,count(iLink) as clicks FROM [ECTDataNew].[dbo].[ECT_Link_Tracking] where iLink=@iLink group by CONVERT(varchar(10), CONVERT(date, dClicked), 23)", sc);
            //SqlCommand cmd = new SqlCommand("SELECT CAST(dClicked AS DATE) as Date,count(iLink) as Clicks FROM [ECTDataNew].[dbo].[ECT_Link_Tracking] where iLink=@iLink group by CAST(dClicked AS DATE)", sc);
            cmd.Parameters.AddWithValue("@iLink", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table id='example' class='table table-striped table-bordered' style='width: 100%'>" + Environment.NewLine + "");

                    //Add Table Header
                    sb.Append("<thead>" + Environment.NewLine + "<tr class='headings'>" + Environment.NewLine + "");
                    sb.Append("<th>#</th> " + Environment.NewLine + "");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<th>" + column.ColumnName + "</th> " + Environment.NewLine + "");
                    }
                    sb.Append("</tr>" + Environment.NewLine + "</thead>" + Environment.NewLine + "");


                    //Add Table Rows
                    int i = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>" + Environment.NewLine + "");
                        sb.Append("<td>" + i + "</td>" + Environment.NewLine + "");
                        //Add Table Columns
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<td>" + row[column.ColumnName].ToString() + "</td>" + Environment.NewLine + "");
                        }
                        sb.Append("</tr>" + Environment.NewLine + "");
                        i++;
                    }

                    sb.Append("</table>" + Environment.NewLine + "");
                    DynamicTable.Text = sb.ToString();
                }
                else
                {
                    DynamicTable.Text = "<p><b>No Results to show</b></p>";
                }

                Session["dtprogress"] = dt;
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
        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public static List<object> GetChartData()
        //{
        //    string id = HttpContext.Current.Request.QueryString["id"];
        //    Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);            
        //    string query = "SELECT CAST(dClicked AS DATE) as Date,count(iLink) as Clicks FROM [ECTDataNew].[dbo].[ECT_Link_Tracking] where iLink=@iLink group by CAST(dClicked AS DATE)";
        //    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    List<object> chartData = new List<object>();
        //    chartData.Add(new object[]
        //    {
        //"Date", "Clicks"
        //    });
        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("@iLink", id);
        //            cmd.Connection = con;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    chartData.Add(new object[]
        //                    {
        //                sdr["Date"], sdr["Date"]
        //                    });
        //                }
        //            }
        //            con.Close();
        //            return chartData;
        //        }
        //    }
        //}


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object[] GetLineChartData()
        {
            List<GoogleChartData> data = new List<GoogleChartData>();
            DataTable dt = (DataTable)HttpContext.Current.Session["dtprogress"];
            //data = dt.Rows.Cast<DataRow>().ToList();

            var chartData = new object[dt.Rows.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "Clicks",
            };

            int j = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                j++;
                GoogleChartData details = new GoogleChartData();
                details.Date = dt.Rows[i]["Date"].ToString();
                details.Count = Convert.ToDouble(dt.Rows[i]["Clicks"]);
                data.Add(details);
              
                chartData[j] = new object[] { Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("MMM-dd"), Convert.ToDouble(dt.Rows[i]["Clicks"]) };
            }
            return chartData;           
        }

        public class GoogleChartData
        {
            public string Date { get; set; }
            public Double Count { get; set; }
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
    }
}