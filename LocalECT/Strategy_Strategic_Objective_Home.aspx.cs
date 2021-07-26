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
    public partial class Strategy_Strategic_Objective_Home : System.Web.UI.Page
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
                        if (LibraryMOD.isRoleAuthorized(InitializeModule.enumPrivilegeObjects.Strategic_Objective,
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
                        bindStrategic_Objective();
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

        public void bindStrategic_Objective()
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            string sSQL = "SELECT CS_Strategic_Objective.iSerial, CS_Strategic_Objective.sStrategicObjectiveID, CS_Strategic_Objective.sStrategicObjectiveDesc, CS_Strategic_Objective.iInspectionComplianceDomain, CS_Strategic_Objective.iOrder, CS_Strategic_Objective.iStrategyVersion, CS_Strategic_Objective.dAdded, CS_Strategic_Objective.sAddedBy, CS_Strategic_Objective.dUpdated, CS_Strategic_Objective.sUpdatedBy, CS_Strategic_Objective.sAbbreviation, CS_Strategic_Objective.iStrategicProject, CS_Strategic_Objective.sImagePath,  CS_Strategic_Objective.iLevel, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID, CS_Strategy_Version.sStrategyVersion, CS_Strategic_Project.sStrategicProjectID FROM CS_Strategic_Objective INNER JOIN CS_Inspection_Compliance_Domain ON CS_Strategic_Objective.iInspectionComplianceDomain = CS_Inspection_Compliance_Domain.iSerial INNER JOIN CS_Strategy_Version ON CS_Strategic_Objective.iStrategyVersion = CS_Strategy_Version.iSerial INNER JOIN CS_Strategic_Project ON CS_Strategic_Objective.iStrategicProject = CS_Strategic_Project.iSerial order by CS_Strategic_Objective.iOrder";
            if (id != null && f != null)
            {
                lnk_Create.Visible = false;
                Img_Header.Visible = true;
                //row1.Style.Add("margin-top", "18% !important");
                Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Strategy/dttable.css") + "\" />"));
                sSQL = "SELECT CS_Strategic_Objective.iSerial, CS_Strategic_Objective.sStrategicObjectiveID, CS_Strategic_Objective.sStrategicObjectiveDesc, CS_Strategic_Objective.iInspectionComplianceDomain, CS_Strategic_Objective.iOrder, CS_Strategic_Objective.iStrategyVersion, CS_Strategic_Objective.dAdded, CS_Strategic_Objective.sAddedBy, CS_Strategic_Objective.dUpdated, CS_Strategic_Objective.sUpdatedBy, CS_Strategic_Objective.sAbbreviation, CS_Strategic_Objective.iStrategicProject, CS_Strategic_Objective.sImagePath,  CS_Strategic_Objective.iLevel, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID, CS_Strategy_Version.sStrategyVersion, CS_Strategic_Project.sStrategicProjectID FROM CS_Strategic_Objective INNER JOIN CS_Inspection_Compliance_Domain ON CS_Strategic_Objective.iInspectionComplianceDomain = CS_Inspection_Compliance_Domain.iSerial INNER JOIN CS_Strategy_Version ON CS_Strategic_Objective.iStrategyVersion = CS_Strategy_Version.iSerial INNER JOIN CS_Strategic_Project ON CS_Strategic_Objective.iStrategicProject = CS_Strategic_Project.iSerial where CS_Strategic_Objective.iSerial="+id+" order by CS_Strategic_Objective.iOrder";
            }
            else
            {
                //row1.Style.Add("margin-top", "0px !important");
                sSQL = "SELECT CS_Strategic_Objective.iSerial, CS_Strategic_Objective.sStrategicObjectiveID, CS_Strategic_Objective.sStrategicObjectiveDesc, CS_Strategic_Objective.iInspectionComplianceDomain, CS_Strategic_Objective.iOrder, CS_Strategic_Objective.iStrategyVersion, CS_Strategic_Objective.dAdded, CS_Strategic_Objective.sAddedBy, CS_Strategic_Objective.dUpdated, CS_Strategic_Objective.sUpdatedBy, CS_Strategic_Objective.sAbbreviation, CS_Strategic_Objective.iStrategicProject, CS_Strategic_Objective.sImagePath,  CS_Strategic_Objective.iLevel, CS_Inspection_Compliance_Domain.sInspectionComplianceDomainID, CS_Strategy_Version.sStrategyVersion, CS_Strategic_Project.sStrategicProjectID FROM CS_Strategic_Objective INNER JOIN CS_Inspection_Compliance_Domain ON CS_Strategic_Objective.iInspectionComplianceDomain = CS_Inspection_Compliance_Domain.iSerial INNER JOIN CS_Strategy_Version ON CS_Strategic_Objective.iStrategyVersion = CS_Strategy_Version.iSerial INNER JOIN CS_Strategic_Project ON CS_Strategic_Objective.iStrategicProject = CS_Strategic_Project.iSerial order by CS_Strategic_Objective.iOrder";
            }
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
                Response.Redirect("Strategy_Strategic_Objective_Update.aspx?f=m&id=" + id + "&t=v");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_Objective_Update.aspx?id=" + id + "&t=v");
            }
        }

        protected void lnk_Edit_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Objective_Update.aspx?f=m&id=" + id + "&t=e");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_Objective_Update.aspx?id=" + id + "&t=e");
            }
        }

        protected void lnk_Substipulation_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string f = Request.QueryString["f"];
            if (id != null && f != null)
            {
                Response.Redirect("Strategy_Strategic_Objective_Sub_Stipulation_Home.aspx?f=m&id=" + id + "");
            }
            else
            {
                Response.Redirect("Strategy_Strategic_Objective_Sub_Stipulation_Home.aspx?id=" + id + "");
            }
        }
    }
}