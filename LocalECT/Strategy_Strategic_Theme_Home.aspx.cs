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
    public partial class Strategy_Strategic_Theme_Home : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Theme,
                        InitializeModule.enumPrivilege.ShowBrowse, CurrentRole) != true)
                        {
                            //Server.Transfer("Authorization.aspx");
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
                        string f = Request.QueryString["f"];                        
                        bindStrategic_Theme();
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

        public void bindStrategic_Theme()
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            string sSQL = "SELECT CS_Strategic_Theme.iSerial, CS_Strategic_Theme.sThemeCode, CS_Strategic_Theme.sThemeDesc, CS_Strategic_Theme.iOrder, CS_Strategic_Theme.dAdded, CS_Strategic_Theme.sAddedBy, CS_Strategic_Theme.dUpdated, CS_Strategic_Theme.sUpdatedBy, CS_Strategic_Theme.iStrategyVersion, CS_Strategic_Theme.sAbbreviation, CS_Strategic_Theme.sImagePath, CS_Strategic_Theme.iLevel, CS_Strategy_Version.sStrategyVersion FROM CS_Strategic_Theme INNER JOIN CS_Strategy_Version ON CS_Strategic_Theme.iStrategyVersion = CS_Strategy_Version.iSerial order by CS_Strategic_Theme.iOrder";
            if (id != null && f!=null)
            {
                lnk_Create.Visible = false;
                Img_Header.Visible = true;                
                //row1.Style.Add("margin-top", "18% !important");
                Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Strategy/dttable.css") + "\" />"));
                sSQL = "SELECT CS_Strategic_Theme.iSerial, CS_Strategic_Theme.sThemeCode, CS_Strategic_Theme.sThemeDesc, CS_Strategic_Theme.iOrder, CS_Strategic_Theme.dAdded, CS_Strategic_Theme.sAddedBy, CS_Strategic_Theme.dUpdated, CS_Strategic_Theme.sUpdatedBy, CS_Strategic_Theme.iStrategyVersion, CS_Strategic_Theme.sAbbreviation, CS_Strategic_Theme.sImagePath, CS_Strategic_Theme.iLevel, CS_Strategy_Version.sStrategyVersion FROM CS_Strategic_Theme INNER JOIN CS_Strategy_Version ON CS_Strategic_Theme.iStrategyVersion = CS_Strategy_Version.iSerial where CS_Strategic_Theme.iSerial="+id+ " order by CS_Strategic_Theme.iOrder";
            }
            //else
            //{
            //    row1.Style.Add("margin-top", "0px !important");
            //}
            Connection_StringCLS myConnection_String = new Connection_StringCLS(InitializeModule.EnumCampus.ECTNew);
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["ECTDataNew"].ConnectionString);

            SqlCommand cmd = new SqlCommand(sSQL, sc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sc.Open();
                da.Fill(dt);
                sc.Close();

                if (id != null && f != null)
                {
                    Img_Header.Src = dt.Rows[0]["sImagePath"].ToString();
                }

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

        protected void lnk_View_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Theme_Update.aspx?f=m&id="+ id + "&t=v");
            }
            else
            {
                //Get the reference of the clicked button.
                LinkButton button = (sender as LinkButton);
                //Get the command argument
                string dateWarning = button.CommandArgument;//dateWarning
                Response.Redirect("Strategy_Strategic_Theme_Update.aspx?id=" + dateWarning + "&t=v");
            }
        }

        protected void lnk_Edit_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Theme_Update.aspx?f=m&id=" + id + "&t=e");
            }
            else
            {   //Get the reference of the clicked button.
                LinkButton button = (sender as LinkButton);
                //Get the command argument
                string dateWarning = button.CommandArgument;//dateWarning
                Response.Redirect("Strategy_Strategic_Theme_Update.aspx?id=" + dateWarning + "&t=e");
            }
        }
    }
}