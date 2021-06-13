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
    public partial class Strategy_Strategic_Sub_Period_Home : System.Web.UI.Page
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
                        //if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.LinkManager,
                        //InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        //{
                        //    Server.Transfer("Authorization.aspx");
                        //}
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
                        string sver = Request.QueryString["sver"];
                        if (id != null)
                        {
                            bindStrategic_Sub_Period(id,sver);
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

        public void bindStrategic_Sub_Period(string id,string sver)
        {
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SELECT CS_Strategic_Sub_Period.iSerial, CS_Strategic_Sub_Period.sSubPeriod, CS_Strategic_Sub_Period.iPeriod, CS_Strategic_Sub_Period.iOrder, CS_Strategic_Sub_Period.iStrategyVersion, CS_Strategic_Sub_Period.dAdded, CS_Strategic_Sub_Period.sAddedBy, CS_Strategic_Sub_Period.dUpdated, CS_Strategic_Sub_Period.sUpdatedBy, CS_Strategic_Period.sPeriod, CS_Strategy_Version.sStrategyVersion FROM CS_Strategic_Sub_Period INNER JOIN CS_Strategic_Period ON CS_Strategic_Sub_Period.iPeriod = CS_Strategic_Period.iSerial INNER JOIN CS_Strategy_Version ON CS_Strategic_Sub_Period.iStrategyVersion = CS_Strategy_Version.iSerial where (iPeriod=@iPeriod) and (CS_Strategic_Sub_Period.iStrategyVersion=@iStrategyVersion)", sc);
            cmd.Parameters.AddWithValue("@iPeriod", id);
            cmd.Parameters.AddWithValue("@iStrategyVersion", sver);
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
            string sver = Request.QueryString["sver"];
            Response.Redirect("Strategy_Strategic_Sub_Period_Update?id=" + id + "&sver=" + sver + "");
        }
    }
}