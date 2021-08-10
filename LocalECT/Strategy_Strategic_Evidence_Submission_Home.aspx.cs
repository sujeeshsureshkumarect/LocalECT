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

namespace LocalECT
{
    public partial class Strategy_Strategic_Evidence_Submission_Home : System.Web.UI.Page
    {
        int CurrentRole = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strRefPage = "";
            if (Request.UrlReferrer != null)
            {
                strRefPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
            }
            else
            {
                Server.Transfer("Authorization.aspx");
            }
            try
            {
                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];
                    if (!IsPostBack)
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Evidence,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        {
                            Server.Transfer("Authorization.aspx");
                        }
                    }
                }
                else
                {
                    Session.RemoveAll();
                    Response.Redirect("Login.aspx");

                }
                if (Session["CurrentUserName"] != null)
                {
                    if (!IsPostBack)
                    {
                        string id = Request.QueryString["id"];
                        if (id != null)
                        {
                            bindStrategic_Evidence_Submission(id);
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
        public void bindStrategic_Evidence_Submission(string id)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            string sSQL = "";
            sSQL += " SELECT        CS_Strategic_Evidence_Submission.iSerial, CS_Strategic_Evidence_Submission.iEvidence, CS_Strategic_Evidence_Submission.iPeriod, CS_Strategic_Evidence_Submission.iSubPeriod,  ";
            sSQL += "                          CS_Strategic_Evidence_Submission.sNote, CS_Strategic_Evidence_Submission.sPath, CS_Strategic_Evidence_Submission.dAdded, CS_Strategic_Evidence_Submission.sAddedBy,  ";
            sSQL += "                          CS_Strategic_Evidence_Submission.dUpdated, CS_Strategic_Evidence_Submission.sUpdatedBy, CS_Strategic_Evidence_Submission.sLink, CS_Strategic_Evidence.sEvidenceRecored, CS_Strategic_Period.sPeriod,  ";
            sSQL += "                          CS_Strategic_Sub_Period.sSubPeriod ";
            sSQL += " FROM            CS_Strategic_Evidence_Submission INNER JOIN ";
            sSQL += "                          CS_Strategic_Evidence ON CS_Strategic_Evidence_Submission.iEvidence = CS_Strategic_Evidence.iSerial INNER JOIN ";
            sSQL += "                          CS_Strategic_Period ON CS_Strategic_Evidence_Submission.iPeriod = CS_Strategic_Period.iSerial INNER JOIN ";
            sSQL += "                          CS_Strategic_Sub_Period ON CS_Strategic_Evidence_Submission.iSubPeriod = CS_Strategic_Sub_Period.iSerial ";
            sSQL += " where CS_Strategic_Evidence_Submission.iEvidence=@iEvidence";

            SqlCommand cmd = new SqlCommand(sSQL, sc);
            cmd.Parameters.AddWithValue("@iEvidence", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
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
        protected void lnk_Create_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (id != null)
            {
                Response.Redirect("Strategy_Strategic_Evidence_Submission_Update.aspx?id=" + id + "");
            }
        }
    }
}