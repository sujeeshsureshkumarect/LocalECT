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
                            last7(id);
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
        public void last7(string id)
        {
            Session["dtprogress"] = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(10), CONVERT(date, dClicked), 23) AS Date,count(iLink) as clicks,'7' as Type FROM [ECTDataNew].[dbo].[ECT_Link_Tracking] where iLink=@iLink and (dClicked>=DATEADD(DAY,-7,GETDATE()) and dClicked!>DATEADD(DAY,0,GETDATE())) group by CONVERT(varchar(10), CONVERT(date, dClicked), 23)", sc);
            cmd.Parameters.AddWithValue("@iLink", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                txt_Start.Text = (DateTime.Now.AddDays(-7)).ToString("yyyy-MM-dd");
                txt_End.Text = (DateTime.Now).ToString("yyyy-MM-dd");

                Session["dtprogress"] = dt;
                showanalysis(id);
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
        public void daily(string id)
        {
            Session["dtprogress"] = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(10), CONVERT(date, dClicked), 23) AS Date,count(iLink) as clicks,'D' as Type FROM [ECTDataNew].[dbo].[ECT_Link_Tracking] where iLink=@iLink  group by CONVERT(varchar(10), CONVERT(date, dClicked), 23)", sc);            
            cmd.Parameters.AddWithValue("@iLink", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Session["dtprogress"] = dt;
                showanalysis(id);
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

            dates(id);
        }

        public void dates(string id)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd1 = new SqlCommand("select dAdded from ECT_Link_Management where iLink=@iLink", sc);
            cmd1.Parameters.AddWithValue("@iLink", id);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            try
            {
                sc.Open();
                da1.Fill(dt1);
                sc.Close();

                if(dt1.Rows.Count>0)
                {
                    txt_Start.Text = Convert.ToDateTime(dt1.Rows[0]["dAdded"]).ToString("yyyy-MM-dd");
                    txt_End.Text = (DateTime.Now).ToString("yyyy-MM-dd");
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
        public void weekly(string id)
        {
            Session["dtprogress"] = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT DATEPART(week, dClicked) AS Week,count(iLink) as clicks,'W' as Type FROM [ECTDataNew].[dbo].[ECT_Link_Tracking] where iLink=@iLink group by  DATEPART(week, dClicked) order by DATEPART(week, dClicked) asc", sc);
            cmd.Parameters.AddWithValue("@iLink", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Session["dtprogress"] = dt;
                showanalysis(id);
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
            dates(id);
        }
        public void monthly(string id)
        {
            Session["dtprogress"] = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT MONTH(dClicked) [Month1],Year(dClicked) as Year,DATENAME(MONTH,dClicked) +'-'+ convert(varchar(4), Year(dClicked)) AS Month,count(iLink) as clicks,'M' as Type FROM [ECTDataNew].[dbo].[ECT_Link_Tracking] where iLink=@iLink group by DATENAME(MONTH,dClicked) +'-'+convert(varchar(4), Year(dClicked)) ,MONTH(dClicked),Year(dClicked) order by Year(dClicked) asc,MONTH(dClicked) asc", sc);
            cmd.Parameters.AddWithValue("@iLink", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Session["dtprogress"] = dt;
                showanalysis(id);
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
            dates(id);
        }
        public void yearly(string id)
        {
            Session["dtprogress"] = "";
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT Year(dClicked) as Year,count(iLink) as clicks,'Y' as Type FROM [ECTDataNew].[dbo].[ECT_Link_Tracking] where iLink=@iLink group by  Year(dClicked) order by Year(dClicked) asc", sc);
            cmd.Parameters.AddWithValue("@iLink", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Session["dtprogress"] = dt;
                showanalysis(id);
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
            dates(id);
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

                //Session["dtprogress"] = dt;
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
            //List<GoogleChartData> data = new List<GoogleChartData>();
            DataTable dt = (DataTable)HttpContext.Current.Session["dtprogress"];
            //data = dt.Rows.Cast<DataRow>().ToList();

            var chartData = new object[dt.Rows.Count + 1];
            if(dt.Rows.Count>0)
            {
                if (dt.Rows[0]["Type"].ToString() == "D" || dt.Rows[0]["Type"].ToString() == "7")
                {
                    chartData[0] = new object[]{
                "Date",
                "Clicks",
            };
                }
                else if (dt.Rows[0]["Type"].ToString() == "W")
                {
                    chartData[0] = new object[]{
                "Week",
                "Clicks",
            };
                }
                else if (dt.Rows[0]["Type"].ToString() == "M")
                {
                    chartData[0] = new object[]{
                "Month",
                "Clicks",
            };
                }
                else if (dt.Rows[0]["Type"].ToString() == "Y")
                {
                    chartData[0] = new object[]{
                "Year",
                "Clicks",
            };
                }
            }
            else
            {
                chartData[0] = new object[]{
                "Date",
                "Clicks",
            };
            }
            

            int j = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                j++;
                //GoogleChartData details = new GoogleChartData();
                //details.Date = dt.Rows[i]["Date"].ToString();
                //details.Count = Convert.ToDouble(dt.Rows[i]["Clicks"]);
                //data.Add(details);
                if (dt.Rows[i]["Type"].ToString() == "D"|| dt.Rows[i]["Type"].ToString() == "7")
                {
                    chartData[j] = new object[] { Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("MMM-dd"), Convert.ToDouble(dt.Rows[i]["Clicks"]) };
                }
                else if (dt.Rows[i]["Type"].ToString() == "W")
                {
                    int q = i + 1;
                    chartData[j] = new object[] { "Week " + q + "", Convert.ToDouble(dt.Rows[i]["Clicks"]) };
                }
                else if (dt.Rows[i]["Type"].ToString() == "M")
                {
                    chartData[j] = new object[] { dt.Rows[i]["Month"], Convert.ToDouble(dt.Rows[i]["Clicks"]) };
                }
                else if (dt.Rows[i]["Type"].ToString() == "Y")
                {
                    chartData[j] = new object[] { dt.Rows[i]["Year"], Convert.ToDouble(dt.Rows[i]["Clicks"]) };
                }                
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

        protected void lbl_Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbl_Order.SelectedItem.Text == "Last 7 days")
            {
                string id = Request.QueryString["id"];
                if (id != null)
                {
                    last7(id);
                }
            }
            else if (lbl_Order.SelectedItem.Text=="Daily")
            {
                string id = Request.QueryString["id"];
                if (id != null)
                {
                    daily(id);
                }
            }
            else if (lbl_Order.SelectedItem.Text == "Weekly")
            {
                string id = Request.QueryString["id"];
                if (id != null)
                {
                    weekly(id);
                }
            }
            else if (lbl_Order.SelectedItem.Text == "Monthly")
            {
                string id = Request.QueryString["id"];
                if (id != null)
                {
                    monthly(id);
                }
            }
            else if (lbl_Order.SelectedItem.Text == "Yearly")
            {
                string id = Request.QueryString["id"];
                if (id != null)
                {
                    yearly(id);
                }
            }
        }

        protected void txt_Start_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txt_Start.Text) && !string.IsNullOrEmpty(txt_End.Text))
            {
                Session["dtprogress"] = "";
                Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
                SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(10), CONVERT(date, dClicked), 23) AS Date,count(iLink) as clicks,'D' as Type FROM [ECTDataNew].[dbo].[ECT_Link_Tracking] where iLink=@iLink and (dClicked between '" + txt_Start.Text.Trim() + " 00:00:00.000' AND '" + txt_End.Text.Trim() + " 23:59:59.999')  group by CONVERT(varchar(10), CONVERT(date, dClicked), 23)", sc);
                cmd.Parameters.AddWithValue("@iLink", Request.QueryString["id"]);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    sc.Open();
                    da.Fill(dt);
                    sc.Close();

                    Session["dtprogress"] = dt;
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
    }
}