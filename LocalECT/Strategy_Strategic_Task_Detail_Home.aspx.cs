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
    public partial class Strategy_Strategic_Task_Detail_Home : System.Web.UI.Page
    {
        int CurrentRole = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["CurrentRole"] != null)
                {
                    CurrentRole = (int)Session["CurrentRole"];
                    if (!IsPostBack)
                    {
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Initiative,
                        InitializeModule.enumPrivilege.CS_Execute, CurrentRole) != true)
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
                        string id = Request.QueryString["id"];//iInitiative
                        string sid= Request.QueryString["sid"];//TaskID                        
                        bindStrategic_Task_Detail(sid);
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

        public void bindStrategic_Task_Detail(string sid)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            string sSQL = "";

            sSQL  = " SELECT        CS_Strategic_Task_Detail.iSerial, CS_Strategic_Task_Detail.iPeriod, CS_Strategic_Task_Detail.iSubPeriod, CS_Strategic_Task_Detail.iTask, CS_Strategic_Task_Detail.dStart, CS_Strategic_Task_Detail.dEnd,  ";
            sSQL += "                          CS_Strategic_Task_Detail.iDepartment, CS_Strategic_Task_Detail.iSection, CS_Strategic_Task_Detail.iTaskStatus, CS_Strategic_Task_Detail.iSubmittedEvidence, CS_Strategic_Task_Detail.sNote,  ";
            sSQL += "                          CS_Strategic_Task_Detail.iStrategyVersion, CS_Strategic_Task_Detail.dAdded, CS_Strategic_Task_Detail.sAddedBy, CS_Strategic_Task_Detail.dUpdated, CS_Strategic_Task_Detail.sUpdatedBy,  ";
            sSQL += "                          CS_Strategic_Task_Detail.iEvidence, CS_Strategic_Period.sPeriod, CS_Strategic_Sub_Period.sSubPeriod, CS_Strategic_Task.sTaskID, CS_Strategic_Task.sTaskDesc, CS_Strategic_Task.iInitiative, Lkp_Department.DescEN, Lkp_Department.DepartmentAbbreviation,  ";
            sSQL += "                          Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1, CS_Strategic_Task_Status.sTaskStatus, CS_Strategy_Version.sStrategyVersion, CS_Strategic_Evidence.sEvidenceTitle ";
            sSQL += " FROM            CS_Strategic_Evidence INNER JOIN ";
            sSQL += "                          Lkp_Department INNER JOIN ";
            sSQL += "                          CS_Strategic_Period INNER JOIN ";
            sSQL += "                          CS_Strategic_Task_Detail ON CS_Strategic_Period.iSerial = CS_Strategic_Task_Detail.iPeriod INNER JOIN ";
            sSQL += "                          CS_Strategic_Sub_Period ON CS_Strategic_Task_Detail.iSubPeriod = CS_Strategic_Sub_Period.iSerial INNER JOIN ";
            sSQL += "                          CS_Strategic_Task ON CS_Strategic_Task_Detail.iTask = CS_Strategic_Task.iSerial ON Lkp_Department.DepartmentID = CS_Strategic_Task_Detail.iDepartment INNER JOIN ";
            sSQL += "                          Lkp_Section ON CS_Strategic_Task_Detail.iSection = Lkp_Section.SectionID INNER JOIN ";
            sSQL += "                          CS_Strategic_Task_Status ON CS_Strategic_Task_Detail.iTaskStatus = CS_Strategic_Task_Status.iSerial INNER JOIN ";
            sSQL += "                          CS_Strategy_Version ON CS_Strategic_Task_Detail.iStrategyVersion = CS_Strategy_Version.iSerial INNER JOIN ";
            sSQL += "                          CS_Strategic_Evidence_Submission ON CS_Strategic_Task_Detail.iSubmittedEvidence = CS_Strategic_Evidence_Submission.iSerial ON CS_Strategic_Evidence.iSerial = CS_Strategic_Task_Detail.iEvidence ";
            sSQL += " where iTask=@iTask ";

            SqlCommand cmd = new SqlCommand(sSQL, sc);
            cmd.Parameters.AddWithValue("@iTask", sid);
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
            Response.Redirect("Strategy_Strategic_Task_Detail_Update?id=" + Request.QueryString["id"] + "&sid=" + Request.QueryString["sid"] + "");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Strategy_Strategic_Task_Home?id=" + Request.QueryString["id"] + "");
        }
    }
}