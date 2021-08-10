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
    public partial class Strategy_Strategic_KPI_Detail_Home : System.Web.UI.Page
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
                        string sid = Request.QueryString["sid"];//KPIID                        
                        bindStrategic_KPI_Detail(sid);
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

        public void bindStrategic_KPI_Detail(string sid)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);
            string sSQL = "";

            sSQL = " SELECT         CS_Strategic_KPI_Detail.cSubPeriodTarget,CS_Strategic_KPI_Detail.iSerial, CS_Strategic_KPI_Detail.iPeriod, CS_Strategic_KPI_Detail.iSubPeriod, CS_Strategic_KPI_Detail.cValue, CS_Strategic_KPI_Detail.iKPI, CS_Strategic_KPI_Detail.iDepartment,  ";
            sSQL += "                          CS_Strategic_KPI_Detail.iSection, CS_Strategic_KPI_Detail.iStrategyVersion, CS_Strategic_KPI_Detail.dAdded, CS_Strategic_KPI_Detail.sAddedBy, CS_Strategic_KPI_Detail.dUpdated, CS_Strategic_KPI_Detail.sUpdatedBy,  ";
            sSQL += "                          CS_Strategic_KPI_Detail.iKPIStatus, CS_Strategic_KPI_Detail.sNote, CS_Strategic_Period.sPeriod, CS_Strategic_Sub_Period.sSubPeriod, CS_Strategic_KPI.sKPIID, CS_Strategic_KPI.sKPIDesc, CS_Strategic_KPI.iInitiative, Lkp_Department.DescEN,  ";
            sSQL += "                          Lkp_Department.DepartmentAbbreviation, Lkp_Section.SectionAbbreviation, Lkp_Section.DescEN AS Expr1, CS_Strategy_Version.sStrategyVersion, CS_Strategic_KPI_Status.sKPIStatus ";
            sSQL += " FROM            CS_Strategic_KPI_Status INNER JOIN ";
            sSQL += "                          CS_Strategy_Version INNER JOIN ";
            sSQL += "                          Lkp_Section INNER JOIN ";
            sSQL += "                          CS_Strategic_KPI INNER JOIN ";
            sSQL += "                          CS_Strategic_Sub_Period INNER JOIN ";
            sSQL += "                          CS_Strategic_KPI_Detail INNER JOIN ";
            sSQL += "                          CS_Strategic_Period ON CS_Strategic_KPI_Detail.iPeriod = CS_Strategic_Period.iSerial ON CS_Strategic_Sub_Period.iSerial = CS_Strategic_KPI_Detail.iSubPeriod ON  ";
            sSQL += "                          CS_Strategic_KPI.iSerial = CS_Strategic_KPI_Detail.iKPI INNER JOIN ";
            sSQL += "                          Lkp_Department ON CS_Strategic_KPI_Detail.iDepartment = Lkp_Department.DepartmentID ON Lkp_Section.SectionID = CS_Strategic_KPI_Detail.iSection ON  ";
            sSQL += "                          CS_Strategy_Version.iSerial = CS_Strategic_KPI_Detail.iStrategyVersion ON CS_Strategic_KPI_Status.iSerial = CS_Strategic_KPI_Detail.iKPIStatus ";
            sSQL += " where iKPI=@iKPI ";

            SqlCommand cmd = new SqlCommand(sSQL, sc);
            cmd.Parameters.AddWithValue("@iKPI", sid);
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
            //Response.Redirect("Strategy_Strategic_KPI_Detail_Update?id=" + Request.QueryString["id"] + "&sid=" + Request.QueryString["sid"] + "");
            string f = Request.QueryString["f"];
            if (f != null)
            {               
                Response.Redirect("Strategy_Strategic_KPI_Detail_Update?f=m&id=" + Request.QueryString["id"] + "&sid=" + Request.QueryString["sid"] + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_KPI_Detail_Update?id=" + Request.QueryString["id"] + "&sid=" + Request.QueryString["sid"] + "");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Strategy_Strategic_KPI_Home?id=" + Request.QueryString["id"] + "");
            string f = Request.QueryString["f"];
            if (f != null)
            {                
                Response.Redirect("Strategy_Strategic_KPI_Home?f=m&id=" + Request.QueryString["id"] + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_KPI_Home?id=" + Request.QueryString["id"] + "");
            }
        }

        protected void lnk_View_Click(object sender, EventArgs e)
        {
            //<a href="Strategy_Strategic_KPI_Detail_Update.aspx?id=<%#Eval("iInitiative")%>&sid=<%#Eval("iKPI")%>&did=<%#Eval("iSerial")%>&t=v" class="dropdown-item">View</a> 
            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string commandArgument = button.CommandArgument;
            string CommandName = button.CommandName;
            string tooltip = button.ToolTip;
            string f = Request.QueryString["f"];
            if (f != null)
            {
                Response.Redirect("Strategy_Strategic_KPI_Detail_Update.aspx?f=m&id="+ CommandName + "&sid="+ tooltip + "&did="+ commandArgument + "&t=v");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_KPI_Detail_Update.aspx?id=" + CommandName + "&sid=" + tooltip + "&did=" + commandArgument + "&t=v");
            }            
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //<a href="Strategy_Strategic_KPI_Detail_Update.aspx?id=<%#Eval("iInitiative")%>&sid=<%#Eval("iKPI")%>&did=<%#Eval("iSerial")%>&t=v" class="dropdown-item">View</a> 
            //Get the reference of the clicked button.
            LinkButton button = (sender as LinkButton);

            //Get the command argument
            string commandArgument = button.CommandArgument;
            string CommandName = button.CommandName;
            string tooltip = button.ToolTip;
            string f = Request.QueryString["f"];
            if (f != null)
            {
                Response.Redirect("Strategy_Strategic_KPI_Detail_Update.aspx?f=m&id=" + CommandName + "&sid=" + tooltip + "&did=" + commandArgument + "&t=e");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_KPI_Detail_Update.aspx?id=" + CommandName + "&sid=" + tooltip + "&did=" + commandArgument + "&t=e");
            }
        }
    }
}