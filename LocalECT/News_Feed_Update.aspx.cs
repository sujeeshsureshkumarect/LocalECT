﻿using System;
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
    public partial class News_Feed_Update : System.Web.UI.Page
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
                        string id = Request.QueryString["id"];
                        if (id != null)
                        {
                            bindnewsfeed(id);
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

        public void bindnewsfeed(string id)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from ECT_SIS_News_Feed where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@iSerial", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (dt.Rows.Count > 0)
                {
                    txt_Header.Text = dt.Rows[0]["sHeader"].ToString();
                    txt_Detail.Text = dt.Rows[0]["sDetail"].ToString();
                    txt_Link.Text = dt.Rows[0]["sLink"].ToString();
                    txt_Date.Text = Convert.ToDateTime(dt.Rows[0]["dDate"]).ToString("dd/MM/yyyy");
                    HyperLink1.NavigateUrl = dt.Rows[0]["sAttachment"].ToString();
                    HyperLink1.Text = dt.Rows[0]["sAttachment"].ToString();
                    bool isActive = Convert.ToBoolean(dt.Rows[0]["isActive"]);
                    int boolInt = isActive ? 1 : 0;
                    drp_Status.SelectedIndex = drp_Status.Items.IndexOf(drp_Status.Items.FindByValue(boolInt.ToString()));
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

            SqlCommand cmd = new SqlCommand("update ECT_SIS_News_Feed set sHeader=@sHeader,sDetail=@sDetail,dDate=@dDate,sLink=@sLink,sAttachment=@sAttachment,isActive=@isActive,sUser=@sUser,dCreated=@dCreated where iSerial=@iSerial", sc);
            cmd.Parameters.AddWithValue("@sHeader", txt_Header.Text.Trim());
            cmd.Parameters.AddWithValue("@sDetail", txt_Detail.Text.Trim());
            DateTime date = DateTime.ParseExact(txt_Date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            cmd.Parameters.AddWithValue("@dDate", date);
            cmd.Parameters.AddWithValue("@sLink", txt_Link.Text.Trim());
            string path = "";
            if (flp_Upload.HasFile)
            {
                string extension = Path.GetExtension(flp_Upload.PostedFile.FileName);
                string filename = Path.GetFileName(flp_Upload.PostedFile.FileName);
                flp_Upload.SaveAs(Server.MapPath("~/NewsFeed/" + filename));
                path = "NewsFeed/" + filename;
            }
            else
            {
                path = HyperLink1.NavigateUrl;
            }
            cmd.Parameters.AddWithValue("@sAttachment", path);
            cmd.Parameters.AddWithValue("@isActive", drp_Status.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@sUser", sName);
            cmd.Parameters.AddWithValue("@dCreated", DateTime.Now);
            cmd.Parameters.AddWithValue("@iSerial", Request.QueryString["id"]);
            try
            {
                sc.Open();
                cmd.ExecuteNonQuery();
                sc.Close();

                //txt_Header.Text = "";
                //txt_Detail.Text = "";
                //txt_Link.Text = "";
                //txt_Date.Text = "";
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
            Response.Redirect("News_Feed_Home");
        }
    }
}