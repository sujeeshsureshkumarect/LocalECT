using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalECT
{
    public partial class Bulk_SC_Send_SMS : System.Web.UI.Page
    {
        InitializeModule.EnumCampus Campus = InitializeModule.EnumCampus.Females;
        string constr = ConfigurationManager.ConnectionStrings["ECTDataFemales"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRole"] != null)
            {
                int CurrentRole = (int)Session["CurrentRole"];
                Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                if (!IsPostBack)
                {
                    if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.ECT_Student_Data,
                   InitializeModule.enumPrivilege.SendSMS, CurrentRole) != true)
                    {
                        Server.Transfer("Authorization.aspx");
                    }
                    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                    if (Session["sids"] != null)
                    {
                        string value = Session["sids"].ToString();
                        lnk_BulkUpdate.Visible = true;
                        stringsids(value);
                    }
                    else
                    {
                        //lnk_BulkUpdate.Visible = false;
                        //alertsearch.Visible = false;
                        //lbl_IDs.Text = "";
                        //lbl_Msg.Text = "No Data Selected for Bulk Operation";
                        //div_msg.Visible = true;                        
                    }
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }
        public void stringsids(string sIDs)
        {
            int iLen = sIDs.Length;
            string sLast = sIDs.Substring(iLen - 1, 1);
            if (sLast == ",")
            {
                sIDs = sIDs.Remove(iLen - 1, 1);
            }
            string s = sIDs;
            string[] uniqueItems = s.Split(',');
            IEnumerable<string> splittedArray = uniqueItems.Distinct<string>();
            //if (s.Length<=10)
            //{
            //    alertsearch.Visible = true;
            //    lbl_IDs.Text = sIDs;
            //}
            alertsearch.Visible = true;
            lbl_IDs.Text = splittedArray.Count().ToString() + " records selected for Bulk Action";
            //sIDs = "'" + s.Replace(",", "','") + "'";

        }
        public DataTable READExcel(string path)
        {
            Microsoft.Office.Interop.Excel.Application objXL = null;
            Microsoft.Office.Interop.Excel.Workbook objWB = null;
            objXL = new Microsoft.Office.Interop.Excel.Application();
            objWB = objXL.Workbooks.Open(path);
            Microsoft.Office.Interop.Excel.Worksheet objSHT = objWB.Worksheets[1];

            int rows = objSHT.UsedRange.Rows.Count;
            int cols = objSHT.UsedRange.Columns.Count;
            DataTable dt = new DataTable();
            int noofrow = 1;

            for (int c = 1; c <= cols; c++)
            {
                string colname = objSHT.Cells[1, c].Text;
                dt.Columns.Add(colname);
                noofrow = 2;
            }

            for (int r = noofrow; r <= rows; r++)
            {
                DataRow dr = dt.NewRow();
                for (int c = 1; c <= cols; c++)
                {
                    dr[c - 1] = objSHT.Cells[r, c].Text;
                }

                dt.Rows.Add(dr);
            }

            objWB.Close();
            objXL.Quit();
            return dt;
        }
        protected void lnk_BulkUpdate_Click(object sender, EventArgs e)
        {
            Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
            Connection_StringCLS connstr = new Connection_StringCLS(Campus);
            SqlConnection sc = new SqlConnection(connstr.Conn_string);

            int iEffected = 0;

            if (flp_upload.HasFile==true)
            {
                //Excel Reader
                string filetype = Path.GetExtension(flp_upload.FileName);
                if (filetype.ToLower() == ".xlsx"|| filetype.ToLower() == ".xls")
                {
                    //getting the path of the file   
                    string path = Server.MapPath("~/Upload/" + flp_upload.FileName);
                    //saving the file inside the MyFolder of the server  
                    flp_upload.SaveAs(path);
                    DataTable dt = READExcel(path);
                    if (path != null)
                    {
                        string FileUrls = path;
                        System.IO.File.Delete(FileUrls);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        string text_contents = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[i]["Mobile_Number"].ToString()) && !string.IsNullOrEmpty(dt.Rows[i]["SMS_Text"].ToString()))
                            {
                                string mobile = dt.Rows[i]["Mobile_Number"].ToString();
                                string SMS_Text = dt.Rows[i]["SMS_Text"].ToString();
                                string textmessage = SMS_Text.Replace("\r\n", "\\r\\n");
                                mobile = "+" + mobile;
                                if (mobile.StartsWith("+971") && mobile.Substring(4, 1) == "5")
                                {
                                    text_contents += "\n{\n\"source\": \"AD-ECT\",\n\"sourceTON\": \"ALPHANUMERIC\",\n\"destination\": \"" + mobile + "\",\n\"userData\": \"" + textmessage + "\"\n},";
                                    //text_contents += "\n{\n\"source\": \"AD-ECT\",\n\"sourceTON\": \"ALPHANUMERIC\",\n\"destination\": \"+971558784117\",\n\"userData\": \"" + txt_Text.Text.Trim() + "\"\n},";
                                    iEffected++;
                                }
                            }
                        }
                        int iLen1 = text_contents.Length;
                        string sLast1 = text_contents.Substring(iLen1 - 1, 1);
                        if (sLast1 == ",")
                        {
                            text_contents = text_contents.Remove(iLen1 - 1, 1);
                        }
                        bulksms(text_contents);
                        lbl_Msg.Text = "Bulk Operation (Send SMS) Completed Successfully-SMS sent to " + iEffected + " students.";
                        div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        div_msg.Visible = true;
                        lnk_BulkUpdate.Visible = false;                        
                    }
                }
                else
                {
                    lbl_Msg.Text = "Only .xlsx,.xls files are allowed";
                    div_msg.Visible = true;
                    return;
                }
            }
            else
            {
                if (Session["sids"] != null)
                {
                    if(txt_Text.Text.Length>0)
                    {
                        string sIDs = Session["sids"].ToString();
                        int iLen = sIDs.Length;
                        string sLast = sIDs.Substring(iLen - 1, 1);
                        if (sLast == ",")
                        {
                            sIDs = sIDs.Remove(iLen - 1, 1);
                        }
                        string s = sIDs;
                        sIDs = "'" + s.Replace(",", "','") + "'";

                        string sSQL = "SELECT  Reg_Students_Data.strPhone1 ";
                        sSQL += " FROM Reg_Applications INNER JOIN ";
                        sSQL += "  Reg_Students_Data ON Reg_Applications.lngSerial = Reg_Students_Data.lngSerial ";
                        sSQL += " WHERE Reg_Applications.lngStudentNumber in (" + sIDs + ")";

                        SqlConnection Conn = new SqlConnection(connstr.Conn_string.ToString());

                        SqlCommand cmd = new SqlCommand(sSQL, Conn);
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        try
                        {
                            sc.Open();
                            da.Fill(dt);
                            sc.Close();

                            if (dt.Rows.Count > 0)
                            {
                                string text_contents = "";
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (!string.IsNullOrEmpty(dt.Rows[i]["strPhone1"].ToString()))
                                    {
                                        string mobile = dt.Rows[i]["strPhone1"].ToString();
                                        mobile = LibraryMOD.CleanPhone(mobile);
                                        if (mobile.Substring(0, 1) == "0")
                                        {
                                            mobile = "+971" + mobile.Remove(0, 1);
                                        }
                                        if (mobile.StartsWith("+971") && mobile.Substring(4, 1) == "5")
                                        {
                                            text_contents += "\n{\n\"source\": \"AD-ECT\",\n\"sourceTON\": \"ALPHANUMERIC\",\n\"destination\": \"" + mobile + "\",\n\"userData\": \"" + txt_Text.Text.Trim() + "\"\n},";
                                            //text_contents += "\n{\n\"source\": \"AD-ECT\",\n\"sourceTON\": \"ALPHANUMERIC\",\n\"destination\": \"+971558784117\",\n\"userData\": \"" + txt_Text.Text.Trim() + "\"\n},";
                                            iEffected++;
                                        }
                                    }
                                }
                                int iLen1 = text_contents.Length;
                                string sLast1 = text_contents.Substring(iLen1 - 1, 1);
                                if (sLast1 == ",")
                                {
                                    text_contents = text_contents.Remove(iLen1 - 1, 1);
                                }
                                bulksms(text_contents);
                                lbl_Msg.Text = "Bulk Operation (Send SMS) Completed Successfully-SMS sent to " + iEffected + " students.";
                                div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                                div_msg.Visible = true;
                                lnk_BulkUpdate.Visible = false;
                                //Clear Cookies with selected Student ID's
                                if (Session["sids"] != null)
                                {
                                    Session["sids"] = null;
                                }
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
                    else
                    {
                        lbl_Msg.Text = "SMS Text cannot be empty";
                        div_msg.Visible = true;
                        return;
                    }
                }
                else
                {
                    lbl_Msg.Text = "No Data Selected for Bulk Operation";
                    div_msg.Visible = true;
                    return;
                }                
            }                                
        }
        public void bulksms(string text_contents)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://c-eu.linkmobility.io/sms/sendbatch"))
                {                   
                    request.Headers.TryAddWithoutValidation("Authorization", "Basic cE9UZ1oyTFc6R2NuMzU1MzJHcXc=");
                    request.Content = new StringContent("{\n\"platformId\": \"SMSC\",\n\"platformPartnerId\": \"3759\",\n\"useDeliveryReport\": false,\n\"sendRequestMessages\": ["+ text_contents + "\n]\n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");                            
                    var task = httpClient.SendAsync(request);
                    task.Wait();
                    var response = task.Result;
                    string s = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode == true)
                    {
                        //Success
                        //lbl_Msg.Text = "SMS Sent";
                        //div_Alert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        //div_msg.Visible = true;
                    }
                }
            }
        }
        protected void lnk_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentSearch.aspx");
        }
    }
}