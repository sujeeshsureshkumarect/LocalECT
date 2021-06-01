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
    public partial class Link_Manager_Update : System.Web.UI.Page
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
                        InitializeModule.enumPrivilege.EditUpdate, CurrentRole) != true)
                        {
                           Server.Transfer("Authorization.aspx");
                        }
                    }
                }
                else
                {
                    //showErr("Session is expired, Login again please...");
                    ClearSession();
                    Response.Redirect("Login.aspx");

                }
                //if (Session["CurrentCampus"] != null)
                //{
                //    string sCampus = Session["CurrentCampus"].ToString();
                //    Campus = (InitializeModule.EnumCampus)Session["CurrentCampus"];
                //    //Campus_ddl.SelectedValue = ((int)Campus).ToString();
                //    string sConn = "";
                //    Connection_StringCLS ConnectionString;
                //    switch (Campus)
                //    {
                //        case InitializeModule.EnumCampus.Males:
                //            ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Males);
                //            sConn = ConnectionString.Conn_string;
                //            break;
                //        case InitializeModule.EnumCampus.Females:
                //            ConnectionString = new Connection_StringCLS(InitializeModule.EnumCampus.Females);
                //            sConn = ConnectionString.Conn_string;
                //            break;
                //    }

                //}
                if (Session["CurrentUserName"] != null)
                {
                    sNo = Session["CurrentUserName"].ToString();
                    sName = Session["CurrentUserName"].ToString();
                    if (!IsPostBack)
                    {
                        FillTerms();
                        string id = Request.QueryString["id"];
                        if (id != null)
                        {
                            bindlink(id);
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
        public void bindlink(string id)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from ECT_Link_Management where iLink=@iLink", sc);
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
                    txt_Description.Text = dt.Rows[0]["sDesc"].ToString();
                    txt_URL.Text = dt.Rows[0]["sURL"].ToString();
                    txt_Alt_URL.Text = dt.Rows[0]["sAlternativeURL"].ToString();
                    txt_Date.Text = Convert.ToDateTime(dt.Rows[0]["dExpiry"]).ToString("dd/MM/yyyy");
                    bool isActive = Convert.ToBoolean(dt.Rows[0]["isActive"]);
                    int boolInt = isActive ? 1 : 0;
                    drp_Status.SelectedIndex = drp_Status.Items.IndexOf(drp_Status.Items.FindByValue(boolInt.ToString()));
                    txt_ShortURL.Text = "https://dt.ect.ac.ae/l?q=" + dt.Rows[0]["sCode"].ToString() + "";
                    hyp_Copy.NavigateUrl= "https://dt.ect.ac.ae/l?q=" + dt.Rows[0]["sCode"].ToString() + "";
                    hdn_sCode.Value = dt.Rows[0]["sCode"].ToString();
                    txt_Source.Text = dt.Rows[0]["sSource"].ToString();
                    ddlRegTerm.SelectedIndex = ddlRegTerm.Items.IndexOf(ddlRegTerm.Items.FindByValue(dt.Rows[0]["iTerm"].ToString()));
                    drp_Target.SelectedIndex = drp_Target.Items.IndexOf(drp_Target.Items.FindByText(dt.Rows[0]["sTargetLanguage"].ToString()));
                    drp_Medium.SelectedIndex = drp_Medium.Items.IndexOf(drp_Medium.Items.FindByText(dt.Rows[0]["sMedium"].ToString()));
                    txt_Note.Text = dt.Rows[0]["sNote"].ToString();
                }
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

            SqlCommand cmd = new SqlCommand("update ECT_Link_Management set sDesc=@sDesc,sURL=@sURL,sAlternativeURL=@sAlternativeURL,dExpiry=@dExpiry,isActive=@isActive,sSource=@sSource,sNote=@sNote,iTerm=@iTerm,sAddedby=@sAddedby,dAdded=@dAdded,sTargetLanguage=@sTargetLanguage,sMedium=@sMedium where iLink=@iLink", sc);
            cmd.Parameters.AddWithValue("@sDesc", txt_Description.Text.Trim());
            cmd.Parameters.AddWithValue("@sURL", txt_URL.Text.Trim());
            cmd.Parameters.AddWithValue("@sAlternativeURL", txt_Alt_URL.Text.Trim());
            //cmd.Parameters.AddWithValue("@sCode", hdn_sCode.Value);
            DateTime date = DateTime.ParseExact(txt_Date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            cmd.Parameters.AddWithValue("@dExpiry", date);
            cmd.Parameters.AddWithValue("@isActive", drp_Status.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@sSource", txt_Source.Text.Trim());
            cmd.Parameters.AddWithValue("@sNote", txt_Note.Text.Trim());
            cmd.Parameters.AddWithValue("@iTerm", ddlRegTerm.SelectedValue);
            cmd.Parameters.AddWithValue("@sAddedby", Session["CurrentUserName"].ToString());
            cmd.Parameters.AddWithValue("@dAdded", DateTime.Now);
            cmd.Parameters.AddWithValue("@sTargetLanguage", drp_Target.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@sMedium", drp_Medium.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@iLink", Request.QueryString["id"]);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

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