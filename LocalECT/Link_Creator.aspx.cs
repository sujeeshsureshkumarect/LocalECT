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
using System.Globalization;
using System.IO;

namespace LocalECT
{
    public partial class Link_Creator : System.Web.UI.Page
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
                        //getcode();
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.LinkManager,
                        InitializeModule.enumPrivilege.AddNew, CurrentRole) != true)
                        {
                            Server.Transfer("Authorization.aspx");
                        }
                        txt_Date.Text = DateTime.Now.AddYears(5).ToString("dd/MM/yyyy");
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
                        FillTerms();
                        //hdn_sCode.Value = Create16DigitString();                        
                        //txt_ShortURL.Text = "https://dt.ect.ac.ae/l?q=" + hdn_sCode.Value + "";
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

        private void FillTerms()
        {
            List<Semesters> myTerms = new List<Semesters>();
            SemesterDAL myTermsDAL = new SemesterDAL();
            try
            {
                myTerms = myTermsDAL.GetTerms(InitializeModule.EnumCampus.ECTNew, "", true);
                for (int i = 0; i < myTerms.Count; i++)
                {
                    ddlRegTerm.Items.Add(new ListItem(myTerms[i].ShortDesc, myTerms[i].Term.ToString()));
                }
                //ddlRegTerm.Items.Insert(0, new ListItem("Unspecified", "0"));
                int iYear = 0;
                int iSem = 0;
                int iTerm = 0;
                iYear = (int)Session["RegYear"];
                iSem = (int)Session["RegSemester"];
                iTerm = iYear * 10 + iSem;
                ddlRegTerm.SelectedValue = iTerm.ToString();
            }
            catch (Exception ex)
            {
                LibraryMOD.ShowErrorMessage(ex);
                //divMsg.InnerText = ex.Message;
            }
            finally
            {
                myTerms.Clear();
            }
        }
        public string Create16DigitString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[5];
            var random = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString.ToString();
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

        public void getcode()
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("select * from ECT_Link_Management where sCode=''", sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if(dt.Rows.Count>0)
                {
                    for(int j=0;j<dt.Rows.Count;j++)
                    {
                        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                        var stringChars = new char[5];
                        var random = new Random((int)DateTime.Now.Ticks);
                        for (int i = 0; i < stringChars.Length; i++)
                        {
                            stringChars[i] = chars[random.Next(chars.Length)];
                        }
                        var finalString = new String(stringChars);

                        SqlCommand cmd2 = new SqlCommand("select * from ECT_Link_Management where sCode=@sCode", sc);
                        cmd2.Parameters.AddWithValue("@sCode", finalString.ToString());
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                        try
                        {
                            sc.Open();
                            da2.Fill(dt2);
                            sc.Close();

                            if(dt2.Rows.Count>0)
                            {
                                //Duplicate
                            }
                            else
                            {
                                SqlCommand cmd1 = new SqlCommand("update ECT_Link_Management set sCode=@sCode,dCodeCreated=@dCodeCreated where iLink=@iLink", sc);
                                cmd1.Parameters.AddWithValue("@sCode", finalString.ToString());
                                cmd1.Parameters.AddWithValue("@dCodeCreated", DateTime.Now);
                                cmd1.Parameters.AddWithValue("@iLink", dt.Rows[j]["iLink"].ToString());
                                try
                                {
                                    sc.Open();
                                    cmd1.ExecuteNonQuery();
                                    sc.Close();
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

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            if (flp_upload.HasFile == true)
            {
                //Excel Reader
                string filetype = Path.GetExtension(flp_upload.FileName);
                if (filetype.ToLower() == ".xlsx" || filetype.ToLower() == ".xls")
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
                        int ieffected = 0;
                        for(int i=0;i<dt.Rows.Count;i++)
                        {
                            string sCode = Create16DigitString();
                            SqlCommand cmd = new SqlCommand("insert into ECT_Link_Management values(@sDesc,@sURL,@sAlternativeURL,@sCode,@dExpiry,@isActive,@sSource,@sNote,@iTerm,@sAddedby,@dAdded,@dCodeCreated,@sTargetLanguage,@sMedium)", sc);
                            cmd.Parameters.AddWithValue("@sDesc", txt_Description.Text.Trim());
                            cmd.Parameters.AddWithValue("@sURL", dt.Rows[i]["sURL"].ToString());
                            cmd.Parameters.AddWithValue("@sAlternativeURL", txt_Alt_URL.Text.Trim());
                            cmd.Parameters.AddWithValue("@sCode", sCode);
                            DateTime date = DateTime.ParseExact(txt_Date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            cmd.Parameters.AddWithValue("@dExpiry", date);
                            cmd.Parameters.AddWithValue("@isActive", drp_Status.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@sSource", drp_Source.SelectedItem.Text);
                            cmd.Parameters.AddWithValue("@sNote", txt_Note.Text.Trim());
                            cmd.Parameters.AddWithValue("@iTerm", ddlRegTerm.SelectedValue);
                            cmd.Parameters.AddWithValue("@sAddedby", Session["CurrentUserName"].ToString());
                            cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
                            cmd.Parameters.AddWithValue("@dCodeCreated", DateTime.Now);
                            cmd.Parameters.AddWithValue("@sTargetLanguage", drp_Target.SelectedItem.Text);
                            cmd.Parameters.AddWithValue("@sMedium", drp_Medium.SelectedItem.Text);
                            try
                            {
                                sc.Open();
                                cmd.ExecuteNonQuery();
                                sc.Close();
                                ieffected++;
                            }
                            catch (Exception ex)
                            {
                                sc.Close();
                                Console.WriteLine("{0} Exception caught.", ex);
                            }
                            finally
                            {
                                sc.Close();                               
                            }
                        }
                        lbl_Msg.Text = ""+ ieffected + " Link(s) Created Successfully";

                        txt_Description.Text = "";

                        txt_Alt_URL.Text = "https://ect.ac.ae/";
                        txt_Date.Text = DateTime.Now.AddYears(5).ToString("dd/MM/yyyy");
                        drp_Status.SelectedIndex = 0;
                        txt_Note.Text = "";
                        int iYear = 0;
                        int iSem = 0;
                        int iTerm = 0;
                        iYear = (int)Session["RegYear"];
                        iSem = (int)Session["RegSemester"];
                        iTerm = iYear * 10 + iSem;
                        ddlRegTerm.SelectedValue = iTerm.ToString();
                        drp_Target.SelectedIndex = 0;
                        drp_Medium.SelectedIndex = 0;

                        div_msg.Visible = true;
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
                lbl_Msg.Text = "Please select any file to upload";
                div_msg.Visible = true;
                return;
            }           
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Link_Manager_Home");
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
    }
}