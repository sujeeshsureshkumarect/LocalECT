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
    public partial class Link_Manager_Create : System.Web.UI.Page
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
                        InitializeModule.enumPrivilege.AddNew, CurrentRole) != true)
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
                        FillTerms();
                        hdn_sCode.Value = Create16DigitString();

                        //Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
                        //SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
                        //SqlCommand cmd = new SqlCommand("select * from ECT_Link_Management where sCode=@sCode", sc);
                        //cmd.Parameters.AddWithValue("@sCode", Code);
                        //DataTable dt = new DataTable();
                        //SqlDataAdapter da = new SqlDataAdapter(cmd);
                        //try
                        //{
                        //    if (dt.Rows.Count > 0)
                        //    {
                        //        Code = Create16DigitString();
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    sc.Close();
                        //    Console.WriteLine(ex.Message);
                        //}
                        //finally
                        //{
                        //    sc.Close();
                        //}

                        txt_ShortURL.Text = "https://dt.ect.ac.ae/l?q=" + hdn_sCode.Value + "";
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
            var random = new Random();
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

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("insert into ECT_Link_Management values(@sDesc,@sURL,@sAlternativeURL,@sCode,@dExpiry,@isActive,@sSource,@sNote,@iTerm,@sAddedby,@dAdded,@dCodeCreated)", sc);
            cmd.Parameters.AddWithValue("@sDesc", txt_Description.Text.Trim());
            cmd.Parameters.AddWithValue("@sURL", txt_URL.Text.Trim());            
            cmd.Parameters.AddWithValue("@sAlternativeURL", txt_Alt_URL.Text.Trim());
            cmd.Parameters.AddWithValue("@sCode", hdn_sCode.Value);
            DateTime date = DateTime.ParseExact(txt_Date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            cmd.Parameters.AddWithValue("@dExpiry", date);
            cmd.Parameters.AddWithValue("@isActive", drp_Status.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@sSource", drp_Source.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@sNote", txt_Note.Text.Trim());
            cmd.Parameters.AddWithValue("@iTerm", ddlRegTerm.SelectedValue);
            cmd.Parameters.AddWithValue("@sAddedby", Session["CurrentUserName"].ToString());
            cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
            cmd.Parameters.AddWithValue("@dCodeCreated", DateTime.Now);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                lbl_Msg.Text = "Link Created Successfully (" + txt_ShortURL.Text + ")";

                txt_Description.Text = "";
                txt_URL.Text = "";
                txt_Alt_URL.Text = "https://ect.ac.ae/";
                hdn_sCode.Value = Create16DigitString();
                txt_ShortURL.Text = "https://dt.ect.ac.ae/l?q=" + hdn_sCode.Value + "";
                txt_Date.Text = "";
                drp_Status.SelectedIndex = 0;
                txt_Note.Text = "";
                int iYear = 0;
                int iSem = 0;
                int iTerm = 0;
                iYear = (int)Session["RegYear"];
                iSem = (int)Session["RegSemester"];
                iTerm = iYear * 10 + iSem;
                ddlRegTerm.SelectedValue = iTerm.ToString();
                
                div_msg.Visible = true;
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

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Link_Manager_Home");
        }
    }
}