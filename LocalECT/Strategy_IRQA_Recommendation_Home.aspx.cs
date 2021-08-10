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
    public partial class Strategy_IRQA_Recommendation_Home : System.Web.UI.Page
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
                        string sid = Request.QueryString["sid"];//KPI
                        bindIRQA_Recommendation(sid);
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

        public void bindIRQA_Recommendation(string sid)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            string sSQL = "";
            sSQL  = " SELECT CS_IRQA_Recommendation.iSerial, CS_IRQA_Recommendation.sIRQARecommendation, CS_IRQA_Recommendation.iPeriod, CS_IRQA_Recommendation.iSubPeriod, CS_IRQA_Recommendation.iStrategyVersion,  ";
            sSQL += "                          CS_IRQA_Recommendation.iKPI, CS_IRQA_Recommendation.dAdded, CS_IRQA_Recommendation.sAddedBy, CS_IRQA_Recommendation.dUpdated, CS_IRQA_Recommendation.sUpdatedBy, CS_Strategic_Period.sPeriod,  ";
            sSQL += "                          CS_Strategic_Sub_Period.sSubPeriod, CS_Strategy_Version.sStrategyVersion, CS_Strategic_KPI.sKPIID ";
            sSQL += " FROM            CS_Strategic_KPI INNER JOIN ";
            sSQL += "                          CS_Strategy_Version INNER JOIN ";
            sSQL += "                          CS_Strategic_Sub_Period INNER JOIN ";
            sSQL += "                          CS_IRQA_Recommendation INNER JOIN ";
            sSQL += "                          CS_Strategic_Period ON CS_IRQA_Recommendation.iPeriod = CS_Strategic_Period.iSerial ON CS_Strategic_Sub_Period.iSerial = CS_IRQA_Recommendation.iSubPeriod ON  ";
            sSQL += "                          CS_Strategy_Version.iSerial = CS_IRQA_Recommendation.iStrategyVersion ON CS_Strategic_KPI.iSerial = CS_IRQA_Recommendation.iKPI where iKPI=@iKPI";

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
            string f = Request.QueryString["f"];
            //Response.Redirect("Strategy_IRQA_Recommendation_Update?id=" + Request.QueryString["id"] + "&sid=" + Request.QueryString["sid"] + "");
            if(f!=null)
            {
                Response.Redirect("Strategy_IRQA_Recommendation_Update?f=m&id=" + Request.QueryString["id"] + "&sid=" + Request.QueryString["sid"] + "");
            }
           else
            {
                Response.Redirect("Strategy_IRQA_Recommendation_Update?id=" + Request.QueryString["id"] + "&sid=" + Request.QueryString["sid"] + "");
            }
        }

        protected void lnk_Back_Click(object sender, EventArgs e)
        {            
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if(f!=null)
            {
                Response.Redirect("Strategy_Strategic_KPI_Home.aspx?f=m&id=" + id + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_KPI_Home.aspx?id=" + id + "");
            }            
        }
    }
}